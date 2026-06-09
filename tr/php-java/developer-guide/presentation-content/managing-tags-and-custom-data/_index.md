---
title: PHP Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veriler
type: docs
weight: 300
url: /tr/php-java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da etiketleri ve özel verileri ekleme, okuma, güncelleme ve kaldırma konusunda, PowerPoint ve OpenDocument sunumlarına yönelik örneklerle öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel veri ile nasıl çalıştığını açıklar. PPTX dosyalarında verinin nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerinin nasıl okunacağını ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleneceğini gösterir. Ek olarak, makale tüm etiketleri temizleme, bir etiketi adla kaldırma ve etiket adlarının listesini alma gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantılı öğeler—Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verinin yapısını tanımlar.

*Slide* (slayt), sunumların öğelerinden biridir ve bir *slide part* tek bir slaytın içeriğini barındırır. Bir slide part, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok bölüme açık ilişkiler içerebilir.

Özel veri (bir sunuma özgü) veya kullanıcı, etiketler ([TagCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/)) ve CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/)) şeklinde bulunabilir.

{{% alert color="primary" %}} 
Etiketler temel olarak dize‑anahtar çift değerleridir. 
{{% /alert %}} 

## **Etiket Değerlerini Almak**

Slaytlarda, bir etiket [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getKeywords) ve [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#setKeywords) yöntemlerine karşılık gelir. Bu örnek kod, Aspose.Slides for PHP via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) içinde etiket değerinin nasıl alınacağını gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı - `MyTag`
- özel bir özelliğin değeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerinden gelen tüm sunumları bir araya getirmek veya sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for PHP via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) içine nasıl etiket ekleneceğini gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Etiketler ayrıca [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) için de ayarlanabilir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Veya herhangi bir tekil [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Sınırlamalar**

`getCustomData()->getTags()` kullanılarak özel veri etiket koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyası içinde depolanır. Sunum PDF’ye dışa aktarıldığında bu etiketler PDF etiket yapısına **taşınmaz**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı, etiketli PDF’den alınamaz.

**Geçici Çözüm**: Nesnenin **Alt Text** (örneğin, `$shape->setAlternativeText("MyId")`) içinde bir özel tanımlayıcı depolayabilirsiniz. PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [Tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/clear/) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir defada siler.

**Tüm koleksiyonu döngüye almadan bir etiketin adını kullanarak tek bir etiket nasıl silinir?**

Etiketi anahtarına göre silmek için [tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) üzerindeki [remove(name)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/remove/) işlemini kullanın.

**Analiz veya filtreleme amacıyla etiket adlarının tam listesini nasıl alabilirim?**

Etiket adlarının tam listesini almak için [tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/getnamesoftags/) yöntemini kullanın; bu, tüm etiket adlarını içeren bir dizi döndürür.