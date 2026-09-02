---
title: 带备注的 TIFF 转换
type: docs
weight: 10
url: /zh/net/conversion-to-tiff-with-notes/
---
TIFF 是 Aspose.Slides for .NET 支持的几种常用图像格式之一，可用于将带备注的演示文稿转换为图像。您还可以在备注幻灯片视图中生成幻灯片缩略图。下面的两个代码片段展示了如何在备注幻灯片视图中生成演示文稿的 TIFF 图像。

**Save** 方法由 **Presentation** 类公开，可用于将整个演示文稿在备注幻灯片视图中转换为 TIFF。您也可以为单个幻灯片在备注幻灯片视图中生成幻灯片缩略图。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation(srcFileName))
{
    //将演讲者备注放置在每张渲染的幻灯片下方
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //将演示文稿保存为带备注的 TIFF
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)