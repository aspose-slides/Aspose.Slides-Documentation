---
title: Proteja Apresentações com Senha em JavaScript
linktitle: Proteção por Senha
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

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção oferece confidencialidade.

Uma senha de abertura é diferente de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Proteção contra gravação de apresentações](/slides/pt/nodejs-java/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos usam ambos os formatos onde o comportamento baseado em arquivos e em streams é importante.

## **Criptografar uma apresentação com uma senha de abertura**

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

## **Carregar uma apresentação criptografada**

Defina [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) com a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

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

## **Remover a criptografia de uma apresentação**

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

## **Validar uma senha de abertura antes de carregar**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) para obter [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/) sem criar uma instância completa da apresentação. Verifique [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Fluxo de trabalho por caminho de arquivo**

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

### **Fluxo de trabalho com stream**

Use [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) para inspecionar um stream legível do Node.js. Após o stream de inspeção ser consumido, crie um novo stream antes de carregar a apresentação completa com [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

### **Valores de retorno de checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkPassword) retorna `true` somente quando a apresentação possui uma senha de abertura e a senha fornecida está correta. Retorna `false` em cada um destes casos:

- A senha está incorreta.
- A apresentação não possui uma senha de abertura.
- A senha fornecida é `null` ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma apresentação carregada está criptografada**

Depois de carregar uma apresentação com a senha correta, inspecione [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que a apresentação original estava criptografada. Para detectar a proteção por senha de abertura antes de carregar, use [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) conforme mostrado acima.

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

## **Recomendações de segurança**

{{% alert color="warning" title="Security" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas repetidas desnecessárias de validação, mantenha as senhas na memória apenas enquanto necessário e reutilize um resultado de validação bem‑sucedido ao carregar a apresentação imediatamente.
{{% /alert %}}

## **Proteja uma apresentação com senha online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou faça upload da apresentação.
1. Digite uma senha para proteção de visualização.
1. Opcionalmente, digite uma senha separada para proteção de edição.
1. Aplique a proteção e faça download do arquivo resultante.

{{% alert color="info" title="See also" %}}
- [Proteção contra gravação de apresentações](/slides/pt/nodejs-java/write-protected-presentation/)
- [Assinatura digital no PowerPoint](/slides/pt/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas frequentes**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha as informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Os fluxos de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo e em stream comportam‑se da mesma forma para apresentações PPT e PPTX.