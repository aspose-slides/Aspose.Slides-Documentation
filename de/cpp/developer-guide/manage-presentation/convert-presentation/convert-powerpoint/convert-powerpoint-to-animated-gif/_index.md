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
description: "Einfach PowerPoint-Präsentationen (PPT, PPTX) mit Aspose.Slides für C++ in animierte GIFs konvertieren. Schnell, qualitativ hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C++ zeigt, wie man eine Präsentation mit den Standardeinstellungen in ein animiertes GIF konvertiert:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Das animierte GIF wird mit den Standardparametern erstellt.

{{%  alert  title="TIP"  color="primary"  %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) verwenden. Siehe den Beispielcode unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie man in C++ eine Präsentation mit benutzerdefinierten Einstellungen in ein animiertes GIF konvertiert:
```cpp
auto gifOptions = System::MakeObject<GifOptions>();
// die Größe des erzeugten GIFs
gifOptions->set_FrameSize(Size(960, 720));
// wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
gifOptions->set_DefaultDelay(2000);
// FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie sich den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif)-Konverter von Aspose ansehen. 
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/cpp/powerpoint-fonts/). Aspose.Slides wird ersetzen, aber das Aussehen kann abweichen. Für das Branding sollten die benötigten Schriftarten immer ausdrücklich verfügbar sein.

**Kann ich ein Wasserzeichen über den GIF‑Frames einblenden?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/cpp/watermark/) zur Masterfolie oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint in jedem Frame.