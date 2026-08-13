---
title: ".NET में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें"
linktitle: "PowerPoint गणितीय समीकरण"
type: docs
weight: 80
url: /hi/net/powerpoint-math-equations/
keywords:
- "गणितीय समीकरण"
- "गणितीय प्रतीक"
- "गणितीय सूत्र"
- "गणितीय पाठ"
- "गणितीय समीकरण जोड़ें"
- "गणितीय प्रतीक जोड़ें"
- "गणितीय सूत्र जोड़ें"
- "गणितीय पाठ जोड़ें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, फ़ॉर्मेटिंग नियंत्रण, और स्पष्ट C# कोड उदाहरण प्रदान करता है."
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for .NET के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, सरणियाँ, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः समीकरण जोड़ते हैं **Insert > Equation** से:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय शैप, जिसे [AddMathShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addmathshape/) के साथ बनाया जाता है, वह शैप है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) शैप के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट्स को सम्मिलित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/) के फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड संक्षिप्त और पढ़ने योग्य रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in .NET](/slides/hi/net/exporting-math-equations/)।

## **एक समीकरण बनाएं**

यह उदाहरण एक गणितीय शैप बनाता है और पाइथागोरस सिद्धांत जोड़ता है:

![c वर्ग बराबर a वर्ग प्लस b वर्ग समीकरण](powerpoint-math-equations_3.png)

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

{{% alert color="info" %}}
`AddMathShape` एक शैप बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहला `MathPortion` प्राप्त करें, उसका `MathParagraph` लें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

`Divide` का उपयोग करके एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें 1 को x द्वारा विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड (ऊँचा) भिन्न के लिए, `MathFractionTypes.Bar` का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

`Radical` का उपयोग करके वर्गमूल, घनमूल, या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और आर्ग्यूमेंट डिग्री बन जाता है।

![एक n-थ मूल अभिव्यक्ति जिसमें x मूल संकेत के नीचे है](powerpoint-math-equations_5.png)

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

## **फ़ंक्शन और सीमाएँ जोड़ें**

`AsArgumentOfFunction` या `Function` का उपयोग करके `sin(x)`, `log(x)` जैसी फ़ंक्शन या कस्टम फ़ंक्शन नाम बनाएं। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathlimit/) में रखें या `SetLowerLimit` का उपयोग करें।

![x की सीमा जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary ऑपरेटर्स और इंटीग्रल जोड़ें**

संकलन, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर्स के लिए `Nary` का उपयोग करें। इंटीग्रल के लिए `Integral` का उपयोग करें। दोनों मेथड्स आपको निचली और ऊपरी सीमाएँ निर्धारित करने की अनुमति देते हैं।

![एक योग जिसमें निचली और ऊपरी सीमाएँ हैं](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर `MathematicalText` के रूप में जोड़े जाते हैं और अभिव्यक्ति में शामिल होते हैं।

इंटीग्रल के लिए, `Integral` का उपयोग करें:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और कॉलम्स के लिए [MathMatrix](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण सरणियाँ जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों के ऊर्ध्वाधर स्टैक की आवश्यकता हो, तो `ToMathArray` का उपयोग करें।

![एक ऊर्ध्वाधर गणितीय सरणी जिसमें x y के ऊपर स्थित है](powerpoint-math-equations_11.png)

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

## **त्रिकोणमितीय फ़ंक्शन्स जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो `AsArgumentOfFunction` का उपयोग करें।

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

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर्स का उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष में दिखाई देना चाहिए, तो `SetSubSuperscriptOnTheLeft` का उपयोग करें।

![एक बड़े अक्षर Y जिसमें बाएँ-साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n है](powerpoint-math-equations_9.png)

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

`Enclose` का उपयोग करके अभिव्यक्ति को डिलिमिटर के भीतर रखें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z को वर्टिकल बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

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

## **बॉर्डर बॉक्स जोड़ें**

`ToBorderBox` का उपयोग करें जब समीकरण स्वयं को फ्रेम किया जाना चाहिए।

![एक बॉक्स में घेरा हुआ समीकरण जिसमें a वर्ग बराबर b वर्ग प्लस c वर्ग दिखाया गया है](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **टर्म्स को समूहित करें**

`Group` का उपयोग करके अभिव्यक्ति के ऊपर या नीचे समूहिंग कैरेक्टर रखें। समूहित टर्म्स को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को समूहित किया गया है जिसमें नीचे कोई टेक्स्ट लेबल है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का फॉर्मेट**

फ़ॉर्मेटिंग हेल्पर्स का उपयोग केवल तब करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, `Overbar` एक गणितीय तत्व के उपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसमें ओवरबार है](powerpoint-math-equations_14.png)

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

## **त्वरित संदर्भ**

| कार्य | Main API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाएं | [IMathElement.Join](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.Divide](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [SetSuperscript](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ें | [Function](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ें | [IMathElement.Radical](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [SetLowerLimit](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ-साइड स्क्रिप्ट जोड़ें | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| योग और इंटीग्रल जोड़ें | [Nary](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण सरणियाँ जोड़ें | [ToMathArray](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| डिलिमिटर जोड़ें | [Enclose](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [Overbar](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म्स को समूहित करें | [Group](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रेज़ेंटेशन खोलें, उस शैप को खोजें जिसमें `MathPortion` है, उसका `MathParagraph` प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। जब आप PPTX में सहेजते हैं, तो Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण का [IMathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathparagraph/) उसके [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph.ToLatex](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in .NET](/slides/hi/net/exporting-math-equations/#export-math-equations-to-latex)।