---
title: C++ में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/cpp/powerpoint-math-equations/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित करें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट C++ कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for C++ के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, एरे और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणामस्वरूप स्लाइड पर संपादनीय गणितीय पाठ मिलता है:

![एक PowerPoint स्लाइड जिसमें संपादनीय गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उन गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जो [AddMathShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapecollection/) द्वारा बनाया गया है, वह आकार है जिसमें समीकरण है।
- [MathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ़्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathblock/) वस्तुओं को सम्मिलित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/) की प्रवाहशील विधियों का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in C++](/slides/hi/cpp/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

![समिकरण c वर्ग बराबर a वर्ग + b वर्ग](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले `MathPortion` को एक्सेस करें, उसका `MathParagraph` प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

`Divide` का उपयोग करके आप एक भिन्न बना सकते हैं। आप [MathFractionTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक विकर्ण गणितीय भिन्न जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

स्टैक्ड भिन्न के लिए, `MathFractionTypes::Bar` का उपयोग करें:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **मूल जोड़ें**

`Radical` का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बना सकते हैं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-था मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

`AsArgumentOfFunction` या `Function` का उपयोग करें जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathlimit/) में रखें या `SetLowerLimit` का प्रयोग करें।

![x की सीमा जब x अनन्त की ओर बढ़ता है](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

`Nary` का उपयोग करके आप योग, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर बना सकते हैं। इंटीग्रल के लिए `Integral` का प्रयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएँ सेट कर सकते हैं।

![निचली और ऊपरी सीमाओं के साथ एक समेशन](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N-ary ऑपरेटर्स बड़े ऑपरेटर्स के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर `MathematicalText` के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

इंटीग्रल के लिए, `Integral` का उपयोग करें:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रेस या ब्रेसेस चाहिए तो मैट्रिक्स को घेरें।

![एक दो पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **समीकरण एरे जोड़ें**

समायोजित समीकरणों या अभिव्यक्तियों के लंबवत स्टैक के लिए `ToMathArray` का उपयोग करें।

![एक लंबवत गणितीय एरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब आर्ग्यूमेंट वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो `AsArgumentOfFunction` का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

इंडेक्स और पावर के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष पर होने चाहिए, तो `SetSubSuperscriptOnTheLeft` का प्रयोग करें।

![एक बड़े Y में बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n है](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर में रखने के लिए `Enclose` का उपयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक सेपरेटर कैरेक्टर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z को ऊर्ध्वाधर बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **बॉर्डर बॉक्स जोड़ें**

जब समीकरण को फ्रेम किया जाना चाहिए, तो `ToBorderBox` का उपयोग करें।

![एक बॉक्स किया हुआ समीकरण जिसमें a वर्ग = b वर्ग + c वर्ग दिखाया गया है](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **टर्म समूहित करें**

`Group` का उपयोग करके आप अभिव्यक्ति के ऊपर या नीचे ग्रुपिंग कैरेक्टर रख सकते हैं। ग्रुप किए गए टर्म को लेबल करने के लिए सीमा जोड़ें।

![अभिव्यक्ति x प्लस y को ग्रुप किया गया है और नीचे लेबल टेक्स्ट है](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **गणितीय तत्व स्वरूपित करें**

फॉर्मैटिंग हेल्पर केवल तब उपयोग करें जब वे समीकरण को स्पष्ट करें। उदाहरण के तौर पर, `Overbar` गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **शीघ्र संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathematicaltext/) |
| तत्व मिलाएं | [IMathElement.Join](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.Divide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/divide/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [SetSuperscript](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| फ़ंक्शन जोड़ें | [Function](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| मूल जोड़ें | [IMathElement.Radical](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [SetLowerLimit](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| योग और इंटीग्रल जोड़ें | [Nary](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [ToMathArray](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| डिलिमिटर जोड़ें | [Enclose](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [Overbar](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| टर्म समूहित करें | [Group](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, वह आकार खोजें जिसमें `MathPortion` हो, उसका `MathParagraph` प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph::ToLatex](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in C++](/slides/hi/cpp/exporting-math-equations/#export-math-equations-to-latex).