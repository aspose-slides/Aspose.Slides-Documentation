---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst σε PHP
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένων
- ετικέτα δεδομένων
- χρώμα κλαδιού
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε ιεραρχικά δεδομένα και να προσαρμόζετε επίπεδα, ετικέτες και χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν τον ίδιο τύπο ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ένθετα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το απεικονίζει ως συγκεντρικούς δακτυλίους: οι ομάδες κορυφαίου επιπέδου βρίσκονται κοντά στο κέντρο, και οι κατηγορίες φύλλων βρίσκονται στον εξωτερικό δακτύλιο.

Στο Aspose.Slides για PHP μέσω Java, κάθε αριθμητική τιμή είναι ένα [ChartDataPoint](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapoint/). Η μέθοδος [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) παρέχει πρόσβαση στο φύλλο και στις γονικές του ομάδες. Αυτό το άρθρο εξηγεί αυτή τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τα δύο είδη διαγράμματος από τα ίδια δεδομένα δείγματος.

![Διάγραμμα Treemap με κλαδιά Consumer και Business](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Consumer και Business](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το παρακάτω παράδειγμα έχει τρία επίπεδα κατηγοριών και μία αριθμητική σειρά:

| Κλαδί | Κόμβος | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Κάθε γραμμή δημιουργεί μία κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης κατηγοριών περιγράφουν τη διαδρομή από αυτό το φύλλο προς τους γονείς του. Για την πρώτη γραμμή, η διαδρομή είναι `Consumer > Computers > Laptops`.

Οι δείκτες που επιστρέφει η μέθοδος [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) τρέχουν από το φύλλο προς τα πάνω:

| `getDataPointLevels()` index | Logical level | Treemap representation | Sunburst representation |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Value rectangle | Outer-ring segment |
| `1` | Κόμβος | Parent rectangle or header | Middle-ring segment |
| `2` | Κλαδί | Top-level rectangle or header | Inner-ring segment |

Αυτή η σειρά είναι η ίδια και για τους δύο τύπους διαγράμματος, ακόμη κι αν οι οπτικές διατάξεις διαφέρουν. Ένα τμήμα γονέα μοιράζεται από πολλά φύλλα. Για να το μορφοποιήσετε, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων στην ομάδα. Για παράδειγμα, το κλαδί `Consumer` ξεκινά με το σημείο `Laptops`, ενώ το κλαδί `Software` ξεκινά με το σημείο `Licenses`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο σαφής και ασφαλής από τη χρήση ανεξήγητων εκφράσεων όπως `$dataPoints->get_Item(0)` ή `$dataPoints->get_Item(6)`.

## **Δημιουργία και Προσαρμογή Και των Δύο Τύπων Διαγράμματος**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Κατασκευάζει την ιεραρχία, εμφανίζει την τιμή για `Tablets`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί μια ετικέτα κλαδιού και αποθηκεύει την παρουσίαση.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Προσθέστε τις κατηγορίες φύλλων. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν ξεκινάει μια νέα ομάδα.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Εμφανίστε την κατηγορία και την τιμή στο φύλλο Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Μορφοποιήστε το κλαδί Consumer μέσω του πρώτου φύλλου σε αυτό το κλαδί.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Μορφοποιήστε τον κόμβο Software μέσω του πρώτου φύλλου σε αυτόν τον κόμβο.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout επηρεάζει τις ετικέτες γονέα του Treemap; το Sunburst χρησιμοποιεί τμήματα δακτυλίου.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Τα κελιά κατηγορίας και τα κελιά τιμής χρησιμοποιούν την ίδια σειρά φύλλου εργασίας, ώστε οι θέσεις των συλλογών τους να παραμένουν ευθυγραμμισμένες. Όταν εργάζεστε με ένα υπάρχον διάγραμμα αντί να δημιουργήσετε ένα, ελέγξτε πρώτα τις σειρές κατηγορίας και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που προτίθεστε να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικά Ζητήματα**

### **Διαφορές μεταξύ Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την περιοχή για να μεταφέρει την τιμή και ένθετα ορθογώνια για να μεταφέρει την ιεραρχία. Η μέθοδος [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/#setParentLabelLayout) ελέγχει τον τρόπο εμφάνισης των ετικετών γονέων σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για να μεταφέρει την τιμή και το βάθος του δακτυλίου για να μεταφέρει την ιεραρχία. Η [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/#setParentLabelLayout) δεν ελέγχει τις ετικέτες των δακτυλίων του.
- Και οι δύο τύποι διαγράμματος χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλου‑προς‑γονέα που επιστρέφει η [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), έτσι ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων μπορεί να μοιραστεί.
- Οι τιμές των γονέων υπολογίζονται από τα υποκατωφύλλα τους. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλαδιά ή κόμβους.

### **Ταξινόμηση και Σειρά Τμημάτων**

Η μηχανή διάταξης του διαγράμματος καθορίζει την τελική τοποθέτηση των ορθογωνίων και των τμημάτων δακτυλίου. Οργανώστε σχετικές σειρές κατηγορίας μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε μια συγκεκριμένη θέση ορθογωνίου ή σε γωνία έναρξης. Εάν η ακολουθία έχει νόημα, συμπεριλάβετε την στις ετικέτες ή χρησιμοποιήστε έναν τύπο διαγράμματος με ρητή άξονα κατηγορίας.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα του διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμο αποτέλεσμα. Εάν το διάγραμμα πρέπει να ακολουθεί τις αλλαγές θέματος, χρησιμοποιήστε χρώματα του σχήματος αντί για σταθερές τιμές RGB και αποφύγετε την υπερβολική αντικατάσταση κάθε επιπέδου. Επίσης, ελέγξτε την αντίθεση των ετικετών μετά την αλλαγή γεμίσματος κλαδιού ή κόμβου.

### **Ετικέτες και Διαθέσιμος Χώρος**

Το PowerPoint μπορεί να κρύψει ή να περικόψει ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η συντόμευση των ονομάτων κατηγορίας ή η εμφάνιση λιγότερων πεδίων ετικέτας συνήθως παράγει πιο καθαρό αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάσει το όνομα της κατηγορίας, το όνομα σειράς και την τιμή μέσω του [DataLabelFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabelformat/), αλλά η ενεργοποίηση όλων των πεδίων συχνά καθιστά τα ιεραρχικά διαγράμματα δύσκολα στην ανάγνωση.

### **Εξαγωγή και Απόδοση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, τα υποστηριζόμενα γεμίσματα και οι ρυθμίσεις ετικετών αποτυπώνονται στο διάγραμμα. Η αντικατάσταση γραμματοσειρών και μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη συρραφή κειμένου ή την ορατότητα της ετικέτας, γι' αυτό εγκαταστήστε τις απαιτούμενες γραμματοσειρές και ελέγξτε τους σημαντικούς προορισμούς εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί η αλλαγή ενός επιπέδου γονέα επηρεάζει πολλά φύλλα;**

Το κλαδί ή ο κόμβος αποτελεί κοινό οπτικό τμήμα. Το [ChartDataPointLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός υποκατωφύλλου, αλλά η μορφοποίηση ανήκει στο κοινό τμήμα γονέα, όχι μόνο στο συγκεκριμένο φύλλο.

**Γιατί λείπει μια ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [DataLabelFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε αν το τμήμα διαθέτει αρκετό χώρο. Η διάταξη ετικέτας γονέα Treemap, οι διαστάσεις του διαγράμματος, το μήκος της ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός των ενεργοποιημένων πεδίων επηρεάζουν το αν η ετικέτα μπορεί να εμφανιστεί.

**Μπορώ να ορίσω την ακριβή σειρά ή τις συντεταγμένες των τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά των σειρών‑πηγής και να κρατήσετε κάθε ομάδα αδιάσπαστη, αλλά δεν μπορείτε να ορίσετε ακριβείς ορθογώνιες περιοχές Treemap ή γωνίες Sunburst. Η μηχανή διάταξης του διαγράμματος τις υπολογίζει από την ιεραρχία, τις τιμές και το διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος παρουσίασης;**

Τα γεμίσματα βάσει θέματος σχεδιάζονται να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά, ή διατηρήστε χρώματα του σχήματος όταν η προσαρμογή σε νέο θέμα είναι προτιμώμενη.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση σε εξαγωγές PDF και εικόνας;**

Ναι, τα υποστηριζόμενα γεμίσματα διαγράμματος και οι ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για συνεπή αποτελέσματα σε όλα τα συστήματα, κάντε διαθέσιμες τις απαιτούμενες γραμματοσειρές και ελέγξτε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή ετικετών εξαρτάται από τη διάταξη.

## **Δείτε επίσης**

- [Δημιουργία διαγραμμάτων Treemap](/slides/el/php-java/create-chart/#create-tree-map-charts)
- [Δημιουργία διαγραμμάτων Sunburst](/slides/el/php-java/create-chart/#create-sunburst-charts)
- [Εξαγωγή διαγραμμάτων παρουσίασης](/slides/el/php-java/export-chart/)
- [Διαχείριση θεμάτων παρουσίασης](/slides/el/php-java/presentation-theme/)