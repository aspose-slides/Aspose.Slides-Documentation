---
title: Personnaliser la taille des diapositives
linktitle: Taille des diapositives
type: docs
weight: 70
url: /fr/net/slide-size/
keywords: "Définir la taille des diapositives, personnaliser les dimensions de la présentation, rapport d'aspect PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Apprenez comment personnaliser et ajuster les tailles de diapositives ou les rapports d'aspect dans PowerPoint en utilisant C# ou .NET avec Aspose.Slides."
---

## **Personnalisation des tailles de diapos et des rapports d’aspect dans PowerPoint**

Aspose.Slides for .NET propose des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran. 

### **Tailles de diapositives populaires et rapports**

- **Standard (rapport d’aspect 4 : 3)** : Idéal pour les écrans et appareils plus anciens.
  
- **Grand écran (rapport d’aspect 16 : 9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, car une seule taille de diapositive et un seul rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d’éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4 : 3.
{{% /alert %}}

## **Comment modifier la taille des diapositives dans PowerPoint**

Cet exemple montre comment changer la taille des diapositives d’une présentation avec Aspose.Slides en C# :
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **Spécifier des tailles de diapositives personnalisées**

Adapter la taille des diapositives à vos besoins spécifiques, par exemple pour des formats de papier uniques ou des spécifications d’écran, peut être bénéfique. Voici comment définir une taille de diapositive personnalisée avec Aspose.Slides for .NET :
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille du papier A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **Gestion du contenu des diapositives après redimensionnement**

Après le redimensionnement, le contenu des diapositives peut se déformer. Vous pouvez contrôler la façon dont Aspose.Slides gère ce redimensionnement :

- **`DoNotScale`** : Conserver les objets à leurs tailles d’origine pour éviter le redimensionnement.
- **`EnsureFit`** : Redimensionner les objets pour les adapter aux diapositives plus petites, afin d’éviter la perte de contenu.
- **`Maximize`** : Agrandir les objets pour les adapter aux diapositives plus grandes, afin de maintenir la cohérence esthétique.

Exemple d’utilisation du paramètre `Maximize` pour ajuster la taille des diapositives :
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise des points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Optez pour une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/net/merge-presentation/) lorsqu’elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. En changeant la taille de la diapositive, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/). Les images générées reflètent la taille de diapositive et le rapport d’aspect actuels, garantissant un cadrage et une géométrie cohérents.