---
title: Seção
type: docs
weight: 90
url: /pt/cpp/examples/elements/section/
keywords:
- exemplo de código
- seção
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Gerencie seções de slides no Aspose.Slides for C++: crie, renomeie, reorganize e agrupe slides com exemplos em C++ para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação — adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for C++**.

## **Adicionar uma Seção**

Crie uma seção que começa em um slide específico.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Especifique o slide que marca o início da seção.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Acessar uma Seção**

Leia as informações da seção a partir de uma apresentação.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Acesse uma seção por índice.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Remova a primeira seção.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```