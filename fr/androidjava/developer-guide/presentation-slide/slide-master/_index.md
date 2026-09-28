---
title: Gérer les diapositives maîtres de présentation sur Android
linktitle: Diapositive maître
type: docs
weight: 70
url: /fr/androidjava/slide-master/
keywords:
- diapositive maître
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
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
description: "Gérez les diapositives maîtres dans Aspose.Slides pour Android via Java : accédez, modifiez, clonez, comparez et supprimez les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un slide master est le moyen habituel de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Android via Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs diapositives maître, et chaque diapositive maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas référence directement à une diapositive maître. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à une diapositive maître.

La hiérarchie est :

1. **Slide master** – définit la conception partagée et le thème.  
1. **Layout slide** – définit une disposition spécifique de zones réservées et de formatage au niveau de la mise en page.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![La hiérarchie des diapositives maître, des diapositives de mise en page et des diapositives normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/). Toutes les diapositives maître d’une présentation sont accessibles via la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getMasters--), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/). Pour l’ensemble complet de l’API Android via Java, consultez la [com.aspose.slides API reference](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si une diapositive maître et une diapositive de mise en page définissent toutes deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, consultez [Apply or Change Slide Layouts](/slides/fr/androidjava/slide-layout/).
{{% /alert %}}

## **Accéder aux maîtres de diapositives**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **Affichage** > **Slide Master**.

![La commande Slide Master dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux diapositives maître :

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

Vous pouvez également obtenir la diapositive maître utilisée par une diapositive normale via sa mise en page :

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

## **Ce que contient un Slide Master**

Un slide master est un objet similaire à une diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/), ce qui expose de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page.

Les membres de slide master les plus couramment utilisés incluent :

| Membre | Utilité |
| --- | --- |
| `getBackground()` | Définit l’arrière‑plan de la diapositive au niveau du maître. |
| `getShapes()` | Contient les formes placées sur le maître, comme les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides()` | Contient les diapositives de mise en page qui appartiennent au maître. |
| `getThemeManager()` | Fournit l’accès aux API du thème maître. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses mises en page enfants. |
| `getDependingSlides()` | Renvoie les diapositives normales qui dépendent du maître via leurs mises en page. |

## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à une diapositive maître, celle‑ci apparaît sur les diapositives qui utilisent des mises en page provenant de ce maître. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo à la première diapositive maître :

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

Pour plus d’informations sur les cadres d’image, consultez [Picture Frame](/slides/fr/androidjava/picture-frame/).

## **Contrôler la visibilité des graphiques du maître**

Utilisez [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) pour masquer les graphiques hérités du maître, tels que les logos ou formes décoratives, sans les supprimer du maître. Passez `false` à [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) sur la diapositive qui doit omettre ces graphiques et conservez `true` sur les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un maître et deux diapositives qui utilisent la même mise en page vierge. La bande est visible sur la première diapositive et masquée sur la seconde. aucune présentation d’entrée ou image n’est requise.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

L’exemple utilise la mise en page **Blank** fournie avec une nouvelle présentation et supprime les zones réservées propres à la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son maître via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#getLayoutSlide--) et [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). La définition de la propriété sur une diapositive individuelle n’affecte que cette diapositive. Passer `false` à [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) masque les graphiques du maître pour les diapositives qui utilisent cette mise en page partagée, même si leur propre paramètre est `true`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez la mise en page partagée inchangée.

Ce paramètre n’est pas pris en charge comme contrôle de visibilité sur la diapositive maître elle‑même. Sur un maître, [getShowMasterShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) renvoie toujours `false`, et passer `true` à [setShowMasterShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) déclenche une exception. Appliquez‑le à une diapositive normale ou à une mise en page à la place.

### **Distinguer les graphiques de l’arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du maître | Contrôle la visibilité des formes héritées du maître sans les supprimer ni modifier les formes propres de la diapositive. |
| Modifier le remplissage d’arrière‑plan de la diapositive | Modifie la couleur, le dégradé ou l’image d’arrière‑plan de la diapositive. Les graphiques du maître sont des formes séparées et peuvent rester visibles au-dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/androidjava/presentation-background/). |
| Supprimer une forme du maître | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce maître. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les diapositives de mise en page. La diapositive maître fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espaces réservés sont disponibles dans la vue Slide Master.

![La commande Insérer un espace réservé dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez avec la diapositive de mise en page qui appartient au maître :

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

Vous pouvez également mettre en forme les formes d’espace réservé déjà présentes sur une diapositive maître. L’exemple suivant trouve l’espace réservé du titre et applique un remplissage dégradé linéaire :

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

![Espace réservé de titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d’options de mise en forme des espaces réservés et du texte, consultez [Set Prompt Text in Placeholder](/slides/fr/androidjava/manage-placeholder/) et [Text Formatting](/slides/fr/androidjava/text-formatting/).

## **Modifier l’arrière‑plan d’un Slide Master**

Un arrière‑plan maître est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan solide pour la première diapositive maître :

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

Pour des sujets connexes, consultez [Presentation Background](/slides/fr/androidjava/presentation-background/) et [Presentation Theme](/slides/fr/androidjava/presentation-theme/).

## **Cloner un Slide Master vers une autre présentation**

Utilisez [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) pour copier une diapositive maître dans une autre présentation. Le maître copié peut ensuite être utilisé par les mises en page et les diapositives de la présentation de destination.

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

Si vous devez cloner des diapositives normales avec leur maître, consultez [Clone Slides](/slides/fr/androidjava/clone-slides/).

## **Ajouter plusieurs Slide Masters**

Une présentation peut contenir plusieurs diapositives maître. Ceci est utile lorsque différentes sections nécessitent des marques, structures de page ou paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les diapositives maître](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, attribue au clone un arrière‑plan différent, crée une mise en page sous ce maître cloné, et ajoute une nouvelle diapositive basée sur cette mise en page :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **Comparer les Slide Masters**

Les diapositives maître peuvent être comparées avec la méthode `equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, comme les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, tels que les ID de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

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

Pour plus d’informations, consultez [Compare Presentation Slides](/slides/fr/androidjava/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

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

Pour plus de paramètres de vue, consultez [Save Presentation](/slides/fr/androidjava/save-presentation/).

## **Supprimer les diapositives maître inutilisées**

Les présentations contiennent parfois des diapositives maître qui ne sont plus utilisées par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

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

Vous pouvez également utiliser la méthode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Quelle est la différence entre un slide master et une diapositive de mise en page ?**  
Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un slide master et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de mise en page, elle hérite donc à la fois de la mise en page et du maître.

**Une présentation peut‑elle contenir plusieurs slide masters ?**  
Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou une identité de marque différents.

**Dois‑je ajouter des espaces réservés à une diapositive maître ou à une diapositive de mise en page ?**  
Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage partagé sur la diapositive maître, puis mettez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis‑je supprimer une diapositive maître qui est encore utilisée ?**  
Non. Une diapositive maître qui possède des diapositives dépendantes ne peut pas être supprimée directement en toute sécurité. Déplacez d’abord ces diapositives vers des mises en page sous un autre maître, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas utilisés.