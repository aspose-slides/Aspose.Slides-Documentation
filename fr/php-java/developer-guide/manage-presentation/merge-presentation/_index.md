---
title: Fusionner la présentation
type: docs
weight: 40
url: /fr/php-java/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, Java"
description: "Fusionnez ou combinez une présentation PowerPoint"
---

{{% alert title="Astuce" color="primary" %}} 

Vous voudrez peut-être consulter l'**application Merger en ligne gratuite d'Aspose** [ici](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT à PPT, PPTX à PPTX, etc.) et de fusionner des présentations dans différents formats (PPT à PPTX, PPTX à ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 

## **Fusion des présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives en une seule présentation pour obtenir un fichier. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) manquent de fonctions qui permettent aux utilisateurs de combiner des présentations de cette manière. 

Cependant, [**Aspose.Slides pour PHP via Java**](https://products.aspose.com/slides/php-java/) vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mises en forme, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données.

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT à PPT, PPTX à PPTX, etc.) et dans différents formats (PPT à PPTX, PPTX à ODP, etc.) les unes avec les autres. 

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/php-java/merger/image-to-image/), telles que [JPG à JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) ou [PNG à PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Documents, tels que [PDF à PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) ou [HTML à HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Et deux fichiers différents tels que [image à PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) ou [JPG à PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) ou [TIFF à PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive dans la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives dans la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de l'interface [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation a une collection [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) afin que vous puissiez appeler une méthode `AddClone` à partir de la présentation avec laquelle vous souhaitez fusionner les diapositives.

La méthode `AddClone` retourne un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives de la source. Par conséquent, vous pouvez apporter des modifications aux diapositives résultantes (par exemple, appliquer des styles ou des options de mise en forme ou des mises en page) sans vous soucier de l'impact sur les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut).

Ce code PHP vous montre comment fusionner des présentations :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Fusionner des présentations avec le maître de diapositives**

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation maître de diapositives. De cette manière, si nécessaire, vous pouvez changer le style des diapositives dans la présentation de sortie.

Ce code démontre l'opération décrite :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

La mise en page de la diapositive pour le maître de diapositives est déterminée automatiquement. Lorsqu'une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) sera déclenchée.

{{% /alert %}}

Si vous souhaitez que les diapositives dans la présentation de sortie aient une mise en page différente, utilisez la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) à la place lors de la fusion.

## **Fusionner des diapositives spécifiques depuis des présentations**

Ce code PHP vous montre comment sélectionner et combiner des diapositives spécifiques de différentes présentations pour obtenir une présentation de sortie :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Fusionner des présentations avec mise en page de diapositive**

Ce code PHP vous montre comment combiner des diapositives de présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Fusionner des présentations avec différentes tailles de diapositives**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec différentes tailles de diapositives. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositives différentes, vous devez redimensionner l'une des présentations pour qu'elle corresponde à la taille de l'autre présentation. 

Ce code d'exemple démontre l'opération décrite :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Fusionner des diapositives dans une section de présentation**

Ce code PHP vous montre comment fusionner une diapositive spécifique dans une section d'une présentation :

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

La diapositive est ajoutée à la fin de la section. 

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner [JPG à JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG à PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

{{% /alert %}}