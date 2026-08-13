---
title: "Aplikace animací tvarů v prezentacích pomocí C++"
linktitle: "Animace tvaru"
type: docs
weight: 60
url: /cs/cpp/shape-animation/
keywords:
- "tvar"
- "animace"
- "efekt"
- "animovaný tvar"
- "animovaný text"
- "přidat animaci"
- "získat animaci"
- "extrahovat animaci"
- "přidat efekt"
- "získat efekt"
- "extrahovat efekt"
- "zvuk efektu"
- "aplikovat animaci"
- "PowerPoint"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](/slides/cs/cpp/animated-charts/). Dodávají prezentacím nebo jejich částem život.

## **Proč používat animace v prezentacích?**

Pomocí animací můžete
* řídit tok informací
* zdůraznit důležité body
* zvýšit zájem nebo zapojení publika
* učinit obsah snazší ke čtení, vstřebání nebo zpracování
* upoutat pozornost čtenářů či diváků na důležité části prezentace

PowerPoint nabízí mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**.

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné k práci s animacemi v rámci jmenného prostoru [Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation),
* Aspose.Slides nabízí více než **150 animačních efektů** v výčtu [EffectType](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako efekty používané v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides for C++ umožňuje aplikovat animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape).
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt na [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape).
7. Nastavte vlastnost [TextAnimation.BuildType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) na hodnotu z výčtu [BuildType Enumeration](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C++ kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidá nový AutoShape s textem
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Přidá efekt animace Fade k tvaru
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animuje text tvaru podle odstavců první úrovně
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Uloží soubor PPTX na disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_paragraph). Viz [**Animovaný text**](/slides/cs/cpp/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_frame) na snímku.
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt na [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_frame).
6. Uložte prezentaci na disk jako soubor PPTX.

Tento C++ kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Přidá rámeček obrázku na snímek
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Přidá animační efekt Fly zleva k rámečku obrázku
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Uloží soubor PPTX na disk
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Použití animace na Shape**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape).
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) (když je tento objekt kliknut, animace se spustí).
5. Vytvořte sekvenci efektů na tvaru bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb na `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C++ kód ukazuje, jak aplikovat efekt `PathFootball` (cesta fotbal) na tvar:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Načte prezentaci
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přistupuje ke kolekci tvarů pro vybraný snímek
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Vytvoří efekt PathFootball pro existující tvar od nuly.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Přidá animační efekt PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Vytvoří určitý typ "tlačítka".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Vytvoří sekvenci efektů pro toto tlačítko.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Vytvoří vlastní uživatelskou cestu. Náš objekt bude přesunut až po kliknutí na tlačítko.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Zapíše soubor PPTX na disk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `GetEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na normálním snímku**

Dříve jste se naučili, jak přidávat animační efekty k tvarům v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním normálním snímku v prezentaci `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných z placeholderů**

Pokud má tvar na normálním snímku placeholdery, které jsou na rozložení snímku a/nebo hlavním snímku, a na tyto placeholdery byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Předpokládejme, že máme soubor prezentace PowerPoint `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem "Made with Aspose.Slides" a na tento tvar je aplikován efekt **Random Bars**.

![Animace tvaru na snímku](slide-shape-animation.png)

Dále předpokládejme, že na placeholder zápatí na **rozložení** snímku je aplikován efekt **Split**.

![Animace tvaru na rozložení](layout-shape-animation.png)

A nakonec, na placeholder zápatí na **hlavním** snímku je aplikován efekt **Fly In**.

![Animace tvaru na hlavním snímku](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `GetBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na rozložení a hlavním snímku.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Získá animační efekty tvaru na normálním snímku.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Získá animační efekty placeholderu na snímku rozložení.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Získá animační efekty placeholderu na hlavním snímku.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Let, Dole
Type: 134, subtype: 45            // Rozdělení, Vertikální vstup
Type: 126, subtype: 22            // Náhodné pruhy, Horizontální
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides for C++ umožňuje změnit časové vlastnosti animačního efektu.

Toto je panel Timing animace v Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto odpovídají časování v PowerPointu a vlastnostem [Effect.Timing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Rozbalovací seznam PowerPoint Timing **Start** odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).
- PowerPoint Timing **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Doba trvání animace (v sekundách) je celkový čas, který animace potřebuje k dokončení jednoho cyklu.
- PowerPoint Timing **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).

Takto změníte vlastnosti Timing efektu:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c), které potřebujete.
3. Uložte upravený soubor PPTX.

Tento C++ kód demonstruje operaci:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Získá první efekt hlavní sekvence.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Změní TriggerType efektu tak, aby se spustil po kliknutí
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Změní délku trvání efektu
effect->get_Timing()->set_Duration(3.f);

// Změní TriggerDelayTime efektu
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Uloží soubor PPTX na disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje tyto vlastnosti pro práci se zvuky v animačních efektech:
- [set_Sound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_sound/)
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_stopprevioussound/)

### **Přidání zvuku animačního efektu**

Tento C++ kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Přidá audio do kolekce audio v prezentaci
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Kontroluje, zda efekt nemá zvuk
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Přidá zvuk pro první efekt
    firstEffect->set_Sound(effectSound);
}

// Získá první interaktivní sekvenci snímku.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Nastaví příznak efektu "Zastavit předchozí zvuk"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Zapíše soubor PPTX na disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte hlavní sekvenci efektů.
4. Extrahujte vestavěný [set_Sound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_sound/) ke každému animačnímu efektu.

Tento C++ kód ukazuje, jak extrahovat zvuk vestavěný v animačním efektu:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Po animaci**

Aspose.Slides for C++ umožňuje změnit vlastnost After animation animačního efektu.

Toto je panel Effect a rozšířené menu v Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam PowerPoint Effect **After animation** odpovídá těmto vlastnostem:
- Vlastnost [set_AfterAnimationType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) popisuje typ After animation:
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/);
  * Položka PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) (výchozí typ after animation);
  * Položka PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/);
  * Položka PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/);
- Vlastnost [set_AfterAnimationColor()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/). Pokud změníte typ na jiný, barva po animaci bude vymazána.

Tento C++ kód ukazuje, jak změnit efekt after animation:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Změní typ po animaci na Barva
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Nastaví barvu po animaci
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Zapíše soubor PPTX na disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animovat text**

Aspose.Slides poskytuje tyto vlastnosti pro práci s blokem *Animate text* animačního efektu:
- [set_AnimateTextType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) popisuje typ animace textu efektu. Text tvaru může být animován:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Slovo po slovu ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Písmeno po písmenu ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) nastavuje prodlevu mezi animovanými částmi textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:
1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost [set_BuildType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation.itextanimation/set_buildtype/) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) pro vypnutí režimu animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [set_AnimateTextType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) a [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Uložte upravený soubor PPTX.

Tento C++ kód demonstruje operaci:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Změní typ textové animace efektu na "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Změní typ animace textu efektu na "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Nastaví prodlevu mezi slovy na 20% trvání efektu
firstEffect->set_DelayBetweenTextParts(20.0f);

// Zapíše soubor PPTX na disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Jak mohu zajistit, aby byly animace zachovány při publikování prezentace na web?

[Export do HTML5](/slides/cs/cpp/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/) zodpovědné za animaci [shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a [transition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/). Čisté HTML nepřehrává animace snímků, zatímco HTML5 ano.

### Jak změna z-order (vrstvy) tvarů ovlivňuje animaci?

Animace a pořadí kreslení jsou nezávislé: efekt řídí načasování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_zorderposition/) určuje, co co překrývá. Viditelné výsledky jsou definovány jejich kombinací. (Toto je obecné chování PowerPointu; model efekty‑a‑tvary v Aspose.Slides následuje stejnou logiku.)

### Existují omezení při převodu animací do videa pro některé efekty?

Obecně jsou [animace podporovány](/slides/cs/cpp/convert-powerpoint-to-video/), ale v rozdílných případech zcela definitivně nedochází. Doporučuje se testovat s efekty, které používáte a s knihovnou verze.