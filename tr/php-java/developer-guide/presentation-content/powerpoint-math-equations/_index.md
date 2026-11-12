---
title: PHP ile PowerPoint Sunumlarına Matematik Denklemleri Ekle
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/php-java/powerpoint-math-equations/
keywords:
- matematik denklemi
- matematik sembolü
- matematik formülü
- matematik metni
- matematik denklemi ekle
- matematik sembolü ekle
- matematik formülü ekle
- matematik metni ekle
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net PHP kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak saklar. Aspose.Slides for PHP via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, radikaller, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te, kullanıcılar genellikle denklemleri **Ekle > Denklem** menüsünden ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şekli, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) üzerindeki akıcı metodları kullanır.

Sunumlardan Matematik Denklemlerini PHP üzerinden Java ile Dışa Aktarma ([Export Math Equations from Presentations in PHP via Java](/slides/tr/php-java/exporting-math-equations/)) senaryoları için bakınız.

## **Bir Denklem Oluşturma**

Bu örnek, [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) kullanarak bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Not" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) öğesine erişin, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

[divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) kullanarak bir kesir oluşturun. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x'e bölünmüş bir kesiri gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Yığılmış bir kesir için, [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Radikal Ekleme**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) kullanarak karekök, küpkök veya başka bir kök oluşturabilirsiniz. Mevcut öğe temel olur, argüman ise derece olur.

![Kök işareti altında x bulunan n'inci kök ifadesi](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Fonksiyon ve Limit Ekleme**

[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) veya [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) metodlarını `sin(x)`, `log(x)` gibi fonksiyonlar veya özel fonksiyon adları için kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) metodunu kullanın.

![x'in sonsuza giderken limiti](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) metodunu argümanıyla birlikte çağırın:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

[nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) metodunu toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için kullanın. [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) metodunu integraller için kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza olanak tanır.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadeye dahil edilir.

Bir integral için, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) kullanın:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matris Ekleme**

[MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) kullanarak satır ve sütunları oluşturun. Matrisler varsayılan olarak köşeli parantez içermez; parantez, kare köşeli veya süslü parantez gibi bir kapsayıcıya ihtiyacınız olduğunda matrisi buna göre sarın.

![Bir boş hücresi olan iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemlere veya dikey bir ifadeler yığınına ihtiyacınız olduğunda [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) metodunu kullanın.

![x'in y'nin üstünde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Trigonometri Fonksiyonları Ekleme**

Argüman mevcut öğe ve fonksiyon adı biliniyorsa [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) metodunu kullanın.

![2x üzerine uygulanan cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Alt ve Üst İndeks Ekleme**

İndeks ve üst üsler için alt ve üst indis yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) metodunu kullanın.

![Sol tarafında 1 altindeksi ve n üstindeksi olan büyük Y](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Sınırlayıcılar Ekleme**

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) metodunu kullanarak bir ifadeyi sınırlayıcılar içine koyun. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de belirleyebilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran bir sınırlayıcı ifadesi](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Boyut ve Hizalama Sınırlayıcıları**

Parantezlerin yüksek bir işlenen etrafında büyümesi için `true` değerini [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metoduna gönderin; normal boyutta kalması için `false` gönderin. İki [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) değerinden biriyle [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) metodunu kullanın. `Centered` parantezleri matematik ekseninde, eşittir işaretinin ortasından geçecek şekilde ortalar. `Match` ise içerikle aynı yükseklikte hizalar. Her iki ayar yalnızca sınırlayıcılara etki eder; içteki ifade aynı kalır.

Örnek, `x` üssünde bir kesir yerleştirerek ifadenin tabandan daha yüksek bir alana uzanmasını gösterir. Dört denklem de aynı parantez ve yazı tipi ayarlarını kullanır.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint'te, büyüme etkisini görmek için satırları karşılaştırın. Üst satırda, parantezler üs kısmını kapsayacak şekilde büyür ve iki şekil de aynı görünür. Alt satırda büyüme kapalıdır; soldaki daha küçük parantez (`Centered`) eşittir işaretiyle hizalanırken, sağdaki (`Match`) ifadeyi daha yukarıda tutar.

![Parantez büyümesi açık ve kapalı olarak dört denklem, solda Centered, sağda Match](delimiter-sizing.png)

## **Kenarlık Kutusu Ekleme**

Bir kesirin tüm ifadesini çerçevelemek için [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) metodunu çağırın. Dönen [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) yöntemlerini kullanın.

Örnek, aynı kesirin altı kopyasını bir slayta yerleştirir. İptal işlemini göstermek için tüm dört kenarı gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metoduna `true` gönderin veya düşen bir diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metodunu kullanın. Görünür kenarların herhangi bir kombinasyonu ile [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metodlarını da tercih edebilirsiniz.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint'te altı düzenlenebilir kesir. Üst satır: tam kenar, alt ve sol kenarlar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay kesik, tam kenarlı dikey kesik.](border-box-fractions.png)

Bu kesirde, yatay kesik kesir çubuğunun üzerine çakışır. Dikey kesik hem payı hem de paydayı keserken etrafındaki kenar görünür kalır. Bu çizgiler bütün ifadeyi süsler. Normal metin üzeri çizgisi yalnızca bir metin koşusundaki karakterlere uygulanır. Sunumu PowerPoint'te yeniden açtıktan sonra, pay ve payda bağımsız olarak hâlâ düzenlenebilir.

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) metodunu kullanarak bir grup karakterini ifadenin üstüne veya altına yerleştirin. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketiyle gruplanmış](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Matematik Öğelerini Biçimlendirme**

Formülü netleştirdiği yerlerde yalnızca biçimlendirme yardımcılarını kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) bir matematik öğesinin üstüne bir çubuk yerleştirir.

![Üst çubuğu olan ABC matematik ifadesi](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Mevcut Bir Denklemde Metni Biçimlendirme**

Mevcut bir denklemdeki metni biçimlendirmek için, her matematik bloğunun öğe ağacını gezin. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür, bu yüzden kesirler, üst/alt indisler, radikaller ve diğer iç içe yapılar içindeki metne ulaşmak için yinelemeli olarak çağırın. Başlangıç öğesini ve onun çocuklarını kontrol edin; öğe [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) olduğunda da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklemi içerdiğini varsayar; bu, payda kısmında bir radikal ve pay kısmında bir altindeks içeren bir kesiri içerir. Yalnızca bloğun üst düzey öğelerini işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bunların bloklarına [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) üzerinden erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) metodunu kullanarak font boyutunu 28 puntoya ayarlamak için [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) çağırır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen sunum, işlenen her denklemin her seviyesinde güncellenmiş metin biçimlendirmesini içerirken, metin içeriğini ve matematiksel yapıyı korur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluştur | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştir | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kesir oluştur | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Üst veya alt indis ekle | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekle | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Radikal ekle | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Limit ekle | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sol taraflı üst/alt indis ekle | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Toplam ve integral ekle | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Matris ekle | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekle | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sınırlayıcı ekle | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Çubuk ve kenarlık ekle | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemine düzenleme yapabilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) nesnesini, ilgili [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) metodunu çağırın. Tam bir örnek için Sunumlardan Matematik Denklemlerini PHP üzerinden Java ile Dışa Aktarma ([Export Math Equations from Presentations in PHP via Java](/slides/tr/php-java/exporting-math-equations/#export-math-equations-to-latex)) sayfasına bakın.