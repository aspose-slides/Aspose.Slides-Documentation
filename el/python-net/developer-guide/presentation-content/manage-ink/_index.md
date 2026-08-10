---
title: Διαχείριση αντικειμένων μελάνης παρουσίασης σε Python
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/python-net/manage-ink/
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
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες των πινάκων, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνα με το Aspose.Slides για Python μέσω .NET."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνη μπορεί να χρησιμοποιηθεί για να τονίσει άλλα αντικείμενα, να δείξει συνδέσεις και διαδικασίες, και να τραβήξει την προσοχή σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Ο χώρος ονομάτων [aspose.slides.ink](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/) περιέχει τις κλάσεις που χρειάζονται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η κλάση [Ink](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/ink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ κανονικών αντικειμένων και αντικειμένων μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint αντιπροσωπεύονται συνήθως από αντικείμενα σχήματος. Στην πιο απλή μορφή, ένα σχήμα είναι ένα δοχείο που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του δοχείου, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε [Shape Layout Format](https://docs.aspose.com/slides/el/python-net/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (δοχείου) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του δοχείου καθορίζεται από τις τυπικές ιδιότητες [Ink.width](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/ink/width/) και [Ink.height](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι το βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς μιας πένας ενώ ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης καθορίζει τις συντεταγμένες X και Y κάθε σημείου δείγματος. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, δημιουργούν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινάκων για Σχέδιο**

Ένας πινάκας χρησιμοποιείται για το σχεδιασμό γραμμών που συνδέουν τα σημεία ενός ίχνους μελάνης. Οι ιδιότητες [InkBrush.color](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/inkbrush/color/) και [InkBrush.size](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/inkbrush/size/) ελέγχουν το χρώμα και το μέγεθός του.

### **Ορισμός Χρώματος Πινάκα Μελάνης**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε το χρώμα ενός πινάκα μελάνης:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Ορισμός Μεγέθους Πινάκα Μελάνης**

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε το μέγεθος ενός πινάκα μελάνης:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Γενικά, το πλάτος και το ύψος ενός πινάκα δεν ταιριάζουν, γι' αυτό το PowerPoint δεν εμφανίζει το μέγεθος του πινάκα (η αντίστοιχη ενότητα δεδομένων είναι θολή). Όταν το πλάτος και το ύψος ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του έτσι:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και ας εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Το δοχείο (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινάκων — θεωρεί πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Ως εκ τούτου, για τον προσδιορισμό της ορατής περιοχής ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινάκα των ιχνών του. Εδώ, το αντικείμενο-στόχος (το ίχνος του χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του δοχείου (πλαισίου). Όταν το μέγεθος του δοχείου αλλάζει, το μέγεθος του πινάκα παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Το Aspose.Slides παρέχει την κλάση [InkOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/) για να ελέγχετε πώς εμφανίζονται τα αντικείμενα μελάνης στην εξαχθείσα ή αποδομένη έξοδο. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να κρύψετε πλήρως τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας πινάκων μελάνης.

Οι επιλογές μελάνης είναι διαθέσιμες μέσω των επιλογών εξαγωγής ή απόδοσης για πολλούς τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Εικόνα διαφάνειας | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Οι ίδιες δύο ρυθμίσεις είναι διαθέσιμες μέσω αυτών των ιδιοτήτων:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/hide_ink/) καθορίζει εάν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή είναι `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) καθορίζει εάν μια λειτουργία μάσκας ερμηνεύεται ως διαφάνεια κατά την απόδοση ενός πινάκας μελάνης. Η προεπιλεγμένη τιμή είναι `True`; ορίστε το σε `False` για χρήση της λειτουργίας ROP αντί αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Ορίστε το [`InkOptions.hide_ink`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/hide_ink/) σε `True` όταν χρειάζεστε καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης.

Το παρακάτω παράδειγμα Python εξάγει μια παρουσίαση σε PDF ενώ κρύβει όλα τα αντικείμενα μελάνης:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση μιας Διαφάνειας ως Εικόνας**

Για να κρύψετε αντικείμενα μελάνης κατά την απόδοση διαφανειών ως bitmap εικόνες, ρυθμίστε το [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/ink_options/) και περάστε τις επιλογές απόδοσης στη μέθοδο [`Slide.get_image`](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/).

Το παρακάτω παράδειγμα Python αποδίδει την πρώτη διαφάνεια ως εικόνα PNG χωρίς αντικείμενα μελάνης:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ιδιότητα [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινάκων μελάνης. Η προεπιλεγμένη τιμή είναι `True`, η οποία χρησιμοποιεί διαφάνεια. Ορίστε την ιδιότητα σε `False` για χρήση της λειτουργίας ROP αντί αυτού.

Το παρακάτω παράδειγμα Python εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βασισμένη σε ROP για τις λειτουργίες μάσκας μελάνης:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [`TiffOptions.ink_options`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/ink_options/) όταν εξάγετε μια παρουσίαση ή αποδίδοντας μια διαφάνεια σε TIFF.

### **Επιλογή Ανάμεσα στην Απόκρυψη ή Διατήρηση της Μελάνης**

Ορίστε το [`InkOptions.hide_ink`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/hide_ink/) σε `True` όταν το εξαγόμενο αρχείο πρέπει να είναι μια καθαρή έκδοση μιας σχολιασμένης παρουσίασης, π.χ. ένα τελικό αντίγραφο που προορίζεται για διανομή χωρίς σημεία ανασκόπησης.

Αφήστε το [`InkOptions.hide_ink`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/hide_ink/) στην προεπιλεγμένη τιμή `False` όταν οι σημειώσεις μελάνης είναι μέρος του επιδιωκόμενου περιεχομένου, όπως σχόλια ανασκόπησης, χειρόγραφες σημειώσεις, επισήμανση ή σχέδια που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εκδόσεις ανασκόπησης και τελικής εξόδου από την ίδια παρουσίαση χωρίς τροποποίηση των αρχικών αντικειμένων μελάνης.

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος ενός υπάρχοντος ίχνος μελάνης;**

Ναι. Λάβετε το ίχνος από το [Ink.traces](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/ink/traces/), στη συνέχεια αλλάξτε το [InkTrace.brush](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/inktrace/brush/). Μπορείτε να ορίσετε τις ιδιότητες [InkBrush.color](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/inkbrush/color/) και [InkBrush.size](https://reference.aspose.com/slides/el/python-net/aspose.slides.ink/inkbrush/size/).

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Το [`InkOptions.hide_ink`](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/inkoptions/hide_ink/) επηρεάζει μόνο το αποδομένο ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποια μορφές εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες διαφανειών bitmap μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενικές πληροφορίες σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/python-net/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποδοτικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/python-net/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες σχετικά με την εξαγωγή PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/python-net/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες σχετικά με την εξαγωγή HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/python-net/convert-powerpoint-to-html/).
* Για λεπτομέρειες σχετικά με την εξαγωγή SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/python-net/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες σχετικά με την εξαγωγή TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/python-net/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες σχετικά με την απόδοση διαφάνειας σε εικόνα, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/python-net/convert-slide/).