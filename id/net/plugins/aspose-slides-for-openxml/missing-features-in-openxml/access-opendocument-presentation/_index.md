---
title: Akses Presentasi OpenDocument
type: docs
weight: 10
url: /id/net/access-opendocument-presentation/
---
Aspose.Slides for .NET menyediakan kelas **Presentation** yang mewakili file presentasi. **Presentation** kelas kini juga dapat mengakses **ODP** melalui konstruktor **Presentation** saat objek diinstansiasi.
## **Contoh**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instansiasi objek Presentation yang mewakili file presentasi

using (Presentation pres = new Presentation(srcFileName))

{

    //Menyimpan presentasi PPTX ke format PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Unduh Contoh yang Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)