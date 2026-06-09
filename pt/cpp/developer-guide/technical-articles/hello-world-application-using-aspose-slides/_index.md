---
title: Aplicação Hello World usando Aspose.Slides para C++
type: docs
weight: 80
url: /pt/cpp/hello-world-application-using-aspose-slides/
keywords:
- olá mundo
- aplicação
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Crie seu primeiro aplicativo C++ com Aspose.Slides, um exemplo simples Hello World que o prepara para automatizar apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação simples de **Hello World** no PowerPoint usando Aspose.Slides. O exemplo demonstra como criar uma nova apresentação, acessar o primeiro slide, adicionar um AutoShape retangular em uma posição especificada, inserir uma caixa de texto contendo o texto **Hello World**, e ajustar a formatação da forma e do texto.

Ele também explica como tornar o texto visível alterando sua cor para preto, ocultar a borda da forma definindo a cor da linha para branco, remover o preenchimento da forma e salvar a apresentação como um arquivo PPTX.

## **Etapas para criar um aplicativo Hello World**

Siga as etapas abaixo para criar um aplicativo **Hello World** usando a API Aspose.Slides para C++:

- Criar uma instância da classe Presentation
- Obter a referência do primeiro slide na apresentação, que é criado na instanciação de Presentation.
- Adicionar um AutoShape com ShapeType como Rectangle na posição especificada do slide.
- Adicionar um TextFrame ao AutoShape contendo Hello World como texto padrão
- Alterar a cor do texto para preto, pois ele é branco por padrão e não é visível no slide com fundo branco
- Alterar a cor da linha da forma para branco a fim de ocultar a borda da forma
- Remover o formato de preenchimento padrão da forma
- Finalmente, gravar a apresentação no formato de arquivo desejado usando o objeto Presentation

A implementação das etapas acima é demonstrada abaixo em um exemplo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // obter o primeiro slide
    auto slide = pres->get_Slides()->idx_get(0);

    // adicionar um AutoShape do tipo Retângulo
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // adicionar TextFrame ao Retângulo
    shape->AddTextFrame(u"Hello World");

    // alterar a cor do texto para Preto (que é Branco por padrão)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // alterar a cor da linha do retângulo para Branco
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // remover qualquer formatação de preenchimento na forma
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // salvar a apresentação no disco
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```