---
title: Obtenir les titres de toutes les diapositives
type: docs
weight: 120
url: /fr/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir les titres de toutes les diapositives.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Obtient une liste des titres de toutes les diapositives de la présentation.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Ouvre la présentation en lecture seule.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Obtient une liste des titres de toutes les diapositives de la présentation.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Obtient un objet PresentationPart à partir de l'objet PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Obtient un objet Presentation à partir de l'objet PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Obtient le titre de chaque diapositive dans l'ordre des diapositives.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Obtient le titre de la diapositive.

                string title = GetSlideTitle(slidePart);

                // Un titre vide peut également être ajouté.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Obtient la chaîne de titre de la diapositive.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Déclare un séparateur de paragraphe.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Recherche toutes les formes de titre.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Obtient le texte de chaque paragraphe dans cette forme.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Ajoute un saut de ligne.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Détermine si la forme est une forme de titre.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Toute forme de titre.

            case PlaceholderValues.Title:

            // Un titre centré.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir tout le texte d'une diapositive.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Nombre de diapositives = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Diapositive #{0} contient : {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Ouvre la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passe la présentation à la méthode CountSlides suivante

        // et renvoie le nombre de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Compte le nombre de diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifie si l'objet document est nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtient la partie présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtient le nombre de diapositives à partir des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Renvoie le nombre de diapositives à la méthode précédente.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obtient l'ID de relation de la première diapositive.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obtient la partie diapositive à partir de l'ID de relation.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Crée un objet StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obtient le texte interne de la diapositive :

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)