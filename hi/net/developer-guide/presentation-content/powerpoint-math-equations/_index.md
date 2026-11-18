---
title: ".NET में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें"
linktitle: "PowerPoint गणितीय समीकरण"
type: docs
weight: 80
url: /hi/net/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय प्रतीक
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय प्रतीक जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट C# कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for .NET के साथ, आप प्रोग्रामेटिक रूप से इसी प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

In PowerPoint, users normally add equations from **Insert > Equation**:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) के माध्यम से बनाया जाता है, वह आकार है जो समीकरण को रखता है।
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ़्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) वस्तुओं को सम्मिलित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) से प्राप्त प्रवाहमान विधियों का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

प्रस्तुति में .NET से गणितीय समीकरण निर्यात के लिए, देखें [प्रेजेंटेशन से .NET में गणितीय समीकरण निर्यात](/slides/hi/net/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) एक आकार बनाता है जिसमें पहले से एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) तक पहुँचें, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जो एक को x द्वारा विभाजित दिखाता है](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n केवें मूल का अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **वर्गमूल की डिग्री दिखाएँ या छुपाएँ**

एक वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x नोटेशन का उपयोग कर सकता है। [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) प्रॉपर्टी [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) की निर्धारित करती है कि कौन सा रूप दिखे। दोनों रूप संपादन योग्य समीकरण में डिग्री 2 और रैडिकेंड x को बनाए रखते हैं।

![इसी वर्गमूल में बाएँ पर HideDegree false और दाएँ पर true सेट किया गया है](square-root-degree.png)

यह उदाहरण वही वर्गमूल दो बार सहेजता है। `visible-degree.pptx` में 2 दिखती है। `hidden-degree.pptx` में यह छिपी हुई है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **फ़ंक्शन और लिमिट जोड़ें**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) या [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) का उपयोग फ़ंक्शन जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नामों के लिए करें। लिमिट के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) में रखें या [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) का उपयोग करें।

![जैसे x अनंत की ओर बढ़ता है, इसका लिमिट](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) को कॉल करें:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

[Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) का उपयोग संकलन, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटरों के लिए करें। इंटीग्रल के लिए [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों विधियाँ आपको निचली और ऊपरी लिमिट सेट करने देती हैं।

![निचली और ऊपरी लिमिट के साथ एक समिश्रण](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N-ary ऑपरेटर वैकल्पिक लिमिट वाले बड़े ऑपरेटरों के लिए होते हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) का उपयोग पंक्तियों और स्तंभों के लिए करें। डिफ़ॉल्ट रूप से मैट्रिक्स में ब्रैकेट नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![एक दो पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **समीकरण ऐरे जोड़ें**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) का उपयोग तब करें जब आपको संरेखित समीकरण या अभिव्यक्तियों का लंबवत स्टैक चाहिए।

![एक लंबवत गणितीय ऐरे जिसमें x ऊपर y है](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

### **परिवेशीय तत्वों के साथ ऐरे को संरेखित करें**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) ऐरे की वर्टीकल संरेखण को उसके बगल के गणितीय तत्वों के संबंध में नियंत्रित करता है। नीचे दिया गया उदाहरण पहले पंक्ति, ऐरे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान ऐरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` और `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math 24 पॉइंट में उपयोग करता है। केवल ऐरे की संरेखण बदलती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

निम्न तुलना PowerPoint में सहेजे गए प्रस्तुति को दिखाती है। प्रत्येक ऐरे के बगल में `A=` और `=B` की स्थिति पर ध्यान दें।

![PowerPoint में समीकरण ऐरे जिनमें शीर्ष, मध्य, और निचला संरेखण है तथा समान पड़ोसी तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) ऐरे में पंक्तियों के लिए अंतराल नियम चुनता है। [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) स्पष्ट अंतराल नियम के लिए एक संख्यात्मक मान प्रदान करता है और पूर्वनिर्धारित नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए, मान को पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए, इसे आधी लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करने पर दोनों प्रॉपर्टी सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं चुना जाता।

नीचे का उदाहरण पाँच प्रस्तुतियों को समान समीकरण, संरेखण, और फ़ॉन्ट सेटिंग्स के साथ सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; आखिरी दो स्पष्ट मान दिखाते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

ऐरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) और [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) शामिल पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि ऐरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह ऐरे के वर्टिकल संरेखण सेटिंग को नहीं बदलता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) का उपयोग तब करें जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स को आधार के बायीं ओर दिखाना हो, तो [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) का उपयोग करें।

![एक बड़े Y के बायीं ओर सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **डिलिमिटर जोड़ें**

[Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करके एक अभिव्यक्ति को डिलिमिटर के भीतर रखें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y और z को वर्टिकल बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **डिलिमिटर का आकार और संरेखण**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) को `true` सेट करने से लंबी ऑपरेण्ड के चारों ओर कोष्ठक बड़ा हो जाता है, या `false` सेट करने से वे सामान्य आकार में रहते हैं। [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिन्ह के मध्य से गुजरता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। भीतर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के घात में एक भिन्न रखा गया है जिससे अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तृत होती है। चारों समीकरण एक ही कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

PowerPoint में, पंक्तियों की तुलना करें ताकि वृद्धि का प्रभाव देखा जा सके। शीर्ष पंक्ति में, कोष्ठक घात को घेरने के लिए बड़े होते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में, वृद्धि बंद है। बाईं ओर के छोटे कोष्ठक (`Centered`) बराबर चिन्ह के साथ संरेखित होते हैं, जबकि दाईं ओर (`Match`) अभिव्यक्ति के चारों ओर अधिक ऊपर होते हैं।

![PowerPoint में चार समीकरण जिनमें डिलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, तथा बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्‍न पर [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) कॉल करें ताकि पूरी अभिव्यक्ति को फ्रेम किया जा सके। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) डिफ़ॉल्ट रूप से सभी चार पक्ष दिखाता है। व्यक्तिगत पक्ष हटाने के लिए [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), और [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) का उपयोग करें।

उदाहरण में एक स्लाइड पर समान भिन्न के छह प्रतियों को रखा गया है। रद्द दिखाने के लिए, सभी चार पक्ष छुपाएँ और एक बढ़ती विकर्ण (↗) के लिए [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/), या गिरती विकर्ण (↘) के लिए [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) सेट करें। आप किसी भी दृश्य पक्ष के संयोजन के साथ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) या [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) भी उपयोग कर सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![PowerPoint में छह संपादन योग्य भिन्‍न। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, बढ़ती विकर्ण। निचली पंक्ति: गिरती विकर्ण, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ लंबवत स्ट्राइक।](border-box-fractions.png)

इस भिन्‍न में, क्षैतिज स्ट्राइक भिन्‍न बार के ऊपर आता है। लंबवत स्ट्राइक अंश और हर दोनों को काटता है जबकि घेराव वाला बॉर्डर दिखाई देता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को फिर से खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **Phantom तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

किसी अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) में लपेटें ताकि उसकी दृश्यता और समीकरण में योगदान करने वाले स्थान को स्वतंत्र रूप से नियंत्रित किया सके। [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) की विशेषताएँ निम्नलिखित को नियंत्रित करती हैं:

| प्रॉपर्टी | प्रभाव |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | इसे `false` सेट करने से अभिव्यक्ति छुप जाती है। इसके आयाम लेआउट में योगदान देते रहेंगे जब तक नीचे की संबंधित प्रॉपर्टी `true` न हों। |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व करीब आ सकें। |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | उसकी आरोहण, अर्थात बेसलाइन के ऊपर की ऊँचाई को शून्य मानें। यह पड़ोसी तत्वों के ऊपर आरक्षित स्थान को कम कर सकता है। |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | उसकी अवरोहण, अर्थात बेसलाइन के नीचे की गहराई को शून्य मानें। यह भिन्‍न बार या अन्य सामग्री को अभिव्यक्ति के नीचे के पड़ोसी तत्वों के करीब ला सकता है। |

बेसलाइन वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छुपाने से उसके आयाम नहीं हटते, और आयाम को शून्य मानने से अभिव्यक्ति नहीं हटती। अंतर्निहित अभिव्यक्ति [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) के माध्यम से उपलब्ध रहती है। [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) को फिर से `true` सेट करने से वह फिर प्रदर्शित होगा; आयाम सेटिंग्स अपरिवर्तित रहती हैं।

नीचे का उदाहरण पाँच साइड‑बाय‑साइड वैरिएंट बनाता है: एक दृश्य भिन्‍न, एक छिपा भिन्‍न जो स्थान आरक्षित करता है, और शून्य आयाम वाले तीन छिपे भिन्‍न। प्रत्येक वैरिएंट समान परिवेशीय अभिव्यक्ति और Cambria Math 24 पॉइंट का उपयोग करता है। सभी समीकरण आकारों की शीर्ष स्थिति समान है, ग्रे गाइड द्वारा चिह्नित। बाहरी भिन्‍न के अंश में फैंटम रखने से वर्टिकल लेआउट परिवर्तन आसानी से देखे जा सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![PowerPoint में पाँच समीकरण जो एक दृश्य भिन्‍न, स्थान आरक्षित करने वाला छिपा भिन्‍न, और ZeroWidth, ZeroAsc, या ZeroDesc सक्रिय वाले छिपे भिन्‍नों की तुलना करते हैं](math-phantom.png)

## **टर्म समूहित करें**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके एक समूहिंग चरित्र को अभिव्यक्ति के ऊपर या नीचे रखें। समूहित टर्म को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को नीचे किसी भी पाठ लेबल के साथ समूहित किया गया](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **गणितीय तत्वों का स्वरूप**

फ़ॉर्मेटिंग हेल्पर केवल तभी उपयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसके ऊपर बार है](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **मौजूदा समीकरण में टेक्स्ट को स्वरूपित करें**

मौजूदा समीकरण के पूरे टेक्स्ट को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) केवल सीधे बच्चों को लौटाता है, इसलिए फ्रैक्शन, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर टेक्स्ट तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) हो तो उसे भी शामिल करने के लिए वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें।

यह उदाहरण मानता है कि प्रस्तुति में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश के अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष-स्तर तत्वों को प्रोसेस करने से भिन्‍न के भीतर का टेक्स्ट खो जाएगा। उदाहरण स्लाइड टेक्स्ट फ़्रेम में गणितीय भागों को खोजता है, उनके ब्लॉक्स को [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व की [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) को 28 पॉइंट सेट करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

सेव किया गया प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट फ़ॉर्मेटिंग रखता है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को संरक्षित करता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को जोड़ें | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ें | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ें | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| लिमिट जोड़ें | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| समिश्रण और इंटीग्रल जोड़ें | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| डिलिमिटर जोड़ें | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म समूहित करें | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, वह आकार खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) हो, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उस पैराग्राफ में गणित ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सेव होते हैं?**

हाँ। जब आप PPTX में सेव करते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण की [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) कॉल करें। पूर्ण उदाहरण के लिए, देखें [प्रेजेंटेशन से .NET में गणितीय समीकरण निर्यात](/slides/hi/net/exporting-math-equations/#export-math-equations-to-latex)।