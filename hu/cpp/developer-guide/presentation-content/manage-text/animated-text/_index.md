---
title: PowerPoint szöveg animálása C++-ban
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/cpp/animated-text/
keywords:
- animált szöveg
- szöveganimáció
- animált bekezdés
- bekezdés animáció
- animációs hatás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dinamikus animált szöveget hozhat létre PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával, könnyen követhető, optimalizált C++ kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet animált szöveggel dolgozni az Aspose.Slides‑ben, animációs hatásokat alkalmazva egyes bekezdésekre, illetve hogyan lehet lekérni a szövegkeret bekezdéseihez már hozzáadott hatásokat. A fókusz azokra az API‑metódusokra irányul, amelyekkel bekezdés‑szintű animációt adhatunk hozzá, illetve meglévő bekezdés‑animációkat vizsgálhatunk meg egy bemutatóban.

## **Animációs hatások hozzáadása bekezdésekhez**

Hozzáadtuk a [**AddEffect()**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) metódust a [**Sequence**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.sequence) és a [**ISequence**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.i_sequence) osztályokhoz. Ez a metódus lehetővé teszi egyetlen bekezdéshez animációs hatás hozzáadását. Az alábbi minta kód megmutatja, hogyan adhatunk animációs hatást egy bekezdéshez:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// válassza ki a bekezdést a hatás hozzáadásához
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// adjon Fly animációs hatást a kiválasztott bekezdéshez
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Animációs hatások lekérése bekezdésekhez**

Előfordulhat, hogy meg szeretné tudni, milyen animációs hatások vannak egy bekezdéshez rendelve – például egy helyzetben a bekezdés animációit szeretné átvinni egy másik bekezdésre vagy alakzatra.

Az Aspose.Slides for C++ lehetővé teszi, hogy lekérje az összes, egy szövegkeret (alakzat) által tartalmazott bekezdéshez alkalmazott animációs hatást. Az alábbi minta kód megmutatja, hogyan kaphatja meg egy bekezdés animációs hatásait:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **GYIK**

**Miben különbözik a szöveganimáció a diaátmenetekhez képest, és kombinálhatóak-e?**

A szöveganimációk a objektum viselkedését szabályozzák időben egy dián, míg a [transitions](/slides/hu/cpp/slide-transition/) azt irányítják, hogyan változnak a diák. Különállóak és együtt is használhatók; a lejátszási sorrendet az animáció idővonal és a átmenet beállításai határozzák meg.

**Megmaradnak a szöveganimációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, így csak a dia egyetlen állapotát láthatja mozgás nélkül. A mozgás megőrzéséhez használja a [video](/slides/hu/cpp/convert-powerpoint-to-video/) vagy a [HTML](/slides/hu/cpp/export-to-html5/) exportot.

**Működnek a szöveganimációk elrendezésekben és a diamesterben?**

Az elrendezés/mester objektumokra alkalmazott hatások öröklődnek a diákra, de azok időzítése és a dia‑szintű animációkkal való kölcsönhatása a végső dián lévő animációs sorozattól függ.