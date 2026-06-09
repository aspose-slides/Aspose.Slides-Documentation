---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις στο Android
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/androidjava/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ενδυναμώστε τις εφαρμογές Java να σχεδιάζουν, να συνδέουν και να αυτοκατευθύνουν γραμμές σε διαφάνειες PowerPoint στο Android - αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, αγκάλια και καμπυλωτούς συνδέσμους."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή συνάπτει δύο σχήματα μαζί και παραμένει προσαρτημένος στα σχήματα ακόμη και όταν μετακινούνται ή αλλάζουν θέση σε μια δεδομένη διαφάνεια. 

Οι σύνδεσμοι συνήθως συνδέονται σε *σημεία σύνδεσης* (πράσινα σημεία), τα οποία υπάρχουν εξ ορισμού σε όλα τα σχήματα. Τα σημεία σύνδεσης εμφανίζονται όταν ο δείκτης πλησιάζει σε αυτά.

*Σημεία προσαρμογής* (πορτοκαλί σημεία), που υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση της θέσης και του σχήματος των συνδέσμων.

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείες, αγκάλια (γωνιακές) και καμπυλωτές συνδέσεις. 

Η Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος | Εικόνα | Αριθμός σημείων προσαρμογής |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Σύνδεση Σχημάτων Χρησιμοποιώντας Συνδέσμους**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://apireference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Καλέστε τη μέθοδο `reroute` για να εφαρμόσετε τη συντομότερη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε έναν σύνδεσμο (καμπυλωτό σύνδεσμο) μεταξύ δύο σχημάτων (ellipse και rectangle):

```Java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη συλλογή σχήματος για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Προσθέτει ένα αυτοσχήμα Έλλειψη
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Προσθέτει ένα αυτοσχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Προσθέτει ένα σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Καλεί τη μέθοδο reroute που ορίζει την αυτόματη συντομότερη διαδρομή μεταξύ των σχημάτων
    connector.reroute();
    
    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Η μέθοδος `Connector.reroute` επαναδρομολογεί έναν σύνδεσμο και τον αναγκάζει να ακολουθεί τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων. Για να επιτύχει αυτό, η μέθοδος μπορεί να αλλάξει τα σημεία `setStartShapeConnectionSiteIndex` και `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορισμός Σημείου Σύνδεσης**

Αν θέλετε ένας σύνδεσμος να συνδέει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να καθορίσετε τα προτιμώμενα σημεία σύνδεσης με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε έναν σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes`, ορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας τον σύνδεσμο. 
1. Καθορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα. 
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να καθορίσετε ένα προτιμώμενο σημείο σύνδεσης:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Προσθέτει ένα αυτοσχήμα Έλλειψη
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Προσθέτει ένα αυτοσχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Προσθέτει ένα σχήμα συνδέσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Συνδέει τα σχήματα χρησιμοποιώντας τον σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Ορίζει το προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψη
    int wantedIndex = 6;

    // Ελέγχει αν ο προτιμώμενος δείκτης είναι μικρότερος από το μέγιστο αριθμό θέσεων
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Ορίζει το προτιμώμενο σημείο σύνδεσης στο αυτοσχήμα Έλλειψη
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσαρμογή Σημείου Συνδέσμου**

Μπορείτε να προσαρμόσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων προσαρμογής του. Μόνο οι σύνδεσμοι με σημεία προσαρμογής μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύποι συνδέσμων.](/slides/el/androidjava/connector/#types-of-connectors)**

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) περνά από ένα τρίτο σχήμα (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Για να αποφύγουμε ή να παρακάμψουμε το τρίτο σχήμα, μπορούμε να προσαρμόσουμε τον σύνδεσμο μετακινώντας την κατακόρυφη γραμμή του προς τα αριστερά ως εξής:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Σύνθετες Περιπτώσεις** 

* Το προσαρμόσιμο σημείο ενός συνδέσμου είναι στενά συνδεδεμένο με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Έτσι, αλλαγές στη θέση του σημείου μπορούν να αλλάξουν το σχήμα του συνδέσμου.
* Τα σημεία προσαρμογής ενός συνδέσμου ορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία προσαρμογής αριθμούνται από το σημείο εκκίνησης του συνδέσμου έως το τέλος του.
* Οι τιμές των σημείων προσαρμογής αντικατοπτρίζουν το ποσοστό του πλάτους/υψους του σχήματος του συνδέσμου. 
  * Το σχήμα περιορίζεται από τα σημεία εκκίνησης και λήξης του συνδέσμου πολλαπλασιασμένα με 1000. 
  * Το πρώτο σημείο, το δεύτερο σημείο και το τρίτο σημείο ορίζουν το ποσοστό από το πλάτος, το ποσοστό από το ύψος και ξανά το ποσοστό από το πλάτος, αντίστοιχα.
* Για τους υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων προσαρμογής ενός συνδέσμου, πρέπει να ληφθεί υπόψη η περιστροφή του συνδέσμου και η αντανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που φαίνονται στην ενότητα **[Τύποι συνδέσμων](/slides/el/androidjava/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται μεταξύ τους μέσω ενός συνδέσμου:

![connector-shape-complex](connector-shape-complex.png)

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Παίρνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.getSlides().get_Item(0);
    // Προσθέτει σχήματα που θα συνδεθούν μαζί μέσω ενός συνδέσμου
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Προσθέτει έναν σύνδεσμο
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Καθορίζει την κατεύθυνση του συνδέσμου
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Καθορίζει το χρώμα του συνδέσμου
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Καθορίζει το πάχος της γραμμής του συνδέσμου
    connector.getLineFormat().setWidth(3);
    
    // Συνδέει τα σχήματα μεταξύ τους με το σύνδεσμο
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Παίρνει τα σημεία προσαρμογής για το σύνδεσμο
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Ρύθμιση**

Μπορούμε να αλλάξουμε τις τιμές των σημείων προσαρμογής του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20% και 200%, αντίστοιχα:

```java
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που να μας επιτρέπει να προσδιορίσουμε τις συντεταγμένες και το σχήμα των μεμονωμένων τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου στο σημείο `connector.getAdjustments().get_Item(0)`:

```java
// Σχεδίαση του κάθετου συστατικού του συνδέσμου
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Το αποτέλεσμα:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, δείξαμε μια απλή λειτουργία προσαρμογής συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές καταστάσεις, πρέπει να ληφθεί υπόψη η περιστροφή του συνδέσμου και η προβολή του (που ορίζονται από τα `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()`). Τώρα θα δείξουμε τη διαδικασία.

Πρώτα, ας προσθέσουμε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και ας δημιουργήσουμε έναν νέο (πράσινο) σύνδεσμο που τον συνδέει με τα αντικείμενα που έχουμε ήδη δημιουργήσει.

```java
// Δημιουργεί ένα νέο αντικείμενο δέσμευσης
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Δημιουργεί ένα νέο σύνδεσμο
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Συνδέει τα αντικείμενα χρησιμοποιώντας το νέο σύνδεσμο
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Λαμβάνει τα σημεία προσαρμογής του συνδέσμου
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Αλλάζει τις τιμές των σημείων προσαρμογής
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![connector-adjusted-3](connector-adjusted-3.png)

Δεύτερον, ας δημιουργήσουμε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου που περνά από το νέο σημείο προσαρμογής `connector.getAdjustments().get_Item(0)`. Θα χρησιμοποιήσουμε τις τιμές από τα δεδομένα του συνδέσμου για `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()` και θα εφαρμόσουμε τον γνωστό τύπο μετασχηματισμού συντεταγμένων για περιστροφή γύρω από σημείο x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωσή μας, η γωνία περιστροφής του αντικειμένου είναι 90 μοίρες και ο σύνδεσμος εμφανίζεται κάθετα, οπότε ο αντίστοιχος κώδικας είναι:

```java
// Αποθηκεύει τις συντεταγμένες του συνδέσμου
x = connector.getX();
y = connector.getY();
// Διορθώνει τις συντεταγμένες του συνδέσμου σε περίπτωση που εμφανίζεται
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Χρησιμοποιεί την τιμή του σημείου προσαρμογής ως συντεταγμένη
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Μετατρέπει τις συντεταγμένες επειδή Sin(90) = 1 και Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Καθορίζει το πλάτος του οριζόντιου συστατικού χρησιμοποιώντας τη δεύτερη τιμή σημείου προσαρμογής
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Το αποτέλεσμα:

![connector-adjusted-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που αφορούν τόσο απλές όσο και σύνθετες προσαρμογές σημείων (σημεία προσαρμογής με γωνίες περιστροφής). Χρησιμοποιώντας τις γνώσεις που αποκτήσατε, μπορείτε να δημιουργήσετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να λάβετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τις τιμές των σημείων προσαρμογής ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Εύρεση Γωνίας Γραμμών Συνδέσμου**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης.
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσεγγίστε το σχήμα της γραμμής συνδέσμου.
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος πλαισίου σχήματος και το πλάτος πλαισίου σχήματος για να υπολογίσετε τη γωνία.

Αυτός ο κώδικας Java δείχνει μια λειτουργία στην οποία υπολογίσαμε τη γωνία για ένα σχήμα γραμμής συνδέσμου:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να «κολληθεί» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε αν το σχήμα εκθέτει [connection sites](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--). Αν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η προσκόλληση δεν είναι διαθέσιμη· σε αυτήν την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι λογικό να ελέγχετε τον αριθμό των θέσεων πριν το συνδέσετε.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του θα αποσυνδεθούν· ο σύνδεσμος παραμένει στη διαφάνεια ως κανονική γραμμή με ελεύθερο αρχικό/τελικό άκρο. Μπορείτε είτε να τον διαγράψετε είτε να επαναναθέσετε τις συνδέσεις και, αν χρειαστεί, να το [reroute](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/connector/#reroute--).

**Διατηρούνται οι δεσμεύσεις των συνδέσμων όταν αντιγράφεται μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγραφούν επίσης. Αν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα χρειαστεί να τα επανασυνδέσετε.