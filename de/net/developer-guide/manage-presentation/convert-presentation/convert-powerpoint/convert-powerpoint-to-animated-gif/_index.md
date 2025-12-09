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
- Standard-Einstellungen
- Benutzerdefinierte Einstellungen
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen (PPT, PPTX) einfach mit Aspose.Slides für .NET in animierte GIFs konvertieren. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen in animiertes GIF mit Standardeinstellungen konvertieren**

Dieses Beispiel in C# zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


Das animierte GIF wird mit den Standard‑Parametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## **Präsentationen in animiertes GIF mit benutzerdefinierten Einstellungen konvertieren**

Dieses Beispiel zeigt, wie Sie eine Präsentation in C# mit benutzerdefinierten Einstellungen in ein animiertes GIF konvertieren:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIFs  
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
        TransitionFps = 35 // FPS erhöhen für bessere Übergangsanimation
    });
}
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatz‑Schriftarten](/slides/de/net/powerpoint-fonts/). Aspose.Slides ersetzt sie, aber das Aussehen kann abweichen. Für Branding stellen Sie stets sicher, dass die benötigten Schriftarten ausdrücklich verfügbar sind.

**Kann ich ein Wasserzeichen auf den GIF‑Frames überlagern?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/net/watermark/) zur Master‑Folie oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint in jedem Frame.