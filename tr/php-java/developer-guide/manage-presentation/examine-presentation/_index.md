---
title: PHP'de Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun mevcut formatını nasıl belirleyeceğinizi, belge özelliklerini okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) API'lerine dayanmaktadır ve sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Sunum Formatını Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Bu PHP koduna bakın:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Sunum Özelliklerini Al**

Bu PHP kodu, sunum özelliklerini (sunum hakkında bilgi) nasıl alacağınızı gösterir:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

[DocumentProperties altındaki özellikleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#DocumentProperties--) sınıfı içinde görebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza izin veren [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için bu bağlantılar faydalı olabilir:

- [Şifreyle Korunan Sunumlar](/slides/tr/php-java/password-protected-presentation/)
- [Yazma Korumalı Sunumlar](/slides/tr/php-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [gömülü yazı tipi bilgilerini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girişleri [içerik boyunca gerçekten kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getfonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin oluşturma için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve kaç tanesi olduğunu nasıl hızlıca öğrenebilirim?**

[slayt koleksiyonunu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) yineleyin ve her slaydın [görünürlük bayrağını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/gethidden/) inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutunu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getslidesize/) ve yönünü standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görmek için bir yol var mı?**

Evet. Tüm [grafikleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) dolaşın, [veri kaynağını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) kontrol edin ve verinin dahili mi yoksa bağlantı temelli mi olduğunu, ayrıca kırık bağlantıları da not edin.

**Renderleme veya PDF dışa aktarma süresini yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını sayın ve büyük görseller, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini arayın; potansiyel performans darboğazlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.