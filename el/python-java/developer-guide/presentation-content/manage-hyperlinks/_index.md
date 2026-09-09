---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε Python μέσω Java
linktitle: Διαχείριση Υπερσύνδεσμου
type: docs
weight: 20
url: /el/python-java/manage-hyperlinks/
keywords:
- Προσθήκη URL
- Προσθήκη υπερσυνδέσμου
- Δημιουργία υπερσυνδέσμου
- Μορφοποίηση υπερσυνδέσμου
- Αφαίρεση υπερσυνδέσμου
- Ενημέρωση υπερσυνδέσμου
- Υπερσύνδεσμος κειμένου
- Υπερσύνδεσμος διαφάνειας
- Υπερσύνδεσμος σχήματος
- Υπερσύνδεσμος εικόνας
- Υπερσύνδεσμος βίντεο
- Μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε εύκολα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java—βελτιώστε την αλληλεπιδραστικότητα και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε ένα αντικείμενο, δεδομένα ή μια θέση. Συνηθισμένοι υπερσύνδεσμοι σε παρουσιάσεις PowerPoint περιλαμβάνουν:

* Συνδέσεις σε ιστοσελίδες σε κείμενο, σχήματα ή πολυμέσα
* Συνδέσεις σε διαφάνειες

Aspose.Slides για Python μέσω Java επιτρέπει την εκτέλεση πολλών εργασιών που αφορούν υπερσυνδέσμους σε παρουσιάσεις. 

{{% alert color="info" title="Σημείωση" %}} 
Ίσως να θέλετε να δείτε τον απλό, [δωρεάν διαδικτυακό επεξεργαστή PowerPoint της Aspose.](https://products.aspose.app/slides/el/editor)
{{% /alert %}} 

## **Προσθήκη URL Υπερσυνδέσμων**

### **Προσθήκη URL Υπερσυνδέσμων σε Κείμενο**

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε κείμενο:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη URL Υπερσυνδέσμων σε Σχήματα ή Πλαίσια**

Αυτό το δείγμα κώδικα σε Python μέσω Java δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε ένα σχήμα:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη URL Υπερσυνδέσμων σε Πολυμέσα**

Το Aspose.Slides επιτρέπει την προσθήκη υπερσυνδέσμων σε εικόνες, ήχους και αρχεία βίντεο. 

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Προσθέτει εικόνα στην παρουσίαση
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βασισμένο στην προηγουμένως προστιθέμενη εικόνα
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:
```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:
```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Συμβουλή" %}} 
Ίσως να θέλετε να δείτε *[Διαχείριση OLE](/slides/el/python-java/manage-ole/)*.
{{% /alert %}}

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Αφού οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για τη δημιουργία πίνακα περιεχομένων. 

Αυτό το δείγμα κώδικα δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Με την ιδιότητα [Hyperlink.setColorSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setColorSource) στην κλάση [Hyperlink](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/), μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε τις πληροφορίες χρώματος από τους υπερσυνδέσμους. Η δυνατότητα αυτή εισήχθη για πρώτη φορά στο PowerPoint 2019, οπότε οι αλλαγές που αφορούν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτός ο κώδικας δείγματος δείχνει μια λειτουργία όπου υπερσύνδεσμοι με διαφορετικά χρώματα προστίθενται στην ίδια διαφάνεια:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κατάργηση Υπερσυνδέσμων από Παρουσιάσεις**

### **Κατάργηση Υπερσυνδέσμων από Κείμενο**

Αυτός ο κώδικας Python δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε μια διαφάνεια παρουσίασης:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Κατάργηση Υπερσυνδέσμων από Σχήματα ή Πλαίσια**

Αυτός ο κώδικας Python δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε μια διαφάνεια παρουσίασης:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μεταβλητός Υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/) είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για τις παρακάτω ιδιότητες:

- [setTargetFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Το απόσπασμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και να επεξεργαστείτε το tooltip του αργότερα:
```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Αλλάζει το tooltip του υπερσυνδέσμου που έχει ήδη προστεθεί
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Υποστηριζόμενες Ιδιότητες στο HyperlinkQueries**

Μπορείτε να προσπελάσετε το [HyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/) από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/) υποστηρίζει τις παρακάτω μεθόδους και ιδιότητες: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;**

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση τεχνικά στοχεύει σε μια συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε μια ενότητα», συνήθως συνδέεστε με την πρώτη της διαφάνεια.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία του κύριου (master) διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του κύριου διαφάνειας και των διατάξεων υποστηρίζουν υπερσυνδέσμους. Τέτοιοι σύνδεσμοι εμφανίζονται στις υποδιαφάνειες και είναι κλικαρίψιμοι κατά τη διάρκεια της παρουσίασης.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Στα [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-java/convert-powerpoint-to-html/), ναι — οι σύνδεσμοι συνήθως διατηρούνται. Κατά την εξαγωγή σε [εικόνες](/slides/el/python-java/convert-powerpoint-to-png/) και [βίντεο](/slides/el/python-java/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν μεταφέρεται λόγω της φύσης αυτών των μορφών (πλαίσια raster/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).