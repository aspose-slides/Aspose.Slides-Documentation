---
title: PowerPoint-Folien in PNG auf Android konvertieren
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- Android
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für Android via Java, wobei präzise, automatisierte Ergebnisse gewährleistet werden."
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG (Portable Network Graphics)-Format ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr verbreitet. 

**Use case:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tip" color="primary" %}} Möglicherweise möchten Sie sich die kostenlosen Aspose **PowerPoint‑zu‑PNG‑Konverter** ansehen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie die folgenden Schritte durch:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Rufen Sie das Folienobjekt aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) unter der Schnittstelle [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) ab.
3. Verwenden Sie die Methode [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide), um das Vorschaubild für jede Folie zu erhalten.
4. Verwenden Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)), um das Folien‑Vorschaubild im PNG-Format zu speichern.

Dieser Java‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Vorschaubilds bestimmen. 

Dieser Java‑Code demonstriert die beschriebene Vorgehensweise:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer gewünschten Größe erhalten möchten, können Sie die gewünschten Argumente `width` und `height` für `ImageSize` übergeben. 

Dieser Code zeigt, wie Sie ein PowerPoint‑Dokument in PNG konvertieren und dabei die Bildgröße festlegen: 
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) anstelle der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Vorschaubildern für einzelne Formen](/slides/de/androidjava/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja, jedoch sollten Sie eine einzelne Präsentationsinstanz nicht über Threads hinweg [teilen](/slides/de/androidjava/multithreading/). Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen gelten in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/androidjava/licensing/), bis eine Lizenz angewendet wird.