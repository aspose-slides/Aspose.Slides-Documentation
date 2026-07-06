---
title: Obter limites de parágrafo de apresentações em C++
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/cpp/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo no Aspose.Slides para C++ para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo de um [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) usando [IParagraph::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getrect/), como obter as coordenadas do parágrafo dentro de um quadro de texto de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de texto nos limites, a conversão para pixels e os valores de formatação de parágrafo efetivos.

## **Obter coordenadas retangulares de um parágrafo**

Use [IParagraph::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getrect/) para obter o retângulo delimitador de um parágrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) em um quadro de texto de célula de tabela, use [IParagraph::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getrect/). O retângulo retornado é relativo ao quadro de texto da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar das coordenadas em nível de slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Em que unidades as coordenadas do parágrafo são medidas?**

Elas são medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões do slide.

**A quebra de texto afeta os limites de um parágrafo?**

Sim. Se [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_wraptext/) estiver habilitado para o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/), o texto será quebrado para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando esta fórmula: pixels = pontos × (DPI / 72). O resultado depende do DPI escolhido para a renderização ou exportação.

**Como obtenho os parâmetros de formatação de parágrafo “efetivos”, levando em conta a herança de estilo?**

Use a [estrutura de dados de formatação de parágrafo efetiva](/slides/pt/cpp/shape-effective-properties/); ela devolve os valores finais consolidados para recuos, espaçamento, quebra de linha, RTL e mais.