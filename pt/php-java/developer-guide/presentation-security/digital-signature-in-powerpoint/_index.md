---
title: Adicionar assinaturas digitais a apresentações em PHP
linktitle: Assinatura Digital
type: docs
weight: 10
url: /pt/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e usar o Aspose.Slides para PHP via Java para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. É separada da assinatura digital e está descrita em [Apresentações protegidas por senha](/slides/pt/php-java/password-protected-presentation/).

O PowerPoint fornece o comando **Add a Digital Signature** em **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDigitalSignatures), que retorna uma [DigitalSignatureCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/) cujos itens são representados por objetos [DigitalSignature](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entender Certificados PFX e Senhas**

Um arquivo PFX, também conhecido como um arquivo PKCS#12 e geralmente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote do certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não envie arquivos PFX ou suas senhas para o controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha a partir de um armazenamento de segredos ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho de apresentação real, carregue um arquivo PPTX existente, crie uma [DigitalSignature](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Salvar o resultado com um novo nome preserva o arquivo fonte não assinado. O valor definido por [DigitalSignature::setComments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/setcomments/) descreve o propósito da assinatura; não é um controle de segurança.

## **Validar assinaturas digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item retornado por [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDigitalSignatures). O método [DigitalSignature::isValid](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/isvalid/) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Um resultado inválido geralmente significa que o conteúdo assinado da apresentação ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação não assinada, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve confirmar que o número esperado de assinaturas e as identidades esperadas dos assinantes estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação pode precisar também construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação do certificado, confirmar o assunto ou impressão digital esperada, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor retornado por [DigitalSignature::getSignTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/getsigntime/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/clear/), e salva uma cópia não assinada.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para remover apenas uma assinatura, chame [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/removeat/) passando seu índice baseado em zero. Salve em um novo arquivo a menos que sobrescrever o original assinado seja parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Complete todas as edições desejadas antes de assinar. Se a apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Quem obtiver a chave privada e sua senha pode criar assinaturas que aparentam ser do titular do certificado.
- Retenha a fonte não assinada ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre a origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/slides/pt/php-java/password-protected-presentation/) quando o acesso ao conteúdo deve ser restrito.

**A senha PFX é a mesma que a senha da apresentação?**

Não. A senha PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não o confiarão automaticamente, a menos que o certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou interorganizacionais geralmente utilizam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo assinado da apresentação ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção do arquivo também pode fazer a validação falhar. Se todas as assinaturas forem removidas, a apresentação ficará não assinada, não contendo uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no assinante?**

Não por si só. A integridade da assinatura e a confiança no assinante são decisões distintas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanecer aceitável depende da sua política e se um carimbo de tempo confiável provar que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário de assinatura exibido como carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar conteúdo assinado geralmente invalida a assinatura existente, portanto finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura à coleção retornada por [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDigitalSignatures) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos PPT e OpenDocument não são suportados por esse fluxo de API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e depois salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.