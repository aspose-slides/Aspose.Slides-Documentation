---
title: PowerPoint‑Präsentationen in animierte GIFs in C++ konvertieren
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
description: "Konvertieren Sie PowerPoint-Präsentationen (PPT, PPTX) mühelos in animierte GIFs mit Aspose.Slides für C++. Schnell, hochwertige Ergebnisse."
---
## **Übersicht**

Aspose.Slides ermöglicht das Konvertieren von PowerPoint-Präsentationen in animierte GIF-Dateien mit nur wenigen Codezeilen. Das ist nützlich, wenn Sie Folieninhalte in einem leichten, weit verbreiteten animierten Format teilen müssen, das in Webseiten, Messenger‑Apps oder Dokumentationen eingebettet werden kann. Dieser Artikel erklärt, wie man eine Präsentation mit den Standardeinstellungen in GIF exportiert und wie man die Ausgabe anpasst, indem man Optionen wie Bildgröße, Folienverzögerung und Übergangs‑Bildrate über [GifOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/gifoptions/) konfiguriert.

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C++ zeigt, wie man eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertiert:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Das animierte GIF wird mit den Standardparametern erstellt.

{{%  alert  title="TIP"  color="info"  %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.export.gif_options) verwenden. Siehe den Beispielcode unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie man eine Präsentation in C++ mit benutzerdefinierten Einstellungen in ein animiertes GIF konvertiert:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// die Größe des resultierenden GIFs
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
gifOptions->set_DefaultDelay(2000);
// FPS erhöhen für bessere Übergangsanimationsqualität
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/de/text-to-gif)-Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

### Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?

Installieren Sie die fehlenden Schriftarten oder [Fallback-Schriftarten konfigurieren](/slides/de/cpp/powerpoint-fonts/). Aspose.Slides wird Ersatz bereitstellen, aber das Aussehen kann abweichen. Für Markenauftritte sollten die erforderlichen Schriften immer explizit verfügbar sein.

### Kann ich ein Wasserzeichen auf die GIF‑Frames legen?

Ja. [Ein halbtransparentes Objekt/Logo hinzufügen](/slides/de/cpp/watermark/) zum Master‑Slide oder zu einzelnen Folien vor dem Export hinzufügen — das Wasserzeichen wird auf jedem Frame angezeigt.