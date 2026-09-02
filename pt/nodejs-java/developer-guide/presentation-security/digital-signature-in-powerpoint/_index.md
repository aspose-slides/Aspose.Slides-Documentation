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
- PKCS#12
- validar assinatura
- PowerPoint
- PPTX
- segurança de apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e usar o Aspose.Slides para Node.js via Java para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. Ela é separada da assinatura digital e está descrita em [Apresentações protegidas por senha](/nodejs-java/password-protected-presentation/).

O PowerPoint fornece o comando **Adicionar assinatura digital** em **Arquivo > Informações > Proteger apresentação**.

![Menu Proteger apresentação do PowerPoint com Adicionar assinatura digital destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [Obter assinaturas digitais da apresentação] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), que retorna uma [Coleção de assinaturas digitais] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignaturecollection/) contendo objetos [Assinatura digital] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e comumente com a extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote de certificados e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não envie arquivos PFX ou suas senhas para o controle de origem. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um repositório secreto ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho real, carregue um arquivo PPTX existente, crie uma [Assinatura digital] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Salvar o resultado com um novo nome preserva o arquivo de origem não assinado. O valor definido por [AssinaturaDigital.setComments] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignature/) descreve o propósito da assinatura; ele não é um controle de segurança.

## **Validar assinaturas digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item retornado por [Obter assinaturas digitais da apresentação] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). O método [AssinaturaDigital.isValid] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignature/) indica se a assinatura embutida é válida para o conteúdo atual da apresentação.

O exemplo a seguir também usa a classe Node.js `X509Certificate` para ler o nome do assunto de cada certificado embutido.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Um resultado inválido geralmente significa que o conteúdo ou os dados da assinatura da apresentação assinada foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação não assinada, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve confirmar que o número esperado de assinaturas e as identidades esperadas dos assinantes estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação pode também precisar construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação, confirmar o assunto ou impressão digital esperados, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor de [AssinaturaDigital.getSignTime] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignature/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [ColeçãoDeAssinaturasDigitais.clear] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), e salva uma cópia não assinada.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para remover apenas uma assinatura, chame [ColeçãoDeAssinaturasDigitais.removeAt] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) com seu índice baseado em zero. Salve em um novo arquivo, a menos que sobrescrever o original assinado seja parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições pretendidas antes de assinar. Se a apresentação precisar ser alterada, salve a versão revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode criar assinaturas que aparentam ser do titular do certificado.
- Preserve a origem não assinada ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre origem e integridade, mas o conteúdo da apresentação permanece legível a menos que criptografia separada seja aplicada. Use [proteção por senha](/nodejs-java/password-protected-presentation/) quando for necessário restringir o acesso ao conteúdo.

**A senha do PFX é a mesma senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote de certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não confiarão nele automaticamente, porém, a menos que o certificado tenha sido explicitamente adicionado ao seu ambiente confiável. Fluxos de trabalho públicos ou entre organizações geralmente utilizam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode causar falha na validação. Se todas as assinaturas forem removidas, a apresentação fica não assinada, e não contém uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no assinante?**

Não por si só. Integridade da assinatura e confiança no assinante são decisões separadas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se a assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável prova que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário da assinatura exibido como carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar conteúdo assinado geralmente torna a assinatura existente inválida, portanto, finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura à coleção retornada por [Obter assinaturas digitais da apresentação] (https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os assinantes necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos PPT e OpenDocument não são suportados por esse fluxo de API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não carrega mais a evidência da assinatura removida.