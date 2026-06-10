---
title: "Prezentációk megnyitása C++-ban"
linktitle: "Prezentáció megnyitása"
type: docs
weight: 20
url: /hu/cpp/open-presentation/
keywords:
- "PowerPoint megnyitása"
- "OpenDocument megnyitása"
- "prezentáció megnyitása"
- "PPTX megnyitása"
- "PPT megnyitása"
- "ODP megnyitása"
- "prezentáció betöltése"
- "PPTX betöltése"
- "PPT betöltése"
- "ODP betöltése"
- "védett prezentáció"
- "nagy prezentáció"
- "külső erőforrás"
- "bináris objektum"
- "C++"
- "Aspose.Slides"
description: "PowerPoint (.pptx, .ppt) és OpenDocument (.odp) prezentációk egyszerű megnyitása az Aspose.Slides for C++ segítségével – gyors, megbízható, teljes körű funkcionalitás."
---
## **Bevezetés**

A PowerPoint-prezentációk teljes újbóli létrehozása mellett az Aspose.Slides lehetővé teszi meglévő prezentációk megnyitását is. Egy prezentáció betöltése után lekérdezheted annak adatait, szerkesztheted a dia tartalmát, új diát adhatsz hozzá, eltávolíthatod a meglévőket, és még sok más.

## **Meglévő prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához hozd létre a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály egy példányát, és add át a fájl elérési útját a konstruktorának.

Az alábbi C++ példa bemutatja, hogyan nyithatsz meg egy prezentációt és szerezheted meg a diáik számát:

```cpp
// Példányosítsd a Presentation osztályt, és add át a fájl elérési útját a konstruktorának.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Kiírja a prezentációban lévő diák teljes számát.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Jelszóval védett prezentációk megnyitása**

Amikor jelszóval védett prezentációt kell megnyitnod, add meg a jelszót a [set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metóduson keresztül a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) osztályban, hogy visszafejtsd és betöltsd azt. Az alábbi C++ kód bemutatja ezt a műveletet:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Műveletek végrehajtása a visszafejtett prezentáción.

presentation->Dispose();
```

## **Nagy prezentációk megnyitása**

Az Aspose.Slides lehetőségeket biztosít – különösen a [get_BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) metódust a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) osztályban – hogy segítsen nagy prezentációk betöltésében.

Az alábbi C++ kód bemutatja egy nagy (például 2 GB) prezentáció betöltését:

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Válaszd a KeepLocked viselkedést – a prezentáció fájl a Presentation példány élettartamáig zárolva marad
// a Presentation példányra, de nem szükséges memóriába betölteni vagy ideiglenes fájlba másolni.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// A nagy prezentáció betöltve van és használható, miközben a memóriahasználat alacsony marad.

// Változtatások végrehajtása a prezentáción.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// A prezentáció mentése egy másik fájlba. A memóriahasználat alacsony marad a művelet során.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Ne tedd ezt! I/O kivétel keletkezik, mivel a fájl zárolva van, amíg a presentation objektum nincs felszabadítva.
File::Delete(filePath);

presentation->Dispose();

// Itt már biztonságos ezt megtenni. A forrásfájl már nincs zárolva a presentation objektum által.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Az adatfolyamok használatakor előforduló bizonyos korlátozások megkerüléséhez az Aspose.Slides a folyam tartalmát másolhatja. Egy nagy prezentáció adatfolyamból történő betöltése a prezentáció másolását eredményezi, és lassíthatja a betöltést. Ezért, ha nagy prezentációt kell betölteni, erősen ajánljuk a prezentáció fájl elérési útjának használatát az adatfolyam helyett.

Amikor olyan prezentációt hozol létre, amely nagy objektumokat tartalmaz (videó, hang, nagy felbontású képek stb.), a [BLOB management](/slides/hu/cpp/manage-blob/) segítségével csökkentheted a memóriahasználatot.
{{%/alert %}}

## **Külső erőforrások kezelése**

Aspose.Slides biztosítja az [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi C++ kód bemutatja, hogyan használhatod a `IResourceLoadingCallback` interfészt:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Betölt egy helyettesítő képet.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Állít be egy helyettesítő URL-t.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Átugorja a többi képet.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy PowerPoint-prezentáció a következő típusú beágyazott bináris objektumokat tartalmazhat:

- VBA projekt (elérhető az [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE objektum beágyazott adat (elérhető az [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX vezérlő bináris adatok (elérhető az [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Az [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) metódus használatával betölthetsz egy prezentációt beágyazott bináris objektumok nélkül.

Ez a metódus hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi C++ kód bemutatja, hogyan tölts be egy prezentációt beágyazott bináris tartalom nélkül:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Műveletek végrehajtása a prezentáción.

presentation->Dispose();
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

A betöltés során egy elemzés/formátum ellenőrzési kivételt kapsz. Az ilyen hibák gyakran érvénytelen ZIP struktúrát vagy hibás PowerPoint rekordokat említenek.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűtípusok?**

A fájl megnyílik, de a későbbi [rendering/export](/slides/hu/cpp/convert-presentation/) helyettesítheti a betűtípusokat. [Configure font substitutions](/slides/hu/cpp/font-substitution/) vagy [add the required fonts](/slides/hu/cpp/custom-font/) a futási környezetbe.

**Mi van a beágyazott médiával (videó/hang) a megnyitáskor?**

Elérhetővé válnak a prezentáció erőforrásaiként. Ha a média külső útvonalakon keresztül van hivatkozva, győződj meg arról, hogy ezek az útvonalak hozzáférhetők a környezetedben; ellenkező esetben a [rendering/export](/slides/hu/cpp/convert-presentation/) kihagyhatja a médiát.