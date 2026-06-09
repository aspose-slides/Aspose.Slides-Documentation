---
title: Personalizar fontes do PowerPoint no .NET
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para .NET para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica por meio de fontes em nível de documento ou carregar fontes externas diretamente a partir de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é diferente de incorporar fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

{{% alert color="primary" %}} 

Aspose Slides permite que você carregue essas fontes usando o método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) e TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída da exportação — como PDF, imagens e outros formatos suportados — para que os documentos resultantes tenham a mesma aparência em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fontes.
2. Chame o método estático [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfonts/) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.ClearCache](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/clearcache/) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```cs
// Defina pastas que contêm arquivos de fontes personalizadas.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Carregue fontes personalizadas das pastas especificadas.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Limpe o cache de fontes depois que o trabalho for concluído.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfonts/) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.
As fontes são inicializadas nesta ordem:

1. O caminho de fonte padrão do sistema operacional.
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter pastas de fontes personalizadas**

Aspose.Slides fornece o método [GetFontFolders](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/getfontfolders/) para permitir que você encontre pastas de fontes. Esse método devolve as pastas adicionadas através do método `LoadExternalFonts` e as pastas de fontes do sistema.

Este código C# mostra como usar [GetFontFolders](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Esta linha exibe as pastas que são verificadas para arquivos de fontes.
// Essas são pastas adicionadas pelo método LoadExternalFonts e pastas de fontes do sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Especificar fontes personalizadas usadas com uma apresentação**

Aspose.Slides fornece a propriedade [DocumentLevelFontSources](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/documentlevelfontsources/) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código C# mostra como usar a propriedade [DocumentLevelFontSources](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Trabalhe com a apresentação
    // CustomFont1, CustomFont2 e fontes das pastas assets\fonts & global\fonts e seus subdiretórios estão disponíveis para a apresentação
}
```

## **Gerenciar fontes externamente**

Aspose.Slides fornece o método [LoadExternalFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) para permitir que você carregue fontes externas a partir de dados binários.

Este código C# demonstra o processo de carregamento de fonte a partir de um array de bytes:

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // fonte externa carregada durante a vida útil da apresentação
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?**

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

**As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?**

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la em um PPTX. Se precisar que a fonte esteja dentro do arquivo de apresentação, use os recursos explícitos de [incorporação](/slides/pt/net/embedded-font/).

**Posso controlar o comportamento de fallback quando uma fonte personalizada não possui certos glifos?**

Sim. Configure [substituição de fontes](/slides/pt/net/font-substitution/), [regras de substituição](/slides/pt/net/font-replacement/) e [conjuntos de fallback](/slides/pt/net/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

**Posso usar fontes em contêineres Linux/Docker sem instalá‑las no sistema?**

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência de diretórios de fontes do sistema na imagem do contêiner.

**E quanto à licenciamento — posso incorporar qualquer fonte personalizada sem restrições?**

Você é responsável pela conformidade de licenciamento das fontes. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre revise o EULA da fonte antes de distribuir os resultados.