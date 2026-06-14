---
title: 新增圖片框架至簡報
type: docs
weight: 50
url: /zh-hant/net/add-picture-frame-to-presentation/
---
## **VSTO**
以下是於 VSTO 簡報中加入圖片的程式碼：

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
若要在投影片中加入簡單的圖片框架，請依照以下步驟：

1. 建立 Presentation 類別的執行個體。
1. 使用索引取得投影片的參照。
1. 透過將影像加入與 Presentation 物件相關聯的 Images 集合，建立 Image 物件，以便用於填充 Shape。
1. 計算影像的寬度與高度。
1. 使用與參照投影片相關聯的 Shapes 物件所提供的 AddPictureFrame 方法，依影像的寬度與高度建立 PictureFrame。
1. 將包含圖片的 PictureFrame 加入投影片。
1. 將已修改的簡報寫入為 PPTX 檔案。

上述步驟已於下方範例中實作。

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //實例化代表 PPTX 的 Presentation 類別

  Presentation pres = new Presentation();

  //取得第一張投影片

  ISlide sld = pres.Slides[0];

  //實例化 ImageEx 類別

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //新增與圖片等高寬的圖片框架

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);
``` 
## **下載執行程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)