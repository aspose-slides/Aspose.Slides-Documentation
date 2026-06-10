---
title: Alakzat animációk alkalmazása prezentációkban .NET környezetben
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
- hatás hangja
- animáció alkalmazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzat animációkat PowerPoint prezentációkban az Aspose.Slides for .NET segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](/slides/hu/net/animated-charts/) lehet alkalmazni. Életet adnak a bemutatóknak vagy azok elemeinek. 

## **Miért használjunk animációkat a bemutatókban?**

* az információáramlás irányítása  
* fontos pontok kiemelése  
* az érdeklődés vagy a közönség részvételének növelése  
* a tartalom könnyebb olvasása, elsajátítása vagy feldolgozása  
* a közönség figyelmének felhívása a bemutató fontos részeire  

A PowerPoint számos lehetőséget és eszközt kínál az animációk és animációs hatások **belépés**, **kilépés**, **kiemelés** és **mozgási útvonalak** kategóriáiban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az osztályokat és típusokat, amelyekre az animációkkal való munkához szükség van az [Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/) névtérben,  
* Az Aspose.Slides több mint **150 animációs hatást** kínál az [EffectType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttype) felsorolásban. Ezek a hatások lényegében ugyanazok (vagy ekvivalens) a PowerPoint-ban használt hatások.  

## **Animáció alkalmazása egy szövegdobozra**

Az Aspose.Slides for .NET lehetővé teszi, hogy animációt alkalmazz a formán belüli szövegre. 

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) elemet.  
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/textframe) objektumhoz.  
5. Szerezzen egy fő hatássorozatot.  
6. Adjon animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) elemhez.  
7. Állítsa be a [TextAnimation.BuildType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/textanimation/properties/buildtype) tulajdonságot a [BuildType Enumeration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype) értékére.  
8. Mentse a bemutatót lemezre PPTX fájlként.  

Ez a C# kód bemutatja, hogyan kell a `Fade` hatást alkalmazni az AutoShape-re, és a szöveganimációt a *By 1st Level Paragraphs* értékre állítani:

```c#
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Új AutoShape elemet ad hozzá szöveggel
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Lekéri a dia fő sorozatát.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fade animációs hatást ad hozzá az alakzathoz
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animálja az alakzat szövegét az első szintű bekezdések szerint
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Mentse a PPTX fájlt a lemezre
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

A szövegre alkalmazott animációk mellett animációkat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph) elemre is alkalmazhat. Lásd [**Animált szöveg**](/slides/hu/net/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása egy PictureFrame-re**

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá vagy szerezzen meg egy [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe) elemet a dián.  
5. Szerezze meg a fő hatássorozatot.  
6. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe) elemhez.  
8. Mentse a bemutatót lemezre PPTX fájlként.  

Ez a C# kód bemutatja, hogyan kell a `Fly` hatást alkalmazni egy képkockára:

```c#
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation pres = new Presentation())
{
    // Betölti a képet, hogy hozzáadja a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Képkockát ad hozzá a diához
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Lekéri a dia fő sorozatát.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fly balról animációs hatást ad hozzá a képkockához
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Mentse a PPTX fájlt a lemezre
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animáció alkalmazása egy alakzatra**

1. Hozzon létre egy példányt a [Presentation](http://www.aspose.com/api/net/slides/hu/aspose.slides/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) elemet.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) elemet (amikor ez az objektumra kattintanak, az animáció lejátszásra kerül).  
5. Hozzon létre egy hatássorozatot a bevel alakzaton.  
6. Hozzon létre egy egyedi `UserPath`-et.  
7. Adjon parancsokat a `UserPath`-ra való mozgáshoz.  
8. Mentse a bemutatót lemezre PPTX fájlként.  

Ez a C# kód bemutatja, hogyan kell a `PathFootball` (path football) hatást alkalmazni egy alakzatra:

```c#
// Példányosít egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Létrehozza a PathFootball hatást egy meglévő alakzatra a semmiből.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Hozzáadja a PathFootball animációs hatást.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Létrehozza egyfajta "gomb" elemet.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Létrehozza a gombhoz tartozó hatássorozatot.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Létrehoz egy egyéni felhasználói útvonalat. Az objektumunk csak a gomb megnyomása után mozdul el.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hozzáad mozgási parancsokat, mivel a létrehozott útvonal üres.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Kiírja a PPTX fájlt a lemezre
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Az alakzatra alkalmazott animációs hatások lekérése**

A következő példák bemutatják, hogyan kell használni a `GetEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/) interfészből, hogy lekérje egy alakzatra alkalmazott összes animációs hatást.  

**Példa 1: Az animációs hatások lekérése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan kell animációs hatásokat hozzáadni az alakzatokhoz a PowerPoint bemutatókban. A következő mintakód bemutatja, hogyan lehet lekérni az első alakzatra az első normál dián a `AnimExample_out.pptx` bemutatóban alkalmazott hatásokat.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Lekéri a dia fő animációs sorozatát.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Lekéri az első alakzatot az első dián.
    IShape shape = firstSlide.Shapes[0];

    // Lekéri az alakzatra alkalmazott animációs hatásokat.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Példa 2: Az összes animációs hatás lekérése, beleértve a helyőrzőkből örökölt hatásokat is**

Ha egy alakzat egy normál dián helyőrzőkkel rendelkezik, amelyek a elrendezés dián és/vagy a mester dián találhatók, és animációs hatásokat adtak hozzá ezekhez a helyőrzőkhöz, akkor az alakzat összes hatása lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat is.  

Tegyük fel, hogy van egy `sample.pptx` nevű PowerPoint bemutatófájl, amely egyetlen diát tartalmaz, azon csak egy lábléc alakzatot a "Made with Aspose.Slides" szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Dia alakzat animációs hatás](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás a lábléc helyőrzőre van alkalmazva az **elrendezés** dián.

![Elrendezés alakzat animációs hatás](layout-shape-animation.png)

Végül, a **Fly In** hatás a lábléc helyőrzőre van alkalmazva a **mester** dián.

![Mester alakzat animációs hatás](master-shape-animation.png)

A következő mintakód bemutatja, hogyan kell használni a `GetBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészből, hogy elérje az alakzat helyőrzőit, és lekérje a lábléc alakzatra alkalmazott animációs hatásokat, beleértve az elrendezés és a mester diákon elhelyezkedő helyőrzőkből örökölt hatásokat.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a normál dián lévő alakzat animációs hatásait.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Lekéri az elrendezés dián lévő helyőrző animációs hatásait.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Lekéri a mester dián lévő helyőrző animációs hatásait.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Az animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for .NET lehetővé teszi az animációs hatások Timing (időzítés) tulajdonságainak módosítását.  

Ez a PowerPointban a Animation Timing ablaktábla és a kibővített menü:  

![animáció időzítése](shape-animation.png)

Az alábbiak a PowerPoint Timing és az [Effect.Timing](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/properties/timing) tulajdonságok közti megfelelések:  

- A PowerPoint Timing **Start** legördülő lista megfelel az [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/triggertype) tulajdonságnak.  
- A PowerPoint Timing **Duration** megfelel az [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/duration) tulajdonságnak. Egy animáció időtartama (másodpercben) az az összidő, ami alatt az animáció egy ciklust befejez.  
- A PowerPoint Timing **Delay** megfelel az [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/properties/triggerdelaytime) tulajdonságnak.  
- A PowerPoint Timing **Repeat** legördülő lista a következő tulajdonságoknak felel meg:  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount) tulajdonság, amely leírja a *szám* ismétlések számát;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide) jelző, amely meghatározza, hogy a hatás a dia végéig ismétlődik-e;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick) jelző, amely azt határozza meg, hogy a hatás a következő kattintásig ismétlődik-e.  
- A PowerPoint Timing **Rewind when done playing** jelölőnégyzet megfelel az [Effect.Timing.Rewind](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/rewind/) tulajdonságnak.  

Így módosíthatja az Effect Timing tulajdonságokat:  

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/properties/timing) tulajdonságokhoz.  
3. Mentse el a módosított PPTX fájlt.  

Ez a C# kód demonstrálja a műveletet:

```c#
// Példányosít egy presentation osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Lekéri a dia fő sorozatát.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lekéri a fő sorozat első hatását.
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
        // A hatás ismétlést "Until Next Click" értékre módosítja
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // A hatás ismétlést "Until End of Slide" értékre módosítja
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Bekapcsolja a hatás Rewind beállítását
        effect.Timing.Rewind = true;
    
    // Mentse a PPTX fájlt a lemezre
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Animációs hatás hangja**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy hangokat kezelhessen animációs hatásokban:  
- [IEffect.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/stopprevioussound/)  

### **Animációs hatás hangjának hozzáadása**

Ez a C# kód bemutatja, hogyan kell animációs hatás hangot hozzáadni és leállítani, amikor a következő hatás elindul:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Audió hozzáadása a prezentáció audiógyűjteményéhez
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Lekéri a dia fő sorozatát.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Lekéri a fő sorozat első hatását
	IEffect firstEffect = sequence[0];

	// Ellenőrzi a hatás \"No Sound\" állapotát
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Hangot ad hozzá az első hatáshoz
		firstEffect.Sound = effectSound;
	}

	// Lekéri a dia első interaktív sorozatát.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Beállítja a hatás \"Stop previous sound\" jelzőjét
	interactiveSequence[0].StopPreviousSound = true;

	// Kiírja a PPTX fájlt a lemezre
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Szerezze meg a fő hatássorozatot.  
4. Válassza ki a [Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effect/sound/) beágyazott hangot minden animációs hatáshoz.  

Ez a C# kód bemutatja, hogyan lehet kinyerni az animációs hatásba beágyazott hangot:

```c#
// Példányosít egy presentation osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lekéri a dia fő sorozatát.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Kivonja a hatás hangját byte tömbbe
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Animáció után**

Az Aspose.Slides for .NET lehetővé teszi az animációs hatás After animation (animáció után) tulajdonságának módosítását.  

Ez a PowerPointban az Animation Effect ablaktábla és a kibővített menü:  

![animációs hatás panel](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő lista a következő tulajdonságoknak felel meg:  

* [IEffect.AfterAnimationType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/afteranimationtype/) tulajdonság, amely leírja az After animation típust:  
  * A PowerPoint **More Colors** megfelel a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típusnak;  
  * A PowerPoint **Don't Dim** listaelem megfelel a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típusnak (az alapértelmezett after animation típus);  
  * A PowerPoint **Hide After Animation** elem megfelel a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típusnak;  
  * A PowerPoint **Hide on Next Mouse Click** elem megfelel a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típusnak;  
* [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/afteranimationcolor/) tulajdonság, amely meghatározza az after animation színformátumot. Ez a tulajdonság a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típussal együtt működik. Ha más típusra változtatja, az after animation szín törlődik.  

Ez a C# kód bemutatja, hogyan kell módosítani egy after animation hatást:

```c#
// Példányosít egy presentation osztályt, amely egy prezentáció fájlt képvisel
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Az after animation típusát Color-ra változtatja
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Beállítja az after animation színét
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Kiírja a PPTX fájlt a lemezre
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Szöveg animálása**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy a *Animate text* blokkot kezelje egy animációs hatásnál:  

* [IEffect.AnimateTextType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/animatetexttype/) amely leírja a szöveg animálásának típusát a hatásban. Az alakzat szövege animálható:  
  * Egyszerre ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/animatetexttype/) típus)  
  * Szó szerint ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/animatetexttype/) típus)  
  * Betű szerint ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/animatetexttype/) típus)  
* [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/delaybetweentextparts/) beállít egy késleltetést a animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát jelzi. A negatív érték a késleltetést másodpercben adja meg.  

Így módosíthatja az Effect Animate text tulajdonságait:  

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítsa be a [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itextanimation/buildtype/) tulajdonságot a [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype/) értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.  
3. Állítson be új értékeket a [IEffect.AnimateTextType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/animatetexttype/) és a [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/delaybetweentextparts/) tulajdonságokhoz.  
4. Mentse el a módosított PPTX fájlt.  

Ez a C# kód demonstrálja a műveletet:

```c#
// Példányosít egy presentation osztályt, amely egy prezentáció fájlt képvisel.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Módosítja a hatás szöveganimáció típusát "As One Object" értékre
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Módosítja a hatás Animate text típusát "By word" értékre
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Beállítja a szavak közti késleltetést a hatás időtartamának 20%-ára
    firstEffect.DelayBetweenTextParts = 20f;

    // Kiírja a PPTX fájlt a lemezre
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hogyan biztosíthatom, hogy az animációk megmaradjanak a bemutató webre publikálásakor?**

[Export to HTML5](/slides/hu/net/export-to-html5/) és engedélyezze az [opciókat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/), amelyek a [shape](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) és [transition](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) animációkért felelősek. A sima HTML nem játszik le diavetítési animációkat, míg a HTML5 igen.  

**Hogyan befolyásolja az animációt az alakzatok z-sorrendjének (rétegsorrend) módosítása?**

Az animáció és a rajzolási sorrend független egymástól: egy hatás szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-sorrend](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/zorderposition/) meghatározza, mi takarja meg a mást. A látható eredményt ezek kombinációja határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatások‑és‑alakzatok modellje ugyanazt a logikát követi.)  

**Vannak korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?**

Általánosságban a [animációk támogatottak](/slides/hu/net/convert-powerpoint-to-video/), de ritka esetekben vagy bizonyos hatások esetén eltérően jelenhetnek meg. Ajánlott tesztelni a használt hatásokkal és a könyvtár verziójával.