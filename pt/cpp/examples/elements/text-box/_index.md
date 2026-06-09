---
title: Caixa de Texto
type: docs
weight: 40
url: /pt/cpp/examples/elements/text-box/
keywords:
- exemplo de código
- caixa de texto
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com caixas de texto no Aspose.Slides para C++: adicione, formate, alinhe, ajuste de linha, ajuste automático e estilize texto usando C++ para apresentações PPT, PPTX e ODP."
---
No Aspose.Slides, uma **caixa de texto** é representada por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma Caixa de Texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Veja como criar uma:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crie uma forma retangular (por padrão preenchida com borda e sem texto).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Remova o preenchimento e a borda para que pareça uma caixa de texto típica.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Defina a formatação do texto.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Atribua o conteúdo de texto real.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Observação:** Qualquer `AutoShape` que contenha um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar Caixas de Texto por Conteúdo**

Para encontrar todas as caixas de texto que contêm uma palavra‑chave específica (por exemplo, "Slide"), iterar pelas formas e verificar o texto delas:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Somente AutoShapes podem conter texto editável.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Faça algo com a caixa de texto correspondente.
            }
        }
    }

    presentation->Dispose();
}
```

## **Remover Caixas de Texto por Conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contêm uma palavra‑chave específica:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá‑la durante a iteração para evitar erros de modificação da coleção.