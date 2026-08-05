---
title: Adicionar assinaturas digitais a apresentações em PHP
linktitle: Assinatura digital
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
- segurança da apresentação
- PHP
- Aspose.Slides
description: "Aprenda como assinar apresentações PPTX existentes com certificados PFX e usar Aspose.Slides para PHP via Java para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. É separada da assinatura digital e é descrita em [Password-Protected Presentations](/php-java/password-protected-presentation/).

O PowerPoint fornece o comando **Adicionar assinatura digital** em **Arquivo > Informações > Proteger Apresentação**.

![Menu Proteger Apresentação do PowerPoint com Adicionar assinatura digital destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint informando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas por meio de [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDigitalSignatures), que retorna uma [DigitalSignatureCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/) cujos itens são representados por objetos [DigitalSignature](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e comumente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote de certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não envie arquivos PFX ou suas senhas para o controle de código-fonte. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um cofre de segredos ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho de apresentação real, carregue um arquivo PPTX existente, crie um [DigitalSignature](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

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

Salvar o resultado com um novo nome preserva o arquivo de origem sem assinatura. O valor definido por [DigitalSignature::setComments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/setcomments/) descreve o propósito da assinatura; não é um controle de segurança.

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

Um resultado inválido normalmente significa que o conteúdo da apresentação assinada ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação sem assinatura, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades esperadas dos signatários estão presentes.

Esse resultado de validade não deve ser considerado uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação pode também precisar construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação do certificado, confirmar o assunto ou impressão digital esperada, validar o uso da chave e avaliar um timestamp confiável. O valor de [DigitalSignature::getSignTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignature/getsigntime/) por si só não é prova de uma autoridade de timestamp confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/clear/), e salva uma cópia sem assinatura.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para remover apenas uma assinatura, chame [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/digitalsignaturecollection/removeat/) com seu índice base zero. Salve em um novo arquivo, a menos que sobrescrever o original assinado seja uma parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicativos ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições pretendidas antes de assinar. Se a apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha o resultado final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura PPTX original como uma assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode ser capaz de criar assinaturas que parecem vir desse titular de certificado.
- Mantenha a fonte sem assinatura ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre a origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/php-java/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restrito.

**A senha do PFX é a mesma que a senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote de certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não o confiarão automaticamente, a menos que o certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou entre organizações geralmente utilizam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção do arquivo também pode fazer a validação falhar. Se todas as assinaturas forem removidas, a apresentação fica sem assinatura, não contendo uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no signatário?**

Não por si só. Integridade da assinatura e confiança no signatário são decisões separadas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de timestamp confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se a assinatura permanece aceitável depende da sua política e de se um timestamp confiável prova que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário de assinatura exibido como um timestamp confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar o conteúdo assinado geralmente invalida a assinatura existente, portanto finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura à coleção retornada por [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDigitalSignatures) antes de salvar. Durante a validação, inspeccione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos PPT e OpenDocument não são suportados por esse fluxo de API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.