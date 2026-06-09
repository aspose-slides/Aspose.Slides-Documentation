---
title: Αντικείμενο OLE
type: docs
weight: 210
url: /el/python-net/examples/elements/ole-object/
keywords:
- αντικείμενο OLE
- προσθήκη αντικειμένου OLE
- πρόσβαση σε αντικείμενο OLE
- αφαίρεση αντικειμένου OLE
- ενημέρωση αντικειμένου OLE
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργαστείτε με αντικείμενα OLE σε Python χρησιμοποιώντας το Aspose.Slides: εισαγάγετε ή ενημερώστε ενσωματωμένα αρχεία, ορίστε εικονίδια ή συνδέσμους, εξαγάγετε περιεχόμενο, ελέγξτε τη συμπεριφορά για PPT, PPTX και ODP."
---
Δείχνει πώς να ενσωματώσετε ένα αρχείο ως αντικείμενο OLE και να ενημερώσετε τα δεδομένα του χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF στην παρουσίαση.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Φόρτωση δεδομένων PDF για ενσωμάτωση.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Προσθήκη πλαισίου αντικειμένου OLE στη διαφάνεια.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανάκτηση του πρώτου πλαισίου αντικειμένου OLE σε μια διαφάνεια.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Λάβετε το πρώτο πλαίσιο αντικειμένου OLE στη διαφάνεια.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Αφαίρεση αντικειμένου OLE**

Διαγραφή ενσωματωμένου αντικειμένου OLE από τη διαφάνεια.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι αντικείμενο OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικατάσταση των δεδομένων που έχουν ενσωματωθεί σε υπάρχον αντικείμενο OLE.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτουμε ότι το πρώτο σχήμα είναι αντικείμενο OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Ενημέρωση του αντικειμένου OLE με τα νέα ενσωματωμένα δεδομένα.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```