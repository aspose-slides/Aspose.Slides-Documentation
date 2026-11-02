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
- resim madde işareti
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
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listelerin nasıl oluşturulup biçimlendirileceğini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) yöntemini kullanın. Ana giriş noktası, bir [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) nesnesi döndüren [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) yöntemidir. Bu nesne sayesinde madde işareti türü, sembol, resim, renk, boyut, numaralandırma stili ve başlangıç numarası ayarlanabilir.

Bu makale aşağıdakileri gösterir:

- özel bir sembolle madde işaretli liste oluşturma
- resim madde işareti oluşturma
- paragraf derinliği ayarlanarak çok seviyeli liste oluşturma
- numaralı liste oluşturma
- var olan bir sunumda liste biçimini inceleme ve değiştirme
- paragraf metniyle birlikte gerçek liste işaretçilerini ve numaraları okuma

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) içine [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) nesneleri ekleyin ve [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) yöntemini [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) olarak ayarlayın. Ardından madde işaretinin görünümünü kontrol etmek için [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) ve [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) yöntemlerini kullanabilirsiniz.

Aşağıdaki PHP kodu, bir slaytta madde işaretli liste nasıl oluşturulacağını gösterir:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Sıralamanın önemli olduğu durumlarda numaralı listeler kullanın. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) yöntemini [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered) olarak ayarlayın. Ayrıca [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) ile bir numaralandırma biçimi seçebilir veya [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) ile listenin 1 dışındaki bir değerden başlamasını sağlayabilirsiniz.

Aşağıdaki PHP kodu, bir slaytta numaralı liste nasıl oluşturulacağını gösterir:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resim Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir resimle değiştirmenize imkan tanır. Resim madde işaretleri, küçük boyutlarda okunabilirliği koruyan basit görseller, örneğin simgeler veya şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="info" title="Note" %}}
İdeal olarak, normal madde işareti sembolünü bir resimle değiştirmeyi planlıyorsanız, şeffaf bir arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görseller özel madde işareti sembolleri olarak iyi performans gösterir.

Görsel çok küçük bir boyuta ölçeklendirileceği için, listede madde işareti olarak kullanılacak bir resmin net ve görsel olarak etkili kalmasına dikkat etmenizi şiddetle öneririz.
{{% /alert %}}

Resim madde işareti oluşturmak için, [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) yöntemiyle bir resim ekleyin ve döndürülen [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) nesnesini [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) metoduna atayın. Resmi atamadan önce [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) yöntemini [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) olarak ayarlayın.

Örneğin elimizde bir "image.png" dosyası olduğunu varsayalım:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki PHP kodu, bir slaytta resim madde işaretlerinin nasıl oluşturulacağını gösterir:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Sonuç:

![Resim madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

Liste öğelerini farklı seviyelere yerleştirmek için [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) yöntemini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe geçer ve bu şekilde devam eder.

Aşağıdaki PHP kodu, çok seviyeli madde işaretli bir listenin nasıl oluşturulacağını gösterir:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Var Olan Bir Listeyi Değiştirme**

Var olan bir sunumda liste biçimini değiştirmek için hedef paragrafı alın ve [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyalarından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki PHP kodu, bir metin çerçevesindeki ilk paragrafı numaralı liste stiline dönüştürür:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
    $presentation->dispose();
}
```

## **Gerçek Madde İşareti Değerlerini Okuma**

Sunum içeriği çıkarılırken liste işaretçileri paragraf metniyle birlikte korunmalıdır. Etkili madde işareti biçimini elde etmek için [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) metodunu çağırın ve [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) üzerinden erişin. Okumadan önce [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) metoduyla madde işareti türünü kontrol edin, ardından [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) metodunu kullanın.

Numaralı listeler için aşağıdaki üç değeri ayırın:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) biçimi belirler; örneğin nokta ile biten Arap rakamları veya nokta ile biten küçük harfler.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) bir grup numaralı paragraf için başlangıç numarasını belirtir.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) belirli bir paragraf için biçimlendirilmiş işareti döndürür. Örneğin, 5'ten başlayan bir listede ikinci öğe `6.` döndürür.

Her paragrafta [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) değerini koruyarak iç içe seviyesini saklayın. Gerçek işaretçi tam hiyerarşiyi kodlamaz: iç içe bir öğe `c.` döndürebilir, `6.c.` gibi birleşik bir etiket yerine.

Aşağıdaki bağımsız örnek, listeler oluşturur, bir sunuma kaydeder ve sunumu yeniden yükleyerek her paragrafın metnini, derinliğini, madde işareti türünü ve gerçek değerini raporlar. Küçük mavi resim işareti, satır içi SVG'den oluşturulmuştur.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Harici bir görüntü dosyası olmadan bir resim işareti oluştur.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

Kaynak listeler aşağıda gösterilmiştir.

![5'ten başlayan listeler, iç içe harf ve Roma rakamı öğeleri, bir sembol işareti, madde işareti olmayan paragraf ve mavi resim işareti](actual_bullet_values.png)

Rapor, PowerPoint'te gösterilen işaretçilerle eşleşir:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType::None ve BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) için, [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` döndürür; boş bir dize değil. Bu türleri ayrı ayrı işleyin: ilki işaretçi içermez, ikincisi ise madde işareti resmini ayrı olarak çıkarmanız gerekir. Bir resim madde işareti yalnızca metin işaretçisinin çıkarılmasıyla yeniden oluşturulamaz.

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere dışa aktarılabilir mi?**

Evet. Aspose.Slides, hedef format ilgili metin yerleşimini ve madde işareti özelliklerini destekliyorsa liste biçimini korur.

**Mevcut sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı alın, [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) ayarlarını inceleyin veya güncelleyin ve sunumu kaydedin.

**Listeler Latin olmayan metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir; böylece çok dilli sunumlarda listeler oluşturabilirsiniz. Kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.