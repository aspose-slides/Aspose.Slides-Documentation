---
title: Funktionsübersicht
type: docs
weight: 20
url: /de/python-net/features-overview/
keywords:
- Funktionen
- unterstützte Plattformen
- Dateiformat
- Konvertierung
- Rendering
- Drucken
- Formatierung
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: Entdecken Sie Aspose.Slides für Python via .NET: eine leistungsstarke API zum Erstellen, Bearbeiten, Automatisieren und Konvertieren von PowerPoint- und OpenDocument-Präsentationen effizient.
---

## **Unterstützte Plattformen**
Die Plattformen, auf denen Aspose.Slides für Python via .NET verwendet werden kann, sind Windows x64 oder x86 sowie eine Vielzahl von Linux‑Distributionen mit installiertem Python 3.5 oder höher. Es gibt zusätzliche Anforderungen an die Ziel‑Linux‑Plattform:
- GCC‑6-Laufzeitbibliotheken (oder neuer)
- Abhängigkeiten des .NET‑Core‑Runtime. Die Installation des .NET‑Core‑Runtime selbst ist NICHT erforderlich
- Für Python 3.5‑3.7: Der `pymalloc`‑Build von Python wird benötigt. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc`‑Build von Python mit dem Suffix `m` im Dateinamen gekennzeichnet.
- `libpython`‑Shared‑Python‑Bibliothek. Die Build‑Option `--enable-shared` ist standardmäßig deaktiviert; einige Python‑Distributionen enthalten die `libpython`‑Shared‑Bibliothek nicht. Für einige Linux‑Plattformen kann die `libpython`‑Shared‑Bibliothek über den Paketmanager installiert werden, z. B.: `sudo apt-get install libpython3.7`. Das häufige Problem besteht darin, dass die `libpython`‑Bibliothek an einem anderen Ort als dem Standardsystempfad für Shared‑Libraries installiert ist. Das Problem kann behoben werden, indem beim Kompilieren von Python alternative Bibliothekspfade gesetzt werden, oder indem ein symbolischer Link zur `libpython`‑Bibliothek im standardmäßigen Systempfad erstellt wird. Typischerweise lautet der Dateiname der `libpython`‑Shared‑Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5‑3.7 bzw. `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B.: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Wenn Sie Unterstützung für weitere Plattformen benötigen, suchen Sie nach den „Zwillingsbruder“-Produkten Aspose.Slides für .NET oder Aspose.Slides für Java.

## **Dateiformate und Konvertierungen**
Aspose.Slides für Python via .NET unterstützt die meisten PowerPoint‑Dokumentformate. Außerdem können Sie diese in die gängigen Formate exportieren, die von Organisationen breit verwendet und ausgetauscht werden. Details finden Sie unten:

|**Feature**|**Beschreibung**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/de/python-net/ppt-vs-pptx/)|Aspose.Slides für Python via .NET bietet die schnellste Verarbeitung für dieses Präsentationsdokumentformat.|
|[PPT to PPTX conversion](/slides/de/python-net/convert-ppt-to-pptx/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PPT nach PPTX.|
|[Portable Document Format (PDF)](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in Adobe Portable Document Format (PDF) exportieren.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in XML Parser Specification (XPS) exportieren.|
|[Tagged Image File Format (TIFF)](/slides/de/python-net/convert-powerpoint-to-tiff/)|Sie können alle unterstützten Präsentationsdateiformate in Tagged Image File Format (TIFF) exportieren.|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PresentationEx nach HTML.|

## **Rendering und Drucken**
Aspose.Slides für Python via .NET unterstützt das hochqualitative Rendering von Folien in Präsentationsdokumenten in verschiedene Grafikformate. Details finden Sie unten:

|**Feature**|**Beschreibung**|
| :- | :- |
|.NET unterstützte Bildformate|Mit Aspose.Slides für Python via .NET können Sie Präsentationsfolien und Bilder auf Folien in allen von .NET unterstützten Grafikformaten wie TIFF, PNG, BMP, JPEG, GIF und Metadateien rendern.|
|SVG‑Format|Aspose.Slides für Python via .NET bietet außerdem integrierte Methoden, mit denen Sie Präsentationsfolien in Scalable Vector Graphics (SVG) exportieren können.|
|Präsentationsdruck|Die neuesten Versionen von Aspose.Slides für Python via .NET enthalten integrierte Druckmethoden mit verschiedenen Optionen.|

## **Inhaltsfunktionen**
Aspose.Slides für Python via .NET ermöglicht den Zugriff, die Änderung oder das Erstellen von fast allen Elementen oder Inhalten von Präsentationsdokumenten. Details finden Sie unten:

|**Feature**|**Beschreibung**|
| :- | :- |
|Master Slides|Die Master‑Folien definieren das Layout der normalen Folien. Aspose.Slides für Python via .NET ermöglicht den Zugriff auf und die Änderung der Master‑Folien von Präsentationsdokumenten.|
|Normal Slides|Mit Aspose.Slides für Python via .NET können Sie neue Folien verschiedener Typen erstellen; Sie können außerdem bestehende Folien in den Präsentationen abrufen und ändern.|
|Cloning / Copying Slides|Es gibt integrierte Methoden von Aspose.Slides für Python via .NET, mit denen Sie bestehende Folien innerhalb einer Präsentation klonen oder kopieren können. Sie können kopierte und geklonte Folien von einer Präsentation zur anderen verwenden. Da eine Folie ihr Layout vom Master‑Slide erbt, kopieren die integrierten Klonmethoden den Master automatisch beim Klonen.|
|Managing Slides sections|Methoden zum Organisieren von Folien in verschiedene Abschnitte innerhalb einer Präsentation.|
|Place Holders and Text Holders|Sie können Platzhalter und Textplatzhalter in einer Folie abrufen. Außerdem können Sie mit der entsprechenden Methode eine Folie mit Textplatzhaltern von Grund auf neu erstellen.|
|Header and Footers|Aspose.Slides für Python via .NET erleichtert die Handhabung von Kopf‑ und Fußzeilen in Folien.|
|Notes in Slides|Mit Aspose.Slides für Python via .NET können Sie Notizen, die einer Folie zugeordnet sind, abrufen und ändern sowie neue Notizen hinzufügen.|
|Finding a Shape|Sie können mit dem alternativen Text, der einer Form zugeordnet ist, eine bestimmte Form auf einer Folie finden.|
|Backgrounds|Aspose.Slides für Python via .NET ermöglicht die Arbeit mit Hintergründen, die einem Master‑ oder einer normalen Folie in einer Präsentation zugeordnet sind.|
|Text Boxes|Textfelder können von Grund auf neu erstellt werden. Sie können vorhandene Textfelder abrufen. Außerdem können Sie deren Texte ändern, ohne das ursprüngliche Textformat zu verlieren.|
|Rectangle Shapes|Sie können Rechteckformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Poly Line Shapes|Sie können Polylinienformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Ellipse Shapes|Sie können Ellipsenformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Group Shapes|Aspose.Slides für Python via .NET unterstützt Gruppierungsformen.|
|Auto Shapes|Aspose.Slides für Python via .NET unterstützt Auto‑Shapes.|
|SmartArt|Aspose.Slides für Python via .NET bietet Unterstützung für SmartArt‑Formen in MS PowerPoint.|
|Charts|Aspose.Slides für Python via .NET bietet Unterstützung für MSO‑Diagramme in PowerPoint.|
|Shapes Serialization|Aspose.Slides für Python via .NET unterstützt eine große Anzahl von Formen. Wenn Aspose.Slides für Python via .NET eine Form nicht unterstützt, können Sie eine Serialisierungsmethode verwenden, mit der Sie diese Form von einer bestehenden Folie serialisieren. Auf diese Weise können Sie die Form weiter nach Ihren Anforderungen verwenden.|
|Picture Frames|Sie können Bilder in Bildrahmen mit Aspose.Slides für Python via .NET verwalten.|
|Audio Frames|Sie können Audio‑Dateien in Audio‑Frames auf Folien mit Aspose.Slides für Python via .NET verlinken oder einbetten.|
|Video Frames|Sie können Videodateien in Video‑Frames handhaben. Aspose.Slides für Python via .NET bietet zudem Unterstützung für verlinkte und eingebettete Videos.|
|OLE Frame|Sie können OLE‑Objekte in OLE‑Frames mit Aspose.Slides für Python via .NET verwalten.|
|Tables|Aspose.Slides für Python via .NET unterstützt Tabellen in Folien.|
|ActiveX Controls|Unterstützung für ActiveX‑Steuerelemente.|
|VBA Macros|Unterstützung für die Verwaltung von VBA‑Makros in Präsentationen.|
|Text Frame|Sie können den Text jeder Form über den mit dieser Form verbundenen Text‑Frame abrufen.|
|Text Scanning|Sie können Text in einer Präsentation auf Präsentations‑ oder Foli Ebene mittels integrierter Scan‑Methoden durchsuchen.|
|Animations|Sie können Animationen auf Formen anwenden.|
|Slide Shows|Aspose.Slides für Python via .NET unterstützt Diashows und Folienübergänge.|

## **Formatierungsfunktionen**
Mit Aspose.Slides für Python via .NET können Sie Texte und Formen auf Folien in Präsentationen formatieren. Details finden Sie unten:

|**Feature**|**Beschreibung**|
| :- | :- |
|Textformatierung|<p>In Aspose.Slides für Python via .NET können Sie Texte über die Text‑Frames verwalten, die den Formen zugeordnet sind. Somit können Sie Texte mithilfe der Absätze und Textabschnitte formatieren, die den Text‑Frames zugeordnet sind. Diese Textelemente können über Aspose.Slides für Python via .NET formatiert werden.</p><p>- Schriftart</p><p>- Schriftgröße</p><p>- Schriftfarbe</p><p>- Schrift‑Schattierungen</p><p>- Absatzausrichtung</p><p>- Absatz Aufzählungszeichen</p><p>- Absatzorientierung</p>|
|Formformatierung|<p>In Aspose.Slides für Python via .NET ist das Basiselement einer Folie eine Form. Sie können diese Formelemente mit Aspose.Slides für Python via .NET formatieren:</p><p>- Position</p><p>- Größe</p><p>- Linie</p><p>- Füllung (einschließlich Muster, Farbverlauf, Solid)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

**Muss ich Microsoft PowerPoint auf dem Server/PC installieren, damit die Bibliothek funktioniert?**

Nein. PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum Erstellen, Bearbeiten, Konvertieren und Rendern von Präsentationen.

**Wie funktioniert Multithreading? Kann die Verarbeitung parallelisiert werden?**

Es ist sicher, verschiedene Dokumente in unterschiedlichen Threads zu verarbeiten; das gleiche [presentation](/slides/de/python-net/presentation/)‑Objekt darf nicht von [multiple threads](/slides/de/python-net/multithreading/) gleichzeitig verwendet werden.

**Werden Dateipasswörter und Verschlüsselung unterstützt?**

Ja. Sie können verschlüsselte Präsentationen öffnen, ein Öffnungs‑ und Schreibpasswort festlegen oder entfernen und den Schutzstatus überprüfen. [Weitere Informationen](/slides/de/python-net/password-protected-presentation/)

**Muss ich in Linux‑Containern auf Schriftpakete achten?**

Ja. Es wird empfohlen, gängige Schriftpakete zu installieren und/oder in Ihrer Anwendung ausdrücklich [font directories](/slides/de/python-net/custom-font/) anzugeben, um unerwartete Ersetzungen zu vermeiden.

**Gibt es Einschränkungen in der Evaluierungsversion?**

Im [evaluation mode](/slides/de/python-net/licensing/) wird dem Ausgabe‑Dokument ein Wasserzeichen hinzugefügt und es gelten bestimmte Beschränkungen; eine [30‑tägige temporäre Lizenz](https://purchase.aspose.com/temporary-license/) steht für vollumfängliche Tests zur Verfügung.

**Wird das Importieren externer Formate in eine Präsentation (PDF/HTML → PPTX) unterstützt?**

Ja. Sie können [PDF‑Seiten und HTML‑Inhalte](/slides/de/python-net/import-presentation/) zu einer Präsentation hinzufügen und dabei automatisch in Folien umwandeln.