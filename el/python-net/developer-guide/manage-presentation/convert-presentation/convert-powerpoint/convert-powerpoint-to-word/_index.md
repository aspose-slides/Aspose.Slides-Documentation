---
title: "Μετατροπή παρουσιάσεων PowerPoint σε έγγραφα Word σε Python"
linktitle: "PowerPoint σε Word"
type: docs
weight: 110
url: /el/python-net/convert-powerpoint-to-word/
keywords:
- "PowerPoint σε DOCX"
- "OpenDocument σε DOCX"
- "παρουσίαση σε DOCX"
- "διαφάνεια σε DOCX"
- "PPT σε DOCX"
- "PPTX σε DOCX"
- "ODP σε DOCX"
- "PowerPoint σε DOC"
- "OpenDocument σε DOC"
- "παρουσίαση σε DOC"
- "διαφάνεια σε DOC"
- "PPT σε DOC"
- "PPTX σε DOC"
- "ODP σε DOC"
- "PowerPoint σε Word"
- "OpenDocument σε Word"
- "παρουσίαση σε Word"
- "διαφάνεια σε Word"
- "PPT σε Word"
- "PPTX σε Word"
- "ODP σε Word"
- "μετατροπή PowerPoint"
- "μετατροπή OpenDocument"
- "μετατροπή παρουσίασης"
- "μετατροπή διαφάνειας"
- "μετατροπή PPT"
- "μετατροπή PPTX"
- "μετατροπή ODP"
- "Python"
- "Aspose.Slides"
description: "Μάθετε πώς να μετατρέπετε εύκολα παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET. Ο οδηγός βήμα‑βήμα με δείγμα κώδικα Python παρέχει τη λύση για προγραμματιστές που θέλουν να βελτιστοποιήσουν τις ροές εργασίας των εγγράφων τους."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει μια λύση για προγραμματιστές σχετικά με τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας το Aspose.Slides for Python via .NET και το Aspose.Words for Python via .NET. Ο οδηγός βήμα‑βήμα σας καθοδηγεί σε κάθε στάδιο της διαδικασίας μετατροπής.

## **Μετατροπή Παρουσίασης σε Έγγραφο Word**

Ακολουθήστε τις παρακάτω οδηγίες για να μετατρέψετε μια παρουσίαση PowerPoint ή OpenDocument σε έγγραφο Word:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε ένα αρχείο παρουσίασης.
2. Δημιουργήστε αντικείμενα των κλάσεων [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) και [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) για να δημιουργήσετε ένα έγγραφο Word.
3. Ορίστε το μέγεθος σελίδας του εγγράφου Word ώστε να ταιριάζει με αυτό της παρουσίασης χρησιμοποιώντας την ιδιότητα [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Ορίστε τα περιθώρια στο έγγραφο Word χρησιμοποιώντας την ιδιότητα [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Περιηγηθείτε σε όλες τις διαφάνειες της παρουσίασης χρησιμοποιώντας την ιδιότητα [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/).
    - Δημιουργήστε μια εικόνα διαφάνειας χρησιμοποιώντας τη μέθοδο `get_image` από την κλάση [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) και αποθηκεύστε την σε ροή μνήμης.
    - Προσθέστε την εικόνα της διαφάνειας στο έγγραφο Word χρησιμοποιώντας τη μέθοδο `insert_image` από την κλάση [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).
6. Αποθηκεύστε το έγγραφο Word σε αρχείο.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση "sample.pptx" που φαίνεται ως εξής:

![PowerPoint presentation](PowerPoint.png)

Το παρακάτω παράδειγμα κώδικα Python δείχνει πώς να μετατρέψετε την παρουσίαση PowerPoint σε έγγραφο Word:

```py
import aspose.slides as slides
import aspose.words as words

# Φορτώστε ένα αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:

    # Δημιουργήστε αντικείμενα Document και DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Ορίστε το μέγεθος σελίδας στο έγγραφο Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Ορίστε τα περιθώρια στο έγγραφο Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Διασχίστε όλες τις διαφάνειες της παρουσίασης.
    for slide in presentation.slides:

        # Δημιουργήστε μια εικόνα διαφάνειας και αποθηκεύστε τη σε ροή μνήμης.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Προσθέστε την εικόνα της διαφάνειας στο έγγραφο Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Αποθηκεύστε το έγγραφο Word σε αρχείο.
    document.save("output.docx")
```

Το αποτέλεσμα:

![Word document](Word.png)

{{% alert color="primary" %}} 

Δοκιμάστε το **[Online PPT to Word Converter](https://products.aspose.app/slides/el/conversion/ppt-to-word)** για να δείτε τι μπορείτε να κερδίσετε μετατρέποντας παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια στοιχεία πρέπει να εγκατασταθούν για να μετατρέψετε παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word;**

Απαιτείται μόνο η προσθήκη των αντίστοιχων πακέτων για [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) και [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) στο έργο Python σας. Και τα δύο πακέτα λειτουργούν ως αυτόνομα API και δεν απαιτείται η εγκατάσταση του Microsoft Office.

**Υποστηρίζονται όλες οι μορφές παρουσίασης PowerPoint και OpenDocument;**

Το Aspose.Slides for Python .NET [υποστηρίζονται όλες οι μορφές παρουσίασης](/slides/el/python-net/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό εξασφαλίζει ότι μπορείτε να εργάζεστε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.