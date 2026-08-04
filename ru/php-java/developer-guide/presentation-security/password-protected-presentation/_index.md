---
title: Защита презентаций паролем в PHP
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/php-java/password-protected-presentation/
keywords:
- блокировать PowerPoint
- блокировать презентацию
- разблокировать PowerPoint
- разблокировать презентацию
- защитить PowerPoint
- защитить презентацию
- установить пароль
- добавить пароль
- зашифровать PowerPoint
- зашифровать презентацию
- расшифровать PowerPoint
- расшифровать презентацию
- защита от записи
- безопасность PowerPoint
- безопасность презентации
- удалить пароль
- удалить защиту
- удалить шифрование
- отключить пароль
- отключить защиту
- снять защиту от записи
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как легко блокировать и разблокировать презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для PHP. Защитите ваши презентации."
---
## **Введение**

Когда вы защищаете презентацию паролем, вы задаёте пароль, который вводит определённые ограничения для презентации. Чтобы снять ограничения, нужно ввести пароль. Презентация, защищённая паролем, считается заблокированной.

Обычно вы можете установить пароль, чтобы ввести эти ограничения для презентации:

- **Изменение**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение предотвращает изменение, изменение или копирование содержимого вашей презентации (если только они не введут пароль). 

  Однако в этом случае пользователь сможет открыть ваш документ даже без пароля. В режиме только для чтения пользователь может просматривать содержимое, включая гиперссылки, анимацию, эффекты и другое, но не может копировать элементы или сохранять презентацию. 

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое вашей презентации (если только они не введут пароль).

  Технически ограничение на открытие также не позволяет пользователям изменять презентацию: если пользователь не может открыть презентацию, он не может вносить в неё изменения. 
  
  **Примечание** что когда вы защищаете презентацию паролем, чтобы запретить её открытие, файл презентации шифруется.

## **Как защищать презентацию паролем онлайн**

1. Перейдите на страницу нашего [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock) page. 

   ![todo:image_alt_text](slides-lock.png)

2. Click **Drop or upload your files**.

3. Выберите файл, который вы хотите защитить паролем, на вашем компьютере. 

4. Введите желаемый пароль для защиты от редактирования; введите желаемый пароль для защиты от просмотра. 

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательный вариант, установите галочку **Mark as final** checkbox.

6. Нажмите **PROTECT NOW.** 

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций в следующих форматах: 

- PPTX и PPT — Microsoft PowerPoint Presentation 
- ODP — OpenDocument Presentation 
- OTP —  OpenDocument Presentation Template 

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для презентаций, чтобы предотвращать изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Снятие защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен ввести пароль. 

Для шифрования или защиты паролем презентации необходимо использовать метод encrypt (из [ProtectionManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/)), чтобы задать пароль для презентации. Пароль передаётся в метод encrypt, а затем метод save сохраняет теперь зашифрованную презентацию.

Этот пример кода демонстрирует, как зашифровать презентацию:

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

## **Установка защиты от записи для презентации**

Вы можете добавить пометку «Do not modify» к презентации. Таким образом, вы сообщаете пользователям, что не желаете, чтобы они вносили изменения в презентацию.  

**Примечание** что процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменять презентацию, но чтобы сохранить изменения, им придётся сохранить её под другим именем. 

Чтобы установить защиту от записи, необходимо использовать метод [setWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setWriteProtection). Этот пример кода демонстрирует, как установить защиту от записи для презентации:

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

## **Загрузка зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Для расшифровки презентации необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeEncryption) без параметров. Затем потребуется ввести правильный пароль, чтобы загрузить презентацию.

Этот пример кода демонстрирует, как расшифровать презентацию: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # работа с расшифрованной презентацией
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Удаление шифрования из презентации**

Вы можете удалить шифрование или защиту паролем из презентации. Таким образом, пользователи смогут получать доступ к презентации или изменять её без ограничений. 

Для удаления шифрования или защиты паролем необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeEncryption). Этот пример кода демонстрирует, как удалить шифрование из презентации:

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

## **Снятие защиты от записи с презентации**

Вы можете использовать Aspose.Slides для снятия защиты от записи, применённой к файлу презентации. Таким образом, пользователи могут изменять её как захотят — и при выполнении этих действий не получают предупреждений.

Снять защиту от записи с презентации можно с помощью метода [removeWriteProtection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Этот пример кода демонстрирует, как снять защиту от записи с презентации:

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

## **Получение свойств зашифрованной презентации**

Обычно пользователи испытывают трудности с получением свойств документа зашифрованной или защищённой паролем презентации. Однако Aspose.Slides предоставляет механизм, позволяющий защитить презентацию паролем, сохранив при этом возможность доступа к её свойствам.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства документа презентации также защищаются паролем. Если необходимо оставить свойства документа доступными даже после шифрования, Aspose.Slides позволяет сделать именно это.

Если вы хотите, чтобы пользователи могли получать доступ к свойствам зашифрованной презентации, передайте `false` в [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Этот пример кода демонстрирует, как зашифровать презентацию, одновременно предоставляя пользователям доступ к её свойствам документа:

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

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/) и передайте `true` в [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). В этом режиме Aspose.Slides игнорирует пароль и загружает только свойства документа, доступные публично.

Следующий пример кода считывает встроенные и пользовательские свойства документа через [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Чтение встроенных свойств документа.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Чтение пользовательских свойств документа.
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

Этот процесс работает только если свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, передача `true` в [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) вызывает исключение, поскольку в этом режиме пароль игнорируется. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая её слайды и прочее содержимое, укажите правильный пароль через [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword).

## **Проверка, защищена ли презентация паролем**

Перед загрузкой презентации вы можете захотеть проверить и убедиться, что она не защищена паролем. Это позволит избежать ошибок и подобных проблем, возникающих при загрузке защищённой паролем презентации без ввода пароля.

Этот PHP‑код демонстрирует, как проверить презентацию на наличие защиты паролем (без её загрузки):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этого вы можете использовать метод [isEncrypted](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isEncrypted), который возвращает `true`, если презентация зашифрована, и `false`, если она не зашифрована.

Этот пример кода демонстрирует, как проверить, зашифрована ли презентация:

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

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этого вы можете использовать метод [isWriteProtected](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isWriteProtected), который возвращает `true`, если презентация защищена, и `false`, если она не защищена.

Этот пример кода демонстрирует, как проверить, защищена ли презентация от записи:

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

## **Проверка или подтверждение использования конкретного пароля**

Возможно, вам потребуется проверить и убедиться, что для защиты документа презентации был использован конкретный пароль. Aspose.Slides предоставляет возможность проверить пароль. 

Этот пример кода демонстрирует, как проверить пароль:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # проверить, совпадает ли пароль
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Он возвращает `true`, если презентация зашифрована указанным паролем. В противном случае возвращает `false`. 

{{% alert color="primary" title="See also" %}} 
- [Цифровая подпись в PowerPoint](/slides/ru/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на базе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию введён неправильный пароль?**

Если используется неверный пароль, генерируется исключение, сообщающее, что доступ к презентации отклонён. Это помогает предотвратить неавторизованный доступ и защищает содержимое презентации.

**Есть ли влияние на производительность при работе с защищёнными паролем презентациями?**

Процесс шифрования и расшифрования может добавить небольшие накладные расходы при открытии и сохранении. В большинстве случаев влияние на производительность минимально и незначительно сказывается на общем времени выполнения задач с презентациями.