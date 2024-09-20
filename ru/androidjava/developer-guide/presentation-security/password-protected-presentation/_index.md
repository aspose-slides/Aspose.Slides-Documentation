---
title: Защищенная паролем презентация
type: docs
weight: 20
url: /androidjava/password-protected-presentation/
keywords: "Заблокировать презентацию PowerPoint в Java"
description: "Заблокировать презентацию PowerPoint. Защищенная паролем презентация PowerPoint в Java"
---

## **О защите паролем**
### **Как работает защита паролем для презентации?**
Когда вы защищаете презентацию паролем, это означает, что вы устанавливаете пароль, который вводит определенные ограничения на презентацию. Чтобы убрать ограничения, необходимо ввести пароль. Презентация, защищенная паролем, считается заблокированной.

Обычно вы можете установить пароль для применения этих ограничений к презентации:

- **Модификация**

  Если вы хотите, чтобы только определенные пользователи могли изменять вашу презентацию, вы можете установить ограничение на модификацию. Это ограничение предотвращает возможность изменения, изменения или копирования элементов в вашей презентации (если они не предоставят пароль).

  Однако в этом случае даже без пароля пользователь сможет получить доступ к вашему документу и открыть его. В этом режиме только для чтения пользователь может просматривать содержимое или объекты—гиперссылки, анимации, эффекты и другие—внутри вашей презентации, но не сможет копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определенные пользователи могли открывать вашу презентацию, вы можете установить ограничение на открытие. Это ограничение предотвращает возможность даже просмотра содержимого вашей презентации (если они не предоставят пароль).

  С технической точки зрения, ограничение на открытие также предотвращает модификацию вашей презентации: когда люди не могут открыть презентацию, они не могут изменить или модифицировать её.

  **Примечание**: когда вы защищаете презентацию паролем для предотвращения открытия, файл презентации становится зашифрованным.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на нашу [**страницу Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Перетащите или загрузите ваши файлы**.

3. Выберите файл, который вы хотите защитить паролем на своем компьютере.

4. Введите предпочитаемый пароль для защиты от редактирования; введите предпочитаемый пароль для защиты от просмотра.

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, отметьте чекбокс **Обозначить как окончательную**.

6. Нажмите **ЗАЩИТИТЬ СЕЙЧАС.**

7. Нажмите **СКАЧАТЬ СЕЙЧАС.**

## **Защита паролем для презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций в следующих форматах:

- PPTX и PPT - Презентация Microsoft PowerPoint
- ODP - Презентация OpenDocument
- OTP - Шаблон презентации OpenDocument

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для презентаций, чтобы предотвратить модификацию следующими способами:

- Шифрование презентации
- Установить защиту от записи на презентацию

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Дешифрование презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователю придется предоставить пароль.

Чтобы зашифровать или защитить презентацию паролем, вы должны использовать метод шифрования (из [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)), чтобы установить пароль для презентации. Вы передаете пароль методу шифрования и используете метод сохранения, чтобы сохранить теперь зашифрованную презентацию.

Этот образец кода показывает вам, как зашифровать презентацию:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Установка защиты от записи на презентацию**

Вы можете добавить пометку с надписью «Не модифицировать» к презентации. Таким образом, вы даете понять пользователям, что не хотите, чтобы они вносили изменения в презентацию.

**Примечание**: процесс защиты от записи не шифрует презентацию. Поэтому пользователи—если они действительно захотят—могут изменить презентацию, но чтобы сохранить изменения, им придется создать презентацию с другим именем.

Чтобы установить защиту от записи, вы должны использовать метод [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Этот образец кода показывает вам, как установить защиту от записи для презентации:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Дешифрование презентации; Открытие зашифрованной презентации**

Aspose.Slides позволяет вам загружать зашифрованный файл, указав его пароль. Чтобы дешифровать презентацию, вам нужно вызвать метод [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) без параметров. Вам затем придется ввести правильный пароль, чтобы загрузить презентацию.

Этот образец кода показывает вам, как дешифровать презентацию:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // работа с дешифрованной презентацией
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Удаление шифрования; Отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем с презентации. Таким образом, пользователи смогут получить доступ или изменить презентацию без ограничений.

Чтобы удалить шифрование или защиту паролем, вам нужно вызвать метод [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) метод. Этот образец кода показывает вам, как удалить шифрование с презентации:

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

Вы можете использовать Aspose.Slides для удаления защиты от записи, используемой на файле презентации. Таким образом, пользователи могут изменять по своему усмотрению—и они не получают предупреждений, когда выполняют такие задачи.

Вы можете удалить защиту от записи с презентации, используя метод [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) метод. Этот образец кода показывает вам, как удалить защиту от записи с презентации:

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

Как правило, пользователи испытывают трудности с получением свойств документа зашифрованной или защищенной паролем презентации. Однако Aspose.Slides предлагает механизм, который позволяет вам защищать презентацию паролем, сохраняя при этом возможность для пользователей получить доступ к свойствам этой презентации.

**Примечание**: когда Aspose.Slides шифрует презентацию, свойства документа презентации по умолчанию также защищены паролем. Но если вам нужно сделать свойства презентации доступными (даже после того, как презентация была зашифрована), Aspose.Slides позволяет вам сделать именно это.

Если вы хотите, чтобы пользователи сохранили возможность доступа к свойствам презентации, которую вы зашифровали, вы можете установить свойство [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) в `true`. Этот образец кода показывает вам, как зашифровать презентацию, предоставляя пользователям возможность доступа к ее свойствам документа:

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

Прежде чем загружать презентацию, вы можете захотеть проверить и подтвердить, что презентация не защищена паролем. Таким образом, вы можете избежать ошибок и подобных проблем, которые возникают, когда защищенную паролем презентацию загружают без её пароля.

Этот Java-код показывает вам, как проверить презентацию на наличие защиты паролем (без загрузки самой презентации):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("Презентация защищена паролем: " + presentationInfo.isPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет вам проверить, зашифрована ли презентация. Чтобы выполнить эту задачу, вы можете использовать свойство [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, или `false`, если презентация не зашифрована.

Этот образец кода показывает вам, как проверить, зашифрована ли презентация:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет вам проверить, защищена ли презентация от записи. Чтобы выполнить эту задачу, вы можете использовать свойство [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, или `false`, если презентация не защищена от записи.

Этот образец кода показывает вам, как проверить, защищена ли презентация от записи:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Подтверждение или проверка, использовался ли конкретный пароль для защиты презентации**

Вы можете захотеть проверить и подтвердить, что конкретный пароль использовался для защиты документа презентации. Aspose.Slides предоставляет средства для валидации пароля.

Этот образец кода показывает вам, как подтвердить пароль:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // проверьте, совпадает ли "pass" с
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Возвращает `true`, если презентация была зашифрована с указанным паролем. В противном случае возвращает `false`.

{{% alert color="primary" title="См. также" %}} 
- [Цифровая подпись в PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}