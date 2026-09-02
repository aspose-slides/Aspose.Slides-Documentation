---
title: .NET में प्रस्तुति तालिकाओं को प्रबंधित करें
linktitle: टेबल प्रबंधन
type: docs
weight: 10
url: /hi/net/manage-table/
keywords:
- टेबल जोड़ें
- टेबल बनाएं
- टेबल तक पहुंचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- टेबल शैली
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड में तालिकाओं को बनाएं एवं संपादित करें। अपने टेबल कार्यप्रवाह को सहज बनाने के लिए सरल C# कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में टेबल जानकारी को प्रदर्शित करने और दर्शाने का एक प्रभावी तरीका है। सेल्स की ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/net/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/net/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जिससे आप सभी प्रकार की प्रस्तुतियों में टेबल बनाकर, अपडेट करके और प्रबंधित करके उपयोग कर सकते हैं। 

## **शुरू से एक टेबल बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।  
2. उसके सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. `columnWidth` का एक एरे परिभाषित करें।  
4. `rowHeight` का एक एरे परिभाषित करें।  
5. [AddTable](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addtable/) मेथड के द्वारा स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।  
6. प्रत्येक [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) को क्रमशः परिक्रमा करके शीर्ष, निचला, दायाँ और बायाँ बॉर्डर फॉर्मेट लागू करें।  
7. टेबल की पहली पंक्ति के पहले दो सेल को मिलाएँ।  
8. किसी [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. संशोधित प्रस्तुति को सहेजें।

यह C# कोड टेबल बनाने का तरीका दिखाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को instantiate करता है
Presentation pres = new Presentation();

// पहली स्लाइड तक पहुँचता है
ISlide sld = pres.Slides[0];

// कॉलम की चौडाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// स्लाइड में टेबल शेप जोड़ता है
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// पंक्ति 1 के सेल 1 और 2 को मिलाता है
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// मर्ज किए गए सेल में कुछ टेक्स्ट जोड़ता है
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// प्रस्तुति को डिस्क पर सहेजता है
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **मानक टेबल में क्रमांकन**

एक मानक टेबल में, सेल्स की संख्यांकन सरल और शून्य-आधारित होती है। टेबल का पहला सेल 0,0 (स्तम्भ 0, पंक्ति 0) के रूप में अनुक्रमित होता है।

उदाहरण के लिए, 4 स्तम्भ और 4 पंक्तियों वाली टेबल के सेल इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह C# कोड ऊपर दर्शाए गए मानक 4 × 4 टेबल को बनाता है और प्रत्येक सेल के बॉर्डर फॉर्मेट को सेट करता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को instantiate करता है
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.Slides[0];

    // कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक टेबल शेप जोड़ता है
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **मौजूदा टेबल तक पहुंचें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।  

2. उसके सूचकांक द्वारा टेबल वाली स्लाइड का संदर्भ प्राप्त करें।  

3. एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट बनाएँ और उसे null सेट करें।  

4. सभी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) ऑब्जेक्ट्स को परिक्रमा करें जब तक टेबल न मिल जाए।  

   यदि आपको संदेह है कि जिस स्लाइड को आप देख रहे हैं वह केवल एक टेबल रखती है, तो आप बस सभी शैलियों की जाँच कर सकते हैं। जब कोई Shape टेबल के रूप में पहचानी जाती है, तो आप उसे [Table](https://reference.aspose.com/slides/hi/net/aspose.slides/table/) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई टेबल हैं, तो आप उसे उसके [AlternativeText](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/alternativetext/) द्वारा खोजने में बेहतर रहेंगे।  

5. टेबल के साथ काम करने के लिये [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में हमने टेबल में एक नई पंक्ति जोड़ी है।  

6. संशोधित प्रस्तुति को सहेजें।  

यह C# कोड मौजूदा टेबल तक पहुंचने और उसके साथ काम करने का तरीका दिखाता है:

```c#
using Aspose.Slides;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को instantiate करता है
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.Slides[0];

    // null TableEx को प्रारम्भ करता है
    ITable tbl = null;

    // शेप्स के माध्यम से इटरैट करता है और मिले टेबल का संदर्भ सेट करता है
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // दूसरी पंक्ति के पहले स्तम्भ के लिए टेक्स्ट सेट करता है
    tbl[0, 1].TextFrame.Text = "New";

    // संशोधित प्रस्तुति को डिस्क पर सहेजता है
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **टेक्स्ट फ्रेम का स्वामी सेल खोजें**

जब सामान्य टेक्स्ट‑प्रोसेसिंग कोड को टेबल से कोई [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त होता है, तो स्वामी [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) प्राप्त करने के लिये [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) प्रॉपर्टी का उपयोग करें। टेबल‑सेल टेक्स्ट फ्रेम के लिये, [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) सेट होता है और [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) `null` रहता है, हालांकि टेबल स्वयं एक Shape है।

सेल निर्देशांक पढ़ने‑के‑लिए‑केवल [ICell.FirstColumnIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/firstcolumnindex/) और [ICell.FirstRowIndex](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/firstrowindex/) प्रॉपर्टीज़ उपलब्ध हैं। [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) भी केवल‑पढ़ने‑के‑लिए है: यह स्वामी तक नेविगेशन प्रदान करता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा जाँचें कि प्राप्त सेल `null` तो नहीं है।

टेबल‑सेल और Shape स्वामियों की पहचान करने वाले पूर्ण उदाहरण के लिये, जिसमें SmartArt नोड्स से जुड़ी शैलियों शामिल हैं, देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **टेबल में टेक्स्ट को संरेखित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।  
2. उसके सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।  
4. टेबल से एक [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) ऑब्जेक्ट प्राप्त करें।  
5. [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) तक पहुंचें।  
6. टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C# कोड टेबल में टेक्स्ट को संरेखित करने का तरीका दिखाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **टेबल स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।  
2. सूचकांक द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) ऑब्जेक्ट प्राप्त करें।  
4. टेक्स्ट के लिये [FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontheight/) सेट करें।  
5. [Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginright/) सेट करें।  
6. [TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/textverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C# कोड टेबल में टेक्स्ट पर वांछित फ़ॉर्मेटिंग लागू करने का तरीका दिखाता है:

```c#
using Aspose.Slides;

// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // मान लेते हैं कि पहली स्लाइड पर पहली शेप एक टेबल है

// टेबल सेल्स का फ़ॉन्ट ऊँचाई सेट करता है
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// एक कॉल में टेबल सेल्स का टेक्स्ट अलाइनमेंट और दायाँ मार्जिन सेट करता है
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// टेबल सेल्स का टेक्स्ट वर्टिकल टाइप सेट करता है
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **टेबल शैली गुण प्राप्त करें**

Aspose.Slides आपको टेबल की शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य टेबल या कहीं और उपयोग कर सकें। यह C# कोड आपको एक टेबल प्रीसेट शैली से शैली गुण प्राप्त करने का तरीका दिखाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // डिफ़ॉल्ट शैली प्रीसेट थीम को बदलें 

    // टेबल का शैली प्रीसेट प्राप्त करें।
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // प्राप्त किए गए शैली प्रीसेट को दूसरे टेबल पर लागू करें।
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **टेबल का आयाम अनुपात लॉक करें**

ज्यामितीय आकार का आयाम अनुपात विभिन्न आयामों में उसके आकारों का अनुपात होता है। Aspose.Slides ने `AspectRatioLocked` प्रॉपर्टी प्रदान की है जिससे आप टेबल और अन्य आकारों के लिये आयाम अनुपात सेटिंग को लॉक कर सकते हैं।  

यह C# कोड टेबल के लिये आयाम अनुपात लॉक करने का तरीका दिखाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // उलटें

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या मैं पूरी टेबल और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ से बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता/सकती हूँ?**

हाँ। टेबल एक [RightToLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/table/righttoleft/) प्रॉपर्टी प्रदान करती है, और पैराग्राफ़ में [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphformat/righttoleft/) होता है। दोनों का उपयोग करने से कोशिकाओं के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में टेबल को स्थानांतरित या आकार बदलने से कैसे रोक सकता/सकती हूँ?**

[shape locks](/slides/hi/net/applying-protection-to-presentation/) का उपयोग करके स्थानांतरण, आकार बदलने, चयन आदि को निष्क्रिय करें। ये लॉक टेबल पर भी लागू होते हैं।

**क्या सेल के भीतर पृष्ठभूमि के रूप में छवि डालना समर्थित है?**

हां। आप सेल के लिए एक [picture fill](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (खिंचा हुआ या टाइल) के अनुसार सेल के क्षेत्र को कवर कर देगी।