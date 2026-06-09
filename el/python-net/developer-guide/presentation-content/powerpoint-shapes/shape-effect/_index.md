---
title: "Εφαρμογή Εφέ Σχήματος σε Παρουσιάσεις με Python"
linktitle: "Εφέ Σχήματος"
type: docs
weight: 30
url: /el/python-net/shape-effect
keywords:
- "εφέ σχήματος"
- "εφέ σκιάς"
- "εφέ αντανακλαστικού"
- "εφέ λάμψης"
- "εφέ μαλακών άκρων"
- "μορφή εφέ"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Μετασχηματίστε τα αρχεία PPT, PPTX και ODP σας με εξελιγμένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για Python—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε λίγα δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνετε ένα σχήμα να ξεχωρίζει, διαφέρουν από τις [fill](/slides/el/python-net/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να εξαπλώσετε το φως ενός σχήματος κ.λπ.

<img src="shape-effect.png" alt="σχήμα-εφέ" style="zoom:50%;" />

* Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.  
* Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτόν τον λόγο, υπάρχουν επιλογές PowerPoint κάτω από **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας γνωστός καλός συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν χρειάζεται να χάνετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Η Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Σκιώδους Εφέ**

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το εξωτερικό σκιώδες εφέ (`outer_shadow_effect`) σε ένα ορθογώνιο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή Αντανακλαστικού Εφέ**

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το αντανακλαστικό εφέ σε ένα σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή Εφέ Λάμψης**

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ λάμψης σε ένα σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Αυτός ο κώδικας Python δείχνει πώς να εφαρμόσετε τα μαλακά άκρα σε ένα σχήμα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκίαση, αντανακλαστικό και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλα.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.