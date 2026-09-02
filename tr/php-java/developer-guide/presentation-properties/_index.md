---
title: PHP'de Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/php-java/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönet
- özellikleri değiştirme
- belge meta verileri
- meta verileri düzenle
- denetleme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisine de Aspose.Slides API'si kullanılarak kolayca erişebilir ve yönetebilirsiniz.

Aspose.Slides, belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDocumentProperties) yöntemiyle döndürülür. Aşağıdaki örnekler, bu özellikleri okuma, değiştirme ve yönetme yollarını gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar, bu yüzden kaydedilen sunum her zaman "Aspose.Slides for PHP via Java" ve onu oluşturan kütüphanenin sürümünü bildirir. `setNameOfApplication`'a geçirilen herhangi bir değer sunum yazıldığında göz ardı edilir.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte bazı faydalı bilgilerin saklanmasına olanak tanır. İki çeşit belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler ise kullanıcılar tarafından **Ad/Değer** çiftleri olarak tanımlanan özelliklerdir; hem ad hem de değer kullanıcı tarafından belirlenir. Aspose.Slides for PHP via Java kullanarak, geliştiriciler yerleşik ve özel özelliklerin değerlerine erişebilir ve bunları değiştirebilir.

## **PowerPoint'te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken Office simgesine tıklamak ve ardından **Prepare | Properties | Advanced Properties** menü öğesini seçmektir; aşağıda gösterildiği gibi:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde PowerPoint dosyasının belge özelliklerini yönetmenize olanak tanıyan bir iletişim kutusu görüntülenir:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Özellikler İletişim Kutusu**'nda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

### Aspose.Slides for PHP via Java ile Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi Aspose.Slides for PHP via Java, **Yerleşik** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Bu nedenle geliştiriciler, Aspose.Slides for PHP via Java API'si kullanarak her iki özellik türüne de erişebilir. Aspose.Slides for PHP via Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasına ilişkin belge özelliklerini temsil eden bir [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties) sınıfı sağlar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) nesnesinin sunduğu **DocumentProperties** özelliğini kullanabilirler:

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties) nesnesi tarafından sunulan bu özellikler şunlardır: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```php
  # Sunumu temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkilendirilmiş IDocumentProperties nesnesine bir referans oluşturun
    $dp = $pres->getDocumentProperties();
    # Yerleşik özellikleri göster
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik özellikleri değiştirmek, onlara erişmek kadar basittir. İstediğiniz bir özelliğe bir dize değer atamanız yeterlidir; böylece özellik değeri güncellenir. Aşağıdaki örnekte, Aspose.Slides for PHP via Java kullanarak bir sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösteriyoruz.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkilendirilmiş IDocumentProperties nesnesine bir referans oluştur
    $dp = $pres->getDocumentProperties();
    # Yerleşik özellikleri ayarla
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Sunumunuzu bir dosyaya kaydedin
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu örnek, aşağıda gösterildiği gibi değiştirilen yerleşik özellikleri sunar:

|**Değiştirmeden Sonra Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for PHP via Java ayrıca geliştiricilerin sunum belge özellikleri için özel değerler eklemesine olanak tanır. Aşağıdaki örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını gösterir.

```php
  $pres = new Presentation();
  try {
    # Belge Özelliklerini Alıyor
    $dProps = $pres->getDocumentProperties();
    # Özel özellikler ekleme
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Belirli bir indeksteki özellik adını alıyor
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Seçilen özelliği kaldırma
    $dProps->removeCustomProperty($getPropertyName);
    # Sunumu kaydetme
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Eklenen Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for PHP via Java ayrıca geliştiricilerin özel özelliklerin değerlerine erişmesini sağlar. Aşağıdaki örnek, bir sunum için bu özel özelliklerin nasıl erişilip değiştirilebileceğini gösterir.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkilendirilmiş DocumentProperties nesnesine bir referans oluştur
    $dp = $pres->getDocumentProperties();
    # Özel özelliklere eriş ve değiştir
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Özel özelliklerin adlarını ve değerlerini göster
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Özel özelliklerin değerlerini değiştir
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Sunumunuzu bir dosyaya kaydedin
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu örnek, bir [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, değişiklik öncesi ve sonrası sunumun özel özelliklerini gösterir:

|**Değiştirmeden Önceki Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değiştirmeden Sonraki Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Note" %}}
Yeni yöntemler [readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ve [writeBindedPresentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation), [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo) sınıfına eklendi; ayrıca [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#setLastSavedTime) özelliğinin ayarlayıcısının mantığı değiştirildi.
{{% /alert %}}

İki yeni yöntem [readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) ve [updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo) sınıfına eklendi. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı tanır.

Tipik senaryo: özellikleri yükle, bir değeri değiştir ve belgeyi güncelle; aşağıdaki gibi uygulanabilir:

```php
  # sunumun bilgilerini oku
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # geçerli özellikleri elde et
  $props = $info->readDocumentProperties();
  # Yazar ve Başlık alanlarının yeni değerlerini ayarla
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # sunumu yeni değerlerle güncelle
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanıp diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Denetleme Dilini Ayarlama**

Aspose.Slides, PowerPoint belgesi için denetleme dilini ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Denetleme dili, PowerPoint içinde yazım ve dilbilgisi denetiminin yapıldığı dildir.

Bu PHP kodu, bir PowerPoint için denetleme dilinin nasıl ayarlanacağını gösterir: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN"); // denetleme dilinin kimliğini ayarla

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Varsayılan Dili Ayarlama**

Bu PHP kodu, bir PowerPoint sunumunun tümü için varsayılan dilin nasıl ayarlanacağını gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Yeni bir dikdörtgen şekil ekle ve metin ekle
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # İlk bölüm dilini kontrol eder
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Canlı Örnek**

Aspose.Slides API'siyle belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama **Aspose.Slides Metadata**'yı deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Bununla birlikte, belirli bir özelliğin izin verdiği durumlarda değerini değiştirebilir veya boş bırakabilirsiniz.

**Var olan bir özel özelliği eklersem ne olur?**

Var olan bir özel özelliği eklediğinizde, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden silmeniz veya kontrol etmeniz gerekmez; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunum özelliklerine, sunumu tam olarak yüklemeden erişebilir miyim?**

Evet. Öncelikle [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) ardından da [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özel sınırlamalar için [/slides/tr/php-java/examine-presentation/](/slides/tr/php-java/examine-presentation/) bölümüne bakın.