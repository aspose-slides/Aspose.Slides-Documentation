---
title: PHP ile PowerPoint Sunumlarına Matematik Denklemleri Ekleme
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
description: "Aspose.Slides for PHP via Java ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML desteği, biçimlendirme kontrolleri ve net PHP kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for PHP via Java ile aynı türde matematik içeriğini programatik olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Insert > Equation** menüsünden ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren PowerPoint slaydı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Matematik paragrafını içeren şekil, [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şeklidir.
- Şekil metin çerçevesindeki matematik içeriğini saklayan [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/).
- Bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) nesnesi içeren [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/).

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) üzerinden gelen akıcı yöntemleri kullanır.

MathML dışa aktarma senaryoları için [Export Math Equations from Presentations in PHP via Java](/slides/tr/php-java/exporting-math-equations/) bölümüne bakın.

## **Denklem Oluşturma**

Bu örnek, bir matematik şekli oluşturmak için [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) kullanır ve Pisagor teoremini ekler:

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) öğesine erişin, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve ona matematik blokları ya da matematik öğeleri ekleyin.
{{% /alert %}}

### **Matematik Bloklarını Birleştirme**

Bir denklemin parçaları bağımsız olarak [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) nesneleri olarak oluşturulduğunda, bunları birleştirmek için [joinBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#joinBlock) kullanın. Örnek, sol blokta `c² =` ve sağ blokta `a² + b²` oluşturur. [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSuperscript) üç gücün de düzenlenebilir üst indislerini oluşturur.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addMathShape(20, 20, 600, 100);
    $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $mathParagraph = $mathPortion->getMathParagraph();

    $leftBlock = new MathBlock();
    $leftBlock->add((new MathematicalText("c"))->setSuperscript("2"));
    $leftBlock->add(new MathematicalText("="));

    $rightBlock = new MathBlock();
    $rightBlock->add((new MathematicalText("a"))->setSuperscript("2"));
    $rightBlock->add(new MathematicalText("+"));
    $rightBlock->add((new MathematicalText("b"))->setSuperscript("2"));

    $combinedBlock = $leftBlock->joinBlock($rightBlock);
    $mathParagraph->add($combinedBlock);

    $presentation->save("equation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#joinBlock) `$leftBlock` nesnesini kendisi olarak döndürür; artık iki parçayı sırayla içerir ve `$rightBlock` boş kalır. Birleştirilmiş bloğu sadece bir kez [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) içine ekleyin. `equation.pptx` yeniden açıldıktan sonra paragraf, `c² = a² + b²` ifadesini temsil eden tek bir blok içerir; üç üst indis de matematik üst indisleri olarak korunur.

[add](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/#add) metodunu `$leftBlock->add($rightBlock)` şeklinde çağırmak, bir bloğu doğrudan diğerinin içine yerleştirmeye çalışır ve `InvalidOperationException` hatası fırlatır.

## **Kesir Ekleme**

Kesir oluşturmak için [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x ile bölünmüş bir kesri gösteren eğik bir kesir](powerpoint-math-equations_4.png)

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

Yığınlı bir kesir için [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Kök Ekleme**

Kare kök, küp kök veya başka bir kök oluşturmak için [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) kullanın. Geçerli öğe taban olur, argüman ise derecedir.

![x altında kök işareti olan n. kök ifadesi](powerpoint-math-equations_5.png)

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

### **Kare Kök Derecesini Gösterme veya Gizleme**

Kare kök, açık bir 2 gösterebilir ya da geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) sınıfının [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) yöntemi hangi formun görüneceğini kontrol eder. Her iki biçim de derece 2 ve radikand x’i düzenlenebilir denklemde tutar.

![Sol tarafta derecesi görünür, sağ tarafta gizli aynı kare kök](square-root-degree.png)

Örnek aynı kare kökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görünür. `hidden-degree.pptx` dosyasında 2 gizlidir.

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

## **Fonksiyon ve Limit Ekleme**

[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) veya [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) metodlarını `sin(x)`, `log(x)` gibi fonksiyonlar için ya da özel fonksiyon adları için kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) içine yerleştirin veya [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) kullanın.

![x'in sınırsızlığa yaklaştığı limit](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için, fonksiyon adını geçerli öğe yapın ve argümanıyla birlikte [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) çağırın:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitlere sahip bir toplama](powerpoint-math-equations_7.png)

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

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-` ve `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadeye birleştirilir.

İntegral için [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) kullanın:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matris Ekleme**

Satır ve sütunları tanımlamak için [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez; parantez, köşeli ayraç veya süslü ayraç gerektiğinde matrisinizi bunlarla sarın.

![Bir boş hücresi olan iki satırlı matematik matrisi](powerpoint-math-equations_10.png)

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

Lineer cebir dersi, önceki örnekle kaydedilmiş `matrix.pptx` dosyasındaki katsayı matrisiyle başlar. Sonraki alıştırma için ilk denklemi tutun, ikincisini iki yeni denklemle değiştirin ve değişken setini güncelleyin. Kalan katsayıları korumak için [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) üzerinden mevcut matrisi açın.

![İlk satırda 1, x ve boş hücre, ikinci satırda x, 2 ve y bulunan orijinal iki satırlı katsayı matrisi](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda matrisin mevcut durumuna yönelir. İndeks 1’den önce bir satır eklemek, orijinal ikinci satırı indeks 2’ye taşır. İndeks 2’den sonra eklemek bir satır ekler. Satır 2’nin silinmesi, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konum yukarı taşıyarak yerleştirir. Sütunlar da aynı şekilde kayar.

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

    // Yeni hücreler başlangıçta null'dur. Önce sıfır olmayan katsayıları ayarlayın.
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

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) indeksi 1’den başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişken içerir. Orijinal birinci satır katsayıları `1` ve `x` artık birinci ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris, satırlar 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1 olarak gösterilir](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Hizalanmış denklemlere ya da ifadelerin dikey yığınına ihtiyaç duyduğunuzda [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) kullanın.

![x üstünde y bulunan dikey bir matematik dizisi](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) dizinin, yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, ilk satır, dizinin ortası ve son satır hizalamalarını karşılaştırır.

Aşağıdaki örnek, üç aynı diziyi oluşturur; her biri üç satır ve komşu öğeler `A=` ve `=B` içerir. Tüm matematik metni Cambria Math 24 punto boyutundadır. Sadece dizi hizalaması değişir.

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

Aşağıdaki karşılaştırma, PowerPoint’te kaydedilen sunumu gösterir. `A=` ve `=B` öğelerinin her dizi yanındaki konumuna dikkat edin.

![PowerPoint’te Üst, Orta ve Alt hizalama ile aynı komşu öğelere sahip denklem dizileri](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) dizideki satırların aralık kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) açık bir aralık kuralı için sayısal bir değer sağlar ve ön tanımlı kurallar tarafından yoksayılır.

Kesin aralık için değer punto cinsindendir. Orantısal aralık için değer yarım satır cinsindendir: örnekteki `3` değeri 1,5 satır demektir. Açık bir değer belirtirken iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek aralık kuralını seçmez.

Aşağıdaki örnek, aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön ayarları kullanır; son ikisi açık değerleri gösterir.

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

Dizi satır aralığı, paragraf aralığından ayrıktır. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) çevreleyen paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Benzer şekilde, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) bütün matematik paragrafını yatay konumlandırır; dizinin dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman geçerli öğe olduğunda ve fonksiyon adı bilindiğinde [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) kullanın.

![2x üzerine uygulanmış cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

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

## **Alt ve Üst İndisler Ekleme**

İndeksler ve üsler için alt ve üst indis yardımcılarını kullanın. İndeksler tabanın sol tarafında görünmeliyse [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) kullanın.

![Sol tarafta alt indis 1 ve üst indis n olan büyük Y harfi](powerpoint-math-equations_9.png)

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

### **Sağ Alt ve Üst İndisleri Hizalama**

İki indis aynı tabana ait olduğunda [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/mathrightsubsuperscriptelement/) kullanın. Bu öğenin [setAlignScripts](https://reference.aspose.com/slides/php-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) yöntemi yatay konumlarını kontrol eder: `false` (varsayılan) indislerin tabanın konturunu takip etmesini, `true` ise indislerin birbirine yatay olarak hizalanmasını sağlar.

Bu örnek aynı düzenlenebilir ifadeyi yan yana iki kopya olarak yerleştirir. Her iki örnek de matematiksel italik f (U+1D453), alt indis 1, üst indis 2 ve Cambria Math 72 punto kullanır. Eğik taban, farkı PowerPoint’te görünür kılar. Örneği çalıştırmadan önce Cambria Math yükleyin.

```php
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\MathRightSubSuperscriptElement;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(900, 250, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $format = new PortionFormat();
    $format->setFontHeight(72);
    $font = new FontData("Cambria Math");
    $format->setLatinFont($font);

    for ($i = 0; $i < 2; $i++) {
        $left = 40 + $i * 440;
        $shape = $slide->getShapes()->addMathShape($left, 75, 380, 150);

        $baseText = new MathematicalText("\u{1D453}", $format);
        $subscript = new MathematicalText("1", $format);
        $superscript = new MathematicalText("2", $format);
        $scripts = new MathRightSubSuperscriptElement($baseText, $subscript, $superscript);
        $scripts->setAlignScripts($i === 1);

        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight($format->getFontHeight());
        $portion->getPortionFormat()->setLatinFont($format->getLatinFont());
        $mathBlock = new MathBlock($scripts);
        $portion->getMathParagraph()->add($mathBlock);
    }

    $presentation->save("aligned-scripts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Sol tarafta setAlignScripts false, sağ tarafta true ayarlı iki düzenlenebilir ifade](aligned-scripts.png)

Sol tarafta alt indis, üst indisden daha sola başlar ve tabanın konturunu takip eder. Sağ tarafta iki indis yatay olarak birbirine hizalanır.

## **Sınırlayıcılar Ekleme**

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) kullanarak bir ifadeyi sınırlayıcılar içine alabilirsiniz. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z öğeleri dikey çubuklarla ayrılmış bir sınırlayıcı ifadesi](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıları Boyutlandırma ve Hizalama**

Parantezlerin yüksek bir operanda göre büyümesi için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metoduna `true` gönderin; normal boyutta kalması için `false` gönderin. [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) metodunu iki [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) değerinden biriyle kullanın. `Centered` parantezleri matematik ekseni (eşittir işaretinin ortasından geçen) üzerine ortalar. `Match` ise içeriğe göre hizalar. Her iki ayar da yalnızca sınırlayıcıları etkiler; içteki ifade aynı kalır.

Örnek, `x` üssüne bir kesir koyar; böylece ifade tabanın üzerindeki kısmı aşağıdakinden daha uzun olur. Dört denklem aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint’te satırları karşılaştırarak büyüme etkisini görün. Üst satırda parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır. Sol tarafta (`Centered`) daha küçük parantezler eşittir işaretiyle hizalıdır; sağ tarafta (`Match`) parantezler ifadeyi daha yüksek tutar.

![PowerPoint’te dört denklem, üstte büyüme açık, altta kapalı; sol tarafta Centered, sağ tarafta Match](delimiter-sizing.png)

## **Kenar Kutusu Ekleme**

Bir kesirin tüm ifadesini çerçevelemek için [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) metodunu çağırın. Döndürülen [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı da gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) kullanın.

Örnek aynı kesirin altı kopyasını bir slayta yerleştirir. İptal etmeyi göstermek için dört kenarın tümünü gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight), düşen bir diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metodunu `true` olarak ayarlayın. Ayrıca görünür kenarlarla birlikte herhangi bir kombinasyon için [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) kullanabilirsiniz.

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

![Alt satırda tam kenar, alt ve sol kenarlar ve yükselen diyagonal; üst satırda düşen diyagonal, yatay çarpı, dikey çarpı ve tam kenar gösteren altı düzenlenebilir kesir](border-box-fractions.png)

Bu kesirde, yatay çarpı kesir çubuğunu kaplar. Dikey çarpı hem payı hem de paydayı keserken çevre kenarı görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin çarpı, bir metin çalışmasındaki karakterlere uygulanır. PowerPoint’te sunumu yeniden açtıktan sonra pay ve payda bağımsız olarak düzenlenebilir.

## **Phantom Öğelerle Görünürlük ve Yerleşimi Kontrol Etme**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) içine sararak görünürlüğünü ve denkleme katkıda bulunduğu alanı bağımsız olarak kontrol edebilirsiniz. [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) yöntemleri aşağıdakileri kontrol eder:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | `false` verirseniz ifadeyi gizlersiniz. Boyutları düzen içinde hâlâ yer kaplar, aşağıdaki yöntemlerden biri `true` almazsa. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | İfadenin yatay genişliğini sıfır olarak kabul eder, komşu öğelerin daha yakın gelmesini sağlar. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | Üst kısmı (baseline’ın üzerindeki yükseklik) sıfır kabul eder; bu, komşu öğelerin üzerindeki alanı azaltabilir. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | Alt kısmı (baseline’ın altındaki derinlik) sıfır kabul eder; bu, bir kesir çubuğu ya da diğer içeriğin altındaki alanı komşulara yaklaştırabilir. |

Baseline, normal matematik harflerinin oturduğu referans çizgidir. İçeriği gizlemek boyutlarını kaldırmaz; bir boyutu sıfır olarak ayarlamak ifadeyi silmez. Temel ifade, [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) ile hâlâ erişilebilir durumdadır. [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) metoduna `true` verirseniz ifadeyi tekrar gösterirsiniz; boyut ayarları değişmeden kalır.

Aşağıdaki örnek, yan yana beş varyant oluşturur: görülebilir bir kesir, alanı koruyan gizli bir kesir ve bir boyutu sıfır olarak ayarlanmış üç gizli kesir. Her varyant aynı çevre ifadesi ve Cambria Math 24 puntoyu kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir; bu, gri kılavuzla işaretlenmiştir. Phantom’u dış kesirin payına koymak, dikey yerleşim değişikliklerini görmeyi kolaylaştırır.

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

![PowerPoint’te beş denklem: görülebilir kesir, alanı koruyan gizli kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkinleştirilmiş üç gizli kesir](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) kullanarak bir ifade üzerine ya da altına bir grup karakteri koyabilirsiniz. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında “any text” etiketiyle gruplanmış](powerpoint-math-equations_15.png)

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

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiğinde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) bir matematik öğesinin üzerine çubuk ekler.

![Üstte bir çubuk bulunan ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

### **Mevcut Bir Denklemi Biçimlendirme**

Mevcut bir denklemi tüm metin boyunca biçimlendirmek için her matematik bloğunun öğe ağacını dolaşın. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) sadece doğrudan çocukları döndürür; bu yüzden kesirler, üst/alt indisler, kökler ve diğer iç içe yapılar içindeki metne ulaşmak için özyinelemeli olarak çağırmanız gerekir. Başlangıç öğesi de [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) olduğunda bunu da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; payda içinde bir alt indis, payda içinde bir kök bulunur. Sadece bloğun üst düzey öğelerini işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklarına [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) üzerinden erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) metoduyla [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) çağrısıyla yazı tipi boyutunu 28 puana ayarlar.

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

Kaydedilen sunum, işlenen her denklemdeki tüm seviyelerde güncellenmiş metin biçimlendirmesini içerir; metin içeriği ve matematik yapısı korunur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kesir oluşturma | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Üst/alt indis ekleme | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sol taraflı indis ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Toplamalar ve integraller ekleme | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Sınırlayıcı ekleme | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Çizgi ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denkleminde değişiklik yapabilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX’e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) öğesini, [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) metodunu çağırın. Tam bir örnek için [Export Math Equations from Presentations in PHP via Java](/slides/tr/php-java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.