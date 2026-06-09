---
title: VSTO ve Aspose.Slides for .NET Kullanarak Metin Biçimlendirme
linktitle: Metni Biçimlendir
type: docs
weight: 30
url: /tr/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- metin biçimlendirme
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçiş yapın ve PowerPoint (PPT, PPTX) sunumlarında metni hassas kontrol ile biçimlendirin."
---
{{% alert color="primary" %}} 

Bazen, slaytlardaki metni programlı olarak biçimlendirmeniz gerekir. Bu makale, ilk slaytta bazı metinler içeren bir örnek sunumu ya [VSTO](/slides/tr/net/format-text-using-vsto-and-aspose-slides-and-net/) ya da [Aspose.Slides for .NET](/slides/tr/net/format-text-using-vsto-and-aspose-slides-and-net/) kullanarak nasıl okuyacağınızı gösterir. Kod, slayttaki üçüncü metin kutusundaki metni son metin kutusundaki gibi biçimler.

{{% /alert %}} 
## **Metni Biçimlendirme**
VSTO ve Aspose.Slides yöntemleri aşağıdaki adımları izler:

1. Kaynak sunumu açın.
1. İlk slayta erişin.
1. Üçüncü metin kutusuna erişin.
1. Üçüncü metin kutusundaki metnin biçimini değiştirin.
1. Sunumu diske kaydedin.

Aşağıdaki ekran görüntüleri, VSTO ve Aspose.Slides for .NET kodunun çalıştırılmasından önce ve sonra örnek slaytı gösterir.

**Girdi Sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Kod Örneği**
Aşağıdaki kod, VSTO kullanarak bir slayttaki metni nasıl yeniden biçimlendireceğinizi gösterir.

**VSTO ile yeniden biçimlendirilmiş metin** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Not: PowerPoint, yukarıda şu şekilde tanımlanmış bir ad alanıdır
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Sunumu aç
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//İlk slayta eriş
PowerPoint.Slide slide = pres.Slides[1];

//Üçüncü şekle eriş
PowerPoint.Shape shp = slide.Shapes[3];

//Metnin yazı tipini Verdana ve yüksekliğini 32 olarak değiştir
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Kalın yap
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//İtalik yap
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Metin rengini değiştir
txtRange.Font.Color.RGB = 0x00CC3333;

//Şekil arka plan rengini değiştir
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Yatay olarak yeniden konumlandır
shp.Left -= 70;

//Çıktıyı diske yaz
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET Örneği**
Aspose.Slides ile metni biçimlendirmek için, metni biçimlendirmeden önce yazı tipini ekleyin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Sunumu aç
Presentation pres = new Presentation("c:\\source.ppt");

//İlk slayta eriş
ISlide slide = pres.Slides[0];

//Üçüncü şekle eriş
IShape shp = slide.Shapes[2];

//Metnin yazı tipini Verdana ve yüksekliğini 32 olarak değiştir
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Kalın yap
port.PortionFormat.FontBold = NullableBool.True;

//İtalik yap
port.PortionFormat.FontItalic = NullableBool.True;

//Metin rengini değiştir
//Yazı tipi rengini ayarla
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Şekil arka plan rengini değiştir
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Çıktıyı diske yaz
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```