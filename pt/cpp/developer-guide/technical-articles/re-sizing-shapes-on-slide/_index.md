---
title: Redimensionar formas em slides de apresentação
type: docs
weight: 100
url: /pt/cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para C++ — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais comuns dos clientes do Aspose.Slides for C++ é como redimensionar formas de modo que, quando o tamanho do slide mudar, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para evitar que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que se ajustem ao novo layout do slide.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Carregue o arquivo da apresentação.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Obtenha o tamanho original do slide.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Altere o tamanho do slide sem escalar as formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Obtenha o novo tamanho do slide.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Redimensione e reposicione as formas em cada slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Escale o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escale a posição da forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Se um slide contiver uma tabela, o código acima não funcionará corretamente. Nesse caso, cada célula da tabela deve ser redimensionada.
{{% /alert %}} 

Use o código a seguir para redimensionar slides que contenham tabelas. Para tabelas, definir a largura ou altura é um caso especial: você deve ajustar as alturas das linhas individuais e as larguras das colunas para mudar o tamanho geral da tabela.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtenha o tamanho original do slide.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Altere o tamanho do slide sem escalar as formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Obtenha o novo tamanho do slide.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Escale o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escale a posição da forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Escale o tamanho da forma.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Escale a posição da forma.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Escale o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Escale a posição da forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

### Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou que as formas fiquem desalinhadas.

### O código fornecido funciona para todos os tipos de forma?

O exemplo básico funciona para a maioria dos tipos de forma (caixas de texto, imagens, gráficos, etc.). Contudo, para tabelas, é necessário tratar linhas e colunas separadamente, pois a altura e a largura de uma tabela são determinadas pelas dimensões das células individuais.

### Como redimensionar tabelas ao redimensionar um slide?

É preciso percorrer todas as linhas e colunas da tabela e redimensionar suas alturas e larguras proporcionalmente, como mostrado no segundo exemplo de código.

### Esse redimensionamento funciona para slides mestre e slides de layout?

Sim, mas você também deve percorrer os [Masters](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/) e os [Layout slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_layoutslides/) e aplicar a mesma lógica de dimensionamento às suas formas para garantir consistência em toda a apresentação.

### Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?

Sim. Você pode usar [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/set_orientation/) para mudar a orientação. Certifique‑se de definir a lógica de dimensionamento adequadamente para preservar o layout.

### Existe um limite para o tamanho de slide que eu posso definir?

Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

### Como posso impedir que formas com proporção fixa fiquem distorcidas?

Você pode verificar o método `get_AspectRatioLocked` da forma antes de dimensionar. Se estiver bloqueado, ajuste a largura ou a altura proporcionalmente, em vez de dimensioná‑las individualmente.