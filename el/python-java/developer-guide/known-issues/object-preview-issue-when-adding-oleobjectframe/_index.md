---
title: Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο άλλαξε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προσθέτετε OleObjectFrame στο Aspose.Slides για Python μέσω Java και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Όταν χρησιμοποιείτε το Aspose.Slides για Python μέσω Java για να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και δεν αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη δουλειά με αντικείμενα OLE, δείτε [Manage OLE](/slides/el/python-java/manage-ole/).

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ενημερώσει ότι το αντικείμενο OLE έχει αλλάξει και ότι πρέπει να ενημερωθεί η εικόνα προεπισκόπησης.

Για παράδειγμα, εάν προσθέσετε ένα γράφημα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Manage OLE») και, στη συνέχεια, ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![OLE object message](OLE_object_message.png)

Για να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, κάντε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή κάντε δεξί κλικ σε αυτό και επιλέξτε **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

Το PowerPoint, τότε, ανοίγει το ενσωματωμένο αντικείμενο OLE.

![OLE object data](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρήσει το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE.

![OLE object preview](OLE_object_preview.png)

Αποθηκεύστε την παρουσίασή σας για να διατηρήσετε την ενημερωμένη εικόνα προεπισκόπησης του αντικειμένου OLE. Όταν ανοίξετε ξανά την παρουσίαση, δεν θα δείτε πια το μήνυμα «EMBEDDED OLE OBJECT».

## **Άλλη Λύση**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Ο παρακάτω κώδικας δείχνει τη διαδικασία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση του αντικειμένου OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η διαφάνεια που περιέχει το [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) τότε μετατρέπεται σε αυτήν:

![New OLE object image](OLE_object_new_image.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί εμφανίζεται το μήνυμα «EMBEDDED OLE OBJECT»;**

Το μήνυμα υποδεικνύει ότι το αντικείμενο OLE έχει αλλάξει και ότι χρειάζεται να ενημερωθεί η εικόνα προεπισκόπησης. Αυτή η συμπεριφορά είναι σκόπιμη.

**Πώς μπορώ να ενημερώσω την προεπισκόπηση στο PowerPoint;**

Κάντε διπλό κλικ στο μήνυμα ή επιλέξτε **Object > Edit** για να ανοίξετε το ενσωματωμένο αντικείμενο OLE. Κάντε κλικ στο αντικείμενο OLE για να ενημερώσετε την προεπισκόπηση και, στη συνέχεια, αποθηκεύστε την παρουσίαση.

**Μπορώ να αντικαταστήσω το μήνυμα χωρίς να ανοίξω την παρουσίαση στο PowerPoint;**

Ναι. Μπορείτε να εκχωρήσετε μια προτιμώμενη εικόνα προεπισκόπησης στο αντικείμενο OLE, όπως φαίνεται στο παραπάνω παράδειγμα κώδικα.