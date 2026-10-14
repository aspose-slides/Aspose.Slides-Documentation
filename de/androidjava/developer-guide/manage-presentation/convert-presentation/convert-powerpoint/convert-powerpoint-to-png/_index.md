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
description: "Konvertieren Sie PowerPoint-Präsentationen schnell in hochwertige PNG‑Bilder mit Aspose.Slides für Android über Java und erhalten Sie präzise, automatisierte Ergebnisse."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsfolien mit Aspose.Slides für Android über Java in PNG‑Bilder umwandeln können. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separates PNG‑Bild speichern.

Die nachstehenden Beispiele zeigen das Rendern mit dem Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und die Auswahl eines Gradienten‑Renderingsstils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und greifen Sie über die Sammlung [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) auf deren Folien zu. Das Beispiel rendert jede Folie mit [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) ohne Parameter, um ein Thumbnail zu erzeugen. Anschließend wird [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) zusammen mit [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Die parameterlose Überladung von [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) rendert mit einer Skalierung von 0,2. Zum Beispiel erzeugt eine Folie mit den Maßen 720 × 540 Punkt ein Vorschaubild von 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit den Maßen 720 × 540 Punkt ein Bild von 1440 × 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jeder Bild wird im PNG‑Format mit [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie eine Größe an [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) anstelle von Skalierungsfaktoren. Dieses Beispiel rendert jede Folie mit 960 × 720 Pixel und speichert das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Verzerren des Bildes zu vermeiden.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Wählen Sie einen Gradient‑Renderingsstil**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anderweitig anders als in PowerPoint. Sie können die Methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) verwenden, die von [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) geerbt wird, um zu wählen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Die nachstehenden Bilder zeigen die Ausgabe derselben Folie, wobei in jedem Bild beide Verläufe zu sehen sind:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-orange und blau-zu-gelb Farbverläufe gerendert mit Default](gradient-Default.png) | ![Die gleichen Farbverläufe gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischentöne, während `PowerPointUI` dunklere Zwischentöne erzeugt. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Default`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Probieren Sie `PowerPointUI`, wenn Ihre Priorität darin besteht, das Erscheinungsbild in PowerPoint zu übernehmen. Vergleichen Sie beide Ausgaben mit Ihrem gewünschten Ergebnis; kein Modus ist generell vorzuziehen.

## **FAQ**

**Wie kann ich ein bestimmtes Shape, wie z. B. ein Diagramm oder Bild, anstatt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Shapes](/slides/de/androidjava/create-shape-thumbnails/), wodurch Sie ein Shape als PNG‑Bild rendern können.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzige Instanz über Threads hinweg](/slides/de/androidjava/multithreading/).

**Welche Einschränkungen gelten im Evaluierungsmodus beim Export in PNG?**

Im Evaluierungsmodus wird den Ausgabebildern ein Wasserzeichen hinzugefügt und es werden [weitere Einschränkungen](/slides/de/androidjava/licensing/) angewendet, bis eine Lizenz installiert ist.