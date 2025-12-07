---
title: ODP zu PPTX in C++ konvertieren
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folien konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- ODP als PPTX speichern
- ODP zu PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie ODP zu PPTX mit Aspose.Slides für C++. Saubere Codebeispiele, Stapelhinweise und hochwertige Ergebnisse - PowerPoint nicht erforderlich."
---

## **ODP zu PPTX-Konvertierung**

Aspose.Slides für .NET bietet die Presentation-Klasse, die eine Präsentationsdatei darstellt. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse kann nun ebenfalls ODP über den Presentation‑Konstruktor nutzen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// ODP-Datei öffnen
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Live-Beispiel**

Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web‑App besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Masterfolien, Layouts und Designs während der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur, einschließlich Masterfolien und Layouts, bei, so dass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und Arbeiten mit [protected presentations](/slides/de/cpp/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.