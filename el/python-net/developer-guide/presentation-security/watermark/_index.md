---
title: "Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις με Python"
linktitle: "Υδατογράφημα"
type: docs
weight: 40
url: /el/python-net/watermark/
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
- "προσθήκη υδατογράφημα σε ODP"
- "αφαίρεση υδατογραφήματος από PPT"
- "αφαίρεση υδατογραφήματος από PPTX"
- "αφαίρεση υδατογραφήματος από ODP"
- "διαγραφή υδατογραφήματος από PPT"
- "διαγραφή υδατογραφήματος από PPTX"
- "διαγραφή υδατογραφήματος από ODP"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Μάθετε πώς να διαχειρίζεστε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με Python για να υποδείξετε πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Υδατογράφημα** σε μία παρουσίαση είναι σήμα κειμένου ή εικόνας που χρησιμοποιείται σε μία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για να αναγνωρίσει τον συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποφυγή παραβίασης πνευματικών δικαιωμάτων υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε ένα υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/python-net/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για να προσθέσετε υδατογραφήματα κειμένου, θα πρέπει να χρησιμοποιήσετε την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/), και για να προσθέσετε υδατογραφήματα εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογραφήματος με μια εικόνα. `PictureFrame` υλοποιεί την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Δεδομένου ότι το `TextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, περιβάλλεται σε ένα αντικείμενο [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) .

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία μόνο διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Η Διαφάνεια‑Κύρια (Slide Master) χρησιμοποιείται για την εφαρμογή ενός υδατογραφήματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στη Διαφάνεια‑Κύρια, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα θεωρείται συνήθως μη διαθέσιμο για επεξεργασία από άλλους χρήστες. Για να αποτραπεί η επεξεργασία του υδατογραφήματος (ή καλύτερα του γονικού σχήματος του υδατογραφήματος), το Aspose.Slides παρέχει λειτουργία κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε μια κανονική διαφάνεια ή σε μια Διαφάνεια‑Κύρια. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στη Διαφάνεια‑Κύρια, θα κλειδωθεί σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το βρείτε στα σχήματα της διαφάνειας με το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως υπάρχουν κοινά χαρακτηριστικά στα υδατογραφήματα, όπως κεντρική στοίχιση, περιστροφή, θέση μπροστά κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσετε στα παραδείγματα παρακάτω.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε ένα υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, στη συνέχεια να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/). Αυτός ο τύπος δεν κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), η οποία διαθέτει ευρύ σύνολο ιδιοτήτων για την ευέλικτη τοποθέτηση του υδατογραφήματος. Συνεπώς, το αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) περιβάλλεται σε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [add_text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/add_text_frame/#str) όπως φαίνεται παρακάτω.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να Χρησιμοποιήσετε τη Κλάση TextFrame](/slides/el/python-net/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογραφήματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε ένα υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslide/). Η υπόλοιπη λογική είναι η ίδια όπως όταν προσθέτετε υδατογράφημα σε μία μόνο διαφάνεια — δημιουργήστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και, στη συνέχεια, προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [add_text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να Χρησιμοποιήσετε το Slide Master](/slides/el/python-net/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**

Από προεπιλογή, το σχήμα ορθογωνίου έχει στυλ με χρώματα γεμίσματος και γραμμής. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαφανές.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογραφήματος κειμένου όπως φαίνεται παρακάτω.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογραφήματος, χρησιμοποιήστε αυτόν τον κώδικα:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Κεντράρισμα Υδατογραφήματος Κειμένου**

Μπορείτε να κεντράρετε το υδατογράφημα σε μία διαφάνεια, και για αυτό μπορείτε να κάνετε το εξής:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογράφημα Εικόνας σε Παρουσίαση**

Για να προσθέσετε ένα υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να κάνετε το εξής:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Εάν είναι απαραίτητο να αποτραπεί η επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε την ιδιότητα [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/auto_shape_lock/) στο σχήμα. Με αυτή την ιδιότητα, μπορείτε να προστατέψετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου του από επεξεργασία, και πολλά άλλα:

```py
# Κλείδωμα του σχήματος του υδατογραφήματος από τροποποίηση
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Μεταφορά Υδατογράφηματος εμπρός**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [ShapeCollection.reorder](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Για να το κάνετε αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατόν να φέρετε ένα σχήμα εμπρός ή να το στείλετε πίσω της διαφάνειας. Αυτή η δυνατότητα είναι ιδιαίτερα χρήσιμη εάν χρειάζεται να τοποθετήσετε ένα υδατογράφημα μπροστά από την παρουσίαση:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Ορισμός Περιστροφής Υδατογραφήματος**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετείται διαγώνια στη διαφάνεια:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε στο μέλλον να το προσπελάσετε για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος του υδατογραφήματος, αντιστοιχίστε το στην ιδιότητα [AutoShape.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα του υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [AutoShape.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/name/) για να το εντοπίσετε στα σχήματα της διαφάνειας. Έπειτα, περάστε το σχήμα υδατογραφήματος στη μέθοδο [ShapeCollection.remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ζωντανό Παράδειγμα**

Μπορεί να θέλετε να εξερευνήσετε τα δωρεάν εργαλεία **Aspose.Slides** [Προσθήκη Υδατογραφήματος](https://products.aspose.app/slides/el/watermark) και [Αφαίρεση Υδατογραφήματος](https://products.aspose.app/slides/el/watermark/remove-watermark) online.

![Online εργαλεία για προσθήκη και αφαίρεση υδατογραφημάτων](online_tools.png)

## **Συχνές Ερωτήσεις**

**Τι είναι ένα υδατογράφημα και γιατί να το χρησιμοποιήσω;**

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται στις διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, ενισχύει την αναγνωρισιμότητα του εμπορικού σήματος ή αποτρέπει τη μη εξουσιοδοτημένη χρήση παρουσιάσεων.

**Μπορώ να προσθέσω ένα υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides σας επιτρέπει να προσθέσετε ένα υδατογράφημα σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να περάσετε διαδοχικά όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφήματος μεμονωμένα.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογραφήματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Ποιοι τύποι εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλες.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφήματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνέπεια του εμπορικού σήματος.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφήματος;**

Μπορείτε να ρυθμίσετε τη θέση και τον προσανατολισμό του υδατογραφήματος τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του [shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/).