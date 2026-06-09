---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/androidjava/examples/elements/header-footer/
keywords:
- παράδειγμα κώδικα
- κεφαλίδα
- υποσέλιδο
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ελέγξτε τις κεφαλίδες και τα υποσέλιδα των διαφανειών με Aspose.Slides for Android: προσθέστε ημερομηνίες, αριθμούς διαφανειών και προσαρμοσμένο κείμενο σε PPT, PPTX και ODP με παραδείγματα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τους υπό-θέτες ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη υποσέλιδου**

Προσθέστε κείμενο στην περιοχή του υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

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

## **Ενημέρωση ημερομηνίας και ώρας**

Τροποποιήστε τον υπό-θέτη ημερομηνίας και ώρας σε μια διαφάνεια.

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