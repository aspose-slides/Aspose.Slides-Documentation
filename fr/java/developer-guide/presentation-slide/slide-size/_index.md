---
title: Modifier la taille des diapositives de la présentation en Java
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/java/slide-size/
keywords:
- taille de diapositive
- rapport d’aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d’écran
- ne pas mettre à l’échelle
- assurer l’ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Java et Aspose.Slides, optimisez les présentations pour n’importe quel écran sans perdre en qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l’impression que pour l’affichage à l’écran. 

Tailles de diapositives et rapports d’aspect courants :

- **Standard (rapport d’aspect 4 : 3)** : Idéal pour les écrans et appareils plus anciens.
- **Widescreen (rapport d’aspect 16 : 9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez la cohérence de votre présentation, car une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives dès le début du processus de création de la présentation afin d’éviter les complications.

{{% alert color="info" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4 : 3.
{{% /alert %}}

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation en Java avec Aspose.Slides :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4 : 3 et 16 : 9) ne conviennent pas à votre travail, vous pouvez choisir d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle depuis votre présentation sur une mise en page de page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficiez d’un réglage de taille personnalisée pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides pour Java afin de spécifier une taille de diapositive personnalisée pour une présentation en Java :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // taille papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et avez besoin qu’Aspose.Slides réduise les objets des diapositives afin de garantir qu’ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez agrandir la taille des diapositives et avez besoin qu’Aspose.Slides augmente les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce paramètre. 

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de la taille d’une diapositive de présentation :

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

### Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

### Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

### Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?

Vous ne pouvez pas [fusionner des présentations](/slides/fr/java/merge-presentation/) tant qu’elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant la mise en forme.

### Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.