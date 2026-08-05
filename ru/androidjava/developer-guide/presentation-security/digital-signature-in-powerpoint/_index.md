---
title: Добавление цифровых подписей к презентациям на Android
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

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три взаимосвязанных концепции безопасности:

- **Цифровой сертификат** — это электронные учётные данные, связывающие идентичность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Открытый ключ сертификата затем используется для проверки подписи. Подпись предоставляет доказательства происхождения и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Password-Protected Presentations](/androidjava/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![Меню PowerPoint Protect Presentation с выделенной командой Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отобразить уведомление о статусе подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), который возвращает [IDigitalSignatureCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/) , элементы которого реализуют [IDigitalSignature](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. Ниже в примерах пароль берётся из переменной окружения только для того, чтобы не встраивать его в код.

## **Добавление цифровой подписи к презентации**

Чтобы подпись была частью реального рабочего процесса, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

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

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, установленное через [IDigitalSignature.setComments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-), описывает цель подписи; это не средство контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверьте каждый элемент, возвращаемый [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Метод [IDigitalSignature.isValid](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#isValid--) указывает, действительна ли встроенная подпись для текущего содержимого презентации.

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

Недействительный результат обычно означает, что содержимое презентации или данные подписи изменились после подписи, либо файл повреждён. Удаление всех подписей приводит к презентации без подписи, поэтому проверка только валидности элементов недостаточна: в рабочих процессах, чувствительных к безопасности, также необходимо убедиться, что присутствует ожидаемое количество подписей и ожидаемые идентификаторы подписантов.

Этот результат не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложение может также потребовать построения и проверки цепочки сертификатов X.509, проверки сроков действия сертификата и статуса отзыва, подтверждения ожидаемого субъекта или отпечатка, проверки использования ключа и оценки доверенного штампа времени. Значение [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) само по себе не является доказательством от доверенного центра штампов времени.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), и сохраняется копия без подписи.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы удалить только одну подпись, вызовите [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) с её нулевым индексом. Сохраняйте в новый файл, если перезапись оригинального подписанного файла не является явной частью вашего рабочего процесса.

## **Учёт редактирования и форматов**

- Подпись не делает презентацию только для чтения. Пользователи и приложения могут по‑прежнему редактировать файл, но изменения подписанного содержимого обычно аннулируют существующую подпись.
- Выполните все планируемые правки до подписи. Если презентацию необходимо изменить, сохраните её исправленную версию и подпишите её заново.
- Оставляйте окончательный результат в формате PPTX. Преобразование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованном файле.
- Рассматривайте закрытый ключ сертификата как конфиденциальный материал. Любой, кто получит закрытый ключ и его пароль, может создавать подписи, выдающие себя за владельца сертификата.
- Сохраняйте исходный файл без подписи или другую контролируемую копию, если ваша политика удержания документов требует этого.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательства происхождения и целостности, но содержимое презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [защиту паролем](/androidjava/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX открывает закрытый ключ, хранящийся в пакете сертификата. Он не управляет тем, кто может открыть или отредактировать файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически да, если в нём присутствует доступный закрытый ключ. Получатели не будут автоматически доверять ему, если только сертификат явно не добавлен в их доверенную среду. В публичных или межорганизационных процессах обычно используют сертификат, выданный доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписи делает подпись недействительной. Повреждение файла также может привести к ошибке валидации. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что я должен доверять подписанту?**

Не автоматически. Целостность подписи и доверие к подписанту — это отдельные решения. Политика продакшн‑валидации должна также проверять цепочку сертификатов, срок действия, статус отзыва, ожидаемую идентичность, использование ключа и любые требования к доверенному штампу времени.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждено ли доверенным штампом времени, что подпись была сделана, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенный штамп времени.

**Можно ли продолжать редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершите правки и подпишите финальную версию.

**Можно ли добавить более одной подписи к презентации?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), перед сохранением. При валидации проверяйте каждую подпись и подтверждайте, что присутствуют все требуемые подписанты.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для формата PPTX. Форматы PPT и OpenDocument в этом API не поддерживаются.

**Можно ли удалить подпись, не затронув слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержание слайдов останется доступным, но сохранённый файл больше не будет содержать доказательства удалённой подписи.