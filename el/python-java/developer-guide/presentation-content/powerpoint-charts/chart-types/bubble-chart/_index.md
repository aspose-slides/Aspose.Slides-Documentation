---
title: Προσαρμογή Διαγραμμάτων Φυσαλίδων σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Διάγραμμα Φυσαλίδων
type: docs
url: /el/python-java/bubble-chart/
keywords:
- διάγραμμα φυσαλίδων
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- αναπαράσταση μεγέθους
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά διαγράμματα φυσαλίδων στο PowerPoint με το Aspose.Slides για Python μέσω Java, ώστε να ενισχύσετε εύκολα την οπτικοποίηση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με διαγράμματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: την κλιμάκωση του μεγέθους των φυσαλίδων μέσω της μεθόδου [setBubbleSizeScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) και τον έλεγχο του τρόπου παρουσίασης των τιμών μεγέθους των φυσαλίδων μέσω της μεθόδου [setBubbleSizeRepresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα διάγραμμα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την παρουσίαση του μεγέθους των φυσαλίδων ώστε να χρησιμοποιείται το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα FAQ που διευκρινίζει την υποστήριξη για τον τύπο διαγράμματος «Bubble with 3-D», σημειώνει ότι τα πρακτικά όρια του διαγράμματος εξαρτώνται από την απόδοση και την έκδοση του PowerPoint‑στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του διαγράμματος μέσω της μηχανής απόδοσης του Aspose.Slides.

## **Κλιμάκωση Μεγέθους Διαγράμματος Φυσαλίδων**
Το Aspose.Slides for Python via Java υποστηρίζει την κλιμάκωση του μεγέθους διαγράμματος φυσαλίδων μέσω των μεθόδων [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), και [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Το παρακάτω παράδειγμα δείχνει πώς να κλιμακώσετε τα μεγέθη των φυσαλίδων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Παράσταση Δεδομένων ως Μεγέθη Διαγράμματος Φυσαλίδων**
Οι μέθοδοι [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) και [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) διατίθενται στην κλάση [ChartSeriesGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartseriesgroup/). Η παράσταση μεγέθους φυσαλίδας καθορίζει πώς οι τιμές μεγέθους των φυσαλίδων εμφανίζονται στο διάγραμμα φυσαλίδων. Πιθανές τιμές είναι [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/el/python-java/aspose.slides/bubblesizerepresentationtype/#Area) και [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/el/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Η απαρίθμηση [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/el/python-java/aspose.slides/bubblesizerepresentationtype/) καθορίζει τους πιθανούς τρόπους παράστασης δεδομένων ως μεγέθη διαγράμματος φυσαλίδων. Το παρακάτω παράδειγμα δείχνει πώς να παρουσιάσετε τα μεγέθη των φυσαλίδων χρησιμοποιώντας το πλάτος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Υπάρχει υποστήριξη για «διάγραμμα φυσαλίδων με 3Δ εφέ» και πώς διαφέρει από ένα κανονικό;**

Ναι. Υπάρχει ξεχωριστός τύπος διαγράμματος, «Bubble with 3-D». Εφαρμόζει 3Δ στυλ στις φυσαλίδες, αλλά δεν προσθέτει πρόσθετο άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος είναι διαθέσιμος στην κλάση [chart type](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/).

**Υπάρχει όριο στον αριθμό των σειρών και των σημείων σε ένα διάγραμμα φυσαλίδων;**

Δεν υπάρχει σκληρό όριο σε επίπεδο API· οι περιορισμοί καθορίζονται από την απόδοση και την έκδοση του PowerPoint‑στόχου. Συνίσταται να διατηρείτε τον αριθμό των σημείων λογικό για να εξασφαλίζεται η αναγνωσιμότητα και η ταχύτητα απόδοσης.

**Πώς θα επηρεάσει η εξαγωγή την εμφάνιση ενός διαγράμματος φυσαλίδων (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του διαγράμματος· η απόδοση γίνεται από τη μηχανή Aspose.Slides. Για μορφές raster/vector ισχύουν οι γενικοί κανόνες απόδοσης γραφικών διαγράμματος (ανάλυση, anti‑aliasing), έτσι επιλέξτε επαρκή DPI για εκτύπωση.