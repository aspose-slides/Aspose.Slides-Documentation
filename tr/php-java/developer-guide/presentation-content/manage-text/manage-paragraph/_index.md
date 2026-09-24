---
title: PHP'de PowerPoint Metin Paragraflarını Yönet
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
  - asılı girinti
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
description: "Aspose.Slides for PHP via Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntülerini nasıl oluşturacağınızı ve biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) bir şeklin içinde metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyindeki biçimlendirmeye erişim sağlar.
* [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) bir paragraf içinde bir metin akışını temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmeye sahip olabilir.

Dolayısıyla bir paragraf, birden fazla bölüm kullanılarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin barındırabilir.

## **Paragraflar Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm İçeren Paragraflar Oluşturma**

Aşağıdaki adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İlgili slayta indeksini kullanarak erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki tane daha [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içerebilmesi için yeterli sayıda [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.
7. Her bölümün metnini ayarlayın.
8. [Portion::getPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getPortionFormat--) üzerinden karakter düzeyinde biçimlendirme uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu PHP örneği adımları uygular:

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

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralandırma, ilgili maddelerin incelenmesini kolaylaştırır. Aspose.Slides içinde liste ayarları [BulletFormat] üzerinden tanımlanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İlgili slayta indeksini kullanarak erişin.
3. Seçilen slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin.
5. Metin çerçevesindeki varsayılan paragrafı kaldırın.
6. Bir sembol madde işareti için [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) oluşturun.
7. [BulletFormat::setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) değerini [BulletType::Symbol](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturun ve [BulletFormat::setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) değerini [BulletType::Numbered](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu PHP örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

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

Resim madde işaretleri, sembol veya sayı yerine özel bir görüntü kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İlgili slayta indeksini kullanarak erişin.
3. Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin ve onun [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin.
4. Metin çerçevesindeki varsayılan paragrafı kaldırın.
5. Madde işareti görüntüsünü yükleyin ve sunumun görüntü koleksiyonuna [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [BulletFormat::setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setType-int-) değerini [BulletType::Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bullettype/) olarak ayarlayın.
8. Görüntüyü [BulletFormat::getPicture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#getPicture--) aracılığıyla atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu PHP örneği bir resim madde işareti oluşturur:

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

### **Çok Düzeyli Liste Oluşturma**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setDepth-short-) ayarlayarak paragrafları bir listenin farklı seviyelerinde konumlandırabilirsiniz. En üst seviye `0` derinliğe sahiptir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin ve metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. Bu paragrafların [ParagraphFormat::setDepth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setDepth-short-) değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu PHP örneği dört seviyeli bir madde işaretli liste oluşturur:

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

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) kullanarak bir numaralı paragraf için görüntülenecek başlangıç numarasını ayarlayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) oluşturun ve bir slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
2. Şeklin metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. İlgili paragraflar için [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/tr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) değerini sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu PHP örneği her paragraf için özel bir başlangıç numarası atar:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
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

## **Paragraf Düzeni ve Bitiş Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu yöntem yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tam paragrafı taşımak gerektiğinde [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) kullanın. Yalnızca ilk satırı taşımak istediğinizde [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) kullanın.

Aşağıdaki örnek, birkaç paragraf oluşturur ve ilk satır girintisinin paragraf düzenini nasıl etkilediğini göstermek için farklı [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) değerleri uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Birçok paragraf oluşturun ve onlara farklı [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu bir paragraf girintisinin nasıl ayarlanacağını gösterir:

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

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides içinde bu etkiyi [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) ile oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için negatif değer gönderin.

Uygulamada, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) paragraf gövdesinin sol konumunu tanımlar, [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) ise ilk satırın bu kenar boşluğuna göre konumunu belirler. Asılı girinti oluşturmak için `setMarginLeft`a pozitif değer, `setIndent`e negatif değer gönderin.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girdileri ve satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için faydalıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her paragraf için [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) değerine pozitif bir değer gönderin.
6. Asılı girinti etkisini oluşturmak için [ParagraphFormat::setIndent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setIndent-float-) değerine negatif bir değer gönderin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu bir paragraf için asılı girintinin nasıl ayarlanacağını gösterir:

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

![Paragrafların asılı girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki PHP örneği ikinci paragrafın son işaretine bir punto büyüklüğü ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yükleyin ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) oluşturun.
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) ve [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ayarlayın.
6. [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ile biçimi atayın ve sunumu kaydedin.

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

## **Render Edilen Satırları Sayma**

[Paragraph::getLinesCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getLinesCount--) kullanarak bir paragrafın metin yerleşiminden sonra kapladığı satır sayısını, otomatik kaydırma dahil, sayabilirsiniz. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken yararlıdır.

Bir paragraf, [TextFrame::getParagraphs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParagraphs--) içindeki tek bir öğedir ve birkaç render edilmiş satır kaplayabilir. Paragraf içinde açık bir satır sonu, yeni bir satır oluşturur ancak yeni bir paragraf oluşturmaz. Otomatik kaydırma, mevcut genişliğe göre satırları oluşturur ve metinde açık satır sonu karakteri eklemez. Bu nedenle, paragraf sayısını veya satır sonu karakterlerini saymak, render edilmiş satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Kaydırma açıktır ve otomatik sığdırma kapalıdır, böylece şekil genişliği kaydırmayı kontrol eder ve metin otomatik olarak küçülmez veya şekil yeniden boyutlandırılmaz. Şekil boyutları puan cinsindendir. Son olarak, örnek başka bir paragraf ekler ve metin çerçevesi boyunca satır sayılarını toplar.

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

Bu metin ve bu boyutlarla, şekli daraltmak satır sayısını artırırken, metni kısa dizeyle değiştirmek azaltır. Kesin sayılar yazı tipi kullanılabilirliği ve ikamesi, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarıyla değişebilir. Bir şablonu kontrol ederken hedef ortam için planlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcısının dışına taşmasını belirlemez. Kullanılabilir yükseklik, satır yükseklikleri, paragraf ve satır aralıkları ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçeri ve Dışa Aktarma**

### **Paragraflara HTML Metni İçeri Aktarma**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Bir slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dosyasını okuyun.
5. HTML dizesini [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metoduna gönderin.
6. Değiştirilmiş sunumu kaydedin.

Bu PHP örneği HTML'yi bir metin çerçevesine içe aktarır:

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

### **Paragraf Metnini HTML Olarak Dışa Aktarma**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) kullanarak seçili paragraf aralığını HTML olarak dışa aktarabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. Slayta erişin ve metni içinde barındıran [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) öğesini bulun.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) öğesine erişin.
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısı ile [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu PHP örneği ilk metin şeklinin tüm paragraflarını dışa aktarır:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
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

### **Bir Paragrafı Görüntü Olarak Render Etme**

[Paragraph::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getImage--) tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) döndürür. Sonucu bir dosyaya veya akışa [IImage::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save-java.lang.String-int-) ile kaydedebilirsiniz. İçeren şekli render etmeye veya bir bitmap'i manuel olarak kırpmaya gerek yoktur.

[Paragraph::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getImage--) paragraf ana koleksiyonunda bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` dönebilir. Kaydetmeden önce sonucu kontrol edin ve kullanımdan sonra döndürülen görüntüyü serbest bırakın.

#### **Varsayılan Ölçekte Bir Paragraf Render Etme**

sample.pptx adlı bir sunum dosyamız olduğunu ve bir slayt içerdiğini, ilk şeklin ise üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki PHP örneği ikinci paragrafı standart bir metin şekli içinde varsayılan ölçekte render eder ve döndürülen görüntüyü PNG formatında kaydeder. `finally` bloğu görüntünün doğru şekilde serbest bırakılmasını sağlar.

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

#### **Bir Tablo Hücresinde Ölçekle Bir Paragraf Render Etme**

[Yönlendirme] (scaling) için `$scaleX` ve `$scaleY` parametrelerini kabul eden [Paragraph::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getImage-float-float-) aşırı yüklemesini kullanın. Aşağıdaki PHP örneği bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin iki katı ve yüksekliğinin iki katı olarak render eder ve sonucu PNG olarak kaydeder.

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

`1` ölçek faktörü ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` kullanmak, genişliği ve yüksekliği yaklaşık iki kat olan bir görüntü üretir; bu da piksel sayısını dört kat artırır. Daha büyük faktörler genellikle yakınlaştırma veya yüksek çözünürlüklü çıktı için daha keskin metin üretir, ancak bellek kullanımı ve dosya boyutunu da artırır. `1`'in altındaki faktörler daha az ayrıntı ile daha küçük görüntüler üretir. Oranları korumak için faktörleri eşit tutun; farklı yatay ve dikey faktörler çıktıyı ayrı ayrı uzatır.

[Shape::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage--) ile tüm şekli render etmek, çıktının şeklin doldurmasını, kenarlığını veya diğer görsel bağlamını içermesi gerektiğinde yararlıdır. Sadece paragraf görüntüsü için [Paragraph::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getImage--) kullanın.

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/#setWrapText-byte-) değerini `false` (0) yaparak kaydırmayı devre dışı bırakabilirsiniz; böylece satırlar metin çerçevesinin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam kenarlarını nasıl alabilirim?**

[Paragraph::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getRect--) metodunu kullanarak paragrafın sınırlayıcı dikdörtgenini alabilirsiniz. [Portion::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getRect--) ise tek bir bölümün sınırlayıcılarını verir.

**Paragraf hizalaması (sol, sağ, ortalanmış veya iki yana yaslama) nerede kontrol edilir?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/#setAlignment-int-) bir paragraf‑düzeyi ayarıdır ve tüm paragrafı, bireysel bölüm biçimlendirmesinden bağımsız olarak uygular.

**Paragrafın bir kısmı için düzeltme dili ayarlayabilir miyim?**

Evet. Tek tek bölümler için [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ayarlayarak bir paragrafta birden çok dilde metin bulunmasını sağlayabilirsiniz.