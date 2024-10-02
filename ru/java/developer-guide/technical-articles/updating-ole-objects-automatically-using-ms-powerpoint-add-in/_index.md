---
title: Автоматическое обновление OLE-объектов с помощью надстройки MS PowerPoint
type: docs
weight: 10
url: /ru/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Об автоматическом обновлении OLE-объектов**
Один из самых частых вопросов, задаваемых клиентами Aspose.Slides, касается того, как создать или изменить редактируемые графики или другие OLE-объекты и сделать так, чтобы они автоматически обновлялись при открытии презентации. К сожалению, PowerPoint не поддерживает автоматические макросы, доступные в Excel и Word. Единственные доступные - это макросы Auto_Open и Auto_Close. Однако они запускаются автоматически только из надстройки. Этот короткий технический совет показывает, как этого добиться.

Во-первых, существуют несколько бесплатных надстроек, которые добавляют возможность макроса Auto_Open в PowerPoint, например, [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) и [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

После установки такой надстройки просто добавьте макрос Auto_Open() (OnPresentationOpen() в случае "Event Generator") в вашу шаблонную презентацию, как показано ниже:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}


{{% alert color="primary" %}} 

Любое изменение, внесенное в OLE-объекты с помощью Aspose.Slides, будет автоматически обновлено, когда PowerPoint открывает презентацию. Если у вас есть много OLE-объектов в презентации и вы не хотите обновлять их все, просто добавьте пользовательский тег к формам, которые нужно обработать, и проверьте его в макросе.

{{% /alert %}}