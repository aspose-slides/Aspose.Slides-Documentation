---
title: Gérer le Zoom de présentation en PHP
linktitle: Gérer le Zoom
type: docs
weight: 60
url: /fr/php-java/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de résumé
- ajouter un zoom
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser le Zoom avec Aspose.Slides for PHP via Java — passez d’une section à l’autre, ajoutez des vignettes et des transitions aux présentations PPT, PPTX et ODP."
---

## **Aperçu**
Les Zooms dans PowerPoint vous permettent de passer d’une diapositive, d’une section ou d’une partie d’une présentation à une autre. Lors de votre présentation, cette capacité à naviguer rapidement dans le contenu peut s’avérer très utile. 

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Summary Zoom](#Summary-Zoom).
* Pour n’afficher que les diapositives sélectionnées, utilisez un [Slide Zoom](#Slide-Zoom).
* Pour n’afficher qu’une seule section, utilisez un [Section Zoom](#Section-Zoom).

## **Zoom de diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le déroulement de votre présentation. Les zooms de diapositive sont idéaux pour les présentations courtes avec peu de sections, mais ils peuvent également être utilisés dans différents scénarios de présentation.

Les zooms de diapositive vous aident à explorer plusieurs informations tout en donnant l’impression d’être sur une seule toile. 

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/) , la classe [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) et certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) .

### **Créer des cadres de zoom**
Vous pouvez ajouter un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier les cadres de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute de nouvelles diapositives à la présentation
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un arrière-plan pour la deuxième diapositive
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la deuxième diapositive
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crée un arrière-plan pour la troisième diapositive
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Ajoute des objets ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Créer des cadres de zoom avec des images personnalisées**
Avec Aspose.Slides for PHP via Java, vous pouvez créer un cadre de zoom avec une image d’aperçu de diapositive différente de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez une nouvelle diapositive à laquelle vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan à la diapositive.
4. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un arrière-plan pour la deuxième diapositive
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crée une nouvelle image pour l'objet Zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute l'objet ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formater les cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom. 

Vous pouvez contrôler le formatage d’un cadre de zoom sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez de nouvelles diapositives auxquelles vous souhaitez lier le cadre de zoom. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne du deuxième objet de cadre de zoom.
8. Supprimez l’arrière‑plan d’une image du deuxième objet de cadre de zoom.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute de nouvelles diapositives à la présentation
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un arrière-plan pour la deuxième diapositive
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la deuxième diapositive
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crée un arrière-plan pour la troisième diapositive
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Ajoute des objets ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Crée une nouvelle image pour l'objet zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Définit une image personnalisée pour l'objet zoomFrame1
    $zoomFrame1->setImage($picture);
    # Définit un format de cadre zoom pour l'objet zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Paramètre pour ne pas afficher l'arrière-plan de l'objet zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zoom de section**
Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en évidence. Vous pouvez également les utiliser pour souligner comment certaines parties de votre présentation sont liées. 

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit la classe [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) et certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) .

### **Créer des cadres de zoom de section**
Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Ajoute un objet SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Créer des cadres de zoom de section avec des images personnalisées**
En utilisant Aspose.Slides for PHP via Java, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Crée une nouvelle image pour l'objet zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute un objet SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formater les cadres de zoom de section**
Pour créer des cadres de zoom de section plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section. 

Vous pouvez contrôler le formatage d’un cadre de zoom de section sur une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de zoom de section créé.
7. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Activez la fonctionnalité *retour à la diapositive d’origine depuis la section liée*. 
10. Supprimez l’arrière‑plan d’une image du cadre de zoom de section.
11. Modifiez le format de ligne du deuxième cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Ajoute un objet SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formatage pour SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zoom de résumé**
Un zoom de résumé ressemble à une page d’atterrissage où toutes les parties de votre présentation sont affichées en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d’un endroit de votre présentation à un autre dans l’ordre que vous désirez. Vous pouvez être créatif, sauter en avant ou revenir sur des parties de votre diaporama sans interrompre le déroulement de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de zoom de résumé, Aspose.Slides fournit les classes [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) et [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) ainsi que certaines méthodes de la classe [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) .

### **Créer un zoom de résumé**
Vous pouvez ajouter un cadre de zoom de résumé à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de résumé à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 2", $slide);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 3", $slide);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 4", $slide);
    # Ajoute un objet SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Ajouter et supprimer une section de zoom de résumé**
Toutes les sections d’un cadre de zoom de résumé sont représentées par des objets [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) stockés dans l’objet [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) . Vous pouvez ajouter ou supprimer un objet de section de zoom de résumé via la classe [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé dans la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de résumé.
6. Supprimez la première section du cadre de zoom de résumé.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 2", $slide);
    # Ajoute un objet SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Ajoute une section au Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Supprime la section du Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Formater les sections de zoom de résumé**
Pour créer des objets de section de zoom de résumé plus complexes, vous devez modifier le formatage d’un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de zoom de résumé. 

Vous pouvez contrôler le formatage d’un objet de section de zoom de résumé dans un cadre de zoom de résumé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Créez de nouvelles diapositives avec arrière‑plan d’identification et nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de résumé à la première diapositive.
4. Récupérez un objet de section de zoom de résumé pour le premier objet à partir de la `SummaryZoomSectionCollection`.
7. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la collection images associée à l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Activez la fonctionnalité *retour à la diapositive d’origine depuis la section liée*. 
11. Modifiez le format de ligne du deuxième objet de cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 1", $slide);
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Ajoute une nouvelle section à la présentation
    $pres->getSections()->addSection("Section 2", $slide);
    # Ajoute un objet SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Récupère le premier objet SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Mise en forme de l'objet SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Enregistre la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après l’affichage de la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) ou la [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) possède un comportement `ReturnToParent` qui, lorsqu’il est activé, renvoie les spectateurs à la diapositive d’origine après avoir visité le contenu cible.

**Puis-je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Zoom prend en charge la définition d’une `TransitionDuration` afin de contrôler la durée de l’animation de saut.

**Existe-t-il des limites au nombre d’objets Zoom qu’une présentation peut contenir ?**

Il n’existe pas de limite API stricte documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de Zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.