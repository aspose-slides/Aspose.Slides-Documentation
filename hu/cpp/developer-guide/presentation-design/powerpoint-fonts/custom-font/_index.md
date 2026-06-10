---
title: PowerPoint betűtípusok testreszabása С++-ban
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
- С++
- Aspose.Slides
description: "Testreszabott betűtípusok PowerPoint diákon az Aspose.Slides for С++ segítségével, hogy a bemutatók minden eszközön élesek és konzisztens megjelenésűek legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a prezentációkban anélkül, hogy azokat a operációs rendszerre telepítené. Betűtípusokat tölthet be egyéni mappákból, betűtípusokat biztosíthat egy adott prezentációhoz dokumentumszintű betűtípusforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy prezentációt renderelnek vagy exportálnak, például PDF, képek és más támogatott formátumok esetén. Ez segít a prezentációk kimenetének konzisztens maradásában különböző környezetekben. A cikk továbbá bemutatja, hogyan lehet megvizsgálni az Aspose.Slides által használt betűtípus-mappákat, és hogyan lehet törölni a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különálló a betűtípusok PPTX-fájlba ágyazásától. Ha egy betűtípust magában a prezentációban kell tárolni, expliciten használja a betűtípus-ágyazási funkciókat.

{{% alert color="primary" %}} 

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Aspose.Slides lehetővé teszi a prezentációban használt betűtípusok betöltését anélkül, hogy a rendszeren telepítené őket. Ez befolyásolja az exportált kimenetet – például PDF, képek és más támogatott formátumok – így a kész dokumentumok környezetek között konzisztensen jelennek meg. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípus fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez ezekből a mappákból.
3. Töltsön be és rendereljen/exportáljon egy prezentációt.
4. Hívja a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/clearcache/) metódust a betűtípus-gyorsítótörléshez.

A következő kódrészlet bemutatja a betűtípus betöltési folyamatát:

```cpp
// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF-re, képekre vagy más formátumokra) a betöltött betűtípusok használatával.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Törölje a betűtípus-gyorsítót a munka befejezése után.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) az extra mappákat adja a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípus inicializálási sorrendjét.
Betűtípusok ebben a sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonal.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) segítségével betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus-mappák lekérése**
Aspose.Slides biztosítja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust, amely lehetővé teszi, hogy megtalálja a betűtípus-mappákat. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat, valamint a rendszer betűtípus-mappákat.

Ez a C++ kód megmutatja, hogyan kell használni a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust:

``` cpp
// Ez a sor kiírja azokat a mappákat, amelyeket betűtípus fájlok keresésére ellenőriznek.
// Ezek a LoadExternalFonts metódus által hozzáadott mappák és a rendszer betűtípus mappái.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Egy prezentációval használt egyéni betűtípusok megadása**
Aspose.Slides biztosítja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot, amely lehetővé teszi, hogy külső betűtípusokat adjon meg a prezentációhoz.

Ez a C++  kód megmutatja, hogyan kell használni a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //munka a prezentációval
    //A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappák és almappáik betűtípusai elérhetők a prezentáció számára
}
```

## **Betűtípusok külső kezelése**
Aspose.Slides biztosítja a [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfont/) metódust, amely lehetővé teszi külső betűtípusok betöltését egy bájt tömbbe.

Ez a C++ kód demonstrálja a bájt tömbös betűtípus betöltési folyamatot:

```cpp
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

**Hatással vannak az egyéni betűtípusok az összes formátum exportjára (PDF, PNG, SVG, HTML)?**

Igen. A csatlakoztatott betűtípusokat a renderelő minden export formátumnál használja.

**Ágyazódnak‑e automatikusan az egyéni betűtípusok a létrejövő PPTX‑be?**

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a betűtípus PPTX‑be ágyazása. Ha a betűtípust a prezentáció fájlon belül kell hordozni, explicit módon a [beágyazási funkciókat](/slides/hu/cpp/embedded-font/) kell használni.

**Irányíthatom a visszalépési viselkedést, ha egy egyéni betűtípus bizonyos glifek hiányoznak?**

Igen. Konfigurálja a [betűtípus helyettesítést](/slides/hu/cpp/font-substitution/), a [helyettesítő szabályokat](/slides/hu/cpp/font-replacement/) és a [fallback készleteket](/slides/hu/cpp/fallback-font/) beállításait, hogy pontosan meghatározza, melyik betűtípust kell használni, ha a kért glif hiányzik.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszer szinten telepíteném őket?**

Igen. Mutasson a saját betűtípus‑mappáira vagy töltse be a betűtípusokat bájt tömbökből. Ez eltávolítja a konténer képből a rendszer betűtárakra való függőséget.

**Mi a helyzet a licenceléssel – ágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**

Ön felelős a betűtípus licencelésének betartásáért. A feltételek változóak; egyes licencek tilthatják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimenetet közzétenné.