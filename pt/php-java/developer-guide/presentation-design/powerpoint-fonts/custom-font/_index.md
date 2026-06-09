---
title: Personalizar fontes do PowerPoint em PHP
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para PHP via Java para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica através de fontes em nível de documento ou carregar fontes externas diretamente a partir de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas pelo Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é separado da incorporação de fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

{{% alert color="primary" %}} 
Aspose Slides permite carregar essas fontes usando o método [loadExternalFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fontes TrueType (.ttf) e TrueType Collection (.ttc). Veja [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fontes OpenType (.otf). Veja [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída de exportação — como PDF, imagens e outros formatos suportados — de modo que os documentos resultantes tenham a mesma aparência em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.  
2. Chame o método estático [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para carregar fontes dessas pastas.  
3. Carregue e renderize/exporte a apresentação.  
4. Chame [FontsLoader::clearCache](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#clearCache--) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```php
// Defina pastas que contêm arquivos de fontes personalizadas.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Carregue fontes personalizadas das pastas especificadas.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Limpe o cache de fontes após o término do trabalho.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Nota" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.  
As fontes são inicializadas nesta ordem:

1. O caminho padrão de fontes do sistema operacional.  
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Obter pastas de fontes personalizadas**
Aspose.Slides fornece o método [getFontFolders](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#getFontFolders--) para permitir que você localize pastas de fontes. Este método retorna pastas adicionadas através do método `LoadExternalFonts` e pastas de fontes do sistema.

Este código PHP mostra como usar [getFontFolders](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Esta linha exibe pastas onde os arquivos de fonte são pesquisados.
# Estas são pastas adicionadas através do método LoadExternalFonts e pastas de fontes do sistema.
$fontFolders = FontsLoader::getFontFolders();
```

## **Especificar fontes personalizadas usadas em uma apresentação**
Aspose.Slides fornece o método [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código PHP mostra como usar o método [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Trabalhe com a apresentação
    # CustomFont1, CustomFont2 e fontes das pastas assets\fonts & global\fonts e suas subpastas estão disponíveis para a apresentação
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gerenciar fontes externamente**

Aspose.Slides fornece o método [loadExternalFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitir que você carregue fontes externas a partir de dados binários.

Este código PHP demonstra o processo de carregamento de fonte a partir de um array de bytes:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # fonte externa carregada durante a vida útil da apresentação
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

**As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?**

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

**As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?**

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la em um PPTX. Se precisar que a fonte esteja dentro do arquivo de apresentação, use os recursos de incorporação explícitos.

**Posso controlar o comportamento de fallback quando uma fonte personalizada não tem determinados glifos?**

Sim. Configure [font substitution](/slides/pt/php-java/font-substitution/), [replacement rules](/slides/pt/php-java/font-replacement/) e [fallback sets](/slides/pt/php-java/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

**Posso usar fontes em contêineres Linux/Docker sem instalá‑las globalmente?**

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência de diretórios de fontes do sistema na imagem do contêiner.

**E quanto à licença — posso incorporar qualquer fonte personalizada sem restrições?**

Você é responsável por cumprir as licenças das fontes. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre revise o EULA da fonte antes de distribuir os resultados.