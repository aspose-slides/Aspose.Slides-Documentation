---
title: ActiveX
type: docs
weight: 200
url: /el/cpp/examples/elements/activex/
keywords:
- παράδειγμα κώδικα
- ActiveX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δείτε παραδείγματα ActiveX του Aspose.Slides for C++: εισαγωγή, διαμόρφωση και έλεγχο αντικειμένων ActiveX σε παρουσιάσεις PPT και PPTX με σαφή κώδικα C++."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να ρυθμίσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη ελέγχου ActiveX**

Εισάγετε έναν νέο έλεγχο ActiveX και προαιρετικά ορίστε τις ιδιότητές του.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέστε έναν νέο έλεγχο ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Προαιρετικά ορίστε ορισμένες ιδιότητες.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Πρόσβαση σε έλεγχο ActiveX**

Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Πρόσβαση στον πρώτο έλεγχο ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Αφαίρεση ελέγχου ActiveX**

Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Αφαίρεση του πρώτου ελέγχου ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Ορισμός ιδιοτήτων ActiveX**

Προσθέστε έναν έλεγχο και ρυθμίστε πολλαπλές ιδιότητες ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέστε έναν έλεγχο Windows Media Player και διαμορφώστε τις ιδιότητες.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```