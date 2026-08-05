---
title: Changer la taille des diapositives de la présentation en JavaScript
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-size/
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
- garantir l’ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Node.js et Aspose.Slides, et à optimiser les présentations pour n’importe quel écran sans perdre de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l’impression que pour l’affichage à l’écran.

Tailles de diapositives et rapports courants :

- **Standard (Rapport d’aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.
- **Écran large (Rapport d’aspect 16:9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez-vous de la cohérence de votre présentation, une taille de diapositive et un rapport d’aspect uniques s’appliquant à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives au début du processus de création de votre présentation afin d’éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4:3.
{{% /alert %}}

## **Modification de la taille des diapositives dans les présentations**

Cet exemple de code montre comment modifier la taille des diapositives d’une présentation en JavaScript à l’aide d’Aspose.Slides :

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Spécification de tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, vous tirerez probablement profit d’un paramètre de taille personnalisée pour votre présentation.

Cet exemple de code montre comment utiliser Aspose.Slides pour Node.js via Java afin de spécifier une taille de diapositive personnalisée pour une présentation en JavaScript :

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestion des problèmes lors de la modification de la taille des diapositives dans les présentations**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille des diapositives. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine la manière dont Aspose.Slides traite le contenu des diapositives.

Selon ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous NE voulez PAS que les objets des diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et avez besoin qu’Aspose.Slides réduise les objets des diapositives afin de garantir qu’ils tiennent tous sur les diapositives (ainsi, vous évitez la perte de contenu), utilisez ce paramètre.

- `Maximize`

  Si vous voulez agrandir la taille des diapositives et avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre.

Cet exemple de code montre comment utiliser le paramètre `Maximize` lors du changement de la taille des diapositives d’une présentation :

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (telle que les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur des diapositives.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points), combinées à une échelle de rendu plus élevée, entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive raisonnable et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/nodejs-java/merge-presentation/) tant qu’elles ont des tailles de diapositives différentes — commencez par redimensionner une présentation pour correspondre à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est traité via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant la mise en forme.

**Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [l’ensemble des diapositives](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getImage). Les images obtenues reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.