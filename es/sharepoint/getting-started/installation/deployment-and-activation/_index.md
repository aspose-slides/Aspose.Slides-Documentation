---
title: Despliegue y Activación
type: docs
weight: 20
url: /es/sharepoint/deployment-and-activation/
description: "Qué instala la solución Aspose.Slides for SharePoint en la granja cuando se despliega, y qué añade su característica de colección de sitios cuando se activa."
---
## **Despliegue**

Durante el despliegue, la solución Aspose.Slides for SharePoint:

- Instala su ensamblado en la Global Assembly Cache y añade entradas SafeControl al archivo **web.config**. En SharePoint 2010 y posteriores, es *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* o *Aspose.Slides.SharePoint2016.dll* (el paquete de SharePoint 2019 también instala *Aspose.Slides.SharePoint2016.dll*). En SharePoint 2007, es *Aspose.Slides.SharePointUI.dll*, junto con *Aspose.Slides.SharePoint.Deployment.dll*.
- Copia la página de conversión y sus imágenes y demás archivos de soporte a las carpetas de instalación de SharePoint.
- Instala la característica y la pone a disposición para su activación en colecciones de sitios.

## **Activación**

Aspose.Slides for SharePoint se empaqueta como una característica de colección de sitios y puede activarse o desactivarse en colecciones de sitios. Cuando se activa en una colección de sitios, la característica añade:

- En SharePoint 2010 y posteriores:
  - el elemento **Convert via Aspose.Slides** al menú de documentos en bibliotecas de documentos;
  - la pestaña de cinta **Aspose Tools** con el botón **Convert Slides**, que convierte los documentos seleccionados;
  - el elemento **View Slides** al menú de archivos PPT, PPTX, PPS y PPSX.
- En SharePoint 2007:
  - el elemento **Convert with Aspose.Slides** al menú de documentos en bibliotecas de documentos;
  - el elemento **Convert All with Aspose.Slides** al menú **Actions** de las bibliotecas de documentos.

En SharePoint 2007, la activación también realiza cambios en el directorio virtual de la aplicación web principal de la colección de sitios. Hace lo siguiente:

- Añade la página de configuración de conversión al archivo sitemap.
- Copia los archivos de recursos necesarios a la carpeta App_GlobalResources en el directorio virtual.

El programa de instalación activa la característica en las colecciones de sitios que seleccione durante la [instalación](/slides/es/sharepoint/installing-aspose-slides-for-sharepoint/).