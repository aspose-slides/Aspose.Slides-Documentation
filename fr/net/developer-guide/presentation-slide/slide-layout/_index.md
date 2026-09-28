---
title: Appliquer ou modifier les dispositions de diapositives dans .NET
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/net/slide-layout/
keywords:
- disposition de diapositive
- disposition de contenu
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
- disposition vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- C#
- .NET
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour .NET, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes comprennent :

- **Diapositive titre** : contient des espaces réservés de titre et de sous‑titre.  
- **Titre et contenu** : contient un espace réservé de titre et un espace réservé de contenu à usage général.  
- **Vide** : ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des dispositions**

Une présentation possède trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.  
1. Une [diapositive de disposition](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/) appartient à un maître et définit un arrangement particulier d'espaces réservés.  
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son maître. Une valeur définie directement sur une diapositive normale outrepasse la valeur héritée à ce niveau. Lorsqu'une diapositive normale est créée, ses formes d'espaces réservés sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter un autre espace réservé à une disposition ultérieurement n’ajoute pas automatiquement une forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez les diapositives dépendantes et examinez la présentation résultante.  
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réattribuez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, voir [Maître de diapositive](/slides/fr/net/slide-master/).

Pour masquer les logos hérités ou les formes décoratives du maître sur une diapositive ou via une disposition partagée, voir [Control the Visibility of Master Graphics](/slides/fr/net/slide-master/). L’exemple compare deux diapositives utilisant le même maître.

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de dispositions standard de PowerPoint. Les noms de dispositions sont modifiables par l’utilisateur et peuvent être localisés, de sorte qu’une sélection basée sur le nom est moins fiable sauf si vous contrôlez le modèle source.

L’exemple suivant recherche **Titre et contenu** sur le premier maître. Si cette disposition n’est pas disponible, il revient délibérément à **Vide**. La deuxième vérification de nullité est nécessaire car une présentation ne peut contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la propriété [ISlide.LayoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```


Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du passage entre des dispositions sensiblement différentes.

## **Ajouter une diapositive de disposition**

La sélection et la création sont des opérations distinctes. L’exemple précédent sélectionne une disposition existante ; il ne la crée pas. Pour créer une disposition, appelez la méthode [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/fr/net/aspose.slides/masterlayoutslidecollection/add/) sur la collection de dispositions du maître cible.

L’exemple suivant ajoute toujours une nouvelle disposition **Titre et contenu** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de dispositions doivent être uniques au sein de la collection.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Ajoutez une disposition uniquement lorsque le modèle a réellement besoin d’une structure réutilisable supplémentaire. Si une disposition appropriée existe déjà, sélectionnez‑la et réutilisez‑la au lieu de créer un doublon.

## **Ajouter des espaces réservés à une diapositive de disposition**

La propriété [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/placeholdermanager/) fournit un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutplaceholdermanager/) pour ajouter des formes d’espaces réservés à une disposition.

| Espace réservé PowerPoint          | Méthode `ILayoutPlaceholderManager` |
| ----------------------------------- | ----------------------------------- |
| ![Contenu](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenu (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texte](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Texte (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Image](picture.png)                | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Graphique](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tableau](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Image en ligne](onlineImage.png)   | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

L’exemple suivant vérifie que la disposition **Vide** existe, ajoute quatre espaces réservés, puis crée une diapositive normale qui utilise la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu’Aspose.Slides puisse générer les formes d’espace réservé correspondantes sur cette diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Le résultat :

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut affecter les diapositives dépendantes. Un espace réservé de disposition ajouté récemment n’est pas rétro‑injecté dans les diapositives normales existantes. Testez les changements de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de disposition inutilisées**

Utilisez la méthode [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour supprimer les dispositions auxquelles aucune diapositive normale ne fait référence. La méthode conserve intactes les dispositions encore utilisées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Pour supprimer une disposition spécifique, utilisez d’abord sa propriété [HasDependingSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/hasdependingslides/) ou sa méthode [GetDependingSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/getdependingslides/). Réattribuez les diapositives dépendantes avant d’appeler [ILayoutSlide.Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/remove/). Tenter de supprimer une disposition utilisée soulève une [PptxEditException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de disposition**

Une disposition possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la propriété [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/headerfootermanager/) pour contrôler ces espaces réservés pour une disposition. Ceci est utile, par exemple, lorsque les dispositions de contenu doivent afficher les pieds de page mais que les dispositions de titre ne le doivent pas.

L’exemple suivant sélectionne une disposition en toute sécurité et rend ses éléments de pied de page visibles :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Contrôler la visibilité du pied de page sur un maître et ses dispositions enfant**

Pour appliquer des paramètres de pied de page cohérents dans toute la hiérarchie du maître, utilisez la propriété [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/headerfootermanager/). Les méthodes de propagation de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslideheaderfootermanager/) s’appliquent au maître ainsi qu’aux dispositions et diapositives normales qui en dépendent ; elles ne ciblent pas une seule diapositive normale.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème et le formatage partagé de la présentation. Une diapositive de disposition appartient à un maître et définit un arrangement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive de disposition d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/globallayoutslidecollection/addclone/). Lors de la copie entre présentations, vérifiez également les polices, thèmes, images et autres ressources utilisées par la disposition source.

**Que se passe‑t‑il si je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition, sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [GetDependingSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/getdependingslides/) pour identifier les diapositives concernées avant d’éditer la disposition.

**Que se passe‑t‑il si je supprime une disposition encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxeditexception/). Réattribuez d’abord les diapositives dépendantes, ou utilisez [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour ne supprimer que les dispositions non référencées.