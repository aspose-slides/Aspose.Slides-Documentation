---
title: Präsentationswarnungen in Node.js behandeln
type: docs
weight: 90
url: /de/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/holen-warnungs-callbacks-fuer-schriftarten-ersetzung-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellbeschädigung
- Kompatibilitätsproblem
- Schriftartenersetzung
- digitale Signatur
- Präsentationsladen
- Präsentationsrendering
- Präsentationskonvertierung
- Präsentationsspeicherung
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für Node.js über Java sammeln, klassifizieren und darauf reagieren können."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele umfassen beschädigte Quellaufzeichnungen, Inhalte, die nicht erhalten werden können, Schriftartenersatz und Einschränkungen des Zielformats. Ein Warn‑Callback ermöglicht einer Anwendung, diese Bedingungen zu protokollieren und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Verwenden Sie `java.newProxy`, um das [IWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarningcallback/) Java‑Interface in JavaScript zu implementieren und die über [IWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/) bereitgestellten Werte [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zu untersuchen. Geben Sie [ReturnAction.Continue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/returnaction/#Continue) zurück, um die Warnung zu akzeptieren, oder [ReturnAction.Abort](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/returnaction/#Abort), um den Vorgang zu stoppen.

Verwenden Sie [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) für Warnungen, die beim Öffnen einer Präsentation auftreten. Rendering‑ und Export‑Option‑Klassen erben [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), das Warnungen vom Folien‑Rendering, der Konvertierung und dem Speichern empfängt. Da die Warnung selbst die Anwendungsoperation nicht identifiziert, sollten Sie jede Callback‑Instanz mit einer Vorgangsphase verknüpfen, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, aus dem Aspose.Slides sich erholen kann, wenn das Callback `ReturnAction.Continue` zurückgibt. Eine Ausnahme bedeutet, dass die angeforderte Operation nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können von einer Warn‑Richtlinie nicht behandelt werden.

Die Rückgabe von `ReturnAction.Abort` veranlasst den Warn‑Dispatcher, die aktuelle Operation durch Auslösen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt von der Operation und dem Präsentationsformat ab. Beispielsweise kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxexception/) auftreten kann. Fangen Sie den Fehler von der Java‑Brücke am Rand der Operation und verwenden Sie den Warnbericht, um zu bestimmen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich auf einen einzigen Ausnahme‑Subtyp oder eine Nachricht zu verlassen. Das Callback protokolliert die Warnung, bevor es `ReturnAction.Abort` zurückgibt, wodurch der Grund für die Anwendung verfügbar bleibt.

## **Warnkategorien**

Die [WarningType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/) Klasse stellt Ganzzahlkonstanten für die folgenden Kategorien bereit:

| Warnungstyp | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Die Quellpräsentation enthält Beschädigungen, die ein im Originalformat gespeichertes Dokument unbrauchbar machen können. | Abbruch. |
| [DataLoss](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#DataLoss) | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbruch. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Die Präsentation kann wichtige Formatierungen verlieren. | Abbruch im strengen Validierungsmodus; andernfalls protokollieren und fortfahren. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Ein begrenzter Formatierungsunterschied kann auftreten. | Für Diagnosezwecke protokollieren und fortfahren. |
| [CompatibilityIssue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Das Ergebnis kann in einigen Anwendungen oder älteren Versionen nicht geöffnet werden oder nicht korrekt funktionieren. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| [UnexpectedContent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Die Quelle enthält nicht unterstützte oder nicht erkannte Inhalte, deren Wirkung noch nicht bekannt sein könnte. | Protokollieren und fortfahren, oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung bestimmen. Speichern Sie den von [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Wert für Diagnosen, aber verlassen Sie sich nicht auf dessen Formulierung für die Anwendungslogik, da der Nachrichtentext zwischen Warnszenarien und Produktversionen variieren kann.

## **Warnungen sammeln und klassifizieren**

Das folgende JavaScript‑Beispiel verwendet einen Anwendungs‑Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen beim Laden, Rendern, PDF‑Konvertieren und PPTX‑Speichern. Die Richtlinie bricht bei Quellbeschädigung oder Datenverlust ab, bricht optional bei erheblichen Formatierungsverlusten ab und fährt für andere Warnungen fort.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Geben Sie beim Erstellen von `WarningPolicy` `false` für `abortOnMajorFormattingLoss` an, wenn größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, kleinere Formatierungsverluste und unerwartete Inhalte bleiben im Bericht erhalten, selbst wenn die Operation fortgesetzt wird. Erweitern Sie `WarningPolicy.getAction`, wenn die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warnszenarien**

Warnungen können in verschiedenen Phasen eines Workflows auftreten:

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase ermöglicht der Anwendung, die Datei abzulehnen oder den gemeldeten Verlust ausdrücklich zu akzeptieren.
- **Schriftartenersatz:** Eine nicht verfügbare Schriftart kann ersetzt werden, während eine Folie gerendert oder exportiert wird. Schriftartenersatz‑Warnungen werden als `DataLoss` gemeldet, sodass die oben beschriebene strenge Richtlinie abortiert, selbst wenn die Anwendung einen bestimmten Ersatz als visuell akzeptabel ansehen würde. Um dieses Verhalten zu beobachten, verwenden Sie eine Eingabedatei, die Text in einer zur Laufzeit nicht verfügbaren Schriftart enthält. Die Warnungsbeschreibung identifiziert den Ersatz; konfigurieren Sie die erforderlichen Schriftarten oder [Schriftartenersatz‑Regeln](/slides/de/nodejs-java/font-substitution/), bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann auf Präsentations‑Records oder Funktionen stoßen, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn bekannt ist, dass Daten oder Formatierungen betroffen sind.
- **Formatkompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Funktionen weglassen oder ein Ergebnis erzeugen, das sich in einigen Anwendungen anders verhält. Zum Beispiel gibt das Speichern einer Präsentation mit mehr als acht horizontalen oder acht vertikalen Zeichenhilfen in ein legacy PPT einen `CompatibilityIssue` aus. Das Callback in der Speicherphase kann den Verlust protokollieren und fortfahren oder ihn ablehnen, wenn das Beibehalten aller Hilfen erforderlich ist.
- **Lade‑Verhalten:** Ladeoptionen und veraltete Verhaltensweisen können ebenfalls Warnungen erzeugen. Zum Beispiel identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) die Verwendung eines veralteten Präsentations‑Sperrverhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, Zielformat, der Operation und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario immer nur einer Kategorie zugeordnet wird.

## **Abgebrochene Vorgänge sicher behandeln**

Wenn ein Callback `ReturnAction.Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass ein Rendering‑ oder Speicherausgabe vollständig ist. Die Operation kann nach dem Erstellen einer Ausgabedatei, aber vor deren Abschluss, beendet werden.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine bestehende Präsentation erst, nachdem die Operation erfolgreich abgeschlossen wurde, der Warnbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft werden kann. So wird vermieden, dass eine gültige Quelldatei mit einem partiellen oder abgelehnten Ergebnis überschrieben wird.

Ein leerer Warnbericht garantiert nicht, dass jedes Quellfeature erhalten wurde. Führen Sie alle zusätzlichen Inhalts‑ und Sichtprüfungen durch, die von der Anwendung verlangt werden. Siehe auch [Open Presentations](/slides/de/nodejs-java/open-presentation/) und [Save Presentations](/slides/de/nodejs-java/save-presentation/).

## **FAQ**

**Kann ein Warn‑Callback jeden Aspose.Slides‑Fehler behandeln?**

Nein. Es behandelt wiederherstellbare Bedingungen, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung rund um den Ladevorgang, das Rendering, die Konvertierung oder den Speichervorgang behandelt werden.

**Garantiert die Rückgabe von `ReturnAction.Continue` identische Ausgabe?**

Nein. Sie erlaubt nur, dass die Verarbeitung fortgesetzt wird. Der gemeldete Zustand kann weiterhin Daten-, Formatierungs‑ oder Kompatibilitätsunterschiede verursachen, daher sollten die gesammelten Warnungstypen und Beschreibungen überprüft werden.

**Wie kann eine Anwendung die Operation ermitteln, die eine Warnung erzeugt hat?**

Erstellen Sie für jede Operation eine Callback‑Instanz und speichern Sie eine anwendungsdefinierte Phase zusammen mit den von [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Werten, wie im Beispiel gezeigt.