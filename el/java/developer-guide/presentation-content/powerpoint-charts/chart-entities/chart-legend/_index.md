---
title: Προσαρμογή Θρύλων Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Θρύλος Διαγράμματος
type: docs
url: /el/java/chart-legend/
keywords:
- θρύλος διαγράμματος
- θέση θρύλου
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσαρμόστε τους θρύλους διαγραμμάτων με το Aspose.Slides for Java για να βελτιώσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση θρύλου."
---
## **Επισκόπηση**

Aspose.Slides for Java παρέχει επιλογές για προσαρμογή θρύλων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να αλλάξετε το μέγεθος ενός θρύλου, να ορίσετε το μέγεθος γραμματοσειράς για όλο το θρύλο, να μορφοποιήσετε μια μεμονωμένη είσοδο θρύλου και να κρύψετε ή να επαναφέρετε επιλεγμένες εγγραφές.

Το FAQ καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένης της διάσπασης χώρου για το θρύλο, της εμφάνισης ετικετών πολλαπλών γραμμών και της κληρονόμησης μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Θρύλου**

Χρησιμοποιήστε τις μεθόδους [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), και [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) του θρύλου για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα συγκεντρωτικό γράφημα στηλών με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Η διαίρεση των επιθυμητών αποσυμπίεστων τιμών και διαστάσεων του θρύλου με το πλάτος και το ύψος του διαγράμματος τα μετατρέπει σε σχετικές τιμές: ο θρύλος είναι μετατοπισμένος κατά 50 μονάδες από την πάνω‑αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 × 100 μονάδες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Εκφράστε τη θέση και το μέγεθος του θρύλου σε σχέση με το γράφημα.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορίστε το Μέγεθος Γραμματοσειράς ενός Θρύλου**

Χρησιμοποιήστε το [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) του θρύλου για να έχετε πρόσβαση στη μορφοποίηση κειμένου του και χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για να ορίσετε το μέγεθος γραμματοσειράς σε μονάδες points.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του θρύλου σε 20 points. Επίσης, απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και ορίζει το εύρος του από -5 έως 10.

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

## **Ορίστε το Μέγεθος Γραμματοσειράς μιας Μεμονωμένης Εισόδου Θρύλου**

Χρησιμοποιήστε τη συλλογή που επιστρέφει η μέθοδος [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) του θρύλου για να έχετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης εισόδου. Οι δείκτες εισόδων είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη είσοδο.

Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωτικό γράφημα στηλών του οποίου τα προεπιλεγμένα δεδομένα περιλαμβάνουν τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη είσοδο θρύλου με έντονο, πλάγιο και μπλε κείμενο μεγέθους 20 points.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Απόκρυψη Μεμονωμένων Εισόδων Θρύλου**

Για να εξαιρέσετε μια βοηθητική σειρά από τον θρύλο ενώ τα δεδομένα της παραμένουν ορατά, καλέστε το [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) με `true` μέσω του [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Αυτό κρύβει μόνο την επιλεγμένη είσοδο θρύλου· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Η κλήση του [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) με `false`, αντιθέτως, κρύβει ολόκληρο τον θρύλο.

Το παρακάτω παράδειγμα δημιουργεί ένα συγκεντρωτικό γράφημα στηλών με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει τη δεύτερη σειρά του θρύλου (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει την είσοδο καλώντας το [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) με `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

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

    // Επαναφέρετε την ίδια είσοδο χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω δείχνει το ίδιο γράφημα με όλες τις εισόδους ορατές και με τη δεύτερη είσοδο κρυφή. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Σε γραφήματα στήλης, ράβδου και γραμμής, οι εισόδους θρύλου προσδιορίζουν σειρές. Σε πίτες, προσδιορίζουν μεμονωμένα σημεία δεδομένων (κομμάτια), οπότε χρησιμοποιήστε το [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) στην επιλεγμένη φέτα. Η τεκμηρίωση του API καλύπτει αυτή τη μέθοδο σημείου δεδομένων για τους τύπους διαγράμματος `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για διαγράμματα δακτυλίου, τα οποία δεν περιλαμβάνονται σε αυτή τη λίστα.

## **FAQ**

**Μπορώ να κάνω το γράφημα να διατηρεί χώρο για το θρύλο αντί να τον επικαλύπτει;**

Ναι. Καλέστε το [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) με `false` για να διατηρήσετε χώρο για το θρύλο αντί να επιτρέψετε την επικάλυψή του στην περιοχή σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες θρύλου πολλών γραμμών;**

Ναι. Οι μακρές ετικέτες μπορούν να αναδιπλωθούν όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες νέας γραμμής στα ονόματα σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς κάνω ώστε ο θρύλος να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τα γέμισματα και τις γραμματοσειρές του θρύλου ακαθόριστα ώστε να κληρονομούν τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση υπερισχύει των αντίστοιχων ρυθμίσεων του θέματος.