---
title: Crea effetti 3D nelle presentazioni con C++
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- presentazione 3D
- rotazione 3D
- profondità 3D
- estrusione 3D
- gradiente 3D
- testo 3D
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in C++ con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides for C++ può creare, modificare, preservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando si esporta una diapositiva in immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Utilizza il metodo [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_threedformat/) per applicare la formattazione 3D a una forma. Il metodo restituisce [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/), che controlla la scena 3D per quella forma.

Per il testo, utilizza il metodo [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/get_threedformat/). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

I metodi più importanti sono:

| Metodo | Cosa controlla | Quando usarlo |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_camera/) | Punto di vista, tipo di telecamera predefinita, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrisponde a un preset di rotazione 3D di PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preset di luce, direzione e rotazione della luce. | Cambia l'aspetto di luci e ombre sulla superficie 3D. |
| [set_Material](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_material/) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Rende la stessa geometria più piatta, più morbida, lucida o metallica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Colore dei lati estrusi. | Rende visibile la profondità o coordina il colore laterale con il riempimento frontale. |
| [set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_depth/) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Affina la profondità per forme o testo, specialmente insieme a impostazioni di smusso e materiale. |
| [get_BevelTop](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_beveltop/) e [get_BevelBottom](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiunge un bordo smussato o modellato invece di una faccia piatta e netta. |
| [get_ContourColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_contourcolor/) e [set_ContourWidth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno attorno all'oggetto 3D. | Evidenzia il bordo dell'oggetto nel risultato renderizzato. |

## **Creare una Forma 3D**

Una forma solitamente richiede quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, poiché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, poiché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, poiché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, poiché una forma piatta necessita di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della telecamera sono in gradi e l'altezza dell'estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a doppia dimensione rispetto ai valori predefiniti e salva la presentazione come PPTX.

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

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco spesso 3D:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruotare una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Pannello Rotazione 3-D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla telecamera tramite [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_camera/). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi rispettivamente. Configura la forma in memoria senza salvare un file:

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

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta questo spessore visibile, e il controllo di colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati su colore di estrusione e proprietà di altezza di estrusione](img_02_02.png)

Imposta [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_extrusionheight/) per lo spessore e [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) per il colore laterale. Questo esempio assegna a un rettangolo un'estrusione di 100 punti con lati viola e ruota la telecamera per rivelarne lo spessore. Configura la forma in memoria senza salvare un file:

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

Il metodo [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_depth/) imposta la profondità di una forma 3D. Il metodo [set_ExtrusionHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_extrusionheight/) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usare Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e comunque utilizzare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della telecamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppia dimensione rispetto ai valori predefiniti:

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

L'output renderizzato mantiene il gradiente sulla faccia anteriore e renderizza separatamente l'estrusione:

![Rettangolo 3D renderizzato con riempimento a gradiente blu‑arancione ed estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della telecamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

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

L'immagine è renderizzata sulla faccia anteriore, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore ed estrusione arancione](img_02_04.png)

## **Applicare la Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con un motivo a griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/get_threedformat/). L'altezza dell'estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti così da rendere visibile solo il testo. L'esempio renderizza un'immagine PNG a doppia dimensione rispetto alla diapositiva predefinita e salva la presentazione come PPTX:

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

Il testo è renderizzato come lettere curve e estruse in 3D:

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantenere il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, chiama [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/set_keeptextflat/) tramite [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_textframeformat/). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue l'orientamento 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua telecamera, illuminazione, materiale ed estrusione restano configurati tramite [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_threedformat/). È anche diversa dalla rotazione ordinaria. [IShape::set_Rotation](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_rotation/) ruota la forma nel piano della diapositiva, mentre [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/set_rotationangle/) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Mantenere il testo fuori dalla scena 3D non resetta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `false` a sinistra e `true` a destra. Gli angoli della telecamera sono in gradi e l'altezza dell'estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a doppia dimensione rispetto al valore predefinito.

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

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli conservano la stessa estrusione visibile e orientamento 3D.

![Rettangoli 3D affiancati: KeepTextFlat è false a sinistra e true a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides preserva la formattazione 3D quando si salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Ciò avviene quando renderizzi le diapositive in [PNG](/slides/it/cpp/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/cpp/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/cpp/convert-powerpoint-to-video/).

Tieniti presente questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, rig di luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà efficaci della forma](/slides/it/cpp/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché preservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate in scene 3D interattive che lo spettatore può ruotare. Nei file PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e either estrusione o profondità. In pratica, imposta anche un rig di luce e un materiale affinché le facce renderizzate abbiano luci e ombre ben definite.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_threedformat/) per il corpo della forma e [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/get_threedformat/) per il testo.

**Gli effetti 3D compariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione efficace descritte in [Proprietà Efficaci della Forma](/slides/it/cpp/shape-effective-properties/) per leggere la telecamera finale, il rig di luce, lo smusso e i relativi valori 3D.