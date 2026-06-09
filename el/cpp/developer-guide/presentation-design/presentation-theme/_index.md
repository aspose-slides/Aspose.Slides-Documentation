---
title: Διαχείριση Θεμάτων Παρουσίασης σε C++
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/cpp/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Χρώμα θέματος
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε θέματα παρουσίασης στο Aspose.Slides για C++ για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή σήμανση."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, βασικά επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και των ιδιοτήτων τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [fonts](/slides/el/cpp/powerpoint-fonts/), [background styles](/slides/el/cpp/presentation-background/) και εφέ.

![συστατικά_θέματος](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Αν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα στο θέμα. Για να μπορείτε να επιλέξετε ένα νέο χρώμα θέματος, το Aspose.Slides παρέχει τιμές στην απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Μπορείτε να προσδιορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος ως εξής:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Χρώμα [A=255, R=128, G=100, B=162])
```

Για να επιδείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα ακόμη στοιχείο και του εκχωρούμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), σχηματίζονται χρώματα από την πρόσθετη παλέτα(2). Στη συνέχεια μπορείτε να ορίσετε και να λάβετε αυτά τα χρώματα θέματος.

![χρώματα-πρόσθετης-παλέτας](additional-palette-colors.png)

**1**- Κύρια χρώματα θέματος  
**2**- Χρώματα από την πρόσθετη παλέτα.

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου τα χρώματα της πρόσθετης παλέτας λαμβάνονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Σχεδίαση `SchemeColor` σε Χρώματα `IColorScheme`**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/cpp/aspose.slides.schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις ακόλουθες τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1` και `Text2`.

Ωστόσο, `Presentation::get_MasterTheme()::get_ColorScheme()` επιστρέφει [IColorScheme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/icolorscheme/), το οποίο εκθέτει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1` και `Light2`.

Αυτή η διαφορά είναι μόνο στη ονομασία. Οι τιμές αναφέρονται στα ίδια slots χρωμάτων θέματος και η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Απλώς είναι εναλλακτικές ονομασίες των ίδιων χρωμάτων θέματος.

Αυτή η διαφορά στην ονομασία προέρχεται από την ορολογία του Microsoft Office. Οι παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τα ίδια slots ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέξετε γραμματοσειρές για θέματα και άλλους σκοπούς, το Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς αναγνωριστές (παρόμοιους με αυτούς που χρησιμοποιεί το PowerPoint):

* **+mn-lt** - Γραμματοσειρά σώματος Latin (Minor Latin Font)
* **+mj-lt** - Γραμματοσειρά κεφαλίδας Latin (Major Latin Font)
* **+mn-ea** - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)
* **+mj-ea** - Γραμματοσειρά σώματος East Asian (Major East Asian Font)

Αυτός ο κώδικας C++ δείχνει πώς να εκχωρήσετε τη λατινική γραμματοσειρά σε ένα στοιχείο θέματος:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε τη γραμματοσειρά του θέματος παρουσίασης:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε [PowerPoint fonts](/slides/el/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προεγκατεστημένα φόντα, αλλά μόνο 3 από αυτά αποθηκεύονται σε μια τυπική παρουσίαση.

![σχεδίαση-παρουσίασης](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα C++ για να μάθετε τον αριθμό των προεγκατεστημένων φόντων στην παρουσίαση:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.i_format_scheme/), μπορείτε να προσθέσετε ή να έχετε πρόσβαση στο στυλ φόντου σε ένα θέμα PowerPoint. 
{{% /alert %}}

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε το φόντο για μια παρουσίαση:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Οδηγός ευρετηρίου**: 0 χρησιμοποιείται για χωρίς γέμισμα. Ο δείκτης αρχίζει από 1.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε [PowerPoint Background](/slides/el/cpp/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε αυτά τα 3 εφέ: subtle, moderate και intense. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![presentation-design_10.png](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.theme.i_format_scheme/) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές στο PowerPoint).

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας μέρη των στοιχείων:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Οι προκύπτουσες αλλαγές στο χρώμα γεμίσματος, τύπο γεμίσματος, εφέ σκιάς κ.λπ.:

![presentation-design_11.png](presentation-design_11.png)

## **FAQ**

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Το Aspose.Slides υποστηρίζει παρακάμψεις θέματος σε επίπεδο διαφάνειας, ώστε να μπορείτε να εφαρμόσετε τοπικό θέμα μόνο σε αυτή τη διαφάνεια ενώ το master theme παραμένει αμετάβλητο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/slidethememanager/)).

**Ποιος είναι ο πιο ασφαλής τρόπος να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

[Clone slides](/slides/el/cpp/clone-slides/) μαζί με το master τους στην προοριστική παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το συσχετισμένο θέμα ώστε η εμφάνιση να παραμένει συνεπής.

**Πώς μπορώ να δω τις «αποτελεσματικές» τιμές μετά από όλες τις κληρονομήσεις και παρακάμψεις;**

Χρησιμοποιήστε τις «αποτελεσματικές» προβολές του API (/slides/el/cpp/shape-effective-properties/) για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις διευθετημένες, τελικές ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών παρακάμψεων.