---
title: Διαχείριση κόμβων σχήματος SmartArt σε παρουσιάσεις με PHP
linktitle: Κόμβος σχήματος SmartArt
type: docs
weight: 30
url: /el/php-java/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Θυγατρικός κόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Κατάργηση κόμβου
- Προσαρμοσμένη θέση
- Κόμβος βοηθού
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε PPT και PPTX με το Aspose.Slides for PHP via Java. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για να βελτιώσετε τις παρουσιάσεις σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt στις παρουσιάσεις του PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides επιτρέπει την προγραμματιστική εργασία με αυτούς τους κόμβους SmartArt: προσθήκη νέων κόμβων και θυγατρικών κόμβων, εισαγωγή θυγατρικών κόμβων σε συγκεκριμένη θέση, πρόσβαση σε υπάρχοντες κόμβους και ανάγνωση του κειμένου, του επιπέδου και της θέσης τους.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρέσετε κόμβους, να εργαστείτε με θυγατρικούς κόμβους με βάση το ευρετήριο ή τη θέση, να μετατρέψετε έναν κόμβο βοηθού σε κανονικό κόμβο, να προσαρμόσετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβου SmartArt, να ορίσετε μορφές γεμίσματος κόμβων και να δημιουργήσετε μικρογραφία για έναν θυγατρικό κόμβο SmartArt.

## **Προσθήκη κόμβου SmartArt**
Το Aspose.Slides for PHP via Java παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον πιο εύκολο τρόπο. Ο παρακάτω κώδικας δείγματος βοηθά στην προσθήκη κόμβου και θυγατρικού κόμβου μέσα σε σχήμα SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. [Add a new Node](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnodecollection/#addNode) στο σχήμα SmartArt **NodeCollection** και ορίστε το κείμενο στο TextFrame.
6. Τώρα, [Add](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnodecollection/#addNode) ένα **Child Node** στο πρόσφατα προστεθέν SmartArt Node και ορίστε το κείμενο στο TextFrame.
7. Αποθηκεύστε την παρουσίαση.

```php
  # Φορτώστε την επιθυμητή παρουσίαση
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Κάντε μετατροπή τύπου του σχήματος σε SmartArt
        $smart = $shape;
        # Προσθήκη νέου κόμβου SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Προσθήκη κειμένου
        $TemNode->getTextFrame()->setText("Test");
        # Προσθήκη νέου θυγατρικού κόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
        $newNode = $TemNode->getChildNodes()->addNode();
        # Προσθήκη κειμένου
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη κόμβου SmartArt σε συγκεκριμένη θέση**
Στο παρακάτω δείγμα κώδικα εξηγούμε πώς να προσθέσετε τους θυγατρικούς κόμβους των αντίστοιχων κόμβων σχήματος SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Προσθέστε ένα σχήμα SmartArt τύπου [**StackedList**](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArtLayoutType#StackedList) στη διαφάνεια.
4. Πρόσβαση στον πρώτο κόμβο του προστεθέντος σχήματος SmartArt.
5. Τώρα, προσθέστε το **Child Node** για τον επιλεγμένο **Node** στη θέση 2 και ορίστε το κείμενό του.
6. Αποθηκεύστε την παρουσίαση.

```php
  # Δημιουργία ενός αντικειμένου παρουσίασης
  $pres = new Presentation();
  try {
    # Πρόσβαση στη διαφάνεια παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Προσθήκη νέου θυγατρικού κόμβου στη θέση 2 στον γονικό κόμβο
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Προσθήκη κειμένου
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Αποθήκευση παρουσίασης
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε κόμβο SmartArt**
Ο παρακάτω κώδικας δείγματος βοηθά στην πρόσβαση σε κόμβους μέσα σε σχήμα SmartArt. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt, καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα SmartArt προστίθεται.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους **Nodes** μέσα στο σχήμα SmartArt.
6. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση κόμβου SmartArt, επίπεδο και κείμενο.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Λήψη πρώτης διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($slide->getShapes() as $shape) {
      # Έλεγχος αν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατροπή τύπου του σχήματος σε SmartArt
        $smart = $shape;
        # Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο i
          $node = $smart->getAllNodes()->get_Item($i);
          # Εκτύπωση των παραμέτρων του κόμβου SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε θυγατρικό κόμβο SmartArt**
Ο παρακάτω κώδικας δείγματος βοηθά στην πρόσβαση στους θυγατρικούς κόμβους των αντίστοιχων κόμβων σχήματος SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους **Nodes** μέσα στο σχήμα SmartArt.
6. Για κάθε επιλεγμένο SmartArt **Node**, περιηγηθείτε σε όλους τους **Child Nodes** μέσα στον συγκεκριμένο κόμβο.
7. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση **Child Node**, επίπεδο και κείμενο.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Λήψη πρώτης διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($slide->getShapes() as $shape) {
      # Έλεγχος αν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατροπή τύπου του σχήματος σε SmartArt
        $smart = $shape;
        # Περιήγηση σε όλους τους κόμβους μέσα στο SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Περιήγηση στα θυγατρικά κόμβοι του κόμβου SmartArt στο ευρετήριο i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Πρόσβαση στον θυγατρικό κόμβο στο SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Εκτύπωση των παραμέτρων του θυγατρικού κόμβου SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε θυγατρικό κόμβο SmartArt σε συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αποκτήσουμε πρόσβαση στους θυγατρικούς κόμβους σε συγκεκριμένη θέση που ανήκουν σε αντίστοιχους κόμβους σχήματος SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Προσθέστε ένα σχήμα SmartArt τύπου [**StackedList**](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArtLayoutType#StackedList).
4. Πρόσβαση στο προστεθέν σχήμα SmartArt.
5. Πρόσβαση στον κόμβο με δείκτη 0 του σχήματος SmartArt.
6. Τώρα, πρόσβαση στο **Child Node** στη θέση 1 για τον επιλεγμένο κόμβο SmartArt χρησιμοποιώντας τη μέθοδο **get_Item()**.
7. Πρόσβαση και εμφάνιση πληροφοριών όπως θέση **Child Node**, επίπεδο και κείμενο.

```php
  # Δημιουργία της παρουσίασης
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη του σχήματος SmartArt στην πρώτη διαφάνεια
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Πρόσβαση στον θυγατρικό κόμβο στη θέση 1 στον γονικό κόμβο
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Εκτύπωση των παραμέτρων του θυγατρικού κόμβου SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση κόμβου SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα στο σχήμα SmartArt.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. Ελέγξτε εάν το SmartArt έχει περισσότερους από 0 κόμβους.
6. Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.
7. Τώρα, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο [**removeNode**](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Αποθηκεύστε την παρουσίαση.

```php
  # Φορτώστε την επιθυμητή παρουσίαση
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Ελέγξτε αν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Αφαίρεση του επιλεγμένου κόμβου
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση κόμβου SmartArt από συγκεκριμένη θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα στο σχήμα SmartArt σε συγκεκριμένη θέση.

1. Δημιουργήйте ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. Επιλέξτε τον κόμβο σχήματος SmartArt με δείκτη 0.
6. Τώρα, ελέγξτε εάν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 θυγατρικούς κόμβους.
7. Τώρα, αφαιρέστε τον κόμβο στη **Θέση 1** χρησιμοποιώντας τη μέθοδο [**removeNode**](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. Αποθηκεύστε την παρουσίαση.

```php
  # Φορτώστε την επιθυμητή παρουσίαση
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Ελέγξτε αν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατρέψτε το σχήμα σε SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Πρόσβαση στον κόμβο SmartArt στο ευρετήριο 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Αφαίρεση του θυγατρικού κόμβου στη θέση 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός προσαρμοσμένης θέσης για θυγατρικό κόμβο σε αντικείμενο SmartArt**
Το Aspose.Slides for PHP via Java υποστηρίζει τον καθορισμό των ιδιοτήτων X και Y του [SmartArtShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/SmartArtShape). Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape· επίσης σημειώστε ότι η προσθήκη νέων κόμβων προκαλεί επανυπολογισμό των θέσεων και μεγεθών όλων των κόμβων. Με τις προσαρμοσμένες ρυθμίσεις θέσης, ο χρήστης μπορεί να θέσει τους κόμβους όπως απαιτείται.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Μετακίνηση του σχήματος SmartArt σε νέα θέση
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Αλλαγή του πλάτους του σχήματος SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Αλλαγή του ύψους του σχήματος SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Αλλαγή της περιστροφής του σχήματος SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Έλεγχος κόμβου βοηθού**
{{% alert color="primary" %}} 

Σε αυτό το άρθρο θα διερευνήσουμε περαιτέρω τις δυνατότητες των σχημάτων SmartArt που προστίθενται σε διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας το Aspose.Slides for PHP via Java.

{{% /alert %}} 

Θα χρησιμοποιήσουμε το παρακάτω σχήμα SmartArt ως πηγή για την έρευνά μας σε διάφορες ενότητες του άρθρου.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Πηγαίο σχήμα SmartArt στη διαφάνεια**|

Στον παρακάτω κώδικα δείγματος θα διερευνήσουμε πώς να εντοπίσετε **Assistant Nodes** στη συλλογή κόμβων SmartArt και να τα τροποποιήσετε.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
2. Λάβετε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.
4. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) και κάντε μετατροπή τύπου του επιλεγμένου σχήματος σε [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) αν είναι SmartArt.
5. Περιηγηθείτε σε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε εάν είναι **Assistant Nodes**.
6. Αλλάξτε την κατάσταση του Assistant Node σε κανονικό κόμβο.
7. Αποθηκεύστε την παρουσίαση.

```php
  # Δημιουργία ενός αντικειμένου παρουσίασης
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Περιήγηση σε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Έλεγχος αν το σχήμα είναι τύπου SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Μετατροπή τύπου του σχήματος σε SmartArt
        $smart = $shape;
        # Περιήγηση σε όλους τους κόμβους του σχήματος SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Έλεγχος αν ο κόμβος είναι κόμβος βοηθού
          if ($node->isAssistant()) {
            # Ορισμός του κόμβου βοηθού σε ψευδές και μετατροπή του σε κανονικό κόμβο
            $node->isAssistant();
          }
        }
      }
    }
    # Αποθήκευση παρουσίασης
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Σχήμα: Οι Assistant Nodes άλλαξαν στο σχήμα SmartArt μέσα στη διαφάνεια**|

## **Ορισμός μορφής γεμίσματος για κόμβο**
Το Aspose.Slides for PHP via Java καθιστά δυνατό το προσθήκη προσαρμοσμένων σχημάτων SmartArt και τον ορισμό της μορφής γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να έχετε πρόσβαση σε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος χρησιμοποιώντας το Aspose.Slides for PHP via Java.

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
2. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το ευρετήριό της.
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) ορίζοντας τον **LayoutType** του.
4. Ορίστε το **Fill Format** για τους κόμβους του σχήματος SmartArt.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  # Δημιουργία της παρουσίασης
  $pres = new Presentation();
  try {
    # Πρόσβαση στη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη σχήματος SmartArt και κόμβων
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Ορισμός χρώματος γεμίσματος του κόμβου
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Αποθήκευση της παρουσίασης
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία μικρογραφίας για θυγατρικό κόμβο SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μικρογραφία για τον θυγατρικό κόμβο ενός SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
2. [Add SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnodecollection/#addNode).
3. Λάβετε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του.
4. Λάβετε την εικόνα μικρογραφίας.
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή αρχείου.

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX
  $pres = new Presentation();
  try {
    # Προσθήκη SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Λήψη της αναφοράς ενός κόμβου χρησιμοποιώντας το ευρετήριό του
    $node = $smart->getNodes()->get_Item(1);
    # Λήψη μικρογραφίας
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Αποθήκευση μικρογραφίας
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η κίνηση SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, οπότε μπορείτε να [apply standard animations](/slides/el/php-java/shape-animation/) (είσοδο, έξοδο, έμφαση, διαδρομές κίνησης) και να ρυθμίσετε το χρονισμό. Μπορείτε επίσης να προβάλλετε κινήσεις σε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

**Πώς μπορώ αξιόπιστα να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια εάν το εσωτερικό του αναγνωριστικό είναι άγνωστο;**

Αντιστοιχίστε και αναζητήστε με βάση το [alternative text](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getalternativetext/). Ορίζοντας ένα χαρακτηριστικό AltText στο SmartArt, μπορείτε να το εντοπίσετε προγραμματιστικά χωρίς να εξαρτάστε από εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [PDF export](/slides/el/php-java/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

**Μπορώ να εξαχθώ μια εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [raster formats](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) ή σε [SVG](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) για κλιμακώσιμο, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο web.