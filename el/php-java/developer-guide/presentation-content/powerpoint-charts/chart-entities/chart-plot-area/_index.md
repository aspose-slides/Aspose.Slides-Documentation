---
title: Προσαρμογή περιοχής σχεδίασης διαγραμμάτων παρουσίασης σε PHP
linktitle: Περιοχή Σχεδίασης
type: docs
url: /el/php-java/chart-plot-area/
keywords:
- διάγραμμα
- περιοχή σχεδίασης
- πλάτος περιοχής σχεδίασης
- ύψος περιοχής σχεδίασης
- μέγεθος περιοχής σχεδίασης
- λειτουργία διάταξης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε περιοχές σχεδίασης διαγραμμάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java. Βελτιώστε τις οπτικές των διαφανειών σας άψογα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με την περιοχή σχεδίασης ενός διαγράμματος στο Aspose.Slides. Εξηγεί πώς να λάβετε τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης επικυρώνοντας τη διάταξη του διαγράμματος και στη συνέχεια διαβάζοντας τις τιμές X, Y, πλάτους και ύψους.

Επίσης δείχνει πώς να διαμορφώσετε τη λειτουργία διάταξης της περιοχής σχεδίασης όταν η διάταξη ορίζεται χειροκίνητα, χρησιμοποιώντας το `LayoutTargetType` για να ορίσετε εάν η περιοχή σχεδίασης υπολογίζεται από την εσωτερική της περιοχή ή από την εξωτερική περιοχή μαζί με τους άξονες και τις ετικέτες άξονα.

## **Λήψη Πλάτους και Ύψους Περιοχής Σχεδίασης Διαγράμματος**
Aspose.Slides for PHP via Java provides a simple API for .  

1. Δημιουργήστε μια παρουσία της κλάσης[Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) .
2. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
4. Καλέστε τη μέθοδο[Chart.validateChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/validatechartlayout/) πριν λάβετε τις πραγματικές τιμές.
5. Λαμβάνει την πραγματική θέση X (αριστερά) του στοιχείου διαγράμματος σε σχέση με την αριστερή άνω γωνία του διαγράμματος.
6. Λαμβάνει την πραγματική κορυφή του στοιχείου διαγράμματος σε σχέση με την αριστερή άνω γωνία του διαγράμματος.
7. Λαμβάνει το πραγματικό πλάτος του στοιχείου διαγράμματος.
8. Λαμβάνει το πραγματικό ύψος του στοιχείου διαγράμματος.

```php
  # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Λειτουργίας Διάταξης Περιοχής Σχεδίασης Διαγράμματος**
Aspose.Slides for PHP via Java provides a simple API to set the layout mode of the chart plot area. Methods[**setLayoutTargetType**](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) and[**getLayoutTargetType**](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) have been added to[**ChartPlotArea**](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartPlotArea) class. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in[**LayoutTargetType**](https://reference.aspose.com/slides/el/php-java/aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/el/php-java/aspose.slides/LayoutTargetType#Inner) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα καθορίζει το μέγεθος της περιοχής σχεδίασης, χωρίς να περιλαμβάνονται οι σημάνσεις και οι ετικέτες άξονα.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/el/php-java/aspose.slides/LayoutTargetType#Outer) - καθορίζει ότι το μέγεθος της περιοχής σχεδίασης θα καθορίζει το μέγεθος της περιοχής σχεδίασης, τις σημάνσεις και τις ετικέτες άξονα.

Δείγμα κώδικα δίνεται παρακάτω.

```php
  # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι πραγματικές τιμές x, y, πλάτους και ύψους;**

Σε points· 1 ίντσα = 72 points. Αυτές είναι οι μονάδες συντεταγμένων του Aspose.Slides.

**Πώς διαφέρει η Περιοχή Σχεδίασης από την Περιοχή Διαγράμματος όσον αφορά το περιεχόμενο;**

Η περιοχή σχεδίασης είναι η περιοχή σχεδίασης δεδομένων (σειρές, γραμμές πλέγματος, γραμμές τάσεων κ.λπ.). Η περιοχή διαγράμματος περιλαμβάνει τα περιβάλλοντα στοιχεία (τίτλος, υπόμνημα κ.λπ.). Σε 3D διαγράμματα, η περιοχή σχεδίασης περιλαμβάνει επίσης τους τοίχους/το δάπεδο και τους άξονες.

**Πώς ερμηνεύονται οι τιμές x, y, πλάτους και ύψους της περιοχής σχεδίασης όταν η διάταξη είναι χειροκίνητη;**

Αποτελούν κλασματικά (0–1) του συνολικού μεγέθους του διαγράμματος· σε αυτή τη λειτουργία, η αυτόματη τοποθέτηση είναι απενεργοποιημένη και χρησιμοποιούνται τα κλάσματα που έχετε ορίσει.

**Γιατί άλλαξε η θέση της περιοχής σχεδίασης μετά την προσθήκη/μετακίνηση του υπομνήματος;**

Το υπόμνημα βρίσκεται στην περιοχή διαγράμματος εκτός της περιοχής σχεδίασης, αλλά επηρεάζει τη διάταξη και τον διαθέσιμο χώρο, έτσι η περιοχή σχεδίασης μπορεί να μετακινηθεί όταν ισχύει η αυτόματη τοποθέτηση. (Αυτή είναι η τυπική συμπεριφορά των διαγραμμάτων PowerPoint.)