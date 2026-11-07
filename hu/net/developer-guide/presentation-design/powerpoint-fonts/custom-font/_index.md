---
title: PowerPoint betűtípusok testreszabása .NET-ben
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/net/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Testreszabhatja a betűtípusokat a PowerPoint diákon az Aspose.Slides for .NET segítségével, hogy prezentációi élesek és konzisztensék legyenek minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyéni betűtípusokat használjon a prezentációkban anélkül, hogy azokat az operációs rendszerre telepítené. Betűtípusokat betölthet egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz dokumentumszintű betűtípusforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor a prezentációt renderelik vagy exportálják, például PDF‑be, képekbe és más támogatott formátumokba. Ez segít abban, hogy a prezentáció kimenete különböző környezetekben is konzisztens maradjon. A cikk bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus‑mappákat, illetve hogyan törölheti a betűtípus‑gyorsítótárat, miután külső betűtípusokkal dolgozott.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok beágyazásától egy PPTX fájlba. Ha egy betűtípust magában a prezentációban kell tárolni, használja a betűtípus‑beágyazási funkciókat kifejezetten.

Egy prezentáció témája különböző betűtípus‑családokat hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések csak a betűtípus neveket tárolják, de nem telepítik vagy töltik be a betűtípus‑fájlokat. Tekintse meg a [Script‑Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat, hogy a hivatkozott betűtípusok elérhetőek legyenek a konzisztens rendereléshez.

{{% alert color="info" title="Note" %}}
Aspose Slides lehetővé teszi, hogy ezeket a betűtípusokat a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) metódussal töltse be:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.
{{% /alert %}}

## **Egyéni Betűtípusok Betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűtípusokat a rendszerre telepítés nélkül töltse be. Ez a beállítás az exportkimenetet – például PDF‑et, képeket és más támogatott formátumokat – érinti, így a létrehozott dokumentumok minden környezetben egységesen néznek ki. A betűtípusok egyedi könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.  
2. Hívja meg a statikus [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez az adott mappákból.  
3. Töltse be és renderelje/exportálja a prezentációt.  
4. Hívja a [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) metódust a betűtípus‑gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűtípus‑betöltési folyamatot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Határozza meg az egyéni betűtípusfájlokat tartalmazó mappákat.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderelje/exportálja a prezentációt (pl. PDF‑be, képekbe vagy más formátumokba) a betöltött betűtípusok használatával.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Törölje a betűtípus-gyorsítótárat, miután a munka befejeződött.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálási sorrendet.  
A betűtípusok a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípusútvonal.  
1. A [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni Betűtípus Mappák Lekérése**

Az Aspose.Slides a [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) metódussal teszi lehetővé, hogy megtalálja a betűtípus‑mappákat. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat és a rendszer betűtípus‑mappákat.

Ez a C# kód megmutatja, hogyan használja a [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) metódust:

```c#
using Aspose.Slides;

// Ez a sor a betűtípusfájlok ellenőrzéséhez használt mappákat adja ki.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappák.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **A Prezentációval Használt Egyéni Betűtípusok Megadása**

Az Aspose.Slides a [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot biztosítja, amely lehetővé teszi, hogy megadja a prezentációval használandó külső betűtípusokat.

Ez a C# kód megmutatja, hogyan használja a [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Munkáljon a prezentációval
    // A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok almappáiból származó betűtípusok elérhetők a prezentáció számára
}
```

## **Betűtípusok Kezelése Külsőleg**

Az Aspose.Slides a [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metódust biztosítja, amely lehetővé teszi, hogy külső betűtípusokat töltsön be bináris adatokból.

Ez a C# kód bemutatja a bájt‑tömb alapú betűtípus‑betöltési folyamatot:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // külső betűtípus betöltve a prezentáció élettartama alatt
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

A regisztrált betűtípusnak az export során való előnyben részesítéséhez, anélkül hogy a beágyazott betűtípust eltávolítaná, tekintse meg a [Prefer Registered Fonts over Embedded Fonts](/slides/hu/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) oldalt (.NET 26.11 vagy újabb).

## **GYIK**

**A saját betűtípusok befolyásolják az összes formátumba (PDF, PNG, SVG, HTML) történő exportot?**  
Igen. A csatlakoztatott betűtípusok a renderelő által minden exportformátumba felhasználásra kerülnek.

**A saját betűtípusok automatikusan be vannak ágyazva a létrejövő PPTX‑be?**  
Nem. Egy betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be ágyazása. Ha a betűtípust a prezentációs fájlban kell tárolni, használja a kifejezett [beágyazási funkciókat](/slides/hu/net/embedded-font/).

**Szabályozhatom a visszaesés (fallback) viselkedését, ha egy egyéni betűtípus hiányos karakterekkel rendelkezik?**  
Igen. Konfigurálja a [betűtípus‑helyettesítést](/slides/hu/net/font-substitution/), a [helyettesítési szabályokat](/slides/hu/net/font-replacement/) és a [fallback készleteket](/slides/hu/net/fallback-font/), hogy pontosan meghatározza, melyik betűtípus kerül felhasználásra, ha a kért karakter hiányzik.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszerszinten telepíteném őket?**  
Igen. Hivatkozhat saját betűtípus‑mappákra vagy betöltheti a betűtípusokat bájt‑tömbökből. Ez eltávolítja a rendszer‑betűtár‑könyvtárakra való függőséget a konténer‑képből.

> **Megjegyzés Linux/Docker esetén**: A `FontsLoader.LoadExternalFonts` hívásakor biztosítsa, hogy a `directories` tömb minden eleme egy nem üres, létező könyvtárra mutató elérési utat tartalmazzon. Ha egy környezeti változó, amely a betűtípus‑úthoz van használva, nincs definiálva vagy üres, az Aspose.Slides megpróbálhatja a üres értéket teljes elérési útként feloldani, ami `System.ArgumentException` kivételt eredményez.

**Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**  
Ön felelős a betűtípus‑licencelés betartásáért. A licencfeltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.