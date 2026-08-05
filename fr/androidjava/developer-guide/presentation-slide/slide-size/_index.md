---
title: Modifier la taille des diapositives de la présentation sur Android
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- format large
- 4:3
- 16:9
- definir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisee
- taille de diapositive speciale
- taille de diapositive unique
- diapositive en taille reelle
- type d'ecran
- ne pas redimensionner
- garantir l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Redimensionnez rapidement les diapositives des fichiers PPT, PPTX et ODP avec Java et Aspose.Slides pour Android, optimisez les presentations pour n'importe quel ecran sans perte de qualite."
---
## **Introduction**

Aspose.Slides propose des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran. 

Taille et rapports d’aspect populaires des diapositives :

- **Standard (ratio 4:3)** : Idéal pour les écrans et appareils plus anciens.  
- **Widescreen (ratio 16:9)** : Recommandé pour les projecteurs et écrans modernes.  

Assurez la cohérence de votre présentation, une taille de diapositive et un rapport d’aspect uniques s’appliquant à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives dès le début du processus de création de la présentation afin d’éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio standard 4 : 3.
{{% /alert %}}

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille des diapositives d’une présentation en Java avec Aspose.Slides :

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4 : 3 et 16 : 9) ne conviennent pas à votre travail, vous pouvez choisir d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle depuis votre présentation sur une mise en page personnalisée ou si vous souhaitez afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficiiez d’un paramètre de taille personnalisé pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides pour Android via Java afin de spécifier une taille de diapositive personnalisée pour une présentation en Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // format papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’ajuster à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale` : Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit` : Si vous souhaitez réduire à une taille de diapositive plus petite et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives pour garantir qu’ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize` : Si vous souhaitez augmenter à une taille de diapositive plus grande et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de la taille d’une diapositive de présentation :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/androidjava/merge-presentation/) lorsque les présentations ont des tailles de diapositive différentes — vous devez d’abord redimensionner une présentation pour qu’elle corresponde à l’autre. En changeant la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [entire slides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [selected shapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Les images générées reflètent la taille actuelle de la diapositive et le rapport d’aspect, garantissant un cadrage et une géométrie cohérents.