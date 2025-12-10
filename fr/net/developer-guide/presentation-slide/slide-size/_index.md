---
title: Modifier la taille des diapositives de la présentation en .NET
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
descriptions: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec .NET et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perte de qualité."
---

## **Personnaliser les tailles de diapositive et les rapports d’aspect dans une présentation**

Aspose.Slides pour .NET fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran.

### **Tailles de diapositive et rapports d’aspect populaires**

- **Standard (rapport d’aspect 4 : 3)** : Idéal pour les écrans et appareils plus anciens.  
  
- **Grand écran (rapport d’aspect 16 : 9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez la cohérence de votre présentation, car une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d’éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4 : 3.  
{{% /alert %}}

## **Comment modifier la taille des diapositives dans une présentation**

Cet exemple montre comment changer la taille des diapositives d’une présentation avec Aspose.Slides en C# :
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **Spécifier des tailles de diapositive personnalisées**

Adapter la taille des diapositives à vos besoins spécifiques, par exemple pour des formats papier uniques ou des spécifications d’écran, peut être avantageux. Voici comment définir une taille de diapositive personnalisée avec Aspose.Slides pour .NET :
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // taille de papier A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **Gérer le contenu des diapositives après le redimensionnement**

Après le redimensionnement, le contenu des diapositives peut se déformer. Vous pouvez contrôler la façon dont Aspose.Slides gère ce redimensionnement :

- **`DoNotScale`** : Conserve les objets à leurs tailles d’origine pour éviter le redimensionnement.  
- **`EnsureFit`** : Redimensionne les objets pour qu’ils s’ajustent aux diapositives plus petites, empêchant ainsi la perte de contenu.  
- **`Maximize`** : Agrandit les objets afin qu’ils correspondent aux diapositives plus grandes pour une cohérence esthétique.

Exemple d’utilisation du paramètre `Maximize` pour ajuster la taille des diapositives :
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**Puis‑je définir une taille de diapositive personnalisée avec des unités autres que des pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une très grande taille de diapositive personnalisée affectera‑t‑elle les performances et la consommation de mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive raisonnable et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis‑je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/net/merge-presentation/) tant qu’elles ont des tailles de diapositive différentes — redimensionnez d’abord une présentation pour qu’elle corresponde à l’autre. Lors du changement de la taille de diapositive, vous pouvez choisir la manière dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis‑je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et ces miniatures respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [entire slides](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) ainsi que pour [selected shapes](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille de diapositive et le rapport d’aspect actuels, assurant un cadrage et une géométrie cohérents.