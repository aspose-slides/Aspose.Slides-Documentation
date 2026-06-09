---
title: Προσαρμογή λεζαντών γραφημάτων σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Λεζάντα γραφήματος
type: docs
url: /el/nodejs-java/chart-legend/
keywords:
- λεζάντα γραφήματος
- θέση λεζάντας
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις λεζάντες γραφημάτων με JavaScript και Aspose.Slides για Node.js ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση λεζάντας."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για προσαρμογή των λεζάντων γραφημάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να διαστάσετε μια λεζάντα, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρη τη λεζάντα και να εφαρμόσετε μορφοποίηση σε ξεχωριστή καταχώρηση λεζάντας.

Περιλαμβάνει επίσης αρκετές σχετικές συμπεριφορές στις Συχνές Ερωτήσεις, όπως η χρήση λειτουργίας μη‑επικάλυψης ώστε η περιοχή σχεδίασης να δημιουργεί χώρο για τη λεζάντα, η δυνατότητα να τυλίγονται μακροσκελείς ετικέτες λεζάντας ή να χρησιμοποιούν αλλαγές γραμμής, και η κληρονομικότητα μορφοποίησης της λεζάντας από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητά επιλογές κειμένου και γεμίσματος.

## **Τοποθέτηση Λεζάντας**

Για να ορίσετε τις ιδιότητες της λεζάντας, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Λάβετε αναφορά της διαφάνειας.
- Προσθέτοντας ένα διάγραμμα στη διαφάνεια.
- Ορίζοντας τις ιδιότητες της λεζάντας.
- Γράψτε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τη θέση και το μέγεθος για τη λεζάντα γραφήματος.

```javascript
// Δημιουργήστε μια περίπτωση της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λάβετε αναφορά της διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Προσθέστε ένα συγκεντρωμένο διάγραμμα στήλης στη διαφάνεια
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Ορίστε ιδιότητες λεζάντας
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Γράψτε την παρουσίαση στον δίσκο
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς της Λεζάντας**

Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς της λεζάντας. Παρακαλώ ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Δημιουργώντας το προεπιλεγμένο διάγραμμα.
- Ορίστε το μέγεθος γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε τη μέγιστη τιμή άξονα.
- Γράψτε την παρουσίαση στον δίσκο.

```javascript
// Δημιουργήστε μια περίπτωση της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς μεμονωμένης Λεζάντας**

Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς των μεμονωμένων καταχωρήσεων της λεζάντας. Παρακαλώ ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Δημιουργώντας το προεπιλεγμένο διάγραμμα.
- Πρόσβαση στην καταχώρηση λεζάντας.
- Ορίστε το μέγεθος γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε τη μέγιστη τιμή άξονα.
- Γράψτε την παρουσίαση στον δίσκο.

```javascript
// Δημιουργήστε μια περίπτωση της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω τη λεζάντα ώστε το γράφημα να διατηρεί αυτόματα χώρο για αυτήν αντί να την επικαλύπτει;**

Ναι. Χρησιμοποιήστε τη λειτουργία μη‑επικάλυψης ([setOverlay(false)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/legend/setoverlay/)); σε αυτή την περίπτωση, η περιοχή σχεδίασης θα συρρικνωθεί ώστε να προσαρμόσει τη λεζάντα.

**Μπορώ να δημιουργήσω ετικέτες λεζάντας πολλαπλών γραμμών;**

Ναι. Οι μακροσκελείς ετικέτες τυλίγονται αυτόματα όταν ο χώρος είναι ανεπαρκής· υποστηρίζονται υποχρεωτικές αλλαγές γραμμής μέσω χαρακτήρων νέας γραμμής στο όνομα της σειράς.

**Πώς μπορώ να κάνω τη λεζάντα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίζετε ρητά χρώματα, γεμίσματα ή γραμματοσειρές για τη λεζάντα ή το κείμενό της. Θα κληρονομήσουν το θέμα και θα ενημερώνονται σωστά όταν αλλάζει ο σχεδιασμός.