---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με C++
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
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Εισαγωγή**

Στο Aspose.Slides για C++, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) αντιπροσωπεύει το πιο κοινό σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}
Κάθε αυτόματο σχήμα υλοποιεί το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Κατά την επεξεργασία μιας υπάρχουσας παρουσίασης, ελέγξτε ότι ένα σχήμα υλοποιεί το [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) πριν αποκτήσετε πρόσβαση στο κείμενό του.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το ακόλουθο παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στο [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addautoshape/) μετρώνται σε πόντους. Το [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_istextbox/) για να προσδιορίσετε εάν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που περιέχουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![A text box and a shape](istextbox.png)

Το ακόλουθο παράδειγμα εξετάζει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Ένα πρόσφατα προστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω του [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/) ή του [ITextFrame::set_Text](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/set_text/). Η προσθήκη ή η ανάθεση ενός κενής συμβολοσειράς κάνει το [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_istextbox/) να επιστρέφει `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Οι δύο πρώτοι έλεγχοι επιστρέφουν `true`; οι δύο τελευταίοι επιστρέφουν `false`.

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Ο γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε τη μέθοδο [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) για να πλοηγηθείτε πίσω στο κέφαλο [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε αυτόματο σχήμα ή σε άλλο σχήμα που φέρει κείμενο, το [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentshape/) επιστρέφει τον κάτοχο και το [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_parentcell/) επιστρέφει `nullptr`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Ελέγξτε την επιστρεφόμενη τιμή για `nullptr` πριν την προσπελάσετε. Για να προσδιορίσετε τόσο τους ιδιοκτήτες σχήματος όσο και του κελιού πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/cpp/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_columncount/) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η μέθοδος [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_columnspacing/) ορίζει το κενό μεταξύ των στηλών σε πόντους. Και οι δύο μέθοδοι ανήκουν στο [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/) και μπορούν να κληθούν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο επαναδιανέμεται μεταξύ των στηλών εντός του ίδιου σχήματος· δεν συνεχίζεται σε διαφορετικό σχήμα.

Το ακόλουθο παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 πόντους μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Εξαγωγή κειμένου από μεμονωμένες στήλες**

Χρησιμοποιήστε το [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/splittextbycolumns/) για να ανακτήσετε το κείμενο που έχει εκχωρηθεί σε κάθε οπτική στήλη σε ένα υπάρχον πλαίσιο κειμένου. Η μέθοδος επιστρέφει μία συμβολοσειρά για κάθε στήλη, με σειρά ανάγνωσης βάσει στήλης. Ένα πλαίσιο κειμένου μίας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αντιπροσωπεύεται από κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η διαμόρφωση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:

- Εξαγάγετε κείμενο διατηρώντας τη στήλη‑βάση σειρά ανάγνωσης.
- Καταχωρήσετε ή συγκρίνετε το περιεχόμενο διαφανειών με πολλές στήλες.
- Εξαγάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Εξετάσετε πώς το κείμενο αναδιανέμεται μετά τον ορισμό του αριθμού στηλών με το [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_columncount/) ή του διαστήματος με το [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_columnspacing/), ή αλλαγή της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται μέσα στο τρέχον [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/); δεν ρέει αυτόματα κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή σε στήλες μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, επομένως βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν είναι σημαντικά τα συνεπή αποτελέσματα.

Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου στην πρώτη διαφάνεια, διαβάζει τον ρυθμισμένο αριθμό στηλών του και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε κείμενο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σάς επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη διαμόρφωση χαρακτήρων.

Το ακόλουθο παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με `months` εντός μεμονωμένων τμημάτων κειμένου αυτόματων σχημάτων και κάνει κάθε επηρεαζόμενο τμήμα έντονο:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Αυτή η διέλευση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διέλευση των συλλογών των αντίστοιχων αντικειμένων.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Ένας υπερσύνδεσμος μπορεί να εκχωρηθεί σε συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικ-σύνδεσμος. Χρησιμοποιήστε το [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/el/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) για να συσχετίσετε το τμήμα με μια εξωτερική διεύθυνση URL.

Το ακόλουθο παράδειγμα δημιουργεί συνδεδεμένο κείμενο και το αποθηκεύει σε μια παρουσίαση:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός δεσμευτικού χώρου κειμένου σε κύρια ή διάταξη διαφάνειας;**

Ένας [placeholder](/slides/el/cpp/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη διαμόρφωσή του από μια [master slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslide/) ή μια [layout slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά συμπεριφορά δεσμευτικού χώρου όταν αλλάζει η διάταξη.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διέλευση σε σχήματα που υλοποιούν το [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωση κειμένου. Τα διαγράμματα, οι πίνακες και το SmartArt αποθηκεύουν κείμενο στα δικά τους μοντέλα αντικειμένων, οπότε δεν τροποποιούνται από αυτόν τον βρόχο.