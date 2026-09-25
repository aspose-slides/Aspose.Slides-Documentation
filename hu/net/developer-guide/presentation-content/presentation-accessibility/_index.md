---
title: .NET-ben a prezentáció akadálymentességének kezelése
linktitle: Prezentáció akadálymentesség
type: docs
weight: 30
url: /hu/net/presentation-accessibility/
keywords:
- prezentáció akadálymentesség
- alternatív szöveg
- alternatív szövegcím
- alternatív szöveg leírás
- díszítőként megjelölés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Automatizálja a prezentációk akadálymentességi ellenőrzését PPT, PPTX és ODP fájlokban az Aspose.Slides for .NET segítségével—javítsa a képernyőolvasó élményt és növelje a megfelelőséget."
---
## **Bevezetés**

Az alternatív szöveg segíti a segítő technológiákat használó személyeket a képek, diagramok és egyéb tájékoztató alakzatok jelentésének megértésében. Ez a cikk bemutatja, hogyan olvashatók és frissíthetők az alternatív szövegcímek és leírások az Aspose.Slides for .NET segítségével, hogyan különböztethetők meg a kódban használt alakzatnevektől az akadálymentességi leírások, és hogyan ellenőrizhető, hogy egy alakzat díszítő‑elem‑e.

Ezek a funkciók támogatják a bemutató akadálymentességét, de nem garantálják azt. Az olvasási sorrend, a színkontraszt, a szöveg olvashatósága és más akadálymentességi követelmények is felülvizsgálatot igényelnek.

## **Alternatív szövegcímek és leírások kezelése**

Használjon alternatív szöveget a képek, diagramok és egyéb tájékoztató alakzatok jelentésének elmagyarázásához azok számára, akik nem láthatják őket. A következő tulajdonságok különböző célokra szolgálnak:

| Tulajdonság vagy tartalom | Cél |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetexttitle/) | Rövid cím az alternatív leíráshoz. |
| [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) | Értelemszerű leírás az alakzat tartalmáról vagy céljáról a dia kontextusában. |
| [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) | Az alakzat neve, amelyet a kód használhat a konkrét alakzat megtalálásához a prezentációban. |
| Látható szöveg | A dián megjelenő tartalom, például egy alakzat szövege vagy egy diagram címe és feliratai. Az alternatív szöveg frissítése nem változtatja meg ezt a tartalmat. |

Amikor egy prezentációt sablonként újrahasználják, a kód a [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) alapján megtalálhat egy alakzatot, mielőtt frissítené azt. Ez a név más célt szolgál, mint az alternatív szöveg, amely azt magyarázza, hogy a vizuális elem mit közvetít a nézőnek. Név alapján keresve a szerzők javíthatják vagy lefordíthatják a leírásokat anélkül, hogy a kód módosítaná az alakzat keresésének módját. A neveket szerkeszthető, és nem garantált, hogy egyediek, ezért ellenőrizni kell, hogy a név a kívánt alakzatra vonatkozik‑e; lásd [Alakzatok azonosítása és keresése](/slides/hu/net/shape-manipulations/#identify-and-find-shapes).

Az alábbi példa egy `input.pptx` fájlt igényel, amelynek első diájának első alakzata egy irodai bejárat képe. A képet nem szabad díszítő‑elem‑ként megjelölni. A példa beolvassa és kiírja a jelenlegi alternatív szövegcímet és leírást, frissíti mindkettőt, majd a prezentációt `output.pptx`‑ként menti. A megfogalmazást a tényleges képhez és a közvetített információhoz igazítsa.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Az alternatív szöveg önmagában nem garantálja a prezentáció akadálymentességét vagy a szabványoknak való megfelelést. Ellenőrizze a leírások pontosságát és relevanciáját, valamint vizsgálja meg az olvasási sorrendet, a színkontrasztot, a olvasható szöveget és más akadálymentességi követelményeket. A tájékoztató vizuális elemeket ne jelölje díszítő‑elem‑ként; a következő rész bemutatja, hogyan olvasható a [IsDecorative](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/isdecorative/).

## **Megjelölés díszítő‑elem‑ként**

A díszítő‑elem‑ként való megjelölés azt a kizárólag dekoratív vizuális elemet jelzi, amelyet a képernyőolvasók kihagynek, így csökken a zaj és a figyelem a lényeges tartalomra összpontosítható. Alkalmazza háttérképekre, díszítőelemekre és elválasztókra – soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felderítéshez és az ellenőrzéshez, lehetővé téve az automatizált akadálymentességi ellenőrzéseket és tisztításokat.

![Mark as Decorative](mark_as_decorative.png)

Az alábbi kódrészlet bemutatja, hogyan határozható meg, hogy egy alakzat díszítő‑elem‑ként van‑e jelölve.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **GYIK**

**Mit kell szerepeltetni az alternatív szövegcímben és leírásban?**

Használjon rövid címet a tárgy azonosításához, és egy leírást, amely elmagyarázza, milyen információt közvetít a vizuális elem a dia kontextusában. Egy diagram esetében írja le a releváns trendet vagy összehasonlítást, ne csak azt a szót, hogy „diagram”.

**Használjam az alternatív szöveget az alakzatok sablonban történő megtalálásához?**

Előnyben részesítse az alakzat megtalálását a [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) alapján, és ellenőrizze, hogy a várt alakzatról van‑e szó. Az alternatív szöveg szerkeszthető vagy lefordítható, ami megtörheti a pontos leírásra épülő kódot; lásd [Alakzatok azonosítása és keresése](/slides/hu/net/shape-manipulations/).

**Mikor kell egy alakzatot díszítő‑elem‑ként jelölni?**

A díszítő jelzőt olyan vizuális elemekhez használja, amelyek nem adnak információt, például dekoratív díszítésekhez. A jelentést közvetítő képeknek és diagramoknak megfelelő leírást kell kapniuk.

**Az alternatív szöveg hozzáadása teljesen akadálymentessé teszi a prezentációt?**

Nem. Az alternatív szöveg csak az akadálymentesség egy részét fedi le. Vizsgálja továbbá az olvasási sorrendet, a színkontrasztot, a szöveg olvashatóságát és más alkalmazandó követelményeket; ezeknek a tulajdonságoknak a beállítása egyedül nem hoz létre megfelelőséget.