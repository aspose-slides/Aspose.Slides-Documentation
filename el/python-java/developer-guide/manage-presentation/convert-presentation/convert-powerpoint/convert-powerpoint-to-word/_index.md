---
title: Μετατροπή Παρουσιών PowerPoint σε Έγγραφα Word με Python μέσω Java
linktitle: PowerPoint σε Word
type: docs
weight: 110
url: /el/python-java/convert-powerpoint-to-word/
keywords:
- Μετατροπή PowerPoint
- Μετατροπή παρουσίασης
- PowerPoint σε Word
- Παρουσίαση σε Word
- PPT σε Word
- PPTX σε Word
- ODP σε Word
- PowerPoint σε DOCX
- PPT σε DOCX
- PPTX σε DOCX
- PowerPoint σε DOC
- Αποθήκευση PPT ως DOCX
- Αποθήκευση PPTX ως DOCX
- Εξαγωγή PPT σε DOCX
- Εξαγωγή PPTX σε DOCX
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε Word με Python μέσω Java χρησιμοποιώντας Aspose.Slides και Aspose.Words, συνδυάζοντας εικόνες διαφανειών με επεξεργάσιμο κείμενο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας το Aspose.Slides for Python via Java μαζί με το Aspose.Words for Java. Το Aspose.Slides αποδίδει κάθε διαφάνεια και διαβάζει το κείμενό της, ενώ το Aspose.Words δημιουργεί το έγγραφο Word μέσω του JPype. Το Microsoft Office δεν απαιτείται.

Το παραγόμενο έγγραφο περιέχει μια εικόνα διαφάνειας ακολουθούμενη από επεξεργάσιμο κείμενο που εξάγεται από τα κορυφαίου επιπέδου αυτόματα σχήματα της διαφάνειας. Η εικόνα διατηρεί την οπτική εμφάνιση της διαφάνειας· μεμονωμένα σχήματα, γραφήματα και πίνακες δεν μετατρέπονται σε επεξεργάσιμα αντικείμενα Word. Το εξαγόμενο κείμενο δεν διατηρεί την αρχική μορφοποίηση ή θέση του κειμένου.

## **Μετατροπή PowerPoint σε Word**

1. Εγκαταστήστε [Aspose.Slides for Python via Java](/slides/el/python-java/installation/) και ένα συμβατό περιβάλλον εκτέλεσης Java.  
2. Κατεβάστε [Aspose.Words for Java](https://releases.aspose.com/words/java/). Τοποθετήστε το κύριο αρχείο JAR σε κατάλογο `lib` δίπλα στο σενάριό σας και μετονομάστε το σε `aspose-words.jar`, ή προσαρμόστε τη διαδρομή στο παράδειγμα ώστε να ταιριάζει με το αρχείο που κατεβάσατε.  
3. Τοποθετήστε την παρουσίαση εισόδου, `sample.pptx`, στον τρέχοντα κατάλογο εργασίας. Η διαδρομή `lib/aspose-words.jar` είναι επίσης σχετική με αυτόν τον κατάλογο.  
4. Εκτελέστε τον παρακάτω κώδικα Python για να δημιουργήσετε το `output.docx`.

Το παράδειγμα φορτώνει την πηγή με [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και αποδίδει τις διαφάνειες με [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage). Χρησιμοποιεί [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) από το Aspose.Words για να εισάγει τις εικόνες και το κείμενο στο έγγραφο Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Προσαρμόστε την εικόνα της διαφάνειας στο πλάτος της περιοχής κειμένου, διατηρώντας την αναλογία διαστάσεων.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Προσθέστε απλό κείμενο από τα αυτόματα σχήματα ανώτερου επιπέδου, συμπεριλαμβανομένων των πλαισίων κειμένου.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Κάθε διαφάνεια ξεκινά σε νέα σελίδα. Το μακρύ εξαγόμενο κείμενο ή οι ιδιαίτερα ψηλές εικόνες διαφάνειας μπορεί να απαιτούν πρόσθετες σελίδες. Ο κώδικας προσθέτει αλλαγές σελίδας μόνο μεταξύ διαφανειών και απελευθερώνει την παρουσίαση και τις αποδομένες εικόνες σε μπλοκ `finally`. Η JVM παραμένει διαθέσιμη για επόμενες μετατροπές στην ίδια διαδικασία Python.

## **Συχνές Ερωτήσεις**

**Ποιες βιβλιοθήκες απαιτούνται;**

Χρησιμοποιήστε Aspose.Slides for Python via Java, JPype, ένα συμβατό περιβάλλον εκτέλεσης Java και Aspose.Words for Java. Και οι δύο βιβλιοθήκες λειτουργούν στην ίδια JVM. Το Aspose.Slides διαχειρίζεται την παρουσίαση· το Aspose.Words γράφει το έγγραφο Word.

**Μπορώ να μετατρέψω αρχεία PPT και ODP, καθώς και PPTX;**

Ναι. Αντικαταστήστε το `sample.pptx` με αρχείο PPT ή ODP. Δείτε το [Supported File Formats](/slides/el/python-java/supported-file-formats/) για τις μορφές εισόδου παρουσίασης.

**Είναι όλο το περιεχόμενο της διαφάνειας επεξεργάσιμο στο Word;**

Όχι. Κάθε διαφάνεια εισάγεται ως στατική εικόνα, με απλό κείμενο από τα κορυφαίου επιπέδου αυτόματα σχήματα προστεμένο από κάτω. Το κείμενο εντός ομάδων, πινάκων, SmartArt και γραφημάτων, καθώς και οι σημειώσεις του παρουσιαστή, δεν εξάγονται από αυτό το παράδειγμα. Οι κινήσεις και οι μεταβάσεις δεν αναπαράγονται στο έγγραφο Word.

**Μπορώ να αποθηκεύσω ως DOC αντί για DOCX;**

Ναι. Αλλάξτε το όνομα του εξαγώμενου αρχείου σε `output.doc`. Το Aspose.Words επιλέγει τη μορφή εξόδου από την επέκταση του ονόματος αρχείου όταν χρησιμοποιείται αυτή η υπερφόρτωση αποθήκευσης.