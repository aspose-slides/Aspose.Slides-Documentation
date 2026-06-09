---
title: Formatar texto de apresentação em C++
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/cpp/text-formatting/
keywords:
- texto em destaque
- expressão regular
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência de texto
- espaçamento entre caracteres
- propriedades da fonte
- família de fontes
- rotação de texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- âncora do quadro de texto
- tabulação de texto
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++. Ele aborda destaque, cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Nos exemplos abaixo, usaremos um arquivo chamado **sample.pptx**, que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Texto de exemplo](sample_text.png)

## **Destacar texto**

Use o método [ITextFrame.HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlighttext/) quando precisar destacar texto que corresponda a uma amostra específica dentro de um quadro de texto. O método aplica uma cor de destaque aos fragmentos de texto correspondentes e pode ser usado com [ITextSearchOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/) para controlar como a pesquisa é executada, por exemplo, para corresponder apenas a palavras inteiras.

O exemplo de código abaixo destaca todas as ocorrências dos caracteres **"try"** e depois destaca apenas a palavra completa **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Obtenha a primeira forma do primeiro slide.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Realce a palavra "try" na forma.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Realce a palavra "to" na forma.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O texto destacado](highlighted_text.png)

## **Destacar texto usando expressões regulares**

O método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlightregex/) destaca correspondências de texto encontradas por uma expressão regular. Em C++, essa API é exposta em [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/).

O exemplo de código abaixo destaca todas as palavras que contêm **sete ou mais caracteres**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Destaque todas as palavras com sete ou mais caracteres.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O texto destacado usando a expressão regular](highlighted_text_using_regex.png)

## **Definir cor de fundo do texto**

Use `IParagraphFormat`.DefaultPortionFormat para definir a cor de destaque padrão de um parágrafo, ou use `IPortionFormat`.HighlightColor para porções de texto individuais.

O exemplo de código a seguir mostra como definir a cor de fundo para o **parágrafo inteiro**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **porções de texto com fonte em negrito**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Defina a cor de destaque para a porção de texto.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As porções de texto cinzas](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use `IParagraphFormat`.Alignment para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Defina o alinhamento do parágrafo para o centro.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Definir transparência para texto**

A transparência do texto é controlada pelo componente alfa da cor atribuída a `IPortionFormat`.FillFormat`. Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala de 0‑255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **porções de texto com fonte em negrito**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Defina a transparência da porção de texto.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento de caracteres para texto**

Use `IBasePortionFormat`.Spacing para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto.

O código C++ a seguir mostra como expandir o espaçamento de caracteres no **parágrafo inteiro**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O espaçamento de caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento de caracteres em **porções de texto com fonte em negrito**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O espaçamento de caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desativar kerning para fontes específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para determinadas fontes, mesmo quando a fonte contém informações válidas de kerning e o kerning está habilitado nas configurações do PowerPoint.

Para tornar a saída renderizada mais próxima do PowerPoint nesses casos, você pode desativar o kerning para as porções de texto que usam a fonte afetada. Defina `IPortionFormat`.KerningMinimalSize para um valor significativamente maior que o tamanho real da fonte:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Essa configuração impede que o kerning seja aplicado às porções de texto correspondentes e pode ajudar a alinhar a renderização do Aspose.Slides ao resultado visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de `IParagraphFormat`.DefaultPortionFormat ou em porções individuais através de `IPortionFormat`.

O código a seguir define a fonte e o estilo de texto para o **parágrafo inteiro**: ele aplica tamanho de fonte, negrito, itálico, sublinhado pontilhado e a fonte Times New Roman a todas as porções do parágrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Defina as propriedades da fonte para o parágrafo.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As propriedades de fonte para o parágrafo](font_properties_for_paragraph.png)

O exemplo de código abaixo aplica propriedades semelhantes a **porções de texto com fonte em negrito**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Defina as propriedades da fonte para a porção de texto.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As propriedades de fonte para as porções de texto](font_properties_for_text_portions.png)

## **Definir rotação do texto**

Use `ITextFrameFormat`.TextVerticalType para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para `Vertical270`, que gira o texto **90 graus no sentido anti‑horário**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir rotação personalizada para quadros de texto**

Use `ITextFrameFormat`.RotationAngle para definir um ângulo de rotação personalizado para um `ITextFrame`.

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir espaçamento de linha dos parágrafos**

Aspose.Slides fornece `IParagraphFormat`.SpaceAfter, `IParagraphFormat`.SpaceBefore e `IParagraphFormat`.SpaceWithin para controlar o espaçamento dos parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento de linha como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento de linha em pontos.

O exemplo de código a seguir mostra como especificar o espaçamento de linha dentro do parágrafo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O espaçamento de linha dentro do parágrafo](line_spacing.png)

## **Definir tipo de ajuste automático para quadros de texto**

`ITextFrameFormat`.AutofitType determina como o texto se comporta quando excede os limites de seu contêiner. Use-o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir âncora dos quadros de texto**

`ITextFrameFormat`.AnchoringType define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, centro ou base.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir tabulação de texto**

Use `IParagraphFormat`.DefaultTabSize e `IParagraphFormat`.Tabs para configurar as tabulações em um parágrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir idioma de revisão**

Aspose.Slides fornece `IPortionFormat`.LanguageId, que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado para verificação ortográfica e gramatical no PowerPoint.

O exemplo de código a seguir mostra como definir o idioma de revisão para uma porção de texto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Defina o Id de um idioma de revisão.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir idioma padrão**

Use `ILoadOptions`.DefaultTextLanguage para definir o idioma padrão para textos criados ao carregar ou criar uma apresentação.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use `IPresentation`.DefaultTextStyle`.

O exemplo de código a seguir define uma fonte negrito padrão com tamanho 14 pt para todo o texto em todas as slides de uma nova apresentação.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Obtenha o formato de parágrafo do nível superior.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrair texto com efeito de todas maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz com que o texto apareça em maiúsculas no slide, mesmo quando foi originalmente digitado em minúsculas. Ao recuperar tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique `TextCapType` e converta a string retornada para maiúsculas quando o valor for `All`.

Suponha que temos a seguinte caixa de texto no primeiro slide do arquivo **sample2.pptx**.

![O efeito Todas Maiúsculas](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use `ITable`. Percorra as células e atualize cada célula através de `ICell`.TextFrame e formate os parágrafos usando `IParagraph`.ParagraphFormat.

**Como aplicar cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar cor gradiente ao texto, use `IPortionFormat`.FillFormat. Defina `IFillFormat`.FillType para `FillType`.Gradient e configure as paradas do gradiente, a direção e a transparência.