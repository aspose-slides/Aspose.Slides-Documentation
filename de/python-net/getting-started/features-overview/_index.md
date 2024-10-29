---
title: Funktionenübersicht
type: docs
weight: 20
url: /de/python-net/features-overview/
---

## **Unterstützte Plattformen**
Die Plattformen Aspose.Slides für Python über .NET können auf Windows x64 oder x86 und einer Vielzahl von Linux-Distributionen mit installiertem Python 3.5 oder höher verwendet werden. Es gibt zusätzliche Anforderungen an die Ziel-Linux-Plattform:
- GCC-6 Laufzeitbibliotheken (oder höher)
- Abhängigkeiten der .NET Core Runtime. Die Installation der .NET Core Runtime selbst ist NICHT erforderlich.
- Für Python 3.5-3.7: Der `pymalloc` Build von Python ist erforderlich. Die Python-Build-Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc` Build von Python im Dateinamen mit der Endung `m` gekennzeichnet.
- `libpython` gemeinsame Python-Bibliothek. Die Python-Build-Option `--enable-shared` ist standardmäßig deaktiviert, einige Python-Distributionen enthalten die `libpython` gemeinsame Bibliothek nicht. Für einige Linux-Plattformen kann die gemeinsame Bibliothek `libpython` über den Paketmanager installiert werden, z.B.: `sudo apt-get install libpython3.7`. Das häufige Problem ist, dass die `libpython` Bibliothek an einem anderen Ort installiert ist als der Standard-Systemort für gemeinsame Bibliotheken. Das Problem kann behoben werden, indem die Python-Build-Optionen verwendet werden, um alternative Bibliothekspfade beim Kompilieren von Python festzulegen, oder indem ein symbolischer Link zur `libpython` Bibliotheksdatei im Standardsystemstandort für gemeinsame Bibliotheken erstellt wird. Typischerweise lautet der Dateiname der `libpython` gemeinsamen Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5-3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder höher (z.B.: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Wenn Sie Unterstützung für weitere Plattformen benötigen, suchen Sie nach den "Zwillingsprodukten" Aspose.Slides für .NET oder Aspose.Slides für Java.

## **Dateiformate und Konvertierungen**
Aspose.Slides für Python über .NET unterstützt die meisten PowerPoint-Dokumentformate. Es ermöglicht Ihnen auch, diese in die gängigen Formate zu exportieren, die von Organisationen weit verbreitet verwendet und gegenseitig ausgetauscht werden. Sehen Sie sich diese Details an:

|**Funktion**|**Beschreibung**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/de/python-net/ppt-vs-pptx/)|Aspose.Slides für Python über .NET bietet die schnellste Verarbeitung für dieses Präsentationsdokumentformat.|
|[PPT zu PPTX Konvertierung](/slides/de/python-net/convert-ppt-to-pptx/)|Aspose.Slides für Python über .NET unterstützt die Konvertierung von PPT zu PPTX.|
|[Portable Document Format (PDF)](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in Adobe Portable Document Format (PDF) Dokumente exportieren.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in XML Parser Specification (XPS) Dokumente exportieren.|
|[Tagged Image File Format (TIFF)](/slides/de/python-net/convert-powerpoint-to-tiff/)|Sie können alle unterstützten Präsentationsdateiformate in Tagged Image File Format (TIFF) exportieren.|
|[PPTX zu HTML Konvertierung](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides für Python über .NET unterstützt die Konvertierung von PresentationEx in HTML-Format.|

## **Rendering und Drucken**
Aspose.Slides für Python über .NET unterstützt hochpräzises Rendering von Folien in den Präsentationsdokumenten in verschiedene Grafikformate. Sehen Sie sich diese Details an:

|**Funktion**|**Beschreibung**|
| :- | :- |
|.NET unterstützte Bildformate|Mit Aspose.Slides für Python über .NET können Sie Präsentationsfolien und Bilder auf Folien in allen von .NET unterstützten Grafikformaten wie TIFF, PNG, BMP, JPEG, GIF und Metadateien rendern.|
|SVG-Format|Aspose.Slides für Python über .NET bietet auch integrierte Methoden, die es Ihnen ermöglichen, Präsentationsfolien in Scalable Vector Graphics (SVG) Formate zu exportieren.|
|Präsentation Drucken|Die neuesten Versionen von Aspose.Slides für Python über .NET bieten integrierte Druckmethoden mit verschiedenen Optionen.|

## **Inhaltsfunktionen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, auf fast alle Elemente oder Inhalte von Präsentationsdokumenten zuzugreifen, sie zu ändern oder zu erstellen. Sehen Sie sich diese Details an:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Masterfolien|Die Masterfolien definieren das Layout der normalen Folien. Aspose.Slides für Python über .NET ermöglicht es Ihnen, auf die Masterfolien der Präsentationsdokumente zuzugreifen und sie zu ändern.|
|Normale Folien|Mit Aspose.Slides für Python über .NET können Sie neue Folien unterschiedlicher Typen erstellen; Sie können auch auf vorhandene Folien in den Präsentationen zugreifen und diese ändern.|
|Klone / Kopieren von Folien|Es gibt integrierte Methoden von Aspose.Slides für Python über .NET, die es Ihnen ermöglichen, vorhandene Folien innerhalb einer Präsentation zu klonen oder zu kopieren. Sie können auch kopierte und geklonte Folien von einer Präsentation zu einer anderen verwenden. Da eine Folie ihr Layout von der Masterfolie erbt, kopieren die integrierten Klonmethoden automatisch die Masterfolie beim Klonen.|
|Verwaltung der Folienabschnitte|Methoden zum Organisieren von Folien in verschiedenen Abschnitten innerhalb einer Präsentation.|
|Platzhalter und Texthalter|Sie können auf die Platzhalter und Texthalter in einer Folie zugreifen. Darüber hinaus können Sie eine Folie mit Texthaltern von Grund auf neu erstellen, indem Sie die geeignete Methode verwenden.|
|Kopf- und Fußzeilen|Aspose.Slides für Python über .NET erleichtert die Handhabung von Kopf- und Fußzeilen in Folien.|
|Notizen in Folien|Mit Aspose.Slides für Python über .NET können Sie auf Notizen zugreifen und diese ändern, die mit einer Folie verknüpft sind, und auch neue Notizen hinzufügen.|
|Ein Shape finden|Sie können auch eine bestimmte Form aus einer Folie anhand des alternativen Textes, der mit der Form verknüpft ist, finden.|
|Hintergründe|Aspose.Slides für Python über .NET ermöglicht es Ihnen, mit Hintergründen zu arbeiten, die mit einer Master- oder normalen Folie in einer Präsentation verknüpft sind.|
|Textkästen|Textkästen können von Grund auf neu erstellt werden. Sie können vorhandene Textkästen abrufen. Sie können auch deren Texte ändern, ohne das ursprüngliche Textformat zu verlieren.|
|Rechteckige Formen|Sie können rechteckige Formen mit Aspose.Slides für Python über .NET erstellen oder ändern.|
|Poly-Linienformen|Sie können Poly-Linienformen mit Aspose.Slides für Python über .NET erstellen oder ändern.|
|Ellipseformen|Sie können Ellipseformen mit Aspose.Slides für Python über .NET erstellen oder ändern.|
|Gruppenformen|Aspose.Slides für Python über .NET unterstützt Gruppenformen.|
|Autoformen|Aspose.Slides für Python über .NET unterstützt Autoformen.|
|SmartArt|Aspose.Slides für Python über .NET bietet Unterstützung für SmartArt-Formen in MS PowerPoint.|
|Diagramme|Aspose.Slides für Python über .NET bietet Unterstützung für MSO-Diagramme in PowerPoint.|
|Formenserialisierung|Aspose.Slides für Python über .NET unterstützt eine große Anzahl von Formen. Wenn Aspose.Slides für Python über .NET keine Unterstützung für eine Form hat, können Sie eine Serialisierungsmethode verwenden, über die Sie diese Form von einer vorhandenen Folie serialisieren können. So können Sie die Form je nach Ihren Anforderungen weiter verwenden.|
|Bildrahmen|Sie können Bilder in Bildrahmen mit Aspose.Slides für Python über .NET verwalten.|
|Audio-Rahmen|Sie können Audiodateien in Audio-Rahmen auf Folien mit Aspose.Slides für Python über .NET verlinken oder einbetten.|
|Video-Rahmen|Sie können Videodateien in Video-Rahmen verwalten. Aspose.Slides für Python über .NET bietet auch Unterstützung für verlinkte und eingebettete Videos.|
|OLE-Rahmen|Sie können OLE-Objekte in OLE-Rahmen mit Aspose.Slides für Python über .NET verwalten.|
|Tabellen|Aspose.Slides für Python über .NET unterstützt Tabellen in Folien.|
|ActiveX-Steuerelemente|Unterstützung für ActiveX-Steuerelemente.|
|VBA-Makros|Unterstützung für die Verwaltung von VBA-Makros innerhalb von Präsentationen.|
|Textfeld|Sie können auf den Text mit einer beliebigen Form über das mit dieser Form verknüpfte Textfeld zugreifen.|
|Textscannen|Sie können Texte in einer Präsentation auf der Präsentations- oder Folienstufe durch integrierte Scanmethoden scannen.|
|Animationen|Sie können Animationen auf Formen anwenden.|
|Präsentationen|Aspose.Slides für Python über .NET unterstützt Präsentationen und Folienübergänge.|

## **Formatierungsfunktionen**
Mit Aspose.Slides für Python über .NET können Sie Texte und Formen auf Folien in Präsentationen formatieren. Sehen Sie sich diese Details an:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Textformatierung|<p>In Aspose.Slides für Python über .NET können Sie Texte über die mit den Formen verknüpften Textfelder verwalten. Daher können Sie Texte mithilfe der Absätze und Teile formatieren, die mit den Textfeldern verknüpft sind. Diese Textelemente können durch Aspose.Slides für Python über .NET formatiert werden.</p><p>- Schriftart</p><p>- Schriftgröße</p><p>- Schriftfarbe</p><p>- Schriftarten</p><p>- Absatzausrichtung</p><p>- Absatzaufzählung</p><p>- Absatzausrichtung</p>|
|Formformatierung|<p>In Aspose.Slides für Python über .NET ist das grundlegende Element einer Folie eine Form. Sie können diese Formelemente mit Aspose.Slides für Python über .NET formatieren:</p><p>- Position</p><p>- Größe</p><p>- Linie</p><p>- Füllung (einschließlich Muster, Gradient, Fest)</p><p>- Text</p><p>- Bild</p>|