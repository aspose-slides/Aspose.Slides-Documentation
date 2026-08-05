---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
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
description: "Έλεγχο κεφαλίδων και υποσέλιδων διαφάνειας με Aspose.Slides για .NET: προσθήκη ημερομηνιών, αριθμών διαφανειών και προσαρμοσμένου κειμένου σε PPT, PPTX και ODP με παραδείγματα C#."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τα σύμβολα κράτησης θέσης ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη Υποσέλιδου**
Προσθέστε κείμενο στην περιοχή υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Ενημέρωση Ημερομηνίας και Ώρας**
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