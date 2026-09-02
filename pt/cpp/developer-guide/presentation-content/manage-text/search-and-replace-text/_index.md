---
title: Buscar e Substituir Texto em Apresentações PowerPoint em C++
linktitle: Buscar e Substituir Texto
type: docs
weight: 55
url: /pt/cpp/search-and-replace-text/
keywords:
- texto de pesquisa
- texto realçado
- substituir texto
- expressão regular
- callback de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Pesquisar, realçar e substituir texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides para C++."
---
## **Visão Geral**

Aspose.Slides para C++ pode pesquisar, realçar e substituir texto em um único quadro de texto ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um callback de resultado. Isso permite atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondido, seu contexto, posição, quadro de texto e número do slide.

Esses recursos são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte texto:

![Texto de exemplo](sample_text.png)

## **Escolher o Escopo da Busca**

Use os métodos em [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) para limitar uma operação a um único quadro de texto. Use os métodos em [IPresentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [ITextFrame::HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/highlighttext/) |
| Realçar correspondências de expressão regular | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/highlightregex/) |
| Substituir texto literal | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/replacetext/) |
| Substituir correspondências de expressão regular | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configurar Correspondência de Texto**

Para operações de texto literal, use [ITextSearchOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/) para controlar a correspondência:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limita as correspondências a palavras completas.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) controla se a diferenciação de maiúsculas/minúsculas deve coincidir.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_includenotes/) inclui notas de slide nas operações de busca, substituição e realce em nível de apresentação.

Operações de expressão regular utilizam um `System::Text::RegularExpressions::Regex`, portanto as regras de correspondência, como diferenciação de maiúsculas/minúsculas e limites de palavra, são definidas pela expressão e suas opções.

## **Identificar o Proprietário de um Quadro de Texto**

Fluxos de trabalho genéricos de processamento de texto frequentemente recebem um [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) enquanto pesquisam, substituem, validam ou exportam texto. Use [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentshape/) e [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentcell/) para determinar qual objeto da apresentação possui o quadro de texto.

Os valores esperados dependem do proprietário:

| Proprietário do quadro de texto | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Um AutoShape ou outra forma que contém texto | A [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) proprietária | `nullptr` |
| Uma célula de tabela | `nullptr` | A [ICell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icell/) proprietária |

Ambos os métodos fornecem navegação somente leitura. Chamá‑los não move o quadro de texto nem altera seu proprietário. Código genérico deve verificar ambos os valores em busca de `nullptr` e tratar a possibilidade de que nenhum proprietário esteja disponível.

O exemplo a seguir usa [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/getalltextframes/) para percorrer os quadros de texto em uma apresentação. Para formas, ele relata o nome da forma, o tipo em tempo de execução do C++ e o slide contendo. Para células de tabela, ele relata as coordenadas de coluna e linha baseadas em zero e o slide contendo.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Para conteúdo SmartArt, itere pelas formas em [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) e acesse cada [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). O quadro de texto pode ser rastreado até sua forma associada através de [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentshape/), enquanto [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentcell/) devolve `nullptr`. Portanto, o ramo de forma no exemplo também trata texto de nós SmartArt.

## **Coletar informações de correspondência com um callback**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifindresultcallback/) para receber uma notificação para cada correspondência. Seu método [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifindresultcallback/foundresult/) fornece o quadro de texto relacionado, o texto de origem, o texto correspondido e a posição da correspondência.

O callback não recebe um número de slide diretamente. A implementação abaixo o obtém a partir de [ISlideComponent::get_Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecomponent/get_slide/) e também trata texto encontrado em notas de slide através de [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotesslide/get_parentslide/). Um número de slide nullable permite que o mesmo modelo de resultado represente texto associado a outros tipos de slide.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Para operações de substituição, `FoundText` contém o texto original correspondido, de modo que o callback pode registrar exatamente quais termos foram substituídos.

## **Realçar Texto**

Use o método [ITextFrame::HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlighttext/) para realçar correspondências de texto literal em um quadro de texto. Passe [ITextSearchOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/) para controlar a pesquisa e um callback para coletar detalhes da correspondência.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e depois realça apenas a palavra completa **"to"**. Ambas as pesquisas reportam suas correspondências ao mesmo callback.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O texto realçado](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlightregex/) realça correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres e coleta cada correspondência:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O texto realçado usando a expressão regular](highlighted_text_using_regex.png)

## **Realçar Texto em Toda a Apresentação**

Use [IPresentation::HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/highlighttext/) e [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/highlightregex/) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de email, mantendo coleções de resultados separadas para as duas pesquisas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Substituir Texto em um Quadro de Texto**

Use [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replacetext/) para texto literal e [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replaceregex/) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, que mantém a formatação da porção ao redor em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e depois substitui rótulos de versão. O mesmo callback registra os termos originais correspondidos por ambas as operações.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se uma correspondência abranger porções com formatações diferentes, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir Texto em Toda a Apresentação**

Use [IPresentation::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/replacetext/) e [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/replaceregex/) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Agrupar Correspondências para Relatórios**

Como cada resultado armazena seu número de slide e quadro de texto, as aplicações podem agrupar correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **Perguntas Frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [ITextFrame::HighlightText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replacetext/) ou [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replaceregex/) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Chame [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) e [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) com `true`, e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas diretamente na `System::Text::RegularExpressions::Regex`.

**A busca e substituição podem incluir texto nas notas de slide?**

Sim. Chame [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextsearchoptions/set_includenotes/) com `true` ao usar uma operação de texto literal em nível de apresentação. A implementação de callback mostrada acima mapeia uma correspondência em uma nota de slide de volta ao número do slide pai.

**Como posso criar um relatório sem analisar a apresentação uma segunda vez?**

Passe uma implementação de [IFindResultCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifindresultcallback/) para a operação de realce ou substituição. O callback recebe cada correspondência enquanto a operação é executada, de modo que a aplicação pode armazenar o texto de origem, texto correspondido, posição, quadro de texto e número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replacetext/) e [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/replaceregex/) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação da porção ao redor. Se uma correspondência abranger porções com formatações diferentes, examine o resultado para garantir que a substituição use o estilo desejado.