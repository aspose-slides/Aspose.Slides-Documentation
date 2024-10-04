---
title: Protección con Contraseña de la Presentación Exportada
type: docs
weight: 90
url: /es/reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

Proteger con contraseña una presentación evita el uso y acceso no autorizado. La protección con contraseña es útil si está creando informes que contienen datos sensibles o detalles que solo algunas personas en su organización deberían ver.

Este artículo le muestra cómo actualizar su entorno de Reporting Services o Visual Studio para permitirle guardar presentaciones con protección por contraseña.

{{% /alert %}} 
## **Agregar Protección con Contraseña en Presentaciones Exportadas en un Entorno de Reporting Services**
Para aplicar los cambios aquí, necesita modificar archivos en el directorio donde está instalado Microsoft SQL Server Reporting Services.
### **Paso 1. Localice el directorio de instalación del Servidor de Informes.**
El directorio raíz para Microsoft SQL Server suele ser C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Para sistemas de 64 bits, la instancia x86 de SQL Server está instalada en C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 y 2008: Podría haber varias instancias de Microsoft SQL Server configuradas en la máquina. Cada una ocupa un subdirectorio diferente MSSQL.x, por ejemplo MSSQL.1, MSSQL.2 y así sucesivamente. Encuentre el directorio correcto C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer antes de proceder con los siguientes pasos.

Todas las rutas utilizadas a continuación se refieren al directorio de instalación de Microsoft SQL Server Reporting Services como <Instance>.
### **Paso 2. Agregue el código para agregar contraseñas a presentaciones exportadas**
Reemplace las extensiones de renderizado existentes de Aspose.Slides para Reporting Services en el archivo **rsreportserver.config**. Para hacer esto, abra el archivo C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Encuentre las opciones de renderizado listadas inmediatamente debajo y reemplácelas con el código en el segmento que sigue después de eso.
#### **Encontrar Opciones de Renderizado de Aspose.Slides para Reporting Service**
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
#### **Código de Reemplazo**
**<Render>**

``` xml

   ...

  <!--Comience aquí.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Termine aquí.-->

</Render>

```
### **Agregar Protección con Contraseña para Presentaciones Exportadas en Visual Studio**
Para aplicar los cambios aquí, necesita modificar el archivo donde está instalado el Diseñador de Informes de Microsoft Visual Studio.
### **Paso 1. Abra el directorio de Visual Studio.**
- Para integrarse con el Diseñador de Informes de Visual Studio 2005, abra el directorio C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Para integrarse con el Diseñador de Informes de Visual Studio 2008, abra el directorio C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Paso 2. Agregue el código para agregar contraseña a las presentaciones exportadas.**
Reemplace las extensiones de renderizado existentes de Aspose.Slides para Reporting Services en el archivo **rsreportserver.config**. Para hacer esto, abra el archivo C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (donde **<Version>** es “8” para Visual Studio 2005 o “9.0” para Visual Studio 2008) y agregue estas líneas en el elemento **<Render>**. Luego reem place las con el código en el siguiente segmento de código.
#### **Encontrar Opciones de Renderizado de Aspose.Slides para Reporting Service**
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
#### **Código de Reemplazo**
**<Render>**

``` xml

   ...

  <!--Comience aquí.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Termine aquí.-->

</Render>

```