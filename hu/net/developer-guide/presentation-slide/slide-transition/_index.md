---
title: Diaátmenetek kezelése a .NET prezentációkban
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
- átmenet típusa
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diaátmenetek alkalmazása, automatikus dialépés konfigurálása és a Morph valamint egyéb átmeneti hatások testreszabása az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A diavetítések átmenetei szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for .NET segítségével minden diához kiválaszthat egy átmeneti hatást, beállíthatja a haladást egérkattintás vagy időzítő alapján, és módosíthatja az adott hatáshoz tartozó beállításokat. Ez a cikk C# példákat használ az átmenetek alkalmazására, a pontos átmeneti időtartamok megadására, a dia időzítésének kezelésére és egy Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal, és érje el a dia [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) tulajdonságát. Állítsa be a [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) értékét a [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) felsorolás egyik értékére, majd mentse a bemutatót.

A következő példa kör átmenetet (Circle) alkalmaz az első diára és comb átmenetet (Comb) a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerékátmenet**

Az [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) tulajdonság az [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) interfészben szabályozza, hány sugár (radialis szektor) fed fel céldiat. Állítsa be a dia átmenet [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) értékét Wheel-re a [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)‑ből, mielőtt a [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)‑t [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/)‑ként lekérné.

Ez a példa két azonos páros diát hoz létre: egy fekete diát, amelyet egy arany téglalapos dia követ. A céldiak 1 és 8 sugárszámmal rendelkeznek, ugyanazzal a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) értékkel és egyértelműen 8 000 ms [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) értékkel, hogy a különbség könnyen megfigyelhető legyen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Nyissa meg a kimeneti bemutatót a PowerPointban, és indítsa el a diavetítést. Haladjon az 1‑es diáról a 2‑esre, majd a 3‑asról a 4‑esre. A PowerPoint lejátszásakor az ellenőrzött 1 sugár spirálként fedi fel a diát, míg a 8 sugár egyszerre nyolc radialis szektorban jeleníti meg azt. A céltartalom és az átmenet időzítése azonos, így a különbség a felfedő szektorok száma.

## **Fakulás feketébe a Reveal átmenettel**

Állítsa a céldia átmenet típusát Reveal‑re, majd használja az [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/)‑t a [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/) beállításához. A példa egy türkiz forrásdiát és egy korall céldiat hoz létre, majd mindkettőt klónozza, hogy összehasonlíthassa ugyanazt a kétmásodperces átmenetet a kikapcsolt és bekapcsolt fade‑val.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

PowerPoint diavetítésben haladjon az 1‑es diáról a 2‑esre. A türkiz közvetlenül a korallba fakul. Ezután haladjon a 3‑as diáról a 4‑esre. A képernyő röviden majdnem feketére sötétül, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

Az alábbi sorok a PowerPoint képkockáit mutatják félmásodperces intervallumokban. Hasonlítsa össze a sor középső képkockáját, hogy lássa a beállítás hatását.

![PowerPoint lejátszás ThroughBlack letiltva (felső) és engedélyezve (alsó). Csak az alsó sor halad át közel feketén.](reveal-through-black.png)

## **Haladó diaátmenet hozzáadása**

Konfigurálhatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintásra vagy automatikusan lépjen-e tovább a diavetítés. A következő tulajdonságok szabályozzák ezt a viselkedést:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) lehetővé teszi a nézőnek, hogy az egérkattintással lépjen tovább.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) engedélyezi az automatikus előrehaladást.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) a késleltetést adja meg az automatikus előrehaladás előtt, ezredmásodpercben.

Engedélyezze mind a kattintással, mind az időzítővel történő előrehaladást, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, állítsa a [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) értékét `false`‑ra. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem a vizuális átmenet időtartamát határozza meg.

Ez a példa különböző hatásokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után. Egérkattintással is léphet tovább ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

A timed‑előrehaladás engedélyezésének ellenőrzéséhez olvassa ki a [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) értékét. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diákon, ahol a késleltetés több mint két másodperc. Ezekhez a diákhoz engedélyezi az egérkattintást, majd elmenti a frissített beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

Használja a [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)‑t egy átmeneti hatás pontos hosszának megadásához ezredmásodpercben. A dia [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) tulajdonsága ezeket a beállításokat a [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Tulajdonság | Cél |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Beállítja az átmeneti hatás időtartamát ezredmásodpercben. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Beállítja a késleltetést, mielőtt a dia automatikusan továbblép, ezredmásodpercben. Az [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) engedélyezésével aktiválható ez az időzítő. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/)‑ból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) csak az átmeneti hatást szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs kifejezett időtartam megadva, az Aspose.Slides a hatás időtartamát a átmenet típusából és a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) értékéből számolja ki.

### **Azonos időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa beolvassa a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)‑ból a Fade‑t választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja az egérkattintással történő előrehaladást, majd PPTX‑ként menti az eredményt.

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

    // Állítsa be az automatikus előrehaladást a hatás időtartamától függetlenül.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Különböző időtartamok beállítása egyes diákhoz**

Különböző diák különböző átmeneti időtartamokat használhatnak. Például egy címdia rövid átmenettel, egy szekcióbevezető dia pedig hosszabb átmenettel rendelkezhet. Ez a példa 500 ms‑ot állít be az első diára és 1 200 ms‑ot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Az átmenetek összehangolása animált kimenettel**

Amikor egy [animált GIF](/slides/hu/net/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/net/export-to-html5/) vagy [videó](/slides/hu/net/convert-powerpoint-to-video/) elkészítésén dolgozik, állítson be pontos átmeneti időtartamokat exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms‑os fade‑ot a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön, hogy legyen idő a narrációnak vagy a tartalomnak.

GIF‑ és videó‑kimenetnél szinkronizálja a képkockasebességet a hatás időtartamával: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze a kiválasztott export formátum által támogatott hatásokat és időzítési lehetőségeket, és tekintse meg előzetesen a kimenetet a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam beolvasása**

Olvassa ki a [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) értékét a módosítás előtt, hogy megállapítsa, van‑e kifejezett érték tárolva. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; egy nem negatív érték a tárolt időtartamot adja meg ezredmásodpercben. A be nem állított érték nem a számított lejátszási idő, mivel az Aspose.Slides a átmenet típusát és a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) értékét használja a hossz meghatározásához. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok közötti változásokat egymást követő diákon. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át az objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Így az átmenet a megfelelő objektumokat animálja az eredeti és a módosított állapot között.

Az alábbi példa egy szöveges téglalapos diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a téglalap helyét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) felsorolásból a második diára a Morph‑t választja. Nyissa meg a mentett fájlt egy Morph‑ot támogató bemutató‑megjelenítőben, hogy a diavetítés során lássa a hatást.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) felsorlat szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) minden alakzatot teljes objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak szerinti egyeztetéssel animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek szerinti egyeztetéssel animálja, ahol lehetséges.

Állítsa be a [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) átmenetet Morph‑ra, mielőtt elérné a [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)‑t. A visszakapott érték a [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) interfészt adja, amelynek a [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) tulajdonsága választja ki a párosítási módot.

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

<!-- visual-explanation:slide-transition:start -->
[![A Morph egyező egységek megjelenítése egész alakzatként, egyes szavakként és egyes karakterekként.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph képes egyező egész alakzatokat, szavakat vagy karaktereket kezelni, ahol lehetséges. Ezek a dobozok az egyező egységeket jelölik a megfigyelt mozgás helyett. A példa a második dián a ByWord lehetőséget választja.*
<!-- visual-explanation:slide-transition:end -->

## **Átmeneti effektusok beállítása**

Néhány átmenet további beállítási lehetőségeket fed fel, például irányt vagy azt, hogy a hatás fekete képernyőről indul‑e. A rendelkezésre álló opciók a kiválasztott átmenet [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/)‑től függenek. Először állítsa be a típust, majd használja a megfelelő interfészt a [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)-ból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) beállítást az [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/)‑on keresztül adja meg, így az átmenet fekete képernyőről indul.

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

**Mégvezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/)‑t, ha pontos hatásidőre van szüksége ezredmásodpercben. Használja a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)‑t, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva. Ezek a beállítások az átmeneti hatást szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok hangot egy átmenethez, és ismételhetem?**

Igen. Rendeljen beágyazott hangot a [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/)-hoz, állítsa a [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/)-t StartSound‑ra a [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) felsorolásból, és engedélyezze a [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/)-ot. A hang a következő hangeseményig a diavetítésben ismétlődik.

**Mi a leggyorsabb módja ugyanazon átmenet alkalmazásának minden diára?**

Iteráljon végig a bemutató [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) gyűjteményén, és állítsa minden dia [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) tulajdonságát ugyanarra az értékre. Állítson be minden időzítési és effektus‑opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, melyik átmenet van jelenleg beállítva egy dián?**

Olvassa ki a [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) tulajdonságot a dia [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/)‑ból. Ez egy [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) felsorolás értékét adja vissza; a None azt jelenti, hogy nincs átmeneti hatás alkalmazva.