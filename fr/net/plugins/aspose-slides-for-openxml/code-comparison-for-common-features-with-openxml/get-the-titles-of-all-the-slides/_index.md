---
title: Obtenez les titres de toutes les diapositives
type: docs
weight: 120
url: /net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Fichiers Exemples\";

string FileName = FilePath + "Obtenez les titres de toutes les diapositives.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Obtenez une liste des titres de toutes les diapositives dans la présentation.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Obtenez une liste des titres de toutes les diapositives dans la présentation.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Obtenez un objet PresentationPart à partir de l'objet PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Obtenez un objet Presentation à partir de l'objet PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Obtenez le titre de chaque diapositive dans l'ordre des diapositives.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Obtenez le titre de la diapositive.

                string title = GetSlideTitle(slidePart);

                // Un titre vide peut également être ajouté.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Obtenez la chaîne de titre de la diapositive.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Déclarez un séparateur de paragraphes.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Trouvez toutes les formes de titre.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Obtenez le texte dans chaque paragraphe de cette forme.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Ajoutez un saut de ligne.

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

 string FilePath = @"..\..\..\..\Fichiers Exemples\";

string FileName = FilePath + "Obtenez tout le texte dans une diapositive.pptx";

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

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passez la présentation à la méthode CountSlides suivante

        // et renvoyez le nombre de diapositives.

        return CountSlides(presentationDocument);

    }

}

// Comptez les diapositives dans la présentation.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Vérifiez qu'il n'y a pas d'objet document nul.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Obtenez la partie de présentation du document.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtenez le nombre de diapositives à partir des SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Retournez le nombre de diapositives à la méthode précédente.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Obtenez l'ID de relation de la première diapositive.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Obtenez la partie diapositive à partir de l'ID de relation.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Construisez un objet StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Obtenez le texte intérieur de la diapositive :

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
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtenez%20les%20titres%20de%20toutes%20les%20diapositives%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtenez%20les%20titres%20de%20toutes%20les%20diapositives%20\(Aspose.Slides\).zip)