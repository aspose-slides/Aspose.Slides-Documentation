---
title: 取得簡報的檔案格式
type: docs
weight: 50
url: /zh-hant/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
為了取得檔案格式，請遵循以下步驟：

- 建立 **IPresentationInfo** 類別的實例
- 取得簡報的資訊

在下面的範例中，我們已取得檔案格式。
## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)