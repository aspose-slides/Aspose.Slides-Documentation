---
title: Gestion des transitions de diapositives dans les présentations avec C++
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition Morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives, et personnaliser les transitions Morph et autres effets de transition avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les transitions de diapositives controlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides pour C++, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l'avancement par clic de souris ou par minuterie, et ajuster les options specific a un effet. Cet article utilise des exemples C++ pour appliquer des transitions, definir des durees de transition exactes, gerer le chronometrage des diapositives, et creer une transition Morph entre deux diapositives. Les exemples montrent egalement comment enregistrer les parametres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une presentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et accedez aux parametres de transition d'une diapositive via [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Appelez [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) avec une valeur de l'enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) puis enregistrez la presentation.

L'exemple suivant applique une transition Circle a la premiere diapositive et une transition Comb a la deuxieme. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Transition roue**

La methode [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) de [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) controle le nombre de secteurs radiaux qui devoilent la diapositive de destination. Appelez [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) avec Wheel de l'enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) avant d'acceder a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) en tant que [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Cet exemple cree deux paires identiques de diapositives: une diapositive noire suivie d'une diapositive contenant un rectangle dore. Les diapositives de destination utilisent des comptes de rayons de 1 et 8, avec la meme vitesse definie via [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) et une duree explicite de 8 000 millisecondes definie via [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) pour rendre la difference facile a observer.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Ouvrez la presentation de sortie dans PowerPoint et lancez le diaporama. Passez de la diapositive 1 a la diapositive 2, puis de la diapositive 3 a la diapositive 4. Dans la lecture PowerPoint, le nombre de rayons verifie de 1 devoile la diapositive avec un balayage horaire unique; le nombre verifie de 8 la devoile a travers huit secteurs radiaux simultanement. Le contenu de destination et le chronometrage de la transition sont identiques, la difference reside donc dans le nombre de secteurs de dévoilement.

## **Ajouter une transition de diapositive avancee**

Vous pouvez configurer la duree d'affichage d'une diapositive a l'ecran et si un clic de souris avance le diaporama. Les methodes suivantes controlent ce comportement:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) permet au spectateur d'avancer en cliquant la souris.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) active l'avancement automatique.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specifie le delai avant l'avancement automatique, en millisecondes.

Activez a la fois l'avancement par clic et par minuterie pour permettre au spectateur de passer a la diapositive suivante avec un clic ou d'attendre le minuteur. Pour n'utiliser que le minuteur, appelez [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) avec `false`. Le delai controle le moment ou le diaporama avance; il ne definit pas la duree de l'effet de transition visuel.

Cet exemple attribue differents effets aux trois premieres diapositives et active l'avancement automatique apres 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent egalement avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Pour verifier si l'avancement chronometre est active, appelez [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Un delai stocke seul n'indique pas que le minuteur est actif.

L'exemple suivant ouvre le fichier enregistre ci-dessus, signale chaque minuteur active, et desactive l'avancement automatique pour les diapositives dont le delai est superieur a deux secondes. Il active les clics de souris pour ces diapositives et enregistre les parametres mis a jour.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Controler precisement le chronometrage des transitions**

Utilisez [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) pour specifie la duree exacte d'un effet de transition en millisecondes. La methode [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositive expose ces parametres via [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Méthode | Objectif |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Definie la duree de l'effet de transition lui-meme, en millisecondes. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Definie le delai avant que la diapositive avance automatiquement, en millisecondes. Appelez [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) avec `true` pour activer ce minuteur. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Selectionne une categorie de vitesse predeterminee dans [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ou Fast. Elle est utilisee lorsqu'aucune duree exacte n'est specifiee. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ne controle que l'effet de transition; il ne determine pas la duree pendant laquelle la diapositive reste visible. Configurez separement le delai d'avancement automatique. Lorsqu'aucune duree explicite n'est definie, Aspose.Slides determine la duree de l'effet a partir du type de transition et de la valeur renvoyee par [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Des barres separees identifient la duree de transition de 750 ms et le reglage d'avancement automatique de 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L'exemple partage applique a chaque diapositive une transition Fade de 750 ms et active separement l'avancement automatique a 5 000 ms. La duree de la transition controle l'effet; l'avancement controle le moment de quitter la diapositive. Ces barres sont des reglage schematique, pas une chronologie combinee mesuree.*
<!-- visual-explanation:slide-transition:end -->

### **Appliquer la meme duree a chaque diapositive**

Pour un rythme coherent, appliquez le meme effet et la meme duree exacte a chaque diapositive. Cet exemple charge `input.pptx`, selectionne Fade dans [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), et attribue a chaque transition une duree de 750 millisecondes. Il active separement l'avancement automatique apres 5 000 millisecondes et desactive l'avancement par clic de souris, puis enregistre le resultat au format PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Configurer l'avancement automatique independamment de la duree de l'effet.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Definir des durees differentes pour chaque diapositive**

Des diapositives differentes peuvent utiliser des durees d'effet differentes. Par exemple, utilisez une transition brève pour une diapositive de titre et une transition plus longue pour une introduction de section. Cet exemple definit 500 millisecondes pour la premiere diapositive et 1 200 millisecondes pour la deuxieme. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Coordonner les transitions avec la sortie animee**

Lors de la preparation d'un [GIF anime](/slides/fr/cpp/convert-powerpoint-to-animated-gif/), d'une [presentation HTML5](/slides/fr/cpp/export-to-html5/), ou d'une [video](/slides/fr/cpp/convert-powerpoint-to-video/), definissez des durees de transition exactes avant l'exportation afin d'ajuster le rythme prevu. Par exemple, utilisez un fondu de 600 millisecondes entre les scenes, et ajustez separement le delai d'avancement de chaque diapositive pour laisser le temps a la narration ou au contenu.

Pour les GIF et les videos, coordonnez la frequence d'images de sortie avec la duree de l'effet: 600 millisecondes correspondent a 18 images a 30 images par seconde. En HTML5, activez les transitions animees dans les parametres d'exportation. Verifiez les effets et options de chronometrage pris en charge par le format d'exportation choisi, et preview la sortie pour confirmer la synchronisation.

### **Lire la duree d'une transition existante**

Appelez [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) avant de modifier la transition afin de determiner si une valeur explicite est stockee. Une valeur de `-1` signifie qu'aucune duree explicite n'est definie; une valeur non negative indique la duree stockee en millisecondes. La valeur non definie n'est pas la duree de lecture calculee: Aspose.Slides utilise le type de transition et la valeur renvoyee par [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) pour determiner cette duree. La definition d'un type de transition peut initialiser une duree, il est donc recommande d'inspecter d'abord les parametres d'origine.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Transition Morph**

La transition Morph anime les changements entre les objets sur des diapositives consecutives. Pour creer un effet Morph simple, dupliquez une diapositive, deplacez ou redimensionnez un objet sur la duplication, et appliquez la transition Morph a la deuxieme diapositive. Cela fournit a la transition les objets correspondants a animer entre leurs etats d'origine et modifie.

L'exemple suivant cree une diapositive contenant un rectangle texte, duplique la diapositive, et modifie la position et la taille du rectangle sur la duplication. Il selectionne ensuite Morph dans l'enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) pour la deuxieme diapositive. Ouvrez le fichier enregistre dans un visualiseur de presentation prenant en charge Morph pour voir l'effet pendant un diaporama.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Types de transition Morph**

L'enumeration [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) controle la facon dont Morph fait correspondre et anime le contenu:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) traite chaque forme comme un objet entier.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les mots lorsque c'est possible.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les caracteres lorsque c'est possible.

Appelez [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) avec Morph avant d'acceder a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). La valeur fournit alors l'interface [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), dont la methode [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) selectionne le mode de correspondance.

Cet exemple ouvre la presentation creee dans la section precedente et configure la deuxieme diapositive pour utiliser l'animation Morph basee sur les mots.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Definir les effets de transition**

Certaines transitions exposent des options supplementaires, comme la direction ou si l'effet demarre a partir d'un ecran noir. Les options disponibles depandent du type de transition selectionne. Definissez d'abord le type, puis utilisez l'interface appropriee renvoyee par [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

L'exemple suivant applique une transition Cut a la premiere diapositive de `input.pptx`. Il appelle [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) avec `true` via [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) afin que la transition demarre a partir d'un ecran noir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Puis-je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Preferez [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) lorsqu’une catégorie prédéfinie [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) : Slow, Medium ou Fast suffit et qu’aucune durée explicite n’est définie. Ces réglages contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis-je attacher de l’audio à une transition et le faire boucler ?**

Oui. Assignez l’audio intégré avec [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), appelez [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) avec StartSound de l’enumeration [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/), et activez la boucle avec [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). L’audio boucle jusqu’au prochain événement sonore dans le diaporama.

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Parcourez la collection retournee par la methode [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) de la presentation et appelez [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) avec la meme valeur pour chaque transition de diapositive. Definissez les options de chronometrage et d’effet dans la meme boucle pour garder un comportement coherent sur toutes les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) sur la transition renvoyée par la methode [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositive. Elle renvoie une valeur de l’enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) ; None signifie qu’aucun effet de transition n’est applique.