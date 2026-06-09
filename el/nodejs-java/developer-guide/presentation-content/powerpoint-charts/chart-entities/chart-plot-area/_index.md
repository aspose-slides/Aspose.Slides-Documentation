---
title: Προσαρμογή Περιοχών Σχεδίασης Διαγραμμάτων Παρουσίασης σε JavaScript
linktitle: Περιοχή Σχεδίασης
type: docs
url: /el/nodejs-java/chart-plot-area/
keywords:
- διάγραμμα
- περιοχή σχεδίασης
- πλάτος περιοχής σχεδίας
- ύψος περιοχής σχεδίασης
- μέγεθος περιοχής σχεδίασης
- λειτουργία διάταξης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις περιοχές σχεδίασης διαγραμμάτων σε παρουσιάσεις PowerPoint με JavaScript και Aspose.Slides για Node.js. Βελτιώστε οπτικά τις διαφάνειές σας χωρίς κόπο."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με την περιοχή σχεδίασης ενός διαγράμματος στο Aspose.Slides. Εξηγεί πώς να λάβετε τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης επικυρώνοντας τη διάταξη του διαγράμματος και στη συνέχεια διαβάζοντας τις τιμές X, Y, πλάτος και ύψος.

Επίσης, επιδεικνύει πώς να ρυθμίσετε τη λειτουργία διάταξης της περιοχής σχεδίασης όταν η διάταξη ορίζεται χειροκίνητα, χρησιμοποιώντας `LayoutTargetType` για να καθορίσετε εάν η περιοχή σχεδίασης υπολογίζεται από την εσωτερική της περιοχή ή από την εξωτερική περιοχή μαζί με τους άξονες και τις ετικέτες άξονα.

## **Λήψη Πλάτους, Ύψους της Περιοχής Σχεδίασης Γραφήματος**

Aspose.Slides for Node.js via Java provides a simple API for .  

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Καλέστε τη μέθοδο [Chart.validateChartLayout()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart#validateChartLayout--) πριν λάβετε τις πραγματικές τιμές.
1. Λαμβάνει την πραγματική θέση X (αριστερά) του στοιχείου του διαγράμματος σε σχέση με την αριστερή επάνω γωνία του διαγράμματος.
1. Λαμβάνει το πραγματικό πάνω μέρος του στοιχείου του διαγράμματος σε σχέση με την αριστερή επάνω γωνία του διαγράμματος.
1. Λαμβάνει το πραγματικό πλάτος του στοιχείου του διαγράμματος.
1. Λαμβάνει το πραγματικό ύψος του στοιχείου του διαγράμματος.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Λειτουργίας Διάταξης της Περιοχής Σχεδίασης Γραφήματος**

Aspose.Slides for Node.js via Java provides a simple API to set the layout mode of the chart plot area. Methods [**setLayoutTargetType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) and [**getLayoutTargetType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) have been added to [**ChartPlotArea**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartPlotArea) class and [**ChartPlotArea**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartPlotArea) class. Εάν η διάταξη της περιοχής σχεδίασης ορίζεται χειροκίνητα, αυτή η ιδιότητα καθορίζει εάν η περιοχή σχεδίασης θα διαταχθεί από το εσωτερικό της (χωρίς τους άξονες και τις ετικέτες τους) ή από το εξωτερικό (συμπεριλαμβανομένων των άξονων και των ετικετών τους). Υπάρχουν δύο πιθανές τιμές που ορίζονται στο enum [**LayoutTargetType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LayoutTargetType#Inner) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης καθορίζει το μέγεθος της περιοχής σχεδίασης, χωρίς τα σημεία σήμανσης και τις ετικέτες άξονα.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LayoutTargetType#Outer) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης καθορίζει το μέγεθος της περιοχής σχεδίασης, των σημείων σήμανσης και των ετικετών άξονα.

Sample code is given below.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι πραγματικές τιμές X, Y, Πλάτος και Ύψος;**

Σε μονάδες σημείου (points); 1 ίντσα = 72 σημεία. Αυτές είναι οι μονάδες συντεταγμένων του Aspose.Slides.

**Πώς διαφέρει η Περιοχή Σχεδίασης από την Περιοχή Διαγράμματος ως προς το περιεχόμενο;**

Η Περιοχή Σχεδίασης είναι η περιοχή σχεδίασης δεδομένων (σειρές, γραμμές πλέγματος, γραμμές τάσης κ.λπ.). Η Περιοχή Διαγράμματος περιλαμβάνει τα περιβάλλοντα στοιχεία (τίτλος, υπόμνημα κ.λπ.). Στα διαγράμματα 3D, η Περιοχή Σχεδίασης περιλαμβάνει επίσης τα τοιχώματα/πάτωμα και τους άξονες.

**Πώς ερμηνεύονται τα X, Y, Πλάτος και Ύψος της Περιοχής Σχεδίασης όταν η διάταξη είναι χειροκίνητη;**

Αποτελούν κλασματικά (0–1) του συνολικού μεγέθους του διαγράμματος· σε αυτή τη λειτουργία η αυτόματη τοποθέτηση είναι απενεργοποιημένη και χρησιμοποιούνται τα κλάσματα που έχετε ορίσει.

**Γιατί άλλαξε η θέση της Περιοχής Σχεδίασης μετά την προσθήκη/μετακίνηση του υπομνήματος;**

Το υπόμνημα βρίσκεται στην περιοχή διαγράμματος εκτός της Περιοχής Σχεδίασης, αλλά επηρεάζει τη διάταξη και τον διαθέσιμο χώρο, έτσι η Περιοχή Σχεδίασης μπορεί να μετακινηθεί όταν είναι ενεργή η αυτόματη τοποθέτηση. (Αυτή είναι η τυπική συμπεριφορά των διαγραμμάτων PowerPoint.)