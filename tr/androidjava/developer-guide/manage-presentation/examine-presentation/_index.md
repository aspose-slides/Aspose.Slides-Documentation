---
title: Android'de Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Java kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun mevcut formatını belirleme, belge özelliklerini okuma ve gerektiğinde bu özellikleri güncelleme yöntemlerini açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/) API'lerine dayanmakta ve sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Sunum Formatını Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki Java koduna bakın:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Sunum Özelliklerini Al**

Bu Java kodu, sunum özelliklerini (sunum hakkında bilgi) nasıl alacağınızı gösterir:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

DocumentProperties sınıfı altındaki [DocumentProperties sınıfı altındaki özellikler](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanızı sağlayan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metodunu sunar.

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

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar yararlı olabilir:

- [Sunumun Şifreli Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sunumun Yazma Koruması (salt okunur) Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sunumu Yüklemeden Önce Parola Koruması Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Sunumu Koruyan Parolayı Doğrulama](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [gömülü-yazı tipi bilgisi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) bilgisine bakın, ardından bu girişleri [içerikte gerçekte kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getFonts--) içinde kullanılan yazı tipleriyle karşılaştırarak görüntüleme için kritik olan yazı tiplerini belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

[slayt koleksiyonu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/) üzerinden döngü yapın ve her slaydın [görünürlük bayrağı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getHidden--) özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideSize--) ve yönelimi standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görebilir miyim?**

Evet. Tüm [grafikler](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/) üzerinde gezinin, [veri kaynağı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) öğelerini kontrol edin ve verinin dahili mi yoksa bağlantı tabanlı mı olduğunu, kırık bağlantılar dahil, not alın.

**Renderlama veya PDF dışa aktarımı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını toplayın ve büyük görseller, saydamlık, gölgeler, animasyonlar ve multimedya gibi öğelere bakın; potansiyel performans sorunlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.