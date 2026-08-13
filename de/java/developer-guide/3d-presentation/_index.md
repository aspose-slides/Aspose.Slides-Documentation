---
title: Erstellen von 3D‑Effekten in Präsentationen mit Java
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑Präsentation
- 3D‑Drehung
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Verlauf
- 3D‑Text
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Überblick**

Aspose.Slides für Java kann PowerPoint‑ähnliche 3D‑Formatierungen für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen sowie 3D‑Text.

{{% alert color="info" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D‑Formatierung**

Verwenden Sie [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/).`getThreeDFormat()`, um einer Form 3D‑Formatierung zuzuweisen. Das zurückgegebene Formatobjekt steuert die 3D‑Szene für diese Form.

Für Text verwenden Sie [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formenkörper angewendet.

| API‑Mitglied | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvorgabe, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderfläche nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vorderseite ab. |
| [getDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägung‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine weiche oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourWidth--), und [setContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D aussieht:

- Kameraeinstellungen, da die Standard‑Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten sichtbar macht.
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeneinstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seinem Vorderteil Text hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Drehen einer Form mit der Kamera**

In PowerPoint wird die 3D‑Drehung im Bereich 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Bereich 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über das 3D‑Format, das von `shape.getThreeDFormat()` zurückgegeben wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie verändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderfläche erweitert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, abgebildet auf Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Setzen Sie die Extrusionshöhe für die Dicke und die Extrusionsfarbe für die Seitenfarbe:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Verwenden Sie die Tiefen‑Einstellung, wenn Sie den PowerPoint‑Tiefenwert direkt bearbeiten oder die Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist die Extrusionshöhe die eindeutigere Einstellung, da sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden von Farbverläufen oder Bildfüllungen mit 3D‑Effekten**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können dem Vorderteil eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung zuweisen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Farbverlauf auf die Form an und eine dunklere Extrusionsfarbe auf die Seiten:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und ordnen es der Formfüllung zu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musternfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/):

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gerenderter 3D‑Text mit einer gebogenen WordArt‑Transformation, orangefarbener Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in Layout‑feste Formate wird die 3D‑Szene gerastert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Das gilt, wenn Sie Folien nach [PNG](/slides/de/java/convert-powerpoint-to-png/) rendern, nach [PDF](/slides/de/java/convert-powerpoint-to-pdf/) exportieren, nach [HTML](/slides/de/java/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/java/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Lichtaufbau, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/java/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert statt als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

### Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

### Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

### Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?

Mindestens muss eine Kameradrehung sowie entweder Extrusion oder Tiefe gesetzt werden. In der Praxis sollten zudem ein Lichtsetup und Material festgelegt werden, damit die gerenderten Flächen klare Highlights und Schatten erhalten.

### Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?

Ja. Verwenden Sie [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/).`getThreeDFormat()` für den Formenkörper und [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` für Text.

### Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames sichtbar?

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames, die für die Video‑Konvertierung verwendet werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

### Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Thema auslesen?

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Shape Effective Properties](/slides/de/java/shape-effective-properties/) beschrieben sind, um die endgültigen Kameras-, Licht‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.