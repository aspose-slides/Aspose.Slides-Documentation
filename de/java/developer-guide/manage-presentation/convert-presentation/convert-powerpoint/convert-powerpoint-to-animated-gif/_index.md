---
title: PowerPoint-Präsentationen in Java in animierte GIFs konvertieren
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/java/convert-powerpoint-to-animated-gif/
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
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen (PPT, PPTX) mühelos in animierte GIFs mit Aspose.Slides für Java. Schnelle, hochwertige Ergebnisse."
---

## Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren ##

Dieser Beispielcode in Java zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


Das animierte GIF wird mit den Standard‑Parametern erstellt. 

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions) verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren ##
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Java in ein animiertes GIF konvertieren:
```java
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

Vielleicht möchten Sie den kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}