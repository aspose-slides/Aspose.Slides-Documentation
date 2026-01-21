---
title: OpenDocument‑Präsentationen in .NET konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/net/convert-openoffice-odp/
keywords:
- ODP konvertieren
- ODP zu Bild
- ODP zu GIF
- ODP zu HTML
- ODP zu JPG
- ODP zu MD
- ODP zu PDF
- ODP zu PNG
- ODP zu PPT
- ODP zu PPTX
- ODP zu TIFF
- ODP zu Video
- ODP zu Word
- ODP zu XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides für .NET ermöglicht das einfache Konvertieren von ODP in PDF, HTML und Bildformate. Steigern Sie Ihre .NET-Anwendungen mit schneller und genauer Präsentationskonvertierung."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) ermöglicht das Konvertieren von OpenDocument (ODP)-Präsentationen in viele Formate (HTML, PDF, TIFF, SWF, XPS usw.). Die API, die zum Konvertieren von ODP-Dateien in andere Dokumentformate verwendet wird, ist dieselbe wie die für PowerPoint‑(PPT und PPTX)Konvertierungs‑Operationen.

Zum Beispiel, wenn Sie eine ODP‑Präsentation in PDF konvertieren müssen, können Sie dies wie folgt tun:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **OpenDocument‑Präsentation in verschiedenen Anwendungen**

Wenn eine OpenDocument‑Präsentation (ODP)-Datei in PowerPoint geöffnet wird, kann sie die ursprüngliche Formatierung aus der Anwendung, in der sie erstellt wurde, nicht beibehalten. Das liegt daran, dass die OpenDocument‑Präsentations‑App und die PowerPoint‑App unterschiedliche Funktionen und Render‑Verhalten bieten.

Hier sind einige der Unterschiede:

- In PowerPoint werden Tabellen in der Regel zuletzt gerendert und können andere Formen überlagern, unabhängig von ihrer Reihenfolge auf der ODP‑Folie.
- Bildfüllungen für ODP‑Tabellen werden in PowerPoint nicht unterstützt.
- Vertikale Textrotation (270°, gestapelt) und verteilte Ausrichtung werden in LibreOffice/OpenOffice Impress nicht unterstützt.
- Bildfüllungen, Farbverlauf‑Füllungen und Muster‑Füllungen für Text werden in LibreOffice/OpenOffice Impress nicht unterstützt.

MS PowerPoint und LibreOffice/OpenOffice Impress gehen mit Listen ebenfalls unterschiedlich um. Eine in PowerPoint erstellte ODP‑Datei wird in LibreOffice/OpenOffice Impress möglicherweise nicht korrekt angezeigt, und umgekehrt.

Das Bild unten zeigt, wie eine Liste aussieht, wenn sie in LibreOffice Impress erstellt wird:

![ODP list example](odp-list-example.png)

Aspose.Slides speichert ODP‑Listen so, dass sie in LibreOffice/OpenOffice Impress korrekt angezeigt werden.

[Erfahren Sie mehr über das OpenDocument-Format und PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Was ist, wenn sich die Formatierung meiner ODP‑Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle, und einige Elemente – wie Tabellen, benutzerdefinierte Schriftarten oder Füllstile – werden möglicherweise nicht exakt gleich gerendert. Es wird empfohlen, die Ausgabe zu überprüfen und bei Bedarf Layout oder Formatierung im Code anzupassen.

**Benötige ich OpenOffice oder LibreOffice, um die ODP‑Konvertierung zu nutzen?**

Nein, Aspose.Slides für .NET ist eine eigenständige Bibliothek und erfordert nicht, dass OpenOffice oder LibreOffice auf Ihrem System installiert ist.

**Kann ich das Ausgabeformat während der ODP‑Konvertierung anpassen (z. B. PDF‑Optionen festlegen)?**

Ja, Aspose.Slides bietet umfangreiche Optionen zur Anpassung der Ausgabe. Zum Beispiel können Sie beim Speichern als PDF die Kompression, Bildqualität, Textdarstellung und mehr über die [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse steuern.

**Ist Aspose.Slides für die serverseitige oder cloudbasierte ODP‑Verarbeitung geeignet?**

Absolut. Aspose.Slides für .NET ist dafür ausgelegt, sowohl in Desktop‑ als auch in Server‑Umgebungen zu arbeiten, einschließlich cloudbasierter Plattformen wie Azure, AWS und Docker‑Containern, ohne jegliche UI‑Abhängigkeiten.