---
title: Добавление цифровых подписей к презентациям на C++
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Узнайте, как подписывать существующие презентации PPTX с помощью сертификатов PFX и использовать Aspose.Slides для C++ для проверки или удаления цифровых подписей."
---
## **Обзор**

Цифровая подпись помогает получателю определить, кто подписал презентацию и изменилось ли подписанное содержимое. Здесь важны три связанных понятия безопасности:

- **Цифровой сертификат** — это электронное удостоверение, которое связывает личность с открытым ключом. Доверенный центр сертификации (CA) может выдать сертификат, либо организация может использовать самоподписанный сертификат для внутренних рабочих процессов.
- **Цифровая подпись** создаётся из содержимого презентации и закрытого ключа владельца сертификата. Затем открытый ключ сертификата может быть использован для проверки подписи. Подпись предоставляет доказательства происхождения и целостности; она не шифрует презентацию.
- **Защита паролем** контролирует, может ли пользователь открыть или изменить презентацию. Это отдельный механизм от цифровой подписи и описан в [Password-Protected Presentations](/slides/ru/cpp/password-protected-presentation/).

PowerPoint предоставляет команду **Add a Digital Signature** в меню **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

После открытия подписанной презентации PowerPoint может отобразить уведомление о состоянии подписи.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides раскрывает подписи через [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_digitalsignatures/), который возвращает [IDigitalSignatureCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignaturecollection/), элементы которой реализуют [IDigitalSignature](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignature/). Презентация может содержать несколько подписей.

## **Понимание сертификатов PFX и паролей**

Файл PFX, также известный как файл PKCS#12 и обычно имеющий расширение `.pfx` или `.p12`, может содержать сертификат X.509, его закрытый ключ и цепочку сертификатов. Закрытый ключ позволяет владельцу создать подпись. Сертификат без доступного закрытого ключа нельзя использовать для подписи презентации.

Пароль PFX защищает пакет сертификата и закрытый ключ. Это **не** пароль для открытия или редактирования презентации. Не сохраняйте файлы PFX и их пароли в системе контроля версий. В продакшене ограничьте доступ к файлу сертификата и получайте его пароль из хранилища секретов или другого защищённого конфигурационного источника. Ниже приведённые примеры используют переменную окружения только для того, чтобы не встраивать пароль в код.

## **Добавление цифровой подписи к презентации**

Для подписи реального рабочего процесса загрузите существующий файл PPTX, создайте [DigitalSignature](https://reference.aspose.com/slides/ru/cpp/aspose.slides/digitalsignature/) из сертификата PFX и его пароля, добавьте подпись в коллекцию презентации и сохраните в файл PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Сохранение результата под новым именем сохраняет неподписанный исходный файл. Значение [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignature/set_comments/) описывает цель подписи; это не средство контроля безопасности.

## **Проверка цифровых подписей**

При загрузке подписанного файла PPTX проверьте каждый элемент, возвращённый [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Метод [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignature/get_isvalid/) указывает, является ли встроенная подпись действительной для текущего содержимого презентации.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Недействительный результат обычно означает, что содержимое подписанной презентации или данные подписи изменились после подписи, либо файл повреждён. Удаление всех подписей приводит к неподписанной презентации, поэтому проверка только валидности элементов недостаточна: в чувствительном к безопасности процессе также необходимо убедиться, что присутствует ожидаемое количество подписей и ожидаемые идентификаторы подписантов.

Этот результат валидации не следует рассматривать как окончательное решение о доверии к сертификату. В зависимости от вашей политики безопасности приложению может потребоваться построить и проверить цепочку сертификатов X.509, проверить даты действия сертификата и статус отзыва, подтвердить ожидаемый субъект или отпечаток, проверить назначение ключа и оценить надёжный временной штамп. Значение [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignature/get_signtime/) само по себе не является доказательством от надёжного органа штампов времени.

## **Удаление цифровых подписей**

Удаление подписей меняет состояние безопасности презентации. В следующем примере загружается подписанный файл PPTX, все подписи удаляются с помощью [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignaturecollection/clear/), и сохраняется неподписанная копия.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Чтобы удалить только одну подпись, вызовите [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idigitalsignaturecollection/removeat/) с её нулевым индексом. Сохраните в новый файл, если только перезапись оригинала не является явной частью вашего рабочего процесса.

## **Редактирование и форматные соображения**

- Подпись не делает презентацию только для чтения. Пользователи и приложения всё ещё могут редактировать файл, но изменения подписанного содержимого обычно делают существующую подпись недействительной.
- Выполните все необходимые правки до подписи. Если презентацию нужно изменить, сохраните исправленную версию и подпишите её заново.
- Оставляйте конечный результат в формате PPTX. Конвертация подписанной презентации в другой формат не переносит оригинальную подпись PPTX как действительную подпись в преобразованном файле.
- Относитесь к закрытому ключу сертификата как к конфиденциальному. Любой, кто получит закрытый ключ и его пароль, может создавать подписи, выглядящие так, будто они созданы владельцем сертификата.
- Сохраняйте неподписанный исходный файл или другую контролируемую копию, если это требуется вашей политикой хранения документов.

## **FAQ**

**Шифрует ли цифровая подпись презентацию?**

Нет. Цифровая подпись предоставляет доказательства происхождения и целостности, но содержимое презентации остаётся читаемым, если не применено отдельное шифрование. Используйте [password protection](/slides/ru/cpp/password-protected-presentation/), когда необходимо ограничить доступ к содержимому.

**Является ли пароль PFX тем же самым, что пароль презентации?**

Нет. Пароль PFX разблокирует закрытый ключ, хранящийся в пакете сертификата. Он не контролирует, кто может открыть или редактировать файл PPTX.

**Можно ли использовать самоподписанный сертификат?**

Технически самоподписанный сертификат может быть использован, если в нём есть доступный закрытый ключ. Получатели автоматически не будут ему доверять, если только сертификат явно не добавлен в их доверенную среду. В публичных или межорганизационных процессах обычно используют сертификат, выданный доверенным CA.

**Что делает подпись недействительной?**

Изменение подписанного содержимого презентации или данных подписи после подписи делает подпись недействительной. Повреждение файла также может привести к ошибке валидации. Если все подписи удалены, презентация считается неподписанной, а не содержащей недействительную подпись.

**Означает ли действительная подпись, что её следует доверять?**

Не обязательно. Целостность подписи и доверие к подписанту — это отдельные решения. Политика проверки в продакшене должна также проверять цепочку сертификатов, срок действия, статус отзыва, ожидаемую личность, назначение ключа и любые требования к надёжному временнóму штампу.

**Что происходит, когда срок действия сертификата истекает?**

Истечение срока действия сертификата не изменяет байты презентации, но влияет на оценку доверия к сертификату. Приёмлемость подписи зависит от вашей политики и от того, подтверждает ли надёжный временной штамп, что подпись была выполнена, пока сертификат был действителен. Не полагайтесь только на отображаемое время подписи как на надёжный штамп времени.

**Можно ли продолжать редактировать подписанную презентацию?**

Да. Подпись не блокирует файл. Редактирование подписанного содержимого обычно делает существующую подпись недействительной, поэтому завершите работу над презентацией и подпишите окончательную версию.

**Может ли презентация содержать более одной подписи?**

Да. Добавьте каждую подпись в коллекцию, возвращаемую [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_digitalsignatures/), перед сохранением. При проверке просмотрите каждую подпись и убедитесь, что все требуемые подписанты присутствуют.

**Какие форматы презентаций поддерживают эти операции?**

Aspose.Slides поддерживает описанные здесь операции с цифровой подписью только для PPTX. Форматы PPT и OpenDocument не поддерживаются этим API.

**Можно ли удалить подпись, не затронув слайды?**

Да. Вы можете удалить одну подпись или очистить всю коллекцию, а затем сохранить презентацию. Содержание слайдов останется доступным, но сохранённый файл больше не будет содержать доказательства подписи.