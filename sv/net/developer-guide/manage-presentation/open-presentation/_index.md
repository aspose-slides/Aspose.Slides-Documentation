---
title: Öppna presentationer i .NET
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/net/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint‑ och OpenDocument‑presentationer i C#, anger öppningslösenord, styr resursladdning och minskar minnesanvändning med Aspose.Slides för .NET."
---
## **Introduktion**

[Aspose.Slides for .NET](https://products.aspose.com/slides/sv/net/) kan läsa PowerPoint‑ och OpenDocument‑presentationer från filer och strömmar. När en presentation har lästs in kan du undersöka dess struktur, redigera bilder, hantera resurser och spara den i original‑ eller ett annat stödd format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/). Du kan till exempel ange ett öppningslösenord, hålla stora binära objekt utanför hanterat minne, styra externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). Disposera presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande C#‑exempel visar hur du öppnar en presentation och får dess bildantal:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, tilldela rätt lösenord till [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/) och skicka med alternativen till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). Inläsning misslyckas när lösenordet saknas eller är felaktigt.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Password‑Protect Presentations](/slides/sv/net/password-protected-presentation/). Om en krypterad presentation avsiktligt sparats med offentliga dokumentegenskaper kan dessa läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/net/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/blobmanagementoptions/) styr hur Aspose.Slides hanterar stora binära objekt som bilder, ljud och video. Du kan behålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande C#‑kod demonstrerar inläsning av en stor presentation (t.ex. 2 GB):

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

{{% alert color="info" title="Obs" %}}
Med `PresentationLockingBehavior.KeepLocked` förblir källfilen låst tills `Presentation`‑objektet disponeras. Flytta, skriv över eller ta inte bort källfilen medan objektet är aktivt.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför generellt mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/net/manage-blob/) för ytterligare lagrings‑ och minneshanteringsalternativ.
{{% /alert %}}

## **Styr externa resurser**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/resourceloadingcallback/) accepterar en implementering av [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iresourceloadingcallback/). Återuppringningen kan leverera ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets‑ eller lagringsregler.

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

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation varken behöver eller vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [IPresentation.VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/vbaproject/);
- inbäddad OLE‑data, tillgänglig via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX‑kontrolldata, tillgänglig via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/sv/net/aspose.slides/icontrol/activexcontrolbinary/).

Ställ in [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) till `true` för att ta bort dessa binära data vid inläsning. Spara den inlästa presentationen för att bevara det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade payloads, men är ingen komplett malware‑detektering eller innehållssaniteringslösning.

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

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller formatfel under inläsning. Hantera detta misslyckande separat från ett felaktigt lösenord så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentation kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan [konfigurera teckensnittsersättning](/slides/sv/net/font-substitution/) eller [tillhandahålla anpassade teckensnitt](/slides/sv/net/custom-font/) för att göra utdata mer förutsägbar.

**Läser inläsning av en presentation också in dess inbäddade media?**

Inbäddat ljud och video blir tillgängligt via presentationsobjektmodellen. Externa resurser löses enligt den konfigurerade resurs‑laddningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.