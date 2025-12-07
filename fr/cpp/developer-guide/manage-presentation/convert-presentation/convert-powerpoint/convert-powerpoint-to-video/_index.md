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
description: "Apprenez à convertir des présentations PowerPoint en vidéo en C++. Découvrez le code d'exemple et les techniques d'automatisation pour optimiser votre flux de travail."
---

## **Vue d'ensemble**

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les appareils (indépendamment de la plateforme) sont équipés de lecteurs vidéo par défaut, contrairement aux applications d'ouverture de présentations, ce qui facilite l'ouverture ou la lecture des vidéos.
* **Portée accrue :** Grâce aux vidéos, vous pouvez atteindre un large public et leur fournir des informations qui pourraient autrement sembler fastidieuses dans une présentation. La plupart des enquêtes et statistiques indiquent que les gens regardent et consomment davantage les vidéos que les autres formes de contenu, et ils préfèrent généralement ce type de contenu.

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), nous avons implémenté la prise en charge de la conversion de présentation en vidéo. 

* Utilisez Aspose.Slides pour générer un ensemble d'images (à partir des diapositives de la présentation) correspondant à un certain nombre d'images par seconde (FPS).
* Utilisez un utilitaire tiers comme `ffmpeg` pour créer une vidéo à partir des images.

## **Convertir une présentation PowerPoint en vidéo**

1. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).
2. Ajoutez le chemin de `ffmpeg.exe` à la variable d'environnement `PATH`.
3. Exécutez le code de conversion PowerPoint en vidéo.

Ce code C++ montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :
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

    // Ajoute une forme sourire puis l'anime
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

Vous pourriez vouloir consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/cpp/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et elles font de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
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


Aspose.Slides prend également en charge l'animation du texte. Nous animons donc les paragraphes sur les objets, qui apparaîtront les uns après les autres (avec un délai d'une seconde) :
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


## **Classes de conversion vidéo**

Pour vous permettre d'effectuer des tâches de conversion de PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) et [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) .

PresentationAnimationsGenerator vous permet de définir la taille des images pour la vidéo (qui sera créée ultérieurement) via son constructeur. Si vous transmettez une instance de la présentation, `Presentation.SlideSize` sera utilisé et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) utilise. 

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, qui possède le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), les propriétés [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) sont utilisées. Chaque position d'animation est définie dans la plage *0 à durée*, puis la méthode `GetFrame` renvoie un Bitmap correspondant à l'état de l'animation à ce moment.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // état initial de l'animation
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap d'état initial de l'animation

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // état final de l'animation
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // dernier frame de l'animation
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


Pour faire jouer toutes les animations d'une présentation simultanément, la classe [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) ainsi que les FPS des effets, dans son constructeur, puis appelle l'événement `FrameTick` pour toutes les animations afin de les lire :
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


Ensuite les images générées peuvent être assemblées pour produire une vidéo. Voir la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**


**Entrée**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparition** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fondu** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Vol entrant** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flottement entrant** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Division** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Effacement** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Roue** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Croissance et rotation** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pivot** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebond** | ![pris en charge](v.png) | ![pris en charge](v.png) |


**Mise en valeur**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulsion** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Impulsion de couleur** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Oscillation** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rotation** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Agrandir/Rétrécir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Désaturation** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Assombrir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Éclaircir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparence** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de l'objet** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur complémentaire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de ligne** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de remplissage** | ![non pris en charge](x.png) | ![pris en charge](v.png) |


**Sortie**:

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparition** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fondu** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Sortie en vol** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flottement sortant** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Division** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Effacement** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rétrécir et tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pivot** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebond** | ![pris en charge](v.png) | ![pris en charge](v.png) |


**Chemins de mouvement :**

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Virages** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Formes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Boucles** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Chemin personnalisé** | ![pris en charge](v.png) | ![pris en charge](v.png) |

## **FAQ**

**Est-il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides permet de travailler avec les [présentations protégées par mot de passe](/slides/fr/cpp/password-protected-presentation/). Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides prend-il en charge une utilisation dans les solutions cloud ?**

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, assurant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe-t-il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides est capable de gérer des présentations de taille pratiquement illimitée. Cependant, lors du traitement de fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d'optimiser la présentation afin d'améliorer les performances.