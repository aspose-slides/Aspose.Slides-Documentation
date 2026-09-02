---
title: 按用户定义尺寸渲染为 Tiff
type: docs
weight: 40
url: /zh/net/rendered-as-tiff-by-user-defined-dimension/
---
以下示例演示如何使用 **TiffOptions** 类将演示文稿转换为具有自定义图像大小的 TIFF 文档。

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//实例化表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation(srcFileName);

//实例化 TiffOptions 类

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//设置压缩类型

opts.CompressionType = TiffCompressionTypes.Default;

//压缩类型

//默认 - 指定默认的压缩方案 (LZW).

//无 - 指定不进行压缩.

//CCITT3

//CCITT4

//LZW

//RLE

//深度 - 取决于压缩类型，无法手动设置.

//分辨率单位 - 始终等于 "2"（每英寸点数）

//设置图像 DPI

opts.DpiX = 200;

opts.DpiY = 100;

//设置图像大小

opts.ImageSize = new Size(1728, 1078);

//使用指定的图像大小将演示文稿保存为 TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)