---
title: Προσαρμογή σημείων δεδομένων σε διαγράμματα Treemap και Sunburst σε Python
linktitle: Σημεία δεδομένων σε διαγράμματα Treemap και Sunburst
type: docs
url: /el/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλάδου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σημεία δεδομένων σε διαγράμματα treemap και sunburst με το Aspose.Slides για Python μέσω .NET, συμβατό με μορφές PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ανάμεσα σε άλλους τύπους διαγραμμάτων PowerPoint, υπάρχουν δύο ιεραρχικά—**Treemap** και **Sunburst** (γνωστά επίσης ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi-Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο—από τα φύλλα μέχρι την κορυφή ενός κλαδιού. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επόμενο ένθετο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Το Aspose.Slides for Python via .NET σας επιτρέπει να διαμορφώσετε τα σημεία δεδομένων των διαγραμμάτων Sunburst και Treemap σε Python.

Ακολουθεί ένα διάγραμμα Sunburst όπου τα δεδομένα στη στήλη Series1 ορίζουν τα φύλλα, ενώ οι άλλες στήλες ορίζουν ιεραρχικά σημεία δεδομένων:

![Sunburst chart example](sunburst_example.png)

Ας ξεκινήσουμε προσθέτοντας ένα νέο διάγραμμα Sunburst στην παρουσίαση:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**Δημιουργία διαγραμμάτων Sunburst**](/slides/el/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Εάν χρειάζεται να διαμορφώσετε σημεία δεδομένων διαγράμματος, χρησιμοποιήστε τα παρακάτω API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/), και η ιδιότητα [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) . Παρέχουν πρόσβαση στη μορφοποίηση σημείων δεδομένων σε διαγράμματα Treemap και Sunburst. Το [ChartDataPointLevelsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) χρησιμοποιείται για πρόσβαση σε κατηγορίες πολλαπλών επιπέδων· καθορίζει ένα περιέκτη αντικειμένων [ChartDataPointLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/). Είναι ουσιαστικά ένας περιτύλιγμα γύρω από το [ChartCategoryLevelsManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartcategorylevelsmanager/) με πρόσθετες ιδιότητες ειδικές για σημεία δεδομένων. Ο τύπος [ChartDataPointLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/) εκθέτει δύο ιδιότητες—[format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/format/) και [label](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatapointlevel/label/)—που παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.

## **Προβολή τιμών σημείων δεδομένων**

Αυτή η ενότητα δείχνει πώς να εμφανίσετε την τιμή για μεμονωμένα σημεία δεδομένων σε διαγράμματα Treemap και Sunburst. Θα δείτε πώς να ενεργοποιήσετε τις ετικέτες τιμών για επιλεγμένα σημεία.

Εμφανίστε την τιμή του σημείου δεδομένων "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Ορισμός ετικετών και χρωμάτων για σημεία δεδομένων**

Αυτή η ενότητα δείχνει πώς να ορίσετε προσαρμοσμένες ετικέτες και χρώματα για μεμονωμένα σημεία δεδομένων σε διαγράμματα Treemap και Sunburst. Θα μάθετε πώς να αποκτήσετε πρόσβαση σε ένα συγκεκριμένο σημείο δεδομένων, να αντιστοιχίσετε μια ετικέτα και να εφαρμόσετε γεμιστό χρώμα για να τονίσετε σημαντικούς κόμβους.

Ορίστε την ετικέτα δεδομένων "Branch 1" ώστε να εμφανίζει το όνομα της σειράς ("Series1") αντί για το όνομα της κατηγορίας, και έπειτα ορίστε το χρώμα κειμένου σε κίτρινο:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Ορισμός χρωμάτων κλάδων για σημεία δεδομένων**

Χρησιμοποιήστε χρώματα κλάδων για να ελέγξετε πώς οι γονικές και θυγατρικές κόμβοι ομαδοποιούνται οπτικά σε διαγράμματα Treemap και Sunburst. Αυτή η ενότητα δείχνει πώς να ορίσετε προσαρμοσμένο χρώμα κλάδου για ένα συγκεκριμένο σημείο δεδομένων ώστε να τονίσετε σημαντικά υποδέντρα και να βελτιώσετε την αναγνωσιμότητα του διαγράμματος.

Αλλάξτε το χρώμα του κλάδου "Stem 4":

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**

Όχι. Το PowerPoint ταξινομεί τα τμήματα αυτόματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Το Aspose.Slides αντικατοπτρίζει αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά άμεσα· μπορείτε να το πετύχετε με προεπεξεργασία των δεδομένων.

**Πώς το θέμα της παρουσίασης επηρεάζει τα χρώματα των τμημάτων και των ετικετών;**

Τα χρώματα του διαγράμματος κληρονομούν το [theme/palette](/slides/el/python-net/presentation-theme/) της παρουσίασης, εκτός αν ορίσετε ρητά γεμίσματα/γραμματοσειρές. Για συνεπή αποτελέσματα, καθορίστε γεμίσματα στερεά και μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλάδων και τις ρυθμίσεις ετικετών;**

Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γεμίσματα, ετικέτες) διατηρούνται στα αρχεία εξόδου επειδή το Aspose.Slides αποδίδει το διάγραμμα με την εφαρμοσμένη μορφοποίηση.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**

Ναι. Μετά την επικύρωση της διάταξης του διαγράμματος, τα `actual_x`/`actual_y` είναι διαθέσιμα για στοιχεία (π.χ., ένα [DataLabel](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datalabel/)), που βοηθά στη ακριβή τοποθέτηση επικαλύψεων.