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
description: "Testreszabja a betűtípusokat PowerPoint diákon az Aspose.Slides C++ verziójával, hogy prezentációi élesek és konzisztensak legyenek bármilyen eszközön."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a prezentációkban a betűtípusok operációs rendszerre való telepítése nélkül. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz a dokumentumszintű betűtípus források segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

Az betöltött betűtípusok felhasználásra kerülnek a prezentáció renderelésekor vagy exportálásakor, például PDF, képek és más támogatott formátumok esetén. Ez segít a prezentációk kimenetének konzisztens megtartásában különböző környezetekben. A cikk emellett bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus mappákat, valamint hogyan törölheti a betűtípus gyorsítótárát a külső betűtípusok használata után.

A betűtípusok rendereléshez való regisztrálása különálló a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust a prezentációban kell tárolni, használja kifejezetten a betűtípus ágyazási funkciókat.

{{% alert color="primary" %}} 

Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) betűtípusok. Lásd [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Aspose.Slides lehetővé teszi a prezentációban használt betűtípusok betöltését anélkül, hogy telepítené őket a rendszerre. Ez befolyásolja az exportkimenetet – például PDF, képek és más támogatott formátumok –, így a létrehozott dokumentumok konzisztensnek mutatnak különböző környezetekben. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.  
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez az adott mappákból.  
3. Töltse be és renderelje/exportálja a prezentációt.  
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/clearcache/) metódust a betűtípus gyorsítótár törléséhez.

A következő kódrészlet bemutatja a betűtípus betöltés folyamatát:

```cpp
// Határozz meg mappákat, amelyek egyedi betűtípus fájlokat tartalmaznak.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Tölts be egyedi betűtípusokat a megadott mappákból.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusok használatával.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Törölje a betűtípus gyorsítótárát a munka befejezése után.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

A [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus keresési útvonalakhoz, de nem változtatja meg a betűtípus inicializációs sorrendjét.
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus útvonala.  
1. A [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus mappák lekérése**
Aspose.Slides biztosítja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust, amely lehetővé teszi a betűtípus mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metóduson keresztül hozzáadott mappákat és a rendszer betűtípus mappákat.

A következő C++ kód megmutatja, hogyan használhatja a [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/getfontfolders/) metódust:

``` cpp
// Ez a sor kiírja a betűtípusfájlok kereséséhez ellenőrzött mappákat.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappái.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Egyéni betűtípusok megadása egy prezentációhoz**
Aspose.Slides biztosítja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot, amely lehetővé teszi külső betűtípusok megadását, amelyeket a prezentáció használni fog.

A következő C++ kód megmutatja, hogyan használhatja a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) tulajdonságot:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // dolgozz a prezentációval
    // A CustomFont1, CustomFont2, valamint az assets\fonts és a global\fonts mappákból (és azok alkönyvtáraiból) származó betűtípusok elérhetők a prezentáció számára
}
```

## **Betűtípusok kezelése külső forrásból**
Aspose.Slides biztosítja a [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfont/) metódust, amely lehetővé teszi a külső betűtípusok betöltését egy bájt tömbbe.

A következő C++ kód bemutatja a bájt tömb betűtípus betöltés folyamatát:

```cpp
// A dokumentumok könyvtárának útvonala
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

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**  
Igen. A csatlakoztatott betűtípusokat a renderelő használja minden export formátumban.

**Are custom fonts automatically embedded into the resulting PPTX?**  
Nem. A betűtípus rendereléshez való regisztrálása nem ugyanaz, mint a PPTX-be való ágyazás. Ha a betűtípust a prezentáció fájlba kell ágyazni, akkor kifejezetten a [embedding features](/slides/hu/cpp/embedded-font/) funkciót kell használni.

**Can I control fallback behavior when a custom font lacks certain glyphs?**  
Igen. Állítsa be a [font substitution](/slides/hu/cpp/font-substitution/), a [replacement rules](/slides/hu/cpp/font-replacement/) és a [fallback sets](/slides/hu/cpp/fallback-font/) beállításokat, hogy pontosan meghatározza, melyik betűtípus legyen használva, ha a kért glif hiányzik.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**  
Igen. Mutasson a saját betűtípus mappáira vagy töltse be a betűtípusokat bájt tömbökből. Ez eltávolítja a függőséget a konténer kép rendszer betűtípus könyvtáraira.

**What about licensing—can I embed any custom font without restrictions?**  
Ön felelős a betűtípus licencelésének betartásáért. A feltételek változóak; egyes licencek tilthatják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA-ját, mielőtt a kimeneteket terjesztené.