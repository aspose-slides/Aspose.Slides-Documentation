---
title: "Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε C++"
linktitle: "Πληροφορίες Παρουσίασης"
type: docs
weight: 30
url: /el/cpp/examine-presentation/
keywords:
- "μορφή παρουσίασης"
- "ιδιότητες παρουσίασης"
- "ιδιότητες εγγράφου"
- "λήψη ιδιοτήτων"
- "ανάγνωση ιδιοτήτων"
- "αλλαγή ιδιοτήτων"
- "τροποποίηση ιδιοτήτων"
- "ενημέρωση ιδιοτήτων"
- "εξέταση PPTX"
- "εξέταση PPT"
- "εξέταση ODP"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας C++ για ταχύτερη κατανόηση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναγνωρίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένου παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να ελέγξετε τις ιδιότητες πριν αποφασίσετε εάν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/) και του [IPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [IDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Εάν έχετε ήδη μια φορτωμένη παρουσίαση, δείτε το [Determine the Original Presentation Format](/slides/el/cpp/detect-presentation-source-format/) για ανίχνευση μετά τη φόρτωση και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) . Η μέθοδος [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_loadformat/) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Δημιουργία Ελαφρού Καταλόγου Παρουσιάσεων**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειάζεστε ένα συμπαγές απόθεμα για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) για να λάβετε ένα αντικείμενο [IPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/) και, στη συνέχεια, καλέστε το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) ούτε απαιτεί την περιήγηση στο πλήρες μοντέλο αντικειμένου παρουσίασης.

Οι επεκτακές ιδιότητες που εκτίθενται από το [IDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/) παρέχουν τις ακόλουθες τιμές καταλόγου:

| Μέθοδος | Τιμή αποθέματος |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_slides/) | Συνολικός αριθμός διαφανειών. |
| [get_HiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Αριθμός κρυφών διαφανειών. |
| [get_Notes](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_notes/) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [get_Paragraphs](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμες. |
| [get_Words](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_words/) | Συνολικός αριθμός λέξεων. |
| [get_MultimediaClips](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Συνδυάζει επίσης το [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_headingpairs/) με το [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) για την εμφάνιση ομάδων περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Κάθε [IHeadingPair](https://reference.aspose.com/slides/el/cpp/aspose.slides/iheadingpair/) παρέχει ένα όνομα ομάδας μέσω του [IHeadingPair::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/iheadingpair/get_name/) και τον αριθμό των στοιχείων στην ομάδα μέσω του [IHeadingPair::get_Count](https://reference.aspose.com/slides/el/cpp/aspose.slides/iheadingpair/get_count/). Το [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) επιστρέφει έναν επίπεδο, διατεταγμένο πίνακα, οπότε καταναλώστε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένου παρουσίασης για να επαναϋπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αντιπροσωπεύονται από προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι ξεπερασμένες εάν η εφαρμογή που αποθήκευσε το αρχείο τελευταία δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκταμένες ιδιότητες εγγράφου για τον αριθμό διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και για ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν είχε ενημερωθεί από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίζει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμό σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε εκτεταμένη ιδιότητα ειδική για το PowerPoint. Οι μεταδεδομένες ιδιότητες κρυφών διαφανειών, σημειώσεων, πολυμέσων, ζεύγων επικεφαλίδων και τίτλων τμημάτων ενδέχεται να μην είναι διαθέσιμες, και οι ιδιότητες καταλόγου μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρήσετε μηδενική τιμή ή κενό πίνακα ως αποδεδειγμένη απόδειξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθέματα και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ενεργό μοντέλο αντικειμένου όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία μιας παρουσίασης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) και, στη συνέχεια, γράψτε την δεσμευμένη παρουσίαση με το [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου.

![Original document properties of the PowerPoint presentation](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ημερομηνία τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Η παρακάτω εικόνα δείχνει τις ενημερωμένες ιδιότητες του εγγράφου.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Password-Protect Presentations](/slides/el/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/cpp/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation::get_FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_fontsmanager/). Καλέστε το [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getembeddedfonts/) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager::GetFonts](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getfonts/) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) μέσω του [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) και του [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι ξεπερασμένα· σε αυτήν την περίπτωση, περιηγηθείτε στις [Presentation::get_Slides](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slides/) και ελέγξτε τη μέθοδο [Slide::get_Hidden](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/get_hidden/) για κάθε διαφάνεια.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και διαβάστε το [Presentation::get_SlideSize](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slidesize/). Ελέγξτε τα [ISlideSize::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/get_size/) και [ISlideSize::get_Orientation](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/get_orientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προεπιλεγμένες τιμές.

**Υπάρχει γρήγορος τρόπος να δω αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/) και ελέγξτε το [ChartData::get_DataSourceType](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Για εξωτερικό βιβλίο εργασίας, διαβάστε το [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Ο τύπος πηγής δεδομένων και η διαδρομή υποδεικνύουν εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μοναδική ιδιότητα πολυπλοκότητας. Περιηγηθείτε στις [Presentation::get_Slides](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slides/) και στη συλλογή [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_shapes/) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό των σχήματων και την παρουσία μεγάλων εικόνων, εφέ, κινήσεων ή πολυμέσων ως δείκτες, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης.