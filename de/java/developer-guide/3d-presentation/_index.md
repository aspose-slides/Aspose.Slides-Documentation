---
title: 3D-Effekte in Präsentationen mit Java erstellen
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Farbverlauf
- 3D-Text
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint‑Formen und -Text in Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für Java kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="primary" %}}

Dieser Artikel beschreibt 3D‑Formatierungseffekte für PowerPoint‑Formen und Text. Er behandelt nicht das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Beim Export einer Folie zu einem Bild, PDF oder HTML rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.

{{% /alert %}}

## **Konzepte der 3D-Formatierung**

Verwenden Sie [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/).`getThreeDFormat()`, um einer Form 3D‑Formatierung zuzuweisen. Das zurückgegebene Formatobjekt steuert die 3D‑Szene für diese Form.

Für Text verwenden Sie [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten API‑Mitglieder sind:

| API‑Mitglied | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getCamera--) | Sichtpunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder verwenden Sie eine vordefinierte PowerPoint‑3D‑Drehung. |
| [getLightRig](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvorgabe, Richtung und Lichtdrehung. | Ändern Sie, wie Highlight‑ und Schattenbereiche auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallischer wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Wandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt um. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Passen Sie die Tiefe für Formen oder Text fein an, insbesondere zusammen mit Abschrägungen und Material. |
| [getBevelTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten an Vorder- und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante anstelle einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourWidth--), und [setContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D-Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, damit sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontalansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche die Lichtdarstellung beeinflusst.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke braucht.

Das folgende Beispiel erstellt ein Rechteck, fügt Text auf der Vorderseite hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

```java
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

## **Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das Bedienfeld „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehungswerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Bedienfeld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Werten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über das 3D‑Format, das von `shape.getThreeDFormat()` zurückgegeben wird:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie der Folie, sondern den 3D‑Blickwinkel, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter der Vorderseite verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Setzen Sie die Extrusionshöhe für die Dicke und die Extrusionsfarbe für die Seitenfarbe:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Verwenden Sie die Tiefeneinstellung, wenn Sie den PowerPoint‑Tiefenwert direkt nutzen oder ihn mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Szenarien ist die Extrusionshöhe die klarere Einstellung, weil sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden von Farbverläufen oder Bildfüllungen mit 3D‑Effekten**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und gleichzeitig dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Farbverlaufsfüllung auf die Form an und eine dunklere Extrusionsfarbe für die Seiten:

```java
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

Die gerenderte Ausgabe behält den Farbverlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbenem Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild der Präsentation hinzu und weisen es der Formfüllung zu:

```java
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
```

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche dargestellt wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D-Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form betrifft den Formkörper. Die 3D‑Formatierung von Text betrifft den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musterfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/):

```java
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

Der Text wird als gebogener, extrudierter 3D‑Schrifttyp gerendert:

![Gerenderter 3D‑Text mit einem Bogen‑WordArt‑Transform, orangefarbener Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in festes Layout werden die 3D‑Szenen rasterisiert bzw. in das Ausgabeformat als 2D‑Ergebnis gezeichnet. Das gilt beim Rendern von Folien zu [PNG](/slides/de/java/convert-powerpoint-to-png/), Exportieren zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/), Exportieren zu [HTML](/slides/de/java/convert-powerpoint-to-html/) oder Erzeugen von Frames für die [Video‑Konvertierung](/slides/de/java/convert-powerpoint-to-video/).

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte einsehen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/java/shape-effective-properties/).
- Einige Ausgabeformate können editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, nicht als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format sie unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind erforderlich, damit eine 3D‑Form sichtbar wird?**

Mindestens sollten Sie eine Kameradrehung und entweder Extrusion oder Tiefe setzen. In der Praxis setzen Sie zudem ein Licht‑Rig und Material, damit die gerenderten Flächen klare Highlights und Schatten haben.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/).`getThreeDFormat()` für den Formkörper und [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` für Text.

**Werden 3D‑Effekte beim Export zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte bei der Erzeugung von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Video‑Konvertierung. Die exportierte Ausgabe enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Format‑APIs, die in [Shape Effective Properties](/slides/de/java/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.