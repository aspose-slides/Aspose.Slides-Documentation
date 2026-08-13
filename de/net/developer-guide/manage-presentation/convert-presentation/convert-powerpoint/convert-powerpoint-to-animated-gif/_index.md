---
title: PowerPoint-Präsentationen in .NET in animierte GIFs konvertieren
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen (PPT, PPTX) mühelos in animierte GIFs mit Aspose.Slides für .NET. Schnell, hochwertige Ergebnisse."
---
## **Übersicht**

Aspose.Slides ermöglicht das Konvertieren von PowerPoint‑Präsentationen in animierte GIF‑Dateien mit nur wenigen Codezeilen. Das ist nützlich, wenn Sie Folieninhalte in einem leichten, breit unterstützten animierten Format teilen möchten, das in Webseiten, Messenger‑Apps oder Dokumentationen eingebettet werden kann. Dieser Artikel erklärt, wie Sie eine Präsentation mit den Standardeinstellungen in GIF exportieren und wie Sie die Ausgabe anpassen können, indem Sie Optionen wie Bildgröße, Folienverzögerung und Übergangs‑Frame‑Rate über [GifOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/gifoptions/) konfigurieren.

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C# zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Das animierte GIF wird mit den Standard‑Parametern erstellt. 

{{%  alert  title="TIP"  color="info"  %}} 
Wenn Sie die Parameter für das GIF lieber anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/gifoptions) verwenden. Siehe den Beispielcode unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in C# in ein animiertes GIF konvertieren:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIFs
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
        TransitionFps = 35 // FPS erhöhen für bessere Übergangsanimation-Qualität
    });
}
```

{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/de/text-to-gif) Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

### Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/net/powerpoint-fonts/). Aspose.Slides wird ersetzen, jedoch kann das Aussehen abweichen. Für das Branding stellen Sie stets sicher, dass die erforderlichen Schriftarten ausdrücklich verfügbar sind.

### Kann ich ein Wasserzeichen über die GIF‑Frames legen?

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/net/watermark/) zur Master‑Folie oder zu einzelnen Folien vor dem Export hinzu – das Wasserzeichen erscheint auf jedem Frame.