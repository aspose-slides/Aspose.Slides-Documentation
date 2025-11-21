---
title: Gérer le zoom de présentation dans .NET
linktitle: Gérer le zoom
type: docs
weight: 60
url: /fr/net/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de résumé
- ajouter un zoom
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser le zoom avec Aspose.Slides pour .NET - passer d'une section à l'autre, ajouter des miniatures et des transitions dans les présentations PPT, PPTX et ODP."
---

## **Vue d'ensemble**
Les zooms dans PowerPoint vous permettent de passer d'une diapositive, d'une section ou d'une partie spécifique d'une présentation à une autre. Lors de la présentation, cette capacité à naviguer rapidement à travers le contenu peut s'avérer très utile. 

![overview_image](overview.png)

* Pour résumer toute une présentation sur une seule diapositive, utilisez un [Summary Zoom](#Summary-Zoom).
* Pour afficher uniquement les diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour afficher une seule section, utilisez un [Section Zoom](#Section-Zoom).

## **Zoom de diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n'importe quel ordre choisi sans interrompre le déroulement de la présentation. Les zooms de diapositive sont idéaux pour des présentations courtes sans nombreuses sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à explorer plusieurs informations tout en donnant l'impression d'être sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), l'interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) et certaines méthodes de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création de cadres de zoom**
Vous pouvez ajouter un cadre de zoom sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives vers lesquelles vous souhaitez lier les cadres de zoom. 
3. Ajoutez un texte d'identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive:
``` csharp
using (Presentation pres = new Presentation())
{
    //Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crée un arrière‑plan pour la deuxième diapositive
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crée un arrière‑plan pour la troisième diapositive
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Ajoute des objets ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Création de cadres de zoom avec images personnalisées**
Avec Aspose.Slides for .NET, vous pouvez créer un cadre de zoom avec une image de prévisualisation de diapositive différente de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive vers laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière‑plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom avec une image différente:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crée un arrière-plan pour la deuxième diapositive
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crée une zone de texte pour la troisième diapositive
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Ajoute l'objet ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Mise en forme des cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier la mise en forme d'un cadre simple. Il existe plusieurs options de mise en forme que vous pouvez appliquer à un cadre de zoom.

Vous pouvez contrôler la mise en forme d'un cadre de zoom sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives vers lesquelles vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
8. Supprimez l'arrière‑plan d'une image du deuxième objet cadre de zoom.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment changer la mise en forme d'un cadre de zoom sur une diapositive: 
``` csharp 
using (Presentation pres = new Presentation())
{
    // Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crée un arrière-plan pour la deuxième diapositive
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Crée un arrière-plan pour la troisième diapositive
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // Ajoute des objets ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Définit une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Définit un format de cadre zoom pour l'objet zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Paramètre pour ne pas afficher l'arrière-plan de l'objet zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez réellement mettre en avant. Ou vous pouvez les utiliser pour souligner comment certaines parties de votre présentation sont reliées. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) et certaines méthodes de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création de cadres de zoom de section**
Vous pouvez ajouter un cadre de zoom de section à une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d'identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Création de cadres de zoom de section avec images personnalisées**
En utilisant Aspose.Slides for .NET, vous pouvez créer un cadre de zoom de section avec une image de prévisualisation de diapositive différente de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d'identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
6. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom avec une image différente:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Mise en forme des cadres de zoom de section**
Pour créer des cadres de zoom de section plus complexes, vous devez modifier la mise en forme d'un cadre simple. Il existe plusieurs options de mise en forme que vous pouvez appliquer à un cadre de zoom de section.

Vous pouvez contrôler la mise en forme d'un cadre de zoom de section sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d'identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l'objet de zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre de zoom de section créé.
9. Activez la fonctionnalité *retour à la diapositive d'origine depuis la section liée*.
10. Supprimez l'arrière‑plan d'une image de l'objet cadre de zoom de section.
11. Modifiez le format de ligne du deuxième objet cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment changer la mise en forme d'un cadre de zoom de section:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatage pour SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom de résumé**
Un zoom de résumé ressemble à une page d'accueil où toutes les parties de votre présentation sont affichées simultanément. Lors de la présentation, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans n'importe quel ordre. Vous pouvez faire preuve de créativité, sauter en avant ou revisiter des parties de votre diaporama sans interrompre le déroulement de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de résumé, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) ainsi que certaines méthodes de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création d'un zoom de résumé**
Vous pouvez ajouter un cadre de zoom de résumé à une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de résumé à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom de résumé sur une diapositive:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 2", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 3", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 4", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Ajout et suppression de sections de zoom de résumé**
Toutes les sections d'un cadre de zoom de résumé sont représentées par des objets [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Vous pouvez ajouter ou supprimer un objet de section de zoom de résumé via l'interface [ISummaryZoomSectionCollection] de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé dans la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de résumé.
6. Supprimez la première section du cadre de zoom de résumé.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment ajouter et supprimer des sections dans un cadre de zoom de résumé:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 2", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Ajoute une section au Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Supprime la section du Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Mise en forme des sections de zoom de résumé**
Pour créer des objets de section de zoom de résumé plus complexes, vous devez modifier la mise en forme d'un cadre simple. Il existe plusieurs options de mise en forme que vous pouvez appliquer à un objet de section de zoom de résumé.

Vous pouvez contrôler la mise en forme d'un objet de section de zoom de résumé dans un cadre de zoom de résumé de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Récupérez un objet de section de zoom de résumé pour le premier objet à partir de la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre de zoom de section créé.
9. Activez la fonctionnalité *retour à la diapositive d'origine depuis la section liée*.
11. Modifiez le format de ligne du deuxième objet cadre de zoom.
12. Modifiez la durée de transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment changer la mise en forme d'un objet de section de zoom de résumé:
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 2", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Obtient le premier objet SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Mise en forme pour l'objet SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après avoir affiché la cible ?**

Oui. Le cadre Zoom ou la section possède un comportement `ReturnToParent` qui, lorsqu'il est activé, renvoie le spectateur à la diapositive d'origine après avoir consulté le contenu cible.

**Puis-je ajuster la « vitesse » ou la durée de la transition Zoom ?**

Oui. Zoom prend en charge la définition d'une `TransitionDuration` afin que vous puissiez contrôler la durée de l'animation de saut.

**Existe-t-il des limites au nombre d'objets Zoom qu'une présentation peut contenir ?**

Il n'existe pas de limite stricte documentée dans l'API. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du lecteur. Vous pouvez ajouter de nombreux cadres Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.