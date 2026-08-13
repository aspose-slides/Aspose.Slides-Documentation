---
title: PowerPoint előadások fejlesztése animációkkal C++-ban
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
- előadás
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és vezérelhet fejlett animációs hatásokat az Aspose.Slides for C++-ban, hogy dinamikus PowerPoint és OpenDocument előadásokat hozzon létre."
---
## **Bevezetés**

Mivel az előadások célja valaminek a bemutatása, a megjelenésük és interaktív viselkedésük mindig szem előtt van a készítés során.

**PowerPoint animáció** fontos szerepet játszik, hogy az előadás figyelemfelkeltő és vonzó legyen a nézők számára. Az Aspose.Slides for C++ széles választékot kínál a PowerPoint előadáshoz való animációk hozzáadásához:

- alkalmazzon különböző típusú PowerPoint animációs hatásokat alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb előadáselemekre.
- több PowerPoint animációs hatást használjon egy alakzaton.
- animációs idővonalat használjon az animációs hatások vezérléséhez.
- hozzon létre egyedi animációt.

Az Aspose.Slides for C++-ban különféle animációs hatásokat lehet alkalmazni az alakzatokra. Mivel a dia minden eleme, beleértve a szöveget, képeket, OLE objektumot, táblázatot stb., alakzatnak tekinthető, ez azt jelenti, hogy az animációs hatást a dia minden elemére alkalmazhatjuk.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation) **névtér** osztályokat biztosít a PowerPoint animációkkal való munkához.

## **Animációs hatások**

Az Aspose.Slides **150+ animációs hatást** támogat, beleértve az alapvető animációs hatásokat, mint a Bounce, PathFootball, Zoom, valamint a specifikus hatásokat, mint az OLEObjectShow, OLEObjectOpen. A teljes animációs hatások listáját megtalálja a [**EffectType**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)felsorolásban.

Ezen felül ezeket az animációs hatásokat másokkal kombinálva is lehet használni:

- [ColorEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.set_effect)

## **Egyedi animáció**

Lehetőség van saját **egyedi animációk** létrehozására az Aspose.Slides-ban.  
Ez akkor érhető el, ha több viselkedést egyesítünk egy új egyedi animációvá.

[**Behavior**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.behavior) a PowerPoint animációs hatás építőeleme. Az összes animációs hatás valójában egy viselkedéscsoport, amely egy stratégiába van összeállítva. A viselkedéseket egy egyedi animációba kombinálhatja egyszer, majd újra felhasználhatja más előadásokban. Ha új viselkedést ad hozzá egy szabványos PowerPoint animációs hatáshoz – az egy újabb egyedi animáció lesz. Például hozzáadhat ismétlődő viselkedést egy animációhoz, hogy az többször ismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.point) az a pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**

[**Sequence**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.sequence) animációs hatások gyűjteménye, amely egy konkrét alakzatra van alkalmazva.

[**AnimationTimeLine**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.animation_time_line) egy sorozatok halmaza, amely egy konkrét dián használatos. Ez egy animációs motor, amely a PowerPoint 2002 óta elérhető. A korábbi PowerPoint verziókban nehéz volt animációs hatásokat hozzáadni az előadáshoz, és csak különféle megoldásokkal volt lehetséges. Az idővonal a régi AnimationSettings osztályt helyettesíti, és egy tisztább objektummodellt biztosít a PowerPoint animációkhoz. Egy diához csak egy animációs idővonal tartozhat.

## **Interaktív animáció**

[**EffectTriggerType**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) lehetővé teszi a felhasználói események (pl. gombkattintás) meghatározását, amelyek egy adott animációt elindítanak. A triggerek csak a legújabb PowerPoint verzióban kerültek be.

## **Alakzat animáció**

Az Aspose.Slides lehetővé teszi animáció alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalap, vonal, keret, OLE objektum stb.

{{% alert color="info" %}} 
További információ [**A alakzat animációjáról**](/slides/hu/cpp/shape-animation/).
{{% /alert %}}

## **Animált diagramok**

Animált diagramok létrehozásához ugyanazokat a osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animáció csak diagramkategóriákra vagy diagramsorozatokra alkalmazható. Animációs hatást alkalmazhat kategóriaelemekre vagy sorozatelemekre is.

{{% alert color="info" %}} 
További információ [**Az animált diagramokról**](/slides/hu/cpp/animated-charts/).
{{% /alert %}}

## **Animált szöveg**

Az animált szövegen kívül animációt alkalmazhat bekezdésre is.

{{% alert color="info" %}} 
További információ [**Az animált szövegről**](/slides/hu/cpp/animated-text/).
{{% /alert %}}

## **GYIK**

### Megmaradnak-e az animációk PDF exportálásakor?

Nem. A PDF statikus formátum, ezért az animációk és a [diaátmenetek](/slides/hu/cpp/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportálja [HTML5](/slides/hu/cpp/export-to-html5/), [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/cpp/convert-powerpoint-to-video/) formátumba.

### Átalakíthatom-e az animált előadást videóvá, és szabályozhatom a képkockasebességet és a képkockaméretet?

Igen. [Renderelheti az előadást képkockákra](/slides/hu/cpp/convert-powerpoint-to-video/), majd videóba kódolhatja (pl. ffmpeg használatával), kiválasztva a képkockasebességet és a felbontást. Az animációk és diaátmenetek lejátszásra kerülnek a renderelés során.

### Az animációk megmaradnak ODP-vel (nem csak PPTX) dolgozva?

A PPT, PPTX és ODP támogatott a [olvasáshoz](/slides/hu/cpp/open-presentation/) és [íráshoz](/slides/hu/cpp/save-presentation/), de a formátumkülönbségek miatt bizonyos hatások kissé másként nézhetnek ki vagy viselkedhetnek. A kritikus eseteket valós mintákkal ellenőrizze.