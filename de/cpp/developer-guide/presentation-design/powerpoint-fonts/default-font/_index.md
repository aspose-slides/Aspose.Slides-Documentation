---
title: Standard-Schriftarten für Präsentationen in C++
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/cpp/default-font/
keywords:
- Standard-Schriftart
- Reguläre Schriftart
- Normale Schriftart
- Asiatische Schriftart
- PDF-Export
- XPS-Export
- Bild-Export
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Standard-Schriftarten in Aspose.Slides für C++ festlegen, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern zu gewährleisten."
---

## **Standard‑Schriftart festlegen**
Mit Aspose.Slides für C++ können Sie die Standardschriftart in PowerPoint‑Präsentationen festlegen. Eine neue Methode [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) wurde zur Klasse [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) hinzugefügt. Sie ermöglicht es, die Standardschriftart festzulegen, die anstelle aller fehlenden Schriftarten verwendet wird, wenn Präsentationen in verschiedene Formate gespeichert werden, ohne die Präsentationen neu zu laden.

Das nachstehende Code‑Snippet demonstriert das Speichern einer Präsentation als [HTML](https://docs.fileformat.com/web/html/) und [PDF](https://docs.fileformat.com/pdf/) mit unterschiedlichen Standardschriftarten.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **Standard‑Schriftarten für die Darstellung einer Präsentation verwenden**
Aspose.Slides ermöglicht es, die Standardschriftart für die Darstellung der Präsentation als PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie DefaultRegularFont und DefaultAsianFont als Standardschriftarten definiert werden. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe der Aspose.Slides‑C++‑API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.  
1. Setzen Sie die DefaultRegularFont auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.  
1. Setzen Sie die DefaultAsianFont auf die gewünschte Schriftart. Ich habe in dem folgenden Beispiel Wingdings verwendet.  
1. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.  
1. Erzeugen Sie nun das Folien‑Thumbnail, PDF und XPS, um die Ergebnisse zu prüfen.

Die Implementierung des Obigen ist unten angegeben.
```cpp
// Verwenden Sie die Ladeoptionen, um die Standard‑Schriftarten für reguläre und asiatische Schriften festzulegen
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```


## **FAQ**

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Thumbnails, PDF, XPS, HTML und SVG?**

Sie wirken sich auf die gesamte Rendering‑Pipeline für alle unterstützten Ausgaben aus. Dazu gehören Folien‑Thumbnails, [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [Raster‑Bilder](/slides/de/cpp/convert-powerpoint-to-png/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/) und [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/), weil Aspose.Slides dieselbe Layout‑ und Glyphen‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriftarten angewendet, wenn man eine PPTX nur liest und speichert, ohne zu rendern?**

Nein. Standardschriftarten kommen nur zum Tragen, wenn Text gemessen und gezeichnet werden muss. Ein reines Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlaufdaten noch die Dateistruktur. Standardschriftarten werden bei Vorgängen aktiv, die Rendern oder Text‑Umfluss erfordern.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriftarten berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/cpp/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriftarten und alle [Fallback‑Regeln](/slides/de/cpp/fallback-font/) prüfen zuerst diese Quellen, was auf Servern und in Containern zu einer zuverlässigeren Abdeckung führt.

**Beeinflussen Standardschriftarten Textmetriken (Kerning, Advances) und damit Zeilenumbrüche und Zeilenumbruch?**

Ja. Durch das Ändern der Schriftart ändern sich Glyphen‑Metriken, was Zeilenumbrüche, Zeilenfluss und Paginierung beim Rendern beeinflussen kann. Für Layout‑Stabilität sollten Sie entweder die Originalschriften [einbetten](/slides/de/cpp/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Macht das Festlegen von Standardschriftarten überhaupt Sinn, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist es nicht nötig, da [eingebettete Schriften](/slides/de/cpp/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriftarten dienen dennoch als Sicherheitsnetz für Zeichen, die nicht im eingebetteten Subset enthalten sind, oder wenn eine Datei sowohl eingebettete als auch nicht eingebettete Texte kombiniert.