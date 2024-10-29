---
title: Gérer le zoom
type: docs
weight: 60
url: /fr/php-java/manage-zoom/
keywords: "Zoom, cadre de zoom, Ajouter un zoom, Format cadre de zoom, Résumé de zoom, Présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter un zoom ou des cadres de zoom aux présentations PowerPoint "
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de passer à des diapositives, sections et portions spécifiques d'une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s'avérer très utile.

![overview_image](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Résumé de Zoom](#Summary-Zoom).
* Pour afficher uniquement des diapositives sélectionnées, utilisez un [Zoom de Diapositive](#Slide-Zoom).
* Pour afficher uniquement une seule section, utilisez un [Zoom de Section](#Section-Zoom).

## **Zoom de Diapositive**
Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l'ordre de votre choix sans interrompre le fil de votre présentation. Les zooms de diapositives sont idéaux pour des présentations courtes sans nombreuses sections, mais vous pouvez toujours les utiliser dans différents scénarios de présentation.

Les zooms de diapositives vous aident à approfondir plusieurs éléments d'information tout en ayant l'impression d'être sur une seule toile.

![overview_image](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), l'interface [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame), et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Créer des Cadres de Zoom**

Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous prévoyez de lier les cadres de zoom.
3. Ajoutez un texte d'identification et un fond aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment créer un cadre de zoom sur une diapositive :

```php
  $pres = new Presentation();
  try {
    # Ajoute de nouvelles diapositives à la présentation
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un fond pour la deuxième diapositive
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la deuxième diapositive
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Deuxième Diapositive");
    # Crée un fond pour la troisième diapositive
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Troisième Diapositive");
    # Ajoute des objets ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Créer des Cadres de Zoom avec des Images Personnalisées**
Avec Aspose.Slides pour PHP via Java, vous pouvez créer un cadre de zoom avec une image d'aperçu de diapositive différente de cette manière :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive à laquelle vous prévoyez de lier le cadre de zoom.
3. Ajoutez un texte d'identification et un fond à la diapositive.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment créer un cadre de zoom avec une image différente :

```php
  $pres = new Presentation();
  try {
    # Ajoute une nouvelle diapositive à la présentation
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un fond pour la deuxième diapositive
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Deuxième Diapositive");
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
    # Ajoute l'objet ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatage des Cadres de Zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom.

Vous pouvez contrôler le formatage d'un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives auxquelles vous prévoyez de lier le cadre de zoom.
3. Ajoutez un texte d'identification et un fond aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) à la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Changez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez le fond d'une image de l'objet de cadre de zoom second.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment changer le formatage d'un cadre de zoom sur une diapositive :

```php
  $pres = new Presentation();
  try {
    # Ajoute de nouvelles diapositives à la présentation
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crée un fond pour la deuxième diapositive
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crée une zone de texte pour la deuxième diapositive
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Deuxième Diapositive");
    # Crée un fond pour la troisième diapositive
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crée une zone de texte pour la troisième diapositive
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Troisième Diapositive");
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
    # Définit un format de cadre de zoom pour l'objet zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Paramètre pour ne pas afficher le fond pour l'objet zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir vers des sections que vous souhaitez vraiment mettre en avant. Ou vous pouvez les utiliser pour souligner comment certaines parties de votre présentation se connectent.

![overview_image](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Créer des Cadres de Zoom de Section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous prévoyez de lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment créer un cadre de zoom sur une diapositive :

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
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Créer des Cadres de Zoom de Section avec des Images Personnalisées**

En utilisant Aspose.Slides pour PHP via Java, vous pouvez créer un cadre de zoom de section avec une image d'aperçu de diapositive différente de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous prévoyez de lier le cadre de zoom.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
5. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment créer un cadre de zoom avec une image différente :

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
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatage des Cadres de Zoom de Section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section.

Vous pouvez contrôler le formatage d'un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez une nouvelle diapositive.
3. Ajoutez un fond d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous prévoyez de lier le cadre de zoom.
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l'objet de zoom de section créé.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet de cadre de zoom de section créé.
9. Activez la capacité *de revenir à la diapositive d'origine depuis la section liée*.
10. Supprimez le fond d'une image de l'objet de cadre de zoom de section.
11. Changez le format de ligne pour le deuxième objet de cadre de zoom.
12. Changez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment changer le formatage d'un cadre de zoom de section :

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
    # Formatage pour le SectionZoomFrame
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
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Résumé de Zoom**

Un résumé de zoom est comme une page d'accueil où toutes les pièces de votre présentation sont affichées à la fois. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans l'ordre que vous souhaitez. Vous pouvez être créatif, passer en avant ou revisiter des parties de votre diaporama sans interrompre le fil de votre présentation.

![overview_image](sumzoomsel.png)

Pour les objets de résumé de zoom, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection), et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) et quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Créer un Résumé de Zoom**

Vous pouvez ajouter un cadre de résumé de zoom à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de résumé de zoom à la première diapositive.
4. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment créer un cadre de résumé de zoom sur une diapositive :

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
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ajouter et Supprimer des Sections de Résumé de Zoom**

Toutes les sections dans un cadre de résumé de zoom sont représentées par des objets [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection). Vous pouvez ajouter ou supprimer un objet de section de résumé de zoom via l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé de zoom à la première diapositive.
4. Ajoutez une nouvelle diapositive et section à la présentation.
5. Ajoutez la section créée au cadre de résumé de zoom.
6. Supprimez la première section du cadre de résumé de zoom.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment ajouter et supprimer des sections dans un cadre de résumé de zoom :

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
    # Ajoute une section au résumé de zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Supprime la section du résumé de zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formatage des Sections de Résumé de Zoom**

Pour créer des objets de section de résumé de zoom plus compliqués, vous devez modifier le formatage d'un simple cadre. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de résumé de zoom.

Vous pouvez contrôler le formatage d'un objet de section de résumé de zoom dans un cadre de résumé de zoom de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Créez de nouvelles diapositives avec un fond d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé de zoom à la première diapositive.
4. Obtenez un objet de section de résumé de zoom pour le premier objet de la `ISummaryZoomSectionCollection`.
7. Créez un objet [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet de cadre de section de résumé créé.
9. Activez la capacité *de revenir à la diapositive d'origine depuis la section liée*.
11. Changez le format de ligne pour le deuxième objet de cadre de zoom.
12. Changez la durée de transition.
13. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment changer le formatage pour un objet de section de résumé de zoom :

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
    # Obtient le premier objet SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formatage pour l'objet SummaryZoomSection
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
    # Sauvegarde la présentation
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```