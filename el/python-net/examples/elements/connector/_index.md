---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/python-net/examples/elements/connector/
keywords:
- σύνδεσμος
- προσθήκη συνδέσμου
- πρόσβαση σε σύνδεσμο
- αφαίρεση συνδέσμου
- επανασύνδεση σχημάτων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Σχεδιάστε και ελέγξτε συνδέσμους σε Python με Aspose.Slides: προσθήκη, δρομολόγηση, επαναδρομολόγηση, ορισμός σημείων σύνδεσης, βελών και στυλ για σύνδεση σχημάτων σε PPT, PPTX και ODP."
---
Δείχνει πώς να συνδέσετε σχήματα με συνδέσμους και να αλλάξετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Συνδέσμου**

Εισάγετε ένα σχήμα συνδέσμου μεταξύ δύο σημείων στη διαφάνεια.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθήκη σχήματος λυγρού συνδέσμου.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Σύνδεσμο**

Ανακτήστε το πρώτο σχήμα συνδέσμου που προστέθηκε σε μια διαφάνεια.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Αφαίρεση Συνδέσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι σύνδεσμος.
        connector = slide.shapes[0]

        # Αφαίρεση του συνδέσμου.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε έναν σύνδεσμο σε δύο σχήματα ορίζοντας τους αρχικούς και τελικούς προορισμούς.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Προσθήκη του πρώτου σχήματος ορθογωνίου.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Προσθήκη του δεύτερου σχήματος ορθογωνίου.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Προσθήκη σχήματος λυγρού συνδέσμου.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Σύνδεση της αρχής του συνδέσμου με το πρώτο σχήμα.
        connector.start_shape_connected_to = shape1
        # Σύνδεση του τέλους του συνδέσμου με το δεύτερο σχήμα.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```