---
title: Slide Mestre
type: docs
weight: 30
url: /pt/net/examples/elements/master-slide/
keywords:
- slide mestre
- adicionar slide mestre
- acessar slide mestre
- remover slide mestre
- slide mestre não utilizado
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Explore exemplos de slide mestre do Aspose.Slides para .NET: crie, edite e estilize mestres, marcadores de posição e temas em PPT, PPTX e ODP com código C# claro."
---
Os slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como fundos, logotipos e formatação de texto. **Slides de layout** herdam dos slides mestre, e **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando Aspose.Slides para .NET.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão. Em seguida, adiciona uma faixa com o nome da empresa a todos os slides por meio da herança de layout.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Clone o slide mestre padrão.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Adicione uma faixa com o nome da empresa no topo do slide mestre.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Atribua o novo slide mestre a um slide de layout.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Atribua o slide de layout ao primeiro slide da apresentação.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Note 1:** Slides mestre fornecem um meio de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.

> 💡 **Note 2:** Qualquer forma ou formatação adicionada a um slide mestre é herdada pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.  
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Slide Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre usando a coleção `Presentation.Masters`. Aqui está como recuperar e trabalhar com eles:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Acesse o primeiro slide mestre.
    var firstMasterSlide = presentation.Masters[0];

    // Altere o tipo de fundo.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Remover um Slide Mestre**

Slides mestre podem ser removidos por índice ou por referência.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Remova um slide mestre por índice.
    presentation.Masters.RemoveAt(0);

    // Remova um slide mestre por referência.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestre que não são usados. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Remova todos os slides mestre não utilizados (mesmo os marcados como Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```