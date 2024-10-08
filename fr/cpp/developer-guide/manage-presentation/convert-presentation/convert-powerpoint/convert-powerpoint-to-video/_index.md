---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /fr/cpp/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, C++, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo avec l'API Aspose.Slides pour C++"
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les appareils (quel que soit le système d'exploitation) sont équipés par défaut de lecteurs vidéo par rapport aux applications d'ouverture de présentations, ce qui facilite l'ouverture ou la lecture de vidéos pour les utilisateurs.
* **Meilleure portée :** Grâce aux vidéos, vous pouvez atteindre un large public et le cibler avec des informations qui pourraient autrement sembler ennuyeuses dans une présentation. La plupart des enquêtes et des statistiques suggèrent que les gens regardent et consomment des vidéos plus que d'autres formes de contenu, et ils préfèrent généralement ce type de contenu.

## **Conversion PowerPoint en Vidéo dans Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), nous avons implémenté la prise en charge de la conversion de présentation en vidéo. 

* Utilisez Aspose.Slides pour générer un ensemble d'images (des diapositives de la présentation) qui correspondent à une certaine FPS (images par seconde)
* Utilisez un utilitaire tiers comme `ffmpeg` pour créer une vidéo basée sur les images.

### **Convertir PowerPoint en Vidéo**

1. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).
2. Ajoutez le chemin vers `ffmpeg.exe` à la variable d'environnement `PATH`.
3. Exécutez le code de conversion PowerPoint en vidéo.

Ce code C++ vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en une vidéo :

```c++
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Effets Vidéo**

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Animation de Forme](https://docs.aspose.com/slides/cpp/shape-animation/), et [Effet de Forme](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus engageants et intéressants - et ils font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :

```c++
// Ajoute une forme de sourire et l'anime

// ...

// Ajoute une nouvelle diapositive et une transition animée

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides prend également en charge l'animation des textes. Nous animons donc des paragraphes sur des objets, qui apparaîtront les uns après les autres (avec un délai réglé à une seconde) :

```c++
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
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides pour C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convertir la présentation PowerPoint avec du texte en vidéo"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraphe par paragraphe"));
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Classes de Conversion Vidéo**

Pour vous permettre d'effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) et [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator vous permet de définir la taille de la frame pour la vidéo (qui sera créée plus tard) via son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisée et elle génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) utilise. 

 Lorsque les animations sont générées, un événement `NewAnimation` est généré pour chaque animation suivante, qui a le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), la propriété [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) sont utilisées. Chaque position d'animation est définie dans la plage *0 à durée*, puis la méthode `GetFrame` renverra un Bitmap qui correspond à l'état de l'animation à ce moment-là.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Durée totale de l'animation : {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // état initial de l'animation
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap de l'état initial de l'animation

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // état final de l'animation
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // dernière image de l'animation
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajoute une forme de sourire et l'anime
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

Pour faire jouer toutes les animations d'une présentation en même temps, la classe [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) et FPS pour les effets dans son constructeur, puis appelle l'événement `FrameTick` pour toutes les animations afin de les faire jouer :

```c++
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

Ensuite, les images générées peuvent être compilées pour produire une vidéo. Consultez la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Pris en Charge**


**Entrée**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Estomper** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Voler** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flotter** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Diviser** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Essuyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Roue** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grandir & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pivot** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |


**Accentuation**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pouls** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Pouls de Couleur** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Balançoire** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Tourner** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grandir/Réduire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Désaturer** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Obscurcir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Éclaircir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparence** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur d'Objet** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur Complémentaire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Ligne** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Remplissage** | ![non pris en charge](x.png) | ![pris en charge](v.png) |


**Sortie**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Estomper** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Voler Hors** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flotter Hors** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Diviser** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Essuyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Réduire & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pivot** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Chemins de Mouvement :**

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Tours** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Formes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Boucles** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Chemin Personnalisé** | ![pris en charge](v.png) | ![pris en charge](v.png) |