---
title: Gérer les espaces réservés de présentation sur Android
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/androidjava/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment inspecter et modifier les espaces réservés de texte, d'image, de graphique et de contenu et comprendre l'héritage des espaces réservés avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d'image, de graphique et de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de mise en page ou d’une diapositive maître.

Aspose.Slides expose les informations d’espace réservé via la méthode [IShape.getPlaceholder](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/). La méthode renvoie un objet [IPlaceholder](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholder/) ou `null` pour une forme normale. Utilisez [IPlaceholder.getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholder/) pour déterminer ce que l’espace réservé est censé contenir.

L’interface de forme reste importante une fois que vous connaissez le type d’espace réservé :

- Un espace réservé vide de texte, d’image, de graphique ou de contenu est généralement représenté par un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).
- Un espace réservé d’image rempli peut être représenté par un [IPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [IPlaceholder.getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholder/) et l’interface de forme d’exécution au lieu de supposer que chaque espace réservé est un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Avertissement" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholder/) décrit le rôle d’un espace réservé ; il ne garantit pas le type d’exécution de la forme. Utilisez toujours une vérification de type avant d’accéder aux membres spécifiques texte, image, graphique, tableau ou média.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maître définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau du maître.
2. Une diapositive de mise en page définit la disposition utilisée par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) pour monter d’un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `null` lorsqu’une forme n’a aucun espace réservé de base.

L’exemple suivant répertorie les espaces réservés sur la première diapositive et indique leurs espaces réservés de base :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce réglage. Une forme ordinaire locale n’a aucun espace réservé de base et ne commence pas à hériter simplement parce qu’elle occupe les mêmes coordonnées.

## **Modifier le texte d’un espace réservé**

Les espaces réservés de titre, de titre centré, de sous-titre, de corps et de texte prennent normalement en charge le texte. Vérifiez la présence d’un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) avant d’utiliser sa méthode [getTextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce modèle évite de convertir les espaces réservés d’image, de graphique, de tableau ou de média en [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/). Il identifie également l’espace réservé par son objectif au lieu de s’appuyer sur un indice de forme fragile.

## **Définir le texte d’invite sur une mise en page**

Le texte d’invite est l’instruction affichée en mode conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez un texte d’invite personnalisé sur l’espace réservé de la mise en page plutôt que d’essayer d’y accéder via la collection de formes d’une diapositive normale. Accédez à la mise en page via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/) et parcourez la collection renvoyée par [ILayoutSlide.getShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/).

L’exemple suivant modifie les invites de titre et de sous-titre sur la mise en page utilisée par la première diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le texte d’invite n’est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d’édition comme PowerPoint. Une fois qu’un utilisateur ou un programme fournit du contenu réel, l’invite n’est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d’image**

Il y a deux cas à gérer :

- Si l’espace réservé d’image est déjà rempli et représenté par un [IPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipictureframe/), remplacez l’image via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/) et [ISlidesPicture.setImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidespicture/).
- S’il s’agit encore d’un espace réservé vide, ajoutez un cadre d’image aux coordonnées de l’espace réservé avec [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/) et supprimez l’espace réservé vide.

L’exemple suivant prend en charge les deux cas et enregistre la présentation :

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le remplacement créé pour un espace réservé vide est un cadre d’image local, pas un nouvel espace réservé, car [IShape.getPlaceholder](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) ne fournit pas de mutateur. Il conserve la position réservée mais n’hérite plus du comportement spécifique à l’espace réservé. Si conserver la relation d’espace réservé est essentiel, préparez et remplissez d’abord l’espace réservé dans PowerPoint, puis mettez à jour le [IPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipictureframe/) résultant avec Aspose.Slides.

Pour la transparence d’image, le recadrage et d’autres effets spécifiques aux images, voir [Manage Picture Frames](/slides/fr/androidjava/picture-frame/). Ces opérations appartiennent au cadre d’image ou au remplissage d’image, pas aux métadonnées de l’espace réservé.

## **Travailler avec les espaces réservés de graphique et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/). Cet exemple trouve un tel graphique à la fois par le type d’espace réservé et par l’interface d’exécution, modifie son titre et enregistre le fichier :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un espace réservé de contenu général possède généralement [PlaceholderType.Object](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, y compris graphiques, tableaux, diagrammes, images et médias. Après qu’il a été rempli, examinez l’interface de forme réelle pour savoir ce qu’il contient. Les mises en page spécialisées peuvent également exposer [PlaceholderType.Chart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un espace réservé vide [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) en [IChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/) simplement en modifiant [IPlaceholder.getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/placeholder/); le type ne peut pas être modifié via l’interface. Pour remplir programatiquement un graphique ou une zone de contenu vide, ajoutez l’objet requis aux coordonnées de l’espace réservé puis supprimez l’espace réservé vide. L’exemple suivant fait cela pour un graphique :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l’espace réservé mais n’hérite pas de l’espace réservé de la mise en page. Utilisez les [chart management articles](/slides/fr/androidjava/powerpoint-charts/) dédiés lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : Mettre à jour le texte ou le contenu image**

L’exemple complet suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d’image, vérifie les types d’espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L’exemple évite délibérément de supposer un indice de forme ou de convertir chaque espace réservé en la même interface.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qu'est-ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) pour le récupérer. Une forme locale ordinaire renvoie `null` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis-je modifier tous les titres de diapositives en modifiant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage hérité ou le texte d’invite via une mise en page, mais le contenu du titre existant est stocké sur les diapositives normales. Pour remplacer le texte réel des titres dans une présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéros de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d’en‑tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du livret appropriés. Consultez [Manage Presentation Header and Footer](/slides/fr/androidjava/presentation-header-and-footer/) pour des exemples complets.