---
title: Adicionar assinaturas digitais a apresentações em .NET
linktitle: Assinatura digital
type: docs
weight: 10
url: /pt/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda como assinar apresentações PPTX existentes com certificados PFX e usar Aspose.Slides para .NET para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado autoassinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. Ela é separada da assinatura digital e é descrita em [Apresentações protegidas por senha](/slides/pt/net/password-protected-presentation/).

O PowerPoint fornece o comando **Adicionar assinatura digital** em **File > Info > Protect Presentation**.

![Menu Proteger Apresentação do PowerPoint com Adicionar assinatura digital destacado](add-digital-signature-in-powerpoint.png)

Depois que uma apresentação assinada é aberta, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/digitalsignatures/), uma [IDigitalSignatureCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/) cujos itens implementam [IDigitalSignature](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Compreender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e geralmente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote de certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não faça commit de arquivos PFX ou suas senhas no controle de código fonte. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha a partir de um cofre de segredos ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar inserir a senha no código.

## **Adicionar assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho real de apresentação, carregue um arquivo PPTX existente, crie um [DigitalSignature](https://reference.aspose.com/slides/pt/net/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Salvar o resultado com um novo nome preserva o arquivo fonte não assinado. O valor [DigitalSignature.Comments](https://reference.aspose.com/slides/pt/net/aspose.slides/digitalsignature/comments/) descreve o propósito da assinatura; não é um controle de segurança.

## **Validar assinaturas digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item em [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/digitalsignatures/). A propriedade [IDigitalSignature.IsValid](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignature/isvalid/) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Um resultado inválido geralmente significa que o conteúdo da apresentação assinada ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está danificado. Remover todas as assinaturas produz uma apresentação não assinada, portanto verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades dos assinantes esperados estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação também pode precisar construir e validar a cadeia de certificados X.509, verificar as datas de validade e o status de revogação do certificado, confirmar o assunto ou impressão digital esperados, verificar o uso da chave e avaliar um carimbo de tempo confiável. O valor [IDigitalSignature.SignTime](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignature/signtime/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/clear/), e salva uma cópia não assinada.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Para remover apenas uma assinatura, chame [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/removeat/) com seu índice baseado em zero. Salve em um novo arquivo a menos que sobrescrever o original assinado seja uma parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna uma apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições pretendidas antes de assinar. Se uma apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como uma assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode criar assinaturas que aparentam ser do titular do certificado.
- Mantenha o fonte não assinado ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre a origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/slides/pt/net/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restrito.

**A senha do PFX é a mesma que a senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado autoassinado?**

Tecnicamente, um certificado autoassinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não o confiarão automaticamente, porém, a menos que esse certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou entre organizações normalmente utilizam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. A corrupção do arquivo também pode causar falha na validação. Se todas as assinaturas forem removidas, a apresentação fica não assinada, em vez de um arquivo contendo uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no assinante?**

Não, por si só. A integridade da assinatura e a confiança no assinante são decisões separadas. Uma política de validação em produção também deve verificar a cadeia de certificados, o período de validade, o status de revogação, a identidade esperada, o uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável válido comprova que a assinatura ocorreu enquanto o certificado estava válido. Não confie apenas no horário de assinatura exibido como um carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar o conteúdo assinado geralmente torna a assinatura existente inválida, portanto finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/digitalsignatures/) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os assinantes necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos de apresentação PPT e OpenDocument não são suportados por este fluxo de trabalho da API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.