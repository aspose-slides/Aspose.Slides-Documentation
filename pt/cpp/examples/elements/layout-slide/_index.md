---
title: Slide de Layout
type: docs
weight: 20
url: /pt/cpp/examples/elements/layout-slide/
keywords:
- exemplo de código
- slide de layout
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine slides de layout no Aspose.Slides para C++: escolha, aplique e personalize layouts de slides, marcadores de posição e mestres com exemplos em C++ para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides for C++. Um slide de layout define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover slides de layout, além de limpar os que não são usados para reduzir o tamanho da apresentação.

## **Adicionar um Slide de Layout**

Você pode criar um slide de layout personalizado para definir formatação reutilizável. Por exemplo, pode adicionar uma caixa de texto que aparece em todos os slides que usam esse layout.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Crie um slide de layout com tipo de layout em branco e um nome personalizado.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Adicione uma caixa de texto ao slide de layout.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Adicione dois slides usando este layout; ambos herdarão o texto do layout.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Slides de layout atuam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá‑los em vários slides.

> 💡 **Nota 2:** Quando você adiciona formas ou texto a um slide de layout, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo slide de layout.

![Slides herdando conteúdo de layout](layout-slide-result.png)

## **Acessar um Slide de Layout**

Slides de layout podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Acesse um slide de layout por índice.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Acesse um slide de layout por tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Remover um Slide de Layout**

Você pode remover um slide de layout específico se ele não for mais necessário.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Obtenha um slide de layout por tipo e remova-o.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Remover Slides de Layout Não Utilizados**

Para reduzir o tamanho da apresentação, você pode querer remover slides de layout que não são usados por nenhum slide normal.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Clonar um Slide de Layout**

Você pode duplicar um slide de layout usando o método `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Obtenha um slide de layout existente por tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Clone o slide de layout para o final da coleção de slides de layout.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Resumo:** Slides de layout são ferramentas poderosas para gerenciar formatação consistente em slides. Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de slides de layout.