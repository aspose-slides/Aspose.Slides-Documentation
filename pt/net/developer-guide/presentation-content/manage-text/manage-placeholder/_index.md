---
title: Gerenciar Marcadores de Posição de Apresentação em .NET
linktitle: Gerenciar Marcadores de Posição
type: docs
weight: 10
url: /pt/net/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de sugestão
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para .NET com facilidade: substitua texto, personalize sugestões e defina transparência de imagem no PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição em slides e alterar seu texto, definir texto de sugestão personalizado para layouts de marcadores de posição e ajustar a transparência de uma imagem usada como plano de fundo de marcador de posição. Também inclui um FAQ curto que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações de marcador de posição podem ser aplicadas por meio de layouts ou mestres e aponta para o gerenciamento de marcadores de posição de cabeçalho e rodapé.

## **Alterar texto em um marcador de posição**

Usando [Aspose.Slides for .NET](/slides/pt/net/), você pode encontrar e modificar marcadores de posição em slides de apresentações. Aspose.Slides permite que você faça alterações no texto de um marcador de posição.

**Pré-requisito**: Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no aplicativo padrão Microsoft PowerPoint.

Veja como usar o Aspose.Slides para substituir o texto no marcador de posição dessa apresentação:

1. Instanciar a classe [`Presentation`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e passar a apresentação como argumento.
2. Obter uma referência ao slide através de seu índice.
3. Iterar pelas formas para encontrar o marcador de posição.
4. Converter a forma do marcador de posição para um [`AutoShape`](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) e alterar o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/). 
5. Salvar a apresentação modificada.

```c#
 // Instancia a classe Presentation
 using (Presentation pres = new Presentation("ReplacingText.pptx"))
 {
 
     // Acessa o primeiro slide
     ISlide sld = pres.Slides[0];
 
     // Itera pelas formas para encontrar o placeholder
     foreach (IShape shp in sld.Shapes)
         if (shp.Placeholder != null)
         {
             // Altera o texto em cada placeholder
             ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
         }
 
     // Salva a apresentação no disco
     pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Definir texto de sugestão em um marcador de posição**

Layouts padrão e pré-construídos contêm textos de sugestão de marcador de posição, como ***Clique para adicionar um título*** ou ***Clique para adicionar um subtítulo***. Usando Aspose.Slides, você pode inserir seus textos de sugestão preferidos em layouts de marcadores de posição.

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itera através do slide
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // O PowerPoint exibe "Clique para adicionar título"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Adiciona subtítulo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Definir transparência da imagem do marcador de posição**

Aspose.Slides permite que você defina a transparência da imagem de fundo em um marcador de posição de texto. Ao ajustar a transparência da imagem em tal quadro, você pode fazer o texto ou a imagem se destacarem (dependendo das cores do texto e da imagem).

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre que a forma do slide herda — tipo, posição e algumas formatações vêm dela. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como posso atualizar todos os títulos ou legendas em uma apresentação sem iterar sobre cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts/nesse mestre herdarão a alteração automaticamente.

**Como controlo os marcadores de posição padrão de cabeçalho/rodapé — data & hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, notas/folhetos) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.