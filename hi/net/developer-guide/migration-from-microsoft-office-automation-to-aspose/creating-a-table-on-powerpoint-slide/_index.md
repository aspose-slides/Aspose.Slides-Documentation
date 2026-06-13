---
title: VSTO और Aspose.Slides for .NET का उपयोग करके टेबल बनाना
linktitle: टेबल बनाना
type: docs
weight: 50
url: /hi/net/creating-a-table-on-powerpoint-slide/
keywords:
- टेबल बनाना
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में माइग्रेट करें और C# में लचीले प्रारूपण के साथ PowerPoint (PPT, PPTX) स्लाइड्स में टेबल बनाएं।"
---
{{% alert color="primary" %}} 

टेबल्स का व्यापक उपयोग प्रस्तुति स्लाइड्स पर डेटा प्रदर्शित करने के लिए किया जाता है। यह लेख दिखाता है कि कैसे प्रोग्रामेटिक रूप से पहले [VSTO 2008](/slides/hi/net/creating-a-table-on-powerpoint-slide/) और फिर [Aspose.Slides for .NET](/slides/hi/net/creating-a-table-on-powerpoint-slide/) का उपयोग करके 15 x 15 टेबल को फ़ॉन्ट आकार 10 के साथ बनाया जा सकता है।

{{% /alert %}} 
## **Creating Tables**
#### **VSTO 2008 Example**
निम्नलिखित चरण VSTO का उपयोग करके Microsoft PowerPoint स्लाइड में एक टेबल जोड़ते हैं:

1. एक प्रस्तुति बनाएं।
1. एक खाली स्लाइड प्रस्तुति में जोड़ें।
1. स्लाइड में 15 x 15 टेबल जोड़ें।
1. टेबल की प्रत्येक सेल में फ़ॉन्ट आकार 10 के साथ टेक्स्ट जोड़ें।
1. प्रस्तुति को डिस्क पर सहेजें।

```c#
//प्रेजेंटेशन बनाएं
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//सभी पंक्तियों के माध्यम से लूप करें
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //पंक्ति में सभी सेल्स के माध्यम से लूप करें
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //प्रत्येक सेल का टेक्स्ट फ्रेम प्राप्त करें
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //कुछ टेक्स्ट जोड़ें
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //टेक्स्ट का फ़ॉन्ट आकार 10 सेट करें
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//प्रेजेंटेशन को डिस्क पर सहेजें
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET Example**
निम्नलिखित चरण Aspose.Slides का उपयोग करके Microsoft PowerPoint स्लाइड में एक टेबल जोड़ते हैं:

1. एक प्रस्तुति बनाएं।
1. पहली स्लाइड में 15 x 15 टेबल जोड़ें।
1. टेबल की प्रत्येक सेल में फ़ॉन्ट आकार 10 के साथ टेक्स्ट जोड़ें।
1. प्रस्तुति को डिस्क पर लिखें।

```c#
Presentation pres = new Presentation();

//पहली स्लाइड तक पहुंचें
ISlide sld = pres.Slides[0];

//चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करें
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//टेबल जोड़ें
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करें
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//प्रत्येक सेल का टेक्स्ट फ्रेम प्राप्त करें
		ITextFrame tf = cell.TextFrame;
		//कुछ टेक्स्ट जोड़ें
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//फ़ॉन्ट आकार 10 सेट करें
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//प्रेजेंटेशन को डिस्क पर लिखें
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```