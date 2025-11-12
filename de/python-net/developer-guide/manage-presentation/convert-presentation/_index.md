---
title: Präsentationen in mehrere Formate konvertieren mit Python
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
description: "PowerPoint- und OpenDocument-Präsentationen in PPTX, PDF, XPS, TIFF und weitere Formate konvertieren mit Aspose.Slides für Python via .NET. Einfache, hochwertige Konvertierung."
---

## **Einführung**

Diese Seite bietet einen Überblick über die Präsentationskonvertierung mit Aspose.Slides für Python via .NET. Sie fasst unterstützte Szenarien zusammen und verweist auf fokussierte Anleitungen, die den genauen Code zum Exportieren von Präsentationen und Folien in Formate wie PDF, XPS, TIFF sowie zum Konvertieren zwischen PPT und PPTX zeigen. Wo relevant, heben die verlinkten Artikel format­spezifische Optionen hervor – zum Beispiel das Rendern von Notizen oder das Anpassen der Bildqualität – und bekannte Einschränkungen wie Teilunterstützung bei PPT→PPTX‑Pfaden. Verwenden Sie diese Seite, um ein Zielformat auszuwählen und anschließend das verlinkte Rezept zu befolgen.

## **PPT‑zu‑PPTX‑Konvertierung**

### **Über PPT/PPTX**

PPT ist das ältere binäre PowerPoint‑Format (97–2003), während PPTX das ZIP‑gepackte Open‑XML‑Format ist, das mit PowerPoint 2007 eingeführt wurde. Im Vergleich zu PPT erzeugt PPTX typischerweise kleinere Dateien, unterstützt moderne Funktionen, arbeitet gut mit Dokumenten‑Automatisierung und wird für langfristige Archivierung sowie plattformübergreifende Workflows empfohlen.

### **PPT nach PPTX konvertieren**

Aspose.Slides unterstützt die Konvertierung von PPT‑Präsentationen in das PPTX‑Format. Der Hauptvorteil der Verwendung der Aspose.Slides‑API für diese Aufgabe liegt in der Einfachheit des erforderlichen Workflows, um das gewünschte Ergebnis zu erzielen. In der Praxis können Sie die Konvertierung mit minimalem Code durchführen und gleichzeitig eine hohe Treue der Folien, Layouts und Medien beibehalten.

{{% alert color="primary" %}}
Read more:[Convert PPT to PPTX in Python](/slides/de/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Präsentation‑zu‑PDF‑Konvertierung**

### **Über PDF**

Das [Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) ist ein Dateiformat, das von Adobe Systems zur Übertragung von Dokumenten zwischen Organisationen erstellt wurde. Sein Zweck ist es, sicherzustellen, dass der Inhalt eines Dokuments unabhängig von der Plattform, auf der es angezeigt wird, dieselbe visuelle Darstellung behält.

### **Präsentationen in PDF konvertieren**

Jede Präsentation, die in Aspose.Slides geladen werden kann, lässt sich in ein PDF‑Dokument konvertieren. Sie können Präsentationen direkt mit der Aspose.Slides‑Komponente nach PDF exportieren; keine Drittanbieter‑Bibliotheken oder die Aspose.PDF‑Komponente sind erforderlich.

{{% alert color="primary" %}}
Read more:[Convert PPT & PPTX to PDF in Python](/slides/de/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Präsentation‑zu‑XPS‑Konvertierung**

### **Über XPS**

Die [XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) ist eine Seitenbeschreibungssprache und ein festes Dokumentenformat, ursprünglich von Microsoft entwickelt. Wie PDF ist XPS ein festes Layout‑Dokumentenformat, das die Treue des Dokuments bewahren und ein geräteunabhängiges Erscheinungsbild bieten soll.

### **Präsentationen in XPS konvertieren**

Jede Präsentation, die von Aspose.Slides geladen werden kann, lässt sich in das XPS‑Format konvertieren. Aspose.Slides verwendet eine hochpräzise Seitenlayout‑ und Rendering‑Engine, um Ausgaben im festen XPS‑Layout zu erzeugen. Bemerkenswert ist, dass Aspose.Slides XPS direkt erstellt, ohne auf Windows Presentation Foundation (WPF) zurückzugreifen.

{{% alert color="primary" %}}
Read more:[Convert PowerPoint Presentations to XPS in Python](/slides/de/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Präsentation‑zu‑TIFF‑Konvertierung**

### **Über TIFF**

Das [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) ist ein Rasterbildformat, das dafür bekannt ist, mehrere Bilder (Seiten) in einer einzigen Datei zu speichern. Ursprünglich von Aldus entwickelt, wird es weitgehend von Scan‑, Fax‑ und anderen Bildverarbeitungsanwendungen unterstützt.

### **Präsentationen in TIFF konvertieren**

Jedes Dokument, das in Aspose.Slides geladen werden kann, lässt sich auch direkt in eine TIFF‑Datei konvertieren, ohne Drittanbieter‑Komponenten. Optional können Sie die Bildgröße für die Seiten der resultierenden TIFF festlegen.

{{% alert color="primary" %}}
Read more:[Convert PowerPoint Presentations to TIFF in Python](/slides/de/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Kann ich ausgeblendete Folien beim Export nach PDF/XPS einbeziehen?**

Ja. Der Export unterstützt das Einbeziehen ausgeblendeter Folien über die entsprechende Option in den [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/)-Einstellungen.

**Wird das Speichern im PDF/A‑Format (für Archivierung) unterstützt?**

Ja, PDF/A‑Konformitätsstufen [sind verfügbar](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (einschließlich A-2a/A-2b/A-2u und A-3a/A-3b) beim Export.

**Was passiert mit Schriften während der Konvertierung: werden sie eingebettet oder ersetzt?**

Es gibt flexible Optionen: Sie können [alle Glyphen oder nur verwendete Teilmengen einbetten](/slides/de/python-net/embedded-font/), eine [Fallback‑Schrift festlegen](/slides/de/python-net/fallback-font/), und das [Verhalten steuern](/slides/de/python-net/font-substitution/), wenn eine Schrift bestimmte Stile nicht enthält.

**Wie kann ich die Qualität und Größe des resultierenden PDF steuern?**

Optionen stehen zur Verfügung für [JPEG‑Qualität](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [Textkompression](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), und einen [ausreichenden Auflösungsschwellenwert](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) für Bilder, plus ein Modus, der die [beste Kompression für Bilder](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) auswählt.

**Kann ich nur einen bestimmten Folienbereich exportieren (z. B. 5–12)?**

Ja, der Export unterstützt die Auswahl eines Teilbereichs von Folien.

**Wird die Verarbeitung mehrerer Dateien gleichzeitig auf mehreren Kernen unterstützt?**

Es ist zulässig, verschiedene Präsentationen parallel in separaten Prozessen zu verarbeiten. Wichtig: Das gleiche [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt darf nicht von [mehreren Threads](/slides/de/python-net/multithreading/) gleichzeitig geladen oder gespeichert werden.

**Gibt es Risiken beim Anwenden der Lizenz von verschiedenen Threads aus?**

Ja, Aufrufe zum [Lizenz‑Setzen](/slides/de/python-net/licensing/) sind nicht thread‑sicher und erfordern Synchronisation.