---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/net/examples/elements/header-footer/
keywords:
- κεφαλίδα υποσέλιδο
- προσθήκη κεφαλίδα υποσέλιδο
- ενημέρωση κεφαλίδα υποσέλιδο
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Έλεγχος κεφαλίδων και υποσελίδων διαφανειών με Aspose.Slides για .NET: προσθήκη ημερομηνιών, αριθμών διαφανειών και προσαρμοσμένου κειμένου σε PPT, PPTX και ODP με παραδείγματα C#."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τα σύμβολα κράτησης θέσης ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη υποσέλιδου**

Προσθέστε κείμενο στην περιοχή του υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Ενημέρωση ημερομηνίας και ώρας**

Τροποποιήστε το σύμβολο κράτησης θέσης ημερομηνίας και ώρας σε μια διαφάνεια.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```