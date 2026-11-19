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
- 3Δ εκτράγηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε C++ με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εκτράγηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εκτράγισμα, πλαγιές, φωτισμό, υλικό, διαβάθμιση ή γέμιση με εικόνα, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές μέθοδοι είναι:

| Μέθοδος | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στον 3Δ χώρο ή ταιριάξτε με προεπιλογή περιστροφής 3Δ του PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των αντανακλαστικών και σκιών στην 3Δ επιφάνεια. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, γυαλιστερή ή μεταλλική. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Πόσο μακριά το σχήμα επεκτείνεται προς τα πίσω από την μπροστινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Χρώμα των εκτραγμένων πλευρών. | Διαφωτίστε το βάθος ή εναρμονίστε το χρώμα των πλευρών με τη γέμιση της μπροστινής πλευράς. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Πρόσθετο βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε προσεκτικά το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με τις ρυθμίσεις πλαγίας και υλικού. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ανασηκωμένα ή στρογγυλεμένα άκρα στην μπροστινή και πίσω πλευρά. | Προσθέστε ένα μαλακό ή σχηματισμένο άκρο αντί για μια αιχμηρή επίπεδη επιφάνεια. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε τα όρια του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3Δ σχήματος**

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εκτράγηση.  
- Ρυθμίσεις φωτισμού, επειδή το φως κάνει τις πλευρές και τις όψεις αναγνώσιμες.  
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει πώς αποδίδεται το φως.  
- Ρυθμίσεις εκτράγησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εκτράγησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις και αποθηκεύει την παρουσίαση ως PPTX.

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

![Αποδομένο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή σχήματος με την κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική από μπροστά, και θέτει τις περιστροφές X, Y, Z αντίστοιχα στις 20, 30 και 40 μοίρες. Ρυθμίζει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή προσανατολισμού κάμερας από σχήμα προτύπου**

Για να ταιριάξετε τον προσανατολισμό κάμερας ενός σχήματος προτύπου, διαβάστε την προεπιλογή του με [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) και εφαρμόστε την με [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). Το παράδειγμα ανοίγει `template.pptx` και αντιγράφει τον προσανατολισμό κάμερας από το πρώτο σχήμα στην πρώτη διαφάνεια στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3Δ φωτισμό, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) επιστρέφει τις γωνίες σε μοίρες. Ο δείκτης `0` είναι γεωγραφικό πλάτος, ο δείκτης `1` είναι γεωγραφικό μήκος και ο δείκτης `2` είναι περιφορά. Περάστε τις γωνίες στο [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) με αυτή τη σειρά. Εάν η πηγή δεν έχει ρητή περιστροφή, το `GetRotation` επιστρέφει δείκτη null, οπότε αφήστε τις γωνίες του δεύτερου σχήματος ακαθορισμένες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει έναν πίνακα τριών μηδενικών και θα πρέπει να αντιγραφεί.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Όταν ανοίξετε ξανά το `camera-copy.pptx` στο PowerPoint, το βέλος στα δεξιά έχει το ίδιο προεπιλεγμένο κάμερας και την ίδια περιστροφή με το ορθογώνιο στα αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και το ίδιο βάθος εκτράγησης.

![Ένα μπλε 3Δ ορθογώνιο και ένα δεξιό βέλος με αντίστοιχο προσανατολισμό κάμερας, προβλημένο από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη εκτράγησης και βάθους**

Η εκτράγηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από τη μπροστινή πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτή τη ορατή πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος εκτράγησης και ύψους εκτράγησης](img_02_02.png)

Θέστε το [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) για το πάχος και το [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εκτράγηση 100 μονάδων με μωβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος. Ρυθμίζει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η μέθοδος [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) ορίζει το βάθος ενός 3Δ σχήματος. Η μέθοδος [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ελέγχει το ύψος του εφέ εκτράγησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση διαβάθμισης ή γέμισης με εικόνα με εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε στερεό χρώμα, διαβάθμιση, μοτίβο ή γέμιση με εικόνα στη μπροστινή πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εκτράγησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην μπροστινή πλευρά και σκούρο πορτοκαλί χρώμα στην εκτράγηση 150 μονάδων. Τα σημεία διαβάθμισης στο 0 και το 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια από τις προεπιλεγμένες διαστάσεις:

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

Η αποδοθείσα έξοδος διατηρεί τη διαβάθμιση στην μπροστινή πλευρά και αποδίδει την εκτράγηση ξεχωριστά:

![Αποδομένο 3Δ ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εκτράγηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα με εικόνα, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στη γέμιση του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εκτράγηση 150 μονάδων και θέτει την περιστροφή της κάμερας σε μοίρες. Ρυθμίζει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην μπροστινή πλευρά, ενώ η εκτράγηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Αποδομένο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην μπροστινή πλευρά και πορτοκαλί εκτράγηση](img_02_04.png)

## **Εφαρμογή μορφοποίησης 3Δ σε κείμενο**

Η μορφοποίηση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εκτράγηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλεγμάτων πορτοκαλί‑λευκού, εφαρμόζει άρμα προς τα πάνω και ρυθμίζει 3Δ ρυθμίσεις μέσω [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Το ύψος εκτράγησης και το βάθος είναι σε μονάδες, η περιστροφή του φωτός σε μοίρες. Η γέμιση και το περίγραμμα του σχήματος είναι κρυφά ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει εικόνα PNG με διπλάσιο από το προεπιλεγμένο μέγεθος διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

![Αποδομένο 3Δ κείμενο με καμπύλη μετασχηματισμό WordArt, γέμισμα με πορτοκαλί μοτίβο και σκούρα εκτράγηση](img_02_05.png)

## **Διατήρηση κειμένου επίπεδου σε 3Δ σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείται η 3Δ εμφάνιση του σχήματος, καλέστε [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) μέσω του [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Όταν η τιμή είναι `true`, το κείμενο παραμένει έξω από τη 3Δ σκηνή. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3Δ προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εκτράγηση παραμένουν ρυθμισμένα μέσω του [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Είναι επίσης διαφορετικό από την κανονική περιστροφή. Το [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου έξω από τη 3Δ σκηνή δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες κάμερας είναι σε μοίρες, το ύψος εκτράγησης 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσιο από το προεπιλεγμένο μέγεθος.

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

Στα αριστερά, το κείμενο ακολουθεί τον 3Δ προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν το ίδιο ορατό πάχος εκτράγησης και τον ίδιο 3Δ προσανατολισμό.

![Δύο πλάγιες 3Δ ορθογώνιες: KeepTextFlat είναι false στα αριστερά και true στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά εξαγωγής και απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή την εξαγωγή σε μορφές σταθερού προσανατολισμού, η 3Δ σκηνή ραστεριζείται ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/cpp/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/cpp/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/cpp/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.  
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εκτράγησης, γέμισης και κλιμάκωσης διαφάνειας.  
- Εάν χρειάζεστε να ελέγξετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/cpp/shape-effective-properties/).  
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**  
Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγώμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3Δ σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3Δ μοντέλου και 3Δ εφέ;**  
Ένα 3Δ μοντέλο είναι ξεχωριστό 3Δ αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο PowerPoint, όπως περιστροφή, εκτράγηση, πλαγία, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**  
Στο ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εκτράγηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρά highlights και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ σε σχήματα και κείμενο;**  
Ναι. Χρησιμοποιήστε το [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) για το σώμα του σχήματος και το [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) για το κείμενο.

**Θα εμφανιστούν τα 3Δ εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή καρέ βίντεο;**  
Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3Δ τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**  
Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/cpp/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, πλαγίας και σχετικών 3Δ τιμών.