---
title: Доступ к презентации OpenDocument
type: docs
weight: 10
url: /ru/net/access-opendocument-presentation/
---

Aspose.Slides для .NET предлагает класс **Presentation**, который представляет файл презентации. Теперь класс **Presentation** также может получать доступ к **ODP** через конструктор **Presentation** при создании объекта.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Презентация OpenDocument.odp";

string destFileName = FilePath + "Презентация OpenDocument.pptx";

//Создание объекта Presentation, который представляет файл презентации

using (Presentation pres = new Presentation(srcFileName))

{

    //Сохранение презентации PPTX в формат PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать рабочий пример**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)

