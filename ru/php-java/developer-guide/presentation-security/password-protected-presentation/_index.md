---
title: Защита презентаций паролем в PHP
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/php-java/password-protected-presentation/
keywords:
- презентация, защищённая паролем
- пароль при открытии
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
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, в PHP с помощью Aspose.Slides."
---
## **Обзор**

Пароль для открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль для открытия отличается от пароля защиты от записи. Защита от записи ограничивает модификацию, но не шифрует содержимое и не препятствует загрузке презентации. Для управления паролями при изменении презентаций см. [Write-Protect Presentations](/slides/ru/php-java/write-protected-presentation/).

Приведённые ниже сценарии применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важно их поведение при работе с файлами и потоками.

## **Зашифровать презентацию паролем при открытии**

Используйте [ProtectionManager::encrypt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#encrypt) для назначения пароля при открытии. Затем используйте [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

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

## **Оставить свойства документа публичными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Метод [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) управляет этим поведением независимо от шифрования содержимого слайдов. Перед вызовом [ProtectionManager::encrypt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#encrypt) передайте `false`, если система индексации, классификации, поиска или управления документами должна считывать метаданные без пароля при открытии.

Следующий пример создаёт зашифрованную презентацию PPTX, при этом оставляя встроенные свойства документа публичными:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Передача `false` в [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) не делает публичными слайды, шаблоны, макеты, фигуры, медиа или другое содержимое презентации. Она влияет только на свойства документа. Чтобы читать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/php-java/presentation-properties/).

## **Загрузить зашифрованную презентацию**

Установите [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword) в пароль при открытии и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) при загрузке файла. Загрузка не удалась, если требуется пароль при открытии, но предоставленный пароль отсутствует или неверен.

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

## **Удалить шифрование из презентации**

Загрузите презентацию с её паролем при открытии, вызовите [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeEncryption) и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

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

## **Проверить пароль при открытии перед загрузкой**

Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isPasswordProtected) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Рабочий процесс с файловым путём**

Следующий пример проверяет пароль при открытии для файла PPTX, передаёт проверенное значение в [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword), а затем загружает полную презентацию:

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

### **Рабочий процесс с потоком**

Перегрузка потока метода [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) предоставляет тот же рабочий процесс. Сбросьте позицию перемещаемого потока перед загрузкой полной презентации из этого потока.

Следующий пример использует файл PPT:

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

### **Значения, возвращаемые checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkPassword) возвращает `true` только когда у презентации есть пароль при открытии и предоставленный пароль правильный. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля при открытии.
- Предоставленный пароль `null` или пустой.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isEncrypted), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем при открытии до загрузки, используйте [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isPasswordProtected), как показано выше.

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
Не записывайте пароли при открытии в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько требуется, и переиспользуйте результат успешной проверки при немедленной загрузке презентации.

Публичные свойства документа могут раскрывать имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставление свойств публичными должно быть явным решением, принимаемым только тогда, когда системы должны индексировать, классифицировать, искать или управлять файлом без пароля при открытии.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При желании введите отдельный пароль для защиты редактирования.
1. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="See also" %}}
- [Защита презентаций от записи](/slides/ru/php-java/write-protected-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем при открытии и паролем защиты от записи?**

Пароль при открытии шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает модификацию без шифрования содержимого.

**Можно ли проверить пароль при открытии без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем при открытии и проверьте пароль до создания полного экземпляра презентации.

**Может ли приложение прочитать метаданные без пароля при открытии?**

Да, но только когда презентация зашифрована с отключённым шифрованием свойств документа. В этом случае приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/php-java/presentation-properties/).

**Поддерживают ли сценарии проверки пароля оба формата PPT и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.