---
title: Obtenir le format de fichier de la présentation
type: docs
weight: 50
url: /net/get-the-file-format-of-presentation/
---

Pour obtenir le format de fichier. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe **IPresentationInfo**
- Obtenez des informations sur la présentation

Dans l'exemple donné ci-dessous, nous avons obtenu le format de fichier.
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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Télécharger l'exemple en fonctionnement**
- [Codeplex](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)