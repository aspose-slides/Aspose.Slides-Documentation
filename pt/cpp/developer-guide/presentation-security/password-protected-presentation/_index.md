---
title: Apresentações Seguras com Senhas em C++
linktitle: Proteção por Senha
type: docs
weight: 20
url: /pt/cpp/password-protected-presentation/
keywords:
- bloquear PowerPoint
- bloquear apresentação
- desbloquear PowerPoint
- desbloquear apresentação
- proteger PowerPoint
- proteger apresentação
- definir senha
- adicionar senha
- criptografar PowerPoint
- criptografar apresentação
- descriptografar PowerPoint
- descriptografar apresentação
- proteção contra gravação
- segurança do PowerPoint
- segurança da apresentação
- remover senha
- remover proteção
- remover criptografia
- desativar senha
- desativar proteção
- remover proteção contra gravação
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a bloquear e desbloquear facilmente apresentações PowerPoint e OpenDocument protegidas por senha com Aspose.Slides para C++. Proteja suas apresentações."
---
## **Introdução**

Quando você protege uma apresentação com senha, está definindo uma senha que impõe certas restrições à apresentação. Para remover as restrições, a senha deve ser inserida. Uma apresentação protegida por senha é considerada uma apresentação bloqueada.

Normalmente, você pode definir uma senha para impor essas restrições em uma apresentação:

- **Modificação**

  Se você deseja que apenas determinados usuários modifiquem sua apresentação, pode definir uma restrição de modificação. Essa restrição impede que as pessoas modifiquem, alterem ou copiem itens na sua apresentação (a menos que forneçam a senha).

  No entanto, nesse caso, mesmo sem a senha, o usuário poderá acessar seu documento e abri‑lo. Nesse modo somente‑leitura, o usuário pode visualizar o conteúdo — hiperlinks, animações, efeitos e outros — dentro da apresentação, mas não pode copiar itens nem salvar a apresentação.

- **Abertura**

  Se você deseja que apenas determinados usuários abram sua apresentação, pode definir uma restrição de abertura. Essa restrição impede que as pessoas visualizem o conteúdo da sua apresentação (a menos que forneçam a senha).

  Tecnicamente, a restrição de abertura também impede que os usuários modifiquem suas apresentações: quando as pessoas não podem abrir uma apresentação, elas não podem fazer alterações nela.  

  **Note** que quando você protege uma apresentação com senha para impedir a abertura, o arquivo da apresentação passa a ser criptografado.

## **Como Proteger uma Apresentação com Senha Online**

1. Acesse nossa página [**Aspose.Slides Lock**](https://products.aspose.app/slides/pt/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Clique **Drop or upload your files**.

3. Selecione o arquivo que você deseja proteger com senha no seu computador. 

4. Insira a senha desejada para proteção de edição; Insira a senha desejada para proteção de visualização. 

5. Se quiser que os usuários vejam sua apresentação como a cópia final, marque a caixa de seleção **Mark as final**.

6. Clique **PROTECT NOW.** 

7. Clique **DOWNLOAD NOW.**

## **Proteção por Senha para Apresentações no Aspose.Slides**
**Formatos suportados**

Aspose.Slides oferece proteção por senha, criptografia e operações semelhantes para apresentações nos seguintes formatos: 

- PPTX e PPT – Apresentação Microsoft PowerPoint 
- ODP – Apresentação OpenDocument 
- OTP – Modelo de Apresentação OpenDocument 

**Operações suportadas**

Aspose.Slides permite usar proteção por senha em apresentações para impedir modificações das seguintes formas:

- Criptografar uma apresentação
- Definir proteção contra gravação em uma apresentação

**Outras operações**

Aspose.Slides permite executar outras tarefas envolvendo proteção por senha e criptografia das seguintes maneiras:

- Descriptografar uma apresentação; abrir uma apresentação criptografada
- Remover criptografia; desativar proteção por senha
- Remover proteção contra gravação de uma apresentação
- Obter as propriedades de uma apresentação criptografada
- Verificar se uma apresentação está criptografada
- Verificar se uma apresentação está protegida por senha.

## **Criptografar uma Apresentação**

Você pode criptografar uma apresentação definindo uma senha. Em seguida, para modificar a apresentação bloqueada, o usuário deverá fornecer a senha. 

Para criptografar ou proteger por senha uma apresentação, você deve usar o método `encrypt` (de [ProtectionManager](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager)) para definir uma senha para a apresentação. Passe a senha ao método `encrypt` e use o método `save` para salvar a apresentação agora criptografada. 

Este código de exemplo mostra como criptografar uma apresentação:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Definir Proteção contra Gravação em uma Apresentação** 

Você pode adicionar uma marca indicando “Não modificar” a uma apresentação. Dessa forma, informa aos usuários que você não deseja que eles façam alterações na apresentação.  

**Note** que o processo de proteção contra gravação não criptografa a apresentação. Portanto, os usuários—se realmente quiserem—podem modificar a apresentação, mas, para salvar as alterações, precisarão criar uma apresentação com um nome diferente. 

Para definir uma proteção contra gravação, você deve usar o método `setWriteProtection`. Este código de exemplo mostra como definir proteção contra gravação em uma apresentação:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Carregar uma Apresentação Criptografada**

Aspose.Slides permite carregar um arquivo criptografado passando sua senha. Para descriptografar uma apresentação, você deve chamar o método [RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sem parâmetros. Em seguida, será necessário inserir a senha correta para carregar a apresentação. 

Este código de exemplo mostra como descriptografar uma apresentação: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// trabalhar com a apresentação descriptografada
```

## **Remover Criptografia de uma Apresentação**

Você pode remover a criptografia ou proteção por senha de uma apresentação. Dessa forma, os usuários passam a poder acessar ou modificar a apresentação sem restrições. 

Para remover a criptografia ou proteção por senha, você deve chamar o método [RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Este código de exemplo mostra como remover a criptografia de uma apresentação:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Remover Proteção contra Gravação de uma Apresentação**

Você pode usar Aspose.Slides para remover a proteção contra gravação usada em um arquivo de apresentação. Assim, os usuários podem modificar à vontade — e não recebem avisos ao executar essas tarefas.

Você pode remover a proteção contra gravação de uma apresentação usando o método [RemoveWriteProtection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Este código de exemplo mostra como remover a proteção contra gravação de uma apresentação:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obter Propriedades de uma Apresentação Criptografada**

Normalmente, os usuários têm dificuldade em recuperar as propriedades do documento de uma apresentação criptografada ou protegida por senha. Contudo, Aspose.Slides fornece um mecanismo que permite proteger uma apresentação por senha enquanto ainda possibilita o acesso às suas propriedades de documento.

**Note:** Por padrão, quando Aspose.Slides criptografa uma apresentação, as propriedades de documento da apresentação também ficam protegidas por senha. Se precisar deixar as propriedades de documento acessíveis mesmo após a criptografia, Aspose.Slides permite fazer exatamente isso.

Se quiser que os usuários mantenham a capacidade de acessar as propriedades de uma apresentação criptografada, passe `false` ao método `set_EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/). Este código de exemplo mostra como criptografar uma apresentação mantendo o acesso dos usuários às propriedades de documento:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Carregar Apenas as Propriedades do Documento de uma Apresentação Criptografada**

Para inspecionar os metadados de uma apresentação criptografada sem carregar seus slides ou outro conteúdo, crie um objeto [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/) e defina [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) como `true`. Nesse modo, Aspose.Slides ignora a senha e carrega somente as propriedades de documento que são publicamente acessíveis.

O exemplo de código a seguir lê propriedades de documento incorporadas e personalizadas através de [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Esse fluxo funciona apenas quando as propriedades de documento foram deixadas sem criptografia (públicas) ao criptografar a apresentação. Se as propriedades de documento estiverem criptografadas, definir `LoadOptions::set_OnlyLoadDocumentProperties` como `true` gera uma exceção porque a senha é ignorada nesse modo. Para acessar propriedades de documento criptografadas ou carregar a apresentação completa, incluindo slides e demais conteúdos, forneça a senha correta com `LoadOptions::set_Password` em [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/).

## **Verificar se uma Apresentação Está Protegida por Senha**

Antes de carregar uma apresentação, pode ser útil verificar e confirmar que a apresentação não está protegida por senha. Dessa forma, você evita erros e problemas semelhantes que surgem quando uma apresentação protegida por senha é carregada sem a senha.

Este código C++ mostra como examinar uma apresentação para verificar se está protegida por senha (sem carregar a própria apresentação):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Verificar se uma Apresentação Está Criptografada**

Aspose.Slides permite verificar se uma apresentação está criptografada. Para realizar essa tarefa, você pode usar o método [get_IsEncrypted()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), que retorna `true` se a apresentação estiver criptografada ou `false` caso contrário. 

Este código de exemplo mostra como verificar se uma apresentação está criptografada:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Verificar se uma Apresentação Está Protegida contra Gravação**

Aspose.Slides permite verificar se uma apresentação está protegida contra gravação. Para realizar essa tarefa, você pode usar o método [get_IsWriteProtected()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), que retorna `true` se a apresentação estiver protegida contra gravação ou `false` caso contrário. 

Este código de exemplo mostra como verificar se uma apresentação está protegida contra gravação:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verificar o Uso de Senha em uma Apresentação**

Pode ser necessário confirmar que uma senha específica foi usada para proteger um documento de apresentação. Aspose.Slides fornece os meios para validar uma senha. 

Este código de exemplo mostra como validar uma senha:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// verifique se "pass" corresponde
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Ele retorna `true` se a apresentação foi criptografada com a senha especificada. Caso contrário, retorna `false`. 

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/pt/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quais métodos de criptografia são suportados pelo Aspose.Slides?**

Aspose.Slides suporta métodos de criptografia modernos, incluindo algoritmos baseados em AES, garantindo um alto nível de segurança dos seus dados nas apresentações.

**O que acontece se uma senha incorreta for inserida ao tentar abrir uma apresentação?**

Uma exceção é lançada quando uma senha incorreta é usada, alertando que o acesso à apresentação foi negado. Isso ajuda a impedir acessos não autorizados e protege o conteúdo da apresentação.

**Existem implicações de desempenho ao trabalhar com apresentações protegidas por senha?**

O processo de criptografia e descriptografia pode introduzir um leve overhead durante as operações de abertura e salvamento. Na maioria dos casos, esse impacto de desempenho é mínimo e não afeta significativamente o tempo total de processamento das suas tarefas com apresentações.