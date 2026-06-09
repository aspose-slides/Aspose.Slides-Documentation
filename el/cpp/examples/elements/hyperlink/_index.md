---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/cpp/examples/elements/hyperlink/
keywords:
- παράδειγμα κώδικα
- υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε και διαχειριστείτε υπερσυνδέσμους στο Aspose.Slides για C++: συνδέστε κείμενο, σχήματα και εικόνες, ορίστε προορισμούς και ενέργειες για PPT, PPTX και ODP με παραδείγματα C++."
---
Αυτό το άρθρο δείχνει πώς να προσθέτετε, να αποκτάτε πρόσβαση, να αφαιρείτε και να ενημερώνετε υπερσυνδέσμους σε σχήματα χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με ένα υπερσύνδεσμο που οδηγεί σε εξωτερική ιστοσελίδα.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Πρόσβαση σε υπερσύνδεσμο**

Αναγνώστε τις πληροφορίες του υπερσυνδέσμου από το κείμενο ενός σχήματος.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Αφαίρεση υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο ενός σχήματος.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Ενημέρωση υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που ήδη περιέχει υπερσύνδεσμο, προσομοιώνοντας τον τρόπο με τον οποίο το PowerPoint ενημερώνει τους υπερσυνδέσμους με ασφάλεια.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
    // HyperlinkManager αντί για την άμεση ανάθεση της ιδιότητας.
    // Αυτό προσομοιώνει τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```