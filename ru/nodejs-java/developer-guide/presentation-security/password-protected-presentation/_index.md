---
title: Защита презентаций паролем в JavaScript
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/nodejs-java/password-protected-presentation/
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
- удалить защиту от записи
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Легко блокировать и разблокировать презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для Node.js через Java. Защитите свои презентации."
---
## **Введение**

Когда вы защищаете презентацию паролем, это означает, что вы задаёте пароль, который накладывает определённые ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Обычно вы можете задать пароль, чтобы применить эти ограничения к презентации:

- **Изменение**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение не позволяет людям вносить изменения, менять или копировать элементы вашей презентации (если только они не предоставят пароль).

  Тем не менее, в этом случае пользователь сможет получить доступ к вашему документу и открыть его даже без пароля. В режиме только для чтения пользователь может просматривать содержимое и элементы — гиперссылки, анимации, эффекты и другие — внутри вашей презентации, но он не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое вашей презентации (если только они не предоставят пароль).

  Технически ограничение на открытие также препятствует пользователям изменять презентацию: если люди не могут открыть презентацию, они не могут вносить изменения или правки в неё.  

  **Примечание**: когда вы защищаете презентацию паролем, чтобы предотвратить её открытие, файл презентации становится зашифрованным.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на страницу нашего [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock)page. 

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Drop or upload your files**.

3. Выберите файл, который вы хотите защитить паролем, на вашем компьютере. 

4. Введите ваш пароль для защиты редактирования; введите ваш пароль для защиты просмотра. 

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, отметьте флажок **Mark as final**.

6. Нажмите **PROTECT NOW.** 

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций в следующих форматах: 

- PPTX и PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для презентаций, чтобы предотвратить изменения следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи у презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, задав пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен ввести пароль.

Чтобы зашифровать или защитить презентацию паролем, вам нужно использовать метод encrypt (из [ProtectionManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager)) для установки пароля презентации. Вы передаёте пароль в метод encrypt и используете метод save, чтобы сохранить теперь зашифрованную презентацию.

Этот пример кода показывает, как зашифровать презентацию:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Установка защиты от записи для презентации**

Вы можете добавить пометку «Do not modify» к презентации. Таким образом, вы сообщаете пользователям, что не хотите, чтобы они вносили изменения в презентацию.  

**Примечание**: процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они действительно захотят — могут изменить презентацию, но чтобы сохранить изменения, им придётся создать презентацию с другим именем. 

Чтобы установить защиту от записи, вам нужно использовать метод [setWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Этот пример кода показывает, как установить защиту от записи для презентации:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Расшифровка презентации; открытие зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) без параметров. Затем вам потребуется ввести правильный пароль для загрузки презентации.

Этот пример кода показывает, как расшифровать презентацию: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // работать с расшифрованной презентацией
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Удаление шифрования; отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем у презентации. Таким образом, пользователи смогут получить доступ к презентации или изменить её без ограничений. 

Чтобы удалить шифрование или защиту паролем, необходимо вызвать метод [removeEncryption](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Этот пример кода показывает, как удалить шифрование из презентации:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Удаление защиты от записи у презентации**

Вы можете использовать Aspose.Slides для удаления защиты от записи, применённой к файлу презентации. Таким образом, пользователи могут вносить изменения по своему усмотрению — и при этом не получают предупреждений.

Вы можете удалить защиту от записи у презентации, используя метод [removeWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Этот пример кода показывает, как удалить защиту от записи у презентации:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Получение свойств зашифрованной презентации**

Обычно пользователям сложно получить свойства документа зашифрованной или защищённой паролем презентации. Однако Aspose.Slides предоставляет механизм, позволяющий защищать презентацию паролем, при этом сохранять возможность доступа пользователей к её свойствам.  

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства документа презентации также защищаются паролем. Если вам необходимо, чтобы свойства документа оставались доступными даже после шифрования, Aspose.Slides позволяет именно это сделать.  

Если вы хотите, чтобы пользователи сохраняли возможность доступа к свойствам зашифрованной презентации, передайте `false` в метод `setEncryptDocumentProperties` объекта [ProtectionManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/). Этот пример кода показывает, как зашифровать презентацию, одновременно предоставляя пользователям доступ к её свойствам документа:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/) и передайте `true` в `setOnlyLoadDocumentProperties`. В этом режиме Aspose.Slides игнорирует пароль и загружает только свойства документа, которые доступны публично.  

Следующий пример кода читает встроенные и пользовательские свойства документа с помощью `getDocumentProperties` у [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Читать встроенные свойства документа.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Читать пользовательские свойства документа.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Этот процесс работает только тогда, когда свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, передача `true` в `LoadOptions.setOnlyLoadDocumentProperties` вызывает исключение, поскольку пароль игнорируется в этом режиме. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая её слайды и другое содержимое, укажите правильный пароль через `LoadOptions.setPassword` у [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/).

## **Проверка, защищена ли презентация паролем, перед её загрузкой**

Перед тем как загрузить презентацию, вы можете захотеть проверить и убедиться, что презентация не защищена паролем. Это позволяет избежать ошибок и подобных проблем, возникающих при загрузке защищённой паролем презентации без пароля.  

Этот JavaScript‑код показывает, как проверить презентацию на наличие пароля (без загрузки самой презентации):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этой задачи можно использовать свойство [isEncrypted](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, или `false`, если презентация не зашифрована.  

Этот пример кода показывает, как проверить, зашифрована ли презентация:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этой задачи можно использовать свойство [isWriteProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, и `false`, если она не защищена.  

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Проверка или подтверждение, что конкретный пароль использовался для защиты презентации**

Возможно, вам понадобится проверить и подтвердить, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет возможность проверить пароль.  

Этот пример кода показывает, как проверить пароль:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // проверить, совпадает ли "pass"
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Он возвращает `true`, если презентация была зашифрована указанным паролем. В противном случае возвращает `false`.  

{{% alert color="primary" title="Смотрите также" %}} 
- [Digital Signature in PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на основе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию введён неверный пароль?**

Если используется неверный пароль, генерируется исключение, уведомляющее о том, что доступ к презентации отказан. Это помогает предотвратить несанкционированный доступ и защищает содержание презентации.

**Есть ли какие‑либо влияния на производительность при работе с защищёнными паролем презентациями?**

Процесс шифрования и дешифрования может добавить небольшие накладные расходы при открытии и сохранении файлов. В большинстве случаев влияние на производительность минимально и существенно не влияет на общее время обработки задач с презентациями.