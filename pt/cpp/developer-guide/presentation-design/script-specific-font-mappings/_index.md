---
title: Gerenciar fontes de tema específicas de script em C++
linktitle: Fontes de tema específicas de script
type: docs
weight: 15
url: /pt/cpp/script-specific-font-mappings/
keywords:
- fonte específica de script
- mapeamento de fonte de tema
- apresentação multilíngue
- sistema de escrita
- fonte cirílica
- fonte árabe
- fonte japonesa
- fonte georgiana
- fonte thaana
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Inspecionar, adicionar, substituir e remover mapeamentos de fontes específicas de script em temas do PowerPoint com Aspose.Slides para C++."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa fontes do tema siga um esquema de fontes coordenado, enquanto utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [IFontScheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ifontscheme/) do tema contém uma coleção de fontes principais, tipicamente usada para títulos, e uma coleção de fontes secundárias, tipicamente usada para o corpo do texto. Além de suas propriedades de fontes latinas e do Leste Asiático, ambas as coleções expõem mapeamentos de tags de sistema de escrita para nomes de famílias de fontes por meio da interface [IFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações persistem após um ciclo de salvar e recarregar.

## **Entender tags de script**

Os métodos de fonte de script usam subtags de script BCP 47 de quatro letras para identificar sistemas de escrita. Valores comuns incluem:

| Tag de script | Sistema de escrita |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chinês simplificado |
| `Jpan` | Japonês |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Esses mapeamentos pertencem ao esquema de fontes do tema, não a trechos individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principais e secundárias, e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fontes de script**

Use [Presentation::get_MasterTheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_mastertheme/) para acessar o tema ao nível da apresentação. Os métodos [FontScheme::get_Major](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/fontscheme/get_major/) e [FontScheme::get_Minor](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/fontscheme/get_minor/) retornam as duas coleções [IFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifonts/).

Chame [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/getscriptfontmap/) para recuperar todos os mapeamentos de uma coleção. Para procurar um sistema de escrita, chame [Fonts::GetScriptFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/getscriptfont/) com sua tag de script. `GetScriptFont` devolve uma string nula quando essa coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [Fonts::SetScriptFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/setscriptfont/) para criar um mapeamento ou substituir sua família de fontes atual. Use [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/removescriptfont/) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, procura a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria um mapeamento thaana somente quando ainda não houver um definido.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

A verificação usa o mesmo comportamento de string nula de uma busca ordinária: após a remoção ser salva, `GetScriptFont(u"Thaa")` devolve uma string nula para a coleção secundária.

## **Distinguir mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Propósito | Efeito de alterar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte principal ou secundária do tema para um sistema de escrita. | O texto que ainda usa a fonte de tema correspondente pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a um trecho de texto | fixa a família de fontes solicitada naquele trecho em vez de depender do tema. | O trecho pode permanecer inalterado porque sua formatação direta sobrescreve a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando ela não está disponível ou quando uma regra de substituição se aplica. | Atua após a fonte ter sido solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, frequentemente para intervalos Unicode específicos. | Preenche cobertura de glifos ausentes; não altera o mapeamento de tema armazenado. |

Para mais informações sobre os dois últimos mecanismos, veja [Font Substitution](/slides/pt/cpp/font-substitution/) e [Fallback Fonts](/slides/pt/cpp/fallback-font/).

Alterar um mapeamento em [Presentation::get_MasterTheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_mastertheme/) afeta apenas o conteúdo cujo formatação efetiva ainda depende desse tema. O texto pode, em vez disso, herdar uma sobrescrição de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não seguir o mapeamento ao nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena um nome de família de fonte; ele não instala nem carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides por meio de uma fonte personalizada, como [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/loadexternalfonts/) ou [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Consulte [Custom Fonts](/slides/pt/cpp/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita requerido em uma imagem ou PDF e inspecione a saída. Isso captura fontes ausentes, cobertura incompleta de glifos, comportamento de fallback e alterações de layout antes que a apresentação seja distribuída. Veja [Convert PowerPoint Presentations](/slides/pt/cpp/convert-powerpoint/) para exemplos de renderização e exportação.

## **FAQ**

**O que `GetScriptFont` devolve quando um script não está mapeado?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/getscriptfont/) devolve uma string nula quando o mapeamento de script solicitado não está definido naquela coleção principal ou secundária.

**`SetScriptFont` adiciona um segundo mapeamento quando o script já existe?**

Não. [Fonts::SetScriptFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fonts/setscriptfont/) cria o mapeamento quando ele está ausente e substitui a família de fonte mapeada quando a mesma tag de script já está presente.

**Por que a alteração de um mapeamento de tema não mudou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrição ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script ao nível da apresentação controla apenas o texto cuja formatação efetiva ainda faz referência àquela coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita requerido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.