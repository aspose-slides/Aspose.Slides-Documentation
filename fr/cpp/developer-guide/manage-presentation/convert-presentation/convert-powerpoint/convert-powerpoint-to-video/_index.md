---
title: Convertir les présentations PowerPoint en vidéo en C++
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
description: "Apprenez comment convertir les présentations PowerPoint en vidéo en C++. Découvrez des exemples de code et des techniques d'automatisation pour rationaliser votre flux de travail."
---

## **Vue d’ensemble**

En convertissant votre présentation PowerPoint en vidéo, vous obtenez  

* **Amélioration de l’accessibilité :** Tous les appareils (indépendamment du système) sont fournis par défaut avec des lecteurs vidéo, contrairement aux applications d’ouverture de présentations, ce qui facilite l’ouverture ou la lecture des vidéos.  
* **Portée accrue :** Grâce aux vidéos, vous pouvez toucher un large public et leur fournir des informations qui pourraient autrement sembler fastidieuses dans une présentation. La plupart des enquêtes et statistiques indiquent que les gens regardent et consomment davantage les vidéos que les autres formes de contenu, et ils préfèrent généralement ce type de contenu.

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), nous avons ajouté la prise en charge de la conversion de présentations en vidéo.  

* Utilisez Aspose.Slides pour générer un ensemble de cadres (à partir des diapositives) correspondant à un certain FPS (images par seconde).  
* Utilisez un utilitaire tiers comme `ffmpeg` pour créer une vidéo à partir de ces cadres.

## **Convertir une présentation PowerPoint en vidéo**

1. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).  
2. Ajoutez le chemin vers `ffmpeg.exe` à la variable d’environnement `PATH`.  
3. Exécutez le code de conversion PowerPoint → vidéo.

Ce code C++ montre comment convertir une présentation (contennant une figure et deux effets d’animation) en vidéo :
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

    // Ajoute une forme souriante puis l'anime
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


## **Effets vidéo**

Vous pouvez appliquer des animations aux objets des diapositives et utiliser des transitions entre les diapositives.

{{% alert color="primary" %}} 

Vous pourriez être intéressé par ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/cpp/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et il en va de même pour les vidéos. Ajoutons une diapositive supplémentaire et une transition au code de la présentation précédente :
```c++
// Ajoute une forme sourire et l'anime

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


Aspose.Slides prend également en charge l’animation du texte. Nous animons ainsi les paragraphes sur des objets, qui apparaîtront les uns après les autres (avec un délai d’une seconde) :
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

    // Convertit les cadres en vidéo
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


## **Classes de conversion vidéo**

Pour vous permettre d’effectuer des conversions PowerPoint → vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) et [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator vous permet de définir la taille du cadre vidéo (qui sera créée ultérieurement) via son constructeur. Si vous transmettez une instance de présentation, `Presentation.SlideSize` sera utilisée et il génère les animations que [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) exploite.  

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, contenant le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Ce dernier représente un lecteur pour une animation individuelle.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), on utilise la propriété [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (durée totale de l’animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Chaque position d’animation est définie dans l’intervalle *0 à durée*, puis la méthode `GetFrame` renvoie un Bitmap correspondant à l’état de l’animation à ce moment‑là.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

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


Pour faire jouer toutes les animations d’une présentation simultanément, on utilise la classe [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). Cette classe reçoit une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) et le FPS des effets dans son constructeur, puis déclenche l’événement `FrameTick` pour toutes les animations afin de les lire :
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


Ensuite, les cadres générés peuvent être assemblés pour produire une vidéo. Voir la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**


**Entrée** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![not supported](x.png) | ![supported](v.png) |
| **Fondu** | ![supported](v.png) | ![supported](v.png) |
| **Vol entrant** | ![supported](v.png) | ![supported](v.png) |
| **Flottement entrant** | ![supported](v.png) | ![supported](v.png) |
| **Division** | ![supported](v.png) | ![supported](v.png) |
| **Effacement** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Roue** | ![supported](v.png) | ![supported](v.png) |
| **Barres aléatoires** | ![supported](v.png) | ![supported](v.png) |
| **Croître et tourner** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Pivot** | ![supported](v.png) | ![supported](v.png) |
| **Rebond** | ![supported](v.png) | ![supported](v.png) |


**Accentuation** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulsion** | ![not supported](x.png) | ![supported](v.png) |
| **Impulsion de couleur** | ![not supported](x.png) | ![supported](v.png) |
| **Oscillation** | ![supported](v.png) | ![supported](v.png) |
| **Rotation** | ![supported](v.png) | ![supported](v.png) |
| **Agrandir/Rétrécir** | ![not supported](x.png) | ![supported](v.png) |
| **Désaturation** | ![not supported](x.png) | ![supported](v.png) |
| **Assombrir** | ![not supported](x.png) | ![supported](v.png) |
| **Éclaircir** | ![not supported](x.png) | ![supported](v.png) |
| **Transparence** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de l’objet** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur complémentaire** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de ligne** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de remplissage** | ![not supported](x.png) | ![supported](v.png) |

**Sortie** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![not supported](x.png) | ![supported](v.png) |
| **Fondu** | ![supported](v.png) | ![supported](v.png) |
| **Vol sortant** | ![supported](v.png) | ![supported](v.png) |
| **Flottement sortant** | ![supported](v.png) | ![supported](v.png) |
| **Division** | ![supported](v.png) | ![supported](v.png) |
| **Effacement** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Barres aléatoires** | ![supported](v.png) | ![supported](v.png) |
| **Rétrécir et tourner** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Pivot** | ![supported](v.png) | ![supported](v.png) |
| **Rebond** | ![supported](v.png) | ![supported](v.png) |

**Chemins de mouvement** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Virages** | ![supported](v.png) | ![supported](v.png) |
| **Formes** | ![supported](v.png) | ![supported](v.png) |
| **Boucles** | ![supported](v.png) | ![supported](v.png) |
| **Chemin personnalisé** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides permet de travailler avec des [présentations protégées par mot de passe](/slides/fr/cpp/password-protected-presentation/). Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides prend‑il en charge une utilisation dans des solutions cloud ?**

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides peut gérer des présentations de taille pratiquement illimitée. Cependant, avec des fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.