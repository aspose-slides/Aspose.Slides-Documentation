---
title: Modifier la taille des diapositives de la présentation en .NET
linktitle: Taille des diapositives
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
- diapositive en pleine taille
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

Aspose.Slides for .NET fournit des outils complets pour ajuster la taille des diapositives et le rapport d'aspect dans les présentations PowerPoint, essentiels à la fois pour l'impression et l'affichage a l'ecran.

Tailles de diapositives populaires et rapports :

- **Standard (rapport d'aspect 4:3)** : Ideal pour les ecrans et appareils plus anciens.
- **Widescreen (rapport d'aspect 16:9)** : Recommande pour les projecteurs et affichages modernes.

Assurez la coherence de l'ensemble de votre presentation, car une taille de diapositive et un rapport d'aspect uniques s'appliquent a toutes les diapositives. Pour des resultats optimaux, definissez les dimensions de vos diapositives au debut du processus de creation de votre presentation afin d'eviter les complications.

{{% alert color="info" %}} 
Par defaut, les presentations creees avec Aspose.Slides utilisent le rapport d'aspect standard 4:3.
{{% /alert %}}

## **Comment modifier la taille des diapositives dans une presentation**

Cet exemple montre comment modifier la taille des diapositives d'une presentation avec Aspose.Slides en C#:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specifier des tailles de diapositives personnalisees**

Adapter la taille des diapositives a vos besoins specifics, par exemple pour des formats de papier uniques ou des specifications d'ecran, peut etre avantageux. Voici comment definir une taille de diapositive personnalisee avec Aspose.Slides pour .NET:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Format papier A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Gerer le contenu des diapositives apres le redimensionnement**

Apres le redimensionnement, le contenu des diapositives peut se deformer. Vous pouvez contrôler la facon dont Aspose.Slides gere ce redimensionnement :

- **`DoNotScale`** : Conserver les objets a leurs tailles d'origine pour eviter le redimensionnement.
- **`EnsureFit`** : Redimensionner les objets pour qu'ils tiennent sur des diapositives plus petites, evitant ainsi la perte de contenu.
- **`Maximize`** : Agrandir les objets afin de correspondre a des diapositives plus grandes pour une coherence estetique.

Exemple d'utilisation du parametre `Maximize` pour ajuster la taille des diapositives :
```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Puis-je definir une taille de diapositive personnalisee en utilisant des unites autres que les pouces (par exemple, des points ou des millimetres) ?

Oui. Aspose.Slides utilise les points en interne, ou 1 point egal a 1/72 de pouce. Vous pouvez convertir n'importe quelle unite (comme les millimetres ou les centimetres) en points et utiliser les valeurs converties pour definir la largeur et la hauteur de la diapositive.

### Une taille de diapositive personnalisee tres grande affectera-t-elle les performances et l'utilisation de la memoire lors du rendu ?

Oui. Des dimensions de diapositive plus grandes (en points) combinees a une echelle de rendu plus elevee entrainent une consommation de memoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'echelle de rendu uniquement si necessaire pour obtenir la qualite de sortie souhaitee.

### Puis-je definir une taille de diapositive non standard puis fusionner des diapositives provenant de presentations ayant des tailles diferentes ?

Vous ne pouvez pas [fusionner les presentations](/slides/fr/net/merge-presentation/) tant qu'elles ont des tailles de diapositive differentes - commencez par redimensionner une presentation pour qu'elle corresponde a l'autre. Lors du changement de la taille de la diapositive, vous pouvez choisir la facon dont le contenu existant est gere via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesizescaletype/). Apres avoir aligne les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

### Puis-je generer des miniatures pour des formes individuelles ou des regions spécifiques d'une diapositive, et respecteront-elles la nouvelle taille de diapositive ?

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) ainsi que pour [les formes selectionnees](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getimage/). Les images resultantes reflètent la taille de diapositive et le rapport d'aspect actuels, garantissant un cadrage et une geometrie coherents.