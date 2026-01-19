---
title: PPT から PPTX 形式への変換
type: docs
weight: 20
url: /ja/net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides のユニークな機能は、作業に影響を与えることなくバージョン間の変換に柔軟性を提供します。  
SaveFormat は列挙型で、以下の表に示す拡張子にドキュメントを変換できます。

|**メンバー名**|**値**|**説明**|
| :- | :- | :- |
|HTML|13||
|ODP|6||
|PDF|1||
|PDF Notes|12||
|POTM|11||
|POTX|10||
|PPS|0||
|PPSM|9||
|PPSX|4||
|PPT|0||
|PPTM|7||
|PPTX|3||
|TIFF|5||
|TiffNotes|14||
|XPS|2||

以下は PPT から PPTX への変換を示すコードスニペットです。逆方向の変換も可能です。

``` csharp
 string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";
string destFileName = FilePath + "Conversion PPT to PPTX.pptx";
//Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation(srcFileName);
//Saving the PPTX presentation to PPTX format
pres.Save(destFileName, SaveFormat.Pptx);
``` 

## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)