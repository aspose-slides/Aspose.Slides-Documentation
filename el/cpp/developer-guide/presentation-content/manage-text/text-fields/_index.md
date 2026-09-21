---
title: Διαχείριση πεδίων κειμένου σε παρουσιάσεις PowerPoint με C++
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/cpp/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- τμήμα κειμένου
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Δημιουργήστε, εξετάστε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++. Διατηρήστε τη μορφοποίηση και ελέγξτε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα συνηθισμένο [IPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου έχει επίσης ένα [IField](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifield/) του οποίου ο τύπος υποδεικνύει μια αυτόματα ενημερώσιμη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε [IPortion::get_Field](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/get_field/) για να τα ξεχωρίσετε: επιστρέφει `nullptr` για συνηθισμένο κείμενο. [IPortion::AddField](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/addfield/) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Κρατήστε μια ετικέτα και τη δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει πεδία μέσα σε κείμενο, τη μορφοποίησή τους και την αποθήκευσή τους σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε [Manage Text](/slides/el/cpp/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, επομένως το αναμενόμενο κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι θα πρέπει να εμφανίσουν `True`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι κυριολεκτικό `1`. Η αναφορά και οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και στα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

[FieldType](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/) υλοποιεί το [IFieldType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifieldtype/) και παρέχει τις παρακάτω προορισμένες τιμές. Περάστε την κατάλληλη τιμή στη [AddField](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/addfield/).

| Accessor | Purpose |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_slidenumber/) | Ο τρέχων αριθμός διαφάνειας. |
| [get_DateTime](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime/) | Η ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [get_DateTime1](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime9/) | Προκαθορισμένες μορφές ημερομηνίας ή συνδυασμένες μορφές ημερομηνίας/ώρας. |
| [get_DateTime10](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime13/) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ώρολογο ρολόι. |
| [get_Header](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_header/) | Πεδίου κεφαλίδας· δείτε τους περιορισμούς του προσδιοριστικού στοιχείου και της μορφής παρακάτω. |
| [get_Footer](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_footer/) | Πεδίου υποσέλιδου. |

Για παράδειγμα, το [get_DateTime3](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/get_datetime3/) παρέχει ημέρα, πλήρες όνομα μήνα και έτος στα Αγγλικά. Πρόκειται για προορισμένες μορφές πεδίου, όχι αυθαίρετες αλφαριθμητικές μορφές ημερομηνίας. Η γλώσσα του τμήματος, που ορίζεται με το [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_languageid/), και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορεί να επηρεάσει το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Σειρά**

Η υπερφόρτωση συμβολοσειράς του [AddField](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/addfield/) δέχεται έναν εσωτερικό αναγνωριστικό πεδίου. Χρησιμοποιήστε το όταν θέλετε να διατηρήσετε έναν αναγνωριστικό που παρέχει άλλη εφαρμογή και δεν έχει προορισμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/cpp/aspose.slides/fieldtype/fieldtype/) από τον αναγνωριστικό. Το [IFieldType::get_InternalString](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifieldtype/get_internalstring/) εκθέτει αυτόν τον αναγνωριστικό για επιθεώρηση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με εφεδρικό κείμενο `Report-042`. Δεν απαιτείται αρχείο εισόδου. Ο αναγνωριστικός δεν εγγράφεται ως υπολογισμός: το Aspose.Slides δεν δημιουργεί IDs αναφοράς για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτόν τον αναγνωριστικό πρέπει να παρέχει το νόημά του και να ενημερώνει την τιμή του.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Μετά από αυτό το γύρισμα PPTX, ο αναμενόμενος τύπος είναι `custom-report-id` και το αναμενόμενο κείμενο είναι `Report-042`. Η διέλευση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονόμαζε τύπο πεδίου· δεν θα διαμόρφωνε προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Έλεγχος, Τροποποίηση και Αφαίρεση Πεδία Ημερομηνίας/Ώρας**

Διαβάστε έναν υπάρχοντα τύπο πεδίου μέσω του [IField::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifield/get_type/) και αλλάξτε το μέσω του [IField::set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifield/set_type/). Ελέγξτε ότι το πεδίο υπάρχει πριν προσπελάσετε τον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [IPortion::RemoveField](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/removefield/). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη συσχέτιση πεδίου. Αν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, ορίστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/set_currentdatetime/). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης όταν μετατρέπει ένα πεδίο σε συνηθισμένο κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον τρέχοντα φάκελο εργασίας. Περιέχει δύο ονομασμένα σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, καθώς και συνηθισμένες ετικέτες κειμένου. Το ακόλουθο παράδειγμα περιηγείται στα κορυφαία σχήματα κειμένου σε κανονικές διαφάνειες. Μετατρέπει τα πεδία ημερομηνίας/ώρας σε μορφή «μακρά ημερομηνία» και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις τους. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Οι ενσωματωμένοι εσωτερικοί αναγνωριστικοί `datetime` και `datetime1` έως `datetime13` αναγνωρίζονται από το δείγμα. Ομάδες, πίνακες, σημειώσεις, διατάξεις και κύριοι (masters) απαιτούν διερεύνηση των δικών τους περιεκτών κειμένου και δεν εμπίπτουν στο εύρος αυτού του παραδείγματος.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Μετά το άνοιγμα, το `UpdatedAt` πρέπει να έχει τύπο `datetime3` και να παραμείνει δυναμικό. Το `ApprovedDate` δεν πρέπει να έχει πεδίο και να περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα παραμένουν αμετάβλητα. Οι συνηθισμένες ετικέτες κειμένου δεν αλλάζουν. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Εργαστείτε με το υπάρχον τμήμα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση εκείνου του τμήματος. Χρησιμοποιήστε το [IPortion::get_PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/get_portionformat/) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως κάνουν τα παραδείγματα για χρώμα ή πλάγια.

Αποφύγετε την ανακατασκευή ολόκληρου πλαισίου κειμένου μόνο για να ενημερώσετε ένα πεδίο· αυτό μπορεί να χάσει τα αρχικά όρια τμημάτων και τη δική τους μορφοποίηση. Επίσης διαχωρίστε ρητά ορισμένη μορφοποίηση από αυτήν που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/cpp/text-formatting/) για ευρύτερες επιλογές μορφοποίησης.

## **Πεδία και Ενθέματα Header/Footer**

Ένα πεδίο είναι μέρος ενός τμήματος κειμένου. Ένα ένθεμα (placeholder) είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα συνηθισμένο πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε ένθεμα.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο ενθέματος και την ορατότητά του σε διαφάνειες, διατάξεις και κύριους, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και αν δεν χρησιμοποιείτε το ένθεμα αριθμού διαφάνειας. Αντίστροφα, η αλλαγή ορατότητας ενθέματος δεν αφαιρεί πεδίο από ένα μη σχετικό πλαίσιο κειμένου.

Οι προκαθορισμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα ένθεμα ούτε παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει ένθεμα κεφαλίδας· οι κεφαλίδες ανήκουν σε σελίδες σημειώσεων και φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα λάβει αυτόματα το κείμενο που ρυθμίζεται μέσω του διαχειριστή ενθέματος. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/cpp/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το προκύπτον κείμενο μετά την αποθήκευση και το άνοιγμα ξανά. Η διατήρηση ενός αναγνωριστικού δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Αποθηκεύει εσωτερικά αναγνωριστικά πεδίου μαζί με το κείμενο του πεδίου. Χρησιμοποιήστε τα παραδείγματα παραπάνω για να ελέγξετε προορισμένους τύπους και προσαρμοσμένα αναγνωριστικά μετά την αποθήκευση και το άνοιγμα. Ένας άγνωστος προσαρμοσμένος τύπος δεν αποκτά λογική αυτόματου υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει μη υποστηριζόμενα αναγνωριστικά διαφορετικά. |
| PPT | Χρησιμοποιεί παλαιές αναπαραστάσεις πεδίου και έχει πιο περιορισμένη συμβατότητα. Τα πεδία αριθμού διαφάνειας και οι προορισμένες ημερομηνίες/ώρες έχουν παλαιές αναπαραστάσεις. Μη υποστηριζόμενα προσαρμοσμένα πεδία ή πεδία κεφαλίδας σε συνηθισμένο πλαίσιο κειμένου διαφάνειας μπορεί να εμφανίσουν `*` ως κείμενο. Μην βασίζεστε σε προσαρμοσμένα πεδία ή σε μη υποστηριζόμενα περιβάλλοντα πεδίου να διατηρούν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και ορίστε ρητά την τιμή που θέλετε πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή-στόχο όταν η δική της επαναϋπολογισμός πεδίων αποτελεί μέρος της ροής εργασίας.

## **ΣΥ.Ρ.Ε.**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Επιθεωρήστε το [IPortion::get_Field](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/get_field/). Μια μη‑μηδενική τιμή αναγνωρίζει ένα πεδίο· το εμφανιζόμενο κείμενο μόνο του δεν μπορεί να το διαγνώσει.

**Αφαιρεί η αφαίρεση πεδίου το κείμενο ή τη μορφοποιήσή του;**

Όχι. Το [RemoveField](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/removefield/) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Ορίστε μια ρητή τιμή μετά εάν χρειάζεστε μια συγκεκριμένη παγωμένη ημερομηνία ή εφεδρική τιμή.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**

Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος αναγνωριστικός δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας. Χρησιμοποιήστε έναν υποστηριζόμενο προορισμένο τύπο ή μορφοποιήστε την τιμή εσείς ως συνηθισμένο κείμενο.

**Γιατί πρέπει να ελέγξω ξανά την παρουσίαση μετά την αποθήκευση;**

Οι αναγνωριστικοί πεδίου, το κείμενο που υπολογίζεται και η μορφοποίηση είναι ξεχωριστά στοιχεία που πρέπει να επαληθευτούν. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν ο αναγνωριστικός πεδίου παραμένει.