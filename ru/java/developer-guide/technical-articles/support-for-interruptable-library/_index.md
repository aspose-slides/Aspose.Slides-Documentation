---
title: Поддержка прерываемой библиотеки
type: docs
weight: 120
url: /ru/java/support-for-interruptable-library/
---

## **Прерываемая библиотека**
Теперь в Aspose.Slides добавлены структуры InterruptionToken и класс InterruptionTokenSource. Эти типы поддерживают прерывание длительных задач, таких как десериализация, сериализация или рендеринг. InterruptionTokenSource представляет источник токена или нескольких токенов, передаваемых в **ILoadOptions.InterruptionToken**. Когда ILoadOptions.InterruptionToken установлен и этот экземпляр LoadOptions передан в конструктор Presentation, любая длительная задача, связанная с этой презентацией, будет прервана, когда будет вызван метод InterruptionTokenSource.Interrupt.

Ниже приведен фрагмент кода, демонстрирующий прерывание выполняемой задачи.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}