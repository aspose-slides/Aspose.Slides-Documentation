---
title: Incorporar fontes em apresentações usando Java
linktitle: Incorporando Fonte
type: docs
weight: 40
url: /pt/java/embedded-font/
keywords:
- adicionar fonte
- incorporar fonte
- incorporação de fonte
- obter fonte incorporada
- adicionar fonte incorporada
- remover fonte incorporada
- compactar fonte incorporada
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para Java, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Embedded fonts in PowerPoint** são úteis quando você deseja que sua apresentação apareça corretamente ao ser aberta em qualquer sistema ou dispositivo. Se você usou uma fonte de terceiros ou não padrão porque foi criativo no seu trabalho, então tem ainda mais motivos para incorporar sua fonte. Caso contrário (sem fontes incorporadas), os textos ou números em seus slides, o layout, a formatação etc. podem mudar ou se transformar em retângulos confusos. 

A classe [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager), a classe [FontData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontdata/), a classe [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) e suas interfaces contêm a maioria das propriedades e métodos que você precisa para trabalhar com fontes incorporadas em apresentações do PowerPoint. 

## **Obter e Remover Fontes Incorporadas**

Aspose.Slides fornece o método [getEmbeddedFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposto pela classe [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager)) para permitir que você obtenha (ou descubra) as fontes incorporadas em uma apresentação. Para remover fontes, o método [removeEmbeddedFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposto pela mesma classe) é usado.

Este código Java mostra como obter e remover fontes incorporadas de uma apresentação:

```java
// Instancia um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza um slide contendo um quadro de texto que usa a fonte incorporada "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Salva a imagem no disco em formato JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtém todas as fontes incorporadas
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Encontra a fonte "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Remove a fonte "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderiza a apresentação; a fonte "Calibri" é substituída por uma existente
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Salva a imagem no disco em formato JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Salva a apresentação sem a fonte "Calibri" incorporada no disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar Fontes Incorporadas**

Usando o enum [EmbedFontCharacters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/embedfontcharacters/) e duas sobrecargas do método [addEmbeddedFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), você pode selecionar a regra de incorporação preferida para incorporar as fontes em uma apresentação. Este código Java mostra como incorporar e adicionar fontes a uma apresentação:

```java
// Carrega a apresentação
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Salva a apresentação no disco
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Comprimir Fontes Incorporadas**

Para permitir que você comprima as fontes incorporadas em uma apresentação e reduza seu tamanho de arquivo, o Aspose.Slides fornece o método [compressEmbeddedFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposto pela classe [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/)).

Este código Java mostra como comprimir fontes do PowerPoint incorporadas:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como posso saber que uma fonte específica na apresentação ainda será substituída durante a renderização apesar de estar incorporada?**

Verifique as [informações de substituição](/slides/pt/java/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/java/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes "do sistema" como Arial/Calibri?**

Normalmente não — elas estão quase sempre disponíveis. Mas para total portabilidade em ambientes "leves" (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.