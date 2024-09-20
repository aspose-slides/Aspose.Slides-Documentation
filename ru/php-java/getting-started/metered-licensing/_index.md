---
title: Лицензирование по измерению
type: docs
weight: 100
url: /php-java/metered-licensing/
---

{{% alert color="primary" %}} 

Лицензирование по измерению — это новый механизм лицензирования, который можно использовать наряду с существующими методами лицензирования. Если вы хотите, чтобы вам выставляли счета на основе использования функций API Aspose.Slides, выберите лицензирование по измерению.

Когда вы покупаете лицензию по измерению, вы получаете ключи (а не файл лицензии). Этот измерительный ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/), предоставленного Aspose для операций измерения. Для получения дополнительных сведений смотрите [Часто задаваемые вопросы по лицензированию по измерению](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. Передайте ваши публичные и частные ключи методу [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Выполните некоторую обработку (выполните задачи).

1. Вызовите метод [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) класса Metered.

   Вы должны увидеть количество/объем API-запросов, которые вы использовали до сих пор.

Этот код на PHP показывает, как установить публичные и частные ключи для измерения:

```php
  $metered = new Metered();
  try {
    // Доступ к свойству setMeteredKey и передача публичного и частного ключей в качестве параметров
    $metered->setMeteredKey("<действительный публичный ключ>", "<действительный частный ключ>");
    // Получает значение потребляемого объема до обращения к API
    $quantityOld = Metered->getConsumptionQuantity();
    echo("Количество потребления" . $quantityOld);
    // Получает значение потребляемого объема после обращения к API
    $quantity = Metered->getConsumptionQuantity();
    echo("Количество потребления" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="ПРИМЕЧАНИЕ"  %}} 

Для использования лицензирования по измерению вам необходимо стабильное подключение к Интернету, так как механизм лицензирования использует Интернет для постоянного взаимодействия с нашими услугами и выполнения расчетов.

{{% /alert %}} 