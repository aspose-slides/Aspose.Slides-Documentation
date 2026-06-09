---
title: Gerenciar gráficos SmartArt em apresentações no .NET
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /pt/net/manage-smartart-shape/
keywords:
- objeto SmartArt
- gráfico SmartArt
- estilo SmartArt
- cor SmartArt
- criar SmartArt
- adicionar SmartArt
- editar SmartArt
- alterar SmartArt
- acessar SmartArt
- tipo de layout SmartArt
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em .NET usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, localizar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar uma forma SmartArt**
Aspose.Slides for .NET agora facilita a adição de formas SmartArt personalizadas em seus slides a partir do zero. Aspose.Slides for .NET fornece a API mais simples para criar formas SmartArt da maneira mais fácil. Para criar uma forma SmartArt em um slide, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione uma forma SmartArt definindo seu LayoutType.
- Grave a apresentação modificada como um arquivo PPTX.

```c#
// Instanciar a apresentação
using (Presentation pres = new Presentation())
{

    // Acessar o slide da apresentação
    ISlide slide = pres.Slides[0];

    // Adicionar forma Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Salvar a apresentação
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Acessar uma forma SmartArt em um slide**
O código a seguir será usado para acessar as formas SmartArt adicionadas no slide da apresentação. No código de exemplo percorreremos cada forma dentro do slide e verificaremos se ela é uma forma SmartArt. Se a forma for do tipo SmartArt, faremos o cast para a instância SmartArt.

```c#
// Carregar a apresentação desejada
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Percorrer todas as formas dentro do primeiro slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape is ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```



## **Acessar uma forma SmartArt com um tipo de layout específico**
O código de exemplo a seguir ajuda a acessar a forma SmartArt com um LayoutType específico. Observe que não é possível alterar o LayoutType do SmartArt, pois ele é somente leitura e definido apenas quando a forma SmartArt é adicionada.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, caso seja SmartArt.
- Verifique a forma SmartArt com o LayoutType desejado e execute as ações necessárias posteriormente.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Percorrer todas as formas dentro do primeiro slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape is ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verificando o layout do SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```



## **Alterar o estilo de uma forma SmartArt**
O código de exemplo a seguir ajuda a acessar a forma SmartArt com um LayoutType específico.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, caso seja SmartArt.
- Encontre a forma SmartArt com o Estilo desejado.
- Defina o novo Estilo para a forma SmartArt.
- Salve a apresentação.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Percorrer todas as formas dentro do primeiro slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape is ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Verificando o estilo do SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Alterando o estilo do SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Salvando a apresentação
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Alterar o estilo de cor de uma forma SmartArt**
Neste exemplo, aprenderemos a alterar o estilo de cor de qualquer forma SmartArt. No código de exemplo a seguir será acessada a forma SmartArt com um estilo de cor específico e seu estilo será alterado.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a forma SmartArt.
- Obtenha a referência do primeiro slide usando seu Índice.
- Percorra cada forma dentro do primeiro slide.
- Verifique se a forma é do tipo SmartArt e faça o cast da forma selecionada para SmartArt, caso seja SmartArt.
- Encontre a forma SmartArt com o Estilo de Cor desejado.
- Defina o novo Estilo de Cor para a forma SmartArt.
- Salve a apresentação.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Percorrer todas as formas dentro do primeiro slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificar se a forma é do tipo SmartArt
        if (shape is ISmartArt)
        {
            // Fazer cast da forma para SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Verificando o tipo de cor do SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Alterando o tipo de cor do SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Salvando a apresentação
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso animar o SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [standard animations](/slides/pt/net/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, caminhos de movimento) assim como para outras formas.

**Como posso encontrar um SmartArt específico em um slide se não conheço seu ID interno?**

Defina e use o Texto Alternativo (AltText) e procure a forma por esse valor — esta é uma maneira recomendada de localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas etc.) e então [manipulate the group](/slides/pt/net/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para pré‑visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [render individual shapes](/slides/pt/net/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter toda a apresentação para PDF?**

Sim. O mecanismo de renderização visa alta fidelidade para [PDF export](/slides/pt/net/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.