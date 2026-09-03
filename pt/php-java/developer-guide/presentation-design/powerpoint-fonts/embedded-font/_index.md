---
title: Incorporar fontes em apresentações usando PHP
linktitle: Fontes incorporadas
type: docs
weight: 40
url: /pt/php-java/embedded-font/
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
- PHP
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para PHP via Java. Adicione, recupere, remova e compacte fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados da fonte dentro de uma apresentação PowerPoint. Quando um visualizador oferece suporte a fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que elas não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento do texto e o layout dos slides.

Aspose.Slides for PHP via Java permite recuperar, adicionar e remover fontes incorporadas através da classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/) retornada por [Presentation::getFontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getFontsManager). Você também pode reduzir o tamanho dos dados da fonte incorporada removendo caracteres que a apresentação não usa.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique‑se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) e, em seguida, salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove Calibri se ela estiver presente:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Remover uma fonte incorporada elimina seus dados de fonte armazenados; não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda poderá usá‑la. Caso contrário, a renderização pode exigir [substituição de fonte](/slides/pt/php-java/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados de Fonte e Permissões de Incorporação**

Use a classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [FontsManager::getFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getFonts) para recuperar as fontes usadas na apresentação. Para cada fonte, passe um objeto [FontData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontdata/) e o valor requerido de [FontStyleType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontstyletype/) para [FontsManager::getFontBytes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getFontBytes). O método devolve os dados binários para esse estilo de fonte, ou `null` quando a fonte ou o estilo solicitado não está disponível. Não passe um resultado `null` para [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), pois esse método requer um array de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embeddinglevel/) é uma enumeração de flags que relata as restrições de incorporação armazenadas na fonte:

- `Installable` permite a incorporação e a instalação permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proíbe a incorporação a menos que seja obtida permissão do proprietário legal da fonte quando esta for a única flag de permissão de uso.
- `PreviewPrint` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente‑leitura.
- `Editable` permite uso temporário e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restrição adicional que proíbe a incorporação de apenas um subconjunto dos glifos. Incorpore todos os caracteres quando essa flag estiver presente.
- `BitmapOnly` é uma restrição adicional que permite apenas que strikes bitmap sejam incorporados, não dados de contorno. Se a fonte não possuir strikes bitmap, ela não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operações bit a bit. Como `Installable` é zero, mascare os bits de permissão de uso e compare o resultado com `Installable` em vez de verificá‑lo como uma flag. As fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o auxiliar abaixo seleciona a permissão menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte devolvida por `FontsManager::getFonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes somente‑bitmap, fontes limitadas a visualização e impressão porque a saída permanece editável, e fontes que já estejam incorporadas. Se algum estilo disponível possuir `NoSubsetting`, ele incorpora todos os caracteres para essa família de fontes.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP.END;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP.END;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Essa inspeção relata as restrições codificadas em cada arquivo de fonte. Não concede licença, não comprova que você obteve a fonte legalmente e não substitui a verificação do acordo de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) para incorporar uma fonte. Seus sobrecargas aceitam um objeto [FontData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontdata/) ou um array de bytes contendo os dados da fonte. A enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedfontcharacters/) controla quais caracteres são incluídos:

- [All](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisarem editar a apresentação e inserir novo texto.
- [OnlyUsed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedfontcharacters/) incorpora apenas os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final que será principalmente visualizada.

O exemplo a seguir usa [FontsManager::getFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getFonts) para recuperar as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes incorporadas existentes mantêm seus conjuntos de caracteres atuais.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Compactar Fontes Incorporadas**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#compressEmbeddedFonts) reduz os dados de fonte incorporada removendo caracteres não utilizados. Ele opera sobre fontes que já estão incorporadas, de modo que a redução de tamanho depende de quanto de dados de fonte não utilizados a apresentação contém.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mantenha o arquivo original caso os destinatários precisem adicionar texto posteriormente. Os caracteres removidos durante a compactação não ficam mais disponíveis na fonte incorporada, mesmo que você originalmente tenha incorporado todos os caracteres.

## **Perguntas Frequentes**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getSubstitutions) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Também verifique as configurações de [substituição de fonte](/slides/pt/php-java/font-substitution/) e as regras de [fallback de fonte](/slides/pt/php-java/fallback-font/). O fallback lida com caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode aumentar o tamanho do arquivo desnecessariamente. Se os destinatários ou servidores podem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.