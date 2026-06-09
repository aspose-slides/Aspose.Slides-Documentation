---
title: Πλαίσιο κειμένου
type: docs
weight: 40
url: /el/cpp/examples/elements/text-box/
keywords:
- παράδειγμα κώδικα
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εργαστείτε με πλαίσια κειμένου στο Aspose.Slides για C++: προσθέστε, μορφοποιήστε, ευθυγραμμίστε, περιτύλιξη, αυτόματη προσαρμογή και στυλιζάστε το κείμενο χρησιμοποιώντας C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να αφαιρέσετε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη πλαισίου κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με κάποια μορφοποιημένο κείμενο. Δείτε πώς να δημιουργήσετε ένα:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Δημιουργήστε ένα σχήμα ορθογωνίου (προεπιλεγμένα γεμάτο με περίγραμμα και χωρίς κείμενο).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Αφαιρέστε το γέμισμα και το περίγραμμα ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ορίστε τη μορφοποίηση του κειμένου.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Αναθέστε το πραγματικό περιεχόμενο κειμένου.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Σημείωση:** Οποιοδήποτε `AutoShape` που περιέχει ένα μη κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε πλαίσια κειμένου βάσει περιεχομένου**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη-κλειδί (π.χ. «Slide»), επαναλάβετε τα σχήματα και ελέγξτε το κείμενό τους:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Μόνο τα AutoShapes μπορούν να περιέχουν επεξεργάσιμο κείμενο.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Κάντε κάτι με το αντίστοιχο πλαίσιο κειμένου.
            }
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση πλαισίων κειμένου βάσει περιεχομένου**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη-κλειδί:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Συμβουλή:** Δημιουργήστε πάντα ένα αντίγραφο της συλλογής σχήματος πριν το τροποποιήσετε κατά τη διάρκεια της επανάληψης για να αποφύγετε σφάλματα τροποποίησης της συλλογής.