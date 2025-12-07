---
title: PowerPoint-Präsentationen in animierte GIFs in C++ konvertieren
linktitle: PowerPoint zu GIF
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
- Standardeinstellungen
- benutzerdefinierte Einstellungen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Einfach PowerPoint-Präsentationen (PPT, PPTX) mit Aspose.Slides für C++ in animierte GIFs konvertieren. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C++ zeigt, wie man eine Präsentation mit Standard‑Einstellungen in ein animiertes GIF konvertiert:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Das animierte GIF wird mit den Standard‑Parametern erstellt. 

{{% alert title="TIPP" color="primary" %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options)‑Klasse verwenden. Siehe den Beispielcode unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie man eine Präsentation mit benutzerdefinierten Einstellungen in C++ in ein animiertes GIF konvertiert:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// die Größe des resultierenden GIFs 
gifOptions->set_FrameSize(Size(960, 720));
// wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
gifOptions->set_DefaultDelay(2000);
// FPS erhöhen für bessere Qualität der Übergangsanimation
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den KOSTENLOSEN [Text‑zu‑GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriften nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriften oder [konfigurieren Sie Ersatzschriften](/slides/de/cpp/powerpoint-fonts/). Aspose.Slides wird ersetzen, aber das Aussehen kann abweichen. Für Branding sollten die erforderlichen Schriftarten immer explizit verfügbar sein.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/cpp/watermark/) zum Master‑Folie oder zu einzelnen Folien vor dem Export hinzu – das Wasserzeichen wird in jedem Frame angezeigt.