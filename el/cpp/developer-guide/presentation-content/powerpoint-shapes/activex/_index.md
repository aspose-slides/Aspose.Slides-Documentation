---
title: Διαχείριση Ελέγχων ActiveX σε Παρουσιάσεις με C++
linktitle: ActiveX
type: docs
weight: 80
url: /el/cpp/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- Διαχείριση ActiveX
- Προσθήκη ActiveX
- Τροποποίηση ActiveX
- Αναπαραγωγέας πολυμέσων
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides for C++ αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση των παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο πάνω στις διαφάνειες."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for C++ σάς επιτρέπει να διαχειρίζεστε ελέγχους ActiveX, αλλά η διαχείρισή τους είναι λίγο πιο δύσκολη και διαφορετική από τα κανονικά σχήματα της παρουσίασης. Από το Aspose.Slides for C++ 18.1, το στοιχείο υποστηρίζει τη διαχείριση ελέγχων ActiveX. Αυτή τη στιγμή, μπορείτε να αποκτήσετε πρόσβαση σε ήδη προστεθέν έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή διαγράψετε χρησιμοποιώντας τις διάφορες ιδιότητές του. Θυμηθείτε, οι έλεγχοι ActiveX δεν είναι σχήματα και δεν αποτελούν μέρος του IShapeCollection της παρουσίασης, αλλά του ξεχωριστού IControlCollection. Αυτό το άρθρο δείχνει πώς να εργαστείτε με αυτούς.

## **Τροποποίηση ελέγχου ActiveX**
Για να διαχειριστείτε έναν απλό έλεγχο ActiveX όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολών σε μια διαφάνεια:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation και φορτώστε την παρουσίαση που περιέχει ελέγχους ActiveX.
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση το δείκτη της.
1. Προσπελάστε τους ελέγχους ActiveX στη διαφάνεια μέσω του IControlCollection.
1. Προσπελάστε τον έλεγχο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο ControlEx.
1. Αλλάξτε τις διάφορες ιδιότητες του ελέγχου ActiveX TextBox1, συμπεριλαμβανομένου του κειμένου, της γραμματοσειράς, του ύψους γραμματοσειράς και της θέσης του πλαισίου.
1. Προσπελάστε τον δεύτερο έλεγχο που ονομάζεται CommandButton1.
1. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.
1. Μετατοπίστε τη θέση των πλαισίων των ελέγχων ActiveX.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Το παρακάτω απόσπασμα κώδικα ενημερώνει τους ελέγχους ActiveX στις διαφάνειες της παρουσίασης όπως φαίνεται παρακάτω.

``` cpp
// Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
auto slide = presentation->get_Slides()->idx_get(0);

// Αλλαγή κειμένου TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // αλλαγή εναλλακτικής εικόνας. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά τη διάρκεια της ενεργοποίησης του ActiveX, οπότε μερικές φορές είναι εντάξει να αφήσουμε την εικόνα αμετάβλητη.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Αλλαγή λεζάντας κουμπιού
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // αλλαγή εναλλακτικού
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Μετακίνηση πλαισίων ActiveX 100 μονάδες προς τα κάτω
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Αποθήκευση της παρουσίασης με Επεξεργασμένα Ελέγχους ActiveX
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Τώρα αφαίρεση ελέγχων
slide->get_Controls()->Clear();

// Αποθήκευση της παρουσίασης με εκκαθαρισμένους ελέγχους ActiveX
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Προσθήκη ελέγχου ActiveX Media Player**
Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for C++ σάς επιτρέπει να προσθέτετε και να διαχειρίζεστε ελέγχους ActiveX, αλλά η διαχείρισή τους είναι λίγο πιο δύσκολη και διαφορετική από τα κανονικά σχήματα της παρουσίασης. Από το Aspose.Slides for C++ 18.1, η υποστήριξη για την προσθήκη ελέγχου ActiveX Media Player προστέθηκε στο Aspose.Slides. Θυμηθείτε, οι έλεγχοι ActiveX δεν είναι σχήματα και δεν αποτελούν μέρος του IShapeCollection της παρουσίασης, αλλά του ξεχωριστού IControlExCollection. Αυτό το άρθρο δείχνει πώς να εργαστείτε με αυτούς. Για να διαχειριστείτε έναν έλεγχο ActiveX Media Player, παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation και φορτώστε τη δοκιμαστική παρουσίαση που περιέχει ελέγχους ActiveX Media Player.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation-στόχου και δημιουργήστε μια κενή παρουσίαση.
1. Κλωνοποιήστε τη διαφάνεια με τον έλεγχο ActiveX Media Player από την πρότυπη παρουσίαση στη στόχευση Presentation.
1. Προσπελάστε τη κλωνοποιημένη διαφάνεια στην στόχευση Presentation.
1. Προσπελάστε τους ελέγχους ActiveX στη διαφάνεια μέσω του IControlCollection.
1. Προσπελάστε τον έλεγχο ActiveX Media Player και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

``` cpp
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Δημιουργία κενής παρουσίασης
auto newPresentation = System::MakeObject<Presentation>();

// Αφαίρεση προεπιλεγμένης διαφάνειας
newPresentation->get_Slides()->RemoveAt(0);

// Κλωνοποίηση διαφάνειας με έλεγχο Media Player ActiveX
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός διαδρομής βίντεο
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Αποθήκευση της παρουσίασης
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Διατηρεί το Aspose.Slides τους ελέγχους ActiveX όταν διαβάζει και αποθηκεύει ξανά εάν δεν μπορούν να εκτελεστούν στο περιβάλλον εκτέλεσης C++;**

Ναι. Το Aspose.Slides τα θεωρεί μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· η εκτέλεση των ελέγχων δεν απαιτείται για τη διατήρησή τους.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Οι έλεγχοι ActiveX είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/cpp/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ. ένα φύλλο Excel). Αποθηκεύονται και αντιμετωπίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα γεγονότα ActiveX και οι μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα κατάσταση σήμανσης και τα μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.