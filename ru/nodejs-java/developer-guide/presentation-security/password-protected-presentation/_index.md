---
title: Презентация с защитой паролем
type: docs
weight: 20
url: /ru/nodejs-java/password-protected-presentation/
keywords: "Блокировать презентацию PowerPoint в JavaScript"
description: "Блокировать презентацию PowerPoint. Защищённый паролем PowerPoint в JavaScript"
---

## **О защите паролем**
### **Как работает защита паролем для презентаций?**
Когда вы защищаете презентацию паролем, вы задаёте пароль, который накладывает определённые ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной.

Обычно вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Модификация**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на модификацию. Это ограничение предотвращает изменение, копирование или перемещение элементов в вашей презентации (если только не введён пароль).

  Однако в этом случае, даже без пароля, пользователь сможет открыть документ. В режиме только для чтения пользователь может просматривать содержимое — гиперссылки, анимацию, эффекты и прочее — но не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение запрещает просмотр содержимого презентации (если только не введён пароль).

  Технически ограничение на открытие также препятствует модификации презентации: если пользователь не может открыть презентацию, он не может её изменить.

  **Примечание** — когда вы защищаете презентацию паролем, чтобы запретить её открытие, файл презентации шифруется.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Drop or upload your files**.

3. Выберите файл, который хотите защитить паролем, на своём компьютере.

4. Введите желаемый пароль для защиты от изменения; введите желаемый пароль для защиты от просмотра.

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, отметьте чекбокс **Mark as final**.

6. Нажмите **PROTECT NOW.**

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем для презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций следующих форматов:

- PPTX и PPT — Microsoft PowerPoint Presentation
- ODP — OpenDocument Presentation
- OTP — OpenDocument Presentation Template

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для предотвращения модификаций презентаций следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять дополнительные задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Снятие защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, задав пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен предоставить пароль.

Чтобы зашифровать или защитить презентацию паролем, используйте метод encrypt (из [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager)) для установки пароля презентации. Передайте пароль в метод encrypt и используйте метод save для сохранения зашифрованной презентации.

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

Вы можете добавить отметку «Не изменять» к презентации. Таким образом вы уведомляете пользователей, что не хотите, чтобы они вносили изменения в презентацию.

**Примечание** — процесс установки защиты от записи не шифрует презентацию. Поэтому пользователи — если действительно захотят — могут изменить презентацию, но для сохранения изменений им придётся сохранить её под другим именем.

Для установки защиты от записи используйте метод [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Этот пример кода показывает, как установить защиту от записи для презентации:
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

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, вызовите метод [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) без параметров. Затем необходимо ввести правильный пароль для загрузки презентации.

Этот пример кода показывает, как расшифровать презентацию:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // работа с расшифрованной презентацией
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Удаление шифрования; отключение защиты паролем**

Вы можете удалить шифрование или защиту паролем с презентации. После этого пользователи смогут получить доступ к презентации или изменить её без ограничений.

Для удаления шифрования или защиты паролем вызовите метод [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Этот пример кода показывает, как удалить шифрование из презентации:
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


## **Снятие защиты от записи с презентации**

Вы можете использовать Aspose.Slides для снятия защиты от записи, установленной для файла презентации. После этого пользователи могут изменять её как захотят и не получат предупреждений при выполнении этих действий.

Для снятия защиты от записи используйте метод [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Этот пример кода показывает, как снять защиту от записи с презентации:
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

Обычно пользователям сложно получить свойства документа зашифрованной или защищённой паролем презентации. Aspose.Slides предлагает механизм, позволяющий защитить паролем презентацию и одновременно предоставить пользователям возможность доступа к её свойствам.

**Примечание** — когда Aspose.Slides шифрует презентацию, свойства её документа по умолчанию также защищаются паролем. Однако при необходимости сделать свойства презентации доступными (даже после шифрования), Aspose.Slides позволяет это сделать.

Если вы хотите, чтобы пользователи сохраняли возможность доступа к свойствам зашифрованной презентации, установите свойство [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) в `true`. Этот пример кода показывает, как зашифровать презентацию, предоставив пользователям доступ к её свойствам документа:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Проверка, защищена ли презентация паролем перед её загрузкой**

Перед загрузкой презентации вы можете проверить, не защищена ли она паролем. Это позволяет избежать ошибок и подобных проблем, возникающих при загрузке защищённой паролем презентации без соответствующего пароля.

Этот JavaScript‑код показывает, как проверить презентацию на наличие пароля (не загружая её полностью):
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для выполнения этой задачи используйте свойство [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--), которое возвращает `true`, если презентация зашифрована, и `false`, если нет.

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

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для выполнения этой задачи используйте свойство [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--), которое возвращает `true`, если презентация защищена от записи, и `false`, если нет.

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


## **Проверка, использован ли конкретный пароль для защиты презентации**

Вы можете проверить, был ли использован определённый пароль для защиты документа презентации. Aspose.Slides предоставляет средства для проверки пароля.

Этот пример кода показывает, как проверить пароль:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // проверьте, совпадает ли "pass" с
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Он возвращает `true`, если презентация зашифрована указанным паролем. В остальных случаях возвращает `false`.

{{% alert color="primary" title="См. также" %}} 
- [Цифровая подпись в PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на базе AES, обеспечивая высокий уровень безопасности данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию ввести неверный пароль?**

Выбрасывается исключение, указывающее, что доступ к презентации отклонён. Это помогает предотвратить неавторизованный доступ и защищает содержимое презентации.

**Есть ли влияние на производительность при работе с защищёнными паролем презентациями?**

Процессы шифрования и расшифрования могут добавить небольшие накладные расходы при открытии и сохранении файлов. В большинстве случаев это влияние минимально и несущественно сказывается на общей продолжительности обработки ваших задач.