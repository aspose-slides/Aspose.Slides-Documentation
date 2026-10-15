---
title: PowerPoint Metin Paragraflarını PHP'de Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- askıda girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) şeklin içinde metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) bir metin çerçevesindeki tek bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyinde biçimlendirmesine erişim sağlar.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) bir paragraftaki metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içerebilir.

## **Paragraflar Oluşturma ve Biçimlendirme**

Bir şeklin metin çerçevesinde paragraflar oluşturun ve bölümleri kullanarak tek tek metin yürütmelerini biçimlendirin. Bu bölüm, her paragrafta birden çok bölümü birleştirmenin ve farklı renkler, yazı tipi boyutları ve stiller uygulamanın nasıl yapılacağını gösterir.

### **Birden Çok Bölümle Paragraflar Oluşturma**

Aşağıdaki PHP örneği, [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) tarafından döndürülen koleksiyonda üç metin yürütmesi içeren üç paragraf oluşturur. Varsayılan paragraf ve boş bölüm yeniden kullanılır, ardından kalan paragraflar ve bölümler eklenir. Biçimlendirme, [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) aracılığıyla uygulanır: her paragraftaki ilk bölüm kırmızı, kalın ve 15 puan; ikinci bölüm mavi, italik ve 18 puan. Üçüncü bölüm varsayılan biçimlendirmesini korur:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

Paragraf metnini semboller, sayılar veya özel görsellerle listelere dönüştürün. Bu bölümde madde işareti biçimlendirmesi, çok seviyeli listeler ve özel başlangıç sayıları ele alınmıştır.

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralandırma ilgili öğeleri taramayı kolaylaştırır. Aspose.Slides içinde liste ayarları, [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) aracılığıyla tanımlanır.

Bu PHP örneği aynı metin çerçevesine bir sembol madde işareti ve bir numaralı öğe ekler. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) madde işareti türünü belirler, [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) sembolü sağlar ve [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) numaralandırma stilini seçer. Her iki öğe de %100 yükseklikte ve 25 puan paragraf girintisine sahip siyah madde işaretleri kullanır:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, bir sembol veya sayı yerine özel bir görsel kullanmanızı sağlar.

Bu PHP örneği, bir [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) olarak sunumun görsel koleksiyonuna bir resim ekler ve bunu paragraf madde işareti olarak kullanır. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) ile resim madde işareti seçilir ve resim, [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) aracılığıyla atanır. [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) %100 olarak ayarlanarak madde işaretinin paragraf metnine göre boyutu belirlenir:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Çok Seviyeli Liste Oluşturma**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) ayarı, paragrafları bir listenin farklı seviyelerine yerleştirmenizi sağlar. Üst seviye derinliği `0` dır.

Bu PHP örneği, dört paragraf için [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) değerlerini 0‑3 arasında atayarak tek bir metin çerçevesinde hiyerarşi oluşturur. Her paragraf, [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) ile yuvarlak madde işareti ve tire arasında geçiş yaparak bitişik seviyeleri ayırır:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) ile numaralı bir paragraf için başlangıç numarasını ayarlayabilirsiniz.

Bu PHP örneği, üç paragraf için [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) ile numaralandırma etkinleştirir ve [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) değerlerini sırasıyla 2, 3 ve 7 olarak belirler. Başlangıç değeri her paragraf için ayrı ayrı yapılandırılır, böylece gösterilen sayılar atlanabilir:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Etme**

Paragraf kenar boşlukları ve girintileri ayarlayarak ilk satırın ve satır devamlarının konumunu kontrol edin. Ayrıca paragraf son işaretini, görünür metin bölümlerinden ayrı olarak biçimlendirebilirsiniz.

### **İlk Satır Girintisi Ayarlama**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) yöntemi, bir paragrafın ilk satır girintisini kontrol eder. Bu ayar yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tam paragrafı taşımak istediğinizde [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) kullanın. Sadece ilk satırı taşımak istediğinizde ise [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) kullanın.

Aşağıdaki örnek, üç paragrafın aynı [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) değerini 20 puan ve [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) değerlerini 0, 20 ve 40 puan olarak ayarlar. İlk satırlar giderek daha büyük ofsetlerde başlarken, satır devamları aynı sol kenar boşluğunu korur:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragrafların birinci satır girintisi](first_line_indent.png)

### **Askıda Girinti Ayarlama**

Askıda girinti, ilk satırın kalan satırların soluna başladığı bir paragraf düzenidir. Aspose.Slides içinde bu etkiyi [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) özelliği ile oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Uygulamada, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) paragraf gövdesinin sol konumunu tanımlar, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) ise bu kenar boşluğuna göre ilk satırın konumunu tanımlar. Askıda girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girişleri ve satır devamlarının paragraf gövdesinin altına hizalanması gereken diğer paragraflar için faydalıdır.

Aşağıdaki PHP örneği, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) değerlerini 40 ve 60 puan, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) değerlerini -20 ve -30 puan olarak eşleştirir. Her paragrafta ilk satır, satır devamlarının solunda başlar; ikinci paragrafta daha derin bir askıda girinti elde edilir:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragrafların askıda girintisi](hanging_indent.png)

### **Paragraf Son Koşul Özelliklerini Ayarlama**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) yöntemi, paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek, [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) oluşturur; bu formatta [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 48 puan ve [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) Times New Roman olarak ayarlanır. Bu format ikinci paragrafın son işaretine atanır, görünür metin bölümleri değişmeden kalır:

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Çizilen Satırları Sayma**

Satır sonlarında otomatik satır bölme ve noktalama kurallarını görmek için [Control Line Breaking](/slides/tr/php-java/text-formatting/#control-line-breaking) ve [Control Hanging Punctuation](/slides/tr/php-java/text-formatting/#control-hanging-punctuation) bölümlerine bakın.

[Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) yöntemi, metin yerleşimi sonrası bir paragrafın kapladığı satır sayısını, otomatik satır bölmeyi de dahil ederek sayar. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken yararlıdır.

Bir paragraf, [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) içinde bir öğedir ve birkaç çizilen satır kaplayabilir. Bir paragraftaki açık satır sonu, başka bir paragraf oluşturmadan yeni bir satır oluşturur. Otomatik sarmalama, metindeki açık satır sonu karakteri eklemeden kullanılabilir genişliğe göre satırlar oluşturur. Bu nedenle paragraf saymak ya da satır sonu karakterlerini saymak çizilen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Örnek, [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) ile sarmalamayı etkinleştirir ve [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) ile otomatik sığdırmayı devre dışı bırakır; böylece şekil genişliği, metni otomatik küçültmeden sarmalamayı kontrol eder. Her ölçüm [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) ile yapılır. Şekil boyutları puan cinsindendir. Son olarak örnek başka bir paragraf ekler ve metin çerçevesindeki satır sayılarını toplar:

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Bu metin ve boyutlarla şekli daraltmak satır sayısını artırırken, kısa dizeyle değiştirmek azaltır. Kesin sayılar, yazı tipi bulunabilirliği ve ikamesi, yazı tipi boyutu, kenar boşlukları, girinti, sarmalama ve otomatik sığdırma ayarlarına göre değişebilir. Şablonu kontrol ederken hedef ortam için tasarlanmış yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcı içinde taşma olup olmadığını belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; sarmalama devre dışı bırakıldığında tek bir satır bile kullanılabilir genişliği aşabilir.

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

HTML kullanarak metni bir sunuma getirebilir veya mevcut paragrafları dışarıda kullanmak üzere dışa aktarabilirsiniz. Bu bölüm ayrıca tablolar içinde paragrafları görüntü olarak render etme yöntemlerini gösterir.

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) ile HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

Bu PHP örneği bir dosyadan HTML okur ve işaretlemeyi [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) metoduna iletir. Metin çerçevesinin varsayılan paragrafı temizlenir, böylece çerçeve sadece içe aktarılan içeriği içerir. Dikdörtgen şekil, slaytın her iki yanında 10 puan kenar boşluğu bırakır:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Paragraf Metnini HTML’ye Dışa Aktarma**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) ile seçili bir paragraf aralığını HTML olarak dışa aktarabilirsiniz. Sunum metnini bir web sitesinde yeniden kullanırken, sunumun yazı tipi, boyutu veya metin kutusu stillerini taşımadan yerel vurgulamayı korumak isteyebilirsiniz. [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) ayarı, dışa aktarıcının biçimlendirme kalıtımını ne kadar takip edeceğini kontrol eder.

[örnek sunumu](text-inheritance.pptx) indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, “Inherited text; explicit red 18pt” metnini içeren bir metin şekli barındırır. Giriş, bilinçli olarak birkaç biçimlendirme seviyesi kullanır:

- Sunumun varsayılan metin stili Calibri ve 28 pt sağlar.
- Metin çerçevesinin birinci seviye metin stili mavi metin ve italik sağlar.
- Paragraf açıkça kalın metin ayarlar.
- İkinci bölüm, “explicit red 18pt”, kırmızı metin ve 18 pt boyutunu açıkça ayarlar.

Aşağıdaki tam örnek aynı paragrafları üç kez dışa aktarır. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) dışa aktarma yöntemine iletilir ve her sonuç ayrı bir UTF‑8 HTML dosyasına yazılır:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Oluşturulan HTML, ilk bölüm “Inherited text; ” için aşağıdaki CSS’i içerir. Tablo ilgili bildirimleri listeler; diğer oluşturulan özellikler açıklık için atlanmıştır.

| Çıktı | İlk bölüm için ilgili CSS | Görünüm |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri mevcutsa 28 pt, mavi, kalın, italik metin. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Mavi, kalın, italik metin; sayfa ya da tarayıcı font ailesi ve boyutunu sağlar. |
| `ParagraphOnly.html` | `font-weight:bold` | Kalın metin; sayfa ya da tarayıcı font ailesi, boyutu, rengi ve italik stili sağlar. |

İkinci bölüm tüm üç çıktıda `color:#ff0000`, `font-size:18pt` ve `font-weight:bold` değerlerini korur. `All` ve `TextBox`’da italik de korunur, `ParagraphOnly`’da korunmaz. Kalıtımı kısıtlamak, bir paragraf veya bölüme açıkça atanmış biçimlendirmeyi kaldırmaz.

Aynı tarayıcıda dosyaları açıp karşılaştırın. Kısıtlı iki modda atlanan CSS özellikleri hedef sayfanın stilleri ya da tarayıcı varsayılanları tarafından çözülür; bu da görünümün HTML’nin kullanıldığı yere bağlı olarak değişmesine yol açar.

### **Paragrafı Görüntü Olarak Render Etme**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) döndürür. Sonucu [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) ile dosya ya da akışa kaydedebilirsiniz. İçeren şekli render etmenize veya bitmap’i manuel olarak kırpmanıza gerek yoktur.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage), paragraf ana koleksiyonunda bulunamazsa, geçerli bir render alanı yoksa veya render edilemezse `null` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullanım sonrası döndürülen resmi serbest bırakın.

#### **Varsayılan Ölçekte Paragraf Render Etme**

Örnek, üç paragraf içeren bir metin kutusuna sahip tek slaytlı bir sunum kullanır.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, ikinci paragrafı (indeks 1) seçer ve ölçek parametresi olmadan [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) çağırır. Şeklin gerekli paragrafı içerdiğini ve render sonucunun bir resim olduğunu kontrol eder, ardından resmi PNG formatında kaydetmek için [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) kullanır. `finally` bloğu, kullanım sonrası resmi serbest bırakır.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçekli Paragraf Render Etme**

Yatay ve dikey ölçek faktörlerini ayarlamak için `$scaleX` ve `$scaleY` parametrelerini kabul eden [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) aşırı yüklemesini kullanın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olarak render eder ve sonucu PNG görüntüsü olarak kaydeder.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

`1` faktörü, ilgili ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` kullanmak, genişliği ve yüksekliği yaklaşık iki kat olan bir görüntü üretir; bu da piksel sayısını dört katına çıkarır. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktı için metni daha net yapar, fakat bellek kullanımını ve dosya boyutunu artırır. `1`’in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. En-boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ile tüm şekli render etmek, çıktının şeklin doldurması, kenarlığı veya diğer görsel bağlamı içermesi gerektiğinde hâlâ faydalıdır. Yalnızca paragraf görüntüsü için [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) kullanın.

## **SSS**

**Bir metin çerçevesinde satır sarmalamayı tamamen devre dışı bırakabilir miyim?**

Evet. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) özelliğini kapatarak sarmalamayı devre dışı bırakabilirsiniz; böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) kullanın. Tek bir bölümün sınırlarını elde etmek için [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) kullanılır.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslanmış) nerede kontrol edilir?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) bir paragraf‑düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

Farklı yazı tipi boyutlarına sahip bölümleri aynı satır içinde dikey olarak hizalamak için [Align Fonts Within a Line](/slides/tr/php-java/text-formatting/#align-fonts-within-a-line) bölümüne bakın.

**Paragrafın bir kısmı için denetleme dilini ayarlayabilir miyim?**

Evet. Bireysel bölümler için [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) ayarlayarak bir paragrafta birden çok dilde metin bulunmasını sağlayabilirsiniz.