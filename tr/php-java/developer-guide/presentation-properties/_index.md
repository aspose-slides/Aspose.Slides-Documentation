---
title: PHP'de Sunum Özelliklerini Yönetme
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
- özellikleri değiştir
- belge üst verileri
- üst verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java içinde sunum özelliklerini ustalaştırın ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaştırmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisine de Aspose.Slides API’si ile kolayca erişebilir ve yönetebilirsiniz.

Aspose.Slides, sunum belge özellikleriyle **[DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/)** sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, **[Presentation::getDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDocumentProperties)** yöntemi ile döndürülür. Aşağıdaki örnekler, bu özellikleri okuma, değiştirme ve yönetme yollarını gösterir.

{{% alert color="primary" %}} 

Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini, bu alanların her zaman "Aspose Ltd." ve "Aspose.Slides for PHP via Java x.x.x" değerlerini göstereceğini unutmayın.

{{% /alert %}} 

## **Sunum Özelliklerini Yönetme**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte faydalı bilgilerin saklanmasına olanak tanır. İki tür belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler ise kullanıcılar tarafından **Ad/Değer** çiftleri şeklinde tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for PHP via Java kullanarak, geliştiriciler hem yerleşik hem de özel özelliklerin değerlerine erişebilir ve bunları değiştirebilir.

## **PowerPoint’te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklamak ve **Prepare | Properties | Advanced Properties** menü öğesini seçmektir; aşağıda gösterildiği gibi:

|**Gelişmiş Özellikler menü öğesini seçme**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Gelişmiş Özellikler** menü öğesini seçtikten sonra, aşağıdaki şekildeki gibi PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Yukarıdaki **Özellikler İletişim Kutusu**’nda, **Genel**, **Özet**, **İstatistikler**, **İçerikler** ve **Özel** gibi birçok sekme sayfası gördüğünüzü fark edeceksiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı türde bilgilerin yapılandırılmasına izin verir. **Özel** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

### Aspose.Slides for PHP via Java ile Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi Aspose.Slides for PHP via Java, **Yerleşik** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Böylece geliştiriciler, Aspose.Slides for PHP via Java API’si sayesinde her iki tür özelliğe de erişebilir. Aspose.Slides for PHP via Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasına ilişkin belge özelliklerini temsil eden **[DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties)** sınıfını sunar.

Geliştiriciler, **[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation)** nesnesinin sunduğu **DocumentProperties** özelliğini kullanarak aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişebilir:

## **Yerleşik Özelliklere Erişim**

**[DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties)** nesnesi tarafından sunulan bu özellikler şunlardır: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```php
  # Sunumu temsil eden Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    $dp = $pres->getDocumentProperties();
    # Yerleşik özellikleri görüntüle
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar basittir. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri güncellenir. Aşağıda verilen örnekte, Aspose.Slides for PHP via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösteriyoruz.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
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

|**Değiştirme Sonrası Yerleşik Belge Özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for PHP via Java, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de izin verir. Aşağıdaki örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını gösterir.

```php
  $pres = new Presentation();
  try {
    # Belge Özelliklerini Alıyor
    $dProps = $pres->getDocumentProperties();
    # Özel özellikler ekliyor
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Belirli bir indekste özellik adını alıyor
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Seçilen özelliği kaldırıyor
    $dProps->removeCustomProperty($getPropertyName);
    # Sunumu kaydediyor
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Eklenen Özel Belge Özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişme ve Değiştirme**

Aspose.Slides for PHP via Java, geliştiricilerin özel özelliklerin değerlerine erişmesini de sağlar. Aşağıda, bir sunum için tüm bu özel özelliklere nasıl erişebileceğinizi ve değiştirebileceğinizi gösteren bir örnek bulunmaktadır.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    $dp = $pres->getDocumentProperties();
    # Özel özelliklere eriş ve değiştir
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Özel özelliklerin adlarını ve değerlerini görüntüle
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

Bu örnek, **[PPTX ](https://docs.fileformat.com/presentation/pptx/)** sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, değiştirme öncesi ve sonrası sunum özel özelliklerini gösterir:

|**Değiştirme Öncesi Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değiştirme Sonrası Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="primary" %}} 

Yeni yöntemler **[readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)**, **[updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)** ve **[writeBindedPresentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)**, **[PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo)** sınıfına eklenmiştir; **[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#setLastSavedTime)** özelliği ayarlayıcısının mantığı değiştirilmiştir.

{{% /alert %}} 

Yeni eklenen iki yöntem **[readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)** ve **[updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)**, **[PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo)** sınıfına eklenmiştir. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye imkan tanır.

Tipik senaryo: özellikleri yükle, bir değeri değiştir ve belgeyi güncelle. Aşağıdaki şekilde uygulanabilir:

```php
  # sunumun bilgilerini oku
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # mevcut özellikleri al
  $props = $info->readDocumentProperties();
  # Yazar ve Başlık alanlarının yeni değerlerini ayarla
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # sunumu yeni değerlerle güncelle
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemenin bir başka yolu da vardır:

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

## **Düzeltme Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanıyan **LanguageId** özelliğini (**PortionFormat** sınıfı tarafından ortaya konur) sağlar. Düzeltme dili, PowerPoint’te yazım ve dilbilgisi denetiminin yapıldığı dildir.

Bu PHP kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// düzeltme dilinin kimliğini ayarla

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Varsayılan Dil Ayarlama**

Bu PHP kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Yeni bir dikdörtgen şekli ve metin ekler
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # İlk bölümün dilini kontrol eder
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API’si üzerinden nasıl çalışılacağını görmek için çevrimiçi **[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata)** uygulamasını deneyin:

[![PowerPoint Metadata’ı Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir yerleşik özelliği sunumdan nasıl kaldırabilirim?**

Yerleşik özellikler sunumun bütünleşik bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa değerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özelliği eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, **[PresentationFactory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/)** sınıfının `getPresentationInfo` yöntemini kullanarak sunumu tamamen yüklemeden özelliklere erişebilirsiniz. Ardından, **[PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/)** sınıfının `readDocumentProperties` yöntemini kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu sağlayabilir ve performansı artırabilirsiniz.