---
title: 3D-Effekte in Präsentationen auf Android erstellen
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Präsentation
- 3D Drehung
- 3D Tiefe
- 3D Extrusion
- 3D Farbverlauf
- 3D Text
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text auf Android mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides für Android über Java kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen sowie 3D‑Text.

{{% alert color="primary" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte auf PowerPoint‑Formen und -Text. Er bezieht sich nicht auf das Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D‑Formatierung**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) , um einer Form 3D‑Formatierungen zuzuweisen. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Diese wendet 3D‑Formatierung auf den Textrahmen statt auf den Formkörper an.

Die wichtigsten API‑Mitglieder sind:

| API‑Mitglied | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungs‑Voreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvoreinstellung, Richtung und Lichtrotation. | Ändern Sie, wie Lichtreflexe und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt ist. | Verwandeln Sie eine flache Form in ein sichtbar dickeres 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderseitenfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierungen verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseite. | Fügen Sie eine weiche oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), und [setContourWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Umrandung um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D aussieht:

- Kameraeinstellungen, da die Standard‑Frontalansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten sichtbar macht.
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeneinstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderseite hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie als PNG‑Bild.

```java
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

In PowerPoint wird die 3D‑Drehung im Bereich 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungs‑Paneel mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

Verwenden Sie in Aspose.Slides die Methode [IThreeDFormat.getCamera](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getCamera--) :

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Verwenden Sie die Kamera, wenn Sie die Blickrichtung des Betrachters auf das Objekt ändern müssen. Sie verändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dicker erscheinen, indem sie hinter der Vorderseite erweitert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefen‑Steuerungen zu den Eigenschaften Extrusionsfarbe und Extrusionshöhe zugeordnet](img_02_02.png)

Setzen Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) für die Dicke und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) für die Seitenfarbe:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Verwenden Sie [IThreeDFormat.setDepth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-), wenn Sie den PowerPoint‑Tiefenwert direkt nutzen oder die Tiefe mit Abschrägung, Material und Texteffekten kombinieren möchten. In vielen Form‑Szenarien ist `setExtrusionHeight` die klarere Einstellung, da sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können die Vorderseite mit einer Vollfarbe, einem Farbverlauf, einem Muster oder einer Bildfüllung versehen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Farbverlauf auf die Form und eine dunklere Extrusionsfarbe auf die Seiten an:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und orangener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musterausfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/) :

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

![Gerenderter 3D‑Text mit einer gebogenen WordArt‑Transformation, orangefarbener Musterausfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Render‑Verhalten**

Aspose.Slides erhält die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert bzw. in die Ausgabe als 2D‑Ergebnis gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/androidjava/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) exportieren oder Frames für [video conversion](/slides/de/androidjava/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effective shape properties](/slides/de/androidjava/shape-effective-properties/).
- Einige Ausgabformate können nicht editierbare PowerPoint‑3D‑Formatierungen speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens sollte eine Kameradrehung und entweder Extrusion oder Tiefe gesetzt werden. In der Praxis sollten zudem ein Licht‑Rig und Material gesetzt werden, damit die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) für den Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Themainstellungen auslesen?**

Ja. Verwenden Sie die effektiven Format‑APIs, die in [Shape Effective Properties](/slides/de/androidjava/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.