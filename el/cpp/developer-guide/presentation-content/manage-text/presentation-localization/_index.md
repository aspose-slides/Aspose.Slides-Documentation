---
title: Αυτοματοποίηση της Τοπικοποίησης Παρουσίασης σε C++
linktitle: Τοπικοποίηση Παρουσίασης
type: docs
weight: 100
url: /el/cpp/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- καταστολή ορθογραφικού ελέγχου
- γλώσσα ελέγχου
- αναγνωριστικό γλώσσας
- πολυγλωσσικό κείμενο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ορίστε τις γλώσσες ελέγχου για το κείμενο παρουσιάσεων PowerPoint και OpenDocument σε C++ με το Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολυγλωσσικών παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ σάς επιτρέπει να διαμορφώσετε μεταδεδομένα ελέγχου για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_languageid/) για να καθορίσετε τη γλώσσα ελέγχου, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_spellcheck/) για να επιτρέψετε ή να καταστείλετε τον ορθογραφικό έλεγχο, και [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_proofdisabled/) για να ελέγξετε την ευρύτερη κατάσταση «μη απόδειξης». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μια παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες ελέγχου.

Αυτό το άρθρο εξηγεί πώς να αντιστοιχίσετε γλώσσα σε συγκεκριμένο κείμενο, να ορίσετε τη προεπιλεγμένη γλώσσα για νέο κείμενο με [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), να δημιουργήσετε πολυγλωσσικές παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled`, και να διατηρήσετε τις επιθυμητές ρυθμίσεις όταν χρησιμοποιείτε [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν ορθογραφικό έλεγχο με λεξικό, ούτε επιστρέφουν εσφαλμένες λέξεις.

## **Ορισμός της γλώσσας ελέγχου για το κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), αποκτήστε πρόσβαση στο απαιτούμενο τμήμα κειμένου μέσω [IPortion::get_PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/get_portionformat/), και ορίστε τον αναγνωριστικό γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει την βρετανική αγγλική ως γλώσσα ελέγχου και αποθηκεύει το αποτέλεσμα με [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός της προεπιλεγμένης γλώσσας για νέο κείμενο**

Χρησιμοποιήστε [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) για να καθορίσετε τη γλώσσα ελέγχου που θα αναθέτει το Aspose.Slides στο κείμενο που δημιουργείται νέο. Αυτή η ρύθμιση είναι χρήσιμη όταν το μεγαλύτερο ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας του κειμένου που ήδη έχει ρητή γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο ακολουθεί κανόνες γερμανικού ελέγχου:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Χρήση πολλαπλών γλωσσών σε μία παράγραφο**

Ένα [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) περιέχει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ένα ξεχωριστό [Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides/portion/) για κάθε γλώσσα και ορίστε ανεξάρτητα το `LanguageId`.

Αυτό το παράδειγμα δημιουργεί μια παράγραφο με τμήματα αγγλικών και γαλλικών:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ενεργοποίηση ή καταστολή του ορθογραφικού ελέγχου για μεμονωμένα τμήματα**

Το [IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από το [IBasePortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/). Αποκτήστε τη μορφοποίηση ενός τμήματος μέσω [IPortion::get_PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/get_portionformat/) και καλέστε [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_spellcheck/) για να ελέγξετε αν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλογή είναι `false`: το `true` επιτρέπει τον έλεγχο, ενώ το `false` τον καταστέλλει.

Η ρύθμιση εφαρμόζεται σε μεμονωμένα τμήματα κειμένου. Έτσι, διαφορετικά τμήματα στην ίδια παράγραφο μπορούν να έχουν διαφορετικές τιμές. Τα [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) και `SpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `LanguageId` προσδιορίζει τη γλώσσα ελέγχου, ενώ το `SpellCheck` καθορίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για το τμήμα.

Το [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_proofdisabled/) ελέγχει επίσης τον έλεγχο, αλλά αντιπροσωπεύει την ευρύτερη κατάσταση «μη απόδειξης» ως [NullableBool](https://reference.aspose.com/slides/el/cpp/aspose.slides/nullablebool/). Χρησιμοποιήστε `SpellCheck` όταν χρειάζεστε έναν άμεσο Boolean διακόπτη ειδικά για ορθογραφικούς ελέγχους. Χρησιμοποιήστε `ProofDisabled` όταν θέλετε να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη απόδειξης» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NullableBool::NotDefined`. Εάν ορίσετε και τις δύο ιδιότητες, κρατήστε τις τιμές τους συμβατές· μην συνδυάσετε `SpellCheck = true` με `ProofDisabled = NullableBool::True`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα ελέγχου που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση λεξικοβάσιστου ορθογραφικού ελέγχου ή για επιστροφή λίστας εσφαλμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια είσοδο παρουσίασης, τη φορτώνει, αναθέτει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες ελέγχου σε δύο τμήματα στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ανοίγει ξανά και επαληθεύει τις αποθηκευμένες τιμές:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/joinportionswithsameformatting/) συνδυάζει γειτονικά τμήματα που έχουν την ίδια μορφοποίηση. Μια διαφορά μόνο στο `SpellCheck` δεν κρατά τα τμήματα χωριστά· μετά το συνδυασμό, το προκύπτον τμήμα διατηρεί την τιμή `SpellCheck` του πρώτου τμήματος. Αν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου, καλέστε `JoinPortionsWithSameFormatting` πριν ορίσετε αυτές τις ρυθμίσεις, ή ελέγξτε τα όρια του προκύπτοντoυ τμήματος και επαναφαρμόστε τις ρυθμίσεις μετά. Τμήματα με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστά επειδή η μορφοποίηση γλώσσας ελέγχου διαφέρει.

## **Συχνές ερωτήσεις**

**Μεταφράζει το κείμενο ένας αναγνωριστικός κώδικας γλώσσας;**

Όχι. Το [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_languageid/) αποθηκεύει μεταδεδομένα ελέγχου για ορθογραφία και γραμματική· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε τον κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ο έλεγχος γλώσσας ελέγχει γραμματοσειρές, συλλαβισμό ή αναδίπλωση γραμμής;**

Όχι. Ο αναγνωριστικός κώδικας αφορά μόνο τον έλεγχο. Η απόδοση του κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/cpp/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, διαμορφώστε την [font substitution](/slides/el/cpp/font-substitution/), ή [embed fonts](/slides/el/cpp/embedded-font/) στην παρουσίαση.

**Μπορεί μια παράγραφος να χρησιμοποιεί πολλές γλώσσες ελέγχου;**

Ναι. Αντιστοιχίστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως δείχνει το παράδειγμα πολυγλωσσικής παραγράφου.

**Να χρησιμοποιήσω `DefaultTextLanguage` ή `LanguageId`;**

Χρησιμοποιήστε [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) όταν θέλετε μια προεπιλογή για το κείμενο που δημιουργείται νέο. Χρησιμοποιήστε [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_languageid/) όταν ένα συγκεκριμένο τμήμα χρειάζεται ρητή γλώσσα ελέγχου ή όταν μια παράγραφη περιέχει πολλαπλές γλώσσες.