---
title: "Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με C++"
linktitle: "Διαχείριση πλαισίου κειμένου"
type: docs
weight: 20
url: /el/cpp/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Το Aspose.Slides for C++ καθιστά εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, βελτιώνοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και μετά να βάλετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides for C++ παρέχει το interface [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κείμενο.

{{% alert title="Πληροφορίες" color="info" %}}

Το Aspose.Slides παρέχει επίσης το interface [IShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape) που σας επιτρέπει να προσθέσετε σχήματα στις διαφάνειες. Ωστόσο, όχι όλα τα σχήματα που προσθέτονται μέσω του interface `IShape` μπορούν να κρατήσουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω του interface [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) μπορεί να περιέχουν κείμενο. 

{{% /alert %}}

{{% alert title="Σημείωση" color="warning" %}} 

Συνεπώς, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω του interface `IAutoShape`. Μόλις το κάνετε, θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame), το οποίο είναι ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/cpp/manage-textbox/#update-text) σε αυτή τη σελίδα. 

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε μια διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation). 
2. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) με το [ShapeType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοδημιουργηθέντος αντικειμένου `IAutoShape`. 
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε αυτό το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C++—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```cpp
// Δημιουργεί παρουσίαση
auto pres = System::MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια στην παρουσίαση
auto sld = pres->get_Slides()->idx_get(0);

// Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Προσθέτει TextFrame στο Rectangle
ashp->AddTextFrame(u" ");

// Προσπελαύνει το TextFrame
auto txtFrame = ashp->get_TextFrame();

// Δημιουργεί το αντικείμενο Paragraph για το TextFrame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Δημιουργεί ένα αντικείμενο Portion για το paragraph
auto portion = para->get_Portions()->idx_get(0);

// Ορίζει κείμενο
portion->set_Text(u"Aspose TextBox");

// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [get_IsTextBox](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_istextbox/) από το interface [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) που σας επιτρέπει να εξετάζετε σχήματα και να εντοπίζετε πλαίσια κειμένου.

![Text box and shape](istextbox.png)

Αυτός ο κώδικας C++ σας δείχνει πώς να ελέγξετε εάν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Σημειώστε ότι εάν προσθέσετε απλώς ένα autoshape χρησιμοποιώντας τη μέθοδο `AddAutoShape` από το interface [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/), η μέθοδος `get_IsTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `AddTextFrame` ή τη μέθοδο `set_Text`, η μέθοδος `get_IsTextBox` θα επιστρέψει `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() επιστρέφει false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() επιστρέφει true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() επιστρέφει false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() επιστρέφει true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() επιστρέφει false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() επιστρέφει false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() επιστρέφει false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() επιστρέφει false
```

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [set_ColumnCount](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) και [set_ColumnSpacing](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (από το interface [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format)) που σάς επιτρέπουν να προσθέσετε στήλες στα πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε το διάστημα σε πόντους μεταξύ των στηλών. 

Αυτός ο κώδικας C++ δείχνει τη λειτουργία:

```cpp
auto presentation = System::MakeObject<Presentation>();
// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
auto slide = presentation->get_Slides()->idx_get(0);

// Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Προσθέτει TextFrame στο Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Λαμβάνει τη μορφοποίηση κειμένου του TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Ορίζει τον αριθμό των στηλών στο TextFrame
format->set_ColumnCount(3);

// Ορίζει το διάστημα μεταξύ των στηλών
format->set_ColumnSpacing(10);

// Αποθηκεύει την παρουσίαση
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Προσθήκη στηλών σε πλαίσιο κειμένου (Text Frame)**
Το Aspose.Slides for C++ παρέχει τη μέθοδο [set_ColumnCount](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (από το interface [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format)) που σάς επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της μεθόδου, μπορείτε να ορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου. 

Αυτός ο κώδικας C++ σας δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλα τα κείμενα που περιέχονται σε μια παρουσίαση. 

Αυτός ο κώδικας C++ παρουσιάζει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζουν:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Αλλάζει το κείμενο
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Αλλάζει τη μορφοποίηση
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Αποθηκεύει την τροποποιημένη παρουσίαση
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεση** 

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν κάνετε κλικ στο πλαίσιο κειμένου, οι χρήστες κατευθύνονται για να ανοίξουν τον σύνδεσμο. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`. 
2. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με το `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοδημιουργηθέντος αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `IHyperlinkManager`. 
6. Αναθέστε το αντικείμενο `IHyperlinkManager` στη μέθοδο [set_HyperlinkClick](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) που σχετίζεται με το προτιμώμενο τμήμα του `TextFrame`. 
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C++—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεση σε μια διαφάνεια:

```cpp
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα PPTX
auto presentation = System::MakeObject<Presentation>();

// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
auto slide = presentation->get_Slides()->idx_get(0);

// Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Κάνει cast το σχήμα σε AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Προσπελαύνει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Προσθέτει κάποιο κείμενο στο πλαίσιο
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ορίζει τον υπερσύνδεσμο για το κείμενο της Portion
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Αποθηκεύει την παρουσίαση PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και αντικαταστάτη κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/cpp/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslide/) και μπορεί να παρακαμφθεί στα [layouts](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/), ενώ ένα απλό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να εκτελέσω αντικατάσταση κειμένου μαζικά σε όλη την παρουσίαση χωρίς να αγγίξω το κείμενο μέσα σε διαγράμματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε autoshapes που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartart/)) μεταβαίνοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.