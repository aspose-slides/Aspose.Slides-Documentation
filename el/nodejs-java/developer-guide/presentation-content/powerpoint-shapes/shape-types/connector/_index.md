---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/nodejs-java/connector/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, συνδέετε, επαναδρομολογείτε, ρυθμίζετε και ελέγχετε ευθείς, λυγμένους και καμπυλωτούς συνδέσμους PowerPoint με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μια γραμμή που μπορεί να παραμένει συνδεδεμένη σε δύο σχήματα όταν το ένα από τα σχήματα κινείται. Τα άκρα του συνδέονται σε σημεία σύνδεσης, που αναπαρίστανται από πράσινα σημεία στο PowerPoint. Ορισμένοι λυγμένοι και καμπυλωτοί σύνδεσμοι εκθέτουν επίσης σημεία ρύθμισης, που αναπαρίστανται από πορτοκαλί σημεία, τα οποία ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Το Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της κλάσης [Connector](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/). Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους σε σχήματα, να επιλέξετε σημεία σύνδεσης, να τα επαναδρομολογήσετε και να τροποποιήσετε τη γεωμετρία των συνδέσμων που διαθέτουν σημεία ρύθμισης.

## **Τύποι Συνδέσμων**

Η κλάση [ShapeType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapetype/) περιλαμβάνει προεπιλεγμένα ευθείς, λυγμένους και καμπυλωτούς συνδέσμους. Ο παρακάτω πίνακας δείχνει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό των σημείων ρύθμισης που ορίζονται από κάθε προεπιλογή.

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

Ο αριθμός και η σημασία των σημείων ρύθμισης αποτελούν μέρος της επιλεγμένης προεπιλογής του συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμων εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε το [ShapeCollection.addConnector](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/addconnector/) για να προσθέσετε έναν σύνδεσμο και τα [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) και [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) για να συνδέσετε τα άκρα του. Αφού συνδεθούν και τα δύο άκρα, το [Connector.reroute](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/reroute/) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο με έναν λυγμένο σύνδεσμο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Προειδοποίηση" %}}
Η κλήση του `reroute` μπορεί να αλλάξει τις τιμές των [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) και [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Αναθέστε συγκεκριμένα σημεία σύνδεσης μετά την επαναδρομολόγηση εάν αυτά τα σημεία πρέπει να παραμείνουν σταθερά.
{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε σχήμα που μπορεί να συνδεθεί αναφέρει τον αριθμό των σημείων του μέσω του [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Επικυρώστε έναν προτιμώμενο δείκτη μηδενικής βάσης πριν τον αναθέσετε σε άκρο συνδέσμου· οι μετρήσεις των σημείων διαφέρουν ανάλογα με τη γεωμετρία του σχήματος.

Αυτό το παράδειγμα συνδέει τον σύνδεσμο με ένα συγκεκριμένο σημείο στην έλλειψη όταν αυτό το σημείο υπάρχει:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ρύθμιση Σημείου Συνδέσμου**

Οι σύνδεσμοι που διαθέτουν σημεία ρύθμισης τα εκθέτουν μέσω του [GeometryShape.getAdjustments](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/geometryshape/). Εξετάστε κάθε [AdjustValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/) και ελέγξτε την τιμή του [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/) πριν την αλλάξετε με το [setRawValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Οι γενικοί κανόνες για την αναγνώριση προεπιλεγμένων ρυθμίσεων σχήματος περιγράφονται στην ενότητα [Shape Manipulation](/slides/el/nodejs-java/shape-manipulations/).

Ο αριθμός, η σειρά, η σημασία και το έγκυρο εύρος τιμών των ρυθμίσεων συνδέσμου εξαρτώνται από την προεπιλογή του συνδέσμου. Ο τύπος της ρύθμισης είναι μόνο για ανάγνωση, ενώ η τιμή της ρύθμισης είναι εγγράψιμη. Η μέθοδος μόνο για ανάγνωση [getName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/getname/) παρέχει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερα από ένα σημεία ίδιας σημασιολογικής κατηγορίας.

### **Δρομολόγηση γύρω από Εμπόδιο**

Στην παρακάτω διάταξη, ένας σύνδεσμος `BentConnector5` μεταξύ δύο σχημάτων περνά μέσα από τρίτο σχήμα:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμποδισμένο σύνδεσμο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μετακίνηση του κάθετου λυγμού αλλάζει τη διαδρομή ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης συλλογής `1` αντιπροσωπεύει πάντα τον κάθετο λυγμό, αυτό το παράδειγμα ψάχνει για `ConnectorBendPositionY` και το αλλάζει μόνο όταν υπάρχει ο αναμενόμενος σημασιολογικός τύπος:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ένας `BentConnector5` έχει δύο ρυθμίσεις `ConnectorBendPositionX` και μία ρύθμιση `ConnectorBendPositionY`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, ελέγξτε το `getName` και τη γνωστή γεωμετρία της προεπιλογής πριν επιλέξετε μία. Εάν μια ρύθμιση επιστρέφει `ShapeAdjustmentType.Custom`, αντιμετωπίστε τη σημασία και το εύρος της ως προεπιλογή‑συγκεκριμένα και μην την αλλάξετε μέχρι να γνωρίζετε τη σύμβαση.

## **Συσχέτιση Τιμών Ρύθμισης με Γεωμετρία Συνδέσμου**

Για λυγμένους συνδέσμους, οι τιμές ρύθμισης μπορούν να χρησιμοποιηθούν για την εκτίμηση των θέσεων των μεμονωμένων τμημάτων. Αυτοί οι υπολογισμοί είναι ειδικοί για την προεπιλογή του συνδέσμου:

- Το `BentConnector4` συνήθως εκθέτει μία ρύθμιση `ConnectorBendPositionX` και μία `ConnectorBendPositionY`.
- Για αυτές τις θέσεις λυγμού, η διαίρεση της τιμής που επιστρέφει το `getRawValue` με `100000` παράγει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παραδείγματα παρακάτω.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αναστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετασχηματιστούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το `getType` για την αρχική ταυτοποίηση των ρυθμίσεων. Δεν θεωρούν τους δείκτες συλλογής ως φορητούς αναγνωριστικούς.

### **Απροστροφικός Σύνδεσμος**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με έναν `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει τον σύνδεσμο και λαμβάνει τις οριζόντιες και κάθετες ρυθμίσεις λυγμού:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Για να αλλάξετε και τους δύο λυγμούς, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού βρεθούν και οι δύο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα είναι ένας σύνδεσμος του οποίου τα οριζόντια και κάθετα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Αυτό το παράδειγμα σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κάθετο τμήμα που ελέγχεται από τις δύο ρυθμίσεις λυγμού:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Το σχήμα οδηγού σημειώνει το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Αντιστραμμένος Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου είναι προσανατολισμένη κάθετα, οι τιμές [Shape.getFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/getfliph/) και [ShapeFrame.getFlipV](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/getflipv/) επηρεάζουν τη μετατροπή από τις συντεταγμένες πλαισίου συνδέσμου σε συντεταγμένες διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κάθετα προσανατολισμένο σύνδεσμο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο ρυθμισμένος σύνδεσμος εμφανίζεται κάθετα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για οποιαδήποτε γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου‑συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας χειρίζεται τον προσανατολισμό 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ο κόκκινος οδηγός σημειώνει το υπολογισμένο τμήμα μετά τον μετασχηματισμό των συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επικυρώστε τους τύπους ρύθμισης, τον προσανατολισμό του πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθύ συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, με τις οριζόντιες και κάθετες αντιστροφές να έχουν εφαρμοστεί. Το παρακάτω παράδειγμα αναφέρει τη δεξιόστροφη γωνία από τον θετικό οριζόντιο άξονα σε συντεταγμένες διαφάνειας:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να συνδεθεί σε ένα σχήμα;**

Ελέγξτε την τιμή [getConnectionSiteCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getconnectionsitecount/) του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επικυρώστε τον επιλεγμένο δείκτη σημείου πριν τον αναθέσετε σε κάποιο άκρο του συνδέσμου.

**Μπορώ να προσδιορίσω μια ρύθμιση συνδέσμου με τον δείκτη της συλλογής;**

Ένας δείκτης είναι σημαντικός μόνο για μια γνωστή προεπιλογή συνδέσμου και διάταξη συλλογής. Ελέγξτε το [AdjustValue.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/) πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το [AdjustValue.getName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/getname/) ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν το σχήμα που είναι συνδεδεμένο διαγράψεται;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί ξανά σε άλλο σχήμα.

**Διατηρούνται οι συνδέσεις του συνδέσμου όταν αντιγράψουμε μια διαφάνεια;**

Οι συνδέσεις διατηρούνται κατά κανόνα όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς κάποιο από τα σχήματα-στόχους, το επηρεασμένο άκρο πρέπει να συνδεθεί ξανά.