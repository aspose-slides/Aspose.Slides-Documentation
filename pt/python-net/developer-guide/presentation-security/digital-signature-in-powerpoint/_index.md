---
title: Adicionar assinaturas digitais a apresentações com Python
linktitle: Assinatura digital
type: docs
weight: 10
url: /pt/python-net/digital-signature-in-powerpoint/
keywords:
- assinatura digital
- certificado digital
- autoridade certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como assinar digitalmente arquivos PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Proteja seus slides em segundos com exemplos de código claros."
---
## **Introdução**

**Certificado digital** é usado para criar uma apresentação PowerPoint protegida por senha, marcada como criada por uma organização ou pessoa específica. O certificado digital pode ser obtido entrando em contato com uma organização autorizada – uma autoridade certificadora. Depois de instalar o certificado digital no sistema, ele pode ser usado para adicionar uma assinatura digital à apresentação via Arquivo -> Informações -> Proteger Apresentação:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A apresentação pode conter mais de uma assinatura digital. Depois que a assinatura digital é adicionada à apresentação, uma mensagem especial aparecerá no PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para assinar a apresentação ou verificar a autenticidade das assinaturas da apresentação, **Aspose.Slides API** fornece a classe [**DigitalSignature**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignature/), a classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/DigitalSignatureCollection/) e a propriedade [**Presentation.digital_signatures**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/digital_signatures/). Atualmente, assinaturas digitais são suportadas apenas para o formato PPTX.

## **Adicionar assinatura digital a partir de certificado PFX**

O exemplo de código abaixo demonstra como adicionar uma assinatura digital a partir de um certificado PFX:

1. Abra o arquivo PFX e passe a senha do PFX para o objeto **DigitalSignature**.
2. Adicione a assinatura criada ao objeto da apresentação.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Crie o objeto DigitalSignature com o arquivo PFX e a senha PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comentário da nova assinatura digital
    signature.comments = "Aspose.Slides digital signing test."

    # Adicione a assinatura digital à apresentação
    pres.digital_signatures.add(signature)

    # Salve a apresentação
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Agora é possível verificar se a apresentação foi assinada digitalmente e não foi modificada:

```py
# Abrir apresentação
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Verificar se todas as assinaturas digitais são válidas
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Perguntas frequentes**

**Posso remover assinaturas existentes de um arquivo?**

Sim. A coleção de assinaturas digitais permite [remover itens individuais](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignaturecollection/remove_at/) e [limpar totalmente a coleção](https://reference.aspose.com/slides/pt/python-net/aspose.slides/digitalsignaturecollection/clear/); após salvar o arquivo, a apresentação não terá assinaturas.

**O arquivo se torna “somente leitura” após a assinatura?**

Não. Uma assinatura preserva a integridade e a autoria, mas não impede edições. Para restringir a edição, combine-a com ["Somente leitura" ou uma senha](/slides/pt/python-net/password-protected-presentation/).

**A assinatura será exibida corretamente em diferentes versões do PowerPoint?**

A assinatura é criada para o contêiner OOXML (PPTX). Versões modernas do PowerPoint que suportam assinaturas OOXML exibem corretamente o status dessas assinaturas.