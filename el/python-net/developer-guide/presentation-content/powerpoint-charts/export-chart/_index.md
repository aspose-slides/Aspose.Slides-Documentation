---
title: Εξαγωγή Διαγραμμάτων Παρουσίασης με Python
linktitle: Εξαγωγή Διαγράμματος
type: docs
weight: 90
url: /el/python-net/export-chart/
keywords:
- διάγραμμα
- διάγραμμα σε εικόνα
- διάγραμμα ως εικόνα
- εξαγωγή εικόνας διαγράμματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε διαγράμματα παρουσίασης με Aspose.Slides για Python μέσω .NET, υποστηρίζοντας μορφές PPT, PPTX και ODP, και να απλοποιήσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να εξάγετε ένα διάγραμμα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα διάγραμμα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν πρέπει να επαναχρησιμοποιήσετε τα οπτικά στοιχεία του διαγράμματος εκτός μιας παρουσίασης PowerPoint.

## **Λήψη εικόνας διαγράμματος**
Aspose.Slides for Python via .NET παρέχει υποστήριξη για εξαγωγή εικόνας συγκεκριμένου διαγράμματος. Η παρακάτω ενδεικτική παράδειγμα παρέχεται. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα διάγραμμα ως διάνυσμα (SVG) αντί για εικόνα raster;**

Ναι. Ένα διάγραμμα είναι σχήμα, και το περιεχόμενό του μπορεί να αποθηκευτεί σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/write_as_svg/).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου διαγράμματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφορτώσεις απόδοσης εικόνας που επιτρέπουν τον καθορισμό του μεγέθους ή της κλίμακας — η βιβλιοθήκη υποστηρίζει την απόδοση αντικειμένων με δεδομένες διαστάσεις/κλίμακες.

**Τι πρέπει να κάνω αν οι γραμματοσειρές στις ετικέτες και στο υπόμνημα εμφανίζονται λανθασμένα μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/python-net/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsloader/) ώστε η απόδοση του διαγράμματος να διατηρεί τις μετρικές και την εμφάνιση του κειμένου.

**Τηρεί η εξαγωγή το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναι. Ο μηχανισμός απόδοσης του Aspose.Slides ακολουθεί τη διαμόρφωση της παρουσίασης (θέματα, στυλ, γεμίσματα, εφέ), ώστε η εμφάνιση του διαγράμματος να διατηρείται.

**Πού μπορώ να βρω τις διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από τις εικόνες διαγραμμάτων;**

Δείτε την ενότητα εξαγωγής του [API](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/)/[τεκμηρίωσης](/slides/el/python-net/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/el/python-net/convert-powerpoint-to-xps/), [HTML](/slides/el/python-net/convert-powerpoint-to-html/), κ.ά.) και τις σχετικές επιλογές απόδοσης.