---
title: Präsentationen nach XAML in .NET
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/net/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint nach XAML
- OpenDocument nach XAML
- Präsentation nach XAML
- PPT nach XAML
- PPTX nach XAML
- ODP nach XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien nach XAML in .NET mit Aspose.Slides - schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert werden. Er enthält eine kurze Einführung in XAML, zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML gespeichert wird, und demonstriert, wie der Export über [XamlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/) angepasst werden kann, einschließlich des Exports versteckter Folien. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriften, XAML‑Stack‑Kompatibilität und dem Exportverhalten versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die zur Beschreibung von Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms verwendet wird.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Markup‑Datei direkt schreiben und bearbeiten.

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Das folgende C#‑Beispiel zeigt, wie eine Präsentation mit den Standardeinstellungen nach XAML exportiert wird:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert, wie von [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) zurückgegeben. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls gespeichert.

Der Ausgabeordner‑Name wird aus dem Quell-Dateinamen ohne Erweiterung übernommen. Für `pres.pptx` werden die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. genannt. Selbst wenn Sie einen absoluten Pfad zur Eingabe‑Präsentation übergeben, wird der Ausgabeordner relativ zum aktuellen Arbeitsverzeichnis erstellt, nicht neben der Eingabedatei.

## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen**

Verwenden Sie die Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/ixamloutputsaver/) und weisen Sie eine Instanz Ihrer Implementierung der Eigenschaft [OutputSaver](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/outputsaver/) von [XamlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/) zu.

Um versteckte Folien in die XAML‑Ausgabe einzubeziehen, setzen Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) auf `true`, wie im folgenden C#‑Beispiel gezeigt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Alle erzeugten XAML‑Artefakte erfassen**

Ein XAML‑Export kann für jede exportierte Folie ein XAML‑Dokument sowie separate Bilder und unterstützende Ressourcen erzeugen. Weisen Sie [XamlOptions.OutputSaver](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/outputsaver/) ein benutzerdefiniertes [IXamlOutputSaver](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/ixamloutputsaver/) zu, um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), die XAML‑Optionen akzeptiert.

### **Verstehen des Callback‑Lebenszyklus**

Der Exporter ruft [IXamlOutputSaver.Save](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/ixamloutputsaver/save/) separat für jedes erzeugte Artefakt auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information, da XAML Ressourcen über relative Pfade referenzieren kann.
- `data` enthält die Bytes des Artefakts. Bilder und andere binäre Ressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten zu behalten oder zu persistieren, bevor er zurückkehrt. Die Beispiele kopieren jedes Byte‑Array in vom Anwender verwalteten Speicher.
- Behandeln Sie den Export nur als erfolgreich, wenn der Präsentations‑Speichervorgang zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Unterdrücken Sie keine Speicherausnahmen und starten Sie keine unbeobachteten Hintergrundschreibvorgänge. Erfolgt die Persistenz danach, melden Sie den Gesamterfolg erst, nachdem auch dieser Schritt erfolgreich war.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) gilt ebenfalls für einen benutzerdefinierten Saver. Sein Standardwert `false` schließt XAML‑Dokumente versteckter Folien aus. Setzen Sie ihn auf `true`, um diese und alle für ihren Export benötigten Ressourcen einzubeziehen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht von einem Callback pro Folie oder einer festen Callback‑Reihenfolge aus.

### **Exportieren in den Arbeitsspeicher und die Artefakte prüfen**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einem [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es bewahrt die bereitgestellten Namen exakt. Doppelte Namen führen zum Fehlschlag der Sammlung, anstatt ein Artefakt still zu überschreiben.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Nur XAML dekodieren und nur, wenn eine textuelle Inspektion erforderlich ist.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Rufen Sie `InMemoryXamlExample.Run` aus Ihrer Anwendung auf. Erweiterungsprüfungen sind für die Inspektion nützlich; bewahren Sie alle Artefakte, einschließlich unbekannter Ressourcentypen. Lassen Sie die Bytes beim Speichern oder Übertragen unverändert. Verwenden Sie [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) nur für XAML, das einer textuellen Verarbeitung bedarf.

### **Gesammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses eigenständige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein eindeutiger Archivname trennt gleichzeitig laufende Export‑Jobs. ZIP‑Einträge verwenden Vorwärtsschrägstriche und bewahren relative Verzeichnisse. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen dazu, dass das gesamte Paket vor dem Schreiben abgelehnt wird.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Das ZIP-Verzeichnis wurde durch die Entsorgung fertiggestellt, bevor der Erfolg gemeldet wird.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Rufen Sie `ZipXamlExample.Run` aus Ihrer Anwendung auf. Das Beispiel verwendet [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive), um ein lokales Archiv zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für Remote‑Speicher ersetzen Sie die Phase des Archiverstellens durch das Hochladen der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Identifier plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Identifier, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbank‑Transaktion bestätigt wurde. Bereinigen Sie Teil‑Ausgaben, falls die Persistenz fehlschlägt.

Für sehr große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um zu vermeiden, dass eine zusätzliche Kopie des gesamten Exports im Speicher gehalten wird. Der Exporter sammelt weiterhin alle erzeugten Artefakte im Speicher, bevor er den Saver aufruft. Halten Sie jeden Callback aus Sicht des Exporters synchron: geben Sie erst zurück, wenn das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler zum Aufrufer durchdringen.

### **Ressourcennamen beibehalten und Verweise prüfen**

- Normalisieren Sie Pfadtrennzeichen, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht ausschließlich [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename), es sei denn, jeder generierte Name ist eindeutig und Ressourcen‑Verweise bleiben gültig.
- Wenden Sie ziel­spezifische Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie Pfade mit Root‑Bezug und Traversal‑Segmenten ab, ermitteln Sie das Ziel mit [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) und prüfen Sie, dass es innerhalb des vorgesehenen Export‑Verzeichnisses bleibt, einschließlich des Verzeichnis‑Trennzeichens in der Enthaltungsprüfung. Nutzen Sie ein vom Anwender kontrolliertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Verwenden Sie für jeden Export‑Job einen separaten Saver und Namensraum. Erkennen Sie Kollisionen nach Normalisierung der Trennzeichen und gemäß den Fallsensitivitäts‑Regeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen die dateibasierten Ressourcen‑Verweise, etwa Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI gegen das Verzeichnis des zugehörigen XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Dictionary‑Schlüssel, ZIP‑Eintrag oder gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Beispiel: Verweist `pres/Slide_1.xaml` auf `images/image1.png`, muss die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu behalten, würde die Beziehung zerstören. Für Objektspeicher bewahren Sie dieselbe Struktur unter dem Job‑Präfix und stellen Sie diese Ressourcen‑URLs dem XAML‑Verbraucher zur Verfügung. Öffnen Sie das fertige ZIP erneut, prüfen Sie die Eintragsnamen und Ressourcebytes und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich sicherstellen, dass vorhersehbare Schriften verwendet werden, wenn die Originalschrift nicht auf dem Rechner vorhanden ist?**

Setzen Sie [DefaultRegularFont](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/) – sie wird während des Exports als Ersatzschrift verwendet, wenn die Originalschrift fehlt. Dies garantiert nicht, dass das generierte XAML die Ersatzschrift referenziert oder dass die Schrift auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die vom XAML referenzierten Schriften in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks, wie UWP und Xamarin.Forms, ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [ExportHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export.xaml/xamloptions/) steuern – deaktivieren Sie es, wenn Sie sie nicht exportieren müssen.