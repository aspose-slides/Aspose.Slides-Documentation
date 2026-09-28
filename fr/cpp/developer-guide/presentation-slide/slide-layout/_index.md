---
title: Appliquer ou modifier les dispositions de diapositives en C++
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/cpp/slide-layout/
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
- C++
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour C++, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition offre aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes comprennent :

- **Title Slide** : Contains title and subtitle placeholders.
- **Title and Content** : Contains a title placeholder and a general-purpose content placeholder.
- **Blank** : Contains no content placeholders and is useful when every shape will be positioned manually.

## **Comprendre l'héritage des dispositions**

Une présentation comporte trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/) définit le thème, le formatage partagé, les arrière-plans et les objets communs.
1. Une [diapositive de disposition](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/) appartient à une maître et définit un agencement particulier d'espaces réservés.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espaces réservés sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter un autre espace réservé à une disposition ultérieurement n’ajoute pas automatiquement la forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation entraîne deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réaffectez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, voir [Slide Master](/slides/fr/cpp/slide-master/).

Pour masquer les logos hérités ou les formes décoratives du maître sur une diapositive ou via une disposition partagée, consultez [Control the Visibility of Master Graphics](/slides/fr/cpp/slide-master/). L’exemple compare deux diapositives utilisant le même maître.

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de dispositions standard de PowerPoint. Les noms de dispositions sont éditables par l’utilisateur et peuvent être localisés, ainsi la sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L’exemple suivant recherche **Title and Content** sur le premier maître. Si cette disposition n’est pas disponible, il revient volontairement à **Blank**. La seconde vérification de nullité est nécessaire parce qu’une présentation peut ne contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du basculement entre des dispositions substantiellement différentes.

## **Ajouter une diapositive de disposition**

La sélection et la création sont des opérations séparées. L’exemple précédent sélectionne une disposition existante ; il n’en crée pas une nouvelle. Pour créer une disposition, appelez la méthode [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterlayoutslidecollection/add/) sur la collection de dispositions du maître cible.

L’exemple suivant ajoute toujours une nouvelle disposition **Title and Content** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de dispositions doivent être uniques au sein de la collection.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ajoutez une disposition uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si une disposition adéquate existe déjà, sélectionnez‑la et réutilisez‑la au lieu d’en créer une duplicate.

## **Ajouter des espaces réservés à une diapositive de disposition**

La méthode [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) fournit un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/) pour ajouter des formes d’espaces réservés à une disposition.

| Espace réservé PowerPoint          | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Contenu](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenu (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texte](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Texte (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Image](picture.png)                | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Graphique](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tableau](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Image en ligne](onlineImage.png)   | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

L’exemple suivant vérifie que la disposition **Blank** existe, ajoute quatre espaces réservés à celle‑ci, puis crée une diapositive normale qui utilise la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, de sorte qu’Aspose.Slides puisse générer les formes d’espaces réservés correspondantes sur cette diapositive.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants dans une disposition peut affecter les diapositives dépendantes. Un espace réservé ajouté récemment n’est pas rétro‑alimenté dans les diapositives normales existantes. Testez les modifications de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de disposition inutilisées**

Utilisez la méthode [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour supprimer les dispositions qui ne sont référencées par aucune diapositive normale. La méthode laisse intactes les dispositions encore utilisées.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour supprimer une disposition spécifique, utilisez d’abord sa méthode [get_HasDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ou [GetDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/getdependingslides/). Réaffectez les diapositives dépendantes avant d’appeler [ILayoutSlide::Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/remove/). Tenter de supprimer une disposition utilisée déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de disposition**

Une disposition possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la méthode [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) pour contrôler ces espaces réservés pour une disposition. Ceci est utile, par exemple, lorsqu’il faut afficher les pieds de page sur les dispositions de contenu mais pas sur les dispositions de titre.

L’exemple suivant sélectionne une disposition en toute sécurité et rend ses éléments de pied de page visibles :

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Contrôler la visibilité du pied de page sur un maître et ses dispositions enfants**

Pour appliquer des paramètres de pied de page cohérents à travers une hiérarchie de maîtres, utilisez la méthode [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Les méthodes de propagation de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses dispositions dépendantes et sur les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème et le formatage partagé de la présentation. Une diapositive de disposition appartient à un maître et définit un agencement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive de disposition d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par la disposition source.

**Que se passe‑t‑il si je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition, sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [GetDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/getdependingslides/) pour identifier les diapositives concernées avant de modifier la disposition.

**Que se passe‑t‑il si je supprime une disposition encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxeditexception/). Réaffectez d’abord les diapositives dépendantes, ou utilisez [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour supprimer uniquement les dispositions non référencées.