---
title: Измеряемое лицензирование
type: docs
weight: 90
url: /ru/net/metered-licensing/
---

{{% alert color="primary" %}} 

Измеряемое лицензирование – это новый механизм лицензирования, который можно использовать вместе с существующими методами лицензирования. Если вы хотите получать счета на основании вашего использования функций API Aspose.Slides, выберите измеряемое лицензирование.

Когда вы покупаете измеряемую лицензию, вы получаете ключи (а не файл лицензии). Этот измеряемый ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/), предоставленного Aspose для операций измерения. Для получения дополнительной информации см. [Часто задаваемые вопросы по измеряемому лицензированию](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Передайте свои публичные и приватные ключи в метод [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Выполните некоторые обработки (выполните задачи).
1. Вызовите метод [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) класса Metered.

   Вы должны увидеть количество API-запросов, которые вы израсходовали до настоящего времени.

Этот код на C# показывает, как установить публичные и приватные ключи для измеряемого лицензирования:

```c#
//  Создает экземпляр класса Metered
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  Получает доступ к свойству SetMeteredKey и передает публичные и приватные ключи в качестве параметров
	metered.SetMeteredKey("*****", "*****");

//  Получает количество измеряемых данных до вызова API
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Отображает информацию
	Console.WriteLine("Количество использованных данных до: " + amountbefore.ToString());

//  Получает количество измеряемых данных после вызова API
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Отображает информацию
	Console.WriteLine("Количество использованных данных после: " + amountafter.ToString());
```

{{% alert color="warning" title="ЗАМЕТКА"  %}} 

Для использования измеряемого лицензирования вам необходимо стабильное соединение с интернетом, так как механизм лицензирования использует интернет для постоянного взаимодействия с нашими услугами и выполнения расчетов.

{{% /alert %}} 