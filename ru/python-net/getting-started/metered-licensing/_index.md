---
title: Лицензирование по замерам
type: docs
weight: 90
url: /ru/python-net/metered-licensing/
---

{{% alert color="primary" %}} 

Лицензирование по замерам — это новый механизм лицензирования, который может использоваться наряду с существующими методами лицензирования. Если вы хотите, чтобы расчет стоимости происходил на основе вашего использования функций API Aspose.Slides, выбирайте лицензирование по замерам.

Когда вы приобретаете лицензию по замерам, вы получаете ключи (а не файл лицензии). Этот ключ можно применить с помощью класса [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/), предоставленного Aspose для операций с замерами. Для получения более подробной информации смотрите [Часто задаваемые вопросы о лицензировании по замерам](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Создайте экземпляр класса [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Передайте ваши публичный и приватный ключи в метод `set_metered_key`.
1. Выполните некоторые операции (выполните задачи).
1. Вызовите метод `get_consumption_quantity()` класса Metered.

   Вы должны увидеть количество API-запросов, которые вы использовали до сих пор.

Этот код на Python показывает, как установить публичные и приватные ключи по замерам:

```python
import aspose.slides as slides

# Создает экземпляр класса CAD Metered
metered = slides.Metered()

# Получает свойство set_metered_key и передает публичный и приватный ключи в качестве параметров
metered.set_metered_key("*****", "*****")

# Получает количество данных по замерам до вызова API
amountbefore = slides.metered.get_consumption_quantity()
# Отображает информацию
print("Потреблено до: " + str(amountbefore))

# Загружает документ с диска.
with slides.Presentation("Presentation.pptx") as pres:
   # Получает количество слайдов в документе
   print(len(pres.slides))
   # Сохраняет как PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# Получает количество данных по замерам после вызова API
amountafter = slides.metered.get_consumption_quantity()
# Отображает информацию
print("Потреблено после: " + str(amountafter))
```

{{% alert color="warning" title="ПРИМЕЧАНИЕ"  %}} 

Для использования лицензирования по замерам вам необходима стабильная интернет-связь, потому что механизм лицензирования использует интернет для постоянного взаимодействия с нашими службами и выполнения расчетов.

{{% /alert %}}