---
title: Abrir apresentações em JavaScript
linktitle: Abrir apresentação
type: docs
weight: 20
url: /pt/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como abrir apresentações PowerPoint e OpenDocument em JavaScript, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para Node.js via Java."
---
## **Introdução**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/pt/nodejs-java/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e streams. Após uma apresentação ser carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/). Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória do Node.js, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir Apresentações**

Para abrir uma apresentação existente, passe o caminho do arquivo para o [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) constructor. Libere a apresentação após o uso para que manipuladores de arquivos, dados temporários e outros recursos sejam liberados prontamente.

O exemplo JavaScript a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Protegidas por Senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, passe a senha correta para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) e forneça as opções ao [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) constructor. O carregamento falha quando a senha está ausente ou incorreta.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Para detecção de senha, validação e fluxos de trabalho de criptografia, veja [Apresentações Protegidas por Senha](/slides/pt/nodejs-java/password-protected-presentation/). Se uma apresentação criptografada foi salva deliberadamente com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Gerenciar Propriedades da Apresentação](/slides/pt/nodejs-java/presentation-properties/).

## **Abrir Apresentações Grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) retorna opções que controlam como o Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo de origem bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB mantidos na memória.

O código JavaScript a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Com [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), o arquivo de origem permanece bloqueado até que a instância da apresentação seja descartada. Não mova, sobrescreva ou exclua o arquivo de origem enquanto essa instância estiver ativa.

O Aspose.Slides pode copiar o conteúdo de um stream de entrada ao carregá‑lo. Para apresentações grandes, um caminho de arquivo geralmente é mais eficiente do que um stream. Veja [Manage BLOBs](/slides/pt/nodejs-java/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.

{{% /alert %}}

## **Controlar Recursos Externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) aceita uma implementação de [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iresourceloadingcallback/). O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando as apresentações contêm imagens externas que precisam ser resolvidas de acordo com regras de segurança ou armazenamento específicas da aplicação.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação pode conter dados binários incorporados que uma aplicação não precisa ou não deseja manter. Exemplos incluem:

- Projetos VBA, disponíveis através de [Presentation.getVbaProject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getVbaProject);
- Dados OLE incorporados, disponíveis através de [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Dados de controle ActiveX, disponíveis através de [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Defina [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) como `true` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para persistir o resultado sanitizado.

Esta opção reduz a exposição a payloads incorporados indesejados, mas não é um sistema completo de detecção de malware ou sanitização de conteúdo.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

O Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta para que a aplicação possa relatar a causa com precisão.

**O que acontece se fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e a exportação podem substituir fontes. Você pode [configurar substituição de fontes](/slides/pt/nodejs-java/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/nodejs-java/custom-font/) para tornar a saída mais previsível.

**O carregamento de uma apresentação também carrega sua mídia incorporada?**

Áudios e vídeos incorporados tornam‑se disponíveis através do modelo de objeto da apresentação. Recursos externos são resolvidos de acordo com o comportamento de carregamento de recursos configurado e podem estar indisponíveis se seus locais não puderem ser acessados.