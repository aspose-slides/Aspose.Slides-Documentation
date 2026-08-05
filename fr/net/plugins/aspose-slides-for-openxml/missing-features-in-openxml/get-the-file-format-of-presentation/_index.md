---
title: Obtenir le format du fichier de la présentation
type: docs
weight: 50
url: /fr/net/get-the-file-format-of-presentation/
aliases:
  - /net/format-de-presentation/
---
Pour obtenir le format du fichier, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe **IPresentationInfo**
- Obtenez des informations sur la présentation

Dans l'exemple ci-dessous, nous obtenons le format du fichier.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Télécharger l'exemple en cours d'exécution**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)