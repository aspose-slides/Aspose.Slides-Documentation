---
title: Создать новую презентацию
type: docs
weight: 10
url: /ru/java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO был разработан, чтобы позволить разработчикам создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но обернут внутри объекта .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET framework, а также времени выполнения Microsoft Office на базе CLR. Хотя он может быть использован для создания надстроек Microsoft Office, его практически невозможно использовать в качестве серверного компонента. У него также есть серьезные проблемы с развертыванием.

Aspose.Slides для Java — это компонент, который можно использовать для работы с презентациями Microsoft PowerPoint, так же как и VSTO, но у него есть несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки времени выполнения Microsoft Office. 
- Его можно использовать как клиентский компонент или как серверный компонент.
- Развертывание простое, так как Aspose.Slides содержится в одном файле jar.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, которые иллюстрируют, как VSTO и Aspose.Slides для Java могут быть использованы для достижения одной и той же цели. Первый пример — [VSTO](/slides/ru/java/create-a-new-presentation/); [второй пример](/slides/ru/java/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Пример Aspose.Slides для Java**
**Вывод Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}