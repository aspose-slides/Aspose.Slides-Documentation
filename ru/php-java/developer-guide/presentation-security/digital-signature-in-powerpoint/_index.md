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
description: "Узнайте, как подписывать существующие PPTX-презентации сертификатами PFX и использовать Aspose.Slides для PHP через Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три связанных концепции безопасности:

- **Цифровой сертификат** — это электронные удостоверение, которое связывает личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних рабочих процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Затем открытый ключ сертификата может использоваться для проверки подписи. Подпись предоставляет доказательство источника и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Презентации с защитой паролем](/slides/ru/php-java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![Меню PowerPoint Protect Presentation с выделенной опцией Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отобразить уведомление о состоянии подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDigitalSignatures), который возвращает [DigitalSignatureCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/), элементы которой представлены объектами [DigitalSignature](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создавать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не сохраняйте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого источника конфигурации. Приведённые ниже примеры используют переменную окружения только чтобы избежать встраивания пароля в код.

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

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, установленное с помощью [DigitalSignature::setComments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/setcomments/) описывает цель подписи; это не средство защиты.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверьте каждый элемент, возвращаемый [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDigitalSignatures). Метод [DigitalSignature::isValid](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/isvalid/) указывает, является ли встроенная подпись действительной для текущего содержимого презентации.

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

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписания, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в сценариях с повышенными требованиями к безопасности необходимо также убедиться, что присутствует ожидаемое количество подписей и ожидаемые подписи.

Этот результат проверки не следует рассматривать как полное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложение может также потребовать построения и проверки цепочки сертификатов X.509, проверки дат действия и статуса отзыва сертификата, подтверждения ожидаемого субъекта или отпечатка, проверки использования ключа и оценки доверенного таймстампа. Значение [DigitalSignature::getSignTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignature/getsigntime/) само по себе не является доказательством от доверенного органа таймстампа.

## **Удаление цифровых подписей**

Удаление подписей изменяет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, удаляются все подписи с помощью [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/clear/), и сохраняется неподписанная копия.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы удалить только одну подпись, вызовите [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/digitalsignaturecollection/removeat/) с её нулевым индексом. Сохраните в новый файл, если перезапись подписанного оригинала не является явной частью вашего рабочего процесса.

## **Редактирование и соображения формата**

- Подпись не делает презентацию только для чтения. Пользователи и приложения всё ещё могут редактировать файл, но изменения подписанного содержимого обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписания. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её заново.
- Сохраняйте окончательный результат в формате PPTX. Конвертирование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись для преобразованного файла.
- Рассматривайте закрытый ключ сертификата как конфиденциальный. Любой, кто получит закрытый ключ и его пароль, может создать подписи, выглядящие как сделанные этим владельцем сертификата.
- Сохраняйте неподписанный исходник или другую контролируемую копию, если ваша политика удержания документов требует этого.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательство происхождения и целостности, но содержимое презентации остаётся читаемым, если не применено отдельное шифрование. Используйте [защиту паролем](/slides/ru/php-java/password-protected-presentation/) когда необходимо ограничить доступ к содержимому.

**Является ли пароль PFX тем же, что и пароль презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не определяет, кто может открыть или отредактировать файл PPTX.

**Могу ли я использовать самоподписанный сертификат?**

Технически самоподписанный сертификат можно использовать, если в нём есть доступный закрытый ключ. Однако получатели автоматически не будут ему доверять, если только сертификат не был явно добавлен в их доверенную среду. Публичные или межорганизационные рабочие процессы обычно используют сертификат, выданный доверенным ЦС.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписания может сделать подпись недействительной. Повреждение файла также может привести к ошибке проверки. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что я должен доверять подписанту?**

Не само по себе. Целостность подписи и доверие к подписанту — это отдельные решения. Политика проверки в продакшене также должна проверять цепочку сертификатов, срок действия, статус отзыва, ожидаемую идентичность, использование ключа и любые требования к доверенному таймстампу.

**Что происходит, когда срок действия сертификата истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия сертификату. Приёмлемость подписи зависит от вашей политики и от того, доказывает ли действительный доверенный таймстамп, что подпись была сделана, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенный таймстамп.

**Можно ли редактировать подписанную презентацию?**

Да. Подписание не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершите презентацию и подпишите окончательную версию.

**Может ли презентация содержать более одной подписи?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [Presentation::getDigitalSignatures] перед сохранением. При проверке проверяйте каждую подпись и подтверждайте наличие всех требуемых подписантов.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает операции с цифровой подписью, описанные здесь, только для PPTX. Форматы PPT и OpenDocument не поддерживаются этим API.

**Могу ли я удалить подпись, не затрагивая слайды?**

Да. Можно удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержимое слайдов остаётся, но сохранённый файл больше не содержит доказательств удалённой подписи.