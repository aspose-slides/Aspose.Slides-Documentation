---
title: Prezentációk megnyitása .NET-ben
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/net/open-presentation/
keywords:
- PowerPoint megnyitása
- prezentáció megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett prezentáció
- nagy prezentáció
- külső erőforrás
- bináris objektum
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat C#‑ban, adjon meg megnyitási jelszavakat, szabályozza az erőforrás betöltést, és csökkentse a memóriahasználatot az Aspose.Slides for .NET‑vel."
---
## **Bevezetés**

[Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) betöltheti a PowerPoint és OpenDocument prezentációkat fájlokból és adatfolyamokból. Miután egy prezentáció betöltésre került, megvizsgálhatja annak felépítését, szerkesztheti a diákat, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályon keresztül. Például megadhat egy megnyitási jelszót, a nagy bináris objektumokat a kezelt memória kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Fájl vagy adatfolyam betöltése után [meghatározhatja az eredeti prezentáció formátumát](/slides/hu/net/detect-presentation-source-format/), hogy kiválaszthassa, alkalmazása hogyan dolgozza fel.

Egy meglévő prezentáció megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorának. Használat után szabadítsa fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi C# példa bemutatja, hogyan nyithat meg egy prezentációt és szerezheti meg a diák számát:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Jelszóval védett prezentációk megnyitása**

A megnyitási jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez állítsa be a megfelelő jelszót a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) tulajdonságba, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

A jelszó detektálásához, ellenőrzéséhez és titkosítási munkafolyamatokhoz lásd a [Password-Protect Presentations](/slides/hu/net/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/net/presentation-properties/) részt.

## **Nagy prezentációk megnyitása**

A [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/blobmanagementoptions/) szabályozza, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt zárolva tarthatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatmennyiséget.

Az alábbi C# kód bemutatja egy nagy prezentáció (például 2 GB) betöltését:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KeepLocked` használatával a forrásfájl zárolva marad, amíg a `Presentation` objektumot el nem engedik. Ne mozgassa, felülírja vagy törölje a forrásfájlt, amíg az objektum él.

Az Aspose.Slides betöltéskor másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonala általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/net/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások kezelése**

A [LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/resourceloadingcallback/) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iresourceloadingcallback/) megvalósítást fogad el. A callback helyettesítő adatokat szolgáltathat, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

A prezentáció beágyazott bináris adatokat tartalmazhat, amelyeket egy alkalmazás nem igényel vagy nem kíván megtartani. Példák:

- VBA projektek, elérhetők a [IPresentation.VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/vbaproject/) segítségével;
- beágyazott OLE adatok, elérhetők a [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) segítségével;
- ActiveX vezérlő adatok, elérhetők a [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hu/net/aspose.slides/icontrol/activexcontrolbinary/) segítségével.

Állítsa a [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) értékét `true`-ra a bináris adatok betöltés közbeni eltávolításához. Mentse el a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nem kívánt beágyazott payloadok kitettségét, de nem teljes körű rosszindulatú programok detektálási vagy tartalom-tisztítási rendszer.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides a betöltés során parsing vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a renderelés és export betűtípus helyettesítést alkalmazhat. [Betűtípus-helyettesítés beállítása](/slides/hu/net/font-substitution/) vagy [Egyéni betűtípusok biztosítása](/slides/hu/net/custom-font/) segítségével teheti kimenetét előrejelezhetőbbé.

**A prezentáció betöltése egyben betölti a beágyazott médiát is?**

A beágyazott hang és videó a prezentáció objektummodelljén keresztül lesz elérhető. A külső erőforrások a konfigurált erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha azok helyei nem hozzáférhetők.