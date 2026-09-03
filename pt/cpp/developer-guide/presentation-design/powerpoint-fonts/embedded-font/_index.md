---
title: Incorporar fontes em apresentações em C++
linktitle: Fontes incorporadas
type: docs
weight: 40
url: /pt/cpp/embedded-font/
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
- C++
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para C++. Adicione, recupere, remova e compacte fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados da fonte dentro de uma apresentação PowerPoint. Quando um visualizador suporta fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento do texto e o layout dos slides.

Aspose.Slides for C++ permite recuperar, adicionar e remover fontes incorporadas através do [Presentation::get_FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_fontsmanager/) método de uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Você também pode reduzir o tamanho dos dados de fontes incorporadas removendo caracteres que a apresentação não usa.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique‑se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), e então salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove Calibri se estiver presente:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Remover uma fonte incorporada elimina os dados de fonte armazenados; isso não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda pode usá‑la. Caso contrário, a renderização pode exigir [substituição de fonte](/slides/pt/cpp/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados da Fonte e Permissões de Incorporação**

Use a interface [IFontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [IFontsManager::GetFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getfonts/) para obter as fontes usadas na apresentação. Para cada fonte, passe um objeto [IFontData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontdata/) e o valor requerido de [FontStyleType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontstyletype/) para [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getfontbytes/). O método devolve os dados binários desse estilo de fonte, ou `nullptr` quando a fonte ou estilo solicitados não estão disponíveis. Não passe um resultado `nullptr` para [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), pois esse método requer um array de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/embeddinglevel/) é uma enumeração de sinalizadores que relata as restrições de incorporação armazenadas na fonte:

- `Installable` permite a incorporação e instalação permanente em outro sistema, sujeito à licença da fonte.
- `Restricted` proíbe a incorporação a menos que seja obtida permissão do proprietário legal da fonte quando este for o único sinalizador de permissão de uso.
- `PreviewPrint` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente leitura.
- `Editable` permite uso temporário e permite que o documento seja editado e salvo.
- `NoSubsetting` é uma restrição adicional que proíbe incorporar apenas um subconjunto dos glifos. Incorpore todos os caracteres quando este sinalizador estiver presente.
- `BitmapOnly` é uma restrição adicional que permite apenas bitmap strikes serem incorporados, não dados de contorno. Se a fonte não possuir bitmap strikes, não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NoSubsetting` e `BitmapOnly` podem ser combinados com eles. Verifique os modificadores com operações bit‑a‑bit. Como `Installable` vale zero, mascare os bits de permissão de uso e compare o resultado com `Installable`. As fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o auxiliar abaixo seleciona a permissão menos restritiva: `Editable`, depois `PreviewPrint`, depois `Restricted`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte retornada por `GetFonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes apenas‑bitmap, fontes limitadas a visualização e impressão porque a saída permanece editável, e fontes que já estão incorporadas. Se algum estilo disponível possuir `NoSubsetting`, ele incorpora todos os caracteres para aquela família de fontes.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Esta inspeção relata as restrições codificadas em cada arquivo de fonte. Ela não concede licença, não prova que você obteve a fonte legalmente, nem substitui a verificação do contrato de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/addembeddedfont/) para incorporar uma fonte. Suas sobrecargas aceitam um objeto [IFontData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontdata/) ou um array de bytes contendo os dados da fonte. A enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedfontcharacters/) controla quais caracteres são incluídos:

- [All](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisarem editar a apresentação e inserir novo texto.
- [OnlyUsed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedfontcharacters/) incorpora apenas os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final destinada principalmente à visualização.

O exemplo a seguir usa [IFontsManager::GetFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getfonts/) para obter as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes incorporadas existentes mantêm seus conjuntos de caracteres atuais.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comprimir Fontes Incorporadas**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) reduz os dados de fontes incorporadas removendo caracteres não usados. Ele opera sobre fontes que já estão incorporadas, portanto a redução de tamanho depende de quantos dados de fonte não utilizados a apresentação contém.

O exemplo a seguir comprime as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Guarde o arquivo original caso os destinatários precisem adicionar texto posteriormente. Os caracteres removidos durante a compressão não ficam mais disponíveis na fonte incorporada, mesmo que você originalmente tenha incorporado todos os caracteres.

## **Perguntas Frequentes**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontsmanager/getsubstitutions/) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Também verifique as configurações de [substituição de fonte](/slides/pt/cpp/font-substitution/) e as regras de [fallback de fonte](/slides/pt/cpp/fallback-font/). O fallback trata caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode acrescentar tamanho de arquivo desnecessário. Se os destinatários ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.