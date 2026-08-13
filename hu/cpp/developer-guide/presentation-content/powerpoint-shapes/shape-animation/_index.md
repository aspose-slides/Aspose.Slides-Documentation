---
title: Alakzatanimációk alkalmazása prezentációkban C++ használatával
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/cpp/shape-animation/
keywords:
- alakzat
- animáció
- hatás
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- hatás hozzáadása
- hatás lekérése
- hatás kinyerése
- hatás hangja
- animáció alkalmazása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzatanimációkat PowerPoint prezentációkban az Aspose.Slides for C++ használatával. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](/slides/hu/cpp/animated-charts/) lehet alkalmazni. Életet lehelnek a prezentációkba vagy azok elemeibe.

## **Miért használjunk animációkat a prezentációkban?**

Az animációk segítségével

* szabályozhatja az információ áramlását  
* kiemelheti a fontos pontokat  
* növelheti a közönség érdeklődését vagy részvételét  
* könnyebbé teheti a tartalom olvasását, befogadását vagy feldolgozását  
* a nézők figyelmét a prezentáció fontos részeire irányíthatja  

A PowerPoint számos lehetőséget és eszközt kínál az animációkhoz és animációs hatásokhoz az **belépés**, **kilépés**, **kiemelés** és **mozgáspálya** kategóriákban.

## **Animációk az Aspose.Slides-ben**

* Az Aspose.Slides a [Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation) névtér alatt biztosítja a szükséges osztályokat és típusokat az animációk kezeléséhez,  
* Az Aspose.Slides több mint **150 animációs hatást** kínál a [EffectType](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) felsorolásban. Ezek a hatások lényegében ugyanazok (vagy ekvivalensak), mint a PowerPointban használtak.

## **Animáció alkalmazása egy TextBox-ra**

Az Aspose.Slides for C++ lehetővé teszi animáció alkalmazását egy alakzat szövegére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze be egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape)-et.  
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3)-hez.  
5. Szerezze be a fő hatássorozatot.  
6. Adjon hozzá egy animációs hatást az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape)-hez.  
7. Állítsa be a [TextAnimation.BuildType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) tulajdonságot a [BuildType Enumeration](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) értékére.  
8. Írja a prezentációt lemezre PPTX fájlként.

Ez a C++ kód azt mutatja, hogyan lehet a `Fade` hatást alkalmazni egy AutoShape-ra, és a szöveg animációt a *By 1st Level Paragraphs* értékre állítani:

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

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}}  

A szövegre történő animációk alkalmazása mellett animációt alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_paragraph)-ra is. Lásd a [**Animated Text**](/slides/hu/cpp/animated-text/) oldalt.  

{{% /alert %}}  

## **Animáció alkalmazása egy PictureFrame-re**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze be egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá vagy szerezzen be egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_frame)-et a dián.  
4. Szerezze be a fő hatássorozatot.  
5. Adjon hozzá egy animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_frame)-hez.  
6. Írja a prezentációt lemezre PPTX fájlként.

Ez a C++ kód azt mutatja, hogyan lehet a `Fly` hatást alkalmazni egy képkeretre:

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

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Képkockát ad hozzá a diához
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Fly from Left animációs hatást ad a képkockához
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Elmenti a PPTX fájlt a lemezre
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animáció alkalmazása egy Shape-re**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
2. Szerezze be egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape)-et.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape)-et (a kattintáskor az animáció lejátszódik).  
5. Hozzon létre egy hatássorozatot a bevel alakzaton.  
6. Hozzon létre egy egyedi `UserPath`-t.  
7. Adjon hozzá parancsokat a `UserPath`-hez való mozgatáshoz.  
8. Írja a prezentációt lemezre PPTX fájlként.

Ez a C++ kód azt mutatja, hogyan lehet a `PathFootball` (path football) hatást alkalmazni egy alakzatra:

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

	// A dokumentumkönyvtár elérési útja.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Betölti a prezentációt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Eléri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Eléri a kiválasztott dia alakzatgyűjteményét
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Újrateremt egy PathFootball hatást a meglévő alakzatra a semmiből.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Hozzáadja a PathFootBall animációs hatást
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Létrehoz egyfajta "gombot".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Létrehoz egy hatássorozatot ehhez a gombhoz.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Létrehoz egy egyedi felhasználói útvonalat. Az objektumunk csak a gomb megnyomása után lesz mozgatva.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Hozzáad mozgási parancsokat, mivel a létrehozott útvonal üres.
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
	 
	 // A PPTX fájlt a lemezre írja
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Az alakzatra alkalmazott animációs hatások lekérdezése**

Az alábbi példák azt mutatják, hogyan használhatja a [ISequence](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/) interfész `GetEffectsByShape` metódusát az alakzatra alkalmazott összes animációs hatás lekérésére.

**Példa 1: Animációs hatások lekérdezése egy normál dián lévő alakzatra**

Korábban megtanulta, hogyan adhat animációs hatásokat alakzatokhoz PowerPoint‑prezentációkban. Az alábbi mintakód megmutatja, hogyan lehet lekérni az első normál dián lévő első alakzatra alkalmazott hatásokat a `AnimExample_out.pptx` prezentációban.

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

// Lekéri a dia fő animációs sorozatát.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Lekéri az első dián az első alakzatot.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Lekéri az alakzatra alkalmazott animációs hatásokat.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Példa 2: Az összes animációs hatás lekérdezése, beleértve a helyettesítőkből örökölt hatásokat is**

Ha egy normál dián lévő alakzat helyettesítőkkel rendelkezik, amelyek az elrendezés‑ vagy mesterdián vannak, és animációs hatások vannak hozzárendelve ezekhez a helyettesítőkhöz, akkor a dia vetítés során a helyettesítőkből örökölt hatások is lejátszásra kerülnek.

Tegyük fel, hogy van egy `sample.pptx` PowerPoint‑prezentáció, amelynek egyetlen diája csak egy lábléc‑alakzatot tartalmaz a „Made with Aspose.Slides” szöveggel, és a **Random Bars** hatás van rá alkalmazva.

![Slide shape animation effect](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás a lábléc‑helyettesítőre van alkalmazva az **elrendezés** dián.

![Layout shape animation effect](layout-shape-animation.png)

Végül a **Fly In** hatás a lábléc‑helyettesítőre van alkalmazva a **mester** dián.

![Master shape animation effect](master-shape-animation.png)

Az alábbi mintakód megmutatja, hogyan használhatja a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfész `GetBasePlaceholder` metódusát a helyettesítők lekéréséhez, és hogyan kérdezheti le a lábléc‑alakzatra alkalmazott animációs hatásokat, beleértve a helyettesítőkből örökölt hatásokat is.

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

// A normál dián lévő alakzatra vonatkozó animációs hatások lekérése.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Az elrendezés dián lévő helyettesítőre vonatkozó animációs hatások lekérése.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// A mester dián lévő helyettesítőre vonatkozó animációs hatások lekérése.
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
Type: 134, subtype: 45            // Felosztás, FüggőlegesBe
Type: 126, subtype: 22            // Véletlenszerűsávok, Vízszintes
```

## **Animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for C++ lehetővé teszi az animációs hatások időzítési tulajdonságainak módosítását.

Ez a PowerPoint‑ban megjelenő **Animation Timing** ablaktábla:

![example1_image](shape-animation.png)

Az alábbi összefüggések a PowerPoint‑időzítés és a [Effect.Timing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) tulajdonságok között állnak fenn:

- A PowerPoint‑időzítés **Start** legördülőlistája a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) tulajdonságnak felel meg.  
- A PowerPoint‑időzítés **Duration** a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) tulajdonságnak felel meg. A animáció időtartama (másodpercben) az az összidő, amely a hatás egy ciklusának befejezéséhez szükséges.  
- A PowerPoint‑időzítés **Delay** a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) tulajdonságnak felel meg.

Az Effect Timing tulajdonságok módosítása:

1. [Apply](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) tulajdonságokhoz.  
3. Mentse a módosított PPTX fájlt.

Ez a C++ kód bemutatja a műveletet:

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

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Lekéri a fő sorozat első hatását.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Módosítja a hatás TriggerType értékét kattintásra indításra
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Módosítja a hatás időtartamát
effect->get_Timing()->set_Duration(3.f);

// Módosítja a hatás TriggerDelayTime értékét
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Mentés a PPTX fájlt a lemezre
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animációs hatás hangja**

Az Aspose.Slides a következő tulajdonságokat biztosítja a hangok animációs hatásokban való kezeléséhez:

- [set_Sound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **Animációs hatás hangjának hozzáadása**

Ez a C++ kód megmutatja, hogyan adhat hozzá egy animációs hatás hangját, és hogyan állíthatja le, amikor a következő hatás elindul:

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

// Hangot ad a prezentáció audio gyűjteményéhez
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a dia fő sorozatát.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Lekéri a fő sorozat első hatását
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Ellenőrzi a hatást "Nincs hang" esetére
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Hangot ad az első hatáshoz
    firstEffect->set_Sound(effectSound);
}

// Lekéri a dia első interaktív sorozatát.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Beállítja a hatás "Előző hang leállítása" jelzőjét
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// A PPTX fájlt a lemezre írja
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze be egy dia hivatkozását az indexe alapján.  
3. Szerezze be a fő hatássorozatot.  
4. Kinyerje a [set_Sound()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effect/set_sound/) minden animációs hatáshoz beágyazott hangját.

Ez a C++ kód megmutatja, hogyan nyerheti ki egy animációs hatásba beágyazott hangot:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

Az Aspose.Slides for C++ lehetővé teszi az animációs hatás **After animation** tulajdonságának módosítását.

Ez a PowerPoint‑ban megjelenő **Animation Effect** ablaktábla és kiterjesztett menü:

![example1_image](shape-after-animation.png)

A PowerPoint **After animation** legördülőlistája a következő tulajdonságoknak felel meg:

- [set_AfterAnimationType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) tulajdonság, amely leírja az After animation típust:
  * A PowerPoint **More Colors** a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
  * A PowerPoint **Don't Dim** elem a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típusnak felel meg (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** elem a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
  * A PowerPoint **Hide on Next Mouse Click** elem a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) tulajdonság, amely egy after animation színformátumot határoz meg. Ez a tulajdonság a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típussal együtt működik. Ha a típust másra módosítja, az after animation szín törlődik.

Ez a C++ kód megmutatja, hogyan módosíthat egy after animation hatást:

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

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a fő sorozat első hatását
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Módosítja az after animation típusát Színre
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Beállítja az after animation színét
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// A PPTX fájlt a lemezre írja
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Szöveg animálása**

Az Aspose.Slides a következő tulajdonságokat biztosítja az animációs hatás **Animate text** blokkjának kezeléséhez:

- [set_AnimateTextType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) amely leírja az animált szöveg típusát. A forma szövege animálható:
  - egyszerre mind (**AnimateTextType.AllAtOnce** típussal)  
  - szavanként (**AnimateTextType.ByWord** típussal)  
  - betűnként (**AnimateTextType.ByLetter** típussal)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) beállítja a késleltetést az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg, a negatív érték másodpercben határozza meg a késleltetést.

Az Effect Animate text tulajdonságainak módosítása:

1. [Apply](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítsa be a [set_BuildType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation.itextanimation/set_buildtype/) tulajdonságot a [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.  
3. Állítson be új értékeket a [set_AnimateTextType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) és a [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) tulajdonságokhoz.  
4. Mentse a módosított PPTX fájlt.

Ez a C++ kód bemutatja a műveletet:

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

// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lekéri a fő sorozat első hatását
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Módosítja a hatás szöveganimáció típusát "As One Object"-re
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Módosítja a hatás Animate text típusát "By word"-ra
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Beállítja a szavak közti késleltetést a hatás időtartamának 20%-ára
firstEffect->set_DelayBetweenTextParts(20.0f);

// A PPTX fájlt a lemezre írja
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **GYIK**

### Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre történő közzétételekor?

Használja az [Export to HTML5](/slides/hu/cpp/export-to-html5/) funkciót, és engedélyezze az [options](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/) között a [shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) és [transition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) animációkat. A sima HTML nem játszik le diavetítés‑animációkat, míg az HTML5 igen.

### Hogyan befolyásolja az alakzatok z‑rendjének (réteg sorrendjének) módosítása az animációt?

Az animációs és a rajzolási sorrend független egymástól: egy hatás szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-order](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_zorderposition/) határozza meg, hogy mi takarja le mi‑t. A látható eredményt kombinációjuk határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatás‑és‑alakzat modellje ugyanazt a logikát követi.)

### Vannak-e korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?

Általánosságban az [animációk támogatottak](/slides/hu/cpp/convert-powerpoint-to-video/), de ritka esetekben vagy bizonyos hatásoknál eltérő megjelenés fordulhat elő. Javasolt tesztelni a használt hatásokat és a könyvtár verzióját.