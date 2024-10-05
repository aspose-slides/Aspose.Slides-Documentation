---
title: PPTからPPTX形式への変換
type: docs
weight: 20
url: /net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slidesの独自機能は、作業に影響を与えずにバージョン変換の柔軟性を提供します。SaveFormatは、以下の表に示す拡張子でドキュメントを変換できる列挙型です。

|**メンバー名**|**値**|**説明**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDFノート|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|Tiffノート|14| |
|XPS|2| |
以下は、PPTからPPTXへの変換を示すコードスニペットで、逆に変換することもできます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//PPTXファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(srcFileName);

//PPTXプレゼンテーションをPPTX形式で保存

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **サンプルコードをダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)