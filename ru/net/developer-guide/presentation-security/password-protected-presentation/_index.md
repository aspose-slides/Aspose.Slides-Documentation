---
title: Защита презентаций паролями в .NET
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/net/password-protected-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как без труда блокировать и разблокировать презентации PowerPoint и OpenDocument, защищённые паролем, с помощью Aspose.Slides для .NET. Защитите свои презентации."
---
## **Введение**

Когда вы устанавливаете пароль на презентацию, вы задаёте пароль, который вводит определённые ограничения для презентации. Чтобы снять эти ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Обычно вы можете задать пароль, чтобы применить эти ограничения к презентации:

- **Изменение**

Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на изменение. Это ограничение препятствует людям изменять, менять или копировать элементы в вашей презентации, если они не введут пароль.  

Тем не менее, даже без пароля пользователь всё равно сможет открыть ваш документ. В режиме только для чтения пользователь может просматривать содержимое — включая гиперссылки, анимацию, эффекты и другие элементы — но он не может копировать элементы или сохранять презентацию.

- **Открытие**

Если вы хотите, чтобы только определённые пользователи могли открывать вашу презентацию, вы можете установить ограничение на открытие. Это ограничение препятствует людям даже просматривать содержимое вашей презентации без ввода пароля.

Технически ограничение на открытие также препятствует пользователям изменять ваши презентации — если человек не может открыть презентацию, он не может её изменить или внести в неё правки.

**Примечание:** Когда вы защищаете презентацию паролем, чтобы запретить её открытие, файл презентации шифруется.

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

Чтобы зашифровать (или защитить паролем) презентацию, используйте метод `Encrypt` из [ProtectionManager](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager), передав пароль в метод `Encrypt`, а затем сохраните презентацию с помощью метода `Save`.

Следующий пример кода показывает, как зашифровать презентацию:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Установка защиты от записи для презентации** 

Вы можете добавить пометку «Не изменять» к презентации. Это сообщает пользователям, что вы не хотите, чтобы они вносили изменения в презентацию.

**Примечание:** Процесс установки защиты от записи не шифрует презентацию. Поэтому пользователи — если захотят — могут изменить её, но для сохранения изменений им придётся сохранять файл под другим именем.

Чтобы установить защиту от записи, используйте метод `SetWriteProtection`. Этот пример кода показывает, как установить защиту от записи для презентации:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Загрузка зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованную презентацию, указав правильный пароль. Этот пример кода показывает, как загрузить зашифрованную презентацию:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Работа с дешифрованной презентацией.
}
```

## **Удаление шифрования из презентации**

Вы можете удалить шифрование или защиту паролем из презентации, позволяя пользователям получать к ней доступ или изменять её без ограничений.

Чтобы удалить шифрование или защиту паролем, вызовите метод [RemoveEncryption](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/methods/removeencryption). Этот пример кода показывает, как удалить шифрование из презентации:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Удаление защиты от записи из презентации**

Вы можете использовать Aspose.Slides для снятия защиты от записи с файла презентации. После этого пользователи смогут изменять её как захотят — и не будут получать предупреждений при выполнении таких действий.

Снять защиту от записи можно с помощью метода [RemoveWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/methods/removewriteprotection). Этот пример кода показывает, как снять защиту от записи с презентации:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Получение свойств зашифрованной презентации**

Обычно пользователям трудно получить свойства документа зашифрованной или защищённой паролем презентации. Тем не менее Aspose.Slides предлагает механизм, позволяющий защитить презентацию паролем и одновременно сохранять возможность доступа к её свойствам.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства документа презентации также защищаются паролем. Если вам необходимо, чтобы свойства документа оставались доступными даже после шифрования, Aspose.Slides позволяет это сделать.

Если вы хотите, чтобы пользователи могли обращаться к свойствам зашифрованной презентации, установите свойство `EncryptDocumentProperties` интерфейса [IProtectionManager](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/) в `false`. Этот пример кода показывает, как зашифровать презентацию, оставив свойства документа доступными:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов или другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/) и установите [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) в `true`. В этом режиме Aspose.Slides игнорирует пароль и загружает только публично доступные свойства документа.

Следующий пример кода читает встроенные и пользовательские свойства документа через [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/documentproperties/):

```c#
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

Этот сценарий работает только когда свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, установка `OnlyLoadDocumentProperties` в `true` приводит к исключению, поскольку пароль в таком режиме игнорируется. Чтобы получить доступ к зашифрованным свойствам документа или загрузить полную презентацию, включая слайды и другое содержимое, укажите правильное значение `Password` в [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/).

## **Проверка, защищена ли презентация паролем**

Прежде чем загрузить презентацию, вы можете проверять, не была ли она защищена паролем. Это помогает избежать ошибок и подобных проблем, возникающих при попытке загрузить защищённую паролем презентацию без правильного пароля.

Этот код на C# показывает, как определить, защищена ли презентация паролем, без её фактической загрузки:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этого вы можете использовать свойство [IsEncrypted](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/properties/isencrypted), которое возвращает `true`, если презентация зашифрована, и `false` в противном случае.

Этот пример кода показывает, как проверить, зашифрована ли презентация:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этого вы можете использовать свойство [IsWriteProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/protectionmanager/properties/iswriteprotected), которое возвращает `true`, если презентация защищена от записи, и `false` в противном случае.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Проверка использования пароля для презентации**

Вам может потребоваться убедиться, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет средства для проверки пароля.

Этот пример кода показывает, как валидировать пароль:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Проверьте, совпадает ли пароль.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Метод возвращает `true`, если презентация зашифрована указанным паролем; в противном случае — `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Перейдите на страницу нашего [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock).  
2. Нажмите **Drop or upload your files**.  
3. Выберите файл, который хотите защитить паролем, на вашем компьютере.  
4. Введите желаемый пароль для защиты от редактирования и желаемый пароль для защиты от просмотра.  
5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, установите флажок **Mark as final**.  
6. Нажмите **PROTECT NOW.**  
7. Нажмите **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на базе AES, обеспечивая высокий уровень защиты данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию ввести неправильный пароль?**

Выбрасывается исключение, информирующее о том, что доступ к презентации отклонён. Это помогает предотвратить неавторизованный доступ и защищает содержимое презентации.

**Есть ли какие‑либо последствия для производительности при работе с паролем защищёнными презентациями?**

Процессы шифрования и дешифрования могут добавить небольшую нагрузку при открытии и сохранении файлов. В большинстве случаев влияние на производительность минимально и не оказывает значительного влияния на общее время обработки задач с презентациями.