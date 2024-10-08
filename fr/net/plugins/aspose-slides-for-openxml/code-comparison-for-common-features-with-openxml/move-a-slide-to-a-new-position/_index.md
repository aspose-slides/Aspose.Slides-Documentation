---
title: Déplacer une diapositive vers une nouvelle position
type: docs
weight: 140
url: /fr/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Déplacer une diapositive vers une nouvelle position.pptx";

MoveSlide(FileName, 1, 2);

// Compter les diapositives dans la présentation.

public static int CountSlides(string presentationFile)

{

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passer la présentation à la prochaine méthode CountSlides

        // et retourner le compte de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Compter les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifier si l'objet document est nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenir la partie de présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenir le nombre de diapositives des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourner le compte de diapositives à la méthode précédente.

    return slidesCount;

}

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives dans la présentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives dans la présentation.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Appeler la méthode CountSlides pour obtenir le nombre de diapositives dans la présentation.

    int slidesCount = CountSlides(presentationDocument);

    // Vérifier que les positions from et to sont dans les limites et différentes l'une de l'autre.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Obtenir la partie de présentation du document de présentation.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Le compte de diapositives n'est pas nul, donc la présentation doit contenir des diapositives.            

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

    // Enlever la diapositive source de sa position actuelle.

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

string FileName = FilePath + "Déplacer une diapositive vers une nouvelle position.pptx";

MoveSlide(FileName, 1, 2);

// Déplacer une diapositive vers une position différente dans l'ordre des diapositives dans la présentation.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Instancier la classe PresentationEx pour charger le fichier PPTX source

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Obtenir la diapositive dont la position doit être changée

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
## **Télécharger le Code Exemple**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Déplacer%20une%20diapositive%20vers%20une%20nouvelle%20position%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Déplacer%20une%20diapositive%20vers%20une%20nouvelle%20position%20\(Aspose.Slides\).zip)
