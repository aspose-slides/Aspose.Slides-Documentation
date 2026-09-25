---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε C++
linktitle: WordArt
type: docs
weight: 110
url: /el/cpp/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιάς
- εφέ ανάκλασης
- εφέ λάμψης
- μετασχηματισμός WordArt
- 3Δ εφέ
- εφέ εξωτερικής σκιάς
- εφέ εσωτερικής σκιάς
- C++
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides for C++. Αυτός ο βήμα-προς-βήμα οδηγός βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε C++."
---
## **Επισκόπηση**

Τα εφέ WordArt σάς επιτρέπουν να μορφοποιήσετε το κείμενο με γεμίσματα, περιγράμματα, σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for C++, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργήστε ένα Απλό Πρότυπο WordArt και Εφαρμόστε Το σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, το γεμίσιμο μοτίβου και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στην πρώτη της διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε μονάδες (points):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Ορίστε τη γραμματοσειρά σε Arial Black με μέγεθος 36 points για να γίνει η μορφοποίηση πιο εμφανής:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

Εφαρμόστε ένα μοτίβο [SmallGrid](https://reference.aspose.com/slides/el/cpp/aspose.slides/patternstyle/) με σκούρο πορτοκαλί πρώτο σχέδιο και λευκό φόντο, έπειτα προσθέστε μαύρο περίγραμμα κειμένου με πλάτος 1 point:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Το παραγόμενο κείμενο:

![The simple WordArt template](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόσετε σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D εφέ στο κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώματος, την κλίμακα και την κλίση της.

Αυτό το παράδειγμα καλεί [EnableOuterShadowEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) και ορίζει μια μαύρη σκιά με ακτίνα θολώματος 4 point, κατεύθυνση 230 μοίρες και απόσταση 30 point. Τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια κλίση την κλίνει κατά 20 μοίρες. Η μεταστροφή άλφα ορίζει τη διαφάνεια στο 32%:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Το παραγόμενο κείμενο:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται μαζί εξωτερικές και προκαθορισμένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Αν χρησιμοποιούνται ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το τελικό αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Μια αντανάκλαση δημιουργεί ένα καθρεπτικό αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, το θολώσιμο και τη διαφάνεια για να ελέγξετε την εμφάνισή του.

Αυτό το παράδειγμα καλεί [EnableReflectionEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) και κυλίει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώματος 0,5 point και απόσταση 4,72 point. Η διαφάνεια μειώνεται από 60% σε 0,9% μεταξύ των θέσεων 0% και 60% κατά μήκος της αντανάκλασης:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

Το παραγόμενο κείμενο:

![The Reflection effect](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Μια λάμψη προσθέτει ένα απαλό χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί [EnableGlowEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides/ieffectformat/enablegloweffect/) και εφαρμόζει κόκκινη λάμψη με διαφάνεια 54% και ακτίνα 7 points:

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Το παραγόμενο κείμενο:

![The Glow effect](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγώνουν, τεντώνονται ή παραμορφώνουν ένα μπλοκ κειμένου.

Ορίστε [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_transform/) σε [ArchUpPour](https://reference.aspose.com/slides/el/cpp/aspose.slides/textshapetype/) για να καμπυλώσετε όλο το πλαίσιο κειμένου προς τα πάνω:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Το παραγόμενο κείμενο:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for C++ παρέχει ένα σύνολο προ‑ορισμένων [transformation types](https://reference.aspose.com/slides/el/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3D εφέ σε ένα σχήμα ή στο κείμενό του. Οι ακμές, η εξώθηση, ο φωτισμός και οι ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/) για να προσθέσει κυκλικές ακμές, πορτοκαλί εξώθηση και σκούρο κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις των ακμών, το ύψος εξώθησης, το πλάτος περιγράμματος και το βάθος μετρώνται σε points. Ένα πλαστικό υλικό, ισορροπημένο φωτισμό περιστραμμένο 40 μοίρες γύρω από τον άξονα Z και μια προοπτική κάμερα ορίζουν την εμφάνιση:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Το παραγόμενο σχήμα:

![The shape 3D effect](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3D μορφοποίηση στο κείμενο μέσω [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/get_threedformat/). Μικρότερες ακμές διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός δίνουν βάθος στο κείμενο:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Το παραγόμενο κείμενο:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3D εφέ σε κείμενο ή σε σχήμα—και η αλληλεπίδραση μεταξύ αυτών—ρυθμίζεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την τρισδιάστατη αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν έχει οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει δική του σκηνή αλλά διαθέτει τρισδιάστατη αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει καθόλου 3D εφέ, θεωρείται επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις μεθόδους [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_lightrig/) και [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

Για να διατηρήσετε το κείμενο επίπεδο και ευανάγνωστο ενώ διατηρείτε τη 3D μορφοποίηση του σχήματος, δείτε το [Keep Text Flat on a 3D Shape](/slides/el/cpp/3d-presentation/) για σύγκριση των ρυθμίσεων και ένα πλήρες παράδειγμα C++.

## **FAQ**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή γραφές (π.χ., Αραβική, Κινική);**

Ναι, το Aspose.Slides for C++ υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφές. Τα εφέ WordArt όπως σκιά, γεμίσμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις κύριες διαφάνειες, συμπεριλαμβανομένων των σημειώσεων τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master επηρεάζουν όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Κάπως. Εφέ όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας [ISlide::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/), ή να αποδώσετε μεμονωμένα σχήματα μέσω [IShape::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getimage/). Αυτό σας επιτρέπει να δείτε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.