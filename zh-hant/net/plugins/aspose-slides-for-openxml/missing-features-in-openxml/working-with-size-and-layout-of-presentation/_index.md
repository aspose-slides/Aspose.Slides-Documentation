---
title: 運用簡報的大小與版面配置
type: docs
weight: 90
url: /zh-hant/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** 與 **SlideSize.Size** 為 presentation 類別的屬性，可如下例所示設定或取得。
## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//實例化一個代表簡報檔案的 Presentation 物件 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//將產生的簡報的投影片大小設定為來源簡報的大小

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//將簡報儲存至磁碟

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

如需更多資訊，請參閱 [在 .NET 中變更簡報投影片大小](/slides/zh-hant/net/slide-size/).

{{% /alert %}}