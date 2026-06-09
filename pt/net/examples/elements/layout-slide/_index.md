---
title: Slide de Layout
type: docs
weight: 20
url: /pt/net/examples/elements/layout-slide/
keywords:
- slide de layout
- adicionar slide de layout
- acessar slide de layout
- remover slide de layout
- slide de layout não usado
- clonar slide de layout
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Slides mestres de layout no Aspose.Slides para .NET: escolha, aplique e personalize layouts de slide, marcadores de posição e mestres com exemplos em C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides para .NET. Um layout slide define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover layout slides, além de limpar os não utilizados para reduzir o tamanho da apresentação.

## **Adicionar um Layout Slide**

Você pode criar um layout slide personalizado para definir formatação reutilizável. Por exemplo, você pode adicionar uma caixa de texto que aparece em todos os slides que usam esse layout.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Crie um slide de layout com um tipo de layout em branco e um nome personalizado.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Adicione uma caixa de texto ao slide de layout.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Adicione dois slides usando este layout; ambos herdarão o texto do layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Nota 1:** Os layout slides atuam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá‑los em muitos slides.

> 💡 **Nota 2:** Quando você adiciona formas ou texto a um layout slide, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.  
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo layout slide.

![Slides Herdando Conteúdo do Layout](layout-slide-result.png)

## **Acessar um Layout Slide**

Os layout slides podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Acesse um slide de layout por índice.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Acesse um slide de layout por tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Remover um Layout Slide**

Você pode remover um layout slide específico se ele não for mais necessário.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Obtenha um slide de layout por tipo e remova-o.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Remover Layout Slides Não Utilizados**

Para reduzir o tamanho da apresentação, você pode querer remover layout slides que não são usados por nenhum slide normal.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clonar um Layout Slide**

Você pode duplicar um layout slide usando o método `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Obtenha um slide de layout existente por tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone o slide de layout para o final da coleção de slides de layout.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Resumo:** Os layout slides são ferramentas poderosas para gerenciar formatação consistente em todos os slides. O Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de layout slides.