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
description: "Nyisson PowerPoint (.pptx, .ppt) és OpenDocument (.odp) prezentációkat könnyedén az Aspose.Slides for .NET segítségével – gyors, megbízható, teljes funkcionalitással."
---
## **Bevezetés**

A PowerPoint-prezentációk nulláról való létrehozása mellett az Aspose.Slides lehetővé teszi meglévő prezentációk megnyitását is. A prezentáció betöltése után lekérdezheti annak adatait, szerkesztheti a diák tartalmát, új diákat adhat hozzá, eltávolíthatja a meglévőket, és még sok más.

## **Prezentációk megnyitása**

Meglévő prezentáció megnyitásához hozza létre a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt, és adja át a fájl útvonalát a konstruktorának.

Az alábbi C# példa bemutatja, hogyan lehet megnyitni egy prezentációt és lekérni a diák számát:

```cs
// Példányosítja a Presentation osztályt, és átadja a fájl útvonalát a konstruktorának.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Kiírja a prezentáció diáinak teljes számát.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Jelszóval Védett Prezentációk Megnyitása**

Ha jelszóval védett prezentációt kell megnyitni, adja meg a jelszót a [Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) tulajdonságon keresztül a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályban, hogy visszafejtse és betöltse azt. Az alábbi C# kód bemutatja ezt a műveletet:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Műveletek végrehajtása a visszafejtett prezentáción.
}
```

## **Nagy Méretű Prezentációk Megnyitása**

Az Aspose.Slides lehetőségeket kínál – különösen a [BlobManagementOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/blobmanagementoptions/) tulajdonságot a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályban –, hogy segítsen nagy méretű prezentációk betöltésében.

Az alábbi C# kód bemutatja egy nagy méretű prezentáció betöltését (például 2 GB):

```cs
LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Válassza a KeepLocked viselkedést - a prezentációfájl a Presentation
        // példány élettartama alatt zárolva marad, de nem szükséges memóriába betölteni vagy ideiglenes fájlba másolni.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // A nagy prezentáció betöltődött és használható, miközben a memóriafogyasztás alacsony marad.

    // Módosítások végrehajtása a prezentáción.
    presentation.Slides[0].Name = "Large presentation";

    // A prezentáció mentése egy másik fájlba. A memóriafogyasztás ebben a műveletben alacsony marad.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Ne tegye ezt! I/O kivétel lép fel, mert a fájl zárolva marad, amíg a presentation objektum nincs felszabadítva.
    File.Delete(filePath);
}

// Itt már rendben van. A forrásfájl már nincs zárolva a presentation objektum által.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Az adatfolyamokkal kapcsolatos bizonyos korlátozások megkerülése érdekében az Aspose.Slides másolhatja az adatfolyam tartalmát. Egy nagy méretű prezentáció adatfolyamból való betöltése miatt a prezentáció másolódik, ami lassíthatja a betöltést. Ezért, ha nagy prezentációt kell betölteni, erősen javasoljuk, hogy az adatfolyam helyett a prezentáció fájl útvonalát használja.

Amikor olyan prezentációt hoz létre, amely nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmaz, használhatja a [BLOB-kezelés](/slides/hu/net/manage-blob/) lehetőséget a memóriafogyasztás csökkentéséhez.
{{%/alert %}}

## **Külső Erőforrások Kezelése**

Az Aspose.Slides biztosítja a [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi C# kód bemutatja, hogyan kell használni az `IResourceLoadingCallback` interfészt:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Betölt egy helyettesítő képet.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Beállít egy helyettesítő URL-t.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Kihagy minden egyéb képet.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Prezentációk Betöltése Beágyazott Bináris Objektumok Nélkül**

PowerPoint-prezentáció tartalmazhatja az alábbi típusú beágyazott bináris objektumokat:

- VBA projekt (elérhető a [IPresentation.VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/vbaproject/));
- OLE objektum beágyazott adatai (elérhető a [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX vezérlő bináris adatai (elérhető a [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hu/net/aspose.slides/icontrol/activexcontrolbinary/)).

Az [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) tulajdonság használatával betölthet egy prezentációt anélkül, hogy bármilyen beágyazott bináris objektumot tartalmazna.

Ezt a tulajdonságot felhasználhatja a potenciálisan rosszindulatú bináris tartalom eltávolítására. Az alábbi C# kód bemutatja, hogyan tölthet be egy prezentációt beágyazott bináris tartalom nélkül:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Műveletek végrehajtása a prezentáción.
}
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Betöltés közben parsing/formátum‑validációs kivételt kap. Az ilyen hibák gyakran egy érvénytelen ZIP‑struktúrát vagy hibás PowerPoint‑rekordokat említenek.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűkészletek?**

A fájl megnyílik, de a későbbi [megjelenítés/export](/slides/hu/net/convert-presentation/) helyettesítheti a betűkészleteket. [Betűkészlet-helyettesítések konfigurálása](/slides/hu/net/font-substitution/) vagy [szükséges betűkészletek hozzáadása](/slides/hu/net/custom-font/) a futási környezethez.

**Mi a helyzet a beágyazott médiával (videó/hang) a megnyitáskor?**

Elérhetővé válnak prezentációs erőforrásként. Ha a médiát külső útvonalakon keresztül hivatkozzák, győződjön meg arról, hogy ezek az útvonalak elérhetők a környezetében; ellenkező esetben a [megjelenítés/export](/slides/hu/net/convert-presentation/) kihagyhatja a médiát.