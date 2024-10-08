---
title: Taille de la diapositive
type: docs
weight: 70
url: /fr/java/slide-size/

---

## Tailles de Diapositive dans les Présentations PowerPoint

Aspose.Slides pour Java vous permet de changer la taille de la diapositive ou le format d'aspect dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez prêter attention à la taille de sa diapositive ou au format d'aspect. 

Voici les tailles de diapositive et les formats d'aspect les plus courants :

- **Standard (format d'aspect 4:3)**

  Si votre présentation va être affichée ou vue sur des appareils ou écrans relativement anciens, vous voudrez peut-être utiliser ce paramètre.

- **Widescreen (format d'aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou affichages modernes, vous voudrez peut-être utiliser ce paramètre.

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une seule présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce paramètre de taille de diapositive s'applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier votre taille de diapositive préférée au début, c'est-à-dire lorsque vous êtes juste en train de configurer la présentation — avant d'ajouter du contenu à la présentation. De cette manière, vous évitez les complications résultant des modifications (futures) apportées à la taille des diapositives. 

{{% alert color="primary" %}} 

 Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le format d'aspect 4:3.

{{% /alert %}} 

## Changer la Taille de la Diapositive dans les Présentations 

 Cet exemple de code vous montre comment changer la taille de la diapositive dans une présentation en Java en utilisant Aspose.Slides :

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Spécifier des Tailles de Diapositive Personnalisées dans les Présentations

Si vous trouvez que les tailles de diapositive courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives à taille réelle de votre présentation sur un layout de page personnalisé ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, il est probable que vous bénéficierez de l'utilisation d'un paramètre de taille personnalisé pour votre présentation. 

Cet exemple de code vous montre comment utiliser Aspose.Slides pour Java pour spécifier une taille de diapositive personnalisée pour une présentation en Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Traiter les Problèmes Lors du Changement de la Taille des Diapositives dans les Présentations

Après avoir changé la taille de la diapositive pour une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de la diapositive. Cependant, lorsque vous changez la taille de la diapositive d'une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides traite le contenu sur les diapositives.

En fonction de ce que vous avez l'intention de faire ou d'atteindre, vous pouvez utiliser l'un de ces paramètres :

- `DoNotScale`

  Si vous ne voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez redimensionner à une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives pour s'assurer qu'ils tiennent tous sur les diapositives (de cette manière, vous évitez de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez redimensionner à une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce paramètre. 

Cet exemple de code vous montre comment utiliser le paramètre `Maximize` lors du changement de la taille de la diapositive d'une présentation :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```