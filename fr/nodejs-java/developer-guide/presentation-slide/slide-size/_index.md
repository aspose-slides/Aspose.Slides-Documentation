---
title: Taille de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-size/
---

## **Tailles de diapositives dans les présentations PowerPoint**

Aspose.Slides for Node.js via Java vous permet de modifier la taille ou le rapport d'aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez prêter attention à leur taille ou à leur rapport d'aspect.

Voici les tailles de diapositives et rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous pouvez souhaiter utiliser ce réglage. 

- **Écran large (rapport d'aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou écrans modernes, vous pouvez souhaiter utiliser ce réglage. 

Vous ne pouvez pas utiliser plusieurs réglages de taille de diapositive dans une même présentation. Lorsque vous choisissez une taille de diapositive pour une présentation, ce réglage s'applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons vivement de le faire tôt. Idéalement, vous devez spécifier la taille souhaitée dès le départ, c'est-à-dire lors de la configuration initiale de la présentation - avant d'ajouter tout contenu. Ainsi, vous évitez les complications dues aux modifications (futures) de la taille des diapositives. 

{{% alert color="primary" %}} 

Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d'aspect 4:3.

{{% /alert %}} 

## **Modifier la taille de la diapositive dans les présentations**

Ce code d'exemple vous montre comment modifier la taille de la diapositive d'une présentation en JavaScript avec Aspose.Slides :
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


## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, il est probable que l'utilisation d'un réglage de taille personnalisé vous soit bénéfique.

Ce code d'exemple vous montre comment utiliser Aspose.Slides for Node.js via Java pour spécifier une taille de diapositive personnalisée pour une présentation en JavaScript :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// taille de papier A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer les problèmes lors du changement de taille des diapositives dans les présentations**

Après avoir modifié la taille des diapositives d'une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont redimensionnés automatiquement pour s'adapter à la nouvelle taille. Cependant, lors du changement de la taille des diapositives d'une présentation, vous pouvez spécifier un réglage qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

Selon ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l'un de ces réglages :

- `DoNotScale`

  Si vous NE voulez PAS que les objets des diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives afin qu'ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce réglage. 

- `Maximize`

  Si vous souhaitez augmenter la taille des diapositives et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce réglage. 

Ce code d'exemple vous montre comment utiliser le réglage `Maximize` lors du changement de taille d'une diapositive de présentation :
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

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/nodejs-java/merge-presentation/) tant qu'elles ont des tailles de diapositive différentes - d'abord, redimensionnez une présentation pour correspondre à l'autre. Lors du changement de la taille des diapositives, vous pouvez choisir comment le contenu existant est géré via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/). Après avoir harmonisé les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d'une diapositive, et respecteront-elles la nouvelle taille de la diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [entire slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) ainsi que pour [selected shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage). Les images résultantes reflètent la taille et le rapport d'aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.