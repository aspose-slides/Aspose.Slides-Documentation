---
title: Μορφοποίηση Διαγραμμάτων Παρουσίασης σε Python
linktitle: Μορφοποίηση Διαγράμματος
type: docs
weight: 60
url: /el/python-java/chart-formatting/
keywords:
- μορφοποίηση διαγράμματος
- μορφοποίηση διαγράμματος
- στοιχείο διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για Python μέσω Java και ενισχύστε την παρουσίαση PowerPoint σας με επαγγελματικό, εντυπωσιακό στυλ."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόζετε βασικά στοιχεία του διαγράμματος όπως οι άξονες, οι γραμμές πλέγματος, οι τίτλοι, τα υπομνήματα, η περιοχή σχεδίασης και οι γεμίσεις τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος.

Επίσης, παρουσιάζει πώς να ορίζετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόζετε προεπιλεγμένες και προσαρμοσμένες αριθμητικές μορφές στα δεδομένα του διαγράμματος και να ενεργοποιείτε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση.

## **Μορφοποίηση Στοιχείων Διαγράμματος**
Aspose.Slides for Python via Java επιτρέπει στους προγραμματιστές να προσθέτουν προσαρμοσμένα διαγράμματα στις διαφάνειές τους από την αρχή. Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε διαφορετικά στοιχεία διαγράμματος, συμπεριλαμβανομένων των άξονων κατηγορίας και τιμής.

Aspose.Slides for Python via Java παρέχει ένα απλό API για τη διαχείριση διαφορετικών στοιχείων διαγράμματος και τη μορφοποίησή τους με προσαρμοσμένες τιμές:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσπελάστε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα διάγραμμα του επιθυμητού τύπου με προεπιλεγμένα δεδομένα (αυτό το παράδειγμα χρησιμοποιεί [ChartType.LineWithMarkers](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Προσπελάστε τον άξονα τιμών του διαγράμματος και ορίστε τις παρακάτω ιδιότητες:
   1. Ορίστε **Line format** για τις κύριες γραμμές πλέγματος του άξονα τιμών.
   1. Ορίστε **Line format** για τις δευτερεύουσες γραμμές πλέγματος του άξονα τιμών.
   1. Ορίστε **Number Format** για τον άξονα τιμών.
   1. Ορίστε **minimum, maximum, major, and minor units** για τον άξονα τιμών.
   1. Ορίστε **Text Properties** για τα δεδομένα του άξονα τιμών.
   1. Ορίστε **Title** για τον άξονα τιμών.
1. Προσπελάστε τον άξονα κατηγορίας του διαγράμματος και ορίστε τις παρακάτω ιδιότητες:
   1. Ορίστε **Line format** για τις κύριες γραμμές πλέγματος του άξονα κατηγορίας.
   1. Ορίστε **Line format** για τις δευτερεύουσες γραμμές πλέγματος του άξονα κατηγορίας.
   1. Ορίστε **Text Properties** για τα δεδομένα του άξονα κατηγορίας.
   1. Ορίστε **Title** για τον άξονα κατηγορίας.
   1. Ορίστε **Label Positioning** για τον άξονα κατηγορίας.
   1. Ορίστε **Rotation Angle** για τις ετικέτες του άξονα κατηγορίας.
1. Προσπελάστε το υπόμνημα του διαγράμματος και ορίστε τις **text properties** του.
1. Εμφανίστε το υπόμνημα του διαγράμματος χωρίς να επικαλύπτει το διάγραμμα.
1. Προσπελάστε τον **secondary value axis** του διαγράμματος και ορίστε τις παρακάτω ιδιότητες:
   1. Ενεργοποιήστε τον δευτερογενή **value axis**.
   1. Ορίστε **Line Format** για τον δευτερογενή άξονα τιμών.
   1. Ορίστε **Number Format** για τον δευτερογενή άξονα τιμών.
   1. Ορίστε **minimum, maximum, major, and minor units** για τον δευτερογενή άξονα τιμών.
1. Σχεδιάστε τη πρώτη σειρά διαγράμματος στον δευτερογενή άξονα τιμών.
1. Ορίστε το χρώμα γεμίσματος του πίσω τοίχου του διαγράμματος.
1. Ορίστε το χρώμα γεμίσματος της περιοχής σχεδίασης του διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη του παραδείγματικού διαγράμματος
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Ορισμός Τίτλου Διαγράμματος
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ορισμός μορφής αριθμού για τον άξονα τιμών
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Ορισμός μέγιστων και ελάχιστων τιμών διαγράμματος
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Ορισμός ιδιοτήτων κειμένου του άξονα τιμών
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Ορισμός τίτλου άξονα τιμών
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ορισμός μορφής κύριων γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Ορισμός μορφής δευτερευουσών γραμμών πλέγματος για τον άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ορισμός ιδιοτήτων κειμένου του άξονα κατηγορίας
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Ορισμός Τίτλου Κατηγορίας
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ορισμός θέσης ετικέτας άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Ορισμός γωνίας περιστροφής ετικέτας άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Ορισμός ιδιοτήτων κειμένου υπομνήματος
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Εμφάνιση του υπομνήματος διαγράμματος χωρίς επικάλυψη
    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Ορισμός δευτερεύοντος άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Ορισμός μορφής αριθμού για τον δευτερεύοντα άξονα τιμών
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Ορισμός μέγιστων και ελάχιστων τιμών διαγράμματος
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Ορισμός χρώματος πίσω τοίχου διαγράμματος
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Ορισμός χρώματος περιοχής σχεδίασης
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Αποθήκευση της παρουσίασης
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορίστε Ιδιότητες Γραμματοσειράς για ένα Διάγραμμα**
Aspose.Slides for Python via Java υποστηρίζει τον ορισμό ιδιοτήτων γραμματοσειράς για διαγράμματα. Ακολουθήστε αυτά τα βήματα για να ορίσετε τις ιδιότητες γραμματοσειράς:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Προσθέστε ένα διάγραμμα στη διαφάνεια.
- Ορίστε το ύψος γραμματοσειράς.
- Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δείχνει αυτά τα βήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

    # Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορίστε τη Μορφή Αριθμών**
Aspose.Slides for Python via Java παρέχει ένα απλό API για τη διαχείριση μορφών δεδομένων διαγράμματος:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσπελάστε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα διάγραμμα του επιθυμητού τύπου με προεπιλεγμένα δεδομένα (αυτό το παράδειγμα χρησιμοποιεί [ChartType.ClusteredColumn](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Ορίστε τη προεπιλεγμένη μορφή αριθμού από τις διαθέσιμες προεπιλεγμένες τιμές.
1. Επανάληψη στις κυψέλες δεδομένων κάθε σειράς διαγράμματος και ορισμός της μορφής αριθμού τους.
1. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
presentation = Presentation()
try:
    # Πρόσβαση στην πρώτη διαφάνεια παρουσίασης
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη προεπιλεγμένου διαγράμματος στήλης με συστοιχίσεις
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Πρόσβαση στη συλλογή σειρών του διαγράμματος
    chart_series_collection = chart.getChartData().getSeries()

    # Επανάληψη σε κάθε σειρά του διαγράμματος
    for chart_series in chart_series_collection:
        # Επανάληψη σε κάθε σημείο δεδομένων της σειράς
        for data_point in chart_series.getDataPoints():
            # Ορισμός μορφής αριθμού
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Αποθήκευση της παρουσίασης
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι διαθέσιμες προεπιλεγμένες μορφές αριθμών και οι δείκτες τους παρατίθενται παρακάτω:

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

## **Ορίστε Στρογγυλοποιημένα Όρια Περιοχής Διαγράμματος**
Aspose.Slides for Python via Java υποστηρίζει στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος μέσω των μεθόδων [hasRoundedCorners](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#hasRoundedCorners) και [setRoundedCorners](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setRoundedCorners) της κλάσης [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/).

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσθέστε ένα διάγραμμα στη διαφάνεια.
1. Ορίστε τον τύπο γεμίσματος και το στυλ της γραμμής περιγράμματος του διαγράμματος.
1. Ενεργοποιήστε τις στρογγυλεμένες γωνίες.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δείχνει αυτά τα βήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΜΒΑΤΕΣ**

**Μπορώ να ορίσω ημιδιαφανείς γεμίσεις για στήλες/περιοχές ενώ το περίγραμμα παραμένει αδιαφανές;**

Ναι. Η διαφάνεια του γεμίσματος και η γραμμή περιγράμματος διαχειρίζονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές οπτικοποιήσεις.

**Πώς μπορώ να αντιμετωπίσω ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος της γραμματοσειράς, απενεργοποιήστε μη απαραίτητα στοιχεία ετικετών (π.χ. κατηγορίες), ορίστε την απόκλιση/θέση της ετικέτας, εμφανίστε ετικέτες μόνο για επιλεγμένα σημεία εφόσον χρειάζεται, ή αλλάξτε τη μορφή σε «τιμή + υπόμνημα».

**Μπορώ να εφαρμόσω διαβαθμίσεις ή μοτίβα γεμίσματος σε σειρές;**

Ναι. Συνήθως διατίθενται τόσο γεμίσματα μονής απόχρωσης όσο και διαβαθμίσεων/μοτίβων. Στην πράξη, χρησιμοποιήστε τις διαβαθμίσεις με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.