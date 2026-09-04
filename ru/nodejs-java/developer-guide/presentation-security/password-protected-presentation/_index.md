---
title: Защита презентаций паролем в JavaScript
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/nodejs-java/password-protected-presentation/
keywords:
- презентация, защищённая паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Шифруйте, обнаруживайте, проверяйте, открывайте и расшифровывайте презентации PowerPoint PPT и PPTX, защищённые паролем, в JavaScript с помощью Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Для управления паролями при изменении презентаций см. [Write-Protect Presentations](/slides/ru/nodejs-java/write-protected-presentation/).

Приведённые ниже сценарии применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важны их поведение при работе с файлами и потоками.

## **Зашифровать презентацию паролем открытия**

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

## **Сделать свойства документа общедоступными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. Метод [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) управляет этим поведением независимо от шифрования содержимого слайдов. Перед вызовом [ProtectionManager.encrypt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#encrypt) передайте `false`, если система индексации, классификации, поиска или управления документами должна читать метаданные без пароля открытия.

Следующий пример создаёт зашифрованную презентацию PPTX, оставляя её встроенные свойства документа общедоступными:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Передача `false` в [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) не делает слайды, шаблоны, макеты, фигуры, медиа‑файлы или другое содержимое презентации общедоступными. Это влияет только на свойства документа. Чтобы читать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/nodejs-java/presentation-properties/).

## **Загрузка зашифрованной презентации**

Установите [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword) в значение пароля открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) при загрузке файла. Загрузка завершается ошибкой, когда требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Работать с расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```

## **Удалить шифрование из презентации**

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

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) для получения [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/) без создания полного экземпляра презентации. Проверьте [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) перед запросом или проверкой пароля. Когда защита присутствует, проверьте переданное значение с помощью [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Сценарий с указанием пути к файлу**

Следующий пример проверяет пароль открытия для файла PPTX, передаёт подтверждённое значение в [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword) и затем загружает полную презентацию:

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

### **Сценарий с потоком**

Используйте [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) для анализа читаемого потока Node.js. После того как поток проверки будет использован, создайте новый поток перед загрузкой полной презентации с помощью [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

### **Возвращаемые значения checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#checkPassword) возвращает `true` только когда у презентации установлен пароль открытия и предоставленный пароль верен. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль `null` или пустой.

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
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте излишних повторных попыток проверки, храните пароли в памяти только столько, сколько необходимо, и переиспользуйте успешный результат проверки при немедленной загрузке презентации.

Общие свойства документа могут раскрывать имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставлять свойства общедоступными следует только в том случае, когда системы обязаны индексировать, классифицировать, искать или управлять файлом без пароля открытия.
{{% /alert %}}

## **Защитить презентацию паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
1. Выберите или загрузите презентацию.
1. Введите пароль для защиты просмотра.
1. При необходимости введите отдельный пароль для защиты редактирования.
1. Примените защиту и скачайте полученный файл.

{{% alert color="info" title="См. также" %}}
- [Write-Protect Presentations](/slides/ru/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Можно ли проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль до создания полного экземпляра презентации.

**Может ли приложение читать метаданные без пароля открытия?**

Да, но только когда презентация зашифрована с отключённым шифрованием свойств документа. В этом случае приложение должно использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/nodejs-java/presentation-properties/).

**Поддерживают ли сценарии проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.