---
title: JavaScript'te PowerPoint Sunumlarına Matematik Denklemleri Ekleme
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net JavaScript kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Node.js via Java ile aynı tür matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te, kullanıcılar genellikle denklemleri **Insert > Equation** üzerinden eklerler:

![PowerPoint Insert sekmesi, Equation komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Matematik şekli, [addMathShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan ve denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) içindeki akıcı yöntemleri kullanır.

[MathML Dışa Aktarma Senaryoları için](/slides/tr/nodejs-java/exporting-math-equations/).

## **Denklem Oluşturma**

Bu örnek bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk `MathPortion`a erişin, onun `MathParagraph`ını alın ve ona matematik blokları ya da matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

[`divide`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanarak bir kesir oluşturabilirsiniz. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x'e bölünmüş bir sayıyı gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yığılmış bir kesir için `MathFractionTypes.Bar` kullanın:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Kök Ekleme**

[`radical`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanarak karekök, küpkök veya diğer kökleri oluşturabilirsiniz. Mevcut öğe taban olur, argüman derece olur.

![Kök işareti altında x bulunan n. dereceden kök ifadesi](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fonksiyon ve Limit Ekleme**

[`asArgumentOfFunction`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) veya [`function`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanarak `sin(x)`, `log(x)` gibi fonksiyonlar ya da özel fonksiyon adları ekleyebilirsiniz. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathlimit/) içine koyun veya [`setLowerLimit`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın.

![x'in sonsuza yaklaşırken limiti](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Özel bir fonksiyon adı için fonksiyon adını mevcut öğe yapın:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

[`nary`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanarak toplamlar, birleşimler, kesişimler ve diğer büyük operatörleri ekleyebilirsiniz. İntegraller için [`integral`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle `MathematicalText` olarak eklenir ve ifadeye katılır.

Bir integral için `integral` kullanın:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Matris Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; parantez, köşeli parantez veya süslü parantez gerekirse matrisi bu şekilde sarmalayın.

![Bir boş hücreli iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey ifadeler yığını gerektiğinde [`toMathArray`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın.

![x'in y'nin üzerinde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe olduğunda ve fonksiyon adı bilindiğinde [`asArgumentOfFunction`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın.

![cos fonksiyonunun 2x'e uygulanması](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alt ve Üst Simge Ekleme**

İndeksler ve üssler için alt ve üst simge yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın.

![Sol tarafında alt simge 1 ve üst simge n olan büyük Y](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ayırıcılar Ekleme**

İfadeyi ayırıcıların içine koymak için [`enclose`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın. Birden fazla öğe içeren ayırıcı ifadeleri için ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z'nin dikey çubuklarla ayrıldığı bir ayırıcı ifadesi](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kenar Kutusu Ekleme**

Denklemin kendisinin çerçevelenmesi gerektiğinde [`toBorderBox`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın.

![a² = b² + c² gösteren bir kutulu denklem](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Terimleri Gruplama**

İfadenin üstüne veya altına bir gruplama karakteri yerleştirmek için [`group`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) kullanın. Gruplanmış terimlere etiket eklemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketiyle gruplandırılmış](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Matematik Öğelerini Biçimlendirme**

Formülü açıklayan yerlerde yalnızca biçimlendirme yardımcılarını kullanın. Örneğin, [`overbar`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) bir matematik öğesinin üstüne bir çubuk ekler.

![Üstü çizili ABC matematik ifadesi](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [join](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Kesir oluşturma | [divide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Üst simge veya alt simge ekleme | [setSuperscript](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Sol taraflı alt/üst simge ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Toplamları ve integralleri ekleme | [nary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Ayırıcı ekleme | [enclose](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Üst çubuk ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir `MathPortion` içeren şekli bulun, onun `MathParagraph`ını alın ve o paragraftaki matematik bloklarını güncelleyin.

**Den­kle­mler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Den­kle­leri LaTeX’e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) öğesini, onun [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.toLatex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/#toLatex--) metodunu çağırın. Tam bir örnek için [Node.js via Java ile Sunumlardan Matematik Denklemlerini Dışa Aktarma](/slides/tr/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.