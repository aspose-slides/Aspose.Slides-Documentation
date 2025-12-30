---
title: Spécifier les polices par défaut de la présentation en PHP
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/php-java/default-font/
keywords:
- police par défaut
- police régulière
- police normale
- police asiatique
- exportation PDF
- exportation XPS
- exportation d'images
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Définissez les polices par défaut dans Aspose.Slides pour PHP via Java afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) en PDF, XPS et images."
---

## **Utiliser les polices par défaut pour le rendu d’une présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou miniatures. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont à utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices depuis des répertoires externes à l’aide d’Aspose.Slides pour PHP via l’API Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) à la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) à la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.
4. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
5. Ensuite, générez les miniatures de diapositives, le PDF et le XPS pour vérifier les résultats.

L’implémentation ci‑dessus est fournie ci‑après.
```php
  # Utiliser les options de chargement pour définir les polices régulières et asiatiques par défaut
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Charger la présentation
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Générer la miniature de la diapositive
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # enregistrer l'image sur le disque.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Générer le PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Générer le XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Qu’est‑ce que DefaultRegularFont et DefaultAsianFont affectent exactement — seulement l’exportation, ou aussi les miniatures, PDF, XPS, HTML et SVG ?**

Ils participent au pipeline de rendu pour toutes les sorties prises en charge. Cela comprend les miniatures de diapositives, [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/), [images raster](/slides/fr/php-java/convert-powerpoint-to-png/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), et [SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut sont importantes lorsque le texte doit être mesuré et dessiné. Un simple en‑registrement ouvert‑fermé d’une présentation ne modifie pas les jeux de caractères stockés ni la structure du fichier. Les polices par défaut interviennent lors des opérations qui rendent ou réorganisent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. Les [sources de polices personnalisées](/slides/fr/php-java/custom-font/) élargissent le catalogue de familles et de glyphes disponibles que le moteur peut utiliser. Les polices par défaut et les [règles de secours](/slides/fr/php-java/fallback-font/) seront résolues en priorité à partir de ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police change les métriques des glyphes et peut modifier les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour la stabilité de la mise en page, [intégrez les polices d’origine](/slides/fr/php-java/embedded-font/) ou choisissez des familles par défaut et de secours compatibles sur le plan métrique.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont incorporées ?**

Souvent ce n’est pas nécessaire, car les [polices incorporées](/slides/fr/php-java/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble incorporé ou lorsqu’un fichier combine du texte incorporé et non incorporé.