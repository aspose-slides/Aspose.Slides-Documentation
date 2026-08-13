---
title: Testreszabott PowerPoint betűtípusok .NET-ben
linktitle: Egyedi betűtípus
type: docs
weight: 20
url: /hu/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Aspose.Slides for .NET segítségével, hogy prezentációi élesek és következetesek legyenek bármely eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyéni betűtípusokat használjon bemutatókban anélkül, hogy azokat telepítené az operációs rendszerre. Betűtípusokat tölthet be egyéni mappákból, dokumentumszintű betűtípus‑forrásokkal adhat meg betűtípusokat egy adott bemutatóhoz, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok a prezentáció megjelenítésekor vagy exportálásakor kerülnek felhasználásra, például PDF‑hez, képekhez és egyéb támogatott formátumokhoz. Ez segít a kimenet egységességében a különböző környezetek között. A cikk bemutatja, hogyan vizsgálhatja meg az Aspose.Slides által használt betűtípus‑mappákat, valamint hogyan törölheti a betűtípus‑gyorsítót külső betűtípusok használata után.

A betűtípusok regisztrálása a megjelenítéshez különálló a betűtípusok PPTX‑fájlba ágyazásától. Ha egy betűtípust magában a bemutatóban kell tárolni, használja kifejezetten a betűtípus‑ágyazási funkciókat.

{{% alert color="info" %}} 

Az Aspose Slides a következő módszerrel tölti be ezeket a betűtípusokat: [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd: [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) betűtípusok. Lásd: [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy betöltse a prezentációban használt betűtípusokat anélkül, hogy azokat a rendszerre telepítené. Ez hatással van az exportálási kimenetre – például PDF‑re, képekre és egyéb támogatott formátumokra – így a létrehozott dokumentumok környezetfüggetlenül egységesek maradnak. A betűtípusok egyéni könyvtárakból kerülnek betöltésre.

1. Adjon meg egy vagy több könyvtárat, amely a betűtípus‑fájlokat tartalmazza.  
2. Hívja meg a statikus [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez az adott könyvtárakból.  
3. Töltse be és jelenítse meg/exportálja a prezentációt.  
4. Hívja meg a [FontsLoader.ClearCache](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/clearcache/) metódust a betűtípus‑gyorsítótörléshez.

Az alábbi kódpélda bemutatja a betűtípusok betöltési folyamatát:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Határozza meg az egyéni betűtípusfájlokat tartalmazó mappákat.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF-hez, képekhez vagy más formátumokhoz) a betöltött betűtípusok használatával.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Törölje a betűtípus-gyorsítót a munka befejezése után.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Megjegyzés" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálás sorrendjét.  
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus‑útvonala.  
1. A [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/)-en keresztül betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus‑mappák lekérése**

Az Aspose.Slides a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust biztosítja a betűtípus‑mappák megtalálásához. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat és a rendszer betűtípus‑mappákat.

Az alábbi C# kód bemutatja, hogyan használja a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust:

```c#
using Aspose.Slides;

// Ez a sor kiírja azokat a mappákat, amelyekben a betűtípusfájlok keresése történik.
// Ezek a LoadExternalFonts metódus által hozzáadott mappák és a rendszer betűtípusmappái.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Egyéni betűtípusok megadása egy prezentációhoz**

Az Aspose.Slides a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot biztosítja, amely lehetővé teszi külső betűtípusok megadását a prezentációhoz.

Az alábbi C# kód bemutatja a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonság használatát:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Dolgozz a prezentációval
    // A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok almappáiból származó betűtípusok a prezentáció számára elérhetők
}
```

## **Betűtípusok kezelése külsőleg**

Az Aspose.Slides a [LoadExternalFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metódust kínálja, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Az alábbi C# kód bemutatja a bájt‑tömb alapú betűtípus‑betöltést:

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

## **GyIK**

**A egyéni betűtípusok hatással vannak az összes formátumra (PDF, PNG, SVG, HTML) történő exportálásra?**

Igen. A csatlakoztatott betűtípusokat a renderelő minden export‑formátumban felhasználja.

**A egyéni betűtípusok automatikusan beágyazódnak a létrehozott PPTX‑be?**

Nem. A betűtípus regisztrálása a megjelenítéshez nem ugyanaz, mint a PPTX‑be ágyazása. Ha a betűtípust a prezentáció fájljába kell helyezni, használja a kifejezett [beágyazási funkciókat](/slides/hu/net/embedded-font/).

**Kontrollálhatom a hibakereső viselkedést, ha egy egyéni betűtípusból hiányoznak bizonyos glifek?**

Igen. Állítsa be a [betűtípus‑helyettesítést](/slides/hu/net/font-substitution/), a [helyettesítési szabályokat](/slides/hu/net/font-replacement/) és a [fallback‑készleteket](/slides/hu/net/fallback-font/) a hiányzó glif esetén használandó betűtípus pontos meghatározásához.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy telepíteném őket a rendszer egészére?**

Igen. Hivatkozhat saját betűtípus‑mappáira vagy betöltheti a betűtípusokat bájt‑tömbökből. Ez megszünteti a rendszer‑betűtípus‑könyvtárakra való függőséget a konténer‑képen belül.

> **Megjegyzés Linux/Docker esetén**: A `FontsLoader.LoadExternalFonts` hívásakor győződjön meg arról, hogy a `directories` tömb minden eleme nem üres útvonalat tartalmaz egy létező könyvtárra mutatva. Ha egy környezeti változó, amely a betűtípus‑útvonalat építi, nincs definiálva vagy üres, az Aspose.Slides megpróbálhatja az üres értéket teljes útvonalként feloldani, ami `System.ArgumentException`‑t eredményezhet.

**Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**

Ön felelős a betűtípus‑licenc megfelelőségéért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimenetet terjesztené.