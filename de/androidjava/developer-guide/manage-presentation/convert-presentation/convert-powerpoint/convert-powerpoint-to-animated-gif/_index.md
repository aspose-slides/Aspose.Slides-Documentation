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
- Benutzerdefinierte Einstellungen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen (PPT, PPTX) problemlos mit Aspose.Slides für Android über Java in animierte GIFs konvertieren. Schnelle, hochwertige Ergebnisse."
---

## **Präsentationen in animiertes GIF mit Standardeinstellungen konvertieren**

Dieses Beispielcode in Java zeigt, wie Sie eine Präsentation mit den Standardeinstellungen in ein animiertes GIF konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions) verwenden. Siehe den Beispielcode unten.

{{% /alert %}} 

## **Präsentationen in animiertes GIF mit benutzerdefinierten Einstellungen konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Java in ein animiertes GIF konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // die Größe des erzeugten GIFs
	gifOptions.setDefaultDelay(2000); // wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
	gifOptions.setTransitionFps(35); // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/androidjava/powerpoint-fonts/). Aspose.Slides wird ersetzen, aber das Erscheinungsbild kann abweichen. Für Branding stellen Sie stets sicher, dass die erforderlichen Schriftarten ausdrücklich verfügbar sind.

**Kann ich ein Wasserzeichen auf den GIF-Frames überlagern?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/androidjava/watermark/) zur Master-Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint auf jedem Frame.