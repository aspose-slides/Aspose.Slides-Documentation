---
title: Prezentációk létrehozása C++-ban
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/cpp/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Prezentációk létrehozása C++ nyelven az Aspose.Slides segítségével – PPT, PPTX és ODP fájlok generálása, az OpenDocument támogatás kihasználása, és programozott mentés megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet létrehozni egy prezentációt az Aspose.Slides-ban, egyszerű tartalmat hozzáadni egy diára, és az eredményt fájlként menteni.

## **PowerPoint‑prezentáció létrehozása**
Egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg egy dia hivatkozását az Index használatával.
1. Adjon hozzá egy vonal típusú AutoShape‑et a Shapes objektum által biztosított AddAutoShape metódussal.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alább látható példában egy vonalat adtunk hozzá a prezentáció első diájához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **GYIK**

**Milyen formátumokba menthetem az új prezentációt?**

Menthet [PPTX, PPT és ODP](/slides/hu/cpp/save-presentation/), valamint exportálhat [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), [SVG](/slides/hu/cpp/convert-powerpoint-to-png/) és [képek](/slides/hu/cpp/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek sablonból (POTX/POTM), és menthetem szabályos PPTX‑ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/cpp/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát prezentáció létrehozásakor?**

Állítsa be a [dia méretét](/slides/hu/cpp/slide-size/) (beleértve az 4:3 és 16:9 előre beállítottak vagy egyedi méretek lehetőségét), és válassza ki, hogyan méreteződjön a tartalom.

**Milyen egységekben mérik a méreteket és koordinátákat?**

Pontokban: 1 hüvelyk = 72 egység.

**Hogyan kezeljek nagyon nagy prezentációkat (sok médiafájllal), hogy csökkentsem a memóriahasználatot?**

Használjon [BLOB‑kezelési stratégiákat](/slides/hu/cpp/manage-blob/), korlátozza a memóriában tárolást ideiglenes fájlok használatával, és részesítse előnyben a fájlalapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**

Nem működtethet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányon [több szál](/slides/hu/cpp/multithreading/) esetén. Indítson külön, elszigetelt példányokat szálanként vagy folyamatként.

**Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?**

[Alkalmazzon licencet](/slides/hu/cpp/licensing/) egyszer a folyamatban. A licenc XML‑nek változatlanul kell maradnia, és a licenc beállítását szinkronizálni kell, ha több szál is érintett.

**Digitálisan aláírhatom a létrehozott PPTX‑et?**

Igen. A [digitális aláírások](/slides/hu/cpp/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatottak a prezentációkhoz.

**Makrók (VBA) támogatottak a létrehozott prezentációkban?**

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/cpp/presentation-via-vba/) és menthet makróval ellátott fájlokat, például PPTM/PPSM.