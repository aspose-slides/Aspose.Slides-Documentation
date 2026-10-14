---
title: Convertir les diapositives PowerPoint en PNG avec Java
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- Java
- Aspose.Slides
description: "Convertissez les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour Java, assurant des résultats précis et automatisés."
---
## **Aperçu**

Cet article explique comment convertir des diapositives de présentation en images PNG à l'aide d'Aspose.Slides pour Java. Vous pouvez charger des présentations dans des formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l’enregistrer en tant qu’image PNG distincte.

Les exemples ci‑dessous illustrent le rendu à l’échelle par défaut, l’augmentation de l’échelle, la spécification des dimensions de sortie en pixels et le choix d’un style de rendu de dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et accédez à ses diapositives via la collection [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--). L’exemple rend chaque diapositive avec [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) sans paramètres pour créer une miniature. Il appelle ensuite [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) avec [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) pour enregistrer chaque diapositive rendue en tant qu’image PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
La surcharge sans paramètres de [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) rend à une échelle de 0,2. Par exemple, une diapositive mesurant 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d’échelle ou une taille d’image explicite présentée ci‑dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d’échelle horizontaux et verticaux à [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont égaux à 2, de sorte qu’une diapositive mesurant 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d’échelle égaux conservent le ratio d’aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) au lieu de facteurs d’échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat avec [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Choisissez des dimensions qui correspondent au ratio d’aspect de la diapositive afin d’éviter d’étirer l’image.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Choisir un style de rendu de dégradé**

Supposons qu’une diapositive contienne des remplissages en dégradé, mais que les transitions dans le PNG exporté apparaissent plus claires ou différemment de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la méthode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) héritée de [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l’application. Sa première diapositive contient deux dégradés linéaires : cyan à orange en haut et bleu à jaune en bas. Chaque dégradé possède deux arrêts, à 0 % et 100 %.

L’exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Les images ci‑dessous montrent le rendu de la même diapositive, avec les deux dégradés dans chaque image :

| Default | PowerPointUI |
| --- | --- |
| ![Dégradés cyan-à-orange et bleu-à-jaune rendus avec Default](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus sombres. La différence dépend des couleurs et des arrêts du dégradé.

Choisissez `Default` lorsque la sortie standard d’Aspose.Slides répond à vos besoins. Essayez `PowerPointUI` lorsque votre priorité est de correspondre à l’apparence dans PowerPoint. Comparez les deux sorties avec le résultat souhaité ; aucun des deux modes n’est universellement préférable.

## **FAQ**

**Comment puis‑je exporter une forme spécifique, telle qu’un graphique ou une image, au lieu de toute la diapositive ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/java/create-shape-thumbnails/), vous permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque thread ou processus ; [ne partagez pas une même instance entre les threads](/slides/fr/java/multithreading/).

**Quelles sont les limitations de la version d’évaluation lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images de sortie et applique [d’autres restrictions](/slides/fr/java/licensing/) jusqu’à ce qu’une licence soit appliquée.