---
title: Appliquer ou Modifier les Modèles de Diapositive en Java
linktitle: Modèle de Diapositive
type: docs
weight: 60
url: /fr/java/slide-layout/
keywords:
- modèle de diapositive
- modèle de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- modèle inutilisé
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seul
- modèle vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Appliquer, créer et modifier les modèles de diapositives dans Aspose.Slides pour Java, ajouter des espaces réservés, supprimer les modèles inutilisés et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Un modèle de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer un modèle donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les modèles les plus courants comprennent :

- **Title Slide** : Contient les espaces réservés au titre et au sous-titre.
- **Title and Content** : Contient un espace réservé au titre et un espace réservé de contenu à usage général.
- **Blank** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des modèles**

Une présentation possède trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/) définit le thème, le formatage partagé, les arrière-plans et les objets communs.
1. Une [diapositive modèle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/) appartient à un maître et définit une disposition particulière d'espaces réservés.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/) utilise un modèle et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de son modèle, et le modèle hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu'une diapositive normale est créée, ses formes d'espaces réservés sont générées à partir du modèle sélectionné, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à un modèle avant de créer des diapositives à partir de celui‑ci. Ajouter un autre espace réservé à un modèle ultérieurement n'ajoute pas automatiquement une forme d'espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur un modèle peut mettre à jour chaque diapositive qui en dépend. Avant de modifier un modèle déjà utilisé, inspectez ses diapositives dépendantes et révisez la présentation résultante.
- Un modèle encore utilisé par une diapositive ne peut pas être supprimé. Réattribuez d'abord ses diapositives dépendantes à un autre modèle, ou supprimez uniquement les modèles inutilisés.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, voir [Slide Master](/slides/fr/java/slide-master/).

Pour masquer les logos hérités ou les formes décoratives du maître sur une diapositive ou via un modèle partagé, voir [Control the Visibility of Master Graphics](/slides/fr/java/slide-master/). L'exemple compare deux diapositives utilisant le même maître.

## **Sélectionner et appliquer un modèle de diapositive**

Utilisez un type de modèle lorsque la présentation suit les définitions de modèles standard de PowerPoint. Les noms de modèles sont modifiables par l'utilisateur et peuvent être localisés, ainsi la sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L'exemple suivant recherche **Title and Content** sur le premier maître. Si ce modèle n'est pas disponible, il revient délibérément à **Blank**. Le deuxième test de nullité est nécessaire car une présentation peut ne contenir que des modèles personnalisés. Le modèle sélectionné est ensuite appliqué à la première diapositive normale via la méthode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Modifier le modèle d'une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et le nouveau modèle peuvent changer, il faut donc inspecter le résultat lors du passage entre des modèles sensiblement différents.

## **Ajouter une diapositive modèle**

La sélection et la création sont des opérations distinctes. L'exemple précédent sélectionne un modèle existant ; il n'en crée pas. Pour créer un modèle, appelez la méthode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) sur la collection de modèles du maître cible.

L'exemple suivant ajoute toujours un nouveau modèle **Title and Content** nommé `Report Title and Content`, puis ajoute une diapositive normale basée sur celui‑ci. Les noms de modèles doivent être uniques au sein de la collection.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ajoutez un modèle uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si un modèle approprié existe déjà, sélectionnez‑le et réutilisez‑le au lieu d'en créer un duplicata.

## **Ajouter des espaces réservés à une diapositive modèle**

La méthode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) fournit un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/) pour ajouter des formes d'espaces réservés à un modèle.

| Espace réservé PowerPoint | Méthode `ILayoutPlaceholderManager` |
| -------------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

L'exemple suivant vérifie que le modèle **Blank** existe, ajoute quatre espaces réservés à celui‑ci, puis crée une diapositive normale qui utilise le modèle modifié. L'ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu'Aspose.Slides puisse générer les formes d'espaces réservés correspondantes sur cette diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les espaces réservés sur la diapositive modèle](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés d'un modèle existant peut affecter les diapositives dépendantes. Un espace réservé de modèle récemment ajouté n'est pas rétroactivement ajouté aux diapositives normales existantes. Testez les modifications du modèle sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives modèle inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) pour supprimer les modèles qui ne sont référencés par aucune diapositive normale. La méthode laisse intacts les modèles encore utilisés.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour supprimer un modèle spécifique, utilisez d'abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ou [getDependingSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Réattribuez les diapositives dépendantes avant d'appeler [ILayoutSlide.remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#remove--). Tenter de supprimer un modèle utilisé génère une [PptxEditException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive modèle**

Un modèle possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la méthode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) pour contrôler ces espaces réservés pour un modèle. Cela est utile lorsqu, par exemple, les modèles de contenu doivent afficher les pieds de page mais les modèles de titre ne le doivent pas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler la visibilité du pied de page sur un maître et ses modèles enfants**

Pour appliquer des paramètres de pied de page cohérents sur l'ensemble d'une hiérarchie de maîtres, utilisez la méthode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Les méthodes de propagation de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives modèle dépendantes et les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive modèle ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive modèle appartient à un maître et définit une disposition réutilisable d'espaces réservés. Les diapositives normales utilisent ces modèles et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive modèle d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par le modèle source.

**Que se passe‑t‑il lorsque je modifie un modèle déjà utilisé ?**

Les diapositives dépendantes héritent des modifications du modèle à moins qu'elles ne remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer sur de nombreuses diapositives simultanément. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) pour identifier les diapositives concernées avant de modifier le modèle.

**Que se passe‑t‑il si je supprime un modèle encore utilisé ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxeditexception/). Réattribuez d'abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) pour ne supprimer que les modèles non référencés.