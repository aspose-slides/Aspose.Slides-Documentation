---
title: PowerPoint prezentációk videóvá konvertálása C++-ban
linktitle: PowerPoint videó
type: docs
weight: 130
url: /hu/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint videóvá konvertálása
- prezentáció videóvá konvertálása
- PPT videóvá konvertálása
- PPTX videóvá konvertálása
- PowerPoint MP4-re konvertálása
- prezentáció MP4-re konvertálása
- PPT MP4-re konvertálása
- PPTX MP4-re konvertálása
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konvertálás
- PowerPoint
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhatja a PowerPoint prezentációkat videóvá C++-ban. Fedezze fel a mintakódot és az automatizálási technikákat, hogy egyszerűsítse a munkafolyamatát."
---
## **Bevezetés**

PowerPoint prezentációja videóvá konvertálásával a következőket kapja:

* **A hozzáférhetőség növelése:** Minden eszköz (függetlenül a platformtól) alapértelmezés szerint videolejátszóval rendelkezik a prezentáció‑megnyitó alkalmazásokhoz képest, így a felhasználók könnyebben nyitják meg vagy játsszák le a videókat.
* **Nagyobb elérés:** Videókkal nagy közönséget érhet el, és információkkal célozhatja őket, amelyek egy prezentációban egyébként unalmasnak tűnhetnek. A legtöbb felmérés és statisztika szerint az emberek a videókat gyakrabban nézik és fogyasztják, mint más tartalomtípusokat, és általában előnyben részesítik ezeket.

Az [Aspose.Slides 22.11](https://docs.aspose.com/slides/hu/cpp/aspose-slides-for-cpp-22-11-release-notes/) verzióban bevezettük a prezentáció‑videó‑konvertálás támogatását.

* Használja az Aspose.Slides‑t a diákból származó képkockák sorozatának előállításához, amelyek egy adott FPS‑nek (képkocka másodpercenként) felelnek meg.
* Használjon harmadik féltől származó segédprogramot, például a `ffmpeg`‑et, a képkockák alapján videó létrehozásához.

## **PowerPoint prezentáció videóvá konvertálása**

1. Töltse le a ffmpeg‑et [itt](https://ffmpeg.org/download.html).
2. Adja hozzá a `ffmpeg.exe` elérési útját a `PATH` környezeti változóhoz.
3. Futtassa a PowerPoint‑videó kódot.

Ez a C++ kód bemutatja, hogyan lehet egy prezentációt (amely egy ábrát és két animációs hatást tartalmaz) videóvá konvertálni:

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

    // Hozzáad egy mosoly alakzatot, majd animálja
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

## **Videó effektusok**

Az animációkat alkalmazhatja a diák objektumaira, és használhat áttűnéseket a diák között.

{{% alert color="info" %}} 
Érdemes lehet ezeket a cikkeket elolvasni: [PowerPoint animáció](https://docs.aspose.com/slides/hu/cpp/powerpoint-animation/), [Ábra animáció](https://docs.aspose.com/slides/hu/cpp/shape-animation/), és [Ábra effektus](https://docs.aspose.com/slides/hu/cpp/shape-effect/).
{{% /alert %}} 

Az animációk és áttűnések a diavetítést vonzóbbá és érdekesebbé teszik – és ugyanígy hatnak a videókra is. Adjunk egy újabb diát és áttűnést a korábbi prezentáció kódjához:

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

// Hozzáad egy mosoly alakzatot és animálja, ahogy fent mutattuk
auto presentation = System::MakeObject<Presentation>();

// Hozzáad egy új diát és animált áttűnést

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides szövegekre is támogat animációt. Így a objektumokon lévő bekezdéseket animáljuk, amelyek egyesével jelennek meg (az eltolás egy másodpercre van beállítva):

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

    // Szöveget és animációkat ad hozzá
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

    // Képkockákat videóvá konvertál
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

## **Videó konvertáló osztályok**

A PowerPoint‑videó konvertálási feladatok elvégzéséhez az Aspose.Slides a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_animations_generator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) osztályokat biztosítja.

A PresentationAnimationsGenerator a videó képkockaméretét (amely később lesz létrehozva) a konstruktorában állíthatja be. Ha a prezentáció egy példányát adja át, a `Presentation.SlideSize` lesz használva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) használ.

Az animációk generálásakor minden egyes animációhoz egy `NewAnimation` esemény keletkezik, amelynek van egy [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player/) paramétere. Az utóbbi egy olyan osztály, amely egy különálló animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player/) használatához a [get_Duration](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (az animáció teljes időtartama) tulajdonságot és a [SetTimePosition](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) metódust használjuk. Minden animáció pozíciója a *0‑tól‑az‑időtartamig* tartományon belül állítható be, majd a `GetFrame` metódus egy Bitmapet ad vissza, amely az adott pillanatban lévő animációs állapotot tükrözi.

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
    // az animáció kezdeti állapota
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // az animáció kezdeti állapotának bitmapje

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // az animáció végső állapota
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // az animáció utolsó képkockája
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Hozzáad egy mosoly alakzatot és animálja
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

Az összes animáció egyszerre történő lejátszásához egy prezentációban a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) osztályt használjuk. Ez az osztály a konstruktorában egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_animations_generator/) példányt és az effektus FPS‑ét veszi, majd a `FrameTick` eseményt hívja meg minden animációra, hogy lejátszásra kerüljön:

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

A generált képkockákat ezután összeállíthatja videó létrehozásához. Lásd a [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) részt.

## **Támogatott animációk és effektusok**

**Belépés**:

| Animációtípus | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fade** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Fly In** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Float In** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Split** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wipe** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shape** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wheel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Random Bars** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Grow & Turn** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Zoom** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Swivel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Bounce** | ![támogatott](v.png) | ![támogatott](v.png) |

**Kiemelés**:

| Animációtípus | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Color Pulse** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Teeter** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Spin** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Grow/Shrink** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Desaturate** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Darken** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Lighten** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Transparency** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Object Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Complementary Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Line Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fill Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |

**Kilépés**:

| Animációtípus | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fade** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Fly Out** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Float Out** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Split** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wipe** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shape** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Random Bars** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shrink & Turn** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Zoom** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Swivel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Bounce** | ![támogatott](v.png) | ![támogatott](v.png) |

**Mozgás útvonalak**:

| Animációtípus | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Arcs** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Turns** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shapes** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Loops** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Custom Path** | ![támogatott](v.png) | ![támogatott](v.png) |

## **GYIK**

### Lehet jelszóval védett prezentációkat konvertálni?

Az Aspose.Slides lehetővé teszi a [jelszóval védett prezentációk](/slides/hu/cpp/password-protected-presentation/) használatát. Az ilyen fájlok feldolgozásához meg kell adnia a megfelelő jelszót, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

### Támogatja‑e az Aspose.Slides a felhőmegoldásokban való használatot?

Az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár úgy van tervezve, hogy szerverkörnyezetben működjön, biztosítva a magas teljesítményt és a skálázhatóságot a fájlok kötegelt feldolgozásához.

### Vannak‑e méretkorlátok a prezentációk konvertálása során?

Az Aspose.Slides képes gyakorlatilag bármilyen méretű prezentációk kezelésére. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és néha ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.