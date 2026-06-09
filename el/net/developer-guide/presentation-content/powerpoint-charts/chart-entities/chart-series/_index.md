---
title: Διαχείριση Σειρών Δεδομένων Διαγραμμάτων σε Παρουσιάσεις στο .NET
linktitle: Σειρές Δεδομένων
type: docs
url: /el/net/chart-series/
keywords:
- σειρά διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγραμμάτων σε C# για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει τον ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartseries/) στο Aspose.Slides for .NET, εστιάζοντας στον τρόπο που τα δεδομένα δομούνται και απεικονίζονται μέσα σε παρουσιάσεις. Τα αντικείμενα αυτά παρέχουν τα θεμελιώδη στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγοριών και παραμέτρων εμφάνισης σε ένα διάγραμμα. Εργαζόμενοι με [ChartSeries](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν αβίαστα τις υποκείμενες πηγές δεδομένων και να διατηρήσουν πλήρη έλεγχο πάνω στο πώς εμφανίζονται οι πληροφορίες, δημιουργώντας δυναμικές, δεδομενο‑κεντρικές παρουσιάσεις που μεταδίδουν σαφή διορατικότητα και ανάλυση.

Μια σειρά είναι μια γραμμή ή στήλη αριθμών που σχεδιάζονται σε ένα γράφημα.

![σειρά-γράφηματος-powerpoint](chart-series-powerpoint.png)

## **Ορισμός της Επικάλυψης Σειράς Γραφήματος**

Η ιδιότητα [IChartSeriesOverlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/properties/overlap) ελέγχει πώς οι μπάρες και οι στήλες επικαλύπτονται σε ένα 2D γράφημα, καθορίζοντας ένα εύρος από -100 έως 100. Δεδομένου ότι αυτή η ιδιότητα σχετίζεται με την ομάδα σειρών και όχι με τη μεμονωμένη σειρά γραφήματος, είναι μόνο‑ανάγνωση σε επίπεδο σειράς. Για να διαμορφώσετε τις τιμές επικάλυψης, χρησιμοποιήστε την ιδιότητα `ParentSeriesGroup.Overlap` ανάγνωση/εγγραφή, η οποία εφαρμόζει την καθορισμένη επικάλυψη σε όλες τις σειρές της ομάδας.

Παρακάτω φαίνεται ένα παράδειγμα C# που δείχνει πώς να δημιουργήσετε μια παρουσίαση, να προσθέσετε ένα γράφημα στήλης σε συσσωμάτωση, να προσπελάσετε την πρώτη σειρά γραφήματος, να ρυθμίσετε τη ρύθμιση επικάλυψης και στη συνέχεια να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα στήλης σε ομαδοποίηση με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Ορίστε την επικάλυψη της σειράς.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισματος Σειράς**

Το Aspose.Slides καθιστά εύκολη την προσαρμογή των χρωμάτων γέμισματος των σειρών γραφήματος, επιτρέποντάς σας να τονίζετε συγκεκριμένα σημεία δεδομένων και να δημιουργείτε οπτικά ελκυστικά διαγράμματα. Αυτό υλοποιείται μέσω του αντικειμένου [IFormat](https://reference.aspose.com/slides/el/net/aspose.slides.charts/iformat/), το οποίο υποστηρίζει διάφορους τύπους γέμισματος, ρυθμίσεις χρώματος και άλλες προχωρημένες επιλογές μορφοποίησης. Αφού προσθέσετε ένα γράφημα σε μια διαφάνεια και προσπελάσετε τη ζητούμενη σειρά, απλώς αποκτήστε τη σειρά και εφαρμόστε το κατάλληλο χρώμα γέμισματος. Πέρα από τα στερεά γεμίσματα, μπορείτε επίσης να χρησιμοποιήσετε διαβάθμιση ή μοτίβο για μεγαλύτερη ευελιξία σχεδίασης. Μόλις ορίσετε τα χρώματα σύμφωνα με τις απαιτήσεις σας, αποθηκεύστε την παρουσίαση για να οριστικοποιήσετε την ενημερωμένη εμφάνιση.

Το παρακάτω παράδειγμα κώδικα C# δείχνει πώς να αλλάξετε το χρώμα της πρώτης σειράς:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα στήλης σε ομαδοποίηση με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ορίστε το χρώμα της πρώτης σειράς.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το χρώμα της σειράς](series_color.png)

## **Αλλαγή Ονόματος Σειράς** 

Το Aspose.Slides προσφέρει έναν απλό τρόπο για την τροποποίηση των ονομάτων των σειρών γραφήματος, κάνοντάς το πιο εύκολο να ετικετοποιήσετε τα δεδομένα με σαφή και κατανοητό τρόπο. Περνώντας στο αντίστοιχο κελί φύλλου εργασίας στα δεδομένα του γραφήματος, οι προγραμματιστές μπορούν να προσαρμόσουν τον τρόπο παρουσίασης των δεδομένων. Η τροποποίηση αυτή είναι ιδιαίτερα χρήσιμη όταν τα ονόματα των σειρών πρέπει να ενημερωθούν ή να διευκρινιστούν βάσει του πλαισίου των δεδομένων. Μετά την αλλαγή του ονόματος, η παρουσίαση μπορεί να αποθηκευτεί ώστε οι αλλαγές να παραμείνουν.

Παρακάτω υπάρχει ένα απόσπασμα κώδικα C# που δείχνει τη διαδικασία σε δράση.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα στήλης σε ομαδοποίηση με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ορίστε το όνομα της πρώτης σειράς.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Το παρακάτω παράδειγμα κώδικα C# παρουσιάζει έναν εναλλακτικό τρόπο αλλαγής του ονόματος της σειράς:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα στήλης σε ομαδοποίηση με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ορίστε το όνομα της πρώτης σειράς.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το όνομα της σειράς](series_name.png)

## **Ανάκτηση Αυτόματου Χρώματος Γέμισματος Σειράς**

Το Aspose.Slides for .NET σας επιτρέπει να λάβετε το αυτόματο χρώμα γέμισματος για σειρές γραφήματος εντός μιας περιοχής σχεδίασης. Αφού δημιουργήσετε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), μπορείτε να αποκτήσετε αναφορά στην επιθυμητή διαφάνεια με βάση το δείκτη, στη συνέχεια να προσθέσετε ένα γράφημα χρησιμοποιώντας τον προτιμώμενο τύπο (π.χ. `ChartType.ClusteredColumn`). Προσπελαύνοντας τις σειρές στο γράφημα, μπορείτε να λάβετε το αυτόματο χρώμα γέμισμα.

Ο παρακάτω κώδικας C# επεξηγεί τη διαδικασία αυτή λεπτομερώς.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα στήλης σε ομαδοποίηση με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Λάβετε το χρώμα γέμισμα της σειράς.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Έξοδος:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Ορισμός Αντιστροφής Χρώματος Γέμισματος για Σειρά Γραφήματος**

Όταν η σειρά δεδομένων σας περιέχει τόσο θετικές όσο και αρνητικές τιμές, το χρωματισμό κάθε στήλης ή μπάρας με το ίδιο χρώμα μπορεί να δυσκολεύει την ανάγνωση του γραφήματος. Το Aspose.Slides for .NET σάς επιτρέπει να ορίσετε ένα χρώμα αντιστροφής—ένα ξεχωριστό γέμισμα που εφαρμόζεται αυτόματα σε σημεία δεδομένων κάτω από το μηδέν—ώστε οι αρνητικές τιμές να ξεχωρίζουν αμέσως. Σε αυτήν την ενότητα θα μάθετε πώς να ενεργοποιήσετε αυτήν την επιλογή, να επιλέξετε ένα κατάλληλο χρώμα και να αποθηκεύσετε την ενημερωμένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα δείχνει τη λειτουργία:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Προσθήκη νέας σειράς.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Συμπλήρωση δεδομένων σειράς.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Ορισμός ρυθμίσεων χρώματος για τη σειρά.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το αντιστροφομένο στερεό γέμισμα](inverted_solid_fill_color.png)

Μπορείτε να αντιστρέψετε το χρώμα γέμισματος για ένα μεμονωμένο σημείο δεδομένων αντί για ολόκληρη τη σειρά. Απλώς προσπελάστε το επιθυμητό `IChartDataPoint` και ορίστε την ιδιότητα `InvertIfNegative` σε true.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς γίνεται αυτό:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Αντιστρέψτε το χρώμα εάν το σημείο δεδομένων στο δείκτη 2 είναι αρνητικό.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Καθαρισμός Συγκεκριμένων Τιμών Σημείων Δεδομένων**

Μερικές φορές ένα γράφημα περιέχει δοκιμαστικές τιμές, εκτοπές ή ξεπερασμένες εγγραφές που χρειάζεται να αφαιρέσετε χωρίς να ξαναχτίσετε ολόκληρη τη σειρά. Το Aspose.Slides for .NET σάς επιτρέπει να στοχεύσετε οποιοδήποτε σημείο δεδομένων με βάση το δείκτη, να διαγράψετε το περιεχόμενό του και να ενημερώσετε αμέσως το γράφημα ώστε τα υπόλοιπα σημεία να μετατοπιστούν και οι άξονες να ξαναπροσαρμοστούν αυτόματα.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Πλάτους Κενών Μεταξύ Σειρών**

Το πλάτος κενών (Gap width) ελέγχει το ποσό του κενου χώρου μεταξύ γειτονικών στηλών ή μπαρών—μεγαλύτερα κενά τονίζουν μεμονωμένες κατηγορίες, ενώ πιο στενά κενά δημιουργούν πιο πυκνή, πιο συμπαγή εμφάνιση. Μέσω του Aspose.Slides for .NET μπορείτε να ρυθμίσετε αυτήν την παράμετρο για ολόκληρη τη σειρά, επιτυγχάνοντας ακριβώς την οπτική ισορροπία που απαιτεί η παρουσίασή σας χωρίς να αλλάξετε τα υποκείμενα δεδομένα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το πλάτος κενών για μια σειρά:

```cs
ushort gapWidth = 30;

// Δημιουργήστε μια κενή παρουσίαση.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Ορίστε την τιμή GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το πλάτος των κενών](gap_width.png)

## **ΣΥΚΕΥΗ**

**Υπάρχει κάποιο όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα ενιαίο γράφημα;**

Το Aspose.Slides δεν επιβάλλει σταθερό όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό όριο καθορίζεται από την αναγνωσιμότητα του γραφήματος και από τη διαθέσιμη μνήμη της εφαρμογής σας.

**Τι γίνεται αν οι στήλες μέσα σε μια ομάδα είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ρυθμίστε την ιδιότητα `GapWidth` για εκείνη τη σειρά (ή για την ομάδα γονέα της σειράς). Η αύξηση της τιμής διευρύνει το κενό μεταξύ των στηλών, ενώ η μείωση της φέρνει τις στήλες πιο κοντά.