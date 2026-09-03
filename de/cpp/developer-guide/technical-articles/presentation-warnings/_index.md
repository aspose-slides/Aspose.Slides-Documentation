---
title: Behandlung von Präsentationswarnungen in C++
type: docs
weight: 70
url: /de/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnungs-Callback
- Warnungsrichtlinie
- Datenverlust
- Quellkorruption
- Kompatibilitätsproblem
- Schriftart-Substitution
- Digitale Signatur
- Präsentationsladen
- Präsentationsrendern
- Präsentationskonvertierung
- Präsentationsspeicherung
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnungen beim Laden, Rendern, Konvertieren und Speichern von Präsentationen mit Aspose.Slides für C++ sammeln, klassifizieren und darauf reagieren."
---
## **Übersicht**

Aspose.Slides kann wiederherstellbare Probleme melden, wenn es eine Präsentation lädt, rendert, konvertiert oder speichert. Beispiele sind beschädigte Quelldatensätze, Inhalte, die nicht erhalten werden können, Schriftartersetzungen und Einschränkungen des Ziel‑Formats. Ein Warn‑Callback ermöglicht es einer Anwendung, diese Zustände zu protokollieren und zu entscheiden, ob der aktuelle Vorgang fortgesetzt werden darf.

Implementieren Sie die [IWarningCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/iwarningcallback/)‑Schnittstelle und prüfen Sie die Methoden [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) und [IWarningInfo::get_Description](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/iwarninginfo/get_description/), die über [IWarningInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/iwarninginfo/) bereitgestellt werden. Geben Sie [ReturnAction::Continue](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/returnaction/) zurück, um die Warnung zu akzeptieren, oder `ReturnAction::Abort`, um den Vorgang zu stoppen.

Verwenden Sie [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_warningcallback/) für Warnungen, die beim Öffnen einer Präsentation ausgelöst werden. Rendering‑ und Export‑Option‑Klassen erben von [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/set_warningcallback/), das Warnungen beim Folien‑Rendering, der Konvertierung und beim Speichern empfängt. Da die Warnung selbst nicht den Anwendungsvorgang identifiziert, verbinden Sie jede Callback‑Instanz mit einer Vorgangsphase, wenn Sie einen kombinierten Bericht erstellen.

## **Warnungen und Ausnahmen**

Eine Warnung beschreibt einen Zustand, von dem Aspose.Slides sich erholen kann, wenn der Callback `ReturnAction::Continue` zurückgibt. Eine Ausnahme bedeutet, dass der angeforderte Vorgang nicht normal abgeschlossen werden kann; Ausnahmen werden nicht in Warnungen umgewandelt und können nicht durch eine Warn‑Richtlinie behandelt werden.

Die Rückgabe von `ReturnAction::Abort` veranlasst den Warn‑Dispatcher, den aktuellen Vorgang durch Auslösen einer Ausnahme zu beenden. Die öffentliche Ausnahme hängt vom Vorgang und vom Präsentationsformat ab. Beispielsweise kann beim Laden eine [PptxReadException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxreadexception/) oder [PptReadException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptreadexception/) auftreten, während beim Speichern oder Exportieren eine [PptxException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxexception/) ausgelöst werden kann. Behandeln Sie die Ausnahme an der Grenze des Vorgangs und verwenden Sie den Warnbericht, um festzustellen, ob die Anwendungsrichtlinie die Beendigung verursacht hat, anstatt sich nur auf einen Ausnahme‑Untertyp oder eine Meldung zu stützen. Der Callback protokolliert die Warnung, bevor er `ReturnAction::Abort` zurückgibt, sodass der Grund für die Anwendung verfügbar bleibt.

## **Warn‑Kategorien**

Die Aufzählung [WarningType](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/warningtype/) liefert die folgenden Kategorien:

| Warnungstyp | Bedeutung | Typische Richtlinie |
| --- | --- | --- |
| `SourceFileCorruption` | Die Quelldatei enthält Beschädigungen, die ein im Originalformat gespeichertes Dokument unbrauchbar machen können. | Abbrechen. |
| `DataLoss` | Text, Diagramme, Bilder oder andere Daten können nach dem Laden oder Speichern fehlen. | Abbrechen. |
| `MajorFormattingLoss` | Die Präsentation kann wichtige Formatierungen verlieren. | Im strengen Validierungsmodus abbrechen; sonst protokollieren und fortfahren. |
| `MinorFormattingLoss` | Es kann zu geringen Formatierungsunterschieden kommen. | Für Diagnosen protokollieren und fortfahren. |
| `CompatibilityIssue` | Das Ergebnis lässt sich in einigen Anwendungen oder älteren Versionen evtl. nicht öffnen oder verhält sich nicht korrekt. | Protokollieren und fortfahren, sofern Kompatibilität nicht zwingend erforderlich ist. |
| `UnexpectedContent` | Die Quelle enthält ununterstützte oder nicht erkennbare Inhalte, deren Auswirkung noch unbekannt sein kann. | Protokollieren und fortfahren oder bei einer strengen Richtlinie als Fehler behandeln. |

Die Kategorie sollte die Richtlinienentscheidung steuern. Speichern Sie die Warnungsbeschreibung für Diagnosen, verlassen Sie sich jedoch nicht auf deren Wortlaut für Anwendungslogik, da der Meldungstext je nach Warnungsszenario und Produktversion variieren kann.

## **Warnungen sammeln und klassifizieren**

Das folgende Beispiel verwendet einen anwendungsweiten Bericht für die gesamte Verarbeitungspipeline. Eine separate Callback‑Instanz kennzeichnet Warnungen aus Laden, Rendern, PDF‑Konvertierung und PPTX‑Speicherung. Die Richtlinie bricht bei Quell‑Beschädigung oder Datenverlust ab, bricht optional bei großem Formatierungsverlust ab und fährt bei anderen Warnungen fort.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Setzen Sie `abortOnMajorFormattingLoss` auf `false`, wenn größere Formatierungsunterschiede akzeptabel sind. Kompatibilitätsprobleme, geringere Formatierungsverluste und unerwartete Inhalte bleiben dennoch im Bericht erhalten, selbst wenn der Vorgang fortgesetzt wird. Erweitern Sie `WarningPolicy::GetAction`, falls die Anwendung eine dieser Kategorien ablehnen muss.

## **Häufige Warn‑Szenarien**

Warnungen können in verschiedenen Phasen eines Workflows auftreten:

- **Digitale Signaturen:** Eine signierte Präsentation kann beim Laden eine Warnung erzeugen, dass ihre Signatur während der Verarbeitung verloren geht. Aspose.Slides meldet diesen `DataLoss`‑Zustand über [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Ein Callback in der Ladephase ermöglicht es der Anwendung, die Datei abzulehnen oder den gemeldeten Verlust ausdrücklich zu akzeptieren.
- **Schriftart‑Substitution:** Eine nicht verfügbare Schriftart kann ersetzt werden, während eine Folie gerendert oder exportiert wird. Schriftart‑Substitutionswarnungen werden als `DataLoss` gemeldet, sodass die oben beschriebene strikte Richtlinie selbst dann abbricht, wenn die Anwendung die Ersetzung visuell akzeptieren würde. Verwenden Sie dafür eine Eingabedatei, die Text in einer zur Laufzeit nicht vorhandenen Schriftart enthält. Die Warnungsbeschreibung gibt die Substitution an; konfigurieren Sie die erforderlichen Schriftarten oder [font substitution rules](/slides/de/cpp/font-substitution/) bevor Sie es erneut versuchen.
- **Nicht unterstützte oder unerwartete Inhalte:** Ein Loader kann Datensätze oder Funktionen treffen, die er nicht kennt. Solche Warnungen können `UnexpectedContent` verwenden oder eine schwerwiegendere Kategorie, wenn Daten oder Formatierungen betroffen sind.
- **Format‑Kompatibilität:** Das Speichern in ein anderes Präsentationsformat kann Funktionen weglassen oder ein Ergebnis erzeugen, das sich in manchen Anwendungen anders verhält. Beispielsweise meldet das Speichern einer Präsentation mit mehr als acht horizontalen oder vertikalen Zeichenhilfen im Legacy‑PPT‑Format ein `CompatibilityIssue`. Der Callback in der Speicherphase kann den Verlust protokollieren und fortfahren oder ablehnen, wenn das Beibehalten aller Hilfen erforderlich ist.
- **Ladeverhalten:** Ladeoptionen und veraltete Verhaltensweisen können ebenfalls Warnungen erzeugen. Zum Beispiel identifiziert [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) die Nutzung eines veralteten Präsentations‑Locking‑Verhaltens als `CompatibilityIssue`.

Warnungen hängen vom Quell‑Dokument, Ziel‑Format, Vorgang und der Aspose.Slides‑Version ab. Gehen Sie nicht davon aus, dass jede Datei eine Warnung erzeugt oder dass ein Szenario stets nur einer Kategorie zugeordnet werden kann.

## **Sichere Handhabung abgebrochener Vorgänge**

Wenn ein Callback `ReturnAction::Abort` zurückgibt, verwenden Sie kein Objekt, das nicht geladen werden konnte, und gehen Sie nicht davon aus, dass eine Rendering‑ oder Speicher‑Ausgabe vollständig ist. Der Vorgang kann beendet werden, nachdem eine Ausgabedatei erstellt, aber bevor sie fertiggestellt wurde.

Speichern Sie validierte Ergebnisse in einem separaten Pfad, z. B. `validated-output.pptx`. Ersetzen Sie eine vorhandene Präsentation erst, nachdem der Vorgang erfolgreich abgeschlossen, der Warnbericht die Anwendungsrichtlinie erfüllt und die Ausgabe geöffnet und geprüft wurde. So vermeiden Sie das Überschreiben einer gültigen Quelldatei mit einem unvollständigen oder abgelehnten Ergebnis.

Ein leerer Warnbericht garantiert nicht, dass jedes Quell‑Feature erhalten wurde. Führen Sie alle zusätzlichen Inhalts‑ und Sichtprüfungen durch, die die Anwendung verlangt. Siehe auch [Open Presentations](/slides/de/cpp/open-presentation/) und [Save Presentations](/slides/de/cpp/save-presentation/).

## **FAQ**

**Kann ein Warn‑Callback jeden Aspose.Slides‑Fehler handhaben?**

Nein. Er behandelt nur wiederherstellbare Zustände, die als Warnungen gemeldet werden. Ausnahmen, die unabhängig vom Callback auftreten, müssen von der Anwendung um den Ladevorgang, das Rendering, die Konvertierung oder das Speichern herum behandelt werden.

**Garantiert das Zurückgeben von `ReturnAction::Continue` ein identisches Ergebnis?**

Nein. Es erlaubt lediglich das Fortsetzen der Verarbeitung. Der gemeldete Zustand kann dennoch Daten-, Formatierungs‑ oder Kompatibilitätsunterschiede verursachen, sodass die gesammelten Warnungs‑Typen und Beschreibungen geprüft werden sollten.

**Wie kann eine Anwendung den Vorgang identifizieren, der eine Warnung erzeugt hat?**

Erstellen Sie für jeden Vorgang eine eigene Callback‑Instanz und speichern Sie zusammen mit dem Warnungs‑Typ und der Beschreibung eine von der Anwendung definierte Phase, wie im Beispiel gezeigt.