---
title: Gérer les masques de diapositives de présentation en Java
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/java/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs masques de diapositives
- comparer les masques de diapositives
- arrière‑plan
- espace réservé
- cloner le masque de diapositive
- copier le masque de diapositive
- dupliquer le masque de diapositive
- masque de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour Java : accédez, modifiez, clonez, comparez et supprimez les masques de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Un **masque de diapositive** définit les paramètres de conception communs pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un masque de diapositive est la manière habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs masques de diapositive, et chaque masque peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas directement référence à un masque de diapositive. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à un masque de diapositive.

La hiérarchie est :

1. **Masque de diapositive** – définit la conception et le thème partagés.  
1. **Diapositive de mise en page** – définit un agencement spécifique d’espaces réservés et de formatage au niveau de la mise en page.  
1. **Diapositive normale** – contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un masque de diapositive est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/). Tous les masques d’une présentation sont accessibles via la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getMasters--) qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Héritage" %}}

Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un masque et une mise en page définissent tous deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, voir [Apply or Change Slide Layouts](/slides/fr/java/slide-layout/).

{{% /alert %}}

## **Accéder aux masques de diapositive**

Dans PowerPoint, vous pouvez ouvrir la vue Masque des diapositives depuis **Affichage** > **Masque des diapositives**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux masques :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Vous pouvez également obtenir le masque utilisé par une diapositive normale via sa mise en page :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Contenu d’un masque de diapositive**

Un masque de diapositive est un objet semblable à une diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/), de sorte qu’il expose de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page. Les membres spécifiques au masque sont répertoriés sur la page API [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/).

Parmi les membres de masque les plus couramment utilisés :

| Membre | Objectif |
| --- | --- |
| `getBackground()` | Définit l’arrière‑plan au niveau du masque. |
| `getShapes()` | Stocke les formes placées sur le masque, comme les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides()` | Stocke les diapositives de mise en page appartenant au masque. |
| `getThemeManager()` | Fournit l’accès aux API du thème du masque. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le masque et ses mises en page enfants. |
| `getDependingSlides()` | Retourne les diapositives normales qui dépendent du masque via leurs mises en page. |

## **Ajouter une image à un masque de diapositive**

Lorsque vous ajoutez une image à un masque, elle apparaît sur les diapositives qui utilisent les mises en page de ce masque. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels récurrents.

L’exemple suivant ajoute un logo au premier masque :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour plus d’informations sur les cadres d’image, voir [Picture Frame](/slides/fr/java/picture-frame/).

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les diapositives de mise en page. Le masque fournit le style et le thème partagés que ces mises en page héritent, chaque mise en page décidant quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espaces réservés sont disponibles en vue Masque des diapositives.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page appartenant au masque :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également formater les formes d’espace réservé déjà présentes sur un masque. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage en dégradé linéaire :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Pour plus d’options de formatage des espaces réservés et du texte, voir [Set Prompt Text in Placeholder](/slides/fr/java/manage-placeholder/) et [Text Formatting](/slides/fr/java/text-formatting/).

## **Modifier l’arrière‑plan d’un masque de diapositive**

Un arrière‑plan de masque est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier masque :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les sujets associés, voir [Presentation Background](/slides/fr/java/presentation-background/) et [Presentation Theme](/slides/fr/java/presentation-theme/).

## **Cloner un masque de diapositive vers une autre présentation**

Utilisez [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) pour copier un masque dans une autre présentation. Le masque copié peut alors être utilisé par les mises en page et les diapositives de la présentation cible.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Si vous devez cloner des diapositives normales avec leur masque, voir [Clone Slides](/slides/fr/java/clone-slides/).

## **Ajouter plusieurs masques de diapositive**

Une présentation peut contenir plusieurs masques. Cela est utile lorsque différentes sections nécessitent des marques, des structures de page ou des réglages de thème différents.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le masque par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce masque cloné et ajoute une nouvelle diapositive basée sur cette mise en page :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparer des masques de diapositive**

Les masques peuvent être comparés avec la méthode `equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d’autres réglages de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Pour plus d’informations, voir [Compare Presentation Slides](/slides/fr/java/compare-slides/).

## **Définir la vue Masque de diapositive comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Masque de diapositive :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour d’autres réglages de vue, voir [Save Presentation](/slides/fr/java/save-presentation/).

## **Supprimer les masques de diapositive inutilisés**

Les présentations contiennent parfois des masques qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masques inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `removeUnused` pour supprimer les masques inutilisés de la collection `getMasters()` :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également utiliser la méthode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre un masque de diapositive et une diapositive de mise en page ?**

Un masque définit les paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un masque et définit un agencement spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de mise en page, héritant ainsi à la fois du layout et du masque.

**Une présentation peut‑elle contenir plusieurs masques de diapositive ?**

Oui. Une présentation peut contenir plusieurs masques. Utilisez plusieurs masques lorsque différentes sections nécessitent des systèmes visuels ou des marques différents.

**Dois‑je ajouter des espaces réservés à un masque ou à une diapositive de mise en page ?**

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage commun sur le masque, puis les espaces réservés de contenu sur les mises en page utilisées par les diapositives normales.

**Puis‑je supprimer un masque qui est encore utilisé ?**

Non. Un masque ayant des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d’abord ces diapositives vers des mises en page sous un autre masque, ou utilisez une méthode de nettoyage des masques inutilisés qui ne supprime que les masques qui ne sont pas en usage.