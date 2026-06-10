---
title: Diaátmenetek kezelése prezentációkban .NET-ben
linktitle: Diaátmenet
type: docs
weight: 90
url: /hu/net/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diaátmeneteket az Aspose.Slides for .NET-ben, lépésről lépésre útmutatóval a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a diák átmenetei prezentációkban az Aspose.Slides segítségével. Megmutatja, hogyan alkalmazhatók átmenettípusok a diákra, hogyan konfigurálható az átmenet viselkedése, például kattintásra vagy meghatározott idő után továbbhaladás, hogyan ellenőrizhető és letiltható az automatikus továbbhaladás, a Morph átmenet és annak típusainak használata, valamint az átmeneti effektus beállításai. A példák demonstrálják, hogyan töltsünk be vagy hozzunk létre egy prezentációt, hogyan módosítsuk a kiválasztott diák átmenetbeállításait, és hogyan mentsük az eredményt PPTX fájlként. A cikk továbbá válaszol a gyakori kérdésekre az átmenet sebességével, hangokkal, ugyanazon átmenet több diára való alkalmazásával, valamint a dián jelenleg beállított átmenet ellenőrzésével kapcsolatban.

## **Diaátmenet hozzáadása**
Az érthetőség kedvéért bemutattuk az Aspose.Slides for .NET használatát egyszerű diaátmenetek kezelésére. A fejlesztők nemcsak különböző diaátmeneti effektusokat alkalmazhatnak a diákon, hanem testre is szabhatják ezeknek a hatásoknak a viselkedését. Egy egyszerű diaátmeneti effektus létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for .NET által kínált átmeneti effektusok egyikéből a TransitionType felsorolás (enum) használatával.  
3. Írja ki a módosított prezentációfájlt.  

```c#
// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Kör típusú átmenet alkalmazása az 1. diára
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Comb típusú átmenet alkalmazása a 2. diára
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // A prezentáció mentése lemezre
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Haladó diaátmenet hozzáadása**
Az előző szakaszban csak egy egyszerű átmenetet alkalmaztunk a diára. Most, hogy ezt az egyszerű átmenetet még jobbá és szabályozottabbá tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for .NET által kínált átmeneti effektusok egyikéből.  
3. Beállíthatja az átmenetet, hogy kattintásra (Advance On Click), egy meghatározott idő elteltével vagy mindkettőre.  
4. Ha a diaátmenet be van állítva, hogy kattintásra haladjon (Advance On Click), az átmenet csak akkor lép tovább, amikor valaki rákattint az egérre. Ezenkívül, ha az Advance After Time tulajdonság be van állítva, az átmenet automatikusan továbbhalad a megadott idő leteltével.  
5. Írja ki a módosított prezentációt prezentációfájlként.  

```c#
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Kör típusú átmenet alkalmazása az 1. diára
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Átmenet időtartamának beállítása 3 másodperc
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Comb típusú átmenet alkalmazása a 2. diára
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Átmenet időtartamának beállítása 5 másodperc
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Zoom típusú átmenet alkalmazása a 3. diára
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Átmenet időtartamának beállítása 7 másodperc
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // A prezentáció mentése lemezre
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Továbbá az [AdvanceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceafter/) tulajdonság segítségével ellenőrizheti, hogy a diaátmenet úgy van-e beállítva, hogy a következő diára lépjen, vagy letiltja-e a beállítást.

Ez a C# kód demonstrálja a műveletet:

```c#
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // A dia átmenetének lekérése
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Ellenőrzi, hogy az Advance After Time beállítás engedélyezve van-e
        if (slideTransition.AdvanceAfter)
        {
            // Kiírja az Advance After Time értékét
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Letiltja a diaátmenetet egy adott idő után, ha az AdvanceAfterTime értéke nagyobb, mint 2 másodperc
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph átmenet**
Aspose.Slides for .NET most már támogatja a [Morph Transition](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/imorphtransition) funkciót. Ez egy új morph átmenetet jelent, amelyet a PowerPoint 2019 vezette be. A Morph átmenet lehetővé teszi a sima mozgás animálását az egyik diáról a következőre. Ez a cikk leírja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyek legalább egy közös objektummal rendelkeznek. A legegyszerűbb módja egy dia duplikálása, majd a második dián lévő objektum áthelyezése egy másik helyre.

Az alábbi kódrészlet megmutatja, hogyan adhatunk egy klónt a diáról szöveggel a prezentációhoz, és állíthatunk be egy [morph type](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) átmenetet a második diára.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph átmenet típusok**
Új [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionmorphtype) enumeráció került hozzáadásra. Különböző Morph diaátmenet típusokat képvisel.

- ByObject: A Morph átmenet úgy történik, hogy a alakzatokat elválaszthatatlan objektumokként veszi figyelembe.  
- ByWord: A Morph átmenet során, ahol lehetséges, a szöveget szavanként továbbítja.  
- ByChar: A Morph átmenet során, ahol lehetséges, a szöveget karakterenként továbbítja.  

Az alábbi kódrészlet megmutatja, hogyan állítható be a morph átmenet a diára, és hogyan változtatható a morph típus:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Átmeneti effektusok beállítása**
Az Aspose.Slides for .NET támogatja az átmeneti effektusok beállítását, például feketéből, balról, jobbról stb. Az átmeneti effektus beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.  
- Szerezze meg a dia hivatkozását.  
- Állítsa be az átmeneti effektust.  
- Írja ki a prezentációt egy [PPTX ](https://docs.fileformat.com/presentation/pptx/)fájlként.  

Az alábbi példában beállítottuk az átmeneti effektusokat.

```c#
// Példányosít egy Presentation osztályt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Állítja be a hatást
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// A prezentáció mentése lemezre
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Személyre szabhatom a diaátmenet lejátszási sebességét?**

Igen. Állítsa be az átmenet [Speed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/speed/) értékét a [TransitionSpeed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionspeed/) beállítással (például lassú/közepes/gyors).

**Csatolhatok audiót egy átmenethez, és beállíthatom, hogy ismétlődjön?**

Igen. Beágyazhat hangot az átmenethez, és a viselkedést szabályozhatja olyan beállításokkal, mint a hang mód és a loop (például [Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/soundloop/), plus metadata such as [SoundIsBuiltIn](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) and [SoundName](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden dia számára alkalmazzuk?**

Állítsa be a kívánt átmenettípust minden dia átmeneti beállításában; az átmenetek diánként vannak tárolva, ezért ugyanazt a típust minden dián alkalmazva konzisztens eredményt kap.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslide/slideshowtransition/) és olvassa el annak [transition type](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/type/) értékét; ez a érték pontosan megmondja, melyik hatás van alkalmazva.