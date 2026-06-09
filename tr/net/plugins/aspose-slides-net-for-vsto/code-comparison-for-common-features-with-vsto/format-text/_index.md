---
title: Metin Biçimlendirme
type: docs
weight: 110
url: /tr/net/format-text/
---
VSTO ve Aspose.Slides yöntemleri aşağıdaki adımları izler:

- Kaynak sunumu açın.
- İlk slayda erişin.
- Üçüncü metin kutusuna erişin.
- Üçüncü metin kutusundaki metnin biçimlendirmesini değiştirin.
- Sunumu diske kaydedin.
## **VSTO**
``` csharp

 //Sunumu aç

Presentation pres = new Presentation("source.ppt");

//Verdana yazı tipini ekle

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//İlk slayta eriş

Slide slide = pres.GetSlideByPosition(1);

//Üçüncü şekle eriş

Shape shp = slide.Shapes[2];

//Metnin yazı tipini Verdana'ya ve yüksekliğini 32'ye değiştir

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Kalın yap

port.FontBold = true;

//İtalik yap

port.FontItalic = true;

//Metin rengini değiştir

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Şekil arka plan rengini değiştir

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Çıktıyı diske yaz

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Sunumu aç

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoFalse,

    Microsoft.Office.Core.MsoTriState.msoTrue);

//İlk slayta eriş

PowerPoint.Slide slide = pres.Slides[1];

//Üçüncü şekle eriş

PowerPoint.Shape shp = slide.Shapes[3];

//Metnin yazı tipini Verdana'ya ve yüksekliğini 32'ye değiştir

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

pres.SaveAs("outVSTO.ppt",

    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

    Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)