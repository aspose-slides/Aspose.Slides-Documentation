---
title: Aspose.Slides para .NET 6 de Plataforma Cruzada
type: docs
weight: 237
url: /es/net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, Plataforma cruzada
description: Aspose.Slides para .NET 6 de Plataforma Cruzada
---

1. Aspose.Slides para .NET6 de plataforma cruzada se puede usar para .NET 7 y futuras versiones de .NET.

2. **Requisito previo**: Para usar la versión de plataforma cruzada Aspose.Slides para .NET 6, necesita descargar el paquete Aspose.Slides de la [Página de Lanzamientos](https://releases.aspose.com/slides/net/). El paquete NuGet de Aspose.Slides no es adecuado porque proporciona soporte de plataforma cruzada solo para .NET Standard.

3. **Requisitos**: [Requisitos del sistema](https://docs.aspose.com/slides/net/system-requirements/). Tenga en cuenta que Aspose.Slides para .NET 6 y .NET 7 requiere Linux x86_x64 con GLIBC 2.23 o superior. **CentOS** 7 (cuyo versión de GLIBC es 2.14) no es compatible. Para usar Slides en CentOS 7 u otros sistemas (como Alpine) que no cumplen con el requisito, obtenga Aspose.Slides para .NETStandard.

## **Obtener y Usar Aspose.Slides de Plataforma Cruzada**

1. Descargue el paquete ZIP de la última versión de Aspose.Slides desde la [Página de Lanzamientos](https://releases.aspose.com/slides/net/). 

2. Descomprima los archivos de *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* y colóquelos en la carpeta que se usará para las dependencias en su proyecto.

3. Agregue una referencia a Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   En nuestro ejemplo (a continuación), las bibliotecas están ubicadas en la carpeta del proyecto a lo largo de esta ruta: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Coloque los archivos restantes (de los que Aspose.Slides depende) en el directorio de salida añadiendo instrucciones al archivo de proyecto csproj de esta manera:
```
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Preste atención a TargetPath. 

   Por defecto, `<CopyToOutputDirectory>` copia archivos preservando su ruta relativa, pero necesitamos que las bibliotecas dependientes vayan a la misma carpeta donde se genera la salida (ubicación de Aspose.Slides.dll).

## Notas

### **Soporte de System.Drawing.Common Solo para Windows**

A partir de .NET 6, el soporte para System.Drawing.Common (que proporciona soporte GDI+) está disponible [solo en Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Aspose.Slides para .NET depende de GDI+. Además, la API pública de Aspose.Slides contiene tipos (Bitmap, Metafile, Graphics, etc.) del paquete System.Drawing.Common.

### **Subsistema Gráfico Propietario**

Para resolver el problema de cambio de ruptura (que cancela el soporte multiplataforma para System.Drawing.Common), Aspose.Slides—comenzando en la versión 23.6—utiliza su propia implementación de subsistema gráfico.

Estos son los sistemas compatibles: **Windows**, **Linux** y **macOS**.

Aspose.Slides de plataforma cruzada es una colección de bibliotecas:

| Aspose.Slides.dll                                          | Ensamblaje principal de .NET responsable de toda la lógica de Aspose.Slides    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dependencia: implementación del subsistema gráfico para Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dependencia: implementación del subsistema gráfico para Win x64    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dependencia: implementación del subsistema gráfico para Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | Dependencia: implementación del subsistema gráfico para macOS      |

Aspose.Slides.dll utiliza la biblioteca que requiere el sistema en el que se está ejecutando. Las bibliotecas generalmente se encuentran en la misma ubicación que Aspose.Slides.dll en cualquier sistema de archivos.

### **API Pública de Aspose.Slides y Tipos de System.Drawing.Common. Solución al Problema de Conflictos de Nombres**

La API pública de Aspose.Slides utiliza tipos de System.Drawing.Common (Bitmap, Metafile, Graphics y muchos otros). Para facilitar la transición suave al nuevo producto de Aspose.Slides de plataforma cruzada y evitar introducir muchos cambios disruptivos en la API pública de Slides, la implementación propietaria del subsistema gráfico **duplica** los tipos y espacios de nombres de System.Drawing.Common.

Por lo tanto, si desarrolla o trabaja en un entorno Linux, solo tiene que usar Aspose.Slides como dependencia, y toda la API se mantiene igual.

**Problema potencial**: La configuración descrita tiene sus desventajas. Por ejemplo, si usted desarrolla en Windows y tiene proyectos que utilizan el original System.Drawing.Common, podría encontrar conflictos con los tipos de Aspose.Slides.

**Solución**: Puede usar un alias externo para resolver el problema. Consulte [**Uso del paquete System.Drawing.Common y clases de Slides para .NET6 (CS0433: El tipo existe tanto en Slides como en System.Drawing.Common error)**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error).

El equipo de Slides está trabajando en tareas que resultarán en una API pública simplificada y unificada.

### **Paquetes NuGet y ZIP**

* NuGet Aspose.Slides para .NET actualmente carece de soporte para Aspose.Slides de plataforma cruzada para .NET 6.

* El paquete NuGet Aspose.Slides para .NET soporta plataforma cruzada para .NET Standard pero no para .NET 6.

* La versión de plataforma cruzada de Aspose.Slides está disponible como paquetes zip proporcionados en la [página de lanzamientos](https://releases.aspose.com/slides/net/).

* El paquete ZIP contiene esta estructura de carpetas:

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* Cada carpeta contiene ensamblados para su correspondiente versión de .NET. Hay dos versiones para net6.0: win y crossplatform. Esta última contiene el Aspose.Slides.dll de plataforma cruzada y todas sus dependencias. Los contenidos descomprimidos de esta carpeta pueden utilizarse como una adición de dependencias en un proyecto para desarrollo de plataforma cruzada y otros instancias de uso de Aspose.Slides.