---
title: Конвертация из PPT в формат PPTX в Aspose.Slides
type: docs
weight: 10
url: /ru/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** для .NET теперь позволяет разработчикам получать доступ к PPT с помощью экземпляра класса Presentation и конвертировать его в соответствующий формат PPTX. В настоящее время поддерживается частичная конверсия PPT в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях конверсии PPT в PPTX перейдите по этой ссылке на документацию.

**Aspose.Slides** для .NET предоставляет класс Presentation, который представляет файл презентации PPTX. Класс Presentation теперь также может получать доступ к PPT через Presentation при создании объекта.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Скачать пример кода**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)