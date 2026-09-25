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
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides for Java kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D-Formatierung**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getThreeDFormat--) , um einer Form 3D‑Formatierung zuzuweisen. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten API‑Elemente sind:

| API‑Element | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie ein PowerPoint‑3D‑Drehungs‑Preset an. |
| [getLightRig](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getLightRig--) | Licht‑Preset, Richtung und Lichtdrehung. | Ändern Sie, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderseite nach hinten ragt. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourColor--) und [getContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getContourWidth--) und [setContourWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Umriss um das 3D‑Objekt. | Betont die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderseite hinzu und wendet 3D‑Formatierung an. Die Kamera‑Drehwerte sind in Grad angegeben, und die Extrusions‑Höhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

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

In PowerPoint wird die 3D‑Drehung über das Fenster **3‑D‑Drehung** konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3D‑Drehungsfenster mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat.getCamera](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getCamera--) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Frontansicht und setzt die X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern möchten, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter die Vorderfläche ragt. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusions‑Farbe‑ und Extrusions‑Höhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Verwenden Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) , um die Dicke festzulegen, und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) , um die Seitenfarbe abzurufen. Dieses Beispiel gibt einem Rechteck eine Extrusion von 100 Punkten mit violetten Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Die Methode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setDepth-double-) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verlauf- oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselbe Kamera, Beleuchtung, Material und Extrusion verwenden.

Dieses Beispiel wendet einen blau‑zu‑orangefarbenen Verlauf auf die Vorderseite an und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion. Die Verlaufspunkte bei 0 % und 100 % markieren Anfang und Ende des Farbverlaufs. Die Kamera‑Drehwerte sind in Grad. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

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

Das gerenderte Ergebnis behält den Verlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit einem blau‑zu‑orangefarbenen Farbverlaufs‑Füllung und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt voraus, dass im Arbeitsverzeichnis eine Datei namens **image.jpg** vorhanden ist. Es streckt das Bild, um das Rechteck zu füllen, wendet eine Extrusion von 150 Punkten an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Das Bild wird auf der Vorderfläche gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Form‑3D‑Formatierung betrifft den Formkörper. Text‑3D‑Formatierung betrifft den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraparameter benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑und‑weiß­em Rastermuster, wendet einen nach oben geschwungenen Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Die Extrusions‑Höhe und Tiefe sind in Punkten angegeben, und die Licht‑Drehung in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Foliengröße und speichert die Präsentation als PPTX:

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

Der Text wird als gebogener, extrudierender 3D‑Schriftzug gerendert:

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbiger Mustervollfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) über [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getTextFrameFormat--) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: deren Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getThreeDFormat--) konfiguriert. Sie unterscheidet sich außerdem von einer normalen Drehung. [IShape.setRotation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setRotation-float-) dreht die Form in der Folienebene, während [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keine dieser Drehungen zurück.

Das folgende, in sich geschlossene Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad, die Extrusions‑Höhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichs‑Folie zu PNG mit doppelter Standardgröße.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Auf der linken Seite folgt der Text der 3D‑Ausrichtung. Auf der rechten Seite bleibt er flach und besser lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander dargestellte 3D‑Rechtecke: Text folgt der 3D‑Ausrichtung links und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Darstellung gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/java/convert-powerpoint-to-png/), zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/java/convert-powerpoint-to-html/) rendern oder Frames für die [Video‑Konvertierung](/slides/de/java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Beleuchtung, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/java/shape-effective-properties/).
- Einige Ausgabformate können keine editierbare PowerPoint‑3D‑Formatierung speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie auch eine Beleuchtung und ein Material einstellen, damit die gerenderten Flächen klare Highlights und Schatten erhalten.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgaben, HTML‑Ausgaben und Frames für die Video‑Konvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, jedoch kein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung von Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [Shape Effective Properties](/slides/de/java/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Beleuchtungs‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.