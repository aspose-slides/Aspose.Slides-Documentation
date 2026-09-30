---
title: Προσαρμογή των Υπομνήσεων Διαγραμμάτων σε Παρουσιάσεις σε Android
linktitle: Υπόμνηση Διαγράμματος
type: docs
url: /el/androidjava/chart-legend/
keywords:
- υπόμνηση διαγράμματος
- θέση υπόμνησης
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τις υπομνήσεις διαγραμμάτων με το Aspose.Slides for Android via Java για να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήσεων."
---
## **Επισκόπηση**

Το Aspose.Slides for Android via Java προσφέρει επιλογές για προσαρμογή των υπομνήσεων των διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος μιας υπόμνησης, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρη την υπόμνηση, να μορφοποιήσετε μια ατομική εγγραφή υπόμνησης και να αποκρύψετε ή να επαναφέρετε τις επιλεγμένες εγγραφές.

Το τμήμα Συχνές ερωτήσεις καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένης της διάθεσης χώρου για την υπόμνηση, της εμφάνισης ετικετών πολλαπλών γραμμών και της κληρονομίας μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπόμνησης**

Χρησιμοποιήστε τις μεθόδους [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), και [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) της υπόμνησης για να καθορίσετε τη θέση και το μέγεθός της ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα στυλοβαθμικό γράφημα σε στήλες με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Διαίρετε τις επιθυμητές μετατοπίσεις και διαστάσεις της υπόμνησης με το πλάτος και το ύψος του διαγράμματος τις μετατρέπει σε σχετικές τιμές: η υπόμνηση μετατοπίζεται κατά 50 σημεία από την επάνω‑αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 κατά 100 σημεία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Εκφράστε τη θέση και το μέγεθος της υπόμνησης σε σχέση με το διάγραμμα.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπόμνησης**

Χρησιμοποιήστε το [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) της υπόμνησης για να αποκτήσετε πρόσβαση στη μορφοποίηση κειμένου της και χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για να ορίσετε το μέγεθος γραμματοσειράς σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο της υπόμνησης σε 20 σημεία. Επίσης απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και ορίζει το εύρος του από -5 έως 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Ατομικής Εγγραφής Υπόμνησης**

Χρησιμοποιήστε τη συλλογή που επιστρέφεται από τη μέθοδο [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) της υπόμνησης για να αποκτήσετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης εγγραφής. Οι δείκτες των εγγραφών είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη εγγραφή.

Αυτό το παράδειγμα δημιουργεί ένα στυλοβαθμικό γράφημα σε στήλες που τα προεπιλεγμένα δεδομένα του περιλαμβάνουν τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη εγγραφή υπόμνησης με έντονο, πλάγιο και κείμενο μπλε 20 σημείων.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Απόκρυψη Ατομικών Εγγραφών Υπόμνησης**

Για να εξαιρέσετε μια βοηθητική σειρά από την υπόμνηση ενώ διατηρείτε τα δεδομένα της ορατά, καλέστε το [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) με `true` μέσω του [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Αυτό αποκρύπτει μόνο την επιλεγμένη εγγραφή υπόμνησης· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Αντιθέτως, η κλήση του [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) με `false` αποκρύπτει ολόκληρη την υπόμνηση.

Το παρακάτω παράδειγμα δημιουργεί ένα στυλοβαθμικό γράφημα σε στήλες με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Αποκρύπτει την εγγραφή υπόμνησης της δεύτερης σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει την εγγραφή καλώντας το [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) με `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Επαναφέρετε την ίδια εγγραφή χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω εμφανίζει το ίδιο γράφημα με όλες τις εγγραφές ορατές και με τη δεύτερη εγγραφή κρυφή. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση διαγράμματος με όλες τις εγγραφές υπόμνησης ορατές και με τη Σειρά 2 κρυφή από την υπόμνηση· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε διαγράμματα στήλης, ράβδων και γραμμών, οι εγγραφές υπόμνησης προσδιορίζουν τις σειρές. Για διαγράμματα πίτας, προσδιορίζουν ατομικά σημεία δεδομένων (κοπές), επομένως χρησιμοποιήστε το [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) στην επιλεγμένη κοπή. Η API τεκμηριώνει αυτή τη μέθοδο σημείου δεδομένων για τους τύπους διαγραμμάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για διαγράμματα δακτυλίου, που δεν περιλαμβάνονται σε αυτή τη λίστα.

## **Συχνές ερωτήσεις**

**Μπορώ να κάνω το διάγραμμα να δεσμεύει χώρο για την υπόμνηση αντί να το επικαλύπτει;**

Ναι. Καλέστε το [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) με `false` για να δεσμεύσετε χώρο για την υπόμνηση αντί να επιτρέψετε την επικάλυψη της περιοχής σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπόμνησης πολλαπλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες μπορούν να αγκυροβοληθούν όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες αλλαγής γραμμής στα ονόματα των σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω την υπόμνηση να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τα γέμιστρα και τις γραμματοσειρές της υπόμνησης ακαθόριστα ώστε να κληρονομούν τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση παρακάμπτει τις αντίστοιχες ρυθμίσεις του θέματος.