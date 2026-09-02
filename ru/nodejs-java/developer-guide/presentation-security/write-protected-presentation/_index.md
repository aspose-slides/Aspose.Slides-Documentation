---
title: Защита презентаций от записи в JavaScript
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/nodejs-java/write-protected-presentation/
keywords:
- защита от записи
- защита от записи PowerPoint
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверить пароль изменения
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Устанавливайте, обнаруживайте, проверяйте и удаляйте пароли защиты от записи в презентациях PowerPoint PPT и PPTX с использованием Aspose.Slides для Node.js через Java."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просмотреть защищённую паролем презентацию без ввода пароля. В зависимости от приложения они также могут иметь возможность редактировать содержимое и сохранить его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит иной цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Защита презентаций паролем](/slides/ru/nodejs-java/password-protected-presentation/).

Рабочие процессы в этой статье применимы как к презентациям PPT, так и PPTX. Примеры используют файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи для презентации**

Используйте [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection), чтобы задать пароль для изменения презентации. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи для презентации PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Загрузить защищённую от записи презентацию**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль актуален только при проверке права на изменение защищённой презентации.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Не передавайте пароль защиты от записи в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword). Этот метод принимает пароль открытия для зашифрованного содержимого. Если презентация имеет оба типа защиты, укажите пароль открытия для загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Удалить защиту от записи у презентации**

Используйте [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection), чтобы снять ограничение изменения, затем сохраните презентацию.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверить, защищена ли презентация от записи**

Чтобы проверить файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), вызовите [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) и проверьте [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Метод использует [NullableBool](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/nullablebool/) и возвращает `NullableBool.True`, когда обнаружена защита от записи.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Метод, основанный на потоках, [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream), предоставляет ту же информацию для презентации, переданной как читаемый поток Node.js.

## **Проверить пароль защиты от записи**

Используйте [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection), чтобы проверить пароль изменения без полной загрузки презентации. Сначала проверьте [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected), чтобы приложение запрашивало или проверяло пароль только при наличии защиты от записи.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, может ли быть загружено зашифрованное содержимое. Напротив, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkPassword) проверяет только пароль открытия. Если полная презентация уже загружена, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) предоставляет эквивалентную проверку защиты от записи через менеджер защиты.

В производственных приложениях не регистрируйте пароли и не включайте их в диагностические сообщения. Избегайте лишних повторных попыток проверки и храните пароли в памяти только столько, сколько требуется.

{{% alert color="info" title="См. также" %}}
- [Защита презентаций паролем](/slides/ru/nodejs-java/password-protected-presentation/)
- [Презентации только для чтения](/slides/ru/nodejs-java/read-only-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ЧАВО**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Только пароль открытия требуется для загрузки зашифрованного содержимого презентации.

**Может ли презентация иметь одновременно пароль открытия и пароль защиты от записи?**

Да. Укажите пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и отдельно проверьте пароль защиты от записи, когда требуется право на изменение.