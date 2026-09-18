---
title: Criar e Modificar Comportamentos de Animação Personalizados em C++
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/cpp/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para C++."
---
## **Visão geral**

Os comportamentos de animação personalizados permitem controlar operações individuais dentro de um efeito de animação, como mudar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades permanecem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, consulte [Shape Animation](/slides/pt/cpp/shape-animation/).

## **Entenda o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- O [get_Timeline](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_timeline/) do slide contém sua sequência principal e sequências interativas.
- Uma [ISequence](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [IEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/) identifica a forma alvo, preset, subtipo e tempo do efeito.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_behaviors/) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade etc.

## **Criar comportamentos individuais**

Chame [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) para criar um efeito e acessar sua coleção [get_Behaviors](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_behaviors/). Um preset pode preencher essa coleção automaticamente. Mantenha suas operações ao estender o preset ou use [Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/clear/) ao substituí‑las deliberadamente.

[IBehaviorFactory](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. O movimento é abordado em [Build a Motion Path](#build-a-motion-path). Cada exemplo de criação é código autocontido para ser executado dentro de uma função; exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [CreateRotationEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) para criar uma rotação. [get_By](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/irotationeffect/get_by/) especifica um ângulo relativo em graus; [get_From](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/irotationeffect/get_from/) e [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/irotationeffect/get_to/) especificam pontos finais.

O exemplo inicia com um efeito Spin, substitui suas operações de preset por um comportamento de rotação e dá a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário um ângulo inicial explícito.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo utilizam este arquivo.

### **Escala**

Use [CreateScaleEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) com percentuais X/Y: [get_From](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/iscaleeffect/get_from/) e [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/iscaleeffect/get_to/) descrevem o tamanho inicial e final, enquanto [get_By](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/iscaleeffect/get_by/) descreve uma alteração relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % em dois segundos. Usar porcentagens horizontais e verticais iguais mantém as proporções da forma; porcentagens diferentes esticariam uma dimensão mais que a outra.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Cor**

Use [CreateColorEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) para mudar o preenchimento de azul para laranja. [get_From](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icoloreffect/get_from/) e [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icoloreffect/get_to/) são cores; [get_By](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icoloreffect/get_by/) é um deslocamento de cor. [IBehavior::get_Properties](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehavior/get_properties/) identifica o atributo que está sendo animado.

O preenchimento sólido da forma é inicializado como azul, coincidindo com a cor inicial da animação. Selecionar o atributo de cor de preenchimento indica ao comportamento qual parte da forma deve ser alterada; os pontos finais de cor por si só não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtro**

Use [CreateFilterEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) para selecionar um wipe. [get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) e [get_Reveal](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) especificam o filtro, a direção e se a forma será revelada ou ocultada.

Este exemplo configura um wipe de dois segundos que revela a forma usando o subtipo de direção à direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após a remoção das operações originais do preset.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Propriedade**

Use [CreatePropertyEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) para animar a opacidade. [get_From](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ipropertyeffect/get_to/) e [get_By](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ipropertyeffect/get_by/) são strings interpretadas usando [get_ValueType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) e [get_CalcMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Escolha pontos finais ou um deslocamento relativo em vez de definir os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. A interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final adequados ao atributo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Definir**

Use [CreateSetEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) para atribuir visibilidade através de [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/iseteffect/get_to/). Um comportamento de definição não interpola entre pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. Em C++, encapsule a string como um objeto antes de atribuí‑la ao comportamento de definição. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Essa operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Comando**

Use [CreateCommandEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) e configure [get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) e [get_ShapeTarget](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Coloque uma gravação WAV chamada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [AddAudioFrameEmbedded](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) e anexa um comando de reprodução ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando isolada não identifica qual objeto de mídia controlar. O efeito está configurado para iniciar ao clicar durante a apresentação.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um player de slideshow que suporte o comando e seu alvo de mídia.

## **Gerenciar a coleção de comportamentos**

[IBehaviorCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/) oferece [Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/remove/) e [RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Este exemplo abre `rotation.pptx`, adiciona escala, move‑a antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem criar uma cópia.

A sequência de edições altera a coleção de rotação‑escala para escala‑rotação e, em seguida, apenas para escala. Os índices referem‑se à coleção atual, de modo que a remoção usa o novo índice da rotação após a reordenação. A enumeração final confirma qual comportamento será salvo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

A saída é `ScaleEffect`: somente a escala permanece. A ordem da coleção, por si só, não agenda comportamentos um após o outro. Limpe a coleção apenas ao substituir todas as suas operações.

## **Configurar o tempo do comportamento**

[IBehavior::get_Timing](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehavior/get_timing/) expõe [ITiming](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/), independentemente de [IEffect::get_Timing](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_timing/). O tempo do efeito agenda o efeito envolvente; o tempo do comportamento descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina [get_Duration](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_duration/) e [get_TriggerDelayTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) em segundos, depois configure [get_RepeatCount](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_accelerate/) e [get_Decelerate](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_decelerate/) são frações da duração; mantenha a soma deles em no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

O comportamento usa duração de dois segundos, atraso de meio segundo e contagem de repetição 3. Os primeiros e últimos 20 % de sua duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [get_RepeatDuration](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), e [get_RepeatUntilNextClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); escolha uma política em vez de habilitá‑las todas simultaneamente. [get_AutoReverse](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itiming/get_autoreverse/) reproduz a animação ao contrário após a passagem direta. Aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Construir um caminho de movimento**

Use [CreateMotionEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) para criar movimento. Seus [get_From](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_to/) e [get_By](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_by/) descrevem coordenadas baseadas em percentual ou deslocamentos. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/motionpath/) e atribua‑o a [IMotionEffect::get_Path](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/motioncommandpathtype/) seleciona a operação:

| Comando | Pontos | Significado |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorna à posição inicial. |
| End | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/motionpathpointstype/) descreve características de edição de ponto, como ponto de canto ou suave. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo avança para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é independente de [get_Origin](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_origin/), que seleciona a referência do caminho, e de [get_PathEditMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), que controla como o caminho se move quando a forma é movida.

### **Criar um caminho reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [IMotionPath::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotionpath/add/) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0.25, 0), dando à rota um deslocamento horizontal de um quarto da largura do slide. O comando final não possui pontos coordenados. Após atribuir o caminho, adicionar o comportamento de movimento ao efeito conecta essa rota ao retângulo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivos a seguir utilizam esta estrutura conhecida.

### **Comparar coordenadas absolutas e relativas**

Esses dois objetos de caminho descrevem a mesma rota. O comando absoluto termina em (0.3, 0.1); o comando relativo adiciona (0.1, 0.1) à posição atual, (0.2, 0).

Ambos os caminhos iniciam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas resultaria em uma rota diferente.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para aquele comando.

### **Substituir uma linha por uma curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos do ponto final.

A posição inicial é fornecida pelo comando anterior. Os primeiros dois pontos modelam a curva, enquanto o terceiro é seu destino; não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e a matriz de pontos mantém o segmento consistente com sua nova geometria.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

O caminho em `curve.pptx` ainda possui três comandos; seu comando do meio agora define uma curva.

## **Inspecionar e editar um caminho salvo**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioncmdpath/) expõe [get_Points](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), e [get_IsRelative](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Os exemplos a seguir usam o caminho conhecido de três comandos em `motion.pptx`. Para entradas arbitrárias, localize o efeito pretendido e verifique tipos de comando e contagem de pontos antes de editar por índice.

### **Ler comandos e coordenadas**

Leia o caminho sem alterá‑lo. Comandos de fim e de fechamento de laço não precisam de pontos, portanto permita um array de pontos nulo.

A saída associa cada comando ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

A listagem contém um ponto inicial, uma linha absoluta terminando em (0.25, 0) e um comando de fim.

### **Alterar um ponto final**

Abra `motion.pptx` e substitua o array de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar o tipo de comando, o tempo ou a posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição e não um deslocamento acrescentado.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

A linha em `motion-endpoint.pptx` termina em (0.4, 0.1); o arquivo original permanece inalterado.

### **Substituir um segmento**

Use [Insert](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotionpath/insert/) e [RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/imotionpath/removeat/) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra a substituição de um objeto de comando em vez de editar suas coordenadas existentes. Após a inserção, a coleção contém temporariamente o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa a nova rota no lugar.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0.2, 0.1) e o comando de fim por último.

## **Modificar e verificar um comportamento existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [IRotationEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/irotationeffect/), altera o ângulo e verifica o valor salvo após reabrir.

A verificação de tipo permite que o laço ignore comportamentos que não são rotações. A segunda carga lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica dados persistidos em vez do valor ainda mantido na memória. Este exemplo ainda supõe que o efeito conhecido esteja primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

A saída é `Rotation preserved: True`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma alvo, efeito, tipos e ordem dos comportamentos, tempo e comandos de caminho. Use tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Read Shape Animations](/slides/pt/cpp/shape-animation/#read-shape-animations) para percorrer sequências principais e interativas.

## **Ordem dos comportamentos, presets e reprodução**

A ordem em [IBehaviorCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma lista de reprodução na qual cada comportamento espera automaticamente pelo anterior. O tempo e o efeito envolvente determinam o agendamento. Os comportamentos podem se sobrepor, e operações na mesma propriedade podem interagir através de [get_Additive](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehavior/get_additive/) e [get_Accumulate](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Não use apenas reordenação da coleção para agendar “mover, então girar”; use tempo explícito ou efeitos separados como descrito em [Shape Animation](/slides/pt/cpp/shape-animation/).

O [get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_type/) e [get_Subtype](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/get_subtype/) do efeito descrevem seu preset. Eles não fornecem uma descrição completa de uma árvore de comportamentos editada. Escolha o preset e o subtipo antes de personalizar comportamentos: mudar o preset pode reconstruir a coleção e descartar suas operações customizadas. Por exemplo, mudar um efeito Spin customizado para Fade pode substituir seu comportamento de rotação por comportamentos de set e filter. Inspecione a coleção novamente após mudar um preset ou subtipo. Limpar comportamentos do preset também pode remover operações de visibilidade ou inicialização que o preset necessita. Os exemplos deliberadamente usam formas visíveis e substituem os comportamentos; não reconstruem a implementação de cada preset.

## **Compatibilidade de formatos**

Uma árvore de comportamentos preservada não garante reprodução idêntica em todos os visualizadores ou renderizadores de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra para confirmar a árvore de comportamentos editável, então teste a reprodução na versão do PowerPoint pretendida. |
| PPT | A representação binária legada pode divergir do PPTX. Teste um ciclo separado de salvar‑reabrir e reprodução; não infira suporte a toda combinação customizada apenas por um output PPTX bem‑sucedido. |
| PDF, PNG, JPEG e outras imagens estáticas de slide | Contêm uma representação estática do slide, não uma linha de tempo reproduzível ou um quadro final de animação garantido. |
| [HTML5](/slides/pt/cpp/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações customizadas no navegador. |
| [Animated GIF](/slides/pt/cpp/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não comportamentos editáveis ou interação por clique. Verifique o movimento realmente renderizado. |
| [Video](/slides/pt/cpp/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte é limitado às [animações e efeitos suportados](/slides/pt/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) do renderizador; comandos e eventos interativos não se tornam uma linha de tempo editável. |

## **FAQ**

**Por que meu efeito contém comportamentos antes de eu adicionar algum?**

Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende o preset ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele reproduza primeiro?**

Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**

Ele marca o término do caminho e não requer coordenadas. Ao inspecionar um caminho lido de um arquivo, verifique se o array de pontos é nulo.

**Um ciclo bem‑sucedido de ida e volta é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades verificadas. Teste o player de slideshow ou a exportação animada separadamente para confirmar o comportamento visual.