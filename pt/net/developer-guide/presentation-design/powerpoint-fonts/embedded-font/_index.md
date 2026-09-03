---
title: Incorporar Fontes em Apresentações no .NET
linktitle: Fontes Incorporadas
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
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para .NET. Use C# para adicionar, recuperar, remover e compactar fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados da fonte dentro de uma apresentação do PowerPoint. Quando um visualizador suporta fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que elas não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento de texto e layout dos slides.

Aspose.Slides for .NET permite que você recupere, adicione e remova fontes incorporadas por meio da propriedade [FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/fontsmanager/) de uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Você também pode reduzir o tamanho dos dados da fonte incorporada removendo caracteres que a apresentação não utiliza.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique‑se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [GetEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts/) para listar as fontes armazenadas em uma apresentação. Para remover uma delas, passe uma fonte dessa lista para [RemoveEmbeddedFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/removeembeddedfont/), em seguida salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove Calibri se ela estiver presente:

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

Remover uma fonte incorporada elimina seus dados de fonte armazenados; isso não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda poderá utilizá‑la. Caso contrário, a renderização pode exigir [font substitution](/slides/pt/net/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados da Fonte e Permissões de Incorporação**

Use a interface [IFontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [IFontsManager.GetFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getfonts/) para obter as fontes usadas na apresentação. Para cada fonte, passe um objeto [IFontData](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontdata/) e o valor necessário de [FontStyleType](https://reference.aspose.com/slides/pt/net/aspose.slides/fontstyletype/) para [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getfontbytes/). O método devolve os dados binários para esse estilo de fonte, ou `null` quando a fonte ou o estilo solicitado não está disponível. Não passe um resultado `null` para [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), pois esse método requer um array de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/pt/net/aspose.slides/embeddinglevel/) é uma enumeração de flags que relata as restrições de incorporação armazenadas na fonte:

- `Installable` permite a incorporação e instalação permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proíbe a incorporação a menos que permissão seja obtida do proprietário legal da fonte quando esse for o único flag de permissão de uso.
- `PreviewPrint` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente‑leitura.
- `Editable` permite uso temporário e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restrição adicional que proíbe a incorporação de apenas um subconjunto de glifos. Incorpore todos os caracteres quando essa flag estiver presente.
- `BitmapOnly` é uma restrição adicional que permite apenas a incorporação de bitmaps, não de dados de contorno. Se a fonte não possuir bitmaps, ela não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operações bitwise. Como `Installable` tem valor zero, não use `HasFlag` para detectá‑lo; faça uma máscara dos bits de permissão de uso e compare o resultado com `Installable`. Fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o auxiliar abaixo seleciona a permissão menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte retornada por `GetFonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes somente‑bitmap, fontes limitadas a visualização e impressão porque a saída permanece editável, e fontes que já estão incorporadas. Se algum estilo disponível possuir `NoSubsetting`, ele incorpora todos os caracteres dessa família de fontes.

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

Essa inspeção relata as restrições codificadas em cada arquivo de fonte. Ela não concede licença, não prova que você obteve a fonte legalmente, nem substitui a verificação do contrato de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [AddEmbeddedFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/addembeddedfont/) para incorporar uma fonte. Seus overloads aceitam ou um objeto [IFontData](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontdata/) ou um array de bytes contendo os dados da fonte. A enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedfontcharacters/) controla quais caracteres são incluídos:

- [All](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisarão editar a apresentação e inserir novo texto.
- [OnlyUsed](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedfontcharacters/) incorpora apenas os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final destinada principalmente à visualização.

O exemplo a seguir usa [GetFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes incorporadas existentes mantêm seus conjuntos de caracteres atuais.

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

[CompressEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduz os dados de fontes incorporadas removendo caracteres não utilizados. Ele opera sobre fontes que já foram incorporadas, portanto a redução de tamanho depende da quantidade de dados de fonte não utilizados presentes na apresentação.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Mantenha o arquivo original se os destinatários puderem precisar adicionar texto posteriormente. Caracteres removidos durante a compactação não ficam mais disponíveis na fonte incorporada, mesmo que você originalmente tenha incorporado todos os caracteres.

## **FAQ**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getsubstitutions/) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Verifique também as configurações de [font substitution](/slides/pt/net/font-substitution/) e as regras de [font fallback](/slides/pt/net/fallback-font/). O fallback lida com caracteres ausentes, portanto incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode acrescentar tamanho de arquivo desnecessário. Se os destinatários ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.