---
title: Προσαρμογή υπομνημάτων διαγραμμάτων σε παρουσιάσεις με Java
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/java/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα διαγραμμάτων με το Aspose.Slides για Java ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για την προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα και να εφαρμόσετε μορφοποίηση σε μια μεμονωμένη είσοδο υπομνήματος.

Επιπλέον, καλύπτει διάφορες σχετικές συμπεριφορές στις Συχνές Ερωτήσεις, συμπεριλαμβανομένης της χρήσης της λειτουργίας χωρίς επικάλυψη ώστε η περιοχή γραφήματος να κάνει χώρο για το υπόμνημα, της δυνατότητας τα μακρά ετικέτες υπομνήματος να αναδιπλώνονται ή να χρησιμοποιούν αλλαγές γραμμής, και της κληρονομίας της μορφοποίησης του υπομνήματος από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητά ρυθμίσεις κειμένου και γέμισης.

## **Τοποθέτηση Υπομνήματος**
Για να ορίσετε τις ιδιότητες του υπομνήματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Αποκτήστε αναφορά στη διαφάνεια.
- Προσθέστε ένα διάγραμμα στη διαφάνεια.
- Ορίστε τις ιδιότητες του υπομνήματος.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, ορίσαμε τη θέση και το μέγεθος του υπομνήματος γραφήματος.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λάβετε αναφορά στη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθέστε ένα γράφημα ομαδικής στήλης στη διαφάνεια
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Ορισμός ιδιοτήτων υπομνήματος
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
Το Aspose.Slides για Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς του υπομνήματος. Παρακαλώ ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Δημιουργήστε το προεπιλεγμένο διάγραμμα.
- Ορίστε το μέγεθος γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε την μέγιστη τιμή άξονα.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

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
Το Aspose.Slides για Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς των μεμονωμένων καταχωρήσεων υπομνήματος. Παρακαλώ ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Δημιουργήστε το προεπιλεγμένο διάγραμμα.
- Πρόσβαση στην καταχώρηση υπομνήματος.
- Ορίστε το μέγεθος γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε την μέγιστη τιμή άξονα.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

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

**Μπορώ να ενεργοποιήσω το υπόμνημα ώστε το διάγραμμα να κατανέμει αυτόματα χώρο γι’ αυτό αντί να το επικαλύπτει;**

Ναι. Χρησιμοποιήστε τη λειτουργία χωρίς επικάλυψη ([setOverlay(false)](https://reference.aspose.com/slides/el/java/com.aspose.slides/legend/#setOverlay-boolean-)); σε αυτήν την περίπτωση, η περιοχή γραφήματος θα μειωθεί ώστε να φιλοξενήσει το υπόμνημα.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλαπλών γραμμών;**

Ναι. Οι μακρές ετικέτες αναδιπλώνονται αυτόματα όταν ο χώρος είναι ανεπαρκής· επιβάλλονται αλλαγές γραμμής μέσω χαρακτήρων νέας γραμμής στο όνομα της σειράς.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίζετε ρητά χρώματα/γεμίσματα/γραμματοσειρές για το υπόμνημα ή το κείμενό του. Θα κληρονομήσουν το χρώμα από το θέμα και θα ενημερώνονται σωστά όταν αλλάζει ο σχεδιασμός.