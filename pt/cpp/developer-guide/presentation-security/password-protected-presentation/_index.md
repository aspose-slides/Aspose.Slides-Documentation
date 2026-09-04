---
title: Apresentações com Proteção por Senha em C++
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

Uma senha de abertura difere de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Proteger Apresentações contra Gravação](/slides/pt/cpp/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos usam ambos os formatos onde seu comportamento baseado em arquivo e baseado em fluxo é importante.

## **Criptografar uma Apresentação com uma Senha de Abertura**

Use [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/encrypt/) para atribuir uma senha de abertura. Em seguida, use [IPresentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/save/) para salvar a apresentação criptografada.

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

## **Manter as Propriedades do Documento Públicas**

Por padrão, o Aspose.Slides inclui as propriedades do documento na criptografia da apresentação. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) controla esse comportamento independentemente da criptografia do conteúdo dos slides. Passe `false` a esse método antes de chamar [IProtectionManager::Encrypt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/encrypt/) quando um sistema de indexação, classificação, busca ou gerenciamento de documentos precisar ler os metadados sem a senha de abertura.

O exemplo a seguir cria uma apresentação PPTX criptografada deixando suas propriedades de documento internas públicas:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Passar `false` para `set_EncryptDocumentProperties` não torna os slides, mestres, layouts, formas, mídia ou outro conteúdo da apresentação público. Afeta apenas as propriedades do documento. Para ler essas propriedades sem carregar o conteúdo criptografado, veja [Gerenciar Propriedades da Apresentação](/slides/pt/cpp/presentation-properties/).

## **Carregar uma Apresentação Criptografada**

Defina [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/) com a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Trabalhe com a apresentação descriptografada.
```

## **Remover a Criptografia de uma Apresentação**

Carregue a apresentação com sua senha de abertura, chame [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/removeencryption/), e salve o resultado. A apresentação salva pode então ser carregada sem senha.

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

## **Validar uma Senha de Abertura Antes de Carregar**

Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para obter [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/) sem criar uma instância completa da apresentação. Verifique [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Fluxo de Trabalho com Caminho de Arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/), e então carrega a apresentação completa:

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

### **Fluxo de Trabalho com Stream**

A sobrecarga de stream de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornece o mesmo fluxo de trabalho. Redefina a posição de um stream de busca antes de carregar a apresentação completa a partir desse stream.

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

### **Valores de Retorno de CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/checkpassword/) retorna `true` apenas quando a apresentação tem uma senha de abertura e a senha fornecida está correta. Retorna `false` em cada um destes casos:

- A senha está incorreta.
- A apresentação não possui senha de abertura.
- A senha fornecida é nula ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma Apresentação Carregada está Criptografada**

Depois de carregar uma apresentação com a senha correta, inspecione [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) para confirmar que a apresentação original estava criptografada. Para detectar a proteção por senha de abertura antes de carregar, use `IPresentationInfo::get_IsPasswordProtected` como mostrado acima.

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

## **Recomendações de Segurança**

{{% alert color="warning" title="Segurança" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias, mantenha as senhas na memória apenas enquanto necessário e reutilize um resultado de validação bem‑sucedido ao carregar a apresentação imediatamente.

As propriedades públicas do documento podem revelar nomes de autor, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados, mesmo que o conteúdo da apresentação esteja criptografado. Criptografe metadados sensíveis juntamente com a apresentação. Deixar as propriedades públicas deve ser uma decisão explícita tomada apenas quando os sistemas precisam indexar, classificar, buscar ou gerenciar o arquivo sem uma senha de abertura.
{{% /alert %}}

## **Proteger uma Apresentação com Senha Online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou carregue a apresentação.
1. Digite uma senha para proteção de visualização.
1. Opcionalmente, digite uma senha separada para proteção de edição.
1. Aplique a proteção e faça download do arquivo resultante.

{{% alert color="info" title="Veja também" %}}
- [Proteger Apresentações contra Gravação](/slides/pt/cpp/write-protected-presentation/)
- [Assinatura Digital no PowerPoint](/slides/pt/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas Frequentes**

**Qual a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Um aplicativo pode ler metadados sem a senha de abertura?**

Sim, mas somente quando a apresentação foi criptografada com `set_EncryptDocumentProperties(false)`. Nesse caso, o aplicativo deve usar o modo de carregamento apenas das propriedades do documento descrito em [Gerenciar Propriedades da Apresentação](/slides/pt/cpp/presentation-properties/).

**Os fluxos de trabalho de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo e em stream comportam‑se da mesma forma para apresentações PPT e PPTX.