---
title: Alakzatanimációk alkalmazása prezentációkban C++-val
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/cpp/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat alakzatanimációkat PowerPoint prezentációkban az Aspose.Slides for C++ segítségével. Emelkedjen ki!"
---
## **Bevezetés**

Az animációk vizuális effektusok, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](/slides/hu/cpp/animated-charts/) lehet alkalmazni. Életet adnak a prezentációknak vagy annak elemeinek. 

## **Miért használjunk animációkat a prezentációkban?**

Az animációk segítségével

* információáramlás irányítása
* fontos pontok kiemelése
* az érdeklődés vagy részvétel növelése a közönség körében
* a tartalom könnyebben olvashatóvá, befogadhatóvá vagy feldolgozhatóvá tétele
* a közönség figyelmének felhívása a prezentáció fontos részeire

A PowerPoint számos beállítást és eszközt biztosít az animációkhoz és az animációs effektusokhoz a **belépés**, **kilépés**, **kiemelés** és **mozgáspályák** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az osztályokat és típusokat, melyekre az animációkkal való munkához a [Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation) névtérben szüksége van,  
* Az Aspose.Slides több mint **150 animációs effektust** biztosít a [EffectType](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumerációban. Ezek az effektusok lényegében megegyeznek (vagy ekvivalensek) a PowerPoint-ban használtakkal.  

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for C++ lehetővé teszi, hogy animációt alkalmazzon egy alakzat szövegére. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze meg egy dia referenciaját az indexén keresztül.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) elemet.  
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) elemhez.  
5. Szerezze meg a fő effektussorozatot.  
6. Adjon animációs effektust a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) elemhez.  
7. Állítsa be a [TextAnimation.BuildType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) tulajdonságot a [BuildType Enumeration](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) értékére.  
8. Írja a prezentációt lemezre PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan kell alkalmazni a `Fade` effektust az AutoShape-re, és beállítani a szöveg animációját a *By 1st Level Paragraphs* értékre:

```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Új AutoShape-et ad hozzá szöveggel
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Fade animációs effektust ad az alakzathoz
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Az alakzat szövegét az első szintű bekezdések szerint animálja
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Mentse el a PPTX fájlt a lemezre
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Az animációk szövegre való alkalmazása mellett animációkat is alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_paragraph) elemre. Lásd a [**Animated Text**](/slides/hu/cpp/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása képkeretre**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze meg egy dia referenciaját az indexén keresztül.  
3. Adjon hozzá vagy szerezze meg a dián a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_frame) elemet.  
4. Szerezze meg a fő effektussorozatot.  
5. Adjon animációs effektust a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_frame) elemhez.  
6. Írja a prezentációt lemezre PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan kell alkalmazni a `Fly` effektust egy képkeretre:

```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Betölti a képet, amely a prezentáció képgyűjteményébe lesz hozzáadva
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Képkeretet ad hozzá a diához
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Balról repülő animációs effektust ad a képkerethez
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Mentse el a PPTX fájlt a lemezre
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze meg egy dia referenciaját az indexén keresztül.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) elemet.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) elemet (amikor ezt az objektumot rákattintják, az animáció lejátszásra kerül).  
5. Hozzon létre egy effektussorozatot a bevel alakzaton.  
6. Hozzon létre egy egyéni `UserPath`-ot.  
7. Adjon parancsokat a `UserPath`-ra való mozgáshoz.  
8. Írja a prezentációt lemezre PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan kell alkalmazni a `PathFootball` (path football) effektust egy alakzatra:

```c++
	// A dokumentumkönyvtár elérési útja.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Betölti a prezentációt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Eléri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Eléri a kiválasztott dia alakzatgyűjteményét
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Létrehozza a PathFootball effektust a meglévő alakzatra nulláról.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Hozzáadja a PathFootball animációs effektust
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Létrehoz egyfajta „gombot”.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Létrehoz egy sorozatot az effektusokból ehhez a gombhoz.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Létrehoz egy egyéni felhasználói útvonalat. Az objektum csak a gomb megnyomása után kerül mozgatásra.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Parancsokat ad hozzá a mozgáshoz, mivel a létrehozott útvonal üres.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	 //SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // A PPTX fájlt lemezre írja
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alakzatra alkalmazott animációs effektusok lekérése**

Az alábbi példák megmutatják, hogyan kell használni a `GetEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/) interfészből, hogy lekérje az alakzatra alkalmazott összes animációs effektust.

**Példa 1: Animációs effektusok lekérése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan kell animációs effektusokat hozzáadni az alakzatokhoz PowerPoint prezentációkban. Az alábbi minta kód megmutatja, hogyan kell lekérni az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban alkalmazott effektusokat.

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

**Példa 2: Az összes animációs effektus lekérése, beleértve a helyőrzőkből örökölt effektusokat**

Ha egy alakzat egy normál dián olyan helyőrzőkkel rendelkezik, amelyek az elrendezés-dián és/vagy a mester-dián találhatók, és animációs effektusok lettek hozzáadva ezekhez a helyőrzőkhöz, akkor az alakzat összes effektusa lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt effektusokat.

Tegyük fel, hogy van egy `sample.pptx` nevű PowerPoint prezentációfájlunk, amely egyetlen diát tartalmaz, azon csak egy lábléc alakzatot a „Made with Aspose.Slides” szöveggel, és a **Random Bars** effektus van alkalmazva az alakzatra.

![Dia alakzat animációs effektus](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** effektus van alkalmazva a lábléc helyőrzőre az **elrendezés** dián.

![Elrendezés alakzat animációs effektus](layout-shape-animation.png)

Végül a **Fly In** effektus van alkalmazva a lábléc helyőrzőre a **mester** dián.

![Mester alakzat animációs effektus](master-shape-animation.png)

Az alábbi minta kód megmutatja, hogyan kell használni a `GetBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészből az alakzat helyőrzőinek eléréséhez, és az animációs effektusok lekéréséhez, amelyek a lábléc alakzatra vannak alkalmazva, beleértve az elrendezésen és a mesterdián lévő helyőrzőkből örökölt effektusokat.

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

// Lekéri a normál dián lévő alakzat animációs effektusait.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Lekéri a helyőrző animációs effektusait az elrendezés dián.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Lekéri a helyőrző animációs effektusait a mester dián.
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
Type: 47, subtype: 2              // Repülés, Alul
Type: 134, subtype: 45            // Szétválás, Függőlegesen be
Type: 126, subtype: 22            // Véletlen csíkok, Vízszintes
```

## **Animációs effektus időzítési tulajdonságok módosítása**

Az Aspose.Slides for C++ lehetővé teszi az animációs effektus időzítési tulajdonságainak módosítását.

Ez a Animation Timing panel a Microsoft PowerPoint-ben:
![animáció időzítés panel](shape-animation.png)

Az alábbiak a megfelelések a PowerPoint időzítés és a [Effect.Timing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) tulajdonságok között:

- A PowerPoint Timing **Start** legördülő lista egyezik a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) tulajdonsággal. 
- A PowerPoint Timing **Duration** egyezik a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) tulajdonsággal. Az animáció időtartama (másodpercben) az az összes idő, amely egy ciklus befejezéséhez szükséges. 
- A PowerPoint Timing **Delay** egyezik a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) tulajdonsággal. 

Így módosíthatja az Effect Timing tulajdonságokat:

1. Alkalmazza ([Apply](#apply-animation-to-shape)) vagy szerezze meg az animációs effektust.  
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) tulajdonságokra.  
3. Mentse a módosított PPTX fájlt.  

Ez a C++ kód bemutatja a műveletet:
```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Lekéri a fő sorozat első effektusát.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Módosítja az effektus TriggerType értékét kattintásra indításra
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Módosítja az effektus időtartamát
effect->get_Timing()->set_Duration(3.f);

// Módosítja az effektus TriggerDelayTime értékét
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Elmenti a PPTX fájlt a lemezre
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animációs effektus hang**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy hangokat kezelhessen animációs effektusokban: 

- [set_Sound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Animációs effektus hang hozzáadása**

Ez a C++ kód bemutatja, hogyan kell animációs effektus hangot hozzáadni és leállítani, amikor a következő effektus kezdődik:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Hangot ad a prezentáció audio gyűjteményéhez
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Lekéri a fő sorozat első effektusát
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Ellenőrzi, hogy az effektusnak nincs hangja
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Hangot ad az első effektushoz
    firstEffect->set_Sound(effectSound);
}

// Lekéri a dia első interaktív sorozatát.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Beállítja az effektus "Előző hang leállítása" jelzőjét
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// A PPTX fájlt lemezre írja
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Animációs effektus hang kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciaját az indexén keresztül.  
3. Szerezze meg a fő effektussorozatot.  
4. Vonja ki a [set_Sound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_sound/) beágyazott hangot minden egyes animációs effektusból.  

Ez a C++ kód bemutatja, hogyan kell kinyerni egy animációs effektusba beágyazott hangot:
```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Animáció után**

Az Aspose.Slides for C++ lehetővé teszi, hogy megváltoztassa egy animációs effektus After animation (animáció után) tulajdonságát.

Ez a Animation Effect panel és a kibővített menü a Microsoft PowerPoint-ben:
![animáció hatás panel](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő lista egyezik ezekkel a tulajdonságokkal: 

- A [set_AfterAnimationType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) tulajdonság, amely leírja az After animation típust :
  * A PowerPoint **More Colors** egyezik a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal;
  * A PowerPoint **Don't Dim** listaelem egyezik a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** elem egyezik a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal;
  * A PowerPoint **Hide on Next Mouse Click** elem egyezik a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal;
- A [set_AfterAnimationColor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) tulajdonság, amely egy after animation színformátumot definiál. Ez a tulajdonság a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal együttműködve működik. Ha a típust másikra módosítja, az after animation szín törlődik.

Ez a C++ kód bemutatja, hogyan kell módosítani egy after animation effektust:
```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a fő sorozat első effektusát
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// A animáció után típusát Színre változtatja
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Beállítja az animáció után a sötétítő színt
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// A PPTX fájlt lemezre írja
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Szöveg animálása**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy kezelhesse egy animációs effektus *Animate text* blokkját:

- A [set_AnimateTextType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) amely leírja az animált szöveg típusát az effektusban. Az alakzat szövege animálható:
  - Egyszerre ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/animatetexttype/) típus)
  - Szó szerint ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/animatetexttype/) típus)
  - Betű szerint ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/animatetexttype/) típus)
- A [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) beállítja a késleltetést az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a effektus időtartamának százalékát jelöli. A negatív érték a késleltetést másodpercben adja meg.

Így módosíthatja az Effect Animate text tulajdonságokat:

1. Alkalmazza ([Apply](#apply-animation-to-shape)) vagy szerezze meg az animációs effektust.  
2. Állítsa be a [set_BuildType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation.itextanimation/set_buildtype/) tulajdonságot a [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) értékre, hogy kikapcsolja a *By Paragraphs* (bekezdésenként) animációs módot.  
3. Állítson be új értékeket a [set_AnimateTextType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) és a [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) tulajdonságokra.  
4. Mentse a módosított PPTX fájlt.  

Ez a C++ kód bemutatja a műveletet:
```c++
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a fő sorozat első effektusát
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Módosítja az effektus szöveg animáció típusát "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Módosítja az effektus szöveg animálás típusát "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Beállítja a szavak közötti késleltetést az effektus időtartamának 20%-ára
firstEffect->set_DelayBetweenTextParts(20.0f);

// A PPTX fájlt lemezre írja
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre publikálásakor?**  
[Export to HTML5](/slides/hu/cpp/export-to-html5/) és engedélyezze a [beállításokat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/), amelyek a [shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) és [transition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) animációkért felelősek. A sima HTML nem játszik le dián animációkat, míg a HTML5 igen.  

**Hogyan befolyásolja a z-sorrend (réteg sorrend) módosítása az animációt?**  
Az animációs és a rajzolási sorrend független egymástól: egy effektus szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-sorrend](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_zorderposition/) meghatározza, hogy mi takarja meg miét. A látható eredményt ezek kombinációja határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides effektus‑ és alakzat‑modellje ugyanazt a logikát követi.)  

**Vannak korlátozások az animációk videóvá konvertálásakor bizonyos effektusok esetén?**  
Általánosságban a [animációk támogatottak](/slides/hu/cpp/convert-powerpoint-to-video/), de ritka esetekben vagy specifikus effektusok másként jelenhetnek meg. Javasoljuk, hogy tesztelje a használt effektusokkal és a könyvtár verziójával.