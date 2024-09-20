---
title: Защищенная паролем презентация
type: docs
weight: 20
url: /java/password-protected-presentation/
keywords: "Заблокировать презентацию PowerPoint на Java"
description: "Заблокировать презентацию PowerPoint. Презентация PowerPoint с защитой паролем на Java"
---

## **О защите паролем**
### **Как работает защита паролем для презентации?**
Когда вы защищаете презентацию паролем, это означает, что вы устанавливаете пароль, который налагает определенные ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Защищенная паролем презентация считается заблокированной презентацией.

Обычно вы можете установить пароль для наложения этих ограничений на презентацию:

- **Изменение**

  Если вы хотите, чтобы только определенные пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение предотвращает модификацию, изменение или копирование материалов вашей презентации (если они не предоставят пароль).

  Однако в этом случае даже без пароля пользователь сможет получить доступ к вашему документу и открыть его. В этом режиме только для чтения пользователь может просматривать содержимое или объекты – гиперссылки, анимации, эффекты и другие – внутри вашей презентации, но они не могут копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определенные пользователи могли открывать вашу презентацию, вы можете установить ограничение на открытие. Это ограничение предотвращает возможность просмотра содержимого вашей презентации (если они не предоставят пароль).

  Технически, ограничение на открытие также предотвращает возможность изменения ваших презентаций: когда люди не могут открыть презентацию, они не могут изменить или внести в нее изменения.

  **Замечание**: когда вы защищаете презентацию паролем, чтобы предотвратить открытие, файл презентации становится зашифрованным.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на нашу страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Перетащите или загрузите ваши файлы**.

3. Выберите файл, который вы хотите защитить паролем на вашем компьютере.

4. Введите предпочтительный пароль для защиты редактирования; Введите предпочтительный пароль для защиты просмотра.

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, установите флажок **Обозначить как окончательную**.

6. Нажмите **ЗАЩИТИТЬ СЕЙЧАС.**

7. Нажмите **СКАЧАТЬ СЕЙЧАС.**

## **Защита паролем для презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и подобные операции для презентаций в этих форматах:

- PPTX и PPT - Презентация Microsoft PowerPoint
- ODP - Презентация OpenDocument
- OTP - Шаблон презентации OpenDocument

**Поддерживаемые операции**

Aspose.Slides позволяет вам использовать защиту паролем для презентаций, чтобы предотвратить изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет вам выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен предоставить пароль.

Чтобы зашифровать или защитить презентацию паролем, вы должны использовать метод шифрования (из [IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)), чтобы установить пароль для презентации. Вы передаете пароль методу шифрования и используете метод сохранения для сохранения теперь зашифрованной презентации.

Этот пример кода показывает, как зашифровать презентацию:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Установка защиты от записи для презентации**

Вы можете добавить отметку, указывающую "Не изменять", к презентации. Таким образом, вы сообщаете пользователям, что не хотите, чтобы они вносили изменения в презентацию.

**Замечание**: процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменить презентацию, но для сохранения изменений им придется создать презентацию с другим именем.

Чтобы установить защиту от записи, вы должны использовать метод [setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Этот пример кода показывает, как установить защиту от записи для презентации:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Расшифровка презентации; Открытие зашифрованной презентации**

Aspose.Slides позволяет вам загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, вам нужно вызвать метод [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) без параметров. Вам придется ввести правильный пароль, чтобы загрузить презентацию.

Этот пример кода показывает, как расшифровать презентацию:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // работа с расшифрованной презентацией
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Удаление шифрования; Отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем с презентации. Таким образом, пользователи могут получить доступ или изменять презентацию без ограничений.

Чтобы удалить шифрование или защиту паролем, вам нужно вызвать метод [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--). Этот пример кода показывает, как удалить шифрование с презентации:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Удаление защиты от записи с презентации**

Вы можете использовать Aspose.Slides для удаления защиты от записи, используемой на файле презентации. Таким образом, пользователи могут изменять по своему усмотрению — и им не будет выдаваться никаких предупреждений при выполнении таких действий.

Вы можете удалить защиту от записи с презентации, используя метод [removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--). Этот пример кода показывает, как удалить защиту от записи с презентации:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Получение свойств зашифрованной презентации**

Обычно пользователи сталкиваются с трудностями при получении свойств документа зашифрованной или защищенной паролем презентации. Aspose.Slides, однако, предлагает механизм, который позволяет вам защищать презентацию паролем, сохраняя при этом возможность для пользователей получать доступ к свойствам этой презентации.

**Замечание**: когда Aspose.Slides шифрует презентацию, свойства документа презентации также по умолчанию защищаются паролем. Но если вам нужно сделать свойства презентации доступными (даже после ее шифрования), Aspose.Slides позволяет сделать именно это.

Если вы хотите, чтобы пользователи могли получать доступ к свойствам презентации, которую вы зашифровали, вы можете установить свойство [encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) в `true`. Этот пример кода показывает, как зашифровать презентацию, предоставляя пользователям возможность получать доступ к ее свойствам документа:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Проверка, защищена ли презентация паролем, перед ее загрузкой**

Прежде чем загрузить презентацию, вы можете проверить и подтвердить, что презентация не защищена паролем. Таким образом, вы сможете избежать ошибок и подобных проблем, которые возникают, когда загружается защищенная паролем презентация без пароля.

Этот Java-код показывает, как проверить презентацию на наличие защиты паролем (без загрузки самой презентации):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("Презентация защищена паролем: " + presentationInfo.isPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет вам проверить, зашифрована ли презентация. Чтобы выполнить эту задачу, вы можете использовать свойство [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, или `false`, если презентация не зашифрована.

Этот пример кода показывает, как проверить, зашифрована ли презентация:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет вам проверить, защищена ли презентация от записи. Чтобы выполнить эту задачу, вы можете использовать свойство [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, или `false`, если презентация не защищена от записи.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isWriteProtected = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Проверка или подтверждение того, что для защиты презентации использован конкретный пароль**

Вы можете проверить и подтвердить, что для защиты документа презентации использован конкретный пароль. Aspose.Slides предоставляет средства для проверки пароля.

Этот пример кода показывает, как проверить пароль:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // проверить, соответствует ли "pass"
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Возвращает `true`, если презентация была зашифрована с указанным паролем. В противном случае возвращает `false`.

{{% alert color="primary" title="См. также" %}} 
- [Цифровая подпись в PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}