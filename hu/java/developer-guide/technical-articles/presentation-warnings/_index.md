---
title: Prezentációs figyelmeztetések kezelése Java-ban
type: docs
weight: 90
url: /hu/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztető visszahívás
- figyelmeztetési szabályzat
- adatveszteség
- forráskorruptság
- kompatibilitási probléma
- betűkészlet helyettesítés
- digitális aláírás
- prezentáció betöltése
- prezentáció renderelése
- prezentáció konvertálása
- prezentáció mentése
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtheti össze, csoportosíthatja és kezelheti a figyelmeztetéseket a prezentációk betöltése, renderelése, konvertálása és mentése során az Aspose.Slides for Java-val."
---
## **Áttekintés**

Az Aspose.Slides képes visszaállítható problémákat jelenteni a betöltés, renderelés, konvertálás vagy a prezentáció mentése során. Ilyenek például a sérült forrásrekordok, a megőrizni nem tudható tartalom, a betűkészlet helyettesítés és a célnyelv formátum korlátai. Egy figyelmeztető visszahívás lehetővé teszi az alkalmazás számára, hogy rögzítse ezeket a körülményeket, és eldöntse, hogy a jelenlegi művelet folytatható‑e.

Implementálja az [IWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarningcallback/) interfészt, és vizsgálja meg a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) értékeket, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/) biztosít. Adja vissza a [ReturnAction.Continue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/returnaction/#Continue) értéket a figyelmeztetés elfogadásához, vagy a [ReturnAction.Abort](https://reference.aspose.com/slides/hu/java/com.aspose.slides/returnaction/#Abort) értéket a művelet leállításához.

Használja a [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust a megnyitás közben keletkező figyelmeztetésekhez. A renderelés és export beállítási osztályok öröklik a [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust, amely a diák renderelése, konvertálása és mentése során érkező figyelmeztetéseket kapja. Mivel a figyelmeztetés önmagában nem azonosítja az alkalmazás műveletét, kapcsoljon minden visszahívási példányt egy adott műveleti szakaszhoz, amikor kombinált jelentést állít össze.

## **Figyelmeztetések és kivételek**

Egy figyelmeztetés egy olyan állapotról tájékoztat, amelyből az Aspose.Slides helyre tudja állítani magát, ha a visszahívás `ReturnAction.Continue` értéket ad vissza. Egy kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételek nem alakulnak át figyelmeztetésekké, és egy figyelmeztetési szabályzat nem kezelheti őket.

`ReturnAction.Abort` visszaadása a figyelmeztető diszpécsernek kéri, hogy a jelenlegi műveletet kivétel dobásával állítsa le. A nyilvános kivétel a művelettől és a prezentáció formátumától függ. Például a betöltés során egy [PptxReadException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptreadexception/) léphet fel, míg a mentés vagy exportálás során egy [PptxException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxexception/) jelenhet meg. Kezelje a kivételt a művelet határán, és használja a figyelmeztetési jelentést annak meghatározására, hogy az alkalmazás szabályzata váltotta‑e ki a leállást, ahelyett, hogy csak egy kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás a figyelmeztetést rögzíti a `ReturnAction.Abort` visszaadása előtt, biztosítva, hogy az ok elérhető maradjon az alkalmazás számára.

## **Figyelmeztetés kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/) osztály egész számú állandókat biztosít a következő kategóriákhoz:

| Figyelmeztetés típusa | Jelentés | Tipikus szabályzat |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Az forrás prezentáció korrupt, ami azt eredményezheti, hogy az eredeti formátumban mentett dokumentum használhatatlanná válik. | Megszakítás. |
| [DataLoss](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#DataLoss) | Szöveg, diagram, kép vagy egyéb adat hiányozhat a betöltés vagy mentés után. | Megszakítás. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | A prezentáció elveszítheti a fontos formázást. | Szigorú validálási módban megszakítás; egyébként rögzítés és folytatás. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Korlátozott formázási eltérés léphet fel. | Rögzítés diagnosztikai célokra és folytatás. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Az eredmény egyes alkalmazásokban vagy régebbi verziókban nem nyílik meg, vagy nem működik helyesen. | Naplózás és folytatás, hacsak a kompatibilitás nem kötelező. |
| [UnexpectedContent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/warningtype/#UnexpectedContent) | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még nem ismert. | Rögzítés és folytatás, vagy szigorú szabályzat esetén hibaként kezelése. |

A kategória kell, hogy meghatározza a szabályzat döntését. Tárolja a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értéket diagnosztikai célokra, de ne függjön a szövegkörnyezettől az alkalmazás logikájában, mivel az üzenet szövege változhat a figyelmeztetési helyzetek és a termék verziói között.

## **Figyelmeztetések összegyűjtése és besorolása**

A következő példa egy alkalmazásszintű jelentést használ a teljes feldolgozási csővezetékhez. Egy külön visszahívási példány címkézi a betöltés, renderelés, PDF‑konvertálás és PPTX‑mentés során keletkező figyelmeztetéseket. A szabályzat megszakítja a forráskorrupt vagy adatvesztés esetén, opcionálisan megszakítja a nagyobb formázási eltérések esetén, és a többi figyelmeztetést tovább folytatja.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

A `WarningPolicy` létrehozásakor adja át a `abortOnMajorFormattingLoss` paraméternek a `false` értéket, ha a nagyobb formázási eltérések elfogadhatók. A kompatibilitási problémák, kisebb formázási veszteség és a nem várt tartalom továbbra is megmarad a jelentésben, még ha a művelet folytatódik is. Bővítse a `WarningPolicy.getAction` metódust, ha az alkalmazásnak el kell utasítania bármelyik kategóriát.

## **Gyakori figyelmeztetési helyzetek**

A figyelmeztetések a munkafolyamat különböző szakaszaiban jelentkezhetnek:

- **Digitális aláírások:** Egy aláírtt prezentáció betöltéskor figyelmeztetést generálhat, hogy az aláírás a feldolgozás során elveszik. Az Aspose.Slides ezt a `DataLoss` állapotot az [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationsignedwarninginfo/) segítségével jelenti. A betöltési szakasz visszahívása lehetővé teszi az alkalmazásnak, hogy elutasítsa a fájlt, vagy kifejezetten elfogadja a jelentett adatvesztést.
- **Betűkészlet helyettesítés:** Egy nem elérhető betűkészlet helyettesíthető, amikor egy dia renderelődik vagy exportálódik. A betűkészlet helyettesítési figyelmeztetések `DataLoss`‑ként jelennek meg, ezért a fenti szigorú szabályzat megszakít, még ha az alkalmazás egy adott helyettesítést vizuálisan elfogadhatónak is tekint. Ennek a viselkedésnek a megfigyeléséhez használjon egy bemeneti prezentációt, amely olyan betűkészletben lévő szöveget tartalmaz, amely a futtatókörnyezet számára nem elérhető. A figyelmeztetés leírása azonosítja a helyettesítést; állítsa be a szükséges betűkészleteket vagy a [font substitution rules](/slides/hu/java/font-substitution/) szabályokat, mielőtt újra próbálkozik.
- **Nem támogatott vagy nem várt tartalom:** A betöltő olyan prezentációs rekordokkal vagy funkciókkal találkozhat, amelyeket nem ismer fel. Az ilyen figyelmeztetések a `UnexpectedContent` típust használhatják, vagy súlyosabb kategóriát, ha adat vagy formázás érintett.
- **Formátum kompatibilitás:** Másik prezentációs formátumba mentéskor bizonyos funkciók kimaradhatnak, vagy olyan eredmény keletkezhet, amely más alkalmazásokban másként viselkedik. Például egy olyan prezentáció mentése, amely több mint nyolc vízszintes vagy nyolc függőleges rajzolósegédet tartalmaz, a régi PPT formátumba `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha az összes segéd megtartása kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és a régi viselkedések is generálhatnak figyelmeztetéseket. Például az [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) egy elavult prezentáció‑zárolási viselkedés használatát `CompatibilityIssue`‑ként jelzi.

A figyelmeztetések a forrásdokumentumtól, a célnyelv formátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy helyzet mindig csak egy kategóriába sorolható.

## **Az abortált műveletek biztonságos kezelése**

Ha egy visszahívás `ReturnAction.Abort` értéket ad vissza, ne használjon olyan objektumot, amely betöltése nem sikerült, és ne feltételezze, hogy a renderelés vagy mentés eredménye kész. A művelet leállhat a kimeneti fájl létrehozása után, de még mielőtt befejeződne.

Mentsen érvényesített eredményeket egy külön útvonalra, például a `validated-output.pptx` fájlba. Egy meglévő prezentációt csak akkor cseréljen le, ha a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályzatának, és a kimenet megnyitható és ellenőrizhető. Ez megakadályozza, hogy egy érvényes forrásfájl részlegesen vagy elutasított eredménnyel legyen felülírva.

Az üres figyelmeztetési jelentés nem garancia arra, hogy minden forrásfunkció megmaradt. Alkalmazza az alkalmazás által előírt további tartalmi és vizuális ellenőrzéseket. Lásd még a [Open Presentations](/slides/hu/java/open-presentation/) és a [Save Presentations](/slides/hu/java/save-presentation/) oldalakat.

## **GYIK**

**Képes egy figyelmeztető visszahívás kezelni minden Aspose.Slides hibát?**

Nincs. A visszahívás csak a figyelmeztetésként jelentett helyreállítható állapotokat kezeli. Azok a kivételek, amelyek a visszahívástól függetlenül fordulnak elő, az alkalmazásnak a betöltés, renderelés, konvertálás vagy mentés hívása körül kell kezelnie.

**Garantálja a `ReturnAction.Continue` visszaadása az azonos kimenetet?**

NEM. Csak azt engedélyezi, hogy a feldolgozás folytatódjon. A jelentett állapot továbbra is adat-, formázási vagy kompatibilitási különbségeket okozhat, ezért tekintse át a gyűjtött figyelmeztetési típusokat és leírásokat.

**Hogyan tud egy alkalmazás azonosítani azt a műveletet, amelyik a figyelmeztetést előidézte?**

Hozzon létre egy visszahívási példányt minden egyes művelethez, és tároljon egy alkalmazás által definiált szakaszt a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értékekkel együtt, ahogyan a példában látható.