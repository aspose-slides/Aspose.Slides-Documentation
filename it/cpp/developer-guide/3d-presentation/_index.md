---
title: Crea effetti 3D nelle presentazioni usando C++
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

Aspose.Slides per C++ può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Utilizza il metodo [get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_threedformat/) dell'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per applicare la formattazione 3D a una forma. Il metodo restituisce [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/), che controlla la scena 3D per quella forma.

Per il testo, utilizza il metodo [get_ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/get_threedformat/) dell'interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/). Questo applica la formattazione 3D al frame di testo invece che al corpo della forma.

I metodi più importanti sono:

| Metodo | Cosa controlla | Quando usarlo |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_camera/) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preset di luce, direzione e rotazione della luce. | Modificare come appaiono le luci e le ombre sulla superficie 3D. |
| [set_Material](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_material/) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, più morbida, lucida o metallica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Quanto la forma si estende all'indietro dalla sua faccia frontale. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_depth/) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, soprattutto in combinazione con impostazioni di smusso e materiale. |
| [get_BevelTop](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_beveltop/) e [get_BevelBottom](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordi rialzati o arrotondati sulle facce frontale e posteriore. | Aggiungere un bordo smussato o modellato invece di una faccia piatta e netta. |
| [get_ContourColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_contourcolor/) e [set_ContourWidth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno intorno all'oggetto 3D. | Evidenziare i confini dell'oggetto nell'output renderizzato. |

## **Creare una Forma 3D**

Una forma solitamente necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce su come la luce è renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia frontale, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

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

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia frontale](img_01_01.png)

## **Ruotare una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal riquadro Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Riquadro Rotazione 3-D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

Utilizza il tipo di telecamera e la rotazione tramite [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non cambia la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere Estrusione e Profondità**

L'estrusione rende una forma più spessa estendendola dietro la faccia frontale. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Imposta [set_ExtrusionHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_extrusionheight/) per lo spessore e [get_ExtrusionColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) per il colore laterale:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Usa [set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/set_depth/) quando è necessario lavorare direttamente con il valore di profondità di PowerPoint o combinare profondità con smusso, materiale e effetti di testo. In molti scenari di forme, `set_ExtrusionHeight` è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Usare Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia frontale e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento a gradiente alla forma e un colore di estrusione più scuro ai lati:

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

L'output renderizzato mantiene il gradiente sulla faccia frontale e renderizza l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento a gradiente da blu a arancione ed estrusione arancione](img_02_03.png)

Per utilizzare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

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

L'immagine è renderizzata sulla faccia frontale, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia frontale ed estrusione arancione](img_02_04.png)

## **Applicare la Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul frame di testo. Questo è utile per effetti simili a WordArt in cui le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con un riempimento a pattern, applica una trasformazione WordArt e configura le impostazioni 3D su [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/):

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

Il testo è renderizzato come lettere 3D curve ed estruse:

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento pattern arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si esegue il rendering o l'esportazione in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/cpp/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/cpp/convert-powerpoint-to-html/), o generi frame per la [conversione video](/slides/it/cpp/convert-powerpoint-to-video/).

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, illuminazione, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [Proprietà Effective della Forma](/slides/it/cpp/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In quei formati, il risultato visivo è renderizzato piuttosto che conservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore può ruotare. In PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e o l'estrusione o la profondità. In pratica, imposta anche un sistema di illuminazione e un materiale affinché le facce renderizzate abbiano evidenti luci e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per il corpo della forma e [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o frame video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini diapositive, output PDF, output HTML e frame usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori 3D finali dopo che sono stati applicati ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effective descritte in [Proprietà Effective della Forma](/slides/it/cpp/shape-effective-properties/) per leggere telecamera, illuminazione, smusso e relativi valori 3D finali.