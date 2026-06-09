---
title: Java'da Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/java/examine-presentation/
keywords:
- sunum formatı
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden mevcut biçimini belirlemeyi, belge özelliklerini okumayı ve gerektiğinde bu özellikleri güncellemeyi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/) API'lerine dayanmaktadır ve sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Sunum Biçimini Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi biçimde (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun biçimini, sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki Java koduna bakın:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Sunum Özelliklerini Al**

Bu Java kodu, sunum özelliklerini (sunumla ilgili bilgiler) nasıl alacağınızı gösterir:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

[DocumentProperties sınıfının özelliklerini](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#DocumentProperties--) görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metodunu sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Belge özelliklerini değiştirme sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik nitelikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Et](https://docs.aspose.com/slides/tr/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Bir Sunumun Yazma Koruması (yalnızca okunur) olup olmadığını Kontrol Et](https://docs.aspose.com/slides/tr/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Bir Sunumun Yüklemeden Önce Şifreyle Korunup Korunmadığını Kontrol Et](https://docs.aspose.com/slides/tr/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bir Sunumu Korumak İçin Kullanılan Şifreyi Doğrulama](https://docs.aspose.com/slides/tr/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Sunularda gömülü fontların olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**  
Sunum düzeyinde [embedded-font bilgilerini](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) arayın, ardından bu girişleri [içerik genelinde gerçekten kullanılan fontlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getFonts--) ile karşılaştırarak hangi fontların render için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu nasıl hızlıca öğrenebilirim?**  
[slide collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/) içinde döngü kurun ve her slaydın [visibility flag](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getHidden--) özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**  
Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlideSize--) ve yönelimi standart ön ayarlarla karşılaştırın; bu, baskı ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına referans verip vermediğini hızlıca görmenin bir yolu var mı?**  
Evet. Tüm [charts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/) üzerinden geçin, [data source](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) özelliklerini kontrol edin ve verinin içsel mi yoksa bağlantı temelli mi olduğunu, kırık bağlantılar dahil, not edin.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**  
Her slayt için nesne sayılarını sayın, büyük görüntüler, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini izleyin; potansiyel performans sorunlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.