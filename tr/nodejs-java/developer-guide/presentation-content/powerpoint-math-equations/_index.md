---
title: JavaScript ile PowerPoint Sunumlarına Matematik Denklemleri Ekleyin
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
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML desteği, biçimlendirme kontrolleri ve net JavaScript kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint denklemleri Office Math Markup Language (OMML) biçiminde saklar. Aspose.Slides for Node.js via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N‑ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint’te kullanıcılar genellikle **Ekle > Denklem** menüsünden denklemler ekler:

![PowerPoint Ekle sekmesinde Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Bir matematik şekli, [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulur ve denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) şeklin metin çerçevesindeki matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki örneklerin çoğu, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/)’ın akıcı yöntemlerini kullanır.

MathML dışa aktarım senaryoları için [Export Math Equations from Presentations in Node.js via Java](/slides/tr/nodejs-java/exporting-math-equations/) bölümüne bakın.

## **Denklem Oluşturma**

Bu örnek, bir matematik şekli oluşturmak ve Pisagor teoremini eklemek için [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) kullanır:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}

[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) alın, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve ona matematik blokları ya da elemanları ekleyin.

{{% /alert %}}

## **Kesir Ekleme**

Kesir oluşturmak için [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x’e bölünmüş bir kesiri gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

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

Yığınlı bir kesir için [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Kök Ekleme**

Kök (kare kök, küp kök vb.) oluşturmak için [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) kullanın. Mevcut eleman taban olur, argüman ise derecedir.

![x altında kök işareti bulunan n‑inci kök ifadesi](powerpoint-math-equations_5.png)

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

## **Fonksiyonlar ve Limitler Ekleme**

`sin(x)`, `log(x)` gibi fonksiyonlar için [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ya da [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) kullanın.

![x’in sonsuza giderken limiti](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için fonksiyon adını mevcut eleman yapın ve argümanı ile [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) çağırın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

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

N‑ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadeye bağlanır.

İntegral için [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Matris Ekleme**

Satır ve sütunları tanımlamak için [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; parantez, köşeli ya da süslü paranteze ihtiyacınız olduğunda matrisi kendiniz sarın.

![Bir boş hücre içeren iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

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

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey bir ifadeler yığını gerektiğinde [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) kullanın.

![x’in y üzerindeki dikey bir matematik dizisi](powerpoint-math-equations_11.png)

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

### **Diziyi Çevreleyen Elemanlarla Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification), bir dizi ile yanındaki matematiksel elemanlar arasındaki dikey hizalamayı kontrol eder. Aşağıdaki örnek, ilk satır, dizi ortası ve son satır hizalamasını karşılaştırır.

Aşağıdaki örnek, üç aynı dizi oluşturur; her biri üç satır ve komşu elemanlar `A=` ve `=B` içerir. Tüm matematik metni Cambria Math, 24 punto olarak ayarlanmıştır. Yalnızca dizi hizalaması değişir.

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

Aşağıdaki karşılaştırma, PowerPoint’te kaydedilmiş sunumu gösterir. `A=` ve `=B` konumuna dikkat edin.

![PowerPoint’te Üst, Orta ve Alt hizalama ile aynı komşu elemanlara sahip denklem dizileri](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) dizi içinde satırların aralık kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) kesin bir aralık kuralı için sayısal bir değer sağlar ve önceden tanımlı kurallar tarafından yoksayılır.

Kesin aralık için değer puan cinsindendir. Orantılı aralık için yarım satır birimi kullanılır: örnekte `3` değeri 1,5 satır anlamına gelir. Açık bir değer belirtirken her iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek bir kural seçmez.

Aşağıdaki örnek, aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön ayarları; son ikisi ise açık değerleri gösterir.

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

Dizi satır aralığı paragraf aralığından ayrıdır. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) kapsayan paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Benzer şekilde, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) bütün matematik paragrafını yatay konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut eleman olduğunda ve fonksiyon adı bilindiğinde [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) kullanın.

![2x üzerine uygulanan cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

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

## **Alt ve Üst İndeks Ekleme**

İndeks ve üs için alt ve üst indis yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerektiğinde [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) kullanın.

![Sol tarafta alt indeks 1 ve üst indis n olan büyük Y harfi](powerpoint-math-equations_9.png)

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

İfadeyi sınırlayıcıların içine koymak için [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) kullanın. Birden fazla eleman içeren sınırlayıcı ifadeler için ayırıcı karakter de belirtebilirsiniz.

![x, y ve z’nin dikey çubuklarla ayrıldığı bir sınırlayıcı ifadesi](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıları Boyutlandırma ve Hizalama**

Parantezlerin yüksek bir operandı çevrelemesi için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)’a `true` gönderin; normal boyutta kalmasını istiyorsanız `false` gönderin. [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) ile iki [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) değerinden birini seçin. `Centered` parantezleri matematik eksenine, yani eşittir işaretinin ortasına ortalar. `Match` ise içerdiği içeriğe göre hizalar. Her iki ayar da yalnızca sınırlayıcıları etkiler; içteki ifade aynı kalır.

Örnek, `x` in üstünde bir kesir koyar, böylece ifade tabandan daha yukarı çıkar. Dört denklem de aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint’te büyüme etkisini görmek için satırları karşılaştırın. Üst satırda parantezler üste doğru büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır; sol taraftaki daha küçük parantez (`Centered`) eşittir işaretiyle hizalanırken, sağ taraftaki (`Match`) ifadeyi daha yukarıda tutar.

![Parantez büyümesi açık ve kapalı olarak dört denklem, sol tarafta Centered, sağ tarafta Match](delimiter-sizing.png)

## **Köşe Kutusu Ekleme**

Bir kesir üzerine [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) çağırarak bütün ifadeyi çerçeveleyin. Dönen [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) kullanın.

Örnek, aynı kesirin altı kopyasını bir slayta yerleştirir. İptal göstermek için tüm dört kenarı gizleyin ve yükselen çapraz için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) ‘true’ gönderin (↗) ya da düşen çapraz için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) ‘true’ gönderin (↘). Ayrıca, görünür kenar kombinasyonlarıyla [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) kullanabilirsiniz.

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

![PowerPoint’te altı düzenlenebilir kesir. Üst satır: tam çerçeve, alt ve sol kenarlar, yükselen çapraz. Alt satır: düşen çapraz, yatay kesik, dikey kesik ve tam çerçeve.](border-box-fractions.png)

Bu kesirde, yatay kesik kesir çubuğunun üzerine binmektedir. Dikey kesik hem payı hem de paydayı keserken çevre çerçeve görünür kalır. Bu çizgiler bütün ifadeyi süsler. Normal metin üzeri çizgisi yalnızca metin çalıştırındaki karakterlere uygulanır. PowerPoint’te sunumu yeniden açtıktan sonra pay ve payda bağımsız olarak düzenlenebilir.

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) kullanarak bir grup karakterini ifadenin üstüne ya da altına yerleştirin. Gruplanan terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında “any text” etiketiyle gruplanmış](powerpoint-math-equations_15.png)

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

## **Matematik Elemanlarını Biçimlendirme**

Yalnızca formülü açıklığa kavuşturduğunda biçimlendirme yardımcılarını kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) bir matematik elemanının üzerine bir çubuk yerleştirir.

![Üstü çizgili ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

### **Mevcut Bir Denklemi Biçimlendirme**

Mevcut bir denklemi metin boyunca biçimlendirmek için her matematik bloğunun eleman ağacını dolaşın. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür; bu yüzden kesir, üst-alt indis, kök gibi iç içe yapıların içindeki metne ulaşmak için yinelemeli olarak çağırın. Eleman [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) olduğunda da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; burada payda kök, payda ise alt indisli bir kesir bulunur. Yalnızca blokların üst‑seviye elemanlarını işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklarına [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) ile erişir ve her metin elemanının [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) metodunu kullanarak [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi boyutunu 28 punto yapar.

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

Kaydedilen sunum, işlenen her denklemin tüm düzeylerinde güncellenmiş metin biçimlendirmesini içerir; metin içeriği ve matematik yapısı korunur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Elemanları birleştirme | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Kesir oluşturma | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Üst‑alt indis ekleme | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Sol‑taraflı üst‑alt indis ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Toplam ve integral ekleme | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Sınırlayıcı ekleme | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Çubuk ve çerçeve ekleme | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX’e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) nesnesini [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) çağırın. Tam bir örnek için [Export Math Equations from Presentations in Node.js via Java](/slides/tr/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.