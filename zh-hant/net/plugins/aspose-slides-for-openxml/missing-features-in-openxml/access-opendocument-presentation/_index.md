---
title: 存取 OpenDocument 簡報
type: docs
weight: 10
url: /zh-hant/net/access-opendocument-presentation/
---
Aspose.Slides for .NET 提供 **Presentation** 類別，該類別代表一個簡報檔案。**Presentation** 類別現在也可以在實例化物件時，透過 **Presentation** 建構函式存取 **ODP**。
## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//建立一個代表簡報檔案的 Presentation 物件

using (Presentation pres = new Presentation(srcFileName))

{

    //將 PPTX 簡報儲存為 PPTX 格式

    pres.Save(destFileName, SaveFormat.Pptx);

}
``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)