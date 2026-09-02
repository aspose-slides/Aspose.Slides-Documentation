---
title: Добавление цифровых подписей к презентациям на JavaScript
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/nodejs-java/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PKCS#12
- проверка подписи
- PowerPoint
- PPTX
- безопасность презентаций
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для Node.js через Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись позволяет получателю определить, кто подписал презентацию и изменилось ли подписанное содержание. Здесь важны три связанных концепции безопасности:

- **Цифровой сертификат** – это электронные учетные данные, связывающие идентификатор с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Открытый ключ сертификата затем используется для проверки подписи. Подпись подтверждает происхождение и целостность; она не шифрует презентацию.
- **Защита паролем** управляет тем, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Презентации с паролем](/slides/ru/nodejs-java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отображать уведомление о состоянии подписи.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет доступ к подписям через [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), который возвращает [DigitalSignatureCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignaturecollection/) с объектами [DigitalSignature](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignature/). Презентация может содержать несколько подписей.

## **Понимание PFX‑сертификатов и паролей**

Файл PFX (также известный как PKCS#12, обычно с расширением `.pfx` или `.p12`) может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не коммитьте файлы PFX и их пароли в систему контроля версий. В производстве ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. В примерах ниже переменная окружения используется лишь для того, чтобы не встраивать пароль в код.

## **Добавление цифровой подписи к презентации**

Чтобы подписать реальную презентацию, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignature/) из PFX‑сертификата и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, задаваемое методом [DigitalSignature.setComments](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignature/), описывает назначение подписи; это не средство контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверьте каждый элемент, возвращаемый [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Метод [DigitalSignature.isValid](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignature/) указывает, является ли встроенная подпись действительной для текущего содержимого презентации.

Следующий пример также использует класс Node.js `X509Certificate` для чтения имени субъекта из каждого встроенного сертификата.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Неправильный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписи, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в рабочем процессе, чувствительном к безопасности, необходимо также убедиться, что присутствует ожидаемое количество подписей и нужные идентичности подписантов.

Этот результат валидности не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложение может также построить и проверить цепочку сертификатов X.509, проверить даты действительности и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить доверенную метку времени. Значение, получаемое через [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignature/), само по себе не является доказательством от доверенного сервера меток времени.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), и сохраняется неподписанная копия.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить только одну подпись, вызовите [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) с её нулевым индексом. Сохраняйте в новый файл, если только перезапись подписанного оригинала не является явной частью вашего процесса.

## **Соображения по редактированию и форматам**

- Подпись не делает презентацию доступной только для чтения. Пользователи и приложения всё равно могут редактировать файл, но изменения в подписанном содержимом обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписи. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её заново.
- Сохраняйте окончательный результат в формате PPTX. Преобразование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованном файле.
- Рассматривайте закрытый ключ сертификата как конфиденциальный. Любой, кто получит закрытый ключ и его пароль, может создавать подписи, которые выглядят как подписи владельца сертификата.
- Сохраняйте неподписанный исходник или другую контролируемую копию, если ваша политика хранения документов этого требует.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись подтверждает происхождение и целостность, но содержание презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [защиту паролем](/slides/ru/nodejs-java/password-protected-presentation/), когда требуется ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX открывает закрытый ключ, хранящийся в пакете сертификата. Он не управляет тем, кто может открыть или отредактировать файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически да, если в нём присутствует доступный закрытый ключ. Получатели не будут автоматически ему доверять, если только сертификат явно не добавлен в их доверенную среду. Для публичных или кросс‑организационных процессов обычно используют сертификат, выданный доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписи приводит к недействительности подписи. Повреждение файла также может вызвать ошибку валидации. Если удалить все подписи, презентация становится неподписанной, а не содержит недействительную подпись.

**Означает ли действительная подпись, что подписьному лицу можно доверять?**

Не автоматически. Целостность подписи и доверие к подписьному лицу – это отдельные решения. Политика валидации в производстве должна также проверять цепочку сертификатов, период действия, статус отзыва, ожидаемую личность, назначение ключа и любые требования к доверенным меткам времени.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли доверенная метка времени, что подпись была выполнена, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенную метку времени.

**Можно ли редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершайте презентацию перед подписью финальной версии.

**Может ли презентация содержать более одной подписи?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), перед сохранением. При валидации проверяйте каждую подпись и убеждайтесь, что присутствуют все необходимые подписанты.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для формата PPTX. Форматы PPT и OpenDocument не поддерживаются этим API‑процессом.

**Можно ли удалить подпись, не затронув слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержание слайдов остаётся, но сохранённый файл больше не содержит доказательства подписи.