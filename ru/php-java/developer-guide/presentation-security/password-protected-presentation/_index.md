---
title: Презентация с защитой паролем
type: docs
weight: 20
url: /ru/php-java/password-protected-presentation/
keywords: "Защитить презентацию PowerPoint"
description: "Защитить презентацию PowerPoint. Презентация с защитой паролем"
---

## **О защите паролем**
### **Как работает защита паролем для презентаций?**
Когда вы защищаете презентацию паролем, это означает, что вы устанавливаете пароль, который накладывает определенные ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация с защитой паролем считается заблокированной.

Обычно вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Изменение**

  Если вы хотите, чтобы только определенные пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение препятствует людям в изменении, редактировании или копировании элементов в вашей презентации (если они не предоставят пароль).

  Однако в этом случае даже без пароля пользователь сможет получить доступ к вашему документу и открыть его. В этом режиме только для чтения пользователь может просматривать содержимое или элементы — гиперссылки, анимации, эффекты и другие — внутри вашей презентации, но он не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определенные пользователи могли открывать вашу презентацию, вы можете установить ограничение на открытие. Это ограничение препятствует людям даже в просмотре содержимого вашей презентации (если они не предоставят пароль).

  Технически ограничение на открытие также предотвращает возможность изменения ваших презентаций: когда люди не могут открыть презентацию, они не могут изменять или вносить в нее изменения.

  **Обратите внимание**, что когда вы защищаете презентацию паролем для предотвращения открытия, файл презентации становится зашифрованным.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на нашу страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Перетащите или загрузите ваши файлы**.

3. Выберите файл, который вы хотите защитить паролем на вашем компьютере. 

4. Введите предпочтительный пароль для защиты от редактирования; введите предпочтительный пароль для защиты от просмотра. 

5. Если вы хотите, чтобы пользователи видели вашу презентацию как финальную копию, отметьте чекбокс **Отметить как финальный**.

6. Нажмите **ЗАЩИЩАТЬ СЕЙЧАС.** 

7. Нажмите **СКАЧАТЬ СЕЙЧАС.**

## **Защита паролем для презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций в этих форматах: 

- PPTX и PPT - Презентация Microsoft PowerPoint 
- ODP - Презентация OpenDocument 
- OTP - Шаблон презентации OpenDocument 

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем на презентациях, чтобы предотвратить изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием следующими способами:

- Дешифрование презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен предоставить пароль. 

Чтобы зашифровать или защитить презентацию паролем, вы должны использовать метод шифрования (из [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)), чтобы установить пароль для презентации. Вы передаете пароль в метод шифрования и используете метод сохранения, чтобы сохранить теперь зашифрованную презентацию.

Этот пример кода показывает, как зашифровать презентацию:

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

Вы можете добавить отметку с надписью «Не изменять» к презентации. Таким образом, вы можете сообщить пользователям, что не хотите, чтобы они вносили изменения в презентацию.  

**Обратите внимание**, что процесс защиты от записи не шифрует презентацию. Следовательно, пользователи — если они действительно этого хотят — могут изменять презентацию, но чтобы сохранить изменения, им придется создать презентацию с другим именем. 

Чтобы установить защиту от записи, вы должны использовать метод [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Этот пример кода показывает, как установить защиту от записи для презентации:

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

## **Дешифрование презентации; Открытие зашифрованной презентации**

Aspose.Slides позволяет загружать зашифрованный файл, указывая его пароль. Чтобы дешифровать презентацию, вы должны вызвать метод [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) без параметров. Затем вам нужно будет ввести правильный пароль, чтобы загрузить презентацию.

Этот пример кода показывает, как дешифровать презентацию: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # работа с дешифрованной презентацией
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Удаление шифрования; Отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем с презентации. Таким образом, пользователи смогут получить доступ к презентации или изменять ее без ограничений. 

Чтобы удалить шифрование или защиту паролем, вам нужно вызвать метод [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--). Этот пример кода показывает, как удалить шифрование с презентации:

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

## **Удаление защиты от записи с презентации**

Вы можете использовать Aspose.Slides для удаления защиты от записи с файла презентации. Таким образом, пользователи смогут изменять по своему усмотрению — и они не получат никаких предупреждений при выполнении таких действий.

Вы можете удалить защиту от записи с презентации, используя метод [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--). Этот пример кода показывает, как удалить защиту от записи с презентации:

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

Обычно пользователи сталкиваются с трудностями при получении свойств документа зашифрованной или защищенной паролем презентации. Однако Aspose.Slides предлагает механизм, который позволяет вам защищать презентацию паролем, сохраняя при этом средства для доступа пользователей к свойствам этой презентации.

**Обратите внимание**, что когда Aspose.Slides шифрует презентацию, свойства документа презентации также имеют защиту паролем по умолчанию. Но если вам необходимо сделать свойства презентации доступными (даже после того, как презентация зашифрована), Aspose.Slides позволяет вам сделать именно это. 

Если вы хотите, чтобы пользователи сохранили возможность доступа к свойствам презентации, которую вы зашифровали, вы можете установить свойство [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) в значение `true`. Этот пример кода показывает, как зашифровать презентацию, предоставляя пользователям возможность доступа к ее свойствам документа:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Проверка, защищена ли презентация паролем перед загрузкой**

Перед загрузкой презентации вы можете захотеть проверить и подтвердить, что презентация не защищена паролем. Таким образом, вы сможете избежать ошибок и подобных проблем, которые возникают, когда защищенная паролем презентация загружается без пароля.

Этот PHP код показывает, как проверить презентацию, чтобы узнать, защищена ли она паролем (без загрузки самой презентации):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("Презентация защищена паролем: " . $presentationInfo->isPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Чтобы выполнить эту задачу, вы можете использовать свойство [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, или `false`, если презентация не зашифрована.

Этот пример кода показывает, как проверить, зашифрована ли презентация:

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

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Чтобы выполнить эту задачу, вы можете использовать свойство [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, или `false`, если презентация не защищена от записи.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

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

## **Проверка или подтверждение, что для защиты презентации использован конкретный пароль**

Вы можете проверить и подтвердить, что для защиты документа-презентации использован конкретный пароль. Aspose.Slides предоставляет средства для валидации пароля. 

Этот пример кода показывает, как проверить пароль:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # проверьте, соответствует ли "pass" 
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Он вернет `true`, если презентация была зашифрована с указанным паролем. В противном случае он вернет `false`. 

{{% alert color="primary" title="Смотрите также" %}} 
- [Цифровая подпись в PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}