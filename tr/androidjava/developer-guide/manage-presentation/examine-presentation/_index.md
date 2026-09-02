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
description: "Java kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun mevcut formatını nasıl belirleyeceğinizi, belge özelliklerini okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/) API'lerine dayanmaktadır ve sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Sunum Formatını Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki Java koduna bakın:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

DocumentProperties sınıfı altındaki [özellikleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) görebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanızı sağlayan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metodunu sunar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Belge özelliklerini değiştirme sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumları Parola ile Koruma](/slides/tr/androidjava/password-protected-presentation/)
- [Sunumları Yazma Korumasıyla Koruma](/slides/tr/androidjava/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [gömülü yazı tipi bilgisi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) arayın, ardından bu girdileri [içerikte gerçek olarak kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getFonts--) ile karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

[slayt koleksiyonunu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/) dolaşın ve her bir slaydın [görünürlük bayrağını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getHidden--) inceleyin.

**Özel slayt boyutu ve yönü kullanılıp kullanılmadığını ve bunların varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutunu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideSize--) ve yönünü standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurduğunu hızlıca görebileceğim bir yol var mı?**

Evet. Tüm [grafikleri](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/) gezinin, [veri kaynaklarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) kontrol edin ve verinin dahili mi yoksa bağlantı temelli mi olduğunu, kırık bağlantılar dahil, not edin.

**Render'ı veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her bir slayt için nesne sayılarını toplayın ve büyük görüntüler, şeffaflık, gölgeler, animasyonlar ve multimedya gibi öğelere bakın; potansiyel performans sorunlarını işaretlemek için kaba bir karmaşıklık puanı atayın.