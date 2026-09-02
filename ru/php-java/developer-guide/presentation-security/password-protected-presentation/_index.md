---
title: Защита презентаций паролем в PHP
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/php-java/password-protected-presentation/
keywords:
- презентация с защитой паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- проверка пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- PHP
- Aspose.Slides
description: "Шифруйте, обнаруживайте, проверяйте, открывайте и расшифровывайте презентации PowerPoint PPT и PPTX, защищённые паролем, в PHP с помощью Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Write-Protect Presentations](/slides/ru/php-java/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и к PPTX. Примеры используют оба формата, когда важно их поведение при работе с файлами и потоками.

## **Зашифровать презентацию паролем открытия**

Используйте [ProtectionManager::encrypt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#encrypt), чтобы задать пароль открытия. Затем используйте [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) для сохранения зашифрованной презентации.

В следующем примере происходит шифрование PPTX‑презентации:

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

## **Загрузить зашифрованную презентацию**

Установите [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) при загрузке файла. Загрузка прекращается, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Работа с расшифрованной презентацией.
} finally {
    $presentation->dispose();
}
```

## **Убрать шифрование из презентации**

Загрузите презентацию с её паролем открытия, вызовите [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeEncryption) и сохраните результат. Сохранённая презентация затем может быть загружена без пароля.

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

## **Проверить пароль открытия перед загрузкой**

Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isPasswordProtected) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Рабочий процесс с путём к файлу**

В следующем примере проверяется пароль открытия для файла PPTX, проверенное значение передаётся в [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword), после чего загружается полная презентация:

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

### **Рабочий процесс с потоками**

Перегрузка с потоками метода [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) обеспечивает тот же процесс. Сбросьте позицию позиционируемого потока перед загрузкой полной презентации из этого потока.

В следующем примере используется PPT‑файл:

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

### **Возвращаемые значения checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkPassword) возвращает `true` только когда у презентации установлен пароль открытия и предоставленный пароль правильный. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль равен `null` или пустой.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isEncrypted), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isPasswordProtected), как показано выше.

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

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, держите пароли в памяти только столько, сколько необходимо, и переиспользуйте успешный результат проверки при непосредственной загрузке презентации.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При необходимости введите отдельный пароль для защиты редактирования.
1. Примените защиту и загрузите полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Можно ли проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль до создания полного экземпляра презентации.

**Поддерживают ли процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.