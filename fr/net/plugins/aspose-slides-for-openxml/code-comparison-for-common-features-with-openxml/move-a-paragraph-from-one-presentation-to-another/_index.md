---
title: Déplacer un paragraphe d'une présentation à une autre
type: docs
weight: 130
url: /net/move-a-paragraph-from-one-presentation-to-another/
---

## **Présentation OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Déplacer un Paragraphe d'une Présentation à une Autre 1.pptx";

string DestFileName = FilePath + "Déplacer un Paragraphe d'une Présentation à une Autre 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Déplace une plage de paragraphe dans une forme TextBody dans le document source

// vers une autre forme TextBody dans le document cible.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Ouvre le fichier source en lecture/écriture.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Ouvre le fichier cible en lecture/écriture.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Obtient la première diapositive dans la présentation source.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Obtient la première forme TextBody dans celle-ci.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Obtient le premier paragraphe dans la forme TextBody.

        // Remarque : "Drawing" est l'alias de l'espace de noms DocumentFormat.OpenXml.Drawing

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Obtient la première diapositive dans la présentation cible.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Obtient la première forme TextBody dans celle-ci.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Clone le paragraphe source et insère le paragraphe cloné dans la forme TextBody cible.

        // Passer "true" crée un clone profond, ce qui crée une copie de l'

        // objet Paragraph et tout ce qui est référencé directement ou indirectement par cet objet.

        textBody2.Append(p1.CloneNode(true));

        // Supprime le paragraphe source du fichier source.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Remplace le paragraphe supprimé par un espace réservé.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Enregistre la diapositive dans le fichier source.

        slide1.Slide.Save();

        // Enregistre la diapositive dans le fichier cible.

        slide2.Slide.Save();

    }

}

}

// Obtient la partie diapositive de la première diapositive dans le document de présentation.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtient l'ID de relation de la première diapositive

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtient la partie diapositive par l'ID de relation.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire du texte à partir de présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. Que ce soit pour extraire du texte d'une seule diapositive ou d'une présentation entière, Aspose.Slides utilise la classe PresentationScanner et les méthodes statiques qu'elle expose. Elles sont toutes regroupées sous l'espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Déplacer un Paragraphe d'une Présentation à une Autre 1.pptx";

string DestFileName = FilePath + "Déplacer un Paragraphe d'une Présentation à une Autre 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Déplace une plage de paragraphe dans une forme TextBody dans le document source

// vers une autre forme TextBody dans le document cible.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instancier la classe Presentation qui représente le PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Accéder à la première forme dans la première diapositive

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Obtenir le texte de l'espace réservé

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Accéder à la première forme dans la première diapositive

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Obtenir le texte de l'espace réservé

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **Télécharger l'Exemple de Code Fonctionnant**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exemple de Code**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Déplacer un Paragraphe/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Déplacer%20un%20Paragraphe)