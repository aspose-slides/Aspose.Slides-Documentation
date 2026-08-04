---
title: Защита презентаций паролем на Android
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/androidjava/password-protected-presentation/
keywords:
- заблокировать PowerPoint
- заблокировать презентацию
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
- снять защиту
- удалить шифрование
- отключить пароль
- отключить защиту
- снять защиту от записи
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Без труда блокируйте и разблокируйте презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для Android на Java. Защитите свои презентации."
---
## **Введение**

Когда вы защищаете презентацию паролем, вы задаёте пароль, который накладывает определённые ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной.

Обычно вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Изменение**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете задать ограничение на изменение. Это ограничение не позволяет людям изменять, менять или копировать содержимое вашей презентации (если только они не введут пароль).

  Однако в этом случае, даже без пароля, пользователь сможет открыть документ. В режиме только для чтения пользователь может просматривать содержимое — гиперссылки, анимацию, эффекты и другие элементы — но не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открывать вашу презентацию, вы можете задать ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое вашей презентации (если только они не введут пароль).

  Технически ограничение на открытие также не позволяет пользователям изменять ваши презентации: когда люди не могут открыть презентацию, они не могут вносить в неё изменения.

  **Примечание**: когда вы защищаете презентацию паролем, чтобы предотвратить её открытие, файл презентации шифруется.

## **Защита паролем для презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций следующих форматов:

- PPTX и PPT — Microsoft PowerPoint Presentation
- ODP — OpenDocument Presentation
- OTP — OpenDocument Presentation Template

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для предотвращения изменения презентаций следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Снятие шифрования; отключение защиты паролем
- Снятие защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, задав пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен ввести пароль.

Чтобы зашифровать или защитить паролем презентацию, необходимо использовать метод `encrypt` из [IProtectionManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager) для установки пароля презентации. Вы передаёте пароль в метод `encrypt` и используете метод `save` для сохранения уже зашифрованной презентации.

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

Вы можете добавить отметку «Не изменять» к презентации. Таким образом вы информируете пользователей, что не хотите, чтобы они вносили изменения в презентацию.

**Примечание**: процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменить презентацию, но чтобы сохранить изменения, им придётся сохранить её под другим именем.

Чтобы установить защиту от записи, необходимо использовать метод [setWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Этот пример кода показывает, как установить защиту от записи для презентации:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Загрузка зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) без параметров. Затем вам придётся ввести правильный пароль для загрузки презентации.

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

## **Снятие шифрования с презентации**

Вы можете снять шифрование или защиту паролем с презентации. После этого пользователи смогут получить доступ к презентации или изменять её без ограничений.

Чтобы снять шифрование или защиту паролем, необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Этот пример кода показывает, как снять шифрование с презентации:

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

## **Снятие защиты от записи с презентации**

Вы можете использовать Aspose.Slides для снятия защиты от записи с файла презентации. После этого пользователи могут изменять её как угодно и не получают предупреждений при выполнении таких действий.

Вы можете снять защиту от записи с презентации, используя метод [removeWriteProtection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Этот пример кода показывает, как снять защиту от записи с презентации:

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

Обычно пользователям сложно получить свойства документа зашифрованной или защищённой паролем презентации. Тем не менее, Aspose.Slides предлагает механизм, позволяющий защитить презентацию паролем, одновременно сохраняющего возможность доступа к её свойствам.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства документа презентации также защищаются паролем. Если вам нужно, чтобы свойства документа оставались доступными даже после шифрования, Aspose.Slides позволяет сделать именно это.

Если вы хотите, чтобы пользователи могли по‑прежнему получать доступ к свойствам зашифрованной презентации, передайте `false` в [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Этот пример кода показывает, как зашифровать презентацию, одновременно предоставив пользователям доступ к её свойствам:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/) и передайте `true` в [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). В этом режиме Aspose.Slides игнорирует пароль и загружает только публично доступные свойства документа.

Следующий пример кода читает встроенные и пользовательские свойства документа через [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Чтение встроенных свойств документа.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Чтение пользовательских свойств документа.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Этот сценарий работает только тогда, когда свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, передача `true` в `loadOptions.setOnlyLoadDocumentProperties` приводит к исключению, поскольку пароль в этом режиме игнорируется. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая её слайды и другое содержимое, укажите правильный пароль через [ILoadOptions.setPassword](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Проверка, защищена ли презентация паролем**

Перед тем как загрузить презентацию, вы можете проверить, защищена ли она паролем. Это позволяет избежать ошибок и подобных проблем, которые возникают при попытке загрузить защищённую паролем презентацию без пароля.

Этот код на Java показывает, как проверить презентацию на наличие защиты паролем (без загрузки самой презентации):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этой задачи вы можете использовать свойство [isEncrypted](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, и `false`, если нет.

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

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этой задачи вы можете использовать свойство [isWriteProtected](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, и `false`, если нет.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Проверка или подтверждение использования конкретного пароля**

Вам может потребоваться проверить и подтвердить, что для защиты документа презентации использовался конкретный пароль. Aspose.Slides предоставляет средства для проверки пароля.

Этот пример кода показывает, как проверить пароль:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // проверить, совпадает ли "pass" с
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Он возвращает `true`, если презентация была зашифрована указанным паролем. В противном случае возвращается `false`.

{{% alert color="primary" title="Смотрите также" %}} 
- [Цифровая подпись в PowerPoint](/slides/ru/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на базе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию ввести неверный пароль?**

Если используется неверный пароль, выбрасывается исключение, сообщающее, что доступ к презентации отклонён. Это помогает предотвратить несанкционированный доступ и защищает содержимое презентации.

**Есть ли какие‑либо последствия для производительности при работе с защищёнными паролем презентациями?**

Процессы шифрования и расшифрования могут добавить небольшую нагрузку во время открытия и сохранения файлов. В большинстве случаев влияние на производительность минимально и незначительно сказывается на общем времени выполнения задач с презентациями.