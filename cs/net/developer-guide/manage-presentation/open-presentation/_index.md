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
description: "Zjistěte, jak v C# otevřít prezentace PowerPoint a OpenDocument, zadat otevírací hesla, řídit načítání zdrojů a snížit využití paměti pomocí Aspose.Slides pro .NET."
---
## **Úvod**

[Aspose.Slides pro .NET](https://products.aspose.com/slides/cs/net/) může načíst prezentace PowerPoint a OpenDocument ze souborů a streamů. Po načtení prezentace můžete prohlížet její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo řízenou paměť, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Pro otevření existující prezentace předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Po použití prezentaci uvolněte, aby byly souborové handly, dočasná data a další zdroje rychle uvolněny.

Následující příklad v C# ukazuje, jak otevřít prezentaci a získat počet snímků:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace přiřaďte správné heslo k [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) a předáte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Načítání selže, pokud heslo chybí nebo je nesprávné.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Pro detekci hesla, validaci a pracovní postupy šifrování viz [Password-Protect Presentations](/slides/cs/net/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Manage Presentation Properties](/slides/cs/net/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/blobmanagementoptions/) řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v C# ukazuje načtení velké prezentace (například 2 GB):

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
S `PresentationLockingBehavior.KeepLocked` zůstává zdrojový soubor zamčený, dokud není objekt `Presentation` uvolněn. Nepřesouvejte, nepřepisujte ani nesmažte zdrojový soubor, dokud je tento objekt aktivní.

Aspose.Slides může během načítání zkopírovat obsah vstupního streamu. Pro velké prezentace je tedy cesta k souboru obecně efektivnější než stream. Viz [Manage BLOBs](/slides/cs/net/manage-blob/) pro další možnosti úložiště a řízení paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/resourceloadingcallback/) přijímá implementaci [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iresourceloadingcallback/). Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které musí být řešeny podle bezpečnostních nebo úložných pravidel aplikace.

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

## **Načítání prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje ani nechce zachovat. Příklady zahrnují:

- projekty VBA, dostupné přes [IPresentation.VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/vbaproject/);
- vložená data OLE, dostupná přes [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- data ovládacích prvků ActiveX, dostupná přes [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/cs/net/aspose.slides/icontrol/activexcontrolbinary/).

Nastavte [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) na `true`, aby byla tato binární data při načítání odstraněna. Uložte načtenou prezentaci, aby byl sanitovaný výsledek zachován.

Tato možnost snižuje expozici nežádoucím vloženým nákladům, ale nejedná se o kompletní systém detekce malwaru nebo sanitizace obsahu.

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

**Jak zjistím, že je soubor poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku parsování nebo formátu. Ošetřete toto selhání odděleně od chyby nesprávného hesla, aby aplikace mohla přesně oznámit příčinu.

**Co se stane, pokud chybí požadované písma?**

Prezentace se stále načte, ale při vykreslování a exportu může dojít k substituci písem. Můžete [nastavit substituci písem](/slides/cs/net/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/net/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načítání prezentace také její vložená média?**

Vložený zvuk a video jsou k dispozici přes model objektu prezentace. Externí zdroje jsou řešeny podle nakonfigurovaného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění nelze přistupovat.