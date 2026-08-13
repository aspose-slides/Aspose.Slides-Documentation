---
title: Защищённые паролем презентации в .NET
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/net/password-protected-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как легко блокировать и разблокировать защищённые паролем презентации PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Обеспечьте безопасность ваших презентаций."
---
## **Введение**

Когда вы устанавливаете пароль на презентацию, вы задаёте пароль, который накладывает определённые ограничения на её использование. Чтобы снять эти ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Обычно вы можете задать пароль, чтобы наложить такие ограничения на презентацию:

- **Модификация**

Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на модификацию. Это ограничение не позволяет людям изменять, менять или копировать элементы в вашей презентации без ввода пароля.  

Однако даже без пароля пользователь всё равно сможет открыть ваш документ. В режиме только для чтения пользователь может просматривать содержимое — включая гиперссылки, анимацию, эффекты и другие элементы — но не может копировать элементы или сохранять презентацию.

- **Открытие**

Если вы хотите, чтобы только определённые пользователи могли открывать вашу презентацию, вы можете установить ограничение на открытие. Это ограничение не позволяет людям даже просматривать содержимое презентации без ввода пароля.

Технически ограничение на открытие также препятствует модификации презентаций — если пользователь не может открыть презентацию, он не может её изменить.

**Примечание:** Когда вы защищаете презентацию паролем, чтобы запретить её открытие, файл презентации становится зашифрованным.

## **Защита паролем в Aspose.Slides**

**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и аналогичные операции для презентаций следующих форматов:

- PPTX и PPT — презентации Microsoft PowerPoint
- ODP — презентации OpenDocument
- OTP — шаблоны презентаций OpenDocument

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для предотвращения изменений презентации следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять дополнительные задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Снятие шифрования; отключение защиты паролем
- Снятие защиты от записи с презентации
- Получение свойств зашифрованной презентации
- Проверка, защищена ли презентация паролем, перед её загрузкой
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем

## **Защита презентации паролем**

Вы можете зашифровать презентацию, задав пароль. Затем, чтобы изменить заблокированную презентацию, пользователь должен ввести пароль.

Чтобы зашифровать (или защитить паролем) презентацию, используйте метод `Encrypt` из [ProtectionManager](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager) и передайте пароль в метод `Encrypt`, а затем вызовите метод `Save`, чтобы сохранить теперь зашифрованную презентацию.

Пример кода, показывающий, как зашифровать презентацию:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Установка защиты от записи для презентации** 

Вы можете добавить пометку «Не изменять» к презентации. Это информирует пользователей о том, что вы не хотите, чтобы они вносили изменения.

**Примечание:** Процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если захотят — могут изменить её, но для сохранения изменений им придётся сохранять файл под другим именем.

Чтобы установить защиту от записи, используйте метод `SetWriteProtection`. Пример кода, показывающий, как установить защиту от записи для презентации:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Загрузка зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованную презентацию, передав правильный пароль. Пример кода, показывающий, как загрузить зашифрованную презентацию:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Работайте с расшифрованной презентацией.
}
```

## **Снятие шифрования с презентации**

Вы можете снять шифрование или защиту паролем с презентации, позволяя пользователям получать к ней доступ или изменять её без ограничений.

Чтобы снять шифрование или защиту паролем, вызовите метод [RemoveEncryption](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/methods/removeencryption). Пример кода, показывающий, как снять шифрование с презентации:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Снятие защиты от записи с презентации**

Вы можете использовать Aspose.Slides для снятия защиты от записи с файла презентации. Таким образом, пользователи смогут изменять её как захотят — и не получат предупреждений при выполнении таких действий.

Снять защиту от записи можно с помощью метода [RemoveWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/methods/removewriteprotection). Пример кода, показывающий, как снять защиту от записи с презентации:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Получение свойств зашифрованной презентации**

Как правило, пользователям трудно получить свойства документа зашифрованной или защищённой паролем презентации. Однако Aspose.Slides предлагает механизм, позволяющий защитить презентацию паролем и одновременно сохранять возможность доступа к её свойствам.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства её документа также защищаются паролем. Если вам нужно, чтобы свойства документа были доступны даже после шифрования, Aspose.Slides позволяет это сделать.

Если вы хотите, чтобы пользователи могли по‑прежнему получать доступ к свойствам зашифрованной презентации, установите свойство `EncryptDocumentProperties` интерфейса [IProtectionManager](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/) в `false`. Пример кода, показывающий, как зашифровать презентацию, оставив свойства документа доступными:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/) и установите [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) в `true`. В этом режиме Aspose.Slides игнорирует пароль и загружает только публично доступные свойства документа.

Следующий пример кода читает встроенные и пользовательские свойства документа через [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Этот сценарий работает только тогда, когда свойства документа были оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, установка `OnlyLoadDocumentProperties` в `true` вызывает исключение, поскольку пароль в этом режиме игнорируется. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая слайды и другое содержимое, укажите правильное значение `Password` в [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/).

## **Проверка, защищена ли презентация паролем**

Перед загрузкой презентации вы можете проверить, не защищена ли она паролем. Это поможет избежать ошибок и аналогичных проблем, возникающих при загрузке защищённой паролем презентации без правильного пароля.

Этот код на C# показывает, как проверить презентацию на наличие паролевой защиты без её полной загрузки:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этой задачи используйте свойство [IsEncrypted](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/properties/isencrypted), которое возвращает `true`, если презентация зашифрована, и `false`, если нет.

Пример кода, показывающий, как проверить, зашифрована ли презентация:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этой задачи используйте свойство [IsWriteProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/properties/iswriteprotected), которое возвращает `true`, если презентация защищена от записи, и `false`, если нет.

Пример кода, показывающий, как проверить, защищена ли презентация от записи:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Проверка использования пароля презентации**

Возможно, вам понадобится убедиться, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет возможность проверить пароль.

Пример кода, показывающий, как проверить пароль:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Проверьте, соответствует ли пароль.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Метод возвращает `true`, если презентация была зашифрована указанным паролем; в противном случае — `false`.

{{% alert color="info" title="См. также" %}} 
- [Digital Signature in PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Перейдите на страницу нашего [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock). 
2. Нажмите **Drop or upload your files**.  
3. Выберите файл, который хотите защитить паролем, на вашем компьютере.  
4. Введите желаемый пароль для защиты редактирования и пароль для защиты просмотра.  
5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательный вариант, установите флажок **Mark as final**.  
6. Нажмите **PROTECT NOW.**  
7. Нажмите **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на основе AES, обеспечивая высокий уровень безопасности данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию ввести неверный пароль?**

Выбрасывается исключение, сообщающее, что доступ к презентации отклонён. Это помогает предотвратить несанкционированный доступ и защищает содержимое презентации.

**Есть ли влияние на производительность при работе с презентациями, защищёнными паролем?**

Процессы шифрования и дешифрования могут добавить небольшие задержки при открытии и сохранении файлов. В большинстве случаев влияние на производительность минимально и не существенно сказывается на общем времени обработки ваших задач.