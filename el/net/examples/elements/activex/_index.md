---
title: ActiveX
type: docs
weight: 200
url: /el/net/examples/elements/activex/
keywords:
- ActiveX
- προσθήκη ActiveX
- πρόσβαση ActiveX
- αφαίρεση ActiveX
- Ιδιότητες ActiveX
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δείτε παραδείγματα ActiveX του Aspose.Slides for .NET: εισαγωγή, διαμόρφωση και έλεγχο αντικειμένων ActiveX σε παρουσιάσεις PPT και PPTX με σαφή κώδικα C#."
---
Το άρθρο αυτό δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη ελέγχου ActiveX**

Εισάγετε έναν νέο έλεγχο ActiveX και προαιρετικά ορίστε τις ιδιότητές του.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Προσθήκη νέου ελέγχου ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Προαιρετικά ορίστε κάποιες ιδιότητες.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Πρόσβαση σε έλεγχο ActiveX**

Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Πρόσβαση στον πρώτο έλεγχο ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Αφαίρεση ελέγχου ActiveX**

Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Αφαίρεση του πρώτου ελέγχου ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Ορισμός ιδιοτήτων ActiveX**

Προσθέστε έναν έλεγχο και διαμορφώστε πολλές ιδιότητες ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Προσθήκη CommandButton και διαμόρφωση ιδιοτήτων.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```