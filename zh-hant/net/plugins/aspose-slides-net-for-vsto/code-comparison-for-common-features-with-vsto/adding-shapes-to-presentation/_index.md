---
title: 在簡報中添加形狀
type: docs
weight: 30
url: /zh-hant/net/adding-shapes-to-presentation/
---
## **VSTO**
以下是新增線條形狀的程式碼片段：

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
若要在簡報的選取投影片上新增簡單的直線，請依照以下步驟：

- 建立 Presentation 類別的實例
- 使用索引取得投影片的參考
- 使用 Shapes 物件提供的 AddAutoShape 方法，新增類型為 Line 的 AutoShape
- 將修改後的簡報寫入為 PPTX 檔案

在下列範例中，我們已在簡報的第一張投影片上新增了一條線條。

``` csharp

   //實例化表示 PPTX 的 Presentation 類別

  Presentation pres = new Presentation();

  //取得第一張投影片

  ISlide slide = pres.Slides[0];

  //新增類型為線條的自動形狀

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **下載執行程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)