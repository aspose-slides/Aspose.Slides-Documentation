---
title: Prezentációs figyelmeztetések kezelése .NET-ben
type: docs
weight: 120
url: /hu/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztetési visszahívás
- figyelmeztetési szabályzat
- adatveszteség
- forráskorruptió
- kompatibilitási probléma
- betűkészlet helyettesítés
- digitális aláírás
- prezentáció betöltés
- prezentáció renderelés
- prezentáció konvertálás
- prezentáció mentés
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtsön, soroljon be és kezeljen figyelmeztetéseket a prezentációk betöltése, renderelése, konvertálása és mentése során az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides jelentést készíthet a helyrehozható problémákról, amikor betölt, megjelenít, konvertál vagy ment egy prezentációt. Ilyen példák a sérült forrásrekordok, a megőrizhetetlen tartalom, betűkészlet helyettesítés és a célformátum korlátozásai. A figyelmeztetési visszahívás lehetővé teszi az alkalmazás számára, hogy rögzítse ezeket a feltételeket, és eldöntse, hogy a jelenlegi művelet folytatódhat‑e.

Valósítsa meg a [IWarningCallback](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iwarningcallback/) felületet, és vizsgálja meg a [WarningType](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iwarninginfo/warningtype/) és [Description](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iwarninginfo/description/) tulajdonságokat, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iwarninginfo/) biztosít. Adjon vissza [ReturnAction.Continue](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/returnaction/) értéket a figyelmeztetés elfogadásához, vagy `ReturnAction.Abort`‑ot a művelet leállításához.

Használja a [LoadOptions.WarningCallback](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/warningcallback/) lehetőséget a prezentáció megnyitása közben felmerülő figyelmeztetésekhez. A renderelési és exportálási beállítási osztályok öröklik a [SaveOptions.WarningCallback](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/warningcallback/)‑t, amely a dia rendereléséből, konvertálásából és mentéséből származó figyelmeztetéseket kapja. Mivel a figyelmeztetés önmagában nem azonosítja az alkalmazás műveletét, minden visszahívási példányt társítson egy műveleti szakaszhoz, amikor kombinált jelentést állít össze.

## **Figyelmeztetések és kivételek**

A figyelmeztetés olyan feltételt ír le, amelyből az Aspose.Slides helyrehozható, ha a visszahívás `ReturnAction.Continue`‑t ad vissza. A kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételek nem konvertálódnak figyelmeztetésekké, és nem kezelhetők figyelmeztetési szabályzattal.

A `ReturnAction.Abort` visszaadása a figyelmeztetési diszpatchernek jelzi, hogy a jelenlegi műveletet kivétel dobásával kell befejezni. A nyilvános kivétel a művelettől és a prezentáció formátumától függ. Például a betöltés során felmerülhet egy [PptxReadException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptreadexception/), míg a mentés vagy exportálás során egy [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/). Kezelje a kivételt a művelet határán, és használja a figyelmeztetési jelentést annak megállapítására, hogy az alkalmazás szabályzata okozta-e a leállást, ahelyett, hogy egy adott kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás rögzíti a figyelmeztetést a `ReturnAction.Abort` visszaadása előtt, biztosítva, hogy az ok elérhető maradjon az alkalmazás számára.

## **Figyelmeztetési kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/warningtype/) felsorolás a következő kategóriákat kínálja:

| Figyelmeztetés típusa | Jelentés | Tipikus irányelv |
| --- | --- | --- |
| `SourceFileCorruption` | A forrás prezentáció sérülést tartalmaz, ami azt eredményezheti, hogy az eredeti formátumban mentett dokumentum használhatatlan lesz. | Megszakítás. |
| `DataLoss` | Szöveg, diagramok, képek vagy egyéb adatok hiányozhatnak a betöltés vagy mentés után. | Megszakítás. |
| `MajorFormattingLoss` | A prezentáció fontos formázásait elveszítheti. | Megszakítás szigorú validációs módban; egyébként rögzítés és folytatás. |
| `MinorFormattingLoss` | Korlátozott formázási különbség léphet fel. | Diagnosztikai rögzítés és folytatás. |
| `CompatibilityIssue` | Az eredmény nem nyitható meg vagy nem viselkedik helyesen bizonyos alkalmazásokban vagy régebbi verziókban. | Naplózás és folytatás, ha a kompatibilitás nem kötelező. |
| `UnexpectedContent` | A forrás olyan nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még nem ismert. | Rögzítés és folytatás, vagy szigorú szabályzat esetén hiba. |

A kategória irányítja a politikai döntést. Tárolja a `Description`‑t diagnosztikai célokra, de ne a szövegét használja alkalmazáslogikához, mivel a üzenet szövege változhat a figyelmeztetési helyzetek és a termék verziói között.

## **Figyelmeztetések összegyűjtése és besorolása**

Az alábbi példa egy alkalmazásszintű jelentést használ a teljes feldolgozási csővezetékhez. Egy külön visszahívási példány címkézi a betöltés, renderelés, PDF‑konvertálás és PPTX‑mentés során keletkező figyelmeztetéseket. A szabályzat leállítja a forráskorruptió vagy adatveszteség esetén, opcionálisan leállítja a jelentős formázásveszteséget, a többi figyelmeztetés esetén pedig folytatja.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Állítsa be az `abortOnMajorFormattingLoss` értékét `false`‑ra, ha a jelentős formázási eltérések elfogadhatóak. A kompatibilitási problémák, a kisebb formázásveszteség és a nem várt tartalom továbbra is szerepelnek a jelentésben, még akkor is, ha a művelet folytatódik. Bővítse a `WarningPolicy.GetAction` metódust, ha az alkalmazásnak el kell utasítania bármelyik ilyen kategóriát.

## **Gyakori figyelmeztetési forgatókönyvek**

A figyelmeztetések a munkafolyamat különböző szakaszaiban jelenhetnek meg:

- **Digitális aláírások:** Egy aláírt prezentáció betöltéskor figyelmeztetést generálhat arról, hogy az aláírás elveszik a feldolgozás során. Az Aspose.Slides ezt a `DataLoss` feltételt az [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/ipresentationsignedwarninginfo/) útján jelzi. A betöltési szakasz visszahívása lehetővé teszi, hogy az alkalmazás elutasítsa a fájlt, vagy kifejezetten elfogadja a jelentett veszteséget.
- **Betűkészlethelyettesítés:** Egy nem elérhető betűkészlet helyettesíthető, amikor egy dia renderelődik vagy exportálódik. A betűkészlethelyettesítési figyelmeztetéseket `DataLoss`‑ként jelentik, ezért a fenti szigorú szabályzat még akkor is megszakít, ha az alkalmazás a helyettesítést vizuálisan elfogadhatónak tartaná. Ennek megfigyeléséhez használjon egy bemeneti prezentációt, amely olyan betűtípust tartalmaz, amely a futási környezetben nem érhető el. A figyelmeztetés leírása megnevezi a helyettesítést; konfigurálja a szükséges betűkészleteket vagy a [font substitution rules](/slides/hu/net/font-substitution/) szabályait, mielőtt újrapróbálná.
- **Nem támogatott vagy nem várt tartalom:** A betöltő olyan prezentációs rekordokba vagy funkciókba ütközhet, amelyeket nem ismer. Az ilyen figyelmeztetések használhatják az `UnexpectedContent`‑et, vagy egy súlyosabb kategóriát, ha adat vagy formázás ismert módon érintett.
- **Formátumkompatibilitás:** Másik prezentációformátumba mentéskor egyes funkciók kimaradhatnak, vagy az eredmény különbözően viselkedhet bizonyos alkalmazásokban. Például, ha egy prezentáció több mint nyolc vízszintes vagy nyolc függőleges rajzolósegédet tartalmaz, a régi PPT formátumba mentés `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha minden segéd megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és a régi viselkedések is generálhatnak figyelmeztetéseket. Például az [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) a régi prezentáció‑zárolási viselkedés használatát `CompatibilityIssue`‑ként azonosítja.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy forgatókönyv mindig csak egy kategóriába sorolható.

## **Biztonságos leállított műveletek kezelése**

Amikor egy visszahívás `ReturnAction.Abort`‑ot ad vissza, ne használja azt az objektumot, amelyik nem töltődött be, és ne tegyen feltevést arról, hogy a renderelés vagy mentés kimenete teljes. A művelet befejeződhet egy kimeneti fájl létrehozása után, de még mielőtt az befejeződne.

Mentse a validált eredményeket egy külön útvonalra, például `validated-output.pptx`. Felülírja a meglévő prezentációt csak akkor, amikor a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályzatának, és a kimenet megnyitható és ellenőrizhető. Ez megakadályozza, hogy egy részleges vagy elutasított eredménnyel felülírjon egy érvényes forrásfájlt.

Egy üres figyelmeztetési jelentés nem garantálja, hogy minden forrásjellemző megmaradt. Alkalmazzon minden további tartalmi és vizuális ellenőrzést, amelyet az alkalmazás megkövetel. Lásd még a [Open Presentations](/slides/hu/net/open-presentation/) és a [Save Presentations](/slides/hu/net/save-presentation/) oldalakat.

## **GYIK**

**Kezelhet-e egy figyelmeztetési visszahívás minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett helyrehozható feltételeket kezeli. Azokat a kivételeket, amelyek a visszahívástól függetlenül fordulnak elő, az alkalmazásnak a betöltés, renderelés, konvertálás vagy mentés hívása körül kell kezelnie.

**Garantálja a `ReturnAction.Continue` visszaadása azonos kimenetet?**

Nem. Csak azt engedélyezi, hogy a feldolgozás folytatódjon. A jelentett feltétel továbbra is adat-, formázási- vagy kompatibilitási különbségeket okozhat, ezért ellenőrizze a gyűjtött figyelmeztetéstípusokat és leírásokat.

**Hogyan azonosíthatja egy alkalmazás a figyelmeztetést előállító műveletet?**

Hozzon létre egy visszahívási példányt minden egyes művelethez, és tárolja az alkalmazás által definiált szakaszt a `WarningType` és `Description` mellett, ahogy a példában is látható.