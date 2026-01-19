---
title: Compter le nombre de diapositives
type: docs
weight: 50
url: /fr/net/count-the-number-of-slides/
---

## **SDK OpenXML**
```csharp
// Chemin d'accès au fichier d'exemple.
string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Nombre de diapositives = {0}",
CountSlides(FileName));

Console.ReadKey();

// Obtenir l'objet de présentation et le transmettre à la méthode CountSlides suivante.
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
    // Vérifier qu'un objet de document nul n'est pas fourni.
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }

    int slidesCount = 0;

    // Obtenir la partie de présentation du document.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenir le nombre de diapositives à partir des SlideParts.
    if (presentationPart != null)
    {
        slidesCount = presentationPart.SlideParts.Count();
    }

    // Retourner le nombre de diapositives à la méthode précédente.
    return slidesCount;
}
``` 

## **Aspose.Slides**
```csharp
string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Nombre de diapositives = {0}",
CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)
{
    // Instancier un objet PresentationEx qui représente un fichier PPTX
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }
}
``` 

## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)