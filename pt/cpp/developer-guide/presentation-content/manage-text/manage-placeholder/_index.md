---
title: "Gerenciar placeholders de apresentação em C++"
linktitle: "Gerenciar placeholders"
type: docs
weight: 10
url: /pt/cpp/manage-placeholder/
keywords:
- "marcador de posição"
- "marcador de texto"
- "marcador de imagem"
- "marcador de gráfico"
- "marcador de conteúdo"
- "texto de sugestão"
- "PowerPoint"
- "apresentação"
- "C++"
- "Aspose.Slides"
description: "Aprenda como inspecionar e editar marcadores de texto, imagem, gráfico e conteúdo e entender a herança de marcadores com Aspose.Slides para C++."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um determinado tipo de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Diferente de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe as informações de placeholder através do método [IShape::get_Placeholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_placeholder/). O método devolve um objeto [IPlaceholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iplaceholder/) ou `nullptr` para uma forma normal. Use [IPlaceholder::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iplaceholder/get_type/) para determinar o que o placeholder deve conter.

A interface da forma ainda é importante depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo costuma ser representado por um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iplaceholder/get_type/) quanto a interface da forma em tempo de execução em vez de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Aviso" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iplaceholder/get_type/) descreve o papel de um placeholder; ele não garante o tipo da forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a herança de placeholders**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getbaseplaceholder/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `nullptr` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders do primeiro slide e relata seus placeholders base:

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

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma local comum não tem placeholder base e não começa a herdar apenas por ocupar as mesmas coordenadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) antes de usar seu método [get_TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_textframe/).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

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

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/). Ele também identifica o placeholder pelo propósito em vez de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

O texto de sugestão é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder do layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/get_layoutslide/) e itere sobre [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_shapes/).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

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

O texto de sugestão não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Quando o usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar uma sugestão também não substitui o texto existente nos slides que usam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a tratar:

- Se o placeholder de imagem já estiver preenchido e for representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/get_picture/) e [ISlidesPicture::set_Image](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/set_image/).
- Se ainda for um placeholder vazio, adicione um frame de imagem nas coordenadas do placeholder com [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addpictureframe/) e remova o placeholder vazio.

O próximo exemplo trata ambos os casos e salva a apresentação:

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

A substituição criada para um placeholder vazio é um frame de imagem local, não um novo placeholder, porque [IShape::get_Placeholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_placeholder/) é somente leitura. Ela mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se manter a relação de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro e, depois, atualize o [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Gerenciar frames de imagem](/slides/pt/cpp/picture-frame/). Essas operações pertencem ao frame de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral costuma ter [PlaceholderType::Object](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType::Chart](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/pt/cpp/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/) apenas alterando [IPlaceholder::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iplaceholder/get_type/); o tipo é somente leitura. Para preencher programaticamente um gráfico ou área de conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os artigos dedicados à [gerência de gráficos](/slides/pt/cpp/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar conteúdo de texto ou imagem**

O exemplo a seguir, de ponta a ponta, abre um modelo, procura no primeiro slide por um placeholder de título ou imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou converter todos os placeholders para a mesma interface.

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

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou no mestre a partir da qual outro placeholder herda. Use [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getbaseplaceholder/) para recuperá‑lo. Uma forma local comum devolve `nullptr` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de sugestão através de um layout, mas o conteúdo real dos títulos está armazenado nos slides normais. Para substituir o texto de título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado (slide, layout, mestre, notas ou folhetos). Consulte [Gerenciar cabeçalho e rodapé da apresentação](/slides/pt/cpp/presentation-header-and-footer/) para exemplos completos.