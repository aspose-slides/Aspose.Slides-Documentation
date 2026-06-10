---
title: PowerPoint-prezentációk videóvá alakítása C++-ban
linktitle: PowerPoint videóvá
type: docs
weight: 130
url: /hu/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint videóvá
- prezentáció videóvá
- PPT videóvá
- PPTX videóvá
- PowerPoint MP4-re
- prezentáció MP4-re
- PPT MP4-re
- PPTX MP4-re
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó átalakítás
- PowerPoint
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet PowerPoint-prezentációkat videóvá alakítani C++-ban. Fedezze fel a mintakódot és az automatizálási technikákat, amelyek egyszerűsítik a munkafolyamatát."
---
## **Bevezetés**

PowerPoint‑prezentáció videóvá alakításával 

* **Növekvő hozzáférhetőség:** Minden eszköz (platformtól függetlenül) alapértelmezés szerint videolejátszóval rendelkezik, szemben a prezentáció‑megnyitó alkalmazásokkal, így a felhasználók könnyebben nyitják meg vagy játsszák le a videókat.
* **Nagyobb elérés:** Videókkal széles közönséget érhetünk el, és olyan információkat közvetíthetünk, amelyek egy prezentációban unalmasnak tűnhetnek. A legtöbb felmérés és statisztika szerint az emberek a videót többet nézik és fogyasztják, mint más tartalomtípusokat, és általában ezt a formát részesítik előnyben.

Az [Aspose.Slides 22.11](https://docs.aspose.com/slides/hu/cpp/aspose-slides-for-cpp-22-11-release-notes/)‑ben bevezettük a prezentáció‑videó konverzió támogatását. 

* Használja az Aspose.Slides‑t a diákból származó képkockák (keretek) előállításához, egy adott FPS‑hez (képkocka másodpercenként)
* Használjon egy harmadik féltől származó segédprogramot, például a `ffmpeg`‑et a képkockák alapján videó létrehozásához.

## **PowerPoint prezentáció konvertálása videóvá**

1. Töltse le az ffmpeg‑et [itt](https://ffmpeg.org/download.html).
2. Adja hozzá a `ffmpeg.exe` elérési útját a `PATH` környezeti változóhoz.
3. Futtassa a PowerPoint‑videó kódot.

Ez a C++ kód bemutatja, hogyan konvertálhat egy prezentációt (egy ábrával és két animációs effektussal) videóvá:

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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Videóhatások**

Animációkat alkalmazhat a diák objektumaira, valamint átmeneteket a diák között.

{{% alert color="primary" %}} 

Érdemes megnézni ezeket a cikkeket: [PowerPoint animáció](https://docs.aspose.com/slides/hu/cpp/powerpoint-animation/), [Alakzat animáció](https://docs.aspose.com/slides/hu/cpp/shape-animation/), és [Alakzat effektus](https://docs.aspose.com/slides/hu/cpp/shape-effect/).

{{% /alert %}} 

Az animációk és átmenetek élvezetesebbé és érdekesebbé teszik a diavetítéseket – és ugyanezt teszik a videókkal is. Adjuk hozzá a kódhoz egy újabb diát és átmenetet a korábbi prezentációhoz:

```c++
// Hozzáad egy mosoly alakzatot és animálja

// ...

// Hozzáad egy új diát és animált átmenetet

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Az Aspose.Slides szövegekre is támogat animációt. Így beállíthatunk bekezdés‑animációkat az objektumokon, amelyek egyesével jelennek meg (az egy másodperces késleltetést beállítva):

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

    // Hozzáad szöveget és animációkat
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

    // Átalakítja a képkockákat videóvá
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

## **Videókonverziós osztályok**

Annak érdekében, hogy PowerPoint‑videó konverziós feladatokat hajthasson végre, az Aspose.Slides a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_animations_generator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) osztályokat biztosítja.

A PresentationAnimationsGenerator lehetővé teszi a videó képkockaméretének beállítását (amelyet később létrehoz) a konstruktorán keresztül. Ha egy prezentáció példányát adja át, a `Presentation.SlideSize` kerül felhasználásra, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) használ.

Animációk generálásakor minden egyes további animációhoz egy `NewAnimation` esemény keletkezik, amely a [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player/) paramétert kapja. Az utóbbi egy külön animáció lejátszását megvalósító osztály.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player/) használatához a [get_Duration](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (az animáció teljes időtartama) tulajdonságot és a [SetTimePosition](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) metódust használjuk. Minden animáció pozíciója a *0-tól időtartamig* tartományban állítható be, és a `GetFrame` metódus egy Bitmapet ad vissza, amely az adott pillanatban lévő animációs állapotot tükrözi.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // kezdeti animációs állapot
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // kezdeti animációs állapot bitmap

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // animáció végső állapota
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // animáció utolsó képkockája
    lastBitmap->Save(u"last.png");
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

Az összes animáció egyidejű lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_player/) osztályt használjuk. Ez az osztály egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.presentation_animations_generator/) példányt és az FPS‑t veszi át a konstruktorában, majd a `FrameTick` eseményt hívja meg az összes animációra a lejátszáshoz:

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

Ezután a generált képkockákból videó állítható össze. Lásd a [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) szakaszt.

## **Támogatott animációk és effektusok**


**Bevezető**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Megjelenés** | ![not supported](x.png) | ![supported](v.png) |
| **Halványulás** | ![supported](v.png) | ![supported](v.png) |
| **Beúszás** | ![supported](v.png) | ![supported](v.png) |
| **Lebegő beúszás** | ![supported](v.png) | ![supported](v.png) |
| **Szétválasztás** | ![supported](v.png) | ![supported](v.png) |
| **Törlés** | ![supported](v.png) | ![supported](v.png) |
| **Alakzat** | ![supported](v.png) | ![supported](v.png) |
| **Kerék** | ![supported](v.png) | ![supported](v.png) |
| **Véletlen sávok** | ![supported](v.png) | ![supported](v.png) |
| **Növekedés és fordítás** | ![not supported](x.png) | ![supported](v.png) |
| **Nagyítás** | ![supported](v.png) | ![supported](v.png) |
| **Forgatás** | ![supported](v.png) | ![supported](v.png) |
| **Ugrálás** | ![supported](v.png) | ![supported](v.png) |


**Kiemelés**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulzus** | ![not supported](x.png) | ![supported](v.png) |
| **Színimpulzus** | ![not supported](x.png) | ![supported](v.png) |
| **Bambusz** | ![supported](v.png) | ![supported](v.png) |
| **Forgás** | ![supported](v.png) | ![supported](v.png) |
| **Növekedés/Kicsinyítés** | ![not supported](x.png) | ![supported](v.png) |
| **Telítetlenné tétel** | ![not supported](x.png) | ![supported](v.png) |
| **Sötétítés** | ![not supported](x.png) | ![supported](v.png) |
| **Világosítás** | ![not supported](x.png) | ![supported](v.png) |
| **Átlátszóság** | ![not supported](x.png) | ![supported](v.png) |
| **Objektum színe** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementer szín** | ![not supported](x.png) | ![supported](v.png) |
| **Vonal színe** | ![not supported](x.png) | ![supported](v.png) |
| **Kitöltés színe** | ![not supported](x.png) | ![supported](v.png) |

**Kijáró**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Eltűnés** | ![not supported](x.png) | ![supported](v.png) |
| **Halványulás** | ![supported](v.png) | ![supported](v.png) |
| **Kifutás** | ![supported](v.png) | ![supported](v.png) |
| **Lebegő kifutás** | ![supported](v.png) | ![supported](v.png) |
| **Szétválasztás** | ![supported](v.png) | ![supported](v.png) |
| **Törlés** | ![supported](v.png) | ![supported](v.png) |
| **Alakzat** | ![supported](v.png) | ![supported](v.png) |
| **Véletlen sávok** | ![supported](v.png) | ![supported](v.png) |
| **Kicsinyítés és fordítás** | ![not supported](x.png) | ![supported](v.png) |
| **Nagyítás** | ![supported](v.png) | ![supported](v.png) |
| **Forgatás** | ![supported](v.png) | ![supported](v.png) |
| **Ugrálás** | ![supported](v.png) | ![supported](v.png) |

**Mozgásútvonalak**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Vonalak** | ![supported](v.png) | ![supported](v.png) |
| **Ívek** | ![supported](v.png) | ![supported](v.png) |
| **Fordulatok** | ![supported](v.png) | ![supported](v.png) |
| **Alakzatok** | ![supported](v.png) | ![supported](v.png) |
| **Hurkok** | ![supported](v.png) | ![supported](v.png) |
| **Egyéni útvonal** | ![supported](v.png) | ![supported](v.png) |

## **GYIK**

**Lehetőség van jelszóval védett prezentációk konvertálására?**

Igen, az Aspose.Slides támogatja a [jelszóval védett prezentációk](/slides/hu/cpp/password-protected-presentation/) kezelését. Ilyen fájlok feldolgozásakor a helyes jelszó megadása szükséges ahhoz, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

**Az Aspose.Slides használható felhőmegoldásokban?**

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár szerver környezetben való futásra lett tervezve, magas teljesítményt és skálázhatóságot biztosítva a kötegelt fájlfeldolgozáshoz.

**Van méretkorlátozás a prezentációk konvertálásakor?**

Az Aspose.Slides gyakorlatilag bármilyen méretű prezentációt képes kezelni. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és gyakran ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.