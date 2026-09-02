---
title: Personalizar fontes do PowerPoint em JavaScript
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com JavaScript e Aspose.Slides para Node.js via Java para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica por meio de fontes em nível de documento ou carregar fontes externas diretamente a partir de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos compatíveis. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é separado de incorporar fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

Um tema de apresentação pode referenciar diferentes famílias de fontes para sistemas de escrita individuais. Esses mapeamentos armazenam nomes de fontes, mas não instalam nem carregam os arquivos de fonte. Consulte [Fontes de Tema Específicas ao Script](/slides/pt/nodejs-java/script-specific-font-mappings/) para gerenciar os mapeamentos e use as opções de carregamento abaixo para tornar as fontes referenciadas disponíveis para renderização consistente.

{{% alert color="info" title="Nota" %}}

Aspose Slides permite que você carregue essas fontes usando o método [loadExternalFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fontes TrueType (.ttf) e TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fontes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída da exportação — como PDF, imagens e outros formatos compatíveis — de modo que os documentos resultantes pareçam consistentes em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.
2. Chame o método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.clearCache](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/clearcache/) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Defina pastas que contêm arquivos de fontes personalizados.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Carregue fontes personalizadas das pastas especificadas.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Limpe o cache de fontes após o término do trabalho.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Nota" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.  
As fontes são inicializadas nesta ordem:

1. O caminho padrão de fontes do sistema operacional.  
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter pasta de fontes personalizadas**

Aspose.Slides fornece o método [getFontFolders](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) para permitir que você encontre pastas de fontes. Esse método retorna pastas adicionadas através do método `LoadExternalFonts` e pastas de fontes do sistema.

Este código JavaScript mostra como usar [getFontFolders](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Esta linha exibe pastas onde os arquivos de fonte são pesquisados.
// Estas são pastas adicionadas através do método LoadExternalFonts e pastas de fontes do sistema.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Especificar fontes personalizadas usadas com a apresentação**

Aspose.Slides fornece a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código JavaScript mostra como usar a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabalhar com a apresentação
    // CustomFont1, CustomFont2 e fontes das pastas assets\fonts & global\fonts e suas subpastas estão disponíveis para a apresentação
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerenciar fontes externamente**

Aspose.Slides fornece o método [loadExternalFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitir que você carregue fontes externas a partir de dados binários.

Este código JavaScript demonstra o processo de carregamento de fonte a partir de um array de bytes:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // fonte externa carregada durante a vida útil da apresentação
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Perguntas frequentes**

### As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

### As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la em um PPTX. Se você precisar que a fonte seja transportada dentro do arquivo da apresentação, deve usar os [recursos de incorporação](/slides/pt/nodejs-java/embedded-font/).

### Posso controlar o comportamento de fallback quando uma fonte personalizada não possui determinados glifos?

Sim. Configure a [substituição de fontes](/slides/pt/nodejs-java/font-substitution/), as [regras de substituição](/slides/pt/nodejs-java/font-replacement/) e os [conjuntos de fallback](/slides/pt/nodejs-java/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

### Posso usar fontes em contêineres Linux/Docker sem instalá‑las em todo o sistema?

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência dos diretórios de fontes do sistema na imagem do contêiner.

### E quanto à licença — posso incorporar qualquer fonte personalizada sem restrições?

Você é responsável pela conformidade de licenciamento das fontes. Os termos variam; algumas licenças proíbem a incorporação ou uso comercial. Sempre revise a EULA da fonte antes de distribuir os resultados.