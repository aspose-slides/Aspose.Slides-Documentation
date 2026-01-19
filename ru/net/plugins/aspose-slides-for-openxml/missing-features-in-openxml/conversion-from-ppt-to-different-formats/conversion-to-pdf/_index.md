---
title: Конвертация в PDF
type: docs
weight: 30
url: /ru/net/conversion-to-pdf/
---

PDF‑документы широко используются как стандартный формат обмена документами между организациями, государственными структурами и отдельными лицами. Это популярный формат, поэтому разработчиков часто просят конвертировать файлы презентаций Microsoft PowerPoint в PDF‑документы. Понимая эту возможную потребность, Aspose.Slides for .NET поддерживает преобразование презентаций в PDF‑документы без использования каких‑либо других компонентов.

**Aspose.Slides for .NET** предоставляет класс Presentation, который представляет файл презентации. Класс **Presentation** открывает метод Save, который можно вызвать для преобразования всей презентации в документ **PDF**. Класс **PdfOptions** предоставляет параметры для создания **PDF**, такие как JpegQuality, TextCompression, Compliance и другие. Эти параметры можно использовать для получения нужного стандарта PDF.

``` csharp
 string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Conversion.pptx";
string destFileName = FilePath + "Converting to PDF.pdf";
//Создаёт объект Presentation, представляющий файл презентации
Presentation pres = new Presentation(srcFileName);
//Сохранить презентацию в PDF с параметрами по умолчанию
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);
``` 

## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)