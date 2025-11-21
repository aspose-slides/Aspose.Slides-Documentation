---
title: ODP zu PPTX konvertieren in .NET
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/net/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "ODP mit Aspose.Slides für .NET zu PPTX konvertieren. Saubere C#-Beispielcodes, Batch-Tipps und hochwertige Ergebnisse - PowerPoint nicht erforderlich."
---

## **Übersicht**

Dieser Artikel erklärt die folgenden Themen.

- [C# ODP in PPTX konvertieren](#csharp-odp-to-pptx)
- [C# ODP in PowerPoint konvertieren](#csharp-odp-to-powerpoint)

## **ODP-zu-PPTX-Konvertierung**

Aspose.Slides für .NET bietet die Klasse **Presentation**, die eine Präsentationsdatei darstellt. Die **Presentation**-Klasse kann nun auch über den Presentation‑Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Schritte: ODP zu PPTX in C# konvertieren</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Schritte: ODP zu PowerPoint in C# konvertieren</strong></a>
```c#
 // ODP-Datei öffnen
 Presentation pres = new Presentation("AccessOpenDoc.odp");

 // ODP-Präsentation im PPTX-Format speichern
 pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Live-Beispiel**

Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides‑API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides arbeitet eigenständig und erfordert keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur, einschließlich Master‑Folien und Layouts, bei, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt die Erkennung von Schutz, das Öffnen und Arbeiten mit [geschützten Präsentationen](/slides/de/net/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie die Konfiguration von Verschlüsselung und Zugriff auf Dokumenteigenschaften.

**Eignet sich Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.