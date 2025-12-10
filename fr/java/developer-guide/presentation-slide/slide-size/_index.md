---
title: Modifier la taille des diapositives de la présentation en Java
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/java/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive en pleine taille
- type d'écran
- ne pas mettre à l'échelle
- garantir l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
descriptions: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Java et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perte de qualité."
---

## **Tailles de diapositive dans les présentations PowerPoint**

Aspose.Slides for Java vous permet de modifier la taille ou le rapport d'aspect d'une diapositive dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à la taille ou au rapport d'aspect des diapositives. 

Voici les tailles de diapositive et les rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous pouvez choisir ce paramètre. 

- **Écran large (rapport d'aspect 16:9)** 

  Si votre présentation doit être visualisée sur des projecteurs ou écrans modernes, vous pouvez choisir ce paramètre. 

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une même présentation. Lorsque vous choisissez une taille de diapositive pour une présentation, ce paramètre s'applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons vivement de le faire tôt. Idéalement, vous devez spécifier votre taille de diapositive préférée dès le début, c’est‑à‑dire lors de la création de la présentation—avant d’ajouter tout contenu. Ainsi, vous éviterez les complications liées aux modifications (futures) de la taille des diapositives. 

{{% alert color="primary" %}} 
Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d'aspect 4:3.
{{% /alert %}} 

## **Modifier la taille des diapositives dans les présentations**

Ce code d'exemple vous montre comment modifier la taille d'une diapositive dans une présentation en Java à l'aide d'Aspose.Slides :
```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Spécifier des tailles de diapositive personnalisées dans les présentations**

Si les tailles de diapositive courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page de page personnalisée ou si vous souhaitez afficher votre présentation sur certains types d'écrans, il est probable que l'utilisation d'un paramètre de taille personnalisée vous soit bénéfique. 

Ce code d'exemple vous montre comment utiliser Aspose.Slides for Java pour spécifier une taille de diapositive personnalisée pour une présentation en Java :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // taille papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d'une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de la diapositive. Cependant, lors du changement de la taille des diapositives d'une présentation, vous pouvez spécifier un paramètre qui détermine la manière dont Aspose.Slides gère le contenu des diapositives. 

Selon ce que vous avez l'intention de faire ou d'atteindre, vous pouvez utiliser l'un de ces paramètres :

- `DoNotScale`

  Si vous ne voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous voulez réduire à une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives afin de garantir qu'ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous voulez agrandir à une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides augmente les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce code d'exemple vous montre comment utiliser le paramètre `Maximize` lors du changement de la taille d'une diapositive de présentation :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (telle que les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive. 

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée. 

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/java/merge-presentation/) lorsqu'elles ont des tailles de diapositives différentes — redimensionnez d'abord une présentation pour qu'elle corresponde à l'autre. En changeant la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant la mise en forme. 

**Puis-je générer des vignettes pour des formes individuelles ou des régions spécifiques d'une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des vignettes pour [toutes les diapositives](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d'aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.