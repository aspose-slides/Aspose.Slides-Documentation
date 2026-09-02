---
title: Übersicht der Funktionen
type: docs
weight: 20
url: /de/python-net/features-overview/
keywords:
- Funktionen
- unterstützte Plattformen
- Dateiformat
- Konvertierung
- Rendering
- Formatierung
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via .NET: eine leistungsstarke API zum effizienten Erstellen, Bearbeiten, Automatisieren und Konvertieren von PowerPoint- und OpenDocument‑Präsentationen."
---
## **Unterstützte Plattformen**
Die Plattformen, auf denen Aspose.Slides für Python via .NET verwendet werden kann, umfassen Windows x64 oder x86 sowie eine breite Palette von Linux‑Distributionen mit installiertem Python 3.5 oder höher. Zusätzlich gibt es Anforderungen an die Ziel‑Linux‑Plattform:
- GCC‑6 Laufzeitbibliotheken (oder neuer)
- Abhängigkeiten des .NET Core‑Runtime. Das Installieren des .NET Core‑Runtime selbst ist NICHT erforderlich
- Für Python 3.5‑3.7: Der `pymalloc`‑Build von Python wird benötigt. Die Python‑Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise wird der `pymalloc`‑Build von Python mit dem Suffix `m` im Dateinamen gekennzeichnet.
- `libpython`-gemeinsame Python‑Bibliothek. Die Python‑Build‑Option `--enable-shared` ist standardmäßig deaktiviert; einige Python‑Distributionen enthalten die `libpython`‑Bibliothek nicht. Für manche Linux‑Plattformen kann die `libpython`‑Bibliothek über den Paket‑Manager installiert werden, zum Beispiel: `sudo apt-get install libpython3.7`. Ein häufiges Problem besteht darin, dass die `libpython`‑Bibliothek an einem anderen Ort als dem Standard‑Systempfad für Shared‑Libraries installiert wird. Das Problem kann behoben werden, indem beim Kompilieren von Python alternative Bibliothekspfade gesetzt werden oder indem ein symbolischer Link zur `libpython`‑Datei im Standard‑Systempfad erstellt wird. Typischerweise lautet der Dateiname der `libpython`‑Shared‑Library `libpythonX.Ym.so.1.0` für Python 3.5‑3.7 bzw. `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Wenn Sie Unterstützung für weitere Plattformen benötigen, schauen Sie sich die „Zwillingsbruder“-Produkte Aspose.Slides für .NET oder Aspose.Slides für Java an.


## **Dateiformate und Konvertierungen**
Aspose.Slides für Python via .NET unterstützt die meisten PowerPoint‑Dokumentformate. Zudem können Sie diese in die gängigen Formate exportieren, die Organisationen häufig nutzen und austauschen. Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/de/python-net/ppt-vs-pptx/)|Aspose.Slides für Python via .NET bietet die schnellste Verarbeitung für dieses Präsentationsdokumentformat.|
|[PPT‑zu‑PPTX-Konvertierung](/slides/de/python-net/convert-ppt-to-pptx/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PPT nach PPTX.|
|[Portable Document Format (PDF)](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode nach Adobe Portable Document Format (PDF) exportieren.|
|[XML‑Parser‑Spezifikation (XPS)](https://docs.aspose.com/slides/de/python-net/convert-powerpoint-to-xps/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode nach XML Parser Specification (XPS) exportieren.|
|[Tagged Image File Format (TIFF)](/slides/de/python-net/convert-powerpoint-to-tiff/)|Sie können alle unterstützten Präsentationsdateiformate in Tagged Image File Format (TIFF) exportieren.|
|[PPTX‑zu‑HTML‑Konvertierung](https://docs.aspose.com/slides/de/python-net/convert-powerpoint-to-html/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PresentationEx nach HTML.|

## **Präsentations‑Rendering**
Aspose.Slides für Python via .NET unterstützt das Rendering von Folien in Präsentationsdokumenten mit hoher Treue zu verschiedenen Grafikformaten. Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|.NET‑unterstützte Bildformate|Mit Aspose.Slides für Python via .NET können Sie Präsentationsfolien und Bilder auf Folien in allen von .NET unterstützten Grafikformaten wie TIFF, PNG, BMP, JPEG, GIF und Metadateien rendern.|
|SVG‑Format|Aspose.Slides für Python via .NET bietet zudem integrierte Methoden, mit denen Sie Präsentationsfolien in Scalable Vector Graphics (SVG) exportieren können.|

## **Inhalts‑Features**
Aspose.Slides für Python via .NET ermöglicht den Zugriff, die Modifikation oder das Erstellen nahezu aller Elemente oder Inhalte von Präsentationsdokumenten. Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Master‑Folien|Die Master‑Folien definieren das Layout der normalen Folien. Aspose.Slides für Python via .NET erlaubt den Zugriff auf und die Modifikation von Master‑Folien in Präsentationsdokumenten.|
|Normale Folien|Mit Aspose.Slides für Python via .NET können Sie neue Folien verschiedener Typen erstellen; Sie erhalten außerdem Zugriff auf und können bestehende Folien in Präsentationen ändern.|
|Klonen / Kopieren von Folien|Es gibt integrierte Methoden von Aspose.Slides für Python via .NET, die das Klonen oder Kopieren von bestehenden Folien innerhalb einer Präsentation erlauben. Sie können geklonte oder kopierte Folien von einer Präsentation zur anderen übertragen. Da eine Folie ihr Layout vom Master‑Slide erbt, kopieren die integrierten Klon‑Methoden den Master automatisch beim Klonen.|
|Verwalten von Folienabschnitten|Methoden zum Organisieren von Folien in verschiedenen Abschnitten innerhalb einer Präsentation.|
|Platzhalter und Text‑Platzhalter|Sie können die Platzhalter und Text‑Platzhalter in einer Folie verwenden. Außerdem können Sie eine Folie mit Text‑Platzhaltern von Grund auf neu erstellen, indem Sie die passende Methode nutzen.|
|Kopf‑ und Fußzeilen|Aspose.Slides für Python via .NET erleichtert die Handhabung von Kopf‑ und Fußzeilen in Folien.|
|Notizen in Folien|Mit Aspose.Slides für Python via .NET können Sie Notizen, die einer Folie zugeordnet sind, lesen und ändern sowie neue Notizen hinzufügen.|
|Suche nach Form|Sie können eine bestimmte Form in einer Folie anhand des alternativen Textes der Form finden.|
|Hintergründe|Aspose.Slides für Python via .NET erlaubt die Arbeit mit Hintergründen, die einem Master‑ oder Normal‑Slide zugeordnet sind.|
|Textfelder|Textfelder können von Grund auf neu erstellt werden. Sie können vorhandene Textfelder verwenden und deren Text ändern, ohne das ursprüngliche Textformat zu verlieren.|
|Rechteck‑Formen|Sie können Rechteck‑Formen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Polylinien‑Formen|Sie können Polylinien‑Formen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Ellipse‑Formen|Sie können Ellipse‑Formen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Gruppen‑Formen|Aspose.Slides für Python via .NET unterstützt Gruppen‑Formen.|
|Auto‑Formen|Aspose.Slides für Python via .NET unterstützt Auto‑Formen.|
|SmartArt|Aspose.Slides für Python via .NET bietet Unterstützung für SmartArt‑Formen in MS PowerPoint.|
|Diagramme|Aspose.Slides für Python via .NET bietet Unterstützung für MSO‑Diagramme in PowerPoint.|
|Serialisierung von Formen|Aspose.Slides für Python via .NET unterstützt eine große Anzahl von Formen. Wenn Aspose.Slides für Python via .NET für eine Form keine Unterstützung bietet, können Sie eine Serialisierungsmethode nutzen, um diese Form von einer bestehenden Folie zu serialisieren und anschließend weiterzuverwenden.|
|Bild‑Frames|Sie können Bilder in Bild‑Frames mit Aspose.Slides für Python via .NET verwalten.|
|Audio‑Frames|Sie können Audio‑Dateien in Audio‑Frames auf Folien verlinken oder einbetten mit Aspose.Slides für Python via .NET.|
|Video‑Frames|Sie erhalten die Möglichkeit, Videodateien in Video‑Frames zu verarbeiten. Aspose.Slides für Python via .NET bietet zudem Unterstützung für verlinkte und eingebettete Videos.|
|OLE‑Frame|Sie können OLE‑Objekte in OLE‑Frames mit Aspose.Slides für Python via .NET verwalten.|
|Tabellen|Aspose.Slides für Python via .NET unterstützt Tabellen in Folien.|
|ActiveX‑Steuerelemente|Unterstützung für ActiveX‑Steuerelemente.|
|VBA‑Makros|Unterstützung für die Verwaltung von VBA‑Makros innerhalb von Präsentationen.|
|Text‑Frame|Sie erhalten Zugriff auf den Text jeder Form über den zugehörigen Text‑Frame.|
|Text‑Scanning|Sie können Text in einer Präsentation auf Präsentations‑ oder Folien‑Ebene mit integrierten Scan‑Methoden durchsuchen.|
|Animationen|Sie können Animationen auf Formen anwenden.|
|Bildschirmpräsentationen|Aspose.Slides für Python via .NET unterstützt Bildschirmpräsentationen und Folienübergänge.|

## **Formatierungs‑Features**
Mit Aspose.Slides für Python via .NET können Sie Texte und Formen auf Folien in Präsentationen formatieren. Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Textformatierung|<p>In Aspose.Slides für Python via .NET können Sie Texte über die Text‑Frames der Formen verwalten. Dadurch können Sie Texte mithilfe der Absätze und Textabschnitte innerhalb der Text‑Frames formatieren. Diese Textelemente können über Aspose.Slides für Python via .NET formatiert werden.</p><p>- Schriftart</p><p>- Schriftgröße</p><p>- Schriftfarbe</p><p>- Schrift-Schattierungen</p><p>- Absatz‑Ausrichtung</p><p>- Absatz‑Aufzählung</p><p>- Absatz‑Ausrichtung</p>|
|Formformatierung|<p>In Aspose.Slides für Python via .NET ist das grundlegende Element einer Folie eine Form. Sie können diese Form‑Elemente mit Aspose.Slides für Python via .NET formatieren:</p><p>- Position</p><p>- Größe</p><p>- Linie</p><p>- Füllung (inkl. Muster, Farbverlauf, Einheitlich)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

### Muss ich Microsoft PowerPoint auf dem Server/PC installieren, damit die Bibliothek funktioniert?

Nein. PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum Erstellen, Bearbeiten, Konvertieren und Rendern von Präsentationen.

### Wie funktioniert Multithreading? Kann die Verarbeitung parallelisiert werden?

Es ist sicher, verschiedene Dokumente in unterschiedlichen Threads zu verarbeiten; das gleiche [presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt darf nicht von [mehreren Threads](/slides/de/python-net/multithreading/) gleichzeitig genutzt werden.

### Werden Dateipasswörter und Verschlüsselung unterstützt?

Ja. [Sie können](/slides/de/python-net/password-protected-presentation/) verschlüsselte Präsentationen öffnen, ein Öffnungs‑ und Schreib‑Passwort setzen oder entfernen und den Schutz‑Status prüfen.

### Muss ich mich um Schriftpakete in Linux‑Containern kümmern?

Ja. Es wird empfohlen, gängige Schriftpakete zu installieren und/oder in Ihrer Anwendung explizit [Schriftverzeichnisse anzugeben](/slides/de/python-net/custom-font/), um unerwartete Ersetzungen zu vermeiden.

### Gibt es Einschränkungen in der Evaluierungs‑Version?

Im [Evaluierungs‑Modus](/slides/de/python-net/licensing/) wird dem Ausgabe‑Dokument ein Wasserzeichen hinzugefügt und gewisse Beschränkungen gelten; ein [30‑tägiges temporäres Lizenz]​(https://purchase.aspose.com/temporary-license/) ist für vollständige Tests verfügbar.

### Wird das Importieren externer Formate in eine Präsentation (PDF/HTML → PPTX) unterstützt?

Ja. Sie können [PDF‑Seiten und HTML‑Inhalte](/slides/de/python-net/import-presentation/) zu einer Präsentation hinzufügen und daraus Folien erzeugen.