---
title: PowerPoint prezentációk fejlesztése animációkkal PHP-ben
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
- PHP
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for PHP via Java képességeit a PowerPoint animációk kezelése terén. Kulcsfontosságú funkciók és betekintések a prezentációk fejlesztéséhez."
---
## **Bevezetés**

Mivel a bemutatók valamit kell, hogy bemutassanak, ezért a vizuális megjelenésüket és interaktív viselkedésüket mindig figyelembe veszik a készítésük során.

**PowerPoint animáció** fontos szerepet játszik a bemutató szemrevaló és vonzóvá tételében a nézők számára. Az Aspose.Slides for PHP via Java széles körű lehetőséget kínál a PowerPoint bemutatóhoz való animáció hozzáadására:

- alkalmazzon különféle típusú PowerPoint animációs effektusokat alakzatokra, diagramokra, táblázatokra, OLE objektumokra és egyéb bemutatóelemekre.
- használjon több PowerPoint animációs effektust egy alakzaton.
- használja az animáció idővonalát az effektusok vezérléséhez.
- hozzon létre egyedi animációt.

Az Aspose.Slides for PHP via Java-ban különféle animációs effektusok alkalmazhatók az alakzatokra. Mivel a dián lévő minden elem, beleértve a szöveget, képeket, OLE objektumot, táblázatot stb., alakzatnak tekinthető, ez azt jelenti, hogy animációs effektust alkalmazhatunk a dia minden elemére.

## **Animációs effektusok**

Az Aspose.Slides támogatja a **150+ animációs effektust**, beleértve az alapvető effekteket, mint a Bounce, a PathFootball, a Zoom effektus, valamint a speciális effekteket, mint az OLEObjectShow, OLEObjectOpen. A teljes animációs effektus lista megtalálható a [**EffectType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttype/) enumerációban.

Ezenkívül ezeket az animációs effektusokat kombinálhatjuk velük:
- [ColorEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SetEffect)

## **Egyedi animáció**

Lehetséges saját **egyedi animációkat** létrehozni az Aspose.Slides-ban. 
Ez úgy érhető el, ha több viselkedést egyesítünk egy új egyedi animációba.

[**Behavior**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Behavior) egy építőeleme bármely PowerPoint animációs effektusnak. Az összes animációs effektus valójában egy viselkedéssorozat, amely egy stratégiába van összefűzve. Egyszer kombinálhatja a viselkedéseket egy egyedi animációba, és újra felhasználhatja más bemutatókban. Ha új viselkedést ad hozzá egy szabványos PowerPoint animációs effektushoz, akkor egy újabb egyedi animáció jön létre. Például hozzáadhat ismétlődő viselkedést egy animációhoz, hogy néhányszor megismétlődjön.

[**Animation Point**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Point) egy pont, ahol a viselkedést alkalmazni kell.

## **Animációs idővonal**

[**Sequence**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Sequence) egy animációs effektusok gyűjteménye, amely egy konkrét alakzatra van alkalmazva.

[**Timeline**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/AnimationTimeLine) egy sorozatot tartalmazó halmaz, amely egy konkrét dián használatos. Ez egy animációs motor, amely a PowerPoint 2002-től van jelen. A korábbi PowerPoint verziókban nehéz volt animációs effektusokat hozzáadni a bemutatóhoz, ami csak különféle megoldásokkal volt lehetséges. A Timeline lecseréli a régi AnimationSettings osztályt, és egyértelműbb objektummodellt biztosít a PowerPoint animációhoz. Egy diához csak egy animációs idővonal rendelkedhet.

## **Interaktív animáció**

[**Trigger**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/EffectTriggerType) lehetővé teszi felhasználói műveletek (pl. gombkattintás) definiálását, amelyek egy adott animációt indítanak el. A triggerek csak a legújabb PowerPoint verzióban kerültek be.

## **Alakzat animáció**

Az Aspose.Slides lehetővé teszi animáció alkalmazását alakzatokra, amelyek lehetnek szöveg, téglalap, vonal, keret, OLE objektum stb.

{{% alert color="primary" %}} 
Olvasd tovább [**Az alakzat animációjáról**](/slides/hu/php-java/shape-animation/).
{{% /alert %}}

## **Animált diagramok**

Animált diagramok létrehozásához ugyanazokat az osztályokat kell használni, mint az alakzatoknál. Azonban a PowerPoint animáció csak a diagramkategóriákra vagy -sorozatokra alkalmazható. Animációs effektust alkalmazhat egy kategóriaelemre vagy sorozatelemre is.

{{% alert color="primary" %}} 
Olvasd tovább [**Az animált diagramokról**](/slides/hu/php-java/animated-charts/).
{{% /alert %}}

## **Animált szöveg**

Az animált szövegen kívül animációt lehet alkalmazni egy bekezdésre is.

{{% alert color="primary" %}} 
Olvasd tovább [**Az animált szövegről**](/slides/hu/php-java/animated-text/).
{{% /alert %}}

## **GYIK**

**Megmaradnak-e az animációk PDF-re exportáláskor?**

Nem. A PDF egy statikus formátum, ezért az animációk és a [diaátmenetek](/slides/hu/php-java/slide-transition/) nem játszódnak le. Ha mozgásra van szükség, exportáljon [HTML5](/slides/hu/php-java/export-to-html5/), [animált GIF](/slides/hu/php-java/convert-powerpoint-to-animated-gif/) vagy [videó](/slides/hu/php-java/convert-powerpoint-to-video/) formátumba.

**Átalakíthatom-e az animált bemutatót videóvá, és szabályozhatom a képkocka sebességet és méretet?**

Igen. A [bemutató képkockákká renderelésével](/slides/hu/php-java/convert-powerpoint-to-video/) és azokat videóvá (például ffmpeg segítségével) kódolhatja, kiválasztva a FPS-t és a felbontást. Az animációk és a diaátmenetek a renderelés során lejátszásra kerülnek.

**Megmaradnak-e az animációk ODP-vel dolgozva (nem csak PPTX)?**

A PPT, PPTX és ODP formátumok támogatottak a [beolvasáshoz](/slides/hu/php-java/open-presentation/) és a [mentéshez](/slides/hu/php-java/save-presentation/), de a formátumkülönbségek miatt egyes effektusok kissé eltérőnek tűnhetnek vagy viselkedhetnek. A kritikus eseteket valós mintákkal ellenőrizze.