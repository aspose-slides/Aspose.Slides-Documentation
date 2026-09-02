---
title: Добавление цифровых подписей к презентациям в PHP
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для PHP через Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Электронная подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержание. Здесь важны три связанных понятия безопасности:

- **Цифровой сертификат** — это электронные учетные данные, связывающие личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Электронная подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Затем открытый ключ сертификата может быть использован для проверки подписи. Подпись предоставляет доказательства подлинности и целостности; она не шифрует презентацию.
- **Защита паролем** определяет, может ли пользователь открыть или изменить презентацию. Это отдельно от цифровой подписи и описано в [Презентации с защитой паролем](/php-java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в разделе **File > Info > Protect Presentation**.

![Меню PowerPoint Protect Presentation с выделенной командой Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может показать уведомление о статусе подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDigitalSignatures), который возвращает [DigitalSignatureCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/), элементы которой представлены объектами [DigitalSignature](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Он **не** является паролем для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте пароль из хранилища секретов или другого защищённого источника конфигурации. Примеры ниже используют переменную окружения только для того, чтобы не встраивать пароль в код.

## **Добавление цифровой подписи к презентации**

Чтобы подписать реальную презентацию, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, установленное через [DigitalSignature::setComments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/setcomments/), описывает цель подписи; это не средство безопасности.

## **Проверка цифровых подписей**

Когда вы загружаете подписанный файл PPTX, проверьте каждый элемент, возвращаемый [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDigitalSignatures). Метод [DigitalSignature::isValid](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/isvalid/) указывает, действительна ли встроенная подпись для текущего содержимого презентации.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписания, либо файл повреждён. Удаление всех подписей приводит к не подписанной презентации, поэтому проверка только валидности элементов недостаточна: в процессе, чувствительном к безопасности, необходимо также убедиться, что присутствует ожидаемое количество подписей и ожидаемые идентификаторы подписантов.

Этот результат валидности не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложение может также потребовать построения и проверки цепочки сертификатов X.509, проверки сроков действия и статуса отзыва сертификата, подтверждения ожидаемого субъекта или отпечатка, проверки назначений ключа и оценки доверенного временного штампа. Значение, возвращаемое [DigitalSignature::getSignTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/getsigntime/), само по себе не является доказательством от доверенного временного сервиса.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/clear/), и сохраняется несо́храняемая копия.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы удалить только одну подпись, вызовите [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/removeat/) с её нулевым индексом. Сохраните в новый файл, если перезапись подписи не является явной частью вашего рабочего процесса.

## **Редактирование и особенности форматов**

- Подпись не делает презентацию только для чтения. Пользователи и приложения по‑прежнему могут редактировать файл, но изменения подписанного содержимого обычно делают существующую подпись недействительной.
- Завершите все планируемые правки до подписания. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её заново.
- Оставляйте окончательный результат в формате PPTX. Преобразование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись для преобразованного файла.
- Считайте закрытый ключ сертификата конфиденциальным. Любой, кто получит закрытый ключ и его пароль, может создать подписи, выглядящие как подписи от владельца сертификата.
- Храните исходный файл без подписи или другую контролируемую копию, если ваша политика хранения документов требует этого.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательства происхождения и целостности, но содержимое презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [защиту паролем](/php-java/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не контролирует, кто может открыть или отредактировать файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически самоподписанный сертификат может быть использован, если в нём присутствует доступный закрытый ключ. Получатели автоматически не будут ему доверять, если только сертификат явно не добавлен в их доверенную среду. В публичных или межорганизационных процессах обычно используют сертификат, выданный доверенным центром сертификации.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписания может сделать подпись недействительной. Повреждение файла также может привести к ошибке проверки. Если все подписи удалены, презентация считается нес­пользованной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что я должен доверять подписанту?**

Нет, это отдельные решения. При проверке в продакшене следует также проверять цепочку сертификатов, срок действия, статус отзыва, ожидаемую личность, назначение ключа и любые требования к доверенному временно́му штампу.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли доверенный временный штамп, что подпись была создана, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенный временной штамп.

**Можно ли продолжать редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершайте презентацию и подпишите окончательную версию.

**Можно ли добавить более одной подписи к презентации?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDigitalSignatures), перед сохранением. При проверке просматривайте каждую подпись и убеждайтесь, что присутствуют все необходимые подписанты.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для PPTX. Форматы PPT и OpenDocument не поддерживаются данным API‑процессом.

**Могу ли я удалить подпись, не затронув слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержимое слайдов останется доступным, но сохранённый файл уже не будет содержать доказательства удалённой подписи.