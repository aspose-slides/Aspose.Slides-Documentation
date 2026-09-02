---
title: Proteger Apresentações com Senha em C++
linktitle: Proteção por Senha
type: docs
weight: 20
url: /pt/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "Criptografe, detecte, valide, abra e descriptografe apresentações PowerPoint PPT e PPTX protegidas por senha em C++ com Aspose.Slides."
---
## **Visão geral**

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção fornece confidencialidade.

Uma senha de abertura é diferente de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Proteger apresentações contra gravação](/slides/pt/cpp/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos utilizam ambos os formatos quando seu comportamento baseado em arquivos ou em streams é importante.

## **Criptografar uma apresentação com uma senha de abertura**

Use [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/encrypt/) para atribuir uma senha de abertura. Em seguida, use [IPresentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/save/) para persistir a apresentação criptografada.

O exemplo a seguir criptografa uma apresentação PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Carregar uma apresentação criptografada**

Defina [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/) como a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Trabalhe com a apresentação descriptografada.
```

## **Remover criptografia de uma apresentação**

Carregue a apresentação com sua senha de abertura, chame [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/removeencryption/) e salve o resultado. A apresentação salva pode então ser carregada sem senha.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Validar uma senha de abertura antes de carregar**

Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para obter [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/) sem criar uma instância completa da apresentação. Verifique [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Fluxo de trabalho com caminho de arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/) e então carrega a apresentação completa:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Fluxo de trabalho com stream**

A sobrecarga de stream de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornece o mesmo fluxo de trabalho. Redefina a posição de um stream pesquisável antes de carregar a apresentação completa a partir desse stream.

O exemplo a seguir usa um arquivo PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Valores de retorno de CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkpassword/) retorna `true` apenas quando a apresentação tem uma senha de abertura e a senha fornecida está correta. Retorna `false` em cada um destes casos:

- A senha está incorreta.
- A apresentação não tem uma senha de abertura.
- A senha fornecida é nula ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma apresentação carregada está criptografada**

Depois de carregar uma apresentação com a senha correta, inspecione [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) para confirmar que a apresentação original estava criptografada. Para detectar proteção por senha de abertura antes de carregar, use `IPresentationInfo::get_IsPasswordProtected` conforme mostrado acima.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Recomendações de segurança**

{{% alert color="warning" title="Segurança" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas repetidas desnecessárias de validação, mantenha as senhas na memória somente enquanto forem necessárias e reutilize um resultado de validação bem‑sucedido ao carregar a apresentação imediatamente.
{{% /alert %}}

## **Proteger uma apresentação com senha online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
2. Selecione ou carregue a apresentação.
3. Digite uma senha para proteção de visualização.
4. Opcionalmente, insira uma senha separada para proteção de edição.
5. Aplique a proteção e baixe o arquivo resultante.

{{% alert color="info" title="Veja também" %}}
- [Proteger apresentações contra gravação](/slides/pt/cpp/write-protected-presentation/)
- [Assinatura digital no PowerPoint](/slides/pt/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Os fluxos de trabalho de verificação de senha suportam PPT e PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo e em stream comportam‑se da mesma forma para apresentações PPT e PPTX.