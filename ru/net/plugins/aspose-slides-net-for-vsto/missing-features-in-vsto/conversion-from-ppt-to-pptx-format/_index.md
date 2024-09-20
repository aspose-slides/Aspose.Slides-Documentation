---  
title: Конвертация из формата PPT в формат PPTX  
type: docs  
weight: 20  
url: /net/conversion-from-ppt-to-pptx-format/  
---  

Уникальная функция Aspose.Slides, которая предоставляет гибкость при конвертации версий без влияния на работу.  
SaveFormat - это перечисление, которое может конвертировать документы в расширения, указанные в таблице ниже.  

|**Имя члена**|**Значение**|**Описание**|  
| :- | :- | :- |  
|HTML|13| |  
|ODP|6| |  
|PDF|1| |  
|PDF Notes|12| |  
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
Ниже приведен фрагмент кода, который демонстрирует конвертацию из PPT в PPTX, вы можете сделать это и наоборот.  

``` csharp  

 string FilePath = @"..\..\..\Sample Files\";  

string srcFileName = FilePath + "Конвертация PPT в PPTX.ppt";  

string destFileName = FilePath + "Конвертация PPT в PPTX.pptx";  

// Создание объекта Presentation, представляющего файл PPTX  

Presentation pres = new Presentation(srcFileName);  

// Сохранение презентации PPTX в формате PPTX  

pres.Save(destFileName, SaveFormat.Pptx);  

```   
## **Скачать образец кода**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)  