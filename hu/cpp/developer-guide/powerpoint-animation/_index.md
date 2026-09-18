---
title: PowerPoint bemutatók fejlesztése animációkkal C++-ban
linktitle: PowerPoint animáció
type: docs
weight: 150
url: /hu/cpp/powerpoint-animation/
keywords:
- animáció hozzáadása
- animáció frissítése
- animáció módosítása
- animáció eltávolítása
- animáció kezelése
- animáció vezérlése
- animációs effektus
- PowerPoint animáció
- animációs idővonal
- interaktív animáció
- egyéni animáció
- alakzatanimáció
- animált diagram
- animált szöveg
- animált alakzat
- animált OLE objektum
- animált kép
- animált táblázat
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és vezérelhet fejlett animációs effektusokat az Aspose.Slides C++ változatában, hogy dinamikus PowerPoint és OpenDocument bemutatókat hozzon létre."
---
## **Bevezetés**

Mivel a bemutatók valamit bemutatni szolgálnak, a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a létrehozás során.

**PowerPoint animáció** fontos szerepet játszik abban, hogy egy bemutató figyelemfelkeltő és vonzó legyen a nézők számára. Az Aspose.Slides széles körű lehetőségeket biztosít a PowerPoint prezentációkhoz animációk hozzáadásához:

- Alkalmazzon különféle PowerPoint animációs effektusokat alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- Használjon több PowerPoint animációs efekttet a egyetlen alakzaton.
- Használja az animáció idővonalát az animációs effektusok vezérléséhez.
- Hozzon létre egyéni animációkat.

Az Aspose.Slides-ben különféle animációs effektusok alkalmazhatók alakzatokra. Mivel a dia minden eleme, beleértve a szöveget, képeket, OLE objektumokat és táblázatokat, alakzatnak számít, az animációs effektusok bármely elemre alkalmazhatók a dián.

Az [Aspose::Slides::Animation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/) névtér osztályokat biztosít a PowerPoint animációkkal való munkához.

## **Animációs hatások**

Az Aspose.Slides **150+ animációs effektust** támogat, beleértve az egyszerű efektusokat, mint a Bounce, PathFootball és a Zoom, valamint a specifikus effektusokat, mint az OLEObjectShow és OLEObjectOpen. A teljes felsorolást megtalálja a [EffectType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttype/) felsorolásban.

Ezen animációs effektusok a következő viselkedésekkel kombinálhatók:
- [ColorEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/seteffect/)

## **Egyéni animáció**

A teljes C++ példa, amely létrehozza, ellenőrzi és módosítja a viselkedéseket és a szerkeszthető mozgási útvonalakat, megtalálható a [Custom Animation](/slides/hu/cpp/custom-animation/) oldalon.

Lehetséges saját **egyéni animációkat** létrehozni az Aspose.Slides-ben. Ezt több viselkedés kombinálásával egy új egyéni animációba lehet elérni.

[Behavior](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/behavior/) a PowerPoint animációs effektus építőköve. Kombinálja a viselkedéseket egy effektus testreszabásához, vagy adjon hozzá egy viselkedést egy előre definiált effektus kibővítéséhez. Az ismétlés az időzítési beállításokkal konfigurálható, nem egy külön ismétlő viselkedéssel.

[Animation Point](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/point/) egy pont, ahol egy viselkedést kell alkalmazni.

## **Animációs idővonal**

[Sequence](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/sequence/) animációs effektusok gyűjteménye, amelyek különböző alakzatokra célozhatók.

[IAnimationTimeLine](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ianimationtimeline/) egy adott dián használt sorozatok halmaza. Ez egy animációs motor, amelyet a PowerPoint 2002-ben vezettek be. A korábbi PowerPoint verziókban az animációs effektusok hozzáadása a prezentációkhoz nehézkes volt, és csak különféle megkerülésekkel volt lehetséges. Az idővonal tisztább objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonal lehet.

## **Interaktív animáció**

[Trigger](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) lehetővé teszi felhasználói műveletek, például gombkattintás meghatározását, amelyek elindítanak egy adott animációt.

## **Alakzat animáció**

Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek tartalmazhatnak szöveget, téglalapokat, vonalakat, kereteket, OLE objektumokat és egyebeket.

{{% alert color="info" title="Note" %}}
Olvassa tovább [**Az alakzatanimációról**](/slides/hu/cpp/shape-animation/).
{{% /alert %}}

## **Animált diagramok**

Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animációk csak diagramkategóriákra vagy diagramsorozatokra alkalmazhatók. Animációs effektusokat alkalmazhat egy kategóriaelemre vagy egy sorozatelemre is.

{{% alert color="info" title="Note" %}}
Olvassa tovább [**Az animált diagramokról**](/slides/hu/cpp/animated-charts/).
{{% /alert %}}

## **Animált szöveg**

A szöveg animálása mellett animációt alkalmazhat bekezdésre is.

{{% alert color="info" title="Note" %}}
Olvassa tovább [**Az animált szövegről**](/slides/hu/cpp/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF-re exportáláskor?**

Nem. A PDF egy statikus formátum, így az animációk és a [diaátmenetek](/slides/hu/cpp/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/cpp/export-to-html5/), [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/cpp/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és vezérelhetem a képkockasebességet és a képkockaméretet?**

Igen. A [bemutató renderelhető képkockáként](/slides/hu/cpp/convert-powerpoint-to-video/) és kódolható videóvá (például ffmpeg‑kel), a FPS és a felbontás kiválasztásával. Az animációk és diaátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk ODP‑vel (nem csak PPTX) dolgozva?**

A PPT, PPTX és ODP támogatott a [olvasáshoz](/slides/hu/cpp/open-presentation/) és a [íráshoz](/slides/hu/cpp/save-presentation/), de ez nem garantálja az animációk megőrzését. Az egyéni animációs adatok elveszhetnek ODP‑re konvertálás közben. Tekintse meg a [Custom Animation](/slides/hu/cpp/custom-animation/) oldalt példákért és útmutatásért a formátumkompatibilitás ellenőrzéséhez.