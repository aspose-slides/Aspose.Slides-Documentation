---
title: 从PPT格式转换为PPTX格式
type: docs
weight: 20
url: /net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides的独特功能提供了在版本转换时的灵活性，而不会影响工作。
SaveFormat是一个枚举，可以将文档转换为下表所示的扩展名。

|**成员名称**|**值**|**描述**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF 注释|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
下面是一个代码片段，显示了从PPT转换为PPTX，你也可以反向操作。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//实例化一个表示PPTX文件的Presentation对象

Presentation pres = new Presentation(srcFileName);

//将PPTX演示文稿保存为PPTX格式

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)