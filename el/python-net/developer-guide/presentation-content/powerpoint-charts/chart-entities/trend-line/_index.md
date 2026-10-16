---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε Python
linktitle: Γραμμή Τάσης
type: docs
url: /el/python-net/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides για Python μέσω .NET — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης στα διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινούμενου μέσου όρου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη ενότητα FAQ σχετικά με τις τιμές προώθησης και ανάστροφης προβολής της γραμμής τάσης και το εάν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Χρησιμοποιήστε [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπο της με το [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Το παράδειγμα δημιουργεί ένα ομαδοποιημένο ενκόνι διαγράμματος με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε καθεμία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή R‑τετράγωνο μέσω του [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) και του [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί το [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) για προσαρμοσμένη ετικέτα. Ο μέσος κινούμενος όρος χρησιμοποιεί μια [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) τριών σημείων δεδομένων και ένα προσαρμοσμένο [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Η πολυωνυμική γραμμή τάσης έχει [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) τρία και επεκτείνει μία κατηγορία προς τα εμπρός μέσω του [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω του [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```
## **Ορισμός Σημείου Τομής Γραμμής Τάσης**

Χρησιμοποιήστε το [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) για να καθορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για τις γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής μπορεί να χρειάζεται να ξεκινά με γνωστά σταθερά κόστη 100, ακόμη και όταν μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδεικνύουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, ο καθορισμός του σημείου τομής περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την περιοριστική συνθήκη. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταύρωσης των αξόνων ελέγχουν πού συναντούν τους άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα scatter (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με το προεπιλεγμένο αυτόματο σημείο τομής, ορίζει το σημείο τομής στο 100 και αποθηκεύει ένα δεύτερο αρχείο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση του σημείου τομής. Η γραμμή τάσης εμφανίζει την εξίσωση της και επεκτείνεται πίσω στο X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Με την αυτόματη υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ο ορισμός του σημείου τομής στο 100 παράγει περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματο σημείο τομής | Σταθερό σημείο τομής 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένο σημείο τομής 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερό σημείο τομής 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες αξόνων. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να εμφανιστούν τα σημεία τομής τους.

Από προεπιλογή, η ιδιότητα περιέχει `float("nan")`, που αντιπροσωπεύει ένα απροσδιόριστο σημείο τομής αντί για μηδέν. Το σημείο τομής τότε υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω από το διάγραμμα, αντί για μια γραμμή τάσης που υπολογίζεται από τα δεδομένα της σειράς. Αυτό το παράδειγμα χρησιμοποιεί το [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται σε συντεταγμένες διαφάνειας, μετρημένες σε σημεία, έτσι ώστε να ξεκινά στο αριστερό άκρο του διαγράμματος και να βρίσκεται στο μέσο του ύψους του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Το [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) δίνει στη γραμμή ένα στερεό κόκκινο χρώμα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```
## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/πίσω: για διαγράμματα scatter (XY) — σε μονάδες άξονα· για μη‑scatter διαγράμματα — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τις ενέργειες αυτές. Μια μέθοδος είναι επίσης διαθέσιμη για [εξαγωγή εικόνας του διαγράμματος](/slides/el/python-net/create-shape-thumbnails/).