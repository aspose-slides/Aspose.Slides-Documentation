---
title: Лицензирование по потреблению
type: docs
weight: 100
url: /ru/nodejs-java/metered-licensing/
keywords:
- лицензия
- лицензирование по потреблению
- Node.js
- Java
- Aspose.Slides для Node.js через Java
---

## **Применить Metered‑ключи**

{{% alert color="primary" %}} 

Metered licensing — это новый механизм лицензирования, который можно использовать вместе с существующими методами лицензирования. Если вы хотите платить за использование возможностей API Aspose.Slides, выбирайте Metered licensing.

При покупке Metered‑лицензии вы получаете ключи (а не файл лицензии). Этот Metered‑ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) , который Aspose предоставляет для операций измерения. Для получения более подробной информации см. [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

1. Передайте свои открытый и закрытый ключи в метод [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Выполните обработку (выполните задачи).

1. Вызовите метод [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) класса `Metered`.

Вы увидите количество запросов API, которые вы потребили до настоящего момента.

Этот пример кода показывает, как использовать Metered licensing:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создаёт экземпляр класса Metered
var metered = new aspose.slides.Metered();

// Передаёт открытый и закрытый ключи объекту Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Получает значение потреблённого количества до вызовов API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Выполните какие‑то действия с API Aspose.Slides здесь
// ...

// Получает значение потреблённого количества после вызовов API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

Для использования Metered licensing требуется стабильное подключение к Интернету, поскольку механизм лицензирования постоянно взаимодействует с нашими сервисами через Интернет и выполняет расчёты.

{{% /alert %}} 

## **FAQ**

**Могу ли я использовать Metered‑лицензию вместе с обычной (постоянной или временной) в одном приложении?**

Да. Metered — это дополнительный механизм лицензирования, который можно использовать вместе с существующими [licensing methods](/slides/ru/nodejs-java/licensing/). Вы выбираете, какой механизм применять при запуске приложения.

**Что именно считается потреблением по Metered‑лицензии: операции или файлы?**

Считается использование API, то есть количество запросов или операций. Текущее потребление можно получить с помощью [consumption-tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**Подходит ли Metered для микросервисов и безсерверных сред, где экземпляры часто перезапускаются?**

Да. Поскольку учёт происходит на уровне вызовов API, сценарии с частыми холодными запусками совместимы, при условии наличия стабильного сетевого доступа для расчётов Metered.

**Отличается ли функциональность библиотеки при использовании Metered‑лицензии от постоянной лицензии?**

Нет. Это касается лишь механизма лицензирования и расчётов; возможности продукта остаются теми же.

**Как Metered соотносится с пробной версией и временной лицензией?**

В пробной версии есть ограничения и водяные знаки, [temporary license](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а Metered снимает ограничения и взимает плату в зависимости от фактического использования.

**Могу ли я контролировать бюджет, автоматически реагируя при превышении порога потребления?**

Да. Распространённый подход — периодически считывать текущее потребление через [tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) и реализовывать собственные ограничения или оповещения на уровне приложения или системы мониторинга.