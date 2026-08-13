---
title: PowerPoint prezentációk bővítése animációkkal Androidon
linktitle: PowerPoint animáció
type: docs
weight: 150
url: /hu/androidjava/powerpoint-animation/
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
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android via Java képességeit a PowerPoint animációk kezelésében. Ez az általános áttekintés kiemeli a főbb funkciókat."
---
## **Bevezetés**

Mivel a prezentációk célja, hogy valamit bemutassanak, a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a létrehozásuk során.

**PowerPoint animáció** fontos szerepet játszik abban, hogy a bemutató szemrevaló és vonzó legyen a nézők számára. Az Aspose.Slides for Android via Java széles körű lehetőséget kínál a PowerPoint prezentációhoz animáció hozzáadására:

- különféle típusú PowerPoint animációs hatás alkalmazása alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb prezentációs elemekre.
- több PowerPoint animációs hatás használata egy alakzaton.
- animációs idővonal használata az animációs hatások vezérlésére.
- egyedi animáció létrehozása.

Az Aspose.Slides for Android via Java-ban különféle animációs hatásokat lehet alkalmazni az alakzatokra. Mivel a dia minden eleme, beleértve a szöveget, képeket, OLE objektumot, táblázatot stb., alakzatnak tekinthető, ezért animációs hatást minden dián lévő elemre alkalmazhatunk.

## **Animációs hatások**
Az Aspose.Slides **150+ animációs hatást** támogat, többek között alapvető animációs hatásokat, mint a Bounce, PathFootball, Zoom, valamint specifikus animációs hatásokat, mint az OLEObjectShow, OLEObjectOpen. A teljes animációs hatások listáját a [**EffectType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttype/) felsorolásában találhatja.

Ezen animációs hatások ezen kiegészítőkkel kombinálhatók:

- [ColorEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SetEffect)

## **Egyedi animáció**
Lehetőség van saját **egyedi animációk** létrehozására az Aspose.Slides-ben. 
Ez akkor érhető el, ha több viselkedést kombinálunk egy új egyedi animációvá.

[**Behavior**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Behavior) egy PowerPoint animációs hatás építőköve. Minden animációs hatás valójában egy viselkedéssorozat, amely egy stratégiába van összerakva. Egy viselkedéssorozatot egyedi animációba kombinálhat, és újra felhasználhat más prezentációkban. Ha egy új viselkedést adunk egy szabványos PowerPoint animációs hatáshoz – az egy újabb egyedi animáció lesz. Például hozzáadhat ismétlődő viselkedést egy animációhoz, hogy az néhányszor megismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Point) egy pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**
[**Sequence**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Sequence) egy animációs hatások gyűjteménye, amely egy konkrét alakzatra van alkalmazva.

[**Timeline**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AnimationTimeLine) egy Sequence-ök halmaza, amely egy konkrét dián használható. Ez az animációs motor, amely a PowerPoint 2002 óta elérhető. A korábbi PowerPoint verziókban nehéz volt animációs hatásokat hozzáadni a prezentációhoz, ezt csak különböző megoldásokkal lehetett elérni. A Timeline a régi AnimationSettings osztályt helyettesíti, és tisztább objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonal lehet.

## **Interaktív animáció**
[**Trigger**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectTriggerType) lehetővé teszi felhasználói műveletek (például gombnyomás) meghatározását, amelyek elindítják egy adott animációt. A triggerek csak a legújabb PowerPoint verzióban lettek bevezetve.

## **Alakzat animáció**
Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalap, vonal, keret, OLE objektum stb.

{{% alert color="info" %}} 
További információ [**Alakzat animációról**](/slides/hu/androidjava/shape-animation/).
{{% /alert %}}

## **Animált diagramok**
Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Ugyanakkor csak a diagram kategóriákra vagy a diagram sorozatokra lehet PowerPoint animációt alkalmazni. Animációs hatást alkalmazhat egy kategóriaelemre vagy sorozat elemre is.

{{% alert color="info" %}} 
További információ [**Animált diagramokról**](/slides/hu/androidjava/animated-charts/).
{{% /alert %}}

## **Animált szöveg**
Az animált szöveg mellett lehetőség van animáció alkalmazására bekezdésre is.

{{% alert color="info" %}} 
További információ [**Animált szövegről**](/slides/hu/androidjava/animated-text/).
{{% /alert %}}

## **GYIK**

### Megmaradnak az animációk PDF-be exportáláskor?
Nem. A PDF egy statikus formátum, ezért az animációk és a [diaátmenetek](/slides/hu/androidjava/slide-transition/) nem játszódnak le. Ha mozgásra van szüksége, exportáljon [HTML5](/slides/hu/androidjava/export-to-html5/), [animált GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/) vagy [video](/slides/hu/androidjava/convert-powerpoint-to-video/) formátumba.

### Átalakíthatom az animált prezentációt videóvá, és szabályozhatom a képkockasebességet és a képkockaméretet?
Igen. A prezentációt [renderelni a prezentációt képkockákként](/slides/hu/androidjava/convert-powerpoint-to-video/) és videóba kódolni (pl. ffmpeg segítségével) lehet, a FPS és a felbontás kiválasztásával. Az animációk és diaátmenetek a renderelés során lejátszásra kerülnek.

### Megmaradnak az animációk ODP-vel való munka során (nem csak PPTX esetén)?
A PPT, PPTX és ODP támogatott a [olvasás](/slides/hu/androidjava/open-presentation/) és a [írás](/slides/hu/androidjava/save-presentation/) műveletekhez, de a formátumkülönbségek miatt egyes hatások kissé eltérőnek vagy viselkedésűnek tűnhetnek. A kritikus eseteket valós mintákkal ellenőrizze.