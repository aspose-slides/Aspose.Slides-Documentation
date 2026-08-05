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
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Standardschriften festzulegen, die beim Rendern einer Präsentation verwendet werden. Dies ist nützlich beim Erzeugen von Folien‑Thumbnails oder beim Exportieren einer Präsentation in Formate wie PDF und XPS. Standardschriften werden über `LoadOptions` konfiguriert, bevor die Präsentation geladen wird.

Die Methode `set_DefaultRegularFont` definiert die Standardschrift für normalen Text, während `set_DefaultAsianFont` die Standardschrift für asiatischen Text festlegt. Nachdem diese Optionen gesetzt wurden, kann die Präsentation geladen und mit den angegebenen Schriften gerendert werden.

## **Verwenden Sie Standardschriften beim Rendern einer Präsentation**
Aspose.Slides ermöglicht es Ihnen, die Standardschrift für das Rendern der Präsentation zu PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont als Standardschriften definiert. Bitte folgen Sie den unten stehenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe der Aspose.Slides‑API für C++ zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
1. Setzen Sie das DefaultRegularFont auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Setzen Sie das DefaultAsianFont auf die gewünschte Schriftart. Ich habe Wingdings im folgenden Beispiel verwendet.
1. Laden Sie die Präsentation mit Presentation und setzen Sie dabei die Ladeoptionen.
1. Generieren Sie nun das Folien‑Thumbnail, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des oben Gesagten ist unten angegeben.

```cpp
// Verwenden Sie die Ladeoptionen, um die standardmäßigen regulären und asiatischen Schriften festzulegen
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

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont—nur den Export oder auch Thumbnails, PDF, XPS, HTML und SVG?**

Sie nehmen an der Rendering‑Pipeline für alle unterstützten Ausgaben teil. Dazu gehören Folien‑Thumbnails, [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/cpp/convert-powerpoint-to-png/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), und [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriften angewendet, wenn lediglich ein PPTX gelesen und gespeichert wird, ohne irgendeine Renderung?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftläufe noch die Dateistruktur. Standardschriften kommen bei Vorgängen zum Tragen, die Text rendern oder neu layouten.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden diese bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Custom font sources](/slides/de/cpp/custom-font/) erweitern den Katalog der verfügbaren Familien und Glyphen, die die Engine verwenden kann. Standardschriften und alle [fallback rules](/slides/de/cpp/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was zu einer zuverlässigeren Abdeckung auf Servern und in Containern führt.

**Beeinflussen Standardschriften die Textmetriken (Kerning, Voranschritte) und damit Zeilenumbrüche und Textumbruch?**

Ja. Das Ändern der Schriftart ändert die Glyphenmetriken und kann Zeilenumbrüche, Textumbruch und Paginierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie [embed the original fonts](/slides/de/cpp/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien wählen.

**Gibt es einen Sinn, Standardschriften festzulegen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist das nicht nötig, da [embedded fonts](/slides/de/cpp/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften sind dennoch als Sicherheitsnetz nützlich für Zeichen, die nicht im eingebetteten Teil enthalten sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text mischt.