---
title: Лицензирование с учётом объёма
type: docs
weight: 90
url: /ru/net/metered-licensing/
keywords:
- лицензия
- лицензия с учётом объёма
- лицензионные ключи
- публичный ключ
- приватный ключ
- потребляемое количество
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как лицензирование с учётом объёма Aspose.Slides для .NET позволяет гибко обрабатывать файлы PowerPoint и OpenDocument, оплачивая только фактическое использование."
---

## **Применение ключей с учётом объёма**

{{% alert color="primary" %}} 

Метрическое лицензирование — это новый механизм лицензирования, который может использоваться совместно с существующими методами лицензирования. Если вы хотите платить за использование функций API Aspose.Slides на основе фактического применения, выбирайте метрическое лицензирование.

При покупке метрической лицензии вы получаете ключи (а не файл лицензии). Этот метрический ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/), предоставленного Aspose для операций учёта. Подробнее см. в разделе [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Передайте публичный и приватный ключи в метод [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Выполните необходимую обработку (выполните задачи).
1. Вызовите метод [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) класса `Metered`.

Вы увидите количество/объём запросов к API, которые вы уже использовали.

Ниже пример кода, показывающий, как использовать метрическое лицензирование:

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

Для использования метрического лицензирования требуется стабильное интернет‑соединение, поскольку механизм лицензирования постоянно взаимодействует с нашими сервисами и выполняет расчёты через сеть.

{{% /alert %}} 

## **FAQ**

**Можно ли использовать метрическую лицензию вместе с обычной (постоянной или временной) в одном приложении?**

Да. Метрическое лицензирование — это дополнительный механизм, который можно использовать совместно с существующими [licensing methods](/slides/ru/net/licensing/). Вы выбираете, какой механизм применить при запуске приложения.

**Что именно считается расходом при метрической лицензии: операции или файлы?**

Учёт ведётся за использованием API, то есть за количеством запросов или операций. Текущий расход можно получить через [consumption‑tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**Подходит ли метрическое лицензирование для микросервисов и серверлесс‑сред, где экземпляры часто перезапускаются?**

Да. Поскольку учёт производится на уровне вызовов API, сценарии с частыми холодными запусками совместимы, при условии стабильного сетевого доступа для метрических расчётов.

**Отличается ли функциональность библиотеки при использовании метрической лицензии от постоянной лицензии?**

Нет. Это касается только механизма лицензирования и оплаты; возможности продукта остаются теми же.

**Как метрическое лицензирование связано с пробной версией и временной лицензией?**

Пробная версия имеет ограничения и водяные знаки, [temporary license](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а метрическое лицензирование снимает ограничения и взимает плату только за фактическое использование.

**Можно ли контролировать бюджет, автоматически реагируя при превышении порога расхода?**

Да. Распространённый подход — периодически считывать текущий расход через [tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) и реализовывать собственные лимиты или оповещения на уровне приложения или мониторинга.