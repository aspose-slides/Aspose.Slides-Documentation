---
title: Διαχείριση Zoom σε Παρουσιάσεις με Python
linktitle: Zoom
type: docs
weight: 60
url: /el/python-net/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ σύνοψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε Zoom με Aspose.Slides για Python μέσω .NET — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σάς επιτρέπουν να πηδάτε προς και από συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης. Όταν κάνετε παρουσίαση, αυτή η δυνατότητα γρήγορης περιήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![επισκόπηση](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#Summary-Zoom).
* Για να εμφανίσετε μόνο τις επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Section Zoom](#Section-Zoom).

## **Zoom Διαφάνειας**

Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να περιηγηθείτε ελεύθερα μεταξύ των διαφανειών με τη σειρά που επιθυμείτε, χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε ακόμη να τα χρησιμοποιήσετε σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφάνειας σας βοηθούν να εμβαθύνετε σε πολλαπλά κομμάτια πληροφορίας ενώ αισθάνεστε ότι βρίσκεστε σε ένα ενιαίο καμβά. 

![slidezoomsel](slidezoomsel.png)

Για αντικείμενα slide zoom, το Aspose.Slides παρέχει την αποτύπωση [ZoomImageType](https://reference.aspose.com/slides/el/python-net/aspose.slides/zoomimagetype/) , την κλάση [ZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/zoomframe/) , και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom**
Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδεθείτε. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα σας δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθήκη νέων διαφανειών στην παρουσίαση
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Δημιουργία φόντου για τη δεύτερη διαφάνεια
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Δημιουργία πλαισίου κειμένου για τη δεύτερη διαφάνεια
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Δημιουργία φόντου για την τρίτη διαφάνεια
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Δημιουργία πλαισίου κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Προσθήκη αντικειμένων ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Αποθήκευση της παρουσίασης
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**
Με το Aspose.Slides for Python μέσω .NET, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με εικόνα διαφορετική από την προεπισκόπηση της διαφάνειας ως εξής: 
1.	Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` .
2.	Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο Presentation και θα χρησιμοποιηθεί για την επεξεργασία του πλαισίου.
5.	Προσθέστε πλαίσια zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python σας δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθήκη νέας διαφάνειας στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Δημιουργία φόντου για τη δεύτερη διαφάνεια
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Δημιουργία πλαισίου κειμένου για την τρίτη διαφάνεια
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Δημιουργία νέας εικόνας για το αντικείμενο zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Προσθήκη αντικειμένου ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Αποθήκευση της παρουσίασης
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Μορφοποίηση Πλαισίων Zoom**
Στις προηγούμενες ενότητες (παραπάνω), σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο πολύπλοκα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση των πλαισίων. Υπάρχουν διάφορες ρυθμίσεις μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` .
2.	Δημιουργήστε νέες διαφάνειες για σύνδεση. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο Presentation και θα χρησιμοποιηθεί για την επεξεργασία του πλαισίου.
6.	Ορίστε προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7.	Αλλάξτε τη μορφοποίηση γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8.	Αφαιρέστε το φόντο από την εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθήκη νέων διαφανειών στην παρουσίαση
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Δημιουργία φόντου για τη δεύτερη διαφάνεια
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Δημιουργία πλαισίου κειμένου για τη δεύτερη διαφάνεια
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Δημιουργία φόντου για την τρίτη διαφάνεια
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Δημιουργία πλαισίου κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Προσθήκη αντικειμένων ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Δημιουργία νέας εικόνας για το αντικείμενο zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Ορισμός προσαρμοσμένης εικόνας για το αντικείμενο zoomFrame1
    zoomFrame1.image = image

    # Ορισμός μορφοποίησης πλαισίου zoom για το αντικείμενο zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Μην εμφανίζετε φόντο για το αντικείμενο zoomFrame2
    zoomFrame2.show_background = False

    # Αποθήκευση της παρουσίασης
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom Ενότητας**

Το zoom ενότητας είναι ένας σύνδεσμος σε μια ενότητα της παρουσίασής σας. Μπορείτε να χρησιμοποιήσετε τα zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε. Ή μπορείτε να τα χρησιμοποιήσετε για να αναδείξετε πώς συνδέονται ορισμένα τμήματα της παρουσίασής σας. 

![seczoomsel](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/sectionzoomframe/) και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom ενότητας σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε μια νέα διαφάνεια. 
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python σας δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.sections.add_section("Section 1", slide)

    # Προσθέτει ένα αντικείμενο SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides for Python, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom ενότητας με διαφορετική εικόνα προεπισκόπηση διαφάνειας ως εξής: 

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και θα χρησιμοποιηθεί για την επεξεργασία του πλαισίου.
6.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει μια αναφορά στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
7.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python σας δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.sections.add_section("Section 1", slide)

    # Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Προσθέτει ένα αντικείμενο SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο πολύπλοκα πλαίσια zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και θα χρησιμοποιηθεί για την επεξεργασία του πλαισίου.
8.	Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο πλαίσιο zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από τη συνδεδεμένη ενότητα*.
10.	Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου πλαίσιου zoom ενότητας.
11.	Αλλάξτε τη μορφή γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12.	Αλλάξτε τη διάρκεια μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.sections.add_section("Section 1", slide)

    # Προσθέτει αντικείμενο SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Μορφοποίηση για SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom Σύνοψης**

Το zoom σύνοψης είναι σαν μια σελίδα προορισμού όπου όλα τα κομμάτια της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν κάνετε παρουσίαση, μπορείτε να χρησιμοποιήσετε το zoom για να περάσετε από ένα σημείο της παρουσίασης σε άλλο με οποιαδήποτε σειρά επιθυμείτε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε ενότητες ή να επανεξερευνήσετε τμήματα της παρουσίασής σας χωρίς να διακόψετε τη ροή της. 

![εικόνα_επισκόπηση](summaryzoom.png)

Για αντικείμενα zoom σύνοψης, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomsection/), και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomsectioncollection/) καθώς και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/) .

### **Δημιουργία Zoom Σύνοψης**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σύνοψης σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε το πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python σας δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σύνοψης σε μια διαφάνεια:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Δημιουργία πίνακα διαφανειών
    for slideNumber in range(5):
        #Προσθήκη νέων διαφανειών στην παρουσίαση
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Δημιουργία φόντου για τη διαφάνεια
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Δημιουργία πλαισίου κειμένου για τη διαφάνεια
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Δημιουργία αντικειμένων zoom για όλες τις διαφάνειες στην πρώτη διαφάνεια
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Ορισμός της ιδιότητας ReturnToParent για επιστροφή στην πρώτη διαφάνεια
        zoomFrame.return_to_parent = True

    # Αποθήκευση της παρουσίασης
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Σύνοψης**

Όλες οι ενότητες σε ένα πλαίσιο zoom σύνοψης αναπαρίστανται από αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomsection/) , τα οποία αποθηκεύονται στο αντικείμενο [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomsectioncollection/) . Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας zoom σύνοψης μέσω της κλάσης [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/summaryzoomsectioncollection/) ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4.	Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5.	Προσθέστε την δημιουργημένη ενότητα στο πλαίσιο zoom σύνοψης.
6.	Αφαιρέστε την πρώτη ενότητα από το πλαίσιο zoom σύνοψης.
7.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα πλαίσιο zoom σύνοψης:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.sections.add_section("Section 1", slide)

    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.sections.add_section("Section 2", slide)

    # Προσθέτει αντικείμενο SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα ενότητα στην παρουσίαση
    section3 = pres.sections.add_section("Section 3", slide)

    # Προσθέτει μια ενότητα στο Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Αφαιρεί ενότητα από το Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Μορφοποίηση Ενοτήτων Zoom Σύνοψης**

Για να δημιουργήσετε πιο πολύπλοκα αντικείμενα ενότητας zoom σύνοψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom σύνοψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom σύνοψης σε ένα πλαίσιο zoom σύνοψης ως εξής:

1.	Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4.	Λάβετε ένα αντικείμενο ενότητας zoom σύνοψης για το πρώτο αντικείμενο από το `SummaryZoomSectionCollection` .
5.	Δημιουργήστε ένα αντικείμενο `PPImage` προσθέτοντας μια εικόνα στη συλλογή images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) που θα χρησιμοποιηθεί για την επεξεργασία του πλαισίου.
6.	Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο zoom ενότητας.
7.	Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από τη συνδεδεμένη ενότητα*.
8.	Αλλάξτε τη μορφή γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
9.	Αλλάξτε τη διάρκεια μετάβασης.
10.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα Python δείχνει πώς να αλλάξετε τη μορφοποίηση για ένα αντικείμενο ενότητας zoom σύνοψης:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.sections.add_section("Section 1", slide)

    #Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.sections.add_section("Section 2", slide)

    # Προσθέτει αντικείμενο SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Παίρνει το πρώτο αντικείμενο SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Μορφοποίηση για το αντικείμενο SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη 'γονική' διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Το [πλαίσιο Zoom](https://reference.aspose.com/slides/el/python-net/aspose.slides/zoomframe/) ή η [ενότητα](https://reference.aspose.com/slides/el/python-net/aspose.slides/sectionzoomframe/) έχει συμπεριφορά `return_to_parent` που, όταν ενεργοποιηθεί, επιστρέφει τους θεατές στην αρχική διαφάνεια μετά την επίσκεψη στο περιεχόμενο-στόχο.

**Μπορώ να ρυθμίσω την 'ταχύτητα' ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει τον ορισμό μιας `transition_duration` ώστε να ελέγχετε πόσο χρόνο διαρκεί η κίνηση μετάβασης.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός API που να τεκμηριώνεται. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις επιδόσεις του θεατή. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και το χρόνο απόδοσης.