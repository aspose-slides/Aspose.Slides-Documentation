---
title: Apresentações protegidas por senha em .NET
linktitle: Proteção por senha
type: docs
weight: 20
url: /pt/net/password-protected-presentation/
keywords:
- apresentação protegida por senha
- senha de abertura
- criptografar PowerPoint
- descriptografar PowerPoint
- validar senha da apresentação
- verificar senha da apresentação
- abrir apresentação criptografada
- remover criptografia
- PowerPoint
- PPT
- PPTX
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Criptografe, detecte, valide, abra e descriptografe apresentações PowerPoint PPT e PPTX protegidas por senha em C# com Aspose.Slides para .NET."
---
## **Visão geral**

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção fornece confidencialidade.

Uma senha de abertura é diferente de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Write-Protect Presentations](/slides/pt/net/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos utilizam ambos os formatos quando seu comportamento baseado em arquivo ou em fluxo é importante.

## **Criptografar uma apresentação com uma senha de abertura**

Use [IProtectionManager.Encrypt](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/encrypt/) para atribuir uma senha de abertura. Em seguida, use [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) para persistir a apresentação criptografada.

O exemplo a seguir criptografa uma apresentação PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Carregar uma apresentação criptografada**

Defina [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/) com a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Trabalhe com a apresentação descriptografada.
```

## **Remover criptografia de uma apresentação**

Carregue a apresentação com sua senha de abertura, chame [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/removeencryption/) e salve o resultado. A apresentação salva pode então ser carregada sem senha.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validar uma senha de abertura antes de carregar**

Use [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationfactory/getpresentationinfo/) para obter [IPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/) sem criar uma instância completa da apresentação. Verifique [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/ispasswordprotected/) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Fluxo de trabalho com caminho de arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/), e então carrega a apresentação completa:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Fluxo de trabalho com fluxo**

A sobrecarga de fluxo de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fornece o mesmo fluxo de trabalho. Redefina a posição de um fluxo pesquisável antes de carregar a apresentação completa a partir desse fluxo.

O exemplo a seguir usa um arquivo PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Valores de retorno de CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/checkpassword/) retorna `true` somente quando a apresentação tem uma senha de abertura e a senha fornecida está correta. Retorna `false` em cada um destes casos:

- A senha está incorreta.
- A apresentação não possui senha de abertura.
- A senha fornecida é `null` ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma apresentação carregada está criptografada**

Depois de carregar uma apresentação com a senha correta, inspeccione [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/isencrypted/) para confirmar que a apresentação original estava criptografada. Para detectar proteção por senha de abertura antes de carregar, use `IPresentationInfo.IsPasswordProtected` como mostrado acima.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Recomendações de segurança**

{{% alert color="warning" title="Security" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias, mantenha as senhas na memória apenas pelo tempo necessário e reutilize um resultado de validação bem-sucedido ao carregar a apresentação imediatamente.
{{% /alert %}}

## **Proteger uma apresentação com senha online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou faça upload da apresentação.
1. Digite uma senha para proteção de visualização.
1. Opcionalmente, digite uma senha separada para proteção de edição.
1. Aplique a proteção e faça download do arquivo resultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/pt/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha as informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Os fluxos de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo ou em fluxo comportam-se da mesma forma para apresentações PPT e PPTX.