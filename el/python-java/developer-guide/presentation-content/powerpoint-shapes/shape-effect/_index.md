---
title: Εφαρμογή Εφέ Σχημάτων στις Παρουσιάσεις Χρησιμοποιώντας Python μέσω Java
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/python-java/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προχωρημένα εφέ σχημάτων χρησιμοποιώντας Aspose.Slides for Python via Java—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να αναδείξουν ένα σχήμα, διαφέρουν από [συμπληρώσεις](/slides/el/python-java/shape-formatting/#gradient-fill) ή περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαστέλλετε τη λάμψη ενός σχήματος κ.λπ.

![Shape effect](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτόν τον λόγο, το PowerPoint παρέχει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι συνδυασμοί δύο ή περισσότερων εφέ που θεωρούνται καλές. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) που επιτρέπουν την εφαρμογή των ίδιων εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Σκιάς**

Το Aspose.Slides for Python via Java υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θόλωσης ώστε να ταιριάζουν με το σχεδιασμό της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να αναδείξετε μια κάρτα ή πίνακα ενάντια στο φόντο της διαφάνειας. Η σκιά εκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θόλωσης ώστε να ταιριάζουν με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εξωτερικό εφέ σκιάς](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) σε ένα ορθογώνιο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Shadow effect](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή πίνακα μια εσοχή. Μία εξωτερική σκιά εκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά χρωματίζει το εσωτερικό των άκρων του.

Καλέστε το [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), στη συνέχεια διαμορφώστε τη σκιά που επιστρέφεται από το [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Μεγαλύτερες τιμές ακτίνας θόλωσης παράγουν πιο απαλές άκρες.

Αυτό το παράδειγμα Python δημιουργεί μια ανοιχτό-μπλε κάρτα με σκούρο γκρι εσωτερική σκιά και το αποθηκεύει ως αρχείο PPTX. Η κατεύθυνση της σκιάς είναι 225 μοίρες, η απόστασή της είναι 7 points και η ακτίνα θόλωσης είναι 6 points:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Ανοιχτό μπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) στο effect format του σχήματος.

### **Εφαρμογή, Αλλαγή και Κατάργηση Preset Σκιάς**

Καλέστε το [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), στη συνέχεια χρησιμοποιήστε το [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) για να επιλέξετε ένα [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Για να αλλάξετε στυλ, αλλάξτε το preset στο ίδιο σχήμα. Καλέστε το [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) για να αφαιρέσετε τη σκιά διατηρώντας το γέμισμα και το περίγραμμα.

Το παράδειγμα κλωνοποιεί το ορθογώνιο σε κάθε στάδιο ώστε να μπορείτε να συγκρίνετε και τις τέσσερις καταστάσεις πλάι-πλάι σε μια διαφάνεια. Και οι δύο σκιές μετατοπίζονται κατά 10 points. Μία κατεύθυνση 225° τοποθετεί την πρώτη σκιά πάνω και προς τα αριστερά του ορθογωνίου. Μία κατεύθυνση 45° τοποθετεί τη δεύτερη κάτω και προς τα δεξιά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Αρχικό | Πρώτη προεπιλογή | Δεύτερη προεπιλογή | Μετά την αφαίρεση |
| :---: | :---: | :---: | :---: |
| ![Χωρίς σκιά](preset_shadow_original.png) | ![Σκιά Πάνω Αριστερά](preset_shadow_top_left.png) | ![Σκιά Κάτω Δεξιά](preset_shadow_bottom_right.png) | ![Χωρίς σκιά μετά την αφαίρεση](preset_shadow_removed.png) |

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides for Python via Java, μπορείτε να προσθέσετε μια καθρεφτική αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως απόσταση, διαφάνεια και μέγεθος. Αυτό το εφέ βελτιώνει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο γυαλιστερή και κομψή εμφάνιση. Είναι εύκολο να υλοποιηθεί με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για συνεπές σχέδιο.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ αντανάκλασης](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Εφέ αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides for Python via Java, μπορείτε να προσθέσετε μια ήπια, λαμπερή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να αναδειχθούν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο να υλοποιηθεί με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ λάμψης](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Εφέ λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides for Python via Java, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις ακμές ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχεδιασμούς που απαιτούν ένα ήπιο, πιο απαλό φινίρισμα. Μπορείτε εύκολα να προσαρμόσετε παραμέτρους όπως η ακτίνα για να πετύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα της παρουσίασής σας.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ μαλακών άκρων](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Εφέ μαλακών άκρων](soft_edges_effect.png)

## **Εφαρμογή Εφέ Θόλωσης**

Χρησιμοποιήστε το θόλωμα σχήματος για να μαλακώσετε το γέμισμα και το περίγραμμα ενός σχήματος ενώ παραμένετε επεξεργάσιμο. Καλέστε το [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) στο effect format του σχήματος. Η ακτίνα μετράται σε points (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, με μεγαλύτερες τιμές να παράγουν πιο έντονο θόλωμα. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ελέγχει τα ορατά όρια του εφέ. Με `False`, το θόλωμα περικόπτεται στα αρχικά ζωγραφισμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `True`, το θόλωμα μπορεί να εκτείνεται πέρα από αυτά τα όρια. Καμία από τις ρυθμίσεις δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η παρακάτω σύγκριση χρησιμοποιεί το ίδιο γέμισμα, περίγραμμα και διαστάσεις σχήματος καθ' όλη τη διάρκεια. Η επάνω σειρά χρησιμοποιεί `grow = False`; η κάτω σειρά χρησιμοποιεί `grow = True`.

![Αρχικό ορθογώνιο συγκριμένο με ακτίνες θόλωσης 5 και 15 points, με το grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα Python δημιουργεί ένα πορτοκαλί ορθογώνιο με σκούρο μπλε περίγραμμα, εφαρμόζει θόλωμα 5 points και στη συνέχεια το ενημερώνει σε θόλωμα 15 points καλώντας ξανά το [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Αποθηκεύει και τις δύο καταστάσεις με θόλωμα, στη συνέχεια καλεί το [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) και αποθηκεύει το σχήμα χωρίς θόλωμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το θόλωμα σχήματος επηρεάζει ταυτόχρονα το γέμισμα και το περίγραμμα. Ένα εφέ μαλακών άκρων εξομαλύνει τις άκρες του σχήματος, ενώ το θόλωμα σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωμα απευθείας στο effect format του σχήματος χωρίς μετατροπή του σχήματος σε εικόνα.

## **FAQ**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE κ.ά.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.