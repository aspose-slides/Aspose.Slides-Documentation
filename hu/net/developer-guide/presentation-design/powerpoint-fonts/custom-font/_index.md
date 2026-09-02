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
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Aspose.Slides for .NET segítségével, hogy bemutatói élesek és konzisztens megjelenést biztosítsanak minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a bemutatókban anélkül, hogy telepítené őket az operációs rendszerre. Betűtípusokat tölthet be egyéni mappákból, biztosíthat betűtípusokat egy adott bemutatóhoz dokumentumszintű betűtípusforrásokon keresztül, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy bemutatót renderelnek vagy exportálnak, például PDF-be, képekbe és más támogatott formátumokba. Ez segít a bemutató kimenetét konzisztens módon megtartani a különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus-mappákat, és hogyan törölheti a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez elkülönül a betűtípusok PPTX fájlba történő beágyazásától. Ha egy betűtípust a bemutatóba kell beágyazni, használja a betűtípus-beágyazási funkciókat kifejezetten.

{{% alert color="primary" %}} 
Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.
{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a bemutatóban használt betűtípusokat a rendszerre való telepítés nélkül töltse be. Ez befolyásolja az export kimenetet – például PDF, képek és más támogatott formátumok – így a létrehozott dokumentumok minden környezetben egységesnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok ezektől a mappáktól történő betöltéséhez.
3. Töltsön be és rendereljen/exportáljon a bemutatót.
4. Hívja meg a [FontsLoader.ClearCache](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/clearcache/) metódust a betűtípus-gyorsítót törléséhez.

Az alábbi kódrészlet bemutatja a betűtípus betöltési folyamatát:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Határozza meg a mappákat, amelyek egyéni betűtípus fájlokat tartalmaznak.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderelje/exportálja a bemutatót (például PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusokkal.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Törölje a betűtípus-gyorsítót a munka befejezése után.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípusok inicializálási sorrendjét.
A betűtípusok a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.
2. A [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípus mappák lekérése**
Az Aspose.Slides a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust biztosítja, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metóduson keresztül hozzáadott mappákat és a rendszer betűtípus-mappákat.

Ez a C# kód bemutatja, hogyan kell használni a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust:

```c#
using Aspose.Slides;

// Ez a sor kiírja azokat a mappákat, amelyeket a betűtípus fájlok ellenőrzésére használnak.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappái.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Megadni a bemutatóval együtt használandó egyéni betűtípusokat**
Az Aspose.Slides a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot biztosítja, amely lehetővé teszi a bemutatóval együtt használandó külső betűtípusok megadását.

Ez a C# kód bemutatja, hogyan kell használni a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Munka a bemutatóval
    // A CustomFont1, CustomFont2, valamint az assets\fonts és global\fonts mappákból és azok alkönyvtáraiból származó betűtípusok elérhetők a bemutatóhoz
}
```

## **Betűtípusok külső kezelése**
Az Aspose.Slides a [LoadExternalFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metódust biztosítja, amely lehetővé teszi a külső betűtípusok bináris adatokból való betöltését.

Ez a C# kód bemutatja a bájt tömbből történő betűtípus betöltési folyamatot: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // külső betűtípus betöltve a bemutató élettartama alatt
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **GYIK**

**A egyéni betűtípusok befolyásolják az összes formátumba (PDF, PNG, SVG, HTML) történő exportálást?**  

Igen. A csatlakoztatott betűtípusokat a renderelő minden export formátumban használja.

**Az egyéni betűtípusok automatikusan be vannak ágyazva a létrehozott PPTX‑be?**  

Nem. A betűtípus rendereléshez való regisztrálása nem ugyanaz, mint a PPTX‑be történő beágyazás. Ha a betűtípust a bemutató fájlba szeretné beágyazni, használja a kifejezett [embedding features](/slides/hu/net/embedded-font/) funkciókat.

**Kezelhetem a helyettesítő viselkedést, ha egy egyéni betűtípus bizonyos glifekkel nem rendelkezik?**  

Igen. Állítsa be a [font substitution](/slides/hu/net/font-substitution/), [replacement rules](/slides/hu/net/font-replacement/) és [fallback sets](/slides/hu/net/fallback-font/) lehetőségeket, hogy pontosan meghatározza, melyik betűtípus legyen használva, ha a kért glif hiányzik.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszerszintű telepítést végeznék?**  

Igen. Mutasson saját betűtípus-mappákra vagy töltse be a betűtípusokat bájt tömbökből. Ez eltávolítja a függőséget a konténerkép rendszerbetűtár könyvtárairól.

> **Megjegyzés Linux/Docker esetén**: `FontsLoader.LoadExternalFonts` hívásakor győződjön meg arról, hogy a `directories` tömb minden eleme nem üres úttal rendelkezik egy létező könyvtárra. Ha a betűtípus útvonal létrehozásához használt környezeti változó nincs definiálva vagy üres, az Aspose.Slides megpróbálhatja az üres értéket teljes útként feloldani, ami `System.ArgumentException` hibát eredményez.

**Mi van a licenceléssel—beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**  

Ön felelős a betűtípus-licenceléssel való megfelelésért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.