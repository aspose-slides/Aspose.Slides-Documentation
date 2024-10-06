---
title: Supprimer une diapositive
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Supprimer une diapositive.pptx";

DeleteSlide(FileName, 1);

// Obtenez l'objet de présentation et passez-le à la méthode DeleteSlide suivante.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Ouvrez le document source en lecture/écriture.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passez le document source et l'index de la diapositive à supprimer à la prochaine méthode DeleteSlide.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Supprime la diapositive spécifiée de la présentation.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Utilisez l'exemple CountSlides pour obtenir le nombre de diapositives dans la présentation.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtenez la partie de présentation du document de présentation. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenez la présentation à partir de la partie de présentation.

    Presentation presentation = presentationPart.Presentation;

    // Obtenez la liste des ID de diapositive dans la présentation.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Obtenez l'ID de diapositive de la diapositive spécifiée

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Obtenez l'ID de relation de la diapositive.

    string slideRelId = slideId.RelationshipId;

    // Supprimez la diapositive de la liste des diapositives.

    slideIdList.RemoveChild(slideId);

    //

    // Supprimez les références à la diapositive de tous les diaporamas personnalisés.

    if (presentation.CustomShowList != null)

    {

        // Itérez à travers la liste des diaporamas personnalisés.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Déclarez une liste chaînée d'entrées de liste de diapositives.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Trouvez la référence de diapositive à supprimer du diaporama personnalisé.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Supprimez toutes les références à la diapositive du diaporama personnalisé.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Enregistrez la présentation modifiée.

    presentation.Save();

    // Obtenez la partie de diapositive pour la diapositive spécifiée.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Supprimez la partie de diapositive.

    presentationPart.DeletePart(slidePart);

}

// Obtenez l'objet de présentation et passez-le à la méthode CountSlides suivante.

public static int CountSlides(string presentationFile)

{

    // Ouvrez la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passez la présentation à la prochaine méthode CountSlide

        // et renvoyez le compte des diapositives.

        return CountSlides(presentationDocument);

    }

}

// Comptez les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifiez s'il s'agit d'un objet document nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenez la partie présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenez le nombre de diapositives à partir des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retournez le nombre de diapositives à la méthode précédente.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Supprimer une diapositive.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Instancier un objet PresentationEx qui représente un fichier PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Accéder à une diapositive en utilisant son index dans la collection de diapositives

        ISlide slide = pres.Slides[slideIndex];


        //Supprimer une diapositive en utilisant sa référence

        pres.Slides.Remove(slide);


        //Écrire la présentation en tant que fichier PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Télécharger le code source**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Supprimer%20une%20diapositive%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Supprimer%20une%20diapositive%20\(Aspose.Slides\).zip)