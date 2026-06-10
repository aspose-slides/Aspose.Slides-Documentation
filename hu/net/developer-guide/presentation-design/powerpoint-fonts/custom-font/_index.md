---
title: PowerPoint betűkészletek testreszabása .NET-ben
linktitle: Egyedi betűkészlet
type: docs
weight: 20
url: /hu/net/custom-font/
keywords:
- betűkészlet
- egyéni betűkészlet
- külső betűkészlet
- betűkészlet betöltése
- betűkészletek kezelése
- betűkészlet mappa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Testreszabhatja a PowerPoint diák betűkészleteit az Aspose.Slides for .NET segítségével, hogy bemutatói minden eszközön élesek és következetesek legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyedi betűkészleteket használjon a bemutatókban anélkül, hogy telepítené őket a operációs rendszerre. Betűkészleteket tölthet be egyedi mappákból, megadhat betűkészleteket egy adott bemutatóhoz dokumentumszintű betűkészletforrásokkal, vagy külső betűkészleteket tölthet be közvetlenül bináris adatból.

A betöltött betűkészletek használatban vannak, amikor egy bemutatót renderelnek vagy exportálnak, például PDF‑be, képekbe és más támogatott formátumokba. Ez segít a bemutató kimenetét konzisztensnek tartani a különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűkészlet-mappákat, és hogyan törölheti a betűkészlet-gyorsítót a külső betűkészletekkel való munka után.

Az egyedi betűkészletek regisztrálása a rendereléshez különálló a betűkészletek PPTX fájlba ágyazásától. Ha egy betűkészletet a bemutatóban kell tárolni, használja kifejezetten a betűkészlet-embedelés funkcióit.

{{% alert color="primary" %}} 
Az Aspose Slides lehetővé teszi ezen betűkészletek betöltését a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódus használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűkészletek. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) betűkészletek. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Egyedi betűkészletek betöltése**

Az Aspose.Slides lehetővé teszi, hogy betűkészleteket töltsön be egy bemutatóhoz anélkül, hogy azokat a rendszerre telepítené. Ez befolyásolja az export kimenetet – például PDF, képek és egyéb támogatott formátumok – így a kapott dokumentumok minden környezetben egységesek maradnak. A betűkészletek egyedi könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűkészlet-fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűkészletek betöltéséhez ezekből a mappákból.
3. Töltse be és renderelje/exportálja a bemutatót.
4. Hívja meg a [FontsLoader.ClearCache](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/clearcache/) metódust a betűkészlet-gyorsító törléséhez.

A következő kódrészlet bemutatja a betűkészlet betöltésének folyamatát:

```cs
// Határozza meg az egyedi betűkészlet fájlokat tartalmazó mappákat.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Töltse be az egyedi betűkészleteket a megadott mappákból.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderelje/exportálja a bemutatót (például PDF-be, képekbe vagy más formátumokba) a betöltött betűkészletekkel.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Törölje a betűkészlet gyorsítótárát a munka befejezése után.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűkészlet-keresési útvonalakhoz, de nem változtatja meg a betűkészlet inicializálási sorrendjét.
A betűkészletek ebben a sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűkészlet útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyedi betűkészlet-mappák lekérdezése**
Az Aspose.Slides a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust biztosítja, amely lehetővé teszi a betűkészlet-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűkészlet-mappákat.

Ez a C# kód megmutatja, hogyan használja a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust:

```c#
// Ez a sor kiírja azokat a mappákat, amelyekben betűkészlet fájlokat keres.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűkészlet mappái.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **A bemutatóval használt egyedi betűkészletek megadása**
Az Aspose.Slides a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot biztosítja, amely lehetővé teszi, hogy külső betűkészleteket adjon meg, amelyeket a bemutatóval együtt használunk.

Ez a C# kód megmutatja, hogyan használja a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Dolgozzon a bemutatóval
    // A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok almappáiból származó betűkészletek elérhetők a bemutatóban
}
```

## **Betűkészletek külső kezelése**

Az Aspose.Slides a [LoadExternalFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metódust biztosítja, amely lehetővé teszi, hogy külső betűkészleteket töltsön be bináris adatokból.

Ez a C# kód demonstrálja a bájt-tömbös betűkészlet betöltésének folyamatát:

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // a bemutató életciklusa során betöltött külső betűkészlet
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Az egyedi betűkészletek befolyásolják az exportot minden formátumba (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolt betűkészleteket a renderelő használja az összes export formátumban.

**Az egyedi betűkészletek automatikusan beágyazódnak a létrehozott PPTX‑be?**

Nem. A betűkészlet regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be való beágyazása. Ha a betűkészletet a bemutató fájlban kell tárolni, expliciten használni kell a [beágyazási funkciókat](/slides/hu/net/embedded-font/).

**Szabályozhatom a fallback viselkedést, ha egy egyedi betűkészlet bizonyos glypheket hiányol?**

Igen. Konfigurálja a [betűkészlet helyettesítést](/slides/hu/net/font-substitution/), a [helyettesítési szabályokat](/slides/hu/net/font-replacement/) és a [fallback készleteket](/slides/hu/net/fallback-font/) hogy pontosan meghatározza, melyik betűkészletet használja, ha a kért glif hiányzik.

**Használhatok betűkészleteket Linux/Docker konténerekben a rendszer szintű telepítés nélkül?**

Igen. Mutasson a saját betűkészlet-mappáira vagy töltsön be betűkészleteket bájt tömbökből. Ez megszünteti a rendszer betűkészlet könyvtáraira való függőséget a konténer képen.

**Mi van a licenceléssel—beágyazhatok bármilyen egyedi betűkészletet korlátozás nélkül?**

Ön felel a betűkészlet licencelt megfeleléséért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűkészlet EULA‑ját, mielőtt kimeneteket terjesztene.