---
title: Добавление цифровых подписей в презентации на Java
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
description: "Узнайте, как подписывать существующие презентации PPTX сертификатами PFX и использовать Aspose.Slides для Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три связанных понятия безопасности:

- **Цифровой сертификат** — это электронные удостоверения, связывающие личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Открытый ключ сертификата затем может использоваться для проверки подписи. Подпись предоставляет доказательство происхождения и целостности; она не шифрует презентацию.
- **Защита паролем** определяет, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Презентации с защитой паролем](/slides/ru/java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в разделе **File > Info > Protect Presentation**.

![Меню PowerPoint Protect Presentation с выделенной командой Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может показывать уведомление о статусе подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), который возвращает [IDigitalSignatureCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignaturecollection/), элементы которого реализуют [IDigitalSignature](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Он **не** является паролем для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. Приведённые ниже примеры используют переменную окружения только для того, чтобы избежать встраивания пароля в код.

## **Добавление цифровой подписи в презентацию**

Чтобы подписать реальную презентацию, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/java/com.aspose.slides/digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

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

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, установленное с помощью [IDigitalSignature.setComments](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-), описывает цель подписи; оно не является элементом контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверьте каждый элемент, возвращаемый [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Метод [IDigitalSignature.isValid](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignature/#isValid--) указывает, является ли встроенная подпись действительной для текущего содержимого презентации.

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

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписания, либо файл повреждён. Удаление всех подписей приводит к презентации без подписи, поэтому проверка только валидности элементов недостаточна: рабочий процесс, чувствительный к безопасности, также должен проверять, что присутствует ожидаемое количество подписей и ожидаемые идентичности подписантов.

Этот результат проверки не следует рассматривать как окончательное решение по доверию к сертификату. В зависимости от вашей политики безопасности приложение может также потребовать построить и проверить цепочку сертификатов X.509, проверить даты действия сертификата и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить доверенную метку времени. Значение, возвращаемое [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignature/#getSignTime--), само по себе не является доказательством от доверенного органа метки времени.

## **Удаление цифровых подписей**

Удаление подписей изменяет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, удаляются все подписи с помощью [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignaturecollection/#clear--), и сохраняется копия без подписи.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить только одну подпись, вызовите [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) с её нулевым индексом. Сохраните в новый файл, если только перезапись оригинального подписанного файла не является явной частью вашего рабочего процесса.

## **Учет правок и форматов**

- Подпись не делает презентацию только для чтения. Пользователи и приложения по‑прежнему могут редактировать файл, но изменения подписанного содержимого обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписания. Если презентацию нужно изменить, сохраните её обновлённую версию и подпишите её заново.
- Оставляйте конечный результат в формате PPTX. Конвертация подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованном файле.
- Рассматривайте закрытый ключ сертификата как конфиденциальный. Любой, получивший закрытый ключ и его пароль, может создавать подписи, которые выглядят как подписи владельца сертификата.
- Сохраняйте неподписанный исходный файл или другую контролируемую копию, если это требует ваша политика хранения документов.

## **Часто задаваемые вопросы**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательства происхождения и целостности, но содержимое презентации остаётся читаемым, если не применено отдельное шифрование. Используйте [защиту паролем](/slides/ru/java/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не управляет тем, кто может открыть или отредактировать файл PPTX.

**Могу ли я использовать самоподписанный сертификат?**

Технически самоподписанный сертификат может быть использован, если в нём доступен закрытый ключ. Однако получатели не будут автоматически ему доверять, если только сертификат явно не добавлен в их доверенную среду. В публичных или межорганизационных процессах обычно используют сертификат, выданный доверенным центром сертификации.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписания может сделать подпись недействительной. Повреждение файла также может привести к сбою проверки. Если все подписи удалены, презентация считается неподписанной, а не файлом с недействительной подписью.

**Означает ли действительная подпись, что я должен доверять подписанту?**

Не сама по себе. Целостность подписи и доверие к подписанту — это отдельные решения. Политика проверки в продакшене также должна проверять цепочку сертификатов, период действия, статус отзыва, ожидаемую идентичность, назначение ключа и любые требования к доверенным меткам времени.

**Что происходит, когда срок действия сертификата истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли действительная доверенная метка времени, что подпись была выполнена, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенную метку времени.

**Можно ли по‑прежнему редактировать подписанную презентацию?**

Да. Подписание не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершите презентацию сначала и подпишите окончательную версию.

**Может ли презентация содержать более одной подписи?**

Да. Добавьте каждую подпись в коллекцию, возвращаемую [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), перед сохранением. При проверке проверьте каждую подпись и убедитесь, что все требуемые подписанты присутствуют.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает операции с цифровой подписью, описанные здесь, только для формата PPTX. Форматы PPT и OpenDocument презентаций не поддерживаются этим API‑процессом.

**Могу ли я удалить подпись, не затронув слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержимое слайдов остаётся, но сохранённый файл больше не содержит доказательства удалённой подписи.