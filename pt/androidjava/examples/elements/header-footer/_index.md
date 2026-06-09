---
title: Cabeçalho e Rodapé
type: docs
weight: 220
url: /pt/androidjava/examples/elements/header-footer/
keywords:
- exemplo de código
- cabeçalho
- rodapé
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Controle cabeçalhos e rodapés de slides com Aspose.Slides para Android: adicione datas, números de slides e texto personalizado em PPT, PPTX e ODP com exemplos em Java."
---
Este artigo demonstra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for Android via Java**.

## **Adicionar um Rodapé**

Adicione texto à área de rodapé de um slide e torne‑o visível.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```