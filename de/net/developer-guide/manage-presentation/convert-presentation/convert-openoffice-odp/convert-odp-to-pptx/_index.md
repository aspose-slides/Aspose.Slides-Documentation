---
title: ODP zu PPTX konvertieren in .NET
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "ODP mit Aspose.Slides für .NET zu PPTX konvertieren. Saubere C#-Codebeispiele, Batch-Tipps und hochwertige Ergebnisse – PowerPoint nicht erforderlich."
---

## **Übersicht**

Dieser Artikel erklärt die folgenden Themen.

- [C# ODP zu PPTX konvertieren](#csharp-odp-to-pptx)
- [C# ODP zu PowerPoint konvertieren](#csharp-odp-to-powerpoint)

## **ODP zu PPTX Konvertierung**

Aspose.Slides für .NET bietet die Presentation-Klasse, die eine Präsentationsdatei darstellt. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse kann nun auch ODP über den Presentation‑Konstruktor zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Schritte: ODP zu PPTX in C# konvertieren</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Schritte: ODP zu PowerPoint in C# konvertieren</strong></a>
```c#
// Öffne die ODP-Datei
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Speichere die ODP-Präsentation im PPTX-Format
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Live-Beispiel**

Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP zu PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und benötigt keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs während der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur bei, einschließlich Master‑Folien und Layouts, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und Arbeiten mit [geschützten Präsentationen](/slides/de/net/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteigenschaften.

**Ist Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.