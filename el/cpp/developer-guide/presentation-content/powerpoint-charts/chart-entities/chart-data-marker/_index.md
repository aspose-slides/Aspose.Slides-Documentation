---
title: Διαχείριση Δεικτών Δεδομένων Διαγράμματος σε Παρουσιάσεις με C++
linktitle: Δείκτης Δεδομένων
type: docs
url: /el/cpp/chart-data-marker/
keywords:
- διάγραμμα
- σημείο δεδομένων
- δείκτης
- επιλογές δείκτη
- μέγεθος δείκτη
- τύπος γεμίσματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσαρμόζετε τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides για C++, ενισχύοντας την επίδραση των παρουσιάσεων σε μορφές PPT και PPTX με σαφή παραδείγματα κώδικα C++."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με τους δείκτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να αποκτήσετε πρόσβαση σε μια σειρά και στα σημεία δεδομένων της, να εφαρμόσετε γεμίσματα εικόνας στους δείκτες σε επίπεδο σημείου δεδομένων, να προσαρμόσετε το μέγεθος του δείκτη και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης σημειώνει ότι τα τυπικά σχήματα δεικτών είναι διαθέσιμα μέσω της απαριθμήσεως `MarkerStyleType` και ότι η εμφάνιση του δείκτη διατηρείται κατά την εξαγωγή διαγραμμάτων σε μορφές raster ή SVG.

## **Ορισμός Δεικτών Διαγράμματος**
Το Aspose.Slides for C++ παρέχει ένα απλό API για τον αυτόματο ορισμό του δείκτη σειράς διαγράμματος. Στη συνέχεια, κάθε σειρά διαγράμματος θα λάβει διαφορετικό προεπιλεγμένο σύμβολο δείκτη αυτόματα.

Η παρακάτω παραδείγματα κώδικα δείχνει πώς να ορίσετε αυτόματα το δείκτη σειράς διαγράμματος.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Ορισμός Επιλογών Δείκτη Διαγράμματος**
Οι δείκτες μπορούν να οριστούν σε σημεία δεδομένων διαγράμματος μέσα σε συγκεκριμένη σειρά. Για να ορίσετε τις επιλογές δείκτη διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
- Δημιουργία προεπιλεγμένου διαγράμματος.
- Ορίστε την εικόνα.
- Πάρτε την πρώτη σειρά διαγράμματος.
- Προσθέστε ένα νέο σημείο δεδομένων.
- Αποθηκεύστε την παρουσίαση σε δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δείκτη διαγράμματος σε επίπεδο σημείων δεδομένων.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Ορισμός Δεικτών Διαγράμματος σε Επίπεδο Σημείου Σειράς**
Τώρα, οι δείκτες μπορούν να οριστούν στα σημεία δεδομένων του διαγράμματος μέσα σε μια συγκεκριμένη σειρά. Για να ορίσετε τις επιλογές δείκτη διαγράμματος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε αντικείμενο κλάσης Presentation.
- Δημιουργία προεπιλεγμένου διαγράμματος.
- Ορίστε την εικόνα.
- Πάρτε την πρώτη σειρά διαγράμματος.
- Προσθέστε ένα νέο σημείο δεδομένων.
- Αποθηκεύστε την παρουσίαση σε δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει τις επιλογές δείκτη διαγράμματος σε επίπεδο σημείων δεδομένων.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Ορισμός του δείκτη του φύλλου δεδομένων διαγράμματος
int defaultWorksheetIndex = 0;

// Λήψη του φύλλου δεδομένων διαγράμματος
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών
chart->get_ChartData()->get_Series()->Clear();

// Τώρα, προσθήκη νέας σειράς
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Λήψη της εικόνας
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Προσθήκη εικόνας στη συλλογή εικόνων της παρουσίασης
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Προσθήκη νέου σημείου (1:3) εκεί.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Αλλαγή δείκτη σειράς διαγράμματος
series->get_Marker()->set_Size(15);

// Εγγραφή του αρχείου παρουσίασης στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Εφαρμογή Χρώματος σε Σημεία Δεδομένων**
Μπορείτε να εφαρμόσετε χρώμα σε σημεία δεδομένων στο διάγραμμα χρησιμοποιώντας το Aspose.Slides for C++. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) και **[IChartDataPointLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/)** classes έχουν προστεθεί για πρόσβαση στις ιδιότητες επιπέδων σημείου δεδομένων. Αυτό το άρθρο δείχνει πώς μπορείτε να έχετε πρόσβαση και να εφαρμόσετε χρώμα σε σημεία δεδομένων σε ένα διάγραμμα.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Συχνές Ερωτήσεις**

**Ποια σχήματα δεικτών διατίθενται άμεσα;**

Διατίθενται τυπικά σχήματα (κύκλος, τετράγωνο, ρόμβος, τρίγωνο κ.λπ.); η λίστα ορίζεται από την απαριθμήση [MarkerStyleType](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/markerstyletype/). Εάν χρειάζεστε μη‑τυπικό σχήμα, χρησιμοποιήστε δείκτη με γεμισμα εικόνας για να προσομοιώσετε προσαρμοστικά γραφικά.

**Διατηρούνται οι δείκτες κατά την εξαγωγή ενός διαγράμματος σε εικόνα ή SVG;**

Ναι. Κατά την απόδοση διαγραμμάτων σε [raster formats](/slides/el/cpp/convert-powerpoint-to-png/) ή την αποθήκευση [shapes as SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/), οι δείκτες διατηρούν την εμφάνιση και τις ρυθμίσεις τους, συμπεριλαμβανομένων του μεγέθους, του γεμίσματος και του περιγράμματος.