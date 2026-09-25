---
title: Δημιουργία 3Δ εφέ σε παρουσιάσεις με χρήση Node.js
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/nodejs-java/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξώθηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Node.js με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσεις και 3Δ κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java can create, edit, preserve, and render PowerPoint-style 3D formatting for shapes and text. This article covers 3D effects such as rotation, extrusion, bevels, lighting, material, gradient or picture fills, and 3D text.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3D σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία αυτόνομων αρχείων μοντέλων 3D. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαχθείσα 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3D**

Use the [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getThreeDFormat) method to apply 3D formatting to a shape. The method returns [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/), which controls the 3D scene for that shape.

For text, use the [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) method. This applies 3D formatting to the text frame instead of the shape body.

The most important API members are:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getCamera) | Οπτικό σημείο, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στον τρισδιάστατο χώρο ή συσχετίστε το με προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται οι ανταυγείες και οι σκιές στην 3Δ επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, λαμπερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την πρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με τη γέμιση του προσώπου. |
| [getDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setDepth) | Επιπλέον 3Δ βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε με ακρίβεια το βάθος για σχήματα ή κείμενο, ειδικά σε συνδυασμό με ρυθμίσεις κλίκας και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ανεβασμένα ή στρογγυλεμένα άκρα στην πρόσωψη και στην πίσω όψη. | Προσθέστε ένα μαλακό ή διαμορφωμένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το σύνορο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3Δ σχήματος**

A shape usually needs four kinds of settings before it looks convincingly 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη πρόσοψη μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει την απόδοση του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

The following example creates a rectangle, adds text to its front face, and applies 3D formatting. The camera rotation values are in degrees, and the extrusion height is 100 points. The example renders the slide to a PNG image at twice its default dimensions and saves the presentation as PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The rendered slide image shows the rectangle as a thick 3D block:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή σχήματος με την κάμερα**

In PowerPoint, 3D rotation is configured from the 3-D Rotation pane. The X, Y, and Z rotation values correspond to the rotation you set through the camera API.

![Πλαίσιο Περιστροφής 3‑Δ του PowerPoint με επισημασμένες τιμές X, Y και Z](img_02_01.png)

In Aspose.Slides, access the camera through [ThreeDFormat.getCamera](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getCamera). This example creates a rectangle, selects an orthographic front view, and sets its X, Y, and Z rotations to 20, 30, and 40 degrees, respectively. It configures the shape in memory without saving a file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Use the camera when you need to change how the viewer sees the object. It does not change the 2D shape geometry on the slide. It changes the 3D viewpoint used by PowerPoint and by Aspose.Slides when rendering.

## **Προσθήκη εξώθησης και βάθους**

Extrusion makes a shape look thick by extending it behind the front face. In PowerPoint, the depth control sets this visible thickness, and the color control sets the color of the side faces.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Use [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) to set the thickness and [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) to access the side color. This example gives a rectangle a 100-point extrusion with purple sides and rotates the camera to reveal its thickness. It configures the shape in memory without saving a file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

The [ThreeDFormat.setDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setDepth) method sets the depth of a 3D shape. The [setExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) method controls the height of the extrusion effect, as shown in this example.

## **Χρήση διαβάθμισης ή γεμίσεων εικόνας με εφέ 3D**

3D formatting is independent of the shape fill. You can apply a solid color, gradient, pattern, or picture fill to the front face and still use the same camera, light, material, and extrusion settings.

This example applies a blue-to-orange gradient to the front face and a dark orange color to the 150-point extrusion. The gradient stops at 0 and 100 mark the start and end of the gradient. The camera rotation values are in degrees. The slide is rendered to a PNG image at twice its default dimensions:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

The rendered output keeps the gradient on the front face and renders the extrusion separately:

![Απόδοση 3Δ ορθογωνίου με διαβάθμιση μπλε‑πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

To use a picture fill instead, add the image to the presentation and assign it to the shape fill. This example requires an existing file named "image.jpg" in the working directory. It stretches the picture to fill the rectangle, applies a 150-point extrusion, and sets the camera rotation in degrees. It configures the shape in memory without saving or rendering a file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

The picture is rendered on the front face, while the extrusion is rendered as the 3D side surface:

![Απόδοση 3Δ ορθογωνίου με γέμιση φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή μορφοποίησης 3D σε κείμενο**

Shape 3D formatting affects the shape body. Text 3D formatting affects the text frame. This is useful for WordArt-like effects where the letters themselves need extrusion, material, lighting, and camera settings.

The following example creates text with an orange-and-white grid pattern, applies an upward arch, and configures 3D settings through [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). The extrusion height and depth are in points, and the light rotation is in degrees. The shape fill and outline are hidden so that only the text is visible. The example renders a PNG image at twice the default slide dimensions and saves the presentation as PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The text is rendered as curved, extruded 3D lettering:

![Απόδοση 3Δ κειμένου με κυρτό WordArt, γέμιση με πορτοκαλί μοτίβο και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση κειμένου επίπεδου σε 3Δ σχήμα**

To keep text readable while preserving a shape's 3D appearance, call [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) through [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). When the value is `true`, the text stays out of the 3D scene. When it is `false`, the text participates in the scene and follows its 3D orientation.

This setting does not remove the shape's 3D formatting: its camera, lighting, material, and extrusion remain configured through [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getThreeDFormat). It is also different from ordinary rotation. [Shape.setRotation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#setRotation) rotates the shape in the slide plane, while [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) controls the text's custom rotation within its bounding box. Keeping text out of the 3D scene does not reset either of those angles.

The following self-contained example creates a blue rectangle with text and clones it beside the original. Both shapes have the same 3D formatting; only the text setting differs: `false` on the left and `true` on the right. The camera angles are in degrees, and the extrusion height is 40 points. The example saves the presentation as PPTX and renders the comparison slide to PNG at twice its default dimensions.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

On the left, the text follows the 3D orientation. On the right, it stays flat and easier to read. Both rectangles retain the same visible extrusion and 3D orientation.

![Δύο πλάγιες 3Δ ορθογώνιες: το κείμενο ακολουθεί την 3Δ προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά εξαγωγής και απόδοσης**

Aspose.Slides preserves 3D formatting when saving to PowerPoint formats such as PPTX. When rendering or exporting to fixed-layout formats, the 3D scene is rasterized or drawn into the output as a 2D result. This applies when you render slides to [PNG](/slides/el/nodejs-java/convert-powerpoint-to-png/), export to [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), export to [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), or generate frames for [video conversion](/slides/el/nodejs-java/convert-powerpoint-to-video/).

Keep these points in mind:

- Exported images and PDFs are not interactive. The object cannot be rotated by the viewer after export.
- The final appearance depends on the combination of camera, light rig, material, extrusion, fill, and slide scaling.
- If you need to inspect inherited or theme-based formatting values, read the [effective shape properties](/slides/el/nodejs-java/shape-effective-properties/).
- Some output formats cannot store editable PowerPoint 3D formatting. In those formats, the visual result is rendered rather than preserved as editable 3D settings.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Aspose.Slides creates and renders PowerPoint 3D effects for shapes and text. It does not make exported images, PDFs, or HTML pages interactive 3D scenes that a viewer can rotate. In PPTX, the 3D formatting remains editable in PowerPoint where the format supports it.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

A 3D model is a separate 3D object inserted into a presentation. A 3D effect is formatting applied to a regular PowerPoint shape or text, such as rotation, extrusion, bevel, lighting, and material. This article covers 3D effects.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

At minimum, set a camera rotation and either extrusion or depth. In practice, also set a light rig and material so the rendered faces have clear highlights and shadows.

**Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;**

Yes. Use [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getThreeDFormat) for the shape body and [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) for text.

**Θα εμφανιστούν τα 3D εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Yes. Aspose.Slides renders 3D effects when producing slide images, PDF output, HTML output, and frames used for video conversion. The exported output contains the rendered appearance, not an editable 3D object.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την εφαρμογή κληρονομικών και θεματικών ρυθμίσεων;**

Yes. Use the effective formatting APIs described in [Shape Effective Properties](/slides/el/nodejs-java/shape-effective-properties/) to read final camera, light rig, bevel, and related 3D values.