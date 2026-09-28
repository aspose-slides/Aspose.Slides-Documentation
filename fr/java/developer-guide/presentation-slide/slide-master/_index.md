---
title: Gérer les maîtres de diapositives de présentation en Java
linktitle: Maître de diapositive
type: docs
weight: 70
url: /fr/java/slide-master/
keywords:
- maître de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner diapositive maître
- copier diapositive maître
- dupliquer diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les maîtres de diapositives dans Aspose.Slides pour Java : accédez, modifiez, clonez, comparez et supprimez les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **maître de diapositive** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un maître de diapositive est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Java prend en charge le même modèle. Une présentation peut contenir un ou plusieurs maîtres de diapositive, et chaque maître peut contenir plusieurs diapositives de disposition. Les diapositives normales ne se réfèrent généralement pas directement à un maître. Au lieu de cela, une diapositive normale utilise une diapositive de disposition, et cette diapositive de disposition appartient à un maître.

La hiérarchie est :

1. **Maître de diapositive** – définit la conception et le thème partagés.  
1. **Diapositive de disposition** – définit un agencement spécifique d’espaces réservés et de mise en forme au niveau de la disposition.  
1. **Diapositive normale** – contient le contenu réel de la présentation et utilise une diapositive de disposition.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un maître de diapositive est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/). Tous les maîtres d’une présentation sont accessibles via la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getMasters--) qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un maître et une disposition définissent tous deux un arrière‑plan, les diapositives basées sur cette disposition utilisent l’arrière‑plan de la disposition. Pour plus d’informations sur les dispositions, voir [Appliquer ou modifier les dispositions des diapositives](/slides/fr/java/slide-layout/).
{{% /alert %}}

## **Accéder aux maîtres de diapositive**

Dans PowerPoint, vous pouvez ouvrir la vue Maître de diapositive depuis **Affichage** > **Maître de diapositive**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux maîtres :

```java
import com.aspose.slides.*;

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

Vous pouvez également obtenir le maître utilisé par une diapositive normale via sa disposition :

```java
import com.aspose.slides.*;

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

## **Ce qu’un maître de diapositive contient**

Un maître de diapositive est un objet semblable à une diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/), ce qui lui donne accès aux mêmes propriétés de diapositive que les diapositives normales et de disposition. Les membres spécifiques au maître sont répertoriés sur la page API [IMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/).

Les membres de maître de diapositive les plus couramment utilisés sont :

| Membre | Utilité |
| --- | --- |
| `getBackground()` | Définit l’arrière‑plan au niveau du maître. |
| `getShapes()` | Contient les formes placées sur le maître, comme les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides()` | Contient les diapositives de disposition appartenant au maître. |
| `getThemeManager()` | Fournit l’accès aux API du thème du maître. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses dispositions enfants. |
| `getDependingSlides()` | Renvoie les diapositives normales qui dépendent du maître via leurs dispositions. |

## **Ajouter une image à un maître de diapositive**

Lorsque vous ajoutez une image à un maître, elle apparaît sur les diapositives qui utilisent les dispositions de ce maître. C’est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier maître :

```java
import com.aspose.slides.*;

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

## **Contrôler la visibilité des graphiques du maître**

Utilisez [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) pour masquer les graphiques hérités du maître, tels que les logos ou formes décoratives, sans les supprimer du maître. Passez `false` à [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) sur la diapositive qui doit ignorer ces graphiques et gardez `true` sur les diapositives qui doivent les afficher.

L’exemple autonome ci‑dessous crée une bande décorative bleue sur un maître et deux diapositives utilisant la même disposition vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d’entrée n’est requis.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’exemple utilise la disposition **Blank** fournie avec une nouvelle présentation et supprime les espaces réservés propres à la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son maître via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getLayoutSlide--) et [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Le réglage de la propriété sur une diapositive individuelle n’affecte que celle‑ci. Passer `false` à [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) masque les graphiques du maître pour toutes les diapositives qui utilisent cette disposition partagée, même si leur propre réglage est `true`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez la disposition partagée inchangée.

Le paramètre n’est pas pris en charge comme contrôle de visibilité sur le maître lui‑même. Sur un maître, [getShowMasterShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterslide/#getShowMasterShapes--) renvoie toujours `false`, et passer `true` à [setShowMasterShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) génère une exception. Appliquez‑le à une diapositive normale ou à une disposition.

### **Distinction entre graphiques et arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du maître | Contrôle la visibilité des formes héritées du maître sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage d’arrière‑plan de la diapositive | Change la couleur, le dégradé ou l’image d’arrière‑plan. Les graphiques du maître sont des formes distinctes et peuvent rester visibles au‑dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/java/presentation-background/). |
| Supprimer une forme du maître | Supprime la forme source partagée, de sorte qu’elle n’est plus disponible pour aucune diapositive utilisant ce maître. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les diapositives de disposition. Le maître fournit le style et le thème partagés que ces dispositions héritent, chaque disposition décidant quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles en mode Maître de diapositive.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de disposition appartenant au maître :

```java
import com.aspose.slides.*;

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

Vous pouvez également mettre en forme les formes d’espace réservé déjà présentes sur un maître. L’exemple suivant trouve l’espace réservé au titre et applique un remplissage en dégradé linéaire :

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Pour d’autres options de formatage d’espaces réservés et de texte, voir [Set Prompt Text in Placeholder](/slides/fr/java/manage-placeholder/) et [Text Formatting](/slides/fr/java/text-formatting/).

## **Modifier l’arrière‑plan d’un maître de diapositive**

Un arrière‑plan de maître est hérité par les dispositions et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier maître :

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Pour des sujets connexes, voir [Presentation Background](/slides/fr/java/presentation-background/) et [Presentation Theme](/slides/fr/java/presentation-theme/).

## **Cloner un maître de diapositive vers une autre présentation**

Utilisez [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) pour copier un maître dans une autre présentation. Le maître copié peut alors être utilisé par les dispositions et diapositives de la présentation cible.

```java
import com.aspose.slides.*;

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

Si vous devez cloner des diapositives normales avec leur maître, voir [Clone Slides](/slides/fr/java/clone-slides/).

## **Ajouter plusieurs maîtres de diapositive**

Une présentation peut contenir plusieurs maîtres. Cela est utile lorsque différentes sections nécessitent des marques, structures de page ou paramètres de thème différents.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, donne au clone un arrière‑plan différent, crée une disposition sous ce maître cloné et ajoute une nouvelle diapositive basée sur cette disposition :

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Comparer des maîtres de diapositive**

Les maîtres peuvent être comparés avec la méthode `equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et les autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les ID de diapositive, ni les valeurs dynamiques d’espaces réservés, comme la date actuelle.

```java
import com.aspose.slides.*;

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

## **Définir la vue Maître de diapositive comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Maître de diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour d’autres réglages de vue, voir [Save Presentation](/slides/fr/java/save-presentation/).

## **Supprimer les maîtres de diapositive inutilisés**

Parfois, des présentations contiennent des maîtres qui ne sont plus utilisés par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `removeUnused` pour supprimer les maîtres inutilisés de la collection `getMasters()` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également recourir à la méthode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre un maître de diapositive et une diapositive de disposition ?**

Un maître de diapositive définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de disposition appartient à un maître et définit un agencement spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de disposition, héritant ainsi à la fois de la disposition et du maître.

**Une présentation peut‑elle contenir plusieurs maîtres de diapositive ?**

Oui. Une présentation peut contenir plusieurs maîtres. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou des marques différents.

**Dois‑je ajouter des espaces réservés à un maître ou à une diapositive de disposition ?**

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de disposition. Placez les éléments visuels partagés et le formatage partagé sur le maître, puis ajoutez les espaces réservés de contenu sur les dispositions que les diapositives normales utiliseront.

**Puis‑je supprimer un maître de diapositive qui est encore utilisé ?**

Non. Un maître qui possède des diapositives dépendantes ne peut pas être supprimé en toute sécurité. Déplacez d’abord ces diapositives vers des dispositions sous un autre maître, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas en usage.