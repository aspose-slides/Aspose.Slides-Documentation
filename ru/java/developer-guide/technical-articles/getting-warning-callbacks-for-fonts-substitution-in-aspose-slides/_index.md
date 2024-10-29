---
title: Получение обратных вызовов предупреждений для замены шрифтов в Aspose.Slides
type: docs
weight: 90
url: /ru/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides для Java позволяет получать обратные вызовы предупреждений для замены шрифтов в случае, если используемый шрифт недоступен на машине во время процесса рендеринга. Обратные вызовы предупреждений полезны для отладки проблем с отсутствующими или недоступными шрифтами во время процесса рендеринга.

{{% /alert %}} 

Aspose.Slides для Java предоставляет простые методы API для получения обратных вызовов предупреждений во время процесса рендеринга. Следуйте указанным ниже шагам, чтобы настроить обратные вызовы предупреждений:

1. Создайте пользовательский класс обратного вызова для получения обратных вызовов.
1. Установите обратные вызовы предупреждений с помощью класса LoadOptions.
1. Загрузите файл презентации, который использует шрифт для текста, который недоступен на вашем целевом компьютере.
1. Сгенерируйте миниатюру слайда, чтобы увидеть эффект.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}