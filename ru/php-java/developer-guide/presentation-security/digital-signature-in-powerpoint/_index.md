---
title: Добавить цифровые подписи к презентациям в PHP
linktitle: Цифровая подпись
type: docs
weight: 10
url: /ru/php-java/digital-signature-in-powerpoint/
keywords:
- цифровая подпись
- цифровой сертификат
- центр сертификации
- сертификат PFX
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как цифрово подписать файлы PowerPoint & OpenDocument с помощью Aspose.Slides для PHP через Java. Защитите свои слайды за секунды с понятными примерами кода."
---

**Цифровой сертификат** используется для создания защищённой паролем презентации PowerPoint, отмеченной как созданная определённой организацией или лицом. Цифровый сертификат можно получить, обратившись в уполномоченную организацию — центр сертификации. После установки цифрового сертификата в систему им можно добавить цифровую подпись к презентации через Файл → Сведения → Защита презентации:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации в PowerPoint появится специальное сообщение:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Для подписи презентации или проверки подлинности подписей презентации **Aspose.Slides API** предоставляет интерфейсы [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) и метод [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--) . В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Добавление цифровой подписи из сертификата PFX**
Ниже приведён пример кода, демонстрирующий, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX объекту [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
1. Добавьте созданную подпись в объект презентации.
```php
  # Открытие файла презентации
  $pres = new Presentation();
  try {
    # Создание объекта DigitalSignature с файлом PFX и паролем PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Комментарий к новой цифровой подписи
    $signature->setComments("Aspose.Slides digital signing test.");
    # Добавление цифровой подписи к презентации
    $pres->getDigitalSignatures()->add($signature);
    # Сохранение презентации
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Теперь можно проверить, подписана ли презентация цифровой подписью и не была ли изменена:
```php
  # Открыть презентацию
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Проверить, являются ли все цифровые подписи действительными
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Можно ли удалить существующие подписи из файла?**

Да. Коллекция цифровых подписей поддерживает [удаление отдельных элементов](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) и [полную очистку](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/); после сохранения файла в презентации не будет подписей.

**Становится ли файл «только для чтения» после подписи?**

Нет. Подпись сохраняет целостность и авторство, но не блокирует редактирование. Чтобы ограничить редактирование, сочетайте её с ["Только для чтения" или паролем](/slides/ru/php-java/password-protected-presentation/).

**Будет ли подпись корректно отображаться в разных версиях PowerPoint?**

Подпись создаётся для контейнера OOXML (PPTX). Современные версии PowerPoint, поддерживающие подписи OOXML, правильно отображают статус таких подписей.