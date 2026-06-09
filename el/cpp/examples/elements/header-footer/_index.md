---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/cpp/examples/elements/header-footer/
keywords:
- παράδειγμα κώδικα
- κεφαλίδα
- υποσέλιδο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ελέγξτε τις κεφαλίδες και τα υποσέλιδα διαφανειών με το Aspose.Slides for C++: προσθέστε ημερομηνίες, αριθμούς διαφανειών και προσαρμοσμένο κείμενο σε αρχεία PPT, PPTX και ODP με παραδείγματα C++."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τα σύμβολα κράτησης θέσης ημερομηνίας και ώρας χρησιμοποιώντας το **Aspose.Slides for C++**.

## **Προσθήκη Υποσέλιδου**

Προσθέστε κείμενο στην περιοχή υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Ενημέρωση Ημερομηνίας και Ώρας**

Τροποποιήστε το σύμβολο κράτησης θέσης ημερομηνίας και ώρας σε μια διαφάνεια.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```