---
title: Erstellen von 3D‑Effekten in Präsentationen auf Android
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑Präsentation
- 3D‑Rotation
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Farbverlauf
- 3D‑Text
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text auf Android mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides for Android via Java kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Rotation, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen sowie 3D‑Text.

{{% alert color="info" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er befasst sich nicht mit dem Einfügen oder Bearbeiten einzelner 3D‑Modelldateien. Beim Export einer Folie zu einem Bild, PDF oder HTML rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) , um 3D‑Formatierung auf eine Form anzuwenden. Die Methode liefert ein [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) , das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Diese wendet 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten API‑Mitglieder sind:

| API‑Mitglied | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Rotation, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder verwenden Sie eine PowerPoint‑3D‑Rotationsvoreinstellung. |
| [getLightRig](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvoreinstellung, Richtung und Lichtrotation. | Ändern Sie, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderfläche nach hinten ausgedehnt ist. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseite. | Fügen Sie eine weiche oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), und [setContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontansicht die Extrusion verbergen kann.  
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.  
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.  
- Extrusions‑ oder Tiefeneinstellungen, weil einer flachen Form Dicke fehlt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderfläche hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

## **Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Rotation im Dialogfeld 3‑D‑Rotation konfiguriert. Die X‑, Y‑ und Z‑Rotationswerte entsprechen der Rotation, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Dialogfeld 3‑D‑Rotation mit hervorgehobenen X‑, Y‑ und Z‑Rotationswerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Rotation über [IThreeDFormat.getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) :

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbst Steuerung legt die Farbe der Seitenflächen fest.

![PowerPoint‑Tiefen‑Steuerungen, die den Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften zugeordnet sind](img_02_02.png)

Setzen Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) für die Dicke und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) für die Seitenfarbe:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Verwenden Sie [IThreeDFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-), wenn Sie direkt mit dem PowerPoint‑Tiefenwert arbeiten oder Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist `setExtrusionHeight` die klarere Einstellung, weil sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden Sie Farbverlauf‑ oder Bildfüller mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderfläche anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions­einstellungen nutzen.

Dieses Beispiel wendet einen Farbverlauf‑Füller auf die Form und eine dunklere Extrusionsfarbe an den Seiten an:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild der Präsentation hinzu und weisen es der Formfüllung zu:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Form‑3D‑Formatierung wirkt sich auf den Formkörper aus. Text‑3D‑Formatierung wirkt sich auf den Textrahmen aus. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musterfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/) :

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![Gerenderter 3D‑Text mit einer bogenförmigen WordArt‑Transformation, orangefarbiger Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides erhält 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder in die Ausgabe als 2D‑Ergebnis gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/androidjava/convert-powerpoint-to-png/), zu [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) rendern oder Frames für die [video conversion](/slides/de/androidjava/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.  
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Beleuchtung, Material, Extrusion, Füllung und Folien‑Skalierung ab.  
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/androidjava/shape-effective-properties/).  
- Einige Ausgab Formate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert und nicht als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

### Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint bearbeitbar, sofern das Format dies unterstützt.

### Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, wie Rotation, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

### Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?

Mindestens müssen Sie eine Kamerarotation und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie außerdem ein Beleuchtungs‑Rig und Material einstellen, damit die gerenderten Flächen klare Highlights und Schatten haben.

### Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?

Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) für Text.

### Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Video‑Frames angezeigt?

Ja. Aspose.Slides rendert 3D‑Effekte bei der Erstellung von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung. Der exportierte Output enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

### Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Themen‑Einstellungen auslesen?

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [effektiven Formeigenschaften](/slides/de/androidjava/shape-effective-properties/) beschrieben werden, um die endgültigen Kamera‑, Beleuchtungs‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.