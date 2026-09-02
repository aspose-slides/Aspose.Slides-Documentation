---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst χρησιμοποιώντας JavaScript
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένων
- ετικέτα δεδομένων
- χρώμα κλάδου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε ιεραρχικά δεδομένα και να προσαρμόσετε επίπεδα, ετικέτες και χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν το ίδιο είδος ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ενσωματωμένα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το σχεδιάζει ως συνευθυμενικούς δακτυλίους: οι ομάδες ανώτερου επιπέδου βρίσκονται κοντά στο κέντρο, ενώ οι κατηγορίες φύλλων είναι στον εξωτερικό δακτύλιο.

Στο Aspose.Slides για Node.js μέσω Java, κάθε αριθμητική τιμή είναι ένα [ChartDataPoint](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatapoint/). Η μέθοδος [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) παρέχει πρόσβαση στο φύλλο και στις γονικές του ομάδες. Αυτό το άρθρο εξηγεί αυτήν τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τους δύο τύπους διαγραμμάτων από τα ίδια δείγματα δεδομένων.

![Διάγραμμα Treemap με κλάδους Καταναλωτής και Επιχείρηση](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Καταναλωτής και Επιχείρηση](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το παρακάτω παράδειγμα έχει τρία επίπεδα κατηγοριών και μία αριθμητική σειρά:

| Κλάδος | Στέλεχος | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Καταναλωτής | Υπολογιστές | Φορητοί Υπολογιστές | 12 |
| Καταναλωτής | Υπολογιστές | Σταθεροί Υπολογιστές | 8 |
| Καταναλωτής | Κινητά | Τηλέφωνα | 15 |
| Καταναλωτής | Κινητά | Ταμπλέτες | 6 |
| Επιχείρηση | Υπηρεσίες | Συμβουλευτική | 10 |
| Επιχείρηση | Υπηρεσίες | Υποστήριξη | 7 |
| Επιχείρηση | Λογισμικό | Άδειες | 11 |
| Επιχείρηση | Λογισμικό | Συνδρομές | 14 |

Κάθε γραμμή δημιουργεί μια κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης κατηγοριών περιγράφουν τη διαδρομή από αυτό το φύλλο προς τους γονείς του. Για την πρώτη γραμμή, η διαδρομή είναι `Καταναλωτής > Υπολογιστές > Φορητοί Υπολογιστές`.

Οι δείκτες που επιστρέφει η [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) τρέχουν από το φύλλο προς τα πάνω:

| Δείκτης `getDataPointLevels()` | Λογικό επίπεδο | Αναπαράσταση Treemap | Αναπαράσταση Sunburst |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Ορθογώνιο τιμής | Τμήμα εξωτερικού δακτυλίου |
| `1` | Στέλεχος | Γονικό ορθογώνιο ή κεφαλίδα | Τμήμα μεσαίου δακτυλίου |
| `2` | Κλάδος | Ορθογώνιο ή κεφαλίδα ανώτερου επιπέδου | Τμήμα εσωτερικού δακτυλίου |

Αυτή η σειρά είναι η ίδια και για τους δύο τύπους διαγραμμάτων, ακόμη και αν οι οπτικές διατάξεις διαφέρουν. Ένα γονικό τμήμα μοιράζεται από πολλά φύλλα. Για να το μορφοποιήσετε, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων στην ομάδα. Για παράδειγμα, ο κλάδος `Καταναλωτής` αρχίζει με το σημείο `Φορητοί Υπολογιστές`, ενώ το στέλεχος `Λογισμικό` αρχίζει με το σημείο `Άδειες`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο σαφής και ασφαλής από τη χρήση ανεξήγητων εκφράσεων όπως `dataPoints.get_Item(0)` ή `dataPoints.get_Item(6)`.

## **Δημιουργία και Προσαρμογή Και των Δύο Τύπων Διαγραμμάτων**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Κατασκευάζει την ιεραρχία, εμφανίζει την τιμή για τα `Ταμπλέτες`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί μια ετικέτα κλάδου και αποθηκεύει την παρουσίαση.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Προσθέστε τις κατηγορίες φύλλων. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν ξεκινά μια νέα ομάδα·
        // οι επόμενες κατηγορίες παραμένουν σε αυτήν την ομάδα μέχρι να οριστεί άλλο στοιχείο.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Εμφανίστε την κατηγορία και την τιμή στο φύλλο Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Διαμορφώστε τον κλάδο Consumer μέσω του πρώτου φύλλου σε αυτόν τον κλάδο.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Διαμορφώστε το στέλεχος Software μέσω του πρώτου φύλλου σε αυτό το στέλεχος.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // Το ParentLabelLayout επηρεάζει τις ετικέτες γονέα του Treemap· το Sunburst χρησιμοποιεί τμήματα δακτυλίων.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα κελιά κατηγοριών και οι τιμές χρησιμοποιούν την ίδια γραμμή φύλλου εργασίας, ώστε οι θέσεις των συλλογών να παραμένουν ευθυγραμμισμένες. Όταν εργάζεστε με ένα υπάρχον διάγραμμα αντί να δημιουργήσετε ένα νέο, εξετάστε πρώτα τις γραμμές κατηγοριών και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που σκοπεύετε να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικές Σκέψεις**

### **Διαφορές μεταξύ Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την επιφάνεια για να μεταδώσει την τιμή και ενσωματωμένα ορθογώνια για να μεταδώσει την ιεραρχία. Η μέθοδος [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) ελέγχει πώς εμφανίζονται οι ετικέτες γονέα σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για να μεταδώσει την τιμή και το βάθος του δακτυλίου για να μεταδώσει την ιεραρχία. Η [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) δεν ελέγχει τις ετικέτες των δακτυλίων του.
- Και οι δύο τύποι διαγραμμάτων χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλο‑για‑γονέα που επιστρέφει η [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), ώστε ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων να μπορεί να μοιραστεί.
- Οι τιμές γονέα υπολογίζονται από τα ανήλικα φύλλα. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλάδους ή στελέχη.

### **Ταξινόμηση και Σειρά Τμημάτων**

Η μηχανή διάταξης του διαγράμματος καθορίζει την τελική θέση των ορθογωνίων και των τμημάτων δακτυλίου. Ομαδοποιήστε σχετικές γραμμές κατηγοριών μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε συγκεκριμένη θέση ορθογωνίου ή γωνία έναρξης. Εάν η ακολουθία έχει νόημα, συμπεριλάβετε τη στις ετικέτες ή χρησιμοποιήστε τύπο διαγράμματος με ρητό άξονα κατηγορίας.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμη έξοδο. Εάν το διάγραμμα πρέπει να ακολουθεί αλλαγές θέματος, χρησιμοποιήστε χρώματα σχήματος αντί στα σταθερά RGB και αποφύγετε την αντικατάσταση κάθε επιπέδου. Επίσης ελέγξτε την αντίθεση της ετικέτας μετά την αλλαγή γεμίσματος κλάδου ή στελέχους.

### **Ετικέτες και Διαθέσιμος Χώρος**

Το PowerPoint μπορεί να κρύψει ή να αποκόψει ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η συντόμευση των ονομάτων κατηγοριών ή η εμφάνιση λιγότερων πεδίων ετικέτας συνήθως αποδίδουν πιο καθαρό αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάζει το όνομα κατηγορίας, το όνομα σειράς και την τιμή μέσω του [DataLabelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datalabelformat/), αλλά η ενεργοποίηση κάθε πεδίου συχνά κάνει τα ιεραρχικά διαγράμματα δύσκολο στην ανάγνωση.

### **Εξαγωγή και Απόδοση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, οι υποστηριζόμενες γεμίσεις και οι ρυθμίσεις ετικετών αποδίδονται με το διάγραμμα. Η αντικατάσταση γραμματοσειράς και μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη στίξη κειμένου ή την ορατότητα ετικετών, γι’ αυτό εγκαταστήστε τις απαιτούμενες γραμματοσειρές και επαληθεύστε τους σημαντικούς στόχους εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί η αλλαγή ενός γονικού επιπέδου επηρεάζει πολλά φύλλα;**

Ένας κλάδος ή στέλεχος είναι ένα κοινόχορο τμήμα. Το [ChartDataPointLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός απογόνου φύλλου, αλλά η μορφοποίηση ανήκει στο κοινόχρηστο γονικό τμήμα και όχι μόνο σε εκείνο το φύλλο.

**Γιατί λείπει η ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [DataLabelFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε αν το τμήμα έχει αρκετό χώρο. Η διάταξη ετικετών γονέα Treemap, οι διαστάσεις διαγράμματος, το μήκος ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός των ενεργοποιημένων πεδίων επηρεάζουν το αν η ετικέτα μπορεί να εμφανιστεί.

**Μπορώ να ορίσω την ακριβή σειρά ή τις συντεταγμένες των τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά γραμμών προέλευσης και να κρατήσετε κάθε ομάδα συνεχόμενη, αλλά δεν μπορείτε να ορίσετε τις ακριβείς θέσεις ορθογωνίων Treemap ή τις γωνίες Sunburst. Η μηχανή διάταξης του διαγράμματος τις υπολογίζει από την ιεραρχία, τις τιμές και τον διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος παρουσίασης;**

Οι γεμίσεις βασισμένες σε θέμα προορίζονται να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά ή διατηρήστε χρώματα σχήματος όταν προτιμάται η προσαρμογή σε νέο θέμα.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση σε εξαγωγές PDF και εικόνας;**

Ναι, οι υποστηριζόμενες γεμίσεις διαγράμματος και οι ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για συνεπή αποτελέσματα σε διαφορετικά συστήματα, καθορίστε τις απαιτούμενες γραμματοσειρές και δοκιμάστε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή ετικετών εξαρτάται από τη διάταξη.

## **Δείτε επίσης**

- [Δημιουργία διαγραμμάτων Treemap](/slides/el/nodejs-java/create-chart/#creating-tree-map-charts)
- [Δημιουργία διαγραμμάτων Sunburst](/slides/el/nodejs-java/create-chart/#creating-sunburst-charts)
- [Εξαγωγή διαγραμμάτων παρουσίασης](/slides/el/nodejs-java/export-chart/)
- [Διαχείριση θεμάτων παρουσίασης](/slides/el/nodejs-java/presentation-theme/)