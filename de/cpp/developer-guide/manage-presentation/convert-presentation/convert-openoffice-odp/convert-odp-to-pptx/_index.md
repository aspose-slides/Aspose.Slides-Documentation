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
description: "ODP zu PPTX mit Aspose.Slides für C++ konvertieren. Saubere Code-Beispiele, Batch-Tipps und hochwertige Ergebnisse – kein PowerPoint erforderlich."
---

## **ODP-zu-PPTX-Konvertierung**

Aspose.Slides für .NET bietet die Presentation‑Klasse, die eine Präsentationsdatei darstellt. Die [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse kann nun auch über den Presentation‑Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// ODP-Datei öffnen
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Live‑Beispiel**

Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web‑App besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App zeigt, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Anwendungen von Drittanbietern zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung erhalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und bewahrt die Struktur, einschließlich Master‑Folien und Layouts, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und Arbeiten mit [geschützte Präsentationen](/slides/de/cpp/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides für cloud‑basierte oder REST‑basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.