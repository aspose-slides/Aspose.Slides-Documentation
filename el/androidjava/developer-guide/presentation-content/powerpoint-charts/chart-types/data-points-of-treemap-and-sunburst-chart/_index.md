---
title: Προσαρμογή σημείων δεδομένων σε διαγράμματα Treemap και Sunburst στο Android
linktitle: Σημεία δεδομένων σε διαγράμματα Treemap και Sunburst
type: docs
url: /el/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένου
- ετικέτα δεδομένων
- χρώμα κλαδιού
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε ιεραρχικά δεδομένα και να προσαρμόσετε τα επίπεδα, τις ετικέτες και τα χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν το ίδιο είδος ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ενσωματωμένα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το σχεδιάζει ως συγκεντρωτικούς δακτυλίους: οι ομάδες κορυφαίου επιπέδου βρίσκονται κοντά στο κέντρο, και οι κατηγορίες φύλλου είναι στον εξωτερικό δακτύλιο.

Στο Aspose.Slides for Android μέσω Java, κάθε αριθμητική τιμή είναι ένα [IChartDataPoint](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/). Η μέθοδος [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) παρέχει πρόσβαση στο φύλλο και στις γονικές του ομάδες. Αυτό το άρθρο εξηγεί αυτή τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τους δύο τύπους διαγραμμάτων από τα ίδια δείγματα δεδομένων.

![Διάγραμμα Treemap με κλαδιά Καταναλωτή και Επιχειρήσεων](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Καταναλωτή και Επιχειρήσεων](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το δείγμα που χρησιμοποιείται παρακάτω έχει τρία επίπεδα κατηγοριών και μια αριθμητική σειρά:

| Κλάδος | Κλαδί | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Κάθε γραμμή δημιουργεί μία κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης κατηγοριών περιγράφουν τη διαδρομή από εκείνο το φύλλο προς τους γονείς του. Για την πρώτη γραμμή, η διαδρομή είναι `Consumer > Computers > Laptops`.

Οι δείκτες που επιστρέφει η μέθοδος [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) τρέχουν από το φύλλο προς τα πάνω:

| `getDataPointLevels()` δείκτης | Λογικό επίπεδο | Παράσταση Treemap | Παράσταση Sunburst |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Ορθογώνιο τιμής | Τμήμα εξωτερικού δακτυλίου |
| `1` | Κλαδί | Γονικό ορθογώνιο ή επικεφαλίδα | Τμήμα μεσαίου δακτυλίου |
| `2` | Κλάδος | Ορθογώνιο ή επικεφαλίδα κορυφαίου επιπέδου | Τμήμα εσωτερικού δακτυλίου |

Αυτή η σειρά είναι η ίδια και για τους δύο τύπους διαγραμμάτων, ακόμη και αν οι οπτικές τους διατάξεις διαφέρουν. Ένα γονικό τμήμα μοιράζεται από πολλά φύλλα. Για να το μορφοποιήσετε, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων σε εκείνη την ομάδα. Για παράδειγμα, το κλαδί `Consumer` ξεκινά με το σημείο `Laptops`, ενώ το κλαδί `Software` ξεκινά με το σημείο `Licenses`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο σαφής και ασφαλής από τη χρήση ανεξήγητων εκφράσεων όπως `dataPoints.get_Item(0)` ή `dataPoints.get_Item(6)`.

## **Δημιουργία και Προσαρμογή και των Δύο Τύπων Διαγράμματος**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Κατασκευάζει την ιεραρχία, εμφανίζει την τιμή για το `Tablets`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί μια ετικέτα κλαδίου και αποθηκεύει την παρουσίαση.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Προσθέστε τις κατηγορίες φύλλου. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν ξεκινά μια νέα ομάδα;
        // οι επόμενες κατηγορίες παραμένουν σε αυτήν την ομάδα μέχρι να οριστεί άλλο στοιχείο.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Εμφανίστε την κατηγορία και την τιμή στο φύλλο Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Μορφοποιήστε το κλαδί Consumer μέσω του πρώτου φύλλου σε αυτό το κλαδί.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Μορφοποιήστε το κλαδί-μέσο Software μέσω του πρώτου φύλλου σε αυτό το κλαδί-μέσο.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // Το ParentLabelLayout επηρεάζει τις ετικέτες γονέα στο Treemap· το Sunburst χρησιμοποιεί τμήματα δακτυλίου.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα κελιά κατηγοριών και τα κελιά τιμών χρησιμοποιούν την ίδια σειρά φύλλου εργασίας, έτσι οι θέσεις των συλλογών τους παραμένουν συγχρονισμένες. Όταν εργάζεστε με ένα υπάρχον διάγραμμα αντί να δημιουργήσετε ένα νέο, ελέγξτε πρώτα τις σειρές κατηγορίας και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που προορίζεται να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικές Παρατηρήσεις**

### **Διαφορές Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την περιοχή για να μεταδώσει την τιμή και ενσωματωμένα ορθογώνια για να μεταδώσει την ιεραρχία. Η μέθοδος [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) ελέγχει πώς εμφανίζονται οι ετικέτες γονέα σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για να μεταδώσει την τιμή και το βάθος του δακτυλίου για την ιεραρχία. Η [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) δεν ελέγχει τις ετικέτες των δακτυλίων του.
- Και οι δύο τύποι διαγράμματος χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλου-προς-γονέα που επιστρέφει η [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), επομένως ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων μπορεί να μοιραστεί.
- Οι τιμές των γονέων υπολογίζονται από τα προέλθοντα φύλλα. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλαδιά ή κλαδιά-μέσου.

### **Ταξινόμηση και Σειρά Τμημάτων**

Ο κινητήρας διάταξης του διαγράμματος καθορίζει την τελική τοποθέτηση των ορθογωνίων και των τμημάτων δακτυλίου. Ομαδοποιήστε σχετικές σειρές κατηγορίας μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε συγκεκριμένη θέση ορθογωνίου ή γωνία εκκίνησης. Εάν η σειρά έχει σημασία, συμπεριλάβετε την στις ετικέτες ή χρησιμοποιήστε τύπο διαγράμματος με ρητό άξονα κατηγοριών.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμο αποτέλεσμα. Εάν το διάγραμμα πρέπει να ακολουθεί αλλαγές θέματος, χρησιμοποιήστε χρώματα σχήματος αντί σταθερών τιμών RGB και αποφύγετε την υπερβολική αντικατάσταση κάθε επιπέδου. Επίσης, ελέγξτε την αντίθεση ετικέτας μετά την αλλαγή γεμίσματος κλαδίου ή κλαδιού.

### **Ετικέτες και Διαθέσιμο Χώρο**

Το PowerPoint μπορεί να κρύψει ή να αποκόψει ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η συντόμευση των ονομάτων κατηγοριών ή η εμφάνιση λιγότερων πεδίων ετικέτας συνήθως παράγει πιο καθαρό αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάσει το όνομα κατηγορίας, το όνομα σειράς και την τιμή μέσω του [IDataLabelFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatalabelformat/), αλλά η ενεργοποίηση όλων των πεδίων συχνά κάνει τα ιεραρχικά διαγράμματα δύσκολο στην ανάγνωση.

### **Εξαγωγή και Απόδοση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, οι υποστηριζόμενες γεμίσεις και οι ρυθμίσεις ετικετών αποδίδονται μαζί με το διάγραμμα. Η αντικατάσταση γραμματοσειρών και οι μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη διάσπαση γραμμής ή την ορατότητα ετικέτας, επομένως εγκαταστήστε τις απαιτούμενες γραμματοσειρές και επαληθεύστε τους σημαντικούς στόχους εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί η αλλαγή ενός επιπέδου γονέα επηρεάζει πολλά φύλλα;**

Ένα κλαδί ή κλαδί-μέσου είναι ένα κοινόχρηστο οπτικό τμήμα. Το [IChartDataPointLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός απογόνου φύλλου, αλλά η μορφοποίηση ανήκει στο κοινόχρηστο γονικό τμήμα και όχι μόνο σε εκείνο το φύλλο.

**Γιατί λείπει μια ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [IDataLabelFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε εάν το τμήμα έχει επαρκή χώρο. Η διάταξη γονικής ετικέτας Treemap, οι διαστάσεις του διαγράμματος, το μήκος της ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός ενεργοποιημένων πεδίων επηρεάζουν αν μπορεί να εμφανιστεί μια ετικέτα.

**Μπορώ να ορίσω ακριβή σειρά ή συντεταγμένες τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά των πηγών‑γραμμών και να διατηρήσετε κάθε ομάδα συνεχόμενη, αλλά δεν μπορείτε να ορίσετε ακριβείς ορθογώνιες περιοχές Treemap ή γωνίες Sunburst. Ο κινητήρας διάταξης του διαγράμματος τις υπολογίζει από την ιεραρχία, τις τιμές και τον διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος της παρουσίασης;**

Οι γεμίσεις βασισμένες σε θέμα δημιουργούνται για να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά, ή διατηρήστε χρώματα σχήματος όταν η προσαρμογή σε νέο θέμα είναι προτιμότερη.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση σε εξαγωγές PDF και εικόνας;**

Ναι, οι υποστηριζόμενες γεμίσεις διαγράμματος και οι ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για συνεπή αποτελέσματα σε διάφορα συστήματα, διασφαλίστε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες και δοκιμάστε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή ετικετών εξαρτάται από τη διάταξη.

## **Δείτε επίσης**

- [Create Treemap charts](/slides/el/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/el/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/el/androidjava/export-chart/)
- [Manage presentation themes](/slides/el/androidjava/presentation-theme/)