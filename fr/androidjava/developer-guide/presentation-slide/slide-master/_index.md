---
title: Gérer les masques de diapositives de présentation sur Android
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- multiples diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérer les masques de diapositives dans Aspose.Slides pour Android via Java : accéder, modifier, cloner, comparer et supprimer les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

Un **masque de diapositives** définit les paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un masque de diapositives est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Android via Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs diapositives maîtres, et chaque diapositive maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas directement référence à une diapositive maître. À la place, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à une diapositive maître.

La hiérarchie est :

1. **Masque de diapositives** - définit la conception et le thème partagés.  
1. **Diapositive de mise en page** - définit une disposition spécifique d'espaces réservés et de formatage au niveau de la mise en page.  
1. **Diapositive normale** - contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![Hiérarchie des masques de diapositives, des diapositives de mise en page et des diapositives normales](slide-master_2.jpg)

Dans Aspose.Slides, un masque de diapositives est représenté par l'interface [IMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/). Toutes les masques de diapositives d'une présentation sont accessibles via la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getMasters--) qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/). Pour l’ensemble complet de l'API Android via Java, voir la [référence de l'API com.aspose.slides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l'emporte. Par exemple, si un masque de diapositives et une diapositive de mise en page définissent tous deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l'arrière‑plan de la mise en page. Pour plus d'informations sur les diapositives de mise en page, voir [Appliquer ou modifier les mises en page de diapositives](/slides/fr/androidjava/slide-layout/).
{{% /alert %}}

## **Accéder aux masques de diapositives**

Dans PowerPoint, vous pouvez ouvrir la vue Masque des diapositives depuis **Affichage** > **Masque des diapositives**.

![Commande Masque des diapositives dans l'onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux masques de diapositives :

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

## **Ce que contient un masque de diapositives**

Un masque de diapositives est un objet similaire à une diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/), aussi il expose de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page.

Les membres de masque de diapositives les plus couramment utilisés incluent :

| Membre | Objectif |
| --- | --- |
| `getBackground()` | Définit l'arrière‑plan de la diapositive au niveau du masque. |
| `getShapes()` | Conserve les formes placées sur le masque, comme les logos, les cadres d'image et le texte partagé. |
| `getLayoutSlides()` | Conserve les diapositives de mise en page qui appartiennent au masque. |
| `getThemeManager()` | Fournit l'accès aux API du thème du masque. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le masque et ses mises en page enfants. |
| `getDependingSlides()` | Renvoie les diapositives normales qui dépendent du masque via leurs mises en page. |

## **Ajouter une image à un masque de diapositives**

Lorsque vous ajoutez une image à un masque de diapositives, elle apparaît sur les diapositives qui utilisent les mises en page de ce masque. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L'exemple suivant ajoute un logo au premier masque de diapositives :

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

Pour plus d'informations sur les cadres d'image, voir [Cadre d'image](/slides/fr/androidjava/picture-frame/).

## **Travailler avec les espaces réservés**

Les espaces réservés sont normalement définis sur les diapositives de mise en page. Le masque de diapositives fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d'espace réservé sont disponibles dans la vue Masque des diapositives.

![Commande Insérer un espace réservé dans la vue Masque des diapositives de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au masque :

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

Vous pouvez également formater les formes d'espace réservé déjà existantes sur un masque de diapositives. L'exemple suivant trouve l'espace réservé du titre et applique un remplissage en dégradé linéaire :

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Espace réservé titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d'options de formatage des espaces réservés et du texte, voir [Définir le texte d'invite dans un espace réservé](/slides/fr/androidjava/manage-placeholder/) et [Mise en forme du texte](/slides/fr/androidjava/text-formatting/).

## **Modifier l'arrière‑plan d'un masque de diapositives**

Un arrière‑plan de masque est hérité par les mises en page et les diapositives qui ne le remplacent pas. L'exemple suivant définit une couleur d'arrière‑plan unie pour le premier masque de diapositives :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les sujets connexes, voir [Arrière‑plan de la présentation](/slides/fr/androidjava/presentation-background/) et [Thème de la présentation](/slides/fr/androidjava/presentation-theme/).

## **Cloner un masque de diapositives vers une autre présentation**

Utilisez [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) pour copier un masque de diapositives dans une autre présentation. Le masque copié peut alors être utilisé par les mises en page et les diapositives de la présentation cible.

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

Si vous devez cloner des diapositives normales avec leur masque, voir [Cloner des diapositives](/slides/fr/androidjava/clone-slides/).

## **Ajouter plusieurs masques de diapositives**

Une présentation peut contenir plusieurs masques de diapositives. Cela est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les masques de diapositives](slide-master_9.jpg)

L'exemple suivant clone le masque par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce masque cloné, et ajoute une nouvelle diapositive basée sur cette mise en page :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **Comparer les masques de diapositives**

Les masques de diapositives peuvent être comparés avec la méthode `equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, comme les formes, le texte, le formatage, les animations et d'autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les ID de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

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

Pour plus d'informations, voir [Comparer les diapositives d'une présentation](/slides/fr/androidjava/compare-slides/).

## **Définir la vue Masque de diapositives comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L'exemple suivant ouvre la présentation dans la vue Masque de diapositives :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour plus de paramètres d'affichage, voir [Enregistrer la présentation](/slides/fr/androidjava/save-presentation/).

## **Supprimer les masques de diapositives inutilisés**

Les présentations contiennent parfois des masques de diapositives qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masques inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

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

Vous pouvez également utiliser la méthode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Quelle est la différence entre un masque de diapositives et une diapositive de mise en page ?**

Un masque de diapositives définit les paramètres de conception partagés tels que le thème, l'arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un masque de diapositives et définit une disposition spécifique d'espaces réservés. Une diapositive normale utilise une diapositive de mise en page, ainsi elle hérite à la fois de la mise en page et du masque.

**Une présentation peut‑elle contenir plusieurs masques de diapositives ?**

Oui. Une présentation peut contenir plusieurs masques de diapositives. Utilisez plusieurs masques lorsque différentes sections nécessitent des systèmes visuels ou une identité de marque différents.

**Dois‑je ajouter des espaces réservés à un masque de diapositives ou à une diapositive de mise en page ?**

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage partagé sur le masque de diapositives, puis placez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis‑je supprimer un masque de diapositives qui est encore utilisé ?**

Non. Un masque de diapositives qui possède des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d'abord ces diapositives vers des mises en page sous un autre masque, ou utilisez une méthode de nettoyage des masques inutilisés qui ne supprime que les masques qui ne sont pas utilisés.