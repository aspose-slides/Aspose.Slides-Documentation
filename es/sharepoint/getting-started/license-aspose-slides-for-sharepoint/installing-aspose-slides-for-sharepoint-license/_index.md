---
title: Instalación de la Licencia de Aspose.Slides para SharePoint
type: docs
weight: 10
url: /es/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

Una vez que estés contento con tu evaluación, puedes [comprar una licencia](https://purchase.aspose.com/buy). Antes de comprar, asegúrate de entender y aceptar los términos de la suscripción de la licencia. La licencia se envía por correo electrónico cuando se ha pagado el pedido.

La licencia es un archivo ZIP que contiene un paquete de solución regular de SharePoint. El archivo contiene:

- Aspose.Slides.SharePoint.License.wsp – el archivo del paquete de solución de SharePoint. La licencia está empaquetada como una solución de SharePoint para facilitar el despliegue y la retirada en una granja de servidores.
- readme.txt – Instrucciones de instalación de la licencia.

{{% /alert %}} 
## **Desplegando la Licencia**
La instalación de la licencia se realiza desde la consola del servidor a través de **stsadm.exe**.

{{% alert color="primary" %}} 

Se omiten las rutas en la siguiente sección para mayor claridad.

{{% /alert %}} 

Realiza los siguientes pasos para desplegar la licencia de Aspose.Slides para SharePoint:

1. Ejecuta stsadm para añadir la solución al almacén de soluciones de SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Despliega la solución en todos los servidores de la granja: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Ejecuta trabajos de temporizador administrativos para completar el despliegue de inmediato: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Recibirás una advertencia al ejecutar el paso de despliegue si el servicio de administración de Windows SharePoint Services no está en funcionamiento. **stsadm.exe** depende de este servicio y del Servicio de Temporizador de Windows SharePoint para replicar datos de la solución en toda la granja. Si estos servicios no están en funcionamiento en tu granja de servidores, es posible que necesites desplegar la licencia en cada servidor.

{{% /alert %}} 
## **Prueba de la Licencia**
Para comprobar que la licencia se ha instalado correctamente, convierte cualquier documento a un nuevo formato. Si no hay marca de agua de evaluación en el documento, la licencia se activó correctamente.