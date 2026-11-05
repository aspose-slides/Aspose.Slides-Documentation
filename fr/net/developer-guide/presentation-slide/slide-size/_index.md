---
title: Modifier la taille des diapositives de la présentation en .NET
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/net/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- format large
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives des fichiers PPT, PPTX et ODP avec .NET et Aspose.Slides, et à optimiser les présentations pour n'importe quel écran sans perdre en qualité."
---
## **Introduction**

Aspose.Slides for .NET fournit des outils complets pour ajuster la taille des diapositives et le ratio d'aspect dans les présentations PowerPoint, indispensable tant pour l'impression que pour l'affichage à l'écran.

Tailles de diapositives et ratios populaires :

- **Standard (ratio d'aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.
- **Widescreen (ratio d'aspect 16:9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez la cohérence de votre présentation en utilisant une taille de diapositive et un ratio d'aspect uniques pour toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d'éviter les complications.

{{% alert color="info" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d'aspect standard 4:3.
{{% /alert %}}

Les pages de notes et de documents ont des dimensions séparées des diapositives normales. Voir [Taille de la page de notes](/slides/fr/net/notes-size/) pour modifier leur taille et orientation.

## **Comment modifier la taille des diapositives dans une présentation**

Cet exemple montre comment modifier la taille des diapositives d'une présentation avec Aspose.Slides en C# :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Spécifier des tailles de diapositives personnalisées**

Adapter la taille des diapositives à vos besoins spécifiques, comme des mises en page papier particulières ou des spécifications d'écran, peut être bénéfique. Voici comment définir une taille de diapositive personnalisée avec Aspose.Slides pour .NET :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // format papier A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gérer le contenu des diapositives après redimensionnement**

Après le redimensionnement, le contenu des diapositives peut se déformer. Vous pouvez contrôler la façon dont Aspose.Slides gère ce redimensionnement :

- **`DoNotScale`** : Conserver les objets à leur taille d'origine pour éviter le redimensionnement.
- **`EnsureFit`** : Redimensionner les objets pour qu'ils s'adaptent aux diapositives plus petites, évitant ainsi la perte de contenu.
- **`Maximize`** : Agrandir les objets afin qu'ils conviennent aux diapositives plus grandes pour une cohérence esthétique.

Exemple d’utilisation du paramètre `Maximize` pour ajuster la taille des diapositives :

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

### Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

### Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?

Vous ne pouvez pas [fusionner les présentations](/slides/fr/net/merge-presentation/) lorsqu'elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour qu'elle corresponde à l'autre. Lors du changement de taille de diapositive, vous pouvez choisir la façon dont le contenu existant est géré via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant la mise en forme.

### Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d'une diapositive, et respecteront-elles la nouvelle taille de diapositive ?

Oui. Aspose.Slides peut générer des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille et le ratio d'aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.