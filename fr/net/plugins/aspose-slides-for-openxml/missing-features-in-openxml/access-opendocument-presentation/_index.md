---
title: Accéder à la Présentation OpenDocument
type: docs
weight: 10
url: /fr/net/access-opendocument-presentation/
---

Aspose.Slides pour .NET offre la classe **Presentation** qui représente un fichier de présentation. La classe **Presentation** peut maintenant également accéder à **ODP** via le constructeur **Presentation** lors de l'instanciation de l'objet.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Fichiers Exemples\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instancier un objet Presentation qui représente un fichier de présentation

using (Presentation pres = new Presentation(srcFileName))

{

    //Sauvegarder la présentation PPTX au format PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Télécharger le Code d'Exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Télécharger l'Exemple Exécutable**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)