---
title: Instalar con instalador MSI
type: docs
weight: 20
url: /es/reportingservices/install-with-msi-installer/
keywords:
- instalador MSI
- instalación
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instale Aspose.Slides for Reporting Services con su instalador MSI: lo que necesita el instalador, lo que cambia en cada instancia del servidor de informes y cómo comprobar el resultado."
---
## **Instalación**

El instalador MSI es la forma más sencilla de instalar Aspose.Slides for Reporting Services. Necesita .NET Framework 3.5 y derechos de administrador en el servidor de informes; vea los [Requisitos del sistema](/slides/es/reportingservices/system-requirements/).

1. Descargue el instalador MSI, *Aspose.Slides for Reporting Services XX.XX*, desde la [página de descarga](https://releases.aspose.com/slides/reportingservices/) y cópielo al servidor de informes.  
1. Ejécútelo como administrador. Si falta .NET Framework 3.5, el instalador se detendrá con un mensaje; instale las características de .NET Framework 3.5 y vuelva a ejecutarlo.  
1. Acepte el acuerdo de licencia.  
1. En la página de **Configuración personalizada**, el árbol de funciones muestra cada instancia de SQL Server Reporting Services y Power BI Report Server que el instalador detecta en la máquina. Para dejar una instancia sin cambios, haga clic en su icono y seleccione **Entire feature will be unavailable**. Las ediciones Express no admiten extensiones de renderizado, así que no seleccione una instancia Express. El instalador oculta las instancias Express de SQL Server 2016 y anteriores.  
1. Seleccione **Next**, y luego **Install**.

La característica opcional **Rpl Export** no está seleccionada por defecto. Añade una extensión oculta que guarda los informes en formato RPL, lo cual es útil cuando envía un informe de problemas a Aspose; vea [Exportar informes al formato RPL](/slides/es/reportingservices/exporting-reports-to-rpl-format/).

## **Qué cambios realiza el instalador**

El instalador guarda sus archivos en *Aspose\Aspose.Slides for Reporting Services* dentro de la carpeta Program Files — *Program Files (x86)* en Windows de 64 bits, porque el instalador es un paquete de 32 bits. Luego, para cada instancia seleccionada,:

- copia *Aspose.Slides.ReportingServices.dll* a la carpeta *ReportServer\bin* de la instancia — la compilación para SQL Server 2005, o la compilación para SQL Server 2008 y posteriores y Power BI Report Server;  
- añade seis extensiones de renderizado — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS y ASODP — al elemento `<Render>` de *rsreportserver.config*;  
- agrega un grupo de código que otorga plena confianza al ensamblado en *rssrvpolicy.config*;  
- guarda una copia de cada archivo de configuración que modifica, añadiendo *.bak* al nombre del archivo.

[Instalar manualmente](/slides/es/reportingservices/install-manually/) muestra estos cambios paso a paso.

Si una instancia no puede configurarse, el instalador la menciona en un mensaje y escribe los detalles en *rserrors&lt;date&gt;.log* en la carpeta de instalación. Instale la extensión en esa instancia manualmente.

## **Comprobar la instalación**

Abra un informe paginado en el portal web (Report Manager en SQL Server 2014 y versiones anteriores) y abra la lista **Exportar**. Ahora incluye estos formatos:

- PPT – Presentación de PowerPoint mediante Aspose.Slides  
- PPS – Show de diapositivas de PowerPoint mediante Aspose.Slides  
- PPTX – Presentación de PowerPoint 2007 mediante Aspose.Slides  
- PPSX – Show de diapositivas de PowerPoint 2007 mediante Aspose.Slides  
- ODP – Presentación OpenDocument mediante Aspose.Slides  
- XPS – mediante Aspose.Slides  

Sin una licencia, los archivos exportados llevan una marca de agua de evaluación; vea [Licencias](/slides/es/reportingservices/license-aspose-slides-for-reporting-services/).

## **Cuándo instalar manualmente**

Instale la extensión [manualmente](/slides/es/reportingservices/install-manually/) en su lugar cuando:

- el instalador no pueda configurar una instancia, por ejemplo, por la configuración de seguridad del servidor;  
- después de una actualización, desee reemplazar solo el ensamblado en lugar de desinstalar la versión anterior y ejecutar el nuevo instalador.

Desinstalar el producto elimina el ensamblado y las entradas de configuración de cada instancia.