---
title: Modifier la taille des diapositives d'une présentation en .NET
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/net/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive plein format
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
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec .NET et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides for .NET fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l’impression que pour l’affichage à l’écran. 

Tailles de diapositives et rapports d’aspect populaires :

- **Standard (rapport d’aspect 4 : 3)** : Idéal pour les écrans et appareils plus anciens.
- **Grand écran (rapport d’aspect 16 : 9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives au début du processus de création afin d’éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4 : 3.
{{% /alert %}}

## **Comment modifier la taille des diapositives dans une présentation**

Cet exemple montre comment modifier la taille des diapositives d’une présentation avec Aspose.Slides en C# :

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Spécifier des tailles de diapositives personnalisées**

Adapter la taille des diapositives à vos besoins spécifiques, comme des mises en page papier uniques ou des spécifications d’écran, peut être avantageux. Voici comment définir une taille de diapositive personnalisée avec Aspose.Slides for .NET :

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // taille du papier A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après le redimensionnement, le contenu des diapositives peut se déformer. Vous pouvez contrôler la façon dont Aspose.Slides gère ce redimensionnement :

- **`DoNotScale`** : Conserver les objets à leur taille d’origine pour éviter le redimensionnement.
- **`EnsureFit`** : Redimensionner les objets pour qu’ils s’ajustent aux diapositives plus petites, afin d’éviter la perte de contenu.
- **`Maximize`** : Agrandir les objets pour les adapter aux diapositives plus grandes afin de maintenir une cohérence esthétique.

Exemple d’utilisation du paramètre `Maximize` pour ajuster la taille des diapositives :

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/net/merge-presentation/) lorsqu’elles ont des tailles de diapositives différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. Lors du changement de taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis-je générer des vignettes pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des vignettes pour [toutes les diapositives](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.