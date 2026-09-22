---
title: Otevření prezentací v .NET
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/net/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak v C# otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro .NET."
---
## **Úvod**

[Aspose.Slides for .NET](https://products.aspose.com/slides/cs/net/) může načítat prezentace PowerPoint a OpenDocument ze souborů a streamů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo spravovanou paměť, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Po načtení souboru nebo streamu můžete [zjistit původní formát prezentace](/slides/cs/net/detect-presentation-source-format/), abyste si vybrali, jak ji aplikace zpracuje.

Pro otevření existující prezentace předáte její souborovou cestu konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Po použití prezentaci uvolněte, aby byly souborové handle, dočasná data a další zdroje okamžitě uvolněny.

Následující příklad v C# ukazuje, jak otevřít prezentaci a získat počet snímků:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace přiřaďte správné heslo k [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) a předejte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Načítání selže, pokud heslo chybí nebo je nesprávné.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Pro detekci, validaci a šifrovací postupy hesel viz [Prezentace chráněné heslem](/slides/cs/net/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti přečíst bez hesla; viz [Správa vlastností prezentace](/slides/cs/net/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/blobmanagementoptions/) řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor uzamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující C# kód demonstruje načtení velké prezentace (například 2 GB):

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

{{% alert color="info" title="Poznámka" %}}
S `PresentationLockingBehavior.KeepLocked` zůstane zdrojový soubor uzamčený, dokud není objekt `Presentation` uvolněn. Soubor nesmíte během existence tohoto objektu přesunout, přepsat nebo smazat.

Aspose.Slides může během načítání zkopírovat obsah vstupního streamu. Pro velké prezentace je proto cesta k souboru obecně efektivnější než stream. Viz [Správa BLOB](/slides/cs/net/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/resourceloadingcallback/) přijímá implementaci [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iresourceloadingcallback/). Zpětné volání může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které musí být řešeny podle specifických bezpečnostních nebo úložných pravidel aplikace.

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

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce uchovávat. Příklady zahrnují:

- VBA projekty, dostupné prostřednictvím [IPresentation.VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/vbaproject/);
- vložená OLE data, dostupná přes [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- data ovládacích prvků ActiveX, dostupná přes [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/cs/net/aspose.slides/icontrol/activexcontrolbinary/).

Nastavte [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) na `true`, aby se při načítání odstranila tato binární data. Uložte načtenou prezentaci, aby se zachoval očištěný výsledek.

Tato volba snižuje vystavení nechtěným vloženým nákladům, ale není kompletním systémem pro detekci malware nebo sanitaci obsahu.

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

## **Často kladené otázky**

**Jak mohu zjistit, že je soubor poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku parsování nebo formátu. Tento selhání ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně nahlásit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se může načíst, ale při renderování a exportu může dojít k náhradě písem. Můžete [nastavit náhradu písem](/slides/cs/net/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/net/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načtení prezentace i její vložená média?**

Vložené audio a video jsou k dispozici prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle nakonfigurovaného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění nelze získat.