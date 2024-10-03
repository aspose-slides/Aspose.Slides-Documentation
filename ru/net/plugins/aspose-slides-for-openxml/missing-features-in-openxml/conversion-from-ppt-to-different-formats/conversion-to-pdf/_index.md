---
title: Конвертация в PDF
type: docs
weight: 30
url: /ru/net/conversion-to-pdf/
---

PDF-документы широко используются как стандартный формат обмена документами между организациями, государственными учреждениями и частными лицами. Это популярный формат, поэтому разработчиков часто просят конвертировать файлы презентаций Microsoft PowerPoint в PDF-документы. Осознавая эту возможную необходимость, Aspose.Slides для .NET поддерживает конвертацию презентаций в PDF-документы без использования каких-либо других компонентов.

**Aspose.Slides для .NET** предлагает класс Presentation, который представляет файл презентации. Класс **Presentation** предоставляет метод Save, который можно вызвать для конвертации всей презентации в **PDF**-документ. Класс **PdfOptions** предоставляет параметры для создания **PDF**, такие как JpegQuality, TextCompression, Compliance и другие. Эти параметры можно использовать для получения желаемого стандарта PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Создаем объект Presentation, представляющий файл презентации

Presentation pres = new Presentation(srcFileName);

//Сохраняем презентацию в PDF с настройками по умолчанию

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)