---
title: Erstellen von 3D-Effekten in Präsentationen auf Android
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint‑Formen und -Text auf Android mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für Android über Java kann PowerPoint‑ähnliche 3D‑Formatierungen für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel handelt von 3D‑Formatierungseffekten auf PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) , um einer Form 3D‑Formatierung anzuwenden. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten API‑Mitglieder sind:

| API‑Element | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine voreingestellte PowerPoint‑3D‑Drehung an. |
| [getLightRig](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderseite nach hinten reicht. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderseitenfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) und [getContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) und [setContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

- Kameraeinstellungen, da die standardmäßige Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, da die Oberfläche beeinflusst, wie das Licht dargestellt wird.
- Extrusions‑ oder Tiefeneinstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild in doppelter Standardgröße und speichert die Präsentation als PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das Paneel „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Paneel 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat.getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Frontansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie. Sie ändert den 3D‑Blickpunkt, der von PowerPoint und von Aspose.Slides beim Rendern verwendet wird.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dicker erscheinen, indem sie hinter die Vorderseite verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerelemente, die den Extrusionsfarbe‑ und Extrusionshöhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Verwenden Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) , um die Dicke festzulegen, und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) , um die Seitenfarbe abzurufen. Dieses Beispiel gibt einem Rechteck eine Extrusion von 100 Punkten mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

Die Methode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können der Vorderseite eine Vollfarbe, einen Verlauf, ein Muster oder eine Bildfüllung zuweisen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusionseinstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Verlaufspunkte bei 0 und 100 markieren den Beginn und das Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild in doppelter Standardgröße gerendert:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Verlauf und oranger Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie dem Dokument das Bild hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei mit dem Namen „image.jpg“ im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine Extrusion von 150 Punkten an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

![Gerendertes 3D‑Rechteck mit einer Fotofüllung auf der Vorderseite und oranger Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt sich auf den Formkörper aus. Die 3D‑Formatierung von Text wirkt sich auf den Textrahmen aus. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraparameter benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weiß‑gitter‑Muster, wendet einen aufwärts gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Die Extrusionshöhe und Tiefe werden in Punkten angegeben, und die Lichtdrehung ist in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild in doppelter Standardgröße der Folie und speichert die Präsentation als PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbener Musterausfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Um den Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) über [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Wenn er `false` ist, nimmt der Text an der Szene teil und folgt ihrer 3D‑Orientierung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: ihre Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) konfiguriert. Sie unterscheidet sich auch von einer normalen Drehung. [IShape.setRotation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setRotation-float-) dreht die Form in der Folienebene, während [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG in doppelter Standardgröße.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

Links folgt der Text der 3D‑Orientierung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Orientierung bei.

![Nebeneinander stehende 3D‑Rechtecke: Text folgt links der 3D‑Orientierung und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in Festlayout‑Formate wird die 3D‑Szene gerastert bzw. als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/androidjava/convert-powerpoint-to-png/), [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) rendern oder Frames für die [Video‑Konvertierung](/slides/de/androidjava/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Light‑Rig, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie ererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effective shape properties](/slides/de/androidjava/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen beibehalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe eingestellt werden. In der Praxis sollten zudem ein Light‑Rig und Material gesetzt werden, damit die gerenderten Flächen klare Lichtreflexe und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) für den Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Shape Effective Properties](/slides/de/androidjava/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Light‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.