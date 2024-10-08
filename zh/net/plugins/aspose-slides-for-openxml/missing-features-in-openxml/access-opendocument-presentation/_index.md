---
title: 访问 OpenDocument 演示文稿
type: docs
weight: 10
url: /net/access-opendocument-presentation/
---

Aspose.Slides for .NET 提供的 **Presentation** 类代表一个演示文稿文件。现在 **Presentation** 类还可以通过 **Presentation** 构造函数访问 **ODP**，当对象被实例化时。
## **示例**
``` csharp

 string FilePath = @"..\..\..\样本文件\";

string srcFileName = FilePath + "OpenDocument 演示文稿.odp";

string destFileName = FilePath + "OpenDocument 演示文稿.pptx";

//实例化一个表示演示文稿文件的 Presentation 对象

using (Presentation pres = new Presentation(srcFileName))

{

    //将 PPTX 演示文稿保存为 PPTX 格式

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下载运行示例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)