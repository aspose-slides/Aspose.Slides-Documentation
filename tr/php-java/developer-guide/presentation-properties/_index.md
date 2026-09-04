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
- özellikleri değiştir
- belge meta verileri
- meta verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da sunum özelliklerini yöneterek PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını düzenleyin."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDocumentProperties) yöntemi tarafından döndürülür. Aşağıdaki örnekler bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides, her kaydetmede bu alanları yeniden yazar, bu nedenle kaydedilen bir sunum her zaman "Aspose.Slides for PHP via Java" ve onu oluşturan kütüphanenin sürümünü rapor eder. `setNameOfApplication` yöntemine geçirilen herhangi bir değer, sunum yazıldığında göz ardı edilir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte faydalı bilgilerin saklanmasına olanak tanır. Aşağıdaki iki tür belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) 
- Kullanıcı Tanımlı (Özel) 

**Yerleşik** özellikler, belge başlığı, yazarın adı, belge istatistikleri vb. gibi belgeyle ilgili genel bilgileri içerir. **Özel** özellikler, kullanıcıların **Ad/Değer** çiftleri olarak tanımladığı, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for PHP via Java kullanılarak geliştiriciler hem yerleşik hem de özel özelliklerin değerlerine erişebilir ve bunları değiştirebilir.

## **PowerPoint'te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterildiği gibi PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Özellikler İletişim Kutusu**'nda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekmeler, PowerPoint dosyalarına ilişkin farklı bilgi türlerini yapılandırmaya olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

Aspose.Slides for PHP via Java Kullanarak Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi, Aspose.Slides for PHP via Java iki tür belge özelliğini destekler: **Yerleşik** ve **Özel** özellikler. Bu nedenle geliştiriciler, Aspose.Slides for PHP via Java API'sini kullanarak her iki tür özelliğe de erişebilir. Aspose.Slides for PHP via Java, bir sunum dosyasıyla ilişkili belge özelliklerini **Presentation.DocumentProperties** özelliği aracılığıyla temsil eden [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties) sınıfını sağlar.

Geliştiriciler, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) nesnesi tarafından sunulan **DocumentProperties** özelliğini kullanarak aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişebilir:

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemine `false` geçirilerek şifrelendiğinde, belge özellikleri hâlâ genel kalır. Bir uygulama daha sonra [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) yöntemine `true` geçirerek açma parolasını sağlamadan genel meta verileri okuyabilir.

document-properties-only seçeneği, Aspose.Slides'in neyi yükleyeceğini kontrol eder; herhangi bir şeyi çözmez. Özellikler şifreleme içine dahil edilmişse, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Aşağıdaki örnek, [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) yöntemiyle yükleme modunu doğrular ve ardından [Presentation::getDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDocumentProperties) üzerinden yerleşik özellikleri okur:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Bu modda slayt içeriği yüklenmez. Slaytlar, ana slaytlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) yöntemini kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Bunları yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel olarak bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, belge-özellikleri-yalnızca modunda yüklenen bir sunum, genel meta verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca meta veri nesnesindeki değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme doğru açma parolasını ve tam bir yüklemeyi gerektirir.

Aşağıdaki örnek, [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) yöntemiyle sunumu açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından, şifrelemenin korunduğunu doğrulamak için [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isEncrypted) kullanır ve yeni değerleri doğrulamak için genel meta verileri parolasız yeniden açar:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Bir uygulamaya sunum içeriğini çözme veya yükleme izni verilmezse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties) nesnesi tarafından sunulan: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

```php
  # Sunumu temsil eden Presentation sınıfını örnekle
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe basitçe bir dize değeri atayabilirsiniz ve özellik değeri değişir. Aşağıda verilen örnekte, Aspose.Slides for PHP via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

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

Bu örnek, aşağıda gösterildiği gibi sunumun yerleşik özelliklerini değiştirir:

|**Değiştirme Sonrası Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for PHP via Java, geliştiricilerin sunum Belge özellikleri için özel değerler eklemesine de izin verir. Aşağıda bir örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını göstermektedir.

```php
  $pres = new Presentation();
  try {
    # Belge Özelliklerini Alma
    $dProps = $pres->getDocumentProperties();
    # Özel özellikler ekleme
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Belirli bir indeksdeki özelliğin adını alma
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

|**Eklenmiş Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for PHP via Java, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıda bir örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini göstermektedir.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    $dp = $pres->getDocumentProperties();
    # özel özelliklere eriş ve değiştir
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # özel özelliklerin adlarını ve değerlerini göster
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # özel özelliklerin değerlerini değiştir
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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki şekiller, değiştirme öncesi ve sonrası sunumun özel özelliklerini göstermektedir:

|**Değiştirme Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değiştirme Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Note" %}}
Yeni yöntemler [readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ve [writeBindedPresentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation), [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo) sınıfına eklendi, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#setLastSavedTime) özelliği ayarlayıcısının mantığı değiştirildi.
{{% /alert %}} 

İki yeni yöntem [readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) ve [updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PresentationInfo) sınıfına eklendi. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye izin verir.

Tipik senaryo, özellikleri yüklemek, bir değeri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

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

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumların özelliklerini güncellemenin başka bir yolu vardır:

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

## **Denetleme Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için denetleme dili ayarlamanıza izin veren LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Denetleme dili, PowerPoint'te imla ve dilbilgisinin kontrol edildiği dildir.

Bu PHP kodu, bir PowerPoint için denetleme dilinin nasıl ayarlanacağını gösterir: xxx LanguageId'nin Java PortionFormat sınıfından neden eksik olduğu?

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
    $portionFormat->setLanguageId("zh-CN");// bir denetleme dilinin kimliğini ayarla

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Varsayılan Dil Ayarlama**

Bu PHP kodu, bir PowerPoint sunumunun tamamı için varsayılan dilin nasıl ayarlanacağını gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Yeni bir dikdörtgen şekil ekleyip metin ekler
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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyin ve Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görün:

[![PowerPoint Meta Verisini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özelliğin izin vermesi durumunda değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) kullanın ve ardından [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) ile bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özelliği sınırlamaları için [Build a Lightweight Presentation Inventory](/slides/tr/php-java/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Belge‑özelliği şifrelemesi, sunum şifrelenmeden önce devre dışı bırakılmış olmalı ve sunum belge‑özellikleri‑yalnızca modunda yüklenmelidir.

**Belge‑özellikleri‑yalnızca modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam sunumu yüklemeyi gerektirir.