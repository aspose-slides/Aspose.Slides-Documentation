---
title: Gérer les espaces réservés de présentation en C++
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/cpp/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à inspecter et à modifier les espaces réservés de texte, d'image, de graphique et de contenu, ainsi qu'à comprendre l'héritage des espaces réservés avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type de contenu particulier dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d’image, de graphique et les espaces réservés de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de mise en page ou d’une diapositive maîtresse.

Aspose.Slides expose les informations d’espace réservé via la méthode [IShape::get_Placeholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_placeholder/). La méthode renvoie un objet [IPlaceholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iplaceholder/) ou `nullptr` pour une forme normale. Utilisez [IPlaceholder::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iplaceholder/get_type/) pour déterminer ce que l’espace réservé est censé contenir.

L’interface de forme reste pertinente après avoir identifié le type d’espace réservé :

- Un espace réservé vide de texte, d’image, de graphique ou de contenu est généralement représenté par un [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/).
- Un espace réservé d’image rempli peut être représenté par un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [IPlaceholder::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iplaceholder/get_type/) et l’interface de forme d’exécution au lieu de supposer que chaque espace réservé est un [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iplaceholder/get_type/) décrit le rôle d’un espace réservé ; il ne garantit pas le type d’exécution de la forme. Effectuez toujours une vérification de type avant d’accéder aux membres spécifiques texte, image, graphique, tableau ou média.
{{% /alert %}}

## **Comprendre l’héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maîtresse définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau maître.
2. Une diapositive de mise en page définit l’agencement utilisé par une ou plusieurs diapositives normales et peut hériter de la maîtresse.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getbaseplaceholder/) pour remonter d’un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `nullptr` lorsque la forme n’a aucun espace réservé de base.

L’exemple suivant répertorie les espaces réservés de la première diapositive et indique leurs espaces réservés de base :

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Modifier un espace réservé sur une diapositive normale crée ou modifie un remplacement local pour cette diapositive. Modifier la mise en page ou le maître associés peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme ordinaire locale n’a aucun espace réservé de base et ne commence pas à hériter simplement parce qu’elle occupe les mêmes coordonnées.

## **Modifier le texte d’un espace réservé**

Les espaces réservés de titre, de titre centré, de sous-titre, de corps et de texte prennent généralement en charge le texte. Vérifiez qu’il s’agit d’un [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) avant d’utiliser sa méthode [get_TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/get_textframe/).

Cet exemple met à jour le premier espace réservé de titre de la première diapositive et enregistre le résultat :

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ce modèle évite de convertir les espaces réservés d’image, de graphique, de tableau ou de média en [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/). Il identifie également l’espace réservé par son objectif au lieu de se fier à un indice de forme fragile.

## **Définir le texte d’invite sur une mise en page**

Le texte d’invite est l’instruction affichée en mode conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez un texte d’invite personnalisé sur l’espace réservé de la mise en page plutôt que d’essayer d’y accéder via la collection de formes d’une diapositive normale. Accédez à la mise en page via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/get_layoutslide/) et parcourez [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_shapes/).

L’exemple suivant modifie les invites de titre et de sous-titre sur la mise en page utilisée par la première diapositive :

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Le texte d’invite n’est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d’édition telles que PowerPoint. Une fois qu’un utilisateur ou un programme fournit du vrai contenu, l’invite n’est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d’image**

Deux cas à gérer :

- Si l’espace réservé d’image est déjà renseigné et représenté par un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/), remplacez l’image via [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/get_picture/) et [ISlidesPicture::set_Image](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/set_image/).
- S’il s’agit encore d’un espace réservé vide, ajoutez un cadre d’image aux coordonnées de l’espace réservé avec [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addpictureframe/) et supprimez l’espace réservé vide.

L’exemple suivant prend en charge les deux cas et enregistre la présentation :

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Le remplacement créé pour un espace réservé vide est un cadre d’image local, pas un nouvel espace réservé, car [IShape::get_Placeholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_placeholder/) est en lecture seule. Il conserve la position réservée mais n’hérite plus du comportement spécifique à l’espace réservé. Si la conservation de la relation d’espace réservé est essentielle, préparez et remplissez l’espace réservé dans PowerPoint d’abord, puis mettez à jour le [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) résultant avec Aspose.Slides.

Pour la transparence d’image, le rognage et d’autres effets spécifiques à l’image, consultez [Gestion des cadres d’image](/slides/fr/cpp/picture-frame/). Ces opérations appartiennent au cadre d’image ou au remplissage d’image, pas aux métadonnées de l’espace réservé.

## **Travailler avec les espaces réservés de graphique et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/). Cet exemple trouve un tel graphique en fonction du type d’espace réservé et de l’interface d’exécution, modifie son titre et enregistre le fichier :

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Un espace réservé de contenu général possède généralement [PlaceholderType::Object](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, y compris les graphiques, tableaux, diagrammes, images et médias. Après qu’il a été renseigné, inspectez l’interface réelle de la forme pour savoir ce qu’elle contient. Les mises en page spécialisées peuvent également exposer [PlaceholderType::Chart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/fr/cpp/aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un espace réservé vide de type [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) en [IChart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/) simplement en modifiant [IPlaceholder::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iplaceholder/get_type/); le type est en lecture seule. Pour remplir programmétiquement un graphique ou une zone de contenu vide, ajoutez l’objet requis aux coordonnées de l’espace réservé, puis supprimez l’espace réservé vide. L’exemple suivant le fait pour un graphique :

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l’espace réservé mais n’hérite pas de la mise en page de l’espace réservé. Utilisez les articles dédiés à la [gestion des graphiques](/slides/fr/cpp/powerpoint-charts/) lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : mettre à jour le texte ou le contenu d’image**

L’exemple de bout en bout suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d’image, vérifie les types d’espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L’exemple évite délibérément de supposer un indice de forme ou de convertir chaque espace réservé à la même interface.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Qu’est‑ce qu’un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont un autre espace réservé hérite. Utilisez [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getbaseplaceholder/) pour le récupérer. Une forme locale ordinaire renvoie `nullptr` parce qu’elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis‑je modifier tous les titres de diapositives en éditant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage hérité ou le texte d’invite via une mise en page, mais le contenu réel du titre est stocké sur les diapositives normales. Pour remplacer le texte réel des titres dans toute la présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéro de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d’en‑tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du support d’impression. Consultez [Gestion des en‑têtes et pieds de page de la présentation](/slides/fr/cpp/presentation-header-and-footer/) pour des exemples complets.