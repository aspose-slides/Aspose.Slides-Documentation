---
title: Добавление цифровых подписей к презентациям на Python
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для Python через Java для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три связанных понятия безопасности:

- **Цифровой сертификат** — это электронные удостоверения, связывающие личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Открытый ключ сертификата затем используется для проверки подписи. Подпись предоставляет доказательства происхождения и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Password-Protected Presentations](/slides/ru/python-java/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![Меню Protect Presentation в PowerPoint с выделенной опцией Add a Digital Signature](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отобразить уведомление о статусе подписи.

![Уведомление PowerPoint, указывающее, что презентация содержит действительные подписи](digital-signature-status-in-powerpoint.png)

Aspose.Slides предоставляет подписи через [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDigitalSignatures), который возвращает [DigitalSignatureCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignaturecollection/) с элементами типа [DigitalSignature](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не размещайте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте пароль из хранилища секретов или другого защищённого источника конфигурации. Примеры ниже используют переменную окружения только чтобы избежать встраивания пароля в код.

## **Добавление цифровой подписи к презентации**

Чтобы подписать реальный рабочий процесс презентации, загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Сохранение результата под новым именем сохраняет исходный файл без подписи. Значение, задаваемое методом [DigitalSignature.setComments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignature/#setComments), описывает цель подписи; это не средство контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверяйте каждый элемент, возвращаемый [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDigitalSignatures). Метод [DigitalSignature.isValid](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignature/#isValid) указывает, действительна ли встроенная подпись для текущего содержимого презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписи, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в безопасном рабочем процессе также необходимо убедиться, что присутствует ожидаемое количество подписей и ожидаемые идентичности подписантов.

Этот результат не следует рассматривать как окончательное решение по доверию к сертификату. В зависимости от вашей политики безопасности приложению может потребоваться построить и проверить цепочку сертификатов X.509, проверить даты действия сертификата и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить доверенную метку времени. Значение, получаемое методом [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignature/#getSignTime), само по себе не является доказательством от доверенного учреждения меток времени.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignaturecollection/#clear), и сохраняется неподписанная копия.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы удалить только одну подпись, вызовите [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/digitalsignaturecollection/#removeAt) с её нулевым индексом. Сохраните в новый файл, если только перезапись подпись оригинала не является явной частью вашего процесса.

## **Соображения по редактированию и форматам**

- Подпись не делает презентацию только для чтения. Пользователи и приложения всё‑равно могут редактировать файл, но изменения в подписанном содержимом обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписи. Если презентацию нужно изменить, сохраните её новую версию и подпишите её снова.
- Сохраняйте окончательный результат в формате PPTX. Преобразование подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованный файл.
- Рассматривайте закрытый ключ сертификата как конфиденциальный. Любой, кто получит закрытый ключ и его пароль, сможет создавать подписи, которые выглядят как подписи владельца сертификата.
- Сохраняйте неподписанный исходник или другую контролируемую копию, если этого требует ваша политика хранения документов.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательства происхождения и целостности, но содержимое презентации остаётся читаемым, если не применяется отдельное шифрование. Используйте [password protection](/slides/ru/python-java/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Совпадает ли пароль PFX с паролем презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не контролирует, кто может открыть или отредактировать файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически да, если у него есть доступный закрытый ключ. Получатели автоматически не будут доверять такому сертификату, если только он явно не добавлен в их доверенную среду. В публичных или межорганизационных процессах обычно используют сертификат, выданный доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписи делает подпись недействительной. Повреждение файла также может привести к ошибке проверки. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что подпись следует доверять?**

Не сама по себе. Целостность подписи и доверие к подписанту — отдельные решения. Политика проверки в продакшене должна также проверять цепочку сертификатов, период действия, статус отзыва, ожидаемую личность, назначение ключа и любые требования к доверенным меткам времени.

**Что происходит, когда сертификат истекает?**

Истечение срока действия сертификата не меняет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли доверенная метка времени, что подпись была выполнена, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на доверенную метку времени.

**Можно ли ещё редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершайте правки перед подписью финальной версии.

**Может ли презентация содержать более одной подписи?**

Да. Добавляйте каждую подпись в коллекцию, возвращаемую [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDigitalSignatures), перед сохранением. При проверке осматривайте каждую подпись и подтверждайте наличие всех требуемых подписантов.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для PPTX. Форматы PPT и OpenDocument не поддерживаются данным API‑процессом.

**Можно ли удалить подпись, не затрагивая слайды?**

Да. Можно удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержимое слайдов остаётся, но сохранённый файл больше не содержит доказательства удалённой подписи.