---
title: PowerPoint betűtípusok testreszabása C++-ban
linktitle: Egyedi betűtípus
type: docs
weight: 20
url: /hu/cpp/custom-font/
keywords:
- betűtípus
- egyedi betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabhatja a betűtípusokat a PowerPoint diákon az Aspose.Slides for C++ segítségével, hogy prezentációi élesek és következetesek legyenek bármilyen eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyedi betűtípusokat használjon a prezentációkban anélkül, hogy azokat az operációs rendszerbe telepítené. Betűtípusokat tölthet be egyéni mappákból, egy adott prezentációhoz megadhat betűtípusokat a dokumentumszintű betűtípusforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy prezentációt renderelnek vagy exportálnak, például PDF‑be, képekbe és egyéb támogatott formátumokba. Ez segít abban, hogy a prezentáció kimenete egységes maradjon különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus‑mappákat, és hogyan törölheti a betűtípus‑gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX‑fájlba való beágyazásától. Ha a betűtípust a prezentációban kell tárolni, használja a betűtípus beágyazási funkciókat kifejezetten.

{{% alert color="info" %}} 

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd az [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációban használt betűtípusokat betöltsön a rendszerbe való telepítés nélkül. Ez befolyásolja az export kimenetet – például PDF, képek és egyéb támogatott formátumok – így a létrehozott dokumentumok környezetfüggetlenül konzisztensnek tűnnek. A betűtípusok egyéni könyvtárakból kerülnek betöltésre.

1. Adjon meg egy vagy több mappát, amely a betűtípus‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) metódust, hogy betöltse a betűtípusokat ezekből a mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/clearcache/) metódust a betűtípus‑gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűtípusok betöltésének folyamatát:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Töltse be az egyéni betűtípusokat a megadott mappákból.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF, képek vagy egyéb formátumok) a betöltött betűtípusokkal.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Törölje a betűtípus gyorsítótárát, miután a munka befejeződött.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem módosítja a betűtípusok inicializálási sorrendjét. A betűtípusok a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus‑mappák lekérése**
Az Aspose.Slides biztosítja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust, amely lehetővé teszi a betűtípus‑mappák keresését. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus‑mappákat.

Ez a C++ kód megmutatja, hogyan használja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Ez a sor kiírja azokat a mappákat, amelyekben a betűtípus fájlokat ellenőrzik.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappái.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Egyéni betűtípusok megadása a prezentációhoz**
Az Aspose.Slides biztosítja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot, amely lehetővé teszi, hogy megadja azokat a külső betűtípusokat, amelyeket a prezentációval együtt használni kíván.

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
    //A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok alkönyvtáraiból származó betűtípusok elérhetők a prezentáció számára
}
```

## **Betűtípusok kezelése külsőleg**
Az Aspose.Slides biztosítja a [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfont/) metódust, amely lehetővé teszi a külső betűtípusok betöltését egy byte‑tömbbe.

Ez a C++ kód bemutatja a byte‑tömbös betűtípus betöltésének folyamatát:

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

### A saját betűtípusok befolyásolják az exportot minden formátumba (PDF, PNG, SVG, HTML)?

Igen. A kapcsolt betűtípusokat a renderelő az összes export formátumban használja.

### A saját betűtípusok automatikusan beágyazódnak a létrehozott PPTX‑be?

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be ágyazás. Ha a betűtípust a prezentáció fájlban szeretné tárolni, kifejezetten a [beágyazási funkciókat](/slides/hu/cpp/embedded-font/) kell használnia.

### Vezérelhetem a fallback (helyettesítő) viselkedést, ha egy egyedi betűtípus nincs meg bizonyos glifekkel?

Igen. Konfigurálja a [betűtípus helyettesítést](/slides/hu/cpp/font-substitution/), a [csere szabályokat](/slides/hu/cpp/font-replacement/), és a [fallback készleteket](/slides/hu/cpp/fallback-font/) annak meghatározásához, hogy pontosan melyik betűtípus legyen használva, ha a kért glif hiányzik.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy telepíteném őket a rendszerre?

Igen. Mutasson a saját betűtípus‑mappáira vagy töltse be a betűtípusokat byte‑tömbökből. Ez eltávolítja a rendszer‑betűtár‑könyvtárakra való függőséget a konténer képből.

### Mi van a licenceléssel—beágyazhatok bármilyen egyedi betűtípust korlátozások nélkül?

Ön felelős a betűtípus licencelésének betartásáért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.