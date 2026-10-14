---
title: PowerPoint-Folien in PNG konvertieren in Java
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folien zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- Java
- Aspose.Slides
description: "PowerPoint‑Präsentationen schnell in hochwertige PNG‑Bilder konvertieren mit Aspose.Slides für Java und dabei präzise, automatisierte Ergebnisse sicherstellen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Präsentationsfolien mit Aspose.Slides für Java in PNG‑Bilder konvertiert werden. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und als separates PNG‑Bild speichern.

Die nachstehenden Beispiele zeigen das Rendern in der Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und die Auswahl eines Gradienten‑Render‑Stils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und greifen Sie über die Sammlung [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) auf die Folien zu. Das Beispiel rendert jede Folie mit [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) ohne Parameter, um ein Thumbnail zu erstellen. Anschließend wird [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) mit [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

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

{{% alert color="info" title="Hinweis" %}}
Die parameterlose Überladung von [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) rendert in einer Skalierung von 0.2. Beispielsweise erzeugt eine Folie mit 720 × 540 Punkten ein Thumbnail von 144 × 108 Pixeln. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit 720 × 540 Punkten ein Bild von 1440 × 1080 Pixeln erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jedes Bild wird im PNG‑Format mit [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) gespeichert.

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

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie eine Größe an [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) , anstatt Skalierungsfaktoren zu verwenden. Dieses Beispiel rendert jede Folie mit 960 × 720 Pixeln und speichert das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Dehnen des Bildes zu vermeiden.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

## **Wählen Sie einen Gradienten‑Render‑Stil**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anderweitig unterschiedlich zu dem, was Sie in PowerPoint sehen. Sie können die Methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) verwenden, die von [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) geerbt wird, um festzulegen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

Die untenstehenden Bilder zeigen die Ausgabe derselben Folie, jeweils mit beiden Verläufen im Bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-Orange- und Blau-zu-Gelb-Verläufe gerendert mit Default](gradient-Default.png) | ![Die gleichen Verläufe gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Default`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Probieren Sie `PowerPointUI`, wenn es Ihnen wichtig ist, das Aussehen in PowerPoint zu treffen. Vergleichen Sie beide Ausgaben mit dem gewünschten Ergebnis; keine der beiden Optionen ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich eine bestimmte Form, wie ein Diagramm oder Bild, statt der gesamten Folie exportieren?**

Aspose.Slides unterstützt [das Erzeugen von Miniaturbildern für einzelne Formen](/slides/de/java/create-shape-thumbnails/), sodass Sie eine Form als PNG‑Bild rendern können.

**Wird parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzige Instanz über mehrere Threads](/slides/de/java/multithreading/).

**Welche Einschränkungen gelten im Evaluationsmodus beim Export nach PNG?**

Im Evaluationsmodus wird den Ausgabebildern ein Wasserzeichen hinzugefügt und es werden [weitere Einschränkungen](/slides/de/java/licensing/) angewendet, bis eine Lizenz aktiviert ist.