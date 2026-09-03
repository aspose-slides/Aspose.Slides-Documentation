---
title: Incorporar fontes em apresentações no Android
linktitle: Fontes incorporadas
type: docs
weight: 40
url: /pt/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para Android via Java. Adicione, recupere, remova e compacte fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados da fonte dentro de uma apresentação do PowerPoint. Quando um visualizador suporta fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que elas não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento do texto e layout dos slides.

Aspose.Slides for Android via Java permite recuperar, adicionar e remover fontes incorporadas através da interface [IFontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/) retornada por [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getFontsManager--). Você também pode reduzir o tamanho dos dados das fontes incorporadas removendo os caracteres que a apresentação não usa.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique-se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [getEmbeddedFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [removeEmbeddedFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), então salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove Calibri se ela estiver presente:
```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Remover uma fonte incorporada elimina seus dados de fonte armazenados; não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda pode usá‑la. Caso contrário, a renderização pode exigir [substituição de fontes](/slides/pt/androidjava/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados da Fonte e Permissões de Incorporação**

Use a interface [IFontsManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [IFontsManager.getFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) para recuperar as fontes usadas na apresentação. Para cada fonte, passe um objeto [IFontData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontdata/) e o valor necessário de [FontStyleType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontstyletype/) para [IFontsManager.getFontBytes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). O método retorna os dados binários para esse estilo de fonte, ou `null` quando a fonte ou o estilo solicitado não está disponível. Não passe um resultado `null` para [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), pois esse método requer um array de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embeddinglevel/) é uma enumeracao de bandeiras que relata as restricoes de incorporacao armazenadas na fonte:

- `Installable` permite a incorporacao e instalacao permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proibe a incorporacao a menos que seja obtida permissao do proprietario legal da fonte quando este for a única bandeira de permissao de uso.
- `PreviewPrint` permite uso temporario para visualizacao e impressao; um documento contendo a fonte deve ser somente-leitura.
- `Editable` permite uso temporario e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restricao adicional que proibe a incorporacao de apenas um subconjunto dos glifos. Incorpore todos os caracteres quando essa bandeira estiver presente.
- `BitmapOnly` é uma restricao adicional que permite apenas a incorporacao de bitmap strikes, não de dados de contorno. Se a fonte não possuir bitmap strikes, não pode ser incorporada.

Os quatro primeiros valores descrevem a permissao de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operacoes bit a bit. Como `Installable` é zero, mascare os bits de permissao de uso e compare o resultado com `Installable` em vez de verifica-lo como uma bandeira. Fontes atuais devem definir no maximo um bit de permissao de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o auxiliar abaixo seleciona a permissao menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, italic e negrito-italic disponiveis para cada fonte retornada por `getFonts`. Ele ignora estilos indisponiveis, fontes restritas, fontes somente-bitmap, fontes limitadas a visualizacao e impressao porque a saida permanece editavel, e fontes que ja estão incorporadas. Se algum estilo disponivel possuir `NoSubsetting`, ele incorpora todos os caracteres para aquela familia de fontes.
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta inspeção relata as restricoes codificadas em cada arquivo de fonte. Ela nao concede uma licença, nao prova que voce obteve a fonte legalmente, nem substitui a verificacao do contrato de licenca da fonte antes de distribuir uma copia incorporada.

## **Adicionar Fontes Incorporadas**

Use [addEmbeddedFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) para incorporar uma fonte. Suas sobrecargas aceitam ou um objeto [IFontData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontdata/) ou um array de bytes contendo os dados da fonte. A enumeracao [EmbedFontCharacters](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embedfontcharacters/) controla quais caracteres são incluidos:

- [All](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opcao quando os destinatarios precisam editar a apresentacao e inserir novo texto.
- [OnlyUsed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/embedfontcharacters/) incorpora apenas os caracteres usados na apresentacao para reduzir o tamanho do arquivo. Escolha esta opcao para uma apresentacao final que e principalmente destinada à visualizacao.

O exemplo a seguir usa [getFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) para recuperar as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda nao estao incorporadas. As fontes a serem adicionadas devem estar disponiveis no dispositivo Android ou registradas no Aspose.Slides. As fontes incorporadas existentes preservam seus conjuntos de caracteres atuais.
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compactar Fontes Incorporadas**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) reduz os dados das fontes incorporadas removendo caracteres nao usados. Ele funciona em fontes que ja estão incorporadas, portanto a reducao de tamanho depende de quantos dados de fonte nao utilizados a apresentacao contém.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:
```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mantenha o arquivo original se os destinatarios puderem precisar adicionar texto posteriormente. Caracteres removidos durante a compactacao nao ficam mais disponiveis na fonte incorporada, mesmo que voce tenha inicialmente incorporado todos os caracteres.

## **FAQ**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [getSubstitutions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) no ambiente onde voce renderiza a apresentacao para ver quais fontes o Aspose.Slides substituirá. Tambem verifique as configuracoes de [substituição de fontes](/slides/pt/androidjava/font-substitution/) e as regras de [fallback de fontes](/slides/pt/androidjava/fallback-font/). O fallback lida com caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisao no ambiente de destino. Se as fontes necessarias estiverem disponiveis em todos os dispositivos que abrem ou renderizam a apresentacao, incorporá‑las pode aumentar o tamanho do arquivo desnecessariamente. Se os destinatarios ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licencas permitam.