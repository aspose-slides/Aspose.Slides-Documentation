---
title: PowerPoint in animiertes GIF umwandeln
type: docs
weight: 65
url: /de/cpp/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint in animiertes GIF umwandeln, "
description: "PowerPoint in animiertes GIF umwandeln: PPT in GIF, PPTX in GIF, mit der Aspose.Slides API."
---

## Präsentationen in animiertes GIF umwandeln mit Standardeinstellungen ##

Dieser Beispielcode in C++ zeigt Ihnen, wie Sie eine Präsentation mit den Standardinstellungen in ein animiertes GIF umwandeln:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Das animierte GIF wird mit den Standardparametern erstellt.

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) Klasse verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## Präsentationen in animiertes GIF umwandeln mit benutzerdefinierten Einstellungen ##
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in ein animiertes GIF umwandeln:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// die Größe des resultierenden GIF
gifOptions->set_FrameSize(Size(960, 720));
// wie lange jede Folie angezeigt wird, bevor sie zur nächsten gewechselt wird
gifOptions->set_DefaultDelay(2000);
// FPS erhöhen für eine bessere Übergangsanimationsqualität
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Sie möchten vielleicht einen KOSTENLOSEN [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter ausprobieren, der von Aspose entwickelt wurde.

{{% /alert %}}