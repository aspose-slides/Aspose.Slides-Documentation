---
title: Gérer le Zoom
type: docs
weight: 60
url: /fr/java/manage-zoom/
keywords: "Zoom, cadre zoom, Ajouter un zoom, Formater le cadre zoom, Résumé zoom, Présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Ajouter un zoom ou des cadres zoom aux présentations PowerPoint en Java"
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de naviguer vers et depuis des diapositives, sections et parties spécifiques d'une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement dans le contenu peut s'avérer très utile. 

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Résumé de Zoom](#Résumé-Zoom).
* Pour ne montrer que des diapositives sélectionnées, utilisez un [Zoom de Diapositive](#Zoom-de-Diapositive).
* Pour ne montrer qu'une seule section, utilisez un [Zoom de Section](#Zoom-de-Section).

## **Zoom de Diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n'importe quel ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont idéaux pour des présentations courtes sans beaucoup de sections, mais vous pouvez toujours les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à explorer plusieurs morceaux d'informations tout en ayant l'impression d'être sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType), l'interface [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) et quelques méthodes dans l'interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Création de Cadres Zoom**

Vous pouvez ajouter un cadre zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous comptez lier les cadres zoom. 
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre zoom sur une diapositive :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un arrière-plan pour la deuxième diapositive
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Deuxième Diapositive");

    // Crée un arrière-plan pour la troisième diapositive
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Troisième Diapositive");

    //Ajoute des objets ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Création de Cadres Zoom avec Images Personnalisées**
Avec Aspose.Slides pour Java, vous pouvez créer un cadre zoom avec une image d'aperçu de diapositive différente de cette façon : 
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive à laquelle vous comptez lier le cadre zoom. 
3. Ajoutez un texte d'identification et un arrière-plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre zoom avec une image différente :

``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un arrière-plan pour la diapositive
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la diapositive
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

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatage des Cadres Zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres zoom simples. Pour créer des cadres zoom plus compliqués, vous devez modifier le format d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre zoom. 

Vous pouvez contrôler le formatage d'un cadre zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives pour lesquelles vous comptez lier le cadre zoom. 
3. Ajoutez du texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet cadre zoom.
7. Changez le format de ligne pour le deuxième objet cadre zoom.
8. Supprimez l'arrière-plan d'une image du deuxième objet cadre zoom.
9. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment changer le formatage d'un cadre zoom sur une diapositive : 

``` java 
Presentation pres = new Presentation();
try {
    //Ajoute de nouvelles diapositives à la présentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un arrière-plan pour la deuxième diapositive
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la deuxième diapositive
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Deuxième Diapositive");

    // Crée un arrière-plan pour la troisième diapositive
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

    // Définit un format de cadre zoom pour l'objet zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Paramètre pour ne pas montrer l'arrière-plan de l'objet zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir à des sections que vous souhaitez vraiment mettre en avant. Ou vous pouvez les utiliser pour souligner comment certaines parties de votre présentation se connectent. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) et quelques méthodes dans l'interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Création de Cadres Zoom de Section**

Vous pouvez ajouter un cadre zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous comptez lier le cadre zoom. 
5. Ajoutez un cadre zoom de section (contenant des références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre zoom sur une diapositive :

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

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Création de Cadres Zoom de Section avec Images Personnalisées**

En utilisant Aspose.Slides pour Java, vous pouvez créer un cadre zoom de section avec une image d'aperçu de diapositive différente de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous comptez lier le cadre zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
6. Ajoutez un cadre zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre zoom avec une image différente :

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

    // Ajoute l'objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatage des Cadres Zoom de Section**

Pour créer des cadres zoom de section plus compliqués, vous devez modifier le format d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre zoom de section. 

Vous pouvez contrôler le formatage d'un cadre zoom de section sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous comptez lier le cadre zoom. 
5. Ajoutez un cadre zoom de section (contenant des références à la section créée) à la première diapositive.
6. Changez la taille et la position de l'objet zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet cadre zoom de section créé.
9. Définissez la capacité de *retour à la diapositive d'origine à partir de la section liée*. 
10. Supprimez l'arrière-plan d'une image de l'objet cadre zoom de section.
11. Changez le format de ligne pour le deuxième objet cadre zoom.
12. Changez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment changer le formatage d'un cadre zoom de section :

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

    // Ajoute l'objet SectionZoomFrame
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

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Résumé Zoom**

Un résumé zoom est comme une page d'accueil où toutes les pièces de votre présentation sont affichées en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans n'importe quel ordre que vous souhaitez. Vous pouvez faire preuve de créativité, passer à l'étape suivante ou revisiter des morceaux de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de résumé zoom, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection), et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) ainsi que quelques méthodes dans l'interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Création de Résumé Zoom**

Vous pouvez ajouter un cadre de résumé zoom à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de résumé zoom à la première diapositive.
4. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment créer un cadre de résumé zoom sur une diapositive :

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

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ajout et Suppression de Section de Résumé Zoom**

Toutes les sections dans un cadre de résumé zoom sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). Vous pouvez ajouter ou supprimer un objet de section de résumé zoom via l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Ajoutez une nouvelle diapositive et une section à la présentation.
5. Ajoutez la section créée au cadre de résumé zoom.
6. Supprimez la première section du cadre de résumé zoom.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment ajouter et supprimer des sections dans un cadre de résumé zoom :

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

    // Ajoute une section au Résumé Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Supprime la section du Résumé Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatage des Sections de Résumé Zoom**

Pour créer des objets de section de résumé zoom plus compliqués, vous devez modifier le format d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de résumé zoom. 

Vous pouvez contrôler le formatage d'un objet de section de résumé zoom dans un cadre de résumé zoom de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé zoom à la première diapositive.
4. Obtenez un objet de section de résumé zoom pour le premier objet à partir de la `ISummaryZoomSectionCollection`.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour l'objet cadre de section zoom créé.
7. Définissez la capacité de *retour à la diapositive d'origine à partir de la section liée*. 
8. Changez le format de ligne pour le deuxième objet cadre zoom.
9. Changez la durée de transition.
10. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Java vous montre comment changer le formatage pour un objet de section de résumé zoom :

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

    // Sauvegarde la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```