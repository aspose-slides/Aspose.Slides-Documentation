---
title: Transição de Slide
type: docs
weight: 110
url: /pt/cpp/examples/elements/slide-transition/
keywords:
- exemplo de código
- transição de slide
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine as transições de slide no Aspose.Slides for C++: adicione, personalize e encadeie efeitos e durações com exemplos em C++ para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra a aplicação de efeitos de transição de slide e temporizações com **Aspose.Slides for C++**.

## **Adicionar uma Transição de Slide**

Aplique um efeito de transição de fade ao primeiro slide.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Aplicar uma transição de fade.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Acessar uma Transição de Slide**

Leia o tipo de transição atualmente atribuído a um slide.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Acessar o tipo de transição.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Remover uma Transição de Slide**

Remova qualquer efeito de transição definindo o tipo como `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Remover a transição definindo None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Definir Duração da Transição**

Especifique quanto tempo o slide permanece exibido antes de avançar automaticamente.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // Em milissegundos.

    presentation->Dispose();
}
```