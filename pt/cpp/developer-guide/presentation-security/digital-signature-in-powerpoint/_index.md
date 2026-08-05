---
title: Adicionar assinaturas digitais a apresentações em C++
linktitle: Assinatura Digital
type: docs
weight: 10
url: /pt/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e usar Aspose.Slides para C++ para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. Ela é separada da assinatura digital e é descrita em [Apresentações protegidas por senha](/cpp/password-protected-presentation/).

O PowerPoint fornece o comando **Adicionar uma Assinatura Digital** em **Arquivo > Informações > Proteger Apresentação**.

![Menu Proteger Apresentação do PowerPoint com Adicionar Assinatura Digital destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

O Aspose.Slides expõe assinaturas por meio de [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_digitalsignatures/), que retorna um [IDigitalSignatureCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignaturecollection/) cujos itens implementam [IDigitalSignature](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Entender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e comumente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote de certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não envie arquivos PFX ou suas senhas para o controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um cofre de segredos ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar a incorporação da senha no código.

## **Adicionar uma Assinatura Digital a uma Apresentação**

Para assinar um fluxo de trabalho de apresentação real, carregue um arquivo PPTX existente, crie um [DigitalSignature](https://reference.aspose.com/slides/pt/cpp/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Salvar o resultado com um novo nome preserva o arquivo de origem não assinado. O valor de [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignature/set_comments/) descreve a finalidade da assinatura; não é um controle de segurança.

## **Validar Assinaturas Digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item retornado por [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_digitalsignatures/). O método [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignature/get_isvalid/) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Um resultado inválido normalmente significa que o conteúdo da apresentação assinada ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação não assinada, portanto verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades esperadas dos signatários estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação também pode precisar construir e validar a cadeia de certificados X.509, verificar as datas de validade do certificado e o status de revogação, confirmar o sujeito ou impressão digital esperada, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor de [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignature/get_signtime/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover Assinaturas Digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignaturecollection/clear/), e salva uma cópia não assinada.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para remover apenas uma assinatura, chame [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idigitalsignaturecollection/removeat/) com seu índice baseado em zero. Salve em um novo arquivo, a menos que sobrescrever o original assinado seja uma parte explícita do seu fluxo de trabalho.

## **Considerações de Edição e Formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições previstas antes de assinar. Se a apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original PPTX como uma assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode ser capaz de criar assinaturas que pareçam provenir do titular do certificado.
- Mantenha a fonte não assinada ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **Perguntas frequentes**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre a origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/cpp/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restrito.

**A senha do PFX é a mesma que a senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote de certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. No entanto, os destinatários não o confiarão automaticamente, a menos que esse certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou interorganizacionais geralmente usam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode fazer a validação falhar. Se todas as assinaturas forem removidas, a apresentação fica não assinada, ao invés de ser um arquivo contendo uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no assinante?**

Não por si só. A integridade da assinatura e a confiança no assinante são decisões separadas. Uma política de validação em produção também deve verificar a cadeia de certificados, o período de validade, o status de revogação, a identidade esperada, o uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável válido comprova que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário de assinatura exibido como um carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. A assinatura não bloqueia o arquivo. Editar conteúdo assinado geralmente torna a assinatura existente inválida, portanto finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura à coleção retornada por [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_digitalsignatures/) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

O Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos de apresentação PPT e OpenDocument não são suportados por este fluxo de trabalho da API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.