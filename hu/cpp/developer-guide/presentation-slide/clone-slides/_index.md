---
title: Prezentációs diák klónozása C++-ban
linktitle: Diák klónozása
type: docs
weight: 40
url: /hu/cpp/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Gyorsan duplikáld a PowerPoint diákat az Aspose.Slides for C++ segítségével. Kövesd világos kódpéldáinkat, hogy másodpercek alatt automatizáld a PPT létrehozását és megszüntesd a manuális munkát."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció elkészítésének folyamata. Az Aspose.Slides for C++ lehetővé teszi, hogy bármely diát lemásolj vagy klónozz, majd a klónozott diát a jelenlegi vagy bármely más megnyitott prezentációba illeszd be. A diák klónozása egy új diát hoz létre, amelyet a fejlesztők módosíthatnak az eredeti dia megváltoztatása nélkül. Több lehetséges módja is létezik a dia klónozásának:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióban a prezentáción belül.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik pozícióban egy másik prezentációban.
- Klónozás egy meghatározott pozícióban egy másik prezentációban.

Az Aspose.Slides for C++ (egy [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumok gyűjteménye) a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumon keresztül a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) és [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódusokat biztosítja a fentebb felsorolt dia‑klónozási típusok végrehajtásához.

## **Klón egy diát a prezentáció végén**
Ha egy diát klónozni szeretnél, majd ugyanabban a prezentációfájlban a meglévő diák végére helyezni, használd a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust az alábbi lépések szerint:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Hozz létre egy példányt az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) osztályból, a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum által kitetts Slides gyűjteményre hivatkozva.
1. Hívd meg az [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektum biztosít, és add meg a klónozni kívánt diát paraméterként.
1. Írd ki a módosított prezentációfájlt.

Az alábbi példában egy diát (ami a prezentáció első (nulla) pozíciójában található) a prezentáció végére klónoztuk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klón egy diát egy másik pozícióba a prezentáción belül**
Ha egy diát klónozni szeretnél, majd ugyanabban a prezentációfájlban egy másik pozícióban használni, használd a [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Hozz létre egy példányt a **Slides** gyűjteményre hivatkozva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum biztosít.
1. Hívd meg az [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektum biztosít, és add meg a klónozni kívánt diát valamint az új pozíció indexét paraméterként.
1. Írd ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy diát (ami a prezentáció nulla indexén, azaz 1. pozíciójában található) a 1. indexre (2. pozíció) klónoztunk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klón egy diát egy másik prezentáció végén**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentáció fájl végéhez hozzáadni:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a célnak megfelelő prezentációt tartalmazza.
1. Hozz létre egy példányt az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) osztályból a célnak megfelelő Presentation objektum **Slides** gyűjteményére hivatkozva.
1. Hívd meg az [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektum biztosít, és add meg a forrás prezentációból származó diát paraméterként.
1. Írd ki a módosított célprezentációt.

Az alábbi példában egy diát (a forrás prezentáció első indexéből) a célprezentáció végére klónoztunk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klón egy diát egy másik pozícióba egy másik prezentációban**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációban egy meghatározott pozícióban használni:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a célnak megfelelő prezentációt tartalmazza.
1. Hozz létre egy példányt az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) osztályból a célprezentáció Presentation objektum Slides gyűjteményére hivatkozva.
1. Hívd meg az [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektum biztosít, és add meg a forrás prezentációból származó diát valamint a kívánt pozíciót paraméterként.
1. Írd ki a módosított célprezentációt.

Az alábbi példában egy diát (a forrás prezentáció nulladik indexéből) az 1. indexre (2. pozíció) klónoztunk a célprezentációban.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klón egy diát egy meghatározott pozícióban egy másik prezentációban**
Ha egy diát a mesterdiával együtt egy prezentációból egy másikba kell klónozni, először a kívánt mesterdiát kell a forrás prezentációból a célprezentációba klónozni. Ezután ezt a mesterdiát kell a dia klónozásához használni. A **AddClone(ISlide, IMasterSlide)** a célprezentáció mesterdiáját várja, nem a forrásét. A mesterdiával ellátott dia klónozásához kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a célprezentációt tartalmazza.
1. Szerezz hozzáférést a klónozandó diához és a hozzá tartozó mesterdiához.
1. Hozz létre egy példányt az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) osztályból a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum Masters gyűjteményére hivatkozva.
1. Hívd meg az [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) objektum biztosít, és add meg a forrás PPTX‑ből származó mesterdiát paraméterként.
1. Hozz létre egy példányt az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) osztályból a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum Slides gyűjteményére hivatkozva.
1. Hívd meg az [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektum biztosít, és add meg a forrás prezentációból származó diát és a mesterdiát paraméterként.
1. Írd ki a módosított célprezentációt.

Az alábbi példában egy mesterdiával ellátott diát (ami a forrás prezentáció nulladik indexén található) a célprezentáció végére klónoztunk a forrás diából származó mesterrel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klón egy diát egy meghatározott szekció végén**
Ha egy diát klónozni szeretnél, majd ugyanabban a prezentációfájlban egy másik szekcióba helyezni, akkor használd a [**AddClone()**](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet a [**ISlideCollection**](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) interfész biztosít. Az Aspose.Slides for C++ lehetővé teszi, hogy egy diát az első szekcióból klónozz, majd a klónozott diát a második szekcióba illeszd be ugyanabban a prezentációban.

Az alábbi kódrészlet megmutatja, hogyan kell egy diát klónozni, és a klónozott diát egy meghatározott szekcióba beszúrni.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Biztosítsa a megfelelő dia méretet**
Amikor diákat klónozol egy másik prezentációba, ügyelj arra, hogy a célprezentáció dia mérete megegyezzen a forráséval. Ha a dia méretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – az eredeti koordinátáik és méreteik megmaradnak, ami azt eredményezheti, hogy a tartalom nem lesz megfelelően igazítva vagy a dia határain kívülre kerül.

A mesterdiát és a diát klónozás előtt állítsd be a célprezentáció dia méretét a forráséhoz:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Ezt a mester- és diaklónozás előtt kell elvégezni.

## **GYIK**

**Klónozódnak a jegyzetek és a felülvizsgálati megjegyzések?**  
Igen. A jegyzetoldal és a felülvizsgálati megjegyzések is benne vannak a klónban. Ha nem szeretnéd őket, [remove them](/slides/hu/cpp/presentation-notes/) az inserció után.

**Hogyan kezelődik a diagram és annak adatforrása?**  
A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz (például OLE‑beágyazott munkafüzethez) volt kapcsolva, ez a kapcsolat OLE‑objektumként ([OLE object](/slides/hu/cpp/manage-ole/)) marad meg. A fájlok közti áthelyezés után ellenőrizd az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és szekcióit?**  
Igen. A klónot egy adott dia indexhez illesztheted, és egy kiválasztott [section](/slides/hu/cpp/slide-section/)‑be helyezheted. Ha a cél szekció nem létezik, előbb hozd létre, majd mozdítsd át a diát oda.