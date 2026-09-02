---
title: Adicionar assinaturas digitais a apresentações em Python
linktitle: Assinatura Digital
type: docs
weight: 10
url: /pt/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Aprenda a assinar apresentações PPTX existentes com certificados PFX e usar o Aspose.Slides para Python via .NET para validar ou remover assinaturas digitais."
---
## **Visão geral**

Uma assinatura digital ajuda o destinatário a determinar quem assinou uma apresentação e se o conteúdo assinado foi alterado. Três conceitos de segurança relacionados são importantes aqui:

- Um **certificado digital** é uma credencial eletrônica que associa uma identidade a uma chave pública. Uma autoridade certificadora (CA) confiável pode emitir um certificado, ou uma organização pode usar um certificado auto‑assinado para fluxos de trabalho internos.
- Uma **assinatura digital** é criada a partir do conteúdo da apresentação e da chave privada do titular do certificado. A chave pública do certificado pode então ser usada para verificar a assinatura. Uma assinatura fornece evidência de origem e integridade; ela não criptografa a apresentação.
- **Proteção por senha** controla se um usuário pode abrir ou modificar uma apresentação. É separado da assinatura digital e é descrito em [Apresentações protegidas por senha](/python-net/password-protected-presentation/).

O PowerPoint fornece o comando **Adicionar assinatura digital** sob **Arquivo > Informações > Proteger Apresentação**.

![Menu Proteger Apresentação do PowerPoint com Adicionar assinatura digital destacado](add-digital-signature-in-powerpoint.png)

Após abrir uma apresentação assinada, o PowerPoint pode exibir uma notificação de status da assinatura.

![Notificação do PowerPoint indicando que a apresentação contém assinaturas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expõe assinaturas através de [Presentation.digital_signatures](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/digital_signatures/), uma [DigitalSignatureCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignaturecollection/) cujos itens são objetos [DigitalSignature](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/). Uma apresentação pode conter várias assinaturas.

## **Compreender certificados PFX e senhas**

Um arquivo PFX, também conhecido como arquivo PKCS#12 e geralmente com extensão `.pfx` ou `.p12`, pode conter um certificado X.509, sua chave privada e a cadeia de certificados. A chave privada é o que permite ao titular criar uma assinatura. Um certificado sem uma chave privada acessível não pode ser usado para assinar uma apresentação.

A senha do PFX protege o pacote do certificado e a chave privada. Ela **não** é uma senha para abrir ou editar a apresentação. Não faça commit de arquivos PFX ou de suas senhas no controle de versão. Em produção, limite o acesso ao arquivo de certificado e obtenha sua senha de um armazenamento secreto ou de outra fonte de configuração protegida. Os exemplos abaixo usam uma variável de ambiente apenas para evitar incorporar a senha no código.

## **Adicionar uma assinatura digital a uma apresentação**

Para assinar um fluxo de trabalho real, carregue um arquivo PPTX existente, crie uma [DigitalSignature](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/) a partir de um certificado PFX e sua senha, adicione a assinatura à coleção da apresentação e salve em um arquivo PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Salvar o resultado com um novo nome preserva o arquivo de origem não assinado. O valor de [DigitalSignature.comments](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/comments/) descreve o propósito da assinatura; ele não é um controle de segurança.

## **Validar assinaturas digitais**

Ao carregar um arquivo PPTX assinado, inspecione cada item em [Presentation.digital_signatures](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/digital_signatures/). A propriedade [DigitalSignature.is_valid](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/is_valid/) indica se a assinatura incorporada é válida para o conteúdo atual da apresentação.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Um resultado inválido geralmente significa que o conteúdo da apresentação assinado ou os dados da assinatura foram alterados após a assinatura, ou que o arquivo está corrompido. Remover todas as assinaturas produz uma apresentação não assinada, portanto, verificar apenas a validade dos itens não é suficiente: um fluxo sensível à segurança também deve verificar se o número esperado de assinaturas e as identidades dos signatários esperados estão presentes.

A propriedade [DigitalSignature.certificate](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/certificate/) fornece os dados do certificado como um array de bytes. O exemplo calcula sua impressão digital SHA‑256 para que um aplicativo possa compará‑la com a impressão digital de um certificado de signatário esperado.

Esse resultado de validade não deve ser tratado como uma decisão completa de confiança no certificado. Dependendo da sua política de segurança, seu aplicativo pode também precisar construir e validar a cadeia de certificados X.509, verificar datas de validade e status de revogação, confirmar o sujeito ou impressão digital esperada, validar o uso da chave e avaliar um carimbo de tempo confiável. O valor de [DigitalSignature.sign_time](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/sign_time/) por si só não é prova de uma autoridade de carimbo de tempo confiável.

## **Remover assinaturas digitais**

Remover assinaturas altera o estado de segurança da apresentação. O exemplo a seguir carrega um PPTX assinado, remove todas as assinaturas com [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignaturecollection/clear/), e salva uma cópia não assinada.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Para remover apenas uma assinatura, chame [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignaturecollection/remove_at/) com seu índice baseado em zero. Salve em um novo arquivo, a menos que sobrescrever o original assinado seja parte explícita do seu fluxo de trabalho.

## **Considerações de edição e formato**

- Uma assinatura não torna a apresentação somente leitura. Usuários e aplicativos ainda podem editar o arquivo, mas alterações no conteúdo assinado normalmente invalidam a assinatura existente.
- Conclua todas as edições pretendidas antes de assinar. Se a apresentação precisar ser alterada, salve a versão revisada e assine essa revisão novamente.
- Mantenha a saída final no formato PPTX. Converter uma apresentação assinada para outro formato não transfere a assinatura original do PPTX como assinatura válida para o arquivo convertido.
- Trate a chave privada do certificado como informação sensível. Qualquer pessoa que obtenha a chave privada e sua senha pode criar assinaturas que pareçam vir daquele titular de certificado.
- Preserve a fonte não assinada ou outra cópia controlada quando sua política de retenção de documentos exigir.

## **Perguntas frequentes**

**A assinatura digital criptografa a apresentação?**

Não. Uma assinatura digital fornece evidência sobre origem e integridade, mas o conteúdo da apresentação permanece legível a menos que uma criptografia separada seja aplicada. Use [proteção por senha](/python-net/password-protected-presentation/) quando o acesso ao conteúdo precisar ser restrito.

**A senha do PFX é a mesma que a senha da apresentação?**

Não. A senha do PFX desbloqueia a chave privada armazenada no pacote do certificado. Ela não controla quem pode abrir ou editar o arquivo PPTX.

**Posso usar um certificado auto‑assinado?**

Tecnicamente, um certificado auto‑assinado pode ser usado quando inclui uma chave privada acessível. Os destinatários não confiarão nele automaticamente, a menos que o certificado tenha sido explicitamente adicionado ao ambiente confiável deles. Fluxos de trabalho públicos ou interorganizacionais geralmente utilizam um certificado emitido por uma CA confiável.

**O que torna uma assinatura inválida?**

Alterar o conteúdo da apresentação assinada ou os dados da assinatura após a assinatura pode invalidar a assinatura. Corrupção de arquivo também pode causar falha na validação. Se todas as assinaturas forem removidas, a apresentação fica não assinada, e não contém uma assinatura inválida.

**Uma assinatura válida significa que devo confiar no signatário?**

Não por si só. Integridade da assinatura e confiança no signatário são decisões separadas. Uma política de validação em produção deve também verificar a cadeia de certificados, período de validade, status de revogação, identidade esperada, uso da chave e quaisquer requisitos de carimbo de tempo confiável.

**O que acontece quando o certificado expira?**

A expiração do certificado não altera os bytes da apresentação, mas afeta a avaliação de confiança do certificado. Se uma assinatura permanece aceitável depende da sua política e de se um carimbo de tempo confiável comprova que a assinatura ocorreu enquanto o certificado era válido. Não confie apenas no horário exibido como carimbo de tempo confiável.

**Uma apresentação assinada ainda pode ser editada?**

Sim. Assinar não bloqueia o arquivo. Editar o conteúdo assinado geralmente torna a assinatura existente inválida, portanto finalize a apresentação primeiro e assine a revisão final.

**Uma apresentação pode conter mais de uma assinatura?**

Sim. Adicione cada assinatura a [Presentation.digital_signatures](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/digital_signatures/) antes de salvar. Durante a validação, inspecione cada assinatura e confirme que todos os signatários necessários estão presentes.

**Quais formatos de apresentação suportam essas operações?**

Aspose.Slides oferece as operações de assinatura digital descritas aqui apenas para PPTX. Os formatos PPT e OpenDocument não são suportados por esse fluxo de API.

**Posso remover uma assinatura sem afetar os slides?**

Sim. Você pode remover uma assinatura ou limpar toda a coleção e então salvar a apresentação. O conteúdo dos slides permanece disponível, mas o arquivo salvo não contém mais a evidência da assinatura removida.