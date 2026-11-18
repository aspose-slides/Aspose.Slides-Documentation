---
title: JavaScript ile PowerPoint Sunumlarına Matematik Denklemleri Ekleme
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
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net JavaScript kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak saklar. Aspose.Slides for Node.js via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N‑türlü operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Ekle > Denklem** menüsünden ekler:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metni olur:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Bir matematik şekli, [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulur ve denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini saklar.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) nesnesini içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) yöntemlerini kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in Node.js via Java](/slides/tr/nodejs-java/exporting-math-equations/) bölümüne bakın.

## **Denklem Oluşturma**

Bu örnek, bir matematik şekli oluşturmak için [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) kullanır ve Pisagor teoremini ekler:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Not" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) öğesine erişin, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

Kesir oluşturmak için [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) kullanın. Bir kesir stili seçmek için [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) kullanabilirsiniz.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Yığılmış bir kesir için, [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Kökler Ekleme**

Kare kök, küp kök veya başka bir kök oluşturmak için [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) kullanın. Geçerli öğe taban olur ve argüman derece olur.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Kare Kökün Derecesini Gösterme veya Gizleme**

Kare kök açık bir 2 gösterebilir veya geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) üzerindeki [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) yöntemi hangi biçimin görüneceğini kontrol eder. Her iki biçim de derecesi 2 ve radikandı x olan düzenlenebilir denklemi korur.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

Örnek aynı kare kökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görünür. `hidden-degree.pptx` dosyasında 2 gizlidir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fonksiyonlar ve Limitler Ekleme**

Fonksiyonlar (ör. `sin(x)`, `log(x)`) veya özel fonksiyon adları için [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ya da [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) kullanın.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Özel bir fonksiyon adı için, fonksiyon adını geçerli öğe yapın ve argümanı ile [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) metodunu çağırın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑türlü Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

N‑türlü operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-` ve `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadenin içine birleştirilir.

İntegral için, [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Matrisler Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez; parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi sarın.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Mevcut Matrisi Düzenleme**

Diyelim ki `matrix.pptx` dosyasında katsayı matrisi, önceki örnekle kaydedildi. Sonraki alıştırmada, ilk denklemi tutun, ikincisini iki yeni denklemle değiştirin ve değişken setini revize edin. Kalan katsayıları korumak için mevcut matrisi [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) aracılığıyla açın.

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda mevcut matrise göre değerlendirilir. İndeks 1'den önce bir satır eklemek, orijinal ikinci satırı indeks 2'ye taşır. İndeks 2'den sonra eklemek bir satır ekler. Satır 2'yi silmek, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konum yukarı taşır. Sütunlar da aynı şekilde kayar.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Yeni hücreler başlangıçta null'dur. Sıfır olmayan katsayıları önce ayarlayın.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) indeks 1'den başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` dosyasında, matris üç denklem ve dört değişkene sahiptir. Orijinal ilk satır katsayıları `1` ve `x` artık ilk ve üçüncü sütunlarda görünür.

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Hizalanmış denklemlere veya dikey bir ifade yığınına ihtiyacınız olduğunda [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) kullanın.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Diziyi Çevreleyen Öğelerle Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) bir dizinin, yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, ilk satır, dizinin merkezi ve son satır hizalamasını karşılaştırır.

Aşağıdaki örnek, üç aynı dizi oluşturur; her biri üç satır ve komşu öğeler `A=` ve `=B` içerir. Tüm matematik metni Cambria Math, 24 punto kullanır. Yalnızca dizi hizalaması değişir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, PowerPoint'te kaydedilmiş sunumu gösterir. `A=` ve `=B` öğelerinin konumuna dikkat edin.

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **Satır Boşluğunu Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) dizi içindeki satırların boşluk kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) açık bir boşluk kuralı için sayısal bir değer sağlar ve önceden ayarlanmış kurallar tarafından yok sayılır.

Kesin boşluk için değer nokta cinsindendir. Orantılı boşluk için yarı‑satır cinsindendir: örnekte `3` değeri 1,5 satır anlamına gelir. Açık bir değer belirtirken her iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek bir boşluk kuralı seçmez.

Aşağıdaki örnek beş sunumu aynı denklemler, hizalama ve yazı tipi ayarlarıyla kaydeder. İlk üçü önceden ayarlardan; son ikisi açık değerlerden oluşur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Dizi satır boşluğu, paragraf boşluğundan ayrıdır. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) diziyi içeren paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Aynı şekilde, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) bütün matematik paragrafını yatay olarak konumlandırır; dizinin dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman geçerli öğe olduğunda ve fonksiyon adı biliniyorsa, [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) kullanın.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Alt Simge ve Üst Simge Ekleme**

İndeksler ve kuvvetler için alt ve üst simge yardımcılarını kullanın. İndeksler temel öğenin sol tarafında görünmeliyse, [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) kullanın.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Sınırlayıcılar Ekleme**

İfadenin etrafına sınırlayıcı koymak için [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) kullanın. Birden fazla öğe içeren sınırlayıcı ifadeler için bir ayırıcı karakter de ayarlayabilirsiniz.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **Sınırlayıcıların Boyutu ve Hizalanması**

Parantezlerin yüksek bir operanda göre büyümesini sağlamak için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) yöntemine `true` gönderin; normal boyutta kalması için `false` gönderin. [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) ile iki [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) değerinden birini seçin. `Centered` parantezleri matematik ekseninde ortalar; bu eksen eşittir işaretinin ortasından geçer. `Match` ise içeriğe göre hizalar. Her iki ayar yalnızca sınırlayıcıları etkiler; içteki ifade aynı kalır.

Bu örnek, `x` üssüne bir kesir yerleştirir; böylece ifade tabandan daha çok yukarı çıkar. Dört denklem aynı parantez ve yazı tipi ayarlarını kullanır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te, büyümenin etkisini görmek için satırları karşılaştırın. Üst satırda, parantezler üssü kapsayacak şekilde büyür ve iki şekil de aynı görünür. Alt satırda büyüme kapalıdır; sol taraf (`Centered`) daha küçük parantezler eşittir işaretiyle hizalanırken, sağ taraf (`Match`) içerik etrafında daha yüksek durur.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **Kenarlıklı Kutular Ekleme**

Bir kesir üzerine [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) çağırarak ifadenin etrafına bir çerçeve ekleyin. Dönen [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) metodlarını kullanın.

Bu örnek aynı kesirin altı kopyasını bir slaytta gösterir. İptal göstermek için tüm kenarları gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight), düşen bir diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metodunu `true` olarak ayarlayın. Ayrıca [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metodlarını istediğiniz kenar kombinasyonlarıyla kullanabilirsiniz.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

Bu kesirde, yatay çizgi kesir çubuğunun üzerine biner. Dikey çizgi hem payı hem de paydayı keser, çevre kenarı ise görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin üzerindeki üst çizgi yalnızca metin koşulları için geçerlidir. Sunumu PowerPoint'te yeniden açtıktan sonra hâlâ pay ve paydayı bağımsız olarak düzenleyebilirsiniz.

## **Phantom Öğelerle Görünürlük ve Düzeni Kontrol Etme**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) içinde sarmalayarak, görünürlüğünü ve denkleme katkı sağladığı alanı bağımsız olarak kontrol edebilirsiniz. [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) metodları aşağıdakileri kontrol eder:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false` göndererek ifadeyi gizleyin. Boyutları hâlâ yerleşime katkıda bulunur, aşağıdaki ilgili metodlar `true` almazsa. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | İfadenin yatay genişliğini sıfır olarak kabul eder, komşu öğelerin daha yakın gelmesini sağlar. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | Üst boşluğu (baseline üzerindeki yüksekliği) sıfır olarak kabul eder, üstteki boşluğu azaltabilir. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | Alt boşluğu (baseline altındaki derinliği) sıfır olarak kabul eder, bir kesir çubuğu gibi öğelerin altındaki boşluğu azaltabilir. |

Baseline, normal matematik harflerinin oturduğu referans çizgisidir. İçeriği gizlemek boyutlarını kaldırmaz; bir boyutu sıfır olarak ayarlamak ifadeyi silmez. İfade, [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) aracılığıyla hâlâ erişilebilir. Tekrar görüntülemek için [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) metoduna `true` gönderin; boyut ayarları değişmez.

Aşağıdaki örnek beş yan yana varyant oluşturur: görünür bir kesir, alanı ayıran gizli bir kesir ve bir boyutu sıfır olan üç gizli kesir. Her varyant aynı çevre ifadesi ve Cambria Math, 24 punto kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir; gri kılavuzla işaretlenmiştir. Phantom öğeyi dış kesirin payına yerleştirmek, dikey düzen değişikliklerini görmeyi kolaylaştırır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **Terimleri Gruplama**

Bir grup karakterini bir ifadenin üstüne veya altına yerleştirmek için [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) kullanın. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Yalnızca formülü netleştiren yerlerde biçimlendirme yardımcılarını kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) bir matematik öğesinin üzerine bir çubuk ekler.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Mevcut Denklemede Metni Biçimlendirme**

Mevcut bir denklemede metni biçimlendirmek için her matematik bloğunun öğe ağacını dolaşın. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür; bu yüzden kesirler, üst/alt simgeler, kökler ve diğer iç içe yapılar içindeki metne ulaşmak için yöntemi yineleme olarak çağırın. Başlangıç öğesi [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) olduğunda da onu ve çocuklarını kontrol edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; bu denklem, payda bir kesir içinde bir alt simge ve payda bir kök içerir. Yalnızca bloğun üst‑seviye öğelerini işlemek, kesir içindeki metni atlayacaktır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklara [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) ile erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) metodunu kullanarak [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi yüksekliğini 28 punto yapar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunum, işlenen her denklemin her seviyesindeki metin biçimlendirmesini günceller; metin içeriği ve matematik yapısı korunur.

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Kesir oluşturma | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Üst simge veya alt simge ekleme | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Sol‑taraflı üst/alt simge ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Toplam ve integral ekleme | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Sınırlayıcı ekleme | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Çizgi ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklemler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office math içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) nesnesini, ilgili [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) metodunu çağırın. Tam bir örnek için, [Export Math Equations from Presentations in Node.js via Java](/slides/tr/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.