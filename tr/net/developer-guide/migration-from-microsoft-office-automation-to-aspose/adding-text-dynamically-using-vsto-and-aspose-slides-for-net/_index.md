---
title: VSTO ve Aspose.Slides for .NET Kullanarak Dinamik Metin Ekleme
linktitle: Dinamik Metin Ekleme
type: docs
weight: 20
url: /tr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- metin ekle
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e nasıl geçileceğini ve C# ile PowerPoint (PPT, PPTX) sunumlarına dinamik metin nasıl ekleneceğini görün."
---
{{% alert color="primary" %}} 

Geliştiricilerin sıkça gerçekleştirdiği bir görev, slaytlara dinamik olarak metin eklemektir. Bu makale, [VSTO](/slides/tr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) ve [Aspose.Slides for .NET](/slides/tr/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) kullanarak dinamik metin ekleme için kod örneklerini gösterir.

{{% /alert %}} 
## **Dinamik Olarak Metin Ekleme**
Her iki yöntem de şu adımları izler:

1. Bir sunum oluşturun.
1. Boş bir slayt ekleyin.
1. Bir metin kutusu ekleyin.
1. Metin ayarlayın.
1. Sunumu kaydedin.

## **VSTO Kod Örneği**
Aşağıdaki kod parçacıkları, düz bir slayt ve üzerinde bir metin satırı olan bir sunum oluşturur.

**VSTO'da oluşturulan sunum** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Not: PowerPoint, yukarıda şu şekilde tanımlanmış bir ad alanıdır
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Sunum oluştur
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Boş slayt düzenini al
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Boş bir slayt ekle
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Metin ekle
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Metni ayarla
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Çıktıyı diske kaydet
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```

## **Aspose.Slides for .NET Örneği**
Aşağıdaki kod parçacıkları, Aspose.Slides kullanarak düz bir slayt ve üzerinde bir metin satırı bulunan bir sunum oluşturur.

**Aspose.Slides for .NET kullanılarak oluşturulan sunum** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Bir sunum oluştur
Presentation pres = new Presentation();

//Boş slayt varsayılan olarak eklenir, oluşturduğunuzda
//varsayılan kurucudan sunum
//Bu yüzden herhangi bir boş slayt eklememize gerek yok
ISlide sld = pres.Slides[1];

//Bir metin kutusu ekle
//Bunu eklemek için önce bir dikdörtgen ekleyeceğiz
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Çizgisini gizle
shp.LineFormat.Style = LineStyle.NotDefined;

//Ardından içine bir metin çerçevesi ekle
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Metin ayarla
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Çıktıyı diske kaydet
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```