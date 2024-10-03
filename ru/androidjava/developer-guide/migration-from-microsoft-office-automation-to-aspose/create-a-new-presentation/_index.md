---
title: Создание новой презентации
type: docs
weight: 10
url: /ru/androidjava/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO был разработан для того, чтобы разработчики могли создавать приложения, которые могли бы работать внутри Microsoft Office. VSTO основан на COM, но он обернут внутри объекта .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET-фреймворка, а также среды выполнения CLR Microsoft Office. Хотя его можно использовать для создания надстроек Microsoft Office, практически невозможно использовать его в качестве компонента на стороне сервера. У него также есть серьезные проблемы с развертыванием.

Aspose.Slides для Android через Java - это компонент, который можно использовать для работы с презентациями Microsoft PowerPoint, так же как и VSTO, но у него есть несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как компонент на стороне клиента или на стороне сервера.
- Развертывание простое, так как Aspose.Slides содержится в одном jar-файле.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, которые иллюстрируют, как VSTO и Aspose.Slides для Android через Java могут использоваться для достижения одной и той же цели. Первый пример - это [VSTO](/slides/ru/androidjava/create-a-new-presentation/); [второй пример](/slides/ru/androidjava/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Пример Aspose.Slides для Android через Java**
**Вывод от Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}