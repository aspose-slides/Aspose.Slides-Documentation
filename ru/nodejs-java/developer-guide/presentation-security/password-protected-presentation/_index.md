---
title: Защита презентаций паролем в JavaScript
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/nodejs-java/password-protected-presentation/
keywords:
- презентация с паролем
- пароль открытия
- шифрование PowerPoint
- дешифрование PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открыть зашифрованную презентацию
- снятие шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и дешифрование презентаций PowerPoint PPT и PPTX, защищённых паролем, в JavaScript с Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Для загрузки и просмотра содержимого презентации требуется правильный пароль, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Защита презентаций от записи](/slides/ru/nodejs-java/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, когда важны их поведение при работе с файлами и потоками.

## **Шифрование презентации паролем открытия**

Используйте [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#encrypt) для назначения пароля открытия. Затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Загрузка зашифрованной презентации**

Установите [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) при загрузке файла. Загрузка завершается неудачей, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Работа с расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```

## **Снятие шифрования с презентации**

Загрузите презентацию с её паролем открытия, вызовите [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Проверка пароля открытия перед загрузкой**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Рабочий процесс с указанием пути к файлу**

Следующий пример проверяет пароль открытия для файла PPTX, передаёт проверенное значение в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword) и затем загружает полную презентацию:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Рабочий процесс с потоками**

Используйте [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) для проверки читаемого потока Node.js. После того как поток проверки будет потреблен, создайте новый поток перед загрузкой полной презентации с помощью [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Следующий пример использует файл PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Значения, возвращаемые checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkPassword) возвращает `true` только когда у презентации есть пароль открытия и предоставленный пароль верен. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль равен `null` или пустой строке.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверка, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected), как показано выше.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Безопасность" %}}
Не регистрируйте пароли открытия и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько необходимо, и повторно используйте успешный результат проверки при немедленной загрузке презентации.
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При желании введите отдельный пароль для защиты от редактирования.
5. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="Смотрите также" %}}
- [Защита презентаций от записи](/slides/ru/nodejs-java/write-protected-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Вопросы и ответы**

**В чем разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает возможность изменения без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль перед созданием полного экземпляра презентации.

**Поддерживают ли рабочие процессы проверки пароля как PPT, так и PPTX?**

Да. Определение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.