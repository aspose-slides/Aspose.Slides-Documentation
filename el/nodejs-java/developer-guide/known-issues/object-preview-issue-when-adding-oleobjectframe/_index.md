---
title: Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο άλλαξε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προσθέτετε OleObjectFrame στο Aspose.Slides για Node.js και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides for Java, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα "EMBEDDED OLE OBJECT" στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη εργασία με αντικείμενα OLE, δείτε το [Manage OLE](/slides/el/nodejs-java/manage-ole/).

## **Εξήγηση και λύση**

Το Aspose.Slides εμφανίζει το μήνυμα "EMBEDDED OLE OBJECT" για να σας ενημερώσει ότι το αντικείμενο OLE έχει αλλάξει και ότι η εικόνα προεπισκόπησης πρέπει να ενημερωθεί.

Για παράδειγμα, αν προσθέσετε ένα γράφημα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο "Manage OLE") και έπειτα ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα "EMBEDDED OLE OBJECT", ή μπορείτε να κάνετε δεξί κλικ πάνω του και να επιλέξετε την επιλογή **Αντικείμενο > Επεξεργασία**.

![Αντικείμενο > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint τότε ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια ενδέχεται να διατηρεί το μήνυμα "EMBEDDED OLE OBJECT". Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα "EMBEDDED OLE OBJECT" αντικαθίσταται με την πραγματική εικόνα του αντικειμένου OLE.

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θελήσετε να αποθηκεύσετε την παρουσίασή σας ώστε να εξασφαλίσετε ότι η εικόνα για το αντικείμενο OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα "EMBEDDED OLE OBJECT".

## **Άλλες λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος "Embedded OLE Object" με εικόνα**

Αν δεν θέλετε να αφαιρέσετε το μήνυμα "EMBEDDED OLE OBJECT" ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση αντικειμένου OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` μεταβάλλεται σε αυτήν:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που θα ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.