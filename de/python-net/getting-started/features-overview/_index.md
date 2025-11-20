---
title: Überblick über die Funktionen
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
description: "Entdecken Sie Aspose.Slides für Python via .NET: eine leistungsstarke API zum Erstellen, Bearbeiten, Automatisieren und effizienten Konvertieren von PowerPoint- und OpenDocument-Präsentationen."
---

## **Unterstützte Plattformen**
Die Plattformen, auf denen Aspose.Slides für Python via .NET verwendet werden kann, sind Windows x64 oder x86 sowie eine breite Palette von Linux‑Distributionen mit installiertem Python 3.5 oder höher. Für die Ziel‑Linux‑Plattform gelten zusätzliche Anforderungen:
- GCC‑6 Runtime‑Bibliotheken (oder neuer)
- Abhängigkeiten des .NET Core Runtime. Die Installation des .NET Core Runtime selbst ist **nicht** erforderlich
- Für Python 3.5‑3.7: Der `pymalloc`‑Build von Python wird benötigt. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc`‑Build von Python mit dem Suffix `m` im Dateinamen gekennzeichnet.
- `libpython`‑gemeinsame Python‑Bibliothek. Die Build‑Option `--enable-shared` ist standardmäßig deaktiviert, manche Python‑Distributionen enthalten die `libpython`‑Bibliothek nicht. Für einige Linux‑Plattformen kann die `libpython`‑Bibliothek über den Paketmanager installiert werden, z. B.: `sudo apt-get install libpython3.7`. Ein häufiges Problem ist, dass die `libpython`‑Bibliothek an einem anderen Ort als dem Standard‑Systempfad für Shared‑Libraries installiert wird. Das Problem kann behoben werden, indem beim Python‑Build alternative Bibliothekspfade angegeben werden oder indem ein symbolischer Link zur `libpython`‑Datei im Standard‑Systempfad erstellt wird. Typischerweise lautet der Dateiname der `libpython`‑Shared‑Library `libpythonX.Ym.so.1.0` für Python 3.5‑3.7 bzw. `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B.: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Falls Sie Unterstützung für weitere Plattformen benötigen, schauen Sie sich die „Zwillingsbruder“-Produkte Aspose.Slides für .NET oder Aspose.Slides für Java an.

## **Dateiformate und Konvertierungen**
Aspose.Slides für Python via .NET unterstützt die meisten PowerPoint‑Dokumentformate. Außerdem können Sie diese in die populären Formate exportieren, die von Organisationen häufig verwendet und ausgetauscht werden. Details finden Sie unten:

|**Funktion**|**Beschreibung**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/de/python-net/ppt-vs-pptx/)|Aspose.Slides für Python via .NET bietet die schnellste Verarbeitung für dieses Präsentationsdokumentformat.|
|[PPT zu PPTX Konvertierung](/slides/de/python-net/convert-ppt-to-pptx/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PPT zu PPTX.|
|[Portable Document Format (PDF)](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in Adobe Portable Document Format (PDF) exportieren.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Sie können alle unterstützten Dateiformate mit einer einzigen Methode in XML Parser Specification (XPS) Dokumente exportieren.|
|[Tagged Image File Format (TIFF)](/slides/de/python-net/convert-powerpoint-to-tiff/)|Sie können alle unterstützten Präsentationsdateiformate in Tagged Image File Format (TIFF) exportieren.|
|[PPTX zu HTML Konvertierung](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides für Python via .NET unterstützt die Konvertierung von PresentationEx in das HTML‑Format.|

## **Rendering und Drucken**
Aspose.Slides für Python via .NET unterstützt das hochqualitative Rendering von Folien in Präsentationsdokumenten in verschiedene Grafikformate. Details finden Sie unten:

|**Funktion**|**Beschreibung**|
| :- | :- |
|.NET unterstützte Bildformate|Mit Aspose.Slides für Python via .NET können Sie Präsentationsfolien und Bilder auf Folien in allen von .NET unterstützten Grafikformaten wie TIFF, PNG, BMP, JPEG, GIF und Metadateien rendern.|
|SVG‑Format|Aspose.Slides für Python via .NET bietet außerdem integrierte Methoden, mit denen Sie Präsentationsfolien in Scalable Vector Graphics (SVG) Formate exportieren können.|
|Präsentationsdruck|Die neuesten Versionen von Aspose.Slides für Python via .NET bieten integrierte Druckmethoden mit verschiedenen Optionen.|

## **Inhalts‑Funktionen**
Aspose.Slides für Python via .NET ermöglicht den Zugriff, die Änderung oder das Erstellen fast aller Elemente oder Inhalte von Präsentationsdokumenten. Details finden Sie unten:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Master‑Folien|Die Master‑Folien definieren das Layout der normalen Folien. Aspose.Slides für Python via .NET ermöglicht den Zugriff und die Änderung der Master‑Folien von Präsentationsdokumenten.|
|Normale Folien|Mit Aspose.Slides für Python via .NET können Sie neue Folien verschiedener Typen erstellen; Sie können zudem vorhandene Folien in den Präsentationen abrufen und ändern.|
|Klonen / Kopieren von Folien|Es gibt integrierte Methoden von Aspose.Slides für Python via .NET, mit denen Sie vorhandene Folien innerhalb einer Präsentation klonen oder kopieren können. Sie können geklonte und kopierte Folien von einer Präsentation zur anderen verwenden. Da eine Folie ihr Layout vom Master‑Slide erbt, kopieren die integrierten Klon‑Methoden den Master automatisch beim Klonen.|
|Verwalten von Folien‑Abschnitten|Methoden zur Organisation von Folien in verschiedenen Abschnitten innerhalb einer Präsentation.|
|Platzhalter und Text‑Platzhalter|Sie können die Platzhalter und Text‑Platzhalter in einer Folie abrufen. Außerdem können Sie mit der entsprechenden Methode eine Folie mit Text‑Platzhaltern von Grund auf neu erstellen.|
|Kopf‑ und Fußzeilen|Aspose.Slides für Python via .NET erleichtert die Handhabung von Kopf‑/Fußzeilen in Folien.|
|Notizen in Folien|Mit Aspose.Slides für Python via .NET können Sie Notizen, die einer Folie zugeordnet sind, abrufen und ändern sowie neue Notizen hinzufügen.|
|Form finden|Sie können mithilfe des alternativen Textes, der einer Form zugeordnet ist, eine bestimmte Form in einer Folie finden.|
|Hintergründe|Aspose.Slides für Python via .NET ermöglicht die Arbeit mit Hintergründen, die einem Master‑ oder Normal‑Slide zugeordnet sind.|
|Textfelder|Textfelder können von Grund auf neu erstellt werden. Sie können vorhandene Textfelder abrufen und deren Texte ändern, ohne das ursprüngliche Textformat zu verlieren.|
|Rechteckformen|Sie können Rechteckformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Polylinienformen|Sie können Polylinienformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Ellipsenformen|Sie können Ellipsenformen mit Aspose.Slides für Python via .NET erstellen oder ändern.|
|Gruppenformen|Aspose.Slides für Python via .NET unterstützt Gruppenformen.|
|Autoformen|Aspose.Slides für Python via .NET unterstützt Autoformen.|
|SmartArt|Aspose.Slides für Python via .NET bietet Unterstützung für SmartArt‑Formen in MS PowerPoint.|
|Diagramme|Aspose.Slides für Python via .NET bietet Unterstützung für MSO‑Diagramme in PowerPoint.|
|Form‑Serialisierung|Aspose.Slides für Python via .NET unterstützt eine große Anzahl von Formen. Wenn Aspose.Slides für Python via .NET keine Unterstützung für eine Form bietet, können Sie eine Serialisierungsmethode verwenden, um diese Form aus einer bestehenden Folie zu serialisieren und anschließend weiter zu nutzen.|
|Bilderrahmen|Sie können Bilder in Bildrahmen mit Aspose.Slides für Python via .NET verwalten.|
|Audio‑Rahmen|Sie können Audio‑Dateien in Audio‑Rahmen auf Folien mit Aspose.Slides für Python via .NET verlinken oder einbetten.|
|Video‑Rahmen|Sie können Video‑Dateien in Video‑Rahmen verarbeiten. Aspose.Slides für Python via .NET bietet zudem Unterstützung für verlinkte und eingebettete Videos.|
|OLE‑Rahmen|Sie können OLE‑Objekte in OLE‑Rahmen mit Aspose.Slides für Python via .NET verwalten.|
|Tabellen|Aspose.Slides für Python via .NET unterstützt Tabellen in Folien.|
|ActiveX‑Steuerelemente|Unterstützung für ActiveX‑Steuerelemente.|
|VBA‑Makros|Unterstützung für die Verwaltung von VBA‑Makros innerhalb von Präsentationen.|
|Text‑Rahmen|Sie können über den Text‑Rahmen, der einer Form zugeordnet ist, auf den Text jeder Form zugreifen.|
|Text‑Scannen|Sie können mittels integrierter Scan‑Methoden Text in einer Präsentation auf Präsentations‑ oder Folienebene durchsuchen.|
|Animationen|Sie können Animationen auf Formen anwenden.|
|Bildschirmpräsentationen|Aspose.Slides für Python via .NET unterstützt Bildschirmpräsentationen und Folienübergänge.|

## **Formatierungs‑Funktionen**
Mit Aspose.Slides für Python via .NET können Sie Texte und Formen auf Folien in Präsentationen formatieren. Details finden Sie unten:

|**Funktion**|**Beschreibung**|
| :- | :- |
|Textformatierung|<p>In Aspose.Slides für Python via .NET können Sie Texte über die Text‑Frames verwalten, die den Formen zugeordnet sind. Damit können Sie Texte mithilfe der Absätze und Portionen des Text‑Frames formatieren. Diese Textelemente können über Aspose.Slides für Python via .NET formatiert werden.</p><p>- Schriftart</p><p>- Schriftgröße</p><p>- Schriftfarbe</p><p>- Schattierungen</p><p>- Absatzausrichtung</p><p>- Aufzählungszeichen</p><p>- Absatzorientierung</p>|
|Formformatierung|<p>In Aspose.Slides für Python via .NET ist das Grundelement einer Folie eine Form. Sie können diese Formelemente mit Aspose.Slides für Python via .NET formatieren:</p><p>- Position</p><p>- Größe</p><p>- Linie</p><p>- Füllung (inkl. Muster, Verlauf, einfarbig)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

**Muss ich Microsoft PowerPoint auf dem Server/PC installieren, damit die Bibliothek funktioniert?**

Nein. PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum Erstellen, Bearbeiten, Konvertieren und Rendern von Präsentationen.

**Wie funktioniert Multithreading? Kann die Verarbeitung parallelisiert werden?**

Es ist sicher, verschiedene Dokumente in unterschiedlichen Threads zu verarbeiten; das gleiche [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt darf nicht von [multiple threads](/slides/de/python-net/multithreading/) gleichzeitig verwendet werden.

**Werden Dateipasswörter und Verschlüsselung unterstützt?**

Ja. [You can](/slides/de/python-net/password-protected-presentation/) verschlüsselte Präsentationen öffnen, ein Öffnungs‑ und Schreib‑Passwort setzen oder entfernen und den Schutzstatus prüfen.

**Muss ich mich um Schriftpakete in Linux‑Containern kümmern?**

Ja. Es wird empfohlen, gängige Schriftpakete zu installieren und/oder in Ihrer Anwendung explizit [specify font directories](/slides/de/python-net/custom-font/) anzugeben, um unerwartete Ersetzungen zu vermeiden.

**Gibt es Einschränkungen in der Evaluierungs‑Version?**

Im [evaluation mode](/slides/de/python-net/licensing/) wird ein Wasserzeichen zum Output hinzugefügt und bestimmte Einschränkungen gelten; eine [30‑day temporary license](https://purchase.aspose.com/temporary-license/) steht für vollständige Tests zur Verfügung.

**Wird das Importieren externer Formate in eine Präsentation (PDF/HTML → PPTX) unterstützt?**

Ja. Sie können [PDF pages and HTML content](/slides/de/python-net/import-presentation/) zu einer Präsentation hinzufügen und in Folien umwandeln.