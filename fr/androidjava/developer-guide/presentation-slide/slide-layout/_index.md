---
title: "Appliquer ou modifier les dispositions de diapositives sur Android"
linktitle: "Disposition de diapositive"
type: docs
weight: 60
url: /fr/androidjava/slide-layout/
keywords:
- mise en page de diapositive
- mise en page de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- disposition inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre uniquement
- disposition vide
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour Android via Java, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes comprennent :

- **Diapositive titre** : contient des espaces réservés de titre et de sous‑titre.
- **Titre et contenu** : contient un espace réservé de titre et un espace réservé de contenu à usage général.
- **Vide** : ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des dispositions**

Une présentation comporte trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.  
1. Une [diapositive de disposition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/) appartient à un maître et définit un arrangement particulier d'espaces réservés.  
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espace réservé sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter un autre espace réservé à une disposition ultérieurement n’ajoute pas automatiquement la forme correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.  
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réaffectez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, voir [Slide Master](/slides/fr/androidjava/slide-master/).

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de disposition PowerPoint standard. Les noms de disposition sont éditables par l’utilisateur et peuvent être localisés, de sorte qu’une sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L’exemple suivant recherche **Titre et contenu** sur le premier maître. Si cette disposition n’est pas disponible, il revient délibérément à **Vide**. La seconde vérification de nullité est nécessaire parce qu’une présentation peut ne contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du passage entre des dispositions sensiblement différentes.

## **Ajouter une diapositive de disposition**

La sélection et la création sont des opérations séparées. L’exemple précédent sélectionne une disposition existante ; il n’en crée pas une. Pour créer une disposition, appelez la méthode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) sur la collection de dispositions du maître cible.

L’exemple suivant ajoute toujours une nouvelle disposition **Titre et contenu** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de disposition doivent être uniques au sein de la collection.

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

Ajoutez une disposition uniquement lorsque le modèle a réellement besoin d’une autre structure réutilisable. Si une disposition appropriée existe déjà, sélectionnez‑la et réutilisez‑la plutôt que de créer un duplicata.

## **Ajouter des espaces réservés à une diapositive de disposition**

La méthode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) fournit un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) pour ajouter des formes d’espace réservé à une disposition.

| Espace réservé PowerPoint | `ILayoutPlaceholderManager` Method |
| -------------------------- | ---------------------------------- |
| ![Contenu](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Contenu (vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Texte](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Texte (vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Image](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Graphique](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tableau](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Image en ligne](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

L’exemple suivant vérifie que la disposition **Vide** existe, ajoute quatre espaces réservés, puis crée une diapositive normale qui utilise la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu’Aspose.Slides puisse générer les formes d’espace réservé correspondantes sur cette diapositive.

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

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés de disposition existants peut affecter les diapositives dépendantes. Un espace réservé de disposition ajouté récemment n’est pas rétro‑appliqué aux diapositives normales existantes. Testez les modifications de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de disposition inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) pour supprimer les dispositions auxquelles aucune diapositive normale ne fait référence. La méthode laisse intactes les dispositions encore en cours d’utilisation.

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

Pour supprimer une disposition spécifique, utilisez d’abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ou [getDependingSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Réaffectez les diapositives dépendantes avant d’appeler [ILayoutSlide.remove](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#remove--). Tenter de supprimer une disposition utilisée lève une [PptxEditException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de disposition**

Une disposition possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la méthode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) pour contrôler ces espaces réservés sur une disposition. Cela est utile lorsqu’une disposition de contenu doit afficher les pieds de page mais qu’une disposition de titre ne doit pas le faire.

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

## **Contrôler la visibilité du pied de page sur un maître et ses dispositions enfants**

Pour appliquer des réglages de pied de page cohérents sur toute la hiérarchie d’un maître, utilisez la méthode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Les méthodes de propagation de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives de disposition dépendantes et les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

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

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive de disposition appartient à un maître et définit un arrangement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis-je copier une diapositive de disposition d'une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par la disposition source.

**Que se passe-t-il lorsque je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) pour identifier les diapositives concernées avant de modifier la disposition.

**Que se passe-t-il si je supprime une disposition qui est encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxeditexception/). Réaffectez d’abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) pour ne supprimer que les dispositions non référencées.