---
title: Präsentationen in Python in mehrere Formate konvertieren
linktitle: Präsentationen konvertieren
type: docs
weight: 70
url: /de/python-net/developer-guide/manage-presentation/convert-presentation/
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
description: "PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET in PPTX, PDF, XPS, TIFF und weitere Formate konvertieren. Einfach, hochwertige Konvertierung."
---

## **Einleitung**

Auf dieser Seite finden Sie einen Überblick über die Präsentationskonvertierung mit Aspose.Slides für Python via .NET. Sie fasst unterstützte Szenarien zusammen und verweist auf gezielte Anleitungen, die den genauen Code zum Exportieren von Präsentationen und Folien in Formate wie PDF, XPS, TIFF sowie zum Konvertieren zwischen PPT und PPTX zeigen. Bei Bedarf heben die verlinkten Artikel format‑spezifische Optionen hervor – beispielsweise das Rendern von Notizen oder das Anpassen der Bildqualität – und weisen auf bekannte Einschränkungen wie Teilunterstützung bei PPT→PPTX‑Pfade hin. Nutzen Sie diese Seite, um ein Zielformat auszuwählen und folgen Sie dann dem verlinkten Rezept.

## **PPT‑zu‑PPTX‑Konvertierung**

### **Über PPT/PPTX**

PPT ist das ältere binäre PowerPoint‑Format (97–2003), während PPTX das ZIP‑gepackte Open‑XML‑Format ist, das mit PowerPoint 2007 eingeführt wurde. Im Vergleich zu PPT erzeugt PPTX typischerweise kleinere Dateien, unterstützt moderne Funktionen, lässt sich gut mit Dokumenten‑Automatisierung einsetzen und wird für die langfristige Speicherung sowie plattformübergreifende Workflows empfohlen.

### **PPT in PPTX konvertieren**

Aspose.Slides unterstützt die Konvertierung von PPT‑Präsentationen in das PPTX‑Format. Der Hauptvorteil der Verwendung der Aspose.Slides‑API für diese Aufgabe liegt in der Einfachheit des Workflows, der das gewünschte Ergebnis liefert. In der Praxis können Sie die Konvertierung mit minimalem Code durchführen und dabei die hohe Treue von Folien, Layouts und Medien beibehalten.

{{% alert color="primary" %}}
Weitere Informationen: [Convert PPT to PPTX in Python](/slides/de/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Präsentation‑zu‑PDF‑Konvertierung**

### **Über PDF**

Das [Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) ist ein von Adobe Systems entwickeltes Dateiformat zum Austausch von Dokumenten zwischen Organisationen. Ziel ist es, sicherzustellen, dass der Inhalt eines Dokuments auf jeder Plattform identisch angezeigt wird.

### **Präsentationen in PDF konvertieren**

Jede Präsentation, die in Aspose.Slides geladen werden kann, lässt sich in ein PDF‑Dokument konvertieren. Sie können Präsentationen direkt mit der Aspose.Slides‑Komponente in PDF exportieren; dafür sind keine Drittanbieter‑Bibliotheken oder die Aspose.PDF‑Komponente erforderlich.

{{% alert color="primary" %}}
Weitere Informationen: [Convert PPT & PPTX to PDF in Python](/slides/de/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Präsentation‑zu‑XPS‑Konvertierung**

### **Über XPS**

Die [XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) ist eine Seitenbeschreibungssprache und ein festes Dokumentenformat, das ursprünglich von Microsoft entwickelt wurde. Ähnlich wie PDF ist XPS ein festes Layout‑Format, das die Dokumententreue bewahrt und ein geräteunabhängiges Aussehen bietet.

### **Präsentationen in XPS konvertieren**

Jede Präsentation, die von Aspose.Slides geladen werden kann, lässt sich in das XPS‑Format konvertieren. Aspose.Slides verwendet eine hochpräzise Layout‑ und Rendering‑Engine, um Ausgaben im festem Layout‑XPS‑Format zu erzeugen. Bemerkenswert ist, dass Aspose.Slides XPS direkt erzeugt, ohne auf Windows Presentation Foundation (WPF) zurückzugreifen.

{{% alert color="primary" %}}
Weitere Informationen: [Convert PowerPoint Presentations to XPS in Python](/slides/de/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Präsentation‑zu‑TIFF‑Konvertierung**

### **Über TIFF**

Das [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) ist ein Raster‑Bildformat, das dafür bekannt ist, mehrere Bilder (Seiten) in einer einzigen Datei zu speichern. Ursprünglich von Aldus entwickelt, wird es breit von Scan‑, Fax‑ und anderen Bildverarbeitungs‑Anwendungen unterstützt.

### **Präsentationen in TIFF konvertieren**

Jedes Dokument, das in Aspose.Slides geladen werden kann, lässt sich ebenfalls direkt in eine TIFF‑Datei konvertieren, ohne Drittanbieter‑Komponenten. Optional können Sie die Bildgröße für die Seiten der resultierenden TIFF-Datei angeben.

{{% alert color="primary" %}}
Weitere Informationen: [Convert PowerPoint Presentations to TIFF in Python](/slides/de/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Kann ich beim Export nach PDF/XPS versteckte Folien einbeziehen?**

Ja. Der Export unterstützt das Einbeziehen versteckter Folien über die entsprechende Option in den [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/)‑Einstellungen.

**Wird das Speichern im PDF/A‑Format (für Archivierung) unterstützt?**

Ja, PDF/A‑Kompatibilitätsstufen [stehen zur Verfügung](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (einschließlich A-2a/A-2b/A-2u und A-3a/A-3b) beim Export.

**Was passiert mit Schriften während der Konvertierung: werden sie eingebettet oder ersetzt?**

Es gibt flexible Optionen: Sie können [alle Glyphen oder nur verwendete Teilmengen einbetten](/slides/de/python-net/embedded-font/), eine [Fallback‑Schrift angeben](/slides/de/python-net/fallback-font/), und das [Verhalten steuern](/slides/de/python-net/font-substitution/), wenn einer Schrift bestimmte Stile fehlen.

**Wie kann ich die Qualität und Größe des resultierenden PDFs steuern?**

Optionen stehen zur Verfügung für [JPEG‑Qualität](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [Textkompression](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), und einen [ausreichenden Auflösungs‑Schwellenwert](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) für Bilder, plus ein Modus, der die [beste Kompression für Bilder](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) auswählt.

**Kann ich nur einen Folienbereich exportieren (z. B. 5–12)?**

Ja, der Export unterstützt das Auswählen eines Teilbereichs von Folien.

**Wird die Mehrkern‑Verarbeitung mehrerer Dateien gleichzeitig unterstützt?**

Es ist zulässig, verschiedene Präsentationen parallel in separaten Prozessen zu verarbeiten. Wichtig: Das gleiche [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt darf nicht von [mehreren Threads](/slides/de/python-net/multithreading/) geladen oder gespeichert werden.

**Gibt es Risiken beim Anwenden der Lizenz aus verschiedenen Threads?**

Ja, Aufrufe zum [Lizenz‑Setzen](/slides/de/python-net/licensing/) sind nicht threadsicher und erfordern Synchronisation.