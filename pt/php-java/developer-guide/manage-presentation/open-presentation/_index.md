---
title: Abrir apresentações em PHP
linktitle: Abrir apresentação
type: docs
weight: 20
url: /pt/php-java/open-presentation/
keywords:
- abrir PowerPoint
- abrir OpenDocument
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
description: "Abrir apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) de forma fácil com Aspose.Slides para PHP via Java — rápido, confiável, totalmente funcional."
---
## **Introdução**

Além de criar apresentações do PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Após carregar uma apresentação, você pode recuperar informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Abrir apresentações**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo PHP a seguir mostra como abrir uma apresentação e obter sua contagem de slides:

```php
// Instancie a classe Presentation e passe um caminho de arquivo ao seu construtor.
$presentation = new Presentation("Sample.pptx");
try {
    // Imprima o número total de slides na apresentação.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Abrir apresentações protegidas por senha**

Quando precisar abrir uma apresentação protegida por senha, passe a senha através do método [setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword) da classe [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/) para descriptografá‑la e carregá‑la. O código PHP a seguir demonstra essa operação:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Execute operações na apresentação descriptografada.
} finally {
    $presentation->dispose();
}
```

## **Abrir apresentações grandes**

O Aspose.Slides fornece opções — particularmente o método [getBlobManagementOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) na classe [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/) — para ajudar a carregar apresentações grandes.

O código PHP a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Escolha o comportamento KeepLocked — o arquivo de apresentação permanecerá bloqueado durante a vida útil de
// a instância Presentation, mas não precisa ser carregado na memória ou copiado para um arquivo temporário.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // A apresentação grande foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.

    // Faça alterações na apresentação.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Não faça isso! Uma exceção de I/O será lançada porque o arquivo está bloqueado até que o objeto Presentation seja descartado.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// É seguro fazer isso aqui. O arquivo de origem não está mais bloqueado pelo objeto Presentation.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode desacelerar o carregamento. Portanto, quando precisar carregar uma apresentação grande, recomendamos enfaticamente o uso do caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contém objetos grandes (vídeo, áudio, imagens de alta resolução etc.), você pode usar o [BLOB management](/slides/pt/php-java/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Controlar recursos externos**

O Aspose.Slides fornece a interface [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iresourceloadingcallback/) que permite gerenciar recursos externos. O código PHP a seguir mostra como usar a interface `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Carregue uma imagem substituta.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Defina uma URL substituta.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Ignorar todas as outras imagens.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Carregar apresentações sem objetos binários incorporados**

Uma apresentação do PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [Presentation.getVbaProject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getVbaProject));
- Dados incorporados de objeto OLE (acessível via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Dados binários de controle ActiveX (acessível via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pt/php-java/aspose.slides/control/#getActiveXControlBinary)).

Usando o método [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), você pode carregar uma apresentação sem quaisquer objetos binários incorporados.

Esse método é útil para remover conteúdo binário potencialmente malicioso. O código PHP a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Execute operações na apresentação.
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Como posso saber se um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de análise/validação de formato durante o carregamento. Esses erros frequentemente mencionam uma estrutura ZIP inválida ou registros do PowerPoint corrompidos.

**O que acontece se as fontes necessárias estiverem ausentes ao abrir?**

O arquivo será aberto, mas posteriormente a [renderização/exportação](/slides/pt/php-java/convert-presentation/) pode substituir as fontes. [Configure substituições de fontes](/slides/pt/php-java/font-substitution/) ou [adicione as fontes necessárias](/slides/pt/php-java/custom-font/) ao ambiente de tempo de execução.

**E quanto a mídia incorporada (vídeo/áudio) ao abrir?**

Eles se tornam disponíveis como recursos da apresentação. Se a mídia for referenciada por caminhos externos, assegure que esses caminhos estejam acessíveis em seu ambiente; caso contrário, a [renderização/exportação](/slides/pt/php-java/convert-presentation/) pode omitir a mídia.