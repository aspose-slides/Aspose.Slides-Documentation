---
title: Διαχείριση OLE σε Παρουσιάσεις με C++
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/cpp/manage-ole/
keywords:
- αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- πρόσθεση OLE
- ενσωμάτωση OLE
- πρόσθεση αντικειμένου
- ενσωμάτωση αντικειμένου
- πρόσθεση αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεδεμένο αρχείο
- αλλαγή OLE
- εικονίδιο OLE
- τίτλος OLE
- εξαγωγή OLE
- εξαγωγή αντικειμένου
- εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και στα αρχεία OpenDocument με το Aspose.Slides για C++. Ενσωματώστε, ενημερώστε και εξαγάγετε περιεχόμενο OLE αδιάσπαστα."
---
## **Introduction**

{{% alert title="Πληροφορίες" color="info" %}}
OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και στα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης.
{{% /alert %}} 

Σκεφτείτε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια μέσα σε μια διαφάνεια του PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην αντίστοιχη εφαρμογή του (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του γραφήματος και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/el/cpp/) σας επιτρέπει να εισάγετε OLE Objects στις διαφάνειες ως πλαίσια αντικειμένου OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/)).

## **Προσθήκη πλαισίων αντικειμένου OLE στις διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for C++, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.  
3. Διαβάστε το αρχείο Excel ως πίνακα bytes.  
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) στη διαφάνεια, περιέχοντας τον πίνακα bytes και άλλες πληροφορίες για το αντικείμενο OLE.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) χρησιμοποιώντας το Aspose.Slides for C++.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) δέχει ως δεύτερο παράμετρο μια επέκταση ενσωματωμένου αντικειμένου. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Προετοιμάστε τα δεδομένα για το αντικείμενο OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένου OLE**

Το Aspose.Slides for C++ σας επιτρέπει να προσθέσετε ένα [OleObjectFrame] χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο στο αρχείο.

Αυτός ο κώδικας C++ εμφανίζει πώς να προσθέσετε ένα [OleObjectFrame] με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Πρόσβαση σε πλαίσια αντικειμένου OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.  
3. Προσπελάστε το σχήμα [OleObjectFrame]. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* (μετατράψαμε) αυτό το αντικείμενο ως [IOleObjectFrame]. Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.  
4. Μόλις πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση στις ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας C++ δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ελέγξτε εάν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame->get_IsObjectLink())
    {
        // Εκτυπώστε τη πλήρη διαδρομή προς το συνδεδεμένο αρχείο.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Εκτυπώστε τη σχετική διαδρομή προς το συνδεδεμένο αρχείο αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="primary" %}} 
Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με τον εξής τρόπο:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).  
2. Αποκτήστε τη αναφορά της διαφάνειας μέσω του δείκτη της.  
3. Προσπελάστε το σχήμα [OLEObjectFrame]. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* (μετατράψαμε) αυτό το αντικείμενο ως [IOleObjectFrame]. Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.  
4. Μόλις πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.  
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.  
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.  
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ένα stream.  
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από το stream.  

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προσπελάζεται και τα δεδομένα του αρχείου τροποποιούνται για να ενημερωθούν τα δεδομένα του γραφήματος.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Αναγνώστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Τροποποιήστε τα δεδομένα του workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ενσωμάτωση άλλων τύπων αρχείων στις διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides for C++ σας επιτρέπει να ενσωματώνετε άλλους τύπους αρχείων στις διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο ενσωματωμένο αντικείμενο, ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμά του.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά την εργασία με παρουσιάσεις, ίσως χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for C++ σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Αλλάξτε τον τύπο αρχείου σε ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός εικόνων εικονιδίου και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for C++.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αποτροπή αλλαγής μεγέθους και επανατοποθέτησης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που ζητά να ενημερώσετε τις συνδέσεις. Κάνοντας κλικ στο κουμπί "Update Links" (Ενημέρωση Συνδέσεων) μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `set_UpdateAutomatic` της διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) σε `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Το Aspose.Slides for C++ σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα στις διαφάνειες ως αντικείμενα OLE ως εξής:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) που περιέχει τα αντικείμενα OLE που επιθυμείτε να εξάγετε.  
2. Διέλθετε όλες τις μορφές στην παρουσίαση και προσπελάστε τις μορφές [OLEObjectFrame].  
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένου OLE και γράψτε τα στο δίσκο.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Θα αποδίδεται το περιεχόμενο OLE κατά τη� εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικόνα αντικατάστασης (προεπισκόπηση). Το "ζωντανό" περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να διασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην το μετακινούν/επεξεργάζονται στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/cpp/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel "πηδά" ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/cpp/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε ένα σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα αντικατάστασης.

**Θα διατηρηθούν οι σχετικοί δρόμοι (paths) για τα συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, δεν διατίθεται πληροφορία «σχετικό μονοπάτι»—μόνο το πλήρες μονοπάτι. Τα σχετικά μονοπάτια υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστα απόλυτα μονοπάτια/προσβάσιμα URIs ή ενσωμάτωση.