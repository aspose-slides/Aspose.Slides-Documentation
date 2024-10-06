---
title: Compter le nombre de diapositives
type: docs
weight: 50
url: /net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Compter le nombre de diapositives.pptx";

Console.WriteLine("Nombre de diapositives = {0}",

CountSlides(FileName));

Console.ReadKey();

// Obtenez l'objet de présentation et passez-le au prochain méthode CountSlides.

public static int CountSlides(string presentationFile)

{

    // Ouvrir la présentation en mode lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passer la présentation à la prochaine méthode CountSlide

        // et retourner le nombre de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Compter les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifiez l'objet de document nul.

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

    // Retourner le nombre de diapositives à la méthode précédente.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Compter le nombre de diapositives.pptx";

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
## **Télécharger le Code d'Exemple**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)