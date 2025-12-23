---
title: Fusionner efficacement des présentations en PHP
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/php-java/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner des présentations
- fusionner des diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- PHP
- Aspose.Slides
description: "Fusionnez facilement des présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour PHP via Java, en simplifiant votre flux de travail."
---

## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), cependant, vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mises en forme, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données.

**Voir aussi**

[Cloner les diapositives](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT en PPT, PPTX en PPTX, etc.) et dans des formats différents (PPT en PPTX, PPTX en ODP, etc.) les unes avec les autres. 

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* **Images**, comme [JPG en JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) ou [PNG en PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* **Documents**, comme [PDF en PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) ou [HTML en HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Et deux fichiers différents tels que [image en PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/), [JPG en PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) ou [TIFF en PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation résultante conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation résultante. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de l’interface [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ; vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner des diapositives.

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives de la présentation résultante sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives obtenues (par exemple, appliquer des styles, des options de mise en forme ou des mises en page) sans craindre d’affecter les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et leurs styles (paramètres par défaut).

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


## **Fusionner des présentations avec un masque de diapositive** 

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui vous permet de combiner des diapositives tout en appliquant un modèle de masque de diapositive. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation résultante.

Ce code montre l’opération décrite :
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

La mise en page de la diapositive du masque est déterminée automatiquement. Lorsqu’aucune mise en page appropriée ne peut être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est à true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation résultante aient une mise en page différente, utilisez plutôt la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lors de la fusion.

## **Fusionner des diapositives spécifiques à partir de présentations** 

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des jeux de diapositives personnalisés. Aspose.Slides for PHP via Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve la mise en forme, la disposition et le design des diapositives d’origine.

Le code PHP suivant crée une nouvelle présentation, ajoute des diapositives de titre provenant de deux autres présentations, puis enregistre le résultat dans un fichier :
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **Fusionner des présentations avec une mise en page de diapositive** 

Ce code PHP vous montre comment combiner des diapositives de présentations tout en appliquant votre mise en page de diapositive préférée afin d’obtenir une présentation de sortie unique :
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


## **Fusionner des présentations avec différentes tailles de diapositive** 

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner deux présentations dont les tailles de diapositive diffèrent, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre.

Ce code d’exemple montre l’opération décrite :
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

Ce code PHP vous montre comment fusionner une diapositive spécifique dans une section d’une présentation :
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

## **Voir aussi**


Aspose propose un [FREE Online Collage Maker](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid) et bien plus encore.

Découvrez le [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). Il vous permet de fusionner des présentations PowerPoint dans le même format (par ex., PPT en PPT, PPTX en PPTX) ou entre différents formats (par ex., PPT en PPTX, PPTX en ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**Existe‑t‑il des limitations concernant le nombre de diapositives lors de la fusion de présentations ?**

Aucune limitation stricte. Aspose.Slides peut gérer de gros fichiers, mais les performances dépendent de la taille du fichier et des ressources système. Pour des présentations très volumineuses, il est recommandé d’utiliser une JVM 64 bits et d’allouer suffisamment de mémoire heap.

**Puis‑je fusionner des présentations contenant des vidéos ou des audios intégrés ?**

Oui, Aspose.Slides préserve le contenu multimédia intégré aux diapositives, mais la présentation finale peut devenir sensiblement plus grande.

**Les polices seront‑elles préservées lors de la fusion de présentations ?**

Oui. Les polices utilisées dans les présentations sources sont conservées dans le fichier de sortie, à condition qu’elles soient installées sur le système ou [intégrées](/slides/fr/php-java/embedded-font/).