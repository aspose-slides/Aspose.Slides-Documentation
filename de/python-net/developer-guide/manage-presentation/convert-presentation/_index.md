---
title: Präsentationen in mehrere Formate konvertieren in Python
linktitle: Präsentationen konvertieren
type: docs
weight: 70
url: /de/python-net/convert-presentation/
keywords:
- Präsentation konvertieren
- Präsentation exportieren
- PPT zu PPTX
- PPT zu PDF
- PPTX zu PDF
- PPT zu XPS
- PPTX zu XPS
- PPT zu TIFF
- PPTX zu TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PPTX, PDF, XPS, TIFF und weitere Formate mit Aspose.Slides für Python über .NET. Einfach und qualitativ hochwertige Konvertierung."
---

## **Einführung**

Diese Seite bietet einen Überblick über die Präsentationskonvertierung mit Aspose.Slides für Python über .NET. Sie fasst unterstützte Szenarien zusammen und verweist auf gezielte Leitfäden, die den genauen Code zum Exportieren von Präsentationen und Folien in Formate wie PDF, XPS, TIFF sowie zur Konvertierung zwischen PPT und PPTX zeigen. Wo zutreffend, heben die verlinkten Artikel formatbezogene Optionen hervor – zum Beispiel das Rendern von Notizen oder das Anpassen der Bildqualität – und bekannte Einschränkungen wie die teilweise Unterstützung in PPT→PPTX‑Pfade. Verwenden Sie diese Seite, um ein Zielformat auszuwählen und folgen Sie dann dem verlinkten Rezept.

## **PPT‑zu‑PPTX‑Konvertierung**

### **Über PPT/PPTX**

PPT ist das ältere binäre PowerPoint‑Format (97–2003), während PPTX das ZIP‑gepackte Open‑XML‑Format ist, das mit PowerPoint 2007 eingeführt wurde. Im Vergleich zu PPT erzeugt PPTX in der Regel kleinere Dateien, unterstützt moderne Funktionen, funktioniert gut mit Dokumenten‑Automatisierung und wird für langfristige Archivierung sowie plattformübergreifende Workflows empfohlen.

### **PPT in PPTX konvertieren**

Aspose.Slides unterstützt die Konvertierung von PPT‑Präsentationen in das PPTX‑Format. Der Hauptvorteil bei der Verwendung der Aspose.Slides‑API für diese Aufgabe ist die Einfachheit des Arbeitsablaufs, der zum gewünschten Ergebnis führt. In der Praxis können Sie die Konvertierung mit minimalem Code durchführen und dabei eine hohe Treue von Folien, Layouts und Medien beibehalten.

{{% alert color="primary" %}}
Mehr erfahren: [Convert PPT to PPTX in Python](/slides/de/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Präsentation‑zu‑PDF‑Konvertierung**

### **Über PDF**

Das Portable Document Format (PDF) ist ein Dateiformat, das von Adobe Systems entwickelt wurde, um Dokumente zwischen Organisationen auszutauschen. Ziel ist es, sicherzustellen, dass der Inhalt eines Dokuments unabhängig von der Plattform, auf der es angezeigt wird, dieselbe visuelle Darstellung hat.

### **Präsentationen in PDF konvertieren**

Jede Präsentation, die in Aspose.Slides geladen werden kann, lässt sich in ein PDF‑Dokument konvertieren. Sie können Präsentationen direkt mit der Aspose.Slides‑Komponente nach PDF exportieren; dafür sind keine Drittanbieter‑Bibliotheken oder die Aspose.PDF‑Komponente erforderlich.

{{% alert color="primary" %}}
Mehr erfahren: [Convert PPT & PPTX to PDF in Python](/slides/de/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Präsentation‑zu‑XPS‑Konvertierung**

### **Über XPS**

Die XML Paper Specification (XPS) ist eine Seitenspezifikationssprache und ein Fixed‑Document‑Format, das ursprünglich von Microsoft entwickelt wurde. Ähnlich wie PDF ist XPS ein Fixed‑Layout‑Dokumentformat, das darauf ausgelegt ist, die Dokumenttreue zu bewahren und ein geräteunabhängiges Erscheinungsbild zu bieten.

### **Präsentationen in XPS konvertieren**

Jede Präsentation, die von Aspose.Slides geladen werden kann, lässt sich in das XPS‑Format konvertieren. Aspose.Slides verwendet eine hochpräzise Seitenlayout‑ und Rendering‑Engine, um Ausgaben im Fixed‑Layout‑XPS‑Format zu erzeugen. Bemerkenswert ist, dass Aspose.Slides XPS direkt erzeugt, ohne auf Windows Presentation Foundation (WPF) zurückzugreifen.

{{% alert color="primary" %}}
Mehr erfahren: [Convert PowerPoint Presentations to XPS in Python](/slides/de/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Präsentation‑zu‑TIFF‑Konvertierung**

### **Über TIFF**

Das Tagged Image File Format (TIFF) ist ein Rasterbildformat, das dafür bekannt ist, mehrere Bilder (Seiten) in einer einzigen Datei zu speichern. Ursprünglich von Aldus entwickelt, wird es von Scan‑, Fax‑ und anderen Bildverarbeitungs‑Anwendungen weitgehend unterstützt.

### **Präsentationen in TIFF konvertieren**

Jedes Dokument, das in Aspose.Slides geladen werden kann, kann ebenfalls direkt in eine TIFF‑Datei konvertiert werden, ohne dass Drittanbieter‑Komponenten erforderlich sind. Optional können Sie die Bildgröße für die Seiten im resultierenden TIFF festlegen.

{{% alert color="primary" %}}
Mehr erfahren: [Convert PowerPoint Presentations to TIFF in Python](/slides/de/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Kann ich ausgeblendete Folien beim Export nach PDF/XPS einbeziehen?**

Ja. Der Export unterstützt das Einbeziehen ausgeblendeter Folien über die entsprechende Option in den [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)-/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/)-Einstellungen.

**Wird das Speichern im PDF/A‑Format (für die Langzeitarchivierung) unterstützt?**

Ja, PDF/A‑Konformitätsstufen sind beim Export verfügbar (einschließlich A‑2a/A‑2b/A‑2u und A‑3a/A‑3b).

**Was passiert mit Schriftarten während der Konvertierung: werden sie eingebettet oder ersetzt?**

Es gibt flexible Optionen: Sie können [alle Glyphen oder nur die verwendeten Teilmengen einbetten](/slides/de/python-net/embedded-font/), eine [Ersatzschriftart](/slides/de/python-net/fallback-font/) angeben und das [Verhalten](/slides/de/python-net/font-substitution/) steuern, wenn einer Schriftart bestimmte Stile fehlen.

**Wie kann ich die Qualität und Größe des resultierenden PDFs steuern?**

Optionen sind verfügbar für die [JPEG‑Qualität](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), die [Textkompression](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), und einen Schwellenwert für die [ausreichende Auflösung](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) von Bildern, sowie einen Modus, der die [beste Kompression für Bilder](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) auswählt.

**Kann ich nur einen Folienbereich exportieren (z. B. 5–12)?**

Ja, der Export unterstützt die Auswahl eines Teilbereichs von Folien.

**Wird die Multi‑Core‑Verarbeitung mehrerer Dateien gleichzeitig unterstützt?**

Es ist zulässig, verschiedene Präsentationen parallel in separaten Prozessen zu verarbeiten. Wichtig: Das gleiche [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt darf nicht aus [mehreren Threads](/slides/de/python-net/multithreading/) geladen oder gespeichert werden.

**Gibt es Risiken beim Anwenden der Lizenz aus verschiedenen Threads?**

Ja, Aufrufe zum [license-setting](/slides/de/python-net/licensing/) sind nicht threadsicher und erfordern Synchronisation.