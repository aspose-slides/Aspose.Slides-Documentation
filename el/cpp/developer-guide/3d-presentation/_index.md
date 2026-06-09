---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D παρουσίαση
- 3D περιστροφή
- 3D βάθος
- 3D εξώθηση
- 3D διαβάθμιση
- 3D κείμενο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε C++ με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για C++ μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει διαμορφώσεις 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξότμηση, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3Δ.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά εφέ διαμορφωσης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στο εξαγόμενο 2Δ αποτέλεσμα.
{{% /alert %}}

## **Αρχές Διαμόρφωσης 3Δ**

Χρησιμοποιήστε τη μέθοδο get_ThreeDFormat του περιβάλλοντος [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για να εφαρμόσετε διαμορφωση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο get_ThreeDFormat του περιβάλλοντος [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/). Αυτό εφαρμόζει τη διαμορφωση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές μέθοδοι είναι:

| Μέθοδος | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_camera/) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, μεγέθυνση και προοπτική. | Περιστρέψτε το αντικείμενο σε τρισδιάστατο χώρο ή ταιριάξτε με προεπιλεγμένη περιστροφή 3Δ του PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_lightrig/) | Προεπιλογή φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των αντανακλάσεων και των σκιών στην επιφάνεια 3Δ. |
| [set_Material](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την πρόσθια όψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ αντικείμενο 3Δ. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_depth/) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη διαμορφωση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδίως μαζί με τις ρυθμίσεις λοξότμησης και υλικού. |
| [get_BevelTop](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_beveltop/) και [get_BevelBottom](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ανασηκωμένες ή στρογγυλεμένες άκρες στις πρόσθιες και οπίσθιες όψεις. | Προσθέστε μια μαλακότερη ή διαμορφωμένη άκρη αντί για μια κοφτερή επίπεδη όψη. |
| [get_ContourColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_contourcolor/) και [set_ContourWidth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Περίγραμμα γύρω από το αντικείμενο 3Δ. | Τονίστε το όριο του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσθια όψη του, εφαρμόζει διαμορφωση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3Δ μπλοκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3‑D ρυθμίζεται από το παράθυρο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![PowerPoint 3‑D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και τη περιστροφή μέσω [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ, επεκτείνοντάς το πίσω από την πρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτήν τη ορατή πάχος, και ο έλεγχος χρώματος καθορίζει το χρώμα των πλευρικών όψεων.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Χρησιμοποιήστε τη μέθοδο set_ExtrusionHeight για το πάχος και τη get_ExtrusionColor για το χρώμα των πλευρών:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Χρησιμοποιήστε τη set_Depth όταν χρειάζεται να επεξεργαστείτε απευθείας την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοξότμηση, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, η `set_ExtrusionHeight` είναι πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Γεφυρών ή Εικόνας γεμίσματος με Εφέ 3Δ**

Η διαμορφωση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Το παράδειγμα αυτό εφαρμόζει διαβάθμιση στο σχήμα και ένα πιο σκούρο χρώμα εξώθησης στις πλευρές:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην πρόσθια όψη και αποδίδει την εξώθηση ξεχωριστά:

![Απόδοση 3Δ ορθογωνίου με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και εκχωρήστε την στο γέμισμα του σχήματος:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Η εικόνα αποδίδεται στην πρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Απόδοση 3Δ ορθογωνίου με γέμισμα φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Διαμορφωσης 3Δ σε Κείμενο**

Η διαμορφωση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η διαμορφωση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt, όπου τα ίδια τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει ρυθμίσεις 3Δ στο [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/):

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η αποδιδόμενη εικόνα δείχνει καμπυλωτό 3Δ κείμενο με WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση:

![Απόδοση 3Δ κειμένου με καμπυλωτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη διαμορφωση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ rasterise ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/cpp/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/cpp/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/cpp/convert-powerpoint-to-video/).

Κρατήστε αυτά τα σημεία κατά νου:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης της διαφάνειας.
- Αν χρειάζεται να ελέγξετε κληρονομημένες ή βασισμένες σε θέμα τιμές διαμορφωσης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/cpp/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη διαμορφωση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3Δ σκηνές που μπορεί να περιστρέψει ο θεατής. Στο PPTX, η διαμορφωση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται στην παρουσίαση. Ένα 3Δ εφέ είναι διαμορφωση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξότμηση, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ως ελάχιστο, ορίστε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης το φωτισμό και το υλικό ώστε οι αποδομένες όψεις να έχουν σαφείς αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το IShape για το σώμα του σχήματος και το ITextFrameFormat για το κείμενο.

**Θα εμφανίζονται τα 3Δ εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ κατά τη δημιουργία εικόνων διαφανειών, εξόδου PDF, εξόδου HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την εφαρμογή κληρονομήσεων και ρυθμίσεων θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής διαμορφωσης που περιγράφονται στις [Ιδιότητες Αποτελεσματικού Σχήματος](/slides/el/cpp/shape-effective-properties/) για να διαβάσετε την τελική κάμερα, φωτισμό, λοξότμηση και σχετικές τιμές 3Δ.