---
title: PPT konvertálása PPTX-be C++-ban
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Konvertálja a régi PPT fájlokat PPTX-be C++-ban az Aspose.Slides segítségével. Tartalmaz C++ példákat egyetlen fájl és kötegelt konverzióra, hiba-kezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for C++ képes PPT fájlt betölteni és PPTX‑ként menteni a Microsoft PowerPoint nélkül. Ez a cikk bemutatja, hogyan lehet egy fájlt vagy egy könyvtár fájljait konvertálni, és elmagyarázza, mit kell ellenőrizni a konverzió után.

## **PPT fájl konvertálása PPTX‑be**

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

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) argumentum végzi. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg kell őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden egyes `.ppt` fájlt egy könyvtárban konvertál. Minden fájl függetlenül kerül feldolgozásra, így egy hibás konverzió sem állítja meg a batch többi részét.

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

Éles környezetben naplózza a teljes kivételt, döntse el, felülírható-e egy meglévő kimeneti fájl, és írja a sikertelen fájlneveket egy újbóli próbálkozásra vagy felülvizsgálatra szánt sorba. Sérült fájlok, jelszóval védett fájlok a szükséges jelszó nélkül megnyitva, elérhetetlen útvonalak és nem támogatott tartalom is okozhatja a konverzió meghiúsulását. Lásd a [Password-Protected Presentations](/cpp/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diák, mesteroldalak, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálásra, kihagyásra vagy eltérő megjelenítésre kerülhet.

Ellenőrizze a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. A sima PPTX fájl nem makró‑támogatott formátum, ezért használjon megfelelő, makró‑támogatott munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Emellett ellenőrizze, hogy a szükséges betűtípusok és külső erőforrások rendelkezésre állnak‑e abban a környezetben, ahol a konvertált prezentáció meg lesz nyitva vagy renderelve.

Fontos dokumentumok esetén nyissa meg programozottan az előállított PPTX‑et, ellenőrizze a kulcsfontosságú dia számokat és a tartalmat, majd hasonlítsa össze a megjelenését és a diavetítés viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX reprezentációval rendelkezik.

## **Mikor érdemes PPTX‑et használni**

Használjon PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és visszaállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszaállítási másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szüksége, használja a [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) formátumspecifikus útmutatót, ahelyett, hogy feltételezné, hogy minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Egy alkalmi fájl vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) eszközt. Ismételhető konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hiba­kezeléshez használja a C++ API‑t.

## **Kapcsolódó cikkek**

- [Prezentációk mentése C++](/cpp/save-presentation/)
- [Támogatott fájlformátumok](/cpp/supported-file-formats/)
- [Prezentációk megnyitása C++](/cpp/open-presentation/)

## **GYIK**

**Konvertálhatok PPT‑t PPTX‑be Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for C++ betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPoint szükséges lenne.

**A PPT‑ról PPTX‑re történő konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a gyakori prezentációs tartalmakat, de a pontos pontosság nem garantált minden örökölt vagy nem támogatott funkcióra. Tekintse át a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a helyes jelszót. Hiányzó vagy helytelen jelszó esetén a betöltési művelet hibára fut.

**Töröljem a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg ellenőrizte a PPTX‑et a releváns megjelenítőkben és munkafolyamatokban. Ez visszaállítási másolatot biztosít, ha egy örökölt funkció másként konvertálódik.