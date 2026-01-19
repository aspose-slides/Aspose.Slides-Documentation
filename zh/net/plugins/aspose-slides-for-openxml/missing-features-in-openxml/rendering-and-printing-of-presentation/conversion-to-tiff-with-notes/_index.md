---
title: 带备注的 TIFF 转换
type: docs
weight: 10
url: /zh/net/conversion-to-tiff-with-notes/
---

TIFF 是 Aspose.Slides for .NET 支持的多种常用图像格式之一，可用于将带注释的演示文稿转换为图像。您还可以在备注幻灯片视图中生成幻灯片缩略图。下面提供了两个代码片段，演示如何在备注幻灯片视图中生成演示文稿的 TIFF 图像。

**Presentation** 类公开的 **Save** 方法可用于将整个备注幻灯片视图的演示文稿转换为 TIFF。您也可以为单个幻灯片在备注幻灯片视图中生成缩略图。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)