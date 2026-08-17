---
title: "Appliquer ou modifier les mises en page de diapositives en C++"
linktitle: "Mise en page de diapositive"
type: docs
weight: 60
url: /fr/cpp/slide-layout/
keywords:
- "mise en page de diapositive"
- "mise en page de contenu"
- "espace réservé"
- "conception de présentation"
- "conception de diapositive"
- "mise en page inutilisée"
- "visibilité du pied de page"
- "diapositive de titre"
- "titre et contenu"
- "en-tête de section"
- "deux contenus"
- "comparaison"
- "titre uniquement"
- "mise en page vide"
- "contenu avec légende"
- "image avec légende"
- "titre et texte vertical"
- "titre vertical et texte"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "C++"
- "Aspose.Slides"
description: "Appliquer, créer et modifier les mises en page de diapositives dans Aspose.Slides pour C++, ajouter des espaces réservés, supprimer les mises en page inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une mise en page de diapositive définit les positions et le formatage des zones réservées telles que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une mise en page donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les mises en page les plus courantes comprennent :

- **Diapositive de titre** : Contient des zones réservées pour le titre et le sous-titre.
- **Titre et contenu** : Contient une zone réservée pour le titre et une zone réservée de contenu à usage général.
- **Vide** : Ne contient aucune zone réservée de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des mises en page**

Une présentation possède trois niveaux associés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/) définit le thème, le formatage partagé, les arrière-plans et les objets communs.
1. Une [diapositive de mise en page](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/) appartient à un maître et définit un arrangement particulier de zones réservées.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/) utilise une mise en page et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa mise en page, et la mise en page hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes de zone réservée sont générées à partir de la mise en page sélectionnée, tandis que le contenu saisi dans ces zones appartient à la diapositive normale.

Ajoutez les zones réservées requises à une mise en page avant de créer des diapositives à partir de celle‑ci. L’ajout ultérieur d’une autre zone réservée à une mise en page n’ajoute pas automatiquement une forme de zone réservée correspondante aux diapositives normales existantes.

Cette relation entraîne deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des zones réservées existantes sur une mise en page peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une mise en page déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une mise en page encore utilisée par une diapositive ne peut pas être supprimée. Réassigniez d’abord ses diapositives dépendantes à une autre mise en page, ou supprimez uniquement les mises en page inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, consultez [Maître de diapositive](/slides/fr/cpp/slide-master/).

## **Sélectionner et appliquer une mise en page de diapositive**

Utilisez un type de mise en page lorsque la présentation suit les définitions de mise en page standard de PowerPoint. Les noms de mise en page sont modifiables par l’utilisateur et peuvent être localisés, de sorte que la sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L’exemple suivant recherche **Titre et contenu** sur le premier maître. Si cette mise en page est indisponible, il revient délibérément à **Vide**. La deuxième vérification de nullité est nécessaire car une présentation peut ne contenir que des mises en page personnalisées. La mise en page sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/set_layoutslide/).

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

Modifier la mise en page d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des zones réservées, le formatage hérité et la correspondance entre les zones réservées existantes et la nouvelle mise en page peuvent changer, il faut donc inspecter le résultat lors du passage entre des mises en page substantiellement différentes.

## **Ajouter une diapositive de mise en page**

La sélection et la création sont des opérations distinctes. L’exemple précédent sélectionne une mise en page existante ; il ne la crée pas. Pour créer une mise en page, appelez la méthode [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterlayoutslidecollection/add/) sur la collection de mises en page du maître cible.

L’exemple suivant ajoute toujours une nouvelle mise en page **Titre et contenu** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de mise en page doivent être uniques au sein de la collection.

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

Ajoutez une mise en page uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si une mise en page appropriée existe déjà, sélectionnez‑la et réutilisez‑la au lieu de créer un doublon.

## **Ajouter des zones réservées à une diapositive de mise en page**

La méthode [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) fournit un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/) pour ajouter des formes de zones réservées à une mise en page.

| Zone réservée PowerPoint            | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Contenu](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenu (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texte](text.png)                  | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Texte (Vertical)](textV.png)      | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Image](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Graphique](chart.png)             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tableau](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Image en ligne](onlineImage.png)  | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

L’exemple suivant vérifie que la mise en page **Vide** existe, y ajoute quatre zones réservées, puis crée une diapositive normale qui utilise la mise en page modifiée. L’ordre est intentionnel : les zones réservées sont ajoutées avant la création de la diapositive normale, afin qu’Aspose.Slides puisse générer les formes de zone réservée correspondantes sur cette diapositive.

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

![Les zones réservées sur la diapositive de mise en page](add_placeholders.png)

{{% alert color="warning" title="Avertissement" %}}
Modifier le formatage hérité ou la géométrie des zones réservées existantes sur une mise en page peut affecter les diapositives dépendantes. Une zone réservée nouvellement ajoutée n’est pas rétro‑appliquée aux diapositives normales existantes. Testez les changements de mise en page sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de mise en page inutilisées**

Utilisez la méthode [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour supprimer les mises en page qui ne sont référencées par aucune diapositive normale. La méthode laisse intactes les mises en page encore utilisées.

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

Pour supprimer une mise en page spécifique, utilisez d’abord sa méthode [get_HasDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ou [GetDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/getdependingslides/). Réassigniez toutes les diapositives dépendantes avant d’appeler [ILayoutSlide::Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/remove/). Tenter de supprimer une mise en page utilisée déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de mise en page**

Une mise en page possède ses propres zones réservées de pied de page, de numéro de diapositive et de date/heure. Utilisez la méthode [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) pour contrôler ces zones réservées pour une mise en page. Cela est utile, par exemple, lorsque les mises en page de contenu doivent afficher les pieds de page mais pas les mises en page de titre.

L’exemple suivant sélectionne une mise en page de manière sécurisée et rend ses éléments de pied de page visibles :

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

## **Contrôler la visibilité du pied de page sur un maître et ses mises en page enfants**

Pour appliquer des paramètres de pied de page cohérents sur toute la hiérarchie d’un maître, utilisez la méthode [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Les méthodes de propagation de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives de mise en page dépendantes et ses diapositives normales ; elles ne ciblent pas une seule diapositive normale.

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

**Quelle est la différence entre une diapositive maître et une diapositive de mise en page ?**

Une diapositive maître définit le thème et le formatage partagé de la présentation. Une diapositive de mise en page appartient à un maître et définit un arrangement réutilisable de zones réservées. Les diapositives normales utilisent ces mises en page et stockent le contenu propre à chaque diapositive.

**Puis-je copier une diapositive de mise en page d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par la mise en page source.

**Que se passe-t-il lorsque je modifie une mise en page déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la mise en page sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des zones réservées et le style hérité peuvent donc changer sur de nombreuses diapositives à la fois. Utilisez [GetDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/getdependingslides/) pour identifier les diapositives affectées avant de modifier la mise en page.

**Que se passe-t-il si je supprime une mise en page qui est toujours utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxeditexception/). Réassigniez d’abord les diapositives dépendantes, ou utilisez [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) pour supprimer uniquement les mises en page non référencées.