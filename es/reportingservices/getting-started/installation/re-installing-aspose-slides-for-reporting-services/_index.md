---
title: Reinstalando Aspose.Slides para Reporting Services
type: docs
weight: 40
url: /es/reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

Este artículo describe la solución para una situación en la que Aspose.Slides para Reporting Services ya está instalado, pero por alguna razón, debe ser reinstalado.

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

**Aspose.Slides para Reporting Services** requiere la instalación de **.NET Framework 3.5** en la máquina host. 

{{% /alert %}}

## **Pasos para reinstalar Aspose.Slides para Reporting Services**
Lo más importante es la eliminación completa de las instalaciones anteriores de Aspose.Slides para Reporting Services. Mientras que el instalador MSI puede realizar con éxito las acciones necesarias requeridas para desinstalar y, por lo tanto, reinstalar Aspose.Slides para Reporting Services automáticamente, se deben seguir estos pasos:

1. Desinstala Aspose.Slides para Reporting Services usando el instalador MSI. 

2. Localiza el directorio de instalación de Aspose.Slides para Reporting Services que típicamente se encuentra en:

   **Unidad Raíz del SO\Archivos de Programa\Aspose\Aspose.Slides para Reporting Services** 

3. Si el instalador MSI no ha eliminado el directorio “Aspose.Slides para Reporting Services” al desinstalar Aspose.Slides para Reporting Services, elimina la carpeta. 

4. Localiza el archivo binario **Aspose.Slides.ReportingServices.dll** en el directorio “bin” de cada instancia de SQL Server Reporting Service. Por ejemplo, si hay una instancia de Microsoft SQL Server 2008 “MSSQLSERVER”, el correspondiente directorio “bin” de Reporting Service probablemente estará en: 

   **Unidad Raíz del SO\Archivos de Programa\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Si el instalador MSI no ha eliminado el archivo binario Aspose.Slides.ReportingServices.dll del directorio anterior al desinstalar Aspose.Slides para Reporting Services, elimina el archivo ahora.

6. Localiza el archivo **rsreportserver.config** para cada instancia de SSRS. Por ejemplo, si hay una instancia de Reporting Service “**MSRS10.MSSQLSERVER**”, el archivo **rsreportserver.config** estará en este directorio:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Abre el archivo **rsreportserver.config** en cualquier editor y encuentra las líneas que se crearon para agregar Extensiones de Formato de PowerPoint durante la instalación de Aspose.Slides para Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

``` 

**Paso** **8:** Si el instalador MSI no ha eliminado esas líneas cuando desinstaló Aspose.Slides para Reporting Services, elimina las líneas del archivo **rsreportserver.config** ahora.

**Paso** **9:** Localiza el archivo **rssrvpolicy.config** para cada instancia de SSRS. Por ejemplo, si hay una instancia de Reporting Service “MSRS10.MSSQLSERVER”, el archivo **rssrvpolicy.config** estará en este directorio:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Paso** **10:** Abre el archivo **rssrvpolicy.config** en cualquier editor y encuentra las líneas que se crearon para otorgar permisos de ejecución a Aspose.Slides para Reporting Services durante la instalación de Aspose.Slides para Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Empieza aquí.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Este grupo de código otorga plena confianza al ensamblado AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Termina aquí.-->

  </CodeGroup>

</CodeGroup>

``` 

**Paso** **11:** Si el instalador MSI no ha eliminado las líneas anteriores cuando desinstaló el producto, elimina esas líneas del archivo **rssrvpolicy.config** ahora. 

**Paso** **12:** Si Aspose.Slides para Reporting Services también se instaló con Microsoft Visual Studio para el desarrollo de informes RDL y la exportación a Formatos de PowerPoint dentro del entorno de Microsoft Visual Studio, el archivo binario Aspose.Slides.ReportingServices.dll y los archivos de configuración (**rsreportserver.config** y **rssrvpolicy.config**) en el caso de Microsoft Visual Studio 2008 deberían estar: 

**Unidad Raíz del SO\Archivos de Programa\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Paso** **13:** Si el instalador MSI no ha eliminado el **Aspose.Slides.ReportingServices.dll** binario, elimínalo. Además, si no ha actualizado los archivos **rsreportserver.config** y **rssrvpolicy.config** para eliminar las Extensiones de Formato de PowerPoint y permisos de ejecución de código respectivamente, debes eliminarlos manualmente de la misma manera que lo hiciste con los archivos en pasos anteriores. 

**Paso** **14:** Es hora de reinstalar Aspose.Slides para Reporting Services. Usa el instalador MSI para la instalación automática o hazlo manualmente.