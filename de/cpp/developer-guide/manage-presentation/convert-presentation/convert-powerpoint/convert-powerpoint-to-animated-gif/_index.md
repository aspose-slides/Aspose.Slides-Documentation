---
title: "PowerPoint-Präsentationen in animierte GIFs konvertieren in C++"
linktitle: "PowerPoint zu GIF"
type: docs
weight: 65
url: /de/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu GIF
- Präsentation zu GIF
- Folie zu GIF
- PPT zu GIF
- PPTX zu GIF
- PPT als GIF speichern
- PPTX als GIF speichern
- PPT als GIF exportieren
- PPTX als GIF exportieren
- Standardoptionen
- Benutzerdefinierte Optionen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen (PPT, PPTX) einfach mit Aspose.Slides für C++ in animierte GIFs konvertieren. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C++ zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C++ in ein animiertes GIF konvertieren:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// die Größe des resultierenden GIFs
gifOptions->set_FrameSize(Size(960, 720));
// wie lange jede Folie angezeigt wird, bis zur nächsten gewechselt wird
gifOptions->set_DefaultDelay(2000);
// FPS erhöhen für bessere Übergangsanimationen
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif)-Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die im Vortrag verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/cpp/powerpoint-fonts/). Aspose.Slides wird sie ersetzen, aber das Aussehen kann abweichen. Für Branding sollten Sie stets sicherstellen, dass die benötigten Schriftarten explizit verfügbar sind.

**Kann ich ein Wasserzeichen über die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/cpp/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu – das Wasserzeichen erscheint in jedem Frame.