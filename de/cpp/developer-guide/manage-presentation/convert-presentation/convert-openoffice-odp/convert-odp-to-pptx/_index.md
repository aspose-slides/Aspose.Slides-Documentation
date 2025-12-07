---
title: ODP zu PPTX in C++ konvertieren
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- ODP als PPTX speichern
- ODP nach PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "ODP mit Aspose.Slides für C++ in PPTX konvertieren. Saubere Codebeispiele, Stapelverarbeitungstipps und hochwertige Ergebnisse — ohne PowerPoint."
---

## **ODP zu PPTX-Konvertierung**

Aspose.Slides für .NET bietet die Klasse Presentation, die eine Präsentationsdatei repräsentiert. Die [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse kann nun ebenfalls über den Presentation‑Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP Presentation in eine PPTX Presentation konvertiert.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// ODP-Datei öffnen
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Live-Beispiel**

Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web‑App besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP zu PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur, einschließlich Master‑Folien und Layouts, bei, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und die Arbeit mit [protected presentations](/slides/de/cpp/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort bereitstellen, sowie die Konfiguration von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.