---
title: Instalación
type: docs
weight: 70
url: /es/nodejs-net/installation/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Instale Aspose.Slides para Node.js vía .NET desde npm en Windows o Linux: requisitos previos, la anulación de edge-js, una restauración única de NuGet y un primer programa que crea una presentación."
---
## **Descripción general**

Aspose.Slides for Node.js via .NET es el paquete npm `aspose.slides.via.net`. Ejecuta la biblioteca .NET de Aspose.Slides dentro de Node.js a través del puente [edge-js](https://github.com/agracio/edge-js), por lo que una instalación funcional necesita tanto Node.js como .NET.

Este artículo le guía desde una máquina limpia hasta un primer programa que crea una presentación. Hay cuatro pasos: crear un proyecto con una anulación de edge-js, instalar el paquete desde npm, restaurar una vez las dependencias .NET del paquete y ejecutar su script desde la carpeta del proyecto.

## **Requisitos previos**

- **Node.js 22 o 24 LTS**, versión x64, de [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 o posterior**, de [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Sólo el runtime de .NET no es suficiente: el paso de restauración a continuación necesita el SDK, al igual que el puente cuando se ejecuta su script. Ejecute `dotnet --list-sdks` para comprobar qué SDK están instalados.
- **Solo en Linux**:
  - las herramientas de compilación `python3`, `make` y `g++`, porque npm compila edge-js durante la instalación en Linux;
  - la biblioteca fontconfig, que la biblioteca nativa de dibujo de Aspose.Slides carga.

  En Debian, estos son los paquetes `python3`, `make`, `g++` y `libfontconfig1`.

Los pasos de este artículo se probaron en estas plataformas:

| Plataforma | Resultado |
|---|---|
| Windows x64 con Node.js 22 o 24 | Funciona. Probado con el Microsoft Visual C++ Redistributable instalado. |
| Linux x64 con Node.js 22 o 24, donde el OpenSSL del sistema proviene de la misma línea de versiones que el OpenSSL integrado en Node.js, como Debian 13 | Funciona. |
| Linux donde las dos versiones de OpenSSL difieren, como Debian 12 | Node.js se bloquea con una falla de segmentación cuando se crea una presentación. |
| macOS | No verificado. |

En Linux, compare las dos versiones antes de comenzar. El primer comando muestra la versión de OpenSSL integrada en Node.js; el segundo muestra la versión del sistema. Use un sistema donde ambas empiecen con los mismos números mayor y menor, por ejemplo `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Si no se encuentra el comando `openssl`, instale primero el paquete `openssl`.

## **Crear un proyecto**

Cree una carpeta para su proyecto, inicialícela y añada una anulación que indique a npm qué versión de edge-js instalar:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

El paquete solicita una versión anterior de edge-js cuyas binarias precompiladas para Windows terminan en Node.js 20, por lo que sin la anulación el primer script en Windows se detiene con "The edge module has not been pre-compiled for node.js version". El comando escribe la anulación en la sección `overrides` de `package.json`; añádala antes de instalar el paquete.

## **Instalar el paquete**

Instale Aspose.Slides for Node.js via .NET desde npm:

```sh
npm install aspose.slides.via.net
```

Durante la instalación, el paquete copia sus bibliotecas nativas de dibujo (los archivos cuyos nombres contienen `aspose.slides.drawing.capi`) en la carpeta del proyecto, junto a `package.json`.

El paquete también se publica como un archivo ZIP en [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). Este artículo cubre únicamente la instalación desde npm.

## **Restaurar las dependencias .NET**

El paquete contiene los ensamblados .NET de Aspose.Slides, pero no los 20 paquetes NuGet de los que dependen esos ensamblados. En tiempo de ejecución, .NET los busca en la caché de paquetes NuGet: `%USERPROFILE%\.nuget\packages` en Windows, `~/.nuget/packages` en Linux, o la carpeta establecida en la variable de entorno `NUGET_PACKAGES`. Si faltan, el primer script se detiene con "assembly specified in the dependencies manifest was not found".

Para rellenar la caché, cree una carpeta llamada `deps` en la carpeta del proyecto y guarde el siguiente archivo dentro como `deps.csproj`. Cada elemento `PackageDownload` descarga un paquete en la versión exacta entre corchetes; no se genera nada.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

A continuación, restáurelo desde la carpeta del proyecto:

```sh
dotnet restore deps/deps.csproj
```

Necesita este paso una vez por máquina, no una vez por proyecto: los paquetes permanecen en la caché de NuGet y los proyectos posteriores en la misma máquina los usan. Después de la restauración, puede eliminar la carpeta `deps`.

## **Ejecutar un primer programa**

Cree un archivo llamado `hello.js` en la carpeta del proyecto con el siguiente código. Crea una presentación, añade un rectángulo con el texto "Hello, World!" a la primera diapositiva y guarda el resultado como `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Una nueva presentación contiene una diapositiva vacía.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posición y el tamaño están en puntos (1/72 de pulgada): x, y, ancho, alto.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libere el objeto .NET que respalda la presentación.
    presentation.dispose();
}
```

Ejécútelo desde la carpeta del proyecto:

```sh
node hello.js
```

El script muestra `Saved hello.pptx`. Abra `hello.pptx` para ver una diapositiva con un rectángulo relleno que contiene el texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación; consulte [Evaluate Aspose.Slides](/slides/es/nodejs-net/evaluate-aspose-slides/) y [Licensing](/slides/es/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Ejecute sus scripts desde la carpeta del proyecto, la que contiene `package.json`. Las rutas relativas como `hello.pptx` se resuelven respecto a la carpeta actual, y en algunas máquinas un script iniciado desde otra carpeta no puede crear una presentación.
{{% /alert %}}

La API JavaScript refleja Aspose.Slides para .NET: las clases conservan sus nombres .NET, las propiedades y métodos usan camelCase (`Slides` pasa a `slides`, `AddAutoShape` pasa a `addAutoShape`), y los elementos de la colección se leen con `get(index)`. No existe una referencia de API separada para este paquete, por lo que debe usar la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) para detalles de clases y miembros, por ejemplo [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **Preguntas frecuentes**

**¿Qué significa "The edge module has not been pre-compiled for node.js version"?**

npm instaló la versión anterior de edge-js que solicita el paquete. Añada la anulación de [Create a Project](#create-a-project) y ejecute `npm install` nuevamente.

**¿Qué significa "assembly specified in the dependencies manifest was not found"?**

Las dependencias .NET no están en la caché de NuGet. La misma ejecución también informa "edge.initializeClrFunc is not a function". Siga [Restore the .NET Dependencies](#restore-the-net-dependencies) una vez, y luego ejecute su script nuevamente.

**¿Qué significa "The edge native module is not available" en Linux?**

edge-js no se compiló durante `npm install`, por ejemplo porque faltaba `python3`, `make` o `g++`. npm no lo reporta como un error. Instale las herramientas de compilación y luego ejecute `npm rebuild edge-js` en la carpeta del proyecto.

**¿Por qué falla la creación de una presentación con un "Error" vacío?**

En Linux, compruebe que la biblioteca fontconfig esté instalada (`libfontconfig1` en Debian); sin ella, la biblioteca nativa de dibujo no se puede cargar. En cualquier sistema, también verifique que ejecute el script desde la carpeta del proyecto.

**¿Por qué Node.js se bloquea con una falla de segmentación en Linux?**

El OpenSSL del sistema y el OpenSSL integrado en Node.js provienen de líneas de versiones diferentes. Compárelos como se muestra en [Prerequisites](#prerequisites) y utilice una distribución o compilación de Node.js donde coincidan.

**¿Necesito repetir la restauración de NuGet para cada proyecto?**

No. La restauración llena la caché de NuGet para su cuenta de usuario, y cada proyecto en esa máquina usa la misma caché.