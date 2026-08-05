---
title: PHP'de PowerPoint Sunumlarına Matematik Denklemleri Ekleyin
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

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for PHP via Java ile aynı tür matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Ekle > Denklem** üzerinden ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç temel nesne aracılığıyla oluşturur:

- Denklemi içeren şekil, [addMathShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şeklidir.
- [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) akıcı yöntemlerini kullanır.

MathML dışa aktarım senaryoları için [Sunumlardan PHP via Java'da Matematik Denklemlerini Dışa Aktar](/slides/tr/php-java/exporting-math-equations/).

## **Denklem Oluşturma**

Bu örnek bir matematik şekli oluşturur ve Pisagor teoremini ekler:

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

{{% alert color="primary" %}}
`addMathShape` zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk `MathPortion`a erişin, `MathParagraph`ını alın ve ona matematik blokları ya da matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

Kesir oluşturmak için [`divide`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

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

Katmanlı bir kesir için `MathFractionTypes::Bar` kullanın:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Kök Ekleme**

Karekök, küpkök veya diğer kökleri oluşturmak için [`radical`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Mevcut öğe taban olur, argüman ise derecedir.

![Kök işareti altında x bulunan n'inci dereceden bir kök ifadesi](powerpoint-math-equations_5.png)

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

`sin(x)`, `log(x)` gibi fonksiyonlar ya da özel fonksiyon adları için [`asArgumentOfFunction`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) veya [`function`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Limitler için `lim` i bir [MathLimit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathlimit/) içine koyun veya [`setLowerLimit`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın.

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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary Operatör ve İntegral Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [`nary`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. İntegraller için [`integral`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

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

N-ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-` ve `=` gibi basit operatörler genellikle `MathematicalText` olarak eklenir ve ifadeye birleştirilir.

İntegral için `integral` kullanın:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matris Ekleme**

Satırlar ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi bu işaretlerle sarın.

![Bir boş hücreli iki satırlı matematik matrisi](powerpoint-math-equations_10.png)

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

Hizalanmış denklemler veya dikey bir ifade yığını gerektiğinde [`toMathArray`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın.

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

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe olduğunda ve fonksiyon adı bilindiğinde [`asArgumentOfFunction`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın.

![2x'e uygulanan trigonometrik fonksiyon cos](powerpoint-math-equations_6.png)

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

## **Alt ve Üst İndis Ekleme**

İndeksler ve üsteler için alt ve üst indis yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın.

![Sol tarafında 1 alt indis ve n üst indis olan büyük Y](powerpoint-math-equations_9.png)

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

Bir ifadeyi sınırlayıcılar içine koymak için [`enclose`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de ayarlayabilirsiniz.

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

## **Kenar Kutusu Ekleme**

Denklemin kendisinin çerçevelenmesi gerektiğinde [`toBorderBox`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın.

![a² = b² + c² gösteren kutulu bir denklem](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Terimleri Gruplama**

Bir ifadeye grup karakteri üstüne ya da altına yerleştirmek için [`group`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) kullanın. Gruplanan terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketi ile gruplanmış](powerpoint-math-equations_15.png)

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

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiği yerlerde kullanın. Örneğin, [`overbar`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) bir matematik öğesi üzerine çubuk koyar.

![Üstü çizili ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [join](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Kesirler oluşturma | [divide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Üst indeks veya alt indeks ekleme | [setSuperscript](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Kökler ekleme | [radical](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Limitler ekleme | [setLowerLimit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Sol taraflı alt/üst indis ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Toplamalar ve integraller ekleme | [nary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Sınırlayıcılar ekleme | [enclose](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Üst çubuk ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir `MathPortion` içeren şekli bulun, onun `MathParagraph`ını alın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/)ını [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph::toLatex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/#toLatex) çağırın. Tam bir örnek için [Sunumlardan PHP via Java'da Matematik Denklemlerini Dışa Aktar](/slides/tr/php-java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.