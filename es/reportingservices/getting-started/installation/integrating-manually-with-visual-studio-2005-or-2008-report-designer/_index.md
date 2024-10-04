---
title: Integración Manual con el Diseñador de Informes de Visual Studio 2005 o 2008
type: docs
weight: 50
url: /es/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

Este artículo te enseña cómo integrar Aspose.Slides para Reporting Services manualmente con Visual Studio. 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

**Aspose.Slides para Reporting Services** requiere la instalación de **.NET Framework 3.5** en la máquina host. 

{{% /alert %}}

## **Integrando Aspose.Slides para Reporting Services con Visual Studio**
Recomendamos que utilices el instalador MSI para instalar Aspose.Slides para Reporting Services porque realiza automáticamente todas las tareas de instalación necesarias y los procesos de configuración. Sin embargo, si la instalación con el instalador MSI falla, utiliza la guía aquí. 

Este artículo también te muestra cómo instalar Aspose.Slides para Reporting Services en una computadora con Business Intelligence Development Studio. Esto te permitirá exportar informes a formatos de Microsoft PowerPoint en tiempo de diseño desde el Diseñador de Informes de Microsoft Visual Studio 2005 o 2008. 

1. Copia Aspose.Slides.ReportingServices.dll en el directorio de Visual Studio.

   - Para integrar con el Diseñador de Informes de Visual Studio 2005, copia **Aspose.Slides.ReportingServices.dll** en el directorio **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Para integrar con el Diseñador de Informes de Visual Studio 2008, copia **Aspose.Slides.ReportingServices.dll** en el directorio **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Registra Aspose.Slides para Reporting Services como una extensión de renderizado. 

3. Abre **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (donde <Version> es “8” para Visual Studio 2005 o “9.0” para Visual Studio 2008) y añade estas líneas en el elemento <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

 

```

4. Da a Aspose.Slides para Reporting Services permisos para ejecutarse. 
   1. Abre **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (donde <Version> es “8” para Visual Studio 2005 o “9.0” para Visual Studio 2008).
   1. Añade esta línea como el último elemento en el segundo elemento <CodeGroup> exterior (que debería ser <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Este grupo de código otorga permiso de Ejecución de código a MyComputer.">) 

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

        Description="Este grupo de código otorga plena confianza al ensamblaje AS4SSRS.">

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

5. Verifica que Aspose.Slides para Reporting Services se haya instalado correctamente. 
6. Ejecuta o reinicia Microsoft Visual Studio 2005 o 2008 Diseñador de Informes. Deberías notar nuevos formatos en la lista de formatos de exportación.

**Nuevos formatos de exportación aparecen en el Diseñador de Informes.** 

![todo:texto_alt_imagen](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)