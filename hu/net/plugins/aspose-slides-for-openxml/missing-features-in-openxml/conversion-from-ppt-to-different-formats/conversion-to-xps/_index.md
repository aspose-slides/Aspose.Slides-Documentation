---
title: Átalakítás XPS formátumba
type: docs
weight: 40
url: /hu/net/conversion-to-xps/
---
**XPS** formátum szintén széles körben használt az adatok cseréjére. Az Aspose.Slides for .NET gondoskodik fontosságáról, és beépített támogatást nyújt a bemutató XPS dokumentummá konvertálásához.

A **Save** metódus, amely a Presentation osztályban érhető el, használható a teljes bemutató **XPS** dokumentummá konvertálására. Továbbá a **XpsOptions** osztály **SaveMetafileAsPng** tulajdonsága true vagy false értékre állítható igény szerint.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel

Presentation pres = new Presentation(srcFileName);

//A bemutató mentése TIFF dokumentumba

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)