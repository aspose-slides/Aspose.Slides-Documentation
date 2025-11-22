---
title: ODP nach PPTX konvertieren in C#
linktitle: ODP nach PPTX konvertieren
type: docs
weight: 10
url: /de/net/convert-odp-to-pptx/
keywords: "OpenOffice Präsentation konvertieren, ODP, ODP zu PPTX, C#, Csharp, .NET"
description: "OpenOffice ODP in PowerPoint‑Präsentation PPTX in C# oder .NET konvertieren"
---

## **Übersicht**

Dieser Artikel erklärt die folgenden Themen.

- [C# ODP nach PPTX konvertieren](#csharp-odp-to-pptx)
- [C# ODP nach PowerPoint konvertieren](#csharp-odp-to-powerpoint)

## **ODP nach PPTX‑Konvertierung**

Aspose.Slides für .NET bietet die Klasse **Presentation**, die eine Präsentationsdatei darstellt. Die Klasse **Presentation** kann nun auch über den Presentation‑Konstruktor auf ODP zugreifen, wenn das Objekt erstellt wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Schritte: ODP nach PPTX in C# konvertieren</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Schritte: ODP nach PowerPoint in C# konvertieren</strong></a>
```c#
// ODP-Datei öffnen
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP-Präsentation im PPTX-Format speichern
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Live‑Beispiel**

Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP nach PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs während der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur, einschließlich Master‑Folien und Layouts, bei, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt die Erkennung von Schutz, das Öffnen und Arbeiten mit [geschützten Präsentationen](/slides/de/net/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie die Konfiguration von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend verwenden oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API); beide Optionen unterstützen die ODP → PPTX‑Konvertierung.