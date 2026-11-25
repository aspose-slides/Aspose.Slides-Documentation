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
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET. Προσαρμόστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και το διάστιχο μεταξύ σειρών με παραδείγματα C#."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET σας επιτρέπει να προσαρμόζετε την προβολή ενός 3D διαγράμματος μέσω της ιδιότητας [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και το διάστιχο μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορίστε την περιστροφή και το βάθος ενός 3D διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και χρησιμοποιεί [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να προσθέσει ένα στοίβαγμα 3D στυλοβάτη στο πρώτο του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η κάθε μία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες κατηγοριών.

Οι ιδιότητες [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) και [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) ορίζουν την περιστροφή του διαγράμματος στα 40 και 270 μοίρες, αντίστοιχα. Η ιδιότητα [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) θέτει το βάθος του στο 150 % του πλάτους, ενώ η [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η τελική παρουσίαση περιέχει το πλήρως συμπληρωμένο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Εφαρμόστε γέμισμα εικόνας στην επιφάνεια ενός 3D διαγράμματος**

Ένα 3D διάγραμμα έχει τρεις επιφάνειες που μπορείτε να γεμίσετε ανεξάρτητα: το [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), το [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) και το [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Ορίστε τον τύπο γεμίσματος της επιλεγμένης επιφάνειας ([fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)) σε `Picture` και αντιστοιχίστε μια εικόνα. Ορίστε τόσο τη [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) όσο και τον [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) της επιφάνειας σε `Stretch` ώστε να ταιριάζει ένα αντίγραφο της εικόνας στην επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον κατάλογο εργασίας. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή στον κατακόρυφο άξονα ώστε το πάτωμα να είναι ορατό μεταξύ των στυλοβατών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές πριν εφαρμόσει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Πίσω τοίχος | Πάτωμα |
| --- | --- | --- |
| ![Arrow pointing into the chart along the side wall](side-wall.png) | ![Arrow pointing right across the back wall](back-wall.png) | ![Arrow pointing right across the floor between the columns](floor.png) |

## **Ρυθμίστε τις αναλογίες ύψους ενός 3D διαγράμματος**

Χρησιμοποιήστε το [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς αλλαγή του μεγέθους του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, το διάστιχο σειρών και η μορφοποίηση είναι ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους διαφέρει.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Οι παρακάτω εικόνες εξήχθησαν από τις παραγόμενες παρουσιάσεις χρησιμοποιώντας το Microsoft PowerPoint. Ένα μικρότερο ποσοστό παράγει πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό παράγει υψηλότερη σκηνή μέσα στο ίδιο αντικείμενο διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημαδιών των αξόνων και τη θέση των ετικετών ώστε να ταιριάζει η σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![Διάγραμμα 3D στυλοβάτης με ύψος ορισμένο στο 50 τοις εκατό του πλάτους του](height_percent_50.png) | ![Διάγραμμα 3D στυλοβάτης με ύψος ορισμένο στο 100 τοις εκατό του πλάτους του](height_percent_100.png) | ![Διάγραμμα 3D στυλοβάτης με ύψος ορισμένο στο 200 τοις εκατό του πλάτους του](height_percent_200.png) |

Αυτές οι ιδιότητες ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Ιδιότητα | Επίδραση |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε σημείο. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει στυλοβάτες και ράβδους 3D, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3D γραμμής, περιοχής, πίτας και επιφάνειας. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`· αυτά τα ονόματα ανήκουν στην απαρίθμηση [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Chart Formatting](/slides/el/net/chart-formatting/).

## **Ρυθμίστε το κενό μεταξύ σειρών**

Χρησιμοποιήστε το [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 to 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν το διάστημα. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Προσπελάστε την ομάδα μέσω του [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Η ρύθμιση εφαρμόζεται σε κάθε σειρά της ομάδας, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η ιδιότητα [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) είναι μόνο-ανάγνωση και αντανακλά τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει στυλοβάτες και ράβδους 3D, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3D γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι τακτοποιημένες σε βάθος, σε ομάδες ή στοίβαγμενες. Για σαφή σύγκριση των κενού μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Αυτές οι ιδιότητες ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Ιδιότητα | Επίδραση |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Απόσταση μεταξύ γειτονικών ομάδων ράβδων ή στυλοβατών, ως ποσοστό του πλάτους της ράβδου ή στυλοβάτη. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομα παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με πανομοιότυπα δεδομένα, περιστροφή, πλάτος κενών και βάθος διαγράμματος· μόνο το βάθος κενών αλλάζει.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Οι παρακάτω εικόνες εξήχθησαν από τις παραγόμενες παρουσιάσεις χρησιμοποιώντας το Microsoft PowerPoint.

| Βάθος κενών: 0% | Βάθος κενών: 500% |
| --- | --- |
| ![Διάγραμμα 3D στυλοβάτη χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![Διάγραμμα 3D στυλοβάτη με κενό 500 τοις εκατό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλάξτε τον τύπο σειράς 3D και το σχήμα ράβδου**

Σε ένα διάγραμμα ομαδοποιημένων κυλίνδρων, η πρώτη σειρά ξεκινά με σχήμα κυλινδρικής ράβδου. Το παράδειγμα διαβάζει τα [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) και [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) πριν και μετά από κάθε αλλαγή.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Αλλαγή στην πρώτη σειρά | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Δημιουργία του διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός `Type` σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός `Bar3DShape` σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο της σειράς σε `ClusteredColumn3D`. Εάν ο κώδικοί σας διακλαδίζεται βάσει του τύπου σειράς, διαβάστε το `series.Type` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν την ανάθεση θα εξακολουθούσε να επιλέγει τον κλάδο `ClusteredCone`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **Συχνές ερωτήσεις**

**Ποιους τύπους διαγραμμάτων υποστηρίζει η λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της απαρίθμησης [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) στην τεκμηρίωση API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3D διαγράμματος για αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε το διάγραμμα σε εικόνα με τη μέθοδο [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/net/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερ προεπισκόπηση ή θέλετε να εντάξετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και τη γραφική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, διατηρήστε τις 3D επιδράσεις στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και στις περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την τελική προβολή ή τις απαιτήσεις εκτύπωσης.