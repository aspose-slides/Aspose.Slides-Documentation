---
title: "Präsentationen in C++ speichern"
linktitle: "Präsentation speichern"
type: docs
weight: 80
url: /de/cpp/save-presentation/
keywords:
- "PowerPoint speichern"
- "OpenDocument speichern"
- "Präsentation speichern"
- "Folie speichern"
- "PPT speichern"
- "PPTX speichern"
- "ODP speichern"
- "Präsentation in Datei"
- "Präsentation in Stream"
- "vordefinierter Ansichtstyp"
- "Strict Office Open XML-Format"
- "Zip64-Modus"
- "Vorschaubild aktualisieren"
- "Speicherfortschritt"
- "C++"
- "Aspose.Slides"
description: "Entdecken Sie, wie Sie Präsentationen in C++ mit Aspose.Slides speichern – Export nach PowerPoint oder OpenDocument bei Beibehaltung von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Open Presentations in C++](/slides/de/cpp/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse zum Öffnen einer Präsentation verwendet wird. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie müssen sie nach Abschluss speichern. Mit Aspose.Slides für C++ können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erläutert die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit Aspose.Slides speichern.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Führen Sie hier einige Arbeiten aus...
 
// Speichern Sie die Präsentation in einer Datei.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im nachfolgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Speichern Sie die Präsentation in den Stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/)‑Klasse. Verwenden Sie die [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/)‑Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/)‑Aufzählung.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/)‑Klasse und setzen Sie deren `Conformance`‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Speichern Sie die Präsentation im Strict Office Open XML-Format.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtabmessungen des Archivs festlegt und zudem die Anzahl der Dateien auf 65 535 (2^16‑1) begrenzt. ZIP64‑Format‑Erweiterungen erhöhen diese Grenzen auf 2^64.

Die [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/)‑Methode ermöglicht die Auswahl, wann ZIP64‑Format‑Erweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:

- `IfNecessary` verwendet ZIP64‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet niemals ZIP64‑Erweiterungen.
- `Always` verwendet stets ZIP64‑Erweiterungen.

Der folgende Code demonstriert, wie eine Präsentation als PPTX mit aktivierten ZIP64‑Erweiterungen gespeichert wird:
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen ohne Aktualisierung des Vorschaubilds speichern**

Die [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/)‑Methode steuert die Erzeugung des Vorschaubilds beim Speichern einer Präsentation als PPTX:

- Ist sie auf `true` gesetzt, wird das Vorschaubild während des Speicherns aktualisiert. Dies ist der Standardwert.
- Ist sie auf `false` gesetzt, bleibt das aktuelle Vorschaubild erhalten. Gibt es kein Vorschaubild, wird keines erzeugt.

Im folgenden Code wird die Präsentation ohne Aktualisierung des Vorschaubilds als PPTX gespeichert.
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Diese Option reduziert die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Die [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/)‑Schnittstelle wird über die `set_ProgressCallback`‑Methode der [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/)‑Schnittstelle und der abstrakten [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/)‑Klasse verwendet. Registrieren Sie eine [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/)‑Implementierung mit `set_ProgressCallback`, um Speicherfortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen die Verwendung von `IProgressCallback`.
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Verwenden Sie hier den Fortschrittsprozentsatz.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/splitter) entwickelt, die die eigene API nutzt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird ein „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erzeugt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz [ist nicht threadsicher](/slides/de/cpp/multithreading/); speichern Sie sie aus einem einzigen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/cpp/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.