---
title: Como Adicionar Cabeçalhos & Rodapés a Apresentações em .NET
linktitle: Adicionar Cabeçalho & Rodapé
type: docs
weight: 20
url: /pt/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migração
- adicionar cabeçalho
- adicionar rodapé
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como adicionar cabeçalhos e rodapés em apresentações PowerPoint PPT, PPTX e ODP no .NET usando as APIs Aspose.Slides legadas e modernas."
---
{{% alert color="primary" %}} 

Um novo [Aspose.Slides for .NET API](/slides/pt/net/) foi lançado e agora este único produto suporta a capacidade de gerar documentos PowerPoint do zero e editar os existentes.

{{% /alert %}} 
## **Suporte a Código Legado**
Para usar o código legado desenvolvido com Aspose.Slides for .NET versões anteriores a 13.x, você precisa fazer algumas alterações menores no seu código e ele continuará funcionando como antes. Todas as classes que estavam presentes no antigo Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram mescladas em um único namespace Aspose.Slides. Por favor, veja o trecho de código simples a seguir para adicionar cabeçalho e rodapé em uma apresentação na API legado do Aspose.Slides e siga as etapas que descrevem como migrar para a nova API mesclada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Define as propriedades de visibilidade do cabeçalho e rodapé
//Atualiza os campos de data e hora
//Exibe o espaço reservado para data e hora
//Exibe o espaço reservado para rodapé
//Exibe o número do slide
//Define a visibilidade do cabeçalho e rodapé no slide de título
//Grava a apresentação no disco
sourcePres.Write("NewSource.pptx");
```

```c#
//Criar a apresentação
Presentation pres = new Presentation();

//Obter o primeiro slide
Slide sld = pres.GetSlideByPosition(1);

//Acessar o cabeçalho / rodapé do slide
HeaderFooter hf = sld.HeaderFooter;

//Definir visibilidade do número da página
hf.PageNumberVisible = true;

//Definir visibilidade do rodapé
hf.FooterVisible = true;

//Definir visibilidade do cabeçalho
hf.HeaderVisible = true;

//Definir visibilidade da data e hora
hf.DateTimeVisible = true;

//Definir formato da data e hora
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Definir texto do cabeçalho
hf.HeaderText = "Header Text";

//Definir texto do rodapé
hf.FooterText = "Footer Text";

//Gravar a apresentação no disco
pres.Write("HeadFoot.ppt");
```



## **Abordagem do Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Definir propriedades de visibilidade do cabeçalho e rodapé
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Atualizar os campos de data e hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Exibir o espaço reservado para data e hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Exibir o espaço reservado para rodapé
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Definir a visibilidade do cabeçalho e rodapé no slide de título
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Gravar a apresentação no disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```