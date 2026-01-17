---
title: Aspose.Slides para .NET 6 multiplataforma (paquete ZIP)
type: docs
weight: 237
url: /es/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- multiplataforma
- .NET 6
- GLIBC
- csproj
- ruta de destino
- biblioteca dependiente
- Aspose.Slides.dll
- System.Drawing.Common
- conflicto de nombres
- alias externo
- CS0433
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Utilice Aspose.Slides para .NET 6 para crear aplicaciones C# multiplataforma en Windows, Linux y macOS que generen, editen y conviertan archivos PowerPoint PPT, PPTX y ODP."
---

{{% alert title="Nota" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform también está disponible en [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Uso de Aspose.Slides multiplataforma desde un paquete ZIP**

1. Descargue el paquete ZIP de la última versión de Aspose.Slides desde la [Página de lanzamientos](https://releases.aspose.com/slides/net/). 

2. Descomprima los archivos de *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* y colóquelos en la carpeta que se utilizará para las dependencias en su proyecto.

3. Añada una referencia a Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   En nuestro ejemplo (abajo), las bibliotecas se encuentran en la carpeta del proyecto en la siguiente ruta: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Coloque los archivos restantes (de los que depende Aspose.Slides) en el directorio de salida añadiendo instrucciones al archivo de proyecto csproj de esta manera:
```xml
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```


5. Preste atención a `TargetPath`. 

   Por defecto, `<CopyToOutputDirectory>` copia los archivos conservando su ruta relativa, pero necesitamos que las bibliotecas dependientes se coloquen en la misma carpeta donde se genera la salida (ubicación de Aspose.Slides.dll).

## **Notas**

### **Subsistema gráfico propietario**

Aspose.Slides multiplataforma es una colección de bibliotecas:

| Aspose.Slides.dll                                          | Ensamblado .NET principal responsable de toda la lógica de Aspose.Slides                 |
| ---------------------------------------------------------- | ------------------------------------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dependencia: implementación del subsistema gráfico para Windows x64                     |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dependencia: implementación del subsistema gráfico para Windows x64                     |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dependencia: implementación del subsistema gráfico para Linux (x86/x64)                 |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dependencia: implementación del subsistema gráfico para macOS AMD64 (x86-64/x64)        |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dependencia: implementación del subsistema gráfico para macOS ARM64 (AArch64)           |

Aspose.Slides.dll utiliza la biblioteca que requiere el sistema en el que se ejecuta. Normalmente, las bibliotecas se encuentran en la misma ubicación que Aspose.Slides.dll en cualquier sistema de archivos.

### **Estructura del paquete ZIP**

El paquete ZIP contiene la siguiente estructura de carpetas:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Cada carpeta contiene ensamblados para su versión correspondiente de .NET. Hay dos versiones para net6.0: default y crossplatform. Esta última contiene el Aspose.Slides.dll multiplataforma y todas sus dependencias. El contenido desempaquetado de esta carpeta puede usarse como una adición de dependencia en un proyecto para desarrollo multiplataforma y otros casos de uso de Aspose.Slides.

## **Ver también**

- [Requisitos del sistema](/slides/es/net/system-requirements/)