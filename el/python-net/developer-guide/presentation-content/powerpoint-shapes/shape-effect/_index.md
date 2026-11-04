---
title: Εφαρμογή Εφέ Σχημάτων σε Παρουσιάσεις με Python
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/python-net/shape-effect
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT, PPTX και ODP σας με προηγμένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για Python—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να αναδείξουν ένα σχήμα, διαφέρουν από τα [γεμίσματα](/slides/el/python-net/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαχέετε τη λάμψη ενός σχήματος, κ.λπ.

![Εφέ Σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτόν το λόγο, το PowerPoint διαθέτει επιλογές στο **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας καλά δοκιμασμένος συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να χάνετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Το Aspose.Slides for Python μέσω .NET υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζει με το σχέδιο της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή ένα πάνελ να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά εκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Προσαρμόστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζει με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ εξωτερικής σκιάς](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) σε ένα ορθογώνιο:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Εφέ Σκιάς](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή ένα πάνελ μια εσομένη εμφάνιση. Μια εξωτερική σκιά εκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά χρωματίζει το εσωτερικό των άκρων του.

Καλέστε το [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), στη συνέχεια ρυθμίστε το [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Οι μεγαλύτερες τιμές της ακτίνας θολώματος παράγουν πιο απαλές άκρες.

Αυτό το παράδειγμα Python δημιουργεί μια ανοιχτόμουρφη κάρτα με σκούρο γκρι εσωτερική σκιά και την αποθηκεύει ως αρχείο PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Ανοιχτόμπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) στο format εφέ του σχήματος.

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides for Python μέσω .NET, μπορείτε να προσθέσετε μια καθρεφτική αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο γυαλιστερή και εκλεπτυσμένη εμφάνιση. Είναι εύκολο να υλοποιηθεί με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για ένα συνεπές σχέδιο.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ αντανάκλασης](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) σε ένα σχήμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Εφέ Αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides for Python μέσω .NET, μπορείτε να προσθέσετε μια ήπια, φωτεινή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο να υλοποιηθεί με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το [εφέ λάμψης](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) σε ένα σχήμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Εφέ Λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides for Python μέσω .NET, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχεδιασμούς που απαιτούν μια ήπια, πιο απαλή εμφάνιση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να επιτύχετε το επιθυμητό εφέ σε διάφορα σχήματα στην παρουσίασή σας.

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε τις [μαλακές άκρες](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) σε ένα σχήμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Εφέ Μαλακών Άκρων](soft_edges_effect.png)

## **Εφαρμογή Εφέ Θολώματος**

Χρησιμοποιήστε το θόλωση σχήματος για να μαλακώσετε τη γέμιση και το περίγραμμα ενός σχήματος ενώ το διατηρείτε επεξεργάσιμο. Καλέστε το [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) στο format εφέ του σχήματος. Η ακτίνα μετράται σε πόντους (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, όπου οι μεγαλύτερες τιμές παράγουν πιο έντονη θόλωση. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) ελέγχει τα εμφανή όρια του εφέ. Με `False`, η θόλωση περιορίζεται στα αρχικά ζωγραφισμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `True`, η θόλωση μπορεί να επεκταθεί πέρα από αυτά τα όρια. Καμία από τις ρυθμίσεις δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η σύγκριση παρακάτω χρησιμοποιεί την ίδια γέμιση, περίγραμμα και διαστάσεις σχήματος σε όλη τη διαδικασία. Η επάνω σειρά χρησιμοποιεί `grow = False`; η κάτω σειρά χρησιμοποιεί `grow = True`.

![Αρχικό ορθογώνιο συγκριμένο με ακτίνες θόλωσης 5 και 15 πόντων, με το grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα Python δημιουργεί ένα πορτοκαλί ορθογώνιο με σκούρο μπλε περίγραμμα, εφαρμόζει μια θόλωση 5 πόντων και στη συνέχεια την ενημερώνει σε θόλωση 15 πόντων καλώντας ξανά το [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Αποθηκεύει και τις δύο καταστάσεις θόλωσης, έπειτα καλεί το [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) και αποθηκεύει το σχήμα χωρίς θόλωση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Η θόλωση σχήματος επηρεάζει ταυτόχρονα τη γέμιση και το περίγραμμα. Ένα εφέ μαλακών άκρων εξασθενίζει τις άκρες του σχήματος, ενώ η θόλωση σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωση άμεσα στο format εφέ του σχήματος χωρίς να μετατρέπει το σχήμα σε εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλα.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.