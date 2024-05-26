İşleyiş şekli şudur:
Input modeldeki kelimenin tüm koordinatlarına bakmamıza gerek yok bir kelimenin sol üst koordinatları o kelimenin tam lokasyonu için yeterli.
Gelen json stringindeki kelimelerin sırası da resimdeki hali ile uyuşuyor olsaydı algoritma çok daha basit olabilirdi fakat örnek json stringinde görüldüğü üzere 11. satıdaki 08*5.50 stringi kendi sırasında değil.
Bu durum gelen json sırasına güvenilmemesi gerektiğini düşündürdüğü için bir kelimenin hangi satırda bulundugunun koordinata göre hesaplanması/bulunması ve kelimelerin ayrıca x eksenine göre de sıralanmasını gerekli kılıyor. 
Kelimelerin satırını ortalama satır yüksekliğine göre bulabiliriz. Ortalama satır yüksekliği de gelen json stringindeki satırların arasındaki boşlukları yorumlayarak bulunabilir. 

satır	min	max		minmax fark
1	    88	88		  0
2	    114	123		  9
3	    142	149		  7
4	    170	171		  1
5	    195	201		  6
6	    247	249		  2
7	    272	276		  4
8	    294	301		  7
9	    352	352		  0
10	  375	377		  2
11	  401	406		  5
12	  426	426		  0
13	  449	452		  3
14	  474	476		  2

Bu küçük kümede 2 satır arası minimum fark 22. Ben satır yüksekliğini yukarıdan 12 ve aşağıdan 12 toplam 24 olacak şekilde seçtim. Yani y değeri 123 olan kelime ile y değeri 134 olan kelime aynı satırda fakat 135 olan kelime aynı satırda değildir şeklinde varsayılabilir.
Fakat daha fazla buruşmuş bir fişte iki kelime aynı satırda olmasına rağmen bir kelime daha aşağıda bulunabileceği için bu 12 değeri 20ye kadar yükseltilebilir.
