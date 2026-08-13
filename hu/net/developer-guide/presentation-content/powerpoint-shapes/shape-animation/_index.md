---
title: Alkalmazz alakzat animációkat prezentációkban .NET-ben
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/net/shape-animation/
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
- hatás hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzat animációkat PowerPoint prezentációkban az Aspose.Slides for .NET segítségével. Emelkedjen ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [grafikonokra](/slides/hu/net/animated-charts/) lehet alkalmazni. Életet adnak a prezentációknak vagy azok elemeinek. 

## **Miért használjunk animációkat a prezentációkban?**

Az animációk segítségével 

* az információáramlás szabályozása
* a fontos pontok kiemelése
* az érdeklődés vagy részvétel növelése a közönségben
* a tartalom olvasásának, elsajátításának vagy feldolgozásának megkönnyítése
* a olvasók vagy nézők figyelmének felirányítása a prezentáció fontos részeire

A PowerPoint számos lehetőséget és eszközt kínál az animációk és animációs hatások számára a **belépés**, **kilépés**, **kiemelés** és **mozgáspálya** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az animációkkal való munkához szükséges osztályokat és típusokat a [Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/) névtérben,  
* Az Aspose.Slides több mint **150 animációs hatást** biztosít a [EffectType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttype) felsorolásban. Ezek a hatások lényegében megegyeznek (vagy ekvivalensek) a PowerPoint-ban használt hatásokkal.  

## **Animáció alkalmazása egy TextBox-ra**

Az Aspose.Slides for .NET lehetővé teszi, hogy animációt alkalmazzon egy alakzat szövegére. 

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape)-t.  
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/textframe)-hez.  
5. Szerezze meg a fő hatássorozatot.  
6. Adjon animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape)-hez.  
7. Állítsa be a [TextAnimation.BuildType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/textanimation/properties/buildtype) tulajdonságot a [BuildType Enumeration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype) értékére.  
8. Írja ki a prezentációt lemezre PPTX fájlként.  

Ez a C# kód megmutatja, hogyan kell alkalmazni a `Fade` hatást az AutoShape-re, és beállítani a szöveg animációt a *By 1st Level Paragraphs* értékre:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Új AutoShape-et ad hozzá szöveggel
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Három bekezdést ad hozzá, hogy a bekezdésenkénti felépítésnek legyen mit feldolgoznia.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fade animációs hatást ad az alakzathoz
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Az alakzat szövegét az első szintű bekezdések szerint animálja
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Mentse a PPTX fájlt a lemezre
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

A szövegre való animációk mellett animációkat alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph) elemre is. Lásd [**Animált szöveg**](/slides/hu/net/animated-text/).  

{{% /alert %}} 

## **Animáció alkalmazása egy PictureFrame-re**

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá vagy szerezzen egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe)-et a diára.  
5. Szerezze meg a fő hatássorozatot.  
6. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe)-hez.  
8. Írja ki a prezentációt lemezre PPTX fájlként.  

Ez a C# kód megmutatja, hogyan kell alkalmazni a `Fly` hatást egy képkeretre:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation pres = new Presentation())
{
    // Betölti a képet, amely a prezentáció képkollekciójába kerül
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Képkockát ad a diára
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fly animációt ad a balról a képkockához
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Mentse a PPTX fájlt a lemezre
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animáció alkalmazása egy Shape-re**

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape)-t.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape)-et (amikor ezt az objektumot kattintják, az animáció lejátszódik).  
5. Hozzon létre egy hatássorozatot a bevel alakzaton.  
6. Hozzon létre egy egyéni `UserPath`-t.  
7. Adjon parancsokat a `UserPath`-ra való mozgáshoz.  
8. Írja ki a prezentációt lemezre PPTX fájlként.  

Ez a C# kód megmutatja, hogyan kell alkalmazni a `PathFootball` (path football) hatást egy alakzatra:  

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Létrehozza a PathFootball hatást a meglévő alakzathoz a semmiből.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Hozzáadja a PathFootBall animációs hatást.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Létrehoz egyfajta „gombot”.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Létrehoz egy hatássorozatot a gombhoz.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Létrehoz egy egyéni felhasználói útvonalat. Az objektumunk csak a gomb megnyomása után lesz mozdítva.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Parancsokat ad hozzá a mozgáshoz, mivel a létrehozott útvonal üres.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // A PPTX fájlt lemezre írja
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Az alakzatra alkalmazott animációs hatások lekérése**

A következő példák megmutatják, hogyan kell használni a `GetEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/) interfészből, hogy lekérje egy alakzatra alkalmazott összes animációs hatást.  

**Példa 1: Animációs hatások lekérése egy normál dián lévő alakzatra**  

Korábban megtanulta, hogyan kell animációs hatásokat hozzáadni alakzatokhoz PowerPoint prezentációkban. A következő példa kód megmutatja, hogyan kell lekérni az első alakzatra alkalmazott hatásokat az első normál dián a `AnimExample_out.pptx` prezentációban.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Lekéri a dia fő animációs szekvenciáját.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Lekéri az első alakzatot az első dián.
    IShape shape = firstSlide.Shapes[0];

    // Lekéri az alakzatra alkalmazott animációs hatásokat.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Példa 2: Az összes animációs hatás lekérése, beleértve a helyőrzőkből örökölt hatásokat**  

Ha egy normál dián lévő alakzat helyőrzőkkel rendelkezik, amelyek a layout vagy a master dián vannak, és animációs hatásokat adtak ezekhez a helyőrzőkhöz, akkor az alakzat összes hatása lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat.  

Tegyük fel, hogy van egy `sample.pptx` PowerPoint prezentációs fájlunk, amely egyetlen diát tartalmaz, azon csak egy lábléc alakzat a "Made with Aspose.Slides" szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.  

![Slide shape animation effect](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás alkalmazva van a lábléc helyőrzőre a **layout** dián.  

![Layout shape animation effect](layout-shape-animation.png)

Végül a **Fly In** hatás van alkalmazva a lábléc helyőrzőre a **master** dián.  

![Master shape animation effect](master-shape-animation.png)

A következő példa kód megmutatja, hogyan kell használni a `GetBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészből, hogy hozzáférjünk az alakzat helyőrzőihez, és lekérjük a láblécre alkalmazott animációs hatásokat, beleértve a layout és master diák helyőrzőiből örökölt hatásokat.  

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a alakzatra alkalmazott animációs hatásokat a normál dián.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Lekéri a helyőrzőre alkalmazott animációs hatásokat a layout dián.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Lekéri a helyőrzőre alkalmazott animációs hatásokat a master dián.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for .NET lehetővé teszi, hogy módosítsa egy animációs hatás időzítési tulajdonságait.  

Ez a Microsoft PowerPoint Animation Timing ablaktábla és kibővített menüje:  

![example1_image](shape-animation.png)

- A PowerPoint Timing **Start** legördülő lista megfelel a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/triggertype) tulajdonságnak.  
- A PowerPoint Timing **Duration** a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/duration) tulajdonsággal egyezik. Az animáció időtartama (másodpercben) az az összes idő, amely a hatás egy ciklusának befejezéséhez szükséges.  
- A PowerPoint Timing **Delay** a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/triggerdelaytime) tulajdonsággal egyezik.  
- A PowerPoint Timing **Repeat** legördülő lista megfelel ezeknek a tulajdonságoknak:  
  * a [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount) tulajdonság, amely leírja a hatás *számát*;  
  * a [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide) jelző, amely megadja, hogy a hatás a dia végéig ismétlődik-e;  
  * a [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick) jelző, amely megadja, hogy a hatás a következő kattintásig ismétlődik-e.  
- A PowerPoint Timing **Rewind when done playing** jelölőnégyzet a [Effect.Timing.Rewind](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/rewind/) tulajdonsággal egyezik.  

Így módosíthatja a Effekt időzítési tulajdonságait:  

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.  
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/properties/timing) tulajdonságokhoz.  
3. Mentse a módosított PPTX fájlt.  

Ez a C# kód bemutatja a műveletet:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lekéri a fő szekvencia első hatását.
    IEffect effect = sequence[0];

    // A hatás TriggerType értékét kattintásra indításra módosítja
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // A hatás időtartamát módosítja
    effect.Timing.Duration = 3f;

    // A hatás TriggerDelayTime értékét módosítja
    effect.Timing.TriggerDelayTime = 0.5f;

    // Ha a hatás Repeat értéke "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // A hatás Repeat értékét "Until Next Click"-re módosítja
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // A hatás Repeat értékét "Until End of Slide"-re módosítja
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Bekapcsolja a hatás Rewind beállítását
        effect.Timing.Rewind = true;
    
    // Elmenti a PPTX fájlt lemezre
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Animációs hatás hang**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja, hogy hangokkal dolgozhasson animációs hatásokban:  
- [IEffect.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/stopprevioussound/)  

### **Animációs hatás hang hozzáadása**

Ez a C# kód megmutatja, hogyan kell animációs hatás hangot hozzáadni és leállítani, amikor a következő hatás elindul:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Hozzáad hangot a prezentáció hanggyűjteményéhez
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Lekéri a dia fő szekvenciáját.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Lekéri a fő szekvencia első hatását
	IEffect firstEffect = sequence[0];

	// Ellenőrzi, hogy a hatásnak nincs-e hangja
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Hozzáad hangot az első hatáshoz
		firstEffect.Sound = effectSound;
	}

	// Lekéri a dia első interaktív szekvenciáját.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Beállítja a hatás "Stop previous sound" jelzőjét
	interactiveSequence[0].StopPreviousSound = true;

	// A PPTX fájlt lemezre írja
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Animációs hatás hang kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Szerezze meg a fő hatássorozatot.  
4. Vonja ki minden animációs hatáshoz beágyazott [Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/sound/) hangot.  

Ez a C# kód megmutatja, hogyan kell kinyerni egy animációs hatásba beágyazott hangot:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Kinyeri a hatás hangját bájt tömbbe
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Animáció után**

Az Aspose.Slides for .NET lehetővé teszi, hogy módosítsa egy animációs hatás After animation (animáció után) tulajdonságát.  

Ez a Microsoft PowerPoint Animation Effect ablaktábla és kibővített menüje:  

![example1_image](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő lista megfelel ezeknek a tulajdonságoknak:  

- A [IEffect.AfterAnimationType] tulajdonság, amely leírja az animáció utáni típust:  
  * a PowerPoint **More Colors** a [AfterAnimationType.Color] típussal egyezik;  
  * a PowerPoint **Don't Dim** elem a [AfterAnimationType.DoNotDim] típussal egyezik (az alapértelmezett animáció utáni típus);  
  * a PowerPoint **Hide After Animation** elem a [AfterAnimationType.HideAfterAnimation] típussal egyezik;  
  * a PowerPoint **Hide on Next Mouse Click** elem a [AfterAnimationType.HideOnNextMouseClick] típussal egyezik;  
- Az [IEffect.AfterAnimationColor] tulajdonság egy animáció utáni színformátumot határoz meg. Ez a tulajdonság a [AfterAnimationType.Color] típussal együtt működik. Ha a típust másikra változtatja, az animáció utáni szín törlődik.  

Ez a C# kód megmutatja, hogyan kell módosítani egy animáció utáni hatást:  

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lekéri a fő szekvencia első hatását
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // A "after animation" típust Színre módosítja
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Beállítja az animáció utáni elhalványítás színét
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // A PPTX fájlt lemezre írja
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Szöveg animálása**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja, hogy dolgozhasson egy animációs hatás *Animate text* blokkjával:  

- [IEffect.AnimateTextType] amely leírja az animált szöveg típusát a hatáson. Az alakzat szövege animálható:  
  - egyszerre ([AnimateTextType.AllAtOnce] típus)  
  - szó szerint ([AnimateTextType.ByWord] típus)  
  - betű szerint ([AnimateTextType.ByLetter] típus)  
- [IEffect.DelayBetweenTextParts] késleltetést állít be az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték késleltetést ad másodpercben.  

Így módosíthatja az Effekt Animate text tulajdonságait:  

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.  
2. Állítsa be a [IEffect.TextAnimation.BuildType] tulajdonságot a [BuildType.AsOneObject] értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.  
3. Állítson be új értékeket a [IEffect.AnimateTextType] és a [IEffect.DelayBetweenTextParts] tulajdonságokhoz.  
4. Mentse a módosított PPTX fájlt.  

Ez a C# kód bemutatja a műveletet:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lekéri a fő szekvencia első hatását
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Módosítja a hatás szöveg animáció típusát "As One Object"-ra
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Módosítja a hatás animált szöveg típusát "By word"-ra
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    firstEffect.DelayBetweenTextParts = 20f;

    // A PPTX fájlt lemezre írja
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

### Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre publikálásakor?

[Export to HTML5](/slides/hu/net/export-to-html5/) és engedélyezze a [beállításokat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/), amelyek a [shape](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) és a [transition](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) animációkért felelősek. A sima HTML nem játssza le a diák animációit, míg a HTML5 igen.  

### Hogyan befolyásolja az alakzatok z-sorrendjének (réteg sorrendjének) módosítása az animációt?

Az animáció és a rajzolási sorrend független egymástól: egy hatás szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-order](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/zorderposition/) meghatározza, mi takarja meg miet. A látható eredményt ezek kombinációja határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatás- és alakzatmodellje ugyanazt a logikát követi.)  

### Vannak korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?

Általánosságban a [animációk támogatottak](/slides/hu/net/convert-powerpoint-to-video/), de ritka esetekben vagy egyes hatásoknál eltérő renderelés fordulhat elő. Ajánlott tesztelni a használt hatásokat és a könyvtár verzióját.