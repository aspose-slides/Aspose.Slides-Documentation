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
description: "Redimensione facilmente formas em slides do PowerPoint e OpenDocument com Aspose.Slides para C++ - automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais comuns dos clientes do Aspose.Slides para C++ é como redimensionar formas de modo que, quando o tamanho do slide mudar, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para evitar que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que se ajustem ao novo layout do slide.

```cpp
// Carregar o arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Obter o tamanho original do slide.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Alterar o tamanho do slide sem escalar as formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Obter o novo tamanho do slide.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Redimensionar e reposicionar formas em cada slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Redimensionar o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Redimensionar a posição da forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Se um slide contiver uma tabela, o código acima não funcionará corretamente. Nesse caso, cada célula da tabela deve ser redimensionada.
{{% /alert %}} 

Use o código a seguir para redimensionar slides que contêm tabelas. Para tabelas, definir a largura ou a altura é um caso especial: você deve ajustar as alturas das linhas individuais e as larguras das colunas para mudar o tamanho geral da tabela.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obter o tamanho original do slide.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Alterar o tamanho do slide sem escalar as formas existentes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Obter o novo tamanho do slide.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Redimensionar o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Redimensionar a posição da forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Redimensionar o tamanho da forma.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Redimensionar a posição da forma.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Redimensionar o tamanho da forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Redimensionar a posição da forma.
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

## **FAQ**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou que as formas fiquem desalinhadas.

**O código fornecido funciona para todos os tipos de forma?**

O exemplo básico funciona para a maioria dos tipos de forma (caixas de texto, imagens, gráficos, etc.). Contudo, para tabelas, você precisa tratar linhas e colunas separadamente, pois a altura e a largura de uma tabela são determinadas pelas dimensões das células individuais.

**Como redimensionar tabelas ao redimensionar um slide?**

É necessário percorrer todas as linhas e colunas da tabela e redimensionar suas alturas e larguras proporcionalmente, como mostrado no segundo exemplo de código.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim, mas você também deve percorrer os [Mestres](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/) e os [Slides de layout](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_layoutslides/) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

**Posso mudar a orientação do slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Você pode usar [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/set_orientation/) para mudar a orientação. Certifique‑se de ajustar a lógica de escala adequadamente para preservar o layout.

**Existe um limite para o tamanho do slide que posso definir?**

O Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Você pode verificar o método `get_AspectRatioLocked` da forma antes de escalar. Se estiver bloqueado, ajuste a largura ou a altura proporcionalmente em vez de escalá‑las individualmente.