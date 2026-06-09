---
title: Προσαρμογή περιοχών σχεδίασης διαγραμμάτων παρουσίασης σε Android
linktitle: Περιοχή Σχεδίασης
type: docs
url: /el/androidjava/chart-plot-area/
keywords:
- διάγραμμα
- περιοχή σχεδίασης
- πλάτος περιοχής σχεδίασης
- ύψος περιοχής σχεδίασης
- μέγεθος περιοχής σχεδίασης
- λειτουργία διάταξης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις περιοχές σχεδίασης διαγραμμάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java. Βελτιώστε οπτικά τις διαφάνειές σας αβίαστα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με την περιοχή σχεδίασης (plot area) ενός διαγράμματος στο Aspose.Slides. Εξηγεί πώς να λάβετε τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης επικυρώνοντας τη διάταξη του διαγράμματος και στη συνέχεια διαβάζοντας τις τιμές του X, Y, του πλάτους και του ύψους.

Δείχνει επίσης πώς να διαμορφώσετε τη λειτουργία διάταξης της περιοχής σχεδίασης όταν η διάταξη ορίζεται χειροκίνητα, χρησιμοποιώντας το `LayoutTargetType` για να καθορίσετε εάν η περιοχή σχεδίασης υπολογίζεται από την εσωτερική της περιοχή ή από την εξωτερική της περιοχή μαζί με τους άξονες και τις ετικέτες άξονα.

## **Λήψη Πλάτους και Ύψους της Περιοχής Σχεδίασης Διαγράμματος**
Το Aspose.Slides for Android μέσω Java παρέχει ένα απλό API για .

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Προσπελάστε την πρώτη διαφάνεια.
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
4. Καλέστε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChart#validateChartLayout--) πριν για να λάβετε τις πραγματικές τιμές.
5. Λαμβάνει την πραγματική θέση X (αριστερά) του στοιχείου διαγράμματος σε σχέση με την αριστερή άνω γωνία του διαγράμματος.
6. Λαμβάνει το πραγματικό επάνω μέρος του στοιχείου διαγράμματος σε σχέση με την αριστερή άνω γωνία του διαγράμματος.
7. Λαμβάνει το πραγματικό πλάτος του στοιχείου διαγράμματος.
8. Λαμβάνει το πραγματικό ύψος του στοιχείου διαγράμματος.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ρύθμιση της Λειτουργίας Διάταξης της Περιοχής Σχεδίασης Διαγράμματος**
Το Aspose.Slides for Android μέσω Java παρέχει ένα απλό API για να ορίσετε τη λειτουργία διάταξης της περιοχής σχεδίασης του διαγράμματος. Οι μέθοδοι [**setLayoutTargetType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) και [**getLayoutTargetType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) προστέθηκαν στην κλάση [**ChartPlotArea**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ChartPlotArea) και στη διεπαφή [**IChartPlotArea**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartPlotArea). Εάν η διάταξη της περιοχής σχεδίασης οριστεί χειροκίνητα, αυτή η ιδιότητα καθορίζει εάν η διάταξη της περιοχής σχεδίασης θα γίνει με την εσωτερική της (χωρίς άξονες και ετικέτες άξονα) ή εξωτερική (με άξονες και ετικέτες άξονα). Υπάρχουν δύο δυνατές τιμές που ορίζονται στην απαρίθμηση [**LayoutTargetType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LayoutTargetType#Inner) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα καθορίζει το μέγεθος της περιοχής, χωρίς τις σημαδούρες και τις ετικέτες άξονα.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LayoutTargetType#Outer) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα καθορίζει το μέγεθος της περιοχής, τις σημαδούρες και τις ετικέτες άξονα.

Δείγμα κώδικα παρέχεται παρακάτω.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι πραγματικές τιμές x, y, πλάτους και ύψους;**

Σε μονάδες point· 1 ίντσα = 72 point. Αυτές είναι οι μονάδες συντεταγμένων του Aspose.Slides.

**Πώς διαφέρει η Περιοχή Σχεδίασης από την Περιοχή Διαγράμματος όσον αφορά το περιεχόμενο;**

Η Περιοχή Σχεδίασης είναι η περιοχή σχεδίασης δεδομένων (σειρές, γραμμές πλέγματος, γραμμές τάσης κ.λπ.); η Περιοχή Διαγράμματος περιλαμβάνει τα περιβάλλοντα στοιχεία (τίτλος, υπόμνημα κ.λπ.). Σε διαγράμματα 3D, η Περιοχή Σχεδίασης περιλαμβάνει επίσης τους τοίχους/το δάπεδο και τους άξονες.

**Πώς ερμηνεύονται τα x, y, πλάτος και ύψος της Περιοχής Σχεδίασης όταν η διάταξη είναι χειροκίνητη;**

Αποτελούν κλάσματα (0–1) του συνολικού μεγέθους του διαγράμματος· σε αυτή τη λειτουργία, η αυτόματη τοποθέτηση είναι ανενεργή και χρησιμοποιούνται τα κλάσματα που έχετε ορίσει.

**Γιατί η θέση της Περιοχής Σχεδίασης άλλαξε μετά την προσθήκη/μετακίνηση του υπομνήματος;**

Το υπόμνημα βρίσκεται στην περιοχή διαγράμματος εκτός της Περιοχής Σχεδίασης, αλλά επηρεάζει τη διάταξη και τον διαθέσιμο χώρο, έτσι η Περιοχή Σχεδίασης μπορεί να μετακινηθεί όταν είναι ενεργή η αυτόματη τοποθέτηση. (Αυτή είναι η τυπική συμπεριφορά των διαγραμμάτων PowerPoint.)