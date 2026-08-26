---
title: Proteção contra gravação de apresentações em JavaScript
linktitle: Proteção de Gravação
type: docs
weight: 25
url: /pt/nodejs-java/write-protected-presentation/
keywords:
- proteção contra gravação
- PowerPoint com proteção contra gravação
- senha para modificar
- restrição da edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para Node.js via Java."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo da aplicação, eles também podem editar o conteúdo e salvá-lo com um nome diferente, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, veja [Password-Protect Presentations](/slides/pt/nodejs-java/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos usam arquivos PPTX; ao salvar em PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação persiste a configuração de proteção.

O exemplo a seguir define proteção contra gravação em uma apresentação PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregar a apresentação. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Não passe uma senha de proteção contra gravação para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword). Esse método aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) para remover a restrição de modificação e, em seguida, salvar a apresentação.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/), chame [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) e verifique [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). O método usa [NullableBool](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/nullablebool/) e retorna `NullableBool.True` quando a proteção contra gravação é detectada.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

O método baseado em stream [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) fornece a mesma informação para uma apresentação fornecida como um stream legível do Node.js.

## **Validar uma senha de proteção contra gravação**

Use [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) primeiro para que a aplicação solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#checkPassword) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) fornece a verificação equivalente de proteção contra gravação por meio de seu gerenciador de proteção.

Em aplicativos de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias e mantenha as senhas na memória somente pelo tempo necessário.

{{% alert color="info" title="Veja também" %}}
- [Password-Protect Presentations](/slides/pt/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/pt/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo criptografado da apresentação.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando a autorização de modificação for necessária.