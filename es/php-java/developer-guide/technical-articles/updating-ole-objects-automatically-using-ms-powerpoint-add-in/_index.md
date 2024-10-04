---
title: Actualización automática de objetos OLE utilizando el complemento de MS PowerPoint
type: docs
weight: 10
url: /es/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Sobre la actualización automática de objetos OLE**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides es cómo crear o cambiar gráficos editables u otros objetos OLE y hacer que se actualicen automáticamente al abrir la presentación. Desafortunadamente, PowerPoint no admite macros automáticas, que están disponibles en Excel y Word. Las únicas disponibles son las macros Auto_Open y Auto_Close. Sin embargo, estas solo se ejecutan automáticamente desde un complemento. Este breve consejo técnico muestra cómo lograr eso.

Primero, hay varios complementos gratuitos que agregan la función de macro Auto_Open a PowerPoint, por ejemplo, [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) y [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Después de instalar dicho complemento, simplemente agrega la macro Auto_Open() (OnPresentationOpen() en el caso de "Event Generator") a tu presentación de plantilla como se muestra a continuación:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}

{{% alert color="primary" %}}

Cualquier cambio realizado en objetos OLE con Aspose.Slides se actualizará automáticamente cuando PowerPoint abra la presentación. Si tienes muchos objetos OLE en una presentación y no deseas actualizarlos todos, simplemente agrega una etiqueta personalizada a las formas que necesitas procesar y verifícalo en la macro.

{{% /alert %}}