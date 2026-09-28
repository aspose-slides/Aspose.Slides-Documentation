---
title: Requisitos del sistema
type: docs
weight: 15
url: /es/reportingservices/system-requirements/
keywords:
- requisitos del sistema
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Compruebe qué servidores de informes, ediciones y versión de .NET Framework necesita Aspose.Slides for Reporting Services antes de instalarlo."
---
## **Visión general**

Aspose.Slides for Reporting Services se ejecuta dentro del servidor de informes como una extensión de renderizado. Esta página enumera lo que necesita la máquina del servidor de informes antes de que la [instalar](/slides/es/reportingservices/installing-aspose-slides-for-reporting-services/) . Microsoft PowerPoint y Microsoft Office no son necesarios.

## **Servidores de informes compatibles**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, para informes paginados (RDL) reports

Se admiten servidores de informes de 32‑bit y 64‑bit. SQL Server 2005 utiliza su propia compilación de la extensión; todas las versiones posteriores y Power BI Report Server utilizan la misma compilación. [Instalar manualmente](/slides/es/reportingservices/install-manually/) muestra qué archivo copiar.

Si la versión de su servidor de informes no está en esta lista, pregunte en el [foro de soporte gratuito](https://forum.aspose.com/c/slides/11) antes de desplegar.

## **Ediciones del servidor de informes**

Para SQL Server 2016 Reporting Services y versiones posteriores, y para Power BI Report Server, Microsoft admite extensiones de renderizado en las ediciones Enterprise, Standard, Developer y Evaluation; las ediciones Web y Express no las admiten. Consulte [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). El instalador MSI omite las instancias de la edición Express de SQL Server 2016 y anteriores.

## **.NET Framework**

.NET Framework 3.5 debe estar instalado en la máquina del servidor de informes. Los ensamblados de la extensión se compilan para el runtime de .NET Framework 2.0, y el instalador MSI se detiene con un mensaje si falta .NET Framework 3.5. En Windows Server, añada **.NET Framework 3.5 Features** en el asistente Agregar roles y características; consulte [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Permisos**

Instalar la extensión modifica archivos en la carpeta del servidor de informes, por lo que ambas rutas de instalación requieren derechos de administrador local. Si inicia el instalador MSI sin ellos, ofrecerá reiniciarse con privilegios de administrador.

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint en el servidor de informes?**

No. La extensión crea las presentaciones por sí misma; ni PowerPoint ni Microsoft Office deben estar instalados.

**¿Puedo instalar la extensión en una edición Express?**

No. Las ediciones Express no admiten extensiones de renderizado. El instalador MSI oculta las instancias Express de SQL Server 2016 y anteriores; en versiones posteriores, no seleccione una instancia Express.

**¿Qué formatos añade la extensión a la lista de exportación?**

PPT, PPS, PPTX, PPSX, ODP y XPS. Consulte [Supported File Formats](/slides/es/reportingservices/supported-file-formats/).