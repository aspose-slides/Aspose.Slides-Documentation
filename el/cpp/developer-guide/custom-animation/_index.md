---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε C++
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/cpp/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- μονοπάτι κίνησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε, εξετάστε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμα μονοπάτια κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες εντός ενός εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή ενός σχήματος ή η ακολουθία ενός επεξεργάσιμου μονοπατιού κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργείτε και να συνδυάζετε συμπεριφορές, να διαμορφώνετε το χρονοδιάστημα τους, να ελέγχετε και να τροποποιείτε υπάρχουσες κινήσεις και να επαληθεύετε ότι οι ιδιότητές τους διατηρούνται κατά την αποθήκευση και το άνοιγμα ξανά μιας παρουσίασης.

Για προεγκατεστημένα εφέ και ενεργοποιητές κλικ, δείτε [Κίνηση Σχήματος](/slides/el/cpp/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Η διαφάνεια περιέχει το [get_Timeline](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_timeline/) της, το οποίο περιλαμβάνει την κύρια ακολουθία και τις διαδραστικές ακολουθίες.
- Μία [ISequence](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/) περιέχει εφέ, πιθανόν με διαφορετικά σχήματα-στόχους.
- Μία [IEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/) προσδιορίζει το σχήμα-στόχο, το preset, το υποτύπο και το χρονοδιάστημα του εφέ.
- Η [IEffect::get_Behaviors](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_behaviors/) περιέχει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κ.ά.

## **Δημιουργία Ατομικών Συμπεριφορών**

Καλέστε το [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/) για να δημιουργήσετε ένα εφέ και να αποκτήσετε πρόσβαση στη συλλογή [get_Behaviors](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_behaviors/) του. Ένα preset μπορεί να γεμίσει αυτή τη συλλογή αυτόματα. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το preset ή χρησιμοποιήστε [Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/clear/) όταν τις αντικαθιστάτε σκόπιμα.

[IBehaviorFactory](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφορών που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στο [Δημιουργία Μονοπατιού Κίνησης](#build-a-motion-path). Κάθε παράδειγμα δημιουργίας είναι αυτόνομος κώδικας που εκτελείται μέσα σε μια συνάρτηση· αργότερα τα παραδείγματα επεξεργασίας αναφέρουν ποιο αρχείο εξόδου χρησιμοποιούν.

### **Περιστροφή**

Χρησιμοποιήστε το [CreateRotationEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) για να δημιουργήσετε μια περιστροφή. Η [get_By](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/irotationeffect/get_by/) καθορίζει μια σχετική γωνία σε μοίρες· οι [get_From](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/irotationeffect/get_from/) και [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/irotationeffect/get_to/) ορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεγκατεστημένες λειτουργίες του με μία συμπεριφορά περιστροφής και ορίζει σε αυτήν διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει ένα τέταρτο στροφής από την αρχική προσανατολισμένη θέση του σχήματος, οπότε δεν απαιτείται ρητή αρχική γωνία.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, το χρονοδιάστημα και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [CreateScaleEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) με ποσοστά X/Y: οι [get_From](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/iscaleeffect/get_from/) και [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/iscaleeffect/get_to/) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ η [get_By](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/iscaleeffect/get_by/) αναφέρεται σε σχετική αλλαγή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100% σε 125% σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κάθετων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν τη μία διάσταση περισσότερο από την άλλη.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Χρώμα**

Χρησιμοποιήστε το [CreateColorEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) για να αλλάξετε τη γέμιση από μπλε σε πορτοκαλί. Οι [get_From](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icoloreffect/get_from/) και [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icoloreffect/get_to/) είναι χρώματα· η [get_By](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icoloreffect/get_by/) είναι μια απόκλιση χρώματος. Η [IBehavior::get_Properties](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehavior/get_properties/) προσδιορίζει το χαρακτηριστικό που κινείται.

Η συμπαγής γέμιση του σχήματος αρχικοποιείται σε μπλε, ώστε να ταιριάζει με το αρχικό χρώμα του εφέ. Η επιλογή του χαρακτηριστικού γέμισης λέει στη συμπεριφορά ποιο μέρος του σχήματος θα αλλάξει· τα άκρα του χρώματος από μόνα τους δεν προσδιορίζουν το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια διώροφη μετάβαση σε πορτοκαλί.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Φίλτρο**

Χρησιμοποιήστε το [CreateFilterEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) για να επιλέξετε ένα wipe. Οι [get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) και [get_Reveal](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) καθορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλύψει ή θα κρύψει το σχήμα.

Αυτό το παράδειγμα διαμορφώνει ένα διώροφο wipe που αποκαλύπτει το σχήμα χρησιμοποιώντας τον υποτύπο δεξιάς κατεύθυνσης. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, οπότε ρυθμίζονται αφού αφαιρεθούν οι αρχικές λειτουργίες του preset.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ιδιότητα**

Χρησιμοποιήστε το [CreatePropertyEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) για να κινήσετε την αδιαφάνεια. Οι [get_From](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ipropertyeffect/get_to/) και [get_By](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ipropertyeffect/get_by/) είναι συμβολοσειρές που ερμηνεύονται με τη [get_ValueType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) και τη [get_CalcMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Επιλέξτε άκρα ή σχετική απόκλιση αντί να ορίζετε και τα τρία αδιάφορα.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η αδιαφάνεια και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν μια αλλαγή από 25 % αδιαφάνειας σε πλήρη αδιαφάνεια. Η γραμμική παρεμβολή περιγράφει μια σταδιακή μεταβολή μεταξύ των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε κάποιο άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες σε αυτό το χαρακτηριστικό.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ορισμός**

Χρησιμοποιήστε το [CreateSetEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) για να ορίσετε την ορατότητα μέσω του [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/iseteffect/get_to/). Μια συμπεριφορά set δεν παρεμβάλλει μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και ορίζει τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Στο C++ η συμβολοσειρά πρέπει να εμπτυχθεί ως αντικείμενο πριν την εκχωρήσετε στη συμπεριφορά set. Το ορθογώνιο είναι ήδη ορατό σε αυτήν τη μινιμαλιστική παρουσίαση, έτσι η εκχώρηση μπορεί να μην προκαλέσει εμφανή οπτική αλλαγή από μόνη της. Μια τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα γίνεται κρυφό ή ορατό.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Εντολή**

Χρησιμοποιήστε το [CreateCommandEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) και διαμορφώστε τις [get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) και [get_ShapeTarget](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Τοποθετήστε μια ηχογράφηση WAV με όνομα `sample.wav` στον κατάλογο εργασίας. Αυτό το παράδειγμα την ενσωματώνει με το [AddAudioFrameEmbedded](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) και προσθέτει μια εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι τόσο ο στόχος του εφέ όσο και του εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια συμβολοσειρά εντολής από μόνη της δεν προσδιορίζει ποιο πολυμέσο θα ελεγχθεί. Το εφέ ρυθμίζεται να ξεκινήσει με κλικ κατά την παρουσίαση.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί έναν προβολέα παρουσίασης που υποστηρίζει την εντολή και το πολυμέσο-στόχο της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

[IBehaviorCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/) υποστηρίζει τις μεθόδους [Add](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/remove/), και [RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του αποθηκευμένου στοιχείου χωρίς να δημιουργεί αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή και, τελικά, μόνο σε κλιμάκωση. Οι δείκτες αναφέρονται στη τρέχουσα συλλογή, έτσι η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την επαναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Το αποτέλεσμα είναι `ScaleEffect`: παραμένει μόνο η κλιμάκωση. Η σειρά της συλλογής από μόνη της δεν προγραμματίζει τις συμπεριφορές η μία μετά την άλλη. Καθαρίστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Διαμόρφωση Χρονοδιαγράμματος Συμπεριφοράς**

[IBehavior::get_Timing](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehavior/get_timing/) εκθέτει το [ITiming](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/), ανεξάρτητα από το [IEffect::get_Timing](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_timing/). Το χρονοδιάστημα του εφέ προγραμματίζει το περιβάλλον εφέ· το χρονοδιάστημα της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τις μεθόδους [get_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_duration/) και [get_TriggerDelayTime](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) (σε δευτερόλεπτα), έπειτα διαμορφώστε το [get_RepeatCount](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_repeatcount/). Τα [get_Accelerate](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_accelerate/) και [get_Decelerate](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_decelerate/) είναι κλάσματα της διάρκειας· διατηρήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι αυτό που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστό ότι είναι περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονοδιάστημα εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διατήρηση της γωνίας και του χρονοδιαγράμματος ξεχωριστά καθιστά ευκολότερη τη ρύθμιση του ρυθμού χωρίς να χρειάζεται επανασυγγραφή της κίνησης.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και επανάληψη 3 φορές. Το πρώτο και το τελευταίο 20 % της διάρκειας χρησιμοποιείται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν [get_RepeatDuration](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), και [get_RepeatUntilNextClick](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/). Επιλέξτε μία πολιτική αντί να τις ενεργοποιείτε όλες μαζί. Η [get_AutoReverse](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/get_autoreverse/) παίζει την κίνηση ανάποδα μετά το μπροστινό πέρασμα. Η επιτάχυνση και η επιβράδυνση ισχύουν για συνεχή μεταβολή, όχι για διακριτές εκχωρήσεις ή εντολές.

## **Δημιουργία Μονοπατιού Κίνησης**

Χρησιμοποιήστε το [CreateMotionEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) για να δημιουργήσετε κίνηση. Οι [get_From](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_to/), και [get_By](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_by/) περιγράφουν συντεταγμένες ή μετατοπίσεις βάσει ποσοστών. Για επεξεργάσιμο μονοπάτι, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/motionpath/) και αναθέστε το στο [IMotionEffect::get_Path](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_path/). Η [IMotionPath](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotionpath/) αποθηκεύει τις εντολές του μονοπατιού.

[MotionCommandPathType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/motioncommandpathtype/) επιλέγει τη λειτουργία:

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MoveTo | One | Ορίζει τη θέση έναρξης. |
| LineTo | One | Μετακινεί κατά ευθεία γραμμή μέχρι το άκρο της. |
| CurveTo | Three | Ακολουθεί μια κυβική καμπύλη ορισμένη από δύο σημεία ελέγχου και ένα άκρο. |
| CloseLoop | None | Επιστρέφει στη θέση έναρξης. |
| End | None | Ολοκληρώνει το μονοπάτι. |

[MotionPathPointsType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασίας σημείων, όπως γωνιακά ή λείες κορυφές. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω και τύπο σημείου γωνίας για τα ευθεία τμήματα.

Οι συντεταγμένες του μονοπατιού κανονικοποιούνται ως ποσοστά διαστάσεων της διαφάνειας: μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 μονάδες. Το θετικό Y τρέχει προς τα κάτω. Οι απόλυτες εντολές ορίζουν θέσεις στο σύστημα συντεταγμένων του μονοπατιού· οι σχετικές εντολές ορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [get_Origin](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_origin/), που επιλέγει το πλαίσιο αναφοράς του μονοπατιού, και το [get_PathEditMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), που ελέγχει πώς το μονοπάτι κινείται όταν το σχήμα κινείται.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο έναρξης, ένα ευθύ τμήμα και μία εντολή τερματισμού. Η [IMotionPath::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotionpath/add/) λαμβάνει τον τύπο εντολής, τα σημεία του, τον τύπο σημείου και μια σημαία σχετικής συντεταγμένης.

Η εντολή έναρξης ορίζει (0, 0), και η γραμμή τελειώνει στο (0.25, 0), δίνοντας στο μονοπάτι οριζόντια μετατόπιση του ενός τέταρτου του πλάτους της διαφάνειας. Η εντολή τερματισμού δεν έχει σημεία. Μόλις το μονοπάτι ανατεθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές μονοπατιού. Τα παρακάτω παραδείγματα επεξεργασίας αρχείων χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα μονοπατιού περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή τελειώνει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στη τρέχουσα θέση, δηλαδή (0.2, 0).

Και τα δύο μονοπάτια ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τα X και Y offset στη τρέχουσα θέση για να βρείτε το άκρο· για την απόλυτη γραμμή, διαβάστε το άκρο απευθείας. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιγράψει διαφορετική διαδρομή.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Αναθέστε το ένα ή το άλλο μονοπάτι σε μια συμπεριφορά κίνησης για να το χρησιμοποιήσετε στην παρουσίαση. Το τελικό λογικό όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής του με μια κυβική καμπύλη. Παρέχετε πρώτα τα δύο σημεία ελέγχου, στη συνέχεια το άκρο.

Η θέση έναρξης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι το τελικό της προορισμού· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων ταυτοχρόνως διατηρεί το τμήμα συνεπές με τη νέα γεωμετρία του.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Το μονοπάτι στο `curve.pptx` διατηρεί τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Επιθεώρηση και Επεξεργασία Αποθηκευμένου Μονοπατιού**

Κάθε [IMotionCmdPath](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioncmdpath/) εκθέτει τα [get_Points](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), και [get_IsRelative](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Τα παρακάτω παραδείγματα χρησιμοποιούν το γνωστό μονοπάτι τριών εντολών στο `motion.pptx`. Για αυθαίρετη είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τον αριθμό σημείων πριν την επεξεργασία με δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε το μονοπάτι χωρίς αλλαγές. Οι εντολές End και CloseLoop δεν χρειάζονται σημεία, έτσι επιτρέψτε έναν null πίνακα σημείων.

Η έξοδος αντιστοιχίζει κάθε εντολή με τη σημαία σχετικής συντεταγμένης πριν απαριθμήσει τα σημεία της. Αυτό σας επιτρέπει να διακρίνετε ένα άκρο από μια μετατόπιση πριν τροποποιήσετε το μονοπάτι. Μια καμπύλη θα εμφανίσει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο εμφανίζει μόνο ένα.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Η λίστα περιλαμβάνει σημείο έναρξης, απόλυτη γραμμή που τελειώνει στο (0.25, 0) και εντολή τερματισμού.

### **Αλλαγή Άκρου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να μετακινήσετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή έναρξης και ο δείκτης 1 η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό της χωρίς να αλλάζει τον τύπο εντολής, το χρονοδιάστημα ή τη θέση στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτές συντεταγμένες, το νέο ζεύγος καθορίζει θέση και όχι πρόσθετη μετατόπιση.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Η γραμμή στο `motion-endpoint.pptx` τελειώνει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμήματος**

Χρησιμοποιήστε τις μεθόδους [Insert](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotionpath/insert/) και [RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/imotionpath/removeat/) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετατοπίζει την παλιά γραμμή στο δείκτη 2.

Αυτό δείχνει την αντικατάσταση ενός αντικειμένου εντολής αντί για την επεξεργασία των υπάρχουσων συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την εντολή έναρξης, τη νέα γραμμή, την παλιά γραμμή και την εντολή τερματισμού. Η αφαίρεση του δείκτη 2 διαγράφει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Το αποθηκευμένο μονοπάτι διατηρεί τρεις εντολές, με τη νέα γραμμή να τελειώνει στο (0.2, 0.1) και την εντολή τερματισμού στο τέλος.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν δεν γνωρίζετε το δείκτη της συμπεριφοράς, επιλέξτε την κατά τύπο. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, βρίσκει το [IRotationEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/irotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά το άνοιγμα ξανά.

Ο έλεγχος τύπου επιτρέπει στην βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Η δεύτερη φόρτωση διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, έτσι η σύγκριση ελέγχει τα δεδομένα που έχουν παραμείνει, όχι τις τιμές που παραμένουν στη μνήμη. Αυτό το παράδειγμα υποθέτει ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς κατά τύπο δεν εντοπίζει το σωστό εφέ σε αυθαίρετη παρουσίαση.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Η έξοδος είναι `Rotation preserved: True`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου και σε άλλες συμπεριφορές. Για πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα-στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρονοδιάστημα και τις εντολές του μονοπατιού. Χρησιμοποιήστε αριθμητική ανοχή για δεκαδικές τιμές. Για παρουσίαση με άγνωστη διάταξη κινήσεων, δείτε [Read Shape Animations](/slides/el/cpp/shape-animation/#read-shape-animations) για τη διεξαγωγή των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Presets και Αναπαραγωγή**

Η σειρά στο [IBehaviorCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής στην οποία κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Το χρονοδιάστημα και το περιβάλλον εφέ καθορίζουν τον προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται και οι λειτουργίες στο ίδιο χαρακτηριστικό μπορεί να αλληλεπιδρούν μέσω των [get_Additive](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehavior/get_additive/) και [get_Accumulate](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Μην χρησιμοποιείτε μόνο την επαναταξινόμηση της συλλογής για τον προγραμματισμό “μετακίνηση, μετά περιστροφή”· χρησιμοποιήστε ρητό χρονοδιάστημα ή ξεχωριστά εφέ όπως περιγράφεται στις [Κίνηση Σχήματος](/slides/el/cpp/shape-animation/).

Το [get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_type/) και το [get_Subtype](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_subtype/) του εφέ περιγράφουν το preset του. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δέντρου συμπεριφορών. Επιλέξτε το preset και τον υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του preset μπορεί να ξαναδημιουργήσει τη συλλογή και να διαγράψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Ελέγξτε ξανά τη συλλογή μετά την αλλαγή preset ή υποτύπου. Η εκκαθάριση των συμπεριφορών του preset μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που απαιτούνται από το preset. Τα παραδείγματα χρησιμοποιούν ορατά σχήματα και αντικαθιστούν τις συμπεριφορές· δεν ξαναδημιουργούν την υλοποίηση κάθε preset.

## **Συμβατότητα Μορφών**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται την ίδια αναπαραγωγή σε κάθε θεατή ή εξαγωγέα. Ελέγξτε ξεχωριστά τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα.

| Μορφή ή έξοδος | Τι πρέπει να ελεγχθεί |
| --- | --- |
| PPTX | Χρησιμοποιήστε ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε ξανά το αρχείο για να επαληθεύσετε το επεξεργάσιμο δέντρο συμπεριφορών, κατόπιν ελέγξτε την αναπαραγωγή στην προβλεπόμενη έκδοση του PowerPoint. |
| PPT | Η κληρονομική δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Δοκιμάστε έναν ξεχωριστό κύκλο αποθήκευσης-ανοίγματος και αναπαραγωγής· μην συμπεραίνετε υποστήριξη για κάθε προσαρμοσμένο συνδυασμό από την επιτυχία του PPTX. |
| PDF, PNG, JPEG, και άλλες στατικές εικόνες διαφανειών | Περιλαμβάνουν στατική απεικόνιση διαφάνειας, όχι μια αναγγέλυτη γραμμή χρόνου συμπεριφορών ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/cpp/export-to-html5/) | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στον περιηγητή. |
| [Animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/) | Αποθηκεύει αποδιδόμενα καρέ, όχι επεξεργάσιμες συμπεριφορές ή αλληλεπιδράσεις κλικ. Ελέγξτε το πραγματικό αποδιδόμενο κίνηση. |
| [Video](/slides/el/cpp/convert-powerpoint-to-video/) | Αποδίδει καρέ κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στις [supported animations and effects](/slides/el/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) του renderer· οι εντολές και τα διαδραστικά συμβάντα δεν γίνονται επεξεργάσιμο χρονοδιάγραμμα. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω καμία;**

Η δημιουργία ενός προεγκατεστημένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Ελέγξτε τις πριν αποφασίσετε αν θα επεκτείνετε το preset ή θα αντικαταστήσετε τις συμπεριφορές του.

**Κάνει η μετακίνηση μιας συμπεριφοράς στην αρχή το να παίζει πρώτη;**

Όχι απαραίτητα. Η σειρά της συλλογής δεν αντικαθιστά το χρονοδιάστημα. Ελέγξτε καθυστερήσεις, διάρκειες και αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί μια εντολή End δεν έχει σημεία;**

Δηλώνει το τέλος του μονοπατιού και δεν χρειάζεται συντεταγμένες. Ελέγξτε για null πίνακα σημείων όταν εξετάζετε μονοπάτι που διαβάζεται από αρχείο.

**Αρκεί ένας επιτυχής κύκλος αποθήκευσης-ανοίγματος για να επιβεβαιώσουμε την αναπαραγωγή;**

Όχι. Το άνοιγμα επαληθεύει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον προβολέα παρουσίασης ή την εξαγωγή animation ξεχωριστά για να επιβεβαιώσετε τη οπτική συμπεριφορά.