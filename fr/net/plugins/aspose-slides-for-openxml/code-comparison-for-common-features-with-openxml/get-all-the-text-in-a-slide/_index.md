---
title: Obtenir tout le texte dans une diapositive
type: docs
weight: 110
url: /net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir tout le texte dans une diapositive.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Obtenir tout le texte dans une diapositive.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Ouvrir la présentation en lecture seule.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Passer la présentation et l'index de la diapositive

        // à la prochaine méthode GetAllTextInSlide, et

        // puis retourner le tableau de chaînes qu'elle renvoie. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Vérifier que le document de présentation existe.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Vérifier que l'index de la diapositive est dans les limites.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Obtenir la partie de présentation du document de présentation.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Vérifier que la partie de présentation et la présentation existent.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Obtenir l'objet Presentation à partir de la partie de présentation.

        Presentation presentation = presentationPart.Presentation;

        // Vérifier que la liste des ID de diapositive existe.

        if (presentation.SlideIdList != null)

        {

            // Obtenir la collection des ID de diapositive à partir de la liste des ID de diapositive.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Si l'ID de diapositive est dans les limites...

            if (slideIndex < slideIds.Count)

            {

                // Obtenir l'ID de relation de la diapositive.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Obtenir la partie de diapositive spécifiée à partir de l'ID de relation.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Passer la partie de diapositive à la prochaine méthode, et

                // puis retourner le tableau de chaînes que cette méthode

                // renvoie à la méthode précédente.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Sinon, retourner null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Vérifier que la partie de diapositive existe.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Créer une nouvelle liste chaînée de chaînes.

    LinkedList<string> texts = new LinkedList<string>();

    // Si la diapositive existe...

    if (slidePart.Slide != null)

    {

        // Parcourir tous les paragraphes dans la diapositive.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Créer un nouveau constructeur de chaîne.                    

            StringBuilder paragraphText = new StringBuilder();

            // Parcourir les lignes du paragraphe.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Ajouter chaque ligne aux lignes précédentes.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Ajouter chaque paragraphe à la liste chaînée.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Retourner un tableau de chaînes.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Obtenir tout le texte dans une diapositive.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Obtenir tout le texte dans une diapositive.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Créer une nouvelle liste chaînée de chaînes.

List<string> texts = new List<string>();

// Instancier la classe PresentationEx qui représente PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    // Accéder à la diapositive

    ISlide sld = pres.Slides[slideIndex];

    // Parcourir les formes pour trouver l'espace réservé

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // obtenir le texte de chaque espace réservé

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Retourner un tableau de chaînes.

return texts;

}

``` 
## **Télécharger le code exemple**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Obtenir%20tout%20le%20texte%20dans%20une%20diapositive%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Obtenir%20tout%20le%20texte%20dans%20une%20diapositive%20\(Aspose.Slides\).zip)