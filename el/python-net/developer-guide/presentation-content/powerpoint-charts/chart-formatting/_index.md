---
title: "Μορφοποίηση Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας Python"
linktitle: "Μορφοποίηση Διαγράμματος"
type: docs
weight: 60
url: /el/python-net/chart-formatting/
keywords:
- "μορφοποίηση διαγράμματος"
- "μορφοποίηση διαγράμματος"
- "οντότητα διαγράμματος"
- "ιδιότητες διαγράμματος"
- "ρυθμίσεις διαγράμματος"
- "επιλογές διαγράμματος"
- "ιδιότητες γραμματοσειράς"
- "στρογγυλεμένο περίγραμμα"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Python μέσω .NET και αναβαθμίστε την παρουσίαση PowerPoint ή OpenDocument σας με επαγγελματικό, εντυπωσιακό στυλ."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόσετε βασικά στοιχεία διαγράμματος όπως άξονες, γραμμές πλέγματος, τίτλους, υπομνήματα, την περιοχή σχεδίασης και τις γεμίσματα τοίχου ώστε να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, δείχνει πώς να ορίσετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προεπιλεγμένες και προσαρμοσμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος, και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση.

## **Μορφοποίηση Στοιχείων Διαγράμματος**

Το Aspose.Slides for Python επιτρέπει στους προγραμματιστές να προσθέσουν προσαρμοσμένα διαγράμματα στις διαφάνειές τους από το μηδέν. Αυτή η ενότητα εξηγεί πώς να μορφοποιήσετε διάφορα στοιχεία του διαγράμματος, συμπεριλαμβανομένων των αξόνων κατηγορίας και τιμής.

Το Aspose.Slides παρέχει ένα απλό API για τη διαχείριση των στοιχείων του διαγράμματος και την εφαρμογή προσαρμοσμένης μορφοποίησης:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα του επιθυμητού τύπου (σε αυτό το παράδειγμα, `ChartType.LINE_WITH_MARKERS`).
1. Πρόσβαση στον άξονα τιμής του διαγράμματος και ορισμός των παρακάτω:
   1. Ορίστε τη **μορφή γραμμής** για τις κύριες γραμμές πλέγματος του άξονα τιμής.
   1. Ορίστε τη **μορφή γραμμής** για τις δευτερεύουσες γραμμές πλέγματος του άξονα τιμής.
   1. Ορίστε τη **μορφή αριθμού** για τον άξονα τιμής.
   1. Ορίστε τις **ελάχιστες, μέγιστες, κύριες και δευτερεύουσες μονάδες** για τον άξονα τιμής.
   1. Ορίστε τις **ιδιότητες κειμένου** για τις ετικέτες του άξονα τιμής.
   1. Ορίστε τον **τίτλο** για τον άξονα τιμής.
   1. Ορίστε τη **μορφή γραμμής** για τον άξονα τιμής.
1. Πρόσβαση στον άξονα κατηγορίας του διαγράμματος και ορισμός των παρακάτω:
   1. Ορίστε τη **μορφή γραμμής** για τις κύριες γραμμές πλέγματος του άξονα κατηγορίας.
   1. Ορίστε τη **μορφή γραμμής** για τις δευτερεύουσες γραμμές πλέγματος του άξονα κατηγορίας.
   1. Ορίστε τις **ιδιότητες κειμένου** για τις ετικέτες του άξονα κατηγορίας.
   1. Ορίστε τον **τίτλο** για τον άξονα κατηγορίας.
   1. Ορίστε τη **τοποθέτηση ετικετών** για τον άξονα κατηγορίας.
   1. Ορίστε τη **γωνία περιστροφής** για τις ετικέτες του άξονα κατηγορίας.
1. Πρόσβαση στο υπόμνημα του διαγράμματος και ορισμός των **ιδιοτήτων κειμένου**.
1. Εμφανίστε το υπόμνημα του διαγράμματος χωρίς να επικαλύπτεται με το διάγραμμα.
1. Πρόσβαση στον **δευτερεύοντα άξονα τιμής** του διαγράμματος και ορισμός των παρακάτω:
   1. Ενεργοποιήστε τον δευτερεύοντα **άξονα τιμής**.
   1. Ορίστε τη **μορφή γραμμής** για τον δευτερεύοντα άξονα τιμής.
   1. Ορίστε τη **μορφή αριθμού** για τον δευτερεύοντα άξονα τιμής.
   1. Ορίστε τις **ελάχιστες, μέγιστες, κύριες και δευτερεύουσες μονάδες** για τον δευτερεύοντα άξονα τιμής.
1. Σχεδιάστε τη πρώτη σειρά διαγράμματος στον δευτερεύοντα άξονα τιμής.
1. Ορίστε το χρώμα γεμίσματος του πίσω τοίχου του διαγράμματος.
1. Ορίστε το χρώμα γεμίσματος της περιοχής σχεδίασης του διαγράμματος.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία του αντικειμένου Presentation.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη δείγματος διαγράμματος.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Ορισμός τίτλου διαγράμματος.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Ορισμός μορφής κύριας γραμμής πλέγματος για τον άξονα τιμής.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Ορισμός μορφής δευτερεύουσας γραμμής πλέγματος για τον άξονα τιμής.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Ορισμός μορφής αριθμού για τον άξονα τιμής.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Ορισμός μέγιστης, ελάχιστης τιμής, κύριας μονάδας και δευτερεύουσας μονάδας του άξονα τιμής.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Ορισμός ιδιοτήτων κειμένου του άξονα τιμής.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Ορισμός τίτλου άξονα τιμής.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Ορισμός μορφής κύριας γραμμής πλέγματος για τον άξονα κατηγορίας.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Ορισμός μορφής δευτερεύουσας γραμμής πλέγματος για τον άξονα κατηγορίας.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Ορισμός ιδιοτήτων κειμένου του άξονα κατηγορίας.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Ορισμός τίτλου άξονα κατηγορίας.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Ορισμός θέσης ετικέτας άξονα κατηγορίας.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Ορισμός γωνίας περιστροφής ετικέτας άξονα κατηγορίας.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Ορισμός ιδιοτήτων κειμένου του υπομνήματος.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Εμφάνιση του υπομνήματος διαγράμματος επικαλυπτόμενου το διάγραμμα.
    chart.legend.overlay = True
                
    # Ορισμός χρώματος πίσω τοίχου του διαγράμματος.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Ορισμός χρώματος περιοχής σχεδίασης.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Αποθήκευση της παρουσίασης.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς Διαγράμματος**

Το Aspose.Slides for Python υποστηρίζει τον ορισμό ιδιοτήτων σχετικών με τη γραμματοσειρά για τα διαγράμματα. Ακολουθήστε τα παρακάτω βήματα για να διαμορφώσετε τις ιδιότητες γραμματοσειράς του διαγράμματος:

1. Δημιουργήστε ένα αντικείμενο [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσθέστε ένα διάγραμμα στη διαφάνεια.
1. Ορίστε το ύψος γραμματοσειράς.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρέχεται ένα παράδειγμα κώδικα παρακάτω.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Αριθμητικής Μορφής**

Το Aspose.Slides for Python παρέχει ένα απλό API για τη διαχείριση των μορφών δεδομένων του διαγράμματος:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα οποιουδήποτε επιθυμητού τύπου.
1. Ορίστε μια προεπιλεγμένη μορφή αριθμού από τις διαθέσιμες προεπιλεγμένες τιμές.
1. Περιηγηθείτε στα κελιά δεδομένων του διαγράμματος σε κάθε σειρά και ορίστε τη μορφή αριθμού.
1. Αποθηκεύστε την παρουσίαση.
1. Ορίστε μια προσαρμοσμένη μορφή αριθμού.
1. Περιηγηθείτε στα κελιά δεδομένων του διαγράμματος σε κάθε σειρά και ορίστε διαφορετική μορφή αριθμού.
1. Αποθηκεύστε την παρουσίαση.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη προεπιλεγμένου συγκεντρωτικού διαγράμματος στηλών.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Ορισμός της προεπιλεγμένης μορφής αριθμού.
    # Διατρέξτε κάθε σειρά διαγράμματος.
    for series in chart.chart_data.series:
        # Διατρέξτε κάθε σημείο δεδομένων στη σειρά.
        for cell in series.data_points:
            # Ορισμός μορφής αριθμού.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Αποθήκευση της παρουσίασης.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Οι διαθέσιμες προεπιλεγμένες μορφές αριθμού και οι αντίστοιχοι δείκτες τους παρατίθενται παρακάτω.

|**0**|Γενικό|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ορισμός Στρογγυλεμένων Ορίων για την Περιοχή του Διαγράμματος**

Το Aspose.Slides for Python υποστηρίζει τη ρύθμιση της περιοχής του διαγράμματος χρησιμοποιώντας την ιδιότητα `Chart.has_rounded_corners`.

1. Δημιουργήστε ένα αντικείμενο [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσθέστε ένα διάγραμμα στη διαφάνεια.
3. Ορίστε τον τύπο γεμίσματος και το χρώμα γεμίσματος του διαγράμματος.
4. Ορίστε την ιδιότητα στρογγυλεμένων γωνιών σε `True`.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παρέχεται ένα παράδειγμα παρακάτω.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω ημιδιαφανείς γεμίσματα για στήλες/περιοχές ενώ διατηρώ το περίγραμμα αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και το περίγραμμα ρυθμίζονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές απεικονίσεις.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη απαραίτητα στοιχεία ετικετών (π.χ. κατηγορίες), ορίστε την απόκλιση/θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία εάν χρειάζεται, ή αλλάξτε τη μορφή σε "τιμή + υπόμνημα".

**Μπορώ να εφαρμόσω γεμίσματα διαβάθμισης ή μοτίβου στις σειρές;**

Ναι. Συνήθως διατίθενται τόσο γεμίσματα συμπαγούς όσο και διαβάθμισης/μοτίβου. Στην πράξη, χρησιμοποιήστε διαβαθμίσεις με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.