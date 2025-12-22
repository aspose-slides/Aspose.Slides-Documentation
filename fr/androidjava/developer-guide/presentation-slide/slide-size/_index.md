---
title: Modifier la taille de la diapositive de présentation sur Android
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir taille de diapositive
- changer taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
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
descriptions: "Redimensionnez rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Java et Aspose.Slides pour Android, optimisez les présentations pour n'importe quel écran sans perdre de qualité."
---

## **Taille des diapositives dans les présentations PowerPoint**

Aspose.Slides for Android via Java vous permet de modifier la taille ou le rapport d’aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à la taille ou au rapport d’aspect des diapositives.

Ce sont les tailles de diapositives et rapports d’aspect les plus courants :

- **Standard (rapport d’aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous pouvez vouloir utiliser ce paramètre. 

- **Écran large (rapport d’aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou écrans modernes, vous pouvez vouloir utiliser ce paramètre. 

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une même présentation. Lorsque vous choisissez une taille de diapositive pour une présentation, ce paramètre s’applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier la taille de diapositive souhaitée dès le départ, c’est‑à‑dire lors de la configuration initiale de la présentation—avant d’ajouter tout contenu. Ainsi, vous éviterez les complications dues aux modifications (futures) de la taille des diapositives. 

{{% alert color="primary" %}} 

Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d’aspect 4:3.

{{% /alert %}} 

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation en Java en utilisant Aspose.Slides :
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

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en pleine taille à partir de votre présentation sur une mise en page de page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficiiez d’un paramètre de taille personnalisée pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides for Android via Java pour spécifier une taille de diapositive personnalisée pour une présentation en Java :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // format papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous ne voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire à une taille de diapositive plus petite et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives pour qu’ils tiennent tous sur les diapositives (ainsi vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez agrandir à une taille de diapositive plus grande et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

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

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que des pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise des points en interne, où 1 point vaut 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/androidjava/merge-presentation/) tant qu’elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour correspondre à l’autre. Lors du changement de la taille de la diapositive, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut générer des miniatures pour [diapositives entières](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [formes sélectionnées](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.