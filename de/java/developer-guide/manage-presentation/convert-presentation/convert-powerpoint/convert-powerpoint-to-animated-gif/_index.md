---
title: PowerPoint in animiertes GIF umwandeln
type: docs
weight: 65
url: /de/java/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint in animiertes GIF umwandeln, PPT in GIF, PPTX in GIF"
description: "PowerPoint in animiertes GIF umwandeln: PPT in GIF, PPTX in GIF, mit der Aspose.Slides-API."
---

## Präsentationen in animiertes GIF mit Standardeinstellungen umwandeln ##

Dieser Beispielcode in Java zeigt Ihnen, wie Sie eine Präsentation in ein animiertes GIF mit Standardeinstellungen umwandeln können:

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

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions) Klasse verwenden. Siehe den Beispielcode unten.

{{% /alert %}} 

## Präsentationen in animiertes GIF mit benutzerdefinierten Einstellungen umwandeln ##
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in ein animiertes GIF mit benutzerdefinierten Einstellungen in Java umwandeln können:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // die Größe des resultierenden GIF  
	gifOptions.setDefaultDelay(2000); // wie lange jede Folie angezeigt wird, bis sie zur nächsten gewechselt wird
	gifOptions.setTransitionFps(35); // FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Sie sollten einen KOSTENLOSEN [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren.

{{% /alert %}}