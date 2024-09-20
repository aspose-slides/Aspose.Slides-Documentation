---
title: Лицензирование с учётом объёма
type: docs
weight: 100
url: /java/metered-licensing/
---

{{% alert color="primary" %}} 

Лицензирование с учётом объёма — это новый механизм лицензирования, который можно использовать наряду с существующими методами лицензирования. Если вы хотите получать счета на основе вашего использования функций API Aspose.Slides, выберите лицензирование с учётом объёма.

При покупке лицензии с учётом объёма вы получаете ключи (а не файл лицензии). Этот лицензированный ключ может быть применён с использованием класса [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/), предоставленного Aspose для операций учёта. Для получения дополнительной информации смотрите [Часто задаваемые вопросы о лицензировании с учётом объёма](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Передайте ваши открытые и закрытые ключи в метод [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Выполните некоторые операции (выполните задачи).

1. Вызовите метод [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) класса Metered.

   Вы должны увидеть объём/количество запросов API, которые вы использовали до сих пор.

Этот код на Java показывает, как установить открытые и закрытые ключи с учётом объёма:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Доступ к свойству setMeteredKey и передача открытых и закрытых ключей в качестве параметров
    metered.setMeteredKey("<действительный открытый ключ>", "<действительный закрытый ключ>");

    // Получение значения потреблённого количества до доступа к API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Потреблённое количество: " + quantityOld);


    // Получение значения потреблённого количества после доступа к API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Потреблённое количество: " + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="ПРИМЕЧАНИЕ"  %}} 

Для использования лицензирования с учётом объёма вам необходимо стабильное интернет-соединение, так как механизм лицензирования использует интернет для постоянного взаимодействия с нашими услугами и выполнения расчётов.

{{% /alert %}} 