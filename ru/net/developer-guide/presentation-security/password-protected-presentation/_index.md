---
title: Защита паролем презентаций в .NET
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/net/password-protected-presentation/
keywords:
- презентация с защитой паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- проверка пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- .NET
- C#
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, на C# с Aspose.Slides для .NET."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Для управления паролями при изменении презентаций см. [Write-Protect Presentations](/slides/ru/net/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важно их поведение при работе с файлами и потоками.

## **Зашифровать презентацию паролем открытия**

Используйте [IProtectionManager.Encrypt](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/encrypt/) для назначения пароля открытия. Затем используйте [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Загрузить зашифрованную презентацию**

Установите [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) при загрузке файла. Загрузка завершается ошибкой, если нужен пароль открытия, но предоставленный пароль отсутствует или неверен.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Работайте с расшифрованной презентацией.
```

## **Снять шифрование с презентации**

Загрузите презентацию, указав её пароль открытия, вызовите [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/removeencryption/) и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Проверить пароль открытия перед загрузкой**

Используйте [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationfactory/getpresentationinfo/) для получения [IPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/) без создания полного экземпляра презентации. Проверьте [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/ispasswordprotected/) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Рабочий процесс с путем к файлу**

Следующий пример проверяет пароль открытия для файла PPTX, передаёт проверенное значение в [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/), а затем загружает полную презентацию:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Рабочий процесс с потоком**

Перегрузка потока метода [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationfactory/getpresentationinfo/) обеспечивает тот же рабочий процесс. Сбросьте позицию позиционируемого потока перед загрузкой полной презентации из этого потока.

Следующий пример использует файл PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Возвратные значения CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/checkpassword/) возвращает `true` только когда у презентации установлен пароль открытия и предоставленный пароль правильный. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль `null` или пустой.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверить, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/isencrypted/), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте `IPresentationInfo.IsPasswordProtected`, как показано выше.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, держите пароли в памяти только столько, сколько необходимо, и повторно используйте успешный результат проверки при немедленной загрузке презентации.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При желании введите отдельный пароль для защиты редактирования.
5. Примените защиту и загрузите полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Вопросы и ответы**

**В чем разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль до создания полного экземпляра презентации.

**Поддерживают ли рабочие процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку ведут себя одинаково для презентаций PPT и PPTX.