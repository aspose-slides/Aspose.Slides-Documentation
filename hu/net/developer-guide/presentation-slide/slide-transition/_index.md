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
- fejlett diaátmenet
- Morph átmenet
- átmenettípus
- átmenet effektus
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza a diaátmeneteket, állítsa be az automatikus dia előrehaladást, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for .NET segítségével minden diához kiválaszthatja az átmeneti effektust, beállíthatja a haladást egérkattintással vagy időzítővel, és módosíthatja az effektushoz specifikus beállításokat. Ez a cikk C# példákat használ az átmenetek alkalmazására, a pontos átmeneti időtartamok megadására, a diaidőzítés kezelésére, valamint egy Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal, majd érje el a dia [SlideShowTransition](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/slideshowtransition/) tulajdonságát. Állítsa be a [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/type/) értékét a [TransitionType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitiontype/) felsorolt értékei közül, majd mentse a prezentációt.

Az alábbi példa a Circle átmenetet alkalmazza az első diára, a Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Fejlett diaátmenet hozzáadása**

Beállíthatja, hogy mennyi ideig maradjon egy dia a képernyőn, és hogy egérkattintás-e szükséges a diavetítés haladásához. A következő tulajdonságok szabályozzák ezt a viselkedést:

- [AdvanceOnClick](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceonclick/) lehetővé teszi a néző számára, hogy egérkattintással lépjen tovább.
- [AdvanceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceafter/) aktiválja a automatikus haladást.
- [AdvanceAfterTime](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceaftertime/) adja meg a késleltetést az automatikus haladás előtt ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített haladást, hogy a néző kattintással léphessen tovább vagy a visszaszámlálóra várjon. Ha csak az időzítőt szeretné használni, állítsa a [AdvanceOnClick](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceonclick/) értékét `false`‑ra. A késleltetés azt szabályozza, mikor halad tovább a diavetítés; nem határozza meg a vizuális átmenet effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és 3, 5 illetve 7 másodperces automatikus haladást állít be. Egérkattintással is előreléphet a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Az időzített haladás engedélyezésének ellenőrzéséhez olvassa ki a [AdvanceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceafter/) értékét. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus haladást azoknál a diákon, ahol a késleltetés több mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Az átmeneti időzítés pontos szabályozása**

Használja a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/duration/) tulajdonságot a átmeneti effektus pontos hosszának megadásához ezredmásodpercben. A dia [SlideShowTransition](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/slideshowtransition/) tulajdonsága ezeket a beállításokat az [ISlideShowTransition](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Tulajdonság | Leírás |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/duration/) | Beállítja az átmenet effektus tényleges időtartamát ezredmásodpercben. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhalad, ezredmásodpercben. Engedélyezze a [AdvanceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/advanceafter/) tulajdonságot az időzítő aktiválásához. |
| [Speed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/speed/) | A [TransitionSpeed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionspeed/) felsorolt előre meghatározott sebességkategóriáját választja: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/duration/) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus haladás késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a átmeneti típus és a [Speed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/speed/) érték alapján határozza meg az effektus hosszát.

### **Azonos időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt az effektust és ugyanazt a pontos időtartamot minden dián. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitiontype/) közül a Fade‑et választja, és minden átmenetnek 750 ms időtartamot ad. Ezen kívül külön engedélyezi az automatikus haladást 5 000 ms után, és letiltja a kattintásos haladást, majd PPTX‑ként menti az eredményt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Állítsa be az automatikus haladást az effektus időtartamától függetlenül.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Különböző időtartamok beállítása az egyes diákhoz**

Különböző diák használhatnak eltérő effektus időtartamokat. Például egy címdia esetén rövid átmenetet, egy szekcióbevezetőnél hosszabbat alkalmazhat. Ez a példa 500 ms‑et állít be az első diára, és 1 200 ms‑et a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Átmenetek összehangolása animált kimenettel**

Amikor [animated GIF](/slides/hu/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/net/export-to-html5/) vagy [video](/slides/hu/net/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat az export előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms‑es fade‑et a jelenetek között, és külön szabályozza minden dia haladási késleltetését, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF‑ és videó‑kimenetnél koordinálja a kimeneti képkockasebességet az effektus időtartamával: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze az adott exportformátum támogatott effektusait és időzítési lehetőségeit, és előnézeti módban győződjön meg a szinkronizációról.

### **Létező átmenet időtartamának olvasása**

Olvassa ki a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/duration/) értékét a módosítás előtt, hogy megállapítsa, tárolt‑e expliciten időtartam. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; egy nem negatív érték a tárolt időtartamot jelzi ezredmásodpercben. A be nem állított érték nem a számított lejátszási időtartam: az Aspose.Slides a tranzíció típusa és a [Speed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/speed/) alapján határozza meg azt. Egy átmenettípus beállítása inicializálhatja az időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph átmenet**

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozgass vagy méretezzen át egy objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapot között.

Az alábbi példa egy szövegbuborékot tartalmazó diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a buborék helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitiontype/) felsorolásból a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs megtekintőben, hogy lássa az effektust a diavetítés közben.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph átmenettípusok**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan illeszti és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionmorphtype/) az egyes alakzatokat egészként kezeli.
- [ByWord](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak szerint illeszti, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek szerint illeszti, ahol lehetséges.

Állítsa a [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/type/) attribútumot Morph‑ra, mielőtt elérné a [Value](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/value/) attribútumot. A value ezután az [IMorphTransition](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/imorphtransition/) interfészt biztosítja, amelynek a [MorphType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/imorphtransition/morphtype/) tulajdonsága választja ki a megfelelő illesztési módot.

Ez a példa megnyitja az előző szekcióban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra állítja be.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Átmeneti hatások beállítása**

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy azt, hogy az effektus fekete képernyőről indul-e. Az elérhető opciók a kiválasztott [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/type/) függvényében változnak. Először állítsa be a típust, majd használja a megfelelő interfészt a [Value](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/value/) attribútumból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/ioptionalblacktransition/) segítségével beállítja a [FromBlack](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) attribútumot, így az átmenet fekete képernyőről indul.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **GYIK**

**Szabályozhatom a diaátmenet lejátszási sebességét?**

Igen. Használja a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/duration/) tulajdonságot, ha pontos effektusidőt szeretne megadni ezredmásodpercben. Használja a [Speed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/slideshowtransition/speed/) tulajdonságot, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva. Ezek a beállítások a átmeneti effektust szabályozzák, függetlenül az automatikus haladás késleltetésétől.

**Csatolhatok hangot egy átmenethez, és megismételhetem azt?**

Igen. Rendelj egy beágyazott hangot a [Sound](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/sound/) attribútumhoz, állítsa a [SoundMode](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/soundmode/) értékét a [TransitionSoundMode](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitionsoundmode/) felsorolásából a StartSound‑ra, és engedélyezze a [SoundLoop](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/soundloop/) beállítást. A hang addig ismétlődik, amíg a következő hangesemény meg nem jelenik a diavetítésben.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iteráljon végig a prezentáció [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményén, és állítsa be minden dia [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/type/) attribútumát azonos értékre. A cikluson belül állítsa be a szükséges időzítési és effektus opciókat, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy milyen átmenet van jelenleg beállítva egy dián?**

Olvassa ki a [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/islideshowtransition/type/) attribútumot a dia [SlideShowTransition](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/slideshowtransition/) tulajdonságából. Az érték a [TransitionType](https://reference.aspose.com/slides/hu/net/aspose.slides.slideshow/transitiontype/) felsorolt értékei közül egyet ad vissza; a None azt jelenti, hogy nincs átmeneti effektus alkalmazva.