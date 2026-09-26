---
title: Aspose.Slides für .NET
second_title: Aspose.Slides für .NET
type: docs
weight: 10
url: /de/net/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für .NET, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API-Referenz und den Support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET ist eine Klassenbibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument‑Präsentationen in .NET‑Anwendungen, ohne Microsoft PowerPoint oder Office‑Automatisierung.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagenvarianten, und exportiert in PDF, XPS, HTML, SVG, TIFF, Markdown und Bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>Erste Schritte</p>
<ul>
<li><a href="/slides/de/net/installation/">Installation</a></li>
<li><a href="/slides/de/net/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/net/getting-started/">Einführungsleitfaden</a></li>
</ul>
<p>Bewerten</p>
<ul>
<li><a href="/slides/de/net/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/net/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/net/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>Allgemeine Aufgaben</p>
<ul>
<li><a href="/slides/de/net/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/net/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/net/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/net/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/net/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>Slides-Arbeitsabläufe</p>
<ul>
<li><a href="/slides/de/net/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/net/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/net/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/net/presentation-design/">Foliengestaltung</a></li>
<li><a href="/slides/de/net/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>Beispiele</p>
<ul>
<li><a href="/slides/de/net/examples/">Beispiele nach Folienelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Beispiele auf GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API‑Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/net/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Herunterladen</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Erstellen Sie eine Konsolenanwendung mit dem .NET SDK 6 oder höher:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Fügen Sie dann ein Paket für Ihre Plattform hinzu:

- Unter Windows: `dotnet add package Aspose.Slides.NET`
- Unter Linux und macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — siehe [Installation](/slides/de/net/installation/) für die Linux‑Voraussetzungen und für Systeme, die stattdessen Aspose.Slides.NET benötigen.

Ersetzen Sie den Inhalt von *Program.cs* durch diesen Code und führen Sie `dotnet run` aus:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Das Programm speichert *hello.pptx* mit einer Folie, die ein Textfeld enthält. Ohne Lizenz enthält die gespeicherte Datei ein Evaluierungswasserzeichen — siehe [Lizenzierung](/slides/de/net/licensing/). Weitere Möglichkeiten zum Erstellen und Befüllen einer Präsentation finden Sie unter [Präsentationen erstellen](/slides/de/net/create-presentation/).