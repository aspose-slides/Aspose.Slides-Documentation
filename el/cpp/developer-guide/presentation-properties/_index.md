---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε C++
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/cpp/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ελέγχου ορθογραφίας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides for C++ και βελτιστοποιήστε την αναζήτηση, τη χρήση εταιρικής ταυτότητας και τη ροή εργασιών στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Η Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσεγγιστούν και να διαχειριστούν μέσω του API της Aspose.Slides.

Η Aspose.Slides επιτρέπει την εργασία με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/). Μια παρουσία αυτής της διεπαφής επιστρέφεται από το [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή θα εμφανίζονται τα στοιχεία Aspose Ltd. και Aspose.Slides for C++ x.x.x σε αυτά τα πεδία.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει τη δυνατότητα προσθήκης ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής:

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως τίτλος, όνομα συγγραφέα, στατιστικά εγγράφου κ.ά. Οι **Custom** ιδιότητες είναι αυτές που ορίζουν οι χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας την Aspose.Slides for C++, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Απλώς κάντε κλικ στο εικονίδιο Office και στη συνέχεια στην επιλογή **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στον **Properties Dialog**, μπορείτε να δείτε πολλές καρτέλες όπως **General, Summary, Statistics, Contents and Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη ρύθμιση διαφορετικών ειδών πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται περνώντας `false` στη μέθοδο [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), οι ιδιότητες εγγράφου παραμένουν δημόσιες. Η εφαρμογή μπορεί στη συνέχεια να περάσει `true` στη μέθοδο [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

`set_OnlyLoadDocumentProperties` ελέγχει τι φορτώνει η Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παρακάτω παράδειγμα ελέγχει τη λειτουργία φόρτωσης μέσω του [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω του [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφάνειων δεν φορτώνεται. Διαφάνειες, master, layouts, σχήματα, μέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το `get_IsOnlyDocumentPropertiesLoaded` πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορεί να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε τις ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Κρατήστε τις δημόσιες μόνο όταν συστήματα κατάταξης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση να τις προσπελάσουν χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίας**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά την κλήση `set_OnlyLoadDocumentProperties(true)` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Η Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμένουν σύμφωνες με τα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) για να επιβεβαιώσει ότι η κρυπτογράφηση διατηρείται και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Εάν μια εφαρμογή δεν έχει δικαίωμα να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση Σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο **IDocumentProperties** περιλαμβάνουν: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβαση σε αυτές. Απλώς εκχωρήστε μια συμβολοσειρά στην επιθυμητή ιδιότητα και η τιμή της θα τροποποιηθεί. Στο παρακάτω παράδειγμα δείξαμε πώς μπορεί να τροποποιηθεί η ενσωματωμένη ιδιότητα εγγράφου ενός αρχείου παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Η Aspose.Slides for C++ επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργία αντικειμένου της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();

// Λήψη ιδιοτήτων εγγράφου
auto documentProperties = presentation->get_DocumentProperties();

// Προσθήκη προσαρμοσμένων ιδιοτήτων
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Αφαίρεση επιλεγμένης ιδιότητας
documentProperties->RemoveCustomProperty(getPropertyName);

// Αποθήκευση παρουσίασης
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Η Aspose.Slides for C++ επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Η Aspose.Slides παρέχει την ιδιότητα [LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) (εκτεθειμένη από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/portionformat/)) για να ορίσετε τη γλώσσα ελέγχου ορθογραφίας ενός εγγράφου PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη μια παρουσίαση PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Προσθέτει ένα νέο σχήμα ορθογωνίου με κείμενο
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Ελέγχει τη γλώσσα του πρώτου τμήματος
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) online για να δείτε πώς να εργάζεστε με ιδιότητες εγγράφου μέσω του API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Μπορείτε, ωστόσο, είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς η Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώνω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) και στη συνέχεια το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/cpp/examine-presentation/) για πλήρη παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί περνώντας `false` στη μέθοδο `set_EncryptDocumentProperties` και να έχει φορτωθεί με `true` στη μέθοδο `set_OnlyLoadDocumentProperties`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο‑ιδιοτήτων‑εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί πλήρη φόρτωση της παρουσίασης με τον σωστό κωδικό ανοίγματος.