---
title: Instalación de Aspose.Slides para SharePoint
type: docs
weight: 10
url: /es/sharepoint/installing-aspose-slides-for-sharepoint/
---

{{% alert color="primary" %}}

Aspose.Slides para SharePoint se descarga como el archivo comprimido Aspose.Slides.SharePoint.zip. El archivo contiene:

- **Aspose.Slides.SharePoint.wsp**: Archivo de solución de SharePoint. Aspose.Slides para SharePoint está empaquetado como una solución de SharePoint para facilitar la activación y desactivación en toda la granja de servidores.
- **Aspose_LicenseAgreement.rtf**: El acuerdo de licencia de usuario final.
- **Setup.exe**: El programa de instalación.
- **Setup.exe.config**: El archivo de configuración de la instalación.

{{% /alert %}}
## **Proceso de Instalación**
Antes de ejecutar la instalación, el programa de instalación verifica que:

- WSS 3.0 o MOSS 2007 esté instalado.
- El usuario tenga permiso para instalar soluciones de SharePoint.
- La base de datos de SharePoint esté en línea.
- El servicio de administración de WSS esté iniciado.
- El servicio de temporizador de WSS esté iniciado.

Los servicios de administración y temporizador de WSS son necesarios porque algunas acciones de instalación dependen de un trabajo de temporizador para propagarse a todos los servidores en la granja de servidores.
### **Ejecutando la Instalación**
Para instalar Aspose.Slides para SharePoint:

1. Descomprima el zip de Aspose.Slides.SharePoint en la unidad local en el servidor MOSS 7.0 o WSS 3.0.
2. Ejecute setup.exe y siga las instrucciones en la pantalla.
   El programa de instalación realiza las siguientes acciones:
   1. Verifica los requisitos previos de instalación. La instalación no continuará si alguna verificación falla.

      **Ejecutando una verificación de sistemas**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)

3. Muestra el Acuerdo de Licencia de Usuario Final. Debe aceptar el acuerdo para continuar.

   **El EULA**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)

4. Muestra la selección del destino de implementación. Selecciona las aplicaciones web y colecciones de sitios para las que se debe activar la función.

   **Seleccionando destinos de implementación**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)

5. Despliega la función en la granja de servidores.

   **La barra de progreso de instalación**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)

6. Activa Aspose.Slides para las colecciones de sitios seleccionadas y configura sus aplicaciones web principales.
7. Muestra una lista de aplicaciones web y colecciones de sitios para las que la función se ha desplegado y activado.

   **Instalación exitosa**

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)