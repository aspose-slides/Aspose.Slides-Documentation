---
title: Προσαρμογή Περιοχών Σχεδίασης Διαγραμμάτων Παρουσίασης σε Java
linktitle: Περιοχή Σχεδίασης
type: docs
url: /el/java/chart-plot-area/
keywords:
- διάγραμμα
- περιοχή σχεδίασης
- πλάτος περιοχής σχεδίασης
- ύψος περιοχής σχεδίασης
- μέγεθος περιοχής σχεδίασης
- λειτουργία διάταξης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις περιοχές σχεδίασης γραφημάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides for Java. Βελτιώστε τα οπτικά στοιχεία των διαφανειών σας χωρίς κόπο."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με την περιοχή σχεδίασης ενός διαγράμματος στο Aspose.Slides. Εξηγεί πώς να λάβετε τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης επικυρώνοντας τη διάταξη του διαγράμματος και στη συνέχεια αναγνώνοντας τις τιμές X, Y, πλάτους και ύψους.

Δείχνει επίσης πώς να ρυθμίσετε τη λειτουργία διάταξης της περιοχής σχεδίασης όταν η διάταξη ορίζεται χειροκίνητα, χρησιμοποιώντας `LayoutTargetType` για να ορίσετε εάν η περιοχή σχεδίασης υπολογίζεται από την εσωτερική της περιοχή ή από την εξωτερική περιοχή μαζί με τους άξονες και τις ετικέτες άξονα.

## **Λήψη Πλάτους και Ύψους της Περιοχής Σχεδίασης Διαγράμματος**
Το Aspose.Slides for Java παρέχει ένα απλό API για .  

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Καλέστε τη μέθοδο [IChart.validateChartLayout()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChart#validateChartLayout--) πριν λάβετε τις πραγματικές τιμές.
1. Λαμβάνει την πραγματική θέση X (αριστερά) του στοιχείου διαγράμματος σε σχέση με την πάνω αριστερή γωνία του διαγράμματος.
1. Λαμβάνει το πραγματικό πάνω του στοιχείου διαγράμματος σε σχέση με την πάνω αριστερή γωνία του διαγράμματος.
1. Λαμβάνει το πραγματικό πλάτος του στοιχείου διαγράμματος.
1. Λαμβάνει το πραγματικό ύψος του στοιχείου διαγράμματος.

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

## **Ορισμός Λειτουργίας Διάταξης της Περιοχής Σχεδίασης Διαγράμματος**
Το Aspose.Slides for Java παρέχει ένα απλό API για τον ορισμό της λειτουργίας διάταξης της περιοχής σχεδίασης του διαγράμματος. Οι μέθοδοι [**setLayoutTargetType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) και [**getLayoutTargetType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) έχουν προστεθεί στην κλάση [**ChartPlotArea**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ChartPlotArea) και στη διεπαφή [**IChartPlotArea**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartPlotArea). Εάν η διάταξη της περιοχής σχεδίασης ορίζεται χειροκίνητα, αυτή η ιδιότητα καθορίζει εάν η περιοχή σχεδίασης θα τοποθετηθεί με βάση το εσωτερικό της (χωρίς τους άξονες και τις ετικέτες άξονα) ή το εξωτερικό (συμπεριλαμβανομένων των αξόνων και των ετικετών άξονα). Υπάρχουν δύο δυνατές τιμές που ορίζονται στο enum [**LayoutTargetType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/el/java/com.aspose.slides/LayoutTargetType#Inner) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα προσδιορίσει το μέγεθος της περιοχής σχεδίασης, χωρίς τα σημεία σήμανσης και τις ετικέτες άξονα.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/el/java/com.aspose.slides/LayoutTargetType#Outer) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα προσδιορίσει το μέγεθος της περιοχής σχεδίασης, τα σημεία σήμανσης και τις ετικέτες άξονα.

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

**Σε ποιες μονάδες επιστρέχονται οι πραγματικές τιμές x, y, πλάτος και ύψος;**

Σε σημεία· 1 ίντσα = 72 σημεία. Αυτές είναι οι μονάδες συντεταγμένων του Aspose.Slides.

**Πώς διαφέρει η Περιοχή Σχεδίασης από την Περιοχή Διαγράμματος όσον αφορά το περιεχόμενο;**

Η Περιοχή Σχεδίασης είναι η περιοχή σχεδίασης των δεδομένων (γραμμές σειράς, γραμμές πλέγματος, γραμμές τάσης κ.λπ.); η Περιοχή Διαγράμματος περιλαμβάνει τα περιβάλλοντα στοιχεία (τίτλος, υπόμνημα κ.λπ.). Σε τρισδιάστατα διαγράμματα, η Περιοχή Σχεδίασης περιλαμβάνει επίσης τους τοίχους/το πάτωμα και τους άξονες.

**Πώς ερμηνεύονται οι τιμές x, y, πλάτους και ύψους της Περιοχής Σχεδίασης όταν η διάταξη είναι χειροκίνητη;**

Είναι κλάσματα (0–1) του συνολικού μεγέθους του διαγράμματος· σε αυτή τη λειτουργία η αυτόματη τοποθέτηση είναι απενεργοποιημένη και τα κλάσματα που ορίζετε χρησιμοποιούνται.

**Γιατί άλλαξε η θέση της Περιοχής Σχεδίασης μετά την προσθήκη/μετακίνηση του υπομνήματος;**

Το υπόμνημα βρίσκεται στην περιοχή διαγράμματος εκτός της Περιοχής Σχεδίασης, αλλά επηρεάζει τη διάταξη και τον διαθέσιμο χώρο, επομένως η Περιοχή Σχεδίασης μπορεί να μετακινηθεί όταν είναι ενεργή η αυτόματη τοποθέτηση. (Αυτή είναι η προεπιλεγμένη συμπεριφορά των διαγραμμάτων του PowerPoint.)