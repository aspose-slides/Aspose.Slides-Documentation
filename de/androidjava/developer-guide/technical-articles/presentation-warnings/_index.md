---
title: Warnungen bei Präsentationen auf Android behandeln
type: docs
weight: 90
url: /de/androidjava/presentation-warnings/
aliases:
- /androidjava/abrufen-warnungs-callbacks-fuer-schriften-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellenkorruption
- Kompatibilitätsproblem
- Schriftart-Substitution
- digitale Signatur
- Laden der Präsentation
- Rendern der Präsentation
- Konvertierung der Präsentation
- Speichern der Präsentation
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für Android via Java erfassen, klassifizieren und behandeln."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele sind beschädigte Quellaufzeichnungen, Inhalte, die nicht erhalten werden können, Font-Substitution und Beschränkungen des Zielformats. Ein Warnungs‑Callback ermöglicht einer Anwendung, diese Bedingungen zu protokollieren und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Implementieren Sie die [IWarningCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarningcallback/) Schnittstelle und prüfen Sie die über [IWarningInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/) bereitgestellten Werte von [getWarningType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/#getDescription--). Geben Sie [ReturnAction.Continue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/returnaction/#Continue) zurück, um die Warnung zu akzeptieren, oder [ReturnAction.Abort](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/returnaction/#Abort), um den Vorgang zu beenden.

Verwenden Sie [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering- und Exportoption‑Klassen erben von [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), die Warnungen vom Folien‑Rendering, der Konvertierung und dem Speichern empfängt. Da die Warnung selbst die Anwendungsoperation nicht identifiziert, ordnen Sie jeder Callback‑Instanz eine Betriebsstufe zu, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction.Continue` zurückgibt. Eine Ausnahme bedeutet, dass der angeforderte Vorgang nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können nicht durch eine Warnungsrichtlinie behandelt werden.

Durch Rückgabe von `ReturnAction.Abort` wird der Warnungs‑Dispatcher aufgefordert, den aktuellen Vorgang durch Auslösen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt vom Vorgang und vom Präsentationsformat ab. Zum Beispiel kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxexception/) auftreten kann. Behandeln Sie die Ausnahme an der Grenze des Vorgangs und nutzen Sie den Warnungsbericht, um festzustellen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich auf einen einzelnen Ausnahmetyp oder eine Nachricht zu verlassen. Der Callback protokolliert die Warnung, bevor er `ReturnAction.Abort` zurückgibt, sodass der Grund für die Anwendung verfügbar bleibt.

## **Warnungskategorien**

Die Klasse [WarningType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/) stellt ganzzahlige Konstanten für die folgenden Kategorien bereit:

| Warnungsart | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Die Quellpräsentation enthält Beschädigungen, die ein im ursprünglichen Format gespeichertes Dokument unbrauchbar machen können. | Abbrechen. |
| [DataLoss](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#DataLoss) | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbrechen. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Die Präsentation kann wichtige Formatierungen verlieren. | Abbruch im strengen Validierungsmodus; sonst protokollieren und fortfahren. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Es kann zu einer begrenzten Formatierungsabweichung kommen. | Zur Diagnose protokollieren und fortfahren. |
| [CompatibilityIssue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Das Ergebnis kann in einigen Anwendungen oder älteren Versionen nicht öffnen oder korrekt funktionieren. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| [UnexpectedContent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Die Quelle enthält nicht unterstützte oder nicht erkennbare Inhalte, deren Wirkung noch unbekannt sein kann. | Protokollieren und fortfahren, oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtliniendekision steuern. Speichern Sie den von [getDescription](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Wert zu Diagnosezwecken, verlassen Sie sich jedoch nicht auf dessen Formulierung für Anwendungslogik, da der Text je nach Warnungsszenario und Produktversion variieren kann.

## **Warnungen sammeln und klassifizieren**

Das folgende Beispiel verwendet einen anwendungsweiten Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen aus Laden, Rendern, PDF‑Konvertierung und PPTX‑Speicherung. Die Richtlinie bricht bei Quellenkorruption oder Datenverlust ab, bricht optional bei großem Formatierungsverlust ab und fährt für andere Warnungen fort.

Platzieren Sie `input.pptx` in einem beschreibbaren Anwendungsverzeichnis und übergeben Sie dieses Verzeichnis an `PresentationWarningExample.run`. Das Beispiel speichert seine Ausgaben im selben Verzeichnis. Führen Sie die Präsentationsverarbeitung in einem Hintergrund‑Thread aus, damit die Android‑Benutzeroberfläche reaktionsfähig bleibt.

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

Übergeben Sie `false` für `abortOnMajorFormattingLoss`, wenn Sie `WarningPolicy` erstellen, falls größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, geringfügiger Formatierungsverlust und unerwartete Inhalte bleiben dennoch im Bericht erhalten, selbst wenn der Vorgang weiterläuft. Erweitern Sie `WarningPolicy.getAction`, falls die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warnungs‑Szenarien**

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase ermöglicht der Anwendung, die Datei abzulehnen oder den gemeldeten Verlust explizit zu akzeptieren.
- **Font‑Substitution:** Eine nicht verfügbare Schriftart kann ersetzt werden, während eine Folie gerendert oder exportiert wird. Font‑Substitutions‑Warnungen werden als `DataLoss` gemeldet, sodass die oben genannte strenge Richtlinie abortiert, selbst wenn die Anwendung einen bestimmten Ersatz visuell akzeptabel findet. Um dieses Verhalten zu beobachten, verwenden Sie eine Eingabepäsentation, die Text in einer für die Laufzeit nicht verfügbaren Schriftart enthält. Die Warnungsbeschreibung identifiziert die Substitution; konfigurieren Sie die erforderlichen Schriften oder [Font‑Substitutions‑Regeln](/slides/de/androidjava/font-substitution/), bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann auf Präsentations‑Records oder Features stoßen, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerere Kategorie, wenn Daten oder Formatierungen bekanntermaßen betroffen sind.
- **Format‑Kompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Features weglassen oder ein Ergebnis erzeugen, das sich in einigen Anwendungen anders verhält. Beispielsweise meldet das Speichern einer Präsentation mit mehr als acht horizontalen oder vertikalen Zeichenhilfen an einem Legacy‑PPT einen `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust protokollieren und fortfahren oder ihn ablehnen, wenn das Beibehalten aller Hilfen erforderlich ist.
- **Ladeverhalten:** Ladeoptionen und Legacy‑Verhalten können ebenfalls Warnungen erzeugen. Zum Beispiel identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) die Verwendung eines veralteten Präsentations‑Locking‑Verhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, Ziel‑Format, Vorgang und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario stets nur einer Kategorie zugeordnet werden kann.

## **Abgebrochene Vorgänge sicher handhaben**

Wenn ein Callback `ReturnAction.Abort` zurückgibt, verwenden Sie kein Objekt, das das Laden fehlgeschlagen ist, und gehen Sie nicht davon aus, dass ein Rendering‑ oder Speicher‑Output vollständig ist. Der Vorgang kann nach dem Erzeugen einer Ausgabedatei, aber vor deren Abschluss beendet werden.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, nachdem der Vorgang erfolgreich abgeschlossen ist, der Warnungsbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft werden kann. Dadurch wird vermieden, dass eine gültige Quelldatei mit einem teilweisen oder abgelehnten Ergebnis überschrieben wird.

Ein leerer Warnungsbericht garantiert nicht, dass jedes Quell‑Feature erhalten wurde. Führen Sie alle zusätzlichen Inhalts‑ und Visuell‑Checks durch, die die Anwendung erfordert. Siehe auch [Open Presentations](/slides/de/androidjava/open-presentation/) und [Save Presentations](/slides/de/androidjava/save-presentation/).

## **FAQ**

**Kann ein Warnungs‑Callback jeden Aspose.Slides‑Fehler behandeln?**

Nein. Er behandelt nur wiederherstellbare Zustände, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung rund um den Lade‑, Render‑, Konvertierungs‑ oder Speicheraufruf behandelt werden.

**Garantiert die Rückgabe von `ReturnAction.Continue` identische Ausgabe?**

Nein. Sie lässt lediglich zu, dass die Verarbeitung fortgesetzt wird. Der gemeldete Zustand kann dennoch zu Daten‑, Formatierungs‑ oder Kompatibilitäts‑Unterschieden führen, sodass die gesammelten Warnungs‑Typen und Beschreibungen geprüft werden sollten.

**Wie kann eine Anwendung die Operation ermitteln, die eine Warnung erzeugt hat?**

Erstellen Sie für jede Operation eine eigene Callback‑Instanz und speichern Sie eine anwendungsspezifische Stufe zusammen mit den Werten, die von [getWarningType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegeben werden, wie im Beispiel gezeigt.