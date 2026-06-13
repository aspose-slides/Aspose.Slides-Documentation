---
title: VSTO और Aspose.Slides में PowerPoint स्लाइड पर तालिका बनाना
type: docs
weight: 90
url: /hi/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
निम्नलिखित चरण VSTO का उपयोग करके Microsoft PowerPoint स्लाइड में एक तालिका जोड़ते हैं:

- एक प्रस्तुति बनाएँ।
- एक खाली स्लाइड प्रस्तुति में जोड़ें।
- स्लाइड में 15 x 15 की तालिका जोड़ें।
- तालिका की प्रत्येक कक्ष में फ़ॉन्ट आकार 10 के साथ पाठ जोड़ें।
- प्रस्तुति को डिस्क पर सहेजें।
## **VSTO**
``` csharp

 //प्रस्तुति बनाएँ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//एक खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//सभी पंक्तियों पर लूप करें
foreach (PowerPoint.Row row in tbl.Rows)
{
	i = i + 1;
	j = -1;
	//पंक्ति में सभी कोशिकाओं पर लूप करें
	foreach (PowerPoint.Cell cell in row.Cells)
	{
		j = j + 1;
		//प्रत्येक कोशिका का टेक्स्ट फ्रेम प्राप्त करें
		PowerPoint.TextFrame tf = cell.Shape.TextFrame;
		//कुछ पाठ जोड़ें
		tf.TextRange.Text = "T" + i.ToString() + j.ToString();
		//पाठ का फ़ॉन्ट आकार 10 सेट करें
		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
	}
}

//प्रस्तुति को डिस्क पर सहेजें
pres.SaveAs("tblVSTO.ppt",
	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	  Microsoft.Office.Core.MsoTriState.msoFalse);
``` 

निम्नलिखित चरण Aspose.Slides का उपयोग करके Microsoft PowerPoint स्लाइड में एक तालिका जोड़ते हैं:

- एक प्रस्तुति बनाएँ।
- पहले स्लाइड में 15 x 15 की तालिका जोड़ें।
- तालिका की प्रत्येक कक्ष में फ़ॉन्ट आकार 10 के साथ पाठ जोड़ें।
- प्रस्तुति को डिस्क पर लिखें।
## **Aspose.Slides**
``` csharp

 //प्रस्तुति बनाएं

Presentation pres = new Presentation();

//पहली स्लाइड तक पहुंचें

Slide sld = pres.GetSlideByPosition(1);

//तालिका जोड़ें

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//पंक्तियों पर लूप करें

for (int i = 0; i < tbl.RowsNumber; i++)

	//कोशिकाओं पर लूप करें

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//प्रत्येक कोशिका का टेक्स्ट फ्रेम प्राप्त करें

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//कुछ पाठ जोड़ें

		tf.Text = "T" + i.ToString() + j.ToString();

		//फ़ॉन्ट आकार 10 सेट करें

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//प्रस्तुति को डिस्क पर लिखें

pres.Write("tblSLD.ppt");

``` 
## **सैंपल कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)