---
title: PowerPoint in animiertes GIF konvertieren
type: docs
weight: 65
url: /de/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint in animiertes GIF konvertieren, PPT zu GIF, PPTX zu GIF"
description: "PowerPoint in animiertes GIF konvertieren: PPT zu GIF, PPTX zu GIF, mit Aspose.Slides API."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in JavaScript zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIPP"  color="primary"  %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions)‑Klasse verwenden. Siehe den Beispielcode unten.
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in JavaScript in ein animiertes GIF konvertieren:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// die Größe des resultierenden GIFs
    gifOptions.setDefaultDelay(2000);// wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
    gifOptions.setTransitionFps(35);// FPS erhöhen für bessere Übergangsanimationsqualität
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
Vielleicht interessieren Sie sich für einen KOSTENLOSEN [Text‑zu‑GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter von Aspose. 
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriften nicht auf dem System installiert sind?**  
Installieren Sie die fehlenden Schriften oder [fallback fonts konfigurieren](/slides/de/nodejs-java/powerpoint-fonts/). Aspose.Slides wird Ersatzschriften verwenden, das Aussehen kann jedoch abweichen. Für Markenauftritte stellen Sie stets sicher, dass die benötigten Schriftarten explizit verfügbar sind.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**  
Ja. [Ein halbtransparentes Objekt/Logo hinzufügen](/slides/de/nodejs-java/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export – das Wasserzeichen erscheint auf jedem Frame.