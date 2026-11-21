---
title: Modifier la taille des diapositives de la présentation sur Android
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-size/
keywords:
- taille de diapositive
- rapport d’aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d’écran
- ne pas mettre à l’échelle
- assurer l’ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Redimensionnez rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Java et Aspose.Slides pour Android, optimisez les présentations pour n’importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides propose des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran.

Tailles de diapositives et rapports d’aspect courants :

- **Standard (ratio d’aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.  
- **Écran large (ratio d’aspect 16:9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation ; une même taille et un même rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions des diapositives dès le début du processus de création afin d’éviter des complications.

{{% alert color="info" title="Remarque" %}}
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d’aspect standard 4:3.  
{{% /alert %}}

Les pages de notes et de documents séparés ont des dimensions différentes de celles des diapositives classiques. Consultez [Taille de la page de notes](/slides/fr/androidjava/notes-size/) pour modifier leur taille et leur orientation.

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille des diapositives d’une présentation en Java avec Aspose.Slides :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives habituelles (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle sur une mise en page personnalisée ou si vous devez afficher votre présentation sur certains types d’écrans, il peut être judicieux d’utiliser un paramètre de taille personnalisé pour votre présentation.

Ce code d’exemple montre comment, via Java, utiliser Aspose.Slides pour Android afin de spécifier une taille de diapositive personnalisée pour une présentation :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille. Cependant, lors du changement de la taille des diapositives, vous pouvez spécifier un paramètre déterminant la façon dont Aspose.Slides traite le contenu des diapositives.

Selon votre objectif, vous pouvez choisir l’un de ces paramètres :

- `DoNotScale`  
  Si vous NE voulez PAS que les objets des diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`  
  Si vous réduisez la taille des diapositives et que vous avez besoin qu’Aspose.Slides réduise les objets afin qu’ils tiennent tous sur les diapositives (éviter ainsi la perte de contenu), utilisez ce paramètre.

- `Maximize`  
  Si vous augmentez la taille des diapositives et que vous souhaitez qu’Aspose.Slides agrandisse les objets pour les proportionner à la nouvelle taille, utilisez ce paramètre.

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de la taille des diapositives d’une présentation :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Puis‑je définir une taille de diapositive personnalisée avec des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point = 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (millimètres, centimètres, etc.) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive très grande affectera‑t‑elle les performances et la consommation mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu élevée entraînent une consommation mémoire accrue et des temps de traitement plus longs. Privilégiez une taille de diapositive raisonnable et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité souhaitée.

**Puis‑je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/androidjava/merge-presentation/) tant qu’elles ont des tailles de diapositives différentes — redimensionnez d’abord l’une des présentations pour qu’elle corresponde à l’autre. Lors du changement de taille, vous pouvez choisir la gestion du contenu existant via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis‑je générer des vignettes pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des vignettes pour [toutes les diapositives](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.