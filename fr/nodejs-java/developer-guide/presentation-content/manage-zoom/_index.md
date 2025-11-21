---
title: Gérer le Zoom
type: docs
weight: 60
url: /fr/nodejs-java/manage-zoom/
keywords: "Zoom, cadre Zoom, ajouter un zoom, mettre en forme le cadre Zoom, zoom de résumé, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Ajouter des zooms ou des cadres de zoom aux présentations PowerPoint en JavaScript"
---

## **Vue d'ensemble**

Les Zooms dans PowerPoint vous permettent de sauter vers et depuis des diapositives, sections et parties spécifiques d’une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement entre le contenu peut s’avérer très utile. 

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Summary Zoom](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour afficher une seule section uniquement, utilisez un [Section Zoom](#Section-Zoom).

## **Zoom de diapositive**

Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre que vous choisissez sans interrompre le déroulement de votre présentation. Les zooms de diapositive sont idéaux pour les présentations courtes sans trop de sections, mais vous pouvez tout de même les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à examiner plusieurs informations tout en donnant l’impression d’être sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType), la classe [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) et quelques méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Création de cadres de zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute de nouvelles diapositives à la présentation
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crée un arrière-plan pour la deuxième diapositive
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crée une zone de texte pour la deuxième diapositive
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crée un arrière-plan pour la troisième diapositive
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Ajoute des objets ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de cadres de zoom avec images personnalisées**

Avec Aspose.Slides for Node.js via Java, vous pouvez créer un cadre de zoom avec une image de prévisualisation différente de cette façon :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière-plan à la diapositive.
4. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui servira à remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crée un arrière-plan pour la deuxième diapositive
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crée une zone de texte pour la troisième diapositive
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crée une nouvelle image pour l'objet zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute l'objet ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Mise en forme des cadres de zoom**

Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un cadre de zoom. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives à lier auxquelles vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui servira à remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne du deuxième objet de cadre de zoom.
8. Supprimez l’arrière-plan d’une image du deuxième objet de cadre de zoom.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute de nouvelles diapositives à la présentation
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crée un arrière-plan pour la deuxième diapositive
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crée une zone de texte pour la deuxième diapositive
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crée un arrière-plan pour la troisième diapositive
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Crée une zone de texte pour la troisième diapositive
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Ajoute des objets ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Crée une nouvelle image pour l'objet zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Définit une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.setImage(picture);
    // Définit un format de cadre zoom pour l'objet zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Paramètre pour ne pas afficher l'arrière-plan pour l'objet zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Vous pouvez également les utiliser pour souligner comment certaines parties de votre présentation se connectent. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit la classe [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) et quelques méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Création de cadres de zoom de section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Ajoute un objet SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de cadres de zoom de section avec images personnalisées**

En utilisant Aspose.Slides for Node.js via Java, vous pouvez créer un cadre de zoom de section avec une image de prévisualisation différente de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui servira à remplir le cadre.
6. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Crée une nouvelle image pour l'objet zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute un objet SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Mise en forme des cadres de zoom de section**

Pour créer des cadres de zoom de section plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un cadre de zoom de section. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de zoom de section créé.
7. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui servira à remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Définissez la *return to the original slide from the linked section* ability. 
10. Supprimez l’arrière-plan d’une image de l’objet de cadre de zoom de section.
11. Modifiez le format de ligne du deuxième objet de cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Ajoute un objet SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Mise en forme du SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zoom de résumé**

Un zoom de résumé ressemble à une page d’atterrissage où toutes les parties de votre présentation sont affichées simultanément. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d’un endroit de votre présentation à un autre dans l’ordre de votre choix. Vous pouvez faire preuve de créativité, sauter en avant ou revisiter des parties de votre diaporama sans interrompre le déroulement de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de résumé, Aspose.Slides fournit les classes [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) et [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) ainsi que quelques méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Création du zoom de résumé**

Vous pouvez ajouter un cadre de zoom de résumé à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de résumé à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 3", slide);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 4", slide);
    // Ajoute un objet SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Ajout et suppression de sections de zoom de résumé**

Toutes les sections d’un cadre de zoom de résumé sont représentées par des objets [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection), qui sont stockés dans l’objet [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Vous pouvez ajouter ou supprimer un objet de section de zoom de résumé via la classe [SummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé dans la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de résumé.
6. Supprimez la première section du cadre de zoom de résumé.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);
    // Ajoute un objet SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Ajoute une section au Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Supprime la section du Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Mise en forme des sections de zoom de résumé**

Pour créer des objets de section de zoom de résumé plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un objet de section de zoom de résumé. 

Vous pouvez contrôler la mise en forme d’un objet de section de zoom de résumé dans un cadre de zoom de résumé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un arrière-plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Obtenez un objet de section de zoom de résumé pour le premier objet depuis la `ISummaryZoomSectionCollection`.
5. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la collection images associée à l'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui servira à remplir le cadre.
6. Définissez une image personnalisée pour l’objet de cadre de section de zoom créé.
7. Définissez la *return to the original slide from the linked section* ability. 
8. Changez le format de ligne du deuxième objet de cadre de zoom.
9. Changez la durée de la transition.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une nouvelle diapositive à la présentation
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 1", slide);
    // Ajoute une nouvelle diapositive à la présentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Ajoute une nouvelle section à la présentation
    pres.getSections().addSection("Section 2", slide);
    // Ajoute un objet SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Récupère le premier objet SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Mise en forme de l'objet SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Enregistre la présentation
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après avoir affiché la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) ou la [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) possède une méthode `setReturnToParent` qui, lorsqu’elle est activée, renvoie les spectateurs à la diapositive d’origine après qu’ils aient consulté le contenu cible.

**Puis-je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Zoom expose une méthode `setTransitionDuration` qui vous permet de contrôler la durée de l'animation de saut.

**Existe-t-il des limites au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’existe aucune limite API stricte documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.