---
title: Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο άλλαξε
- προεπισκόπηση αντικειμένου
- παρουσίαση
- PowerPoint
- Python
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προσθέτετε OleObjectFrame στο Aspose.Slides για Python και πώς να διορθώσετε προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ είναι σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη δουλειά με αντικείμενα OLE, δείτε το [Manage OLE](/slides/el/python-net/manage-ole/). 

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ενημερώσει ότι το αντικείμενο OLE έχει αλλάξει και ότι η εικόνα προεπισκόπησης πρέπει να ενημερωθεί. 

Για παράδειγμα, αν προσθέσετε ένα διάγραμμα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Manage OLE») και έπειτα ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή μπορείτε να κάνετε δεξί κλικ πάνω του και να περάσετε από την επιλογή **Object > Edit**.

![OLE αντικείμενο > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint ανοίγει τότε το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρήσει το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE. 

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θέλετε να αποθηκεύσετε την παρουσίαση ώστε να εξασφαλίσετε ότι η εικόνα για το αντικείμενο OLE ενημερώνεται σωστά. Έτσι, μετά την αποθήκευση της παρουσίασης, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα «EMBEDDED OLE OBJECT». 

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος «Embedded OLE Object» με εικόνα**

Αν δεν θέλετε να αφαιρέσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και έπειτα αποθηκεύοντάς τη, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Προσθήκη μιας εικόνας στους πόρους της παρουσίασης.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ορισμός τίτλου και εικόνας για την προεπισκόπηση του αντικειμένου OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Η διαφάνεια που περιέχει το `OleObjectFrame` τότε αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.