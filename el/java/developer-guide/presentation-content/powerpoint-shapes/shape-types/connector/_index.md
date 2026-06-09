---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις με Java
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/java/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ενδυναμώστε τις εφαρμογές Java να σχεδιάζουν, συνδέουν και αυτόματα δρομολογούν γραμμές σε διαφάνειες PowerPoint—αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, λοξές και καμπύλες συνδέσεις."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια ειδική γραμμή που συνδέει ή ενώνει δύο σχήματα μεταξύ τους και παραμένει προσαρτημένος στα σχήματα ακόμη και όταν αυτά μετακινούνται ή τοποθετούνται ξανά σε μια δεδομένη διαφάνεια.  

Οι σύνδεσμοι συνήθως συνδέονται με *σημεία σύνδεσης* (πράσινα σημεία), τα οποία υπάρχουν σε όλα τα σχήματα από προεπιλογή. Τα σημεία σύνδεσης εμφανίζονται όταν ο κέρσορας πλησιάζει.  

*Σημεία ρύθμισης* (πορτοκαλί σημεία), που υπάρχουν μόνο σε ορισμένους συνδέσμους, χρησιμοποιούνται για την τροποποίηση των θέσεων και των σχημάτων των συνδέσμων.  

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε ευθείες, λοξές (γωνιακές) και καμπύλες συνδέσεις.  

Aspose.Slides παρέχει αυτούς τους συνδέσμους:

| Σύνδεσμος | Εικόνα | Αριθμός σημείων ρύθμισης |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![σύνδεσμος-γραμμής](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![σύνδεσμος-ευθείας-1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![σύνδεσμος-καμπύλος-2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![σύνδεσμος-καμπύλος-3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![σύνδεσμος-καμπύλος-4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![σύνδεσμος-καμπύλος-5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![σύνδεσμος-καμπυλωτός-2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![σύνδεσμος-καμπυλωτός-3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![σύνδεσμος-καμπυλωτός-4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![σύνδεσμος-καμπυλωτός-5](shapetype.curvedconnector5.png) | 3 |

## **Σύνδεση Σχημάτων με Συνδέσμους**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε ένα σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes` καθορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας το σύνδεσμο. 
1. Καλέστε τη μέθοδο `reroute` για να εφαρμόσετε τη συντομότερη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα σύνδεσμο (έναν λυγό σύνδεσμο) μεταξύ δύο σχημάτων (μίας έλλειψης και ενός ορθογωνίου):

```Java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Προσθέτει ένα αυτόματο σχήμα Έλλειψη
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Καλεί τη μέθοδο reroute που ορίζει τη αυτόματη συντομότερη διαδρομή μεταξύ σχημάτων
    connector.reroute();
    
    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Η μέθοδος `Connector.reroute` επαναδρομολογεί έναν σύνδεσμο και τον αναγκάζει να πάρει τη συντομότερη δυνατή διαδρομή μεταξύ σχημάτων. Για να επιτύχει τον στόχο της, η μέθοδος μπορεί να αλλάξει τα σημεία `setStartShapeConnectionSiteIndex` και `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Καθορισμός Σημείου Σύνδεσης**

Αν θέλετε ένας σύνδεσμος να συνδέει δύο σχήματα χρησιμοποιώντας συγκεκριμένα σημεία στα σχήματα, πρέπει να καθορίσετε τα προτιμώμενα σημεία σύνδεσης με αυτόν τον τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσθέστε δύο [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/AutoShape) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `addAutoShape` που παρέχεται από το αντικείμενο `Shapes`.
1. Προσθέστε ένα σύνδεσμο χρησιμοποιώντας τη μέθοδο `addConnector` που παρέχεται από το αντικείμενο `Shapes` καθορίζοντας τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα χρησιμοποιώντας το σύνδεσμο. 
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα. 
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java παρουσιάζει μια λειτουργία όπου καθορίζεται ένα προτιμώμενο σημείο σύνδεσης:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στη συλλογή σχημάτων για μια συγκεκριμένη διαφάνεια
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Προσθέτει ένα αυτόματο σχήμα Έλλειψη
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Προσθέτει ένα αυτόματο σχήμα Ορθογώνιο
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Προσθέτει ένα σχήμα σύνδεσμου στη συλλογή σχημάτων της διαφάνειας
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Συνδέει τα σχήματα χρησιμοποιώντας το σύνδεσμο
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Ορίζει τον προτιμώμενο δείκτη σημείου σύνδεσης στο σχήμα Έλλειψη
    int wantedIndex = 6;

    // Ελέγχει αν ο προτιμώμενος δείκτης είναι μικρότερος από το μέγιστο πλήθος δεικτών σημείων
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Ορίζει το προτιμώμενο σημείο σύνδεσης στο αυτόματο σχήμα Έλλειψη
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Αποθηκεύει την παρουσίαση
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσαρμογή Σημείου Συνδέσμου**

Μπορείτε να προσαρμόσετε έναν υπάρχοντα σύνδεσμο μέσω των σημείων ρύθμισης του. Μόνο οι σύνδεσμοι με σημεία ρύθμισης μπορούν να τροποποιηθούν με αυτόν τον τρόπο. Δείτε τον πίνακα κάτω από **[Τύποι συνδέσμων.](/slides/el/java/connector/#types-of-connectors)** 

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (Α και Β) περνάει από ένα τρίτο σχήμα (Γ):

![σύνδεσμος-εμπόδιο](connector-obstruction.png)

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

![σύνδεσμος-εμπόδιο-διόρθωση](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Περίπλοκες Περιπτώσεις** 

Για να πραγματοποιήσετε πιο σύνθετες προσαρμογές, πρέπει να λάβετε υπόψη τα εξής:

* Το προσαρμόσιμο σημείο ενός συνδέσμου συνδέεται στενά με έναν τύπο που υπολογίζει και καθορίζει τη θέση του. Έτσι, αλλαγές στη θέση του σημείου μπορεί να τροποποιήσουν το σχήμα του συνδέσμου.  
* Τα σημεία ρύθμισης ενός συνδέσμου ορίζονται με αυστηρή σειρά σε έναν πίνακα. Τα σημεία ρύθμισης αριθμούνται από το αρχικό σημείο του συνδέσμου έως το τελικό του.  
* Οι τιμές των σημείων ρύθμισης αντικατοπτρίζουν το ποσοστό του πλάτους/ύψους του σχήματος του συνδέσμου.  
  * Το σχήμα περιορίζεται από τα αρχικά και τελικά σημεία του συνδέσμου πολλαπλασιασμένα επί 1000.  
  * Το πρώτο σημείο, το δεύτερο σημείο και το τρίτο σημείο ορίζουν αντίστοιχα το ποσοστό από το πλάτος, το ποσοστό από το ύψος και πάλι το ποσοστό από το πλάτος.  
* Για υπολογισμούς που καθορίζουν τις συντεταγμένες των σημείων ρύθμισης ενός συνδέσμου, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την ανάκλασή του. **Σημείωση** ότι η γωνία περιστροφής για όλους τους συνδέσμους που εμφανίζονται κάτω από **[Τύποι συνδέσμων](/slides/el/java/connector/#types-of-connectors)** είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται μέσω ενός συνδέσμου:

![σύνδεσμος-σχήμα-πλοκό](connector-shape-complex.png)

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.getSlides().get_Item(0);
    // Προσθέτει σχήματα που θα συνδεθούν μέσω ενός συνδέσμου
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Προσθέτει ένα σύνδεσμο
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Καθορίζει την κατεύθυνση του συνδέσμου
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Καθορίζει το χρώμα του συνδέσμου
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Καθορίζει το πάχος της γραμμής του συνδέσμου
    connector.getLineFormat().setWidth(3);
    
    // Συνδέει τα σχήματα μαζί με το σύνδεσμο
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Λαμβάνει τα σημεία ρύθμισης του συνδέσμου
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Ρύθμιση**

Μπορούμε να αλλάξουμε τις τιμές των σημείων ρύθμισης του συνδέσμου αυξάνοντας το αντίστοιχο ποσοστό πλάτους και ύψους κατά 20 % και 200 % αντίστοιχα:

```java
// Αλλάζει τις τιμές των σημείων ρύθμισης
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![σύνδεσμος-ρυθμισμένος-1](connector-adjusted-1.png)

Για να ορίσουμε ένα μοντέλο που να μας επιτρέπει να προσδιορίσουμε τις συντεταγμένες και το σχήμα των επιμέρους τμημάτων του συνδέσμου, ας δημιουργήσουμε ένα σχήμα που αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου στο σημείο `connector.getAdjustments().get_Item(0)`:

```java
// Σχεδιάζει το κατακόρυφο μέρος του συνδέσμου
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Το αποτέλεσμα:

![σύνδεσμος-ρυθμισμένος-2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, παρουσιάσαμε μια απλή λειτουργία ρύθμισης συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε κανονικές καταστάσεις, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και την προβολή του (που ορίζονται από τις μεθόδους `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()`). Θα δείξουμε τώρα τη διαδικασία.

Πρώτα, ας προσθέσουμε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σκοπούς σύνδεσης) και ας δημιουργήσουμε ένα νέο (πράσινο) σύνδεσμο που το συνδέει με τα αντικείμενα που ήδη δημιουργήσαμε.

```java
// Δημιουργεί ένα νέο αντικείμενο σύνδεσης
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Δημιουργεί ένα νέο σύνδεσμο
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Συνδέει αντικείμενα χρησιμοποιώντας το πρόσφατα δημιουργημένο σύνδεσμο
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Λαμβάνει τα σημεία ρύθμισης του συνδέσμου
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Αλλάζει τις τιμές των σημείων ρύθμισης
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Το αποτέλεσμα:

![σύνδεσμος-ρυθμισμένος-3](connector-adjusted-3.png)

Δεύτερον, ας δημιουργήσουμε ένα σχήμα που θα αντιστοιχεί στο οριζόντιο συστατικό του συνδέσμου που περνά από το νέο σημείο ρύθμισης `connector.getAdjustments().get_Item(0)`. Θα χρησιμοποιήσουμε τις τιμές από τα δεδομένα του συνδέσμου για `connector.getRotation()`, `connector.getFrame().getFlipH()` και `connector.getFrame().getFlipV()` και θα εφαρμόσουμε τον γνωστό τύπο μετατροπής συντεταγμένων για περιστροφή γύρω από σημείο `x0`:

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
// Λαμβάνει την τιμή του σημείου ρύθμισης ως συντεταγμένη
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Μετατρέπει τις συντεταγμένες επειδή Sin(90) = 1 και Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Καθορίζει το πλάτος του οριζόντιου τμήματος χρησιμοποιώντας τη τιμή του δεύτερου σημείου ρύθμισης
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Το αποτέλεσμα:

![σύνδεσμος-ρυθμισμένος-4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που αφορούν απλές προσαρμογές και σύνθετα σημεία ρύθμισης (σημεία ρύθμισης με γωνίες περιστροφής). Με τη γνώση που αποκτήσατε, μπορείτε να δημιουργήσετε το δικό σας μοντέλο (ή να γράψετε κώδικα) για να λάβετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τις τιμές των σημείων ρύθμισης ενός συνδέσμου με βάση συγκεκριμένες συντεταγμένες διαφάνειας.

## **Εύρεση Γωνίας Γραμμών Συνδέσμου**

1. Δημιουργήστε μια παρουσία της κλάσης.
1. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Πρόσβαση στο σχήμα γραμμής του συνδέσμου.
1. Χρησιμοποιήστε το πλάτος, το ύψος, το ύψος του πλαισίου σχήματος και το πλάτος του πλαισίου σχήματος για να υπολογίσετε τη γωνία.

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

## **ΣΥ.Ζ.**

**Πώς μπορώ να διαπιστώ αν ένας σύνδεσμος μπορεί να «κολλήσει» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε ότι το σχήμα εκθέτει [connection sites](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getConnectionSiteCount--). Αν δεν υπάρχουν ή η μέτρηση είναι μηδέν, η προσκόλληση δεν είναι διαθέσιμη· σε αυτή την περίπτωση χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι λογικό να ελέγχετε τον αριθμό των σημείων πριν προσαρτήσετε.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του θα αποσυνδεθούν· ο σύνδεσμος παραμένει στη διαφάνεια ως απλή γραμμή με ελεύθερο αρχικό/τελικό σημείο. Μπορείτε είτε να τον διαγράψετε είτε να επανακοινώσετε τις συνδέσεις και, εάν χρειάζεται, να χρησιμοποιήσετε το [reroute](https://reference.aspose.com/slides/el/java/com.aspose.slides/connector/#reroute--).

**Διατηρούνται οι συνδέσεις των συνδέσμων όταν αντιγράφετε μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγράφονται επίσης. Αν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα χρειαστεί να τα συνδέσετε ξανά.