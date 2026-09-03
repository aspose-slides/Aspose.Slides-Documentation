---
title: Behandlung von Präsentationswarnungen in .NET
type: docs
weight: 120
url: /de/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellkorruption
- Kompatibilitätsproblem
- Schriftartsubstitution
- Digitale Signatur
- Präsentationsladen
- Präsentationsrendering
- Präsentationskonvertierung
- Präsentationsspeicherung
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für .NET sammeln, klassifizieren und darauf reagieren."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, während es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele sind beschädigte Quelldatensätze, Inhalte, die nicht erhalten werden können, Schriftart‑Substitution und Einschränkungen des Zielformats. Ein Warn‑Callback ermöglicht es einer Anwendung, diese Bedingungen aufzuzeichnen und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Implementieren Sie das [IWarningCallback](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/iwarningcallback/) Interface und prüfen Sie die Eigenschaften [WarningType](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/iwarninginfo/warningtype/) und [Description](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/iwarninginfo/description/), die über [IWarningInfo](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/iwarninginfo/) bereitgestellt werden. Geben Sie [ReturnAction.Continue](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/returnaction/) zurück, um die Warnung zu akzeptieren, oder `ReturnAction.Abort`, um den Vorgang zu stoppen.

Verwenden Sie [LoadOptions.WarningCallback](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/warningcallback/) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering‑ und Exportoption‑Klassen erben [SaveOptions.WarningCallback](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/warningcallback/), die Warnungen vom Folien‑Rendering, der Konvertierung und dem Speichern empfängt. Da die Warnung selbst die Anwendungsoperation nicht identifiziert, ordnen Sie jeder Callback‑Instanz ein Operationsstadium zu, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction.Continue` zurückgibt. Eine Ausnahme bedeutet, dass der angeforderte Vorgang nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können von einer Warnungsrichtlinie nicht behandelt werden.

Das Zurückgeben von `ReturnAction.Abort` veranlasst den Warnungs‑Dispatcher, den aktuellen Vorgang durch Auslösen einer Ausnahme zu beenden. Die ausgelöste Ausnahme hängt vom Vorgang und dem Präsentationsformat ab. Zum Beispiel kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/net/aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) ausgelöst werden kann. Behandeln Sie die Ausnahme an der Grenze des Vorgangs und verwenden Sie den Warnbericht, um zu bestimmen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich nur auf einen Ausnahme‑Untertyp oder eine Meldung zu verlassen. Der Callback zeichnet die Warnung auf, bevor er `ReturnAction.Abort` zurückgibt, sodass der Grund für die Anwendung weiterhin verfügbar bleibt.

## **Warnkategorien**

Die Aufzählung [WarningType](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/warningtype/) liefert die folgenden Kategorien:

| Warnungstyp | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| `SourceFileCorruption` | Die Quellpräsentation enthält Korruption, die ein im Originalformat gespeichertes Dokument unbrauchbar machen kann. | Abbruch. |
| `DataLoss` | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbruch. |
| `MajorFormattingLoss` | Die Präsentation kann wichtige Formatierungen verlieren. | Abbruch im strengen Validierungsmodus; sonst aufzeichnen und fortfahren. |
| `MinorFormattingLoss` | Es kann ein begrenzter Formatierungsunterschied auftreten. | Zur Diagnose aufzeichnen und fortfahren. |
| `CompatibilityIssue` | Das Ergebnis kann in einigen Anwendungen oder älteren Versionen nicht geöffnet werden oder sich nicht korrekt verhalten. | Protokollieren und fortfahren, es sei denn, Kompatibilität ist zwingend erforderlich. |
| `UnexpectedContent` | Die Quelle enthält nicht unterstützte oder nicht erkannte Inhalte, deren Auswirkung möglicherweise noch nicht bekannt ist. | Aufzeichnen und fortfahren, oder in einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung bestimmen. Speichern Sie `Description` für Diagnosezwecke, aber verlassen Sie sich nicht auf die Formulierung für Anwendungslogik, da der Meldungstext zwischen Warnszenarien und Produktversionen variieren kann.

## **Warnungen sammeln und klassifizieren**

Das folgende Beispiel verwendet einen anwendungsbezogenen Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen aus Laden, Rendering, PDF‑Konvertierung und PPTX‑Speichern. Die Richtlinie bricht bei Quellkorruption oder Datenverlust ab, bricht optional bei gravierendem Formatierungsverlust ab und fährt bei anderen Warnungen fort.

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

Setzen Sie `abortOnMajorFormattingLoss` auf `false`, wenn größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, geringfügige Formatierungsverluste und unerwartete Inhalte verbleiben weiterhin im Bericht, selbst wenn der Vorgang fortgesetzt wird. Erweitern Sie `WarningPolicy.GetAction`, wenn die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warnszenarien**

Warnungen können in verschiedenen Phasen eines Workflows auftreten:

- **Digital signatures:** Eine signierte Präsentation kann beim Laden eine Warnung ausgeben, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase lässt die Anwendung die Datei ablehnen oder den gemeldeten Verlust ausdrücklich akzeptieren.
- **Font substitution:** Eine nicht verfügbare Schriftart kann während des Renderns oder Exportierens einer Folie ersetzt werden. Schriftart‑Substitutionswarnungen werden als `DataLoss` gemeldet, sodass die oben genannte strenge Richtlinie abortiert, selbst wenn die Anwendung einen bestimmten Ersatz visuell akzeptabel findet. Verwenden Sie dazu eine Eingabepäsentation, die Text in einer zur Laufzeit nicht vorhandenen Schriftart enthält. Die Warnungsbeschreibung identifiziert die Substitution; konfigurieren Sie die erforderlichen Schriftarten oder [Schriftart‑Ersetzungsregeln](/slides/de/net/font-substitution/) bevor Sie es erneut versuchen.
- **Unsupported or unexpected content:** Ein Loader kann Präsentationsdatensätze oder Funktionen begegnen, die er nicht erkennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn Daten oder Formatierungen betroffen sind.
- **Format compatibility:** Das Speichern in ein anderes Präsentationsformat kann Funktionen weglassen oder ein Ergebnis erzeugen, das sich in manchen Anwendungen anders verhält. Zum Beispiel meldet das Speichern einer Präsentation mit mehr als acht horizontalen bzw. acht vertikalen Zeichenhilfen im Legacy‑PPT-Format ein `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust aufzeichnen und fortfahren oder ihn ablehnen, falls das Beibehalten aller Hilfen erforderlich ist.
- **Loading behavior:** Ladeoptionen und veraltete Verhaltensweisen können ebenfalls Warnungen erzeugen. Zum Beispiel identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) die Verwendung eines veralteten Präsentations‑Locking‑Verhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quelldokument, Zielformat, Vorgang und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario stets nur einer Kategorie zugeordnet werden kann.

## **Abgebrochene Vorgänge sicher handhaben**

Wenn ein Callback `ReturnAction.Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass ein Render‑ oder Speicher‑Output vollständig ist. Der Vorgang kann nach Erzeugung einer Ausgabedatei, aber vor deren Abschluss beendet werden.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, nachdem der Vorgang erfolgreich abgeschlossen, der Warnbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft wurde. So vermeiden Sie, dass eine gültige Quelldatei mit einem teilweisen oder abgelehnten Ergebnis überschrieben wird.

Ein leerer Warnbericht garantiert nicht, dass jedes Quell‑Feature erhalten geblieben ist. Führen Sie alle zusätzlichen Inhalts‑ und Sichtprüfungen durch, die die Anwendung erfordert. Siehe auch [Präsentationen öffnen](/slides/de/net/open-presentation/) und [Präsentationen speichern](/slides/de/net/save-presentation/).

## **FAQ**

**Kann ein Warn‑Callback jeden Aspose.Slides‑Fehler behandeln?**

Nein. Er behandelt nur wiederherstellbare Zustände, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung um den Lade‑, Render‑, Konvertierungs‑ oder Speicheraufruf herum behandelt werden.

**Garantiert das Zurückgeben von `ReturnAction.Continue` identische Ausgabe?**

Nein. Es erlaubt lediglich die Fortsetzung der Verarbeitung. Der gemeldete Zustand kann weiterhin zu Daten‑, Formatierungs‑ oder Kompatibilitätsunterschieden führen, sodass die gesammelten Warnungs‑Typen und Beschreibungen geprüft werden sollten.

**Wie kann eine Anwendung die Operation identifizieren, die eine Warnung erzeugt hat?**

Erstellen Sie für jede Operation eine eigene Callback‑Instanz und speichern Sie ein anwendungsspezifisches Stadium zusammen mit `WarningType` und `Description`, wie im Beispiel gezeigt.