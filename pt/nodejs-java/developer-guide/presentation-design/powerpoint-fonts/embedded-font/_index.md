---
title: Incorporar Fontes em Apresentações Usando JavaScript
linktitle: Incorporando Fonte
type: docs
weight: 40
url: /pt/nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para Node.js via Java, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Fontes incorporadas no PowerPoint** são úteis quando você quer que sua apresentação apareça corretamente ao ser aberta em qualquer sistema ou dispositivo. Se você usou uma fonte de terceiros ou não padrão porque se tornou criativo com seu trabalho, então tem ainda mais razões para incorporar sua fonte. Caso contrário (sem fontes incorporadas), os textos ou números em seus slides, o layout, o estilo, etc., podem mudar ou se transformar em retângulos confusos. 

A classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager), a classe [FontData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontdata/) e a classe [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/) contêm a maioria das propriedades e métodos que você precisa para trabalhar com fontes incorporadas em apresentações do PowerPoint.

## **Obter ou Remover Fontes Incorporadas da Apresentação**

Aspose.Slides fornece o método [getEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposto pela classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager)) para permitir que você obtenha (ou descubra) as fontes incorporadas em uma apresentação. Para remover fontes, utiliza-se o método [removeEmbeddedFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (exposto pela mesma classe).

Este código JavaScript mostra como obter e remover fontes incorporadas de uma apresentação:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza um slide contendo um quadro de texto que usa a fonte incorporada "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Salva a imagem no disco em formato JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Obtém todas as fontes incorporadas
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Encontra a fonte "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Remove a fonte "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renderiza a apresentação; a fonte "Calibri" é substituída por uma existente
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Salva a imagem no disco em formato JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Salva a apresentação sem a fonte "Calibri" incorporada no disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionar Fontes Incorporadas à Apresentação**

Usando o enum [EmbedFontCharacters](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/embedfontcharacters/) e duas sobrecargas do método [addEmbeddedFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) você pode selecionar a regra de incorporação que preferir para incorporar as fontes em uma apresentação. Este código JavaScript mostra como incorporar e adicionar fontes a uma apresentação:

```javascript
// Carrega a apresentação
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Salva a apresentação no disco
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Compactar Fontes Incorporadas**

Para permitir que você compacte as fontes incorporadas em uma apresentação e reduza seu tamanho de arquivo, Aspose.Slides fornece o método [compressEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (exposto pela classe [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/)).

Este código JavaScript mostra como compactar fontes do PowerPoint incorporadas:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como posso saber se uma fonte específica na apresentação ainda será substituída durante a renderização apesar de estar incorporada?**

Verifique as [informações de substituição](/slides/pt/nodejs-java/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/nodejs-java/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes do "sistema" como Arial/Calibri?**

Normalmente não—elas estão quase sempre disponíveis. Mas para total portabilidade em ambientes "magros" (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.