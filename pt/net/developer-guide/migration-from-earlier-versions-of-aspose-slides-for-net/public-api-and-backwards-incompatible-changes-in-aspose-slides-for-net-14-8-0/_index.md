---
title: API pública e alterações incompatíveis retroativas no Aspose.Slides for .NET 14.8.0
linktitle: Aspose.Slides for .NET 14.8.0
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
description: "Revise as atualizações da API pública e as mudanças que quebram a compatibilidade no Aspose.Slides for .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) e outras alterações introduzidas com a API do Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Propriedades Alteradas**
#### **Adicionada a Interface IVbaProject, Alterada a Propriedade Presentation.VbaProject**
A propriedade VbaProject da classe Presentation foi substituída. Em vez da representação bruta em bytes do projeto VBA da propriedade VbaProject, foi adicionada a nova implementação da interface IVbaProject.

Use a propriedade IVbaProject para gerenciar projetos VBA incorporados em uma apresentação. Você pode adicionar novas referências de projeto, editar módulos existentes e criar novos.

Além disso, você pode criar um novo projeto VBA usando a classe VbaProject, que implementa a interface IVbaProject.

O exemplo a seguir mostra a criação de um projeto VBA simples contendo um módulo e adicionando duas referências necessárias às bibliotecas.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Criar novo Projeto VBA

    pres.VbaProject = new VbaProject();

    // Adicionar módulo vazio ao projeto VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Definir código-fonte do módulo

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Criar referência para <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Criar referência para Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Adicionar referências ao projeto VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Este exemplo mostra como copiar um projeto VBA de uma apresentação existente para uma nova.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Interfaces, Propriedades e Opções de Enumeração Adicionadas**
#### **Adicionada a Propriedade Aspose.Slides.Charts.IChartSeries.Overlap**
A propriedade Aspose.Slides.Charts.IChartSeries.Overlap especifica o quanto barras e colunas devem se sobrepor em gráficos 2D (variando de -100 a 100).

Esta é a propriedade não apenas desta série, mas de todas as séries no grupo de séries pai – é uma projeção da propriedade de grupo correspondente. Portanto, essa propriedade é somente leitura.

- Use a propriedade ParentSeriesGroup para acessar o grupo de séries pai.
- Use a propriedade ParentSeriesGroup.Overlap (leitura/gravação) para alterar o valor.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


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
A propriedade Aspose.Slides.Charts.IChartSeriesGroup.Overlap especifica o quanto barras e colunas devem se sobrepor em gráficos 2D (de -100 a 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Adicionado o Valor de Enumeração ShapeThumbnailBounds.Appearance**
Este método de criação de miniatura de forma permite gerar uma miniatura dentro dos limites da sua aparência. Ele considera todos os efeitos da forma. A miniatura gerada é limitada pelos limites do slide.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```