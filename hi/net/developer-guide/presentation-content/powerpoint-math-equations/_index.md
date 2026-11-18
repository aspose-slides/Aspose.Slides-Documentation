---
title: .NET में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
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
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for .NET के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भाग, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे और स्वरूपित गणित ब्लॉक।

PowerPoint में उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणित पाठ होता है:

![एक PowerPoint स्लाइड जिसमें एक संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) के साथ बनाया जाता है, वह आकार है जिसमें समीकरण शामिल होता है।
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट्स को सम्मिलित करता है।

नीचे अधिकांश उदाहरणों में कोड को संक्षिप्त और पठनीय रखने के लिए [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) की फ़्लुएंट विधियों का उपयोग किया गया है।

MathML निर्यात परिदृश्यों के लिये, देखें [प्रेजेंटेशनों से गणितीय समीकरण निर्यात .NET](/slides/hi/net/exporting-math-equations/)।

## **एक समीकरण बनाएं**

यह उदाहरण [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस सिद्धांत जोड़ता है:

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) को एक्सेस करें, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भाजक जोड़ें**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके एक भाजक बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) के साथ एक भाजक शैली चुन सकते हैं।

![एक तिरछा गणितीय भाजक जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड (वारी) भाजक के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व बेस बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-स्थ मूल अभिव्यक्ति जिसमें x मूल संकेत के नीचे है](powerpoint-math-equations_5.png)

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

### **वर्गमूल की डिग्री दिखाएँ या छिपाएँ**

वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x नोटेशन का उपयोग कर सकता है। [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) प्रॉपर्टी [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) यह नियंत्रित करती है कि कौन सा रूप प्रदर्शित हो। दोनों रूप संपादन योग्य समीकरण में डिग्री 2 और radicand x को बनाए रखते हैं।

![एक ही वर्गमूल जिसमें बाएँ ओर HideDegree false और दाएँ ओर true सेट है](square-root-degree.png)

उदाहरण समान वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दिखाई देता है। `hidden-degree.pptx` में यह छिपा रहता है।

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

## **फ़ंक्शन और सीमा जोड़ें**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) या [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) का उपयोग करके `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नाम जैसे फ़ंक्शन बनाएं। सीमाओं के लिये, `lim` को एक [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) में रखें या [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) का उपयोग करें।

![जब x अनंत की ओर बढ़ता है तो x की सीमा](powerpoint-math-equations_8.png)

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

[Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करके योग, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर बनाएं। इंटीग्रल के लिये [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएँ सेट कर सकते हैं।

![निचली और ऊपरी सीमाओं के साथ एक योग](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटर्स के लिये होते हैं जिनकी वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिये, [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिस जोड़ें**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) का उपयोग करके पंक्तियों और स्तंभों को बनाएं। मैट्रिस डिफ़ॉल्ट रूप से कोष्ठक शामिल नहीं करती हैं, इसलिए जब आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिस को घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिस जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

### **मौज़ूदा मैट्रिस को संपादित करें**

मान लीजिए एक रैखिक बीजगणित पाठ `matrix.pptx` में गुणांक मैट्रिस से शुरू होता है, जो पिछले उदाहरण द्वारा सहेजा गया है। अगले अभ्यास के लिये, पहली समीकरण को रखें, दूसरी को दो नई समीकरणों से बदलें, और चरों के सेट को पुनः निर्धारित करें। लागू गुणांकों को रखते हुए मौज़ूदा मैट्रिस को [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) के माध्यम से खोलें।

![मूल दो-पंक्तियों वाला गुणांक मैट्रिस जिसमें पहली पंक्ति में 1, x और एक खाली सेल है और दूसरी पंक्ति में x, 2 और y हैं](matrix-before-edit.png)

पंक्तियों और स्तंभों के सूचक शून्य से शुरू होते हैं और प्रत्येक कॉल पर मैट्रिस की वर्तमान स्थिति का संदर्भ देते हैं। सूचकांक 1 से पहले पंक्ति सम्मिलित करने से मूल दूसरी पंक्ति सूचकांक 2 पर चली जाती है। सूचकांक 2 के बाद सम्मिलित करने से एक पंक्ति जोड़ दी जाती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ी गई पंक्ति एक स्थिति ऊपर ख़िसक जाती है। स्तंभ भी इसी प्रकार शिफ्ट होते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// नई कोशिकाएँ प्रारंभिक रूप से null हैं। पहले गैर-शून्य गुणांक सेट करें।
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) पहले स्तंभ को बाएँ संरेखित करता है। [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) तीन क्रमिक स्तंभों को दाएँ संरेखित करता है, जो सूचकांक 1 से शुरू होते हैं। `updated-matrix.pptx` में, मैट्रिस में तीन समीकरण और चार चरों हैं। मूल पहली पंक्ति के गुणांक `1` और `x` अब पहले और तीसरे स्तंभ में दिखाई देते हैं।

![अपडेटेड तीन-पंक्तियों वाला मैट्रिस जिसमें पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 दिखाए गए हैं](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) का उपयोग तब करें जब आपको संरेखित समीकरण या अभिव्यक्तियों का ऊर्ध्वाधर स्टैक चाहिए।

![एक ऊर्ध्वाधर गणित एरे जिसमें x, y के ऊपर है](powerpoint-math-equations_11.png)

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

### **एरे को आसपास के तत्वों के साथ संरेखित करें**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) एरे की ऊर्ध्वाधर संरेखण को उसके बगल के गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण एरे की पहली पंक्ति, मध्य और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियों और पड़ोसी तत्व `A=` और `=B` होते हैं। सभी गणितीय पाठ Cambria Math 24 पॉइंट में हैं। केवल एरे का संरेखण बदलता है।

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

निम्न तुलना PowerPoint में सहेजी गई प्रस्तुति को दर्शाती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति पर ध्यान दें।

![PowerPoint में समीकरण एरे शीर्ष, मध्य और निचले संरेखण के साथ और समान पड़ोसी तत्वों के साथ](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) एरे की पंक्तियों के लिए अंतराल नियम चुनता है। [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) स्पष्ट अंतराल नियम के लिये एक संख्यात्मक मान देता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिये, मान पॉइंट में मापा जाता है। अनुपाती अंतराल के लिये, इसे आधी लाइनों में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करने पर दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम चयनित नहीं होता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुतियों को सहेजता है। पहले तीन प्रीसेट का उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) और [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) सम्मिलित पैराग्राफ के चारों ओर अंतराल जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी तरह, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे के ऊर्ध्वार संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) का उपयोग करें।

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

## **सबस्क्रिप्ट और सुपर्सक्रिप्ट जोड़ें**

सूचकांक और घात के लिये सबस्क्रिप्ट और सुपर्सक्रिप्ट हेल्पर्स का उपयोग करें। जब सूचकांकों को बेस के बाएँ तरफ दिखाना हो, तो [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) का उपयोग करें।

![एक बड़े Y के बाएँ तरफ सबस्क्रिप्ट 1 और सुपर्सक्रिप्ट n](powerpoint-math-equations_9.png)

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

## **डेलिमिटर जोड़ें**

[Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करके अभिव्यक्ति को डेलिमिटर के भीतर रखें। आप कई तत्वों वाली डेलिमिटर अभिव्यक्तियों के लिये एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डेलिमिटर अभिव्यक्ति जिसमें x, y, और z को वर्टिकल बार से अलग किया गया है](powerpoint-math-equations_13.png)

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

### **डेलिमिटर का आकार और संरेखण**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) को `true` सेट करने से कोष्ठक बड़े ऑपरेन्ड के चारों ओर बढ़ते हैं, या `false` सेट करने से वे सामान्य आकार के रहते हैं। [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से गुजरता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डेलिमिटर को प्रभावित करती हैं। अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भाजक रखा गया है जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित होती है। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे पंक्ति में, वृद्धि बंद है। बाएँ छोटे कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ कोष्ठक (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![PowerPoint में चार समीकरण जिनमें डेलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, तथा बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भाजक पर [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) डिफ़ॉल्ट रूप से चारों पक्ष दिखाता है। व्यक्तिगत पक्ष हटाने के लिये [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), और [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) का उपयोग करें।

उदाहरण में समान भाजक की छह प्रतियां एक स्लाइड पर रखी गई हैं। रद्द करना दिखाने के लिये, सभी चार पक्ष छिपाएँ और ऊपर बाएँ से नीचे दाएँ की ओर रैखिक (↗) के लिये [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) सेट करें या नीचे बाएँ से ऊपर दाएँ (↘) के लिये [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) सेट करें। आप किसी भी दृश्यमान पक्ष के साथ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) या [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) भी उपयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भाजक। शीर्ष पंक्ति: पूर्ण सीमा, नीचे और बाएँ पक्ष, बढ़ता डायगोनल। नीचे पंक्ति: गिरता डायगोनल, क्षैतिज स्ट्राइक, पूर्ण सीमा के साथ ऊर्ध्वाधर स्ट्राइक।](border-box-fractions.png)

इस भाजक में, क्षैतिज स्ट्राइक भाजक रेखा पर छाया बनाता है। ऊर्ध्वाधर स्ट्राइक अंश और हर दोनों को पार करता है जबकि आसपास की सीमा दृश्यमान रहती है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य पाठ स्ट्राइकथ्रू टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को फिर से खोलने के बाद, आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फैंटम तत्वों से दृश्यता और लेआउट नियंत्रित करें**

[MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) में अभिव्यक्ति को लपेटें ताकि उसकी दृश्यता और समीकरण में योगदान देने वाले स्थान को स्वतंत्र रूप से नियंत्रित किया जा सके। [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) प्रॉपर्टी निम्नलिखित को नियंत्रित करती हैं:

| प्रॉपर्टी | प्रभाव |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | `false` सेट करके अभिव्यक्ति को छिपाएँ। इसके आयाम लेआउट में योगदान देते हैं जब तक नीचे की संबंधित प्रॉपर्टी `true` न हों। |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पास के तत्व अधिक करीब आ सकें। |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | इसके आरोह (baseline के ऊपर की ऊँचाई) को शून्य मानें। इससे पास के तत्वों के ऊपर आरक्षित स्थान घट सकता है। |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | इसके अवरोह (baseline के नीचे की गहराई) को शून्य मानें। इससे अभिव्यक्ति के नीचे की भाजक रेखा या अन्य सामग्री पास के तत्वों के करीब आ सकती है। |

Baseline वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसके आयाम नहीं हटते, और आयाम को शून्य मानने से अभिव्यक्ति नहीं हटती। अंतर्निहित अभिव्यक्ति [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) के माध्यम से उपलब्ध रहती है। फिर से दिखाने के लिये [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) को `true` सेट करें; आयाम सेटिंग्स अपरिवर्तित रहती हैं।

नीचे का उदाहरण पाँच साइड-भाई वैरिएंट बनाता है: एक दृश्यमान भाजक, एक छिपा भाजक जो स्थान आरक्षित रखता है, और तीन छिपे भाजक जिनमें से एक आयाम शून्य माना गया है। प्रत्येक वैरिएंट समान आसपास की अभिव्यक्ति और 24 पॉइंट Cambria Math का उपयोग करता है। सभी समीकरण आकारों की शीर्ष स्थिति समान है, जिसे ग्रे गाइड से चिह्नित किया गया है। बाहरी भाजक के अंश में फैंटम रखने से ऊर्ध्वादर लेआउट परिवर्तन देखना आसान हो जाता है।

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

![PowerPoint में पाँच समीकरण जो दृश्यमान भाजक, स्थान आरक्षित करने वाला छिपा भाजक, और ZeroWidth, ZeroAsc, या ZeroDesc सक्षम वाले छिपे भाजकों की तुलना करते हैं](math-phantom.png)

## **टर्म समूहित करें**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे समूहित चरित्र रखें। समूहित टर्म को लेबल करने के लिये सीमा जोड़ें।

![अभिव्यक्ति x + y को समूहित किया गया है और उसके नीचे लेबल कोई भी पाठ](powerpoint-math-equations_15.png)

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

## **गणित तत्वों का स्वरूप**

फ़ॉर्मेटिंग हेल्पर्स केवल तब उपयोग करें जब वे सूत्र को स्पष्ट बनाते हैं। उदाहरण के लिये, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के साथ ओवरबार](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में पाठ का स्वरूप**

मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिये, प्रत्येक गणित ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) केवल तत्काल बच्चों को लौटाता है, इसलिए भिन्न, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के पाठ तक पहुँचने के लिये इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों को जांचें ताकि शुरुआती तत्व को शामिल किया जा सके जब वह [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) हो।

यह उदाहरण मानता है कि प्रस्तुति में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में अंश के अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष-स्तर के तत्वों को प्रोसेस करने से भाजक के भीतर का पाठ छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भाग खोजता है, उनके ब्लॉकों को [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) के माध्यम से पहुँचता है, और प्रत्येक टेक्स्ट तत्व के [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के द्वारा [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) को 28 पॉइंट सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन पाठ स्वरूपण रखती है, जबकि उसके पाठ सामग्री और गणितीय संरचना को संरक्षित रखती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाएँ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| भाजक बनाएं | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ें | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ें | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| योग और इंटीग्रल जोड़ें | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिस जोड़ें | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| डेलिमिटर जोड़ें | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म समूहित करें | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौज़ूदा PowerPoint समीकरण संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, वह आकार खोजें जिसमें [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) हो, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उस पैराग्राफ में गणित ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण का [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) उसके [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिये [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। पूर्ण उदाहरण के लिये देखें [प्रेजेंटेशनों से गणितीय समीकरण निर्यात .NET](/slides/hi/net/exporting-math-equations/#export-math-equations-to-latex)।