---
title: Cloner des diapositives
type: docs
weight: 35
url: /php-java/cloner-des-diapositives/
---

## **Cloner des Diapositives dans une Présentation**
Le clonage est le processus de création d'une copie exacte ou d'une réplique de quelque chose. Aspose.Slides pour PHP via Java permet également de faire une copie ou un clone de n'importe quelle diapositive, puis d'insérer cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositives crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer l'original. Il existe plusieurs manières possibles de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans la présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour PHP via Java, (une collection d'[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) objets) exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) fournit les méthodes [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pour effectuer les types de clonage de diapositives ci-dessus.

## **Cloner à la Fin d'une Présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) selon les étapes listées ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en faisant référence à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Écrivez le fichier de présentation modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à la première position – index zéro – de la présentation) à la fin de la présentation.

```php
  # Instanciez la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Écrivez la présentation modifiée sur disque
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Cloner à une Autre Position dans la Présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instanciez la classe en référant la collection [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner ainsi que l'index pour la nouvelle position comme paramètre à la méthode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.

```php
  # Instanciez la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    $slds = $pres->getSlides();
    # Clonez la diapositive souhaitée à l'index spécifié dans la même présentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Écrivez la présentation modifiée sur disque
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Cloner à la Fin d'une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) en référant la collection de [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (de l'index premier de la présentation source) à la fin de la présentation de destination.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciez la classe Presentation pour PPTX de destination (où la diapositive doit être clonée)
    $destPres = new Presentation();
    try {
      # Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Écrivez la présentation de destination sur disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Cloner à Une Autre Position dans une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en référant la collection de diapositives exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source ainsi que la position souhaitée comme paramètre à la méthode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (de l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciez la classe Presentation pour PPTX de destination (où la diapositive doit être clonée)
    $destPres = new Presentation();
    try {
      # Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Écrivez la présentation de destination sur disque
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Cloner à une Position Spécifique dans une Autre Présentation**
Si vous devez cloner une diapositive avec un master d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner le master souhaité de la présentation source vers la présentation de destination. Ensuite, vous devez utiliser ce master pour cloner la diapositive avec le master. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) attend un master de la présentation de destination plutôt que de la présentation source. Pour cloner la diapositive avec un master, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant la présentation de destination dans laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'au master.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) en référant la collection de Masters exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) et passez le master de la source PPTX à cloner comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) en mettant la référence à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source à cloner et le master comme paramètre à la méthode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive avec un master (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant un master de la diapositive source.

```php
  # Instanciez la classe Presentation pour charger le fichier de présentation source
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciez la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    $destPres = new Presentation();
    try {
      # Instanciez ISlide à partir de la collection de diapositives dans la présentation source avec
      # Master slide
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonez le master souhaité de la présentation source vers la collection de masters dans la
      # Présentation de destination
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonez le master souhaité de la présentation source vers la collection de masters dans la
      # Présentation de destination
      $iSlide = $masters->addClone($SourceMaster);
      # Clonez la diapositive souhaitée de la présentation source avec le master souhaité à la fin de la
      # Collection de diapositives dans la présentation de destination
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Sauvegardez la présentation de destination sur disque
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Cloner à la Fin dans une Section Spécifiée**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposée par l'interface [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). Aspose.Slides pour PHP via Java permet de cloner une diapositive de la première section et d'insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le snippet de code suivant vous montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Sauvegardez la présentation de destination sur disque
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```