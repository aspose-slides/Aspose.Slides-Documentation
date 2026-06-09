---
title: Διάγραμμα
type: docs
weight: 60
url: /el/python-net/examples/elements/chart/
keywords:
- διάγραμμα
- προσθήκη διαγράμματος
- πρόσβαση διαγράμματος
- αφαίρεση διαγράμματος
- ενημέρωση διαγράμματος
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα στην Python με Aspose.Slides: προσθέστε δεδομένα, μορφοποιήστε σειρές, άξονες και ετικέτες, αλλάξτε τύπους και εξάγετε—λειτουργεί με PPT, PPTX και ODP."
---
Παραδείγματα για την προσθήκη, πρόσβαση, διαγραφή και ενημέρωση διαφορετικών τύπων διαγραμμάτων με **Aspose.Slides for Python via .NET**. Τα παρακάτω αποσπάσματα δείχνουν βασικές λειτουργίες διαγραμμάτων.

## **Προσθήκη Διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθέστε ένα απλό διάγραμμα στήλης στην πρώτη διαφάνεια.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Διάγραμμα**

Ο ακόλουθος κώδικας ανακτά ένα διάγραμμα από τη συλλογή σχημάτων.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Αφαίρεση Διαγράμματος**

Ο ακόλουθος κώδικας αφαιρεί ένα διάγραμμα από μια διαφάνεια.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι ένα διάγραμμα.
        chart = slide.shapes[0]

        # Αφαίρεση του διαγράμματος.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση Δεδομένων Διαγράμματος**

Μπορείτε να αλλάξετε τις ιδιότητες του διαγράμματος, όπως ο τίτλος.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι ένα διάγραμμα.
        chart = slide.shapes[0]

        # Αλλαγή του τίτλου του διαγράμματος.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```