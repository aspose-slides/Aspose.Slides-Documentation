---
title: Gérer le zoom de la présentation dans .NET
linktitle: Gérer le zoom
type: docs
weight: 60
url: /fr/net/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom récapitulatif
- ajouter un zoom
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser le zoom avec Aspose.Slides pour .NET — naviguer entre les sections, ajouter des miniatures et des transitions dans les présentations PPT, PPTX et ODP."
---

## **Vue d'ensemble**
Les zooms dans PowerPoint vous permettent de naviguer vers et depuis des diapositives, sections et parties spécifiques d’une présentation. Lors d’une présentation, cette capacité à naviguer rapidement dans le contenu peut s’avérer très utile. 

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Zoom récapitulatif](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Zoom de diapositive](#Slide-Zoom).
* Pour afficher une seule section, utilisez un [Zoom de section](#Section-Zoom).

## **Zoom de diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont idéaux pour les présentations courtes sans trop de sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à approfondir plusieurs éléments d’information tout en restant sur une seule « toile ». 

![overview_image](slidezoomsel.png)

Pour les objets zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), l’interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Créer des cadres de zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives que vous souhaitez lier aux cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive :
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute de nouvelles diapositives à la présentation
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

    //Ajoute des objets ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides pour .NET, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette façon : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom avec une image différente :
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

### **Formater les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier le formatage d’un cadre simple. Plusieurs options de formatage peuvent être appliquées à un cadre de zoom. 

Vous pouvez contrôler le formatage d’un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives à lier auxquelles vous souhaitez associer le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
8. Supprimez l’arrière‑plan d’une image du deuxième objet cadre de zoom.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment modifier le formatage d’un cadre de zoom sur une diapositive : 
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute de nouvelles diapositives à la présentation
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

    //Ajoute des objets ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Définit une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Définit un format de cadre de zoom pour l'objet zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Paramètre pour ne pas afficher l'arrière-plan pour l'objet zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour illustrer comment certaines parties de votre présentation sont reliées entre elles. 

![overview_image](seczoomsel.png)

Pour les objets zoom de section, Aspose.Slides fournit l’interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Créer des cadres de zoom de section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive :
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle Section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Enregistre la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Créer des cadres de zoom de section avec des images personnalisées**

Avec Aspose.Slides pour .NET, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom avec une image différente :
``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle Section à la présentation
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

### **Formater les cadres de zoom de section**

Pour créer des cadres de zoom de section plus complexes, vous devez modifier le formatage d’un cadre simple. Plusieurs options de formatage peuvent être appliquées à un cadre de zoom de section. 

Vous pouvez contrôler le formatage d’un cadre de zoom de section sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet cadre de zoom de section créé.
9. Activez la fonction *retour à la diapositive d’origine depuis la section liée*. 
10. Supprimez l’arrière‑plan d’une image de l’objet cadre de zoom de section.
11. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment modifier le formatage d’un cadre de zoom de section :
``` csharp 
using (Presentation pres = new Presentation())
{
    // Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Ajoute une nouvelle section à la présentation
    pres.Sections.AddSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Mise en forme pour SectionZoomFrame
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



## **Zoom récapitulatif**

Un zoom récapitulatif fonctionne comme une page d’accueil où toutes les parties de votre présentation sont affichées en même temps. Lors d’une présentation, vous pouvez utiliser le zoom pour passer d’un endroit à un autre dans votre présentation, dans l’ordre de votre choix. Vous pouvez être créatif, sauter en avant ou revenir sur des parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets zoom récapitulatif, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) ainsi que certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Créer un zoom récapitulatif**

Vous pouvez ajouter un cadre de zoom récapitulatif à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom récapitulatif à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom récapitulatif sur une diapositive :
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


### **Ajouter et supprimer une section de zoom récapitulatif**

Toutes les sections d’un cadre de zoom récapitulatif sont représentées par des objets [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), qui sont stockés dans l’objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Vous pouvez ajouter ou supprimer une section de zoom récapitulatif via l’interface [ISummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom récapitulatif à la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom récapitulatif.
6. Supprimez la première section du cadre de zoom récapitulatif.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment ajouter et supprimer des sections dans un cadre de zoom récapitulatif :
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


### **Formater les sections de zoom récapitulatif**

Pour créer des objets section de zoom récapitulatif plus complexes, vous devez modifier le formatage d’un cadre simple. Plusieurs options de formatage peuvent être appliquées à un objet section de zoom récapitulatif. 

Vous pouvez contrôler le formatage d’un objet section de zoom récapitulatif dans un cadre de zoom récapitulatif de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom récapitulatif à la première diapositive.
4. Récupérez un objet section de zoom récapitulatif pour le premier objet depuis la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet cadre de section de zoom créé.
9. Activez la fonction *retour à la diapositive d’origine depuis la section liée*. 
11. Modifiez le format de ligne pour le deuxième objet cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment modifier le formatage d’un objet section de zoom récapitulatif :
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

    // Récupère le premier objet SummaryZoomSection
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

**Puis‑je contrôler le retour à la diapositive « parent » après l’affichage de la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) ou le [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) possède un comportement `ReturnToParent` qui, lorsqu’il est activé, renvoie les spectateurs à la diapositive d’origine après qu’ils aient consulté le contenu cible.

**Puis‑je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le Zoom prend en charge la définition d’une `TransitionDuration` afin que vous puissiez contrôler la durée de l’animation de saut.

**Existe‑t‑il des limites au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’existe aucune limite API stricte documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.