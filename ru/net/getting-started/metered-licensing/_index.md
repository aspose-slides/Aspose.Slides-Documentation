---
title: Лицензирование с измерением
type: docs
weight: 90
url: /ru/net/metered-licensing/
keywords:
- лицензия
- лицензирование с измерением
- C#
- Aspose.Slides для .NET
---

## **Применение счётных ключей**

{{% alert color="primary" %}} 

Лицензирование с измерением — новый механизм лицензирования, который может использоваться вместе с существующими методами лицензирования. Если вы хотите платить за использование функций API Aspose.Slides на основе фактического использования, выбираете лицензирование с измерением.

При покупке лицензии с измерением вы получаете ключи (а не файл лицензии). Этот ключ с измерением можно применить с помощью класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) от Aspose, предоставленного для операций измерения. Подробнее см. в разделе [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Передайте ваши публичный и приватный ключи в метод [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Выполните некоторую обработку (выполните задачи).
1. Вызовите метод [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) класса `Metered`.

Вы должны увидеть количество/объём запросов API, использованных до сих пор.

Этот пример кода показывает, как использовать лицензирование с измерением:

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Для использования лицензирования с измерением требуется стабильное интернет‑соединение, так как механизм лицензирования постоянно взаимодействует с нашими сервисами через интернет и выполняет вычисления.

{{% /alert %}} 

## **FAQ**

**Можно ли использовать лицензию с измерением вместе с обычной (постоянной или временной) в одном приложении?**

Да. Лицензирование с измерением — дополнительный механизм, который может использоваться вместе с существующими [методами лицензирования](/slides/ru/net/licensing/). Вы выбираете, какой механизм применять при запуске приложения.

**Что именно учитывается как потребление по лицензии с измерением: операции или файлы?**

Учёт ведётся по использованию API, то есть по количеству запросов или операций. Текущие данные о потреблении можно получить с помощью [методов отслеживания потребления](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**Подходит ли лицензирование с измерением для микросервисов и безсерверных окружений, где экземпляры часто перезапускаются?**

Да. Поскольку учёт происходит на уровне вызова API, сценарии с частыми холодными запусками совместимы, при условии наличия стабильного сетевого доступа для вычислений лицензирования с измерением.

**Отличается ли функциональность библиотеки при использовании лицензии с измерением от постоянной лицензии?**

Нет. Это касается только механизма лицензирования и оплаты; возможности продукта остаются теми же.

**Как лицензирование с измерением соотносится с пробной версией и временной лицензией?**

Пробная версия имеет ограничения и водяные знаки, [временная лицензия](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а лицензирование с измерением снимает ограничения и взимает плату за фактическое использование.

**Могу ли я контролировать бюджет, автоматически реагируя, когда превышен порог потребления?**

Да. Распространённый подход — периодически считывать текущее потребление с помощью [методов отслеживания](https://reference.aspose.com/slides/net/aspose.slides/metered/) и реализовать собственные ограничения или оповещения на уровне приложения или мониторинга.