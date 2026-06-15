---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις με PHP
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/php-java/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ενδυναμώστε τις εφαρμογές PHP να σχεδιάζουν, συνδέουν και αυτο-δρομολογούν γραμμές σε διαφάνειες PowerPoint — αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, αγκάλες και καμπυλωτούς συνδέσμους."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή ενώνει δύο σχήματα μεταξύ τους και παραμένει συνδεδεμένος με τα σχήματα ακόμη και όταν αυτά μετακινούνται ή τοποθετούνται ξανά σε μια δεδομένη διαφάνεια. 

Οι σύνδεσμοι συνδέονται τυπικά σε *σημεία σύνδεσης* (πράσινα σημεία), που υπάρχουν προεπιλεγμένα σε όλα τα σχήματα. Τα σημεία σύνδεσης εμφανίζονται όταν ο δρομέας πλησιάζει σε αυτά.

*Σημεία προσαρμογής* (πορτοκαλί σημεία), που υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση των θέσεων και των μορφών των συνδέσμων.

## **Τύποι συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείς, αγκυκλούς (γωνιακούς) και καμπυλωτούς συνδέσμους. 

Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος | Εικόνα | Αριθμός σημείων προσαρμογής |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Σύνδεση σχημάτων με συνδέσμους**

1. Δημιουργήστε μία εμφάνιση της κλάσης [Presentation](https://apireference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Καλέστε τη μέθοδο `reroute` για να εφαρμόσετε τη μικρότερη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε έναν σύνδεσμο (έναν λυγμό σύνδεσμου) μεταξύ δύο σχημάτων (μιας έλλειψης και ενός ορθογωνίου):

```php
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει το αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Προσθέτει αυτόματο σχήμα Έλλειψης
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Προσθέτει αυτόματο σχήμα Ορθογώνιου
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Προσθέτει σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Καλεί τη μέθοδο reroute που ορίζει τη αυτόματη πιο σύντομη διαδρομή μεταξύ των σχημάτων
    $connector->reroute();
    # Αποθηκεύει την παρουσίαση
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Η μέθοδος `Connector.reroute` επαναδρομολογεί έναν σύνδεσμο και τον αναγκάζει να ακολουθήσει τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων. Για να πετύχει τον στόχο της, η μέθοδος μπορεί να αλλάξει τα σημεία `setStartShapeConnectionSiteIndex` και `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορισμός σημείου σύνδεσης**

Αν θέλετε ένας σύνδεσμος να ενώσει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να καθορίσετε τα προτιμώμενα σημεία σύνδεσης ως εξής:

1. Δημιουργήστε μία εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα. 
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας PHP δείχνει μια λειτουργία όπου καθορίζεται ένα προτιμώμενο σημείο σύνδεσης:

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Προσθέτει αυτόματο σχήμα Έλλειψη
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Προσθέτει αυτόματο σχήμα Ορθογώνιου
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Προσθέτει σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Θέτει το προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψη
    $wantedIndex = 6;
    # Ελέγχει αν ο προτιμώμενος δείκτης είναι μικρότερος από το μέγιστο πλήθος δεικτών σημείου
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Θέτει το προτιμώμενο σημείο σύνδεσης στο αυτόματο σχήμα Έλλειψη
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Αποθηκεύει την παρουσίαση
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ρύθμιση σημείου συνδέσμου**

Μπορείτε να ρυθμίσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων προσαρμογής του. Μόνο σύνδεσμοι με σημεία προσαρμογής μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύποι συνδέσμων](/slides/el/php-java/connector/#types-of-connectors)**

### **Απλή περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) περνά μέσα από ένα τρίτο σχήμα (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Για να αποφύγουμε ή να παρακάμψουμε το τρίτο σχήμα, μπορούμε να ρυθμίσουμε τον σύνδεσμο μετακινώντας την κάθετη γραμμή του προς τα αριστερά ως εξής:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Σύνθετες περιπτώσεις** 

Για να πραγματοποιήσετε πιο σύνθετες ρυθμίσεις, πρέπει να λάβετε υπόψη τα εξής:

* Το προσαρμοζόμενο σημείο ενός συνδέσμου συνδέεται στενά με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Συνεπώς, οι αλλαγές στη θέση του σημείου μπορεί να αλλάξουν το σχήμα του συνδέσμου.
* Τα σημεία προσαρμογής ενός συνδέσμου ορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία αριθμούνται από το σημείο εκκίνησης του συνδέσμου μέχρι το τέλος του.
* Οι τιμές των σημείων προσαρμογής αντανακλούν το ποσοστό του πλάτους/ύψους του σχήματος του συνδέσμου. 
  * Το σχήμα περιορίζεται από τα σημεία εκκίνησης και τέλους του συνδέσμου πολλαπλασιασμένα με 1000. 
  * Το πρώτο, το δεύτερο και το τρίτο σημείο καθορίζουν αντίστοιχα το ποσοστό από το πλάτος, το ποσοστό από το ύψος και πάλι το ποσοστό από το πλάτος.
* Για υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων προσαρμογής ενός συνδέσμου, πρέπει να ληφθεί υπόψη η περιστροφή του συνδέσμου και η αντανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που εμφανίζονται κάτω από **[Τύποι συνδέσμων](/slides/el/php-java/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται μέσω ενός συνδέσμου:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέτει σχήματα που θα ενωθούν μέσω ενός συνδέσμου
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Προσθέτει έναν σύνδεσμο
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Καθορίζει την κατεύθυνση του συνδέσμου
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Καθορίζει το χρώμα του συνδέσμου
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Καθορίζει το πάχος της γραμμής του συνδέσμου
    $connector->getLineFormat()->setWidth(3);
    # Συνδέει τα σχήματα μεταξύ τους με το σύνδεσμο
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Λαμβάνει τα σημεία προσαρμογής του συνδέσμου
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ρύθμιση**

Μπορούμε να αλλάξουμε τις τιμές των σημείων προσαρμογής του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20% και 200% αντίστοιχα:

```php
  # Αλλάζει τις τιμές των σημείων προσαρμογής
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που να μας επιτρέπει τον προσδιορισμό των συντεταγμένων και του σχήματος των μεμονωμένων τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου στο σημείο `connector.getAdjustments().get_Item(0)`:

```php
  # Σχεδιάζει το κάθετο συστατικό του συνδέσμου
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Το αποτέλεσμα:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, παρουσιάσαμε μια απλή λειτουργία ρύθμισης συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές συνθήκες, πρέπει να ληφθούν υπόψη η περιστροφή του συνδέσμου και η προβολή του (που ορίζονται από τις μεθόδους `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()`). Τώρα θα δείξουμε τη διαδικασία.

Πρώτα, προσθέστε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και δημιουργήστε έναν νέο (πράσινο) σύνδεσμο που το συνδέει με τα αντικείμενα που έχουμε ήδη δημιουργήσει.

```php
  # Δημιουργεί ένα νέο αντικείμενο σύνδεσης
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Δημιουργεί έναν νέο σύνδεσμο
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Συνδέει αντικείμενα χρησιμοποιώντας τον νεοδημιουργημένο σύνδεσμο
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Λαμβάνει τα σημεία προσαρμογής του συνδέσμου
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Αλλάζει τις τιμές των σημείων προσαρμογής
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Το αποτέλεσμα:

![connector-adjusted-3](connector-adjusted-3.png)

Δεύτερον, ας δημιουργήσουμε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου που διέρχεται από το νέο σημείο προσαρμογής του συνδέσμου `connector.getAdjustments().get_Item(0)`. Θα χρησιμοποιήσουμε τις τιμές από τα δεδομένα του συνδέσμου για `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()` και θα εφαρμόσουμε τον δημοφιλές τύπο μετασχηματισμού συντεταγμένων για περιστροφή γύρω από ένα σημείο x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωσή μας, η γωνία περιστροφής του αντικειμένου είναι 90 μοίρες και ο σύνδεσμος εμφανίζεται κάθετα, έτσι αυτός είναι ο αντίστοιχος κώδικας:

```php
  # Αποθηκεύει τις συντεταγμένες του συνδέσμου
  $x = $connector->getX();
  $y = $connector->getY();
  # Διορθώνει τις συντεταγμένες του συνδέσμου σε περίπτωση που εμφανίζεται
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Λαμβάνει την τιμή του σημείου προσαρμογής ως συντεταγμένη
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Μετατρέπει τις συντεταγμένες επειδή Sin(90) = 1 και Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Καθορίζει το πλάτος του οριζόντιου συστατικού χρησιμοποιώντας τη δεύτερη τιμή σημείου προσαρμογής
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Το αποτέλεσμα:

![connector-adjusted-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που αφορούν απλές ρυθμίσεις και σύνθετα σημεία προσαρμογής (σημεία με γωνίες περιστροφής). Με τη γνώση που αποκτήσατε, μπορείτε να αναπτύξετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να λάβετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να θέσετε τις τιμές των σημείων προσαρμογής ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Εύρεση γωνίας γραμμών συνδέσμου**

1. Δημιουργήστε μια εμφάνιση της κλάσης.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσπελάστε το σχήμα γραμμής του συνδέσμου.
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος του πλαισίου σχήματος και το πλάτος του πλαισίου σχήματος για να υπολογίσετε τη γωνία.

Αυτός ο κώδικας PHP δείχνει μια λειτουργία στην οποία υπολογίσαμε τη γωνία για ένα σχήμα γραμμής συνδέσμου:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να «κολλήσει» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε αν το σχήμα εκθέτει [σημεία σύνδεσης](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getconnectionsitecount/). Αν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η δυνατότητα κόλλησης δεν είναι διαθέσιμη· σε αυτή την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Συνιστάται να ελέγχετε τον αριθμό των σημείων πριν την προσάρτηση.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του αποσυνδέονται· ο σύνδεσμος παραμένει στη διαφάνεια ως απλή γραμμή με ελεύθερη αρχή/τέλος. Μπορείτε είτε να το διαγράψετε είτε να επανακαθορίσετε τις συνδέσεις και, εάν χρειαστεί, να το [επανδρομολογήσετε](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/reroute/).

**Διατηρούνται οι δεσμοί των συνδέσμων όταν αντιγράψετε μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγραφούν επίσης. Αν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα πρέπει να τα επανα-συνδέσετε.