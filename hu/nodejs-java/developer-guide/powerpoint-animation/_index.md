---
title: Fejlessze a PowerPoint bemutatókat animációkkal JavaScriptben
linktitle: PowerPoint animáció
type: docs
weight: 150
url: /hu/nodejs-java/powerpoint-animation/
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
- egyedi animáció
- alakzat animáció
- animált diagram
- animált szöveg
- animált alakzat
- animált OLE objektum
- animált kép
- animált táblázat
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Használja az Aspose.Slides for Node.js via Java könyvtárat PowerPoint animációk kezelésére. Ez az áttekintés kiemeli a kulcsfontosságú funkciókat és betekintést nyújt a bemutatók fejlesztéséhez."
---
## **Bevezetés**

Mivel a bemutatók célja valami bemutatása, a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a létrehozás során.

**PowerPoint animáció** fontos szerepet játszik abban, hogy egy bemutató szemmel ragadó és a nézők számára vonzó legyen. Az Aspose.Slides for Node.js via Java számos lehetőséget kínál PowerPoint bemutatók animációinak hozzáadására:

- Alkalmazzon különféle PowerPoint animációs effektusokat alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- Hozzon létre több PowerPoint animációs effektust egyetlen alakzaton.
- Használja az animáció idővonalát az animációs effektusok vezérlésére.
- Készítsen egyedi animációkat.

Az Aspose.Slides for Node.js via Java-ban különféle animációs effektusok alkalmazhatók alakzatokra. Mivel a dián minden elem – beleértve a szöveget, képeket, OLE objektumokat és táblázatokat – alakzatnak tekinthető, az animációs effektusok bármely dián lévő elemre alkalmazhatók.

## **Animációs effektusok**
Az Aspose.Slides **150+ animációs effektust** támogat, beleértve az alapvető effektusokat, mint a Bounce, PathFootball és a Zoom, valamint specifikus effektusokat, mint az OLEObjectShow és OLEObjectOpen. A teljes felsorolást megtalálja az [EffectType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttype/) felsorolásban.

Ezen animációs effektusok a következő viselkedésekkel kombinálhatók:
- [ColorEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SetEffect)

## **Egyedi animáció**
A viselkedéseket és szerkeszthető mozgáspályákat létrehozó, ellenőrző és módosító teljes JavaScript példákért tekintse meg a [Egyedi animáció](/slides/hu/nodejs-java/custom-animation/) oldalt.

Lehetőség van saját **egyedi animációk** létrehozására az Aspose.Slides-ban. Ezt több viselkedés kombinálásával egy új egyedi animációba lehet elérni.

[Behavior](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behavior/) egy PowerPoint animációs hatás építőköve. Kombináljon viselkedéseket az effektus testreszabásához, vagy adjon hozzá egy viselkedést egy előre definiált hatás kibővítéséhez. Az ismétlés az időzítési beállításokon keresztül történik, nem külön ismétlő viselkedésként.

[Animation Point](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/point/) egy pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**
[Sequence](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/) egy animációs effektusok gyűjteménye, amely különböző alakzatokra célozhat.

[Timeline](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/animationtimeline/) egy adott dián használt animációs sorozatok halmaza. Ez egy animációs motor, amelyet a PowerPoint 2002 bevezetett. A korábbi PowerPoint verziókban az animációs effektusok hozzáadása a bemutatókhoz nehézségekbe ütközött, és csak különféle megoldásokkal volt lehetséges. Az idővonal tisztább objektummodellt biztosít a PowerPoint animációk számára. Egy dián csak egy animációs idővonal lehet.

## **Interaktív animáció**
[Trigger](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/) lehetővé teszi felhasználói műveletek, például egy gombnyomás meghatározását, amely elindít egy adott animációt.

## **Alakzat animáció**
Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek tartalmazhatnak szöveget, téglalapokat, vonalakat, kereteket, OLE objektumokat és egyebeket.

{{% alert color="info" title="Note" %}}
További információ [**Alakzat animációról**](/slides/hu/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animált diagramok**
Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. A PowerPoint animációk azonban csak diagramkategóriákra vagy diagram sorozatokra alkalmazhatók. Animációs effektusokat kategóriaelemre vagy sorozatelemre is fel lehet használni.

{{% alert color="info" title="Note" %}}
További információ [**Animált diagramokról**](/slides/hu/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animált szöveg**
A szöveg animálása mellett animációt alkalmazhat bekezdésre is.

{{% alert color="info" title="Note" %}}
További információ [**Animált szövegről**](/slides/hu/nodejs-java/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak az animációk PDF-re exportáláskor?**

Nem. A PDF egy statikus formátum, ezért az animációk és a [diaváltások](/slides/hu/nodejs-java/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/nodejs-java/export-to-html5/), [animált GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/nodejs-java/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és szabályozhatom a képkockasebességet és a képkocka méretét?**

Igen. A [bemutató renderelésével képkockákká](/slides/hu/nodejs-java/convert-powerpoint-to-video/) és videóvá (például ffmpeg segítségével) kódolhatja, a FPS-t és a felbontást kiválasztva. Az animációk és a diaváltások a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk ODP-vel való munka során (nem csak PPTX esetén)?**

A PPT, PPTX és ODP támogatott a [olvasás](/slides/hu/nodejs-java/open-presentation/) és a [írás](/slides/hu/nodejs-java/save-presentation/) esetén, de ez nem garantálja az animációk megőrzését. Egyedi animációs adatok elveszhetnek ODP-re konvertáláskor. Tekintse meg a [Custom Animation](/slides/hu/nodejs-java/custom-animation/) oldalt példákért és útmutatásért a formátum kompatibilitás ellenőrzéséhez.