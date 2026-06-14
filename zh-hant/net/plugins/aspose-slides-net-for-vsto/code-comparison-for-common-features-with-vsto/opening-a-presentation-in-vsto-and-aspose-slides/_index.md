---
title: 在 VSTO 和 Aspose.Slides 中開啟簡報
type: docs
weight: 120
url: /zh-hant/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
以下是開啟簡報的程式碼片段：

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET 提供了用於開啟現有簡報的 **Presentation** 類別。它提供了幾個重載的建構函式，我們可以使用 **Presentation** 類別的其中一個適當建構函式，根據現有簡報建立其物件。在下方範例中，我們將要開啟的簡報檔案名稱傳遞給 **Presentation** 類別的建構函式。檔案開啟後，我們取得簡報中總共的投影片數量，並將其印在螢幕上。

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **下載執行程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)