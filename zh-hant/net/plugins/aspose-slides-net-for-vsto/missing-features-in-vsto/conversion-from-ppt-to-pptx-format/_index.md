---
title: 從 PPT 轉換為 PPTX 格式
type: docs
weight: 20
url: /zh-hant/net/conversion-from-ppt-to-pptx-format/
---
Aspose.Slides 獨特的功能，提供在版本轉換時的彈性，且不影響工作。  
SaveFormat 是一個列舉，可將文件轉換為下表中列出的副檔名。

|**成員名稱**|**值**|**說明**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

以下程式碼片段展示了從 PPT 轉換為 PPTX 的方法，也可以反向操作。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//實例化一個代表 PPTX 檔案的 Presentation 物件

Presentation pres = new Presentation(srcFileName);

//將 PPTX 簡報儲存為 PPTX 格式

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)