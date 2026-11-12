---
title: PowerPoint प्रस्तुतियों में .NET के साथ गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
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
description: "Aspose.Slides for .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट C# कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for .NET के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर्स, मैट्रिसेज़, एरे, और स्वरूपित गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जो [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) के साथ बनाया गया है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ़्रेम के अंदर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट होते हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) से फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पढ़ने योग्य रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [प्रस्तुतीकरणों से .NET में गणितीय समीकरण निर्यात करें](/slides/hi/net/exporting-math-equations/)।

## **समीकरण बनाना**

यह उदाहरण [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) का उपयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

![समीकरण c² = a² + b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) तक पहुंचें, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ना**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

## **मूल जोड़ना**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके वर्गमूल, घनमूल, या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और आर्ग्युमेंट डिग्री बन जाता है।

![एक n-वीं मूल अभिव्यक्ति जिसमें x मूल संकेत के नीचे है](powerpoint-math-equations_5.png)

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

## **फ़ंक्शन और सीमाएँ जोड़ना**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) या [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) का उपयोग करके `sin(x)`, `log(x)` जैसे फ़ंक्शन या कस्टम फ़ंक्शन नाम बनाएं। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) में रखें या [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) का उपयोग करें।

![x का सीमा जब x अनंत की ओर जाता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, वर्तमान तत्व को फ़ंक्शन नाम बनाएं और उसके आर्ग्युमेंट के साथ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) को कॉल करें:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary ऑपरेटर्स और इंटीग्रल्स जोड़ना**

[ Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करके समाकलन, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटर्स बनाएं। इंटीग्रल्स के लिए [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों मेथड्स आपको निचली और ऊपरी सीमाएँ सेट करने की अनुमति देते हैं।

![निचली और ऊपरी सीमाओं के साथ समाकलन](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) के माध्यम से जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिसेज़ जोड़ना**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) का उपयोग करके पंक्तियों और स्तंभों को परिभाषित करें। मैट्रिसेज़ में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या कर्ली ब्रैकेट चाहिए तो मैट्रिक्स को इनके भीतर रखें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली कोशिका है](powerpoint-math-equations_10.png)

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

## **समीकरण एरेज़ जोड़ना**

जब आपको संरेखित समीकरण या व्यवस्थित अभिव्यक्तियों की लंबवत स्टैक चाहिए, तो [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) का उपयोग करें।

![एक लंबवत गणितीय एरे जहाँ x y के ऊपर है](powerpoint-math-equations_11.png)

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

### **आस-पास के तत्वों के साथ एरे को संरेखित करना**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) एरे को उसके बगल में मौजूद गणितीय तत्वों के सापेक्ष लंबवत संरेखण को नियंत्रित करता है। नीचे दिया गया उदाहरण पहली पंक्ति, एरे के केंद्र, और आखिरी पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और निकटवर्ती तत्व `A=` और `=B` होते हैं। सभी गणितीय टेक्स्ट Cambria Math फ़ॉन्ट 24 पॉइंट पर है। केवल एरे का संरेखण बदलता है।

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

निम्न तुलना PowerPoint में संग्रहीत प्रस्तुति को दिखाती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति ध्यान दें।

![PowerPoint में समीकरण एरेज़ के साथ शीर्ष, मध्य, और निचला संरेखण और समान आस-पास के तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करना**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) एरे के भीतर पंक्तियों के लिए अंतराल नियम चुनता है। [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) स्पष्ट अंतराल मान प्रदान करता है और पूर्वनिर्धारित नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए यह आधी-लाइन में मापा जाता है: उदाहरण में मान `3` का अर्थ 1.5 लाइनों का अंतराल है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से कोई अंतराल नियम नहीं चुना जाता।

नीचे का उदाहरण वही समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुतियां सहेजता है। पहली तीन प्रीसेट उपयोग करती हैं; अंतिम दो स्पष्ट मान दिखाती हैं।

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

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) और [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) पैराग्राफ के चारों ओर स्पेस जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थिति देता है; यह एरे की लंबवत संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ना**

जब आर्ग्युमेंट वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) का उपयोग करें।

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

## **सबसक्रिप्ट और सुपरसक्रिप्ट जोड़ना**

इंडेक्स और घात के लिए सबसक्रिप्ट और सुपरसक्रिप्ट हेल्पर्स का उपयोग करें। जब इंडेक्स को आधार के बाएँ पक्ष पर दिखाना हो, तो [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) का उपयोग करें।

![एक बड़े अक्षर Y के बाएँ-साइड पर सबसक्रिप्ट 1 और सुपरसक्रिप्ट n](powerpoint-math-equations_9.png)

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

## **डिलिमीटर जोड़ना**

एक अभिव्यक्ति को डिलिमीटर के भीतर रखने के लिए [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करें। कई तत्वों वाली डिलिमीटर अभिव्यक्तियों के लिए आप विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमीटर अभिव्यक्ति जिसमें x, y, और z को लंबवत बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

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

### **डिलिमीटर का आकार और संरेखण**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) को `true` पर सेट करने से पैरेंथेसिस लंबी ऑपरेण्ड के आसपास बढ़ते हैं, या `false` पर सामान्य आकार पर रहते हैं। [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `Centered` पैरेंथेसिस को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिन्ह के मध्य से गुजरता है। `Match` उन्हें समाहित सामग्री के साथ गठित करता है। दोनों सेटिंग्स केवल डिलिमीटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में एक भिन्न को `x` के एक्सपोनेंट में रखा गया है जिससे अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तारित होती है। सभी चार समीकरण समान पैरेंथेसिस और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, प्रभाव देखने के लिए पंक्तियों की तुलना करें। शीर्ष पंक्ति में पैरेंथेसिस एक्सपोनेंट को कवर करने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में वृद्धि बंद है। बाएँ की छोटी पैरेंथेसिस (`Centered`) बराबर चिन्ह के साथ संरेखित होती है, जबकि दाएँ की (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होती है।

![PowerPoint में चार समीकरण जिनमें डिलिमीटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, और बाएँ `Centered` तथा दाएँ `Match` है](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ना**

एक भिन्न पर [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) को कॉल करके पूरे अभिव्यक्ति को फ्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) डिफ़ॉल्ट रूप से चारों ओर दिखाता है। व्यक्तिगत पक्षों को हटाने के लिए [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), और [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) का उपयोग करें।

उदाहरण में एक ही स्लाइड पर समान भिन्न की छह प्रतियां रखी गई हैं। रद्दीकरण दिखाने के लिए सभी चार पक्ष छिपाएँ और [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) का उपयोग करके ऊपर की ओर तिरछी रेखा (↗) बनाएं या नीचे की ओर तिरछी रेखा (↘) के लिए [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) का उपयोग करें। आप किसी भी संयोजन में दृश्य पक्षों के साथ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) या [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) का भी उपयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूर्ण बॉर्डर, निचला और बायाँ पक्ष, ऊपर की ओर तिरछी रेखा। निचली पंक्ति: नीचे की ओर तिरछी रेखा, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ ऊर्ध्वाधर स्ट्राइक।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा के ऊपर ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक अंश और हर दोनों को काटता है जबकि बाउंडर दृश्य रहता है। ये रेखाएं पूरी अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति पुनः खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म्स को ग्रुप करना**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक ग्रुपिंग कैरेक्टर रखें। ग्रुपेड टर्म्स को लेबल करने के लिए सीमा जोड़ें।

![एक अभिव्यक्ति x + y को लेबल any text के साथ नीचे समूहित किया गया है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का फ़ॉर्मेट**

केवल तभी फ़ॉर्मेटिंग हेल्पर्स का प्रयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) एक गणितीय तत्व के ऊपर बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट का फ़ॉर्मेट**

मौजूदा समीकरण में पूरे टेक्स्ट को फ़ॉर्मेट करने के लिए, प्रत्येक गणितीय ब्लॉक के एलिमेंट ट्री को ट्रवर्स करें। [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) केवल तत्काल चाइल्ड्स लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, रेडिकल और अन्य नेस्टेड स्ट्रक्चर के भीतर टेक्स्ट तक पहुंचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें ताकि शुरुआती तत्व को भी शामिल किया जा सके जब वह [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) हो।

यह उदाहरण मानता है कि प्रस्तुति में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश में सबसक्रिप्ट और हर में रेडिकल है। केवल ब्लॉक के टॉप-लेवल तत्वों को प्रोसेस करने से फ्रैक्शन के भीतर का टेक्स्ट छूट जाएगा। यह उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्सों को खोजता है, उनके ब्लॉकों को [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) को 28 पॉइंट सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अपडेटेड टेक्स्ट फ़ॉर्मेट रखती है, जबकि टेक्स्ट कंटेंट और गणितीय संरचना को संरक्षित रखती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाना | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाना | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाना | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरसक्रिप्ट या सबसक्रिप्ट जोड़ना | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ना | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ना | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| सीमा जोड़ना | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ना | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| समाकलन और समाकल जोड़ना | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिसेज़ जोड़ना | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरेज़ जोड़ना | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| डिलिमीटर जोड़ना | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ना | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म्स को ग्रुप करना | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) हो, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉकों को अपडेट करें।

**क्या समीकरणों को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हां। जब आप PPTX में सहेजते हैं, तो Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हां। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। एक पूर्ण उदाहरण के लिए देखें [प्रस्तुतीकरणों से .NET में गणितीय समीकरण निर्यात करें](/slides/hi/net/exporting-math-equations/#export-math-equations-to-latex)।