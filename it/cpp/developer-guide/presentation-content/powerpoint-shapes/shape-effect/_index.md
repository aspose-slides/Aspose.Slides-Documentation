---
title: Applica effetti forma nelle presentazioni usando C++
linktitle: Effetto forma
type: docs
weight: 30
url: /it/cpp/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflesso
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per C++ — crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Pur quanto gli effetti in PowerPoint possano essere usati per far risaltare una forma, essi differiscono da [riempimenti](/slides/it/cpp/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti risultano migliori di altre. Per questo motivo, PowerPoint dispone di opzioni sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione di due o più effetti noti per funzionare bene insieme. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Aspose.Slides per C++ supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adattarli al design della presentazione.

### **Applica un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per abbinare l'illuminazione e lo stile del tuo modello.

Questo codice C++ mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) a un rettangolo:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Effetto ombra](shadow_effect.png)

### **Applica un'ombra interna**

Quando riproduci lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende all'esterno della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), quindi configura [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Valori più alti del raggio di sfocatura producono bordi più morbidi.

Questo esempio C++ crea una scheda azzurra chiara con un'ombra interna grigio scuro e la salva come file PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) sul formato effetti della forma.

## **Applica un effetto riflesso**

Per applicare un effetto riflesso in Aspose.Slides per C++, è possibile aggiungere un riflesso simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle presentazioni conferendo alle forme un aspetto più curato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice C++ mostra come applicare l'[effetto riflesso](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) a una forma:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Effetto riflesso](reflection_effect.png)

## **Applica un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per C++, è possibile aggiungere un'aura luminosa soffusa intorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta le forme a distinguersi e aggiunge un elemento visivo attraente e accattivante alla presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle diapositive.

Questo codice C++ mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) a una forma:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Effetto bagliore](glow_effect.png)

## **Applica un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per C++, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più discreto e raffinato, perfetto per design che richiedono un aspetto delicato e più morbido. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice C++ mostra come applicare i [bordi morbidi](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) a una forma:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applica un effetto sfocatura**

Usa la sfocatura della forma per ammorbidire riempimento e contorno mantenendo la forma modificabile. Chiama [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) sul formato effetti della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, valori più alti producono una sfocatura più intensa. Un raggio pari a zero lascia l'aspetto invariato.

L'impostazione [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è limitata ai confini originali dipinti, inclusi i contorni. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto qui sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutti i casi. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio C++ crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti, quindi la aggiorna a 15 punti chiamando nuovamente [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Salva entrambe le versioni sfocate, poi chiama [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) e salva la forma senza sfocatura.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

La sfocatura della forma influisce contemporaneamente su riempimento e contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione immagine operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetti della forma senza convertire la forma in immagine.

## **Domande frequenti**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare effetti diversi, come ombra, riflesso e bagliore, su un'unica forma per creare un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, incluse forme automatiche, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare gli effetti a forme raggruppate?**

Sì, è possibile applicare gli effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.