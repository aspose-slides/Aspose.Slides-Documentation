---
title: VSTO ve Aspose.Slides for .NET Kullanarak Metni Biçimlendirme
linktitle: Metni Biçimlendirme
type: docs
weight: 30
url: /tr/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- metni biçimlendir
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçiş yapın ve PowerPoint (PPT, PPTX) sunumlarında metni hassas bir kontrolle biçimlendirin."
---
{{% alert color="info" %}} 
Bazen slaytlardaki metni programlı olarak biçimlendirmeniz gerekir. Bu makale, birinci slaytta bazı metinler içeren örnek bir sunumu VSTO ve [Aspose.Slides for .NET](/slides/tr/net/format-text-using-vsto-and-aspose-slides-and-net/) kullanarak nasıl okuyacağınızı gösterir. Kod, slayttaki üçüncü metin kutusundaki metni son metin kutusundaki gibi biçimlendirir.
{{% /alert %}} 
## **Metni Biçimlendirme**
Hem VSTO hem de Aspose.Slides yöntemleri aşağıdaki adımları izler:

1. Kaynak sunumu açın.
1. İlk slayta erişin.
1. Üçüncü metin kutusuna erişin.
1. Üçüncü metin kutusundaki metnin biçimini değiştirin.
1. Sunumu diske kaydedin.

Aşağıdaki ekran görüntüleri, VSTO ve Aspose.Slides for .NET kodunun çalıştırılmasından önce ve sonra örnek slaytı gösterir.

**Girdi sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Kod Örneği**
Aşağıdaki kod, VSTO kullanarak bir slayd üzerindeki metni nasıl yeniden biçimlendireceğinizi gösterir.

**VSTO ile yeniden biçimlendirilmiş metin** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Not: PowerPoint, yukarıda şu şekilde tanımlanmış bir ad alanıdır
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET Örneği**
Aspose.Slides ile metni biçimlendirmek için, metni biçimlendirmeden önce yazı tipini ekleyin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Open the presentation
Presentation pres = new Presentation("source.ppt");

//Access the first slide
//İlk slayta eriş
ISlide slide = pres.Slides[0];

//Access the third shape
//Üçüncü şekle eriş
IShape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32
//Metnin yazı tipini Verdana ve boyutunu 32 olarak değiştir
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Bolden it
//Kalın yap
port.PortionFormat.FontBold = NullableBool.True;

//Italicize it
//Eğik yap
port.PortionFormat.FontItalic = NullableBool.True;

//Change text color
//Metin rengini değiştir
//Set font color
//Yazı tipi rengini ayarla
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Change shape background color
//Şekil arka plan rengini değiştir
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Write the output to disk
//Çıktıyı diske kaydet
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```