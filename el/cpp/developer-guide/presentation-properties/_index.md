---
title: Διαχείριση ιδιοτήτων παρουσίασης σε C++
linktitle: Ιδιότητες παρουσίασης
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
- Γλώσσα διορθωτικής ανασκόπησης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- C++
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για C++ και βελτιστοποιήστε την αναζήτηση, τη δημιουργία εμπορικού σήματος και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Introduction**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι αυτών των ιδιοτήτων μπορούν να προσπελαστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_document_properties). Μια παρουσία αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_documentproperties/) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}

Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές στα πεδία **Application** και **Producer**, επειδή θα εμφανίζονται τα “Aspose Ltd.” και “Aspose.Slides for C++ x.x.x” σε αυτά τα πεδία.

{{% /alert %}} 

## **Manage Presentation Properties**

Το Microsoft PowerPoint παρέχει μια δυνατότητα για την προσθήκη ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση ορισμένων χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- Ιδιότητες Ορισμένες από το Σύστημα (Built-in)
- Ιδιότητες Ορισμένες από το Χρήστη (Custom)

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, τα στατιστικά του εγγράφου κλπ. Οι **Custom** ιδιότητες είναι αυτές που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides για C++, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στο **Properties Dialog**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General, Summary, Statistics, Contents και Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών ειδών πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Access Built-in Properties**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο **IDocumentProperties** περιλαμβάνουν: **Creator (Author)**, **Description**, **KeyWords**, **Created** (Ημερομηνία δημιουργίας), **Modified** (Ημερομηνία τροποποίησης), **Printed** (Τελευταία ημερομηνία εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινή χρήση μεταξύ διαφορετικών παραγωγών?), **PresentationFormat**, **Subject** και **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modify Built-in Properties**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβασή τους. Μπορείτε απλώς να εκχωρήσετε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198afeff7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Add Custom Presentation Properties**

Το Aspose.Slides για C++ επίσης επιτρέπει στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές στις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

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

// Ανάκτηση ιδιοτήτων εγγράφου
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

## **Access and Modify Custom Properties**

Το Aspose.Slides για C++ επίσης επιτρέπει στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Set Proofing Language**

Το Aspose.Slides παρέχει την ιδιότητα [LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) (εκτεθειμένη από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/portionformat/)) ώστε να σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

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
// ορίστε το Id μιας γλώσσας διορθωτικού ελέγχου

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Set Default Language**

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

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

// Προσθέτει ένα νέο σχήμα ορθογώνιου με κείμενο
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Ελέγχει τη γλώσσα του πρώτου τμήματος
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live Example**

Δοκιμάστε την διαδικτυακή εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **FAQ**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε ως κενές, εφόσον αυτό επιτρέπεται από τη συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν απαιτείται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) και κατόπιν το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσία [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/cpp/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.