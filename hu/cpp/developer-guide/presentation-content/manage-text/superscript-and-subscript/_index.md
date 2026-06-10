---
title: Felső- és alindex kezelése prezentációkban C++ használatával
linktitle: Felsőindex és alindex
type: docs
weight: 80
url: /hu/cpp/superscript-and-subscript/
keywords:
- felsőindex
- alindex
- felsőindex hozzáadása
- alindex hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Mestere a felső- és alindex formázásnak az Aspose.Slides C++-ban, és emelje prezentációit professzionális szövegformázással a maximális hatásért."
---
## **Áttekintés**

Az Aspose.Slides olyan funkciókat kínál, amelyek lehetővé teszik a felső- és alindex szöveg integrálását a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkba. Akár kémiai képleteket, matematikai egyenleteket kell kiemelni, vagy tartalmat lábjegyzetekkel ellátni, ezek a speciális formázási lehetőségek segítenek a tisztaság és pontosság megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazhatja zökkenőmentesen a felső- és alindex stílusokat, és biztosíthat professzionális eredményeket minden dián.

## **Felső- és alindex szöveg kezelése**

Szuper‑ és alindex szöveget bármely bekezdésrészbe hozzáadhat. Az Aspose.Slides szövegdobozában felső- vagy alindex szöveg hozzáadásához a PortionFormat osztály **Escapement** tulajdonságait kell használni.  
Ez a tulajdonság visszaadja vagy beállítja a felső- vagy alindex szöveget (érték -100 % (alsóindex) és 100 % (felsőindex) között). Például:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze be a dia referenciáját az Indexe használatával.
- Adjon hozzá egy IAutoShape elemet Rectangle típusban a diához.
- Hozzáférés az IAutoShape-hez társított ITextFrame-hez.
- Törölje a meglévő bekezdéseket.
- Hozzon létre egy új bekezdésobjektumot a felsőindex szöveg tárolásához, és adja hozzá az ITextFrame IParagraphs gyűjteményéhez.
- Hozzon létre egy új részlet (portion) objektumot.
- Állítsa be az Escapement tulajdonságot a részletnél 0 és 100 közé a felsőindex hozzáadásához. (0 jelentése nincs felsőindex)
- Állítson be szöveget a Portion számára, majd adja hozzá a bekezdés portion gyűjteményéhez.
- Hozzon létre egy új bekezdésobjektumot az alindex szöveg tárolásához, és adja hozzá az ITextFrame IParagraphs gyűjteményéhez.
- Hozzon létre egy új részlet (portion) objektumot.
- Állítsa be az Escapement tulajdonságot a részletnél 0 és -100 között az alindex hozzáadásához. (0 jelentése nincs alindex)
- Állítson be szöveget a Portion számára, majd adja hozzá a bekezdés portion gyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább látható.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **GYIK**

**Megmarad a felső- és alindex formázás PDF vagy más formátumok exportálásakor?**  
Igen, az Aspose.Slides megfelelően megőrzi a felső- és alindex formázást a prezentációk PDF, PPT/PPTX, képek és egyéb támogatott formátumokba történő exportálása során. A speciális formázás minden kimeneti fájlban érintetlen marad.

**Kombinálható a felső- és alindex más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**  
Igen, az Aspose.Slides lehetővé teszi, hogy különböző szövegstílusokat keverjen egyetlen szövegrészben. Bekapcsolhatja a félkövér, dőlt, aláhúzott stílusokat, és egyidejűleg alkalmazhatja a felső- vagy alindexet a megfelelő tulajdonságok beállításával a [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) osztályban.

**Működik a felső- és alindex formázás táblázatokban, diagramokban vagy SmartArtban lévő szövegre?**  
Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és a diagram elemeket is. SmartArt használatakor el kell érni a megfelelő elemeket (például a [SmartArtNode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartnode/)) és azok szövegtárolóiról, majd hasonló módon be kell állítani a [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) tulajdonságokat.