---
title: JavaScript-ben PowerPoint bemutatók animálása
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Használja az Aspose.Slides for Node.js via Java könyvtárat a PowerPoint animációk kezeléséhez. Ez az áttekintés kiemeli a főbb funkciókat és gyakorlati tippeket nyújt a bemutatók fejlesztéséhez."
---
## **Bevezetés**

Mivel a bemutatók célja valami bemutatása, vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a készítésük során.

**PowerPoint animáció** fontos szerepet játszik annak érdekében, hogy a bemutató figyelemfelkeltő és vonzó legyen a nézők számára. Az Aspose.Slides for Node.js via Java számos lehetőséget kínál a PowerPoint bemutató animációjának hozzáadására:

- különféle PowerPoint animációs hatások alkalmazása alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- több PowerPoint animációs hatás használata egy alakzaton.
- animációs idővonal használata az animációs hatások vezérléséhez.
- egyéni animációk létrehozása.

Az Aspose.Slides for Node.js via Java‑ben különféle animációs hatásokat lehet alkalmazni az alakzatokra. Mivel a dián lévő minden elem, beleértve a szöveget, képeket, OLE objektumot, táblázatot stb., alakzatként van kezelve, ez azt jelenti, hogy animációs hatást alkalmazhatunk a dia minden elemére.

## **Animációs hatások**
Az Aspose.Slides **150+ animációs hatást** támogat, köztük alapvető hatásokat, mint a Bounce, PathFootball, Zoom, valamint specifikus hatásokat, például OLEObjectShow, OLEObjectOpen. A teljes animációs hatáslistát megtalálja a [**EffectType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttype/) felsorolásban.

Ezen felül ezek a animációs hatások kombinálhatók is:
- [ColorEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SetEffect)

## **Egyéni animáció**
Lehetőség van saját **egyéni animációk** létrehozására az Aspose.Slides‑ben. Ez akkor érhető el, ha több viselkedést egyesít egy új egyéni animációba.

[**Behavior**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Behavior) bármely PowerPoint animációs hatás építőeleme. Az összes animációs hatás valójában egy viselkedéscsoport, amely egy stratégiába van összeállítva. Egy viselkedést egyszer egyéni animációba kombinálhat, majd újra felhasználhat más bemutatókban. Ha új viselkedést ad egy szabványos PowerPoint animációs hatáshoz, az egy újabb egyéni animáció lesz. Például hozzáadhat ismétlési viselkedést egy animációhoz, hogy az többször ismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Point) az a pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**
[**Sequence**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Sequence) egy animációs hatások gyűjteménye, amely egy konkrét alakzatra van alkalmazva.

[**Timeline**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AnimationTimeLine) egy sorozat gyűjteménye, amely egy adott dián használatos. Ez egy animációs motor, amely a PowerPoint 2002‑től elérhető. A korábbi PowerPoint verziókban nehéz volt animációs hatásokat hozzáadni a bemutatóhoz, amely csak különféle megoldásokkal volt kivitelezhető. Az idővonal a régi AnimationSettings osztályt helyettesíti, és egy tisztább objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonala lehet.

## **Interaktív animáció**
[**Trigger**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/EffectTriggerType) lehetővé teszi felhasználói műveletek (pl. gombkattintás) definiálását, amelyek elindítják a megfelelő animációt. A triggerek csak a legújabb PowerPoint verzióban kerültek bevezetésre.

## **Alakzat animáció**
Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek valójában szöveg, téglalap, vonal, keret, OLE objektum stb. lehetnek.

{{% alert color="primary" %}} 
Olvassa tovább [**Alakzat animációról**](/slides/hu/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animált diagramok**
Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animáció csak diagramkategóriákra vagy diagramsorozatokra alkalmazható. Animációs hatást alkalmazhat egy kategóriaelemre vagy sorozatelemre is.

{{% alert color="primary" %}} 
Olvassa tovább [**Animált diagramokról**](/slides/hu/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animált szöveg**
Az animált szövegen kívül páragrafról is lehet animációt alkalmazni.

{{% alert color="primary" %}} 
Olvassa tovább [**Animált szövegről**](/slides/hu/nodejs-java/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF‑formátumba exportáláskor?**

Nem. A PDF statikus formátum, így az animációk és a [diaátmenetek](/slides/hu/nodejs-java/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/nodejs-java/export-to-html5/), [animált GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/nodejs-java/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és szabályozhatom a képkockasebességet és a képméretet?**

Igen. A [bemutató képkockákként való renderelésével](/slides/hu/nodejs-java/convert-powerpoint-to-video/) le tudja kódolni videóvá (például ffmpeg‑kel), a FPS‑et és a felbontást kiválasztva. Az animációk és a diaátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk az ODP‑vel (nem csak PPTX) való munkavégzés során?**

A PPT, PPTX és ODP támogatott a [beolvasáshoz](/slides/hu/nodejs-java/open-presentation/) és a [íráshoz](/slides/hu/nodejs-java/save-presentation/), de a formátumkülönbségek miatt egyes hatások kissé másként jelenhetnek meg vagy viselkedhetnek. Kritikus eseteket valós mintákkal ellenőrizze.