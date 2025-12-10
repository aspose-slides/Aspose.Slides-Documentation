---
title: Измеряемое лицензирование
type: docs
weight: 100
url: /ru/java/metered-licensing/
keywords:
- лицензия
- измеряемая лицензия
- ключи лицензии
- публичный ключ
- приватный ключ
- количество потребления
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как измеряемое лицензирование Aspose.Slides для Java позволяет гибко обрабатывать файлы PowerPoint и OpenDocument, платя только за использованное."
---

## **Применение измеряемых ключей**

{{% alert color="primary" %}} 

Измеряемое лицензирование — это новый механизм лицензирования, который может использоваться вместе с существующими методами лицензирования. Если вы хотите, чтобы оплата происходила в зависимости от использования функций API Aspose.Slides, выбирайте измеряемое лицензирование.

При покупке измеряемой лицензии вы получаете ключи (а не файл лицензии). Этот измеряемый ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) Aspose, предоставленного для операций измерения. Подробнее см. в разделе [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Передайте ваши публичный и приватный ключи в метод [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Выполните необходимую обработку (выполните задачи).

1. Вызовите метод [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) класса `Metered`.

Вы должны увидеть количество/объём запросов API, использованных до текущего момента.

Этот пример кода показывает, как использовать измеряемое лицензирование:

```java
// Creates an instance of the Metered class
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passes the public and private keys to the Metered object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Gets the consumed quantity value before API calls
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Do something with Aspose.Slides API here
    // ...

    // Gets the consumed quantity value after API calls
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Для использования измеряемого лицензирования требуется стабильное подключение к интернету, поскольку механизм лицензирования постоянно взаимодействует с нашими сервисами и выполняет расчёты.

{{% /alert %}} 

## **FAQ**

**Могу ли я использовать измеряемую лицензию вместе с обычной (постоянной или временной) в одном приложении?**

Да. Измеряемое лицензирование — дополнительный механизм, который можно использовать наряду с существующими [licensing methods](/slides/ru/java/licensing/). Вы выбираете, какой механизм применять при запуске приложения.

**Что именно считается потреблением по измеряемой лицензии: операции или файлы?**

Учтено использование API, то есть количество запросов или операций. Текущее потребление можно получить через [consumption‑tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

**Подходит ли измеряемое лицензирование для микросервисов и серверлес‑окружений, где экземпляры часто перезапускаются?**

Да. Поскольку учет ведётся на уровне вызовов API, сценарии с частыми холодными запусками совместимы, при условии стабильного сетевого доступа для расчётов измеряемой лицензии.

**Отличается ли функциональность библиотеки при использовании измеряемой лицензии от постоянной лицензии?**

Нет. Это только вопрос механизма лицензирования и оплаты; возможности продукта остаются теми же.

**Как измеряемое лицензирование соотносится с пробной версией и временной лицензией?**

Пробная версия имеет ограничения и водяные знаки, [temporary license](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а измеряемое лицензирование снимает ограничения и взимает плату только за фактическое использование.

**Можно ли контролировать бюджет, автоматически реагируя при превышении порога потребления?**

Да. Распространённый подход — периодически считывать текущее потребление через [tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) и реализовать собственные ограничения или оповещения на уровне приложения или системы мониторинга.