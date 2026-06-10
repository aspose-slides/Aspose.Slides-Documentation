---
title: Diaátmenetek kezelése prezentációkban C++ használatával
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/cpp/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- fejlett diaátmenet
- morph átmenet
- átmennettípus
- átmenet effektus
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diaátmeneteket az Aspose.Slides for C++-ban, lépésről lépésre útmutatóval a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk leírja, hogyan kezelhetők a diaátmenetek a bemutatókban az Aspose.Slides használatával. Bemutatja, hogyan lehet átmenettípusokat alkalmazni a diákra, beállítani az átmenet viselkedését, például kattintásra vagy meghatározott idő után történő előrehaladást, ellenőrizni és letiltani az automatikus előrehaladást, használni a Morph átmenetet és annak típusait, valamint megadni az átmenet‑effektus beállításait. A példák azt mutatják be, hogyan kell betölteni vagy létrehozni egy bemutatót, módosítani a kiválasztott diák átmenet beállításait, és az eredményt PPTX fájlként menteni. A cikk emellett válaszol a gyakori kérdésekre az átmenet sebességéről, hangjairól, ugyanazon átmenet több diára történő alkalmazásáról és arról, hogyan ellenőrizhető, hogy melyik átmenet van beállítva egy dián.

## **Diaátmenet hozzáadása**
A megértés megkönnyítése érdekében bemutattuk az Aspose.Slides for C++ használatát egyszerű diaátmenetek kezelésekor. A fejlesztők nemcsak különböző diaátmenet‑effekteket alkalmazhatnak a diákra, hanem testreszabhatják ezen effektusok viselkedését is. Egy egyszerű diaátmenet‑effektus létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Alkalmazzon egy Slide Transition Type‑t a diára az Aspose.Slides for C++ által kínált átmenet‑effektek egyikéből a TransitionType enum segítségével.
1. Írja ki a módosított bemutató fájlt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Fejlett diaátmenet hozzáadása**
Az előző szakaszban csak egy egyszerű átmenet‑effektust alkalmaztunk a diára. Most, hogy ez a egyszerű átmenet még jobb és szabályozható legyen, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Alkalmazzon egy Slide Transition Type‑t a diára az Aspose.Slides for C++ által kínált átmenet‑effektek egyikéből.
1. Beállíthatja, hogy az átmenet Advance On Click‑re, egy meghatározott időtartam után vagy mindkettőre történjen.
1. Ha a diaátmenet Advance On Click‑re van állítva, az átmenet csak akkor halad tovább, ha valaki kattint az egérrel. Továbbá, ha az Advance After Time tulajdonság be van állítva, az átmenet a megadott idő letelte után automatikusan továbbhalad.
1. Írja ki a módosított bemutatót bemutató fájlként.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph átmenet**
Az Aspose.Slides for C++ most már támogatja a Morph átmenetet. Ez a PowerPoint 2019‑ben bevezetett új morph átmenetet képviseli. A Morph átmenet lehetővé teszi a sima animációt az egyik dia és a következő közötti mozgásra. Ez a cikk leírja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két dia szükséges, amelyek legalább egy közös objektummal rendelkeznek. A legegyszerűbb módja ennek, ha duplikálja a diát, majd a második dián áthelyezi az objektumot egy másik helyre.

Az alábbi kódrészlet megmutatja, hogyan adhatunk a bemutatóhoz egy klónozott diát szöveggel, és állíthatunk morph típusú átmenetet a második diára.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph átmenet típusai**
Új, a Aspose.Slides.SlideShow.TransitionMorphType enum került hozzáadásra. Ez a különböző Morph diaátmenet‑típusokat képviseli.

A TransitionMorphType enum három taggal rendelkezik:

- ByObject: A morph átmenet a formákat oszthatatlan objektumokként veszi figyelembe.
- ByWord: A morph átmenet a szöveget szavakra bontva, ahol lehetséges, továbbítja.
- ByChar: A morph átmenet a szöveget karakterekre bontva, ahol lehetséges, továbbítja.

Az alábbi kódrészlet megmutatja, hogyan állítható be a morph átmenet egy diára, és hogyan módosítható a morph típus:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Átmenet‑effektek beállítása**
Az Aspose.Slides for C++ támogatja az átmenet‑effektek, például „from black”, „from left”, „from right” stb. Az átmenet‑effekt beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból.
- Szerezze meg a dia referenciaát.
- Állítsa be az átmenet‑effektet.
- Írja ki a bemutatót PPTX fájlként.

Az alábbi példában beállítottuk az átmenet‑effekteket.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **GYIK**

**Vezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Állítsa be az átmenet [speed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) értékét a [TransitionSpeed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionspeed/) beállítással (például slow/medium/fast).

**Csatolhatok hangot az átmenethez, és beállíthatom a hurok‑lejátszást?**

Igen. Beágyazhat hangot az átmenethez, és a viselkedést vezérelheti olyan beállításokkal, mint a hang módja és a hurkolás (például [set_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), plusz metaadatok, mint [set_SoundIsBuiltIn](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) és [set_SoundName](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Állítsa be a kívánt átmenet‑típust minden dia átmenet‑beállításánál; az átmenetek diáronként tárolódnak, így ugyanazt a típust minden diához alkalmazva konzisztens eredményt kap.

**Hogyan ellenőrizhetem, melyik átmenet van jelenleg egy dián beállítva?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/cpp/aspose.slides.baseslide/get_slideshowtransition/)‑ét, és olvassa ki annak [transition type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/slideshowtransition/get_type/)‑ját; ez az érték pontosan megmutatja, melyik effektus van alkalmazva.