---
title: "Προσαρμογή άξονων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας C++"
linktitle: "Άξονας διαγράμματος"
type: docs
url: /el/cpp/chart-axis/
keywords:
- "άξονας διαγράμματος"
- "κατακόρυφος άξονας"
- "οριζόντιος άξονας"
- "προσαρμογή άξονα"
- "χειρισμός άξονα"
- "διαχείριση άξονα"
- "ιδιότητες άξονα"
- "μέγιστη τιμή"
- "ελάχιστη τιμή"
- "γραμμή άξονα"
- "μορφή ημερομηνίας"
- "τίτλος άξονα"
- "θέση άξονα"
- "PowerPoint"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για C++ για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λαμβάνετε τις πραγματικές τιμές των αξόνων, να ανταλλάσσετε δεδομένα μεταξύ αξόνων, να κρύβετε τον κάθετο ή τον οριζόντιο άξονα για διαγράμματα γραμμής, να αλλάζετε τον τύπο του άξονα κατηγορίας, να ορίζετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέφετε τον τίτλο του άξονα, να ορίζετε τη θέση του άξονα και να εμφανίζετε μια ετικέτα μονάδας στον άξονα τιμών.

## **Λήψη των μέγιστων τιμών στον κάθετο άξονα**
Το Aspose.Slides για C++ σάς επιτρέπει να λαμβάνετε τις ελάχιστες και μέγιστες τιμές σε έναν κάθετο άξονα. Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
1. Λάβετε την πραγματική μέγιστη τιμή στον άξονα.
1. Λάβετε την πραγματική ελάχιστη τιμή στον άξονα.
1. Λάβετε την πραγματική κύρια μονάδα του άξονα.
1. Λάβετε την πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα της κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα της δευτερεύουσας μονάδας του άξονα.

Αυτό το δείγμα κώδικα — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να λαμβάνετε τις απαιτούμενες τιμές σε C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Αποθηκεύει την παρουσίαση
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Ανταλλαγή δεδομένων μεταξύ αξόνων**
Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων — τα δεδομένα που εμφανίζονται στον κάθετο άξονα (y-axis) μετακινούνται στον οριζόντιο άξονα (x-axis) και αντίστροφα.

Αυτός ο κώδικας C++ σας δείχνει πώς να εκτελέσετε την ανταλλαγή δεδομένων μεταξύ των αξόνων σε ένα γράφημα:

``` cpp
// Δημιουργεί κενή παρουσίαση
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Αλλάζει γραμμές και στήλες
chart->get_ChartData()->SwitchRowColumn();

// Αποθηκεύει την παρουσίαση
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Απενεργοποίηση του κάθετου άξονα για διαγράμματα γραμμής**

Αυτός ο κώδικας C++ σας δείχνει πώς να κρύψετε τον κάθετο άξονα για ένα γράφημα γραμμής:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Αυτός ο κώδικας σας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα γράφημα γραμμής:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Αλλαγή του άξονα κατηγορίας**

Χρησιμοποιώντας τη μέθοδο **set_CategoryAxisType()**, μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας C++ επιδεικνύει τη λειτουργία:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός μορφής ημερομηνίας για τις τιμές του άξονα κατηγορίας**
Το Aspose.Slides για C++ σάς επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία επιδεικνύεται σε αυτόν τον κώδικα C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα**
Το Aspose.Slides για C++ σάς επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο άξονα ενός διαγράμματος. Αυτός ο κώδικας C++ επιδεικνύει τη λειτουργία:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**
Το Aspose.Slides για C++ σάς επιτρέπει να ορίσετε τη θέση άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας C++ δείχνει πώς να εκτελέσετε την εργασία:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Ενεργοποίηση ετικέτας μονάδας εμφάνισης σε άξονα τιμών διαγράμματος**
Το Aspose.Slides για C++ σάς επιτρέπει να ρυθμίσετε ένα γράφημα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του. Αυτός ο κώδικας C++ επιδεικνύει τη λειτουργία:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασύνδεση άξονα);**

Οι άξονες παρέχουν μια [ρύθμιση διασταύρωσης](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/axis/set_crosstype/): μπορείτε να επιλέξετε να διασχίσει στο μηδέν, στο μέγιστο της κατηγορίας/τιμής ή σε συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του άξονα X πάνω ή κάτω ή για την ανάδειξη μιας βασικής γραμμής.

**Πώς μπορώ να τοποθετήσω τις ετικέτες των σημείων ανάλογα με τον άξονα (πλάι, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/axis/set_majortickmark/) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη διατήρηση του χώρου, ειδικά σε μικρά διαγράμματα.