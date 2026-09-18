---
title: PowerPoint bemutatók fejlesztése animációkkal PHP-ben
linktitle: PowerPoint animáció
type: docs
weight: 150
url: /hu/php-java/powerpoint-animation/
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
- alakzat animáció
- animált diagram
- animált szöveg
- animált alakzat
- animált OLE objektum
- animált kép
- animált táblázat
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for PHP via Java képességeit a PowerPoint animációk kezelésében. Kulcsfontosságú funkciók és betekintések a bemutatók fejlesztéséhez."
---
## **Bevezetés**

Mivel a bemutatók célja, hogy valamit bemutassanak, a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a létrehozás során.

**PowerPoint animáció** fontos szerepet játszik abban, hogy egy bemutató figyelemfelkeltő és lebilincselő legyen a nézők számára. Az Aspose.Slides for PHP via Java számos lehetőséget kínál a PowerPoint bemutatók animációinak hozzáadásához:

- Alkalmazzon különféle típusú PowerPoint animációs hatásokat alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- Használjon több PowerPoint animációs hatást egyetlen alakzaton.
- Használja az animáció idővonalát az animációs hatások vezérléséhez.
- Készítsen egyéni animációkat.

Az Aspose.Slides for PHP via Java-ban különféle animációs hatásokat lehet alkalmazni alakzatokra. Mivel egy dián minden elem, beleértve a szöveget, képeket, OLE objektumokat és táblázatokat, alakzatnak tekinthető, az animációs hatások bármely diára lévő elemre alkalmazhatók.

## **Animációs hatások**

Aspose.Slides támogat **150+ animációs hatást**, beleértve az alapvető hatásokat, mint a Bounce, a PathFootball és a Zoom, valamint specifikus hatásokat, mint az OLEObjectShow és az OLEObjectOpen. A teljes felsorolást megtalálja a [EffectType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttype/) osztályban.

Emellett ezeket az animációs hatásokat a következő viselkedésekkel kombinálva is használhatja:

- [ColorEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SetEffect)

## **Egyéni animáció**

A viselkedések és szerkeszthető mozgásútvonalak létrehozásával, ellenőrzésével és módosításával kapcsolatos teljes PHP példákért tekintse meg a [Custom Animation](/slides/hu/php-java/custom-animation/) oldalt.

Lehetséges saját **egyéni animációkat** létrehozni az Aspose.Slides-ban. Ez több viselkedés kombinálásával egy új egyéni animációban érhető el.

[Behavior](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behavior/) a PowerPoint animációs hatás építőeleme. Kombinálja a viselkedéseket egy hatás testreszabásához, vagy adjon hozzá egy viselkedést egy előre definiált hatás kibővítéséhez. A ismétlődést az időzítési beállításokkal konfigurálják, nem különálló ismétlés‑viselkedéssel.

[Animation Point](https://reference.aspose.com/slides/hu/php-java/aspose.slides/point/) egy pont, ahol egy viselkedést kell alkalmazni.

## **Animációs idővonal**

[Sequence](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/) animációs hatások gyűjteménye, amely különböző alakzatokat célozhat meg.

[Timeline](https://reference.aspose.com/slides/hu/php-java/aspose.slides/animationtimeline/) egy sorozat, amelyet egy adott dián használnak. Ez egy animációs motor, amelyet a PowerPoint 2002-ben vezettek be. A korábbi PowerPoint verziókban az animációs hatások hozzáadása a bemutatókhoz nehézkes volt, és különféle megoldásokra volt szükség. Az idővonal egy világosabb objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonal lehet.

## **Interaktív animáció**

[Trigger](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttriggertype/) lehetővé teszi felhasználói műveletek, például egy gombkattintás meghatározását, amelyek egy adott animációt indítanak.

## **Alakzat animáció**

Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek közé tartozhat a szöveg, téglalapok, vonalak, keretek, OLE objektumok és egyéb elemek.

{{% alert color="info" title="Note" %}}
További információ [**Az alakzat animációjáról**](/slides/hu/php-java/shape-animation/).
{{% /alert %}}

## **Animált diagramok**

Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatok esetén. A PowerPoint animációk azonban csak diagramkategóriákra vagy diagramsorozatokra alkalmazhatók. Animációs hatásokat alkalmazhat egy kategóriaelemen vagy egy sorozatelemen is.

{{% alert color="info" title="Note" %}}
További információ [**Az animált diagramokról**](/slides/hu/php-java/animated-charts/).
{{% /alert %}}

## **Animált szöveg**

A szöveg animálása mellett animációt alkalmazhat egy bekezdésre is.

{{% alert color="info" title="Note" %}}
További információ [**Az animált szövegről**](/slides/hu/php-java/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF exportálásakor?**

Nem. A PDF egy statikus formátum, így az animációk és a [slide transitions](/slides/hu/php-java/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/php-java/export-to-html5/), [animated GIF](/slides/hu/php-java/convert-powerpoint-to-animated-gif/) vagy [video](/slides/hu/php-java/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom az animált bemutatót videóvá, és szabályozhatom a képkockasebességet és a képkockaméretet?**

Igen. A [render the presentation as frames](/slides/hu/php-java/convert-powerpoint-to-video/) segítségével a bemutatót képkockákra bontva kódolhatja videóvá (pl. ffmpeg használatával), megadva a FPS-t és a felbontást. Az animációk és a diaátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk ODP-vel történő munkavégzés során (nem csak PPTX esetén)?**

A PPT, PPTX és ODP támogatott [reading](/slides/hu/php-java/open-presentation/) és [writing](/slides/hu/php-java/save-presentation/) céljára, de ez nem garantálja az animációk megőrzését. Az egyéni animációs adatok elveszhetnek ODP-re konvertáláskor. Tekintse meg a [Custom Animation](/slides/hu/php-java/custom-animation/) oldalt példákért és útmutatásért a formátum kompatibilitás ellenőrzéséhez.