---
title: Добавление цифровых подписей к презентациям на Java
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Электронная подпись позволяет получателю определить, кто подписал презентацию и изменилось ли подписанное содержание. Здесь важны три взаимосвязанных понятия безопасности:

- **Цифровой сертификат** — это электронные учётные данные, связывающие идентичность с открытым ключом. Доверенный центр сертификации (CA) может выпустить сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Электронная подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Открытый ключ сертификата затем используется для проверки подписи. Подпись предоставляет доказательство подлинности и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Password-Protected Presentations](/java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![Меню Protect Presentation в PowerPoint с выделенной опцией Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может показать уведомление о статусе подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides.ipresentation/#getDigitalSignatures--), который возвращает [IDigitalSignatureCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignaturecollection/) с элементами, реализующими [IDigitalSignature](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписания презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. Ниже в примерах пароль берётся из переменной окружения только для того, чтобы не встраивать его в код.

## **Добавление цифровой подписи к презентации**

Чтобы подписать реальную презентацию, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/java/com.aspose.slides.digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, задаваемое через [IDigitalSignature.setComments](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignature/#setComments-java.lang.String-), описывает цель подписи; оно не является элементом контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX необходимо просмотреть каждый элемент, возвращаемый [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides.ipresentation/#getDigitalSignatures--). Метод [IDigitalSignature.isValid](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignature/#isValid--) указывает, является ли встроенная подпись действительной для текущего содержимого презентации.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписания, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в работе, важной с точки зрения безопасности, также необходимо убедиться, что присутствует ожидаемое количество подписей и ожидаемые идентификаторы подписывающих.

Этот результат проверки не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от политики безопасности ваше приложение может также потребовать построить и проверить цепочку сертификатов X.509, проверить даты действия сертификата и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить доверенный временной штамп. Значение, возвращаемое [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignature/#getSignTime--), само по себе не является доказательством от доверенного сервера временных штампов.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignaturecollection/#clear--), и сохраняется неподписанная копия.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить только одну подпись, вызовите [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides.idigitalsignaturecollection/#removeAt-int-) с её нулевым индексом. Сохраните в новый файл, если только перезапись подписанного оригинала не является явной частью вашего процесса.

## **Редактирование и соображения формата**

- Подпись не делает презентацию только для чтения. Пользователи и приложения всё ещё могут редактировать файл, но изменения в подписанном содержимом обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписания. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её снова.
- Сохраняйте окончательный результат в формате PPTX. Конвертация подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись для преобразованного файла.
- Относитесь к закрытому ключу сертификата как к конфиденциальному. Любой, кто получит закрытый ключ и его пароль, может создавать подписи, которые будут выглядеть как подписанные этим владельцем сертификата.
- Сохраняйте неподписанный исходный файл или другую контролируемую копию, если это требует ваша политика хранения документов.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательство происхождения и целостности, но содержание презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [password protection](/java/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не управляет тем, кто может открыть или изменить файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически самоподписанный сертификат можно использовать, если в нём присутствует доступный закрытый ключ. Однако получатели не будут автоматически ему доверять, если только сертификат явно не добавлен в их доверенное окружение. В публичных или межорганизационных процессах обычно используют сертификаты, выданные доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписания делает подпись недействительной. Повреждение файла также может привести к ошибке верификации. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что я должен доверять подписывающему?**

Не автоматически. Целостность подписи и доверие к подписывающему — это отдельные решения. Политика проверки в продакшене должна также проверять цепочку сертификатов, срок действия, статус отзыва, ожидаемую личность, назначение ключа и любые требования к доверенному временного штампа.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли доверенный временной штамп, что подпись была сделана, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенный штамп времени.

**Можно ли редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому сначала завершайте правки, а затем подписывайте окончательную версию.

**Можно ли в презентации иметь более одной подписи?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides.ipresentation/#getDigitalSignatures--), перед сохранением. При проверке просматривайте каждую подпись и убеждайтесь, что все необходимые подписывающие присутствуют.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для PPTX. Форматы PPT и OpenDocument не поддерживаются этим API.

**Можно ли удалить подпись, не затронув слайды?**

Да. Можно удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержимое слайдов остаётся, но сохранённый файл больше не содержит доказательство удалённой подписи.