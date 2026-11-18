---
title: PowerPoint Sunumlarına PHP ile Matematik Denklemleri Ekle
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
description: "Aspose.Slides for PHP via Java ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net PHP kod örnekleri sunar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for PHP via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'ta, kullanıcılar genellikle **Insert > Equation** üzerinden denklem ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şekli, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) şeklin metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/)'den gelen akıcı yöntemleri kullanır.

MathML dışa aktarma senaryoları için, [PHP via Java ile Sunumlardan Matematik Denklemlerini Dışa Aktarma](/slides/tr/php-java/exporting-math-equations/) sayfasına bakın.

## **Denklem Oluşturma**

Bu örnek, [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) kullanarak bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c kare eşittir a kare artı b kare denklemi](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) öğesine erişin, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve ona matematik blokları ya da matematik öğeleri ekleyin.
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

## **Kök Ekleme**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) kullanarak karekök, küpkök veya diğer kökleri oluşturabilirsiniz. Mevcut öğe taban olur, argüman ise derecedir.

![x, radikal işaretinin altında olan n'inci kök ifadesi](powerpoint-math-equations_5.png)

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

### **Karekök Derecesini Gösterme veya Gizleme**

Karekök, açık bir 2 gösterebilir veya geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) üzerindeki [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) yöntemi hangi biçimin görüneceğini denetler. Her iki biçim de düzenlenebilir denkleme derece 2 ve radikand x'i korur.

![Aynı karekök, sol tarafta derecesi görünür ve sağ tarafta gizlidir](square-root-degree.png)

Örnek aynı karekökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görünür. `hidden-degree.pptx` dosyasında ise gizlidir.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Fonksiyonlar ve Limitler Ekleme**

[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) veya [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) kullanarak `sin(x)`, `log(x)` gibi fonksiyonları veya özel fonksiyon adlarını ekleyin. Limitler için, `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) kullanın.

![x'in sonsuza yaklaşırken limiti](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve argümanıyla birlikte [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) çağırın:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-Aralı Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

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

N-aralı operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-` ve `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) olarak eklenir ve ifadeye katılır.

Bir integral için, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) kullanın:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matrisler Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi kapatın.

![Bir boş hücreli iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

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

### **Mevcut Bir Matrisi Düzenleme**

`matrix.pptx` dosyasında katsayı matrisi ile başlayan bir lineer cebir dersi varsayalım; bu matris önceki örnekle kaydedildi. Sonraki alıştırma için ilk denklemi tutun, ikinciyi iki yeni denklemle değiştirin ve değişken kümesini güncelleyin. Uygun katsayıları korumak için mevcut matrisi [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) aracılığıyla açın.

![İlk satırda 1, x ve boş hücre, ikinci satırda x, 2 ve y içeren orijinal iki satırlı katsayı matrisi](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda matrisin bulunduğu duruma göre referans verilir. 1 indeksinden önce bir satır eklemek, orijinal ikinci satırı 2 indeksine taşır. 2 indeksinden sonra eklemek bir satır ekler. 2. satırı silmek, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konum yukarı kaydırır. Sütunlar da aynı şekilde kayar.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // Yeni hücreler başlangıçta null değerindedir. Önce sıfır olmayan katsayıları ayarlayın.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) ise indeks 1'den başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişkene sahiptir. Orijinal ilk satır katsayıları `1` ve `x` şimdi birinci ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris, satırları 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1 olarak gösterir](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Hizalanmış denklemlere veya dikey bir ifade yığınına ihtiyaç duyduğunuzda [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) kullanın.

![x'in y'nin üzerinde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

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

### **Diziyi Çevreleyen Öğelerle Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) bir dizinin, yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, hizalamayı ilk satır, dizinin merkezi ve son satır ile karşılaştırır.

Aşağıdaki örnek, üç aynı diziyi oluşturur; her biri üç satır ve komşu öğeler `A=` ve `=B` içerir. Tüm matematik metni Cambria Math 24 punto kullanır. Yalnızca dizi hizalaması değişir.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki karşılaştırma, PowerPoint'te kaydedilen sunumu gösterir. Her dizinin yanında `A=` ve `=B` konumuna dikkat edin.

![PowerPoint'te Üst, Orta ve Alt hizalamalı denkleml dizileri ve aynı komşu öğeler](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) dizi içindeki satırlar için aralık kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) belirli bir aralık kuralı için sayısal bir değer sağlar ve önceden tanımlı kurallar tarafından yok sayılır.

Tam aralık için değer puan cinsinden ölçülür. Orantılı aralık için yarım satır cinsinden ölçülür: örnekteki `3` değeri 1.5 satır anlamına gelir. Belirli bir değer belirtirken her iki özelliği de ayarlayın; yalnızca sayısal değeri değiştirmek bir aralık kuralı seçmez.

Aşağıdaki örnek, aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunumu kaydeder. İlk üçü ön tanımları kullanır; son ikisi belirli değerleri gösterir.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

Dizi satır aralığı, paragraf aralığından ayrı tutulur. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) içeren paragrafın etrafına boşluk ekler, dizi satırları arasında değil. Benzer şekilde, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) tüm matematik paragrafını yatay konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe ve fonksiyon adı biliniyorsa, [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) kullanın.

![2x'e uygulanan cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

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

## **Alt Simge ve Üst Simge Ekleme**

İndeksler ve üsler için alt simge ve üst simge yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde, [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) kullanın.

![Sol tarafında alt simge 1 ve üst simge n olan büyük Y](powerpoint-math-equations_9.png)

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

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) kullanarak bir ifadeyi sınırlayıcıların içine koyabilirsiniz. Birden fazla öğe içeren sınırlayıcı ifadeler için bir ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran bir sınırlayıcı ifade](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıların Boyutu ve Hizalanması**

Parantezlerin yüksek bir operanda göre büyümesini sağlamak için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)‘e `true` gönderin, normal boyutta tutmak için `false` gönderin. İki [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) değerinden biriyle [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) kullanın. `Centered` parantezleri eşit işaretinin ortasından geçen matematik ekseninde ortalar. `Match` ise içeriğe göre hizalar. Her iki ayar yalnızca sınırlayıcıları etkiler. İçteki ifade aynı kalır.

Örnek, `x`'in üstünde bir kesir yerleştirir, böylece ifade alt çizgiye göre daha yukarı uzanır. Dört denklemin hepsi aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint'te, büyüme etkisini görmek için satırları karşılaştırın. Üst satırda parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır. Soldaki daha küçük parantezler (`Centered`) eşit işaretiyle hizalanırken, sağdaki (`Match`) ifadeye göre daha yüksek konumlanır.

![PowerPoint'te dört denklem, üstte sınırlayıcı büyümesi etkin, altta devre dışı, sol tarafta Centered ve sağda Match](delimiter-sizing.png)

## **Kenar Kutusu Ekleme**

Bir kesir üzerinde [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) çağırarak ifadenin tümünü çerçevelendirin. Dönen [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) varsayılan olarak dört tarafı da gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) kullanın.

Örnek, aynı kesirin altı kopyasını bir slayta yerleştirir. İptal göstermek için, dört kenarı gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight)’e `true`, düşen bir diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)’e `true` gönderin. Ayrıca görünür kenarların herhangi bir kombinasyonu ile [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) de kullanılabilir.

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

![PowerPoint'te altı düzenlenebilir kesir. Üst satır: tam kenar, alt ve sol kenarlar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay kırpma, tam kenarlı dikey kırpma.](border-box-fractions.png)

Bu kesirde, yatay çizgi kesir çubuğunun üzerine çıkar. Dikey çizgi hem payı hem de paydayı keserken çevredeki kenar görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin üzeri çizgisi bir metin çalıştırmasındaki karakterlere uygulanır. Sunumu PowerPoint'te yeniden açtıktan sonra, payı ve paydayı bağımsız olarak düzenlemeye devam edebilirsiniz.

## **Phantom Öğelerle Görünürlük ve Yerleşimi Kontrol Etme**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) içinde sararak görünürlüğünü ve denkleme katkıda bulunduğu boşluğu bağımsız olarak kontrol edin. [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) yöntemleri aşağıdakileri denetler:

| Yöntem | Etki |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | İfadeyi gizlemek için `false` gönderin. Boyutları hâlâ yerleşime katkıda bulunur, aşağıdaki ilgili yöntemler `true` alana kadar. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | İfadenin yatay genişliğini sıfır kabul edin, komşu öğelerin daha yakın gelmesini sağlar. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | Yükselişini (baseline üstündeki yüksekliği) sıfır kabul edin. Bu, komşu öğelerin üzerindeki boşluğu azaltabilir. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | Alçalmasını (baseline altındaki derinliği) sıfır kabul edin. Bu, bir kesir çubuğu veya diğer içeriklerin ifadenin altındaki boşluğunu komşulara yaklaştırabilir. |

Baseline, normal matematik harflerinin oturduğu referans çizgidir. İçeriği gizlemek boyutlarını kaldırmaz ve bir boyutu sıfır kabul etmek ifadeyi silmez. Alt ifadeye [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) aracılığıyla hâlâ erişilebilir. Tekrar göstermek için [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow)’e `true` gönderin; boyut ayarları değişmeden kalır.

Aşağıdaki örnek, yan yana beş varyant oluşturur: görünür bir kesir, boşluk ayıran gizli bir kesir ve bir boyutu sıfır kabul edilen üç gizli kesir. Her varyant aynı çevreleyici ifadeyi ve Cambria Math 24 puntoyu kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir, gri kılavuzla işaretlenmiştir. Phantom’u dış kesirin payına yerleştirmek, dikey yerleşim değişikliklerini daha iyi görmeyi sağlar.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint'te beş denklem, görünür bir kesir, boşluk ayıran gizli bir kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkin gizli kesirleri karşılaştırıyor](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) kullanarak bir ifadenin üstüne veya altına bir gruplama karakteri koyun. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

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

Biçimlendirme yardımcılarını yalnızca formülü açıklayan yerlerde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) bir matematik öğesinin üzerine bir çubuk koyar.

![Üstü çizgili bir ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

Mevcut bir denklemdeki metni biçimlendirmek için, her matematik bloğunun öğe ağacını dolaşın. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür, bu yüzden kesirler, üst/alt simgeler, kökler ve diğer iç içe yapılar içindeki metne ulaşmak için yinelemeli olarak çağırın. Başlangıç öğesi [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) olduğunda da dahil etmek için mevcut öğeyi ve çocuklarını kontrol edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; kesir, payda içinde bir alt simge ve payda içinde bir kök içerir. Yalnızca bloğun en üst seviyesindeki öğeleri işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklarına [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) üzerinden erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) yöntemi aracılığıyla [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi boyutunu 28 puana ayarlar.

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

Kaydedilen sunum, işlenen her denklemin her seviyesinde güncellenmiş metin biçimlendirmesini içerir ve metin içeriğini ve matematik yapısını korur.

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluştur | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştir | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kesirler oluştur | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Üst simge veya alt simge ekle | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Fonksiyonlar ekle | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kökler ekle | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Limitler ekle | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sol taraflı üst/alt simgeler ekle | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Toplamalar ve integraller ekle | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Matrisler ekle | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekle | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sınırlayıcılar ekle | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Çubuklar ve kenarlıklar ekle | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Terimleri grupla | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, içinde bir [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) bulunan şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office math içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) öğesini [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) çağırın. Tam bir örnek için, [PHP via Java ile Sunumlardan Matematik Denklemlerini Dışa Aktarma](/slides/tr/php-java/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.