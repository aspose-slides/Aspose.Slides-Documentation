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
- σημείο σύνδεσης
- σημείο ρύθμισης
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, συνδέετε, επαναδρομολογείτε, ρυθμίζετε και επιθεωρείτε απλούς, λυγόμενους και καμπυλωτούς συνδέσμους PowerPoint με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μια γραμμή που μπορεί να παραμένει συνδεδεμένη σε δύο σχήματα όταν μετακινείται οποιοδήποτε από αυτά. Τα άκρα του συνδέονται σε σημεία σύνδεσης, που απεικονίζονται με πράσινα κουκκίδες στο PowerPoint. Ορισμένοι λυγόμενοι και καμπυλωτοί σύνδεσμοι εκθέτουν επίσης σημεία ρύθμισης, που απεικονίζονται με πορτοκαλί κουκκίδες, και ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της διεπαφής [IConnector](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/) . Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους σε σχήματα, να επιλέξετε σημεία σύνδεσης, να τα επαναδρομολογήσετε και να τροποποιήσετε τη γεωμετρία των συνδέσμων που έχουν σημεία ρύθμισης.

## **Τύποι Συνδέσμων**

Η κλάση [ShapeType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapetype/) περιλαμβάνει προρυθμισμένα απλά, λυγόμενα και καμπυλωτά σύνδεσμο. Ο παρακάτω πίνακας δείχνει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό των σημείων ρύθμισης που ορίζονται από κάθε προρύθμιση.

| Σύνδεσμος | Εικόνα | Αριθμός σημείων ρύθμισης |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και το νόημα των σημείων ρύθμισης αποτελούν μέρος της επιλεγμένης προρύθμισης σύνδεσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμου εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε το [IShapeCollection.addConnector](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) για να προσθέσετε έναν σύνδεσμο και τα [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) και [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) για να συνδέσετε τα άκρα του. Αφού συνδεθούν και τα δύο άκρα, το [IConnector.reroute](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/#reroute--) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο με έναν λυγό σύνδεσμο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Προειδοποίηση" %}}
Η κλήση του `reroute` μπορεί να αλλάξει τις τιμές των [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) και [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Αναθέστε συγκεκριμένα σημεία σύνδεσης μετά την επαναδρομολόγηση εάν αυτά πρέπει να παραμείνουν σταθερά.
{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε συνδεδεμένο σχήμα αναφέρει τον αριθμό των σημείων του μέσω του [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Επικυρώστε έναν προτιμώμενο δεικτικό σημείο μηδενικής βάσης πριν το αναθέσετε σε άκρο συνδέσμου· οι αριθμοί των σημείων διαφέρουν ανά γεωμετρία σχήματος.

Το παρακάτω παράδειγμα συνδέει τον σύνδεσμο με ένα συγκεκριμένο σημείο στην έλλειψη όταν αυτό το σημείο υπάρχει:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ρύθμιση Σημείου Συνδέσμου**

Οι σύνδεσμοι με σημεία ρύθμισης τα εκθέτουν μέσω του [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Εξετάστε κάθε [IAdjustValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/) και ελέγξτε την τιμή του [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getType--) πριν το αλλάξετε με το [setRawValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). Οι γενικοί κανόνες για την αναγνώριση προρυθμισμένων ρυθμίσεων σχήματος περιγράφονται στην ενότητα [Shape Manipulation](/slides/el/androidjava/shape-manipulations/).

Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος τιμών των ρυθμίσεων εξαρτώνται από την προρύθμιση του συνδέσμου. Ο τύπος της ρύθμισης είναι μόνο για ανάγνωση, ενώ η τιμή είναι εγγράψιμη. Η μέθοδος μόνο για ανάγνωση [getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getName--) προσφέρει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία ρυθμίσεις του ίδιου σημασιολογικού τύπου.

### **Δρομολόγηση Περιμέσου Εμπόδου**

Στη παρακάτω διάταξη, ένας σύνδεσμος `BentConnector5` μεταξύ δύο σχημάτων περνά μέσω τρίτου σχήματος:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμποδισμένο σύνδεσμο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μετακίνηση του κάθετου λυγμού αλλάζει τη διαδρομή ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης συλλογής `1` αντιπροσωπεύει πάντα τον κάθετο λυγμό, αυτό το παράδειγμα αναζητά το `ConnectorBendPositionY` και το αλλάζει μόνο όταν είναι παρούσα η αναμενόμενη σημασιολογική κατηγορία:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ένας σύνδεσμος `BentConnector5` έχει δύο ρυθμίσεις `ConnectorBendPositionX` και μία ρύθμιση `ConnectorBendPositionY`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, ελέγξτε το `getName` και τη γνωστή γεωμετρία της προρύθμισης πριν επιλέξετε μία. Εάν μια ρύθμιση επιστρέφει `ShapeAdjustmentType.Custom`, θεωρήστε το νόημα και το εύρος της ως προρύθμιση‑συγκεκριμένα και μην το αλλάξετε μέχρι να είναι γνωστή η συμφωνία.

## **Συσχέτιση Τιμών Ρύθμισης με Γεωμετρία Συνδέσμου**

Για λυγόμενους συνδέσμους, οι τιμές ρύθμισης μπορούν να χρησιμοποιηθούν για εκτίμηση των θέσεων των επιμέρους τμημάτων. Οι υπολογισμοί αυτοί είναι ειδικοί για την προρύθμιση του συνδέσμου:

- Το `BentConnector4` συνήθως εκθέτει μία ρύθμιση `ConnectorBendPositionX` και μία `ConnectorBendPositionY`.
- Για αυτές τις ρυθμίσεις λυγμού, η διαίρεση της τιμής που επιστρέφει το `getRawValue` με `100000f` παράγει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παραδείγματα παρακάτω.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αντιστραφεί, οπότε οι συντεταγμένες του πλαισίου πρέπει να μετατραπούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το `getType` για πρώτα να εντοπίσουν τις ρυθμίσεις. Δεν αντιμετωπίζουν τους δείκτες συλλογής ως φορητά αναγνωριστικά.

### **Μη Περιστρεφόμενος Σύνδεσμος**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με έναν `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα ελέγχει τον σύνδεσμο και λαμβάνει τις οριζόντιες και κάθετες ρυθμίσεις λυγμού:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Για να αλλάξετε και τα δύο λυγμούς, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού βρεθούν και οι δύο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα είναι ένας σύνδεσμος των οποίων τα οριζόντια και κάθετα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Αυτό το παράδειγμα σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κάθετο τμήμα που ελέγχεται από τις δύο ρυθμίσεις λυγμού:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Το σχήμα οδηγού δείχνει το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Ανεστραμμένος Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου είναι προσανατολισμένη κάθετα, οι τιμές του [IShape.getFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getFrame--), του [ShapeFrame.getFlipH](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/#getFlipH--) και του [ShapeFrame.getFlipV](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/#getFlipV--) επηρεάζουν τη μετατροπή από συντεταγμένες πλαισίου συνδέσμου σε συντεταγμένες διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κάθετα προσανατολισμένο σύνδεσμο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο ρυθμισμένος σύνδεσμος εμφανίζεται κάθετα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για μια αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας χειρίζεται τον προσανατολισμό 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ο κόκκινος οδηγός σημαδεύει το υπολογισμένο τμήμα μετά τη μετατροπή συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προρυθμίσεις που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επικυρώστε τους τύπους ρύθμισης, τον προσανατολισμό του πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προρύθμιση.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός απλού συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, λαμβάνοντας υπόψη τις οριζόντιες και κάθετες αντιστροφές. Το παρακάτω παράδειγμα αναφέρει τη φορά της ώρας από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να διαπιστώ αν ένας σύνδεσμος μπορεί να συνδεθεί με ένα σχήμα;**

Ελέγξτε την τιμή του [getConnectionSiteCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επικυρώστε τον επιλεγμένο δείκτη σημείου πριν το αναθέσετε σε κάποιο άκρο του συνδέσμου.

**Μπορώ να προσδιορίσω μια ρύθμιση συνδέσμου από τον δείκτη της συλλογής;**

Ένας δείκτης έχει νόημα μόνο για μια γνωστή προρύθμιση συνδέσμου και διάταξη συλλογής. Ελέγξτε το [IAdjustValue.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getType--) πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το [IAdjustValue.getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getName--) ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγραφεί;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί με άλλο σχήμα.

**Διατηρούνται οι συνδέσεις συνδέσμων όταν αντιγραφεί μια διαφάνεια;**

Οι συνδέσεις συνήθως διατηρούνται όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς ένα από τα σχήματα στόχους, το αντίστοιχο άκρο πρέπει να συνδεθεί ξανά.