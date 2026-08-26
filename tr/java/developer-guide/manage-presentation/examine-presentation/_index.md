---
title: Java'da Sunum Bilgilerini Alın ve Güncelleyin
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
description: "Java kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden mevcut biçimini nasıl belirleyeceğinizi, belge özelliklerini nasıl okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/) API'lerine dayanmaktadır ve sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Sunum Biçimini Kontrol Etme**

Bir sunumla çalışmadan önce, mevcut olarak hangi biçimde (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun biçimini, sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki Java koduna bakın:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Sunum Özelliklerini Almak**

Bu Java kodu, sunum özelliklerini (sunum hakkındaki bilgileri) nasıl alacağınızı gösterir:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

[DocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/documentproperties/#DocumentProperties--) sınıfındaki özellikleri görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelleme**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yöntemini sağlar.

Aşağıdaki gibi belge özellikleri gösterilen bir PowerPoint sunumumuz olduğunu varsayalım.

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

Bir sunum ve güvenlik nitelikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Parola Korumalı Sunumlar](/slides/tr/java/password-protected-presentation/)
- [Yazma Koruması Olan Sunumlar](/slides/tr/java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunum düzeyinde [embedded-font information](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) arayın, ardından bu girdileri içerik boyunca kullanılan [fonts actually used across content](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getFonts--) ile karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

[slide collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/) üzerinden yineleyin ve her slaydın [visibility flag](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getHidden--) özelliğini inceleyin.

**Özel slayt boyutu ve yönlendirmesi kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlideSize--) ve yönlendirmeyi standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını önceden tahmin etmenize yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurduğunu hızlıca görebilir miyim?**

Evet. Tüm [charts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/) üzerinde dolaşın, [data source](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) öğesini kontrol edin ve verinin dahili mi yoksa bağlantı‑tabanlı mı olduğunu, ayrıca kırık bağlantılar olup olmadığını not edin.

**Render veya PDF dışa aktarma sırasında yavaşlayabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını sayın ve büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini arayın; potansiyel performans sorunlarını işaretlemek için kaba bir karmaşıklık puanı atayın.