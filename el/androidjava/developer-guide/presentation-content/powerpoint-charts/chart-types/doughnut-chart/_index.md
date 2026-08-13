---
title: Προσαρμογή γραφημάτων δακτυλίου σε παρουσιάσεις στο Android
linktitle: Διάγραμμα Δακτυλίου
type: docs
weight: 30
url: /el/androidjava/doughnut-chart/
keywords:
- διάγραμμα δακτυλίου
- κεντρικό κενό
- μέγεθος τρύπας
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργήσετε και να προσαρμόσετε γραφήματα δακτυλίου στο Aspose.Slides για Android μέσω Java, υποστηρίζοντας μορφές PowerPoint για δυναμικές παρουσιάσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργαστείτε με ένα γράφημα δακτυλίου στο Aspose.Slides προσθέτοντας το γράφημα σε μια διαφάνεια, ορίζοντας το μέγεθος της κεντρικής τρύπας και αποθηκεύοντας την παρουσίαση. Επικεντρώνεται στη μέθοδο `setDoughnutHoleSize` και παρουσιάζει τα βασικά βήματα που απαιτούνται για την προσαρμογή αυτού του τύπου γραφήματος με κώδικα.

Περιλαμβάνει επίσης μια σύντομη ενότητα FAQ που καλύπτει σχετικές περιπτώσεις γραφημάτων δακτυλίου, όπως η χρήση πολλαπλών σειρών για τη δημιουργία πολλαπλών δαχτυλιδιών, η εργασία με εκραγμένα γραφήματα δακτυλίου, και η εξαγωγή γραφήματος ως εικόνα raster ή SVG.

## **Καθορισμός του Κεντρικού Κενού σε Γράφημα Δακτυλίου**
{{% alert color="info" %}} 
Το Aspose.Slides για Android μέσω Java υποστηρίζει πλέον τον καθορισμό του μεγέθους της τρύπας σε γράφημα δακτυλίου. Σε αυτό το θέμα, θα δούμε με παράδειγμα πώς να καθορίσετε το μέγεθος της τρύπας σε γράφημα δακτυλίου.
{{% /alert %}} 

Για να καθορίσετε το μέγεθος της τρύπας σε γράφημα δακτυλίου, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
1. Προσθέστε γράφημα δακτυλίου στη διαφάνεια.
1. Καθορίστε το μέγεθος της τρύπας σε γράφημα δακτυλίου.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει το μέγεθος της τρύπας σε γράφημα δακτυλίου.

```java
import com.aspose.slides.*;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Γράψτε την παρουσίαση στον δίσκο
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Μπορώ να δημιουργήσω ένα πολυεπίπεδο δακτύλιο με πολλαπλά δαχτυλίδια;

Ναι. Προσθέστε πολλαπλές σειρές σε ένα μόνο γράφημα δακτυλίου — κάθε σειρά γίνεται ξεχωριστό δαχτυλίδι. Η σειρά των δαχτυλιδιών καθορίζεται από τη σειρά των σειρών στη συλλογή.

### Υποστηρίζεται ένα «εκραγμένο» δακτύλιο (διαχωρισμένες φέτες);

Ναι. Υπάρχει τύπος γραφήματος Exploded Doughnut [chart type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/) και ιδιότητα έκρηξης στα σημεία δεδομένων· μπορείτε να διαχωρίσετε μεμονωμένες φέτες.

### Πώς μπορώ να αποκτήσω εικόνα ενός γραφήματος δακτυλίου (PNG/SVG) για μια αναφορά;

Ένα γράφημα είναι σχήμα· μπορείτε να το αποδώσετε σε μια [raster image](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ή να εξάγετε το γράφημα σε μια [SVG image](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).