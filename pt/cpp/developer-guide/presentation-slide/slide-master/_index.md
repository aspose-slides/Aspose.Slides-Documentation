---
title: Gerenciar Slides Masters de Apresentação em C++
linktitle: Mestre de Slide
type: docs
weight: 80
url: /pt/cpp/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Gerencie slides masters no Aspose.Slides para C++: acesse, edite, clone, compare e remova slides masters em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e de rodapé. No PowerPoint, editar um slide master é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

O Aspose.Slides para C++ suporta o mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais geralmente não referenciam um master slide diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** - define o design e tema compartilhados.  
1. **Layout slide** - define um arranjo específico de marcadores de posição e formatação em nível de layout.  
1. **Normal slide** - contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e normal slides](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/). Todos os master slides em uma apresentação estão disponíveis por meio da coleção [Presentation::get_Masters](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um master slide e um layout slide definirem ambos um plano de fundo, os slides baseados nesse layout usarão o plano de fundo do layout. Para mais informações sobre layout slides, veja [Apply or Change Slide Layouts](/slides/pt/cpp/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização Slide Master em **View** > **Slide Master**.

![O comando Slide Master na guia View do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `get_Masters()` para acessar os master slides:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Você também pode obter o master slide usado por um slide normal através de seu layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **O que um Slide Master contém**

Um master slide é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos de master são listados na página da API [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/).

Membros de master slide comumente usados incluem:

| Membro | Objetivo |
| --- | --- |
| `get_Background()` | Define o plano de fundo do slide no nível master. |
| `get_Shapes()` | Armazena as formas colocadas no master, como logotipos, quadros de imagens e texto compartilhado. |
| `get_LayoutSlides()` | Armazena os layout slides que pertencem ao master. |
| `get_ThemeManager()` | Fornece acesso às APIs de tema do master. |
| `get_HeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `GetDependingSlides()` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Ao adicionar uma imagem a um master slide, ela aparece nos slides que utilizam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para mais informações sobre quadros de imagem, veja [Picture Frame](/slides/pt/cpp/picture-frame/).

## **Controlar a visibilidade de gráficos do Master**

Use [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/set_showmastershapes/) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Passe `false` para [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/set_showmastershapes/) no slide que deve omitir esses gráficos e `true` nos slides que devem exibi‑los.

O exemplo autocontido a seguir cria uma faixa decorativa azul em um master e em dois slides que utilizam o mesmo layout em branco. A faixa fica visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os próprios marcadores de posição do slide inicial.

### **Escolher o escopo da configuração**

Um slide normal usa seu master através de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/get_layoutslide/) e [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_masterslide/). Definir a propriedade em um slide individual afeta somente esse slide. Passar `false` para [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/layoutslide/set_showmastershapes/) oculta os gráficos do master para slides que utilizam esse layout compartilhado, mesmo que sua própria configuração seja `true`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e mantenha o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio master slide. Em um master, ela sempre retorna `false`, e atribuir `true` gera `System::NotSupportedException`. Aplique‑a a um slide normal ou a um layout em vez disso.

### **Diferenciar gráficos do plano de fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade das formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Os gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Presentation Background](/slides/pt/cpp/presentation-background/). |
| Excluir uma forma do master | Remove a forma de origem compartilhada, de modo que não fique mais disponível para nenhum slide que use esse master. |

## **Trabalhar com marcadores de posição**

Os placeholders são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais placeholders estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de placeholder estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos placeholders com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Você também pode formatar formas de placeholder que já existem em um master slide. O exemplo a seguir encontra o placeholder de título e aplica um preenchimento de gradiente linear:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de placeholders e formatação de texto, consulte [Set Prompt Text in Placeholder](/slides/pt/cpp/manage-placeholder/) e [Text Formatting](/slides/pt/cpp/text-formatting/).

## **Alterar o plano de fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro master slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para tópicos relacionados, veja [Presentation Background](/slides/pt/cpp/presentation-background/) e [Presentation Theme](/slides/pt/cpp/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/addclone/) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Se precisar clonar slides normais junto com seu master, veja [Clone Slides](/slides/pt/cpp/clone-slides/).

## **Adicionar vários Slide Masters**

Uma apresentação pode conter vários master slides. Isso é útil quando diferentes seções exigem diferentes marcas, estrutura de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comparar Slide Masters**

Os master slides podem ser comparados com o método `Equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/). A comparação verifica a estrutura e o conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slides, ou valores dinâmicos de placeholder, como a data atual.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Para mais informações, veja [Compare Presentation Slides](/slides/pt/cpp/compare-slides/).

## **Definir a visualização Slide Master como visualização padrão**

Use o método `set_LastView` em [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre inicialmente. O exemplo a seguir abre a apresentação na visualização Slide Master:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para mais configurações de visualização, veja [Save Presentation](/slides/pt/cpp/save-presentation/).

## **Remover master slides não utilizados**

Apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção do modelo.

Use [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/pt/cpp/aspose.slides/masterslidecollection/removeunused/) para remover masters não utilizados da coleção `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Você também pode usar o método de low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de placeholders. Um slide normal usa um layout slide, portanto herda tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisam de sistemas visuais ou marcas diferentes.

**Devo adicionar placeholders a um master slide ou a um layout slide?**

Na maioria dos casos, adicione placeholders aos layout slides. Coloque elementos visuais compartilhados e formatação compartilhada no master slide e, em seguida, coloque os placeholders de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um master slide que ainda está em uso?**

Não. Um master slide que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não utilizados que remove apenas masters que não estão em uso.