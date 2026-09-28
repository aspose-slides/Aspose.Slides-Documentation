---
title: Funktionsübersicht
type: docs
weight: 94
url: /de/net/features-overview/
keywords:
- Funktionen
- unterstützte Plattformen
- Dateiformate
- Konvertierung
- Rendering
- Präsentationsinhalt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblicken Sie, was Aspose.Slides für .NET abdeckt, bevor Sie es evaluieren: unterstützte Plattformen, Dateiformate, Folien-Rendering und die Inhalte, die Sie erstellen und bearbeiten können."
---
## **Übersicht**

Aspose.Slides für .NET ist eine Klassenbibliothek zum Erstellen, Lesen, Bearbeiten, Konvertieren und Rendern von PowerPoint- und OpenDocument-Präsentationen. Sie verfügt über keine eigene Benutzeroberfläche und erfordert weder Microsoft PowerPoint noch Office, sodass Sie sie in Konsolenanwendungen, Desktopanwendungen wie Windows Forms, Webanwendungen und Webdiensten verwenden können. Dieser Artikel fasst zusammen, was die Bibliothek abdeckt, und verweist auf die Artikel, die jeden Bereich beschreiben.

## **Unterstützte Plattformen**

Aspose.Slides for .NET wird als zwei NuGet‑Pakete mit derselben API bereitgestellt:

|**Paket**|**Builds im Paket**|**Betriebssysteme**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 und .NET 6. Verwenden Sie es mit .NET Framework 4.6.2 oder höher bzw. mit .NET 6 oder höher.|Windows. Linux und macOS mit der Bibliothek `libgdiplus` und dem Schalter `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Verwenden Sie es mit .NET 6 oder höher.|Windows (x86, x64), Linux (x64 mit glibc 2.23 oder höher, ARM64 mit glibc 2.39 oder höher) und macOS (x64, ARM64).|

[Installation](/slides/de/net/installation/) erklärt, welches Paket zu wählen ist und was jedes von ihnen unter Linux benötigt. [System Requirements](/slides/de/net/system-requirements/) listet die unterstützten Plattformen im Detail auf.

## **Dateiformate und Konvertierungen**

Aspose.Slides öffnet und speichert PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP und PowerPoint‑XML‑Präsentationen. Es importiert PDF‑ und HTML‑Inhalte in Folien und speichert Präsentationen als PDF, XPS, HTML, HTML5, TIFF, animiertes GIF, SWF, Markdown und XAML. [Supported File Formats](/slides/de/net/supported-file-formats/) listet jedes Format mit der API auf, die es liest oder schreibt.

|**Funktion**|**Beschreibung**|
| :- | :- |
|[PPT und PPTX](/slides/de/net/ppt-vs-pptx/)|Lesen und schreiben sowohl das binäre PowerPoint‑97‑2003‑Format als auch das Office‑Open‑XML‑Format.|
|[PPT‑zu‑PPTX‑Konvertierung](/slides/de/net/convert-ppt-to-pptx/)|Konvertieren Sie Legacy‑PPT‑Präsentationen zu PPTX.|
|[Portable Document Format (PDF)](/slides/de/net/convert-powerpoint-to-pdf/)|Exportieren von Präsentationen nach PDF, einschließlich PDF/A‑ und PDF/UA‑Dokumenten.|
|[XML Paper Specification (XPS)](/slides/de/net/convert-powerpoint-to-xps/)|Exportieren von Präsentationen zu XPS‑Dokumenten.|
|[Tagged Image File Format (TIFF)](/slides/de/net/convert-powerpoint-to-tiff/)|Exportieren von Präsentationen zu TIFF‑Bildern.|
|[HTML](/slides/de/net/convert-powerpoint-to-html/)|Exportieren von Präsentationen nach HTML und HTML5.|
|[PDF and HTML import](/slides/de/net/import-presentation/)|Erstellen von Folien aus PDF‑Seiten und HTML‑Inhalten.|

## **Präsentationsrendering**

Aspose.Slides rendert Folien und einzelne Formen als PNG-, JPEG-, BMP-, GIF-, TIFF- und SVG‑Bilder sowie Folien als EMF‑Metadateien. Siehe [Präsentationsfolien in Bilder konvertieren](/slides/de/net/convert-slide/), [Eine Folie als SVG‑Bild rendern](/slides/de/net/render-a-slide-as-an-svg-image/) und [Form‑Miniaturansichten erstellen](/slides/de/net/create-shape-thumbnails/).

## **Inhaltsfunktionen**

Aspose.Slides ermöglicht das Erstellen, Lesen und Ändern fast aller Inhalte einer Präsentation:

|**Bereich**|**Was Sie tun können**|
| :- | :- |
|[Folien](/slides/de/net/presentation-slide/)|Hinzufügen, Klonen, Neuordnen und Entfernen von Folien; Anwenden von Layouts und Master‑Folien; Organisieren von Folien in Abschnitten; Ändern der Foliengröße.|
|[Design](/slides/de/net/presentation-design/)|Hintergründe, Designfarben, Kopf‑ und Fußzeilen sowie Schriften festlegen.|
|[Text](/slides/de/net/manage-text/)|Textfelder, Absätze und Textabschnitte erstellen und bearbeiten; Schriftarten, Farben, Aufzählungen und Ausrichtung festlegen; Text suchen und ersetzen.|
|[Formen](/slides/de/net/powerpoint-shapes/)|AutoShapes, Linien, Verbinder, Gruppierungen und Bildrahmen erstellen; Position, Größe, Linie sowie einfarbige, Verlauf‑ oder Musterfüllungen festlegen; eine Form anhand ihres Alternativtextes finden.|
|[Tabellen](/slides/de/net/powerpoint-table/), [Diagramme](/slides/de/net/powerpoint-charts/), und [SmartArt](/slides/de/net/powerpoint-smartart/)|Tabellen, Microsoft‑Office‑Diagramme und SmartArt‑Diagramme erstellen und bearbeiten.|
|[Medien](/slides/de/net/manage-media-files/), [OLE‑Objekte](/slides/de/net/manage-ole/), und [ActiveX‑Steuerelemente](/slides/de/net/activex/)|Eingebettete oder verknüpfte Audio‑ und Video‑Frames hinzufügen, OLE‑Objekte einbetten sowie ActiveX‑Steuerelemente hinzufügen, ändern oder entfernen.|
|[Notizen](/slides/de/net/presentation-notes/) und [Kommentare](/slides/de/net/presentation-comments/)|Sprecher‑Notizen und Review‑Kommentare hinzufügen, lesen und bearbeiten.|
|[Animation](/slides/de/net/powerpoint-animation/) und [Übergänge](/slides/de/net/slide-transition/)|Animations‑Effekte auf Formen anwenden, Folien‑Übergänge festlegen und die Einstellungen der Bildschirmpräsentation konfigurieren.|
|[Sicherheit](/slides/de/net/presentation-security/)|Präsentationen mit einem Passwort verschlüsseln, Schreibschutz setzen und mit digitalen Signaturen arbeiten.|
|[VBA‑Makros](/slides/de/net/presentation-via-vba/)|VBA‑Module in makroaktivierten Präsentationen hinzufügen, extrahieren und entfernen.|
|[Eigenschaften](/slides/de/net/presentation-properties/)|Dokument‑Eigenschaften lesen und bearbeiten.|

## **FAQ**

**Muss ich Microsoft PowerPoint auf dem Server oder PC installieren, damit die Bibliothek funktioniert?**

Nein. PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum Erstellen, Bearbeiten, Konvertieren und Rendern von Präsentationen.

**Wie funktioniert Multithreading? Kann die Verarbeitung parallelisiert werden?**

Es ist sicher, verschiedene Dokumente in unterschiedlichen Threads zu verarbeiten; das gleiche [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Objekt darf nicht gleichzeitig von [mehreren Threads](/slides/de/net/multithreading/) verwendet werden.

**Werden Dateipasswörter und Verschlüsselung unterstützt?**

Ja. [Sie können](/slides/de/net/password-protected-presentation/) verschlüsselte Präsentationen öffnen, ein Öffnungs‑ und Schreibpasswort festlegen oder entfernen und den Schutzstatus prüfen.

**Muss ich mich um Schriften in Linux‑Containern kümmern?**

Ja. Die in Ihren Präsentationen verwendeten Schriften oder geeignete Ersatzschriften müssen auf dem System installiert sein, damit der Text korrekt dargestellt wird. Sie können außerdem [Schriftverzeichnisse angeben](/slides/de/net/custom-font/) in Ihrer Anwendung. [Installation](/slides/de/net/installation/) listet die Linux‑Voraussetzungen jedes Pakets auf.

**Gibt es Einschränkungen in der Evaluierungsversion?**

Ja. Ohne eine [Lizenz](/slides/de/net/licensing/) fügt Aspose.Slides jedem gespeicherten Folien ein Evaluierungs‑Wasserzeichen hinzu und kürzt den aus Präsentationen gelesenen Text. Eine [30‑tägige temporäre Lizenz](https://purchase.aspose.com/temporary-license/) steht für vollständige Tests zur Verfügung.

**Wird das Importieren externer Formate in eine Präsentation (PDF oder HTML nach PPTX) unterstützt?**

Ja. Sie können [PDF‑Seiten und HTML‑Inhalte](/slides/de/net/import-presentation/) zu einer Präsentation hinzufügen und sie in Folien umwandeln.