---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Διαχείριση πλαισίου κειμένου
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
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Το Aspose.Slides για C++ καθιστά εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να βάλετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides για C++ παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κείμενο.

{{% alert title="Πληροφορία" color="info" %}}
Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape) που σας επιτρέπει να προσθέτετε σχήματα στις διαφάνειες. Ωστόσο, δεν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` μπορούν να περιέχουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) μπορεί να περιέχουν κείμενο. 
{{% /alert %}}

{{% alert title="Σημείωση" color="warning" %}} 
Κατά συνέπεια, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της διεπαφής `IAutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame), που είναι μια ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Ενημέρωση κειμένου](https://docs.aspose.com/slides/el/cpp/manage-textbox/#update-text) σε αυτή τη σελίδα. 
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation). 
2. Λάβετε μια αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) με την ιδιότητα [ShapeType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ορισμένη σε `Rectangle` σε μια καθορισμένη θέση στη διαφάνεια και λάβετε την αναφορά για το νέο αντικείμενο `IAutoShape`. 
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C++—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

// Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
auto portion = para->get_Portions()->idx_get(0);

// Ορίζει το κείμενο
portion->set_Text(u"Aspose TextBox");

// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Έλεγχος σχήματος πλαισίου κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [get_IsTextBox](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_istextbox/) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/), που σας επιτρέπει να ελέγξετε σχήματα και να εντοπίσετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας C++ σας δείχνει πώς να ελέγξετε εάν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
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

Σημειώστε ότι εάν απλώς προσθέσετε ένα αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `AddAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/), η μέθοδος `get_IsTextBox` του αυτόματου σχήματος θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `AddTextFrame` ή τη μέθοδο `set_Text`, η μέθοδος `get_IsTextBox` επιστρέφει `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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

## **Εύρεση σχήματος που ανήκει σε πλαίσιο κειμένου**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) χωρίς να ξέρετε εκ των προτέρων ποια παρουσίαση το περιέχει. Χρησιμοποιήστε το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) για να πλοηγηθείτε πίσω στο ιδιοκτήτη [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) επιστρέφει τον ιδιοκτήτη και το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) επιστρέφει `nullptr`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση, έτσι η κλήση τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη τιμή για `nullptr` πριν αποκτήσετε πρόσβαση στο σχήμα.

Για ένα πλήρες παράδειγμα που εντοπίζει τα ιδιοκτησιακά σχήματα και κελιά πινάκων, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/cpp/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [set_ColumnCount](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) και [set_ColumnSpacing](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format)) που σας επιτρέπουν να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να ορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε την απόσταση μεταξύ των στηλών σε points.

Αυτός ο κώδικας σε C++ δείχνει τη περιγραφόμενη λειτουργία: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

// Καθορίζει τον αριθμό των στηλών στο TextFrame
format->set_ColumnCount(3);

// Καθορίζει το διάστημα μεταξύ των στηλών
format->set_ColumnSpacing(10);

// Αποθηκεύει την παρουσίαση
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides για C++ παρέχει τη μέθοδο [set_ColumnCount](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_text_frame_format)) που σάς επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της μεθόδου, μπορείτε να ορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου. 

Αυτός ο κώδικας C++ σας δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο μιας παρουσίασης. 

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζονται:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
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

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο** 

Μπορείτε να εισαγάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κλικαριστεί, οι χρήστες θα μεταβούν να ανοίξουν τον σύνδεσμο. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`. 
2. Λάβετε μια αναφορά στην πρώτη διαφάνεια της νεοδημιουργημένης παρουσίασης. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο σε `Rectangle` σε μια καθορισμένη θέση στη διαφάνεια και λάβετε την αναφορά του νεοεισαγμένου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `IHyperlinkManager`. 
6. Αναθέστε το αντικείμενο `IHyperlinkManager` στη μέθοδο [set_HyperlinkClick](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) που συνδέεται με το επιθυμητό τμήμα του `TextFrame`. 
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C++—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα PPTX
auto presentation = System::MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια στην παρουσίαση
auto slide = presentation->get_Slides()->idx_get(0);

// Προσθέτει ένα αντικείμενο AutoShape με τύπο Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Κάνει cast του σχήματος σε AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Προσεγγίζει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Προσθέτει κείμενο στο πλαίσιο
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ορίζει τον υπερσύνδεσμο για το κείμενο της ενότητας
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Αποθηκεύει την παρουσίαση PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και placeholder κειμένου κατά την εργασία με master διαφάνειες;**

Ένα [placeholder](/slides/el/cpp/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslide/) και μπορεί να παρακαμφθεί σε [layouts](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/), αντίθετα, ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε layouts.

**Πώς μπορώ να εκτελέσω μαζική αντικατάσταση κειμένου σε όλη την παρουσίαση χωρίς να επηρεάσω κείμενο μέσα σε γραφήματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε αυτόματα σχήματα που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/el/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartart/)) περνώντας τις συλλογές τους χωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.