---
title: Obter callbacks de aviso para substituição de fonte
type: docs
weight: 90
url: /pt/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- substituição de fonte
- processo de renderização
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a obter callbacks de aviso para substituição de fonte no Aspose.Slides for Java e exibir apresentações PowerPoint e OpenDocument com precisão."
---
## **Introdução**

O Aspose.Slides for Java permite receber callbacks de aviso para substituição de fonte quando uma fonte necessária não está disponível na máquina durante a renderização. Esses callbacks ajudam a diagnosticar problemas com fontes ausentes ou inacessíveis.

## **Ativar Callbacks de Aviso**

Aspose.Slides for Java fornece APIs simples para receber callbacks de aviso ao renderizar slides de apresentação. Siga estas etapas para configurar os callbacks de aviso:

1. Crie uma classe de callback personalizada que implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarningcallback/) para tratar avisos.
2. Defina o callback de aviso usando classes de opções como [RenderingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/htmloptions/) e outras.
3. Carregue uma apresentação que use uma fonte não disponível na máquina de destino.
4. Gere uma miniatura de slide ou exporte a apresentação para observar o efeito.

**Classe de Callback de Aviso Personalizada:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Exemplo de saída:
//
// A fonte será substituída de XYZ para {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Gerar uma Miniatura de Slide:**

```java
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a renderização dos slides.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Carregar a apresentação a partir do caminho de arquivo especificado.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Gerar uma imagem miniatura para cada slide da apresentação.
    for (ISlide slide : presentation.getSlides()) {
        // Obter a imagem miniatura do slide usando as opções de renderização especificadas.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Exportar para Formato PDF:**

```java
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Carregar a apresentação a partir do caminho de arquivo especificado.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportar a apresentação como PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Exportar para Formato HTML:**

```java
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Carregar a apresentação a partir do caminho de arquivo especificado.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportar a apresentação no formato HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```