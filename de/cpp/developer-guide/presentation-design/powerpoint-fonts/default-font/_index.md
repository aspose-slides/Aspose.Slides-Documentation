---
title: Standard Schriftart
type: docs
weight: 30
url: /de/cpp/default-font/
keywords: 
- schriftart
- standard schriftart
- präsentation rendern
- PowerPoint
- präsentation
- C++
- Aspose.Slides für C++
description: Die PowerPoint C++ API ermöglicht es Ihnen, die Standard Schriftart für das Rendern von Präsentationen in PDF, XPS oder Miniaturansichten festzulegen.
---

## **Standard Schriftart festlegen**
Mit Aspose.Slides für C++ können Sie die Standard Schriftart in PowerPoint-Präsentationen festlegen. Eine neue Methode [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) wurde zur Klasse [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) hinzugefügt. Sie ermöglicht es, die Standard Schriftart festzulegen, die anstelle aller fehlenden Schriftarten beim Speichern von Präsentationen in verschiedene Formate verwendet wird, ohne die Präsentationen neu zu laden.

Der folgende Codeausschnitt zeigt das Speichern einer Präsentation in [HTML](https://docs.fileformat.com/web/html/) und [PDF](https://docs.fileformat.com/pdf/) mit verschiedenen Standard Schriftarten.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **Standard Schriftarten für das Rendern von Präsentationen verwenden**
Aspose.Slides ermöglicht es Ihnen, die Standard Schriftart für das Rendern der Präsentation in PDF, XPS oder Miniaturansichten festzulegen. In diesem Artikel wird gezeigt, wie man DefaultRegular Font und DefaultAsian Font als Standard Schriftarten definiert. Bitte folgen Sie den folgenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe der Aspose.Slides für C++ API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
2. Setzen Sie die DefaultRegularFont auf Ihre gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
3. Setzen Sie die DefaultAsianFont auf Ihre gewünschte Schriftart. Ich habe in folgendem Beispiel Wingdings verwendet.
4. Laden Sie die Präsentation mit Presentation und setzen Sie die Ladeoptionen.
5. Jetzt generieren Sie die Folienminiaturansicht, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen ist nachfolgend angegeben.

```cpp
// Verwenden Sie die Ladeoptionen, um Standard Schriftarten für reguläre und asiatische Schriftarten anzugeben
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