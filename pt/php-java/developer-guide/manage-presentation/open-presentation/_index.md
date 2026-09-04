---
title: Abrir apresentações em PHP
linktitle: Abrir apresentação
type: docs
weight: 20
url: /pt/php-java/open-presentation/
keywords:
- abrir PowerPoint
- abrir apresentação
- abrir PPTX
- abrir PPT
- abrir ODP
- carregar apresentação
- carregar PPTX
- carregar PPT
- carregar ODP
- apresentação protegida
- apresentação grande
- recurso externo
- objeto binário
- PHP
- Aspose.Slides
description: "Aprenda como abrir apresentações PowerPoint e OpenDocument em PHP, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para PHP via Java."
---
## **Introdução**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/pt/php-java/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e streams. Após uma apresentação ser carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/). Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória heap do Java, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir apresentações**

Para abrir uma apresentação existente, passe o caminho do arquivo ao construtor [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Libere a apresentação após o uso para que manipuladores de arquivos, dados temporários e outros recursos sejam liberados prontamente.

O exemplo PHP a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Abrir apresentações protegidas por senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, passe a senha correta para [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword) e forneça as opções ao construtor [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). O carregamento falha quando a senha está ausente ou incorreta.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Para detecção de senha, validação e fluxos de trabalho de criptografia, consulte [Password-Protect Presentations](/slides/pt/php-java/password-protected-presentation/). Se uma apresentação criptografada foi salva deliberadamente com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Manage Presentation Properties](/slides/pt/php-java/presentation-properties/).

## **Abrir apresentações grandes**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) devolve opções que controlam como o Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo fonte bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB retidos na memória.

O código PHP a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Com [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), o arquivo fonte permanece bloqueado até que a instância da apresentação seja liberada. Não mova, sobrescreva ou exclua o arquivo fonte enquanto essa instância estiver viva.

Aspose.Slides pode copiar o conteúdo de um stream de entrada durante o carregamento. Para apresentações grandes, um caminho de arquivo costuma ser mais eficiente que um stream. Consulte [Manage BLOBs](/slides/pt/php-java/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.

{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) aceita uma implementação da interface Java [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iresourceloadingcallback/) através do PHP/Java Bridge. O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando apresentações contêm imagens externas que precisam ser resolvidas de acordo com regras específicas de segurança ou armazenamento da aplicação.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Carregar apresentações sem objetos binários incorporados**

Uma apresentação pode conter dados binários incorporados que a aplicação não precisa ou não deseja reter. Exemplos incluem:

- projetos VBA, disponíveis através de [Presentation::getVbaProject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getVbaProject);
- dados OLE incorporados, disponíveis através de [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dados de controle ActiveX, disponíveis através de [Control::getActiveXControlBinary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/control/#getActiveXControlBinary).

Defina [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) como `true` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para persistir o resultado sanitizado.

Esta opção reduz a exposição a payloads incorporados indesejados, mas não é um sistema completo de detecção de malware ou de sanitização de conteúdo.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta para que a aplicação possa relatar a causa com precisão.

**O que acontece se fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e a exportação podem substituir fontes. Você pode [configurar substituição de fontes](/slides/pt/php-java/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/php-java/custom-font/) para tornar a saída mais previsível.

**O carregamento de uma apresentação também carrega sua mídia incorporada?**

Áudio e vídeo incorporados ficam disponíveis através do modelo de objeto da apresentação. Recursos externos são resolvidos de acordo com o comportamento de carregamento configurado e podem estar indisponíveis se suas localizações não puderem ser acessadas.