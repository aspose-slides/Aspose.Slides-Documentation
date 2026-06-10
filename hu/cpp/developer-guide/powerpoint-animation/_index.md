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
- animáció irányítása
- animációs effektus
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
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és irányíthat fejlett animációs effektusokat az Aspose.Slides for C++ segítségével, hogy dinamikus PowerPoint és OpenDocument bemutatókat hozzon létre."
---
## **Bevezetés**

Mivel a bemutatók célja valami bemutatása, a megjelenésük és az interaktív viselkedésük mindig figyelembe van véve a létrehozásuk során.

**PowerPoint animáció** fontos szerepet játszik a bemutató látványos és vonzó megjelenése érdekében a nézők számára. Az Aspose.Slides for C++ széles körű lehetőségeket kínál a PowerPoint bemutató animációjának hozzáadásához:

- különböző típusú PowerPoint animációs effektusok alkalmazása alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- több PowerPoint animációs effektus használata egy alakzaton.
- animáció idővonal használata az animációs effektusok vezérléséhez.
- egyéni animáció létrehozása.

Az Aspose.Slides for C++ esetén különböző animációs effektusok alkalmazhatók az alakzatokra. Mivel a dia minden eleme, beleértve a szöveget, képeket, OLE objektumot, táblázatot stb., alakzatnak számít, ezért animációs effektust alkalmazhatunk a dia minden elemére.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation) **névtér** osztályokat biztosít a PowerPoint animációk kezeléséhez.
## **Animációs effektusok**
Az Aspose.Slides **150+ animációs effektust** támogat, beleértve az alapvető effektusokat, mint a Bounce, PathFootball, a Zoom effektus és a speciális effektusokat, mint az OLEObjectShow, OLEObjectOpen. A teljes animációs effektuslista megtalálható a [**EffectType**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) felsorolásban.

Ezen animációs effektusok kombinálhatók a következőkkel:

- [ColorEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.set_effect)

## **Egyéni animáció**
Lehetséges saját **egyéni animációkat** létrehozni az Aspose.Slides-ben.  
Ezt úgy érhetjük el, ha több viselkedést kombinálunk egy új egyéni animációba.

[**Behavior**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.behavior) bármely PowerPoint animációs effektus építőeleme.  
Az összes animációs effektus valójában egy viselkedésekből álló halmaz, amely egy stratégia szerint van összerakva.  
Egy egyéni animációba egyszerűen kombinálhatja a viselkedéseket, és újra felhasználhatja más bemutatókban.  
Ha új viselkedést ad hozzá egy szabványos PowerPoint animációs effektushoz – az egy újabb egyéni animáció lesz.  
Például hozzáadhat ismétlődő viselkedést egy animációhoz, hogy néhányszor megismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.point) az a pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**
[**Sequence**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.sequence) egy konkrét alakzatra alkalmazott animációs effektusok gyűjteménye.

[**AnimationTimeLine**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.animation.animation_time_line) egy konkrét dián használt Szekvenciák halmaza. Ez egy animációs motor, amely a PowerPoint 2002-es verziója óta létezik. Korábbi PowerPoint verziókban nehéz volt animációs effektusokat hozzáadni a bemutatóhoz, ami csak különböző megkerülő megoldásokkal volt lehetséges. Az idővonal a régi AnimationSettings osztályt helyettesíti, és egyértelműbb objektummodellt biztosít a PowerPoint animációkhoz. Egy diának csak egy animációs idővonal lehet.

## **Interaktív animáció**
[**EffectTriggerType**](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) lehetővé teszi felhasználói műveletek (például gombkattintás) definiálását, amelyek elindítanak egy adott animációt. A triggerek csak a legújabb PowerPoint verzióban lettek hozzáadva.

## **Alakzat animáció**
Aspose.Slides lehetővé teszi animációk alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalap, vonal, keret, OLE objektum stb.

{{% alert color="primary" %}} 
További információ [**Az alakzat animációjáról**](/slides/hu/cpp/shape-animation/).
{{% /alert %}}

## **Animált diagramok**
Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animáció csak diagramkategóriákra vagy diagram sorozatokra alkalmazható. Animációs effektust alkalmazhat kategóriaelemre vagy sorozatelemre is.

{{% alert color="primary" %}} 
További információ [**Animált diagramokról**](/slides/hu/cpp/animated-charts/).
{{% /alert %}}

## **Animált szöveg**
Az animált szövegen kívül animációt is alkalmazhat bekezdésre.

{{% alert color="primary" %}} 
További információ [**Az animált szövegről**](/slides/hu/cpp/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF-re exportáláskor?**

Nem. A PDF egy statikus formátum, így az animációk és a [diaátmenetek](/slides/hu/cpp/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/cpp/export-to-html5/), [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/cpp/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és vezérelhetem a képkockasebességet és a képkockaméretet?**

Igen. A [bemutatót képkockákra renderelheti](/slides/hu/cpp/convert-powerpoint-to-video/), majd videóvá (például ffmpeg segítségével) kódolhatja, kiválasztva a FPS-t és a felbontást. Az animációk és a diaátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk az ODP-vel (nem csak PPTX) való munkavégzéskor?**

A PPT, PPTX és ODP támogatott a [olvasáshoz](/slides/hu/cpp/open-presentation/) és a [íráshoz](/slides/hu/cpp/save-presentation/), de a formátumkülönbségek miatt bizonyos effektusok kicsit másként nézhetnek ki vagy viselkedhetnek. Kritikus eseteket valós mintákkal ellenőrizze.