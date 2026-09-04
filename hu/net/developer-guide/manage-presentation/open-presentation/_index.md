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
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat C#-ban, adhat meg nyitó jelszavakat, szabályozhatja az erőforrások betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

[Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. A prezentáció betöltése után ellenőrizheted a felépítését, szerkesztheted a diákat, kezelheted az erőforrásokat, és mentheted az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályon keresztül. Például megadhatsz nyitó jelszót, nagy bináris objektumokat tarthat a kezelt memórián kívül, szabályozhatod a külső erőforrásokat, vagy kihagyhatod a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához add meg a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorának. A használat után használd a `Dispose`‑t, hogy a fájlkezelők, átmeneti adatok és egyéb erőforrások időben felszabaduljanak.

Az alábbi C# példa bemutatja, hogyan nyithatsz meg egy prezentációt és érheted el a diák számát:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez állítsd be a megfelelő jelszót a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) tulajdonságra, majd add át az opciókat a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorának. A betöltés hibázik, ha a jelszó hiányzik vagy helytelen.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

A jelszó felismerésével, érvényesítésével és titkosítási munkafolyamataival kapcsolatos információkért lásd a [Password-Protect Presentations](/slides/hu/net/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentették, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/net/presentation-properties/) oldalt.

## **Nagy prezentációk megnyitása**

A [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/blobmanagementoptions/) szabályozza, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. Megtarthatod a forrásfájlt zárolva, engedélyezheted az ideiglenes fájlok létrehozását, és korlátozhatod a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi C# kód egy nagy prezentáció betöltését mutatja be (például 2 GB):

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

A `PresentationLockingBehavior.KeepLocked` használatával a forrásfájl zárolva marad, amíg a `Presentation` objektum életben van. Ne mozgasd, írj felül vagy töröld a forrásfájlt, amíg az objektum létezik.

Az Aspose.Slides betöltéskor másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén általában hatékonyabb a fájl útvonalat használni, mint az adatfolyamot. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/net/manage-blob/) oldalt.

{{% /alert %}}

## **Külső erőforrások vezérlése**

A [LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/resourceloadingcallback/) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iresourceloadingcallback/) implementációt fogad. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazásbiztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre az alkalmazásnak nincs szüksége, vagy amelyet nem akar megtartani. Példák:

- VBA projektek, elérhetők a [IPresentation.VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/vbaproject/) segítségével;
- beágyazott OLE adatok, elérhetők a [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) segítségével;
- ActiveX vezérlő adat, elérhető a [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hu/net/aspose.slides/icontrol/activexcontrolbinary/) segítségével.

Állítsd a [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) értékét `true`‑ra, hogy a betöltés során eltávolítsd ezeket a bináris adatokat. Mentsd el a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez az opció csökkenti a nem kívánt beágyazott terheknek való kitettséget, de nem jelent teljes körű kártevő-érzékelési vagy tartalom-sanitizációs rendszert.

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

Az Aspose.Slides betöltéskor elemzési vagy formátumkivetést dob. Kezelj ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan tudja jelezni az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a megjelenítés és az export helyettesítő betűtípusokat használhat. [Betűtípus-helyettesítés konfigurálása](/slides/hu/net/font-substitution/) vagy [egyéni betűtípusok biztosítása](/slides/hu/net/custom-font/) segíthet a kimenet kiszámíthatóbbá tételében.

**A prezentáció betöltése magával hozza a beágyazott médiát is?**

A beágyazott hang és videó elérhetővé válik a prezentáció objektummodelljén keresztül. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és lehet, hogy nem érhetők el, ha azok helyei nem hozzáférhetők.