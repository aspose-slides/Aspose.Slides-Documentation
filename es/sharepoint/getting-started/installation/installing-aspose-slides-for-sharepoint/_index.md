---
title: Instalación de Aspose.Slides para SharePoint
type: docs
weight: 10
url: /es/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Instale Aspose.Slides para SharePoint en una granja de SharePoint: elija el programa de instalación para su versión de SharePoint, ejecute la verificación del sistema y despliegue y active la solución."
---
## **Contenido del paquete**

Aspose.Slides for SharePoint se descarga desde la [página de descarga](https://releases.aspose.com/slides/sharepoint/) como un archivo ZIP. El archivo contiene un paquete de solución de SharePoint (WSP) y un programa de instalación para cada versión de SharePoint compatible:

| Versión de SharePoint | Programa de instalación | Paquete de solución |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Cada programa de instalación tiene un archivo de configuración junto a él (por ejemplo, *Setup2019.exe.config*) que indica el paquete de solución que instala. La carpeta *License* contiene un enlace al acuerdo de licencia de usuario final y a los avisos de licencias de terceros.

Aspose.Slides for SharePoint se empaqueta como una solución de SharePoint, que SharePoint despliega en toda la granja de servidores. Su característica se activa o desactiva por colección de sitios.

## **Proceso de instalación**

Antes de la instalación, el programa de instalación ejecuta una verificación del sistema. Comprueba que:

- SharePoint está instalado en el servidor.
- El usuario actual tiene permiso para instalar y desplegar soluciones de SharePoint.
- El servicio de Administración de SharePoint está iniciado.
- El servicio de Temporizador de SharePoint está iniciado.
- El paquete de solución nombrado en el archivo de configuración está presente.

Los servicios de Administración y Temporizador son necesarios porque algunas acciones de instalación se ejecutan como trabajos de temporizador que propagan la solución a todos los servidores de la granja.

### **Ejecutando la instalación**

Para instalar Aspose.Slides for SharePoint:

1. Descomprima el archivo ZIP en una unidad local de un servidor de la granja de SharePoint.
2. Ejecute el programa de instalación que coincida con su versión de SharePoint (consulte la tabla anterior) y siga las instrucciones en pantalla. El programa de instalación:
   1. Ejecuta la verificación del sistema. La instalación no continúa si alguna comprobación falla.

      **Ejecutando una verificación del sistema**

      ![Pantalla de verificación del sistema del programa de instalación](installing-aspose-slides-for-sharepoint_1.png)

   2. Muestra el acuerdo de licencia de usuario final. Debe aceptarlo para continuar.

      **El acuerdo de licencia**

      ![Pantalla del acuerdo de licencia del programa de instalación](installing-aspose-slides-for-sharepoint_2.png)

   3. Muestra los destinos de despliegue. Seleccione las aplicaciones web y colecciones de sitios en las que activar la característica.

      **Seleccionando destinos de despliegue**

      ![Pantalla de destinos de despliegue de la colección de sitios del programa de instalación](installing-aspose-slides-for-sharepoint_3.png)

   4. Despliega la solución en la granja.

      **Progreso de la instalación**

      ![Pantalla de progreso de la instalación del programa de instalación](installing-aspose-slides-for-sharepoint_4.png)

   5. Activa Aspose.Slides for SharePoint en las colecciones de sitios seleccionadas.
   6. Enumera las aplicaciones web y colecciones de sitios donde la solución ha sido desplegada y activada.

      **Instalación exitosa**

      ![Pantalla de instalación completada del programa de instalación](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Las capturas de pantalla se tomaron en SharePoint 2007. Los programas de instalación para versiones posteriores pasan por las mismas pantallas.
{{% /alert %}}

Si la misma versión de Aspose.Slides for SharePoint ya está instalada, el programa de instalación ofrece reparar o eliminarla. Si otra versión está instalada, ofrece actualizarla o eliminarla.

Tras la instalación, aparece un elemento **Convertir mediante Aspose.Slides** en el menú de archivos de las bibliotecas de documentos de las colecciones de sitios seleccionadas (en SharePoint 2007, **Convertir con Aspose.Slides**). Para convertir una primera presentación, consulte [Conversión de documentos Microsoft PowerPoint a otros formatos](/slides/es/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Lo que la solución añade a la granja se describe en [Despliegue y activación](/slides/es/sharepoint/deployment-and-activation/).

## **Preguntas frecuentes**

**¿Qué programa de instalación debo ejecutar?**

El que cuyo nombre coincida con su versión de SharePoint. Por ejemplo, ejecute *Setup2016.exe* en una granja de SharePoint Server 2016. Cada programa de instalación instala solo su propio paquete de solución.

**¿Necesito una descarga separada para la versión con licencia?**

No. El mismo paquete funciona en modo de evaluación hasta que instale la solución de licencia; vea [Instalación de la licencia de Aspose.Slides para SharePoint](/slides/es/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**¿Cómo elimino el producto?**

Ejecute nuevamente el mismo programa de instalación y seleccione **Remove**; vea [Desinstalación de Aspose.Slides para SharePoint](/slides/es/sharepoint/uninstalling-aspose-slides-for-sharepoint/).