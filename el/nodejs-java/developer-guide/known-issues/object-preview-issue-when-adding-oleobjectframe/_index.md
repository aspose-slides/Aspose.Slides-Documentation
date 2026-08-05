---
title: Πρόβλημα προεπισκόπησης αντικειμένου όταν προστίθεται OleObjectFrame
linktitle: Πρόβλημα OLE αντικειμένου
type: docs
weight: 10
url: /el/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αλλαγμένο αντικείμενο
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προστίθεται OleObjectFrame στο Aspose.Slides για Node.js και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για Java, όταν προσθέτετε [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι εκ προθέσεως και ΔΕΝ είναι σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη δουλειά με αντικείμενα OLE, δείτε [Διαχείριση OLE](/slides/el/nodejs-java/manage-ole/). 

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ενημερώσει ότι το αντικείμενο OLE έχει αλλάξει και η προεπισκόπηση εικόνας πρέπει να ενημερωθεί. 

Για παράδειγμα, εάν προσθέσετε ένα διάγραμμα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Διαχείριση OLE») και, στη συνέχεια, ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Εάν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή μπορείτε να κάνετε δεξί κλικ πάνω του και να επιλέξετε **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

Το PowerPoint στη συνέχεια ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρήσει το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE. 

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θελήσετε να αποθηκεύσετε την παρουσίαση για να εξασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν ξανά την ανοίξετε, ΔΕΝ θα δείτε το μήνυμα «EMBEDDED OLE OBJECT». 

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος «Embedded OLE Object» με εικόνα**

Εάν δεν θέλετε να καταργήσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Αυτές οι γραμμές κώδικα δείχνουν τη διαδικασία:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Προσθήκη εικόνας στους πόρους της παρουσίασης.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Ορισμός τίτλου και εικόνας για την προεπισκόπηση του αντικειμένου OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για το PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.