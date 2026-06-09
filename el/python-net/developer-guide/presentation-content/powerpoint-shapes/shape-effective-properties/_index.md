---
title: Λήψη αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις με Python
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/python-net/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- φωτιστικό
- λοξότμηση σχήματος
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για Python μέσω .NET υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ ιδιοτήτων **τοπικές** και **αποτελεσματικές**. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.  
1. Στυλ κειμένου προτύπου σχήματος σε μια διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος διαθέτει ένα.  
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως αποδίδεται», ερευνά την αλυσίδα κληρονομικότητας και επιστρέφει τις **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `get_effective` στο τοπικό αντικείμενο μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/iportionformateffectivedata/), μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Η επανάκληση του `get_effective` μετά την αλλαγή της γονικής ή κληρονομικής μορφοποίησης μπορεί να ανανεώσει τα προσωρινά δεδομένα, και ένα προηγουμένως ληφθέν αντικείμενο ενδέχεται να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την ευθυγράμμιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Ο τύπος [ICameraEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες κάμερας. Μια παρουσίαση του [ICameraEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/icameraeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Λήψη αποτελεσματικών ιδιοτήτων φωτιστικού**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός φωτιστικού. Ο τύπος [ILightRigEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες φωτιστικού. Μια παρουσίαση του [ILightRigEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το φωτιστικό. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Λήψη αποτελεσματικών ιδιοτήτων λοξότμησης σχήματος**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες λοξότμησης ενός σχήματος. Ο τύπος [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάπλασης προσώπου για ένα σχήμα. Μια παρουσίαση του [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την άνω λοξότμηση ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Ο τύπος [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/itextframeformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Ο τύπος [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/itextstyleeffectivedata/) περιέχει αποτελεσματικές ιδιότητες στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Λήψη τιμής αποτελεσματικού ύψους γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής παρουσίασης.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη αποτελεσματικής μορφής γεμίσματος για πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τη αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα πίνακα. Ο τύπος [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ifillformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση σειράς, η μορφοποίηση σειράς έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, χρησιμοποιούνται οι ιδιότητες [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/icellformateffectivedata/) για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τη αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **Συχνές ερωτήσεις**

**Επιστρέφει η `get_effective` ένα στιγμιότυπο;**

Δεν είναι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη μορφοποίηση που υπολογίστηκε μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Μια επακόλουθη κλήση της `get_effective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα προσωρινά δεδομένα, ώστε ένα προηγουμένως ληφθέν αντικείμενο να μην θεωρείται βιώσιμο στιγμιότυπο.

**Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;**

Καλέστε ξανά τη `get_effective` μετά την αλλαγή της τοπικής μορφοποίησης, των γονικών στυλ, της μορφοποίησης διάταξης, της μορφοποίησης κύριας διαφάνειας ή των προεπιλογών επιπέδου παρουσίασης. Η επόμενη κλήση επαναεκτιμά τη ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Η αλλαγή ή η αφαίρεση μιας διάταξης/κύριας διαφάνειας επηρεάζει τις αποτελεσματικές ιδιότητες που έχουν ήδη ληφθεί;**

Ναι, αλλά η αλλαγή αντανακλάται στην επόμενη κλήση της `get_effective`. Εάν μια πηγή γονικής μορφοποίησης αλλάξει ή αφαιρεθεί, τα προηγουμένως ληφθέντα αποτελεσματικά δεδομένα μπορεί να είναι παλιά. Μόλις κληθεί ξανά η `get_effective`, το Aspose.Slides επαναεκτιμά το δέντρο μορφοποίησης και οι γράμματα, τα χρώματα, τα μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει εάν μια ιδιότητα δεν ορισθεί σε επίπεδο σχήματος, ούτε στη διάταξη/κύρια, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον μηχανισμό προεπιλογής, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η επιλυθείσα τιμή γίνεται μέρος των τρεχόντων αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω ποιο επίπεδο παρείχε το μέγεθος ή το είδος γραμματοσειράς;**

Ούτε άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, την κύρια διαφάνεια και το επίπεδο παρουσίασης για να εντοπίσετε πού εμφανίζεται η πρώτη ρητή δήλωση.

**Γιατί οι αποτελεσματικές τιμές μερικές φορές φαίνονται πανομοιότυπες με τις τοπικές;**

Επειδή η τοπική τιμή κατέληξε στο τελικό αποτέλεσμα (δεν απαιτήθηκε κληρονομικότητα ανώτερου επιπέδου). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε μόνο τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» μετά την εφαρμογή όλης της κληρονομικότητας, π.χ. για εναρμόνιση χρωμάτων, εσοχών ή μεγεθών. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν χρειάζεται να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εάν χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.