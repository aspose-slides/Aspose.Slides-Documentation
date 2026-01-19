---
title: Conversion du format PPT vers PPTX
type: docs
weight: 20
url: /fr/net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides est une fonctionnalité unique qui offre de la flexibilité dans les conversions de versions sans affecter le travail.
SaveFormat est une énumération qui peut convertir le document dans les extensions indiquées ci-dessous dans le tableau.

|**Nom du membre**|**Valeur**|**Description**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
Voici un extrait de code qui montre la conversion de PPT vers PPTX ; vous pouvez également faire l’inverse.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instantiate a Presentation object that represents a PPTX file

Presentation pres = new Presentation(srcFileName);

//Saving the PPTX presentation to PPTX format

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)