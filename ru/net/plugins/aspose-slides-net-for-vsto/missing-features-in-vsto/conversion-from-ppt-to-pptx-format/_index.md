---
title: Конвертация из формата PPT в формат PPTX
type: docs
weight: 20
url: /ru/net/conversion-from-ppt-to-pptx-format/
---

Уникальная функция Aspose.Slides, обеспечивающая гибкость при конвертации версий без влияния на работу.
SaveFormat — перечисление, которое может конвертировать документ в расширения, перечисленные в таблице ниже.

|**Имя члена**|**Значение**|**Описание**|
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

Ниже приведён фрагмент кода, показывающий конвертацию из PPT в PPTX; вы также можете выполнить обратную конвертацию.

``` csharp
 string FilePath = @"..\..\..\Sample Files\";
 
string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";
 
string destFileName = FilePath + "Conversion PPT to PPTX.pptx";
 
//Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation(srcFileName);
 
//Saving the PPTX presentation to PPTX format
pres.Save(destFileName, SaveFormat.Pptx);
``` 

## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)