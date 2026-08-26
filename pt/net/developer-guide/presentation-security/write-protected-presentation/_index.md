---
title: Proteção contra gravação de apresentações em .NET
linktitle: Proteção contra gravação
type: docs
weight: 25
url: /pt/net/write-protected-presentation/
keywords:
- proteção contra gravação
- proteção contra gravação PowerPoint
- senha para modificar
- restrição de edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para .NET."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo do aplicativo, eles também podem editar o conteúdo e salvá‑lo com outro nome, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, veja [Password‑Protect Presentations](/slides/pt/net/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos usam arquivos PPTX; ao salvar em PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/setwriteprotection/) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação persiste a configuração de proteção.

O exemplo a seguir define proteção contra gravação em uma apresentação PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregar a apresentação. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Não passe uma senha de proteção contra gravação para [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/). Essa propriedade aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/removewriteprotection/) para remover a restrição de modificação e, em seguida, salve a apresentação.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), chame [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationfactory/getpresentationinfo/) e verifique [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/iswriteprotected/). A propriedade usa [NullableBool](https://reference.aspose.com/slides/pt/net/aspose.slides/nullablebool/) e retorna `NullableBool.True` quando a proteção contra gravação é detectada.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

A sobrecarga de fluxo de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fornece as mesmas informações para uma apresentação fornecida como stream.

## **Validar uma senha de proteção contra gravação**

Use [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/checkwriteprotection/) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/iswriteprotected/) primeiro, de modo que a aplicação solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/checkwriteprotection/) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/checkpassword/) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/checkwriteprotection/) fornece a verificação equivalente de proteção contra gravação por meio do seu gerenciador de proteção.

Em aplicações de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias e mantenha as senhas em memória apenas pelo tempo necessário.

{{% alert color="info" title="Ver também" %}}
- [Password‑Protect Presentations](/slides/pt/net/password-protected-presentation/)
- [Read‑Only Presentations](/slides/pt/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas frequentes**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo criptografado da apresentação.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura nas opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando a autorização de modificação for necessária.