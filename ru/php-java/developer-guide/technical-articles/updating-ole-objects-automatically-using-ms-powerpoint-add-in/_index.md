---
title: Автоматическое обновление объектов OLE с использованием надстройки MS PowerPoint
type: docs
weight: 10
url: /php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Об обновлении объектов OLE автоматически**
Один из наиболее частых вопросов, задаваемых клиентами Aspose.Slides, заключается в том, как создать или изменить редактируемые диаграммы или любые другие объекты OLE и заставить их автоматически обновляться при открытии презентации. К сожалению, PowerPoint не поддерживает автоматические макросы, которые доступны в Excel и Word. Единственными доступными являются макросы Auto_Open и Auto_Close. Однако они запускаются автоматически только из надстройки. Этот краткий технический совет показывает, как это осуществить.

Во-первых, доступно несколько бесплатных надстроек, которые добавляют функцию макроса Auto_Open в PowerPoint, например, [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) и [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

После установки такой надстройки просто добавьте макрос Auto_Open() (OnPresentationOpen() в случае "Event Generator") в свою шаблонную презентацию, как показано ниже:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

Любые изменения, внесенные в объекты OLE с помощью Aspose.Slides, будут автоматически обновлены, когда PowerPoint откроет презентацию. Если у вас много объектов OLE в презентации и вы не хотите обновлять их все, просто добавьте пользовательский тег к формам, которые нужно обработать, и проверьте его в макросе.

{{% /alert %}}