---
title: Edit PDF Documents in C++
linktitle: Edit PDF
type: docs
weight: 65
url: /el/cpp/edit-pdf/
keywords:
- επεξεργασία PDF
- αντικατάσταση κειμένου PDF
- PDF σε PPTX
- PPTX σε PDF
- C++
- Aspose.Slides
description: "Επεξεργαστείτε έγγραφα PDF σε C++ εισάγοντάς τα στο Aspose.Slides, αντικαθιστώντας το κείμενο και αποθηκεύοντας την τροποποιημένη παρουσίαση πίσω σε PDF."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ σάς επιτρέπει να επεξεργάζεστε το περιεχόμενο PDF εισάγοντας τις σελίδες του ως διαφάνειες, τροποποιώντας την παρουσίαση και εξάγοντας την ξανά σε PDF. Αυτό το άρθρο δείχνει μια απλή αντικατάσταση κειμένου. Η παρουσίαση παραμένει στη μνήμη, έτσι η αποθήκευση ενδιάμεσου αρχείου PPTX είναι προαιρετική.

## **Αντικατάσταση κειμένου σε PDF**

Χρησιμοποιήστε [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/addfrompdf/) για να εισάγετε τις σελίδες, [Presentation::ReplaceText](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/replacetext/) για να ενημερώσετε το κείμενο, και [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να εξάγετε το αποτέλεσμα.

Το παρακάτω παράδειγμα αναμένει ότι το `input.pdf` περιέχει τη λέξη "Draft" ως επεξεργάσιμο κείμενο μετά την εισαγωγή. Η λέξη αυτή αντικαθίσταται με "Final" και γράφεται στο `edited.pdf`. Η εκκαθάριση της αρχικής διαφάνειας πριν από την εισαγωγή αποτρέπει μια επιπλέον κενή σελίδα στο αποτέλεσμα. Η αναζήτηση ταιριάζει σε ολόκληρες λέξεις με το ίδιο πεζό/κεφαλαίο σχήμα· `nullptr` σημαίνει ότι δεν απαιτείται κλήση επιστροφής αποτελεσμάτων.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Για περισσότερες επιλογές, δείτε [Αναζήτηση και αντικατάσταση κειμένου](/slides/el/cpp/search-and-replace-text/) και [Μετατροπή PowerPoint σε PDF](/slides/el/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Σημείωση" %}}
Η αντικατάσταση κειμένου λειτουργεί σε εισαγόμενο κείμενο, όχι σε κείμενο μέσα σε σαρωμένες εικόνες. Η μετατροπή μπορεί να επηρεάσει τη διάταξη και τη μορφοποίηση, οπότε ελέγξτε το αποτέλεσμα, ειδικά όταν το κείμενο αντικατάστασης είναι μεγαλύτερο από το αρχικό.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Πρέπει να αποθηκεύσω αρχείο PPTX πριν εξάγω το PDF;**

Όχι. Μπορείτε να επεξεργαστείτε και να εξάγετε την ίδια παρουσίαση στη μνήμη. Αποθηκεύστε ένα αντίγραφο PPTX μόνο αν θέλετε επίσης να συνεχίσετε την επεξεργασία του στο PowerPoint· δείτε [Save Presentations](/slides/el/cpp/save-presentation/).

**Γιατί μπορεί κάποιο κείμενο να παραμείνει αμετάβλητο;**

Το παράδειγμα ταιριάζει ολόκληρη τη λέξη "Draft" με ακριβές πεζό/κεφαλαίο. Κείμενο που εισάγεται ως εικόνα ή χωρίζεται σε ξεχωριστά πλαίσια κειμένου δεν θα ταιριάζει απαραίτητα με την αναζήτηση. Ελέγξτε το εισαγόμενο περιεχόμενο και προσαρμόστε την αναζήτηση για το έγγραφό σας.