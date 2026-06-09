---
title: Obter Limites de Parágrafo de Apresentações em C++
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/cpp/paragraph/
keywords:
- limites de parágrafo
- limites de trecho de texto
- coordenada do parágrafo
- coordenada do trecho
- tamanho do parágrafo
- tamanho do trecho de texto
- quadro de texto
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Saiba como recuperar os limites de parágrafos e trechos de texto no Aspose.Slides para C++ a fim de otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão Geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `GetRect()`, como obter as coordenadas de parágrafo e trecho dentro de um quadro de texto de célula de tabela, e destaca detalhes importantes como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas de parágrafo e trecho em um TextFrame**

Usando Aspose.Slides para C++, os desenvolvedores agora podem obter as coordenadas retangulares de um Parágrafo dentro da coleção de parágrafos de um TextFrame. Também permite obter as coordenadas de um trecho dentro da coleção de trechos de um parágrafo. Neste tópico, vamos demonstrar, com a ajuda de um exemplo, como obter as coordenadas retangulares de um parágrafo juntamente com a posição do trecho dentro de um parágrafo.

## **Obter coordenadas retangulares de um parágrafo**

O novo método **GetRect()** foi adicionado. Ele permite obter o retângulo de limites do parágrafo.

``` cpp
// Instanciar um objeto Presentation que representa um arquivo de apresentação
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Obter o tamanho de um parágrafo e trecho dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas do [Portion](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.portion) ou do [Paragraph](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.paragraph) em um quadro de texto de célula de tabela, você pode usar os métodos [IPortion::GetRect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) e [IParagraph::GetRect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Este código de exemplo demonstra a operação descrita:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**Em que unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se a [wrapping](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframeformat/set_wraptext/) estiver habilitada no [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/), o texto é quebrado para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas com confiabilidade para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para renderização/exportação.

**Como obter os parâmetros de formatação de parágrafo "efetivos", levando em conta a herança de estilo?**

Use a [estrutura de dados de formatação de parágrafo efetiva](/slides/pt/cpp/shape-effective-properties/); ela retorna os valores finais consolidados para recuos, espaçamento, quebra de linha, RTL e mais.