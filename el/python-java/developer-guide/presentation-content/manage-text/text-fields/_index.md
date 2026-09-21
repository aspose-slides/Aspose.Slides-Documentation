---
title: Διαχείριση Πεδία Κειμένου σε Παρουσιάσεις PowerPoint με Python μέσω Java
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/python-java/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- τμήμα κειμένου
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε, επιθεωρήστε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με Aspose.Slides για Python μέσω Java. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα συνηθισμένο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου διαθέτει επίσης ένα [Field](https://reference.aspose.com/slides/el/python-java/aspose.slides/field/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμό διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε το [Portion.getField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getField) για να τα διακρίνετε: επιστρέφει `None` για συνηθισμένο κείμενο. Το [Portion.addField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#addField) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Διατηρήστε μια ετικέτα και την δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία μέσα στο κείμενο, τη μορφοποίησή τους και την αποθήκευσή τους σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε [Manage Text](/slides/el/python-java/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, έπειτα ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο, το κείμενο και τη μορφοποίηση του πεδίου. Δεν απαιτείται αρχείο εισόδου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1`, και και τα δύο ελέγχοι εμφανίζουν `True`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι κυριολεκτικό `1`. Οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και τα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

[FieldType](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/) παρέχει τις ακόλουθες μεθόδους για απόκτηση προεγκατεστημένων τιμών. Μεταβιβάστε την κατάλληλη τιμή στο [addField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#addField).

| Μέθοδος | Σκοπός |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getSlideNumber) | Ο τρέχων αριθμός διαφάνειας. |
| [getDateTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime) | Η ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [getDateTime1](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime9) | Προκαθορισμένες μορφές ημερομηνίας ή συνδυασμένες μορφές ημερομηνίας/ώρας. |
| [getDateTime10](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime13) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ωρο ρολόι. |
| [getHeader](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getHeader) | Ένα πεδίο κεφαλίδας· δείτε τους περιορισμούς του placeholder και της μορφής παρακάτω. |
| [getFooter](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getFooter) | Ένα πεδίο υποσέλιδου. |

Για παράδειγμα, το [getDateTime3](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getDateTime3) αντιπροσωπεύει ημέρα, πλήρες όνομα μήνα και έτος στα Αγγλικά. Πρόκειται για προκαθορισμένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας Python. Η γλώσσα που ορίζεται με το [setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId) και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση συμβολοσειράς του [addField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#addField) δέχεται ένα εσωτερικό αναγνωριστικό πεδίου. Χρησιμοποιήστε την όταν διατηρείτε ένα αναγνωριστικό που παρέχεται από άλλη εφαρμογή και δεν έχει προεγκατεστημένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#FieldType) από το αναγνωριστικό. Το [FieldType.getInternalString](https://reference.aspose.com/slides/el/python-java/aspose.slides/fieldtype/#getInternalString) εμφανίζει αυτό το αναγνωριστικό για επιθεώρηση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο ειδικό για την εφαρμογή `custom-report-id` με το εναλλακτικό κείμενο `Report-042`. Το αναγνωριστικό δεν καταχωρεί κάποιον υπολογισμό: το Aspose.Slides δεν δημιουργεί ταυτοποιητές αναφορών για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτό το αναγνωριστικό πρέπει να παρέχει τη σημασία του και να ενημερώνει την τιμή του.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Μετά από αυτό το κύκλο PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μετάδοση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονόμιζε έναν τύπο πεδίου· δεν θα ρύθμιζε προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Έλεγχος, Τροποποίηση και Αφαίρεση Πεδίων Ημερομηνίας/Ώρας**

Αλλάξτε ένα υπάρχον πεδίο μέσω του [Field.setType](https://reference.aspose.com/slides/el/python-java/aspose.slides/field/#setType). Ελέγξτε ότι το πεδίο υπάρχει πριν αποκτήσετε τον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [Portion.removeField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#removeField). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη σύνδεση με το πεδίο. Αν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, αντιστοιχίστε αυτό το κείμενο μετά την κατάργηση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#setCurrentDateTime). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης όταν μετατρέπει ένα πεδίο σε συνηθισμένο κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον ενεργό φάκελο. Περιέχει δύο κείμενα σχήματα με ονόματα, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, μαζί με ετικέτες συνηθισμένου κειμένου. Το παρακάτω παράδειγμα διασχίζει τα κείμενα σχήματα επιπέδου‑κορυφής σε κανονικές διαφάνειες. Αλλάζει τα πεδία ημερομηνίας/ώρας σε μορφή «μακράς ημερομηνίας» και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις τους. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Το δείγμα αναγνωρίζει τα ενσωματωμένα εσωτερικά αναγνωριστικά `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και master απαιτούν περιήγηση στα δικά τους δοχεία κειμένου και βρίσκονται εκτός του πεδίου αυτού του παραδείγματος.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Χρησιμοποιήστε αγγλικά ονόματα μηνών ανεξάρτητα από τη γλώσσα του συστήματος.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Μετά το άνοιγμα, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα παραμένουν αμετάβλητα. Οι ετικέτες συνηθισμένου κειμένου παραμένουν αμετάβλητες. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Δουλέψτε με το υπάρχον τμήμα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [Portion.getPortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getPortionFormat) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως κάνουν τα παραδείγματα για χρώμα ή πλάγια.

Αποφύγετε την ανακατασκευή ολόκληρου πλαισίου κειμένου μόνο για να ενημερώσετε ένα πεδίο: κάτι τέτοιο μπορεί να χαθεί τα αρχικά όρια τμημάτων και τη δική τους μορφοποίηση. Επίσης διακρίνετε τη ρητά ορισμένη μορφοποίηση από αυτήν που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/python-java/text-formatting/) για πιο εκτεταμένες επιλογές μορφοποίησης.

## **Πεδία και Placeholder Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο είναι μέρος ενός τμήματος κειμένου. Ένα placeholder είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα συνηθισμένο πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε placeholder.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο placeholder και την ορατότητα στις διαφάνειες, διατάξεις και master, συμπεριλαμβανομένης της διαδοχής σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και αν δεν χρησιμοποιείτε το placeholder αριθμού διαφάνειας. Αντίστροφα, η αλλαγή της ορατότητας του placeholder δεν αφαιρεί ένα πεδίο από ένα μη σχετικό πλαίσιο κειμένου.

Οι προεγκατεστημένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα placeholders ή παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει placeholder κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και τα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα αποκτήσει αυτόματα το κείμενο που διαμορφώνεται μέσω ενός διαχειριστή placeholder. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/python-java/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το κείμενο που προκύπτει μετά την αποθήκευση και το άνοιγμα ξανά. Η διατήρηση ενός αναγνωριστικού δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικά αναγνωριστικά πεδίων μαζί με το κείμενο του πεδίου. Στους ελέγχους κυκλικής επανάληψης, οι προκαθορισμένοι τύποι και το προσαρμοσμένο αναγνωριστικό που χρησιμοποιήθηκε παραπάνω επιβίωσαν μετά την αποθήκευση και το άνοιγμα. Ο άγνωστος προσαρμοσμένος τύπος διατήρησε το εναλλακτικό του κείμενο· δεν απέκτησε λογική αυτόματου υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει τα μη υποστηριζόμενα αναγνωριστικά διαφορετικά. |
| PPT | Χρησιμοποιεί παλαιότερες αναπαραστάσεις πεδίων και έχει πιο περιορισμένη συμβατότητα. Στους ελέγχους κυκλικής επανάληψης, τα πεδία αριθμού διαφάνειας και τα προκαθορισμένα πεδία ημερομηνίας/ώρας επέμειναν μετά την αποθήκευση και το άνοιγμα. Ένα προσαρμοσμένο πεδίο σε συνηθισμένο πλαίσιο κειμένου διαφάνειας άνοιξε ξανά με το αναγνωριστικό του αλλά με `*` ως κείμενο· ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο επίσης παρήγαγε `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή σε μη υποστηριζόμενα συμφραζόμενα πεδίου που διατηρούν το ορατό τους κείμενο. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και αντιστοιχίστε ρητά την επιθυμητή τιμή πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή-στόχο όταν η δική της επανυπολογισμός των πεδίων αποτελεί μέρος της ροής εργασίας σας.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Επιθεωρήστε το [Portion.getField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getField). Μια τιμή διαφορετική από `None` προσδιορίζει πεδίο· το εμφανιζόμενο κείμενο μόνο του δεν μπορεί να το δείξει.

**Αφαιρεί η αφαίρεση πεδίου το κείμενο ή τη μορφοποίηση του;**

Όχι. Το [removeField](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#removeField) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Αν χρειάζεστε μια συγκεκριμένη παγωμένη ημερομηνία ή εναλλακτική τιμή, αντιστοιχίστε τη ρητά μετά.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**

Όχι. Καθορίζει έναν τύπο πεδίου. Ένα άγνωστο αναγνωριστικό δεν παρέχει αξιολογητή ή πρότυπο μορφοποίησης ημερομηνίας Python. Χρησιμοποιήστε έναν υποστηριζόμενο προκαθορισμένο τύπο ή μορφοποιήστε την τιμή εσείς ως συνηθισμένο κείμενο.

**Γιατί να ελεγχθεί ξανά μια παρουσίαση μετά την αποθήκευση;**

Τα αναγνωριστικά πεδίων, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία προς επαλήθευση. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν το αναγνωριστικό πεδίου παραμένει.