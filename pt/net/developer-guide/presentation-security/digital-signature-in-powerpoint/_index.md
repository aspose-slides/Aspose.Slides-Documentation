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
- segurança da apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e use Aspose.Slides para .NET para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado auto‑assinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. É separada da assinatura digital e é descrita em [Password-Protected Presentations](/net/password-protected-presentation/).

O PowerPoint fornece o comando **Add a Digital Signature** em **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Após abrir uma apresentação assinada, o PowerPoint pode exibir uma notificação de status da assinatura.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/digitalsignatures/), uma [IDigitalSignatureCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/) cujos itens implementam [IDigitalSignature](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignature/). Uma apresentação pode conter múltiplas assinaturas.

## **Entender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e geralmente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificação. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote do certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não confirme arquivos PFX ou suas senhas no controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um armazenador de segredos ou outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho de apresentação real, carregue um arquivo PPTX existente, crie uma [DigitalSignature](https://reference.aspose.com/slides/pt/net/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

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

Salvar o resultado com um novo nome preserva o arquivo de origem não assinado. O valor de [DigitalSignature.Comments](https://reference.aspose.com/slides/pt/net/aspose.slides/digitalsignature/comments/) descreve o propósito da assinatura; não é um controle de segurança.

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

Um resultado inválido normalmente significa que o conteúdo da apresentação assinada ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está corrompido. Remover todas as assinaturas produz uma apresentação não assinada, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo de trabalho sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades dos signatários esperados estão presentes.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, sua aplicação pode também precisar construir e validar a cadeia de certificados X.509, verificar as datas de validade do certificado e seu status de revogação, confirmar o assunto ou impressão digital esperados, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor de [IDigitalSignature.SignTime](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignature/signtime/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um arquivo PPTX assinado, remove todas as assinaturas com [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/clear/), e salva uma cópia não assinada.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Para remover apenas uma assinatura, chame [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/idigitalsignaturecollection/removeat/) com seu índice baseado em zero. Salve em um novo arquivo, a menos que sobrescrever o original assinado seja parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna uma apresentação somente leitura. Usuários e aplicações ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições planejadas antes de assinar. Se a apresentação precisar ser alterada, salve a apresentação revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como uma assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode criar assinaturas que pareçam originar do titular desse certificado.
- Preserve a origem não assinada ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **FAQ**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre origem e integridade, mas o conteúdo da apresentação permanece legível, a menos que uma criptografia separada seja aplicada. Use [password protection](/net/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restrito.

**A senha do PFX é a mesma da senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado auto‑assinado?**

Tecnicamente, um certificado auto‑assinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não confiarão nele automaticamente, porém, a menos que o certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou entre organizações geralmente usam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode fazer a validação falhar. Se todas as assinaturas forem removidas, a apresentação fica não assinada, em vez de conter uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no signatário?**

Não por si só. Integridade da assinatura e confiança no signatário são decisões separadas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e se um carimbo de tempo confiável demonstra que a assinatura foi feita enquanto o certificado era válido. Não confie apenas no horário de assinatura exibido como um carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar o conteúdo assinado normalmente invalida a assinatura existente, portanto, finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/digitalsignatures/) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários requeridos estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides suporta as operações de assinatura digital descritas aqui apenas para PPTX. Formatos PPT e OpenDocument não são suportados por esse fluxo de trabalho de API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.