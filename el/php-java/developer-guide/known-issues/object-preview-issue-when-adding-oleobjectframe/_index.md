---
title: Πρόβλημα προεπισκόπησης αντικειμένου όταν προστίθεται OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο τροποποιήθηκε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προστίθεται OleObjectFrame στο Aspose.Slides για PHP και πώς να διορθώσετε προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java, όταν προσθέτετε [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται ένα μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη δουλειά με αντικείμενα OLE, δείτε [Διαχείριση OLE](/slides/el/php-java/manage-ole/).

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ενημερώσει ότι το αντικείμενο OLE έχει τροποποιηθεί και ότι πρέπει να ενημερωθεί η εικόνα προεπισκόπησης.

Για παράδειγμα, εάν προσθέσετε ένα γράφημα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Manage OLE») και στη συνέχεια ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE έχει προστεθεί στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή μπορείτε να κάνετε δεξί κλικ επάνω του και να περάσετε από την επιλογή **Object > Edit**.

![OLE object > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint στη συνέχεια ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρήσει το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE.

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θέλετε να αποθηκεύσετε την παρουσίασή σας για να διασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα «EMBEDDED OLE OBJECT».

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος «Embedded OLE Object» με μια εικόνα**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι ακόλουθες γραμμές κώδικα δείχνουν τη διαδικασία:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Προσθήκη εικόνας στους πόρους της παρουσίασης.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ορισμός τίτλου και εικόνας για την προεπισκόπηση του αντικειμένου OLE.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` στη συνέχεια αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.