---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst σε C++
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένων
- ετικέτα δεδομένων
- χρώμα κλάδου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε ιεραρχικά δεδομένα και να προσαρμόζετε επίπεδα, ετικέτες και χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν το ίδιο είδος ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ενσωματωμένα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το σχεδιάζει ως συνελικτικούς δακτυλίους: οι ομάδες του υψηλότερου επιπέδου βρίσκονται κοντά στο κέντρο, ενώ οι κατηγορίες των φύλλων βρίσκονται στον εξωτερικό δακτύλιο.

Στο Aspose.Slides για C++, κάθε αριθμητική τιμή είναι ένα [IChartDataPoint](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapoint/). Η μέθοδος [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) παρέχει πρόσβαση στο φύλλο και στις ομάδες γονέα του. Αυτό το άρθρο εξηγεί αυτή τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τους δύο τύπους διαγραμμάτων από τα ίδια δείγμα δεδομένων.

![Διάγραμμα Treemap με κλαδούς Consumer και Business](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Consumer και Business](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το δείγμα που χρησιμοποιείται παρακάτω έχει τρία επίπεδα κατηγοριών και μία αριθμητική σειρά:

| Κλάδος | Κόμβος | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Κάθε σειρά δημιουργεί μία κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης της κατηγορίας περιγράφουν τη διαδρομή από αυτό το φύλλο μέχρι τους γονείς του. Για την πρώτη σειρά, η διαδρομή είναι `Consumer > Computers > Laptops`.

Οι δείκτες που επιστρέφει η μέθοδος [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) τρέχουν από το φύλλο προς τα πάνω:

| `get_DataPointLevels()` δείκτης | Λογικό επίπεδο | Παράσταση Treemap | Παράσταση Sunburst |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Ορθογώνιο τιμής | Τμήμα εξωτερικού δακτυλίου |
| `1` | Κόμβος | Ορθογώνιο γονέα ή κεφαλίδα | Τμήμα μεσαίου δακτυλίου |
| `2` | Κλάδος | Ορθογώνιο κορυφαίου επιπέδου ή κεφαλίδα | Τμήμα εσωτερικού δακτυλίου |

Αυτή η σειρά είναι η ίδια και για τους δύο τύπους διαγραμμάτων, ακόμη και αν οι οπτικές διατάξεις διαφέρουν. Ένα τμήμα γονέα μοιράζεται από πολλά φύλλα. Για να το μορφοποιήσετε, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων στην ομάδα. Για παράδειγμα, ο κλάδος `Consumer` ξεκινά με το σημείο `Laptops`, ενώ ο κλώνος `Software` ξεκινά με το σημείο `Licenses`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο σαφής και ασφαλής από τη χρήση ανεξήγητων εκφράσεων όπως `dataPoints->idx_get(0)` ή `dataPoints->idx_get(6)`.

## **Δημιουργία και Προσαρμογή Και των Δύο Τύπων Διαγραμμάτων**

Το ακόλουθο πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Δημιουργεί την ιεραρχία, εμφανίζει την τιμή για `Tablets`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί μια ετικέτα κλάδου και αποθηκεύει την παρουσίαση.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Προσθήκη των κατηγοριών φύλλων. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν αρχίζει μια νέα ομάδα;
    // Οι επόμενες κατηγορίες παραμένουν σε αυτήν την ομάδα μέχρι να οριστεί ένα άλλο στοιχείο.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Εμφάνιση της κατηγορίας και της τιμής στο φύλλο Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Μορφοποίηση του κλάδου Consumer μέσω του πρώτου φύλλου σε αυτόν τον κλάδο.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Μορφοποίηση του κλώνου Software μέσω του πρώτου φύλλου σε αυτόν τον κλώνο.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout επηρεάζει τις ετικέτες γονέα του Treemap· το Sunburst χρησιμοποιεί τμήματα δακτυλίου.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Τα κελιά κατηγοριών και τιμών χρησιμοποιούν την ίδια σειρά φύλλου εργασίας, ώστε οι θέσεις των συλλογών τους να παραμένουν ευθυγραμμισμένες. Όταν εργάζεστε με ένα υπάρχον διάγραμμα αντί να δημιουργήσετε ένα νέο, ελέγξτε πρώτα τις σειρές κατηγοριών και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που σκοπεύετε να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικές Παρατηρήσεις**

### **Διαφορές μεταξύ Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την περιοχή για να μεταφέρει την τιμή και τα ενσωματωμένα ορθογώνια για να μεταφέρει την ιεραρχία. Η μέθοδος [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) ελέγχει πώς εμφανίζονται οι ετικέτες γονέα σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για να μεταφέρει την τιμή και το βάθος του δακτυλίου για να μεταφέρει την ιεραρχία. Η μέθοδος [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) δεν ελέγχει τις ετικέτες των δακτυλίων του.
- Και οι δύο τύποι διαγραμμάτων χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλο‑για‑γονέα που επιστρέφεται από τη μέθοδο [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), ώστε ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων να μπορεί να μοιραστεί.
- Οι τιμές γονέα υπολογίζονται από τα κληρονόμοι φύλλα. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλάδους ή κλώνους.

### **Ταξινόμηση και Σειρά Τμημάτων**

Ο μηχανισμός διάταξης του διαγράμματος καθορίζει την τελική θέση των ορθογωνίων και των τμημάτων δακτυλίων. Ομαδοποιήστε σχετικές σειρές κατηγοριών μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε συγκεκριμένη θέση ορθογωνίου ή γωνία εκκίνησης. Αν η σειρά έχει σημασία, συμπεριλάβετε την στις ετικέτες ή χρησιμοποιήστε τύπο διαγράμματος με ρητό άξονα κατηγοριών.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμο αποτέλεσμα. Αν το διάγραμμα πρέπει να ακολουθεί αλλαγές θέματος, χρησιμοποιήστε χρώματα σχήματος αντί για σταθερές τιμές RGB και αποφύγετε την παράκαμψη κάθε επιπέδου. Ελέγξτε επίσης την αντίθεση της ετικέτας μετά την αλλαγή γεμίσματος κλάδου ή κλώνου.

### **Επιγραφές και Διαθέσιμο Χώρο**

Το PowerPoint μπορεί να κρύβει ή να περικόπτει ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η συντόμευση των ονομάτων κατηγοριών ή η εμφάνιση λιγότερων πεδίων ετικέτας συνήθως παράγει πιο καθαρό αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάζει το όνομα κατηγορίας, το όνομα σειράς και την τιμή μέσω του [IDataLabelFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/), αλλά η ενεργοποίηση όλων των πεδίων συχνά καθιστά τα ιεραρχικά διαγράμματα δύσκολο στην ανάγνωση.

### **Εξαγωγή και Απόδοση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, οι υποστηριζόμενες γεμίσεις και ρυθμίσεις ετικετών αποδίδονται με το διάγραμμα. Η αντικατάσταση γραμματοσειρών και μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη διάσπαση γραμμών ή την ορατότητα ετικετών, γι’ αυτό εγκαταστήστε τις απαιτούμενες γραμματοσειρές και επαληθεύστε τους σημαντικούς στόχους εξαγωγής.

## **ΣΥΧΝΑ ΕΡΩΤΗΣΕΙΣ**

**Γιατί η αλλαγή ενός επιπέδου γονέα επηρεάζει πολλά φύλλα;**

Ένας κλάδος ή κλώνος είναι ένα κοινόχρηστο οπτικό τμήμα. Το [IChartDataPointLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός κληρονόμου φύλλου, αλλά η μορφοποίηση ανήκει στο κοινόχρηστο τμήμα γονέα και όχι μόνο σε αυτό το φύλλο.

**Γιατί λείπει μια ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [IDataLabelFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε αν το τμήμα έχει αρκετό χώρο. Η διάταξη ετικέτας γονέα Treemap, οι διαστάσεις του διαγράμματος, το μήκος της ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός των ενεργοποιημένων πεδίων επηρεάζουν το αν μπορεί να εμφανιστεί μια ετικέτα.

**Μπορώ να ορίσω την ακριβή σειρά ή τις συντεταγμένες των τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά των σειρών πηγής και να διατηρήσετε κάθε ομάδα συνεχόμενη, αλλά δεν μπορείτε να ορίσετε ακριβή ορθογώνια Treemap ή γωνίες Sunburst. Η μηχανή διάταξης του διαγράμματος τα υπολογίζει από την ιεραρχία, τις τιμές και τον διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος παρουσίασης;**

Οι γεμίσεις βάσει θέματος σχεδιάζονται να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά, ή διατηρήστε χρώματα σχήματος όταν προτιμάται η προσαρμογή σε νέο θέμα.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση στις εξαγωγές PDF και εικόνας;**

Ναι, οι υποστηριζόμενες γεμίσεις διαγράμματος και ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για συνεπή αποτελέσματα σε διαφορετικά συστήματα, διαθέστε τις απαιτούμενες γραμματοσειρές και δοκιμάστε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή ετικετών εξαρτάται από τη διάταξη.

## **Δείτε Επίσης**

- [Δημιουργία διαγραμμάτων Treemap](/slides/el/cpp/create-chart/#create-tree-map-charts)
- [Δημιουργία διαγραμμάτων Sunburst](/slides/el/cpp/create-chart/#create-sunburst-charts)
- [Εξαγωγή διαγραμμάτων παρουσίασης](/slides/el/cpp/export-chart/)
- [Διαχείριση θεμάτων παρουσίασης](/slides/el/cpp/presentation-theme/)