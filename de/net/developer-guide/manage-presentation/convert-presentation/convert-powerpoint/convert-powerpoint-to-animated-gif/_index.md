---
title: PowerPoint in animiertes GIF konvertieren
type: docs
weight: 65
url: /de/net/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint konvertieren, PPT, PPTX, animiertes GIF, PPT zu animiertem GIF, PPTX zu animiertem GIF C#, Csharp, .NET, Standardeinstellungen, benutzerdefinierte Einstellungen "
description: "PowerPoint-Präsentation in animiertes GIF konvertieren: PPT zu GIF, PPTX zu GIF in C# oder .NET"
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in C# zeigt, wie man eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertiert:
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

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie man eine Präsentation mit benutzerdefinierten Einstellungen in ein animiertes GIF in C# konvertiert:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // die Größe des resultierenden GIFs
        DefaultDelay = 2000, // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
        TransitionFps = 35 // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
    });
}
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/net/powerpoint-fonts/). Aspose.Slides wird ersetzen, aber das Aussehen kann abweichen. Für Branding sollten Sie stets sicherstellen, dass die benötigten Schriftarten explizit verfügbar sind.

**Kann ich ein Wasserzeichen über die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/net/watermark/) dem Master‑Foliensatz oder einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint auf jedem Frame.