---
title: Proteção contra gravação de apresentações em PHP
linktitle: Proteção contra gravação
type: docs
weight: 25
url: /pt/php-java/write-protected-presentation/
keywords:
- proteção contra gravação
- proteção contra gravação PowerPoint
- senha para modificar
- restringir edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para PHP."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo do aplicativo, eles também podem ser capazes de editar o conteúdo e salvá‑lo com outro nome, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, veja [Password-Protect Presentations](/slides/pt/php-java/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos usam arquivos PPTX; ao salvar como PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#setWriteProtection) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação preserva a configuração de proteção.

O exemplo a seguir define a proteção contra gravação em uma apresentação PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregar a apresentação. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Não passe uma senha de proteção contra gravação para [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword). Esse método aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#removeWriteProtection) para remover a restrição de modificação e, em seguida, salvar a apresentação.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/), chame [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/#getPresentationInfo) e examine [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#isWriteProtected). O método usa [NullableBool](https://reference.aspose.com/slides/pt/php-java/aspose.slides/nullablebool/) e retorna `NullableBool::True` quando a proteção contra gravação é detectada.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

A sobrecarga de stream de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fornece a mesma informação para uma apresentação fornecida como stream.

## **Validar uma senha de proteção contra gravação**

Use [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#isWriteProtected) primeiro para que o aplicativo solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#checkWriteProtection) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#checkPassword) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#checkWriteProtection) fornece a verificação equivalente de proteção contra gravação por meio de seu gerenciador de proteção.

Em aplicativos de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias e mantenha as senhas na memória apenas pelo tempo necessário.

{{% alert color="info" title="Veja também" %}}
- [Password-Protect Presentations](/slides/pt/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/pt/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo criptografado da apresentação.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando a autorização de modificação for necessária.