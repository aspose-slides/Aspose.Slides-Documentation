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
description: "Saiba como bloquear e desbloquear facilmente apresentações PowerPoint e OpenDocument protegidas por senha com Aspose.Slides para C++. Proteja suas apresentações."
---
## **Introdução**

Ao proteger uma apresentação com senha, você define uma senha que impõe certas restrições à apresentação. Para remover as restrições, a senha deve ser inserida. Uma apresentação protegida por senha é considerada uma apresentação bloqueada.

Normalmente, você pode definir uma senha para impor essas restrições a uma apresentação:

- **Modificação**

  Se você quiser que apenas determinados usuários modifiquem sua apresentação, pode definir uma restrição de modificação. Essa restrição impede que as pessoas modifiquem, alterem ou copiem elementos da sua apresentação (a menos que forneçam a senha).

  No entanto, nesse caso, mesmo sem a senha, o usuário conseguirá acessar seu documento e abri‑lo. Nesse modo somente‑leitura, o usuário pode visualizar o conteúdo — hiperlinks, animações, efeitos e outros — dentro da apresentação, mas não pode copiar itens nem salvar a apresentação.

- **Abertura**

  Se você quiser que apenas determinados usuários abram sua apresentação, pode definir uma restrição de abertura. Essa restrição impede que as pessoas visualizem o conteúdo da sua apresentação (a menos que forneçam a senha).

  Tecnicamente, a restrição de abertura também impede que os usuários modifiquem suas apresentações: quando as pessoas não podem abrir uma apresentação, elas não podem modificá‑la nem fazer alterações nela.  

  **Observação** que ao proteger uma apresentação com senha para impedir a abertura, o arquivo da apresentação torna‑se criptografado.

## **Como Proteger uma Apresentação com Senha Online**

1. Acesse a página [**Bloqueio Aspose.Slides**](https://products.aspose.app/slides/pt/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Clique em **Drop or upload your files**.

3. Selecione o arquivo que deseja proteger com senha no seu computador.

4. Insira a senha preferida para proteção de edição; insira a senha preferida para proteção de visualização.

5. Se desejar que os usuários vejam sua apresentação como a cópia final, marque a caixa de seleção **Mark as final**.

6. Clique em **PROTECT NOW.**

7. Clique em **DOWNLOAD NOW.**

## **Proteção por Senha para Apresentações no Aspose.Slides**
**Formatos suportados**

Aspose.Slides oferece suporte a proteção por senha, criptografia e operações semelhantes para apresentações nos seguintes formatos:

- PPTX e PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Operações suportadas**

Aspose.Slides permite que você use proteção por senha em apresentações para impedir modificações das seguintes maneiras:

- Criptografar uma apresentação
- Definir proteção contra gravação em uma apresentação

**Outras operações**

Aspose.Slides permite que você execute outras tarefas envolvendo proteção por senha e criptografia das seguintes formas:

- Descriptografar uma apresentação; abrir uma apresentação criptografada
- Remover criptografia; desativar proteção por senha
- Remover proteção contra gravação de uma apresentação
- Obter as propriedades de uma apresentação criptografada
- Verificar se uma apresentação está criptografada
- Verificar se uma apresentação está protegida por senha.

## **Criptografar uma Apresentação**

Você pode criptografar uma apresentação definindo uma senha. Então, para modificar a apresentação bloqueada, o usuário deve fornecer a senha.

Para criptografar ou proteger por senha uma apresentação, você deve usar o método `encrypt` (da classe [ProtectionManager](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager)) para definir uma senha para a apresentação. Passe a senha ao método `encrypt` e use o método `save` para salvar a apresentação agora criptografada.

Este exemplo de código mostra como criptografar uma apresentação:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Definir Proteção contra Gravação em uma Apresentação**

Você pode adicionar uma marca indicando “Não modificar” a uma apresentação. Dessa forma, informa aos usuários que você não deseja que eles façam alterações na apresentação.

**Observação** que o processo de proteção contra gravação não criptografa a apresentação. Portanto, os usuários — se realmente quiserem — podem modificar a apresentação, mas, para salvar as alterações, precisarão criar uma apresentação com um nome diferente.

Para definir proteção contra gravação, você deve usar o método `setWriteProtection`. Este exemplo de código mostra como definir proteção contra gravação em uma apresentação:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Carregar uma Apresentação Criptografada**

Aspose.Slides permite que você carregue um arquivo criptografado passando sua senha. Para descriptografar uma apresentação, é necessário chamar o método [RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sem parâmetros. Em seguida, você deverá inserir a senha correta para carregar a apresentação.

Este exemplo de código mostra como descriptografar uma apresentação:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// trabalhar com a apresentação descriptografada
```

## **Remover Criptografia de uma Apresentação**

Você pode remover a criptografia ou a proteção por senha de uma apresentação. Dessa forma, os usuários podem acessar ou modificar a apresentação sem restrições.

Para remover criptografia ou proteção por senha, você deve chamar o método [RemoveEncryption](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Este exemplo de código mostra como remover a criptografia de uma apresentação:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Remover Proteção contra Gravação de uma Apresentação**

Você pode usar Aspose.Slides para remover a proteção contra gravação aplicada a um arquivo de apresentação. Assim, os usuários podem modificar à vontade — sem avisos ao realizar essas tarefas.

Para remover a proteção contra gravação de uma apresentação, use o método [RemoveWriteProtection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Este exemplo de código mostra como remover a proteção contra gravação de uma apresentação:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obter as Propriedades de uma Apresentação Criptografada**

Normalmente, os usuários têm dificuldade em obter as propriedades de documento de uma apresentação criptografada ou protegida por senha. Aspose.Slides, porém, oferece um mecanismo que permite proteger por senha uma apresentação mantendo a possibilidade de os usuários acessarem as propriedades dessa apresentação.

**Observação** que quando Aspose.Slides criptografa uma apresentação, as propriedades do documento da apresentação também ficam protegidas por senha por padrão. Mas, se for necessário tornar as propriedades da apresentação acessíveis (mesmo após a criptografia), Aspose.Slides permite fazer exatamente isso.

Se desejar que os usuários mantenham a capacidade de acessar as propriedades de uma apresentação que você criptografou, pode passar `true` ao método [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Este exemplo de código mostra como criptografar uma apresentação fornecendo meios para que os usuários acessem suas propriedades de documento:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Verificar se uma Apresentação Está Protegida por Senha**

Antes de carregar uma apresentação, talvez você queira verificar e confirmar que a apresentação não está protegida por senha. Dessa forma, evita erros e problemas semelhantes que surgem quando uma apresentação protegida por senha é carregada sem a senha.

Este código C++ demonstra como examinar uma apresentação para verificar se está protegida por senha (sem carregar a própria apresentação):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Verificar se uma Apresentação Está Criptografada**

Aspose.Slides permite verificar se uma apresentação está criptografada. Para executar essa tarefa, você pode usar o método [get_IsEncrypted()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), que retorna `true` se a apresentação estiver criptografada ou `false` caso contrário.

Este exemplo de código mostra como verificar se uma apresentação está criptografada:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Verificar se uma Apresentação Está Protegida contra Gravação**

Aspose.Slides permite verificar se uma apresentação está protegida contra gravação. Para executar essa tarefa, você pode usar o método [get_IsWriteProtected()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), que retorna `true` se a apresentação estiver protegida contra gravação ou `false` caso contrário.

Este exemplo de código mostra como verificar se uma apresentação está protegida contra gravação:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verificar o Uso da Senha da Apresentação**

Pode ser necessário confirmar que uma senha específica foi usada para proteger um documento de apresentação. Aspose.Slides fornece os meios para validar uma senha.

Este exemplo de código mostra como validar uma senha:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// verificar se "pass" corresponde a
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Ele retorna `true` se a apresentação foi criptografada com a senha especificada. Caso contrário, retorna `false`.

{{% alert color="primary" title="Veja também" %}} 
- [Digital Signature in PowerPoint](/slides/pt/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quais métodos de criptografia são suportados pelo Aspose.Slides?**

Aspose.Slides suporta métodos de criptografia modernos, incluindo algoritmos baseados em AES, garantindo um alto nível de segurança dos seus dados nas apresentações.

**O que acontece se uma senha incorreta for inserida ao tentar abrir uma apresentação?**

É lançada uma exceção se a senha estiver incorreta, alertando que o acesso à apresentação foi negado. Isso ajuda a impedir acesso não autorizado e protege o conteúdo da apresentação.

**Existem implicações de desempenho ao trabalhar com apresentações protegidas por senha?**

O processo de criptografia e descriptografia pode introduzir uma pequena sobrecarga durante as operações de abertura e salvamento. Na maioria dos casos, esse impacto de desempenho é mínimo e não afeta significativamente o tempo total de processamento das suas tarefas de apresentação.