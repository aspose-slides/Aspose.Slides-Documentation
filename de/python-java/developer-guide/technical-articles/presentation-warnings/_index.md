---
title: Verarbeiten von Präsentationswarnungen in Python über Java
type: docs
weight: 90
url: /de/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellbeschädigung
- Kompatibilitätsproblem
- Schriftartenersatz
- digitale Signatur
- Präsentationsladen
- Präsentationsrendering
- Präsentationskonvertierung
- Präsentationsspeichern
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für Python über Java sammeln, klassifizieren und darauf reagieren."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele sind beschädigte Quellaufzeichnungen, Inhalte, die nicht erhalten werden können, Schriftartenersatz und Einschränkungen des Zielformats. Ein Warn‑Callback ermöglicht einer Anwendung, diese Bedingungen aufzuzeichnen und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Implementieren Sie die `IWarningCallback`‑Schnittstelle über `jpype.JProxy` und prüfen Sie die über `IWarningInfo` bereitgestellten Werte `getWarningType` und `getDescription`. Geben Sie [ReturnAction.Continue](https://reference.aspose.com/slides/de/python-java/aspose.slides/returnaction/#Continue) zurück, um die Warnung zu akzeptieren, oder [ReturnAction.Abort](https://reference.aspose.com/slides/de/python-java/aspose.slides/returnaction/#Abort), um den Vorgang zu stoppen.

Verwenden Sie [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setWarningCallback) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering‑ und Export‑Option‑Klassen erben [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setWarningCallback), das Warnungen vom Folienrendering, der Konvertierung und dem Speichern erhält. Da die Warnung selbst die Anwendungsoperation nicht identifiziert, verknüpfen Sie jede Callback‑Instanz mit einer Operationsstufe, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction.Continue` zurückgibt. Eine Ausnahme bedeutet, dass der angeforderte Vorgang nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können nicht durch eine Warnrichtlinie behandelt werden.

Das Zurückgeben von `ReturnAction.Abort` weist den Warnungsdispatcher an, den aktuellen Vorgang durch Auslösen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt vom Vorgang und vom Präsentationsformat ab. Zum Beispiel kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxexception/) auftreten kann. Behandeln Sie die Ausnahme an der Grenze des Vorgangs und verwenden Sie den Warnbericht, um festzustellen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich auf einen Ausnahmetyp oder eine Nachricht zu verlassen. Der Callback zeichnet die Warnung auf, bevor er `ReturnAction.Abort` zurückgibt, sodass der Grund der Anwendung weiterhin zur Verfügung steht.

## **Warnkategorien**

Die [WarningType](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/)‑Klasse stellt Ganzzahlkonstanten für die folgenden Kategorien bereit:

| Warnungsart | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Die Quellpräsentation enthält Beschädigungen, die ein im Originalformat gespeichertes Dokument unbrauchbar machen können. | Abbrechen. |
| [DataLoss](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#DataLoss) | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbrechen. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Die Präsentation kann wichtige Formatierungen verlieren. | Abbruch im strengen Validierungsmodus; andernfalls aufzeichnen und fortfahren. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Eine begrenzte Formatierungsabweichung kann auftreten. | Zur Diagnose aufzeichnen und fortfahren. |
| [CompatibilityIssue](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Das Ergebnis wird in manchen Anwendungen oder älteren Versionen möglicherweise nicht geöffnet oder funktioniert nicht korrekt. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| [UnexpectedContent](https://reference.aspose.com/slides/de/python-java/aspose.slides/warningtype/#UnexpectedContent) | Die Quelle enthält nicht unterstützte oder nicht erkannte Inhalte, deren Wirkung noch nicht bekannt sein könnte. | Aufzeichnen und fortfahren, oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung steuern. Speichern Sie den von `getDescription` zurückgegebenen Wert zu Diagnosezwecken, verlassen Sie sich jedoch nicht auf den genauen Wortlaut für Anwendungslogik, da der Meldungstext je nach Warnszenario und Produktversion variieren kann.

## **Warnungen sammeln und klassifizieren**

Das folgende Beispiel verwendet einen anwendungsübergreifenden Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen aus Laden, Rendern, PDF‑Konvertierung und PPTX‑Speicherung. Die Richtlinie bricht bei Quellbeschädigung oder Datenverlust ab, bricht optional bei großem Formatierungsverlust ab und fährt bei anderen Warnungen fort.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Geben Sie `False` für `abort_on_major_formatting_loss` an, wenn Sie `WarningPolicy` erstellen und größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, kleiner Formatierungsverlust und unerwarteter Inhalt bleiben dennoch im Bericht erhalten, selbst wenn der Vorgang weiterläuft. Erweitern Sie `WarningPolicy.get_action`, wenn die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warnszenarien**

Warnungen können in verschiedenen Phasen eines Workflows auftreten:

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über `IPresentationSignedWarningInfo`. Ein Callback in der Ladephase lässt die Anwendung die Datei ablehnen oder den gemeldeten Verlust explizit akzeptieren.
- **Schriftartenersatz:** Eine nicht verfügbare Schriftart kann während des Renderns oder Exportierens einer Folie ersetzt werden. Schriftartenersatz‑Warnungen werden als `DataLoss` gemeldet, sodass die oben beschriebene strenge Richtlinie sogar dann abbricht, wenn die Anwendung den Ersatz visuell akzeptieren würde. Verwenden Sie dafür eine Eingabedatei, die Text in einer für die Laufzeit nicht verfügbaren Schriftart enthält. Die Warnungsbeschreibung identifiziert den Ersatz; konfigurieren Sie die erforderlichen Schriften oder [font substitution rules](/slides/de/python-java/font-substitution/) bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann Präsentations‑Records oder Features begegnen, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn Daten oder Formatierungen nachweislich betroffen sind.
- **Formatkompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Funktionen weglassen oder ein Ergebnis erzeugen, das sich in manchen Anwendungen anders verhält. Beispielsweise meldet das Speichern einer Präsentation mit mehr als acht horizontalen oder acht vertikalen Zeichenlinien im Legacy‑PPT-Format einen `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust aufzeichnen und fortfahren oder ihn ablehnen, wenn das Beibehalten aller Linien erforderlich ist.
- **Ladeverhalten:** Ladeoptionen und veraltete Verhaltensweisen können ebenfalls Warnungen erzeugen. Beispielsweise identifiziert `IObsoletePresLockingBehaviorWarningInfo` die Verwendung eines veralteten Präsentations‑Locking‑Verhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, Zielformat, Vorgang und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario immer nur einer Kategorie zugeordnet werden kann.

## **Abgebrochene Vorgänge sicher handhaben**

Wenn ein Callback `ReturnAction.Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass ein Rendering‑ oder Speicher‑Ergebnis vollständig ist. Der Vorgang kann nach Erzeugen einer Ausgabedatei, aber bevor sie fertiggestellt ist, beendet werden.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, nachdem der Vorgang erfolgreich abgeschlossen, der Warnbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft werden kann. So vermeiden Sie, dass eine gültige Quelldatei mit einem unvollständigen oder abgelehnten Ergebnis überschrieben wird.

Ein leerer Warnbericht garantiert nicht, dass jedes Quell‑Feature erhalten geblieben ist. Führen Sie alle zusätzlichen Inhalts‑ und visuellen Prüfungen durch, die die Anwendung erfordert. Siehe auch [Präsentationen öffnen](/slides/de/python-java/open-presentation/) und [Präsentationen speichern](/slides/de/python-java/save-presentation/).

## **FAQ**

**Kann ein Warn‑Callback jeden Aspose.Slides‑Fehler behandeln?**

Nein. Er behandelt nur wiederherstellbare Zustände, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung um den Ladevorgang, das Rendern, die Konvertierung oder den Speicheraufruf herum behandelt werden.

**Garantiert das Zurückgeben von `ReturnAction.Continue` identische Ausgabe?**

Nein. Es erlaubt lediglich das Fortsetzen der Verarbeitung. Der gemeldete Zustand kann weiterhin Daten-, Formatierungs‑ oder Kompatibilitätsunterschiede verursachen, sodass die gesammelten Warnungstypen und Beschreibungen geprüft werden sollten.

**Wie kann eine Anwendung die Operation identifizieren, die eine Warnung erzeugt hat?**

Erstellen Sie für jede Operation eine Callback‑Instanz und speichern Sie zusammen mit den von `getWarningType` und `getDescription` zurückgegebenen Werten eine anwendungsspezifische Phase, wie im Beispiel gezeigt.