---
title: Προσαρμογή Υπομνημάτων Διαγραμμάτων σε Παρουσιάσεις με Python
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/python-net/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα διαγραμμάτων με το Aspose.Slides for Python μέσω .NET για βελτιστοποίηση παρουσιάσεων PowerPoint και OpenDocument με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides for Python παρέχει πλήρη έλεγχο των υπομνημάτων διαγράμματος, ώστε να μπορείτε να κάνετε τις ετικέτες δεδομένων σαφείς και έτοιμες για παρουσίαση. Μπορείτε να εμφανίσετε ή να κρύψετε το υπόμνημα, να επιλέξετε τη θέση του στη διαφάνεια και να προσαρμόσετε τη διάταξη ώστε να αποτρέπεται η επικάλυψη με την περιοχή σχεδίασης. Το API σας επιτρέπει να διαμορφώσετε κείμενο και δείκτες, να ρυθμίσετε λεπτομερώς το padding και το φόντο, και να μορφοποιήσετε περιγράμματα και γεμίσματα ώστε να ταιριάζουν με το θέμα σας. Οι προγραμματιστές μπορούν επίσης να έχουν πρόσβαση σε μεμονωμένες καταχωρήσεις υπομνήματος για να τις μετονομάσουν ή να τις φιλτράρουν, διασφαλίζοντας ότι εμφανίζονται μόνο οι πιο σχετικές σειρές. Με αυτές τις δυνατότητες, τα διαγράμματά σας παραμένουν αναγνώσιμα, συνεπή και εναρμονισμένα με τα πρότυπα σχεδίασης της παρουσίασής σας.

## **Τοποθέτηση Υπομνήματος**

Με το Aspose.Slides, μπορείτε γρήγορα να ελέγξετε πού εμφανίζεται το υπόμνημα του διαγράμματος και πώς εντάσσεται στη διάταξη της διαφάνειας. Μάθετε πώς να τοποθετήσετε με ακρίβεια το υπόμνημα.

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Πάρτε μια αναφορά στη διαφάνεια.
1. Προσθέστε ένα διάγραμμα στη διαφάνεια.
1. Ορίστε τις ιδιότητες του υπομνήματος.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, θέτουμε τη θέση και το μέγεθος του υπομνήματος του διαγράμματος:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργήστε ένα παράδειγμα της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Πάρτε μια αναφορά στη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα συγκεντρωτικό γράφημα στηλών στη διαφάνεια.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Ορίστε τις ιδιότητες του υπομνήματος.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Το υπόμνημα ενός διαγράμματος πρέπει να είναι εξίσου ευανάγνωστο με τα δεδομένα που εξηγεί. Αυτή η ενότητα δείχνει πώς να προσαρμόσετε το μέγεθος γραμματοσειράς του υπομνήματος ώστε να ταιριάζει με την τυπογραφία της παρουσίασής σας και να βελτιώσετε την προσβασιμότητα.

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Δημιουργήστε ένα διάγραμμα.
1. Ορίστε το μέγεθος γραμματοσειράς.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Μεγέθους Γραμματοσειράς για Καταχώρηση Υπομνήματος**

Το Aspose.Slides σας επιτρέπει να ρυθμίσετε λεπτομερώς την εμφάνιση των υπομνημάτων διαγραμμάτων μορφοποιώντας μεμονωμένες καταχωρήσεις. Το παρακάτω παράδειγμα δείχνει πώς να στοχεύσετε σε ένα συγκεκριμένο στοιχείο υπομνήματος και να ορίσετε τις ιδιότητές του χωρίς να αλλάξετε το υπόλοιπο υπόμνημα.

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Δημιουργήστε ένα διάγραμμα.
1. Προσπελάστε μια καταχώρηση υπομνήματος.
1. Ορίστε τις ιδιότητες της καταχώρησης.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω το υπόμνημα έτσι ώστε το διάγραμμα να κατανεί μ' αυτό αυτόματα χώρο αντί να το επικάλυπται;**

Ναι. Χρησιμοποιήστε τη λειτουργία χωρίς επικάλυψη ([overlay](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/legend/overlay/) = `false`); σε αυτή την περίπτωση, η περιοχή σχεδίασης θα συρρικνωθεί για να φιλοξενήσει το υπόμνημα.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες τυλίγονται αυτόματα όταν ο χώρος είναι ανεπαρκής· υποστηρίζονται υποχρεωτικές αλλαγές γραμμής μέσω χαρακτήρων newline στο όνομα της σειράς.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίσετε ρητά χρώματα/γεμίσματα/γραμματοσειρές για το υπόμνημα ή το κείμενό του. Θα κληρονομήσουν το θέμα και θα ενημερώνονται σωστά όταν αλλάξει ο σχεδιασμός.