---
title: "Adicionar assinaturas digitais a apresentações em Python"
linktitle: "Assinatura digital"
type: docs
weight: 10
url: /pt/python-java/digital-signature-in-powerpoint/
keywords:
- "assinatura digital"
- "certificado digital"
- "autoridade certificadora"
- "certificado PFX"
- "PKCS#12"
- "validar assinatura"
- "PowerPoint"
- "PPTX"
- "segurança da apresentação"
- "Python"
- "Aspose.Slides"
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e usar o Aspose.Slides para Python via Java para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. Ela é separada da assinatura digital e é descrita em [Apresentações protegidas por senha](/slides/pt/python-java/password-protected-presentation/).

O PowerPoint oferece o comando **Add a Digital Signature** em **File > Info > Protect Presentation**.

![Menu Proteger Apresentação do PowerPoint com Add a Digital Signature destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDigitalSignatures), que retorna uma [DigitalSignatureCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignaturecollection/) cujos itens são instâncias de [DigitalSignature](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entenda os certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e geralmente com a extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote do certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não confirme arquivos PFX ou suas senhas no controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um repositório secreto ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho de apresentação real, carregue um arquivo PPTX existente, crie uma [DigitalSignature](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Salvar o resultado com um novo nome preserva o arquivo fonte sem assinatura. O valor definido por [DigitalSignature.setComments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignature/#setComments) descreve o propósito da assinatura; não é um controle de segurança.

## **Validar assinaturas digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item retornado por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDigitalSignatures). O método [DigitalSignature.isValid](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignature/#isValid) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Um resultado inválido geralmente significa que o conteúdo da apresentação assinada ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação sem assinatura, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades esperadas dos signatários estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação pode também precisar construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação do certificado, confirmar o assunto ou impressão digital esperada, verificar o uso da chave e avaliar um carimbo de tempo confiável. O valor de [DigitalSignature.getSignTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignature/#getSignTime) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignaturecollection/#clear), e salva uma cópia sem assinatura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para remover apenas uma assinatura, chame [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/digitalsignaturecollection/#removeAt) com seu índice baseado em zero. Salve em um novo arquivo a menos que sobrescrever o original assinado seja uma parte explícita do seu fluxo de trabalho.

## **Considerações sobre edição e formato**

- Uma assinatura não torna uma apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições previstas antes de assinar. Se a apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha o resultado final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como uma assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode ser capaz de criar assinaturas que aparentam ser do titular desse certificado.
- Mantenha a fonte sem assinatura ou outra cópia controlada quando a sua política de retenção de documentos exigir.

## **Perguntas frequentes**

**A assinatura digital criptografa a apresentação?**  
Não. Uma assinatura digital fornece evidência sobre a origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/slides/pt/python-java/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restringido.

**A senha do PFX é a mesma que a senha da apresentação?**  
Não. A senha do PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**  
Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. No entanto, os destinatários não o confiarão automaticamente, a menos que o certificado tenha sido explicitamente adicionado ao seu ambiente confiável. Fluxos de trabalho públicos ou interorganizacionais geralmente usam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**  
Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode fazer a validação falhar. Se todas as assinaturas forem removidas, a apresentação fica sem assinatura, em vez de conter uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no signatário?**  
Não, por si só. A integridade da assinatura e a confiança no signatário são decisões separadas. Uma política de validação em produção também deve verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**  
A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável válido prova que a assinatura ocorreu enquanto o certificado estava válido. Não confie apenas no horário de assinatura exibido como um carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**  
Sim. A assinatura não bloqueia o arquivo. Editar o conteúdo assinado geralmente invalida a assinatura existente, portanto, termine a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**  
Sim. Adicione cada assinatura à coleção retornada por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDigitalSignatures) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**  
Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos PPT e OpenDocument não são suportados por este fluxo de trabalho da API.

**Posso remover uma assinatura sem afetar os slides?**  
Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.