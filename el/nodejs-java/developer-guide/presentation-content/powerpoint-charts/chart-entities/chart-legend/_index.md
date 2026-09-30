---
title: Προσαρμογή των Υπόμνησεων Διαγραμμάτων σε Παρουσιάσεις με JavaScript
linktitle: Υπόμνηση Διαγράμματος
type: docs
url: /el/nodejs-java/chart-legend/
keywords:
- υπόμνηση διαγράμματος
- θέση υπόμνησης
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις υπομνήσεις διαγραμμάτων με το Aspose.Slides για Node.js μέσω Java ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήσεων."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java παρέχει επιλογές για την προσαρμογή των υπόμνησεων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να διαμορφώσετε το μέγεθος μιας υπόμνησης, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρη την υπόμνηση, να μορφοποιήσετε μια μεμονωμένη καταχώρηση υπόμνησης και να κρύψετε ή να επαναφέρετε επιλεγμένες καταχωρήσεις.

Το ΤΣΥ (Συχνές ερωτήσεις) καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένης της κράτησης χώρου για την υπόμνηση, της εμφάνισης ετικετών πολλαπλών γραμμών και της κληρονομιάς μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπόμνησης**

Χρησιμοποιήστε τις μεθόδους [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), και [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) της υπόμνησης για να καθορίσετε τη θέση και το μέγεθός της ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα συγκροτημένο στήλης γράφημα με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Διαιρώντας τις επιθυμητές μετατοπίσεις και διαστάσεις της υπόμνησης με το πλάτος και το ύψος του διαγράμματος, μετατρέπονται σε σχετικές τιμές: η υπόμνηση μετατοπίζεται κατά 50 σημεία από την επάνω αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 κατά 100 σημεία.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Δηλώστε τη θέση και το μέγεθος της υπόμνησης σε σχέση με το διάγραμμα.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπόμνησης**

Χρησιμοποιήστε το [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) της υπόμνησης για να έχετε πρόσβαση στη μορφοποίηση κειμένου και χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) για να ορίσετε το μέγεθος γραμματοσειράς σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο της υπόμνησης στα 20 σημεία. Επίσης, απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και ορίζει την περιοχή του από -5 έως 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένης Καταχώρησης Υπόμνησης**

Χρησιμοποιήστε τη συλλογή που επιστρέφεται από τη μέθοδο [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) της υπόμνησης για να αποκτήσετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης καταχώρησης. Οι δείκτες των καταχωρήσεων είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη καταχώρηση.

Αυτό το παράδειγμα δημιουργεί ένα συγκροτημένο στήλης γράφημα του οποίου τα προεπιλεγμένα δεδομένα περιλαμβάνουν τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη καταχώρηση της υπόμνησης με έντονη, πλάγια και γαλάζια γραφή 20 σημείων.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Απόκρυψη Μεμονωμένων Καταχωρήσεων Υπόμνησης**

Για να εξαιρέσετε μια βοηθητική σειρά από την υπόμνηση ενώ διατηρείτε τα δεδομένα της ορατά, καλέστε το [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) με `true` μέσω του [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Αυτό κρύβει μόνο τη συγκεκριμένη καταχώρηση υπόμνησης· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Αντίθετα, η κλήση του [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) με `false` κρύβει ολόκληρη την υπόμνηση.

Το παρακάτω παράδειγμα δημιουργεί ένα συγκροτημένο στήλης γράφημα με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει τη καταχώρηση υπόμνησης της δεύτερης σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει τη καταχώρηση καλώντας το [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) με `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Επαναφέρετε την ίδια καταχώρηση χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παρακάτω σύγκριση δείχνει το ίδιο γράφημα με όλες τις καταχωρήσεις ορατές και με τη δεύτερη καταχώρηση κρυφή. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση γραφήματος με όλες τις καταχωρήσεις υπόμνησης ορατές και με τη Σειρά 2 κρυφή από την υπόμνηση· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε γραφήματα στήλης, μπάρας και γραμμής, οι καταχωρήσεις υπόμνησης προσδιορίζουν τις σειρές. Για διαγράμματα πίτας, προσδιορίζουν μεμονωμένα σημεία δεδομένων (φέτες), επομένως χρησιμοποιήστε το [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) στην επιλεγμένη φέτα. Το API τεκμηριώνει αυτή τη μέθοδο σημείου δεδομένων για τους τύπους διαγραμμάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για διαγράμματα δακτυλίου, που δεν συμπεριλαμβάνονται σε αυτή τη λίστα.

## **Συχνές ερωτήσεις**

**Μπορώ να κάνω το γράφημα να κατανείμει χώρο για την υπόμνηση αντί να την επικαλύπτει;**

Ναι. Καλέστε το [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) με `false` για να κρατήσετε χώρο για την υπόμνηση αντί να επιτρέψετε την επικάλυψή της στην περιοχή σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπόμνησης πολλαπλών γραμμών;**

Ναι. Οι μακριές ετικέτες μπορούν να τυλίγονται όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες νέας γραμμής στα ονόματα των σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω την υπόμνηση να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τα γεμίσματα και τις γραμματοσειρές της υπόμνησης ακαθορισμένα ώστε να κληρονομεί τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση υπερισχύει των αντίστοιχων ρυθμίσεων του θέματος.