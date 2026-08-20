---
title: PPT konvertálása PPTX-re .NET-ben
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a régi PPT fájlokat PPTX-re .NET-ben az Aspose.Slides segítségével. Tartalmaz C# példákat egyetlen fájl és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for .NET képes betölteni egy PPT fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPointra lenne szükség. Ez a cikk bemutatja, hogyan konvertálhat egy fájlt vagy egy könyvtárban lévő fájlok halmazát, és elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX‑re**

Töltsük be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal, majd hívjuk meg a [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) argumentummal. A `using` deklaráció felszabadítja a prezentációt és elengedi annak erőforrásait, amikor a hatókör véget ér.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Töltsd be az örökölt PPT prezentációt.
using var presentation = new Presentation("presentation.ppt");

// Mentsd el a prezentációt PPTX formátumban.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

A fájlkiterjesztés önmagában nem választja ki a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) argumentum határozza meg. Tartsa külön a bemeneti és kimeneti útvonalakat, ha az eredeti PPT fájlt meg szeretné őrizni.

## **Több PPT fájl konvertálása**

Az alábbi példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja le a többi batch‑et.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Éles környezetben naplózzuk a teljes kivételt, döntsük el, felülírható-e egy már létező kimeneti fájl, és írjuk a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok a szükséges jelszó nélkül megnyitva, elérhetetlen útvonalak és nem támogatott tartalom mind egy konverziósikert okozhatnak. Lásd a [Password-Protected Presentations](/slides/hu/net/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diakat, mester-diákat, elrendezéseket, szöveget, alakzatokat, képeket, táblázatokat és diagramokat. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, elhagyható vagy másként jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makró‑engedélyezett formátum, ezért használjon megfelelő makró‑engedélyezett munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Továbbá ellenőrizze, hogy a szükséges betűtípusok és külső erőforrások jelen vannak‑e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy renderelik.

Fontos dokumentumok esetén nyissa meg programozottan a létrehozott PPTX-et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze annak megjelenését és diavetítés viselkedését a célzott megjelenítőben. Ne tekintse a sikeres [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjunk PPTX‑et**

Használjon PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerek között cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszagörgetési másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szükség, akkor használja a [Convert Presentations to Multiple Formats](/slides/hu/net/convert-presentation/) formátumspecifikus útmutatót, ahelyett, hogy azt feltételezné, hogy minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konvertáló**

Egy alkalmi fájl vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hiba kezeléshez használja a .NET API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/net/ppt-vs-pptx/)
- [Prezentációk mentése .NET‑ben](/slides/hu/net/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/net/supported-file-formats/)
- [Prezentációk megnyitása .NET‑ben](/slides/hu/net/open-presentation/)

## **GYIK**

**Átkonvertálhatom a PPT‑t PPTX‑re anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for .NET betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ről PPTX‑re történő konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a szokásos prezentációs tartalmakat, de az pontos pontosság nem garantált minden örökölt vagy nem támogatott funkcióra vonatkozóan. Tekintse át a létrehozott fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a megfelelő jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés meghiúsul.

**Töröljem a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg le nem ellenőrizte a PPTX‑et a Önnek fontos nézőkben és munkafolyamatokban. Ez visszagörgetési másolatot biztosít, ha egy örökölt funkció másként konvertálódik.