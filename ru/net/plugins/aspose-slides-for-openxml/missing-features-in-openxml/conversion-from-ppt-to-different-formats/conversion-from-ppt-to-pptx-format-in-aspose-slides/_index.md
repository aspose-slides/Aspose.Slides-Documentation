---
title: Конвертация из формата PPT в формат PPTX в Aspose.Slides
type: docs
weight: 10
url: /ru/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** для .NET теперь позволяет разработчикам получать доступ к PPT с помощью экземпляра класса Presentation и конвертировать его в соответствующий формат PPTX. В настоящее время он поддерживает частичную конвертацию из PPT в PPTX. Для получения дополнительной информации о поддерживаемых и неподдерживаемых функциях при конвертации PPT в PPTX, пожалуйста, переходите по этой ссылке документации.

**Aspose.Slides** для .NET предлагает класс Presentation, который представляет файл презентации PPTX. Класс Presentation теперь также может получать доступ к PPT через Presentation, когда объект инициализирован.

``` csharp

 //Создайте объект Presentation, представляющий файл PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Сохраняем презентацию PPTX в формате PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Скачать пример кода**
- [Codeplex](http://goo.gl/LklO0x)
- [Github](https://github.com/asposemarketplace/Aspose_for_OpenXML/releases/download/6/Conversion.PPT.to.PPTX.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)