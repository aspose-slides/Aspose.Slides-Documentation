---
title: ODP nach PPTX in C++ konvertieren
linktitle: ODP nach PPTX
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
- ODP nach PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "ODP nach PPTX mit Aspose.Slides für C++ konvertieren. Saubere Codebeispiele, Stapelhinweise und hochwertige Ergebnisse - kein PowerPoint erforderlich."
---

## **ODP zu PPTX-Konvertierung**

Aspose.Slides für .NET bietet die Klasse Presentation, die eine Präsentationsdatei darstellt. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) kann nun auch ODP über den Presentation‑Konstruktor zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// Öffnen Sie die ODP-Datei
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Live‑Beispiel**

Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides‑API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP nach PPTX zu konvertieren?**

Nein. Aspose.Slides arbeitet eigenständig und benötigt keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und bewahrt die Struktur, einschließlich Master‑Folien und Layouts, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und Arbeiten mit [protected presentations](/slides/de/cpp/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteigenschaften.

**Eignet sich Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.