---
title: Modifier la taille des diapositives de la présentation en JavaScript
linktitle: Taille des diapositives
type: docs
weight: 70
url: /fr/nodejs-java/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d'écran
- ne pas mettre à l'échelle
- adapter
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Node.js et Aspose.Slides, optimiser les présentations pour tout type d'écran sans perdre de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran. 

Tailles de diapositives courantes et rapports :

- **Standard (ratio d’aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.
- **Grand écran (ratio d’aspect 16:9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de l’ensemble de votre présentation, car une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d’éviter des complications.

{{% alert color="info" title="Note" %}}
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d’aspect standard 4:3.
{{% /alert %}}

Les pages de notes et de documents ont des dimensions distinctes des diapositives ordinaires. Consultez [Notes Page Size](/slides/fr/nodejs-java/notes-size/) pour modifier leur taille et orientation.

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille des diapositives d’une présentation en JavaScript avec Aspose.Slides :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives pleine taille à partir de votre présentation sur une mise en page de page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficierez de l’utilisation d’un paramètre de taille personnalisée pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides for Node.js via Java pour spécifier une taille de diapositive personnalisée pour une présentation en JavaScript :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Taille du papier A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gérer les problèmes lors du changement de taille des diapositives dans les présentations**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont redimensionnés automatiquement pour s’ajuster à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides gère le contenu des diapositives.

Selon ce que vous avez l’intention de faire ou d’obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous NE souhaitez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire à une taille de diapositive plus petite et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives afin qu’ils tiennent tous sur les diapositives (ainsi vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez agrandir à une taille de diapositive plus grande et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de taille des diapositives d’une présentation :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

**Puis‑je définir une taille de diapositive personnalisée avec des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affecte‑t‑elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis‑je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/nodejs-java/merge-presentation/) lorsqu’elles ont des tailles de diapositives différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. En modifiant la taille de la diapositive, vous pouvez choisir la façon dont le contenu existant est traité via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis‑je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getImage). Les images générées reflètent la taille et le ratio d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.