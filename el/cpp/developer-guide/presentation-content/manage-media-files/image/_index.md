---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις με C++
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/cpp/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το διαδίκτυο
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- EMF
- SVG
- C++
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και στο OpenDocument με το Aspose.Slides για C++, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες καθιστούν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες από αρχείο, το διαδίκτυο ή άλλες τοποθεσίες στις διαφάνειες. Αναλόγως, το Aspose.Slides σας επιτρέπει να προσθέτετε εικόνες στις διαφάνειες των παρουσιάσεών σας μέσω διαφόρων διαδικασιών. 

{{% alert title="Tip" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν γρήγορα παρουσιάσεις από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου—ιδιαίτερα εάν σκοπεύετε να χρησιμοποιήσετε τις τυπικές επιλογές μορφοποίησης για να αλλάξετε το μέγεθός της, να προσθέσετε εφέ κ.λπ.—δείτε το [Picture Frame](/slides/el/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Μπορείτε να χειριστείτε ενέργειες εισόδου/εξόδου που αφορούν εικόνες και παρουσιάσεις PowerPoint ώστε να μετατρέψετε μια εικόνα από μία μορφή σε άλλη. Δείτε αυτές τις σελίδες: μετατρέψτε [image to JPG](https://products.aspose.com/slides/el/cpp/conversion/image-to-jpg/); μετατρέψτε [JPG to image](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-image/); μετατρέψτε [JPG to PNG](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-png/), μετατρέψτε [PNG to JPG](https://products.aspose.com/slides/el/cpp/conversion/png-to-jpg/); μετατρέψτε [PNG to SVG](https://products.aspose.com/slides/el/cpp/conversion/png-to-svg/), μετατρέψτε [SVG to PNG](https://products.aspose.com/slides/el/cpp/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, GIF και άλλες. 

## **Προσθήκη Εικόνων που Αποθηκεύονται Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέτετε μία ή πολλές εικόνες από τον υπολογιστή σας σε μια διαφάνεια σε μια παρουσίαση. Αυτό το δείγμα κώδικα σε C++ δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Προσθήκη Εικόνων από το Διαδίκτυο στις Διαφάνειες**

Εάν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο. 

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια σε C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων σε Master Διαφάνειας**

Ένα master διαφάνειας είναι η κορυφαία διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κ.λπ.) για όλες τις διαφάνειες κάτω από αυτήν. Έτσι, όταν προσθέτετε μια εικόνα σε ένα master διαφάνειας, η εικόνα αυτή εμφανίζεται σε κάθε διαφάνεια που ανήκει σε αυτό το master. 

Αυτό το δείγμα κώδικα σε C++ δείχνει πώς να προσθέσετε μια εικόνα σε ένα master διαφάνειας:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων ως Υπόβαθρο Διαφάνειας**

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως υπόβαθρο για συγκεκριμένη διαφάνεια ή για πολλές διαφάνειες. Σε αυτή την περίπτωση, δείτε *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/el/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε ή να ενσωματώσετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [AddPictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) που ανήκει στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection). 

Για να δημιουργήσετε αντικείμενο εικόνας με βάση μια εικόνα SVG, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε αντικείμενο SvgImage για να το εισάγετε στο ImageShapeCollection  
2. Δημιουργήστε αντικείμενο PPImage από το ISvgImage  
3. Δημιουργήστε αντικείμενο PictureFrame χρησιμοποιώντας τη διεπαφή IPPImage  

Αυτό το δείγμα κώδικα δείχνει πώς να εφαρμόσετε τα παραπάνω βήματα για να προσθέσετε μια εικόνα SVG σε μια παρουσίαση:
``` cpp 
// Η διαδρομή προς τον φάκελο εγγράφων
System::String dataDir = u"D:\\Documents\\";

// Όνομα αρχείου SVG προέλευσης
System::String svgFileName = dataDir + u"sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης
System::String outPptxPath = dataDir + u"presentation.pptx";

// Δημιουργία νέας παρουσίασης
auto p = System::MakeObject<Presentation>();

// Ανάγνωση περιεχομένου αρχείου SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Δημιουργία αντικειμένου SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Δημιουργία αντικειμένου PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Δημιουργεί νέο PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Αποθήκευση παρουσίασης σε μορφή PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργικότητα του PowerPoint που χρησιμοποιείται για τη δουλειά με εικόνες SVG:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργικότητα παρέχεται από μία από τις υπερφορτώσεις της μεθόδου [AddGroupShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) της διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_shape_collection), η οποία δέχεται ως πρώτο όρισμα ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_svg_image). 

Αυτό το δείγμα κώδικα δείχνει πώς να χρησιμοποιήσετε τη περιγραφείσα μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

``` cpp 
// Η διαδρομή προς τον φάκελο εγγράφων
System::String dataDir = u"D:\\Documents\\";

// Όνομα αρχείου SVG προέλευσης
System::String svgFileName = dataDir + u"sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης
System::String outPptxPath = dataDir + u"presentation.pptx";

// Δημιουργία νέας παρουσίασης
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Ανάγνωση περιεχομένου αρχείου SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Δημιουργία αντικειμένου SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Λήψη μεγέθους διαφάνειας
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Μετατροπή εικόνας SVG σε ομάδα σχημάτων κλιμακώνοντάς την στο μέγεθος της διαφάνειας
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Αποθήκευση παρουσίασης σε μορφή PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**

Το Aspose.Slides για C++ σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα Excel και να προσθέσετε τις εικόνες ως EMF στις διαφάνειες με το Aspose.Cells. 

Αυτό το δείγμα κώδικα δείχνει πώς να εκτελέσετε την περιγραφείσα εργασία:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Αποθήκευση του βιβλίου εργασίας σε ροή
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφάνειας). Αυτή η ενότητα δείχνει διάφορες προσεγγίσεις για την ενημέρωση των εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για την αντικατάσταση μιας εικόνας χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) ή μια άλλη εικόνα που υπάρχει ήδη στη συλλογή.  

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).  
2. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.  
3. Αντικαταστήστε την εικόνα‑στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.  
4. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και αντικαταστήστε την εικόνα‑στόχο με αυτό το αντικείμενο.  
5. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα‑στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

```cpp
// Δημιουργεί μια παρουσίαση με την κλάση Presentation που αντιπροσωπεύει αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ο πρώτος τρόπος.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Ο δεύτερος τρόπος.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Ο τρίτος τρόπος.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Χρησιμοποιώντας το δωρεάν μετατροπέα Aspose FREE [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) μπορείτε εύκολα να δημιουργήσετε κινούμενα κείμενα, GIF από κείμενα κ.λπ. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Παραμένει η αρχική ανάλυση της εικόνας μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [picture](/slides/el/cpp/picture-frame/) κλιμακώνεται στη διαφάνεια και από τυχόν συμπίεση κατά την αποθήκευση.  

**Ποιος είναι ο βέλτιστος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στο master slide ή σε ένα layout και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης — οι ενημερώσεις θα εξαπλωθούν σε όλα τα στοιχεία που το χρησιμοποιούν.  

**Μπορεί ένα ενσωματωμένο SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε μια ομάδα σχημάτων, μετά από τα οποία τα επιμέρους μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.  

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

[Ορίστε την εικόνα ως φόντο](/slides/el/cpp/presentation-background/) στο master slide ή στο αντίστοιχο layout — όλες οι διαφάνειες που χρησιμοποιούν αυτό το master/layout θα κληρονομούν το φόντο.  

**Πώς μπορώ να αποτρέψω την παρουσίαση από το «φούσκωμα» του μεγέθους λόγω πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και διατηρήστε τα επαναλαμβανόμενα γραφικά στο master όπου είναι κατάλληλο.