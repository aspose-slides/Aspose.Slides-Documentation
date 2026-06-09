---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Python
linktitle: Σειρές Δεδομένων
type: docs
url: /el/python-net/chart-series/
keywords:
- σειρές γραφήματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές δεδομένων γραφήματος σε Python για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει το ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/) στο Aspose.Slides για Python, εστιάζοντας στον τρόπο με τον οποίο τα δεδομένα είναι δομημένα και οπτικοποιούνται μέσα σε παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα θεμελιώδη στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγοριών και παραμέτρων εμφάνισης σε ένα γράφημα. Με την εργασία με το [ChartSeries](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν αδιάλειπτα τις υποκείμενες πηγές δεδομένων και να διατηρήσουν πλήρη έλεγχο πάνω στο πώς εμφανίζονται οι πληροφορίες, με αποτέλεσμα δυναμικές, προσαρμοσμένες σε δεδομένα παρουσιάσεις που μεταδίδουν σαφώς ιδέες και αναλύσεις.

Μια σειρά είναι μια σειρά ή στήλη αριθμών που σχεδιάζονται σε γράφημα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειρών**

Η ιδιότητα [ChartSeries.overlap](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/overlap/) ελέγχει πώς οι μπάρες και οι στήλες επικαλύπτονται σε ένα 2D γράφημα, ορίζοντας ένα εύρος από -100 έως 100. Δεδομένου ότι αυτή η ιδιότητα σχετίζεται με την ομάδα σειρών και όχι με μεμονωμένες σειρές γραφήματος, είναι μόνο για ανάγνωση στο επίπεδο της σειράς. Για να ρυθμίσετε τις τιμές επικάλυψης, χρησιμοποιήστε την ιδιότητα `parent_series_group.overlap` ανάγνωση/εγγραφή, η οποία εφαρμόζει την καθορισμένη επικάλυψη σε όλες τις σειρές της συγκεκριμένης ομάδας.

Παρακάτω υπάρχει ένα παράδειγμα Python που δείχνει πώς να δημιουργήσετε μια παρουσίαση, να προσθέσετε ένα γράφημα ομαδοποιημένων στηλών, να αποκτήσετε πρόσβαση στην πρώτη σειρά γραφήματος, να ρυθμίσετε την παραμετροποίηση επικάλυψης και, τέλος, να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος ομαδοποιημένων στηλών με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Ορισμός επικάλυψης σειράς.
        series.parent_series_group.overlap = series_overlap

    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισματος Σειράς**

Το Aspose.Slides καθιστά απλό τον προσαρμοσμό των χρωμάτων γεμίσματος των σειρών γραφήματος, επιτρέποντάς σας να τονίσετε συγκεκριμένα σημεία δεδομένων και να δημιουργήσετε οπτικά ελκυστικά γραφήματα. Αυτό επιτυγχάνεται μέσω του αντικειμένου [Format](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/format/), που υποστηρίζει διάφορους τύπους γεμίσματος, διαμορφώσεις χρωμάτων και άλλες προχωρημένες επιλογές στυλ. Αφού προσθέσετε ένα γράφημα σε μια διαφάνεια και έχετε πρόσβαση στη ζητούμενη σειρά, απλώς αποκτήστε τη σειρά και εφαρμόστε το κατάλληλο χρώμα γεμίσματος. Πέρα από τα στερεά γεμίσματα, μπορείτε επίσης να χρησιμοποιήσετε διαβαθμίσεις ή μοτίβα γεμίσματος για ενισχυμένη σχεδιαστική ευελιξία. Μόλις ορίσετε τα χρώματα σύμφωνα με τις απαιτήσεις σας, αποθηκεύστε την παρουσίαση για να ολοκληρώσετε την ενημερωμένη εμφάνιση.

Ο παρακάτω κώδικας Python δείχνει πώς να αλλάξετε το χρώμα της πρώτης σειράς:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος ομαδοποιημένων στηλών με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Ορισμός χρώματος της πρώτης σειράς.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το χρώμα της σειράς](series_color.png)

## **Μετονομασία Σειράς** 

Το Aspose.Slides προσφέρει έναν απλό τρόπο για την τροποποίηση των ονομάτων των σειρών γραφήματος, διευκολύνοντας την ετικετοθέτηση των δεδομένων με σαφή και σημασιολογικό τρόπο. Μέσω πρόσβασης στο αντίστοιχο κελί του φύλλου εργασίας στα δεδομένα του γραφήματος, οι προγραμματιστές μπορούν να προσαρμόσουν πώς παρουσιάζονται τα δεδομένα. Αυτή η τροποποίηση είναι ιδιαίτερα χρήσιμη όταν τα ονόματα των σειρών χρειάζονται ενημέρωση ή διευκρίνιση βάσει του πλαισίου των δεδομένων. Μετά τη μετονομασία της σειράς, η παρουσίαση μπορεί να αποθηκευτεί ώστε να διατηρηθούν οι αλλαγές. 

Παρακάτω υπάρχει ένα απόσπασμα κώδικα Python που δείχνει αυτή τη διαδικασία σε δράση.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος ομαδοποιημένων στηλών με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Ορισμός ονόματος της πρώτης σειράς.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Ο ακόλουθος κώδικας Python δείχνει μια εναλλακτική μέθοδο για την αλλαγή του ονόματος της σειράς:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος ομαδοποιημένων στηλών με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Ορισμός ονόματος της πρώτης σειράς.
    series.name.as_cells[0].value = series_name

    # Αποθήκευση του αρχείου παρουσίασης στο δίσκο.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Το αποτέλεσμα:

![Το όνομα της σειράς](series_name.png)

## **Ανάκτηση Αυτόματου Χρώματος Γέμισματος Σειράς**

Το Aspose.Slides για Python σας επιτρέπει να λάβετε το αυτόματο χρώμα γεμίσματος για σειρές γραφήματος εντός περιοχής σχεδίασης. Αφού δημιουργήσετε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), μπορείτε να αποκτήσετε αναφορά στη ζητούμενη διαφάνεια με βάση το δείκτη, έπειτα να προσθέσετε ένα γράφημα χρησιμοποιώντας τον προτιμώμενο τύπο (όπως `ChartType.CLUSTERED_COLUMN`). Μέσω πρόσβασης στις σειρές του γραφήματος, μπορείτε να λάβετε το αυτόματο χρώμα γεμίσματος.

Ο κώδικας Python παρακάτω περιγράφει αυτή τη διαδικασία με λεπτομέρεια.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος ομαδοποιημένων στηλών με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Λήψη του χρώματος γεμίσματος της σειράς.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Παράδειγμα εξόδου:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Ορισμός Αντιστροφής Χρώματος Γέμισματος για Σειρά**

Όταν μια σειρά δεδομένων περιέχει τόσο θετικές όσο και αρνητικές τιμές, η χρήση του ίδιου χρώματος για κάθε στήλη ή μπάρα μπορεί να δυσκολεύει την ανάγνωση του γραφήματος. Το Aspose.Slides για Python σας επιτρέπει να ορίσετε ένα αντίστροφο χρώμα γεμίσματος — ένα ξεχωριστό γέμισμα που εφαρμόζεται αυτόματα στα σημεία δεδομένων που βρίσκονται κάτω από το μηδέν — ώστε οι αρνητικές τιμές να ξεχωρίζουν αμέσως. Σε αυτήν την ενότητα θα μάθετε πώς να ενεργοποιήσετε αυτήν την επιλογή, να επιλέξετε το κατάλληλο χρώμα και να αποθηκεύσετε την ενημερωμένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα δείχνει τη λειτουργία:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Προσθήκη νέων κατηγοριών.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Προσθήκη νέας σειράς.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Συμπλήρωση δεδομένων της σειράς.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Ορισμός ρυθμίσεων χρώματος για τη σειρά.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το αντιστροφό στερεό γέμισμα](inverted_solid_fill_color.png)

Μπορείτε να αντιστρέψετε το χρώμα γεμίσματος για ένα μόνο σημείο δεδομένων αντί για ολόκληρη τη σειρά. Απλώς αποκτήστε πρόσβαση στο επιθυμητό `ChartDataPoint` και ορίστε την ιδιότητα `invert_if_negative` σε `True`.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να το κάνετε αυτό:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Καθαρισμός Δεδομένων για Συγκεκριμένα Σημεία Δεδομένων**

Μερικές φορές ένα γράφημα περιέχει δοκιμαστικές τιμές, ακραίες τιμές ή παλιές καταχωρήσεις που χρειάζεται να αφαιρέσετε χωρίς να ξαναχτίσετε ολόκληρη τη σειρά. Το Aspose.Slides για Python σας επιτρέπει να στοχεύσετε οποιοδήποτε σημείο δεδομένων με βάση το δείκτη, να διαγράψετε το περιεχόμενό του και να ανανεώσετε αμέσως το γράφημα έτσι ώστε τα υπόλοιπα σημεία να μετακινηθούν και οι άξονες να προσαρμοστούν αυτόματα.

Το παρακάτω παράδειγμα κώδικα δείχνει τη λειτουργία:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Πλάτους Κενών Μεταξύ Σειρών**

Το πλάτος κενών (gap width) ελέγχει την ποσότητα του κενό χώρου μεταξύ γειτονικών στηλών ή μπαρών — ευρύτερα κενά τονίζουν τις μεμονωμένες κατηγορίες, ενώ στενότερα κενά δημιουργούν έναν πιο πυκνό, πιο συμπαγή οπτικό αποτέλεσμα. Μέσω του Aspose.Slides για Python μπορείτε να δοκιμάσετε ακριβώς αυτήν την παράμετρο για ολόκληρη τη σειρά, επιτυγχάνοντας την ακριβή οπτική ισορροπία που απαιτεί η παρουσίασή σας χωρίς να τροποποιήσετε τα υποκείμενα δεδομένα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το πλάτος κενών για μια σειρά:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Δημιουργία κενής παρουσίασης.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Αποθήκευση της παρουσίασης στο δίσκο.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Ορισμός τιμής gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Αποθήκευση της παρουσίασης στο δίσκο.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το πλάτος κενών](gap_width.png)

## **FAQ**

**Υπάρχει όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει σταθερό όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό όριο καθορίζεται από την ευαναγνωσία του γραφήματος και από τη διαθέσιμη μνήμη της εφαρμογής σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύμπλεγμα είναι πολύ κοντά ή πολύ μακριά η μία από την άλλη;**

Ρυθμίστε την παράμετρο [gap_width](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartseries/gap_width/) για εκείνη τη σειρά (ή την γονική ομάδα σειρών). Αυξάνοντας την τιμή διευρύνετε τον χώρο μεταξύ των στηλών, ενώ μειώνοντάς την τα φέρετε πιο κοντά.