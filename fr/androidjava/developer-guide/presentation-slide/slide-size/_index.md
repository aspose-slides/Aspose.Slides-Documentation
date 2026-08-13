---
title: Modifier la taille des diapositives de la présentation sur Android
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive en plein format
- type d'écran
- ne pas mettre à l'échelle
- assurer l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Redimensionnez rapidement les diapositives des fichiers PPT, PPTX et ODP avec Java et Aspose.Slides pour Android, optimisez les présentations pour n'importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d'aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l'impression que pour l'affichage à l'écran. 

Tailles de diapositives populaires et rapports :

- **Standard (ratio d'aspect 4:3)** : Idéal pour les anciens écrans et appareils.
- **Widescreen (ratio d'aspect 16:9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, car une seule taille de diapositive et un seul rapport d'aspect s'appliquent à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d'éviter les complications.

{{% alert color="info" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d'aspect standard 4:3.
{{% /alert %}}

## **Modifier la taille des diapositives dans les présentations**

Ce code d'exemple montre comment modifier la taille d'une diapositive dans une présentation en Java en utilisant Aspose.Slides :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4 :3 et 16 :9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives pleine taille de votre présentation sur une mise en page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, il est probable que l'utilisation d'un réglage de taille personnalisée pour votre présentation vous soit bénéfique. 

Ce code d'exemple montre comment utiliser Aspose.Slides pour Android via Java afin de spécifier une taille de diapositive personnalisée pour une présentation en Java :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille du papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après avoir modifié la taille des diapositives d'une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille des diapositives. Cependant, lors du changement de la taille des diapositives d'une présentation, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives. 

En fonction de ce que vous avez l'intention de faire ou d'atteindre, vous pouvez utiliser l'un de ces paramètres :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et avez besoin qu'Aspose.Slides réduise les objets des diapositives afin de garantir qu'ils tiennent tous sur les diapositives (ainsi, vous évitez la perte de contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez augmenter la taille des diapositives et avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille des diapositives, utilisez ce paramètre. 

Ce code d'exemple montre comment utiliser le paramètre `Maximize` lors du changement de la taille d'une diapositive de présentation :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que le pouce (par exemple, points ou millimètres) ?

Oui. Aspose.Slides utilise des points en interne, où 1 point correspond à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

### Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?

Oui. Des dimensions de diapositive plus grandes (en points) combinées à un facteur de rendu plus élevé entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez le facteur de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

### Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?

Vous ne pouvez pas [merge presentations](/slides/fr/androidjava/merge-presentation/) tant qu'elles ont des tailles de diapositives différentes — commencez par redimensionner une présentation pour l'adapter à l'autre. Lors du changement de la taille des diapositives, vous pouvez choisir comment le contenu existant est géré via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

### Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d'une diapositive, et seront-elles respectueuses de la nouvelle taille de diapositive ?

Oui. Aspose.Slides peut rendre des miniatures pour [diapositives complètes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [formes sélectionnées](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d'aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.