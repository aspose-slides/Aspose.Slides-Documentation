---
title: Προσαρμογή υπομνήσεων γραφημάτων σε παρουσιάσεις σε .NET
linktitle: Υπόμνηση Γραφήματος
type: docs
url: /el/net/chart-legend/
keywords:
- υπόμνηση γραφήματος
- θέση υπομνήσεως
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσαρμόστε τις υπομνήσεις γραφημάτων με το Aspose.Slides για .NET ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για προσαρμογή των υπομνήσεων γραφημάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος μιας υπομνήσεως, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρη την υπομνηση, και να εφαρμόσετε μορφοποίηση σε μεμονωμένη καταχώρηση υπομνήσεως.

Καλύπτει επίσης αρκετές σχετικές συμπεριφορές στις Συχνές Ερωτήσεις, όπως η χρήση λειτουργίας non‑overlay ώστε η περιοχή σχεδίασης να αφήσει χώρο για την υπομνηση, η δυνατότητα οι μακριές ετικέτες υπομνήσεων να αναδιπλώνονται ή να χρησιμοποιούν αλλαγές γραμμής, και η κληρονόμηση μορφοποίησης υπομνήσεων από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητά χρώματα κειμένου και γεμίσματος.

## **Τοποθέτηση Υπόμνησης**
Για να ορίσετε τις ιδιότητες της υπομνήσεως, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
- Πάρτε την αναφορά της διαφάνειας.
- Προσθέστε ένα γράφημα στη διαφάνεια.
- Ορίστε τις ιδιότητες της υπομνήσεως.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, ορίσαμε τη θέση και το μέγεθος για την Υπόμνηση του γραφήματος.

```c#
// Δημιουργήστε μια παρουσίαση της κλάσης Presentation
Presentation presentation = new Presentation();

// Πάρτε την αναφορά της διαφάνειας
ISlide slide = presentation.Slides[0];

// Προσθέστε ένα γράφημα ομαδοποιημένων στηλών στη διαφάνεια
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Ορίστε τις ιδιότητες της υπομνήσεως
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Αποθηκεύστε την παρουσίαση στο δίσκο
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Ορισμός Μεγέθους Γραμματοσειράς Υπόμνησης**
Το Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς της υπομνήσεως. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια εμφάνιση της κλάσης `Presentation`.
- Δημιουργήστε το προεπιλεγμένο γράφημα.
- Ορίστε το Μέγεθος Γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε τη μέγιστη τιμή άξονα.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Ορισμός Μεγέθους Γραμματοσειράς Μονής Καταχώρησης Υπόμνησης**
Το Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να ορίσουν το μέγεθος γραμματοσειράς των μεμονωμένων καταχωρήσεων υπομνήσεως. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια εμφάνιση της κλάσης `Presentation`.
- Δημιουργήστε το προεπιλεγμένο γράφημα.
- Πρόσβαση στην καταχώρηση υπομνήσεως.
- Ορίστε το Μέγεθος Γραμματοσειράς.
- Ορίστε την ελάχιστη τιμή άξονα.
- Ορίστε τη μέγιστη τιμή άξονα.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ενεργοποιήσω την υπομνηση ώστε το γράφημα να κατανείμει αυτόματα χώρο για αυτήν αντί να την επικάλυψη;**

Ναι. Χρησιμοποιήστε τη λειτουργία non‑overlay ([Overlay](https://reference.aspose.com/slides/el/net/aspose.slides.charts/legend/overlay/)=`false`); σε αυτή την περίπτωση, η περιοχή σχεδίασης θα συρρικνωθεί ώστε να φιλοξενήσει την υπομνηση.

**Μπορώ να δημιουργήσω ετικέτες υπομνήσεων πολλαπλών γραμμών;**

Ναι. Μακριές ετικέτες αναδιπλώνονται αυτόματα όταν ο χώρος είναι ανεπαρκής· υποστηρίζονται βίαιοι αλλαγές γραμμής μέσω χαρακτήρων νέας γραμμής στο όνομα σειράς.

**Πώς μπορώ η υπομνηση να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίζετε ρητά χρώματα/γεμίσεις/γραμματοσειρές για την υπομνηση ή το κείμενό της. Θα κληρονομηθεί το χρώμα από το θέμα και θα ενημερωθεί σωστά όταν αλλάξει ο σχεδιασμός.