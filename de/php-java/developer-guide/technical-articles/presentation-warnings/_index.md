---
title: Verarbeitung von Präsentationswarnungen in PHP
type: docs
weight: 90
url: /de/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellkorruption
- Kompatibilitätsproblem
- Schriftartenersatz
- digitale Signatur
- Präsentationsladen
- Präsentationsrendering
- Präsentationskonvertierung
- Präsentationsspeicherung
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für PHP über Java sammeln, klassifizieren und darauf reagieren."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele sind beschädigte Quellaufzeichnungen, Inhalte, die nicht erhalten werden können, Schriftartenersatz und Einschränkungen des Zielformats. Ein Warn-Callback ermöglicht es einer Anwendung, diese Bedingungen zu protokollieren und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Erstellen Sie eine PHP-Klasse mit einer öffentlichen `warning`-Methode und stellen Sie sie über PHP Java Bridge als Java-[IWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarningcallback/)‑Schnittstelle mithilfe von `java_closure` bereit. Untersuchen Sie die Werte von [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--), die über [IWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/) bereitgestellt werden. Geben Sie [ReturnAction::Continue](https://reference.aspose.com/slides/de/php-java/aspose.slides/returnaction/#Continue) zurück, um die Warnung zu akzeptieren, oder [ReturnAction::Abort](https://reference.aspose.com/slides/de/php-java/aspose.slides/returnaction/#Abort), um den Vorgang abzubrechen.

Verwenden Sie [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setWarningCallback) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering‑ und Export‑Klassen erben von [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveoptions/#setWarningCallback), die Warnungen vom Folien-Rendering, der Konvertierung und dem Speichern erhalten. Da die Warnung selbst die Anwendungsoperation nicht identifiziert, verknüpfen Sie jede Callback‑Instanz mit einer Operationsstufe, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Java-Ausnahmen werden über PHP Java Bridge in PHP bereitgestellt; fangen Sie sie an der Operationsgrenze ab, wie im nachfolgenden Beispiel gezeigt. Die Java-Schnittstellen-Links in diesem Artikel beschreiben den von der Bridge verwendeten Callback-Vertrag.

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction::Continue` zurückgibt. Eine Ausnahme bedeutet, dass die angeforderte Operation nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können nicht durch eine Warnungs‑Richtlinie behandelt werden.

Die Rückgabe von `ReturnAction::Abort` veranlasst den Warnungs-Dispatcher, die aktuelle Operation durch Auslösen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt von der Operation und dem Präsentationsformat ab. Zum Beispiel kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxexception/) auftreten kann. Behandeln Sie die Ausnahme an der Grenze der Operation und verwenden Sie den Warnungsbericht, um zu bestimmen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich auf einen einzelnen Ausnahmetyp oder eine Meldung zu verlassen. Der Callback protokolliert die Warnung, bevor er `ReturnAction::Abort` zurückgibt, sodass der Grund für die Anwendung verfügbar bleibt.

## **Warnungskategorien**

Die Klasse [WarningType](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/) stellt Ganzzahlkonstanten für die folgenden Kategorien bereit:

| Warnungstyp | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Die Quellpräsentation enthält Beschädigungen, die ein im Originalformat gespeichertes Dokument unbrauchbar machen können. | Abbrechen. |
| [DataLoss](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#DataLoss) | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbrechen. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Die Präsentation kann wichtige Formatierungen verlieren. | Im strengen Validierungsmodus abbrechen; sonst protokollieren und fortfahren. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Es kann ein geringfügiger Formatierungsunterschied auftreten. | Für Diagnosezwecke protokollieren und fortfahren. |
| [CompatibilityIssue](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Das Ergebnis kann in einigen Anwendungen oder älteren Versionen nicht geöffnet werden oder nicht korrekt funktionieren. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| [UnexpectedContent](https://reference.aspose.com/slides/de/php-java/aspose.slides/warningtype/#UnexpectedContent) | Die Quelle enthält nicht unterstützte oder nicht erkannte Inhalte, deren Wirkung noch unbekannt sein kann. | Protokollieren und fortfahren oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung steuern. Speichern Sie den von [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Wert für Diagnosezwecke, verlassen Sie sich jedoch nicht auf den Wortlaut für die Anwendungslogik, da der Meldungstext zwischen Warnungsszenarien und Produktversionen variieren kann.

## **Sammeln und Klassifizieren von Warnungen**

Das folgende Beispiel verwendet einen Anwendungs-Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback-Instanz kennzeichnet Warnungen aus Laden, Rendern, PDF-Konvertierung und PPTX-Speicherung. Die Richtlinie bricht bei Quellkorruption oder Datenverlust ab, bricht optional bei gravierendem Formatierungsverlust ab und fährt bei anderen Warnungen fort. Der Callback wandelt Warnungswerte vor dem Protokollieren und Vergleichen mit `java_values` in native PHP-Werte um.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Geben Sie beim Erzeugen von `WarningPolicy` `false` für `abortOnMajorFormattingLoss` an, wenn gravierende Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, geringfügiger Formatierungsverlust und unerwartete Inhalte bleiben dennoch im Bericht erhalten, auch wenn die Operation fortgesetzt wird. Erweitern Sie `WarningPolicy::getAction`, falls die Anwendung eine Ablehnung einer dieser Kategorien erfordern sollte.

## **Typische Warnungsszenarien**

Warnungen können in verschiedenen Phasen eines Workflows auftreten:

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase ermöglicht es der Anwendung, die Datei abzulehnen oder den gemeldeten Verlust ausdrücklich zu akzeptieren.
- **Schriftartenersatz:** Ein nicht verfügbare Schriftart kann während des Renderns oder Exportierens einer Folie ersetzt werden. Schriftarten‑Ersatz‑Warnungen werden als `DataLoss` gemeldet, sodass die oben beschriebene strenge Richtlinie selbst dann abbricht, wenn die Anwendung einen bestimmten Ersatz visuell akzeptabel finden würde. Um dieses Verhalten zu beobachten, verwenden Sie eine Eingabepäsentation, die Text in einer Schriftart enthält, die zur Laufzeit nicht verfügbar ist. Die Warnungsbeschreibung identifiziert den Ersatz; konfigurieren Sie die benötigten Schriftarten oder [font substitution rules](/slides/de/php-java/font-substitution/) bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann Präsentations-Records oder Funktionen finden, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn Daten oder Formatierungen bekanntermaßen betroffen sind.
- **Formatkompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Features weglassen oder ein Ergebnis erzeugen, das sich in einigen Anwendungen anders verhält. Beispielsweise meldet das Speichern einer Präsentation mit mehr als acht horizontalen oder acht vertikalen Zeichenführungen im Legacy-PPT-Format einen `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust protokollieren und fortfahren oder ihn ablehnen, wenn das Beibehalten aller Führungen erforderlich ist.
- **Ladeverhalten:** Ladeoptionen und veraltete Verhaltensweisen können ebenfalls Warnungen erzeugen. Beispielsweise identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) die Verwendung eines veralteten Präsentations‑Sperrverhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, dem Zielformat, der Operation und der Aspose.Slides-Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario immer nur einer einzigen Kategorie zugeordnet werden kann.

## **Sicheres Vorgehen bei abgebrochenen Operationen**

Wenn ein Callback `ReturnAction::Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass ein Rendering- oder Speicherergebnis vollständig ist. Die Operation kann nach dem Erzeugen einer Ausgabedatei, aber vor deren Abschluss beendet werden.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, nachdem die Operation erfolgreich abgeschlossen, der Warnungsbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft werden kann. So vermeiden Sie, dass eine gültige Quelldatei mit einem teilweisen oder abgelehnten Ergebnis überschrieben wird.

Ein leerer Warnungsbericht garantiert nicht, dass jedes Quellfeature erhalten wurde. Führen Sie alle zusätzlichen Inhalts- und Sichtprüfungen durch, die von der Anwendung gefordert werden. Siehe außerdem [Open Presentations](/slides/de/php-java/open-presentation/) und [Save Presentations](/slides/de/php-java/save-presentation/).

## **FAQ**

**Kann ein Warn-Callback jeden Aspose.Slides-Fehler behandeln?**

Nein. Er behandelt wiederherstellbare Bedingungen, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung rund um den Ladevorgang, das Rendering, die Konvertierung oder das Speichern herum behandelt werden.

**Garantiert die Rückgabe von `ReturnAction::Continue` identische Ausgabe?**

Nein. Sie erlaubt lediglich, den Vorgang fortzusetzen. Der gemeldete Zustand kann weiterhin zu Daten-, Formatierungs- oder Kompatibilitätsunterschieden führen, sodass die gesammelten Warnungstypen und -beschreibungen überprüft werden sollten.

**Wie kann eine Anwendung die Operation identifizieren, die eine Warnung erzeugt hat?**

Erstellen Sie für jede Operation eine Callback-Instanz und speichern Sie eine von der Anwendung definierte Stufe zusammen mit den von [getWarningType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getWarningType--) und [getDescription](https://reference.aspose.com/slides/de/java/com.aspose.slides/iwarninginfo/#getDescription--) zurückgegebenen Werten, wie im Beispiel gezeigt.