---
title: Clonar Slides de Apresentação em .NET
linktitle: Clonar Slides
type: docs
weight: 40
url: /pt/net/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides para .NET. Siga nossos exemplos de código claros para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. O Aspose.Slides também permite copiar (clonar) qualquer slide e, em seguida, inserir o slide clonado na apresentação atual ou em qualquer outra apresentação aberta. A clonagem de slides cria um novo slide que os desenvolvedores podem modificar sem afetar o slide original. Existem várias maneiras de clonar um slide:

- Clonar ao final de uma apresentação.
- Clonar em outra posição dentro de uma apresentação.
- Clonar ao final de outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar juntamente com seu slide mestre em outra apresentação.

No Aspose.Slides for .NET, a coleção de slides (uma coleção de [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) fornece os métodos [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/insertclone/) para executar as operações de clonagem de slide descritas acima.

## **Clonar um Slide ao Final de uma Apresentação**

Se você quiser clonar um slide e, em seguida, usá‑lo no mesmo arquivo de apresentação ao final dos slides existentes, use o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) de acordo com os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clonar o slide desejado ao final da coleção de slides na mesma apresentação
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Gravar a apresentação modificada no disco
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar um Slide para Outra Posição dentro de uma Apresentação**

Se você quiser clonar um slide e, em seguida, usá‑lo no mesmo arquivo de apresentação, mas em uma posição diferente, use o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
1. Instancie a classe referenciando a coleção **Slides** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) .
1. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide a ser clonado juntamente com o índice para a nova posição como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice 1 – posição 2 – da apresentação) para o índice 2 – posição 3 – da apresentação.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo de apresentação
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clonar o slide desejado ao final da coleção de slides na mesma apresentação
    ISlideCollection slds = pres.Slides;

    // Clonar o slide desejado para o índice especificado na mesma apresentação
    slds.InsertClone(2, pres.Slides[1]);

    // Gravar a apresentação modificada no disco
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar um Slide ao Final de Outra Apresentação**

Se precisar clonar um slide de uma apresentação e usá‑lo em outro arquivo de apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de onde o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de destino onde o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção **Slides** exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    using (Presentation destPres = new Presentation())
    {
        // Clonar o slide desejado da apresentação de origem ao final da coleção de slides na apresentação de destino
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Gravar a apresentação de destino no disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar um Slide para Outra Posição em Outra Apresentação**

Se precisar clonar um slide de uma apresentação e usá‑lo em outro arquivo de apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de origem de onde o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação onde o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Gravar a apresentação de destino no disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar um Slide com seu Slide Mestre para outra Apresentação**

Se precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro clone o slide mestre desejado da apresentação de origem para a apresentação de destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O **AddClone(ISlide, IMasterSlide)** espera um slide mestre da apresentação de destino, não da origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de origem de onde o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de destino para onde o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o slide mestre.
1. Instancie a classe [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection) e passe o mestre do PPTX de origem a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) definindo a referência à coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Grave o arquivo de apresentação de destino modificado.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação de origem) para o final da apresentação de destino usando um mestre do slide de origem.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation para carregar o arquivo de apresentação de origem

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    using (Presentation destPres = new Presentation())
    {

        // Instanciar ISlide a partir da coleção de slides na apresentação de origem junto com
        // Slide mestre
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
        // Apresentação de destino
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
        // Apresentação de destino
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clonar o slide desejado da apresentação de origem com o slide mestre desejado ao final da
        // Coleção de slides na apresentação de destino
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na // apresentação de destino
        // Gravar a apresentação de destino no disco
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## **Clonar um Slide ao Final de uma Seção Especificada**

Com Aspose.Slides for .NET, você pode clonar um slide de uma seção de uma apresentação e inserir esse slide em outra seção na mesma apresentação. Nesse caso, você deve usar o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) da Interface [ISlideCollection].

Este código C# mostra como clonar um slide e inserir o slide clonado em uma seção especificada:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // para clonar
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Garantir Tamanho de Slide Compatível**

Ao clonar slides para outra apresentação, certifique‑se de que a apresentação de destino tenha o mesmo tamanho de slide da origem. Se os tamanhos dos slides forem diferentes, o Aspose.Slides não redimensiona automaticamente as formas clonadas – suas coordenadas e dimensões originais são preservadas, o que pode fazer com que o conteúdo apareça desalinhado ou ultrapasse os limites do slide.

Você pode definir o tamanho do slide da apresentação de destino para corresponder ao da origem antes de clonar o mestre e o slide:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Faça isso antes de clonar o mestre e o slide.

## **Perguntas Frequentes**

**As notas do apresentador e os comentários dos revisores são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos na cópia. Se não quiser eles, [remova-os](/slides/pt/net/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto de gráfico, a formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho incorporada via OLE), essa vinculação é preservada como um [objeto OLE](/slides/pt/net/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções para a cópia?**

Sim. Você pode inserir a cópia em um índice de slide específico e colocá‑la em uma [seção](/slides/pt/net/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.