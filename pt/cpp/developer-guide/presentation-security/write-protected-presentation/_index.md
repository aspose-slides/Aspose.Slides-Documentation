---
title: Proteger Apresentações contra Gravação em C++
linktitle: Proteção contra Gravação
type: docs
weight: 25
url: /pt/cpp/write-protected-presentation/
keywords:
- proteção contra gravação
- PowerPoint com proteção contra gravação
- senha para modificar
- restringir edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para C++."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo do aplicativo, eles também podem editar o conteúdo e salvá-lo com um nome diferente, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, veja [Password-Protect Presentations](/slides/pt/cpp/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos utilizam arquivos PPTX; ao salvar como PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação mantém a configuração de proteção.

O exemplo a seguir define a proteção contra gravação em uma apresentação PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregá‑la. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Não passe uma senha de proteção contra gravação para [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/). Essa propriedade aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possui ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) para remover a restrição de modificação e, em seguida, salvar a apresentação.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), chame [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e examine [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). A propriedade usa [NullableBool](https://reference.aspose.com/slides/pt/cpp/aspose.slides/nullablebool/) e retorna `NullableBool::True` quando a proteção contra gravação é detectada.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

A sobrecarga de stream de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornece a mesma informação para uma apresentação fornecida como stream.

## **Validar uma senha de proteção contra gravação**

Use [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) primeiro para que a aplicação solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkpassword/) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) fornece a verificação equivalente de proteção contra gravação por meio de seu gerenciador de proteção.

Em aplicações de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias e mantenha as senhas na memória apenas pelo tempo necessário.

{{% alert color="info" title="Veja também" %}}
- [Apresentações protegidas por senha](/slides/pt/cpp/password-protected-presentation/)
- [Apresentações somente leitura](/slides/pt/cpp/read-only-presentation/)
- [Assinatura digital no PowerPoint](/slides/pt/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo criptografado da apresentação.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando for necessária autorização para modificação.