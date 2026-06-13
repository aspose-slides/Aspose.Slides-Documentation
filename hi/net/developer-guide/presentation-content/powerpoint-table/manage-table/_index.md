---
title: .NET में प्रस्तुतिकरण तालिकाओं को प्रबंधित करें
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/net/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- पक्ष अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल C# कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रदर्शित करने और दर्शाने का एक प्रभावी तरीका है। कोशिकाओं की ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी स्पष्ट और समझने में आसान होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/net/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/net/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जिससे आप विभिन्न प्रकार की प्रस्तुतियों में तालिकाओं को बना, अपडेट और प्रबंधित कर सकते हैं। 

## **शुरुआत से तालिका बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. `columnWidth` की एक एरे परिभाषित करें।  
4. `rowHeight` की एक एरे परिभाषित करें।  
5. [AddTable](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से स्लाइड में एक [ITable] ऑब्जेक्ट जोड़ें।  
6. प्रत्येक [ICell] पर इटरेट करके शीर्ष, नीचे, दायें और बाएँ सीमाओं पर फॉर्मेटिंग लागू करें।  
7. तालिका की पहली पंक्ति की पहली दो कोशिकाओं को मर्ज करें।  
8. किसी [ICell] की [TextFrame] तक पहुंचें।  
9. [TextFrame] में कुछ टेक्स्ट जोड़ें।  
10. संशोधित प्रस्तुतिकरण को सेव करें।

```c#
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंशिएट करता है
Presentation pres = new Presentation();

// पहली स्लाइड तक पहुंचता है
ISlide sld = pres.Slides[0];

// स्तंभों को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// स्लाइड में एक तालिका आकार जोड़ता है
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
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
// पहली पंक्ति की कोशिकाएँ 1 और 2 को मर्ज करता है
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// मर्ज की गई कोशिका में कुछ पाठ जोड़ता है
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// प्रस्तुति को डिस्क पर सहेजता है
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, कोशिकाओं की क्रमांकन सरल और शून्य-आधारित होती है। तालिका में पहली कोशिका का इंडेक्स 0,0 (स्तंभ 0, पंक्ति 0) होता है।  

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाएँ इस प्रकार क्रमांकित की जाती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```c#
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंशिएट करता है
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.Slides[0];

    // स्तंभों को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक तालिका आकार जोड़ता है
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
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

## **मौजूदा तालिका तक पहुंचें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  

2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का रेफरेंस प्राप्त करें।  

3. एक [ITable] ऑब्जेक्ट बनाएं और उसे null सेट करें।  

4. सभी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) ऑब्जेक्ट्स को इटरेट करें जब तक तालिका न मिल जाए।  
   अगर आप देखते हैं कि स्लाइड में केवल एक तालिका है, तो आप सभी आकारों को जाँच सकते हैं। जब कोई आकार तालिका के रूप में पहचाना जाता है, तो आप उसे [Table] ऑब्जेक्ट के रूप में टाइपकास्ट कर सकते हैं। लेकिन अगर स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [AlternativeText](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/alternativetext/) के माध्यम से खोजना बेहतर रहेगा।  

5. तालिका के साथ काम करने के लिए [ITable] ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में हमने तालिका में एक नई पंक्ति जोड़ी है।  

6. संशोधित प्रस्तुतिकरण को सेव करें।  

```c#
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंशिएट करता है
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.Slides[0];

    // null TableEx को आरंभ करता है
    ITable tbl = null;

    // आकृतियों के माध्यम से इटरेट करता है और मिली तालिका का रेफ़रेंस सेट करता है
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // दूसरी पंक्ति के पहले स्तंभ के लिए टेक्स्ट सेट करता है
    tbl[0, 1].TextFrame.Text = "New";

    // संशोधित प्रस्तुति को डिस्क पर सहेजता है
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **तालिका में टेक्स्ट को संरेखित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड में एक [ITable] ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [ITextFrame] ऑब्जेक्ट तक पहुंचें।  
5. [ITextFrame] की [IParagraph] तक पहुंचें।  
6. टेक्स्ट को लंबवत रूप से संरेखित करें।  
7. संशोधित प्रस्तुतिकरण को सेव करें।  

```c#
// Presentation क्लास की एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();

// पहली स्लाइड प्राप्त करता है
ISlide slide = presentation.Slides[0];

// स्तंभों को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// स्लाइड में तालिका आकार जोड़ता है
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// टेक्स्ट फ्रेम तक पहुंचता है
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
IParagraph paragraph = txtFrame.Paragraphs[0];

// पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// टेक्स्ट को लंबवत संरेखित करता है
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// प्रस्तुति को डिस्क पर सहेजता है
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड से एक [ITable] ऑब्जेक्ट तक पहुंचें।  
4. टेक्स्ट के लिए [FontHeight] सेट करें।  
5. [Alignment] और [MarginRight] सेट करें।  
6. [TextVerticalType] सेट करें।  
7. संशोधित प्रस्तुतिकरण को सेव करें।  

```c#
// Presentation क्लास की एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // मान लीजिए कि पहली स्लाइड पर पहला आकार एक तालिका है

// तालिका कोशिकाओं का फ़ॉन्ट ऊँचाई सेट करता है
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// एक ही कॉल में तालिका कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// तालिका कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका की शैली गुण प्राप्त करने की सुविधा देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह C# कोड आपको तालिका की प्रीसेट शैली से शैली गुण प्राप्त करने का तरीका दिखाता है:  

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // डिफ़ॉल्ट शैली प्रीसेट थीम बदलें
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **तालिका का पक्ष अनुपात लॉक करें**

भौगोलिक आकार का अनुपात विभिन्न आयामों में उसके आकार का अनुपात होता है। Aspose.Slides ने `AspectRatioLocked` प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य आकारों के लिए अनुपात सेटिंग को लॉक कर सकते हैं।  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // उलटा

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**  

हाँ। तालिका एक [RightToLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/table/righttoleft/) प्रॉपर्टी उजागर करती है, और पैराग्राफ में भी [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphformat/righttoleft/) होता है। दोनों का उपयोग करने से कोशिकाओं के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।  

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**  

[shape locks](/slides/hi/net/applying-protection-to-presentation/) का उपयोग करके स्थानांतरित करना, आकार बदलना, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।  

**क्या किसी सेल के अंदर पृष्ठभूमि के रूप में छवि सम्मिलित करना समर्थित है?**  

हाँ। आप किसी सेल के लिए [picture fill](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्टेच या टाइल) के अनुसार सेल क्षेत्र को कवर करेगी।  