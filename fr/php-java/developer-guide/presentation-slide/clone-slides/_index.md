---
title: Cloner les diapositives d'une présentation en PHP
linktitle: Cloner les diapositives
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

## **Cloner des diapositives dans une présentation**
Le clonage est le processus de creation d'une copie exacte ou d'un duplicata de quelque chose. Aspose.Slides pour PHP via Java permet egalement de creer une copie ou un clone de n'importe quelle diapositive puis d'insérer cette diapositive clonee dans la présentation actuelle ou toute autre presentation ouverte. Le processus de clonage de diapositive cree une nouvelle diapositive qui peut être modifiee par les developpeurs sans changer la diapositive originale. Il existe plusieurs facons de cloner une diapositive:

- Cloner a la fin d'une presentation.
- Cloner a une autre position dans la presentation.
- Cloner a la fin dans une autre presentation.
- Cloner a une autre position dans une autre presentation.
- Cloner a une position specifique dans une autre presentation.

Dans Aspose.Slides pour PHP via Java, (une collection d'objets [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) ) exposee par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) fournit les methodes [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour effectuer les types de clonage de diapositive ci-dessus.

## **Cloner une diapositive a la fin d'une presentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le meme fichier de presentation a la fin des diapositives existantes, utilisez la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) selon les etapes ci-dessous:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en referencant la collection Slides exposee par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Appeler la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposee par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et transmettre la diapositive a cloner comme parametre a la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ecrire le fichier de presentation modifie.

Dans l'exemple ci-dessous, nous avons clone une diapositive (située à la première position - indice zero - de la presentation) a la fin de la presentation.
```php
  # Instancie la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clone la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Enregistre la présentation modifiée sur le disque
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Cloner une diapositive a une autre position dans une presentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le meme fichier de presentation mais a une position différente, utilisez la methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instancier la classe en referencant la collection **Slides** exposee par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Appeler la methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposee par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et transmettre la diapositive a cloner ainsi que l'index pour la nouvelle position comme parametres a la methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ecrire la presentation modifiee en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons clone une diapositive (située à l'indice zero - position 1 - de la presentation) a l'indice 1 - Position 2 - de la presentation.
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    # Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Enregistrer la présentation modifiée sur le disque
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Cloner une diapositive a la fin d'une autre presentation**
Si vous devez cloner une diapositive d'une presentation et l'utiliser dans un autre fichier de presentation, a la fin des diapositives existantes:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation dont la diapositive sera clonee.
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation de destination a laquelle la diapositive sera ajoutee.
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) en referencant la collection **Slides** exposee par l'objet Presentation de la presentation de destination.
1. Appeler la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposee par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et transmettre la diapositive de la presentation source comme parametre a la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ecrire le fichier de presentation de destination modifie.

Dans l'exemple ci-dessous, nous avons clone une diapositive (du premier indice de la presentation source) a la fin de la presentation destination.
```php
  # Instancier la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive sera clonée)
    $destPres = new Presentation();
    try {
      # Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Enregistrer la présentation de destination sur le disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Cloner une diapositive a une autre position dans une autre presentation**
Si vous devez cloner une diapositive d'une presentation et l'utiliser dans un autre fichier de presentation, a une position specifique:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation source dont la diapositive sera clonee.
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation a laquelle la diapositive sera ajoutee.
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en referencant la collection Slides exposee par l'objet Presentation de la presentation de destination.
1. Appeler la methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposee par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et transmettre la diapositive de la presentation source ainsi que la position desiree comme parametres a la methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Ecrire le fichier de presentation de destination modifie.

Dans l'exemple ci-dessous, nous avons clone une diapositive (du zero indice de la presentation source) a l'indice 1 (position 2) de la presentation destination.
```php
  # Instancier la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    $destPres = new Presentation();
    try {
      # Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Enregistrer la présentation de destination sur le disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Cloner une diapositive a une position specifique dans une autre presentation**
Si vous devez cloner une diapositive avec une diapositive maitre d'une presentation et l'utiliser dans une autre presentation, vous devez d'abord cloner la diapositive maitre desiree de la presentation source vers la presentation destination. Ensuite vous devez utiliser ce maitre pour cloner la diapositive avec maitre. La methode [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) attend un maitre provenant de la presentation destination plutot que de la source. Pour cloner la diapositive avec maitre, veuillez suivre les etapes ci-dessous:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation source dont la diapositive sera clonee.
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la presentation destination vers laquelle la diapositive sera clonee.
1. Acceder a la diapositive a cloner ainsi que son maitre.
1. Instancier la classe [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) en referencant la collection Masters exposee par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentation destination.
1. Appeler la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposee par l'objet [IMasterSlideCollection] et transmettre le maitre de la presentation source a cloner comme parametre a la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en definissant la reference a la collection Slides exposee par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la presentation destination.
1. Appeler la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposee par l'objet [ISlideCollection] et transmettre la diapositive de la presentation source a cloner ainsi que le maitre comme parametres a la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Ecrire le fichier de presentation destination modifie.

Dans l'exemple ci-dessous, nous avons clone une diapositive avec un maitre (située au zero indice de la presentation source) a la fin de la presentation destination en utilisant un maitre de la diapositive source.
```php
  # Instancier la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    $destPres = new Presentation();
    try {
      # Instancier ISlide à partir de la collection de diapositives de la présentation source avec
      # Diapositive maître
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
      # Présentation de destination
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
      # Présentation de destination
      $iSlide = $masters->addClone($SourceMaster);
      # Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin du
      # Collection de diapositives de la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Enregistrer la présentation de destination sur le disque
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Cloner une diapositive a la fin d'une section specifiee**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le meme fichier de presentation mais dans une section differente, utilisez la methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposee par l'interface [ISlideCollection]. Aspose.Slides pour PHP via Java rend possible le clonage d'une diapositive de la premiere section puis l'insertion de cette diapositive clonee dans la deuxieme section de la meme presentation.

Le fragment de code suivant montre comment cloner une diapositive et inserer la diapositive clonee dans une section specifiee.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Enregistrer la présentation de destination sur le disque
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Les notes du presentateur et les commentaires des releveurs sont-ils clones ?**

Oui. La page de notes et les commentaires de revision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez-les](/slides/fr/php-java/presentation-notes/) apres l'insertion.

**Comment les graphiques et leurs sources de donnees sont-ils geres ?**

L'objet graphique, son formatage et les donnees incorporees sont copies. Si le graphique etait lie a une source externe (par ex., un classeur OLE incorpore), ce lien est conserve sous forme d'[objet OLE](/slides/fr/php-java/manage-ole/). Apres le deplacement entre fichiers, verifiez la disponibilite des donnees et le comportement de rafraichissement.

**Puis-je controler la position d'insertion et les sections du clone ?**

Oui. Vous pouvez inserer le clone a un indice de diapositive specifique et le placer dans une [section](/slides/fr/php-java/slide-section/) choisie. Si la section cible n'existe pas, creez-la d'abord puis deplacez la diapositive dedans.