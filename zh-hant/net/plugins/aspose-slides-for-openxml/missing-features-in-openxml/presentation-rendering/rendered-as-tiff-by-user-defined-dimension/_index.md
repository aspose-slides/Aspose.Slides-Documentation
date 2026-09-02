---
title: 使用者自訂尺寸渲染為 Tiff
type: docs
weight: 40
url: /zh-hant/net/rendered-as-tiff-by-user-defined-dimension/
---
以下範例示範如何使用 **TiffOptions** 類別，將簡報轉換為具有自訂影像大小的 TIFF 文件。

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation(srcFileName);

//實例化 TiffOptions 類別
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//設定壓縮類型
opts.CompressionType = TiffCompressionTypes.Default;

//壓縮類型
//Default - 指定預設的壓縮方案 (LZW).
//None - 指定不使用壓縮.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - 取決於壓縮類型，無法手動設定.
//Resolution unit - 永遠等於 "2"（每英寸點數）

//設定影像 DPI
opts.DpiX = 200;
opts.DpiY = 100;

//設定影像大小
opts.ImageSize = new Size(1728, 1078);

//將簡報存為 TIFF，使用指定的影像大小
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)