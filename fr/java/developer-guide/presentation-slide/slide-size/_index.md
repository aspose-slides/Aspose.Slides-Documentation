---
title: Modifier la taille des diapositives de la présentation en Java
linktitle: Taille des diapositives
type: docs
weight: 70
url: /fr/java/slide-size/
keywords:
- taille des diapositives
- rapport d’aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille des diapositives
- modifier la taille des diapositives
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
description: "Apprenez comment redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Java et Aspose.Slides, optimisez les présentations pour n’importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran.

Tailles de diapositives et rapports d’aspect courants :

- **Standard (rapport d’aspect 4 : 3)** : Idéal pour les écrans et appareils plus anciens.  
- **Grand écran (rapport d’aspect 16 : 9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez la cohérence de toute votre présentation, car une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création afin d’éviter des complications.

{{% alert color="primary" %}}Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4 : 3.{{% /alert %}}

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

Si les tailles de diapositives courantes (4 : 3 et 16 : 9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page de page personnalisée ou si vous devez afficher votre présentation sur certains types d’écrans, vous tirerez parti d’un réglage de taille personnalisée pour votre présentation.

Ce code d’exemple montre comment utiliser Aspose.Slides for Java pour spécifier une taille de diapositive personnalisée dans une présentation en Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se distordre. Par défaut, les objets sont redimensionnés automatiquement pour s’adapter à la nouvelle taille. Cependant, lors du changement de la taille des diapositives, vous pouvez spécifier un paramètre déterminant la façon dont Aspose.Slides gère le contenu des diapositives.

Selon ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces réglages :

- `DoNotScale`

  Si vous NE VOULEZ PAS que les objets des diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous voulez réduire la taille des diapositives et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives afin qu’ils tiennent tous (cela évite la perte de contenu), utilisez ce réglage.

- `Maximize`

  Si vous voulez agrandir la taille des diapositives et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour qu’ils restent proportionnels à la nouvelle taille, utilisez ce réglage.

Ce code d’exemple montre comment utiliser le réglage `Maximize` lors du changement de la taille des diapositives d’une présentation :

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

Oui. Aspose.Slides utilise les points en interne, où 1 point = 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (telle que millimètre ou centimètre) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/java/merge-presentation/) tant qu’elles ont des tailles de diapositives différentes — redimensionnez d’abord une présentation pour qu’elle corresponde à l’autre. En modifiant la taille des diapositives, vous pouvez choisir comment le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.