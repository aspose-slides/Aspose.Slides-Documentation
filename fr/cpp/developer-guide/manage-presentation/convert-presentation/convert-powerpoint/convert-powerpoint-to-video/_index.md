---
title: Convertir des présentations PowerPoint en vidéo en C++
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/cpp/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir PPT
- convertir PPTX
- PowerPoint en vidéo
- présentation en vidéo
- PPT en vidéo
- PPTX en vidéo
- PowerPoint en MP4
- présentation en MP4
- PPT en MP4
- PPTX en MP4
- enregistrer PPT en MP4
- enregistrer PPTX en MP4
- exporter PPT en MP4
- exporter PPTX en MP4
- conversion vidéo
- PowerPoint
- C++
- Aspose.Slides
description: "Apprenez à convertir des présentations PowerPoint en vidéo en C++. Découvrez du code d'exemple et des techniques d'automatisation pour simplifier votre flux de travail."
---
## **Introduction**

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Amélioration de l'accessibilité :** Tous les appareils (quel que soit le système) sont équipés de lecteurs vidéo par défaut, contrairement aux applications d'ouverture de présentations, ce qui facilite l'ouverture ou la lecture des vidéos pour les utilisateurs.
* **Plus grande portée :** Grâce aux vidéos, vous pouvez toucher un large public et le cibler avec des informations qui sembleraient autrement fastidieuses dans une présentation. La plupart des enquêtes et statistiques indiquent que les gens regardent et consomment davantage les vidéos que les autres formes de contenu, et ils préfèrent généralement ce type de contenu.

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/fr/cpp/aspose-slides-for-cpp-22-11-release-notes/), nous avons implémenté la prise en charge de la conversion de présentations en vidéo. 

* Utilisez Aspose.Slides pour générer un ensemble d'images (à partir des diapositives de la présentation) correspondant à un certain nombre d'images par seconde (FPS).
* Utilisez un utilitaire tiers tel que `ffmpeg` pour créer une vidéo à partir des images.

## **Convertir une présentation PowerPoint en vidéo**

1. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).
2. Ajoutez le chemin de `ffmpeg.exe` à la variable d'environnement `PATH`.
3. Exécutez le code de conversion PowerPoint en vidéo.

Ce code C++ vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajoute une forme de sourire puis l'anime
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Effets vidéo**

Vous pouvez appliquer des animations aux objets des diapositives et utiliser des transitions entre les diapositives.

{{% alert color="info" %}} 

Vous souhaiterez peut‑être consulter ces articles : [PowerPoint Animation](https://docs.aspose.com/slides/fr/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/fr/cpp/shape-animation/), et [Shape Effect](https://docs.aspose.com/slides/fr/cpp/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et il en est de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// Ajoute une forme de sourire et l'anime comme indiqué ci-dessus
auto presentation = System::MakeObject<Presentation>();

// Ajoute une nouvelle diapositive et une transition animée

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides prend également en charge l'animation du texte. Nous animons donc les paragraphes sur les objets, qui apparaîtront les uns après les autres (avec un délai d'une seconde) :

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajoute du texte et des animations
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Convertit les images en vidéo
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Classes de conversion vidéo**

Pour vous permettre d'effectuer des tâches de conversion de PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.presentation_animations_generator/) et [PresentationPlayer](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.presentation_player/) .

PresentationAnimationsGenerator vous permet de définir la taille des images pour la vidéo (qui sera créée ultérieurement) via son constructeur. Si vous transmettez une instance de la présentation, `Presentation.SlideSize` sera utilisé et il génère les animations que [PresentationPlayer](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.presentation_player/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, qui possède le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.i_presentation_animation_player/). Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.i_presentation_animation_player/), la propriété [get_Duration](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) sont utilisées. Chaque position d'animation est définie dans l'intervalle *0 à durée*, puis la méthode `GetFrame` renvoie un Bitmap correspondant à l'état de l'animation à ce moment‑là.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // état initial de l'animation
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // bitmap de l'état initial de l'animation

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // état final de l'animation
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // dernière image de l'animation
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajoute une forme sourire et l'anime
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

Pour faire jouer toutes les animations d'une présentation simultanément, la classe [PresentationPlayer](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.presentation_player/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.presentation_animations_generator/) et le nombre d'images par seconde (FPS) des effets dans son constructeur, puis déclenche l'événement `FrameTick` pour toutes les animations afin de les faire jouer :

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

Ensuite, les images générées peuvent être assemblées pour produire une vidéo. Voir la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/fr/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**


**Entrée**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**Emphase**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |


**Sortie**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**Chemins de mouvement :**

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Est‑il possible de convertir des présentations protégées par mot de passe ?

Oui, Aspose.Slides permet de travailler avec les [presentations protégées par mot de passe](/slides/fr/cpp/password-protected-presentation/). Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

### Aspose.Slides prend‑il en charge l'utilisation dans des solutions cloud ?

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant hautes performances et évolutivité pour le traitement batch des fichiers.

### Existe‑t‑il des limites de taille pour les présentations lors de la conversion ?

Aspose.Slides peut gérer des présentations de pratiquement n'importe quelle taille. Cependant, lors du traitement de fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d'optimiser la présentation pour améliorer les performances.