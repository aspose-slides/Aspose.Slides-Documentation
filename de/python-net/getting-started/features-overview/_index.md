---
title: Überblick der Funktionen
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
description: "Entdecken Sie Aspose.Slides für Python via .NET: eine leistungsstarke API zum Erstellen, Bearbeiten, Automatisieren und Konvertieren von PowerPoint- und OpenDocument-Präsentationen effizient."
---

## **Unterstützte Plattformen**
Die Plattformen, auf denen Aspose.Slides für Python via .NET verwendet werden kann, umfassen Windows x64 oder x86 sowie eine breite Palette von Linux‑Distributionen mit installiertem Python 3.5 oder höher. Zusätzliche Anforderungen an die Ziel‑Linux‑Plattform bestehen:

- GCC‑6 Runtime‑Bibliotheken (oder neuer)
- Abhängigkeiten des .NET Core Runtime. Die Installation des .NET Core Runtime selbst ist NICHT erforderlich
- Für Python 3.5‑3.7: Der `pymalloc`‑Build von Python ist erforderlich. Die Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc`‑Build von Python mit dem Suffix `m` im Dateinamen gekennzeichnet.
- `libpython` Shared‑Python‑Bibliothek. Die Option `--enable-shared` ist standardmäßig deaktiviert, einige Python‑Distributionen enthalten die Shared‑Bibliothek `libpython` nicht. Für einige Linux‑Plattformen kann die Shared‑Bibliothek `libpython` über den Paketmanager installiert werden, z. B.: `sudo apt-get install libpython3.7`. Das häufige Problem besteht darin, dass die Bibliothek `libpython` an einem anderen Ort als dem Standard‑Systempfad für Shared‑Bibliotheken installiert ist. Das Problem kann behoben werden, indem beim Kompilieren von Python alternative Bibliothekspfade über die Build‑Optionen gesetzt werden, oder durch Erstellen eines symbolischen Links zur Bibliotheksdatei `libpython` im standardmäßigen Systempfad für Shared‑Bibliotheken. Typischerweise lautet der Dateiname der Shared‑Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5‑3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B.: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Wenn Sie Unterstützung für weitere Plattformen benötigen, schauen Sie sich die „Zwillingsbruder“-Produkte Aspose.Slides für .NET oder Aspose.Slides für Java an.

## **Dateiformate und Konvertierungen**
Aspose.Slides für Python via .NET unterstützt die meisten PowerPoint‑Dokumentformate. Es ermöglicht zudem den Export in die gängigen Formate, die von Organisationen häufig verwendet und ausgetauscht werden. Lesen Sie die Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/de/python-net/ppt-vs-pptx/)|Aspose.Slides für Python via .NET bietet die schnellste Verarbeitung für dieses Präsentationsdokumentformat.|
|[PPT to PPTX conversion](/slides/de/python-net/convert-ppt-to-pptx/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PPT zu PPTX.|
|[Portable Document Format (PDF)](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in Adobe Portable Document Format (PDF) Dokumente exportieren.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in XML Parser Specification (XPS) Dokumente exportieren.|
|[Tagged Image File Format (TIFF)](/slides/de/python-net/convert-powerpoint-to-tiff/)|Sie können alle unterstützten Präsentationsdateiformate in Tagged Image File Format (TIFF) exportieren.|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PresentationEx in das HTML‑Format.|

## **Rendering und Drucken**
Aspose.Slides für Python via .NET unterstützt das hochqualitative Rendering von Folien in Präsentationsdokumenten in verschiedene Grafikformate. Lesen Sie die Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|.NET Supported Image Formats|Mit Aspose.Slides für Python via .NET können Sie Präsentationsfolien und Bilder auf Folien in alle von .NET unterstützten Grafikformate wie TIFF, PNG, BMP, JPEG, GIF und Metadateien rendern.|
|SVG Format|Aspose.Slides für Python via .NET bietet außerdem integrierte Methoden, die den Export von Präsentationsfolien in Scalable Vector Graphics (SVG)-Formate ermöglichen.|
|Presentation Printing|Die neuesten Versionen von Aspose.Slides für Python via .NET bieten integrierte Druckmethoden mit verschiedenen Optionen.|

## **Inhaltsfunktionen**
Aspose.Slides für Python via .NET ermöglicht den Zugriff, die Änderung oder das Erstellen fast aller Elemente oder Inhalte von Präsentationsdokumenten. Lesen Sie die Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Master Slides|Die Masterfolien definieren das Layout der normalen Folien. Aspose.Slides für Python via .NET ermöglicht den Zugriff auf und die Modifikation der Masterfolien von Präsentationsdokumenten.|
|Normal Slides|Mit Aspose.Slides für Python via .NET können Sie neue Folien verschiedener Typen erstellen; Sie erhalten ebenfalls Zugriff auf und können bestehende Folien in Präsentationen ändern.|
|Cloning / Copying Slides|Es gibt integrierte Methoden in Aspose.Slides für Python via .NET, die es ermöglichen, vorhandene Folien innerhalb einer Präsentation zu klonen oder zu kopieren. Sie können geklonte und kopierte Folien von einer Präsentation zur anderen verwenden. Da eine Folie ihr Layout vom Master übernimmt, kopieren die integrierten Klonmethoden den Master automatisch beim Klonen.|
|Managing Slides sections|Methoden zum Organisieren von Folien in verschiedenen Abschnitten innerhalb einer Präsentation.|
|Place Holders and Text Holders|Sie können die Platzhalter und Textplatzhalter in einer Folie zugreifen. Außerdem können Sie eine Folie mit Textplatzhaltern von Grund auf neu erstellen, indem Sie die entsprechende Methode verwenden.|
|Header and Footers|Aspose.Slides für Python via .NET erleichtert die Handhabung von Kopf‑/Fußzeilen in Folien.|
|Notes in Slides|Mit Aspose.Slides für Python via .NET können Sie auf Notizen zu einer Folie zugreifen und diese ändern sowie neue Notizen hinzufügen.|
|Finding a Shape|Sie können auch eine bestimmte Form auf einer Folie anhand des alternativen Textes der Form finden.|
|Backgrounds|Aspose.Slides für Python via .NET ermöglicht die Arbeit mit Hintergründen, die mit einem Master oder einer normalen Folie in einer Präsentation verbunden sind.|
|Text Boxes|Textfelder können von Grund auf neu erstellt werden. Sie können vorhandene Textfelder zugreifen. Sie können deren Texte ändern, ohne das ursprüngliche Textformat zu verlieren.|
|Rectangle Shapes|Sie können Rechteckformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Poly Line Shapes|Sie können Polylinienformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Ellipse Shapes|Sie können Ellipseformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Group Shapes|Aspose.Slides für Python via .NET unterstützt gruppierte Formen.|
|Auto Shapes|Aspose.Slides für Python via .NET unterstützt Autoformen.|
|SmartArt|Aspose.Slides für Python via .NET bietet Unterstützung für SmartArt‑Formen in MS PowerPoint.|
|Charts|Aspose.Slides für Python via .NET bietet Unterstützung für MSO‑Diagramme in PowerPoint.|
|Shapes Serialization|Aspose.Slides für Python via .NET unterstützt eine große Anzahl von Formen. Wenn Aspose.Slides für Python via .NET keine Unterstützung für eine Form bietet, können Sie eine Serialisierungsmethode verwenden, um diese Form von einer bestehenden Folie zu serialisieren. Auf diese Weise können Sie die Form weiter nach Ihren Anforderungen nutzen.|
|Picture Frames|Sie können Bilder in Bildrahmen mit Aspose.Slides für Python via .NET verwalten.|
|Audio Frames|Sie können Audio‑Dateien in Audiorahmen auf Folien verknüpfen oder einbetten mit Aspose.Slides für Python via .NET.|
|Video Frames|Sie können Videodateien in Videorahmen verwalten. Aspose.Slides für Python via .NET bietet zudem Unterstützung für verknüpfte und eingebettete Videos.|
|OLE Frame|Sie können OLE‑Objekte in OLE‑Rahmen mit Aspose.Slides für Python via .NET verwalten.|
|Tables|Aspose.Slides für Python via .NET unterstützt Tabellen in Folien.|
|ActiveX Controls|Unterstützung für ActiveX‑Steuerelemente.|
|VBA Macros|Unterstützung für die Verwaltung von VBA‑Makros in Präsentationen.|
|Text Frame|Sie können den Text jeder Form über den mit dieser Form verbundenen Textrahmen abrufen.|
|Text Scanning|Sie können Text in einer Präsentation auf Präsentations‑ oder Folienebene durch integrierte Scan‑Methoden durchsuchen.|
|Animations|Sie können Animationen auf Formen anwenden.|
|Slide Shows|Aspose.Slides für Python via .NET unterstützt Bildschirmpräsentationen und Folienübergänge.|

## **Formatierungsfunktionen**
Mit Aspose.Slides für Python via .NET können Sie Texte und Formen auf Folien in Präsentationen formatieren. Lesen Sie die Details:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Text Formatting|<p>In Aspose.Slides für Python via .NET können Sie Texte über die Textrahmen verwalten, die den Formen zugeordnet sind. Somit können Sie Texte über die Absätze und Teile formatieren, die den Textrahmen zugeordnet sind. Diese Textelemente können über Aspose.Slides für Python via .NET formatiert werden.</p><p>- Schriftart</p><p>- Schriftgröße</p><p>- Schriftfarbe</p><p>- Schattierungen der Schrift</p><p>- Absatzausrichtung</p><p>- Aufzählungszeichen im Absatz</p><p>- Absatzorientierung</p>|
|Shape Formatting|<p>In Aspose.Slides für Python via .NET ist das grundlegende Element einer Folie eine Form. Sie können diese Formelemente mit Aspose.Slides für Python via .NET formatieren:</p><p>- Position</p><p>- Größe</p><p>- Linie</p><p>- Füllung (inkl. Muster, Verlauf, einfarbig)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

**Muss ich Microsoft PowerPoint auf dem Server/PC installieren, damit die Bibliothek funktioniert?**

Nein. PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum Erstellen, Bearbeiten, Konvertieren und Rendern von Präsentationen.

**Wie funktioniert Multithreading? Kann die Verarbeitung parallelisiert werden?**

Es ist sicher, verschiedene Dokumente in unterschiedlichen Threads zu verarbeiten; das gleiche [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt darf nicht gleichzeitig von [multiple threads](/slides/de/python-net/multithreading/) verwendet werden.

**Werden Dateipasswörter und Verschlüsselung unterstützt?**

Ja. [Sie können](/slides/de/python-net/password-protected-presentation/) verschlüsselte Präsentationen öffnen, ein Öffnungs‑ bzw. Schreibpasswort festlegen oder entfernen und den Schutzstatus prüfen.

**Muss ich mich um Schriftpakete in Linux‑Containern kümmern?**

Ja. Es wird empfohlen, gängige Schriftpakete zu installieren und/oder explizit [Schriftordner anzugeben](/slides/de/python-net/custom-font/) in Ihrer Anwendung, um unerwartete Ersetzungen zu vermeiden.

**Gibt es Einschränkungen in der Evaluierungsversion?**

Im [Evaluierungsmodus](/slides/de/python-net/licensing/) wird dem Ergebnis ein Wasserzeichen hinzugefügt und es gelten bestimmte Einschränkungen; ein [30‑tägiges temporäres Lizenz]https://purchase.aspose.com/temporary-license/ ist für vollumfängliche Tests verfügbar.

**Wird das Importieren externer Formate in eine Präsentation (PDF/HTML → PPTX) unterstützt?**

Ja. Sie können [PDF‑Seiten und HTML‑Inhalte](/slides/de/python-net/import-presentation/) zu einer Präsentation hinzufügen und sie in Folien umwandeln.