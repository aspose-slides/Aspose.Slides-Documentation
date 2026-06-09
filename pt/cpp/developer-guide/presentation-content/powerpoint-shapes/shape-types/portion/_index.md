---
title: Gerenciar Porções de Texto em Apresentações Usando C++
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/cpp/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a gerenciar porções de texto em apresentações PowerPoint usando Aspose.Slides para C++, aumentando o desempenho e a personalização."
---
## **Introdução**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

## **Obter Coordenadas de uma Porção de Texto**
O método GetCoordinates() foi adicionado às classes IPortion e Portion, permitindo recuperar as coordenadas do início da porção:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **Perguntas Frequentes**

**Posso aplicar um hiperlink a apenas parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hiperlink](/slides/pt/cpp/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não o parágrafo inteiro.

**Como funciona a herança de estilos: o que um Portion sobrescreve e o que é obtido do Paragraph/TextFrame?**

As propriedades no nível de Portion têm a precedência mais alta. Se uma propriedade não estiver definida no [Portion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portion/), o mecanismo a obtém do [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/); se também não estiver definida lá, ela vem do [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para um Portion estiver ausente na máquina/servidor de destino?**

As [Regras de substituição de fontes](/slides/pt/cpp/font-selection-sequence/) são aplicadas. O texto pode ser refluído: métricas, hifenização e largura podem mudar, o que importa para um posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico de uma Portion de forma independente do restante do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência no nível do [Portion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.