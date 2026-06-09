---
title: OpenDocument Sunumuna Erişim
type: docs
weight: 10
url: /tr/net/access-opendocument-presentation/
---
Aspose.Slides for .NET, bir sunum dosyasını temsil eden **Presentation** sınıfını sunar. **Presentation** sınıfı, nesne oluşturulduğunda **Presentation** yapıcı aracılığıyla **ODP**'ye de erişebilir.
## **Örnek**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Sunum dosyasını temsil eden bir Presentation nesnesi oluştur

using (Presentation pres = new Presentation(srcFileName))

{

    //PPTX sunumunu PPTX formatına kaydediyor

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örnek İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)