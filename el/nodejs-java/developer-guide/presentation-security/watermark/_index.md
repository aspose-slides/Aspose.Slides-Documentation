---
title: "Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις με JavaScript"
linktitle: "Υδατογράφημα"
type: docs
weight: 40
url: /el/nodejs-java/watermark/
keywords:
- "υδατογράφημα"
- "υδατογράφημα κειμένου"
- "υδατογράφημα εικόνας"
- "προσθήκη υδατογραφήματος"
- "αλλαγή υδατογραφήματος"
- "αφαίρεση υδατογραφήματος"
- "διαγραφή υδατογραφήματος"
- "προσθήκη υδατογραφήματος σε PPT"
- "προσθήκη υδατογραφήματος σε PPTX"
- "προσθήκη υδατογραφήματος σε ODP"
- "αφαίρεση υδατογράφηματος από PPT"
- "αφαίρεση υδατογράφηματος από PPTX"
- "αφαίρεση υδατογράφηματος από ODP"
- "διαγραφή υδατογράφηματος από PPT"
- "διαγραφή υδατογράφηματος από PPTX"
- "διαγραφή υδατογράφηματος από ODP"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument στο Node.js για να υποδείξετε πρόχειρη έκδοση, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι σήμα κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ. υδατογράφημα "Πρόχειρο"), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ. υδατογράφημα "Εμπιστευτικό"), για να καθορίσει σε ποια εταιρεία ανήκει (π.χ. υδατογράφημα "Όνομα Εταιρείας"), για την ταυτοποίηση του συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποτροπή παραβίασης πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατόγραφια χρησιμοποιούνται και στις μορφές παρουσίασης PowerPoint και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε ένα υδατογράφημα στα αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/el/nodejs-java/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για να προσθέσετε υδατογραφήματα κειμένου, πρέπει να χρησιμοποιήσετε τον τύπο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/), και για να προσθέσετε υδατογραφήματα εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογράφηματος με εικόνα. `PictureFrame` υλοποιεί τον τύπο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/), επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Επειδή το `TextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, περιβάλλεται σε ένα αντικείμενο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) .

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**
To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [**TextFrame**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame) type. This type is not inherited from [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame) object is wrapped in an [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) object. To add watermark text to the shape, use the [**addTextFrame**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) method with watermark text passed into it:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- Πώς να χρησιμοποιήσετε [TextFrame](/slides/el/nodejs-java/text-formatting/).
{{% /alert %}}

### **Προσθήκη Υδατογραφήματος Κειμένου στην Παρουσίαση**
If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [**MasterSlide**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MasterSlide). The rest of the logic is the same as when adding a watermark to a single slide — create an [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) object and then add the watermark to it using the [**addTextFrame**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) method:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [Πώς να χρησιμοποιήσετε ](/slides/el/nodejs-java/slide-master/)[Slide Master](/slides/el/nodejs-java/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**
By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**
You can change the font of the text watermark as shown below.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**
To set the color of the watermark text, use this code:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Κεντράρισμα Υδατογραφήματος Κειμένου**
It is possible to center watermark on a slide and for that you can do the following:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

The image below shows the final result.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφήματος Εικόνας σε Παρουσίαση**
To add image watermark into all presentation slides, you may do the following:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Κλείδωμα Υδατογραφήματος από Επεξεργασία**
If it is necessary to prevent a watermark from being edited, use the [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape#getShapeLock--) method on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```javascript
// Κλειδώστε το σχήμα υδατογραφήματος από τροποποίηση
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Μεταφορά Υδατογραφήματος Μπροστά**
In Aspose.Slides, the Z-order of shapes can be set via the [**SlideCollection.reorder**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ορισμός Περιστροφής Υδατογραφήματος**
Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Ορισμός Ονόματος για Υδατογράφημα**
Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [**AutoShape.getName**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getName--) method:

```javascript
watermarkShape.setName("watermark");
```

### **Αφαίρεση Υδατογραφήματος**
To remove the watermark shape, use the [AutoShape.getName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getName--) method to find it in the slide shapes. Then, pass the watermark shape into the [**ShapeCollection.remove**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) method:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Συχνές Ερωτήσεις**

**What is a watermark and why should I use it?**
Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;

A watermark is a text or image overlay applied to slides that helps protect intellectual property, enhance brand recognition, or prevent unauthorized use of presentations.

**Can I add a watermark to all slides in a presentation?**
Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;

Yes, Aspose.Slides allows you to add a watermark to every slide in a presentation. You can iterate through all the slides and apply the watermark settings individually.

**How can I adjust the transparency of the watermark?**
Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;

You can adjust the transparency of the watermark by modifying the [fill settings](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getfillformat/) of the shape. This ensures that the watermark is subtle and does not distract from the slide content.

**What image formats are supported for watermarks?**
Ποιες μορφές εικόνας υποστηρίζονται για υδατογραφήματα;

Aspose.Slides supports various image formats such as PNG, JPEG, GIF, BMP, SVG, and more.

**Can I customize the font and style of a text watermark?**
Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφήματος κειμένου;

Yes, you can choose any font, size, and style to match the design of your presentation and maintain brand consistency.

**How do I change the position or orientation of a watermark?**
Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφήματος;

You can adjust the position and orientation of the watermark by modifying the shape's coordinates, size, and rotation properties.