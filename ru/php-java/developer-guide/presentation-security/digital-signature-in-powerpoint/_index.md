---
title: Цифровая подпись в PowerPoint
type: docs
weight: 10
url: /php-java/digital-signature-in-powerpoint/
keywords: "Сертификат цифровой подписи, удостоверяющий центр"
description: "Добавьте сертификат цифровой подписи, удостоверяющий центр в презентацию PowerPoint с помощью Aspose.Slides."
---

**Цифровой сертификат** используется для создания паролем защищенной презентации PowerPoint, которая отмечена как созданная конкретной организацией или человеком. Цифровой сертификат можно получить, обратившись в уполномоченную организацию - удостоверяющий центр. После установки цифрового сертификата в систему его можно использовать для добавления цифровой подписи к презентации через Файл -> Информация -> Защитить презентацию:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Презентация может содержать более одной цифровой подписи. После добавления цифровой подписи к презентации особое сообщение появится в PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Для подписания презентации или проверки подлинности подписей в презентации **Aspose.Slides API** предоставляет интерфейс [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature), интерфейс [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) и метод [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--). В настоящее время цифровые подписи поддерживаются только для формата PPTX.
## **Добавить цифровую подпись из сертификата PFX**
Пример кода ниже демонстрирует, как добавить цифровую подпись из сертификата PFX:

1. Откройте файл PFX и передайте пароль PFX в объект [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
2. Добавьте созданную подпись в объект презентации.

```php
  # Открытие файла презентации
  $pres = new Presentation();
  try {
    # Создание объекта DigitalSignature с файлом PFX и паролем PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Комментарий к новой цифровой подписи
    $signature->setComments("Тест цифровой подписи Aspose.Slides.");
    # Добавление цифровой подписи в презентацию
    $pres->getDigitalSignatures()->add($signature);
    # Сохранение презентации
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Теперь можно проверить, была ли презентация подписана цифровой подписью и не была ли изменена:

```php
  # Открытие презентации
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Подписи, использованные для подписания презентации: ");
      # Проверка, все ли цифровые подписи действительны
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "ДЕЙСТВИТЕЛЬНО" : "НЕДЕЙСТВИТЕЛЬНО");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Презентация подлинная, все подписи действительны.");
      } else {
        echo("Презентация была изменена после подписания.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```