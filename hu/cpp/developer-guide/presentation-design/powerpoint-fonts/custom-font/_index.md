---
title: "PowerPoint betűtípusok testreszabása C++-ban"
linktitle: "Egyedi betűtípus"
type: docs
weight: 20
url: /hu/cpp/custom-font/
keywords:
- "betűtípus"
- "egyedi betűtípus"
- "külső betűtípus"
- "betűtípus betöltése"
- "betűtípusok kezelése"
- "betűtípus mappa"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Aspose.Slides for C++ segítségével, hogy prezentációi élesek és konzisztensak legyenek minden eszközön."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi egyedi betűtípusok használatát a bemutatókban az operációs rendszerre való telepítés nélkül. Betűtípusokat tölthet be egyéni mappákból, biztosíthat betűtípusokat egy adott prezentációhoz dokumentumszintű betűtípusforrásokon keresztül, vagy külső betűtípusokat tölthet be közvetlenül bináris adatból.

A betöltött betűtípusok a prezentáció renderelésekor vagy exportálásakor kerülnek felhasználásra, például PDF, képek és egyéb támogatott formátumok esetén. Ez segít az előállítás konzisztensnek tartásában különböző környezetekben. A cikk azt is elmagyarázza, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus-mappákat, és hogyan törölheti a betűtípus-gyorsítót a külső betűtípusok használata után.

A saját betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX fájlba ágyazásától. Ha a betűtípust magában a prezentációban kell tárolni, használja a betűtípus-átágyazási funkciókat kifejezetten.

Egy prezentáció témája különböző betűcsaládokra hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések csak a betűtípusneveket tárolják, de nem telepítik vagy töltik be a betűtípusfájlokat. Tekintse meg a [Script-Specific Theme Fonts](/slides/hu/cpp/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési lehetőségeket a hivatkozott betűtípusok rendelkezésre állásához a konzisztens renderelés érdekében.

{{% alert color="info" title="Megjegyzés" %}}
Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Egyedi betűtípusok betöltése**

Aspose.Slides lehetővé teszi, hogy betöltse a prezentációban használt betűtípusokat a rendszerre való telepítés nélkül. Ez befolyásolja az export kimenetet – például PDF, képek és egyéb támogatott formátumok – így a keletkezett dokumentumok konzisztensnek mutatnak különböző környezetekben. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez ezekből a mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/clearcache/) metódust a betűtípus-gyorsítótár törléséhez.

A következő kódrészlet bemutatja a betűtípus betöltési folyamatát:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Határozza meg az egyedi betűtípus fájlokat tartalmazó mappákat.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Töltsön be egyedi betűtípusokat a megadott mappákból.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF‑be, képekbe vagy egyéb formátumokba) a betöltött betűtípusok használatával.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Törölje a betűtípus-gyorsítót a munka befejezése után.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Megjegyzés" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem módosítja a betűtípus inicializálási sorrendjét.
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípus-mappák lekérése**
Aspose.Slides biztosítja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metóduson keresztül hozzáadott mappákat és a rendszer betűtípus-mappáit.

Ez a C++ kód bemutatja, hogyan használja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Ez a sor kiírja azokat a mappákat, amelyekben a betűtípus fájlok keresése történik.
// Ezek a LoadExternalFonts metóduson keresztül hozzáadott mappák és a rendszer betűtípus mappái.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Egyéni betűtípusok megadása a prezentációhoz**
Aspose.Slides biztosítja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot, amely lehetővé teszi külső betűtípusok megadását, melyek a prezentációval együtt lesznek használva.

Ez a C++ kód bemutatja, hogyan használja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //munka a prezentációval
    //CustomFont1, CustomFont2, valamint az assets\fonts és a global\fonts mappákban és azok almappáiban található betűtípusok elérhetők a prezentáció számára
}
```

## **Betűtípusok külső kezelése**
Aspose.Slides biztosítja a [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfont/) metódust, amely lehetővé teszi a külső betűtípusok betöltését egy bájt tömbbe.

Ez a C++ kód bemutatja a bájt tömb betűtípus betöltési folyamatát:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// A dokumentumok könyvtárának elérési útja
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **GYIK**

### Az egyedi betűtípusok érintik az összes formátumba történő exportálást (PDF, PNG, SVG, HTML)?
Igen. A csatlakoztatott betűtípusokat a renderelő az összes export formátumban használja.

### Az egyedi betűtípusok automatikusan beágyazódnak a keletkezett PPTX-be?
Nem. A betűtípus rendereléshez történő regisztrálása nem ugyanaz, mint a PPTX-be történő beágyazás. Ha a betűtípust a prezentáció fájljában kell tárolni, akkor az explicit [embedding features](/slides/hu/cpp/embedded-font/) segítségét kell igénybe venni.

### Szabályozhatom a helyettesítő viselkedést, ha egy egyedi betűtípus bizonyos glifekkel nem rendelkezik?
Igen. Konfigurálja a [font substitution](/slides/hu/cpp/font-substitution/), a [replacement rules](/slides/hu/cpp/font-replacement/) és a [fallback sets](/slides/hu/cpp/fallback-font/) beállításait, hogy pontosan meghatározza, melyik betűtípust használja a kért glif hiányában.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszer szintjén telepíteném őket?
Igen. Mutasson a saját betűtípus-mappáira, vagy töltse be a betűtípusokat bájt tömbökből. Ez eltávolítja a rendszer betűtípus könyvtárakra való függőséget a konténer képből.

### Mi a helyzet a licencelésével — beágyazhatok bármilyen egyedi betűtípust korlátozás nélkül?
Ön felelős a betűtípus-licenc megfeleléséért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimenetet terjesztené.