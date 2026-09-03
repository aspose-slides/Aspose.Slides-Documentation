---
title: Präsentationswarnungen in Java handhaben
type: docs
weight: 90
url: /de/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellbeschädigung
- Kompatibilitätsproblem
- Schriftart-Ersetzung
- digitale Signatur
- Laden der Präsentation
- Rendern der Präsentation
- Konvertierung der Präsentation
- Speichern der Präsentation
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für Java sammeln, klassifizieren und darauf reagieren."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele hierfür sind beschädigte Quellrecords, Inhalte, die nicht erhalten werden können, Schriftartersatz und Einschränkungen des Zielformats. Ein Warn‑Callback ermöglicht einer Anwendung, diese Bedingungen zu protokollieren und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Implementieren Sie das [IWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarningcallback/)‑Interface und untersuchen Sie die über [IWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/) bereitgestellten Werte [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--). Rückgabe von [ReturnAction.Continue](https://reference.aspose.com/slides/de/java/com.aspose.slides/returnaction/#Continue) akzeptiert die Warnung, oder [ReturnAction.Abort](https://reference.aspose.com/slides/de/java/com.aspose.slides/returnaction/#Abort), um den Vorgang zu beenden.

Verwenden Sie [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering‑ und Exportoption‑Klassen erben [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), das Warnungen vom Folien‑Rendering, der Konvertierung und dem Speichern empfängt. Da die Warnung selbst nicht die Anwendungsoperation identifiziert, ordnen Sie jeder Callback‑Instanz ein Operationsstadium zu, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction.Continue` zurückgibt. Eine Ausnahme bedeutet, dass der angeforderte Vorgang nicht regulär abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können nicht durch eine Warn‑Richtlinie behandelt werden.

Die Rückgabe von `ReturnAction.Abort` veranlasst den Warn‑Dispatcher, den aktuellen Vorgang durch Werfen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt vom Vorgang und vom Präsentationsformat ab. Beispielsweise kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxexception/) auftreten kann. Behandeln Sie die Ausnahme an der Grenze des Vorgangs und verwenden Sie den Warnbericht, um zu bestimmen, ob die Anwendungs‑Richtlinie die Beendigung verursacht hat, anstatt sich auf einen einzelnen Ausnahme‑Subtyp oder eine Nachricht zu verlassen. Der Callback protokolliert die Warnung, bevor er `ReturnAction.Abort` zurückgibt, sodass der Grund für die Anwendung verfügbar bleibt.

## **Warnkategorien**

Die [WarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/)‑Klasse stellt ganzzahlige Konstanten für die folgenden Kategorien bereit:

| Warntyp | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Die Quellpräsentation enthält Beschädigungen, die ein im Originalformat gespeichertes Dokument unbrauchbar machen können. | Abbruch. |
| [DataLoss](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#DataLoss) | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbruch. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Die Präsentation kann wichtige Formatierungen verlieren. | Abbruch im strengen Validierungsmodus; sonst protokollieren und fortfahren. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Es kann ein begrenzter Formatierungsunterschied auftreten. | Für Diagnose protokollieren und fortfahren. |
| [CompatibilityIssue](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Das Ergebnis kann in einigen Anwendungen oder älteren Versionen nicht geöffnet werden oder nicht korrekt funktionieren. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| [UnexpectedContent](https://reference.aspose.com/slides/de/java/com.aspose.slides/warningtype/#UnexpectedContent) | Die Quelle enthält nicht unterstützte oder nicht erkennbare Inhalte, deren Wirkung noch nicht bekannt sein könnte. | Protokollieren und fortfahren oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung steuern. Speichern Sie den von [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Wert für Diagnosezwecke, jedoch sollten Sie nicht von seiner Formulierung für Anwendungslogik abhängen, da der Meldungstext zwischen Warnszenarien und Produktversionen variieren kann.

## **Sammeln und Klassifizieren von Warnungen**

Das folgende Beispiel verwendet einen anwendungsübergreifenden Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen beim Laden, Rendern, der PDF‑Konvertierung und dem PPTX‑Speichern. Die Richtlinie bricht bei Quellbeschädigung oder Datenverlust ab, bricht optional bei großem Formatierungsverlust ab und fährt bei anderen Warnungen fort.

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

Übergeben Sie `false` für `abortOnMajorFormattingLoss` beim Erzeugen von `WarningPolicy`, wenn größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, kleiner Formatierungsverlust und unerwartete Inhalte bleiben weiterhin im Bericht erhalten, selbst wenn der Vorgang fortgesetzt wird. Erweitern Sie `WarningPolicy.getAction`, wenn die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warnszenarien**

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase ermöglicht der Anwendung, die Datei abzulehnen oder den gemeldeten Verlust ausdrücklich zu akzeptieren.
- **Schriftartersatz:** Eine nicht verfügbare Schriftart kann ersetzt werden, während eine Folie gerendert oder exportiert wird. Schriftartersatz‑Warnungen werden als `DataLoss` gemeldet, sodass die obige strenge Richtlinie abbricht, selbst wenn die Anwendung einen bestimmten Ersatz visuell akzeptabel finden würde. Um dieses Verhalten zu beobachten, verwenden Sie eine Eingabepäsentation, die Text in einer zur Laufzeit nicht verfügbaren Schriftart enthält. Die Warnungsbeschreibung identifiziert den Ersatz; konfigurieren Sie die erforderlichen Schriftarten oder [font substitution rules](/slides/de/java/font-substitution/) bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann Präsentationsrecords oder Funktionen begegnen, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn Daten oder Formatierungen bekannterweise betroffen sind.
- **Formatkompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Funktionen weglassen oder ein Ergebnis erzeugen, das sich in einigen Anwendungen anders verhält. Beispielsweise meldet das Speichern einer Präsentation mit mehr als acht horizontalen oder acht vertikalen Zeichenhilfen zu einem Legacy‑PPT eine `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust protokollieren und fortfahren oder ihn ablehnen, wenn das Beibehalten aller Hilfen erforderlich ist.
- **Ladeverhalten:** Ladeoptionen und Legacy‑Verhalten können ebenfalls Warnungen erzeugen. Beispielsweise identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) die Verwendung eines veralteten Präsentations‑Locking‑Verhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, Zielformat, Vorgang und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario immer nur einer Kategorie zugeordnet werden kann.

## **Sicheres Vorgehen bei abgebrochenen Vorgängen**

Wenn ein Callback `ReturnAction.Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass eine Render‑ oder Speicher‑Ausgabe vollständig ist. Der Vorgang kann nach dem Erzeugen einer Ausgabedatei, aber vor dessen Fertigstellung beendet werden.

Speichern Sie validierte Ergebnisse in einen separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, wenn der Vorgang erfolgreich abgeschlossen ist, der Warnbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und überprüft werden kann. So wird vermieden, dass eine gültige Quelldatei durch ein partielles oder abgelehntes Ergebnis überschrieben wird.

Ein leerer Warnbericht garantiert nicht, dass jedes Quell‑Feature erhalten wurde. Führen Sie alle zusätzlichen Inhalts‑ und visuellen Prüfungen durch, die die Anwendung erfordert. Siehe auch [Open Presentations](/slides/de/java/open-presentation/) und [Save Presentations](/slides/de/java/save-presentation/).

## **FAQ**

**Kann ein Warn‑Callback jeden Aspose.Slides‑Fehler behandeln?**

Nein. Er behandelt wiederherstellbare Bedingungen, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung rund um den Ladevorgang, das Rendering, die Konvertierung oder den Speicheraufruf behandelt werden.

**Garantiert die Rückgabe von `ReturnAction.Continue` identische Ausgabe?**

Nein. Sie erlaubt lediglich, dass die Verarbeitung fortgesetzt wird. Der gemeldete Zustand kann weiterhin Daten-, Formatierungs‑ oder Kompatibilitätsunterschiede verursachen, daher sollten Sie die gesammelten Warnungstypen und Beschreibungen prüfen.

**Wie kann eine Anwendung die Operation identifizieren, die eine Warnung ausgelöst hat?**

Erstellen Sie für jede Operation eine Callback‑Instanz und speichern Sie ein anwendungsdefiniertes Stadium zusammen mit den von [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Werten, wie im Beispiel gezeigt.