---
title: Gerenciar SmartArt em Apresentações PowerPoint Usando C++
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/cpp/manage-smartart/
keywords:
- SmartArt
- texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagens
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para C++ usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para C++, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartart/get_allnodes/), então leia o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) retornado por [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartlayouttype/), altera para o valor `BasicProcess` e salva a apresentação.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verificar se um nó SmartArt está oculto**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartlayouttype/) e verifica o estado de ocultação do nó.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) e [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) definem como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir os nós filhos para pendurar à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/organizationchartlayouttype/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Criar um organograma de imagens**

Um organograma de imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagem. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. O método [SmartArt::set_IsReversed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartart/set_isreversed/) altera a direção do diagrama de esquerda para a direita para direita para a esquerda, ou o inverso, quando o layout SmartArt selecionado suporta a reversão.

**Como posso copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/cpp/shape-manipulations/) com [ShapeCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/cpp/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam o tamanho, a posição e a formatação.

**Como faço para renderizar o SmartArt em uma imagem raster para visualização ou exportação para a web?**

[Renderize o slide](/slides/pt/cpp/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como posso encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um valor distinto em [Shape::set_AlternativeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/set_alternativetext/) ou [Shape::set_Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/set_name/) na forma SmartArt, procure esse valor em [BaseSlide::get_Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseslide/get_shapes/), e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/ismartart/).