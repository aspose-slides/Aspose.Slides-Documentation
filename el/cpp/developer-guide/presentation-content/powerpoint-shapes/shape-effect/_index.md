---
title: Εφαρμογή εφέ σχήματος σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/cpp/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ ανάκλασης
- εφέ λάμψης
- εφέ απαλών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προηγμένα εφέ σχήματος χρησιμοποιώντας Aspose.Slides για C++ — δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να αναδείξουν ένα σχήμα, διαφέρουν από [συμπλήρωση](/slides/el/cpp/shape-formatting/#gradient-fill) ή περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διασπείρετε το λαμπάδισμα ενός σχήματος, κ.λπ.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* Το PowerPoint προσφέρει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.  

* Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτόν τον λόγο, οι επιλογές του PowerPoint κάτω από **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας γνωστός καλός συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να χάνετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.effect_format/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ στα σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή εφέ σκιάς**

Αυτός ο κώδικας C++ σας δείχνει πώς να εφαρμόσετε το εξωτερικό εφέ σκιάς ([OuterShadowEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) σε ένα ορθογώνιο:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Εφαρμογή εφέ ανάκλασης**

Αυτός ο κώδικας C++ σας δείχνει πώς να εφαρμόσετε το εφέ ανάκλασης σε ένα σχήμα:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **Εφαρμογή εφέ λάμψης**

Αυτός ο κώδικας C++ σας δείχνει πώς να εφαρμόσετε το εφέ λάμψης σε ένα σχήμα:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **Εφαρμογή εφέ απαλών άκρων**

Αυτός ο κώδικας C++ σας δείχνει πώς να εφαρμόσετε τα απαλά άκρα σε ένα σχήμα:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, ανάκλαση και λάμψη, σε ένα ενιαίο σχήμα για να δημιουργήσετε πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλων.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.