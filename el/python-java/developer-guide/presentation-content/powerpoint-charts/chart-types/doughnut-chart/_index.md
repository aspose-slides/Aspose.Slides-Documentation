---
title: Προσαρμογή Διαγραμμάτων Δακτυλίου σε Παρουσιάσεις Χρησιμοποιώντας Python μέσω Java
linktitle: Διάγραμμα Δακτυλίου
type: docs
weight: 30
url: /el/python-java/doughnut-chart/
keywords:
- διάγραμμα δακτυλίου
- κεντρικό άνοιγμα
- μέγεθος τρύπας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα δακτυλίου στο Aspose.Slides για Python μέσω Java, υποστηρίζοντας μορφές PowerPoint για δυναμικές παρουσιάσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με ένα γράφημα δακτυλίου στο Aspose.Slides προσθέτοντας το γράφημα σε μια διαφάνεια, ορίζοντας το μέγεθος της κεντρικής τρύπας του και αποθηκεύοντας την παρουσίαση. Επικεντρώνεται στη μέθοδο [setDoughnutHoleSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) και επιδεικνύει τα βασικά βήματα που απαιτούνται για την προσαρμογή αυτού του τύπου γραφήματος μέσω κώδικα.

Περιέχει επίσης μια σύντομη Συχνές Ερωτήσεις (FAQ) που καλύπτει σχετικές περιπτώσεις γραφημάτων δακτυλίου, όπως η χρήση πολλαπλών σειρών για δημιουργία πολλαπλών δαχτυλιδιών, η εργασία με εκραγμένα (exploded) γραφήματα δακτυλίου, και η εξαγωγή ενός γραφήματος ως raster εικόνα ή SVG.

## **Καθορίστε το Κεντρικό Άνοιγμα σε Γράφημα Δακτυλίου**

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Python μέσω Java υποστηρίζει τον καθορισμό του μεγέθους της τρύπας σε ένα γράφημα δακτυλίου. Αυτή η ενότητα δείχνει πώς να ορίσετε το μέγεθος της τρύπας με ένα παράδειγμα.
{{% /alert %}}

Για να καθορίσετε το μέγεθος της τρύπας σε ένα γράφημα δακτυλίου, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Προσθέστε ένα γράφημα δακτυλίου στη διαφάνεια.
1. Καθορίστε το μέγεθος της τρύπας στο γράφημα δακτυλίου.
1. Γράψτε την παρουσίαση στο δίσκο.

Το παρακάτω παράδειγμα ορίζει το μέγεθος της τρύπας σε ένα γράφημα δακτυλίου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Γράψτε την παρουσίαση στο δίσκο.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να δημιουργήσω ένα πολυεπίπεδο γράφημα δακτυλίου με πολλαπλά δαχτυλίδια;**

Ναι. Προσθέστε πολλαπλές σειρές σε ένα μόνο γράφημα δακτυλίου — κάθε σειρά γίνεται ένα ξεχωριστό δαχτυλίδι. Η σειρά των δαχτυλιδιών καθορίζεται από τη σειρά των σειρών στη συλλογή.

**Υποστηρίζεται ένα «εκραγμένο» γράφημα δακτυλίου (ξεχωριστά τμήματα);**

Ναι. Υπάρχει τύπος γραφήματος Exploded Doughnut [chart type](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/) και ιδιότητα έκρηξης στα σημεία δεδομένων· μπορείτε να διαχωρίσετε μεμονωμένα τμήματα.

**Πώς μπορώ να λάβω μια εικόνα γραφήματος δακτυλίου (PNG/SVG) για μια αναφορά;**

Ένα γράφημα είναι ένα [shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/)· μπορείτε να το αποδώσετε σε μια [raster image](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) ή να εξάγετε το γράφημα ως εικόνα SVG.