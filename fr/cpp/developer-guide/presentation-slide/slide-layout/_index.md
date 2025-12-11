---
title: Appliquer ou modifier les mises en page des diapositives en C++
linktitle: Mise en page des diapositives
type: docs
weight: 60
url: /fr/cpp/slide-layout/
keywords:
- mise en page des diapositives
- mise en page du contenu
- espace réservé
- conception de présentation
- conception de diapositive
- mise en page inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seulement
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez et personnalisez les mises en page des diapositives avec Aspose.Slides pour C++. Explorez les types de mise en page, le contrôle des espaces réservés et la visibilité du pied de page à travers des exemples de code C++."
---

## **Vue d'ensemble**

Une mise en page de diapositive définit l'agencement des zones réservées et le formatage du contenu d’une diapositive. Elle contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les mises en page de diapositives vous aident à créer des présentations rapidement et de manière cohérente — que vous réalisiez quelque chose de simple ou de plus complexe. Parmi les mises en page de diapositives les plus courantes dans PowerPoint, on trouve :

**Disposition Diapositive Titre** – comprend deux zones réservées de texte : une pour le titre et une pour le sous‑titre.

**Disposition Titre et Contenu** – comporte une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Disposition Vierge** – ne contient aucune zone réservée, vous offrant le contrôle total pour concevoir la diapositive à partir de zéro.

Les mises en page de diapositives font partie d’un masque de diapositives, qui est la diapositive de niveau supérieur définissant les styles de mise en page pour la présentation. Vous pouvez accéder aux diapositives de mise en page et les modifier via le masque de diapositives—soit par leur type, leur nom, ou leur ID unique. Vous pouvez également modifier directement une mise en page spécifique dans la présentation.

Pour travailler avec les mises en page de diapositives dans Aspose.Slides for Android, vous pouvez utiliser :

- Des méthodes telles que [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) et [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) sous la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
- Des types comme [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/), et [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur la gestion des diapositives maîtres, consultez l'article [Slide Master](/slides/fr/cpp/slide-master/).
{{% /alert %}}

## **Ajouter des mises en page de diapositives aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouvelles diapositives de mise en page à une présentation. Aspose.Slides for Android vous permet de vérifier si une mise en page spécifique existe déjà, d’en ajouter une nouvelle si besoin, puis de l’utiliser pour insérer des diapositives basées sur cette mise en page.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accédez à la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Vérifiez si la diapositive de mise en page souhaitée existe déjà dans la collection. Si ce n’est pas le cas, ajoutez la mise en page dont vous avez besoin.
1. Ajoutez une diapositive vide basée sur la nouvelle mise en page.
1. Enregistrez la présentation.

Le code C++ suivant montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :
```cpp
// Instanciez la classe Presentation qui représente un fichier PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Situation où la présentation ne contient pas tous les types de mise en page.
    // Le fichier de présentation ne contient que les types de mise en page Blank et Custom.
    // Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
    // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de mise en page.
    // Vous pouvez également vous baser sur un ensemble de types de formes de zones réservées.
    // Par exemple, une diapositive Titre ne doit contenir que le type de zone réservée Title, etc.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Ajoutez une diapositive vide en utilisant la diapositive de mise en page ajoutée.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Enregistrez la présentation sur le disque.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) pour vous permettre de supprimer les diapositives de mise en page indésirables et inutilisées.

Le code C++ suivant montre comment supprimer une mise en page de diapositive d’une présentation PowerPoint :
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Ajouter des zones réservées aux mises en page de diapositives**

Aspose.Slides fournit la méthode [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) qui permet d’ajouter de nouvelles zones réservées à une diapositive de mise en page.

Ce gestionnaire contient des méthodes pour les types de zones réservées suivants :

| Espace réservé PowerPoint | Méthode [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) |
| -------------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| ![Contenu](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Contenu (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texte](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Texte (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Image](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Graphique](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tableau](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Image en ligne](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Le code C++ suivant montre comment ajouter de nouvelles formes de zones réservées à la mise en page Vierge :
```cpp
auto presentation = MakeObject<Presentation>();

// Obtenez la diapositive de mise en page vierge.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Obtenez le gestionnaire de zones réservées de la diapositive de mise en page.
auto placeholderManager = layout->get_PlaceholderManager();

// Ajoutez différentes zones réservées à la diapositive de mise en page vierge.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Ajoutez une nouvelle diapositive avec la mise en page vierge.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Le résultat :

![Les espaces réservés sur la diapositive de mise en page](add_placeholders.png)

## **Définir la visibilité du pied de page pour une diapositive de mise en page**

Dans les présentations PowerPoint, les éléments de pied de page comme la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon la mise en page. Aspose.Slides for Android vous permet de contrôler la visibilité de ces zones réservées de pied de page. Cela est utile lorsque vous souhaitez que certaines mises en page affichent les informations de pied de page tandis que d’autres restent épurées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Récupérez une référence à la diapositive de mise en page par son index.
1. Définissez la zone réservée du pied de page de la diapositive comme visible.
1. Définissez la zone réservée du numéro de diapositive comme visible.
1. Définissez la zone réservée de la date‑heure comme visible.
1. Enregistrez la présentation.

Le code C++ suivant montre comment définir la visibilité du pied de page d’une diapositive et effectuer les tâches associées :
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau de la diapositive maître afin d’assurer la cohérence sur toutes les diapositives de mise en page. Aspose.Slides for Android vous permet de définir la visibilité et le contenu de ces zones réservées de pied de page sur la diapositive maître et de propager ces paramètres à toutes les diapositives de mise en page enfants. Cette approche garantit une information de pied de page uniforme dans toute votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Récupérez une référence au masque maître par son index.
1. Définissez les zones réservées du pied de page du maître et de tous ses enfants comme visibles.
1. Définissez les zones réservées du numéro de diapositive du maître et de tous ses enfants comme visibles.
1. Définissez les zones réservées de la date‑heure du maître et de tous ses enfants comme visibles.
1. Enregistrez la présentation.

Le code C++ suivant illustre cette opération :
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de mise en page ?**

Une diapositive maître définit le thème global et le formatage par défaut, alors que les diapositives de mise en page définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis‑je copier une diapositive de mise en page d’une présentation à une autre ?**

Oui, vous pouvez cloner une diapositive de mise en page à partir de la collection de diapositives de mise en page d’une présentation, accessible via la méthode [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/), puis l’insérer dans une autre présentation à l’aide de la méthode `AddClone`.

**Que se passe‑t‑il si je supprime une diapositive de mise en page encore utilisée par une diapositive ?**

Si vous essayez de supprimer une diapositive de mise en page qui est toujours référencée par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) qui supprime uniquement les mises en page qui ne sont pas utilisées.