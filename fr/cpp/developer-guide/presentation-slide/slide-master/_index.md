---
title: Gérer les maîtres de diapositives de présentation en C++
linktitle: Maître de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-master/
keywords:
- maître de diapositive
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
- C++
- Aspose.Slides
description: "Gérer les maîtres de diapositives dans Aspose.Slides pour C++ : accéder, modifier, cloner, comparer et supprimer les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un slide master est la méthode habituelle pour garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for C++ prend en charge le même modèle. Une présentation peut contenir une ou plusieurs diapositives maîtres, et chaque diapositive maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas référence directement à une diapositive maître. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, qui appartient à une diapositive maître.

La hiérarchie est :

1. **Slide master** - définit la conception partagée et le thème.  
1. **Layout slide** - définit un arrangement spécifique d’espaces réservés et de formatage au niveau de la mise en page.  
1. **Normal slide** - contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![Hiérarchie des diapositives maîtres, des diapositives de mise en page et des diapositives normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/). Toutes les diapositives maîtres d’une présentation sont accessibles via la collection [Presentation::get_Masters](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_masters/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Héritage" %}}

Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si une diapositive maître et une diapositive de mise en page définissent toutes deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, consultez [Appliquer ou modifier les mises en page des diapositives](/slides/fr/cpp/slide-layout/).

{{% /alert %}}

## **Accéder aux slide masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **Affichage** > **Slide Master**.

![Commande Slide Master dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `get_Masters()` pour accéder aux diapositives maîtres :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Vous pouvez également obtenir la diapositive maître utilisée par une diapositive normale via sa mise en page :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Ce que contient un slide master**

Une diapositive maître est un objet semblable à une diapositive. Elle implémente [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/), de sorte qu’elle expose de nombreuses propriétés de diapositive également utilisées par les diapositives normales et de mise en page. Les membres spécifiques au maître sont répertoriés sur la page d’API [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/).

Les membres de slide master les plus couramment utilisés comprennent :

| Membre | Fonction |
| --- | --- |
| `get_Background()` | Définit l’arrière‑plan de la diapositive au niveau du master. |
| `get_Shapes()` | Stocke les formes placées sur le master, comme les logos, les cadres d’image et le texte partagé. |
| `get_LayoutSlides()` | Stocke les diapositives de mise en page appartenant au master. |
| `get_ThemeManager()` | Fournit l’accès aux API du thème du master. |
| `get_HeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le master et ses mises en page enfants. |
| `GetDependingSlides()` | Renvoie les diapositives normales dépendant du master via leurs mises en page. |

## **Ajouter une image à un slide master**

Lorsque vous ajoutez une image à une diapositive maître, elle apparaît sur les diapositives qui utilisent des mises en page provenant de ce master. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

```cpp
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

Pour plus d’informations sur les cadres d’image, consultez [Cadre d’image](/slides/fr/cpp/picture-frame/).

## **Travailler avec les espaces réservés**

Les espaces réservés sont normalement définis sur les diapositives de mise en page. La diapositive maître fournit le style partagé et le thème que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles dans la vue Slide Master.

![Commande Insérer un espace réservé dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au master :

```cpp
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

Vous pouvez également formater les formes d’espace réservé déjà présentes sur une diapositive maître. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage en dégradé linéaire :

```cpp
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

![Espace réservé de titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d’options de formatage des espaces réservés et du texte, consultez [Définir le texte d’invite dans un espace réservé](/slides/fr/cpp/manage-placeholder/) et [Mise en forme du texte](/slides/fr/cpp/text-formatting/).

## **Modifier l’arrière‑plan d’un slide master**

Un arrière‑plan de master est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour la première diapositive maître :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour des sujets associés, consultez [Arrière‑plan de la présentation](/slides/fr/cpp/presentation-background/) et [Thème de la présentation](/slides/fr/cpp/presentation-theme/).

## **Cloner un slide master vers une autre présentation**

Utilisez [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/) pour copier une diapositive maître dans une autre présentation. Le master copié peut alors être utilisé par les mises en page et les diapositives de la présentation de destination.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Si vous devez cloner des diapositives normales avec leur master, consultez [Cloner des diapositives](/slides/fr/cpp/clone-slides/).

## **Ajouter plusieurs slide masters**

Une présentation peut contenir plusieurs diapositives maîtres. Cela est utile lorsque différentes sections nécessitent un branding, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les diapositives maîtres](slide-master_9.jpg)

L’exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce master cloné, puis ajoute une nouvelle diapositive basée sur cette mise en page :

```cpp
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

Les diapositives maîtres peuvent être comparées avec la méthode `Equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les ID de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

```cpp
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

Pour plus d’informations, consultez [Comparer les diapositives d’une présentation](/slides/fr/cpp/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode `set_LastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour plus de paramètres d’affichage, consultez [Enregistrer la présentation](/slides/fr/cpp/save-presentation/).

## **Supprimer les slide masters inutilisés**

Les présentations contiennent parfois des diapositives maîtres qui ne sont plus utilisées par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/fr/cpp/aspose.slides/masterslidecollection/removeunused/) pour supprimer les maîtres inutilisés de la collection `get_Masters()` :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vous pouvez également utiliser la méthode low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Quelle est la différence entre un slide master et une diapositive de mise en page ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un slide master et définit un arrangement spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de mise en page, et hérite ainsi à la fois de la mise en page et du master.

**Une présentation peut-elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou un branding différents.

**Devrais‑je ajouter des espaces réservés à une diapositive maître ou à une diapositive de mise en page ?**

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage partagé sur la diapositive maître, puis ajoutez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis‑je supprimer une diapositive maître qui est encore utilisée ?**

Non. Une diapositive maître qui possède des diapositives dépendantes ne peut pas être supprimée en toute sécurité directement. Déplacez d’abord ces diapositives vers des mises en page sous un autre master, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas en usage.