---
title: 从 PPT 到 PPTX 格式的转换
type: docs
weight: 20
url: /zh/net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides 独特的功能，提供在版本转换时的灵活性，而不会影响工作。  
SaveFormat 是一个枚举，可将文档转换为下表中给出的扩展名。

|**成员名称**|**值**|**描述**|
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

以下代码片段展示了从 PPT 转换为 PPTX 的示例，您也可以逆向转换。

``` csharp
 string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";
string destFileName = FilePath + "Conversion PPT to PPTX.pptx";
//Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation(srcFileName);
//Saving the PPTX presentation to PPTX format
pres.Save(destFileName, SaveFormat.Pptx);
``` 

## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)