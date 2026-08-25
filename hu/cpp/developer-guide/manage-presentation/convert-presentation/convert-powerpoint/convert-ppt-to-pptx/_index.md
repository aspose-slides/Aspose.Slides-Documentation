---
title: PPT konvertálása PPTX-re C++-ban
linktitle: PPT-t PPTX-re
type: docs
weight: 20
url: /hu/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Legacy PPT fájlok konvertálása PPTX-re C++-ban az Aspose.Slides segítségével. Tartalmaz C++ példákat egyedi és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for C++ képes betölteni egy PPT‑fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPointra szükség lenne. Ez a cikk bemutatja, hogyan konvertálhatunk egyetlen fájlt vagy egy könyvtár fájljait, és elmagyarázza, milyen ellenőrzéseket kell elvégezni a konverzió után.

## **PPT fájl konvertálása PPTX-re**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) argumentummal. Szabadítsa fel a prezentációt, amikor már nincs rá szükség, hogy felszabadítsa az erőforrásait.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) argumentum adja meg. Tartsa külön a bemeneti és a kimeneti útvonalakat, ha meg kell őrizni az eredeti PPT‑fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja le a többi feldolgozását.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Éles környezetben naplózza a teljes kivételt, döntsön arról, hogy felülírható-e a meglévő kimeneti fájl, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok, amelyeket a szükséges jelszó nélkül nyitnak meg, elérhetetlen útvonalak és nem támogatott tartalmak is okozhatják a konverziót. A titkosított fájlok betöltéséhez tekintse meg a [Password-Protected Presentations](/slides/hu/cpp/password-protected-presentation/) oldalt.

## **Hitelesség és régi funkciók**

A konverzió általában megőrzi a diákat, mesteroldalakat, elrendezéseket, szöveget, alakzatokat, képeket, táblázatokat és diagramokat. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy olyan régi funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, kihagyható vagy másként jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makró‑engedélyezett formátum, ezért használjon megfelelő makró‑engedélyezett munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Győződjön meg arról is, hogy a szükséges betűtípusok és külső erőforrások rendelkezésre állnak abban a környezetben, ahol a konvertált prezentációt megnyitják vagy renderelik.

Fontos dokumentumok esetén nyissa meg programozottan a létrehozott PPTX‑et, ellenőrizze a kulcsfontosságú diákszámot és tartalmat, majd hasonlítsa össze megjelenését és diavetítés‑viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) hívást bizonyítékra, hogy minden régi funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjunk PPTX‑et**

Használjon PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókkal szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszaállítási példányként, amíg a konvertált prezentáció át nem esik a hitelességi ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szükség, használja a [Convert Presentations to Multiple Formats](/slides/hu/cpp/convert-presentation/) formátumspecifikus útmutatót, ahelyett, hogy azt feltételezné, hogy minden célformátum megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritka alkalomra vagy gyors összehasonlításra használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) eszközt. Ismételhető konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a C++ API‑t.

## **Kapcsolódó cikkek**

- [Prezentációk mentése C++‑ban](/slides/hu/cpp/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/cpp/supported-file-formats/)
- [Prezentációk megnyitása C++‑ban](/slides/hu/cpp/open-presentation/)

## **GYIK**

**Konvertálhatok PPT‑t PPTX‑re Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for C++ betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑PPTX konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a közös prezentációs tartalmakat, de a teljes pontosság nem garantált minden régi vagy nem támogatott funkció esetén. Tekintse át a létrehozott fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a megfelelő jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés sikertelen.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg ellenőrizte a PPTX‑et a fontos nézőprogramokban és munkafolyamatokban. Ez visszaállítási másolatot biztosít, ha egy régi funkció másként konvertálódik.