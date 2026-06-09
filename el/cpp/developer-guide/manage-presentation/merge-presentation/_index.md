---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε C++
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/cpp/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- C++
- Aspose.Slides
description: "Χωρίς κόπο συγχωνεύστε παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP) με το Aspose.Slides για C++, βελτιώνοντας τη ροή εργασίας σας."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να συγχωνεύετε παρουσιάσεις κλωνοποιώντας διαφάνειες από μία παρουσίαση σε άλλη. Αυτό το άρθρο εξηγεί πώς να συγχωνεύσετε ολόκληρες παρουσιάσεις ή επιλεγμένες διαφάνειες, να χρησιμοποιήσετε κύριο πρότυπο διαφάνειας ή συγκεκριμένη διάταξη κατά τη συγχώνευση, να αντιμετωπίσετε παρουσιάσεις με διαφορετικά μεγέθη διαφανειών και να προσθέσετε τις συγχωνευμένες διαφάνειες σε ενότητα παρουσίασης. Περιλαμβάνει επίσης πρακτικές σημειώσεις σχετικά με το συγχωνευμένο περιεχόμενο, όπως σημειώσεις ομιλητή, σχόλια, αρχεία πηγής με κωδικό πρόσβασης και χρήση νημάτων.

## **Συγχώνευση Παρουσιάσεων**

Όταν συγχωνεύετε μία παρουσίαση σε άλλη, συνδυάζετε ουσιαστικά τις διαφάνειές τους σε μία παρουσίαση για να αποκτήσετε ένα αρχείο.

{{% alert title="Πληροφορίες" color="info" %}}

Οι περισσότερες προγράμματα παρουσίασης (PowerPoint ή OpenOffice) δεν διαθέτουν λειτουργίες που επιτρέπουν στους χρήστες να συνδυάζουν παρουσιάσεις με αυτόν τον τρόπο.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/el/cpp/), όμως, επιτρέπει τη συγχώνευση παρουσιάσεων με διάφορους τρόπους. Μπορείτε να συγχωνεύσετε παρουσιάσεις με όλα τα σχήματα, τα στυλ, τα κείμενα, τη μορφοποίηση, τα σχόλια, τις κινήσεις κ.λπ. χωρίς να ανησυχείτε για απώλεια ποιότητας ή δεδομένων.

**Δείτε επίσης**

[Clone Slides](https://docs.aspose.com/slides/el/cpp/clone-slides/)*.*

{{% /alert %}}

### **Τι Μπορεί να Συγχωνευτεί**

Με την Aspose.Slides, μπορείτε να συγχωνεύσετε

* ολόκληρες παρουσιάσεις. Όλες οι διαφάνειες από τις παρουσιάσεις καταλήγουν σε μία παρουσίαση
* συγκεκριμένες διαφάνειες. Οι επιλεγμένες διαφάνειες καταλήγουν σε μία παρουσίαση
* παρουσιάσεις σε μία μορφή (PPT σε PPT, PPTX σε PPTX, κλπ.) και σε διαφορετικές μορφές (PPT σε PPTX, PPTX σε ODP, κλπ.) μεταξύ τους.

{{% alert title="Σημείωση" color="warning" %}}

Εκτός από παρουσιάσεις, η Aspose.Slides επιτρέπει τη συγχώνευση άλλων αρχείων:

* [Images](https://products.aspose.com/slides/el/cpp/merger/image-to-image/), όπως [JPG to JPG](https://products.aspose.com/slides/el/cpp/merger/jpg-to-jpg/) ή [PNG to PNG](https://products.aspose.com/slides/el/cpp/merger/png-to-png/)
* Documents, όπως [PDF to PDF](https://products.aspose.com/slides/el/cpp/merger/pdf-to-pdf/) ή [HTML to HTML](https://products.aspose.com/slides/el/cpp/merger/html-to-html/)
* Και δύο διαφορετικά αρχεία όπως [image to PDF](https://products.aspose.com/slides/el/cpp/merger/image-to-pdf/) ή [JPG to PDF](https://products.aspose.com/slides/el/cpp/merger/jpg-to-pdf/) ή [TIFF to PDF](https://products.aspose.com/slides/el/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Επιλογές Συγχώνευσης**

Μπορείτε να εφαρμόσετε επιλογές που καθορίζουν αν

* κάθε διαφάνεια στην τελική παρουσίαση διατηρεί ένα μοναδικό στυλ
* ένα συγκεκριμένο στυλ χρησιμοποιείται για όλες τις διαφάνειες στην τελική παρουσίαση.

Για να συγχωνεύσετε παρουσιάσεις, η Aspose.Slides παρέχει μεθόδους [AddClone](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (από το interface [ISlideCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide_collection)). Υπάρχουν αρκετές υλοποιήσεις των μεθόδων `AddClone` που ορίζουν τις παραμέτρους της διαδικασίας συγχώνευσης. Κάθε αντικείμενο Presentation έχει μια συλλογή [Slides](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), έτσι μπορείτε να καλέσετε μια μέθοδο `AddClone` από την παρουσίαση στην οποία θέλετε να συγχωνεύσετε διαφάνειες.

Η μέθοδος `AddClone` επιστρέφει ένα αντικείμενο `ISlide`, το οποίο είναι κλώνος της πηγής. Οι διαφάνειες στην τελική παρουσίαση είναι απλώς αντίγραφα των διαφανειών από την πηγή. Συνεπώς, μπορείτε να κάνετε αλλαγές στις προκύπτουσες διαφάνειες (π.χ. να εφαρμόσετε στυλ, επιλογές μορφοποίησης ή διατάξεις) χωρίς να επηρεαστεί η πηγή.

## **Συγχώνευση Παρουσιάσεων**

Η Aspose.Slides παρέχει τη μέθοδο [**AddClone (ISlide)**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) που επιτρέπει τον συνδυασμό διαφανειών ενώ οι διαφάνειες διατηρούν τις διατάξεις και τα στυλ τους (προεπιλεγμένες παράμετροι).

Αυτός ο κώδικας C++ σας δείχνει πώς να συγχωνεύσετε παρουσιάσεις:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Συγχώνευση Παρουσιάσεων με Κύριο Πρότυπο Διαφάνειας**

Η Aspose.Slides παρέχει τη μέθοδο [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) που επιτρέπει τον συνδυασμό διαφανειών εφαρμόζοντας ένα κύριο πρότυπο παρουσίασης. Με αυτόν τον τρόπο, αν χρειαστεί, μπορείτε να αλλάξετε το στυλ για τις διαφάνειες στην τελική παρουσίαση.

Αυτός ο κώδικας C++ παρουσιάζει τη λειτουργία:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Σημείωση" color="warning" %}}

Η διάταξη διαφάνειας για το κύριο πρότυπο καθορίζεται αυτόματα. Όταν δεν μπορεί να προσδιοριστεί κατάλληλη διάταξη, εάν η λογική παράμετρος `allowCloneMissingLayout` της μεθόδου `AddClone` είναι αληθής, χρησιμοποιείται η διάταξη της πηγής. Διαφορετικά, θα εξαπολυθεί [PptxEditException](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

Εάν θέλετε οι διαφάνειες στην τελική παρουσίαση να έχουν διαφορετική διάταξη, χρησιμοποιήστε τη μέθοδο [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) αντί για την προηγούμενη κατά τη συγχώνευση.

## **Συγχώνευση Συγκεκριμένων Διαφανειών από Παρουσιάσεις**

Η συγχώνευση συγκεκριμένων διαφανειών από πολλαπλές παρουσιάσεις είναι χρήσιμη για τη δημιουργία προσαρμοσμένων δεσμών διαφανειών. Η Aspose.Slides C++ σας επιτρέπει να επιλέξετε και να εισάγετε μόνο τις διαφάνειες που χρειάζεστε. Το API διατηρεί τη μορφοποίηση, τη διάταξη και το σχεδιασμό των αρχικών διαφανειών.

Ο παρακάτω κώδικας C++ δημιουργεί μια νέα παρουσίαση, προσθέτει διαφάνειες τίτλου από δύο άλλες παρουσιάσεις και αποθηκεύει το αποτέλεσμα σε αρχείο:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Συγχώνευση Παρουσιάσεων με Διάταξη Διαφάνειας**

Αυτός ο κώδικας C++ σας δείχνει πώς να συνδυάσετε διαφάνειες από παρουσιάσεις εφαρμόζοντας την επιθυμητή διάταξη διαφάνειας για να παραχθεί μία τελική παρουσίαση:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

{{% alert title="Σημείωση" color="warning" %}}

Δεν μπορείτε να συγχωνεύσετε παρουσιάσεις με διαφορετικά μεγέθη διαφανειών.

{{% /alert %}}

Για να συγχωνεύσετε 2 παρουσιάσεις με διαφορετικά μεγέθη διαφανειών, πρέπει να αλλάξετε το μέγεθος μιας από τις παρουσιάσεις ώστε να ταιριάζει με το μέγεθος της άλλης.

Αυτό το παράδειγμα κώδικα δείχνει τη λειτουργία:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Αυτός ο κώδικας C++ δείχνει πώς να συγχωνεύσετε μια συγκεκριμένη διαφάνεια σε μια ενότητα μιας παρουσίασης:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Η διαφάνεια προστίθεται στο τέλος της ενότητας.

{{% alert title="Συμβουλή" color="primary" %}}

Η Aspose παρέχει μια [FREE Collage web app](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτήν την online υπηρεσία, μπορείτε να συγχωνεύσετε [JPG to JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG εικόνες, να δημιουργήσετε [photo grids](https://products.aspose.app/slides/el/collage/photo-grid) κ.λπ.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι σημειώσεις ομιλητή κατά τη συγχώνευση;**

Ναι. Κατά την κλονοποίηση διαφανειών, η Aspose.Slides μεταφέρει όλα τα στοιχεία της διαφάνειας, συμπεριλαμβανομένων των σημειώσεων, της μορφοποίησης και των κινήσεων.

**Μεταφέρονται τα σχόλια και οι συγγραφείς τους;**

Τα σχόλια, ως μέρος του περιεχομένου της διαφάνειας, αντιγράφονται μαζί με τη διαφάνεια. Οι ετικέτες συγγραφέα σχολίων διατηρούνται ως αντικείμενα σχολίου στην προκύπτουσα παρουσίαση.

**Τι γίνεται αν η πηγή παρουσίασης είναι κωδικοποιημένη με κωδικό πρόσβασης;**

Πρέπει να [ανοίξει με τον κωδικό πρόσβασης](/slides/el/cpp/password-protected-presentation/) μέσω του [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/); μετά τη φόρτωση, αυτές οι διαφάνειες μπορούν να κλωνοποιηθούν με ασφάλεια σε αρχείο προορισμού χωρίς προστασία (ή επίσης με προστασία).

**Πόσο ασφαλής είναι η λειτουργία συγχώνευσης ως προς τα νήματα;**

Μην χρησιμοποιείτε την ίδια [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) παρουσίαση από [πολλαπλά νήματα](/slides/el/cpp/multithreading/). Ο συνιστώμενος κανόνας είναι «ένα έγγραφο — ένα νήμα»· διαφορετικά αρχεία μπορούν να επεξεργαστούν παράλληλα σε ξεχωριστά νήματα.