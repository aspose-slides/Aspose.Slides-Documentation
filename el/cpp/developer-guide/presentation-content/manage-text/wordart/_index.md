---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε C++
linktitle: WordArt
type: docs
weight: 110
url: /el/cpp/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιάς
- εφέ προβολής
- εφέ λάμψης
- μετασχηματισμός WordArt
- εφέ 3Δ
- εφέ εξωτερικής σκιάς
- εφέ εσωτερικής σκιάς
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για C++. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε C++."
---
## **Επισκόπηση**

Οι εφέ WordArt σάς επιτρέπουν να προσθέτετε οπτικά ελκυστικό, μορφοποιημένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides, οι προγραμματιστές μπορούν προγραμματιστικά να δημιουργούν, να προσαρμόζουν και να διαχειρίζονται WordArt όπως στο Microsoft PowerPoint—χωρίς να απαιτείται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο ώστε να γίνει πιο ελκυστικό ή εμφανές.

## **Δημιουργία ενός Απλού Πρότυπου WordArt και Εφαρμογή του σε Κείμενο**

**Χρήση Aspose.Slides** 

Πρώτα, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα C++: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε το εφέ να είναι πιο εμφανές μέσω αυτού του κώδικα:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού εφέ WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε ένα προκαθορισμένο εφέ WordArt. Από το μενού στα αριστερά, μπορείτε να ορίσετε τις ρυθμίσεις για ένα νέο WordArt. 

Αυτά είναι κάποια από τα διαθέσιμα παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα μοτίβου SmallGrid στο κείμενο και προσθέτουμε ένα μαύρο περιθώριο κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Το αποτέλεσμα κειμένου:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτά τα εφέ σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, τα εφέ Σκιά, Ανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· τα εφέ 3D Format και 3D Rotation μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Soft Edges μπορεί να εφαρμοστεί σε αντικείμενο Σχήματος (έχει ακόμη αποτέλεσμα όταν δεν έχει οριστεί ιδιότητα 3D Format).

### **Εφαρμογή Σκιών σε Κείμενο**

Εδώ, προτιθέμενοι να ορίσουμε ιδιότητες που αφορούν μόνο κείμενο. Εφαρμόζουμε το εφέ σκίασης σε κείμενο χρησιμοποιώντας αυτόν τον κώδικα C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow. 

Με το PresetShadow, μπορείτε να εφαρμόσετε σκιά σε κείμενο (χρησιμοποιώντας προκαθορισμένες τιμές). 

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Να ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει στην πραγματικότητα την ταυτόχρονη εφαρμογή δύο τύπων σκιών: InnerShadow και PresetShadow.

**Σημειώσεις:**

- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow. 
- Αν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, το αποτέλεσμα ή το εφαρμοσμένο εφέ εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013, το εφέ διπλασιάζεται. Στο PowerPoint 2007, εφαρμόζεται το εφέ OuterShadow. 

### **Εφαρμογή Εφέ Ανάκλασης**

Προσθέτουμε ανάκλαση στο κείμενο μέσω αυτού του δείγματος κώδικα C++:

``` cpp 
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

### **Εφαρμογή Εφέ Λάμψης**

Εφαρμόζουμε το εφέ λάμψης στο κείμενο ώστε να λάμψει ή να ξεχωρίσει χρησιμοποιώντας αυτόν τον κώδικα:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, προβολή και λάμψη. Οι ιδιότητες των εφέ ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 

{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε τη μέθοδο set_Transform (εφαρμοζόμενη σε όλο το μπλοκ κειμένου) μέσω αυτού του κώδικα:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Τanto το Microsoft PowerPoint όσο και το Aspose.Slides για C++ παρέχουν έναν αριθμό προρυθμιζόμενων τύπων μετασχηματισμού. 

{{% /alert %}} 

**Χρήση PowerPoint**

Για να αποκτήσετε πρόσβαση σε προρυθμιζόμενους τύπους μετασχηματισμού, πηγαίνετε στο: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για να επιλέξετε τύπο μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType. 

### **Εφαρμογή 3D Εφέ σε Κείμενο και Σχήματα**

Ορίζουμε ένα 3D εφέ σε σχήμα κειμένου χρησιμοποιώντας αυτό το δείγμα κώδικα:

``` cpp 
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

Το αποτέλεσμα κειμένου και του σχήματος:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε 3D εφέ στο κείμενο με αυτόν τον κώδικα C++:

``` cpp 
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

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Η εφαρμογή 3D εφέ σε κείμενα ή στα σχήματά τους και οι αλληλοεπιδράσεις μεταξύ των εφέ βασίζονται σε ορισμένους κανόνες.

Σκεφτείτε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Το 3D εφέ περιλαμβάνει την αναπαράσταση αντικειμένου 3D και τη σκηνή πάνω στην οποία τοποθετήθηκε το αντικείμενο.

- Όταν η σκηνή ορίζεται και για το σχήμα και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα — η σκηνή του κειμένου αγνοείται. 
- Όταν το σχήμα δεν έχει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
- Αλλιώς — όταν το σχήμα αρχικά δεν έχει 3D εφέ — το σχήμα είναι επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο. 

Αυτές οι περιγραφές συνδέονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Εφαρμογή Εξωτερικής Σκιάς σε Σχήματα**
Το Aspose.Slides για C++ παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.effects.i_outer_shadow) και [**IInnerShadow**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.effects.i_inner_shadow) που επιτρέπουν την εφαρμογή εφέ σκιάς σε κείμενο που βρίσκεται σε TextFrame. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation). 
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της. 
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια. 
4. Προσπελάστε το TextFrame που συνδέεται με το AutoShape. 
5. Ορίστε το FillType του AutoShape σε NoFill. 
6. Δημιουργήστε μια παρουσία της κλάσης OuterShadow. 
7. Ορίστε το BlurRadius της σκιάς. 
8. Ορίστε την Direction της σκιάς. 
9. Ορίστε το Distance της σκιάς. 
10. Ορίστε το RectanglelAlign σε TopLeft. 
11. Ορίστε το PresetColor της σκιάς σε Black. 
12. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX. 

Αυτός ο δείγματος κώδικας σε C++ — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να εφαρμόσετε το εξωτερικό εφέ σκιάς σε κείμενο:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Λάβετε την αναφορά της διαφάνειας
auto sld = pres->get_Slides()->idx_get(0);

// Προσθέστε ένα AutoShape τύπου Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Προσθέστε TextFrame στο Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// Απενεργοποιήστε το γέμισμα του σχήματος σε περίπτωση που θέλουμε τη σκιά του κειμένου
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαραίτητες παραμέτρους
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Αποθηκεύστε την παρουσίαση στο δίσκο
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation). 
2. Αποκτήστε μια αναφορά της διαφάνειας. 
3. Προσθέστε ένα AutoShape τύπου Rectangle. 
4. Ενεργοποιήστε το InnerShadowEffect. 
5. Ορίστε όλες τις απαραίτητες παραμέτρους. 
6. Ορίστε το ColorType ως Scheme. 
7. Ορίστε το Scheme Color. 
8. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Αυτός ο δείγμα κώδικα (βάσει των παραπάνω βημάτων) δείχνει πώς να προσθέσετε ένα σύνδεσμο μεταξύ δύο σχημάτων σε C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Λάβετε την αναφορά μιας διαφάνειας
auto slide = presentation->get_Slides()->idx_get(0);

// Προσθέστε ένα AutoShape τύπου Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Προσθέστε TextFrame στο Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Ενεργοποίηση InnerShadowEffect
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Ορίστε όλες τις απαραίτητες παραμέτρους
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Ορίστε ColorType ως Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Ορίστε Scheme Color
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Αποθηκεύστε την παρουσίαση
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή αλφάβητα (π.χ. αραβικά, κινέζικα);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και αλφάβητα. Τα εφέ WordArt όπως σκιά, γέμισμα και περιγράμματα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master των διαφανειών;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις διαφάνειες master, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις συνδεδεμένες διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου της παρουσίασης;**

Λίγο. Εφέ WordArt όπως σκιές, λάμψεις και διαβαθμίσεις γεμίσματος μπορεί να αυξήσουν ελαφρά το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ. PNG, JPEG) χρησιμοποιώντας τη μέθοδο `GetImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.