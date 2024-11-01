---
title: 获取演示文稿的文件格式
type: docs
weight: 50
url: /zh/net/get-the-file-format-of-presentation/
---

为了获取文件格式，请按照以下步骤操作：

- 创建 **IPresentationInfo** 类的实例
- 获取关于演示文稿的信息

在下面给出的示例中，我们获取了文件格式。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "获取文件格式.pptx";

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
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **下载运行示例**
- [Codeplex](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)