---
title: Μορφοποίηση διαγραμμάτων σε παρουσιάσεις με Python
linktitle: Μορφοποίηση διαγράμματος
type: docs
weight: 60
url: /el/python-net/chart-formatting/
keywords:
- μορφοποίηση διαγράμματος
- μορφοποίηση διαγράμματος
- οντότητα διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Python μέσω .NET και αναβαθμίστε την παρουσίαση PowerPoint σας με προσαρμοσμένους άξονες, γραμματοσειρές, αριθμητικές μορφές και στρογγυλεμένα περιγράμματα διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόσετε τα βασικά στοιχεία του διαγράμματος όπως οι άξονες, οι γραμμές πλέγματος, οι τίτλοι, οι υπομνήματα, η περιοχή σχεδίασης και τα γεμίσματα τοίχους για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, δείχνει πώς να ορίσετε τις ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προρυθμισμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση.

Για ξεχωριστά γεμίσματα και περιγράμματα σε ανοδικά και καθοδικά διαστήματα, δείτε το [παράδειγμα διαγράμματος μετοχών](/slides/el/python-net/create-chart/#create-stock-charts).

## **Μορφοποίηση Στοιχείων Διαγράμματος**

Χρησιμοποιήστε [Διάγραμμα](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) για να μορφοποιήσετε τους τίτλους διαγράμματος, τους άξονες, τις γραμμές πλέγματος, τα υπομνήματα και την περιοχή σχεδίασης. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με δείκτες και προεπιλεγμένα δεδομένα, στη συνέχεια εφαρμόζει ξεχωριστά στυλ κειμένου και γραμμής στους άξονες τιμής και κατηγορίας. Τα μεγέθη γραμματοσειράς και τα πλάτη γραμμών καθορίζονται σε points· οι ετικέτες κατηγορίας περιστρέφονται κατά 45 μοίρες.

Ο άξονας τιμής χρησιμοποιεί [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ανεξάρτητα από τα κελιά προέλευσης. Η κλίμακά του κυμαίνεται από -2 έως 15, με κύρια διαστήματα των 2 και μικρά διαστήματα των 0,5. Το παράδειγμα επίσης συνδυάζει μορφοποίηση ποσοστών με το [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ορισμένο σε χιλιάδες, επομένως προσαρμόστε αυτές τις ρυθμίσεις στο νόημα και το μέγεθος των δεδομένων σας. Το υπόμνημα παραμένει έξω από την περιοχή σχεδίασης επειδή το [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) είναι απενεργοποιημένο. Τα γεμίσματα του πίσω τοίχου και του πατώματος ρυθμίζονται μέσω των [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) και [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), αλλά αυτές οι επιφάνειες είναι ορατές μόνο σε 3D διαγράμματα.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς για Ένα Διάγραμμα**

Ορίστε το προεπιλεγμένο μέγεθος γραμματοσειράς για το κείμενο του διαγράμματος μέσω του [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης με γραμματοσειρά 20 points και ενεργοποιεί ετικέτες τιμών για την πρώτη σειρά μέσω του [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Τα στοιχεία κειμένου με τις δικές τους ρητές ρυθμίσεις γραμματοσειράς μπορούν να υπερισχύσουν της προεπιλογής του διαγράμματος.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Επαναχρησιμοποίηση Μορφοποίησης Πλαισίου Κειμένου για Υπόμνημα Διαγράμματος**

Για να αντιστοιχίσετε ένα υπόμνημα σε μια επικεφαλίδα διαφάνειας, ορίστε τη γραμματοσειρά μέσω του [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) στην πρώτη παράγραφο της επικεφαλίδας. Καλέστε το [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) στο [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) του υπομνήματος. Αντιγράφει τις ρυθμίσεις του πλαισίου κειμένου, τη μορφοποίηση της πρώτης παραγράφου, και τις προεπιλεγμένες ιδιότητες γραμματοσειράς εκείνης της παραγράφου. Η μορφοποίηση που εφαρμόζεται απευθείας σε μεμονωμένα τμήματα ή σε μεταγενέστερες παραγράφους παραμένει τοπική στην πηγή.

Το παράδειγμα χρησιμοποιεί μια επικεφαλίδα με έντονη γραφή, σκούρο μπλε, 26 points Calibri ως πρότυπο. Αφού μορφοποιηθεί το υπόμνημα, χρησιμοποιεί το [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) για να εφαρμόσει την ίδια μορφοποίηση σε μια ξεχωριστή λεζάντα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Στην αποθηκευμένη παρουσίαση, το υπόμνημα και η λεζάντα ταιριάζουν με την επικεφαλίδα σε μέγεθος, βάρος και χρώμα. Το υπόμνημα εξακολουθεί να εμφανίζει τα ονόματα των σειρών, ενώ η λεζάντα διατηρεί το δικό της κείμενο. Εάν ένα τμήμα της λεζάντας έχει ήδη ρητό μέγεθος γραμματοσειράς, αυτό το μέγεθος έχει προτεραιότητα έναντι του αντιγραμμένου προεπιλεγμένου μεγέθους παραγράφου.

| Πριν από την αντιγραφή | Μετά την αντιγραφή |
| --- | --- |
| ![Διάγραμμα πωλήσεων τριμήνου με κανονικές μαύρες ετικέτες υπομνήματος και μαύρη λεζάντα](legend-formatting-before.png) | ![Το ίδιο διάγραμμα με μεγαλύτερες, έντονες σκούρο μπλε ετικέτες υπομνήματος και αντίστοιχη λεζάντα](legend-formatting.png) |

## **Ορισμός Αριθμητικής Μορφής**

Χρησιμοποιήστε το [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) για να εφαρμόσετε μια ενσωματωμένη αριθμητική μορφή στα κελιά του φύλλου εργασίας του διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης με προεπιλεγμένα δεδομένα που προέρχονται από κελιά και εφαρμόζει τον δείκτη μορφής 10 (`0.00%`) σε κάθε κελί τιμής σειράς. Αυτό αλλάζει τον τρόπο εμφάνισης των τιμών στο φύλλο εργασίας χωρίς να αλλάζει τους υποκείμενους αριθμούς· για παράδειγμα, το 0.25 εμφανίζεται ως 25.00%. Οι μορφές των αξόνων και των ετικετών δεδομένων μπορούν να ρυθμιστούν ξεχωριστά.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Ο παρακάτω πίνακας παραθέτει τους ενσωματωμένους δείκτες μορφής αριθμών με αντιπροσωπευτικές μορφές Excel για την αγγλική (Ηνωμένες Πολιτείες) τοπική ρύθμιση. Οι ακριβείς αλφαριθμητικές μορφές και η εμφάνισή τους μπορεί να διαφέρουν ανά εφαρμογή και τοπική ρύθμιση, ιδιαίτερα για νόμισμα και ημερομηνίες. Ορισμένες μορφές Excel διαφέρουν επίσης από τις προεπιλογές στο πρότυπο OOXML, όπως περιγράφεται στις [σημειώσεις υλοποίησης μορφής αριθμών της Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Δείκτης | Μορφή |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ορισμός Στρογγυλεμένων Άκρων Περιοχής Διαγράμματος**

Ενεργοποιήστε το [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) για να στρογγυλοποιήσετε τις γωνίες της περιοχής του διαγράμματος. Το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης και χρησιμοποιεί το [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για να δώσει στο περίγραμμά του ένα ματ ζωντανό γκρι χρώμα και ένα στυλ μονής γραμμής πριν αποθηκευτεί η παρουσίαση.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Επεξεργασία Υπάρχουσων Σχόλων Διαγράμματος**

Ένα διάγραμμα μπορεί να περιέχει προσαρμοσμένα σχήματα, όπως μια σημείωση κειμένου που εξηγεί την κατάσταση μιας έκθεσης. Πρόσβαση σε αυτά τα σχήματα μέσω του [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Η συλλογή [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) περιέχει τα σχήματα που ανήκουν στο διάγραμμα.

Ένα συνηθισμένο πλαίσιο κειμένου τοποθετημένο πάνω από ένα διάγραμμα ανήκει στη διαφάνεια, ακόμη και αν φαίνεται ως μέρος του διαγράμματος. Η επανάληψη μέσω των [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) εντοπίζει το διάγραμμα και τα κανονικά σχήματα της διαφάνειας, αλλά δεν απαριθμεί τα μεμονωμένα σχήματα μέσα στο διάγραμμα. Οι τίτλοι των διαγραμμάτων και οι ετικέτες δεδομένων είναι ξεχωριστά στοιχεία διαγράμματος, όχι προσαρμοσμένες σημειώσεις σε αυτή τη συλλογή.

Κατεβάστε το [chart-annotations.pptx](chart-annotations.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει ένα διάγραμμα με μια μη ομαδοποιημένη σημείωση που γράφει "Preliminary results", μια γραμμή που ανήκει στο διάγραμμα, και ένα συνηθισμένο πλαίσιο κειμένου διαφάνειας που γράφει "Slide overlay". Το παράδειγμα εντοπίζει το πρώτο διάγραμμα σε αυτή τη διαφάνεια και αλλάζει τη σημείωση σε "Final results" όταν η έκθεση είναι έτοιμη για δημοσίευση. Ελέγχει για κενή συλλογή και επεξεργάζεται μόνο ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) με ένα [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) που δεν είναι `None` και περιέχει το αναμενόμενο κείμενο.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Η γραμμή και το πλαίσιο κειμένου της διαφάνειας παραμένουν αμετάβλητα. Οι ακόλουθες εικόνες δείχνουν την είσοδο και το αποθηκευμένο, ξανά ανοιγμένο αποτέλεσμα:

| Πριν από την επεξεργασία | Μετά την επεξεργασία |
| --- | --- |
| ![Σχόλιο διαγράμματος που αναφέρει Preliminary results](chart-annotations-before.png) | ![Σχόλιο διαγράμματος που αναφέρει Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Το παράδειγμα ελέγχει μόνο τα σχήματα του διαγράμματος σε επίπεδο κορυφαίου επιπέδου. Εάν μια σημείωση βρίσκεται μέσα σε ένα [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), ελέγξτε επίσης τη συλλογή [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) του συγκεκριμένου γκρουπ. Επαναλάβετε αυτή τη διαδικασία αναδρομικά για ένθετα γκρουπ, εφαρμόζοντας τις ίδιες ελέγχους κειμένου στα παιδικά τους σχήματα. Ένα γκρουπ από μόνο του είναι ένας δοχείο· μην το αντιμετωπίζετε ως πλαίσιο κειμένου.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω ημιδιαφανή γεμίσματα για στήλες/περιοχές ενώ το περίγραμμα παραμένει αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και το περίγραμμα ρυθμίζονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές απεικονίσεις.

**Πώς μπορώ να χειριστώ τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη ουσιώδη στοιχεία ετικετών (π.χ., κατηγορίες), προσαρμόστε τη θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία εάν χρειάζεται, ή αλλάξτε τη μορφή σε "value + legend".

**Μπορώ να εφαρμόσω διαβαθμισμένα ή μοτίβο γεμίσματα σε σειρές;**

Ναι. Οι σειρές υποστηρίζουν στερεά, διαβαθμισμένα και μοτίβο γεμίσματα. Στην πράξη, χρησιμοποιήστε τα διαβαθμισμένα γεμίσματα με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.