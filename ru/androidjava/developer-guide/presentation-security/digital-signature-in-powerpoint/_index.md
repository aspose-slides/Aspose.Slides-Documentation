---
title: Добавить цифровые подписи к презентациям на Android
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для Android через Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три связанных понятия безопасности:

- **Цифровой сертификат** — это электронные удостоверения, связывающие личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних рабочих процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Публичный ключ сертификата затем используется для проверки подписи. Подпись предоставляет доказательство происхождения и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Защита паролем](/slides/ru/androidjava/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![Меню PowerPoint Protect Presentation с выделенной командой Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отображать уведомление о статусе подписи.

![Уведомление PowerPoint, сообщающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), который возвращает [IDigitalSignatureCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/), элементы которого реализуют [IDigitalSignature](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшн‑среде ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. Приведённые ниже примеры используют переменную окружения только для избежания встраивания пароля в код.

## **Добавление цифровой подписи к презентации**

Чтобы подписать реальный рабочий процесс с презентацией, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/digitalsignature/) используя сертификат PFX и его пароль, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```java
import com.aspose.slides.*;

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

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, установленное через [IDigitalSignature.setComments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-), описывает назначение подписи; это не средство контроля безопасности.

## **Проверка цифровых подписей**

Когда вы загружаете подписанный файл PPTX, просмотрите каждый элемент, возвращённый [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Метод [IDigitalSignature.isValid](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#isValid--) указывает, действительна ли встроенная подпись для текущего содержимого презентации.

```java
import com.aspose.slides.*;

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

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписания, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в сценарии, чувствительном к безопасности, также нужно удостовериться, что присутствует ожидаемое количество подписей и ожидаемые идентичности подписантов.

Этот результат валидности не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложение может также потребовать построить и проверить цепочку сертификатов X.509, проверить даты действия сертификата и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить доверенную временную метку. Значение [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) само по себе не является доказательством от доверенного органа временных меток.

## **Удаление цифровых подписей**

Удаление подписей изменяет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, удаляются все подписи с помощью [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), и сохраняется неподписанная копия.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить только одну подпись, вызовите [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) с её нулевым индексом. Сохраните в новый файл, если только перезапись подписанного оригинала не является явной частью вашего процесса.

## **Соображения по редактированию и форматам**

- Подпись не делает презентацию только для чтения. Пользователи и приложения могут продолжать редактировать файл, но изменения подписанного содержимого обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписания. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её снова.
- Сохраняйте конечный результат в формате PPTX. Преобразование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованном файле.
- Относитесь к закрытому ключу сертификата как к конфиденциальному. Любой, кто получит закрытый ключ и его пароль, может создавать подписи, выглядящие как подписи от владельца сертификата.
- Сохраняйте неподписанный исходник или другую контролируемую копию, если этого требует ваша политика хранения документов.

## **Часто задаваемые вопросы**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательство происхождения и целостности, но содержимое презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [защита паролем](/slides/ru/androidjava/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Является ли пароль PFX тем же, что и пароль презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не контролирует, кто может открыть или отредактировать файл PPTX.

**Могу ли я использовать самоподписанный сертификат?**

Технически самоподписанный сертификат можно использовать, если он включает доступный закрытый ключ. Получатели не будут автоматически ему доверять, если только сертификат явно не добавлен в их доверенную среду. Для публичных или межорганизационных процессов обычно используют сертификат, выданный доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписания может сделать подпись недействительной. Повреждение файла также может привести к ошибке проверки. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что я должен доверять подписанту?**

Не автоматически. Целостность подписи и доверие к подписанту — это отдельные решения. Политика проверки в продакшене должна также проверять цепочку сертификатов, период действия, статус отзыва, ожидаемую идентичность, назначение ключа и требования к доверенной временной метке.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли доверенная временная метка, что подпись была создана, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенную временную метку.

**Можно ли дальше редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно приводит к недействительности существующей подписи, поэтому завершайте презентацию сначала и подпишите окончательную версию.

**Можно ли добавить в презентацию более одной подписи?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), перед сохранением. При проверке просматривайте каждую подпись и убеждайтесь, что присутствуют все требуемые подписанты.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает операции с цифровой подписью, описанные здесь, только для PPTX. Форматы PPT и OpenDocument не поддерживаются этим API‑процессом.

**Могу ли я удалить подпись, не затрагивая слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержание слайдов остаётся доступным, но сохранённый файл больше не содержит доказательства подписи.