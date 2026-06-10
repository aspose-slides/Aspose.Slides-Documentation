---
title: PowerPoint szöveg animálása .NET-ben
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/net/animated-text/
keywords:
- animált szöveg
- szöveganimáció
- animált bekezdés
- bekezdés animáció
- animációs effektus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Dinamikus animált szöveget hozhat létre PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával, könnyen követhető, optimalizált C# kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat animált szöveggel az Aspose.Slides-ben animációs effektusok alkalmazásával egyedi bekezdésekre, valamint hogyan kérdezheti le a már hozzárendelt effektusokat a szövegkeret bekezdéseiben. Az API metódusokra összpontosít, amelyek bekezdés szintű animáció hozzáadását és a meglévő bekezdés animációs effektusok ellenőrzését teszik lehetővé egy prezentációban.

## **Animációs effektusok hozzáadása bekezdésekhez**

Hozzáadtuk az **AddEffect()** metódust a **Sequence** és **ISequence** osztályokhoz. Ez a metódus lehetővé teszi animációs effektus hozzáadását egyetlen bekezdéshez. Az alábbi példa kód bemutatja, hogyan adhatunk animációs effektust egy bekezdéshez:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // válassza ki a bekezdést a hatás hozzáadásához
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // adjon Fly animációs effektust a kiválasztott bekezdéshez
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Animációs effektusok lekérdezése bekezdésekhez**

Előfordulhat, hogy meg szeretné tudni, milyen animációs effektusok vannak egy bekezdéshez hozzáadva – például egy esetben a bekezdés animációs effektusait szeretné lekérdezni, mert ezeket más bekezdésre vagy alakzatra szeretné alkalmazni.

Az Aspose.Slides for .NET lehetővé teszi, hogy lekérje az összes, egy szövegkeret (alakzat) bekezdéseire alkalmazott animációs effektust. Az alábbi példakód bemutatja, hogyan kérdezheti le egy bekezdés animációs effektusait:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Miben különbözik a szöveganimáció a diaátmenetetől, és kombinálhatóak-e?**

A szöveganimációk szabályozzák az objektum viselkedését egy dián az idő múlásával, míg az [átmenetek](/slides/hu/net/slide-transition/) szabályozzák, hogyan változnak a diák. Függetlenek egymástól, és együtt is használhatók; a lejátszási sorrendet az animáció idővonal és az átmenet beállításai határozzák meg.

**Megmaradnak-e a szöveganimációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, így a diát mozgás nélkül, egyetlen állapotban fogja látni. A mozgás megőrzéséhez használja a [videó](/slides/hu/net/convert-powerpoint-to-video/) vagy a [HTML](/slides/hu/net/export-to-html5/) exportot.

**Működnek-e a szöveganimációk elrendezésekben és a dia masterben?**

A layout/master objektumokra alkalmazott effektusok öröklődnek a diákra, azonban azok időzítése és az diaszintű animációkkal való kölcsönhatása a dián lévő végső sorozattól függ.