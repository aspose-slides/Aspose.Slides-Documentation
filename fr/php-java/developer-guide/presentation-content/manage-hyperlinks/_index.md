---
title: Gérer les Hyperliens
type: docs
weight: 20
url: /php-java/manage-hyperlinks/
keywords: "Hyperlien PowerPoint, hyperlien texte, hyperlien diapositive, hyperlien forme, hyperlien image, hyperlien vidéo, Java"
description: "Comment ajouter un hyperlien à une présentation PowerPoint"
---

Un hyperlien est une référence à un objet ou des données ou un endroit dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites web dans des textes, des formes ou des médias
* Liens vers des diapositives

Aspose.Slides pour PHP via Java vous permet d'effectuer de nombreuses tâches impliquant des hyperliens dans les présentations.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter l'éditeur PowerPoint en ligne simple et [gratuit d'Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajouter des Hyperliens URL**

### **Ajouter des Hyperliens URL aux Textes**

Ce code PHP vous montre comment ajouter un hyperlien de site web à un texte :

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose : API de format de fichier");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Ajouter des Hyperliens URL aux Formes ou Cadres**

Ce code d'exemple vous montre comment ajouter un hyperlien de site web à une forme :

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ajouter des Hyperliens URL aux Médias**

Aspose.Slides vous permet d'ajouter des hyperliens à des images, des fichiers audio et des fichiers vidéo.

Ce code d'exemple vous montre comment ajouter un hyperlien à une **image** :

```php
  $pres = new Presentation();
  try {
    # Ajoute une image à la présentation
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Crée un cadre d'image sur la diapositive 1 basé sur l'image précédemment ajoutée
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ce code d'exemple vous montre comment ajouter un hyperlien à un **fichier audio** :

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ce code d'exemple vous montre comment ajouter un hyperlien à une **vidéo** :

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Astuce"  color="primary"  %}} 

Vous voudrez peut-être voir *[Gérer OLE](/slides/php-java/manage-ole/)*.

{{% /alert %}}

## **Utiliser des Hyperliens pour Créer une Table des Matières**

Puisque les hyperliens vous permettent d'ajouter des références à des objets ou des lieux, vous pouvez les utiliser pour créer une table des matières.

Ce code d'exemple vous montre comment créer une table des matières avec des hyperliens :

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Titre de la diapositive 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formater les Hyperliens**

### **Couleur**

Avec la propriété [ColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink#setColorSource-int-) dans l'interface [IHyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink), vous pouvez définir la couleur des hyperliens et également obtenir les informations de couleur à partir des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, donc les modifications concernant la propriété ne s'appliquent pas aux anciennes versions de PowerPoint.

Ce code d'exemple démontre une opération où des hyperliens de différentes couleurs ont été ajoutés à la même diapositive :

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("Ceci est un exemple d'hyperlien coloré.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("Ceci est un exemple d'hyperlien habituel.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer des Hyperliens dans des Présentations**

### **Supprimer des Hyperliens des Textes**

Ce code PHP vous montre comment supprimer l'hyperlien d'un texte dans une diapositive de présentation :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Supprimer des Hyperliens des Formes ou Cadres**

Ce code PHP vous montre comment supprimer l'hyperlien d'une forme dans une diapositive de présentation :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hyperlien Mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/Hyperlink) est mutable. Avec cette classe, vous pouvez changer les valeurs de ces propriétés :

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

L'extrait de code vous montre comment ajouter un hyperlien à une diapositive et modifier son tooltip plus tard :

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose : API de format de fichier");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("Plus de 70% des entreprises du Fortune 100 font confiance aux API Aspose");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Propriétés Supportées dans IHyperlinkQueries**

Vous pouvez accéder à [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) depuis une présentation, une diapositive ou un texte pour lequel l'hyperlien est défini.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

La classe [IHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries) supporte ces méthodes et propriétés :

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/php-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)