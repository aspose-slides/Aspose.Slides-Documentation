---
title: Adicionar assinaturas digitais a apresentações em JavaScript
linktitle: Assinatura digital
type: docs
weight: 10
url: /pt/nodejs-java/digital-signature-in-powerpoint/
keywords:
- assinatura digital
- certificado digital
- autoridade certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como assinar digitalmente arquivos PowerPoint e OpenDocument com Aspose.Slides para Node.js via Java. Proteja seus slides em segundos com exemplos de código claros."
---
## **Introdução**

**Certificado digital** é usado para criar uma apresentação do PowerPoint protegida por senha, marcada como criada por uma organização ou pessoa específica. O certificado digital pode ser obtido entrando em contato com uma organização autorizada – uma autoridade certificadora. Depois de instalar o certificado digital no sistema, ele pode ser usado para adicionar uma assinatura digital à apresentação via Arquivo -> Informações -> Proteger Apresentação:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A apresentação pode conter mais de uma assinatura digital. Depois que a assinatura digital é adicionada à apresentação, uma mensagem especial aparecerá no PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para assinar a apresentação ou verificar a autenticidade das assinaturas da apresentação, a **Aspose.Slides API** fornece a classe [**DigitalSignature**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/DigitalSignature), a classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/DigitalSignatureCollection) e o método [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Atualmente, assinaturas digitais são suportadas apenas para o formato PPTX.

## **Adicionar Assinatura Digital a partir de Certificado PFX**
O exemplo de código abaixo demonstra como adicionar uma assinatura digital a partir de um certificado PFX:

1. Abra o arquivo PFX e passe a senha do PFX para o objeto [**DigitalSignature**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/DigitalSignature).
2. Adicione a assinatura criada ao objeto da apresentação.

```javascript
// Abrindo o arquivo de apresentação
var pres = new aspose.slides.Presentation();
try {
    // Criar objeto DigitalSignature com arquivo PFX e senha PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Comentar nova assinatura digital
    signature.setComments("Aspose.Slides digital signing test.");
    // Adicionar assinatura digital à apresentação
    pres.getDigitalSignatures().add(signature);
    // Salvar apresentação
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Agora é possível verificar se a apresentação foi assinada digitalmente e não foi modificada:

```javascript
// Abrir apresentação
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Verificar se todas as assinaturas digitais são válidas
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Posso remover assinaturas existentes de um arquivo?**

Sim. A coleção de assinaturas digitais suporta [remover itens individuais](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) e [limpar completamente](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); após salvar o arquivo, a apresentação não terá assinaturas.

**O arquivo se torna "somente leitura" após a assinatura?**

Não. Uma assinatura preserva a integridade e a autoria, mas não bloqueia edições. Para restringir a edição, combine-a com ["Somente leitura" ou uma senha](/slides/pt/nodejs-java/password-protected-presentation/).

**A assinatura será exibida corretamente em diferentes versões do PowerPoint?**

A assinatura é criada para o contêiner OOXML (PPTX). Versões modernas do PowerPoint que suportam assinaturas OOXML exibem o status dessas assinaturas corretamente.