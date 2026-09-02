---
title: Защита презентаций от записи в PHP
linktitle: Защита записи
type: docs
weight: 25
url: /ru/php-java/write-protected-presentation/
keywords:
- защита от записи
- защита PowerPoint от записи
- пароль для изменения
- ограничить редактирование презентации
- снять защиту от записи
- проверка пароля изменения
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Установите, обнаружьте, проверьте и удалите пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для PHP."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просмотреть презентацию с защитой от записи без пароля. В зависимости от приложения они также могут редактировать содержимое и сохранять его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит иной цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Password-Protect Presentations](/slides/ru/php-java/password-protected-presentation/).

Процессы, описанные в этой статье, применимы как к презентациям PPT, так и PPTX. В примерах используются файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи в презентации**

Используйте [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setWriteProtection), чтобы назначить пароль для изменения презентации. При сохранении презентации настройка защиты сохраняется.

Следующий пример устанавливает защиту от записи в презентацию PPTX:

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

## **Загрузка презентации с защитой от записи**

Поскольку защита от записи не шифрует содержимое презентации, пароль для загрузки презентации не требуется. Пароль требуется только при проверке разрешения на изменение защищённой презентации.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Не передавайте пароль защиты от записи в [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword). Этот метод принимает пароль открытия для зашифрованного содержимого. Если у презентации оба типа защиты, передайте пароль открытия для её загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Снять защиту от записи с презентации**

Используйте [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeWriteProtection), чтобы убрать ограничение на изменение, затем сохраните презентацию.

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

## **Проверить, защищена ли презентация от записи**

Чтобы проверить файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), вызовите [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) и проверьте [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isWriteProtected). Метод использует [NullableBool](https://reference.aspose.com/slides/ru/php-java/aspose.slides/nullablebool/) и возвращает `NullableBool::True`, когда обнаружена защита от записи.

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

Перегрузка метода, принимающая поток, [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo), предоставляет ту же информацию для презентации, переданной в виде потока.

## **Проверить пароль защиты от записи**

Используйте [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkWriteProtection), чтобы проверить пароль изменения без загрузки полной презентации. Сначала проверьте [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isWriteProtected), чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

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

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkWriteProtection) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, можно ли загрузить зашифрованное содержимое. Напротив, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#checkPassword) проверяет только пароль открытия. Если полная презентация уже загружена, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#checkWriteProtection) предоставляет эквивалентную проверку защиты от записи через свой менеджер защиты.

В производственных приложениях не регистрируйте пароли и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки и храните пароли в памяти только столько, сколько требуется.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/ru/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/ru/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Для загрузки зашифрованного содержимого презентации требуется только пароль открытия.

**Может ли презентация иметь одновременно пароль открытия и пароль защиты от записи?**

Да. Передайте пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется разрешение на изменение.