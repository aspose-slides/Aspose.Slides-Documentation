---
title: Gerenciar Marcadores de Apresentação em C++
linktitle: Gerenciar Marcadores
type: docs
weight: 10
url: /pt/cpp/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de prompt
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como inspecionar e editar marcadores de texto, imagem, gráfico e conteúdo e entender a herança de marcadores com Aspose.Slides para C++."
---
## **Visão geral**

Um marcador de posição é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são marcadores de título, corpo, imagem, gráfico e marcadores de conteúdo de uso geral. Ao contrário de uma forma comum, um marcador de posição pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe informações sobre marcadores de posição através do método [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). O método devolve um objeto [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) ou `nullptr` para uma forma normal. Use [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) para determinar o que o marcador de posição deve conter.

A interface da forma ainda é importante depois que você conhece o tipo de marcador de posição:

- Um marcador de texto, imagem, gráfico ou conteúdo vazio geralmente é representado por um [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Um marcador de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Um marcador de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Um marcador de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) quanto a interface da forma em tempo de execução, em vez de assumir que todo marcador de posição é um [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) descreve o papel de um marcador de posição; ele não garante o tipo de forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Compreender a Herança de Marcadores de Posição**

Os marcadores de posição formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, marcadores de posição no nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os marcadores de posição para esse slide e pode herdar do seu layout.

Chame [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) para subir um nível nessa hierarquia. Um marcador de posição de slide normalmente devolve seu marcador de layout; um marcador de layout pode devolver seu marcador mestre. O método devolve `nullptr` quando a forma não tem marcador de base.

O exemplo a seguir lista os marcadores de posição no primeiro slide e relata seus marcadores de base:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Editar um marcador de posição em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não tem marcador de base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover o Status de Marcador de Posição**

Ao adaptar um modelo, use [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) para manter um objeto existente como uma forma ordinária. Seu método [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) devolve `nullptr`, mas a forma permanece na coleção do slide. Em contraste, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) exclui a forma da coleção.

O exemplo a seguir requer `template.pptx` com pelo menos um slide e um marcador de texto não vazio no primeiro slide. Use um marcador com formatação herdada do seu layout ou mestre para ver o efeito de remover esse relacionamento. O exemplo verifica que a mesma forma permanece, chama o método novamente na forma agora ordinária e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de marcador de posição não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa deliberadamente essas configurações inalteradas, de modo que a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ficar com coordenadas e dimensões zero após a chamada e tornar‑se invisível, embora permaneça na coleção.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Chamando o método em uma forma ordinária não tem efeito.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Para um marcador correspondente, as três verificações imprimem `True`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens da caixa de texto, ancoragem vertical, preenchimento e configurações de linha herdadas podem mudar quando o relacionamento do marcador de posição é removido. Por exemplo, a formatação de título herdada pode recair para a formatação de texto comum. Consulte [Slide Layout](/slides/pt/cpp/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência pretendida, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores de formatação efetiva necessários para variáveis separadas. Recupere esses valores por meio de [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), e [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar depois que o relacionamento for removido. Aplique explicitamente os valores capturados à forma ordinária posteriormente, incluindo família, tamanho, estilo e cor da fonte, configurações de parágrafo, configurações de caixa de texto, preenchimento e linha usados pelo seu modelo.

A geometria da forma herdada também pode precisar ser atribuída explicitamente através de [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Para um marcador de texto retangular, isso significa atribuir [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa exigem que essas configurações sejam tratadas também.

## **Alterar Texto em um Marcador de Posição**

Marcadores de título, título‑centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se a forma é um [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) antes de usar seu método [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/).

Este exemplo atualiza o primeiro marcador de título no primeiro slide e salva o resultado:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Esse padrão evita converter marcadores de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Também identifica o marcador pelo propósito em vez de depender de um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

O texto de prompt é a instrução exibida em tempo de design em um marcador de posição vazio, como *Clique para adicionar título*. Defina um texto de prompt personalizado no marcador de posição do layout em vez de tentar alcançá‑lo pela coleção de formas de um slide normal. Acesse o layout através de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) e itere sobre [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

O texto de prompt não é conteúdo de slide normal. Ele é destinado a marcadores de posição vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui o texto existente nos slides que utilizam o layout.

## **Atualizar um Marcador de Imagem**

Existem dois casos a serem tratados:

- Se o marcador de imagem já estiver preenchido e representado por um [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) e [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Se ainda for um marcador vazio, adicione uma caixa de imagem nas coordenadas do marcador usando [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) e remova o marcador vazio.

O exemplo a seguir suporta ambos os casos e salva a apresentação:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

A substituição criada para um marcador vazio é uma caixa de imagem local, não um novo marcador, porque [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) é somente leitura. Ela mantém a posição reservada, mas não herda mais o comportamento específico de marcador. Se preservar o relacionamento de marcador for essencial, prepare e preencha o marcador no PowerPoint primeiro e, em seguida, atualize o [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, consulte [Manage Picture Frames](/slides/pt/cpp/picture-frame/). Essas operações pertencem à caixa de imagem ou ao preenchimento da imagem, não aos metadados do marcador.

## **Trabalhar com Marcadores de Gráfico e de Conteúdo**

Um marcador de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Este exemplo encontra tal gráfico tanto pelo tipo de marcador quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Um marcador de conteúdo geral costuma ter [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides não converte um marcador de texto vazio [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) apenas alterando [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); o tipo é somente leitura. Para preencher programaticamente uma área vazia de gráfico ou conteúdo, adicione o objeto necessário nas coordenadas do marcador e, em seguida, remova o marcador vazio. O exemplo a seguir faz isso para um gráfico:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do marcador, mas não herda do marcador de layout. Use os artigos dedicados de [chart management articles](/slides/pt/cpp/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo Completo: Atualizar Texto ou Conteúdo de Imagem**

O exemplo completo a seguir abre um modelo, procura o primeiro slide por um marcador de título ou de imagem, verifica os tipos de marcador e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou converter todos os marcadores para a mesma interface.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**O que é um marcador de base?**

Um marcador de base é a forma correspondente no layout ou mestre da qual outro marcador herda. Use [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) para recuperá‑lo. Uma forma ordinária local devolve `nullptr` porque não faz parte da hierarquia de marcadores.

**Posso alterar todos os títulos de slide editando um marcador de layout?**

Você pode mudar a formatação herdada ou o texto de prompt através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real dos títulos em toda a apresentação, itere sobre os slides e atualize cada marcador de título.

**Como gerenciar os marcadores de data, número de slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo de slide, layout, mestre, notas ou folhetos apropriado. Consulte [Manage Presentation Header and Footer](/slides/pt/cpp/presentation-header-and-footer/) para exemplos completos.