---
title: Taille de diapositive
type: docs
weight: 70
url: /net/slide-size/
keywords: "Définir la diapositive, modifier la taille de la diapositive, Présentation PowerPoint, taille de diapositive personnalisée, résoudre les problèmes de diapositive, C#, Csharp, .NET, Aspose.Slides"
descriptions: "Définir et modifier la taille de la diapositive ou le format d'aspect dans PowerPoint en C# ou .NET"
---

## Tailles de Diapositive dans les Présentations PowerPoint

Aspose.Slides pour .NET vous permet de changer la taille de la diapositive ou le format d'aspect dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à la taille de la diapositive ou au format d'aspect. 

Voici les tailles de diapositive et les formats d'aspect les plus courants :

- **Standard (format d'aspect 4:3)**

  Si votre présentation va être affichée ou vue sur des appareils ou des écrans relativement anciens, vous voudrez peut-être utiliser ce réglage. 

- **Écran Large (format d'aspect 16:9)** 

  Si votre présentation va être vue sur des projecteurs ou des affichages modernes, vous voudrez peut-être utiliser ce réglage. 

Vous ne pouvez pas utiliser plusieurs réglages de taille de diapositive dans une seule présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce réglage de taille de diapositive est appliqué à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier votre taille de diapositive préférée au début, c'est-à-dire lorsque vous configurez simplement la présentation—avant d'ajouter tout contenu à la présentation. De cette façon, vous évitez les complications résultant des changements (futurs) apportés à la taille des diapositives. 

{{% alert color="primary" %}} 

 Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou un format d'aspect 4:3.

{{% /alert %}} 

## Changer la Taille de la Diapositive dans les Présentations 

 Cet exemple de code vous montre comment changer la taille de la diapositive dans une présentation en C# en utilisant Aspose.Slides :

```c#
using (Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
}
```

## Spécifier des Tailles de Diapositive Personnalisées dans les Présentations

Si vous trouvez que les tailles de diapositive courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives en taille réelle de votre présentation sur une mise en page de page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écran, vous êtes susceptible de bénéficier de l'utilisation d'un réglage de taille personnalisé pour votre présentation. 

Cet exemple de code vous montre comment utiliser Aspose.Slides pour .NET pour spécifier une taille de diapositive personnalisée pour une présentation en C# :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille de papier A4
    pres.Save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
}
```

## Résoudre les Problèmes Lors du Changement de la Taille des Diapositives dans les Présentations

Après avoir changé la taille de la diapositive pour une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille de diapositive d'une présentation, vous pouvez spécifier un réglage qui détermine comment Aspose.Slides gère le contenu sur les diapositives.

Selon ce que vous avez l'intention de faire ou d'atteindre, vous pouvez utiliser l'un de ces réglages :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous souhaitez réduire à une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides redimensionne les objets des diapositives pour s'assurer qu'ils s'adaptent tous aux diapositives (de cette façon, vous évitez de perdre du contenu), utilisez ce réglage. 

- `Maximize`

  Si vous souhaitez obtenir une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce réglage. 

Cet exemple de code vous montre comment utiliser le réglage `Maximize` lors du changement de la taille de la diapositive d'une présentation :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```