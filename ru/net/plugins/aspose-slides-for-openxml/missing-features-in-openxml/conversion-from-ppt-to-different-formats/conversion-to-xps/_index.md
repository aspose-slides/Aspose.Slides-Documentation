---
title: Преобразование в XPS
type: docs
weight: 40
url: /ru/net/conversion-to-xps/
---

**XPS** формат также широко используется для обмена данными. Aspose.Slides for .NET учитывает его важность и предоставляет встроенную поддержку преобразования презентации в документ XPS.

Метод **Save**, доступный в классе Presentation, можно использовать для преобразования всей презентации в документ **XPS**. Кроме того, класс **XpsOptions** раскрывает свойство **SaveMetafileAsPng**, которое можно установить в true или false в соответствии с требованием.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Загрузить пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)