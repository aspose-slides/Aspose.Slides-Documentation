---
title: Personalizar fontes do PowerPoint em Java
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/java/custom-font/
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
- Java
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para Java para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

O Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica através de fontes em nível de documento, ou carregar fontes externas diretamente a partir de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é separado de incorporar fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

Um tema de apresentação pode referenciar diferentes famílias de fontes para sistemas de escrita individuais. Esses mapeamentos armazenam nomes de fontes, mas não instalam ou carregam os arquivos de fonte. Veja [Script-Specific Theme Fonts](/slides/pt/java/script-specific-font-mappings/) para gerenciar os mapeamentos e use as opções de carregamento abaixo para tornar as fontes referenciadas disponíveis para renderização consistente.

{{% alert color="info" title="Note" %}}
O Aspose Slides permite que você carregue essas fontes usando o método [loadExternalFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fontes TrueType (.ttf) e TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fontes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Carregar fontes personalizadas**

O Aspose.Slides permite que você carregue fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída da exportação — como PDF, imagens e outros formatos suportados — de modo que os documentos resultantes tenham aparência consistente em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.
2. Chame o método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.clearCache](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#clearCache--) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```java
import com.aspose.slides.*;

// Defina pastas que contêm arquivos de fontes personalizadas.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Carregue fontes personalizadas a partir das pastas especificadas.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Limpe o cache de fontes após o trabalho ser concluído.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.
As fontes são inicializadas nesta ordem:

1. O caminho de fonte padrão do sistema operacional.
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Obter pastas de fontes personalizadas**
O Aspose.Slides oferece o método [getFontFolders](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#getFontFolders--) para permitir que você encontre pastas de fontes. Este método retorna pastas adicionadas através do método `LoadExternalFonts` e pastas de fontes do sistema.

Este código Java mostra como usar [getFontFolders](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Esta linha exibe pastas onde os arquivos de fontes são pesquisados.
// Estas são pastas adicionadas através do método LoadExternalFonts e pastas de fontes do sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Especificar fontes personalizadas usadas com uma apresentação**
O Aspose.Slides fornece a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código Java mostra como usar a propriedade [setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabalhe com a apresentação
    // CustomFont1, CustomFont2 e fontes das pastas assets\fonts & global\fonts e de suas subpastas estão disponíveis para a apresentação
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar fontes externamente**

O Aspose.Slides oferece o método [loadExternalFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitir que você carregue fontes externas a partir de dados binários.

Este código Java demonstra o processo de carregamento de fonte a partir de um array de bytes:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Perguntas frequentes**

### As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

### As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la em um PPTX. Se precisar que a fonte fique dentro do arquivo da apresentação, você deve usar os [recursos de incorporação](/slides/pt/java/embedded-font/).

### Posso controlar o comportamento de fallback quando uma fonte personalizada não possui certos glifos?

Sim. Configure [font substitution](/slides/pt/java/font-substitution/), [replacement rules](/slides/pt/java/font-replacement/) e [fallback sets](/slides/pt/java/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

### Posso usar fontes em contêineres Linux/Docker sem instalá‑las no sistema?

Parcialmente. O Aspose.Slides pode usar fontes de suas próprias pastas ou de arrays de bytes sem instalá‑las, mas o suporte a fontes do Java ainda precisa de pelo menos uma fonte instalada na imagem. Sem ela, o carregamento falha com o erro "Fontconfig head is null, check your fonts or fonts configuration". Veja [Deploy Fonts](/slides/pt/java/deploy-fonts/).

### E quanto à licenças — posso incorporar qualquer fonte personalizada sem restrições?

Você é responsável pela conformidade com a licença das fontes. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre revise a EULA da fonte antes de distribuir os resultados.