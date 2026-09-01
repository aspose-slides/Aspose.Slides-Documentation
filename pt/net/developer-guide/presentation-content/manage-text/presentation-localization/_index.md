---
title: Automatizar a localização de apresentações em .NET
linktitle: Localização de Apresentações
type: docs
weight: 100
url: /pt/net/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id do idioma
- texto multilíngue
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Defina idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em .NET com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides for .NET permite configurar metadados de revisão para porções individuais de texto. Use [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/languageid/) para identificar o idioma de revisão, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/spellcheck/) para permitir ou suprimir a verificação ortográfica e [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/proofdisabled/) para controlar o estado mais amplo de “não revisar”. Como essas configurações são aplicadas no nível da porção, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaulttextlanguage/), criar parágrafos multilíngues, escolher entre `SpellCheck` e `ProofDisabled` e preservar as configurações pretendidas ao usar [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/joinportionswithsameformatting/). Essas propriedades armazenam metadados para aplicativos de apresentação; elas não traduzem texto, não executam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para o texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), acesse a porção de texto desejada através de [IPortion.PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/portionformat/) e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o inglês britânico como idioma de revisão e salva o resultado com [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Definir o idioma padrão para novo texto**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaulttextlanguage/) para especificar o idioma de revisão que o Aspose.Slides atribui ao texto recém‑criado. Essa configuração é útil quando a maior parte ou todo o novo texto de uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma de texto que já possui um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto usa as regras de revisão em alemão:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Usar vários idiomas em um parágrafo**

Um [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) contém uma coleção de porções de texto. Crie uma [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/) separada para cada idioma e defina seu `LanguageId` independentemente.

Este exemplo cria um parágrafo com porções em inglês e francês:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Habilitar ou suprimir a verificação ortográfica para porções individuais**

[IPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/) herda as propriedades de texto comuns definidas por [IBasePortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/). Acesse o formato de uma porção através de [IPortion.PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/portionformat/) e defina [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/spellcheck/) para controlar se um aplicativo de apresentação pode verificar a ortografia dessa porção. O valor padrão é `false`: `true` permite a verificação ortográfica, enquanto `false` a suprime.

A configuração se aplica a porções individuais de texto. Porções diferentes no mesmo parágrafo podem, portanto, usar valores diferentes. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/languageid/) e `SpellCheck` têm propósitos complementares: `LanguageId` identifica o idioma de revisão, enquanto `SpellCheck` determina se a verificação ortográfica é permitida para a porção.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/proofdisabled/) também controla a revisão, mas representa o estado mais amplo “não revisar” como um [NullableBool](https://reference.aspose.com/slides/pt/net/aspose.slides/nullablebool/). Use `SpellCheck` quando precisar de um interruptor booleano direto especificamente para verificações ortográficas. Use `ProofDisabled` quando precisar preservar ou controlar explicitamente os metadados de “não revisar” da apresentação, incluindo seu estado `NotDefined`. Se definir ambas as propriedades, mantenha seus valores consistentes; não combine `SpellCheck = true` com `ProofDisabled = NullableBool.True`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não os usa para executar verificação ortográfica baseada em dicionário ou para retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, a carrega, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a duas porções no mesmo parágrafo, salva o resultado, reabre‑o e verifica os valores armazenados:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/joinportionswithsameformatting/) combina porções adjacentes que têm a mesma formatação. Uma diferença apenas em `SpellCheck` não impede que tais porções sejam unidas; após a união, a porção resultante mantém o valor `SpellCheck` da primeira porção. Se as porções precisarem de configurações de verificação ortográfica diferentes, chame `JoinPortionsWithSameFormatting` antes de atribuir essas configurações, ou inspecione os limites das porções resultantes e reaplique as configurações posteriormente. Porções com valores diferentes de `LanguageId` permanecem separadas porque a formatação de idioma de revisão difere.

## **FAQ**

**Um ID de idioma traduz o texto?**

Não. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/languageid/) armazena metadados de revisão para ortografia e gramática; não altera o conteúdo do texto. Traduza o texto separadamente e, então, defina o identificador de idioma apropriado para cada porção traduzida.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma serve para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/net/powerpoint-fonts/), do sistema de escrita e das configurações da caixa de texto. Para renderização confiável, forneça as fontes necessárias, configure a [font substitution](/slides/pt/net/font-substitution/) ou [embed fonts](/slides/pt/net/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a uma porção separada, como mostrado no exemplo de parágrafo multilíngue.

**Devo usar `DefaultTextLanguage` ou `LanguageId`?**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/defaulttextlanguage/) quando quiser um padrão para texto recém‑criado. Use [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/languageid/) quando uma porção específica precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.