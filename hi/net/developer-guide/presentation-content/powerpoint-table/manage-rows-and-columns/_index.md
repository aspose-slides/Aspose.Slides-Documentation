---
title: PowerPoint तालिकाओं में पंक्तियों और स्तम्भों का प्रबंधन .NET में
linktitle: पंक्तियाँ और स्तम्भ
type: docs
weight: 20
url: /hi/net/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तम्भ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तम्भ क्लोन
- पंक्ति कॉपी
- स्तम्भ कॉपी
- पंक्ति हटाएँ
- स्तम्भ हटाएँ
- पंक्ति पाठ स्वरूपण
- स्तम्भ पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint में तालिका की पंक्तियों और स्तम्भों का प्रबंधन करें और प्रस्तुति संपादन तथा डेटा अपडेट्स को तेज़ बनाएँ।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/net/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) इंटरफ़ेस, और कई अन्य प्रकार प्रदान करता है। 

## **पहली पंक्ति को हेडर के रूप में सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति लोड करें। 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट बनाएं और इसे null सेट करें। 
4. संबंधित तालिका खोजने के लिए सभी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) ऑब्जेक्ट्स के माध्यम से इटरेट करें। 
5. तालिका की पहली पंक्ति को हेडर के रूप में सेट करें। 

यह C# कोड दिखाता है कि तालिका की पहली पंक्ति को हेडर के रूप में कैसे सेट करें:

```c#
// Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation("table.pptx");

// पहली स्लाइड तक पहुँचता है
ISlide sld = pres.Slides[0];

// null TableEx को प्रारम्भ करता है
ITable tbl = null;

// शेप्स के माध्यम से इटरेट करता है और तालिका का रेफ़रेंस सेट करता है
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करता है
tbl.FirstRow = true;

// प्रस्तुति को डिस्क पर सहेजता है
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **तालिका की पंक्ति या स्तम्भ को क्लोन करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति लोड करें, 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. `columnWidth` एरे परिभाषित करें। 
4. `rowHeight` एरे परिभाषित करें। 
5. स्लाइड पर [AddTable](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें। 
6. तालिका की पंक्ति को क्लोन करें। 
7. तालिका के स्तम्भ को क्लोन करें। 
8. परिवर्तनित प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि PowerPoint तालिका की पंक्ति या स्तम्भ को कैसे क्लोन किया जाए:

```c#
 // Presentation क्लास का इंस्टांस बनाता है
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = presentation.Slides[0];

    // स्तम्भों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड पर तालिका आकार जोड़ता है
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // पंक्ति 1 सेल 1 में कुछ टेक्स्ट जोड़ता है
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // पंक्ति 1 सेल 2 में कुछ टेक्स्ट जोड़ता है
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // तालिका के अंत में पंक्ति 1 को क्लोन करता है
    table.Rows.AddClone(table.Rows[0], false);

    // पंक्ति 2 सेल 1 में कुछ टेक्स्ट जोड़ता है
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // पंक्ति 2 सेल 2 में कुछ टेक्स्ट जोड़ता है
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // पंक्ति 2 को तालिका की 4थी पंक्ति के रूप में क्लोन करता है
    table.Rows.InsertClone(3,table.Rows[1], false);

    // अंत में पहला स्तम्भ क्लोन करता है
    table.Columns.AddClone(table.Columns[0], false);

    // 4थी स्तम्भ इंडेक्स पर दूसरा स्तम्भ क्लोन करता है
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // प्रस्तुति को डिस्क पर सहेजता है 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **तालिका से पंक्ति या स्तम्भ हटाएँ**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति लोड करें, 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. `columnWidth` एरे परिभाषित करें। 
4. `rowHeight` एरे परिभाषित करें। 
5. स्लाइड पर [AddTable](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें। 
6. तालिका की पंक्ति को हटाएँ। 
7. तालिका के स्तम्भ को हटाएँ। 
8. परिवर्तनित प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि तालिका से पंक्ति या स्तम्भ कैसे हटाया जाए:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **तालिका की पंक्ति स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति लोड करें, 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट तक पहुँचें। 
4. पहली पंक्ति के सेल्स का [FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontheight/) सेट करें। 
5. पहली पंक्ति के सेल्स का [Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginright/) सेट करें। 
6. दूसरी पंक्ति के सेल्स का [TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/textverticaltype/) सेट करें। 
7. परिवर्तनित प्रस्तुति को सहेजें। 

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
// Presentation क्लास का इंस्टांस बनाता है
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है

// पहले पंक्ति के सेल्स की फ़ॉन्ट ऊँचाई सेट करता है
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// पहले पंक्ति के सेल्स के टेक्स्ट संरेखन और दायाँ मार्जिन सेट करता है
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// दूसरी पंक्ति के सेल्स के टेक्स्ट वर्टिकल प्रकार को सेट करता है
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// प्रस्तुति को डिस्क पर सहेजता है
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **तालिका की स्तम्भ स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति लोड करें, 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट तक पहुँचें। 
4. पहली स्तम्भ के सेल्स का [FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontheight/) सेट करें। 
5. पहली स्तम्भ के सेल्स का [Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginright/) सेट करें। 
6. दूसरी स्तम्भ के सेल्स का [TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/textverticaltype/) सेट करें। 
7. परिवर्तनित प्रस्तुति को सहेजें। 

यह C# कोड इस ऑपरेशन को दर्शाता है: 

```c#
// Presentation क्लास का इंस्टांस बनाता है
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है

// पहले स्तम्भ के सेल्स की फ़ॉन्ट ऊँचाई सेट करता है
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// पहले स्तम्भ के सेल्स के टेक्स्ट संरेखन और दायाँ मार्जिन को एक कॉल में सेट करता है
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// दूसरे स्तम्भ के सेल्स के टेक्स्ट वर्टिकल प्रकार को सेट करता है
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// प्रस्तुति को डिस्क पर सहेजता है
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण पुनः प्राप्त करने की सुविधा देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह C# कोड दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // डिफ़ॉल्ट शैली प्रीसेट थीम बदलें
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियाँ लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप उस थीम पर फ़िल्स, बॉर्डर्स, और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका की पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में बिल्ट‑इन सॉर्टिंग या फ़िल्टर नहीं होते। पहले अपने डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में तालिका की पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तम्भ रख सकते हुए विशिष्ट सेल्स पर कस्टम रंग बना सकता हूँ?**

हाँ। बैंडेड कॉलम को सक्रिय करें, फिर विशिष्ट सेल्स को स्थानीय फ़ॉर्मेटिंग के साथ ओवरराइड करें; सेल‑स्तर की फ़ॉर्मेटिंग तालिका शैली पर अधिक प्राथमिकता लेती है।