---
title: Appliquer un thème à une présentation
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML Présentation:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Appliquer Thème à la Présentation.pptx";

string ThemeFileName = FilePath + "Thème.pptx";

AppliquerThèmeÀLaPrésentation(FileName, ThemeFileName);

// Appliquer un nouveau thème à la présentation. 

public static void AppliquerThèmeÀLaPrésentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        AppliquerThèmeÀLaPrésentation(presentationDocument, themeDocument);

    }

}

// Appliquer un nouveau thème à la présentation. 

public static void AppliquerThèmeÀLaPrésentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Obtenir la partie de présentation du document de présentation.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenir la partie du maître de diapositive existante.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Obtenir la nouvelle partie du maître de diapositive.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Supprimer la partie du thème existante.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Supprimer l'ancienne partie du maître de diapositive.

    presentationPart.DeletePart(slideMasterPart);

    // Importer la nouvelle partie du maître de diapositive et réutiliser l'ancien ID de relation.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Changer pour la nouvelle partie du thème.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Insérer le code pour le layout de cet exemple.

    string defaultLayoutType = "Titre et Contenu";

    // Supprimer la relation de mise en page sur toutes les diapositives. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Déterminer le type de mise en page de diapositive pour chaque diapositive.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Supprimer l'ancienne partie de mise en page.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Appliquer la nouvelle partie de mise en page.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Appliquer la nouvelle partie de mise en page par défaut.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Obtenir le type de mise en page de la diapositive.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Remarques : Si cela est utilisé dans le code de production, vérifiez pour une référence nulle.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Pour appliquer un thème, nous devons cloner la diapositive avec le maître, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation contenant la présentation source à partir de laquelle la diapositive sera clonée.
- Créer une instance de la classe Presentation contenant la présentation de destination vers laquelle la diapositive sera clonée.
- Accéder à la diapositive à cloner ainsi qu'à la diapositive maître.
- Instancier la classe IMasterSlideCollection en faisant référence à la collection Masters exposée par l'objet Presentation de la présentation de destination.
- Appeler la méthode AddClone exposée par l'objet IMasterSlideCollection et passer le maître de la source PPTX à cloner comme paramètre à la méthode AddClone.
- Instancier la classe ISlideCollection en définissant la référence à la collection Slides exposée par l'objet Presentation de la présentation de destination.
- Appeler la méthode AddClone exposée par l'objet ISlideCollection et passer la diapositive de la présentation source à cloner et la diapositive maître comme paramètres à la méthode AddClone.
- Écrire le fichier de présentation de destination modifié.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Appliquer Thème à la Présentation.pptx";

string ThemeFileName = FilePath + "Thème.pptx";

AppliquerThèmeÀLaPrésentation(ThemeFileName, FileName);

public static void AppliquerThèmeÀLaPrésentation(string presentationFile, string outputFile)

{

    //Instancier la classe Presentation pour charger le fichier de présentation source

    Presentation srcPres = new Presentation(presentationFile);

    //Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)

    Presentation destPres = new Presentation(outputFile);

    //Instancier ISlide à partir de la collection de diapositives dans la présentation source ainsi que

    //la diapositive maître

    ISlide SourceSlide = srcPres.Slides[0];

    //Cloner la diapositive maître souhaitée de la présentation source à la collection de maîtres dans la

    //présentation de destination

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Cloner la diapositive maître souhaitée de la présentation source à la collection de maîtres dans la

    //présentation de destination

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la

    //collection de diapositives dans la présentation de destination

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Cloner la diapositive maître souhaitée de la présentation source à la collection de maîtres dans la //présentation de destination

    //Sauvegarder la présentation de destination sur disque

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Télécharger l'exemple de code en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)