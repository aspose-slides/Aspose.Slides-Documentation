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

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides também permite copiar (clonar) qualquer slide e, em seguida, inserir o slide clonado na apresentação atual ou em qualquer outra apresentação aberta. A clonagem de slide cria um novo slide que os desenvolvedores podem modificar sem afetar o slide original. Existem várias maneiras de clonar um slide:

- Clonar no final de uma apresentação.
- Clonar em outra posição dentro de uma apresentação.
- Clonar no final de outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

No Aspose.Slides para .NET, a coleção de slides (uma coleção de [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) fornece os métodos [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/insertclone/) para executar as operações de clonagem de slide descritas acima.

## **Clonar um Slide no Final de uma Apresentação**

Se você quiser clonar um slide e, em seguida, usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) conforme os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index).
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // Gravar a apresentação modificada no disco
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Clonar um Slide para Outra Posição dentro de uma Apresentação**
Se você quiser clonar um slide e, em seguida, usá‑lo dentro do mesmo arquivo de apresentação, mas em uma posição diferente, use o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Instancie a classe referenciando a coleção **Slides** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide a ser clonado juntamente com o índice para a nova posição como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice zero – posição 1 – da apresentação) para o índice 1 – Posição 2 – da apresentação.

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação
 using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
 {
 
     // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
     ISlideCollection slds = pres.Slides;
 
     // Clonar o slide desejado para o índice especificado na mesma apresentação
     slds.InsertClone(2, pres.Slides[1]);
 
     // Gravar a apresentação modificada no disco
     pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Clonar um Slide no Final de outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de destino à qual o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção **Slides** exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

```c#
 // Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
 using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
 {
     // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
     using (Presentation destPres = new Presentation())
     {
         // Clonar o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino
         ISlideCollection slds = destPres.Slides;

         slds.AddClone(srcPres.Slides[0]);

         // Gravar a apresentação de destino no disco
         destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
     }
 }
```


## **Clonar um Slide para Outra Posição em outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de origem da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação à qual o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```c#
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


## **Clonar um Slide em uma Posição Específica em outra Apresentação**
Se precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro clone o slide mestre desejado da apresentação de origem para a de destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O método **AddClone(ISlide, IMasterSlide)** espera um slide mestre da apresentação de destino, não da de origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de origem da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo a apresentação de destino para a qual o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o slide mestre.
1. Instancie a classe [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection) e passe o mestre da apresentação PPTX de origem a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) definindo a referência à coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) da apresentação de destino.
1. Chame o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetros para o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação de origem) para o final da apresentação de destino usando um mestre da apresentação de origem.

```c#
 // Instanciar a classe Presentation para carregar o arquivo de apresentação de origem

 using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
 {
     // Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
     using (Presentation destPres = new Presentation())
     {

         // Instanciar ISlide a partir da coleção de slides na apresentação de origem juntamente com
         // o slide mestre
         ISlide SourceSlide = srcPres.Slides[0];
         IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

         // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
         // apresentação de destino
         IMasterSlideCollection masters = destPres.Masters;
         IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

         // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
         // apresentação de destino
         IMasterSlide iSlide = masters.AddClone(SourceMaster);

         // Clonar o slide desejado da apresentação de origem com o mestre desejado para o final da
         // coleção de slides na apresentação de destino
         ISlideCollection slds = destPres.Slides;
         slds.AddClone(SourceSlide, iSlide, true);
       
         // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na apresentação de destino
         // Gravar a apresentação de destino no disco
         destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

     }
 }
```



## **Clonar um Slide no Final de uma Seção Especificada**

Com Aspose.Slides para .NET, você pode clonar um slide de uma seção de uma apresentação e inserir esse slide em outra seção da mesma apresentação. Nesse caso, use o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/methods/addclone/index) da interface [ISlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection).

Este código C# mostra como clonar um slide e inserir o slide clonado em uma seção especificada:

```c#
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

## **FAQ**

**As notas do orador e os comentários de revisão são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos na clonagem. Se não quiser mantê‑los, [remova‑os](/slides/pt/net/presentation-notes/) após a inserção.

**Como gráficos e suas fontes de dados são tratados?**

O objeto de gráfico, a formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma planilha incorporada via OLE), esse vínculo é mantido como um [objeto OLE](/slides/pt/net/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções para a clonagem?**

Sim. Você pode inserir a clonagem em um índice de slide específico e colocá‑la em uma [seção](/slides/pt/net/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.