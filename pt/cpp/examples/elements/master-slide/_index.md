---
title: Slide Mestre
type: docs
weight: 30
url: /pt/cpp/examples/elements/master-slide/
keywords:
- exemplo de código
- slide mestre
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Explore exemplos de slide mestre do Aspose.Slides para C++: crie, edite e estilize mestres, marcadores de posição e temas em PPT, PPTX e ODP com código C++ claro."
---
Os slides mestres formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como fundos, logotipos e formatação de texto. **Slides de layout** herdam dos slides mestres, e **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestres usando Aspose.Slides para C++.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão. Em seguida, adiciona um banner com o nome da empresa a todos os slides por meio da herança de layout.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Clone o slide mestre padrão.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Adiciona um banner com o nome da empresa no topo do slide mestre.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Atribui o novo slide mestre a um slide de layout.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Atribui o slide de layout ao primeiro slide da apresentação.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Slides mestres fornecem uma maneira de aplicar branding consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.

> 💡 **Nota 2:** Quaisquer formas ou formatações adicionadas a um slide mestre são herdadas pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.  
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestres usando a coleção master da apresentação. Veja como recuperá-los e trabalhar com eles:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Alterar o tipo de fundo.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Remover um Slide Mestre**

Slides mestres podem ser removidos por índice ou por referência.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Remover um slide mestre por índice.
    presentation->get_Masters()->RemoveAt(0);

    // Remover um slide mestre por referência.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestres que não estão em uso. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Remover todos os slides mestres não usados (inclusive os marcados como Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```