---
title: Personalizar fontes do PowerPoint em C++
linktitle: Fonte Personalizada
type: docs
weight: 20
url: /pt/cpp/custom-font/
keywords:
- fonte
- fonte personalizada
- fonte externa
- carregar fonte
- gerenciar fontes
- pasta de fontes
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para C++ para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão Geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. É possível carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica por meio de fontes em nível de documento ou carregar fontes externas diretamente a partir de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é separado de incorporar fontes a um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

Um tema de apresentação pode referenciar diferentes famílias de fontes para sistemas de escrita individuais. Esses mapeamentos armazenam nomes de fontes, mas não instalam nem carregam os arquivos de fonte. Consulte [Fontes de Tema Específicas por Script](/slides/pt/cpp/script-specific-font-mappings/) para gerenciar os mapeamentos e use as opções de carregamento abaixo para tornar as fontes referenciadas disponíveis para renderização consistente.

{{% alert color="info" title="Note" %}}

Aspose Slides permite que você carregue essas fontes usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Fontes TrueType (.ttf) e TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fontes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carregar Fontes Personalizadas**

Aspose.Slides permite que você carregue as fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída de exportação — como PDF, imagens e outros formatos suportados — de modo que os documentos resultantes tenham aparência consistente em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.
2. Chame o método estático [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/loadexternalfonts/) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.clearCache](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/clearcache/) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Defina pastas que contenham arquivos de fontes personalizados.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Carregue fontes personalizadas das pastas especificadas.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Limpe o cache de fontes após a finalização do trabalho.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/loadexternalfonts/) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.  
As fontes são inicializadas nesta ordem:

1. O caminho de fonte padrão do sistema operacional.  
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter Pastas de Fontes Personalizadas**

Aspose.Slides fornece [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/getfontfolders/) para permitir que você encontre pastas de fontes. Esse método retorna as pastas adicionadas através do método `LoadExternalFonts` e as pastas de fontes do sistema.

Este código C++ mostra como usar o método [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Esta linha exibe as pastas que são verificadas para arquivos de fonte.
// Essas são pastas adicionadas através do método LoadExternalFonts e pastas de fontes do sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Especificar Fontes Personalizadas Usadas com uma Apresentação**

Aspose.Slides fornece a propriedade [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código C++ mostra como usar a propriedade [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //trabalhe com a apresentação
    //CustomFont1, CustomFont2, bem como fontes das pastas assets\fonts e global\fonts e de suas subpastas, estão disponíveis para a apresentação
}
```

## **Gerenciar Fontes Externamente**

Aspose.Slides fornece o método [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/loadexternalfont/) para permitir que você carregue fontes externas em um array de bytes.

Este código C++ demonstra o processo de carregamento de fonte em um array de bytes:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// O caminho para o diretório de documentos
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

### As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

### As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la a um PPTX. Se precisar que a fonte esteja incluída no arquivo da apresentação, use os recursos explícitos de [incorporação](/slides/pt/cpp/embedded-font/).

### Posso controlar o comportamento de fallback quando uma fonte personalizada não possui certos glifos?

Sim. Configure [substituição de fonte](/slides/pt/cpp/font-substitution/), [regras de substituição](/slides/pt/cpp/font-replacement/) e [conjuntos de fallback](/slides/pt/cpp/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

### Posso usar fontes em contêineres Linux/Docker sem instalá‑las no sistema?

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência de diretórios de fontes do sistema na imagem do contêiner.

### E quanto à licença — posso incorporar qualquer fonte personalizada sem restrições?

Você é responsável pela conformidade com a licença da fonte. Os termos variam; algumas licenças proíbem a incorporação ou uso comercial. Sempre revise o EULA da fonte antes de distribuir os resultados.