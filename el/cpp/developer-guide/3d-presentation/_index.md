---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις με C++
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/cpp/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξωθήση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε C++ με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξωθήση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει 3D μορφοποίηση σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει 3D εφέ όπως περιστροφή, εξωθήση, λεβέλ, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και 3D κείμενο.

{{% alert color="info" %}}
Αυτό το άρθρο αφορά τα 3D εφέ μορφοποίησης σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα 3D εφέ στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Εννοιες 3Δ Μορφοποίησης**

Χρησιμοποιήστε τη διεπαφή [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) και τη μέθοδο [get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_threedformat/) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/), το οποίο ελέγχει τη 3D σκηνή για αυτό το σχήμα.

Για κείμενο, χρησιμοποιήστε τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/) και τη μέθοδο [get_ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/get_threedformat/). Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές μέθοδοι είναι:

| Μέθοδος | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_camera/) | Σημείο θέασης, προρυθμισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3D χώρο ή ταιριάξτε με μια προρυθμισμένη περιστροφή 3D του PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_lightrig/) | Προρύθμιση φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των αντανακλάσεων και των σκιών στην 3D επιφάνεια. |
| [set_Material](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, γυαλιστερή ή μεταλλική. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Πόσο μακριά το σχήμα εκτείνεται πίσω από την πρόσθια όψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_depth/) | Επιπλέον 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με τις ρυθμίσεις λεβέλ και υλικού. |
| [get_BevelTop](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_beveltop/) και [get_BevelBottom](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις πρόσθιες και οπίσθιες όψεις. | Προσθέστε ένα μαλακό ή μορφοποιημένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [get_ContourColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_contourcolor/) και [set_ContourWidth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε τα όρια του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3Δ Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν να φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη πρόσθια όψη μπορεί να κρύβει την εξωθήση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ορατές.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξωθήσης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσθια όψη του, εφαρμόζει 3D μορφοποίηση, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

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

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδιδόμενο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το πλαίσιο 3‑Δ Περιστροφή. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω του [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/):

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
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξωθήσης και Βάθους**

Η εξωθήση κάνει ένα σχήμα να φαίνεται παχύ, επεκτείνοντάς το πίσω από την πρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχισμένοι στο χρώμα εξωθήσης και στις ιδιότητες ύψους εξωθήσης](img_02_02.png)

Ορίστε το [set_ExtrusionHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_extrusionheight/) για το πάχος και το [get_ExtrusionColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) για το χρώμα των πλευρών:

```cpp
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Χρησιμοποιήστε το [set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/set_depth/) όταν χρειάζεται να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λεβέλ, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το `set_ExtrusionHeight` είναι η πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξωθήση.

## **Χρήση Διαβάθμισης ή Γεμισμάτων Εικόνας με 3Δ Εφέ**

Η 3D μορφοποίηση είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξωθήσης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση στο σχήμα και πιο σκούρο χρώμα εξωθήσης στις πλευρές:

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

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην πρόσθια όψη και αποδίδει την εξωθήση ξεχωριστά:

![Αποδιδόμενο 3Δ ορθογώνιο με διαβάθμιση από μπλε σε πορτοκαλί και πορτοκαλί εξωθήση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας αντί αυτού, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος:

```cpp
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
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

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

Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξωθήση:

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξωθήση](img_02_04.png)

## **Εφαρμογή 3Δ Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα απαιτούν εξωθήση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει ρυθμίσεις 3D στο [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/):

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

Αποδιδόμενο 3Δ κείμενο με καμπύλο μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξωθήση:

![Αποδιδόμενο 3Δ κείμενο με καμπύλο μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξωθήση](img_02_05.png)

## **Εξαγωγή και Συμπεριφορά Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση όταν αποθηκεύεται σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η 3D σκηνή ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/cpp/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/cpp/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/cpp/convert-powerpoint-to-video/).

Λάβετε υπόψη τα ακόλουθα σημεία:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτεινού πλαισίου, υλικού, εξωθήσης, γεμίσματος και κλιμάκωσης της διαφάνειας.
- Εάν χρειάζεται να εξετάσετε τις κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/cpp/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **Συχνές Ερωτήσεις**

### Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;

Το Aspose.Slides δημιουργεί και αποδίδει 3D εφέ PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML σε διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint εφόσον η μορφή το υποστηρίζει.

### Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;

Ένα 3D μοντέλο είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξωθήση, λεβέλ, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

### Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;

Κατ' ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξωθήση είτε βάθος. Στην πράξη, ορίστε επίσης φωτεινό πλαίσιο και υλικό ώστε οι αποδιδόμενες όψεις να έχουν σαφείς αντανακλάσεις και σκιές.

### Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;

Ναι. Χρησιμοποιήστε το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για το σώμα του σχήματος και το [ITextFrameFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/) για το κείμενο.

### Θα εμφανίζονται τα 3D εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;

Ναι. Το Aspose.Slides αποδίδει 3D εφέ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

### Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την εφαρμογή κληρονομιών και ρυθμίσεων θέματος;

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στο [Shape Effective Properties](/slides/el/cpp/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτεινού πλαισίου, λεβέλ και σχετικές 3D τιμές.