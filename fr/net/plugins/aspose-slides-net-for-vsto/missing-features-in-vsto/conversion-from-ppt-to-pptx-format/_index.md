---
title: Conversion du format PPT en format PPTX
type: docs
weight: 20
url: /fr/net/conversion-from-ppt-to-pptx-format/
---

La fonctionnalité unique d'Aspose.Slides qui offre une flexibilité dans les conversions de version sans affecter le travail.
SaveFormat est une énumération qui peut convertir un document dans les extensions données ci-dessous dans le tableau.

|**Nom du membre**|**Valeur**|**Description**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
Voici un extrait de code qui montre la conversion de PPT en PPTX, vous pouvez également le faire dans l'autre sens.

``` csharp

 string FilePath = @"..\..\..\Fichiers d'exemple\";

string srcFileName = FilePath + "Conversion PPT en PPTX.ppt";

string destFileName = FilePath + "Conversion PPT en PPTX.pptx";

//Instancier un objet Présentation qui représente un fichier PPTX

Presentation pres = new Presentation(srcFileName);

//Enregistrer la présentation PPTX au format PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)