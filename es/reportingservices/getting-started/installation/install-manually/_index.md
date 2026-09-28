---
title: Instalación manual
type: docs
weight: 30
url: /es/reportingservices/install-manually/
keywords:
- instalación manual
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instale Aspose.Slides for Reporting Services manualmente a partir del paquete ZIP solo con DLLs: qué ensamblado copiar y qué añadir a rsreportserver.config y rssrvpolicy.config."
---
## **Visión general**

Siga estos pasos para instalar Aspose.Slides for Reporting Services sin el instalador MSI, a partir del paquete ZIP *Aspose.Slides for Reporting Services XX.XX (Solo DLLs)* en la [página de descarga](https://releases.aspose.com/slides/es/reportingservices/). Registran las mismas extensiones que el [instalador MSI](/slides/es/reportingservices/install-with-msi-installer/). Repítalos para cada instancia del servidor de informes.

Antes de comenzar, revise los [requisitos del sistema](/slides/es/reportingservices/system-requirements/). Necesita derechos de administrador local en el servidor de informes.

## **Seleccione el ensamblado**

El paquete ZIP contiene varias compilaciones. Copie exactamente un *Aspose.Slides.ReportingServices.dll* al servidor de informes:

| Archivo en el paquete ZIP | Usos |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 y versiones posteriores de Reporting Services, y Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | No para un servidor de informes: aplicaciones que exportan desde el control ReportViewer 2010 o 2012, vea [Usando Aspose.Slides con ReportViewer 2010 y 2012](/slides/es/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Opcional: guarda informes en formato RPL para informes de problemas, vea [Exportando informes a formato RPL](/slides/es/reportingservices/exporting-reports-to-rpl-format/) |

## **Ubique la carpeta del servidor de informes**

Los pasos a continuación hacen referencia a la carpeta *ReportServer* del servidor de informes, que contiene *rsreportserver.config* y *rssrvpolicy.config*. En una instalación predeterminada, es:

| Servidor de informes | Carpeta *ReportServer* predeterminada |
| :- | :- |
| SQL Server 2017 y versiones posteriores de Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 y versiones anteriores de Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, donde la carpeta de instancia es, por ejemplo, `MSRS13.MSSQLSERVER` para SQL Server 2016 o `MSSQL.x` para SQL Server 2005 |

Para más ubicaciones, consulte el artículo de Microsoft sobre el [archivo de configuración RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Instale la extensión**

1. Copie el ensamblado que eligió en la subcarpeta *bin* de la carpeta *ReportServer*.

   El archivo copiado no debe tener permisos NTFS asignados explícitamente, o el servidor de informes se negará el acceso cuando cargue el ensamblado y los nuevos formatos de exportación no aparecerán. Haga clic con el botón derecho en el archivo, seleccione **Propiedades**, y en la pestaña **Seguridad** elimine cualquier permiso asignado explícitamente, dejando solo los heredados. Si la pestaña **General** muestra una opción **Desbloquear**, selecciónela.

2. Guarde una copia de *rsreportserver.config* y luego abra el archivo en un editor de texto. Añada estas entradas dentro del elemento `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Cada entrada registra un formato de exportación; `Name` debe ser único entre las extensiones de renderizado. El instalador MSI registra los mismos seis nombres y tipos. Omitir una entrada si no desea su formato en la lista de exportación.

3. Guarde una copia de *rssrvpolicy.config* y luego abra el archivo en un editor de texto. Encuentre el grupo de código cuya `Description` es "This code group grants MyComputer code Execution permission." y añada este grupo de código como su último hijo:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` es la clave pública del ensamblado Aspose.Slides.ReportingServices. Manténgala en una sola línea.

4. Guarde ambos archivos. El servidor de informes vuelve a leer sus archivos de configuración cada vez que se guardan. Si un archivo contiene XML mal formado, el servidor de informes lo ignora o no se inicia, por lo que debe restaurar su copia si algo sale mal.

## **Compruebe la instalación**

Abra un informe paginado en el portal web (Report Manager en SQL Server 2014 y versiones anteriores) y abra la lista **Exportar**. Ahora incluye estos formatos:

- PPT - Presentación de PowerPoint mediante Aspose.Slides
- PPS - Presentación de diapositivas de PowerPoint mediante Aspose.Slides
- PPTX - Presentación de PowerPoint 2007 mediante Aspose.Slides
- PPSX - Presentación de diapositivas de PowerPoint 2007 mediante Aspose.Slides
- ODP - Presentación OpenDocument mediante Aspose.Slides
- XPS - mediante Aspose.Slides

Seleccione uno de ellos para exportar el informe. El archivo se abre en la aplicación asociada a su formato.

![Un informe exportado a PowerPoint por Aspose.Slides for Reporting Services](install-manually_2.png)

Si los formatos no aparecen, compruebe los permisos NTFS del ensamblado copiado. Sin una licencia, los archivos exportados llevan una marca de agua de evaluación; vea [Licencias](/slides/es/reportingservices/license-aspose-slides-for-reporting-services/).