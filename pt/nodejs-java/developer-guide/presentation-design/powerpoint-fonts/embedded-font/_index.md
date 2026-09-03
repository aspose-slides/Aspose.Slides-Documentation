---
title: Incorporar Fontes em Apresentações em JavaScript
linktitle: Fontes Incorporadas
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
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para Node.js via Java. Adicione, recupere, remova e compacte fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados da fonte dentro de uma apresentação PowerPoint. Quando um visualizador oferece suporte a fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento do texto e layout dos slides.

Aspose.Slides for Node.js via Java permite que você recupere, adicione e remova fontes incorporadas através da classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/) retornada por [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getfontsmanager/). Você também pode reduzir o tamanho dos dados da fonte incorporada removendo caracteres que a apresentação não usa.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique‑se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), depois salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove a Calibri se ela estiver presente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Remover uma fonte incorporada elimina seus dados armazenados; isso não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda pode usá‑la. Caso contrário, a renderização pode exigir [font substitution](/slides/pt/nodejs-java/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados da Fonte e Permissões de Incorporação**

Use a classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [FontsManager.getFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas na apresentação. Para cada fonte, passe um objeto [FontData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontdata/) e o valor necessário de [FontStyleType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontstyletype/) para [FontsManager.getFontBytes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). O método retorna os dados binários para esse estilo de fonte, ou `null` quando a fonte ou estilo solicitado não está disponível. Não passe um resultado `null` para [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), pois esse método requer um array de bytes. No Node.js, converta o array JavaScript retornado em um array de bytes Java com `java.newArray` antes de passá‑lo para `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/embeddinglevel/) relata as restrições de incorporação armazenadas na fonte como um conjunto de flags:

- `Installable` permite a incorporação e instalação permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proíbe a incorporação a menos que seja obtida permissão do proprietário legal da fonte quando é a única flag de permissão de uso.
- `PreviewPrint` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente leitura.
- `Editable` permite uso temporário e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restrição adicional que proíbe incorporar apenas um subconjunto dos glifos. Incorpore todos os caracteres quando essa flag estiver presente.
- `BitmapOnly` é uma restrição adicional que permite só a incorporação de bitmap strikes, não de dados de contorno. Se a fonte não tiver bitmap strikes, ela não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operações bitwise. Como `Installable` vale zero, mascare os bits de permissão de uso e compare o resultado com `Installable` em vez de verificá‑lo como uma flag. As fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o helper abaixo seleciona a permissão menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte retornada por `getFonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes apenas bitmap, fontes limitadas a pré‑visualização e impressão porque a saída permanece editável, e fontes que já estão incorporadas. Se algum estilo disponível possuir `NoSubsetting`, ele incorpora todos os caracteres para aquela família de fontes.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Essa inspeção relata as restrições codificadas em cada arquivo de fonte. Ela não concede uma licença, não prova que você obteve a fonte legalmente, nem substitui a verificação do contrato de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) para incorporar uma fonte. Seus overloads aceitam um objeto [FontData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontdata/) ou um array de bytes contendo os dados da fonte. [EmbedFontCharacters](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/embedfontcharacters/) controla quais caracteres são incluídos:

- `All` incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisarem editar a apresentação e inserir texto novo.
- `OnlyUsed` incorpora apenas os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final que tem como objetivo principal a visualização.

O exemplo a seguir usa [FontsManager.getFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes incorporadas existentes mantêm seus conjuntos de caracteres atuais.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compactar Fontes Incorporadas**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/compressembeddedfonts/) reduz os dados de fontes incorporadas removendo caracteres não usados. Ele opera em fontes que já estão incorporadas, portanto a redução de tamanho depende de quanta parte dos dados da fonte não utilizada a apresentação contém.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mantenha o arquivo original se os destinatários puderem precisar adicionar texto posteriormente. Os caracteres removidos durante a compactação não estarão mais disponíveis na fonte incorporada, mesmo que você tenha incorporado todos os caracteres originalmente.

## **FAQ**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Também verifique as configurações de [font substitution](/slides/pt/nodejs-java/font-substitution/) e as regras de [font fallback](/slides/pt/nodejs-java/fallback-font/). O fallback lida com caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode gerar um tamanho de arquivo desnecessário. Se os destinatários ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.