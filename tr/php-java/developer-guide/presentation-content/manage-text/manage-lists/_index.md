---
title: PHP Kullanarak Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 60
url: /tr/php-java/manage-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resimli madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getParagraphFormat--) metodunu kullanın. Ana giriş noktası, bir [BulletFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/) nesnesi döndüren [ParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getBullet--) metodudur. Bu nesne ile madde işareti türünü, sembolünü, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale şunları gösterir:

- özel bir sembol ile madde işaretli liste oluşturmak
- resimli madde işareti oluşturmak
- paragraf derinliğini ayarlayarak çok seviyeli liste oluşturmak
- numaralı liste oluşturmak
- varolan bir sunumda liste biçimlendirmesini incelemek ve değiştirmek

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içine [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) nesneleri ekleyin ve [BulletFormat.setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) metodunu [BulletType.Symbol](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/#Symbol) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [BulletFormat.setChar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#getColor--) ve [BulletFormat.setHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setHeight-float-) metodlarını kullanabilirsiniz.

Aşağıdaki PHP kodu, bir slaytta madde işaretli bir liste nasıl oluşturulacağını göstermektedir:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğelerin sırası önemli olduğunda numaralı listeler kullanılır. [BulletFormat.setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) metodunu [BulletType.Numbered](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/#Numbered) olarak ayarlayın. Ayrıca numaralandırma biçimini [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) ile seçebilir veya listenin 1 yerine başka bir değerle başlamasını istediğinizde [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) metodunu ayarlayabilirsiniz.

Aşağıdaki PHP kodu, bir slaytta numaralı bir liste nasıl oluşturulacağını gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resimli Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir görüntü ile değiştirmenize olanak tanır. Resimli madde işaretleri, ikonlar veya küçük şeffaf PNG dosyaları gibi küçük boyutta okunabilir kalan basit görüntülerle en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntü ile değiştirmeyi planlıyorsanız, şeffaf arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görüntüler, özel madde işareti sembolleri olarak iyi çalışır.

Görüntünün çok küçük bir boyuta ölçeklendirileceğini unutmayın. Bu nedenle, bir listede madde işareti olarak kullanıldığında net ve görsel olarak etkili kalan bir görüntü seçmenizi şiddetle öneririz.
{{% /alert %}}

Resimli bir madde işareti oluşturmak için, bir görüntüyü [Presentation.getImages](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getImages--) metoduna ekleyin ve döndürülen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesini [BulletFormat.getPicture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#getPicture--) metoduna atayın. Görüntüyü atamadan önce [BulletFormat.setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) metodunu [BulletType.Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/#Picture) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki PHP kodu, bir slaytta resimli madde işaretleri nasıl oluşturulacağını gösterir:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Resimli madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setDepth-short-) metodunu kullanarak liste öğelerini farklı seviyelere yerleştirebilirsiniz. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe yer alır ve bu şekilde devam eder.

Aşağıdaki PHP kodu, çok seviyeli bir madde işaretli liste nasıl oluşturulacağını gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Varolan Bir Listeyi Değiştirme**

Varolan bir sunumda liste biçimlendirmesini değiştirmek için hedef paragrafı erişin ve onun [ParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getBullet--) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki PHP kodu, bir metin çerçevesindeki ilk paragrafı numaralı bir liste stili kullanacak şekilde değiştirir:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Madde işaretli ve numaralı listeler PDF veya görüntülere aktarılabilir mi?**

Evet. Hedef format ilgili metin düzenini ve madde işareti özelliklerini desteklediğinde Aspose.Slides liste biçimlendirmesini korur.

**Varolan sunumlarda listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, onun [ParagraphFormat.getBullet](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#getBullet--) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.