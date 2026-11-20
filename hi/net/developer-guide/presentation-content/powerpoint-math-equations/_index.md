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

PowerPoint समीकरणों को Office Math Markup Language (OMML) में संग्रहीत करता है। Aspose.Slides for .NET के साथ, आप प्रोग्रामmatically समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, सरणी, और स्वरूपित गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) से बनाया जाता है, वह आकार है जिसमें समीकरण शामिल होता है।
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट्स को रखता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) की फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [प्रस्तुतीकरणों में .NET से गणितीय समीकरण निर्यात](/slides/hi/net/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) का उपयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

![समिकरण c² = a² + b²](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) तक पहुंचें, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

### **गणित ब्लॉक्स को मिलाएँ**

जब किसी समीकरण के भाग स्वतंत्र रूप से [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) ऑब्जेक्ट्स के रूप में बनाए जाते हैं, तो उन्हें मिलाने के लिए [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) का उपयोग करें। उदाहरण `c² =` को बाएँ ब्लॉक में और `a² + b²` को दाएँ ब्लॉक में बनाता है। [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) सभी तीन पावरों के लिए संपादन योग्य गणितीय सुपरस्क्रिप्ट बनाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) `leftBlock` को स्वयं लौटाता है, अब क्रम में दोनों भागों को शामिल करता है, और `rightBlock` को खाली छोड़ता है। संयुक्त ब्लॉक को केवल एक बार [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) में जोड़ें। `equation.pptx` को पुनः खोलने के बाद, पैराग्राफ में एक ब्लॉक होता है जो `c² = a² + b²` को दर्शाता है, सभी तीन पावरों को गणितीय सुपरस्क्रिप्ट के रूप में संरक्षित रखता है।

`leftBlock.Add(rightBlock)` के रूप में [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) को कॉल करने से एक ब्लॉक को सीधे दूसरे के भीतर नेस्ट करने का प्रयास होता है और `InvalidOperationException` उत्पन्न होता है।

## **भिन्न जोड़ें**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके आप एक भिन्न बना सकते हैं। आप [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जो 1 को x से विभाजित दिखाता है](powerpoint-math-equations_4.png)

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

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके आप वर्गमूल, घनमूल या अन्य मूल बना सकते हैं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑th मूल अभिव्यक्ति जिसमें x मूल चिन्ह के नीचे है](powerpoint-math-equations_5.png)

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

वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x संकेत उपयोग कर सकता है। [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) प्रॉपर्टी [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) यह नियंत्रित करती है कि कौन सा रूप प्रदर्शित हो। दोनों रूप डिग्री 2 और radicand x को संपादन योग्य समीकरण में रखता है।

![समान वर्गमूल जिसमें बाएँ पर HideDegree false और दाएँ पर true सेट है](square-root-degree.png)

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

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए आप [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) या [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) का उपयोग कर सकते हैं। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) में रखें या [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) का उपयोग करें।

![सीमा जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

समाकलन, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिए आप [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करें। इंटीग्रल के लिए [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों मेथड आपको निचली और ऊपरी सीमाएँ निर्धारित करने की अनुमति देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक समेकन](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में घुलमिल जाते हैं।

इंटीग्रल के लिए, आप [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए आप [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से ब्रैकेट नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिक्स को उन्हें घेर कर रखें।

![एक दो‑पंक्ति गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

### **मौजूद मैट्रिक्स संपादित करें**

मान लीजिए एक रैखिक बीजगणित पाठ्यक्रम `matrix.pptx` में गुणांक मैट्रिक्स के साथ शुरू होता है, जिसे पिछले उदाहरण ने सहेजा था। अगले अभ्यास में, पहली समीकरण को रखें, दूसरी को दो नई समीकरणों से बदलें, और चर सेट को संशोधित करें। मौजूदा मैट्रिक्स को [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) के माध्यम से खोलें ताकि अभी भी लागू गुणांक बरकरार रहें।

![मूल दो‑पंक्ति गुणांक मैट्रिक्स जिसमें पहली पंक्ति में 1, x और एक खाली सेल है तथा दूसरी पंक्ति में x, 2 और y हैं](matrix-before-edit.png)

पंक्ति और स्तंभ सूचकांक शून्य से शुरू होते हैं और प्रत्येक कॉल पर वर्तमान मैट्रिक्स को दर्शाते हैं। सूचकांक 1 से पहले पंक्ति सम्मिलित करने से मूल दूसरी पंक्ति सूचकांक 2 पर चली जाती है। सूचकांक 2 के बाद सम्मिलित करने से एक पंक्ति जोड़ दी जाती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ित पंक्ति एक स्थान ऊपर आती है। स्तंभ भी इसी प्रकार शिफ्ट होते हैं।

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

// नई कोशिकाएँ प्रारंभ में null होती हैं। पहले शून्य नहीं वाले गुणांक सेट करें।
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) पहली स्तंभ को बाएँ संरेखित करता है। [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) सूचकांक 1 से शुरू होकर तीन लगातार स्तंभों को दाएँ संरेखित करता है। `updated-matrix.pptx` में, मैट्रिक्स में तीन समीकरण और चार चर हैं। मूल पहली‑पंक्ति के गुणांक `1` और `x` अब पहली और तीसरी स्तंभ में दिखाई देते हैं।

![अपडेटेड तीन‑पंक्ति मैट्रिक्स जिसमें पंक्तियों 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 दिखाए गए हैं](matrix-after-edit.png)

## **समीकरण एर्रे जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों की लंबवत स्टैक की आवश्यकता हो तो आप [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) का उपयोग करें।

![एक लंबवत गणितीय एर्रे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

### **एर्रे को आसपास के तत्वों के साथ संरेखित करें**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) एर्रे की वर्टिकल संरेखण को उसके बगल के गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहले पंक्ति, एर्रे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

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

निचले चित्र में PowerPoint में सहेजे गए प्रस्तुति की तुलना करें। प्रत्येक एर्रे के बगल में `A=` और `=B` समान है। सभी गणितीय टेक्स्ट Cambria Math 24 पॉइंट पर हैं। केवल एर्रे संरेखण बदलता है।

![PowerPoint में Equation एर्रे Top, Center, और Bottom संरेखण के साथ और समान बगल के तत्वों के साथ](equation-array-alignment.png)

### **पंक्ति अंतर कॉन्फ़िगर करें**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) एर्रे के भीतर पंक्तियों के लिए अंतर नियम चुनता है। [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) स्पष्ट अंतर नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतर के लिए मान को पॉइंट में मापा जाता है। अनुपातिक अंतर के लिए इसे आधी‑लाइन में मापा जाता है: उदाहरण में `3` का अर्थ 1.5 लाइनों के बराबर है। स्पष्ट मान निर्दिष्ट करने पर दोनों प्रॉपर्टी सेट करें; केवल संख्यात्मक मान बदलने से अंतर नियम नहीं चुना जाता।

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

एर्रे पंक्ति अंतर पैराग्राफ अंतर से अलग है। [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) और [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) पूरे पैराग्राफ के चारों ओर अंतर जोड़ते हैं, न कि एर्रे पंक्तियों के बीच। इसी तरह, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एर्रे की वर्टिकल संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो आप [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) का उपयोग कर सकते हैं।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

इंडेक्स और पावर के लिए आप सबस्क्रिप्ट और सुपरस्क्रिप्ट सहायक का उपयोग करें। जब इंडेक्स बेस के बाएँ तरफ दिखने चाहिए, तो [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ एक बड़ा Y](powerpoint-math-equations_9.png)

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

### **दाएँ सबस्क्रिप्ट और सुपरस्क्रिप्ट संरेखित करें**

जब दोनों स्क्रिप्ट एक ही बेस से संबंधित हों, तो आप [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/) का उपयोग करें। इसका [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) प्रॉपर्टी उनके क्षैतिज स्थान को नियंत्रित करती है: `false` (डिफ़ॉल्ट) उन्हें बेस के कंटूर का पालन करने देती है, जबकि `true` स्क्रिप्ट को एक‑दूसरे के साथ क्षैतिज रूप से संरेखित करती है।

यह उदाहरण समान संपादन योग्य अभिव्यक्ति की दो प्रतियों को बगल‑बगल रखता है। दोनों में वैज्ञानिक इटैलिक f (U+1D453), निचला स्क्रिप्ट 1, ऊपरी स्क्रिप्ट 2, और Cambria Math 72 पॉइंट हैं। ढलान वाला बेस PowerPoint में अंतर को स्पष्ट करता है। उदाहरण चलाने से पहले Cambria Math स्थापित करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![PowerPoint में दो संपादन योग्य अभिव्यक्तियाँ जिसमें बाएँ AlignScripts false और दाएँ true सेट है](aligned-scripts.png)

बाएँ, निचला स्क्रिप्ट बेस के कंटूर का पालन करते हुए ऊपरी स्क्रिप्ट से अधिक बाएँ शुरू होता है। दाएँ, दोनों स्क्रिप्ट एक‑दूसरे के साथ क्षैतिज रूप से संरेखित होते हैं।

## **डिलिमिटर जोड़ें**

[Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करके आप अभिव्यक्ति को डिलिमिटर के भीतर रख सकते हैं। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z को लंबवत बार द्वारा विभाजित किया गया है](powerpoint-math-equations_13.png)

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

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) को `true` सेट करने से बड़े ऑपरेण्ड के आसपास कोष्ठक बड़ा हो जाता है, या `false` सेट करने से वे सामान्य आकार में रहते हैं। [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से चलता है। `Match` उन्हें संलग्न सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। भीतर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` की घात में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तृत हो। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग का उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। ऊपर की पंक्ति में, कोष्ठक घात को घेरने के लिए बड़े होते हैं और दोनों आकारों में समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ (`Centered`) छोटे कोष्ठक बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![PowerPoint में चार समीकरण जहाँ डिलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, बाएँ पर Centered और दाएँ पर Match](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

आप एक भिन्न पर [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) को कॉल करके पूरे अभिव्यक्ति को फ्रेम कर सकते हैं। डिफ़ॉल्ट रूप से लौटाए गए [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) में चारों पक्ष दिखते हैं। आप [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), और [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) के साथ व्यक्तिगत पक्ष हटा सकते हैं।

उदाहरण एक ही भिन्न के छह प्रतियों को एक स्लाइड पर रखता है। रद्द करने के लिए, चारों पक्ष को छिपाएँ और [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) को आरोही विकर्ण (↗) या [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) को अवरोही विकर्ण (↘) के रूप में सेट करें। आप किसी भी संयोजन के साथ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) या [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) का भी उपयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, आरोही विकर्ण। नीचे पंक्ति: अवरोही विकर्ण, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ लंबवत स्ट्राइक।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा के ऊपर ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को पार करता है जबकि आसपास का बॉर्डर दिखाई देता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइक थ्रू अक्षर के भाग पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फ़ैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

आप किसी अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) में घेरकर उसकी दृश्यता और समीकरण में योगदान देने वाली जगह को स्वतंत्र रूप से नियंत्रित कर सकते हैं। [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) की प्रॉपर्टी नीचे दिए गए प्रभावों को निर्धारित करती हैं:

| गुणधर्म | प्रभाव |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | `false` सेट करने से अभिव्यक्ति छिप जाती है। इसकी माप अभी भी लेआउट में योगदान देती है जब तक नीचे की प्रॉपर्टी `true` न हो। |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य माना जाता है, जिससे पड़ोसी तत्व एक‑दूसरे के पास आ सकते हैं। |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | उसके आरोह (बेसलाइन के ऊपर की ऊँचाई) को शून्य माना जाता है। यह पड़ोसी तत्वों के ऊपर आरक्षित जगह को कम कर सकता है। |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | उसके अवरोह (बेसलाइन के नीचे की गहराई) को शून्य माना जाता है। यह भिन्न रेखा या अन्य सामग्री को अभिव्यक्ति के नीचे पड़ोसियों के करीब ला सकता है। |

बेसलाइन वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसकी माप नहीं हटती, और माप को शून्य मानने से अभिव्यक्ति नहीं हटती। निहित अभिव्यक्ति [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) के माध्यम से उपलब्ध रहती है। फिर से दिखाने के लिए [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) को `true` सेट करें; माप सेटिंग्स अपरिवर्तित रहती हैं।

उदाहरण नीचे पाँच बगल‑बगल प्रभाव बनाता है: एक दृश्यमान भिन्न, एक छिपा भिन्न जो जगह रखता है, और तीन छिपे भिन्न जिनमें एक माप को शून्य किया गया है। प्रत्येक वरिएंट समान घेरने वाली अभिव्यक्ति और Cambria Math 24 पॉइंट का प्रयोग करता है। सभी समीकरण आकार समान शीर्ष स्थिति के साथ हैं, जो ग्रे गाइड से चिन्हित है। बाहरी भिन्न के अंश में फ़ैंटम रखने से वर्टिकल लेआउट परिवर्तन अधिक स्पष्ट होते हैं।

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

![PowerPoint में पाँच समीकरण जो एक दृश्यमान भिन्न, एक छिपा भिन्न जो जगह रखता है, और ZeroWidth, ZeroAsc, या ZeroDesc सक्षम छिपे भिन्नों की तुलना करते हैं](math-phantom.png)

## **टर्म समूहित करें**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके आप अभिव्यक्ति के ऊपर या नीचे एक समूहित अक्षर रख सकते हैं। समूहित टर्म को लेबल करने के लिए एक सीमा जोड़ें।

![एक अभिव्यक्ति x + y जिसे नीचे any text लेबल के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूपित करें**

यदि वे सूत्र को स्पष्ट करते हैं तो ही स्वरूपण सहायक का उपयोग करें। उदाहरण के लिए, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) एक गणितीय तत्व के ऊपर एक रेखा रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसमें एक ओवरबार है](powerpoint-math-equations_14.png)

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

एक मौजूदा समीकरण के पूरे टेक्स्ट को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक के एलिमेंट ट्री को ट्रैवर्स करें। [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) केवल तत्काल चाइल्ड लौटाता है, इसलिए नेस्टेड संरचनाओं जैसे भिन्न, स्क्रिप्ट, मूल आदि में टेक्स्ट तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके चाइल्ड दोनों की जाँच करें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) हो तो इसे भी शामिल किया जा सके।

उदाहरण मानता है कि प्रस्तुति में ऐसा समीकरण है `z = xᵢ / ∛y`, जिसमें अंश में सबस्क्रिप्ट और हर में मूल दोनों हैं। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाता। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों को [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) के माध्यम से पहुँचता है, और प्रत्येक टेक्स्ट तत्व के [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) को 28 पॉइंट सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के सभी स्तरों पर अद्यतन टेक्स्ट स्वरूपण रखती है, जबकि उसका टेक्स्ट कंटेंट और गणितीय संरचना अपरिवर्तित रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| तत्व मिलाएँ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ें | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ें | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| सीमा जोड़ें | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| समाकलन और इंटीग्रल जोड़ें | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एर्रे जोड़ें | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| डिलिमिटर जोड़ें | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म समूहित करें | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) हो, उसका [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) प्राप्त करें, और पैराग्राफ में मौजूद गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरण को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करके निर्यात करें। पूर्ण उदाहरण के लिए देखें [प्रेजेंटेशन में .NET से गणितीय समीकरण निर्यात](/slides/hi/net/exporting-math-equations/#export-math-equations-to-latex)।