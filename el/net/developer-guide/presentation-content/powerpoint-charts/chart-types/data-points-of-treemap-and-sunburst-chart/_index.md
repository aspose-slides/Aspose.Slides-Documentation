---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst σε .NET
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένων
- ετικέτα δεδομένων
- χρώμα κλαδιού
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε ιεραρχικά δεδομένα και να προσαρμόζετε επίπεδα, ετικέτες και χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν το ίδιο είδος ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ενσωματωμένα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το σχεδιάζει ως συγκεντρικούς δακτυλίους: οι ομάδες κορυφαίου επιπέδου βρίσκονται κοντά στο κέντρο, ενώ οι κατηγορίες φύλλου βρίσκονται στον εξωτερικό δακτύλιο.

Στο Aspose.Slides για .NET, κάθε αριθμητική τιμή είναι ένα [IChartDataPoint](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/). Η συλλογή [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) παρέχει πρόσβαση στο φύλλο και στα γονικά του ομάδες. Αυτό το άρθρο εξηγεί αυτή τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τους δύο τύπους διαγραμμάτων από τα ίδια δείγματα δεδομένων.

![Διάγραμμα Treemap με κλαδιά Καταναλωτής και Επιχείρηση](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Καταναλωτής και Επιχείρηση](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το παρακάτω δείγμα έχει τρία επίπεδα κατηγοριών και μία αριθμητική σειρά:

| Κλαδί | Στέλεχος | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Καταναλωτής | Υπολογιστές | Φορητοί Υπολογιστές | 12 |
| Καταναλωτής | Υπολογιστές | Σταθεροί Υπολογιστές | 8 |
| Καταναλωτής | Κινητές Συσκευές | Τηλέφωνα | 15 |
| Καταναλωτής | Κινητές Συσκευές | Ταμπλετ | 6 |
| Επιχείρηση | Υπηρεσίες | Συμβουλευτικές Υπηρεσίες | 10 |
| Επιχείρηση | Υπηρεσίες | Υποστήριξη | 7 |
| Επιχείρηση | Λογισμικό | Άδειες | 11 |
| Επιχείρηση | Λογισμικό | Συνδρομές | 14 |

Κάθε γραμμή δημιουργεί μία κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης της κατηγορίας περιγράφουν τη διαδρομή από αυτό το φύλλο προς τους γονείς του. Για την πρώτη γραμμή, η διαδρομή είναι `Καταναλωτής > Υπολογιστές > Φορητοί Υπολογιστές`.

Οι δείκτες στη [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) τρέχουν από το φύλλο προς τα πάνω:

| `DataPointLevels` δείκτης | Λογικό επίπεδο | Αναπαράσταση Treemap | Αναπαράσταση Sunburst |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Ορθογώνιο τιμής | Τμήμα εξωτερικού δακτυλίου |
| `1` | Στέλεχος | Γονικό ορθογώνιο ή κεφαλίδα | Τμήμα μεσαίου δακτυλίου |
| `2` | Κλαδί | Ορθογώνιο κορυφαίου επιπέδου ή κεφαλίδα | Τμήμα εσωτερικού δακτυλίου |

Αυτή η σειρά είναι η ίδια και για τους δύο τύπους διαγραμμάτων, ακόμα κι αν οι οπτικές διατάξεις τους διαφέρουν. Ένα γονικό τμήμα μοιράζεται από πολλά φύλλα. Για να μορφοποιηθεί, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων στην ομάδα αυτή. Για παράδειγμα, το κλαδί `Καταναλωτής` ξεκινά με το σημείο `Φορητοί Υπολογιστές`, ενώ το στέλεχος `Λογισμικό` ξεκινά με το σημείο `Άδειες`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο σαφής και ασφαλής από τη χρήση ασαφών εκφράσεων όπως `dataPoints[0]` ή `dataPoints[6]`.

## **Δημιουργία και Προσαρμογή Και των Δύο Τύπων Διαγραμμάτων**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Κατασκευάζει την ιεραρχία, εμφανίζει την τιμή για `Tablets`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί μια ετικέτα κλαδιού και αποθηκεύει την παρουσίαση.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Προσθέστε τις κατηγορίες φύλλου. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν ξεκινά μια νέα ομάδα;
    // Οι παρακάτω κατηγορίες παραμένουν σε αυτήν την ομάδα μέχρι να οριστεί ένα άλλο στοιχείο.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Εμφανίστε την κατηγορία και την τιμή στο φύλλο Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Μορφοποιήστε το κλαδί Consumer μέσω του πρώτου φύλλου σε αυτό το κλαδί.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Μορφοποιήστε το στέλεχος Software μέσω του πρώτου φύλλου σε αυτό το στέλεχος.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // Το ParentLabelLayout επηρεάζει τις ετικέτες γονέα στο Treemap· το Sunburst χρησιμοποιεί τμήματα δακτυλίων.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Τα κελιά κατηγορίας και τιμής χρησιμοποιούν την ίδια σειρά φύλλου εργασίας, έτσι οι θέσεις των συλλογών τους παραμένουν ευθυγραμμισμένες. Όταν εργάζεστε με υπάρχον διάγραμμα αντί να δημιουργήσετε ένα, εξετάστε πρώτα τις σειρές κατηγοριών και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που σκοπεύετε να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικές Παρατηρήσεις**

### **Διαφορές μεταξύ Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την περιοχή για την επικοινωνία της τιμής και ενσωματωμένα ορθογώνια για την επικοινωνία της ιεραρχίας. Η ιδιότητα [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/parentlabellayout/) ελέγχει πώς εμφανίζονται οι ετικέτες γονέα σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για την επικοινωνία της τιμής και το βάθος του δακτυλίου για την επικοινωνία της ιεραρχίας. Η [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/parentlabellayout/) δεν ελέγχει τις ετικέτες του δακτυλίου του.
- Και οι δύο τύποι διαγραμμάτων χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλο‑για‑γονέα στα `DataPointLevels`, έτσι ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων μπορεί να κοινοποιηθεί.
- Οι τιμές γονέα υπολογίζονται από τα καταξιωμένα φύλλα τους. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλαδιά ή στελέχη.

### **Ταξινόμηση και Σειρά Τμημάτων**

Η μηχανή διάταξης του διαγράμματος καθορίζει την τελική τοποθέτηση των ορθογωνίων και των τμημάτων του δακτυλίου. Οργανώστε σχετικές σειρές κατηγοριών μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε συγκεκριμένη θέση ορθογωνίου ή γωνία εκκίνησης. Αν η σειρά έχει σημασία, συμπεριλάβετε την στις ετικέτες ή χρησιμοποιήστε τύπο διαγράμματος με ρητό άξονα κατηγορίας.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμο αποτέλεσμα. Αν το διάγραμμα πρέπει να ακολουθεί αλλαγές θέματος, χρησιμοποιήστε χρώματα σχήματος αντί για σταθερές τιμές RGB και αποφύγετε την αντικατάσταση κάθε επιπέδου. Επίσης ελέγξτε την αντίθεση των ετικετών μετά την αλλαγή γεμίσης κλαδιού ή στελέχους.

### **Ετικέτες και Διαθέσιμος Χώρος**

Το PowerPoint μπορεί να κρύψει ή να περικοπεί ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η σύντμηση ονομάτων κατηγοριών ή η εμφάνιση λιγότερων πεδίων ετικέτας συνήθως παράγει πιο σαφές αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάσει το όνομα κατηγορίας, το όνομα σειράς και την τιμή μέσω του [IDataLabelFormat](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatalabelformat/), αλλά η ενεργοποίηση κάθε πεδίου συχνά καθιστά τα ιεραρχικά διαγράμματα δύσκολα στην ανάγνωση.

### **Εξαγωγή και Απεικόνιση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, οι υποστηριζόμενες γεμίσεις και ρυθμίσεις ετικετών αποδίδονται με το διάγραμμα. Η αντικατάσταση γραμματοσειράς και οι μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη διαστρωμάτωση ή την ορατότητα ετικετών, επομένως εγκαταστήστε τις απαιτούμενες γραμματοσειρές και επαληθεύστε τους σημαντικούς προορισμούς εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί η αλλαγή ενός γονικού επιπέδου επηρεάζει πολλά φύλλα;**

Ένα κλαδί ή στέλεχος είναι ένα κοινόχρηστο οπτικό τμήμα. Το [IChartDataPointLevel](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός καταξιωμένου φύλλου, αλλά η μορφοποίηση ανήκει στο κοινόχρηστο γονικό τμήμα και όχι μόνο σε αυτό το φύλλο.

**Γιατί λείπει μια ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [IDataLabelFormat](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε αν το τμήμα έχει αρκετό χώρο. Η διάταξη ετικέτας γονέα στο Treemap, οι διαστάσεις του διαγράμματος, το μήκος της ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός των ενεργοποιημένων πεδίων επηρεάζουν όλα εάν η ετικέτα μπορεί να εμφανιστεί.

**Μπορώ να ορίσω την ακριβή σειρά ή τις συντεταγμένες των τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά των γραμμών πηγής και να διατηρήσετε κάθε ομάδα συνεχόμενη, αλλά δεν μπορείτε να ορίσετε ακριβείς ορθογώνιους περιορισμούς Treemap ή γωνίες Sunburst. Η μηχανή διάταξης του διαγράμματος τα υπολογίζει από την ιεραρχία, τις τιμές και τον διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος της παρουσίασης;**

Οι γεμίσεις βασισμένες σε θέμα προορίζονται να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά, ή διατηρήστε χρώματα σχήματος όταν προτιμάται η προσαρμογή σε νέο θέμα.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση στις εξαγωγές PDF και εικόνας;**

Ναι, οι υποστηριζόμενες γεμίσεις διαγράμματος και οι ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για ομοιόμορφα αποτελέσματα μεταξύ συστημάτων, κάντε διαθέσιμες τις απαιτούμενες γραμματοσειρές και ελέγξτε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή των ετικετών εξαρτάται από τη διάταξη.

## **Δείτε επίσης**

- [Δημιουργία διαγραμμάτων Treemap](/slides/el/net/create-chart/#create-tree-map-charts)
- [Δημιουργία διαγραμμάτων Sunburst](/slides/el/net/create-chart/#create-sunburst-charts)
- [Εξαγωγή διαγραμμάτων παρουσίασης](/slides/el/net/export-chart/)
- [Διαχείριση θεμάτων παρουσίασης](/slides/el/net/presentation-theme/)