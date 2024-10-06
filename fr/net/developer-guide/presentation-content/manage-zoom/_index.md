---
title: Gérer le Zoom
type: docs
weight: 60
url: /net/manage-zoom/
keywords: 
- zoom
- cadre de zoom
- ajouter un zoom
- format cadre de zoom
- résumé zoom
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Ajoutez un zoom ou des cadres de zoom aux présentations PowerPoint en C# ou .NET"
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de passer d'un diapositive, section ou portion spécifique d'une présentation à une autre. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s’avérer très utile.

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Résumé Zoom](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour afficher une seule section, utilisez un [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Un slide zoom peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n'importe quel ordre sans interrompre le flux de votre présentation. Les slide zooms sont idéaux pour les présentations courtes sans beaucoup de sections, mais vous pouvez les utiliser dans différents scénarios de présentation.

Les slide zooms vous aident à plonger dans plusieurs morceaux d'information tout en ayant l'impression d'être sur une seule toile.

![overview_image](slidezoomsel.png)

Pour les objets de slide zoom, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), l'interface [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe), et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création de Cadres de Zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom. 
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive :

``` csharp 
using (Presentation pres = new Presentation())
{
    //Ajoute des diapositives nouvelles à la présentation
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crée un arrière-plan pour la deuxième diapositive
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Deuxième Diapositive";

    // Crée un arrière-plan pour la troisième diapositive
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Troisième Diapositive";

    //Ajoute des objets ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Création de Cadres de Zoom avec des Images Personnalisées**
Avec Aspose.Slides pour .NET, vous pouvez créer un cadre de zoom avec une image de prévisualisation de diapositive différente de la manière suivante : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière-plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d'Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

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

    // Crée une zone de texte pour la troisième diapo
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Deuxième Diapositive";

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Ajoute l'objet ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatage des Cadres de Zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom. 

Vous pouvez contrôler le formatage d'un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives que vous souhaitez lier à votre cadre de zoom. 
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d'Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre de zoom.
7. Changez le format de ligne pour le deuxième objet cadre de zoom.
8. Supprimez l'arrière-plan d'une image du deuxième objet cadre de zoom.
9. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment modifier le formatage d'un cadre de zoom sur une diapositive : 

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
    autoshape.TextFrame.Text = "Deuxième Diapositive";

    // Crée un arrière-plan pour la troisième diapositive
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Troisième Diapositive";

    //Ajoute des objets ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crée une nouvelle image pour l'objet zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Définit l'image personnalisée pour l'objet zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Définit un format de cadre de zoom pour l'objet zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Paramètre pour ne pas afficher l'arrière-plan de l'objet zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Un section zoom est un lien vers une section de votre présentation. Vous pouvez utiliser les section zooms pour revenir aux sections que vous souhaitez vraiment souligner. Ou vous pouvez les utiliser pour mettre en évidence comment certaines parties de votre présentation se connectent. 

![overview_image](seczoomsel.png)

Pour les objets de section zoom, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création de Cadres de Section Zoom**

Vous pouvez ajouter un cadre de section zoom sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de section zoom (contenant des références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom sur une diapositive :

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

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Création de Cadres de Section Zoom avec des Images Personnalisées**

En utilisant Aspose.Slides pour .NET, vous pouvez créer un cadre de section zoom avec une image de prévisualisation de diapositive différente de la manière suivante : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d'Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
6. Ajoutez un cadre de section zoom (contenant une référence à la section créée) à la première diapositive.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de zoom avec une image différente :

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

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formatage des Cadres de Section Zoom**

Pour créer des cadres de section zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de section zoom. 

Vous pouvez contrôler le formatage d'un cadre de section zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de section zoom (contenant des références à la section créée) à la première diapositive.
6. Changez la taille et la position de l'objet de section zoom créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d'Images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre de section zoom créé.
9. Définissez la capacité de *retourner à la diapositive d'origine depuis la section liée*. 
10. Supprimez l'arrière-plan d'une image de l'objet cadre de section zoom.
11. Changez le format de ligne pour le deuxième objet cadre de zoom.
12. Changez la durée de transition.
13. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment changer le format d'un cadre de section zoom :

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

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Résumé Zoom**

Un résumé zoom est comme une page d'accueil où toutes les parties de votre présentation sont affichées en une fois. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans n'importe quel ordre que vous aimez. Vous pouvez faire preuve de créativité, sauter en avant ou revisiter certaines parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de résumé zoom, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) ainsi que quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Création de Résumé Zoom**

Vous pouvez ajouter un cadre de résumé zoom sur une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de résumé zoom à la première diapositive.
4. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment créer un cadre de résumé zoom sur une diapositive :

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

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Ajout et Suppression de Section de Résumé Zoom**

Toutes les sections dans un cadre de résumé zoom sont représentées par des objets [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Vous pouvez ajouter ou supprimer un objet de section résumé zoom par le biais de l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Ajoutez une nouvelle diapositive et section à la présentation.
5. Ajoutez la section créée au cadre de résumé zoom.
6. Supprimez la première section du cadre de résumé zoom.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment ajouter et supprimer des sections dans un cadre de résumé zoom :

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

    // Ajoute une section au Zoom Résumé
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Supprime une section du Zoom Résumé
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formatage des Sections de Résumé Zoom**

Pour créer des objets de section résumé zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section résumé zoom. 

Vous pouvez contrôler le formatage d'un objet de section résumé zoom dans un cadre de résumé zoom de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Obtenez un objet de section résumé zoom pour le premier objet de la `ISummaryZoomSectionCollection`.
5. Créez un [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour l'objet de section zoom créé.
7. Définissez la capacité de *retourner à la diapositive d'origine depuis la section liée*. 
8. Changez le format de ligne pour le deuxième objet cadre de zoom.
9. Changez la durée de transition.
10. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment changer le format pour un objet de section résumé zoom :

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

    // Formatage pour l'objet SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Sauvegarde la présentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```