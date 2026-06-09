---
title: HeaderFooter
type: docs
weight: 220
url: /el/python-net/examples/elements/header-footer/
keywords:
- κεφαλίδα και υποσέλιδο
- προσθήκη κεφαλίδας και υποσέλιδας
- ενημέρωση κεφαλίδας και υποσέλιδας
- ορισμός ημερομηνίας και ώρας
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Έλεγχος κεφαλίδων και υποσέλιδων σε Python με Aspose.Slides: προσθήκη ή επεξεργασία ημερομηνίας/ώρας, αριθμών διαφάνειας και κειμένου υποσέλιδου, εμφάνιση ή απόκρυψη συμβόλων κράτησης θέσης σε αρχεία PPT, PPTX και ODP."
---
Δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τα σύμβολα κράτησης θέσης ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη υποσέλιδας**

Προσθέστε κείμενο στην περιοχή υποσέλιδας μιας διαφάνειας και κάντε το ορατό.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση ημερομηνίας και ώρας**

Τροποποιήστε το σύμβολο κράτησης θέσης ημερομηνίας και ώρας σε μια διαφάνεια.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```