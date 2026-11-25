---
title: Προσαρμόστε 3D Διαγράμματα σε Παρουσιάσεις με Python
linktitle: 3D Διάγραμμα
type: docs
url: /el/python-net/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides for Python μέσω .NET. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και την απόσταση μεταξύ σειρών με παραδείγματα Python."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω της ιδιότητας [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορίστε την Περιστροφή και το Βάθος ενός 3D Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και χρησιμοποιεί το [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) για να προσθέσει ένα στοίβαγμα 3D στήλης στο πρώτο του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι ιδιότητες [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) και [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) θέτουν την περιστροφή του διαγράμματος σε 40 και 270 μοίρες, αντίστοιχα. Η [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ορίζει το βάθος του στο 150 % του πλάτους του, ενώ η [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το πλήρως διαμορφωμένο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμόστε Γέμισμα Εικόνας στην Επιφάνεια ενός 3D Διαγράμματος**

Μπορείτε να γεμίσετε ανεξάρτητα τον [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), το [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), και το [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) ενός 3D διαγράμματος. Ορίστε τον [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) της επιφάνειας σε `PICTURE` και ορίστε μια εικόνα. Για να ταιριάζει ένα αντίγραφο της εικόνας σε όλη την επιφάνεια, ορίστε τόσο το [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) όσο και τον [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) της επιφάνειας σε `STRETCH`.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα φάκελο εργασίας. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή του κάθετου άξονα ώστε το πάτωμα να είναι ορατό μεταξύ των στηλών. Κάνει κλώνο τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα μοιράζονται τα ίδια δεδομένα, την οπτική γωνία και το φόντο.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Οπίσθιος τοίχος | Πάτωμα |
| --- | --- | --- |
| ![Βέλος που δείχνει μέσα στο διάγραμμα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει προς τα δεξιά κατά μήκος του οπίσθιου τοίχου](back-wall.png) | ![Βέλος που δείχνει προς τα δεξιά κατά μήκος του πατώματος μεταξύ των στηλών](floor.png) |

## **Ρυθμίστε τις Αναλογίες Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε το [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση μεταξύ σειρών και η μορφοποίηση είναι πανομοιότυπα σε όλα τα τρία αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Οι παρακάτω εικόνες εξαχθήκαν από τις παραγόμενες παρουσιάσεις χρησιμοποιώντας το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί πιο ψηλή σκηνή εντός του ίδιου αντικειμένου διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημάνσεων άξονα και τη θέση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![Διάγραμμα 3D στήλης με ύψος ορισμένο στο 50 % του πλάτους του](height_percent_50.png) | ![Διάγραμμα 3D στήλης με ύψος ορισμένο στο 100 % του πλάτους του](height_percent_100.png) | ![Διάγραμμα 3D στήλης με ύψος ορισμένο στο 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι ιδιότητες ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Ιδιότητα | Επίδραση |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε μονάδες point. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει τα 3D διαγράμματα στήλης και ράβδου, περιλαμβανομένων των παραλλαγών κυλίνδρου, κώνου και πυραμίδας, καθώς και τα 3D γραμμικά, εμβαδικά, πίτας και επιφανειακά διαγράμματα. Η παραπάνω σύγκριση χρησιμοποιεί τον επαληθευμένο τύπο `COLUMN_3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `CLUSTERED_COLUMN` ή ενός διαγράμματος `BUBBLE_WITH_3D`; αυτά τα ονόματα είναι μέλη της απαρίθμησης [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Μορφοποίηση Διαγράμματος](/slides/el/python-net/chart-formatting/).

## **Ρυθμίστε το Κενό Μεταξύ Σειρών**

Χρησιμοποιήστε το [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) για να ελέγξετε την απόσταση μεταξύ των σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένων: το `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Προσπελάστε την ομάδα μέσω του [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Η ρύθμιση ισχύει για κάθε σειρά σε αυτήν την ομάδα, όχι μόνο για τη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Το [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) είναι μόνο ανάγνωση και αντικατοπτρίζει τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει τα 3D διαγράμματα στήλης και ράβδου, συμπεριλαμβανομένων των παραλλαγών κυλίνδρου, κώνου και πυραμίδας, καθώς και τα 3D διαγράμματα γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το εάν οι σειρές είναι τακτοποιημένες σε βάθος, ομαδοποιημένες ή στοιβαγμένες. Για καθαρή σύγκριση των κενών μεταξύ διακριτών σειρών, χρησιμοποιήστε το `ChartType.COLUMN_3D` από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Αυτές οι ιδιότητες ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Ιδιότητα | Επίδραση |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Απόσταση μεταξύ διαδοχικών ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Συνολικό βάθος του διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ταυτόδημα δεδομένα, περιστροφή, πλάτος κενού και βάθος διαγράμματος· μόνο το βάθος κενού αλλάζει.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Οι παρακάτω εικόνες εξαχθήκαν από τις παραγόμενες παρουσιάσεις χρησιμοποιώντας το Microsoft PowerPoint.

| Βάθος κενού: 0% | Βάθος κενού: 500% |
| --- | --- |
| ![Διάγραμμα 3D στήλης χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![Διάγραμμα 3D στήλης με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλάξτε τον Τύπο Σειράς 3D και το Σχήμα Ράβδου**

Σε ένα ομαδοποιημένο κύλινδρο διάγραμμα, η πρώτη σειρά ξεκινά με κυλινδρικές ράβδους. Το παράδειγμα διαβάζει το [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) και το [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) πριν και μετά από κάθε αλλαγή.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Αλλαγή στην πρώτη σειρά | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Δημιουργία διαγράμματος | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Ορισμός `type` σε `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Ορισμός `bar_3d_shape` σε `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Ο ορισμός του σχήματος σε `BOX` αλλάζει επίσης τον τύπο σειράς σε `CLUSTERED_COLUMN_3D`. Εάν ο κώδικάς σας κάνει διακλαδώσεις βάσει του τύπου σειράς, διαβάστε το `series.type` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν από την ανάθεση θα επέλεγε ακόμα τη διακλάδωση `CLUSTERED_CONE`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνους και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της απαρίθμησης [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Για έναν ακριβή, ενημερωμένο κατάλογο, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3D διαγράμματος για έκθεση ή το web;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με τη μέθοδο [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ή να [απόδοση ολόκληρης της διαφάνειας](/slides/el/python-net/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερ προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες εργαλείων ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Ποιό είναι το επίπεδο απόδοσης κατά τη δημιουργία και απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για καλύτερα αποτελέσματα, κρατήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και τις περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδίδετε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην προβολή ή τις απαιτήσεις εκτύπωσης.