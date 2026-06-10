---
title: PowerPoint prezentációk fejlesztése animációkkal Androidon
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
- animációs effektus
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
description: "Ismerje meg az Aspose.Slides for Android via Java képességeit a PowerPoint animációk kezelésében. Ez az általános áttekintés kiemeli a főbb funkciókat."
---
## **Bevezetés**

Mivel az előadások célja valamit bemutatni, a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a létrehozásuk során.

**PowerPoint animáció** fontos szerepet játszik, hogy az előadás figyelemfelkeltő és vonzó legyen a nézők számára. Az Aspose.Slides for Android via Java széles körű lehetőségeket kínál a PowerPoint előadáshoz való animáció hozzáadására:

- különféle típusú PowerPoint animációs effektusok alkalmazása alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb előadáselemekre.
- több PowerPoint animációs effektus használata egy alakzaton.
- animációs idővonal használata az animációs effektusok vezérléséhez.
- egyedi animáció létrehozása.

Az Aspose.Slides for Android via Java-ban különféle animációs effektusok alkalmazhatók az alakzatokra. Mivel a dia minden eleme, beleértve a szöveget, a képeket, az OLE objektumot, a táblázatot stb., alakzatnak számít, ez azt jelenti, hogy animációs effektust alkalmazhatunk a dia minden elemére.

## **Animációs effektusok**
Az Aspose.Slides **150+ animációs effektust** támogat, beleértve az alapvető animációs effektusokat, mint a Bounce, a PathFootball, a Zoom effektus, valamint a specifikus animációs effektusokat, mint az OLEObjectShow, OLEObjectOpen. A teljes animációs effektuslista megtalálható a [**EffectType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttype/) felsorolásában.

Ezen animációs effektusok ezen felül kombinálhatók is a következőkkel:
- [ColorEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SetEffect)

## **Egyedi animáció**
Lehetséges saját **egyedi animációk** létrehozni az Aspose.Slides-ban. 
Ez akkor érhető el, ha több viselkedést kombinálunk egy új egyedi animációba.

[**Behavior**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Behavior) egy építőeleme bármely PowerPoint animációs effektusnak. Az összes animációs effektus valójában egy viselkedéssorozat, amely egy stratégiába van összefűzve. Viselkedéseket egy egyedi animációba kombinálhatunk egyszer, majd újra felhasználhatjuk más előadásokban. Ha új viselkedést adunk hozzá egy szabványos PowerPoint animációs effektushoz – az egy másik egyedi animáció lesz. Például hozzáadhatunk ismétlődő viselkedést egy animációhoz, hogy néhányszor ismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Point) egy pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**
[**Sequence**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Sequence) egy animációs effektusok gyűjteménye, amely egy konkrét alakzatra van alkalmazva.

[**Timeline**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AnimationTimeLine) egy sorozatok (Sequences) halmaza, amely egy konkrét dián használatos. Ez egy animációs motor, amely a PowerPoint 2002-től elérhető. Korábbi PowerPoint verziókban nehéz volt animációs effektusokat hozzáadni az előadáshoz, csak különféle megkerülésekkel. A Timeline felváltja a régi AnimationSettings osztályt, és tisztább objektummodellt biztosít a PowerPoint animációkhoz. Egy diához csak egy animációs idővonal tartozhat.

## **Interaktív animáció**
[**Trigger**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectTriggerType) lehetővé teszi a felhasználói műveletek (pl. gombkattintás) definiálását, amelyek elindítanak egy adott animációt. A triggerek csak a legújabb PowerPoint verzióban kerültek bevezetésre.

## **Alakzat animáció**
Az Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalap, vonal, képkocka, OLE objektum stb.

{{% alert color="primary" %}} 
Olvassa tovább [**Alakzat animációról**](/slides/hu/androidjava/shape-animation/).
{{% /alert %}}

## **Animált diagramok**
Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animáció csak diagramkategóriákra vagy diagramsorozatokra alkalmazható. Animációs effektust alkalmazhatunk egy kategóriaelemre vagy sorozatelemre is.

{{% alert color="primary" %}} 
Olvassa tovább [**Animált diagramokról**](/slides/hu/androidjava/animated-charts/).
{{% /alert %}}

## **Animált szöveg**
Az animált szövegen kívül animációt lehet alkalmazni egy bekezdésre is.

{{% alert color="primary" %}} 
Olvassa tovább [**Animált szövegről**](/slides/hu/androidjava/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak az animációk PDF-be exportáláskor?**

Nem. A PDF statikus formátum, ezért az animációk és a [diaváltás](/slides/hu/androidjava/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/androidjava/export-to-html5/), [animated GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/) vagy [video](/slides/hu/androidjava/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom az animált előadást videóvá, és szabályozhatom a képkockasebességet és a képkockaméretet?**

Igen. A [prezentáció keretként történő renderelésével](/slides/hu/androidjava/convert-powerpoint-to-video/) kódolhatja őket videóvá (pl. ffmpeg segítségével), kiválasztva a FPS-t és a felbontást. Az animációk és a diaváltások a renderelés során lejátszásra kerülnek.

**Megmaradnak az animációk ODP-vel (nem csak PPTX) dolgozva?**

A PPT, PPTX és ODP támogatott a [olvasáshoz](/slides/hu/androidjava/open-presentation/) és a [íráshoz](/slides/hu/androidjava/save-presentation/), de a formátumkülönbségek miatt egyes effektusok kissé eltérőnek tűnhetnek vagy másképp viselkedhetnek. Kritikus eseteket ellenőrizze valós mintákkal.