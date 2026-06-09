---
title: Abrir Apresentações em JavaScript
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Abrir apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) de forma simples com Aspose.Slides para Node.js via Java — rápido, confiável e totalmente funcional."
---
## **Introdução**

Além de criar apresentações do PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Depois de carregar uma apresentação, você pode obter informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Abrir Apresentações**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo JavaScript a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```js
// Instancie a classe Presentation e passe um caminho de arquivo ao seu construtor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Imprima o número total de slides na apresentação.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Protegidas por Senha**

Quando precisar abrir uma apresentação protegida por senha, passe a senha através do método [setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) da classe [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/) para descriptografar e carregá‑la. O código JavaScript a seguir demonstra esta operação:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Execute operações na apresentação descriptografada.
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Grandes**

O Aspose.Slides oferece opções — particularmente o método [getBlobManagementOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) da classe [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/) — para ajudar a carregar apresentações grandes.

O código JavaScript a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Escolha o comportamento KeepLocked — o arquivo da apresentação permanecerá bloqueado durante a vida útil de
// a instância Presentation, mas não precisa ser carregado na memória ou copiado para um arquivo temporário.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // A grande apresentação foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.
    
    // Faça alterações na apresentação.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Não faça isso! Uma exceção de I/O será lançada porque o arquivo está bloqueado até que o objeto presentation seja descartado.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Está tudo bem fazer isso aqui. O arquivo fonte não está mais bloqueado pelo objeto presentation.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode tornar o carregamento mais lento. Portanto, quando precisar carregar uma apresentação grande, recomendamos fortemente usar o caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contém objetos grandes (vídeo, áudio, imagens de alta resolução etc.), você pode usar [Gerenciamento de BLOB](/slides/pt/nodejs-java/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Controlar Recursos Externos**

O Aspose.Slides fornece a interface [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iresourceloadingcallback/) que permite gerenciar recursos externos. O código JavaScript a seguir mostra como usar a interface `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Carregue uma imagem substituta.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Defina uma URL substituta.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Ignorar todas as outras imagens.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Carregar Apresentações Sem Objetos Binários Incorporados**

Uma apresentação do PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [Presentation.getVbaProject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getVbaProject));
- Dados incorporados de objeto OLE (acessível via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Dados binários de controle ActiveX (acessível via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Usando o método [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), você pode carregar uma apresentação sem quaisquer objetos binários incorporados.

Esse método é útil para remover conteúdo binário potencialmente malicioso. O código JavaScript a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Execute operações na apresentação.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de validação de parsing/formato durante o carregamento. Esses erros geralmente mencionam uma estrutura ZIP inválida ou registros do PowerPoint corrompidos.

**O que acontece se fontes necessárias estiverem ausentes ao abrir?**

O arquivo será aberto, mas posteriormente a [renderização/exportação](/slides/pt/nodejs-java/convert-presentation/) pode substituir fontes. [Configure a substituição de fontes](/slides/pt/nodejs-java/font-substitution/) ou [adicione as fontes necessárias](/slides/pt/nodejs-java/custom-font/) ao ambiente de tempo de execução.

**E quanto a mídia incorporada (vídeo/áudio) ao abrir?**

Eles se tornam disponíveis como recursos da apresentação. Se a mídia for referenciada por caminhos externos, certifique‑se de que esses caminhos estejam acessíveis no seu ambiente; caso contrário, a [renderização/exportação](/slides/pt/nodejs-java/convert-presentation/) pode omitir a mídia.