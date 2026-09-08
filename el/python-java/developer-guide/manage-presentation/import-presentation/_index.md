---
title: Εισαγωγή Παρουσιάσεων από PDF ή HTML σε Python μέσω Java
linktitle: Εισαγωγή Παρουσίασης
type: docs
weight: 60
url: /el/python-java/import-presentation/
keywords:
- εισαγωγή παρουσίασης
- εισαγωγή διαφάνειας
- εισαγωγή PDF
- εισαγωγή HTML
- PDF σε παρουσίαση
- PDF σε PPT
- PDF σε PPTX
- PDF σε ODP
- HTML σε παρουσίαση
- HTML σε PPT
- HTML σε PPTX
- HTML σε ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να εισάγετε περιεχόμενο PDF και HTML σε παρουσιάσεις PowerPoint σε Python μέσω Java με Aspose.Slides και να αποθηκεύετε τα αποτελέσματα ως αρχεία PPTX."
---
## **Εισαγωγή**

Το Aspose.Slides για Python μέσω Java μπορεί να μετατρέψει σελίδες PDF ή περιεχόμενο HTML σε διαφάνειες PowerPoint χωρίς το Microsoft PowerPoint. Η κλάση [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) παρέχει τις μεθόδους [addFromPdf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromPdf) και [addFromHtml](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromHtml) για την προσάρτηση εισαγόμενου περιεχομένου σε μία παρουσίαση.

Για μεγαλύτερο έλεγχο της τοποθέτησης του HTML, η μέθοδος [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertFromHtml) μπορεί να εισάγει δημιουργημένες διαφάνειες σε ένα δείκτη της συλλογής ή να αρχίσει να γεμίζει τον διαθέσιμο χώρο σε μια υπάρχουσα διαφάνεια. Το μεγάλο HTML σελιδοποιείται αυτόματα σε πρόσθετες διαφάνειες· η πηγή μπορεί να δοθεί ως συμβολοσυνάρτηση ή ροή, και εξωτερικοί πόροι μπορούν να φορτωθούν μέσω του [ExternalResourceResolver](https://reference.aspose.com/slides/el/python-java/aspose.slides/externalresourceresolver/) με βάση μια βασική URI. Ο πίνακας που επιστρέφεται από το [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) προσδιορίζει τις επηρεαζόμενες και τις νέες διαφάνειες.

## **Εισαγωγή από PDF**

Για να μετατρέψετε ένα έγγραφο PDF σε παρουσίαση PowerPoint, εισάγετε το περιεχόμενό του στη συλλογή διαφανειών και αποθηκεύστε το αποτέλεσμα ως αρχείο PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Δημιουργήστε ένα νέο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Καλέστε τη μέθοδο [addFromPdf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromPdf) με τη διαδρομή προς το αρχείο PDF.
3. Καλέστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx) για να γράψετε την παρουσίαση σε αρχείο PPTX.

Το παρακάτω παράδειγμα Python εισάγει ένα έγγραφο PDF και αποθηκεύει τις παραγόμενες διαφάνειες ως παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η προεπιλεγμένη κενή διαφάνεια παραμένει στην παρουσίαση επειδή η εισαγωγή προσθέτει διαφάνειες. Για να διατηρήσετε μόνο τις εισαγόμενες σελίδες, καθαρίστε τη συλλογή διαφανειών με το [SlideCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#clear) πριν από την εισαγωγή.

Η μέθοδος [addFromPdf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromPdf) επιστρέφει τις διαφάνειες που προσθέτει, κάτι χρήσιμο όταν χρειάζεται να επεξεργαστείτε μόνο τις εισαγόμενες διαφάνειες.

{{% alert title="Συμβουλή" color="success" %}}
Δοκιμάστε την δωρεάν εφαρμογή web [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) για να δείτε αυτή τη ροή μετατροπής σε δράση.
{{% /alert %}}

## **Εισαγωγή από HTML**

Το Aspose.Slides μπορεί επίσης να δημιουργήσει διαφάνειες από ένα έγγραφο HTML. Η πηγή μπορεί να δοθεί ως κείμενο HTML ή ροή. Τα παρακάτω βήματα χρησιμοποιούν ροή αρχείου:

1. Δημιουργήστε ένα νέο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Ανοίξτε το αρχείο HTML για ανάγνωση και περάστε τη ροή στη μέθοδο [addFromHtml](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Καλέστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx) για να γράψετε το αποτέλεσμα σε αρχείο PPTX.

Το παρακάτω παράδειγμα Python εισάγει ένα έγγραφο HTML και αποθηκεύει τις παραγόμενες διαφάνειες ως παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εισαγωγή Περιεχομένου HTML**

Χρησιμοποιήστε το [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertFromHtml) όταν οι διαφάνειες που δημιουργήθηκαν από HTML πρέπει να τοποθετηθούν σε συγκεκριμένη θέση αντί για προσθήκη στο τέλος. Ο δείκτης είναι μηδενικής βάσης και προσδιορίζει τη θέση όπου αρχίζει η εισαγωγή.

Το όρισμα `useSlideWithIndexAsStart` ελέγχει πώς ο εισαγωγέας χρησιμοποιεί αυτή τη θέση:

- Όταν είναι `False`, ο εισαγωγέας δημιουργεί νέες διαφάνειες στη συγκεκριμένη θέση και μετατοπίζει τις διαφάνειες που τις ακολουθούν.
- Όταν είναι `True`, ο εισαγωγέας αρχίζει να τοποθετεί το περιεχόμενο στον διαθέσιμο χώρο της υπάρχουσας διαφάνειας στη θέση αυτή. Εάν το HTML δεν χωράει, το Aspose.Slides το σελιδοποιεί αυτόματα και εισάγει επιπλέον διαφάνειες αμέσως μετά τη διαφάνεια έναρξης.

Το [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertFromHtml) επιστρέφει έναν πίνακα αντικειμένων [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/). Όταν η εισαγωγή ξεκινά σε νέες διαφάνειες, κάθε επιστραφόμενο στοιχείο είναι νεοδημιουργημένο. Όταν χρησιμοποιείται μια υπάρχουσα διαφάνεια ως σημείο έναρξης, ο πίνακας περιλαμβάνει αυτή τη διαφάνεια και, στη συνέχεια, τυχόν νέες διαφάνειες υπερχείλισης. Μπορείτε να εξετάσετε αυτόν τον πίνακα αντί να υπολογίσετε το επηρεαζόμενο εύρος από το συνολικό αριθμό των διαφανειών της παρουσίασης.

### **Εισαγωγή HTML ως Νέες Διαφάνειες**

Το παρακάτω παράδειγμα παρέχει το HTML ως συμβολοσυνάρτηση και εισάγει τις παραγόμενες διαφάνειες στον δείκτη συλλογής `1`. Η μετάδοση του `False` αφήνει τις υπάρχουσες διαφάνειες αμετάβλητες, εκτός από τη μετατόπιση τους για δημιουργία χώρου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Έναρξη σε Υπάρχουσα Διαφάνεια**

Το επόμενο παράδειγμα παρέχει το HTML μέσω ροής. Διατηρεί ένα σχήμα κεφαλίδας στην υπάρχουσα διαφάνεια πρότυπο, ξεκινά την εισαγωγή κάτω από την καταληφθείσα περιοχή και επιτρέπει στο μακρύ σώμα να συνεχιστεί σε νέες διαφάνειες.

Το HTML περιέχει επίσης σχετικό URL εικόνας. Ένας [ExternalResourceResolver](https://reference.aspose.com/slides/el/python-java/aspose.slides/externalresourceresolver/) αποκτά τον πόρο, ενώ η βασική URI ενημερώνει τον εισαγωγέα πώς να επιλύσει το `images/logo.png`. Σε αυτό το παράδειγμα, το αρχείο αναμένεται στο `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Προειδοποίηση" color="warning" %}}
Ένας μη περιορισμένος εξωτερικός επιλυτής πόρων μπορεί να διαβάσει τοπικούς ή δικτυακούς πόρους που αναφέρονται από το HTML. Για μη αξιόπιστες εισόδους, επικυρώστε και καθαρίστε τις διευθύνσεις URL πόρων έναντι λίστας επιτρεπόμενων σχημάτων, καταλόγων και κεντρικών υπολογιστών πριν την εισαγωγή του HTML.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να εντοπίζει πίνακες κατά την εισαγωγή PDF;**

Ναι. Δημιουργήστε ένα αντικείμενο [PdfImportOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfimportoptions/), καλέστε τη μέθοδο [setDetectTables](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfimportoptions/#setDetectTables) με `True` και περάστε τις επιλογές στο [addFromPdf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addFromPdf). Η ποιότητα της αναγνώρισης πινάκων εξαρτάται από τη δομή και την πολυπλοκότητα του πηγαίου PDF.

{{% alert title="Σημείωση" color="info" %}}
Μετά την εισαγωγή HTML, μπορείτε επίσης να εξάγετε τις διαφάνειες σε [images](/slides/el/python-java/convert-powerpoint-to-png/), [TIFF](/slides/el/python-java/convert-powerpoint-to-tiff/), ή [SVG](/slides/el/python-java/render-slide-as-svg/).
{{% /alert %}}