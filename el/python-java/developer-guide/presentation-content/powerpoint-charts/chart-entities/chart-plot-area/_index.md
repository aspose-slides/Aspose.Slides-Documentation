---
title: Προσαρμογή Περιοχών Σχεδίασης Διαγραμμάτων Παρουσίασης σε Python
linktitle: Περιοχή Σχεδίασης
type: docs
url: /el/python-java/chart-plot-area/
keywords:
- διάγραμμα
- περιοχή σχεδίασης
- πλάτος περιοχής σχεδίασης
- ύψος περιοχής σχεδίασης
- μέγεθος περιοχής σχεδίασης
- λειτουργία διάταξης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις περιοχές σχεδίασης των διαγραμμάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides for Python via Java. Βελτιώστε τα οπτικά στοιχεία των διαφανειών σας με ευκολία."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με την περιοχή σχεδίασης ενός διαγράμματος στο Aspose.Slides. Εξηγεί πώς να λάβετε τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης επικυρώνοντας τη διάταξη του διαγράμματος και στη συνέχεια διαβάζοντας τις τιμές X, Y, πλάτους και ύψους του.

Δημιουργεί επίσης παράδειγμα για το πώς να ρυθμίσετε τη λειτουργία διάταξης της περιοχής σχεδίασης όταν η διάταξη ορίζεται χειροκίνητα, χρησιμοποιώντας [LayoutTargetType](https://reference.aspose.com/slides/el/python-java/aspose.slides/layouttargettype/) για να ορίσετε εάν η περιοχή σχεδίασης υπολογίζεται από την εσωτερική της περιοχή ή από την εξωτερική της περιοχή μαζί με τους άξονες και τις ετικέτες των αξόνων.

## **Λήψη Πλάτους και Ύψους μιας Περιοχής Σχεδίασης Διαγράμματος**

Το Aspose.Slides for Python via Java παρέχει ένα απλό API για την ανάγνωση της πραγματικής θέσης και του μεγέθους της περιοχής σχεδίασης ενός διαγράμματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
4. Κλήστε τη μέθοδο [Chart.validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) πριν λάβετε τις πραγματικές τιμές.
5. Λάβετε τη πραγματική θέση X (αριστερά) του στοιχείου του διαγράμματος σε σχέση με την πάνω-αριστερή γωνία του διαγράμματος.
6. Λάβετε τη πραγματική θέση Y (πάνω) του στοιχείου του διαγράμματος σε σχέση με την πάνω-αριστερή γωνία του διαγράμματος.
7. Λάβετε το πραγματικό πλάτος του στοιχείου του διαγράμματος.
8. Λάβετε το πραγματικό ύψος του στοιχείου του διαγράμματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Ορισμός Λειτουργίας Διάταξης μιας Περιοχής Σχεδίασης Διαγράμματος**

Το Aspose.Slides for Python via Java παρέχει ένα απλό API για τον ορισμό της λειτουργίας διάταξης της περιοχής σχεδίασης του διαγράμματος. Οι μέθοδοι [setLayoutTargetType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) και [getLayoutTargetType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) είναι διαθέσιμες στην κλάση [ChartPlotArea](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/). Εάν η διάταξη της περιοχής σχεδίασης ορίζεται χειροκίνητα, αυτή η ρύθμιση καθορίζει εάν η περιοχή σχεδίασης θα τοποθετηθεί από το εσωτερικό της (εξαιρώντας άξονες και ετικέτες αξόνων) ή από το εξωτερικό της (συμπεριλαμβάνοντας άξονες και ετικέτες αξόνων). Υπάρχουν δύο πιθανές τιμές που ορίζονται στην απαρίθμηση [LayoutTargetType](https://reference.aspose.com/slides/el/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/el/python-java/aspose.slides/layouttargettype/#Inner) ορίζει ότι το μέγεθος της περιοχής σχεδίασης εξαιρεί τα σημεία σκαρφάλων και τις ετικέτες των αξόνων.
- [Outer](https://reference.aspose.com/slides/el/python-java/aspose.slides/layouttargettype/#Outer) ορίζει ότι το μέγεθος της περιοχής σχεδίασης περιλαμβάνει τα σημεία σκαρφάλων και τις ετικέτες των αξόνων.

Δειγματικός κώδικας παρέχεται παρακάτω.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι πραγματικές τιμές X, Y, πλάτος και ύψος;**

Σε μονάδες σημείων· 1 ίντσα = 72 σημεία. Αυτές είναι οι μονάδες συντεταγμένων του Aspose.Slides.

**Πώς διαφέρει η Περιοχή Σχεδίασης από την Περιοχή Διαγράμματος ως προς το περιεχόμενο;**

Η Περιοχή Σχεδίασης είναι η περιοχή σχεδίασης των δεδομένων (σειρές, γραμμές πλέγματος, γραμμές τάσης κ.λπ.); η Περιοχή Διαγράμματος περιλαμβάνει τα περιβάλλοντας στοιχεία (τίτλος, υπόμνημα κ.λπ.). Σε διαγράμματα 3Δ, η Περιοχή Σχεδίασης περιλαμβάνει επίσης τους τοίχους/το δάπεδο και τους άξονες.

**Πώς ερμηνεύονται οι τιμές X, Y, πλάτος και ύψος της Περιοχής Σχεδίασης όταν η διάταξη είναι χειροκίνητη;**

Αποτελούν κλάσματα (0–1) του συνολικού μεγέθους του διαγράμματος· σε αυτή τη λειτουργία, η αυτόματη τοποθέτηση είναι απενεργοποιημένη και χρησιμοποιούνται τα κλάσματα που έχετε ορίσει.

**Γιατί η θέση της Περιοχής Σχεδίασης άλλαξε μετά την προσθήκη ή την μετακίνηση του υπομνήματος;**

Το υπόμνημα βρίσκεται στην περιοχή του διαγράμματος εκτός της Περιοχής Σχεδίασης, αλλά επηρεάζει τη διάταξη και τον διαθέσιμο χώρο, έτσι η Περιοχή Σχεδίασης μπορεί να μετατοπιστεί όταν είναι ενεργή η αυτόματη τοποθέτηση. (Αυτή είναι η τυπική συμπεριφορά των διαγραμμάτων PowerPoint.)