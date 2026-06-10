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
description: "Az Aspose.Slides for C++ segítségével gyorsan duplikálhatja a PowerPoint diákat. Kövesse világos kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a manuális munkát."
---
## **Bevezetés**

A klónozás egy folyamat, amely valaminek a pontos másolatát vagy replikáját hozza létre. Az Aspose.Slides for C++ is lehetővé teszi, hogy bármely diát lemásolj vagy klónozz, majd a klónozott diát a jelenlegi vagy bármely más megnyitott prezentációba illeszd. A dia klónozási folyamata egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Számos lehetséges módja van a dia klónozásának:

- Klónozás a prezentáció végén.
- Klónozás a prezentációban egy másik pozícióban.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik prezentációban egy másik pozícióban.
- Klónozás egy megadott pozícióban egy másik prezentációban.

Aspose.Slides for C++ esetén a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum által kitetts [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumok gyűjteménye biztosítja a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) és a [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódusokat a fenti dia klónozási típusok végrehajtásához

## **Dia klónozása a prezentáció végén**

Ha egy diát szeretnél klónozni, majd ugyanabban a prezentációfájlban a meglévő diák végén használni, használd a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust az alábbi lépések szerint:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Hozd létre a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum által kitetts Slides gyűjtemény hivatkozásával.  
3. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektumon, és add át a klónozandó diát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódusnak.  
4. Írd vissza a módosított prezentációfájlt.

Az alábbi példában egy diát (amely a prezentáció első pozíciójában – nulla index – helyezkedik el) a prezentáció végére klónoztuk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Dia klónozása egy másik pozícióba a prezentáción belül**

Ha egy diát szeretnél klónozni, majd ugyanabban a prezentációfájlban egy másik pozícióban használni, használja a [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Hozd létre a példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektum által kitetts **Slides** gyűjtemény hivatkozásával.  
3. Hívd meg az [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektumon, és add át a klónozandó diát a kívánt új pozíció indexével együtt paraméterként az [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódusnak.  
4. Írd a módosított prezentációt PPTX fájlként.

Az alábbi példában egy diát (amely a nulla indexen – 1. pozíció – helyezkedik el a prezentációban) az 1-es indexre – 2. pozícióra – klónoztuk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Dia klónozása egy másik prezentáció végén**

Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációfájlban a meglévő diák végén használni:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogod.  
2. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a cél prezentációt tartalmazza, ahová a diát hozzáadod.  
3. Hozd létre a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) példányt a cél prezentáció [Presentation] objektum által kitetts **Slides** gyűjtemény hivatkozásával.  
4. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektumon, és add át a forrás prezentációból származó diát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódusnak.  
5. Írd a módosított cél prezentációfájlt.

Az alábbi példában egy diát (a forrás prezentáció első indexéről) a cél prezentáció végére klónoztunk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Dia klónozása egy másik pozícióba egy másik prezentációban**

Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációfájlban egy meghatározott pozícióban használni:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogod.  
2. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a cél prezentációt tartalmazza, ahová a diát hozzáadod.  
3. Hozd létre a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) példányt a cél prezentáció [Presentation] objektum által kitetts Slides gyűjtemény hivatkozásával.  
4. Hívd meg a [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektumon, és add át a forrás prezentációból származó diát a kívánt pozícióval együtt paraméterként az [InsertClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/insertclone/) metódusnak.  
5. Írd a módosított cél prezentációfájlt.

Az alábbi példában egy diát (a forrás prezentáció nulla indexéről) az 1-es indexre (2. pozíció) klónoztuk a cél prezentációban.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Dia klónozása egy meghatározott pozícióba egy másik prezentációban**

Ha egy diát mester diával együtt kell klónozni egy prezentációból és egy másik prezentációban használni, először a kívánt mesterdiát kell a forrás prezentációból a cél prezentációba klónozni. Ezután ezt a mesterdiát kell használni a diák mesterrel történő klónozásához. A **AddClone(ISlide, IMasterSlide)** a cél prezentáció mesterdiáját várja, nem a forrásét. A diát mesterrel együtt klónozni az alábbi lépések szerint:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogod.  
2. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt, amely a cél prezentációt tartalmazza, ahová a diát klónozni fogod.  
3. Érd el a klónozandó diát a mesterdiával együtt.  
4. Hozd létre a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) példányt a cél prezentáció [Presentation] objektum által kitetts Masters gyűjtemény hivatkozásával.  
5. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) objektumon, és add át a forrás PPTX‑ből származó mesterdiát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódusnak.  
6. Hozd létre a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) példányt úgy, hogy a referencia a cél prezentáció [Presentation] objektum által kitetts Slides gyűjteményre mutasson.  
7. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) objektumon, és add át a forrás prezentációból származó diát, valamint a mesterdiát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódusnak.  
8. Írd a módosított cél prezentációfájlt.

Az alábbi példában egy mesterdiával ellátott diát (a forrás prezentáció nulla indexén) a cél prezentáció végére klónoztunk, a forrás diából származó mesterdiát használva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Dia klónozása egy meghatározott szakasz végén**

Ha egy diát szeretnél klónozni, majd ugyanabban a prezentációfájlban egy másik szakaszban használni, akkor használd a [**AddClone()**](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/addclone/) metódust, amelyet a [**ISlideCollection**](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) interfész biztosít. Az Aspose.Slides for C++ lehetővé teszi, hogy egy diát az első szakaszból klónozz, majd azt a klónozott diát a ugyanazon prezentáció második szakaszába illeszd.

Az alábbi kódrészlet bemutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy megadott szakaszba beszúrni.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **GYIK**

**Másolódnak a beszélőjegyzetek és a lektorálási megjegyzések?**

Igen. A jegyzetoldal és a lektorálási megjegyzések a klónba kerülnek. Ha nem szeretnéd őket, [távolítsd el őket](/slides/hu/cpp/presentation-notes/) a beszúrás után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagramobjektum, a formázás és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz volt kapcsolva (például OLE‑beágyazott munkafüzethez), ez a kapcsolat egy [OLE‑objektum](/slides/hu/cpp/manage-ole/) formájában megmarad. Fájlok között áthelyezés után ellenőrizd az adatok elérhetőségét és a frissítési viselkedést.

**Vezérelhetem a klón beszúrási pozícióját és szakaszait?**

Igen. A klónt beszúrhatod egy adott diáindexre, és elhelyezheted egy kiválasztott [szakaszba](/slides/hu/cpp/slide-section/). Ha a cél szakasz nem létezik, előbb hozd létre, majd helyezd át a diát.