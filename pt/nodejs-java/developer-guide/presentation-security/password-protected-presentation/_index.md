---
title: Apresentações protegidas por senha em JavaScript
linktitle: Proteção de senha
type: docs
weight: 20
url: /pt/nodejs-java/password-protected-presentation/
keywords:
- apresentação protegida por senha
- senha de abertura
- criptografar PowerPoint
- descriptografar PowerPoint
- validar senha da apresentação
- verificar senha da apresentação
- abrir apresentação criptografada
- remover criptografia
- PowerPoint
- PPT
- PPTX
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criptografe, detecte, valide, abra e descriptografe apresentações PowerPoint PPT e PPTX protegidas por senha em JavaScript com Aspose.Slides."
---
## **Visão geral**

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção fornece confidencialidade.

Uma senha de abertura é diferente de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Write-Protect Presentations](/slides/pt/nodejs-java/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos usam ambos os formatos onde seu comportamento baseado em arquivo e em fluxo é importante.

## **Criptografar uma Apresentação com uma Senha de Abertura**

Use [ProtectionManager.encrypt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#encrypt) para atribuir uma senha de abertura. Em seguida, use [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) para salvar a apresentação criptografada.

O exemplo a seguir criptografa uma apresentação PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Manter as Propriedades do Documento Públicas**

Por padrão, o Aspose.Slides inclui propriedades do documento na criptografia da apresentação. O método [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controla esse comportamento de forma independente da criptografia do conteúdo dos slides. Passe `false` antes de chamar [ProtectionManager.encrypt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#encrypt) quando um sistema de indexação, classificação, pesquisa ou gerenciamento de documentos precisar ler metadados sem a senha de abertura.

O exemplo a seguir cria uma apresentação PPTX criptografada, mantendo suas propriedades de documento internas públicas:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Passar `false` para [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) não torna os slides, mestres, layouts, formas, mídia ou outro conteúdo da apresentação públicos. Ele afeta somente as propriedades do documento. Para ler essas propriedades sem carregar o conteúdo criptografado, veja [Manage Presentation Properties](/slides/pt/nodejs-java/presentation-properties/).

## **Carregar uma Apresentação Criptografada**

Defina [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) como a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Trabalhe com a apresentação descriptografada.
} finally {
    presentation.dispose();
}
```

## **Remover a Criptografia de uma Apresentação**

Carregue a apresentação com sua senha de abertura, chame [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) e salve o resultado. A apresentação salva pode então ser carregada sem senha.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validar uma Senha de Abertura Antes de Carregar**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) para obter [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/) sem criar uma instância completa da apresentação. Verifique [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Fluxo de Trabalho por Caminho de Arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) e então carrega a apresentação completa:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Fluxo de Trabalho por Stream**

Use [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) para inspecionar um stream legível do Node.js. Depois que o stream de inspeção for consumido, crie um novo stream antes de carregar a apresentação completa com [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

O exemplo a seguir usa um arquivo PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Valores de Retorno de checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkPassword) retorna `true` somente quando a apresentação tem uma senha de abertura e a senha fornecida está correta. Ele retorna `false` em cada um desses casos:

- A senha está incorreta.
- A apresentação não tem senha de abertura.
- A senha fornecida é `null` ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma Apresentação Carregada Está Criptografada**

Após carregar uma apresentação com a senha correta, inspecione [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que a apresentação original estava criptografada. Para detectar proteção por senha de abertura antes de carregar, use [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) como mostrado acima.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Recomendações de Segurança**

{{% alert color="warning" title="Segurança" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias, mantenha as senhas na memória apenas enquanto necessário, e reutilize um resultado de validação bem‑sucedido ao carregar a apresentação imediatamente.

Propriedades públicas do documento podem revelar nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados, mesmo que o conteúdo da apresentação esteja criptografado. Criptografe metadados sensíveis junto com a apresentação. Deixar as propriedades públicas deve ser uma decisão explícita feita somente quando os sistemas precisam indexar, classificar, pesquisar ou gerenciar o arquivo sem uma senha de abertura.
{{% /alert %}}

## **Proteger uma Apresentação com Senha Online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou faça upload da apresentação.
1. Insira uma senha para proteção de visualização.
1. Opcionalmente insira uma senha separada para proteção de edição.
1. Aplique a proteção e baixe o arquivo resultante.

{{% alert color="info" title="Veja também" %}}
- [Write-Protect Presentations](/slides/pt/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas Frequentes**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha as informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Um aplicativo pode ler metadados sem a senha de abertura?**

Sim, mas somente quando a apresentação foi criptografada com a criptografia de propriedades do documento desativada. O aplicativo deve então usar o modo de carregamento apenas de propriedades de documento descrito em [Manage Presentation Properties](/slides/pt/nodejs-java/presentation-properties/).

**Os fluxos de trabalho de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo e em stream comportam‑se da mesma forma para apresentações PPT e PPTX.