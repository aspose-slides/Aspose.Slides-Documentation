---
title: Gérer les masters de diapositives de présentation en C++
linktitle: Master de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-master/
keywords:
- master de diapositive
- diapositive master
- diapositive master PPT
- plusieurs masters de diapositives
- comparaison de masters de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive master
- copier la diapositive master
- dupliquer la diapositive master
- master de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérer les masters de diapositives dans Aspose.Slides pour C++ : accéder, modifier, cloner, comparer et supprimer les diapositives master dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit les paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière-plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d'un slide master est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for C++ prend en charge le même modèle. Une présentation peut contenir un ou plusieurs slide masters, et chaque slide master peut contenir plusieurs layout slides. Les diapositives normales ne font généralement pas référence directement à un slide master. Au lieu de cela, une diapositive normale utilise un layout slide, et ce layout slide appartient à un slide master.

La hiérarchie est :

1. **Slide master** – définit la conception et le thème partagés.  
1. **Layout slide** – définit une disposition spécifique d'espaces réservés et de formatage au niveau de la mise en page.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise une mise en page.

![La hiérarchie des slides maîtres, des slides de mise en page et des slides normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par l'interface [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/). Toutes les slides maîtres d'une présentation sont accessibles via la collection [Presentation::get_Masters](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_masters/) qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l'emporte. Par exemple, si un slide master et un layout slide définissent tous deux un arrière-plan, les diapositives basées sur cette mise en page utilisent l'arrière-plan de la mise en page. Pour plus d'informations sur les layout slides, voir [Apply or Change Slide Layouts](/slides/fr/cpp/slide-layout/).
{{% /alert %}}

## **Accéder aux slide masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **View** > **Slide Master**.

![La commande Slide Master dans l'onglet View de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `get_Masters()` pour accéder aux slide masters :

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Vous pouvez également obtenir le slide master utilisé par une diapositive normale via sa mise en page :

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Ce que contient un slide master**

Un slide master est un objet de type diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/), il expose donc de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page. Les membres spécifiques au master sont répertoriés sur la page API [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/).

Les membres de slide master les plus courants incluent :

| Membre | Objectif |
| --- | --- |
| `get_Background()` | Définit l'arrière-plan de la diapositive au niveau du master. |
| `get_Shapes()` | Contient les formes placées sur le master, telles que logos, cadres d'image et texte partagé. |
| `get_LayoutSlides()` | Contient les layout slides qui appartiennent au master. |
| `get_ThemeManager()` | Fournit l'accès aux API du thème du master. |
| `get_HeaderFooterManager()` | Contrôle les en-têtes, pieds de page, dates et numéros de diapositive pour le master et ses mises en page enfants. |
| `GetDependingSlides()` | Renvoie les diapositives normales qui dépendent du master via leurs mises en page. |

## **Ajouter une image à un slide master**

Lorsque vous ajoutez une image à un slide master, elle apparaît sur les diapositives qui utilisent les mises en page de ce master. Ceci est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels récurrents.

L'exemple suivant ajoute un logo au premier slide master :

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour plus d'informations sur les cadres d'image, voir [Picture Frame](/slides/fr/cpp/picture-frame/).

## **Contrôler la visibilité des graphiques du master**

Utilisez [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/set_showmastershapes/) pour masquer les graphiques du master hérités, tels que les logos ou formes décoratives, sans les supprimer du master. Passez `false` à [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/set_showmastershapes/) sur la diapositive qui doit omettre ces graphiques et `true` sur les diapositives qui doivent les afficher.

L'exemple autonome suivant crée une bande décorative bleue sur un master et deux diapositives qui utilisent la même mise en page vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d'entrée n'est requis.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'exemple utilise la mise en page **Blank** fournie avec une nouvelle présentation et supprime les espaces réservés de la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son master via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/get_layoutslide/) et [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_masterslide/). La définition de la propriété sur une diapositive individuelle n'affecte que cette diapositive. Passer `false` à [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/layoutslide/set_showmastershapes/) masque les graphiques du master pour les diapositives qui utilisent cette mise en page partagée, même si leur propre réglage est `true`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez la mise en page partagée inchangée.

Le paramètre n'est pas pris en charge comme contrôle de visibilité sur le slide master lui‑même. Sur un master il renvoie toujours `false`, et l'assignation de `true` lève une `System::NotSupportedException`. Appliquez‑le à une diapositive normale ou à une mise en page à la place.

### **Distinguer les graphiques de l'arrière-plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du master | Contrôle la visibilité des formes du master héritées sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage d'arrière-plan de la diapositive | Modifie la couleur, le dégradé ou l'image d'arrière-plan. Les graphiques du master sont des formes séparées et peuvent rester visibles au-dessus de cet arrière-plan. Voir [Presentation Background](/slides/fr/cpp/presentation-background/). |
| Supprimer une forme du master | Supprime la forme source partagée, de sorte qu'elle n'est plus disponible pour aucune diapositive utilisant ce master. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont normalement définis sur les layout slides. Le slide master fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d'espace réservé sont disponibles dans la vue Slide Master.

![La commande Insérer un espace réservé dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez avec le layout slide qui appartient au master :

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vous pouvez également formater les formes d'espace réservé déjà présentes sur un slide master. L'exemple suivant trouve l'espace réservé titre et applique un remplissage en dégradé linéaire :

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Espace réservé titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d'options de mise en forme des espaces réservés et du texte, voir [Set Prompt Text in Placeholder](/slides/fr/cpp/manage-placeholder/) et [Text Formatting](/slides/fr/cpp/text-formatting/).

## **Modifier l'arrière-plan d'un slide master**

Un arrière‑plan de master est hérité par les mises en page et les diapositives qui ne le remplacent pas. L'exemple suivant définit une couleur d'arrière‑plan unie pour le premier slide master :

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour les sujets associés, voir [Presentation Background](/slides/fr/cpp/presentation-background/) et [Presentation Theme](/slides/fr/cpp/presentation-theme/).

## **Cloner un slide master vers une autre présentation**

Utilisez [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/) pour copier un slide master dans une autre présentation. Le master copié peut alors être utilisé par les mises en page et les diapositives de la présentation de destination.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Si vous devez cloner des diapositives normales avec leur master, voir [Clone Slides](/slides/fr/cpp/clone-slides/).

## **Ajouter plusieurs slide masters**

Une présentation peut contenir plusieurs slide masters. Ceci est utile lorsque différentes sections nécessitent des identités visuelles, des structures de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les slide masters](slide-master_9.jpg)

L'exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce master cloné, puis ajoute une nouvelle diapositive basée sur cette mise en page :

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comparer les slide masters**

Les slide masters peuvent être comparés avec la méthode `Equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d'autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques d'espaces réservés, comme la date actuelle.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Pour plus d'informations, voir [Compare Presentation Slides](/slides/fr/cpp/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode `set_LastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L'exemple suivant ouvre la présentation en vue Slide Master :

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour d'autres paramètres de vue, voir [Save Presentation](/slides/fr/cpp/save-presentation/).

## **Supprimer les slide masters inutilisés**

Les présentations contiennent parfois des slide masters qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masters inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/fr/cpp/aspose.slides/masterslidecollection/removeunused/) pour supprimer les masters inutilisés de la collection `get_Masters()` :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vous pouvez également utiliser la méthode low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Quelle est la différence entre un slide master et un layout slide ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l'arrière‑plan, les formes communes et les styles de texte. Un layout slide appartient à un slide master et définit une disposition spécifique d'espaces réservés. Une diapositive normale utilise un layout slide, elle hérite donc à la fois de la mise en page et du master.

**Une présentation peut-elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs masters lorsque différentes sections nécessitent des systèmes visuels ou des identités de marque différents.

**Dois-je ajouter des espaces réservés à un slide master ou à un layout slide ?**

Dans la plupart des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage commun sur le slide master, puis placez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis-je supprimer un slide master qui est encore utilisé ?**

Non. Un slide master qui possède des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d'abord ces diapositives vers des mises en page sous un autre master, ou utilisez une méthode de nettoyage qui ne supprime que les masters non utilisés.