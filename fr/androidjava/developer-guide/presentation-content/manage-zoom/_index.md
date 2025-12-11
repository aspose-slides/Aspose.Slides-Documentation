---
title: Gérer le zoom de présentation sur Android
linktitle: Gérer le zoom
type: docs
weight: 60
url: /fr/androidjava/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de résumé
- ajouter un zoom
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser le zoom avec Aspose.Slides pour Android via Java — passer d’une section à l’autre, ajouter des vignettes et des transitions dans les présentations PPT, PPTX et ODP."
---

## **Vue d'ensemble**
Les Zooms dans PowerPoint vous permettent de passer rapidement à des diapositives, sections et portions spécifiques d’une présentation, et d’en revenir. Lors d’une présentation, cette capacité de navigation rapide peut s’avérer très utile. 

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Zoom de résumé](#Summary-Zoom).
* Pour n’afficher que des diapositives sélectionnées, utilisez un [Zoom de diapositive](#Slide-Zoom).
* Pour n’afficher qu’une seule section, utilisez un [Zoom de section](#Section-Zoom).

## **Zoom de diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont idéaux pour les présentations courtes sans trop de sections, mais vous pouvez également les utiliser dans divers scénarios de présentation.

Les zooms de diapositive vous aident à approfondir plusieurs informations tout en restant sur une même toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), l’interface [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Créer des cadres de zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous envisagez de lier les cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre de zoom sur une diapositive :
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
    autoshape.getTextFrame().setText("Second Slide");

    // Crée un arrière-plan pour la troisième diapositive
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Ajoute des objets ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides for Android via Java, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette façon :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive à laquelle vous envisagez de lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre de zoom avec une image différente :
``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crée un arrière‑plan pour la deuxième diapositive
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crée une zone de texte pour la troisième diapositive
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crée une nouvelle image pour l’objet Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Ajoute l’objet ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mettre en forme les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un cadre de zoom. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives à lier auxquelles vous envisagez de lier le cadre de zoom. 
3. Ajoutez du texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l’arrière‑plan d’une image du deuxième objet de cadre de zoom.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment modifier la mise en forme d’un cadre de zoom sur une diapositive : 
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
    autoshape.getTextFrame().setText("Second Slide");

    // Crée un arrière-plan pour la troisième diapositive
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Ajoute des objets ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Crée une nouvelle image pour l’objet Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Définit une image personnalisée pour l’objet zoomFrame1
    zoomFrame1.setImage(picture);

    // Définit le format d’un cadre Zoom pour l’objet zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Paramètre pour ne pas afficher l’arrière-plan pour l’objet zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour souligner comment certaines parties de votre présentation sont reliées. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l’interface [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Créer des cadres de zoom de section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous envisagez de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre de zoom sur une diapositive :
``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des cadres de zoom de section avec des images personnalisées**

Avec Aspose.Slides for Android via Java, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous envisagez de lier le cadre de zoom. 
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre de zoom avec une image différente :
``` java 
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Crée une nouvelle image pour l’objet Zoom
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

### **Mettre en forme les cadres de zoom de section**

Pour créer des cadres de zoom de section plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un cadre de zoom de section. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom de section sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous envisagez de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Activez la fonction *retour à la diapositive d’origine depuis la section liée*. 
10. Supprimez l’arrière‑plan d’une image de l’objet de cadre de zoom de section.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment modifier la mise en forme d’un cadre de zoom de section :
``` java
Presentation pres = new Presentation();
try {
    //Ajoute une nouvelle diapositive à la présentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);

    // Ajoute un objet SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatage pour SectionZoomFrame
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



## **Zoom de résumé**

Un zoom de résumé ressemble à une page d’atterrissage où toutes les parties de votre présentation sont affichées simultanément. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d’un endroit de votre présentation à un autre dans l’ordre de votre choix. Vous pouvez être créatif, sauter en avant ou revenir sur des parties de votre diaporama sans interrompre le flux de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de résumé, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) ainsi que certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Créer un zoom de résumé**

Vous pouvez ajouter un cadre de zoom de résumé à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de résumé à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre de zoom de résumé sur une diapositive :
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


### **Ajouter et supprimer une section de zoom de résumé**

Toutes les sections d’un cadre de zoom de résumé sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), stockés dans l’objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Vous pouvez ajouter ou supprimer une section de zoom de résumé via l’interface [ISummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de résumé.
6. Supprimez la première section du cadre de zoom de résumé.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment ajouter et supprimer des sections dans un cadre de zoom de résumé :
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

    // Ajoute une section au Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Supprime une section du Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Enregistre la présentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Mettre en forme les sections de zoom de résumé**

Pour créer des objets de section de zoom de résumé plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un objet de section de zoom de résumé. 

Vous pouvez contrôler la mise en forme d’un objet de section de zoom de résumé dans un cadre de zoom de résumé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Récupérez un objet de section de zoom de résumé pour le premier objet depuis la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Activez la fonction *retour à la diapositive d’origine depuis la section liée*. 
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment modifier la mise en forme d’un objet de section de zoom de résumé :
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

    // Mise en forme pour l'objet SummaryZoomSection
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


## **FAQ**

**Puis‑je contrôler le retour à la diapositive « parent » après l’affichage de la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) ou la [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) possède un comportement de retour au parent qui, lorsqu’il est activé, renvoie les spectateurs à la diapositive d’origine après avoir visité le contenu ciblé.

**Puis‑je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le Zoom permet de définir une durée de transition afin que vous puissiez contrôler la rapidité de l’animation de saut.

**Existe‑t‑il des limites quant au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’existe pas de limite API stricte documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visionneur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.