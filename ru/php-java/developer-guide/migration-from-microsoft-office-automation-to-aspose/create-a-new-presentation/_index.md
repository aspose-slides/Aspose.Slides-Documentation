---
title: Создание новой презентации
type: docs
weight: 10
url: /ru/php-java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO был разработан для того, чтобы дать разработчикам возможность создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но он обернут в объект .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET framework, а также среды выполнения Microsoft Office для CLR. Хотя его можно использовать для создания надстроек Microsoft Office, практически невозможно использовать его в качестве компонента на стороне сервера. У него также есть серьезные проблемы с развертыванием.

Aspose.Slides для PHP через Java — это компонент, который можно использовать для манипуляции презентациями Microsoft PowerPoint, так же как и VSTO, но у него есть несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как компонент на стороне клиента или как компонент на стороне сервера.
- Развертывание простое, так как Aspose.Slides содержится в одном jar-файле.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, которые иллюстрируют, как VSTO и Aspose.Slides для PHP через Java могут быть использованы для достижения одной и той же цели. Первый пример — [VSTO](/slides/ru/php-java/create-a-new-presentation/); [второй пример](/slides/ru/php-java/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Пример Aspose.Slides для PHP через Java**
**Вывод Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}