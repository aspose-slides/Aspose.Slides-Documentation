---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides para .NET 14.8.0
linktitle: Aspose.Slides para .NET 14.8.0
type: docs
weight: 100
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migração
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) adicionados ou removidos, além de outras alterações introduzidas na API do Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Propriedades Alteradas**
#### **Adicionada a Interface IVbaProject, Alterada a Propriedade Presentation.VbaProject**
A propriedade VbaProject da classe Presentation foi substituída. Em vez de h3. Added Interfaces, Properties and Enumeration Options a representação em bytes brutos do projeto VBA, foi adicionada a nova implementação da interface IVbaProject.

Use a propriedade IVbaProject para gerenciar projetos VBA incorporados em uma apresentação. Você pode adicionar novas referências de projeto, editar módulos existentes e criar novos.

Além disso, você pode criar um novo projeto VBA usando a classe VbaProject que implementa a interface IVbaProject.

O exemplo a seguir demonstra a criação de um projeto VBA simples contendo um módulo e a adição de duas referências necessárias às bibliotecas.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Cria novo Projeto VBA

    pres.VbaProject = new VbaProject();

    // Adiciona módulo vazio ao projeto VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Define o código-fonte do módulo

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Cria referência para <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Cria referência para Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Adiciona referências ao projeto VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Este exemplo mostra como copiar um projeto VBA de uma apresentação existente para uma nova apresentação.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Adicionados Interfaces, Propriedades e Opções de Enumeração**
#### **Adicionada a Propriedade Aspose.Slides.Charts.IChartSeries.Overlap**
A propriedade Aspose.Slides.Charts.IChartSeries.Overlap especifica o grau de sobreposição de barras e colunas em gráficos 2D (variando de -100 a 100).

Essa propriedade não se aplica apenas a esta série, mas a todas as séries no grupo de séries pai – é uma projeção da propriedade correspondente do grupo. Portanto, essa propriedade é somente leitura.

- Use a propriedade ParentSeriesGroup para acessar o grupo de séries pai.
- Use a propriedade ParentSeriesGroup.Overlap de leitura/gravação para alterar o valor.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **Adicionada a Propriedade Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
A propriedade Aspose.Slides.Charts.IChartSeriesGroup.Overlap especifica o grau de sobreposição de barras e colunas em gráficos 2D (de -100 a 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Adicionado o Valor de Enumeração ShapeThumbnailBounds.Appearance**
Esse método de criação de miniaturas de forma permite gerar uma miniatura de forma dentro dos limites da sua aparência. Ele considera todos os efeitos da forma. A miniatura gerada é restrita pelos limites do slide.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```