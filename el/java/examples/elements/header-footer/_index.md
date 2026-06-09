---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/java/examples/elements/header-footer/
keywords:
- παράδειγμα κώδικα
- κεφαλίδα
- υποσέλιδο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Έλεγχος κεφαλίδων και υποσέλιδων διαφανειών με Aspose.Slides for Java: προσθήκη ημερομηνιών, αριθμών διαφάνειας και προσαρμοσμένου κειμένου σε PPT, PPTX και ODP με παραδείγματα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τους υποκαταστάτες ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη Υποσέλιδου**

Προσθέστε κείμενο στην περιοχή υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση Ημερομηνίας και Ώρας**

Τροποποιήστε τον υποκαταστάτη ημερομηνίας και ώρας σε μια διαφάνεια.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```