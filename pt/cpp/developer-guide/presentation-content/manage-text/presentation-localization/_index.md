---
title: Automatizar a localização de apresentações em C++
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/cpp/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id do idioma
- texto multilíngue
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Defina idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em C++ com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides for C++ permite configurar metadados de revisão para trechos individuais de texto. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_languageid/) para identificar o idioma de revisão, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_spellcheck/) para permitir ou suprimir a verificação ortográfica e [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_proofdisabled/) para controlar o estado mais amplo de “não revisar”. Como essas configurações são aplicadas ao nível do trecho, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), criar parágrafos multilíngues, escolher entre `SpellCheck` e `ProofDisabled` e preservar as configurações desejadas ao usar [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Essas propriedades armazenam metadados para aplicativos de apresentação; elas não traduzem texto, não executam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para o texto**

Crie ou carregue um [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), acesse o trecho de texto desejado através de [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_portionformat/) e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o inglês britânico como idioma de revisão e salva o resultado com [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir o idioma padrão para novo texto**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) para especificar o idioma de revisão que o Aspose.Slides atribui ao texto recém‑criado. Essa configuração é útil quando a maior parte ou todo o texto novo de uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma do texto que já possui um idioma explícito.

O exemplo a seguir cria uma apresentação cujo texto novo usa regras de revisão em alemão:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usar vários idiomas em um parágrafo**

Um [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) contém uma coleção de trechos de texto. Crie um [Portion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portion/) separado para cada idioma e defina seu `LanguageId` independentemente.

Este exemplo cria um parágrafo com trechos em inglês e francês:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Habilitar ou suprimir a verificação ortográfica para trechos individuais**

[IPortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformat/) herda as propriedades comuns de texto definidas por [IBasePortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/). Acesse o formato de um trecho via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_portionformat/) e chame [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_spellcheck/) para controlar se um aplicativo de apresentação pode verificar a ortografia desse trecho. O valor padrão é `false`: `true` permite a verificação ortográfica, enquanto `false` a suprime.

A configuração se aplica a trechos de texto individuais. Trechos diferentes no mesmo parágrafo podem, portanto, usar valores distintos. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) e `SpellCheck` têm propósitos complementares: `LanguageId` identifica o idioma de revisão, enquanto `SpellCheck` determina se a verificação ortográfica é permitida para o trecho.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_proofdisabled/) também controla a revisão, mas representa o estado mais amplo “não revisar” como um [NullableBool](https://reference.aspose.com/slides/pt/cpp/aspose.slides/nullablebool/). Use `SpellCheck` quando precisar de um interruptor booleano direto especificamente para verificações ortográficas. Use `ProofDisabled` quando precisar preservar ou controlar explicitamente os metadados de “não revisar” da apresentação, incluindo seu estado `NullableBool::NotDefined`. Se definir ambas as propriedades, mantenha seus valores consistentes; não combine `SpellCheck = true` com `ProofDisabled = NullableBool::True`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não as utiliza para executar verificação ortográfica baseada em dicionário ou retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, a carrega, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a dois trechos no mesmo parágrafo, salva o resultado, reabre-o e verifica os valores armazenados:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combina trechos adjacentes que têm a mesma formatação. Uma diferença apenas em `SpellCheck` não impede que esses trechos sejam unidos; após a junção, o trecho resultante mantém o valor `SpellCheck` do primeiro trecho. Se os trechos precisarem de configurações de verificação ortográfica diferentes, chame `JoinPortionsWithSameFormatting` antes de atribuir essas configurações, ou inspecione os limites dos trechos resultantes e reaplique as configurações posteriormente. Trechos com valores diferentes de `LanguageId` permanecem separados porque a formatação de idioma de revisão difere.

## **Perguntas frequentes**

**O ID de idioma traduz o texto?**

Não. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_languageid/) armazena metadados de revisão para ortografia e gramática; ele não altera o conteúdo do texto. Traduza o texto separadamente e, então, defina o identificador de idioma apropriado para cada trecho traduzido.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma serve apenas para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/cpp/powerpoint-fonts/), do sistema de escrita e das configurações de quadro de texto. Para renderização confiável, forneça as fontes necessárias, configure a [substituição de fontes](/slides/pt/cpp/font-substitution/) ou [incorpore fontes](/slides/pt/cpp/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a um trecho separado, como mostrado no exemplo de parágrafo multilíngue.

**Devo usar `DefaultTextLanguage` ou `LanguageId`?**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) quando quiser um padrão para texto recém‑criado. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_languageid/) quando um trecho específico precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.