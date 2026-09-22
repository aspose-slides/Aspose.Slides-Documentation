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
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i C#, anger öppningslösenord, styr resursladdning och minskar minnesanvändning med Aspose.Slides för .NET."
---
## **Introduktion**

[Aspose.Slides for .NET](https://products.aspose.com/slides/sv/net/) kan läsa in PowerPoint- och OpenDocument-presentationer från filer och strömmar. När en presentation har lästs in kan du inspektera dess struktur, redigera bilder, hantera resurser och spara den i det ursprungliga eller ett annat stödt format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför hanterat minne, styra externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

Efter att ha läst in en fil eller ström kan du [avgöra dess ursprungliga presentationsformat](/slides/sv/net/detect-presentation-source-format/) för att välja hur din applikation bearbetar den.

För att öppna en befintlig presentation, skicka dess filsökväg till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑konstruktorn. Dispose presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande C#‑exempel visar hur man öppnar en presentation och får antalet bilder:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, tilldela rätt lösenord till [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/) och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑konstruktorn. Inläsning misslyckas när lösenordet saknas eller är felaktigt.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

För lösenorddetektering, validering och krypteringsflöden, se [Password-Protect Presentations](/slides/sv/net/password-protected-presentation/). Om en krypterad presentation avsiktligt sparades med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/net/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/blobmanagementoptions/) styr hur Aspose.Slides hanterar stora binära objekt såsom bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB-data som behålls i minnet.

Följande C#‑kod demonstrerar hur man läser in en stor presentation (till exempel 2 GB):

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
Med `PresentationLockingBehavior.KeepLocked` förblir källfilen låst tills `Presentation`‑objektet avslutas. Flytta, skriv över eller ta inte bort källfilen medan det objektet är aktivt.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför generellt mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/net/manage-blob/) för ytterligare lagrings- och minneshanteringsalternativ.
{{% /alert %}}

## **Styr externa resurser**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/resourceloadingcallback/) accepterar en implementering av [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iresourceloadingcallback/). Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardläsaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas upp enligt applikationsspecifika säkerhets- eller lagringsregler.

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

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [IPresentation.VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/vbaproject/);
- inbäddade OLE‑data, tillgängliga via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX‑kontrolldata, tillgängliga via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/sv/net/aspose.slides/icontrol/activexcontrolbinary/).

Ställ in [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) till `true` för att ta bort dessa binära data vid inläsning. Spara den inlästa presentationen för att bevara det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade belastningar, men det är inte ett fullständigt system för malware‑detektering eller innehållssanering.

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

Aspose.Slides kastar ett parsings‑ eller formatfel under inläsning. Hantera det felet separat från ett felaktigt lösenord‑fel så att applikationen kan rapportera orsaken exakt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men renderingen och exporten kan ersätta teckensnitt. Du kan [configure font substitution](/slides/sv/net/font-substitution/) eller [provide custom fonts](/slides/sv/net/custom-font/) för att göra resultatet mer förutsägbart.

**Laddar inläsning av en presentation även dess inbäddade media?**

Inbäddat audio och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt den konfigurerade resursläsningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.