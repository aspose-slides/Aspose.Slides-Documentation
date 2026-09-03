---
title: Gestion des transitions de diapositives dans les présentations avec C++
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-transition/
keywords:
- transition de diapositive
- ajout de transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives et personnaliser les effets Morph et autres effets de transition avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les transitions de diapositives contrôlent la manière dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides pour C++, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l'avancement par clic de souris ou par minuteur, et ajuster les options propres à un effet. Cet article utilise des exemples C++ pour appliquer des transitions, définir des durées de transition exactes, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et accédez aux paramètres de transition d’une diapositive via [get_SlideShowTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Appelez [set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_type/) avec une valeur provenant de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitiontype/), puis enregistrez la présentation.

L’exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

## **Ajouter une transition avancée de diapositive**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et savoir si un clic de souris avance le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [set_AdvanceOnClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) permet au spectateur d’avancer en cliquant avec la souris.
- [set_AdvanceAfter](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceafter/) active l’avancement automatique.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) spécifie le délai avant l’avancement automatique, en millisecondes.

Activez à la fois le clic et l’avancement chronométré pour laisser le spectateur passer à la prochaine diapositive soit par un clic, soit en attendant le minuteur. Pour n’utiliser que le minuteur, appelez [set_AdvanceOnClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) avec `false`. Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l’effet visuel de transition.

Cet exemple assigne différents effets aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

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

Pour vérifier si l’avancement chronométré est activé, appelez [get_AdvanceAfter](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Un délai stocké seul n’indique pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé et désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

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

## **Contrôler précisément le minutage des transitions**

Utilisez [set_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_duration/) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La méthode [get_SlideShowTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositive expose ces paramètres via [ISlideShowTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/):

| Méthode | Objectif |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_duration/) | Définit la durée de l’effet de transition lui‑même, en millisecondes. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Définit le délai avant que la diapositive n’avance automatiquement, en millisecondes. Appelez [set_AdvanceAfter](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_advanceafter/) avec `true` pour activer ce minuteur. |
| [set_Speed](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_speed/) | Sélectionne une catégorie de vitesse prédéfinie parmi [TransitionSpeed](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionspeed/) : Lente, Moyenne ou Rapide. Elle est utilisée lorsqu’aucune durée exacte n’est spécifiée. |

[set_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_duration/) contrôle uniquement l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d’avancement automatique. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur renvoyée par [get_Speed](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitiontype/), et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l’avancement automatique après 5 000 millisecondes et désactive l’avancement par clic de souris, puis enregistre le résultat au format PPTX.

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

    // Configurer l'avancement automatique indépendamment de la durée de l'effet.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Définir des durées différentes pour chaque diapositive**

Différentes diapositives peuvent utiliser des durées d’effet différentes. Par exemple, utilisez une transition brève pour une diapositive de titre et une transition plus longue pour une introduction de section. Cet exemple fixe 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

### **Coordonner les transitions avec la sortie animée**

Lorsque vous préparez un [animated GIF](/slides/fr/cpp/convert-powerpoint-to-animated-gif/), une [HTML5 presentation](/slides/fr/cpp/export-to-html5/) ou une [video](/slides/fr/cpp/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l’exportation afin de correspondre au rythme souhaité. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d’avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez le taux d’images de sortie avec la durée de l’effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d’exportation. Vérifiez les effets et les options de minutage pris en charge par le format d’export choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d’une transition existante**

Appelez [get_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_duration/) avant de modifier la transition afin de déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu’aucune durée explicite n’est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur renvoyée par [get_Speed](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_speed/) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, il est donc conseillé d’inspecter d’abord les paramètres d’origine.

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

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, dupliquez une diapositive, déplacez ou redimensionnez un objet sur la copie, puis appliquez la transition Morph à la seconde diapositive. Cela fournit à la transition les objets correspondants à animer entre leurs états d’origine et modifié.

L’exemple suivant crée une diapositive contenant un rectangle de texte, duplique la diapositive et modifie la position et la taille du rectangle sur la copie. Il sélectionne ensuite Morph dans l’énumération [TransitionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitiontype/) pour la seconde diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentations qui prend en charge Morph pour voir l’effet pendant un diaporama.

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

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionmorphtype/) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les mots lorsque c’est possible.
- [ByChar](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les caractères lorsque c’est possible.

Appelez [set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_type/) avec Morph avant d’accéder à [get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_value/). La valeur fournit alors l’interface [IMorphTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/imorphtransition/), dont la méthode [set_MorphType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) sélectionne le mode de correspondance.

Cet exemple ouvre la présentation créée dans la section précédente et configure la seconde diapositive pour utiliser l’animation Morph basée sur les mots.

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

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, telles que la direction ou le fait que l’effet démarre depuis un écran noir. Les options disponibles dépendent du type de transition sélectionné. Définissez d’abord le type, puis utilisez l’interface appropriée renvoyée par [get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_value/).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [set_FromBlack](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) avec `true` via [IOptionalBlackTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/ioptionalblacktransition/) afin que la transition commence depuis un écran noir.

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

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Privilégiez [set_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_duration/) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [set_Speed](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_speed/) lorsqu’une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionspeed/) — Lente, Moyenne ou Rapide — est suffisante et qu’aucune durée explicite n’est définie. Ces paramètres contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher un audio à une transition et le faire boucler ?**

Oui. Assignez un audio incorporé avec [set_Sound](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_sound/), appelez [set_SoundMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_soundmode/) avec `StartSound` provenant de l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitionsoundmode/), et activez la boucle avec [set_SoundLoop](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_soundloop/). L’audio se répète jusqu’à l’événement sonore suivant du diaporama.

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Parcourez la collection renvoyée par la méthode [get_Slides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slides/) de la présentation et appelez [set_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/set_type/) avec la même valeur pour la transition de chaque diapositive. Définissez les options de minutage et d’effet dans la même boucle afin de conserver un comportement cohérent sur toutes les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islideshowtransition/get_type/) sur la transition renvoyée par la méthode [get_SlideShowTransition](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositive. Elle renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.slideshow/transitiontype/) ; `None` indique qu’aucun effet de transition n’est appliqué.