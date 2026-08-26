---
title: Защита презентаций от записи в .NET
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/net/write-protected-presentation/
keywords:
- защита от записи
- защита PowerPoint от записи
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверка пароля изменения
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Устанавливайте, обнаруживайте, проверяйте и удаляйте пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для .NET."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просматривать презентацию с защитой от записи без пароля. В зависимости от приложения они также могут редактировать содержимое и сохранять его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит другой цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Password-Protect Presentations](/slides/ru/net/password-protected-presentation/).

Процессы, описанные в этой статье, применимы как к презентациям PPT, так и PPTX. В примерах используются файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи для презентации**

Используйте [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/setwriteprotection/) для назначения пароля, позволяющего изменять презентацию. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи для презентации PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Загрузить презентацию с защитой от записи**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль имеет значение только при проверке разрешения на изменение защищённой презентации.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Не передавайте пароль защиты от записи в [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/). Это свойство принимает пароль открытия для зашифрованного содержимого. Если у презентации есть оба типа защиты, укажите пароль открытия для загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Убрать защиту от записи из презентации**

Используйте [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/removewriteprotection/) для снятия ограничения изменения, затем сохраните презентацию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Проверить, защищена ли презентация от записи**

Чтобы проверить файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), вызовите [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationfactory/getpresentationinfo/) и изучите [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/iswriteprotected/). Свойство использует [NullableBool](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/) и возвращает `NullableBool.True`, когда обнаружена защита от записи.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Перегрузка метода для потока [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationfactory/getpresentationinfo/) предоставляет ту же информацию для презентации, переданной в виде потока.

## **Проверка пароля защиты от записи**

Используйте [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/checkwriteprotection/) для проверки пароля изменения без загрузки полной презентации. Сначала проверьте [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/iswriteprotected/), чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/checkwriteprotection/) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, может ли быть загружено зашифрованное содержимое. Напротив, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/checkpassword/) проверяет только пароль открытия. Если полная презентация уже загружена, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/checkwriteprotection/) предоставляет аналогичную проверку защиты от записи через менеджер защиты.

В производственных приложениях не регистрируйте пароли и не включайте их в диагностические сообщения. Избегайте лишних повторных попыток проверки и храните пароли в памяти только столько, сколько необходимо.

{{% alert color="info" title="Смотрите также" %}}
- [Password-Protect Presentations](/slides/ru/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/ru/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Для загрузки зашифрованного содержимого презентации требуется только пароль открытия.

**Может ли презентация иметь одновременно пароль открытия и пароль защиты от записи?**

Да. Передайте пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется разрешение на изменение.