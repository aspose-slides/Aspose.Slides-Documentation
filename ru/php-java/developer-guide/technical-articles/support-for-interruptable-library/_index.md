---
title: Поддержка для прерываемой библиотеки
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **Прерываемая библиотека**
Теперь в Aspose.Slides добавлены структуры InterruptionToken и класс InterruptionTokenSource. Эти типы поддерживают прерывание долгих задач, таких как десериализация, сериализация или рендеринг. InterruptionTokenSource представляет собой источник токена или нескольких токенов, переданных в **ILoadOptions.InterruptionToken**. Когда ILoadOptions.InterruptionToken установлен и этот экземпляр LoadOptions передан в конструктор Presentation, любая долгосрочная задача, связанная с этой презентацией, будет прервана, когда будет вызван метод InterruptionTokenSource.Interrupt.

Ниже приведен фрагмент кода, демонстрирующий прерывание выполняемой задачи.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}