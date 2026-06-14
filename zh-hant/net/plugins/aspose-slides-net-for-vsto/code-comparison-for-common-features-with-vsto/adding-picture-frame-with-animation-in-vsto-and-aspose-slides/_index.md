---
title: 在 VSTO 與 Aspose.Slides 中加入帶動畫的圖片框架
type: docs
weight: 20
url: /zh-hant/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
以下程式碼範例會建立一個簡報與投影片，加入帶有圖片框架的影像，並對其套用動畫。
## **VSTO**
使用 VSTO，請執行以下步驟：

1. 建立簡報。
1. 新增空白投影片。
1. 在投影片中加入圖片形狀。
1. 對圖片套用動畫。
1. 將簡報寫入磁碟。

``` csharp

 //建立空白簡報

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//新增空白投影片

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//新增圖片框架

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//對圖片框架套用動畫

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//儲存簡報

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
使用 Aspose.Slides for .NET，請執行以下步驟：

1. 建立簡報。
1. 存取第一張投影片。
1. 將影像加入圖片集合。
1. 在投影片中加入圖片形狀。
1. 對圖片套用動畫。
1. 將簡報寫入磁碟。

``` csharp

 //建立空白簡報

Presentation pres = new Presentation();

 //存取第一張投影片

Slide slide = pres.GetSlideByPosition(1);

 //將圖片物件加入簡報的圖片集合

Picture pic = new Picture(pres, "pic.jpeg");

 //加入圖片物件後，會給予唯一的圖片 Id

int picId = pres.Pictures.Add(pic);

 //新增圖片框架

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

 //對圖片框架套用動畫

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

 //儲存簡報

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)