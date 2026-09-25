---
title: Crea e Applica WordArt Effects in C++
linktitle: WordArt
type: docs
weight: 110
url: /it/cpp/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto riflessione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- C++
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per C++. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in C++."
---
## **Panoramica**

Gli effetti WordArt ti consentono di formattare il testo con riempimenti, contorni, ombre, riflessi, bagliori, trasformazioni e formattazione 3D. Questo articolo spiega come creare e personalizzare questi effetti nelle presentazioni PowerPoint utilizzando Aspose.Slides per C++, senza Microsoft Office installato.

## **Creare un modello WordArt semplice e applicarlo al testo**

Gli esempi seguenti creano uno stile WordArt semplice impostando il testo, il carattere, il riempimento a motivo e il contorno.

Ogni esempio crea una nuova presentazione e aggiunge un rettangolo alla prima diapositiva; non è necessario alcun file di input. Il primo esempio imposta il testo su "Aspose.Slides". La posizione e le dimensioni della forma sono misurate in punti:

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

Imposta il carattere su Arial Black a 36 punti per rendere la formattazione più evidente:

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

Applica un motivo [SmallGrid](https://reference.aspose.com/slides/it/cpp/aspose.slides/patternstyle/) con un primo piano arancione scuro e uno sfondo bianco, quindi aggiungi un contorno del testo nero con larghezza di 1 punto:

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

Il testo risultante:

![Il modello WordArt semplice](WordArt_template.png)

## **Applicare altri effetti WordArt**

Gli esempi seguenti dimostrano come applicare ombre, riflessi, bagliori, trasformazioni e effetti 3D al testo.

### **Applicare effetti di ombra esterna**

Un'ombra esterna aggiunge profondità posizionando un'ombra dietro il testo. È possibile personalizzare il colore, la direzione, la distanza, il raggio di sfocatura, la scala e l'inclinazione.

Questo esempio chiama [EnableOuterShadowEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) e imposta un'ombra nera con un raggio di sfocatura di 4 punti, una direzione di 230 gradi e una distanza di 30 punti. Valori di scala pari a 100 preservano le dimensioni dell'ombra, mentre l'inclinazione orizzontale la ruota di 20 gradi. La trasformazione alfa ne imposta l'opacità al 32%:

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

Il testo risultante:

![L'effetto di ombra esterna](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando le ombre esterne e le ombre predefinite sono usate insieme, viene applicata solo l'ombra esterna.
- Se le ombre esterne e interne sono usate simultaneamente, l'effetto risultante dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l'effetto è raddoppiato, mentre in PowerPoint 2007 viene applicata solo l'ombra esterna.
{{% /alert %}}

### **Applicare effetti di riflessione**

Una riflessione crea una copia speculare del testo. Regola posizione, scala, sfocatura e opacità per controllare l'aspetto.

Questo esempio chiama [EnableReflectionEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) e ribalta verticalmente la riflessione con una scala del -100 %. Utilizza un raggio di sfocatura di 0,5 punti e una distanza di 4,72 punti. L'opacità diminuisce dal 60 % allo 0,9 % tra le posizioni 0 % e 60 % lungo la riflessione:

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

Il testo risultante:

![L'effetto di riflessione](reflection_effect.png)

### **Applicare effetti di bagliore**

Un bagliore aggiunge un contorno colorato morbido attorno al testo. Regola colore, opacità e raggio per controllare l'effetto.

Questo esempio chiama [EnableGlowEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides/ieffectformat/enablegloweffect/) e applica un bagliore rosso con opacità del 54 % e raggio di 7 punti:

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

Il testo risultante:

![L'effetto di bagliore](glow_effect.png)

### **Applicare trasformazioni WordArt**

Le trasformazioni WordArt curvano, allungano o deformano un blocco di testo.

Imposta ITextFrameFormat::set_Transform su ArchUpPour per curvare l'intero riquadro di testo verso l'alto:

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

Il testo risultante:

![La trasformazione WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides per C++ fornisce un insieme di tipi di trasformazione predefiniti.
{{% /alert %}}

### **Applicare effetti 3D a forme e testo**

È possibile applicare effetti 3D a una forma o al suo testo. Smussi, estrusione, illuminazione e impostazioni della fotocamera controllano l'aspetto finale.

L'esempio seguente utilizza IThreeDFormat per aggiungere smussi circolari, estrusione arancione e un contorno rosso scuro al rettangolo. Dimensioni degli smussi, altezza dell'estrusione, larghezza e profondità del contorno sono misurate in punti. Un materiale plastico, illuminazione bilanciata ruotata di 40 gradi intorno all'asse Z e una fotocamera prospettica definiscono l'aspetto:

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

La forma risultante:

![L'effetto 3D della forma](shape_3D_effect.png)

Questo esempio applica una formattazione 3D simile al testo tramite ITextFrameFormat::get_ThreeDFormat. Smussi più piccoli modellano i bordi delle lettere, mentre estrusione e illuminazione conferiscono profondità al testo:

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

Il testo risultante:

![L'effetto 3D del testo](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'applicazione degli effetti 3D al testo o alle loro forme — e l'interazione tra questi effetti — è regolata da regole specifiche. Considera una scena che coinvolge sia il testo sia la forma che lo contiene. Un effetto 3D comprende la rappresentazione 3D dell'oggetto e la scena in cui è inserito.

- Se una scena è impostata sia per la forma sia per il testo, la scena della forma ha priorità e quella del testo viene ignorata.
- Se la forma non ha una scena propria ma ha una rappresentazione 3D, viene utilizzata la scena del testo.
- Se la forma non ha alcun effetto 3D, viene trattata come piatta e l'effetto 3D viene applicato solo al testo.

Questi comportamenti riguardano i metodi IThreeDFormat::get_LightRig e IThreeDFormat::get_Camera.
{{% /alert %}}

Per mantenere il testo piatto e leggibile conservando la formattazione 3D della forma, vedere Keep Text Flat on a 3D Shape per un confronto di entrambe le impostazioni e un esempio completo in C++.

## **FAQ**

**Posso utilizzare gli effetti WordArt con font o script diversi (ad esempio arabo, cinese)?**

Sì, Aspose.Slides per C++ supporta Unicode e funziona con tutti i principali font e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei font e il rendering possano dipendere dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno riflesse in tutte le diapositive associate.

**Gli effetti WordArt influenzano la dimensione del file della presentazione?**

Leggermente. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è generalmente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad es. PNG, JPEG) utilizzando [ISlide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/), o renderizzare singole forme con [IShape::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getimage/). Questo consente di vedere il risultato in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.