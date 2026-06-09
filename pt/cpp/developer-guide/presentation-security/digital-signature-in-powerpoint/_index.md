---
title: "Adicionar assinaturas digitais a apresentações em C++"
linktitle: "Assinatura digital"
type: docs
weight: 10
url: /pt/cpp/digital-signature-in-powerpoint/
keywords:
- "assinatura digital"
- "certificado digital"
- "autoridade certificadora"
- "certificado PFX"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- "C++"
- "Aspose.Slides"
description: "Aprenda a assinar digitalmente arquivos PowerPoint e OpenDocument com Aspose.Slides para C++. Proteja seus slides em segundos com exemplos de código claros."
---
## **Introdução**

**Certificado digital** é usado para criar uma apresentação do PowerPoint protegida por senha, marcada como criada por uma organização ou pessoa específica. O certificado digital pode ser obtido entrando em contato com uma organização autorizada – uma autoridade certificadora. Após instalar o certificado digital no sistema, ele pode ser usado para adicionar uma assinatura digital à apresentação via Arquivo -> Informações -> Proteger Apresentação:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A apresentação pode conter mais de uma assinatura digital. Após a assinatura digital ser adicionada à apresentação, uma mensagem especial aparecerá no PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para assinar a apresentação ou verificar a autenticidade das assinaturas da apresentação, a **Aspose.Slides API** fornece a interface [**IDigitalSignature**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_digital_signature), a interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_digital_signature_collection) e o método [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Atualmente, assinaturas digitais são suportadas apenas no formato PPTX.

## **Adicionar uma Assinatura Digital a partir de um Certificado PFX**
O exemplo de código abaixo demonstra como adicionar uma assinatura digital a partir de um certificado PFX:

1. Abra o arquivo PFX e passe a senha do PFX para o objeto [**DigitalSignature**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.digital_signature).
2. Adicione a assinatura criada ao objeto da apresentação.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Criar objeto DigitalSignature com arquivo PFX e senha PFX
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Comentar nova assinatura digital
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Adicionar assinatura digital à apresentação
pres->get_DigitalSignatures()->Add(signature);

// Salvar apresentação
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Agora é possível verificar se a apresentação foi assinada digitalmente e não foi modificada:

``` cpp
// Abrir apresentação
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Verificar se todas as assinaturas digitais são válidas
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **Perguntas frequentes**

**Posso remover assinaturas existentes de um arquivo?**

Sim. A coleção de assinaturas digitais suporta [remover itens individuais](https://reference.aspose.com/slides/pt/cpp/aspose.slides/digitalsignaturecollection/removeat/) e [limpar completamente](https://reference.aspose.com/slides/pt/cpp/aspose.slides/digitalsignaturecollection/clear/); depois de salvar o arquivo, a apresentação não terá assinaturas.

**O arquivo torna‑se “somente‑leitura” após a assinatura?**

Não. Uma assinatura preserva a integridade e a autoria, mas não impede edições. Para restringir a edição, combine-a com ["Read-only" ou uma senha](/slides/pt/cpp/password-protected-presentation/).

**A assinatura será exibida corretamente em diferentes versões do PowerPoint?**

A assinatura é criada para o contêiner OOXML (PPTX). Versões modernas do PowerPoint que suportam assinaturas OOXML exibem o status dessas assinaturas corretamente.