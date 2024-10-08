---
title: Obtenir tout le texte dans toutes les diapositives
type: docs
weight: 100
url: /fr/net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir tout le texte dans une diapositive.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Nombre de diapositives = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Diapositive #{0} contient: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passer la présentation à la prochaine méthode CountSlides

        // et retourner le nombre de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Compte les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifier si l'objet document est nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenir la partie présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenir le nombre de diapositives des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retourner le nombre de diapositives à la méthode précédente.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obtenir l'ID de relation de la première diapositive.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obtenir la partie diapositive à partir de l'ID de relation.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Construire un objet StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obtenir le texte intérieur de la diapositive :

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir tout le texte dans une diapositive.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Nombre de diapositives = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Diapositive #{0} contient: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Instancier la classe PresentationEx qui représente PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    // Instancier la classe PresentationEx qui représente PPTX

    using (Presentation pres = new Presentation(docName))

    {

        // Accéder à la diapositive

        ISlide sld = pres.Slides[index];

        // Itérer à travers les formes pour trouver le placeholder

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                // obtenir le texte de chaque placeholder

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtenir%20tout%20le%20texte%20dans%20toutes%20les%20diapositives%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtenir%20tout%20le%20texte%20dans%20toutes%20les%20diapositives%20\(Aspose.Slides\).zip)