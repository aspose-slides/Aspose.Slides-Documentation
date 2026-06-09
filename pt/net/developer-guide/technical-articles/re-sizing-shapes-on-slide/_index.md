---
title: Redimensionar formas em slides de apresentação no .NET
type: docs
weight: 130
url: /pt/net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Redimensione facilmente formas em slides do PowerPoint e OpenDocument com Aspose.Slides para .NET — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais comuns dos clientes do Aspose.Slides para .NET é como redimensionar formas de modo que, quando o tamanho do slide mudar, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para evitar que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que se ajustem ao novo layout do slide.

```c#
// Carregar o arquivo de apresentação.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obter o tamanho original do slide.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Alterar o tamanho do slide sem dimensionar as formas existentes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obter o novo tamanho do slide.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionar e reposicionar as formas em cada slide.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Dimensionar o tamanho da forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Dimensionar a posição da forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Se um slide contiver uma tabela, o código acima não funcionará corretamente. Nesse caso, cada célula da tabela deve ser redimensionada.
{{% /alert %}}

Use o código a seguir para redimensionar slides que contêm tabelas. Para tabelas, definir a largura ou a altura é um caso especial: você deve ajustar as alturas das linhas individuais e as larguras das colunas para alterar o tamanho geral da tabela.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obter o tamanho original do slide.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Alterar o tamanho do slide sem dimensionar as formas existentes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Obter o novo tamanho do slide.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Dimensionar o tamanho da forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Dimensionar a posição da forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Dimensionar o tamanho da forma.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Dimensionar a posição da forma.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Dimensionar o tamanho da forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Dimensionar a posição da forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou as formas fiquem desalinhadas.

**O código fornecido funciona para todos os tipos de forma?**

O exemplo básico funciona para a maioria dos tipos de forma (caixas de texto, imagens, gráficos etc.). No entanto, para tabelas, é necessário tratar linhas e colunas separadamente, pois a altura e a largura de uma tabela são determinadas pelas dimensões das células individuais.

**Como redimensionar tabelas ao redimensionar um slide?**

É preciso percorrer todas as linhas e colunas da tabela e redimensionar suas alturas e larguras proporcionalmente, conforme mostrado no segundo exemplo de código.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim, mas você também deve percorrer [Masters](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/masters/) e [LayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/layoutslides/) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Você pode definir [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/pt/net/aspose.slides/islidesize/orientation/) para mudar a orientação. Certifique‑se de ajustar a lógica de escala adequadamente para preservar o layout.

**Existe um limite para o tamanho de slide que posso definir?**

O Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Você pode verificar a propriedade `AspectRatioLocked` da forma antes de escalar. Se estiver bloqueada, ajuste a largura ou a altura proporcionalmente em vez de escalá‑las individualmente.