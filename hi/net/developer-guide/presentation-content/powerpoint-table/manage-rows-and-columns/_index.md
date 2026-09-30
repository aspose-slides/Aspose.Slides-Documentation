---
title: PowerPoint तालिकाओं में .NET के साथ पंक्तियों और स्तंभों का प्रबंधन
linktitle: पंक्तियां और स्तंभ
type: docs
weight: 20
url: /hi/net/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति टेक्स्ट स्वरूपण
- स्तंभ टेक्स्ट स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन तथा डेटा अपडेट को तेज़ बनायें।"
---
## **परिचय**

Aspose.Slides for .NET आपको PowerPoint प्रस्तुतियों में तालिका संरचना और स्वरूपण को [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) क्लास और [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) इंटरफ़ेस के माध्यम से प्रबंधित करने देता है। आप हेडर पंक्ति नियुक्त कर सकते हैं, पंक्तियों या स्तंभों को क्लोन या हटाना कर सकते हैं, और पूरी पंक्ति या स्तंभ पर टेक्स्ट स्वरूपण लागू कर सकते हैं।

यह लेख C# उदाहरणों के साथ इन कार्यों को समझाता है। यह भी दर्शाता है कि तालिका की शैली प्रीसेट को कैसे प्राप्त करें ताकि आप इसे पुन: उपयोग कर सकें। तालिका पंक्ति और स्तंभ सूचकांक शून्य-आधारित हैं।

## **पंक्ति की ऊँचाई नियंत्रण**

पंक्ति की न्यूनतम ऊँचाई को पॉइंट्स में सेट करने के लिए [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) का उपयोग करें। यह एक निचला सीमा है, न कि निश्चित ऊँचाई। [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) वास्तविक ऊँचाई लौटाता है और केवल‑पढ़ने योग्य है। पंक्ति तक पहुँचने के लिए [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) का उपयोग करें।

उदाहरण [row-height-input.pptx](row-height-input.pptx) लोड करता है, जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका होती है। इसकी पहली पंक्ति 70 पॉइंट पर शुरू होती है। कोशिकाएँ 18‑पॉइंट Arial टेक्स्ट, रैपिंग, और 6‑पॉइंट शीर्ष एवं नीचे मार्जिन का उपयोग करती हैं; दूसरे स्तंभ में लंबा टेक्स्ट कई लाइनों में रैप हो जाता है। उदाहरण न्यूनतम को 100 पॉइंट तक बढ़ाता है, फिर 20 पॉइंट तक घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई प्रिंट करता है, और दोनों परिणाम सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

प्रदान की गई प्रस्तुति में, न्यूनतम बढ़ाने से पंक्ति में स्थान जुड़ जाता है। इसे घटाने से अतिरिक्त स्थान हट जाता है, पर वास्तविक ऊँचाई 20 पॉइंट से अधिक रहती है क्योंकि टेक्स्ट और कोशिका मार्जिन को अधिक जगह की आवश्यकता होती है। केवल न्यूनतम घटाने से पंक्ति को उसकी सामग्री द्वारा आवश्यक स्थान से नीचे नहीं धकेला जा सकता।

वास्तविक ऊँचाई को कई कारक प्रभावित करते हैं:

- **टेक्स्ट और फ़ॉन्ट आकार:** लंबा टेक्स्ट, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊर्ध्वाधर स्थान की आवश्यकता कर सकता है।
- **रैपिंग और स्तंभ चौड़ाई:** रैपिंग सक्षम होने पर, संकरी [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) अधिक पंक्तियाँ उत्पन्न कर सकती है। चौड़ी स्तंभ ऊर्ध्वाधर आवश्यकता को कम कर सकता है।
- **कोशिका मार्जिन:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) और [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) ऊर्ध्वाधर स्थान जोड़ते हैं। [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) और [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) टेक्स्ट के लिए उपलब्ध चौड़ाई घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

इस तालिका में बिना मर्ज्ड कोशिकाओं के, वह कोशिका जो सबसे अधिक ऊर्ध्वाधर स्थान लेती है, पूरी पंक्ति के लिए सामग्री‑आधारित निचली सीमा निर्धारित करती है। पंक्ति को छोटा करने के लिए, आपको टेक्स्ट को छोटा करना, फ़ॉन्ट आकार या मार्जिन घटाना, या स्तंभ को चौड़ा करना पड़ सकता है।

नीचे की छवियाँ समान तालिका को समान स्केल पर दिखाती हैं। इस रन में वास्तविक ऊँचाइयाँ 70, 100 और 55.2 पॉइंट थीं: अंतिम पंक्ति अपने 20‑पॉइंट न्यूनतम से अधिक ऊँची रही। सटीक टेक्स्ट माप आपके वातावरण में उपलब्ध फ़ॉन्ट के आधार पर भिन्न हो सकते हैं। सहेजे गए परिणाम डाउनलोड करें: [increased minimum](row-height-increased.pptx) और [decreased minimum](row-height-decreased.pptx).

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | बढ़ाया: न्यूनतम 100 pt, वास्तविक 100 pt | घटाया: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![70‑पॉइंट पहली पंक्ति वाली मूल तालिका।](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 पॉइंट बढ़ाने के बाद तालिका।](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 पॉइंट घटाने के बाद तालिका; रैप किया टेक्स्ट पंक्ति को न्यूनतम से ऊँचा रखता है।](row-height-decreased.png) |

## **पहली पंक्ति को हेडर के रूप में सेट करें**

[FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) प्रॉपर्टी का उपयोग करके पहली पंक्ति को हेडर स्वरूपण के लिए चिह्नित करें। इसका स्वरूप तालिका पर लागू तालिका शैली पर निर्भर करता है।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के साथ लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत तालिका तक पहुँचें।
4. उसकी पहली पंक्ति के लिए हेडर स्वरूपण सक्षम करें।
5. संशोधित प्रेजेंटेशन को सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका हो। यह पहली पंक्ति के लिए हेडर स्वरूपण सक्षम करता है और `First_row_header.pptx` सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **तालिका पंक्ति या स्तंभ को क्लोन करें**

पंक्तियों या स्तंभों को क्लोन करके उनकी सामग्री और स्वरूपण को पुन: उपयोग करें। आप कॉपी को तालिका के अंत में जोड़ सकते हैं या किसी विशिष्ट स्थान पर सम्मिलित कर सकते हैं।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास से लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) मेथड से तालिका जोड़ें।
5. आवश्यक पंक्तियों को क्लोन करें।
6. आवश्यक स्तंभों को क्लोन करें।
7. संशोधित प्रेजेंटेशन को सहेजें।

उदाहरण को कम से कम एक स्लाइड वाला `Test.pptx` चाहिए। यह तीन स्तंभ और पाँच पंक्तियों वाली तालिका बनाता है, जिसका आकार पॉइंट्स में निर्दिष्ट है। यह पहली पंक्ति और स्तंभ की प्रतियों को जोड़ता है, फिर दूसरी पंक्ति और स्तंभ की प्रतियों को सूचीक्रम 3 (चौथा स्थान) पर सम्मिलित करता है। परिणामी तालिका में सात पंक्तियाँ और पाँच स्तंभ होते हैं। `false` आर्ग्यूमेंट निकटवर्ती मर्ज्ड पंक्तियों या स्तंभों में क्लोनिंग को अक्षम करता है; इस तालिका में कोई मर्ज्ड कोशिकाएँ नहीं हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

तालिका में अब आवश्यक न रहने वाली पंक्तियों या स्तंभों को हटाएँ। कोई आइटम हटाने से उसके बाद आने वाली पंक्तियों या स्तंभों के सूचकांक शिफ्ट हो जाते हैं।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास से बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) मेथड से तालिका जोड़ें।
5. दूसरी पंक्ति और दूसरा स्तंभ हटाएँ।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह उदाहरण तीन‑बाय‑तीन तालिका बनाता है और क्रमांक 1 पर पंक्ति और स्तंभ हटाता है, जिससे `TestTable_out.pptx` में दो‑बाय‑दो तालिका बचती है। आकार पॉइंट्स में हैं। `false` आर्ग्यूमेंट निकटवर्ती मर्ज्ड पंक्तियों या स्तंभों के हटाने को अक्षम करता है; इस तालिका में कोई मर्ज्ड कोशिकाएँ नहीं हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **तालिका पंक्ति स्तर पर टेक्स्ट स्वरूपण सेट करें**

पूरी पंक्ति पर टेक्स्ट स्वरूपण लागू करें ताकि उसकी कोशिकाएँ संगत रहें। आप प्रत्येक कोशिका को अलग‑अलग स्वरूपित किए बिना फ़ॉन्ट गुण, पैराग्राफ स्वरूपण और टेक्स्ट दिशा सेट कर सकते हैं।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के साथ लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहली पंक्ति के लिए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) सेट करें।
4. पहली पंक्ति के लिए [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) सेट करें।
5. दूसरी पंक्ति के लिए [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) सेट करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दायाँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरी पंक्ति में ऊर्ध्वाधर टेक्स्ट सेट करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **तालिका स्तंभ स्तर पर टेक्स्ट स्वरूपण सेट करें**

पूरे स्तंभ पर टेक्स्ट स्वरूपण लागू करें ताकि उसकी कोशिकाएँ संगत रहें। आप प्रत्येक कोशिका को अलग‑अलग स्वरूपित किए बिना फ़ॉन्ट गुण, पैराग्राफ स्वरूपण और टेक्स्ट दिशा सेट कर सकते हैं।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास के साथ लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहले स्तंभ के लिए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) सेट करें।
4. पहले स्तंभ के लिए [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) सेट करें।
5. दूसरे स्तंभ के लिए [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) सेट करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका और कम से कम दो स्तंभ हों। यह पहले स्तंभ पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दायाँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरे स्तंभ में ऊर्ध्वाधर टेक्स्ट सेट करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) प्रॉपर्टी का उपयोग करके तालिका पर लागू प्रीसेट प्राप्त करें और इसे दूसरी तालिका पर पुन: उपयोग करें। यह व्यक्तिगत कोशिका स्वरूपण ओवरराइड के बजाय प्रीसेट की पहचान करता है।

उदाहरण एक तालिका बनाता है, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) लागू करता है, और प्रीसेट को पुनः पढ़ता है। यह `DarkStyle1` को प्रिंट करता है और तालिका को `table.pptx` में सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले बनाई गई तालिका पर PowerPoint थीम/शैलियों को लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को फिर भी ओवरराइड कर सकते हैं।

**क्या मैं तालिका की पंक्तियों को Excel की तरह सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते। पहले अपनी डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हुए कुछ विशेष कोशिकाओं पर कस्टम रंग रख सकता हूँ?**

हाँ। बैंडेड स्तंभों को सक्रिय करें, फिर विशिष्ट कोशिकाओं को स्थानीय स्वरूपण से ओवरराइड करें; कोशिका‑स्तर का स्वरूपण तालिका शैली पर प्राथमिकता लेता है।