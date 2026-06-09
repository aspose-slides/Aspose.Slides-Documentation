---
title: Προσαρμογή Γραφημάτων Φυσαλίδων σε Παρουσιάσεις με Python
linktitle: Γράφημα Φυσαλίδων
type: docs
url: /el/python-net/bubble-chart/
keywords:
- γράφημα φυσαλίδων
- μέγεθος φυσαλίδας
- κλιμάκωση μεγέθους
- αναπαράσταση μεγέθους
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε ισχυρά γραφήματα φυσαλίδων στο PowerPoint και το OpenDocument με το Aspose.Slides για Python μέσω .NET, ώστε να ενισχύσετε εύκολα την απεικόνιση των δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εργάζεστε με γραφήματα φυσαλίδων στο Aspose.Slides. Καλύπτει δύο συγκεκριμένες επιλογές προσαρμογής: κλιμάκωση του μεγέθους των φυσαλίδων μέσω της ιδιότητας `bubble_size_scale` και έλεγχο του τρόπου με τον οποίο αντιπροσωπεύονται οι τιμές μεγέθους των φυσαλίδων μέσω της ιδιότητας `bubble_size_representation`.

Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ένα γράφημα φυσαλίδων, να προσαρμόσετε την κλιμάκωση του μεγέθους του και να αλλάξετε την αντιπροσώπηση του μεγέθους της φυσαλίδας ώστε να χρησιμοποιείται το πλάτος. Το άρθρο περιλαμβάνει επίσης μια σύντομη ενότητα Συχνών Ερωτήσεων που διευκρινίζει την υποστήριξη για τον τύπο γραφήματος «Bubble with 3-D», σημειώνει ότι τα πρακτικά όρια του γραφήματος εξαρτώνται από την απόδοση και την έκδοση του PowerPoint-στόχου, και εξηγεί ότι η εξαγωγή διατηρεί την εμφάνιση του γραφήματος μέσω της μηχανής απόδοσης του Aspose.Slides.

## **Κλιμάκωση Μεγέθους Γραφήματος Φυσαλίδων**
Το Aspose.Slides for Python μέσω .NET παρέχει υποστήριξη για κλιμάκωση του μεγέθους των γραφημάτων φυσαλίδων. Στο Aspose.Slides for Python μέσω .NET προστέθηκαν οι ιδιότητες **ChartSeries.bubble_size_scale** και **ChartSeriesGroup.bubble_size_scale**. Παρακάτω δίνεται ένα παράδειγμα.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Αναπαράσταση Δεδομένων ως Μεγέθη Γραφήματος Φυσαλίδων**
Η ιδιότητα **bubble_size_representation** προστέθηκε στις κλάσεις ChartSeries και ChartSeriesGroup. Η **bubble_size_representation** καθορίζει πώς αντιπροσωπεύονται οι τιμές μεγέθους των φυσαλίδων στο γράφημα φυσαλίδων. Οι δυνατές τιμές είναι: **BubbleSizeRepresentationType.AREA** και **BubbleSizeRepresentationType.WIDTH**. Συνεπώς, προστέθηκε η απαρίθμηση **BubbleSizeRepresentationType** για να καθορίζει τους πιθανούς τρόπους αναπαράστασης των δεδομένων ως μεγέθη γραφήματος φυσαλίδων. Το παρακάτω δείχνει κώδικα.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται «γράφημα φυσαλίδων με 3Δ εφέ» και πώς διαφέρει από ένα κανονικό;**

Ναι. Υπάρχει ξεχωριστός τύπος γραφήματος, «Bubble with 3-D». Εφαρμόζει στυλ 3‑Δ στις φυσαλίδες αλλά δεν προσθέτει πρόσθετο άξονα· τα δεδομένα παραμένουν X‑Y‑S (μέγεθος). Ο τύπος είναι διαθέσιμος στην απαρίθμηση [chart type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/charttype/).

**Υπάρχει όριο στον αριθμό των σειρών και των σημείων σε ένα γράφημα φυσαλίδων;**

Δεν υπάρχει σκληρό όριο στο επίπεδο του API· οι περιορισμοί καθορίζονται από την απόδοση και την έκδοση του PowerPoint-στόχου. Συνιστάται να διατηρείτε τον αριθμό των σημείων σε λογικό επίπεδο για ευανάγνωστη παρουσίαση και ταχύτητα απόδοσης.

**Πώς θα επηρεάσει η εξαγωγή την εμφάνιση ενός γραφήματος φυσαλίδων (PDF, εικόνες);**

Η εξαγωγή σε υποστηριζόμενες μορφές διατηρεί την εμφάνιση του γραφήματος· η απόδοση γίνεται από τη μηχανή Aspose.Slides. Για μορφές raster/vector ισχύουν οι γενικοί κανόνες απόδοσης γραφικών γραφήματος (ανάλυση, anti‑aliasing), οπότε επιλέξτε επαρκές DPI για εκτύπωση.