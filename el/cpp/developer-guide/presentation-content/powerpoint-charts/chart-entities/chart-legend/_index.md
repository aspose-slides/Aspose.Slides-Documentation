---
title: Προσαρμογή υπομνήματος διαγραμμάτων σε παρουσιάσεις με χρήση C++
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/cpp/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα διαγραμμάτων με το Aspose.Slides για C++ ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Aspose.Slides for C++ παρέχει επιλογές για προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να διαμορφώσετε το μέγεθος ενός υπομνήματος, να ορίσετε το μέγεθος γραμματοσειράς για όλο το υπόμνημα, να μορφοποιήσετε μια μεμονωμένη καταχώριση υπομνήματος και να κρύψετε ή να επαναφέρετε επιλεγμένες καταχωρίσεις.

Το FAQ καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένης της διάθεσης χώρου για το υπόμνημα, της προβολής ετικετών πολλαπλών γραμμών και της κληρονόμησης μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπομνήματος**

Χρησιμοποιήστε τις μεθόδους [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), και [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) του υπομνήματος για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα συγκεντρωμένο γράφημα στηλών με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Η διαίρεση των επιθυμητών μετατοπίσεων και διαστάσεων του υπομνήματος με το πλάτος και το ύψος του διαγράμματος τα μετατρέπει σε σχετικές τιμές: το υπόμνημα έχει μετατοπιστεί κατά 50 σημεία από την επάνω αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 κατά 100 σημεία.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Εκφράζει τη θέση και το μέγεθος του υπομνήματος σε σχέση με το διάγραμμα.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Χρησιμοποιήστε το [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) του υπομνήματος για να προσπελάσετε τη μορφοποίηση κειμένου του και χρησιμοποιήστε το [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) για να ορίσετε το μέγεθος γραμματοσειράς σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του υπομνήματος στα 20 σημεία. Επίσης, απενεργοποιεί τα αυτόματα όρια για τον κάθετο άξονα και θέτει τη σειρά του από -5 έως 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένης Καταχώρισης Υπομνήματος**

Χρησιμοποιήστε τη συλλογή που επιστρέφεται από τη μέθοδο [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) του υπομνήματος για να προσπελάσετε τη μορφοποίηση μιας συγκεκριμένης καταχώρισης. Οι δείκτες των καταχωρίσεων είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη καταχώριση.

Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωμένο γράφημα στηλών του οποίου τα προεπιλεγμένα δεδομένα περιλαμβάνουν τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη καταχώριση του υπομνήματος με έντονη, πλάγια και κυανή γραφή 20 σημείων.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Απόκρυψη Μεμονωμένων Καταχωρίσεων Υπομνήματος**

Για να εξαιρέσετε μια βοηθητική σειρά από το υπόμνημα διατηρώντας τα δεδομένα της ορατά, καλέστε το [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) με `true` μέσω του [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Αυτό κρύβει μόνο την επιλεγμένη καταχώριση του υπομνήματος· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Αντίθετα, καλώντας το [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) με `false` κρύβεται ολόκληρο το υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα συγκεντρωμένο γράφημα στηλών με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει τη καταχώριση του υπομνήματος της δεύτερης σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει την καταχώριση καλώντας το `set_Hide` με `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Επαναφέρετε την ίδια καταχώριση χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Η παρακάτω σύγκριση δείχνει το ίδιο γράφημα με όλες τις καταχωρίσεις ορατές και με τη δεύτερη καταχώριση κρυφή. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση ενός γραφήματος με όλες τις καταχωρίσεις του υπομνήματος ορατές και με τη Σειρά 2 κρυφή από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Στα διαγράμματα στήλης, ράβδου και γραμμής, οι καταχωρίσεις του υπομνήματος προσδιορίζουν τις σειρές. Για διαγράμματα πίτας, προσδιορίζουν μεμονωμένα σημεία δεδομένων (κόμματα), έτσι χρησιμοποιήστε το [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) στην επιλεγμένη κόμμη. Το API τεκμηριώνει αυτή τη μέθοδο σημείου δεδομένων για τους τύπους διαγραμμάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για διαγράμματα δαχτυλιδιού, τα οποία δεν περιλαμβάνονται στη λίστα.

## **Συχνές Ερωτήσεις**

**Μπορώ να κάνει το γράφημα να διαθέσει χώρο για το υπόμνημα αντί να το επικάλυψηει;**

Ναι. Καλέστε το [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) με `false` για να διατηρήσετε χώρο για το υπόμνημα αντί να επιτρέψετε την επικάλυψή του πάνω στην περιοχή σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες μπορούν να αναδιπλώνονται όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες newline στα ονόματα των σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τα γέμισματα και τις γραμματοσειρές του υπομνήματος ακαθόριστα, ώστε να κληρονομεί τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση υπερισχύει των αντίστοιχων ρυθμίσεων του θέματος.