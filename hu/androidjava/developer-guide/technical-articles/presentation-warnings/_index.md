---
title: Prezentációs figyelmeztetések kezelése Androidon
type: docs
weight: 90
url: /hu/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztetési visszahívás
- figyelmeztetési szabályzat
- adatveszteség
- forrássérülés
- kompatibilitási probléma
- betűkészlet helyettesítés
- digitális aláírás
- prezentáció betöltés
- prezentáció renderelés
- prezentáció konvertálás
- prezentáció mentés
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtheti össze, osztályozhatja és kezelheti a figyelmeztetéseket a prezentációk betöltése, renderelése, konvertálása és mentése során az Androidra szánt Aspose.Slides Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides képes visszaállítható problémákat jelenteni, miközben betölt, renderel, konvertál vagy ment egy prezentációt. Példák közé tartozik a sérült forrásrekordok, a megőrizhetetlen tartalom, a betűkészlet helyettesítés és a célformátum korlátozásai. A figyelmeztető visszahívás lehetővé teszi az alkalmazás számára, hogy rögzítse ezeket a feltételeket, és eldöntse, hogy a jelenlegi művelet folytatható-e.

Hozzon létre egy implementációt az [IWarningCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarningcallback/) interfészhez, és vizsgálja meg a [getWarningType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) értékeket, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/) szolgáltat. A [ReturnAction.Continue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/returnaction/#Continue) visszaadása elfogadja a figyelmeztetést, a [ReturnAction.Abort](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/returnaction/#Abort) pedig leállítja a műveletet.

Használja a [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust a prezentáció megnyitása során keletkező figyelmeztetésekhez. A rendereléshez és exportáláshoz kapcsolódó opcióosztályok öröklik a [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust, amely a dia rendereléséből, konvertálásából és mentéséből származó figyelmeztetéseket kapja. Mivel maga a figyelmeztetés nem azonosítja az alkalmazás műveletét, kapcsolja minden visszahívás‑példányt egy művelet‑szakaszhoz, amikor kombinált jelentést épít.

## **Figyelmeztetések és kivételek**

Egy figyelmeztetés leír egy olyan állapotot, amelyből az Aspose.Slides helyreállíthat, ha a visszahívás `ReturnAction.Continue` értéket ad vissza. A kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételek nem alakulnak át figyelmeztetésekké, és figyelmeztetési szabályzat által nem kezelhetők.

`ReturnAction.Abort` visszaadása azt kéri a figyelmeztetés diszpécserétől, hogy egy kivétel dobásával fejezze be a jelenlegi műveletet. A publikus kivétel a művelettől és a prezentáció formátumától függ. Például a betöltés során megjelenhet egy [PptxReadException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptreadexception/), míg mentés vagy exportálás során egy [PptxException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxexception/) jelenhet meg. Kezelje a kivételt a művelet határán, és használja a figyelmeztetési jelentést annak meghatározására, hogy az alkalmazás szabályzata okozta-e a leállást, ahelyett, hogy egyetlen kivételtípusra vagy üzenetre támaszkodna. A visszahívás rögzíti a figyelmeztetést a `ReturnAction.Abort` visszaadása előtt, ezzel biztosítva, hogy az ok elérhető marad az alkalmazás számára.

## **Figyelmeztetési kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/) osztály egész számú állandókat biztosít a következő kategóriákhoz:

| Figyelmeztetés típusa | Jelentés | Általános szabályzat |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | A forrás prezentáció sérülést tartalmaz, amely miatt a saját eredeti formátumban mentett dokumentum használhatatlanná válhat. | Megszakítja. |
| [DataLoss](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#DataLoss) | A betöltés vagy mentés után a szöveg, diagramok, képek vagy más adatok hiányozhatnak. | Megszakítja. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | A prezentáció elveszítheti a fontos formázást. | Szigorú ellenőrzési módban megszakítja; egyébként rögzítés és folytatás. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Korlátozott formázási különbség fordulhat elő. | Rögzítés diagnosztikához és folytatás. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Az eredmény egyes alkalmazásokban vagy régebbi verziókban nem nyitható meg vagy nem működik megfelelően. | Naplózás és folytatás, hacsak a kompatibilitás nem kötelező. |
| [UnexpectedContent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még nem ismert. | Rögzítés és folytatás, vagy szigorú szabályzat esetén hiba kezelése. |

A kategóriának kell irányítania a szabályzati döntést. Tárolja a [getDescription](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értéket diagnosztikához, de ne függjön a szövegtől az alkalmazás logikájában, mivel az üzenet szövege változhat a figyelmeztetési esetek és a termék verziói között.

## **Figyelmeztetések gyűjtése és osztályozása**

A következő példa egy alkalmazásszintű jelentést használ a teljes feldolgozási lánchoz. Egy külön visszahívás‑példány címkézi a betöltés, renderelés, PDF konvertálás és PPTX mentés során keletkező figyelmeztetéseket. A szabályzat megszakítja a forrás‑sérülés vagy adatveszteség esetén, opcionálisan megszakítja a nagy formázásveszteség esetén, és folytatja a többi figyelmeztetésnél.

Helyezze az `input.pptx` fájlt egy írható alkalmazási könyvtárba, és adja meg ezt a könyvtárat a `PresentationWarningExample.run` metódusnak. A példa a kimeneteket ugyanabban a könyvtárban menti. Futtassa a prezentáció feldolgozását egy háttérszálon, hogy az Android felhasználói felület reagáló maradjon.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

A `WarningPolicy` létrehozásakor adja át a `abortOnMajorFormattingLoss` paraméternek a `false` értéket, ha a nagy formázási eltérések elfogadhatóak. A kompatibilitási problémák, a kisebb formázásveszteség és a nem várt tartalom még mindig megtartásra kerül a jelentésben, még ha a művelet folytatódik is. Bővítse a `WarningPolicy.getAction` metódust, ha az alkalmazásnak el kell utasítania bármelyik kategóriát.

## **Gyakori figyelmeztetési helyzetek**

A figyelmeztetések a munkafolyamat különböző szakaszaiban jelenhetnek meg:

- **Digitális aláírások:** Egy aláírt prezentáció betöltés közben figyelmeztetést adhat, hogy az aláírás a feldolgozás során elveszik. Az Aspose.Slides ezt a `DataLoss` állapotot az [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) segítségével jelenti. A betöltési szakasz visszahívása lehetővé teszi az alkalmazás számára, hogy elutasítsa a fájlt vagy kifejezetten elfogadja a jelentett adatveszteséget.
- **Betűkészlet helyettesítés:** Egy nem elérhető betűkészlet helyettesíthető a dia renderelése vagy exportálása során. A betűkészlet helyettesítési figyelmeztetéseket `DataLoss`‑ként jelenti, ezért a fentiekben leírt szigorú szabályzat megszakítja a feldolgozást, még ha az alkalmazás egy adott helyettesítést vizuálisan elfogadhatónak tekintene is. A viselkedés megfigyeléséhez használjon egy bemeneti prezentációt, amely olyan betűkészletben tartalmaz szöveget, amely a futtatókörnyezete számára nem elérhető. A figyelmeztetés leírása azonosítja a helyettesítést; konfigurálja a szükséges betűkészleteket vagy a [betűkészlet helyettesítési szabályokat](/slides/hu/androidjava/font-substitution/) a újrapróbálás előtt.
- **Nem támogatott vagy nem várt tartalom:** Egy betöltő olyan prezentációs rekordokkal vagy funkciókkal ütközhet, amelyeket nem ismer fel. Az ilyen figyelmeztetések `UnexpectedContent`‑et vagy súlyosabb kategóriát használhatnak, ha adatok vagy formázás érintett.
- **Formátum kompatibilitás:** Egy másik prezentációs formátumba mentés elhagyhat bizonyos funkciókat, vagy olyan eredményt hozhat létre, amely néhány alkalmazásban másként viselkedik. Például egy olyan prezentáció mentése, amely nyolcnál több vízszintes vagy nyolcnál több függőleges rajzsegédet tartalmaz, a régi PPT formátumba `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha az összes segéd megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és a régi viselkedések is okozhatnak figyelmeztetéseket. Például az [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) egy elavult prezentációzárási viselkedés használatát `CompatibilityIssue`‑ként azonosítja.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy helyzet mindig csak egy kategóriába sorolható.

## **Megszakított műveletek biztonságos kezelése**

Ha egy visszahívás `ReturnAction.Abort` értéket ad vissza, ne használjon olyan objektumot, amely betöltése sikertelen volt, és ne feltételezze, hogy egy renderelési vagy mentési kimenet teljes. A művelet befejeződhet egy kimeneti fájl létrehozása után, de a befejezése előtt.

Mentse az ellenőrzött eredményeket egy külön útvonalra, például `validated-output.pptx`. A meglévő prezentációt csak a művelet sikeres befejezése után, a figyelmeztetési jelentésnek megfelelve és a kimenet megnyitható és ellenőrizhető állapotban legyen cserélve. Ez megakadályozza, hogy egy érvényes forrásfájl felülíródjon részlegesen vagy elutasított eredménnyel.

Egy üres figyelmeztetési jelentés nem garantálja, hogy minden forrásjellemző megmaradt. Alkalmazzon további tartalmi és vizuális ellenőrzéseket, amelyeket az alkalmazás megkövetel. Lásd még: [Open Presentations](/slides/hu/androidjava/open-presentation/) és [Save Presentations](/slides/hu/androidjava/save-presentation/).

## **GYIK**

**Képes egy figyelmeztető visszahívás kezelni minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett visszaállítható állapotokat kezeli. A visszahívástól függetlenül előforduló kivételeket az alkalmazásnak kell kezelnie a betöltés, renderelés, konvertálás vagy mentés hívása körül.

**Garantálja a `ReturnAction.Continue` visszaadása az azonos kimenetet?**

Nem. Csak engedélyezi a feldolgozás folytatását. A jelentett állapot továbbra is adat-, formázási vagy kompatibilitási eltéréseket okozhat, ezért ellenőrizze a gyűjtött figyelmeztetés típusokat és leírásokat.

**Hogyan tudja az alkalmazás azonosítani a figyelmeztetést eredményező műveletet?**

Hozzon létre egy visszahívás‑példányt minden művelethez, és tárolja az alkalmazás által definiált szakaszt a [getWarningType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) és a [getDescription](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értékekkel együtt, ahogy a példában látható.