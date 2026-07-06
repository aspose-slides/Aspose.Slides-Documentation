---
title: Obter Limites de Porção de Texto em Apresentações em C++
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/cpp/portion-bounds/
keywords:
- limites de porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como recuperar os limites de porções de texto em apresentações PowerPoint usando Aspose.Slides para C++."
---
## **Visão Geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar os limites de um fragmento de texto, aplicar formatação a apenas parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [IPortion::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/getrect/). Também mostra como obter as coordenadas do início de uma porção usando [IPortion::GetCoordinates](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/getcoordinates/). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida através da porção, parágrafo, quadro de texto e herança de tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter Limites de uma Porção de Texto**

Use [IPortion::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/getrect/) para recuperar o retângulo delimitador de uma porção de texto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Obter Coordenadas de uma Porção de Texto**

Use [IPortion::GetCoordinates](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/getcoordinates/) para recuperar as coordenadas do início de uma porção de texto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Perguntas Frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/cpp/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não o parágrafo inteiro.

**Como funciona a herança de estilo: o que uma porção sobrescreve e o que é herdado de um parágrafo ou quadro de texto?**

As propriedades ao nível da porção têm a precedência mais alta. Se uma propriedade não estiver definida na [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/), o Aspose.Slides a obtém da [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) ou do [theme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

[Regras de substituição de fontes](/slides/pt/cpp/font-selection-sequence/) são aplicadas. O texto pode ser reagrupado: métricas, hifenização e largura podem mudar, o que importa para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específico de porção independentemente do restante do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência no nível da [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) podem ser diferentes dos fragmentos vizinhos.