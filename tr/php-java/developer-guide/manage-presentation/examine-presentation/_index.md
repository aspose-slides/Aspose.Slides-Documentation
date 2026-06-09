---
title: PHP'de Sunum Bilgilerini Getirme ve Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/php-java/examine-presentation/
keywords:
- sunum biçimi
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
description: "Aspose.Slides for PHP kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve üst verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun geçerli biçimini nasıl belirleyeceğinizi, belge özelliklerini okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) API'lerine dayanır ve sunum üst verileriyle çalışmak için tipik operasyonları gösterir.

## **Sunum Biçimini Kontrol Et**

Bir sunum üzerinde çalışmadan önce, sunumun şu anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun biçimini, sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki PHP koduna bakın:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Sunum Özelliklerini Al**

Bu PHP kodu, sunum özelliklerini (sunum hakkındaki bilgileri) nasıl alacağınızı gösterir:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

[DocumentProperties sınıfı altındaki özellikleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#DocumentProperties--) görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanızı sağlayan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) yöntemini sunar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumu olduğunu varsayalım.

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

Belge özelliklerini değiştirme sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi almak için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme](https://docs.aspose.com/slides/tr/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sunumun Yazma Koruması (salt okunur) olup olmadığını kontrol etme](https://docs.aspose.com/slides/tr/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sunumu yüklemeden önce şifre korumalı olup olmadığını kontrol etme](https://docs.aspose.com/slides/tr/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Sunumu korumak için kullanılan şifreyi doğrulama](https://docs.aspose.com/slides/tr/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**

Sunum düzeyinde [gömülü-yazı tipi bilgisi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girişleri [içerik boyunca gerçekten kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getfonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

[slayt koleksiyonu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) üzerinden döngü kurun ve her slaytın [visibility flag](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/gethidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutunu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getslidesize/) ve yönünü standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına referans verip vermediğini hızlı bir şekilde görmek mümkün mü?**

Evet. Tüm [grafikleri](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/), [veri kaynağını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) kontrol edin ve verinin içsel mi yoksa bağlantı temelli mi olduğunu, kırık bağlantılar dahil, not edin.

**Render veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını sayın ve büyük görüntüler, şeffaflık, gölgeler, animasyonlar ve multimedya öğeleri arayın; potansiyel performans darboğazlarını işaretlemek için kaba bir karmaşıklık puanı atayın.