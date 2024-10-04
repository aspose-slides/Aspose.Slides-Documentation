---
title: Instalación Manual
type: docs
weight: 30
url: /es/reportingservices/install-manually/
---

{{% alert color="primary" %}} 

Siga estos pasos solo si planea instalar Aspose.Slides para Reporting Services manualmente. En este caso, ha descargado el paquete ZIP que contiene los archivos de ensamblado.

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

**Aspose.Slides para Reporting Services** requiere la instalación de **.NET Framework 3.5** en la máquina anfitriona.

{{% /alert %}}

### **Instalación Manual**
Estas instrucciones le muestran cómo copiar y modificar archivos en el directorio donde está instalado Microsoft SQL Server Reporting Services:

1. Ubique el directorio de instalación del Report Server.
   El directorio raíz para Microsoft SQL Server suele estar aquí: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 y 2008**: Puede haber varias instancias de Microsoft SQL Server configuradas en la máquina y pueden ocupar diferentes subdirectorios MSSQL.x, como MSSQL.1, MSSQL.2, etc. Debe encontrar el directorio correcto ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** antes de continuar con el siguiente paso.
   
   {{% /alert %}} Todos los caminos utilizados a continuación se referirán a este directorio como <Instance>. 

2. Copie Aspose.Slides.ReportingServices.dll en la carpeta **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.
   La descarga de **Aspose.Slides.ReportingServices.zip** contiene el **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

En algunos casos, al copiar el DLL en el directorio **ReportServer\bin**, puede que se copie junto con los permisos explícitos de archivo NTFS que se le asignan. Los permisos NTFS causan que Microsoft SQL Server Reporting Services deniegue el acceso al cargar **Aspose.Slides.ReportingServices.dll**. Si esto sucede, los nuevos formatos de exportación no estarán disponibles. Verifique y confirme que los permisos NTFS correctos están en su lugar:

   1. Haga clic derecho en **Aspose.Slides.ReportingServices.dll**.
   1. Haga clic en **Propiedades** y seleccione la pestaña **Seguridad**.
   1. Elimine cualquier permiso NTFS asignado explícitamente y deje solo permisos heredados.

{{% /alert %}}

3. Registre Aspose.Slides para Reporting Services como una extensión de representación: 
   1. Abra *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. Agregue estas líneas al elemento <Render>: 

**<Render>**

``` xml

   ...

  <!--Comience aquí.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Termine aquí.-->

</Render>

```

4. Dé permisos a Aspose.Slides para Reporting Services para ejecutar: 
   1. Abra **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. Agregue lo siguiente como el último elemento en el segundo elemento <CodeGroup> exterior (que debería ser <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Este grupo de código otorga permiso de Ejecución de código MyComputer. ">). 

**<CodeGroup>**

``` xml

...

  <CodeGroup>

    ...

    <!--Comience aquí.-->

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

    <!--Termine aquí.-->

  </CodeGroup>

</CodeGroup>

```

5. Verifique que Aspose.Slides para Reporting Services se instaló correctamente: 
   1. Abra el Administrador de Informes y verifique la lista de tipos de exportación disponibles para un informe. 
   
      {{% alert color="primary" %}} Puede lanzar el Administrador de Informes abriendo un navegador (Microsoft Internet Explorer 6.0 o superior) y escribiendo la URL del Administrador de Informes en la barra de direcciones (por defecto es http://< ComputerName >/Reports ). 
   
      {{% /alert %}}

1. Seleccione un informe en el servidor.
1. Abra la lista **Seleccionar Formato**.
   Debería ver una lista de formatos de exportación proporcionados por Aspose.Slides para Reporting Services. 
1. Seleccione **PPT – Presentación de PowerPoint a través de Aspose.Slides**. 

   **Aspose.Slides para Reporting Services instalado correctamente y nuevos formatos de exportación están disponibles.** 

![todo:image_alt_text](install-manually_1.png)

6. Haga clic en el enlace **Exportar**.
   El informe se genera en el formato elegido, se envía al cliente y luego se abre en una aplicación adecuada. En nuestro caso, el informe se abrió en Microsoft PowerPoint. 

   **Un informe PPT generado por Aspose.Slides para Reporting Services.** 

![todo:image_alt_text](install-manually_2.png)

¡Ha instalado correctamente Aspose.Slides para Reporting Services y generado un informe como una presentación de Microsoft PowerPoint!