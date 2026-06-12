---
title: Použít animace tvarů v prezentacích pomocí C++
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/cpp/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](/slides/cs/cpp/animated-charts/). Dodávají život prezentacím nebo jejich částem. 

## **Proč používat animace v prezentacích?**

Používáním animací můžete 

* ovládat tok informací
* zdůraznit důležité body
* zvýšit zájem či zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* upoutat pozornost čtenářů nebo diváků na důležité části v prezentaci

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**. 

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy, které potřebujete pro práci s animacemi v namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation),
* Aspose.Slides poskytuje více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) efekty používané v PowerPointu.

## **Použít animaci na TextBox**

Aspose.Slides pro C++ vám umožňuje použít animaci na text ve tvaru. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape). 
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt do [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape). 
7. Nastavte vlastnost [TextAnimation.BuildType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) na hodnotu z [BuildType Enumeration](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Uložte prezentaci na disk ve formátu PPTX.

Tento C++ kód ukazuje, jak použít efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```c++
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

 // Přidá efekt animace Fade do tvaru
 System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
     Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

 // Animuje text tvaru podle odstavců první úrovně
 effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

 // Uloží soubor PPTX na disk
 pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Kromě aplikování animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_paragraph). Viz [**Animated Text**](/slides/cs/cpp/animated-text/).

{{% /alert %}} 

## **Použít animaci na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_frame) na snímku. 
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt do [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_frame).
6. Uložte prezentaci na disk ve formátu PPTX.

```c++
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Načte obrázek, který má být přidán do kolekce obrázků prezentace
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
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Použít animaci na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_auto_shape) (když je tento objekt kliknut, animace se spustí).
5. Vytvořte sekvenci efektů na tvaru bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro přesun na `UserPath`.
8. Uložte prezentaci na disk ve formátu PPTX.

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Načte prezentaci
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přistupuje ke kolekci tvarů pro vybraný snímek
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Vytvoří efekt PathFootball pro existující tvar od začátku.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Přidá animační efekt PathFootball
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Vytvoří nějaký druh "tlačítka".
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

## **Získat animační efekty aplikované na tvar**

Níže uvedené příklady ukazují, jak použít metodu `GetEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/) k získání všech animačních efektů aplikovaných na tvar. 

**Příklad 1: Získat animační efekty aplikované na tvar na běžném snímku**

Dříve jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním běžném snímku v prezentaci `AnimExample_out.pptx`.

```c++
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

**Příklad 2: Získat všechny animační efekty, včetně těch zděděných z placeholderů**

Pokud má tvar na běžném snímku placeholdery, které jsou na snímku rozvržení a/nebo hlavním snímku, a na tyto placeholdery byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Řekněme, že máme soubor prezentace PowerPoint `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem "Made with Aspose.Slides" a na tento tvar je aplikován efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Předpokládejme také, že efekt **Split** je aplikován na placeholder zápatí na snímku **layout**.

![Layout shape animation effect](layout-shape-animation.png)

A nakonec je na placeholder zápatí na snímku **master** aplikován efekt **Fly In**.

![Master shape animation effect](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `GetBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na snímcích layout a master.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Prolet, Dole
Type: 134, subtype: 45            // Rozdělení, Svisle dovnitř
Type: 126, subtype: 22            // Náhodné pruhy, Horizontální
```

## **Změnit časové vlastnosti animačního efektu**

Aspose.Slides pro C++ vám umožňuje změnit časové vlastnosti animačního efektu.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Jedná se o odpovídající položky mezi časováním v PowerPointu a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) :

- Rozbalovací seznam **Start** v časování PowerPointu odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** v časování PowerPointu odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Délka animace (v sekundách) je celková doba, kterou animace potřebuje k dokončení jednoho cyklu. 
- **Delay** v časování PowerPointu odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Takto změníte vlastnosti časování efektu:

1. [Použít](#apply-animation-to-shape) nebo získat animační efekt.
2. Nastavte nové hodnoty požadovaných vlastností [Effect.Timing](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c).
3. Uložte upravený soubor PPTX.

```c++
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Získá první efekt hlavní sekvence.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Změní TriggerType efektu tak, aby se spustil kliknutím
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Změní délku trvání efektu
effect->get_Timing()->set_Duration(3.f);

// Změní TriggerDelayTime efektu
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Uloží soubor PPTX na disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje následující vlastnosti, které umožňují práci se zvuky v animačních efektech: 

- [set_Sound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Přidat zvuk animačního efektu**

Tento C++ kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Přidá zvuk do kolekce audio souborů prezentace
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá hlavní sekvenci snímku.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Kontroluje, zda efekt nemá žádný zvuk
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Přidá zvuk k prvnímu efektu
    firstEffect->set_Sound(effectSound);
}

// Získá první interaktivní sekvenci snímku.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Nastaví příznak efektu "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Zapíše soubor PPTX na disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extrahovat zvuk animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte vložený [set_Sound()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effect/set_sound/) z každého animačního efektu. 

Tento C++ kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```c++
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

Aspose.Slides pro C++ vám umožňuje změnit vlastnost After animation (Po animaci) animačního efektu.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam **After animation** v PowerPointu odpovídá těmto vlastnostem: 

- Vlastnost [set_AfterAnimationType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) , která popisuje typ After animation :
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) (výchozí typ po animaci);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) ;
- Vlastnost [set_AfterAnimationColor()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) , která definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/). Pokud typ změníte na jiný, barva po animaci bude vymazána.

```c++
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Změní typ po animaci na Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Nastaví barvu po animaci
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Zapíše soubor PPTX na disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animovat text**

Aspose.Slides poskytuje následující vlastnosti, které umožňují práci s blokem *Animate text* animačního efektu: 

- [set_AnimateTextType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) , která popisuje typ animovaného textu efektu. Text tvaru může být animován:
  * Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
  * Po slově ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
  * Po písmenu ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/animatetexttype/) typ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) , nastavuje prodlevu mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:

1. [Použít](#apply-animation-to-shape) nebo získat animační efekt.
2. Nastavte vlastnost [set_BuildType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itextanimation/set_buildtype/) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) , čímž vypnete režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [set_AnimateTextType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) a [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Uložte upravený soubor PPTX.

```c++
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Získá první efekt hlavní sekvence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Změní typ textové animace efektu na "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Změní typ animovaného textu efektu na "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Nastaví prodlevu mezi slovy na 20% trvání efektu
firstEffect->set_DelayBetweenTextParts(20.0f);

// Zapíše soubor PPTX na disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **Často kladené dotazy**

**Jak mohu zajistit, že animace zůstanou zachovány při publikování prezentace na web?**

[Export to HTML5](/slides/cs/cpp/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a [transition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/). Prostý HTML animace snímků nepřehraje, zatímco HTML5 ano.

**Jak ovlivňuje změna z-order (pořadí vrstev) tvarů animaci?**

Animace a pořadí vykreslování jsou nezávislé: efekt řídí časování a typ objevování/zmizení, zatímco [z-order](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_zorderposition/) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Toto je obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

**Existují omezení při konverzi animací do videa u některých efektů?**

Obecně jsou [animace podporovány](/slides/cs/cpp/convert-powerpoint-to-video/), ale v ojedinělých případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučuje se otestovat s efekty, které používáte, a s verzí knihovny.