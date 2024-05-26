İşleyiş şekli şudur:
Input modeldeki kelimenin tüm koordinatlarına bakmamıza gerek yok bir kelimenin sol üst koordinatları o kelimenin tam lokasyonu için yeterli.
Gelen json stringindeki kelimelerin sırası da resimdeki hali ile uyuşuyor olsaydı algoritma çok daha basit olabilirdi fakat örnek json stringinde görüldüğü üzere 11. satıdaki 08*5.50 stringi kendi sırasında değil.
Bu durum gelen json sırasına güvenilmemesi gerektiğini düşündürdüğü için bir kelimenin hangi satırda bulundugunun koordinata göre hesaplanması/bulunması ve kelimelerin ayrıca x eksenine göre de sıralanmasını gerekli kılıyor. 
Kelimelerin satırını ortalama satır yüksekliğine göre bulabiliriz. Ortalama satır yüksekliği de gelen json stringindeki satırların arasındaki boşlukları yorumlayarak bulunabilir. 

![image](https://github.com/edbalta/OCRInterpreter/assets/24252480/c1e0cf8d-097a-40a9-9f47-7790e6c59df8)


Bu küçük kümede 2 satır arası minimum fark 22. Ben satır yüksekliğini yukarıdan 12 ve aşağıdan 12 toplam 24 olacak şekilde seçtim. Yani y değeri 123 olan kelime ile y değeri 134 olan kelime aynı satırda fakat 135 olan kelime aynı satırda değildir şeklinde varsayılabilir.
Fakat daha fazla buruşmuş bir fişte iki kelime aynı satırda olmasına rağmen bir kelime daha aşağıda bulunabileceği için bu 12 değeri 20ye kadar yükseltilebilir.
