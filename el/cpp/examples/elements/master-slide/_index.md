---
title: Κύρια Διαφάνεια
type: docs
weight: 30
url: /el/cpp/examples/elements/master-slide/
keywords:
- παράδειγμα κώδικα
- κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κύριας διαφάνειας του Aspose.Slides for C++: δημιουργήστε, επεξεργαστείτε και διαμορφώστε masters, placeholders και θέματα σε PPT, PPTX και ODP με σαφή κώδικα C++."
---
Οι κύριες διαφάνειες αποτελούν το υψηλότερο επίπεδο της ιεραρχίας κληρονομικότητας διαφανειών στο PowerPoint. Μια **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως φόντα, λογότυπα και μορφοποίηση κειμένου. Οι **layout slides** κληρονομούν από τις master slides, και οι **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, να τροποποιήσετε και να διαχειριστείτε τις master slides χρησιμοποιώντας το Aspose.Slides for C++.

## **Προσθήκη Master Slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα master slide αντιγράφοντας την προεπιλεγμένη. Στη συνέχεια προσθέτει μια διαφήμιση με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω κληρονομίας layout.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Κλωνοποίηση της προεπιλεγμένης master διαφάνειας.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Προσθήκη μιας λωρίδας με το όνομα της εταιρείας στην κορυφή της master διαφάνειας.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ανάθεση της νέας master διαφάνειας σε μια layout διαφάνεια.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Ανάθεση της layout διαφάνειας στην πρώτη διαφάνεια της παρουσίασης.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Οι master slides παρέχουν έναν τρόπο να εφαρμόζετε συνεπή ετικέτες ή κοινά στοιχεία σχεδίασης σε όλες τις διαφάνειες. Οποιεσδήποτε αλλαγές γίνουν στη master θα αντικατοπτρίζονται αυτόματα στις εξαρτώμενες layout και normal διαφάνειες.
> 
> 💡 **Note 2:** Οποιεσδήποτε σχήματα ή μορφοποιήσεις προστεθούν σε μια master slide κληρονομούνται από τις layout διαφάνειες και, με τη σειρά τους, από όλες τις normal διαφάνειες που χρησιμοποιούν αυτές τις layout.  
> Η παρακάτω εικόνα απεικονίζει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια master slide εμφανίζεται αυτόματα στην τελική διαφάνεια.

![Παράδειγμα Κληρονομίας Master](master-slide-banner.png)

## **Πρόσβαση σε Master Slide**

Μπορείτε να αποκτήσετε πρόσβαση στις master slides χρησιμοποιώντας τη συλλογή master του παρουσιάσματος. Ακολουθεί πώς να τις ανακτήσετε και να εργαστείτε με αυτές:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Αλλάξτε τον τύπο του φόντου.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Αφαίρεση Master Slide**

Οι master slides μπορούν να αφαιρεθούν είτε με βάση τον δείκτη είτε με αναφορά.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Αφαίρεση μιας master διαφάνειας κατά δείκτη.
    presentation->get_Masters()->RemoveAt(0);

    // Αφαίρεση μιας master διαφάνειας κατά αναφορά.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Αφαίρεση Αχρησιμοποίητων Master Slides**

Μερικές παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Αφαίρεση όλων των αχρησιμοποίητων master διαφανειών (ακόμη και αυτών που έχουν σημειωθεί ως Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```