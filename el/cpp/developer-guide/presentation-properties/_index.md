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
- Γλώσσα ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides για C++ και βελτιστοποιήστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο αυτοί τύποι ιδιοτήτων μπορούν να προσπελαστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_document_properties). Μία παρουσίαση αυτής της διεπαφής επιστρέφεται από τη μέθοδο [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 
Παρακαλούμε σημειώστε ότι δεν μπορείτε να ορίσετε τιμές για τα πεδία **Application** και **Producer**, επειδή θα εμφανίζεται η Aspose Ltd. και το Aspose.Slides for C++ x.x.x σε αυτά τα πεδία.
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint προσφέρει μια λειτουργία για την προσθήκη ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου όπως παρακάτω

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** ιδιότητες περιέχουν γενικές πληροφορίες σχετικά με το έγγραφο όπως ο τίτλος του εγγράφου, το όνομα του συγγραφέα, στατιστικά του εγγράφου κλπ. **Custom** ιδιότητες είναι εκείνες που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου και το όνομα και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for C++, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων. Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007. Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint. Στον **Properties Dialog**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General, Summary, Statistics, Contents and Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη ρύθμιση διαφορετικών ειδών πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Πρόσβαση σε Built-in Properties**

Αυτές οι ιδιότητες, όπως εκτίθενται από το αντικείμενο **IDocumentProperties**, περιλαμβάνουν: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Ημερομηνία Εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινόχρηστο μεταξύ διαφορετικών παραγωγών;), **PresentationFormat**, **Subject** και **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Τροποποίηση Built-in Properties**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβασή τους. Μπορείτε απλώς να αναθέσετε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείξαμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Προσθήκη Custom Presentation Properties**

Το Aspose.Slides for C++ επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

``` cpp
// Δημιουργία αντικειμένου της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();

// Λήψη ιδιοτήτων εγγράφου
auto documentProperties = presentation->get_DocumentProperties();

// Προσθήκη προσαρμοσμένων ιδιοτήτων
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Λήψη ονόματος ιδιότητας σε συγκεκριμένο ευρετήριο
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Αφαίρεση επιλεγμένης ιδιότητας
documentProperties->RemoveCustomProperty(getPropertyName);

// Αποθήκευση παρουσίασης
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Πρόσβαση και Τροποποίηση Custom Properties**

Το Aspose.Slides for C++ επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Set Proofing Language**

Το Aspose.Slides παρέχει την ιδιότητα [LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) (που εκτίθεται από την κλάση [PortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/portionformat/)) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου είναι η γλώσσα για την οποία γίνεται έλεγχος ορθογραφίας και γραμματικής στο PowerPoint.

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// ορίστε το Id μιας γλώσσας ελέγχου

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Set Default Language**

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε την προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live Example**

Δοκιμάστε την διαδικτυακή εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να αφαιρέσω μια built-in ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια custom ιδιότητα που ήδη υπάρχει;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι, μπορείτε να προσπελάσετε τις ιδιότητες της παρουσίασης χωρίς να φορτώσετε πλήρως την παρουσίαση χρησιμοποιώντας τη μέθοδο `GetPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/). Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `ReadDocumentProperties` που παρέχεται από τη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.