---
title: Cloner des diapositives de présentation en PHP
linktitle: Cloner des diapositives
type: docs
weight: 35
url: /fr/php-java/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Dupliquez rapidement des diapositives PowerPoint avec Aspose.Slides pour PHP. Suivez nos exemples de code clairs pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus consistant à créer une copie exacte ou une réplique de quelque chose. Aspose.Slides for PHP via Java permet également de créer une copie ou un clone de n’importe quelle diapositive, puis d’insérer cette diapositive clonée dans la présentation actuelle ou dans toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin d’une présentation.
- Cloner à une autre position dans la même présentation.
- Cloner à la fin d’une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for PHP via Java, (une collection de [Slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Slide) objets) exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) fournit les méthodes [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) et [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone) pour exécuter les types de clonage de diapositive décrits ci‑dessus.

## **Clone a Slide at the End of a Presentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) selon les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation).
1. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) en accédant à la collection de diapositives exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation).
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) et transmettez la diapositive à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone).
1. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.

```php
  # Instanciez la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Enregistrez la présentation modifiée sur le disque
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone a Slide to Another Position within a Presentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation).
1. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection) en accédant à la collection **[Slides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides)** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation).
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (située à l’indice zéro – position 1 – de la présentation) à l’indice 1 – position 2 – de la présentation.

```php
  # Instanciez la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    # Clonez la diapositive souhaitée à l'index spécifié dans la même présentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Enregistrez la présentation modifiée sur le disque
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone a Slide at the End of Another Presentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Récupérez l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection) en accédant à la collection **[Slides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides)** exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) et transmettez la diapositive de la présentation source en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (du premier indice de la présentation source) à la fin de la présentation de destination.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciez la classe Presentation pour le PPTX de destination (où la diapositive sera clonée)
    $destPres = new Presentation();
    try {
      # Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Enregistrez la présentation de destination sur le disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide to Another Position in Another Presentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Récupérez la classe [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) en accédant à la collection Slides exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en paramètres de la méthode [insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#insertClone).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (de l’indice zéro de la présentation source) à l’indice 1 (position 2) de la présentation de destination.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciez la classe Presentation pour le PPTX de destination (où la diapositive sera clonée)
    $destPres = new Presentation();
    try {
      # Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Enregistrez la présentation de destination sur le disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide at a Specific Position in Another Presentation**
Si vous devez cloner une diapositive avec une diapositive maîtresse d’une présentation vers une autre présentation, vous devez d’abord cloner la diapositive maîtresse souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maîtresse pour cloner la diapositive avec maître. La méthode [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) attend une diapositive maîtresse provenant de la présentation de destination plutôt que de la présentation source. Pour cloner une diapositive avec maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maîtresse.
1. Instanciez la classe [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/MasterSlideCollection) en référant la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) exposée par l’objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/MasterSlideCollection) et transmettez le maître de la source PPTX à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone).
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSlides) et transmettez la diapositive de la présentation source à cloner ainsi que la diapositive maîtresse en paramètres de la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive avec maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciez la classe Presentation pour la présentation de destination (où la diapositive sera clonée)
    $destPres = new Presentation();
    try {
      # Instanciez ISlide à partir de la collection de diapositives de la présentation source ainsi que
      # diapositive maîtresse
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonez la diapositive maîtresse souhaitée de la présentation source vers la collection de maîtres dans la
      # présentation de destination
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonez la diapositive maîtresse souhaitée de la présentation source vers la collection de maîtres dans la
      # présentation de destination
      $iSlide = $masters->addClone($SourceMaster);
      # Clonez la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
      # collection de diapositives de la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Enregistrez la présentation de destination sur le disque
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide at the End of a Specified Section**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection/#addClone) exposée par la classe [SlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java permet de cloner une diapositive depuis la première section et d’insérer cette diapositive clonée dans la seconde section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Enregistrez la présentation de destination sur le disque
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ensure Matching Slide Size**

Lorsque vous clonez des diapositives dans une autre présentation, assurez‑vous que la présentation de destination possède la même taille de diapositive que la source. Si les tailles diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées — leurs coordonnées et dimensions d’origine sont conservées, ce qui peut entraîner un mauvais alignement ou un dépassement des limites de la diapositive.

Vous pouvez définir la taille de diapositive de la présentation de destination pour qu’elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Effectuez cette opération avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/php-java/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé sous forme d’[objet OLE](/slides/fr/php-java/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/php-java/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dans celle‑ci.