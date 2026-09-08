---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε Python μέσω Java
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/python-java/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχέδιο
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- InkOptions
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες του πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνες με το Aspose.Slides για Python μέσω Java."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνη μπορεί να χρησιμοποιηθεί για την επισήμανση άλλων αντικειμένων, την εμφάνιση συνδέσεων και διαδικασιών, και την προσέλκυση προσοχής σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Το Aspose.Slides παρέχει τους τύπους που απαιτούνται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η κλάση [Ink](https://reference.aspose.com/slides/el/python-java/aspose.slides/ink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint συνήθως αντιπροσωπεύονται από αντικείμενα σχήματος. Στην πιο απλή του μορφή, ένα σχήμα είναι ένας περιέτης που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του περιέκτη, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε [Διάταξη Σχήματος](/slides/el/python-java/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint επεξεργάζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (του περιέκτη) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του περιέκτη καθορίζεται από τις τυπικές μεθόδους [Shape.getWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getWidth) και [Shape.getHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς μιας στιλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης καθορίζει τις συντεταγμένες X και Y κάθε σημείου δείγματος. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, δημιουργούν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχέδιο**

Ένα πινέλο χρησιμοποιείται για τη σχεδίαση γραμμών που συνδέουν τα σημεία ενός ίχνους μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, τα οποία αντιπροσωπεύονται από τις μεθόδους [InkBrush.getColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkbrush/#getColor) και [InkBrush.getSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkbrush/#getSize).

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε το μέγεθος ενός πινέλου μελάνης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, έτσι το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι απενεργοποιημένη). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του με αυτόν τον τρόπο:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Ο περιέτης (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — υποθέτει πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Κατά συνέπεια, για να προσδιοριστεί η ορατή περιοχή του ολόκληρου αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνού του. Εδώ, το αντικείμενο-στόχος (το ίχνος χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του περιέκτη (πλαισίου). Όταν το μέγεθος του περιέκτη αλλάζει, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Το Aspose.Slides παρέχει την κλάση [InkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/) για να ελέγξετε πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαγόμενη ή αποδοθείσα έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να κρύψετε εντελώς τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας του πινέλου μελάνης.

Οι επιλογές μελάνης διατίθενται μέσω των επιλογών εξαγωγής ή απόδοσης για πολλούς τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Οι ακόλουθες μέθοδοι της κλάσης [InkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/) εμφανίζουν τις ίδιες δύο ρυθμίσεις:

- [getHideInk](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#getHideInk) καθορίζει εάν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή είναι `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) καθορίζει εάν μια λειτουργία μάσκας ερμηνεύεται ως ακάλυπτη (opacity) κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή είναι `True`; καλέστε [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) με `False` για να χρησιμοποιήσετε τη λειτουργία ROP αντ' αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Για να δημιουργήσετε μια καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης, καλέστε [InkOptions.setHideInk](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#setHideInk) με `True`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση μιας Διαφάνειας ως Εικόνα**

Για να αποκρύψετε τα αντικείμενα μελάνης κατά την απόδοση των διαφανειών ως bitmap εικόνες, διαμορφώστε το [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/#getInkOptions) και περάστε τις επιλογές απόδοσης στο [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ρύθμιση [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ελέγχει τον τρόπο ερμηνείας των λειτουργιών μάσκας κατά την απόδοση των πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `True`, που χρησιμοποιεί ακάλυπτη (opacity). Για να χρησιμοποιήσετε τη λειτουργία ROP αντ' αυτού, καλέστε [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) με `False`.

Το παρακάτω παράδειγμα Python εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βασισμένη σε ROP για τις λειτουργίες μάσκας της μελάνης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions.getInkOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/#getInkOptions) όταν εξάγετε μια παρουσίαση ή αποδίδετε μια διαφάνεια σε TIFF.

### **Επιλέξτε Αν θα Αποκρύψετε ή Θα Διατηρήσετε τη Μελάνη**

Όταν χρειάζεστε μια καθαρή έκδοση μιας σχολιασμένης παρουσίασης για διανομή χωρίς σημάδια ελέγχου, καλέστε [InkOptions.setHideInk](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#setHideInk) με `True` κατά την εξαγωγή.

Αφήστε το [InkOptions.getHideInk](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#getHideInk) με την προεπιλεγμένη τιμή `False` όταν οι σημειώσεις μελάνης αποτελούν μέρος του προβλεπόμενου περιεχομένου, όπως σχόλια ελέγχου, χειρόγραφες σημειώσεις, επισήμανση ή σχέδια που πρέπει να παραμείνουν ορατά στην εξαγόμενη έξοδο. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εκδόσεις ελέγχου και τελικής εξόδου από την ίδια παρουσίαση χωρίς να τροποποιήσουν τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος ενός υπάρχοντος ίχνους μελάνης;**

Ναι. Λάβετε το ίχνος από το [Ink.getTraces](https://reference.aspose.com/slides/el/python-java/aspose.slides/ink/#getTraces), στη συνέχεια αλλάξτε το [InkTrace.getBrush](https://reference.aspose.com/slides/el/python-java/aspose.slides/inktrace/#getBrush). Καλέστε [InkBrush.setColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkbrush/#setColor) ή [InkBrush.setSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkbrush/#setSize) για να αλλάξετε το πινέλο.

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Η κλήση του [InkOptions.setHideInk](https://reference.aspose.com/slides/el/python-java/aspose.slides/inkoptions/#setHideInk) επηρεάζει μόνο το αποδιδόμενο ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποια μορφές εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να διαμορφώσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες διαφανειών bitmap μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενική ανάγνωση σχετικά με τα σχήματα, δείτε την ενότητα [Σχήματα PowerPoint](/slides/el/python-java/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποτελεσματικές τιμές, δείτε [Αποτελεσματικές Ιδιότητες Σχήματος](/slides/el/python-java/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες εξαγωγής PDF, δείτε [Μετατροπή PPT και PPTX σε PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες εξαγωγής HTML, δείτε [Μετατροπή Παρουσιάσεων PowerPoint σε HTML](/slides/el/python-java/convert-powerpoint-to-html/).
* Για λεπτομέρειες εξαγωγής SVG, δείτε [Απόδοση Διαφανειών Παρουσίασης ως SVG Εικόνες](/slides/el/python-java/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες εξαγωγής TIFF, δείτε [Μετατροπή Παρουσιάσεων PowerPoint σε TIFF](/slides/el/python-java/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες απόδοσης διαφάνειας-σε-εικόνα, δείτε [Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες](/slides/el/python-java/convert-slide/).