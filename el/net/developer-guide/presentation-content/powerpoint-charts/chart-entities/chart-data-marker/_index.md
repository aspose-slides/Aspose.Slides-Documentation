---
title: Διαχείριση Δεικτών Δεδομένων Διαγράμματος σε Παρουσιάσεις στο .NET
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/net/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δείκτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για .NET, ενισχύοντας την επίδραση των παρουσιάσεων σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα C#."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με δείκτες δεδομένων διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να αποκτήσετε πρόσβαση σε μια σειρά και τα σημεία δεδομένων της, να εφαρμόσετε γεμίσεις εικόνας στους δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επισημαίνει επίσης ότι τα τυπικά σχήματα δεικτών είναι διαθέσιμα μέσω της απαρίθμησης `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός επιλογών δεικτών διαγράμματος**

Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων διαγράμματος εντός συγκεκριμένων σειρών. Για να ορίσετε τις επιλογές δεικτών διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε το αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
- Δημιουργώντας το προεπιλεγμένο διάγραμμα.
- Ορίστε την εικόνα.
- Πάρτε την πρώτη σειρά διαγράμματος.
- Προσθέστε νέο σημείο δεδομένων.
- Αποθηκεύστε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δεικτών διαγράμματος σε επίπεδο σημείων δεδομένων.

```c#
// Δημιουργήστε ένα αντίγραφο της κλάσης Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Δημιουργία του προεπιλεγμένου διαγράμματος
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Λήψη του δείκτη του προεπιλεγμένου φύλλου δεδομένων διαγράμματος
int defaultWorksheetIndex = 0;

// Λήψη του φύλλου δεδομένων διαγράμματος
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Διαγραφή της δοκιμαστικής σειράς
chart.ChartData.Series.Clear();

// Προσθήκη νέας σειράς
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Ορισμός της εικόνας
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Ορισμός της εικόνας
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Πάρτε την πρώτη σειρά διαγράμματος
IChartSeries series = chart.ChartData.Series[0];

// Προσθήκη νέου σημείου (1:3) εκεί.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Αλλαγή του δείκτη σειράς διαγράμματος
series.Marker.Size = 15;

// Αποθήκευση της παρουσίασης στο δίσκο
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

**Ποια σχήματα δεικτών είναι διαθέσιμα εξ'ορισμού;**

Διατίθενται τυπικά σχήματα (κύκλος, τετράγωνο, ρόμβος, τρίγωνο κ.λπ.); η λίστα ορίζεται από την απαρίθμηση [MarkerStyleType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/markerstyletype/). Εάν χρειάζεστε μη τυπικό σχήμα, χρησιμοποιήστε έναν δείκτη με γεμίσματα εικόνας για να προσομοιώσετε προσαρμοστικά γραφικά.

**Διατηρούνται οι δείκτες όταν εξάγετε ένα διάγραμμα σε εικόνα ή SVG;**

Ναι. Κατά την απόδοση διαγραμμάτων σε [μορφές raster](/slides/el/net/convert-powerpoint-to-png/) ή την αποθήκευση [σχήματα ως SVG](/slides/el/net/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένου του μεγέθους, της γεμιστικής και του περιγράμματος.