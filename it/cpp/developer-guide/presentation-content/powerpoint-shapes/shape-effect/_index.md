---
title: Applicare effetti di forma nelle presentazioni usando C++
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
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando Aspose.Slides per C++ — crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/cpp/shape-formatting/#gradient-fill) o contorni. Usando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

<img src="shape-effect.png" alt="effetto-forma" style="zoom:50%;" />

* PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma. 

* Alcune combinazioni di effetti appaiono migliori di altre. Per questo motivo, PowerPoint fornisce le opzioni sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione nota di due o più effetti dall'aspetto gradevole. In questo modo, selezionando un preset, non sarà necessario perdere tempo a testare o combinare diversi effetti per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.effect_format/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Questo codice C++ mostra come applicare l'effetto ombra esterna ([OuterShadowEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) a un rettangolo:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Applicare un effetto riflesso**

Questo codice C++ mostra come applicare l'effetto di riflesso a una forma:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **Applicare un effetto bagliore**

Questo codice C++ mostra come applicare l'effetto bagliore a una forma:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **Applicare un effetto bordi morbidi**

Questo codice C++ mostra come applicare i bordi morbidi a una forma:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflesso e bagliore, su una singola forma per creare un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, incluse autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare gli effetti a forme raggruppate?**

Sì, è possibile applicare gli effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.