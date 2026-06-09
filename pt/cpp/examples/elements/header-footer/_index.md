---
title: Cabeçalho e Rodapé
type: docs
weight: 220
url: /pt/cpp/examples/elements/header-footer/
keywords:
- exemplo de código
- cabeçalho
- rodapé
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Controle os cabeçalhos e rodapés dos slides com Aspose.Slides for C++: adicione datas, números de slide e texto personalizado em PPT, PPTX e ODP com exemplos em C++."
---
Este artigo demonstra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for C++**.

## **Adicionar um Rodapé**

Adicione texto à área de rodapé de um slide e torne‑o visível.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```