---
title: Gérer le Zoom
type: docs
weight: 60
url: /androidjava/manage-zoom/
keywords: "Zoom, cadre de zoom, Ajouter du zoom, Cadre de zoom formaté, Zoom résumé, Présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Ajouter un zoom ou des cadres de zoom aux présentations PowerPoint en Java"
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de sauter vers des diapositives, sections et portions spécifiques d'une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s'avérer très utile.

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Zoom résumé](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Zoom de diapositive](#Slide-Zoom).
* Pour afficher une seule section seulement, utilisez un [Zoom de section](#Section-Zoom).

## **Zoom de Diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l'ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont idéaux pour les courtes présentations sans beaucoup de sections, mais vous pouvez toujours les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à approfondir plusieurs morceaux d'informations tout en ayant l'impression d'être sur une seule toile.

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), l'interface [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Création de Cadres de Zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom.
3. Ajoutez un texte d'identification et un fond aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de zoom sur une diapositive :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un fond pour la deuxième diapositive
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Deuxième Diapositive");

    // Crée un fond pour la troisième diapositive
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Troisième Diapositive");

    //Ajoute des objets ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Création de Cadres de Zoom avec des Images Personnalisées**
Avec Aspose.Slides pour Android via Java, vous pouvez créer un cadre de zoom avec une image de prévisualisation de diapositive différente de cette manière :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom.
3. Ajoutez un texte d'identification et un fond à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de zoom avec une image différente :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un fond pour la deuxième diapositive
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la troisième diapositive
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Deuxième Diapositive");

    // Crée une nouvelle image pour l'objet zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    //Ajoute l'objet ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatage des Cadres de Zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom.

Vous pouvez contrôler le formatage d'un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives que vous souhaitez lier au cadre de zoom.
3. Ajoutez quelques textes d'identification et fonds aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l'arrière-plan d'une image du deuxième objet de cadre de zoom.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment modifier le format d'un cadre de zoom sur une diapositive :

``` java 
Presentation pres = new Presentation();
try {
    //Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un fond pour la deuxième diapositive
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Deuxième Diapositive");

    // Crée un fond pour la troisième diapositive
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Troisième Diapositive");

    //Ajoute des objets ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Crée une nouvelle image pour l'objet zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Définit une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.setImage(picture);

    // Définit un format de cadre de zoom pour l'objet zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Réglage pour ne pas montrer l'arrière-plan pour l'objet zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Ou vous pouvez les utiliser pour souligner comment certaines parties de votre présentation se connectent.

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Création de Cadres de Zoom de Section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de zoom sur une diapositive :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle Section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Création de Cadres de Zoom de Section avec des Images Personnalisées**

En utilisant Aspose.Slides pour Android via Java, vous pouvez créer un cadre de zoom de section avec une image de prévisualisation de diapositive différente de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de zoom avec une image différente :

``` java 
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle Section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Crée une nouvelle image pour l'objet zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatage des Cadres de Zoom de Section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section.

Vous pouvez contrôler le formatage d'un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l'objet de zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet de cadre de zoom de section créé.
9. Activez la fonction *retourner à la diapositive d'origine de la section liée*.
10. Supprimez l'arrière-plan d'une image de l'objet de cadre de zoom de section.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment modifier le format d'un cadre de zoom de section :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle Section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatage pour l'objet SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom Résumé**

Un zoom résumé est comme une page d'atterrissage où toutes les pièces de votre présentation sont affichées en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans l'ordre de votre choix. Vous pouvez être créatif, sauter en avant ou revisiter des morceaux de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom résumé, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) ainsi que quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Création d'un Zoom Résumé**

Vous pouvez ajouter un cadre de zoom résumé à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom résumé à la première diapositive.
4. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de zoom résumé sur une diapositive :

``` java 
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 3", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 4", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ajout et Suppression de Section de Zoom Résumé**

Toutes les sections dans un cadre de zoom résumé sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Vous pouvez ajouter ou supprimer un objet de section de zoom résumé via l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom résumé à la première diapositive.
4. Ajoutez une nouvelle diapositive et section à la présentation.
5. Ajoutez la section créée au cadre de zoom résumé.
6. Supprimez la première section du cadre de zoom résumé.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment ajouter et supprimer des sections dans un cadre de zoom résumé :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Ajoute une section au Zoom Résumé
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Supprime la section du Zoom Résumé
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatage des Sections de Zoom Résumé**

Pour créer des objets de section de zoom résumé plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de zoom résumé.

Vous pouvez contrôler le formatage de l'objet de section de zoom résumé dans un cadre de zoom résumé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom résumé à la première diapositive.
4. Obtenez un objet de section de zoom résumé pour le premier objet à partir de la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet de cadre de zoom créé.
9. Activez la fonction *retourner à la diapositive d'origine de la section liée*.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment modifier le format d'un objet de section de zoom résumé :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    //Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);

    // Ajoute un objet SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Obtient le premier objet SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatage pour l'objet SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```