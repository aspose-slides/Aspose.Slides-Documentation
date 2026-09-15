---
title: Лицензирование с расчётом по использованию
type: docs
weight: 100
url: /ru/python-java/metered-licensing/
keywords:
- лицензия
- лицензия с расчётом по использованию
- ключи лицензии
- публичный ключ
- приватный ключ
- объём потребления
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Python через Java с лицензированием по расчёту позволяет гибко обрабатывать файлы PowerPoint и OpenDocument, платя только за фактически использованные ресурсы."
---
## **Введение**

Метод лицензирования с расчётом по использованию (metered licensing) — это механизм лицензирования, который можно применять вместе с существующими методами лицензирования. Если вы хотите платить за использование функций Aspose.Slides API согласно вашему потреблению, выберите лицензирование с расчётом по использованию.

## **Применение ключей meter‑ed**

{{% alert color="info" title="Примечание" %}}

Метод лицензирования с расчётом по использованию — новый механизм, который можно использовать вместе с существующими методами лицензирования. Если вы хотите платить за использование функций Aspose.Slides API согласно вашему потреблению, выберите лицензирование с расчётом по использованию.

При покупке лицензии с расчётом по использованию вы получаете ключи (а не файл лицензии). Этот ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/) , предоставляемого Aspose для операций учёта. Подробнее см. [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/).

1. Передайте ваши публичный и приватный ключи в метод [setMeteredKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/#setMeteredKey).

1. Выполните необходимую обработку (выполните задачи).

1. Вызовите метод [getConsumptionQuantity](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/#getConsumptionQuantity) класса [Metered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/).

Вы должны увидеть количество/объём запросов к API, которые вы использовали до сих пор.

Этот пример кода показывает, как использовать лицензирование с расчётом по использованию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Создать экземпляр класса Metered.
metered = Metered()

try:
    # Передать публичный и приватный ключи объекту Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Получить потреблённое количество до вызовов API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Выполнить что‑то с API Aspose.Slides здесь.
    # ...

    # Получить потреблённое количество после вызовов API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Предупреждение" %}}

Для использования лицензирования с расчётом по использованию требуется стабильное интернет‑соединение, поскольку механизм лицензирования постоянно взаимодействует с нашими сервисами и выполняет вычисления.

{{% /alert %}}

## **Вопросы и ответы**

**Могу ли я использовать лицензию с расчётом по использованию вместе с обычной (постоянной или временной) в одном приложении?**

Да. Metered — дополнительный механизм лицензирования, который можно использовать наряду с существующими [licensing methods](/slides/ru/python-java/licensing/). Вы выбираете, какой механизм применить при запуске приложения.

**Что именно учитывается как потребление по лицензии с расчётом по использованию: операции или файлы?**

Учёт ведётся по использованию API, то есть по количеству запросов или операций. Текущее потребление можно получить с помощью [consumption‑tracking methods](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/).

**Подходит ли meter‑ed для микросервисов и серверless‑сред, где экземпляры часто перезапускаются?**

Да. Поскольку учёт происходит на уровне вызовов API, сценарии с частыми холодными запусками совместимы, при условии стабильного сетевого доступа для вычислений meter‑ed.

**Отличается ли функциональность библиотеки при использовании лицензии с расчётом по использованию от постоянной лицензии?**

Нет. Это лишь различие в механизме лицензирования и оплаты; возможности продукта остаются теми же.

**Как meter‑ed соотносится с пробной версией и временной лицензией?**

Пробная версия имеет ограничения и водяные знаки, [temporary license](https://purchase.aspose.com/temporary-license/) снимает ограничения на 30 дней, а meter‑ed снимает ограничения и взимает плату на основе фактического использования.

**Могу ли я контролировать бюджет, автоматически реагируя при превышении порога потребления?**

Да. Распространённая практика — периодически считывать текущее потребление через [tracking methods](https://reference.aspose.com/slides/ru/python-java/aspose.slides/metered/) и реализовывать собственные лимиты или оповещения на уровне приложения или системы мониторинга.