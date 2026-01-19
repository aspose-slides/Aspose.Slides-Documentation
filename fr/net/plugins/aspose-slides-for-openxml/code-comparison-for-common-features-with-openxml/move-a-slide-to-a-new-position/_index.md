---
title: Déplacer une diapositive vers une nouvelle position
type: docs
weight: 140
url: /fr/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Comptage des diapositives dans la présentation.

public static int CountSlides(string presentationFile)

{

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Transmettre la présentation à la méthode CountSlides suivante

        // et renvoyer le nombre de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Compter les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifier qu'un objet document n'est pas nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenir la partie présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenir le nombre de diapositives à partir des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourner le nombre de diapositives à la méthode précédente.

    return slidesCount;

}

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives de la présentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives de la présentation.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Appeler la méthode CountSlides pour obtenir le nombre de diapositives dans la présentation.

    int slidesCount = CountSlides(presentationDocument);

    // Vérifier que les deux positions from et to sont dans les limites et différentes l'une de l'autre.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Obtenir la partie présentation du document de présentation.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Le nombre de diapositives n'est pas zéro, donc la présentation doit contenir des diapositives.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtenir l'ID de la diapositive source.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Identifier la position de la diapositive cible après laquelle déplacer la diapositive source.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Supprimer la diapositive source de sa position actuelle.

    sourceSlide.Remove();

    // Insérer la diapositive source à sa nouvelle position après la diapositive cible.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Enregistrer la présentation modifiée.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives de la présentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instancier la classe PresentationEx pour charger le fichier PPTX source

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Obtenir la diapositive dont la position doit être modifiée

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        //Définir la nouvelle position pour la diapositive

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        //Écrire le PPTX sur le disque

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)