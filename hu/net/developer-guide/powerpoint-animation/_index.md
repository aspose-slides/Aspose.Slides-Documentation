---
title: PowerPoint bemutatók fejlesztése animációkkal .NET-ben
linktitle: PowerPoint animáció
type: docs
weight: 150
url: /hu/net/powerpoint-animation/
keywords:
- animáció hozzáadása
- animáció frissítése
- animáció módosítása
- animáció eltávolítása
- animáció kezelése
- animáció vezérlése
- animációs hatás
- PowerPoint animáció
- animációs idővonal
- interaktív animáció
- egyéni animáció
- alakzati animáció
- animált diagram
- animált szöveg
- animált alakzat
- animált OLE objektum
- animált kép
- animált táblázat
- PowerPoint bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for .NET képességeit a PowerPoint animációk kezelésében. Ez az általános áttekintés kiemeli a kulcsfontosságú funkciókat, és olyan betekintést nyújt, amelyek segítenek javítani bemutatóit."
---
## **Bevezetés**

Mivel a bemutatók célja, hogy valamit bemutassanak, a megjelenésük és az interaktív viselkedésük mindig figyelembe van véve a létrehozás során.

**PowerPoint animáció** fontos szerepet játszik abban, hogy egy bemutató figyelemfelkeltő és lebilincselő legyen a nézők számára. Az Aspose.Slides for .NET számos lehetőséget kínál a PowerPoint bemutatók animálásához:

- Különféle PowerPoint animációs hatások alkalmazása alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- Több PowerPoint animációs hatás használata egyetlen alakzaton.
- Az animációs idővonal használata az animációs hatások vezérlésére.
- Egyéni animációk létrehozása.

Az Aspose.Slides for .NET-ben különféle animációs hatásokat lehet alkalmazni alakzatokra. Mivel a dián minden elem, beleértve a szöveget, képeket, OLE objektumokat és táblázatokat, alakzatnak számít, az animációs hatások bármely diabeli elemre alkalmazhatók.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/) névtér osztályokat biztosít a PowerPoint animációkkal való munkához.

## **Animációs hatások**

Az Aspose.Slides **150+ animációs hatást** támogat, beleértve az alapvető hatásokat, mint a Bounce, PathFootball és a Zoom, valamint a speciális hatásokat, mint az OLEObjectShow és az OLEObjectOpen. A teljes animációs hatáslistát a [EffectType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttype) felsorolásban találhatja.

Ezen animációs hatásokat továbbá a következőkkel lehet kombinálni:

- [ColorEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/seteffect)

## **Egyéni animáció**

A viselkedések és szerkeszthető mozgási útvonalak létrehozásával, ellenőrzésével és módosításával foglalkozó teljes C# példákért lásd a [Custom Animation](/slides/hu/net/custom-animation/) oldalt.

Lehetőség van saját **egyéni animációk** létrehozására az Aspose.Slides-ben. Ez több viselkedés egyesítésével egy új egyéni animációban valósítható meg.

[Behavior](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/behavior) egy PowerPoint animációs hatás építőköve. Viselkedéseket kombinálva testre szabhat egy hatást, vagy hozzáadhat egy viselkedést egy előre definiált hatás kibővítéséhez. Az ismétlés időzítési beállításokkal van konfigurálva, nem külön ismétlés viselkedéssel.

[Animation Point](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/point) egy pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**

[Sequence](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/sequence) animációs hatások gyűjteménye, amely különböző alakzatokra célozhat.

[Timeline](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/animationtimeline) egy adott dián használt szekvenciák halmaza. Ez egy animációs motor, amelyet a PowerPoint 2002-ben vezettek be. A korábbi PowerPoint verziókban az animációs hatások hozzáadása a bemutatókhoz kihívást jelentett, és csak különféle megoldásokkal volt lehetséges. Az idővonal helyettesíti a régi AnimationSettings osztályt, és egy átláthatóbb objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonal lehet.

## **Interaktív animáció**

[Trigger](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype) lehetővé teszi felhasználói műveletek (például gombkattintás) definiálását, amelyek egy adott animációt indítanak el. A triggerek a PowerPoint legújabb verziójában lettek bevezetve.

## **Alakzat animáció**

Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalapok, vonalak, keretek, OLE objektumok és egyebek.

{{% alert color="info" title="Note" %}}
További információk [**Alakzat animációja**](/slides/hu/net/shape-animation/).
{{% /alert %}}

## **Animált diagramok**

Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatok esetén. Azonban a PowerPoint animációkat csak diagramkategóriákra vagy diagramsorozatokra lehet alkalmazni. Animációs hatásokat kategoriára vagy sorozatra is alkalmazhat.

{{% alert color="info" title="Note" %}}
További információk [**Animált diagramok**](/slides/hu/net/animated-charts/).
{{% /alert %}}

## **Animált szöveg**

A szöveg animálása mellett animációt alkalmazhat egy bekezdésre is.

{{% alert color="info" title="Note" %}}
További információk [**Animált szöveg**](/slides/hu/net/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF-be exportáláskor?**

Nem. A PDF statikus formátum, így az animációk és a [slide transitions](/slides/hu/net/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/net/export-to-html5/), [animated GIF](/slides/hu/net/convert-powerpoint-to-animated-gif/) vagy [video](/slides/hu/net/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és szabályozhatom a képkockasebességet és a képkockaméretet?**

Igen. A [render the presentation as frames](/slides/hu/net/convert-powerpoint-to-video/) segítségével képkockákká konvertálhatja a bemutatót, majd egy videóba (például ffmpeg segítségével) kódolhatja, kiválasztva a FPS értéket és a felbontást. Az animációk és diákátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk ODP-vel (nem csak PPTX) dolgozva?**

A PPT, PPTX és ODP formátumok támogatottak a [reading](/slides/hu/net/open-presentation/) és a [writing](/slides/hu/net/save-presentation/) műveletekre, de ez nem garantálja az animációk megmaradását. Az egyéni animációs adatok elveszhetnek ODP-re konvertálás során. Lásd a [Custom Animation](/slides/hu/net/custom-animation/) oldalt egy tesztelt példáért és a formátum korlátozásokért.