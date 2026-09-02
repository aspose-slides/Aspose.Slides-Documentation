---
title: Apresentações Seguras com Senhas em PHP
linktitle: Proteção por Senha
type: docs
weight: 20
url: /pt/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear facilmente apresentações PowerPoint e OpenDocument protegidas por senha com Aspose.Slides para PHP. Proteja suas apresentações."
---
## **Introdução**

Quando você protege uma apresentação com senha, está definindo uma senha que impõe determinadas restrições à apresentação. Para remover as restrições, a senha deve ser inserida. Uma apresentação protegida por senha é considerada uma apresentação bloqueada.

Normalmente, você pode definir uma senha para aplicar essas restrições a uma apresentação:

- **Modificação**

  Se quiser que apenas usuários específicos modifiquem sua apresentação, pode definir uma restrição de modificação. Essa restrição impede que as pessoas modifiquem, alterem ou copiem itens na sua apresentação (a menos que forneçam a senha).

  Contudo, nesse caso, mesmo sem a senha, o usuário poderá acessar seu documento e abri‑lo. Nesse modo somente‑leitura, o usuário pode visualizar o conteúdo — hiperlinks, animações, efeitos e outros — dentro da apresentação, mas não pode copiar itens nem salvar a apresentação.

- **Abertura**

  Se quiser que apenas usuários específicos abram sua apresentação, pode definir uma restrição de abertura. Essa restrição impede que as pessoas visualizem o conteúdo da sua apresentação (a menos que forneçam a senha).

  Tecnicamente, a restrição de abertura também impede que os usuários modifiquem suas apresentações: quando as pessoas não podem abrir uma apresentação, elas não podem modificar nem fazer alterações nela.  

  **Nota** que ao proteger uma apresentação com senha para impedir a abertura, o arquivo da apresentação passa a ser criptografado.

## **Como Proteger uma Apresentação com Senha Online**

1. Acesse a nossa página [**Aspose.Slides Lock**](https://products.aspose.app/slides/pt/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Clique em **Drop or upload your files**.

3. Selecione o arquivo que deseja proteger com senha no seu computador.

4. Insira a senha preferida para proteção de edição; insira a senha preferida para proteção de visualização.

5. Se quiser que os usuários vejam sua apresentação como a cópia final, marque a caixa de seleção **Mark as final**.

6. Clique em **PROTEGER AGORA.**

7. Clique em **BAIXAR AGORA.**

## **Proteção por Senha para Apresentações no Aspose.Slides**
**Formatos suportados**

Aspose.Slides oferece suporte a proteção por senha, criptografia e operações semelhantes para apresentações nos seguintes formatos:

- PPTX e PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Operações suportadas**

Aspose.Slides permite usar proteção por senha em apresentações para impedir modificações das seguintes maneiras:

- Criptografar uma apresentação  
- Definir proteção contra gravação em uma apresentação  

**Outras operações**

Aspose.Slides permite executar outras tarefas relacionadas à proteção por senha e criptografia das seguintes formas:

- Descriptografar uma apresentação; abrir uma apresentação criptografada  
- Remover criptografia; desativar a proteção por senha  
- Remover a proteção contra gravação de uma apresentação  
- Obter as propriedades de uma apresentação criptografada  
- Verificar se uma apresentação está criptografada  
- Verificar se uma apresentação está protegida por senha  

## **Criptografar uma Apresentação**

Você pode criptografar uma apresentação definindo uma senha. Em seguida, para modificar a apresentação bloqueada, o usuário precisa fornecer a senha.

Para criptografar ou proteger por senha uma apresentação, use o método **encrypt** (de [ProtectionManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/)) para definir uma senha para a apresentação. Você passa a senha ao método **encrypt** e usa o método **save** para salvar a apresentação agora criptografada.

Este código de exemplo mostra como criptografar uma apresentação:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Definir Proteção Contra Gravação em uma Apresentação**

Você pode adicionar uma marca indicando “Não modificar” a uma apresentação. Dessa forma, informa aos usuários que você não deseja que eles façam alterações na apresentação.

**Nota** que o processo de proteção contra gravação não criptografa a apresentação. Portanto, os usuários — se realmente quiserem — podem modificar a apresentação, mas, para salvar as alterações, precisarão criar a apresentação com um nome diferente.

Para definir uma proteção contra gravação, use o método [setWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#setWriteProtection). Este código de exemplo mostra como definir proteção contra gravação em uma apresentação:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Carregar uma Apresentação Criptografada**

Aspose.Slides permite carregar um arquivo criptografado passando sua senha. Para descriptografar uma apresentação, chame o método [removeEncryption](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#removeEncryption) sem parâmetros. Em seguida, será necessário inserir a senha correta para carregar a apresentação.

Este código de exemplo mostra como descriptografar uma apresentação:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # trabalhar com a apresentação descriptografada
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Remover Criptografia de uma Apresentação**

Você pode remover a criptografia ou a proteção por senha de uma apresentação. Dessa forma, os usuários podem acessar ou modificar a apresentação sem restrições.

Para remover a criptografia ou a proteção por senha, chame o método [removeEncryption](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#removeEncryption). Este código de exemplo mostra como remover a criptografia de uma apresentação:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Remover Proteção Contra Gravação de uma Apresentação**

Você pode usar Aspose.Slides para remover a proteção contra gravação aplicada a um arquivo de apresentação. Assim, os usuários podem modificar livremente e não recebem avisos ao executar essas tarefas.

Remova a proteção contra gravação de uma apresentação usando o método [removeWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Este código de exemplo mostra como remover a proteção contra gravação de uma apresentação:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Obter Propriedades de uma Apresentação Criptografada**

Normalmente, os usuários têm dificuldades para recuperar as propriedades de documento de uma apresentação criptografada ou protegida por senha. Contudo, Aspose.Slides oferece um mecanismo que permite proteger a apresentação com senha e, ainda assim, manter a capacidade dos usuários de acessar suas propriedades.

**Nota:** Por padrão, quando Aspose.Slides criptografa uma apresentação, as propriedades de documento da apresentação também ficam protegidas por senha. Se precisar que as propriedades de documento permaneçam acessíveis mesmo após a criptografia, Aspose.Slides permite fazer exatamente isso.

Se quiser que os usuários mantenham a capacidade de acessar as propriedades de uma apresentação criptografada, passe `false` para [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Este código de exemplo demonstra como criptografar uma apresentação mantendo o acesso dos usuários às propriedades de documento:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Carregar Apenas as Propriedades de Documento de uma Apresentação Criptografada**

Para inspecionar os metadados de uma apresentação criptografada sem carregar seus slides ou outro conteúdo, crie um objeto [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/) e passe `true` para [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). Nesse modo, Aspose.Slides ignora a senha e carrega apenas as propriedades de documento que são publicamente acessíveis.

O exemplo abaixo lê propriedades de documento incorporadas e personalizadas por meio de [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Ler propriedades de documento incorporadas.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Ler propriedades de documento personalizadas.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Esse fluxo funciona apenas quando as propriedades de documento foram deixadas sem criptografia (públicas) ao criptografar a apresentação. Se as propriedades de documento estiverem criptografadas, passar `true` para [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) gera uma exceção porque a senha é ignorada neste modo. Para acessar propriedades de documento criptografadas ou carregar a apresentação completa, incluindo slides e demais conteúdos, forneça a senha correta através de [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword).

## **Verificar se uma Apresentação Está Protegida por Senha**

Antes de carregar uma apresentação, talvez queira verificar e confirmar que a apresentação não está protegida por senha. Dessa forma, evita erros e problemas semelhantes que surgem quando uma apresentação protegida por senha é carregada sem a sua senha.

Este código PHP mostra como examinar uma apresentação para saber se está protegida por senha (sem carregar a própria apresentação):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Verificar se uma Apresentação Está Criptografada**

Aspose.Slides permite verificar se uma apresentação está criptografada. Para executar essa tarefa, use o método [isEncrypted](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#isEncrypted), que retorna `true` se a apresentação estiver criptografada ou `false` caso contrário.

Este código de exemplo mostra como verificar se uma apresentação está criptografada:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Verificar se uma Apresentação Está Protegida contra Gravação**

Aspose.Slides permite verificar se uma apresentação está protegida contra gravação. Para executar essa tarefa, use o método [isWriteProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#isWriteProtected), que retorna `true` se a apresentação estiver protegida contra gravação ou `false` caso contrário.

Este código de exemplo mostra como verificar se uma apresentação está protegida contra gravação:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Validar ou Confirmar que uma Senha Específica Foi Usada**

Pode ser necessário verificar e confirmar que uma senha específica foi usada para proteger um documento de apresentação. Aspose.Slides fornece os meios para validar uma senha.

Este código de exemplo mostra como validar uma senha:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # verificar se "pass" corresponde a
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Ele retorna `true` se a apresentação foi criptografada com a senha especificada. Caso contrário, retorna `false`. 

{{% alert color="primary" title="Veja também" %}} 
- [Assinatura Digital no PowerPoint](/slides/pt/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quais métodos de criptografia são suportados pelo Aspose.Slides?**

Aspose.Slides oferece suporte a métodos de criptografia modernos, incluindo algoritmos baseados em AES, garantindo um alto nível de segurança dos dados das suas apresentações.

**O que acontece se uma senha incorreta for inserida ao tentar abrir uma apresentação?**

Uma exceção é lançada se uma senha incorreta for usada, indicando que o acesso à apresentação foi negado. Isso ajuda a impedir o acesso não autorizado e protege o conteúdo da apresentação.

**Existem implicações de desempenho ao trabalhar com apresentações protegidas por senha?**

O processo de criptografia e descriptografia pode introduzir um pequeno overhead durante as operações de abertura e salvamento. Na maioria dos casos, esse impacto de desempenho é mínimo e não afeta significativamente o tempo total de processamento das suas tarefas de apresentação.