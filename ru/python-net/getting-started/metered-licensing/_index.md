---
title: Лицензирование с измерением
type: docs
weight: 90
url: /ru/python-net/metered-licensing/
keywords:
- лицензия
- лицензия с измерением
- лицензионные ключи
- публичный ключ
- приватный ключ
- количество потребления
- Python
- Aspose.Slides
description: "Узнайте, как лицензирование с измерением Aspose.Slides for Python via .NET позволяет гибко обрабатывать файлы PowerPoint и OpenDocument, оплачивая только фактически использованные функции."
---

## **Применение измерительных ключей**

{{% alert color="primary" %}} 

Лицензирование с измерением — это новый механизм лицензирования, который может использоваться вместе с существующими методами лицензирования. Если вы хотите платить за использование функций API Aspose.Slides в зависимости от объёма, выбирайте лицензирование с измерением.

При покупке лицензии с измерением вы получаете ключи (а не файл лицензии). Этот измерительный ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/), предоставленного Aspose для операций измерения. Подробнее см. [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Передайте ваши публичный и приватный ключи в метод [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Выполните необходимую обработку (выполните задачи).
1. Вызовите метод [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) класса `Metered`.

Вы должны увидеть количество/объём запросов API, которые вы использовали до текущего момента.

Этот пример кода показывает, как использовать лицензирование с измерением:

```python
import aspose.slides as slides

# Creates an instance of the Metered class
metered = slides.Metered()

# Passes the public and private keys to the Metered object
metered.set_metered_key("<valid public key>", "<valid private key>")

# Gets the consumed quantity value before API calls
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Do something with Aspose.Slides API here
# ...

# Gets the consumed quantity value after API calls
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Для использования лицензирования с измерением необходима стабильная интернет‑связь, поскольку механизм лицензирования постоянно взаимодействует с нашими сервисами и выполняет расчёты через сеть.

{{% /alert %}} 

## **Вопросы и ответы**

**Можно ли использовать лицензию с измерением вместе с обычной (постоянной или временной) в одном приложении?**

Да. Лицензирование с измерением — дополнительный механизм, который может использоваться вместе с существующими [методами лицензирования](/slides/ru/python-net/licensing/). Вы выбираете, какой механизм применять при запуске приложения.

**Что именно учитывается как потребление по лицензии с измерением: операции или файлы?**

Учтено использование API, то есть количество запросов или операций. Текущее потребление можно получить с помощью [методов отслеживания потребления](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**Подходит ли лицензирование с измерением для микросервисов и безсерверных окружений, где экземпляры часто перезапускаются?**

Да. Поскольку учёт происходит на уровне запросов API, сценарии с частыми холодными запусками совместимы, при условии наличия стабильного сетевого доступа для расчётов лицензирования с измерением.

**Отличается ли функциональность библиотеки при использовании лицензии с измерением от постоянной лицензии?**

Нет. Это только различие в механизме лицензирования и выставления счетов; возможности продукта остаются теми же.

**Как лицензирование с измерением связано с пробной версией и временной лицензией?**

Пробная версия имеет ограничения и водяные знаки, [временная лицензия](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а лицензия с измерением снимает ограничения и взимает плату за фактическое использование.

**Можно ли контролировать бюджет, автоматически реагируя при превышении порога потребления?**

Да. Распространённый подход — периодически читать текущее потребление с помощью [методов отслеживания](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) и реализовывать собственные ограничения или оповещения на уровне приложения или мониторинга.