---
title: Incorporar fontes em apresentações em .NET
linktitle: Fontes incorporadas
type: docs
weight: 40
url: /pt/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para .NET. Use C# para adicionar, recuperar, remover e compactar fontes, preservando a aparência do texto e reduzindo o tamanho do arquivo."
---
## **Introdução**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for .NET lets you retrieve, add, and remove embedded fonts through the [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) property of a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique‑se de que seus dados de fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) e, em seguida, salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove a Calibri se ela estiver presente:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Remover uma fonte incorporada elimina seus dados de fonte armazenados; isso não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda poderá usá‑la. Caso contrário, a renderização pode exigir [substituição de fonte](/slides/pt/net/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados da Fonte e Permissões de Incorporação**

Use the [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interface to inspect fonts before embedding them. Call [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) to retrieve the fonts used in the presentation. For each font, pass an [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) value to [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). The method returns the binary data for that font style, or `null` when the requested font or style is unavailable. Do not pass a `null` result to [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), because that method requires a byte array.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) é uma enumeração de flags que relata as restrições de incorporação armazenadas na fonte:

- `Installable` permite incorporação e instalação permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proíbe a incorporação a menos que a permissão seja obtida do proprietário legal da fonte quando é a única flag de permissão de uso.
- `PreviewPrint` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente leitura.
- `Editable` permite uso temporário e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restrição adicional que proíbe a incorporação de apenas um subconjunto dos glifos. Incorpore todos os caracteres quando essa flag estiver presente.
- `BitmapOnly` é uma restrição adicional que permite somente a incorporação de rasterizações (bitmap) da fonte, não dos dados de contorno. Se a fonte não possuir rasterizações, ela não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operações bitwise. Como `Installable` é zero, não use `HasFlag` para detectá‑lo; masque os bits de permissão de uso e compare o resultado com `Installable`. As fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o helper abaixo seleciona a permissão menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte retornada por `GetFonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes somente‑bitmap, fontes limitadas a visualização e impressão porque a saída permanece editável, e fontes que já estão incorporadas. Se algum estilo disponível possuir `NoSubsetting`, ele incorpora todos os caracteres para essa família de fontes.
```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Esta inspeção relata as restrições codificadas em cada arquivo de fonte. Ela não concede licença, prova que você obteve a fonte legalmente, nem substitui a verificação do contrato de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) para incorporar uma fonte. Suas sobrecargas aceitam um objeto [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) ou um array de bytes contendo os dados da fonte. A enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) controla quais caracteres são incluídos:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisam editar a apresentação e inserir novo texto.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) incorpora somente os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final que tem como objetivo principal a visualização.

O exemplo a seguir usa [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) para recuperar as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes incorporadas existentes mantêm seus conjuntos de caracteres atuais.
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Compactar Fontes Incorporadas**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduz os dados de fontes incorporadas removendo caracteres não usados. Ele opera em fontes que já estão incorporadas, portanto a redução de tamanho depende de quanta data de fonte não usada a apresentação contém.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Mantenha o arquivo original se os destinatários puderem precisar adicionar texto posteriormente. Os caracteres removidos durante a compactação não ficam mais disponíveis na fonte incorporada, mesmo que você tenha originalmente incorporado todos os caracteres.

Para permitir que uma fonte registrada correspondente tenha prioridade durante a exportação sem remover a fonte incorporada, veja [Preferir fontes registradas em vez de fontes incorporadas](/slides/pt/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 ou posterior).

## **FAQ**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Também verifique as configurações de [substituição de fonte](/slides/pt/net/font-substitution/) e as regras de [fallback de fonte](/slides/pt/net/fallback-font/). O fallback lida com caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode aumentar o tamanho do arquivo desnecessariamente. Se os destinatários ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.