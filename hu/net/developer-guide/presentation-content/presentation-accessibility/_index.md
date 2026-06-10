---
title: Presentációk akadálymentességének kezelése .NET-ben
linktitle: Prezentáció akadálymentesség
type: docs
weight: 30
url: /hu/net/presentation-accessibility/
keywords:
- prezentáció akadálymentesség
- jelölés dekoratívként
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Automatizálja a prezentációk akadálymentességi ellenőrzését PPT, PPTX és ODP fájlokban az Aspose.Slides for .NET segítségével—javítsa a képernyőolvasó élményt és növelje a megfelelőséget."
---
## **Introduction**

A prezentációk akadálymentessége biztosítja, hogy a segédeszközöket, például képernyőolvasókat, braille kijelzőket vagy csak billentyűzettel történő navigációt használók megértsék és könnyedén végigmenjenek a diáidon, ugyanúgy, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a világos olvasási sorrendre, az informatív képek értelmes alternatív szövegére, a megfelelő színkontrasztra, az olvasható tipográfiára, a leíró hivatkozás szövegre, valamint arra összpontosít, hogy ne közvetítsen jelentést kizárólag szín vagy elhelyezés alapján. Ha az akadálymentességet már a kezdetektől tervezik, az eredmény egy tisztább struktúra, konzisztensabb vizuális elemek, és minden nézőhöz eljuttatott tartalom, kerülve a megkerüléseket.

## **Dekorációként jelölés**

A Mark as decorative jelző tisztán díszítő elemeket jelöl, így a képernyőolvasók kihagyják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazd háttérképekre, díszítőelemekre és kitöltőkre – soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides lehetővé teszi e jelző felderítését és validálását, támogatva az automatikus akadálymentességi ellenőrzéseket és tisztítási folyamatokat.

![Mark as Decorative](mark_as_decorative.png)

Az alábbi kódminta bemutatja, hogyan lehet meghatározni, hogy egy alakzat Mark as decorative jelzővel van‑e ellátva.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```