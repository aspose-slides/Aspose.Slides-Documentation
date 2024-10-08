---
title: Travailler avec la Taille et la Mise en Page de la Présentation
type: docs
weight: 90
url: /fr/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** et **SlideSize.Size** sont les propriétés de la classe présentation qui peuvent être définies ou récupérées comme montré ci-dessous dans l'exemple.
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instancier un objet Presentation qui représente un fichier de présentation 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Définir la taille de la diapositive des présentations générées à celle de la source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Sauvegarder la présentation sur le disque

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Télécharger l'Exemple Exécutable**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Travailler Avec la Taille et la Mise en Page de la Diapositive](/slides/fr/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}