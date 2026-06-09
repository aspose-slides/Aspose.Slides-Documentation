---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst με τη χρήση С++
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλαδιού
- PowerPoint
- παρουσίαση
- С++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σημεία δεδομένων σε διαγράμματα treemap και sunburst με το Aspose.Slides για С++, συμβατό με μορφές PowerPoint."
---
## **Εισαγωγή**

Μεταξύ άλλων τύπων διαγραμμάτων PowerPoint, υπάρχουν δύο «ιεραρχικοί» τύποι – το **Treemap** και το **Sunburst** διάγραμμα (γνωστό επίσης ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο – από τα φύλλα μέχρι την κορυφή του κλαδιού. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επόμενο ένθετο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Το Aspose.Slides for C++ επιτρέπει τη μορφοποίηση των σημείων δεδομένων του Διαγράμματος Sunburst και του Treemap σε C++.

Ακολουθεί ένα Διάγραμμα Sunburst, όπου τα δεδομένα στη στήλη Series1 ορίζουν τους κόμβους φύλλων, ενώ άλλα κελιά ορίζουν ιεραρχικά σημεία δεδομένων:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Ας ξεκινήσουμε με την προσθήκη ενός νέου διαγράμματος Sunburst στην παρουσίαση:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [**Δημιουργία διαγράμματος Sunburst**](/slides/el/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Αν υπάρχει ανάγκη μορφοποίησης σημείων δεδομένων του διαγράμματος, πρέπει να χρησιμοποιήσουμε τα παρακάτω:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/) κλάσεις και η μέθοδος [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) παρέχουν πρόσβαση στη μορφοποίηση σημείων δεδομένων των διαγραμμάτων Treemap και Sunburst.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) χρησιμοποιείται για την πρόσβαση σε κατηγορίες πολλαπλών επιπέδων – αντιπροσωπεύει το κοντέινερ των αντικειμένων [**IChartDataPointLevel**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/). Βασικά είναι ένας wrapper για το [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartcategorylevelsmanager/), με τις ιδιότητες που προστίθενται ειδικά για σημεία δεδομένων. Η κλάση [**IChartDataPointLevel**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/) έχει δύο μεθόδους: [**get_Format()**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) και [**get_Label()**](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) που παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.

## **Εμφάνιση τιμής σημείου δεδομένων**
Εμφάνιση τιμής του σημείου δεδομένων "Leaf 4":
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ορισμός ετικέτας και χρώματος σημείου δεδομένων**
Ορίστε την ετικέτα δεδομένων του "Branch 1" ώστε να εμφανίζει το όνομα της σειράς ("Series1") αντί του ονόματος της κατηγορίας. Στη συνέχεια ορίστε το χρώμα κειμένου σε κίτρινο:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ορισμός χρώματος κλαδιού σημείου δεδομένων**
Αλλαγή χρώματος του κλαδιού "Stem 4":
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**  
Όχι. Το PowerPoint ταξινομεί αυτόματα τα τμήματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Το Aspose.Slides αντικατοπτρίζει αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά απευθείας· πρέπει να το κάνετε προεπεξεργάζοντας τα δεδομένα.

**Πώς επηρεάζει το θέμα της παρουσίασης τα χρώματα των τμημάτων και των ετικετών;**  
Τα χρώματα του διαγράμματος κληρονομούν το [θέμα/παλέτα](/slides/el/cpp/presentation-theme/) της παρουσίασης, εκτός εάν ορίσετε ρητά γεμίσεις/γραμματοσειρές. Για συνεπή αποτελέσματα, κλειδώστε σταθερές γεμίσεις και μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλαδιών και τις ρυθμίσεις ετικετών;**  
Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γεμίσεις, ετικέτες) διατηρούνται στα αρχεία εξόδου επειδή το Aspose.Slides αποδίδει το διάγραμμα με την εφαρμοσμένη μορφοποίηση.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**  
Ναι. Μετά την επικύρωση της διάταξης του διαγράμματος, είναι διαθέσιμες οι πραγματικές τιμές X και Y για τα στοιχεία (π.χ., ένα [DataLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/datalabel/)), κάτι που βοηθά στην ακριβή τοποθέτηση των επικαλύψεων.