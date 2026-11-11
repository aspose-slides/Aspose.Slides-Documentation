---
title: Διαχειριστείτε τις Σημειώσεις Παρουσίασης σε PHP
linktitle: Σημειώσεις Παρουσίασης
type: docs
weight: 110
url: /el/php-java/presentation-notes/
keywords:
- σημειώσεις
- διαφάνεια σημειώσεων
- προσθήκη σημειώσεων
- αφαίρεση σημειώσεων
- στυλ σημειώσεων
- κύριες σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσαρμόστε τις σημειώσεις παρουσίασης με το Aspose.Slides για PHP μέσω Java. Εργαστείτε αβίαστα με σημειώσεις PowerPoint και OpenDocument για να αυξήσετε την παραγωγικότητά σας."
---
## **Επισκόπηση**

Το Aspose.Slides υποστηρίζει την αφαίρεση των σελίδων σημειώσεων από μια παρουσίαση. Σε αυτό το θέμα, θα παρουσιάσουμε αυτή τη λειτουργία, συμπεριλαμβανομένου του πώς να αφαιρέσετε σημειώσεις και πώς να εφαρμόσετε στυλ σε σελίδες σημειώσεων σε μια παρουσίαση. Το Aspose.Slides σας επιτρέπει να αφαιρέσετε σημειώσεις από οποιαδήποτε διαφάνεια και επίσης να εφαρμόσετε μορφοποίηση στις υπάρχουσες σημειώσεις. Οι προγραμματιστές μπορούν να αφαιρέσουν σημειώσεις με τους ακόλουθους τρόπους:

- Αφαίρεση σημειώσεων από μια συγκεκριμένη διαφάνεια σε μια παρουσίαση.
- Αφαίρεση σημειώσεων από όλες τις διαφάνειες σε μια παρουσίαση.

Για να διαβάσετε ή να αλλάξετε τις διαστάσεις της σελίδας σημειώσεων, να αλλάξετε την προσανατολισμό και να ελέγξετε τη συμπεριφορά εξαγωγής, δείτε [Notes Page Size](/slides/el/php-java/notes-size/).

## **Αφαίρεση σημειώσεων από διαφάνεια**
Οι σημειώσεις από μια συγκεκριμένη διαφάνεια μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```php
  # Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Αφαίρεση σημειώσεων της πρώτης διαφάνειας
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση σημειώσεων από παρουσίαση**
Οι σημειώσεις από όλες τις διαφάνειες σε μια παρουσίαση μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```php
  # Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Αφαίρεση σημειώσεων από όλες τις διαφάνειες
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη στυλ σημειώσεων**
Η μέθοδος [getNotesStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) της κλάσης [MasterNotesSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/MasterNotesSlide) παρέχει πρόσβαση στο στυλ κειμένου των σημειώσεων. Η υλοποίηση παρουσιάζεται στο παρακάτω παράδειγμα.

```php
  # Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Αποκτήστε το στυλ κειμένου του MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Ορίστε σύμβολο σφαίρας για τις παραγράφους του πρώτου επιπέδου
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Ποια οντότητα API παρέχει πρόσβαση στις σημειώσεις μιας συγκεκριμένης διαφάνειας;**

Οι σημειώσεις προσπελάζονται μέσω του διαχειριστή σημειώσεων της διαφάνειας: η διαφάνεια διαθέτει ένα [NotesSlideManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslidemanager/) και μια [μέθοδο](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslidemanager/getnotesslide/) που επιστρέφει το αντικείμενο σημειώσεων, ή `null` εάν δεν υπάρχουν σημειώσεις.

**Υπάρχουν διαφορές στην υποστήριξη σημειώσεων μεταξύ των εκδόσεων του PowerPoint με τις οποίες λειτουργεί η βιβλιοθήκη;**

Η βιβλιοθήκη στοχεύει σε ένα ευρύ φάσμα μορφών Microsoft PowerPoint (97–νεότερες) και ODP· οι σημειώσεις υποστηρίζονται σε αυτές τις μορφές χωρίς εξάρτηση από εγκατεστημένο αντίγραφο του PowerPoint.