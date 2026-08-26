---
title: Apresentações protegidas por senha em PHP
linktitle: Proteção por senha
type: docs
weight: 20
url: /pt/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "Criptografe, detecte, valide, abra e descriptografe apresentações PowerPoint PPT e PPTX protegidas por senha em PHP com Aspose.Slides."
---
## **Visão geral**

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção fornece confidencialidade.

Uma senha de abertura é diferente de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Write-Protect Presentations](/slides/pt/php-java/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam tanto a apresentações PPT quanto PPTX. Os exemplos usam ambos os formatos onde o comportamento baseado em arquivo e em fluxo é importante.

## **Criptografar uma apresentação com uma senha de abertura**

Use [ProtectionManager::encrypt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#encrypt) para atribuir uma senha de abertura. Em seguida, use [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para persistir a apresentação criptografada.

O exemplo a seguir criptografa uma apresentação PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Carregar uma apresentação criptografada**

Defina [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword) com a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é necessária, mas a senha fornecida está ausente ou incorreta.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Trabalhe com a apresentação descriptografada.
} finally {
    $presentation->dispose();
}
```

## **Remover criptografia de uma apresentação**

Carregue a apresentação com sua senha de abertura, chame [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#removeEncryption) e salve o resultado. A apresentação salva pode então ser carregada sem senha.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Validar uma senha de abertura antes de carregar**

Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/#getPresentationInfo) para obter [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/) sem criar uma instância completa da apresentação. Verifique [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Fluxo de Trabalho por Caminho de Arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword) e então carrega a apresentação completa:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Fluxo de Trabalho com Stream**

A sobrecarga de stream de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fornece o mesmo fluxo de trabalho. Redefina a posição de um stream pesquisável antes de carregar a apresentação completa a partir desse stream.

O exemplo a seguir usa um arquivo PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Valores de Retorno de checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#checkPassword) retorna `true` somente quando a apresentação tem uma senha de abertura e a senha fornecida está correta. Retorna `false` em cada um destes casos:

- A senha está incorreta.
- A apresentação não tem senha de abertura.
- A senha fornecida é `null` ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma apresentação carregada está criptografada**

Depois de carregar uma apresentação com a senha correta, inspecione [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que a apresentação original estava criptografada. Para detectar proteção por senha de abertura antes de carregar, use [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#isPasswordProtected) conforme mostrado acima.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Recomendações de Segurança**

{{% alert color="warning" title="Segurança" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas repetidas de validação desnecessárias, mantenha as senhas na memória apenas enquanto forem necessárias e reutilize um resultado de validação bem-sucedido ao carregar a apresentação imediatamente.
{{% /alert %}}

## **Proteger uma apresentação com senha online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou faça upload da apresentação.
1. Digite uma senha para proteção de visualização.
1. Opcionalmente, insira uma senha separada para proteção de edição.
1. Aplique a proteção e faça download do arquivo resultante.

{{% alert color="info" title="Veja também" %}}
- [Proteger Apresentações contra Gravação](/slides/pt/php-java/write-protected-presentation/)
- [Assinatura Digital no PowerPoint](/slides/pt/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas Frequentes**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Os fluxos de trabalho de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseada em caminho de arquivo e em stream se comportam da mesma forma para apresentações PPT e PPTX.