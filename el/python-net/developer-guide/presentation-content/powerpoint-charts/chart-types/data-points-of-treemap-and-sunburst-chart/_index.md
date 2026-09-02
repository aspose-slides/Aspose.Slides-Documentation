---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst σε Python
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- ιεραρχικό διάγραμμα
- σημείο δεδομένων
- ετικέτα δεδομένων
- χρώμα κλάδου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε ιεραρχικά δεδομένα και να προσαρμόζετε επίπεδα, ετικέτες και χρώματα σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Τα διαγράμματα Treemap και Sunburst εμφανίζουν τον ίδιο τύπο ιεραρχικών δεδομένων, αλλά χρησιμοποιούν διαφορετικές διατάξεις. Ένα Treemap σχεδιάζει την ιεραρχία ως ένθετα ορθογώνια των οποίων οι περιοχές αντιπροσωπεύουν τις τιμές των φύλλων. Ένα Sunburst το εμφανίζει ως κυκλικές άκρες: οι ομάδες κορυφαίου επιπέδου είναι κοντά στο κέντρο, ενώ οι κατηγορίες φύλλων βρίσκονται στην εξωτερική άκρη.

Στο Aspose.Slides for Python via .NET, κάθε αριθμητική τιμή είναι ένα [ChartDataPoint](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/). Η συλλογή [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) παρέχει πρόσβαση στο φύλλο και στις γονικές του ομάδες. Αυτό το άρθρο εξηγεί αυτή τη χαρτογράφηση και δείχνει πώς να δημιουργήσετε και να μορφοποιήσετε και τους δύο τύπους διαγραμμάτων από τα ίδια δείγματα δεδομένων.

![Διάγραμμα Treemap με κλαδιά Consumer και Business](treemap-hierarchy.png)

![Διάγραμμα Sunburst με την ίδια ιεραρχία Consumer και Business](sunburst-hierarchy.png)

## **Κατανόηση Κατηγοριών, Σημείων Δεδομένων και Επιπέδων**

Το δείγμα που χρησιμοποιείται παρακάτω έχει τρία επίπεδα κατηγοριών και μία αριθμητική σειρά:

| Κλάδος | Υπό-κλάδος | Φύλλο | Έσοδα |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Κάθε γραμμή δημιουργεί μία κατηγορία φύλλου και ένα σημείο δεδομένων. Τα επίπεδα ομαδοποίησης της κατηγορίας περιγράφουν τη διαδρομή από αυτό το φύλλο προς τους γονείς του. Για την πρώτη γραμμή, η διαδρομή είναι `Consumer > Computers > Laptops`.

Οι δείκτες στην [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) τρέχουν από το φύλλο προς τα πάνω:

| Δείκτης `data_point_levels` | Λογικό επίπεδο | Αναπαράσταση Treemap | Αναπαράσταση Sunburst |
| ---: | --- | --- | --- |
| `0` | Φύλλο | Ορθογώνιο τιμής | Τμήμα εξωτερικής άκρης |
| `1` | Υπό-κλάδος | Γονικό ορθογώνιο ή τίτλο | Τμήμα μεσαίας άκρης |
| `2` | Κλάδος | Ορθογώνιο κορυφαίου επιπέδου ή τίτλο | Τμήμα εσωτερικής άκρης |

Αυτή η σειρά είναι η ίδια για τους δύο τύπους διαγραμμάτων, ακόμη και αν οι οπτικές διατάξεις διαφέρουν. Ένα γονικό τμήμα μοιράζεται από πολλά φύλλα. Για να το μορφοποιήσετε, χρησιμοποιήστε το αντίστοιχο επίπεδο του πρώτου σημείου δεδομένων στην ομάδα αυτή. Για παράδειγμα, ο κλάδος `Consumer` ξεκινά με το σημείο `Laptops`, ενώ το υπό-κλαδο `Software` ξεκινά με το σημείο `Licenses`. Η διατήρηση αναφορών σε αυτά τα σημεία είναι πιο καθαρή και ασφαλής από τη χρήση ασαφών εκφράσεων όπως `data_points[0]` ή `data_points[6]`.

## **Δημιουργία και Προσαρμογή Και των Δύο Τύπων Διαγράμματος**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα Treemap στην πρώτη διαφάνεια και ένα Sunburst στη δεύτερη διαφάνεια. Κατασκευάζει την ιεραρχία, εμφανίζει την τιμή για τα `Tablets`, εφαρμόζει σταθερά χρώματα σε επιλεγμένα επίπεδα, μορφοποιεί ετικέτα κλάδου και αποθηκεύει την παρουσίαση.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Προσθέστε τις κατηγορίες φύλλων. Ένα στοιχείο ομαδοποίησης ορίζεται μόνο όταν ξεκινά μια νέα ομάδα·
    # οι επόμενες κατηγορίες παραμένουν σε αυτήν την ομάδα μέχρι να οριστεί άλλο στοιχείο.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Εμφανίστε την κατηγορία και την τιμή στο φύλλο Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Διαμορφώστε τον κλάδο Consumer μέσω του πρώτου φύλλου σε αυτόν τον κλάδο.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Διαμορφώστε το υπό-κλαδο Software μέσω του πρώτου φύλλου σε αυτό το υπό-κλαδο.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # Το parent_label_layout επηρεάζει τις ετικέτες γονέα σε Treemap· το Sunburst χρησιμοποιεί τμήματα άκρης.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Τα κελιά κατηγοριών και τα κελιά τιμών χρησιμοποιούν την ίδια σειρά φύλλου εργασίας, έτσι οι θέσεις των συλλογών τους παραμένουν ευθυγραμμισμένες. Όταν εργάζεστε με ένα υπάρχον διάγραμμα αντί να το δημιουργήσετε, ελέγξτε πρώτα τις σειρές κατηγοριών και αποθηκεύστε ονομαστικές αναφορές στα σημεία δεδομένων και στα επίπεδα που σκοπεύετε να μορφοποιήσετε.

## **Συμπεριφορά και Πρακτικές Παρατηρήσεις**

### **Διαφορές Treemap και Sunburst**

- Ένα Treemap χρησιμοποιεί την περιοχή για να μεταδώσει την τιμή και τα ένθετα ορθογώνια για να μεταδώσει την ιεραρχία. Η ιδιότητα [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/parent_label_layout/) ελέγχει πώς εμφανίζονται οι ετικέτες των γονέων σε αυτόν τον τύπο διαγράμματος.
- Ένα Sunburst χρησιμοποιεί τη γωνία για να μεταδώσει την τιμή και το βάθος της άκρης για να μεταδώσει την ιεραρχία. Η [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/parent_label_layout/) δεν ελέγχει τις ετικέτες των άκρων του.
- Και τα δύο διαγράμματα χρησιμοποιούν τα ίδια επίπεδα ομαδοποίησης κατηγοριών και την ίδια σειρά φύλλου‑προς‑γονέα στο `data_point_levels`, έτσι ο κώδικας δημιουργίας δεδομένων και μορφοποίησης επιπέδων μπορεί να μοιραστεί.
- Οι τιμές των γονέων υπολογίζονται από τα κληρονομημένα φύλλα. Μην προσθέτετε ξεχωριστά αριθμητικά σημεία για κλάδους ή υπό‑κλαδους.

### **Ταξινόμηση και Σειρά Τμημάτων**

Η μηχανή διάταξης του διαγράμματος καθορίζει την τελική τοποθέτηση των ορθογωνίων και των τμημάτων της άκρης. Τοποθετήστε σχετικές σειρές κατηγοριών μαζί πριν τις προσθέσετε, αλλά μην βασίζεστε σε συγκεκριμένη θέση ορθογωνίου ή γωνία εκκίνησης. Αν η ακολουθία έχει σημασία, συμπεριλάβετε την στις ετικέτες ή χρησιμοποιήστε τύπο διαγράμματος με ρητό άξονα κατηγοριών.

### **Θέμα και Σταθερά Χρώματα**

Τα μη μορφοποιημένα επίπεδα διαγράμματος κληρονομούν χρώματα από το θέμα της παρουσίασης. Το παράδειγμα χρησιμοποιεί ρητές γεμίσεις RGB για προβλέψιμο αποτέλεσμα. Αν το διάγραμμα πρέπει να ακολουθεί αλλαγές θέματος, χρησιμοποιήστε χρώματα σχήματος αντί για σταθερές τιμές RGB και αποφύγετε την υπερβολική αντικατάσταση κάθε επιπέδου. Επίσης, ελέγξτε την αντίθεση των ετικετών μετά την αλλαγή γεμίσης κλάδου ή υπό‑κλαδου.

### **Ετικέτες και Διαθέσιμος Χώρος**

Το PowerPoint μπορεί να κρύβει ή να κόβει ετικέτες όταν ένα τμήμα είναι πολύ μικρό. Η αύξηση του μεγέθους του διαγράμματος, η συντόμευση των ονομασιών κατηγοριών ή η μείωση του αριθμού των πεδίων ετικέτας συνήθως παράγει πιο ξεκάθαρο αποτέλεσμα. Μια ετικέτα μπορεί να συνδυάσει το όνομα κατηγορίας, το όνομα σειράς και την τιμή μέσω του [DataLabelFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datalabelformat/), αλλά η ενεργοποίηση κάθε πεδίου συχνά κάνει τα ιεραρχικά διαγράμματα δύσκολα στην ανάγνωση.

### **Εξαγωγή και Απόδοση**

Η αποθήκευση σε PPTX διατηρεί το διάγραμμα επεξεργάσιμο. Όταν το Aspose.Slides αποδίδει την παρουσίαση σε PDF ή εικόνα, οι υποστηριζόμενες γεμίσματα και οι ρυθμίσεις ετικετών αποδίδονται μαζί με το διάγραμμα. Η υποκατάσταση γραμματοσειρών και μικρές διαφορές στον διαθέσιμο χώρο διάταξης μπορούν να αλλάξουν τη μορφοποίηση κειμένου ή την ορατότητα ετικετών, έτσι εγκαταστήστε τις απαραίτητες γραμματοσειρές και επαληθεύστε τους σημαντικούς στόχους εξαγωγής.

## **Συχνές Ερωτήσεις**

**Γιατί η αλλαγή ενός γονικού επιπέδου επηρεάζει πολλά φύλλα;**

Ένας κλάδος ή υπό‑κλαδος είναι κοινό οπτικό τμήμα. Το [ChartDataPointLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/) του μπορεί να προσεγγιστεί μέσω ενός κληρονομημένου φύλλου, αλλά η μορφοποίηση ανήκει στο κοινό γονικό τμήμα και όχι μόνο στο συγκεκριμένο φύλλο.

**Γιατί λείπει μια ετικέτα δεδομένων;**

Πρώτα ενεργοποιήστε τα απαιτούμενα πεδία στο αντικείμενο [DataLabelFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datalabelformat/) της ετικέτας. Στη συνέχεια ελέγξτε αν το τμήμα έχει αρκετό χώρο. Η διάταξη ετικετών γονέα Treemap, οι διαστάσεις διαγράμματος, το μήκος ετικέτας, το μέγεθος γραμματοσειράς και ο αριθμός ενεργοποιημένων πεδίων επηρεάζουν το αν μπορεί να εμφανιστεί μια ετικέτα.

**Μπορώ να ορίσω την ακριβή σειρά ή συντεταγμένες των τμημάτων;**

Μπορείτε να ελέγξετε τη σειρά των πηγών‑γραμμών και να κρατήσετε κάθε ομάδα συνεχόμενη, αλλά δεν μπορείτε να ορίσετε ακριβείς ορθογώνιους Treemap ή γωνίες Sunburst. Η μηχανή διάταξης του διαγράμματος τα υπολογίζει από την ιεραρχία, τις τιμές και τον διαθέσιμο χώρο.

**Γιατί αλλάζουν τα χρώματα μετά την αλλαγή του θέματος παρουσίασης;**

Τα γεμίσματα βασισμένα σε θέμα προορίζονται να ακολουθούν την παλέτα της παρουσίασης. Εφαρμόστε ρητά χρώματα RGB στα επίπεδα που πρέπει να παραμείνουν σταθερά, ή διατηρήστε χρώματα σχήματος όταν προτιμάται η προσαρμογή σε νέο θέμα.

**Θα διατηρηθεί η προσαρμοσμένη μορφοποίηση σε εξαγωγές PDF και εικόνας;**

Ναι, τα υποστηριζόμενα γεμίσματα διαγράμματος και οι ρυθμίσεις ετικετών περιλαμβάνονται κατά την απόδοση. Για συνεπή αποτελέσματα σε διαφορετικά συστήματα, διασφαλίστε τη διαθεσιμότητα των απαιτούμενων γραμματοσειρών και δοκιμάστε το τελικό μέγεθος εξαγωγής, επειδή η προσαρμογή ετικετών εξαρτάται από τη διάταξη.

## **Δείτε Επίσης**

- [Create Treemap charts](/slides/el/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/el/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/el/python-net/export-chart/)
- [Manage presentation themes](/slides/el/python-net/presentation-theme/)