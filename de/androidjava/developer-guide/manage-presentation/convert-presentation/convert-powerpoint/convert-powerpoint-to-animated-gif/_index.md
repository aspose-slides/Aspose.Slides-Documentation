---
title: PowerPoint-Präsentationen auf Android in animierte GIFs konvertieren
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Einfach PowerPoint‑Präsentationen (PPT, PPTX) mit Aspose.Slides für Android via Java in animierte GIFs konvertieren. Schnell, hochwertige Ergebnisse."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, PowerPoint‑Präsentationen mit nur wenigen Codezeilen in animierte GIF‑Dateien zu konvertieren. Das ist nützlich, wenn Sie Folieninhalte in einem leichten, weit verbreiteten animierten Format teilen müssen, das in Webseiten, Messenger‑Apps oder Dokumentationen eingebettet werden kann. Dieser Artikel erklärt, wie Sie eine Präsentation mit Standard‑Einstellungen in GIF exportieren und wie Sie die Ausgabe anpassen können, indem Sie Optionen wie Frame‑Größe, Folienverzögerung und Übergangs‑Frame‑Rate über [GifOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/gifoptions/) konfigurieren.

## **Präsentationen mit den Standardeinstellungen in animiertes GIF konvertieren**

Dieses Beispielcode in Java zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIP"  color="info"  %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/GifOptions) verwenden. Siehe den Beispielcode unten.
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieses Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Java in ein animiertes GIF konvertieren:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // die Größe des resultierenden GIF
	gifOptions.setDefaultDelay(2000); // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
	gifOptions.setTransitionFps(35); // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/de/text-to-gif) Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

### Was ist, wenn die in der Präsentation verwendeten Schriften nicht auf dem System installiert sind?

Installieren Sie die fehlenden Schriften oder [konfigurieren Sie Ersatzschriften](/slides/de/androidjava/powerpoint-fonts/). Aspose.Slides wird Ersatz verwenden, aber das Aussehen kann abweichen. Für das Branding stellen Sie stets sicher, dass die benötigten Schriftarten explizit verfügbar sind.

### Kann ich ein Wasserzeichen auf die GIF‑Frames legen?

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/androidjava/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint in jedem Frame.