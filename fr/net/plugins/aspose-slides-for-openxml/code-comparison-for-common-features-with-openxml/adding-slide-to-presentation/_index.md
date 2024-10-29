---
title: Ajouter une diapositive à la présentation
type: docs
weight: 20
url: /fr/net/adding-slide-to-presentation/
---

## **Présentation OpenXML**
Dans la fonctionnalité ci-dessous, par défaut, une diapositive est ajoutée à la présentation. Ici, nous ajoutons une nouvelle diapositive à l'index 2 en y insérant du texte.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "Ma nouvelle diapositive");

// Insérer une diapositive dans la présentation spécifiée.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Ouvrir le document source en lecture/écriture. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Passer le document source, la position et le titre de la diapositive à insérer à la méthode suivante.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Insérer la diapositive spécifiée dans la présentation à la position spécifiée.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Vérifier que la présentation n'est pas vide.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("Le document de la présentation est vide.");

    }

    // Déclarer et instancier une nouvelle diapositive.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Construire le contenu de la diapositive.            

    // Spécifier les propriétés non visuelles de la nouvelle diapositive.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Spécifier les propriétés du groupe de formes de la nouvelle diapositive.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Déclarer et instancier la forme titre de la nouvelle diapositive.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Spécifier les propriétés de forme requises pour la forme titre. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Titre" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Spécifier le texte de la forme titre.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Déclarer et instancier la forme corps de la nouvelle diapositive.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Spécifier les propriétés de forme requises pour la forme corps.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Espace réservé pour le contenu" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Spécifier le texte de la forme corps.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Créer la partie diapositive pour la nouvelle diapositive.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Sauver la nouvelle partie diapositive.

    slide.Save(slidePart);

    // Modifier la liste des IDs de diapositives dans la partie de présentation.

    // La liste des IDs de diapositives ne doit pas être nulle.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Trouver le plus grand ID de diapositive dans la liste actuelle.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Obtenir l'ID de la diapositive précédente.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Utiliser la même mise en page que celle de la diapositive précédente.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Insérer la nouvelle diapositive dans la liste des diapositives après la diapositive précédente.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Sauver la présentation modifiée.

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
Chaque fichier de présentation PowerPoint contient une **diapositive principale master** et d'autres **diapositives normales**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour .NET. Chaque diapositive a une position spécifique et un **ID unique**. L'**ID de diapositive** peut varier de 0 à 255 pour les diapositives master et de 256 à 65535 pour les diapositives normales.

Aspose.Slides pour .NET permet aux développeurs d'ajouter des diapositives vides aux présentations en utilisant la méthode **AddEmptySlide** exposée par l'objet **Presentation**. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Appeler la méthode AddEmptySlide exposée par l'objet Presentation
- Effectuer des travaux avec la nouvelle diapositive vide ajoutée
- Ajouter une autre diapositive et y insérer du texte.
- Enfin, écrire le fichier PPT à l'aide de la méthode Write exposée par l'objet Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

// Instancier la classe PresentationEx qui représente le fichier PPT

Presentation pres = new Presentation();

// Une diapositive blanche est ajoutée par défaut, lorsque vous créez

// une présentation à partir du constructeur par défaut

// Ajouter une diapositive vide à la présentation et obtenir la référence de

// cette diapositive vide

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

// Écrire la sortie sur le disque

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Télécharger le code source**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)