---
title: Adicionar Assinaturas Digitais a Apresentações em Java
linktitle: Assinatura Digital
type: docs
weight: 10
url: /pt/java/digital-signature-in-powerpoint/
keywords:
- assinatura digital
- certificado digital
- autoridade certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como assinar digitalmente arquivos PowerPoint e OpenDocument com Aspose.Slides para Java. Proteja seus slides em segundos com exemplos de código claros."
---
## **Introdução**

**Certificado digital** é usado para criar uma apresentação do PowerPoint protegida por senha, marcada como criada por uma organização ou pessoa específica. O certificado digital pode ser obtido entrando em contato com uma organização autorizada – uma autoridade certificadora. Após instalar o certificado digital no sistema, ele pode ser usado para adicionar uma assinatura digital à apresentação via Arquivo->Informações->Proteger Apresentação:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Uma apresentação pode conter mais de uma assinatura digital. Após a assinatura digital ser adicionada à apresentação, uma mensagem especial aparecerá no PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para assinar a apresentação ou verificar a autenticidade das assinaturas da apresentação, a **Aspose.Slides API** fornece a interface [**IDigitalSignature**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDigitalSignature), a interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDigitalSignatureCollection) e o método [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Atualmente, assinaturas digitais são suportadas apenas no formato PPTX.

## **Adicionar uma Assinatura Digital a partir de um Certificado PFX**

O exemplo de código abaixo demonstra como adicionar uma assinatura digital a partir de um certificado PFX:

1. Abra o arquivo PFX e passe a senha do PFX para o objeto [**DigitalSignature**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/DigitalSignature).
2. Adicione a assinatura criada ao objeto de apresentação.

```java
// Abrindo o arquivo de apresentação
Presentation pres = new Presentation();
try {
    // Cria objeto DigitalSignature com arquivo PFX e senha PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Comentário da nova assinatura digital
    signature.setComments("Aspose.Slides digital signing test.");

    // Adiciona assinatura digital à apresentação
    pres.getDigitalSignatures().add(signature);

    // Salva a apresentação
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Agora é possível verificar se a apresentação foi assinada digitalmente e não foi modificada:

```java
// Abrir apresentação
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Verificar se todas as assinaturas digitais são válidas
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso remover assinaturas existentes de um arquivo?**

Sim. A coleção de assinaturas digitais suporta [remover itens individuais](https://reference.aspose.com/slides/pt/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) e [limpar totalmente](https://reference.aspose.com/slides/pt/java/com.aspose.slides/digitalsignaturecollection/#clear--) ; depois de salvar o arquivo, a apresentação não terá assinaturas.

**O arquivo se torna "somente leitura" após a assinatura?**

Não. Uma assinatura preserva a integridade e a autoria, mas não bloqueia edições. Para restringir a edição, combine-a com ["Somente leitura" ou uma senha](/slides/pt/java/password-protected-presentation/).

**A assinatura será exibida corretamente em diferentes versões do PowerPoint?**

A assinatura é criada para o contêiner OOXML (PPTX). As versões modernas do PowerPoint que suportam assinaturas OOXML exibem o status dessas assinaturas corretamente.