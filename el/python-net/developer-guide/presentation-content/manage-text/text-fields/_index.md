---
title: Διαχείριση πεδίων κειμένου σε παρουσιάσεις PowerPoint με Python
linktitle: Πεδία κειμένου
type: docs
weight: 52
url: /el/python-net/text-fields/
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
- Aspose.Slides
description: "Δημιουργία, επιθεώρηση, τροποποίηση και αφαίρεση πεδίων κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides for Python μέσω .NET. Διατήρηση μορφοποίησης και επαλήθευση αποθηκευμένων αρχείων PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα συνηθισμένο [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου έχει επίσης ένα [Field](https://reference.aspose.com/slides/el/python-net/aspose.slides/field/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε [Portion.field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/field/) για να τα διακρίνετε: είναι `None` για συνηθισμένο κείμενο. Η μέθοδος [Portion.add_field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/add_field/) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Διατηρήστε μια ετικέτα και τη δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει πεδία μέσα σε κείμενο, τη μορφοποίησή τους και την αποθήκευσή τους σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε [Manage Text](/slides/el/python-net/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το πάχος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, οπότε το κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι εμφανίζουν `True`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι κυριολεκτικό `1`. Οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και στα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

[FieldType](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/) παρέχει τις ακόλουθες προεγκατεστημένες τιμές. Περάστε τη κατάλληλη τιμή στη [add_field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/add_field/).

| Τιμή | Προορισμός |
|---|---|
| [slide_number](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/slide_number/) | Ο τρέχων αριθμός διαφάνειας. |
| [date_time](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time/) | Ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [date_time1](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time9/) | Προεγκατεστημένες μορφές ημερομηνίας ή συνδυασμένης ημερομηνίας/ώρας. |
| [date_time10](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time13/) | Προεγκατεστημένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ωρο ρολόι. |
| [header](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/header/) | Πεδίο κεφαλίδας· δείτε τους περιορισμούς υποκατάστασης και μορφής παρακάτω. |
| [footer](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/footer/) | Πεδίο υποσέλιδου. |

Για παράδειγμα, το [date_time3](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/date_time3/) αντιπροσωπεύει ημέρα, πλήρες όνομα μήνα και έτος στα Αγγλικά. Πρόκειται για προεγκατεστημένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας Python. Η [language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/language_id/) του τμήματος και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση συμβολοσυνόλου της [add_field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/add_field/) δέχεται έναν εσωτερικό ταυτοποιητή πεδίου. Χρησιμοποιήστε την όταν θέλετε να διατηρήσετε έναν ταυτοποιητή που παρείχε άλλη εφαρμογή και δεν υπάρχει προεγκατεστημένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/__init__/) από τον ταυτοποιητή. Η ιδιότητα [FieldType.internal_string](https://reference.aspose.com/slides/el/python-net/aspose.slides/fieldtype/internal_string/) εκθέτει αυτόν τον ταυτοποιητή για εξέταση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με το κείμενο εφεδρείας `Report-042`. Ο ταυτοποιητής δεν εγγράφει υπολογισμό: το Aspose.Slides δεν δημιουργεί αναφορικές ταυτότητες για άγνωστους τύπους. Η εφαρμογή που καταλαβαίνει αυτόν τον ταυτοποιητή πρέπει να παρέχει το νόημα και να ενημερώνει την τιμή.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Μετά από αυτόν τον γύρο PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μεταβίβαση μιας συμβολοσειράς όπως `%Y-%m-%d` θα ονομασίαζε έναν τύπο πεδίου· δεν θα ρυθμίζει προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Επιθεώρηση, Τροποποίηση και Διαγραφή Πεδίου Ημερομηνίας/Ώρας**

Διαβάστε και αλλάξτε ένα υπάρχον πεδίο μέσω του [Field.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/field/type/). Ελέγξτε ότι το πεδίο υπάρχει πριν προσπελάσετε τον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [Portion.remove_field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/remove_field/). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη σύνδεση με το πεδίο. Αν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, ορίστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίου ημερομηνίας/ώρας, δείτε το [Presentation.current_date_time](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/current_date_time/). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης όταν μετατρέπει ένα πεδίο σε συνηθισμένο κείμενο. Ένα πλέγμα ονομάτων μηνών στα Αγγλικά κρατά τη σταθερή ημερομηνία ανεξάρτητα από την τοπική ρύθμιση του συστήματος.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον τρέχοντα φάκελο εργασίας. Περιέχει δύο ονομαστικά σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, καθώς και συνηθισμένες ετικέτες κειμένου. Το παρακάτω παράδειγμα περιηγείται στα κορυφαία σχήματα κειμένου σε κανονικές διαφάνειες. Αλλάζει τα πεδία ημερομηνίας/ώρας σε μορφή μεγάλης ημερομηνίας και τα κάνει πλάγια, διατηρώντας τις υπόλοιπες μορφοποιήσεις. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Το δείγμα αναγνωρίζει τους ενσωματωμένους εσωτερικούς ταυτοποιητές `datetime` και `datetime1` έως `datetime13`. Ομάδες, πίνακες, σημειώσεις, διατάξεις και αρχικοί τύποι απαιτούν τη δική τους διασχίσιμο κείμενο και δεν περιλαμβάνονται σε αυτό το παράδειγμα.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Μετά το άνοιγμα ξανά, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα τους παραμένουν αμετάβλητα. Οι συνηθισμένες ετικέτες κειμένου δεν έχουν αλλάξει. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Δουλέψτε με το υπάρχον τμήμα όταν προσθέτετε, αλλάζετε τον τύπο ή αφαιρείτε ένα πεδίο. Αυτές οι ενέργειες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [Portion.portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/portion_format/) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως κάνουν τα παραδείγματα για χρώμα ή πλάγια.

Αποφύγετε την ανασύνθεση ολόκληρου πλαισίου κειμένου μόνο για την ενημέρωση ενός πεδίου: κάτι τέτοιο μπορεί να χάσει τα αρχικά όρια τμημάτων και τη μορφοποίηση τους. Επίσης, διακρίνετε τη ρητά ορισμένη μορφοποίηση από αυτή που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/python-net/text-formatting/) για πιο εκτεταμένες επιλογές μορφοποίησης.

## **Πεδία και Υποκατάστατα Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο είναι μέρος ενός τμήματος κειμένου. Ένα υποκατάστατο είναι σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα συνηθισμένο πλαίσιο κειμένου δεν μετατρέπει το σχήμα αυτό σε υποκατάστατο.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο υποκατάστατου και την ορατότητα στις διαφάνειες, διατάξεις και αρχικοί τύπους, συμπεριλαμβανομένης της διαδοχής σε εξαρτώμενες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και αν δεν χρησιμοποιείτε το υποκατάστατο αριθμού διαφάνειας. Αντίστροφα, η αλλαγή της ορατότητας του υποκατάστατου δεν αφαιρεί ένα πεδίο από ένα μη σχετικό πλαίσιο κειμένου.

Οι προεγκατεστημένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα υποκατάστατα ούτε παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει υποκατάστατο κεφαλίδας· οι κεφαλίδες ανήκουν σε σελίδες σημειώσεων και φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε αυθαίρετο σχήμα θα λάβει αυτόματα το κείμενο που έχει ρυθμιστεί μέσω του διαχειριστή υποκατάστατου. Για αυτήν τη ροή εργασιών, δείτε το [Presentation Headers and Footers](/slides/el/python-net/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το τελικό κείμενο μετά την αποθήκευση και το άνοιγμα ξανά. Η διατήρηση ενός ταυτοποιητή δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικούς ταυτοποιητές πεδίου μαζί με το κείμενο του πεδίου. Στους ελέγχους γύρου, οι προεγκατεστημένοι τύποι και ο προσαρμοσμένος ταυτοποιητής που χρησιμοποιήθηκε παραπάνω επέζησαν της αποθήκευσης και του ανοίγματος. Ο άγνωστος προσαρμοσμένος τύπος κράτησε το κείμενο εφεδρείας· δεν απέκτησε λογική αυτόματου υπολογισμού. Άλλη εφαρμογή μπορεί να αντιμετωπίσει μη υποστηριζόμενους ταυτοποιητές διαφορετικά. |
| PPT | Χρησιμοποιεί παλαιότερες αναπαραστάσεις πεδίου και έχει περιορισμένη συμβατότητα. Στους ελέγχους γύρου, οι αριθμοί διαφάνειας και τα προεγκατεστημένα πεδία ημερομηνίας/ώρας επέζησαν της αποθήκευσης και του ανοίγματος. Ένα προσαρμοσμένο πεδίο σε συνηθισμένο πλαίσιο κειμένου άνοιξε ξανά με τον ταυτοποιητή του αλλά με `*` ως κείμενο· ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή μη υποστηριζόμενα πλαίσια να διατηρούν το ορατό κείμενο. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και ορίστε ρητά την τιμή που θέλετε πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή προορισμού όταν η δική της επανυπολογισμός πεδίου αποτελεί μέρος της ροής εργασίας σας.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Εξετάστε το [Portion.field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/field/). Μια τιμή διαφορετική από `None` υποδεικνύει πεδίο· το εμφανιζόμενο κείμενο μόνο του δεν μπορεί να το αποδείξει.

**Αφαιρεί η διαγραφή ενός πεδίου το κείμενο ή τη μορφοποίηση του;**

Όχι. Η μέθοδος [remove_field](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/remove_field/) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Αναθέστε μια ρητή τιμή αφότου αν χρειάζεστε συγκεκριμένη παγωμένη ημερομηνία ή εφεδρική τιμή.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο υπολογισμού;**

Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος ταυτοποιητής δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας Python. Χρησιμοποιήστε έναν υποστηριζόμενο προεγκατεστημένο τύπο ή μορφοποιήστε την τιμή ως συνηθισμένο κείμενο.

**Γιατί ελέγχω ξανά μια παρουσίαση μετά την αποθήκευση;**

Οι ταυτοποιητές πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία προς επαλήθευση. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν ο ταυτοποιητής πεδίου παραμένει.