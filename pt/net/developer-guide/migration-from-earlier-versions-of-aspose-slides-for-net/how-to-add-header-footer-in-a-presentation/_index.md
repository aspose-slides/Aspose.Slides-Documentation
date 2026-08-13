---
title: Como Adicionar Cabeçalhos e Rodapés a Apresentações em .NET
linktitle: Adicionar Cabeçalho e Rodapé
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
description: "Aprenda como adicionar cabeçalhos e rodapés em apresentações PowerPoint PPT, PPTX e ODP no .NET usando tanto as APIs legadas quanto as modernas do Aspose.Slides."
---
{{% alert color="info" %}} 

Uma nova [Aspose.Slides for .NET API](/slides/pt/net/) foi lançada e agora este único produto oferece a capacidade de gerar documentos PowerPoint do zero e editar os existentes.

{{% /alert %}} 
## **Suporte a Código Legado**
Para usar o código legado desenvolvido com versões do Aspose.Slides for .NET anteriores à 13.x, você precisa fazer algumas pequenas alterações no seu código e ele funcionará como antes. Todas as classes que estavam presentes na antiga Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram mescladas em um único namespace Aspose.Slides. Por favor, veja o trecho de código simples a seguir para adicionar cabeçalho e rodapé em uma apresentação na API legada do Aspose.Slides e siga os passos que descrevem como migrar para a nova API mesclada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Definindo propriedades de visibilidade de Cabeçalho e Rodapé
sourcePres.UpdateSlideNumberFields = true;

//Atualizar os campos de data e hora
sourcePres.UpdateDateTimeFields = true;

//Exibir o espaço reservado de data e hora
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Exibir o espaço reservado do rodapé
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Exibir número do slide
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Definir a visibilidade de cabeçalho e rodapé no slide de título
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Gravar a apresentação no disco
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Criar a apresentação
Presentation pres = new Presentation();

//Obter o primeiro slide
Slide sld = pres.GetSlideByPosition(1);

//Acessar o Cabeçalho / Rodapé do slide
HeaderFooter hf = sld.HeaderFooter;

//Definir a visibilidade do número da página
hf.PageNumberVisible = true;

//Definir a visibilidade do rodapé
hf.FooterVisible = true;

//Definir a visibilidade do cabeçalho
hf.HeaderVisible = true;

//Definir a visibilidade da data e hora
hf.DateTimeVisible = true;

//Definir o formato da data e hora
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Definir o texto do cabeçalho
hf.HeaderText = "Header Text";

//Definir o texto do rodapé
hf.FooterText = "Footer Text";

//Gravar a apresentação no disco
pres.Write("HeadFoot.ppt");
```



## **Nova Abordagem do Aspose.Slides for .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Definindo propriedades de visibilidade de Cabeçalho e Rodapé
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Atualizar os campos de data e hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Exibir o espaço reservado de data e hora
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Exibir o espaço reservado do rodapé
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Definir a visibilidade de cabeçalho e rodapé no slide de título
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Gravar a apresentação no disco
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```