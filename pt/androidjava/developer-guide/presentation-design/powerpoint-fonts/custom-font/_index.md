---
title: Personalizar fontes do PowerPoint no Android
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para Android via Java para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica através de fontes em nível de documento, ou carregar fontes externas diretamente a partir de dados binários.

Fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

O registro de fontes personalizadas para renderização é separado da incorporação de fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

{{% alert color="primary" %}} 

Aspose Slides permite que você carregue essas fontes usando o método [loadExternalFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) e TrueType Collection (.ttc). Veja [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Veja [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída de exportação — como PDF, imagens e outros formatos suportados — de modo que os documentos resultantes tenham aparência consistente entre ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contêm os arquivos de fonte.  
2. Chame o método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para carregar fontes dessas pastas.  
3. Carregue e renderize/exporte a apresentação.  
4. Chame [FontsLoader.clearCache](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontsLoader#clearCache--) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```java
// Defina pastas que contêm arquivos de fontes personalizados.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Carregue fontes personalizadas das pastas especificadas.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Limpe o cache de fontes após o término do trabalho.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.  
As fontes são inicializadas nesta ordem:

1. O caminho padrão de fontes do sistema operacional.  
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter pastas de fontes personalizadas**

Aspose.Slides fornece o método [getFontFolders](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) para permitir que você encontre pastas de fontes. Este método retorna pastas adicionadas através do método `LoadExternalFonts` e pastas de fontes do sistema.

Este código Java mostra como usar [getFontFolders](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Esta linha exibe pastas onde os arquivos de fonte são pesquisados.
// Essas são pastas adicionadas através do método LoadExternalFonts e pastas de fontes do sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Especificar fontes personalizadas usadas em uma apresentação**

Aspose.Slides fornece a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código Java mostra como usar a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabalhe com a apresentação
    // CustomFont1, CustomFont2 e fontes das pastas assets\fonts & global\fonts e suas subpastas estão disponíveis para a apresentação
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar fontes externamente**

Aspose.Slides fornece o método [loadExternalFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitir que você carregue fontes externas a partir de dados binários.

Este código Java demonstra o processo de carregamento de fontes a partir de um array de bytes:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // fonte externa carregada durante a vida útil da apresentação
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?**

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

**As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?**

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la em um PPTX. Se precisar que a fonte esteja dentro do arquivo da apresentação, você deve usar os [recursos de incorporação](/slides/pt/androidjava/embedded-font/).

**Posso controlar o comportamento de fallback quando uma fonte personalizada não possui certos glifos?**

Sim. Configure [substituição de fontes](/slides/pt/androidjava/font-substitution/), [regras de substituição](/slides/pt/androidjava/font-replacement/) e [conjuntos de fallback](/slides/pt/androidjava/fallback-font/) para definir exatamente quais fontes são usadas quando o glifo solicitado está ausente.

**Posso usar fontes em contêineres Linux/Docker sem instalá‑las globalmente no sistema?**

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência dos diretórios de fontes do sistema na imagem do contêiner.

**E quanto à licença – posso incorporar qualquer fonte personalizada sem restrições?**

Você é responsável por cumprir as licenças das fontes. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre reveja o EULA da fonte antes de distribuir os resultados.