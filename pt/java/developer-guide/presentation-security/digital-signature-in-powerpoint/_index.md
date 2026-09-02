---
title: "Adicionar assinaturas digitais a apresentações em Java"
linktitle: "Assinatura digital"
type: docs
weight: 10
url: /pt/java/digital-signature-in-powerpoint/
keywords:
- "assinatura digital"
- "certificado digital"
- "autoridade certificadora"
- "certificado PFX"
- "PKCS#12"
- "validar assinatura"
- "PowerPoint"
- "PPTX"
- "segurança de apresentação"
- "Java"
- "Aspose.Slides"
description: "Saiba como assinar apresentações PPTX existentes com certificados PFX e usar o Aspose.Slides para Java para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. É separada da assinatura digital e é descrita em [Apresentações protegidas por senha](/java/password-protected-presentation/).

O PowerPoint fornece o comando **Add a Digital Signature** em **File > Info > Protect Presentation**.

![Menu Proteger Apresentação do PowerPoint com Adicionar uma Assinatura Digital destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas por meio de [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), que retorna uma [IDigitalSignatureCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignaturecollection/) cujos itens implementam [IDigitalSignature](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entender Certificados PFX e Senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e geralmente com a extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote do certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não faça commit de arquivos PFX ou de suas senhas no controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um cofre de segredos ou de outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar embutir a senha no código.

## **Adicionar uma Assinatura Digital a uma Apresentação**

Para assinar um fluxo de trabalho real, carregue um arquivo PPTX existente, crie um [DigitalSignature](https://reference.aspose.com/slides/pt/java/com.aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Salvar o resultado com um novo nome preserva o arquivo fonte não assinado. O valor definido por [IDigitalSignature.setComments](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) descreve o propósito da assinatura; não é um controle de segurança.

## **Validar Assinaturas Digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item retornado por [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). O método [IDigitalSignature.isValid](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignature/#isValid--) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Um resultado inválido normalmente significa que o conteúdo da apresentação assinado ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está corrompido. Remover todas as assinaturas produz uma apresentação não assinada, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades esperadas dos signatários estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, seu aplicativo pode também precisar construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação, confirmar o assunto ou impressão digital esperada, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor retornado por [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignature/#getSignTime--) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover Assinaturas Digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignaturecollection/#clear--), e salva uma cópia não assinada.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para remover apenas uma assinatura, chame [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) com o índice baseado em zero. Salve em um novo arquivo a menos que sobrescrever o original assinado faça parte explícita do seu fluxo de trabalho.

## **Considerações de Edição e Formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicativos ainda podem editar o arquivo, mas alterações ao conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições planejadas antes de assinar. Se a apresentação precisar ser alterada, salve a versão revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura PPTX original como assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode criar assinaturas que aparentam ser do titular desse certificado.
- Mantenha o fonte não assinado ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre a origem e a integridade, mas o conteúdo da apresentação permanece legível, a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/java/password-protected-presentation/) quando for necessário restringir o acesso ao conteúdo.

**A senha do PFX é a mesma que a senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não o confiarão automaticamente, a menos que o certificado tenha sido adicionado explicitamente ao ambiente confiável deles. Fluxos de trabalho públicos ou entre organizações geralmente usam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode causar falha na validação. Se todas as assinaturas forem removidas, a apresentação está não assinada, e não contém uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no assinante?**

Não por si só. Integridade da assinatura e confiança no assinante são decisões separadas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que ocorre quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável prova que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário de assinatura exibido como carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar o conteúdo assinado geralmente torna a assinatura existente inválida, portanto, finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura à coleção retornada por [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui somente para PPTX. Os formatos PPT e OpenDocument não são suportados por esse fluxo de trabalho da API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não carrega mais a evidência da assinatura removida.