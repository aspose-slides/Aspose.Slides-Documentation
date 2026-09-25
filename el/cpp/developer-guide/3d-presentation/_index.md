---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/cpp/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξώθηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε C++ με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, απότομε άκρες, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ξεχωριστών αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαχθείσα 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_threedformat/) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/get_threedformat/). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί για το σώμα του σχήματος.

Οι πιο σημαντικές μέθοδοι είναι:

| Μέθοδος | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_camera/) | Σημείο θέασης, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στον τρισδιάστατο χώρο ή ταιριάξτε με μια προεπιλογή περιστροφής 3Δ του PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_lightrig/) | Προκαθορισμένος φωτισμός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των αντανακλάσεων και σκιών στην επιφάνεια 3Δ. |
| [set_Material](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_material/) | Υλικό επιφάνειας, π.χ. επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε τη γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, γυαλιστερή ή μεταλλική. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την πρόσθια όψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ 3Δ αντικείμενο. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Χρωμα των εξωθημένων πλευρών. | Κάντε την βάθος ορατή ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_depth/) | Επιπλέον τρισδιάστατο βάθος που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε την βάθος για σχήματα ή κείμενο, ιδίως μαζί με τις ρυθμίσεις κλίκης και υλικού. |
| [get_BevelTop](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_beveltop/) και [get_BevelBottom](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ανασηκωμένες ή στρογγυλεμένες άκρες στις πρόσθιες και οπίσθιες όψεις. | Προσθέστε μια μαλακωμένη ή διαμορφωμένη άκρη αντί για μια αιχμηρή επίπεδη όψη. |
| [get_ContourColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_contourcolor/) και [set_ContourWidth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Περίγραμμα γύρω από το τρισδιάστατο αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3Δ Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν να φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπροστά μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσθια όψη του και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις και αποθηκεύει την παρουσίαση ως PPTX.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδοθείσα μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_camera/). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική μπροστά και ορίζει τις περιστροφές X, Y και Z σε 20, 30 και 40 μοίρες, αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);

presentation->Dispose();
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει την τρισδιάστατη οπτική που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την πρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint που αντιστοιχούν στα χαρακτηριστικά χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) για το πάχος και το [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξώθηση 100 μονάδων με μωβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος του. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Η μέθοδος [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_depth/) ορίζει το βάθος ενός 3Δ σχήματος. Η μέθοδος [set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε μονόχρωμο χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια διαβάθμιση από μπλε σε πορτοκαλί στην πρόσθια όψη και ένα σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Τα σημεία διαβάθμισης στα 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

![Αποδοθείσα 3Δ ορθογώνιο με διαβάθμιση γεμίσματος από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε αντί αυτού γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε τη στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

![Αποδοθείσα 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει ένα τόξο προς τα πάνω και διαμορφώνει τις ρυθμίσεις 3Δ μέσω του [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/get_threedformat/). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή του φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος είναι κρυφά ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

![Αποδομένο 3Δ κείμενο με τόξο τύπου WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3Δ Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείτε την τρισδιάστατη εμφάνιση ενός σχήματος, καλέστε το [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_keeptextflat/) μέσω του [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/get_textframeformat/). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της τρισδιάστατης σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον τρισδιάστατο προσανατολισμό της.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_threedformat/). Επίσης διαφέρει από τη συνήθη περιστροφή. Η [IShape::set_Rotation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/set_rotationangle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της τρισδιάστατης σκηνής δεν επαναφέρει κανένα από αυτά τα γωνιακά στοιχεία.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· η μόνη διαφορά είναι η ρύθμιση κειμένου: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνειά σύγκρισης σε PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

Αριστερά, το κείμενο ακολουθεί τον τρισδιάστατο προσανατολισμό. Δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και τρισδιάστατο προσανατολισμό.

![Δύο 3Δ ορθογώνια δίπλα-δίπλα: KeepTextFlat είναι false στα αριστερά και true στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η τρισδιάστατη σκηνή ρασπρίζεται ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/cpp/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/cpp/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/cpp/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και PDFs δεν είναι αλληλεπιδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης της διαφάνειας.
- Αν χρειάζεστε να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/cpp/shape-effective-properties/).
- Μερικές μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3Δ ρυθμίσεις.

## **FAQ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει τα 3Δ εφέ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDFs ή σελίδες HTML διαδραστικές τρισδιάστατες σκηνές που ο θεατής μπορεί να περιστρέφει. Στο PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint εφόσον η μορφή τη υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ξεχωριστό τρισδιάστατο αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίση, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφή ανάγγειλα και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_threedformat/) για το σώμα του σχήματος και το [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/get_threedformat/) για το κείμενο.

**Θα εμφανιστούν τα 3Δ εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ κατά τη δημιουργία εικόνων διαφανειών, εξόδου PDF, εξόδου HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3Δ τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/cpp/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, κλίκης και σχετικών 3Δ τιμών.