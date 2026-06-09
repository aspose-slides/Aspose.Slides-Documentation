---
title: Προσαρμογή υπομνημάτων διαγραμμάτων σε παρουσιάσεις στο Android
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/androidjava/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα διαγραμμάτων με το Aspose.Slides για Android μέσω Java ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για την προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα και να εφαρμόσετε μορφοποίηση σε μεμονωμένη καταχώριση υπομνήματος.

Καλύπτει επίσης διάφορες σχετικές συμπεριφορές στις Συχνές Ερωτήσεις, όπως η χρήση λειτουργίας χωρίς επικάλυψη ώστε η περιοχή σχεδίασης να κάνει χώρο για το υπόμνημα, η δυνατότητα αυτόματης αναδίπλωσης ή εισαγωγής αλλαγών γραμμής σε μακριές ετικέτες υπομνήματος, και η κληρονομιά μορφοποίησης υπομνήματος από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητές ρυθμίσεις κειμένου ή γεμίσματος.

## **Τοποθέτηση Υπομνήματος**
Για να ορίσετε τις ιδιότητες του υπομνήματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
- Αποκτήστε αναφορά στη διαφάνεια.
- Προσθήκη διαγράμματος στη διαφάνεια.
- Ορισμός των ιδιοτήτων του υπομνήματος.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λάβετε αναφορά στη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθέστε ένα διάγραμμα δοσμένων στηλών στη διαφάνεια
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Ορίστε τις ιδιότητες του υπομνήματος
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς του υπομνήματος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
- Δημιουργία του προεπιλεγμένου διαγράμματος.
- Ορισμός του μεγέθους γραμματοσειράς.
- Ορισμός ελάχιστης τιμής άξονα.
- Ορισμός μέγιστης τιμής άξονα.
- Αποθήκευση της παρουσίασης στον δίσκο.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένου Υπομνήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς των μεμονωμένων καταχωρίσεων υπομνήματος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) .
- Δημιουργία του προεπιλεγμένου διαγράμματος.
- Πρόσβαση στην καταχώριση του υπομνήματος.
- Ορισμός του μεγέθους γραμματοσειράς.
- Ορισμός ελάχιστης τιμής άξονα.
- Ορισμός μέγιστης τιμής άξονα.
- Αποθήκευση της παρουσίασης στον δίσκο.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω το υπόμνημα ώστε το διάγραμμα να διανέμει αυτόματα χώρο για αυτό αντί να το επικάλυπται;**

Ναι. Χρησιμοποιήστε τη λειτουργία χωρίς επικάλυψη ([setOverlay(false)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); σε αυτήν την περίπτωση, η περιοχή σχεδίασης θα μειωθεί ώστε να φιλοξενήσει το υπόμνημα.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες τυλίγονται αυτόματα όταν δεν υπάρχει αρκετός χώρος· η επιβολή αλλαγών γραμμής υποστηρίζεται μέσω χαρακτήρων νέας γραμμής στο όνομα της σειράς.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίζετε ρητά χρώματα/συμπληρώσεις/γραμματοσειρές για το υπόμνημα ή το κείμενό του. Θα κληρονομήσουν το θέμα και θα ενημερώνονται σωστά όταν η σχεδίαση αλλάξει.