---
title: Προσαρμογή 3D Διαγραμμάτων σε Παρουσιάσεις σε .NET
linktitle: 3D Διάγραμμα
type: docs
url: /el/net/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3-Δ διαγράμματα στο Aspose.Slides για .NET, με υποστήριξη αρχείων PPT και PPTX — ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D διάγραμμα στο Aspose.Slides διαμορφώνοντας τις ρυθμίσεις `Rotation3D` όπως `RotationX`, `RotationY`, `DepthPercents` και `RightAngleAxes`. Περιγράφει τη δημιουργία μιας παρουσίασης, την προσθήκη ενός 3D διαγράμματος με προεπιλεγμένα δεδομένα, την εφαρμογή των απαιτούμενων ρυθμίσεων προβολής 3D και την αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός ιδιοτήτων RotationX, RotationY και DepthPercents ενός 3D διαγράμματος**

Το Aspose.Slides for .NET παρέχει ένα απλό API για τον καθορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διάφορες ιδιότητες όπως περιστροφή X, Y, **DepthPercents** κ.λπ. Ο δείγμα κώδικας εφαρμόζει τη ρύθμιση των προαναφερθέντων ιδιοτήτων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα.
1. Ορισμός ιδιοτήτων Rotation3D.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```c#
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation presentation = new Presentation();
           
// Πρόσβαση στην πρώτη διαφάνεια
ISlide slide = presentation.Slides[0];

// Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Ορισμός του δείκτη του φύλλου δεδομένων διαγράμματος
int defaultWorksheetIndex = 0;

// Ανάκτηση του φύλλου εργασίας δεδομένων διαγράμματος
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Προσθήκη σειράς
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Προσθήκη κατηγοριών
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Ορισμός ιδιοτήτων Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Λήψη της δεύτερης σειράς διαγράμματος
IChartSeries series = chart.ChartData.Series[1];

// Τώρα γεμίζουμε τα δεδομένα της σειράς
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Ορισμός τιμής OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Αποθήκευση παρουσίασης στο δίσκο
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των γραφημάτων στήλης, όπως Column 3D, Clustered Column 3D, Stacked Column 3D και 100% Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της απαρίθμησης [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη της [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστηρική εικόνα ενός 3D διαγράμματος για ένα αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getimage/) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/net/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια άψογη προεπισκόπηση pixel-perfect ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για τα καλύτερα αποτελέσματα, διατηρήστε τα εφέ 3D ελάχιστα, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν και αποδώστε σε έξοδο κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την επιδιωκόμενη οθόνη ή τις ανάγκες εκτύπωσης.