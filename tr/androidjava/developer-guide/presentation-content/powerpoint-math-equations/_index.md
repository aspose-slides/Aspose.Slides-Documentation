---
title: Android'de PowerPoint Sunumlarına Matematik Denklemleri Ekle
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net Java kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Android via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te, kullanıcılar genellikle denklemleri **Ekle > Denklem** menüsünden ekler:

![PowerPoint Ekle sekmesinde Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Denklemi içeren şekil, [addMathShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) ile oluşturulan bir matematik şeklidir.
- [MathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) sağladığı akıcı yöntemleri kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations on Android](/slides/tr/androidjava/exporting-math-equations/) bölümüne bakın.

## **Bir Denklem Oluşturma**

Bu örnek bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk `MathPortion`'a erişin, onun `MathParagraph`'ını alın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

`divide` kullanarak bir kesir oluşturun. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![Bir birimin x'e bölünmüş olduğu eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yığılmış bir kesir için `MathFractionTypes.Bar` kullanın:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Kök Ekleme**

`radical` kullanarak karekök, küpkök veya diğer kökleri oluşturun. Mevcut öğe taban olur, argüman ise derece olur.

![Kök işareti altında x bulunan n'inci dereceden kök ifadesi](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fonksiyon ve Limit Ekleme**

`asArgumentOfFunction` veya `function` kullanarak `sin(x)`, `log(x)` gibi fonksiyonları veya özel fonksiyon adlarını ekleyebilirsiniz. Limitler için, `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathlimit/) içine koyun veya `setLowerLimit` kullanın.

![x'in sonsuza giderken limiti](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

`nary` kullanarak toplamalar, birleşimler, kesişimler ve diğer büyük operatörleri ekleyin. İntegraller için `integral` kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitleri olan bir toplam](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle `MathematicalText` olarak eklenir ve ifadeye birleştirilir.

Bir integral için `integral` kullanın:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matris Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi içine alın.

![Bir boş hücreli iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey bir ifade yığını gerektiğinde `toMathArray` kullanın.

![x'in y'nin üzerinde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trigonometri Fonksiyonları Ekleme**

Argüman mevcut öğe ve fonksiyon adı biliniyorsa `asArgumentOfFunction` kullanın.

![cos fonksiyonunun 2x'e uygulanması](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MusicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alt ve Üst İndeks Ekleme**

İndeks ve üsler için alt ve üst indeks yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde `setSubSuperscriptOnTheLeft` kullanın.

![Sol tarafında alt indeks 1 ve üst indeks n olan büyük Y](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sınırlayıcılar Ekleme**

`enclose` kullanarak bir ifadeyi sınırlayıcıların içine koyun. Birden fazla öğe içeren sınırlayıcı ifadeler için bir ayırıcı karakter de belirleyebilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran bir sınırlayıcı ifade](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kenar Kutusu Ekleme**

Denklemin kendisinin çerçevelenmesi gerektiğinde `toBorderBox` kullanın.

![a² = b² + c² gösteren kutulu bir denklem](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Terimleri Gruplama**

`group` kullanarak bir grup karakterini ifadenin üstüne veya altına yerleştirin. Gruplandırılmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketiyle gruplanmış](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Matematik Öğelerini Biçimlendirme**

Biçimlendirme yardımcılarını yalnızca formülü açıklayan yerlerde kullanın. Örneğin, `overbar` bir matematik öğesinin üzerine bir çubuk ekler.

![Üst çubuklu ABC matematik ifadesi](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluştur | [MathematicalText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathematicaltext/) |
| Öğeleri birleştir | [IMathElement.join](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Kesirler oluştur | [IMathElement.divide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Üst indeks veya alt indeks ekle | [setSuperscript](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Fonksiyonlar ekle | [function](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Kökler ekle | [IMathElement.radical](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Limitler ekle | [setLowerLimit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Sol taraflı indeksler ekle | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Toplamalar ve integraller ekle | [nary](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Matrisler ekle | [MathMatrix](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathmatrix/) |
| Denklem dizileri ekle | [toMathArray](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Sınırlayıcılar ekle | [enclose](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Çubuklar ve kenarlar ekle | [overbar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |
| Terimleri grupla | [group](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathelement/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir `MathPortion` içeren şekli bulun, onun `MathParagraph`'ını alın ve ilgili paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [IMathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/) öğesini [IMathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/) üzerinden alın ve doğrudan dışa aktarmak için [IMathParagraph.toLatex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Tam bir örnek için, [Export Math Equations from Presentations in Android via Java](/slides/tr/androidjava/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.