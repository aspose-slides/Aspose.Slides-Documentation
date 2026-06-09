---
title: Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο τροποποιήθηκε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προστίθεται OleObjectFrame στο Aspose.Slides για C++ και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για C++, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα "EMBEDDED OLE OBJECT" στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη χρήση αντικειμένων OLE, δείτε το [Manage OLE](/slides/el/cpp/manage-ole/).

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα "EMBEDDED OLE OBJECT" για να σας ενημερώσει ότι το αντικείμενο OLE έχει τροποποιηθεί και ότι η εικόνα προεπισκόπησης πρέπει να ενημερωθεί.

Για παράδειγμα, εάν προσθέσετε ένα διάγραμμα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο "Manage OLE") και έπειτα ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE έχει προστεθεί στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα "EMBEDDED OLE OBJECT", ή μπορείτε να κάνετε δεξί κλικ σε αυτό και να ακολουθήσετε την επιλογή **Object > Edit**.

![OLE αντικείμενο > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint, στη συνέχεια, ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρεί το μήνυμα "EMBEDDED OLE OBJECT". Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα "EMBEDDED OLE OBJECT" αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE.

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θέλετε να αποθηκεύσετε την παρουσίασή σας για να εξασφαλίσετε ότι η εικόνα για το αντικείμενο OLE θα ενημερωθεί σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν ξαναανοίξετε την παρουσίαση, ΔΕΝ θα δείτε το μήνυμα "EMBEDDED OLE OBJECT".

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος "Embedded OLE Object" με μια εικόνα**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα "EMBEDDED OLE OBJECT" ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς το, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η διαφάνεια που περιέχει το `OleObjectFrame` στη συνέχεια αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία Add‑On για το PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα add‑on για το Microsoft PowerPoint που θα ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.