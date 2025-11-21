---
title: Cómo ejecutar ejemplos
type: docs
weight: 130
url: /es/net/how-to-run-examples/
keywords:
- ejemplos
- requisitos de software
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Ejecute ejemplos de Aspose.Slides para .NET rápidamente: clone el repositorio, restaure los paquetes y luego compile y pruebe las funciones para PPT, PPTX y ODP."
---

## **Requisitos de software**
Antes de descargar y ejecutar los ejemplos, por favor verifique y confirme que su configuración cumple con estos requisitos: 

- Visual Studio 2010 o superior.
- NuGet Package Manager instalado en Visual Studio. Verifique que la versión más reciente de la API de NuGet esté instalada en Visual Studio. 

Para instrucciones sobre cómo instalar el NuGet Package Manager, visite esta página: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Vaya a **Tools** > **Options** > **NuGet Package Manager**.

1. Expanda **NuGet Package Manager** (haciendo doble clic en él) y luego seleccione **Package Sources**. 

1. Verifique y confirme que el parámetro nuget.org esté seleccionado. 

   El proyecto de ejemplo utiliza la función de restauración automática de paquetes de NuGet, por lo que necesita una conexión a Internet activa. 

   Si no tiene una conexión a Internet activa en la máquina donde pretende ejecutar los ejemplos, por favor revise [Instalación](https://docs.aspose.com/slides/net/installation/) y agregue (manualmente) una referencia a Aspose.Slides.dll en el proyecto de ejemplo.
## **Descargar desde GitHub**
Todos los ejemplos de Aspose.Slides para .NET están alojados en [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Puede clonar el repositorio usando su cliente de GitHub favorito o descargar el archivo ZIP [aquí](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Si descarga el archivo ZIP, debe extraer su contenido a una carpeta en su computadora. 

Todos los ejemplos se almacenan en la carpeta **Examples**.

Hay un archivo de solución de Visual Studio en C#. Los proyectos fueron creados en Visual Studio 2013, pero los archivos de solución son compatibles con Visual Studio 2010 SP1 y versiones posteriores.

2. Abra el archivo de solución en Visual Studio y compile el proyecto.

   En la primera ejecución, las dependencias se descargan automáticamente mediante NuGet.

La carpeta **Data** en la raíz de **Examples** contiene los archivos de entrada utilizados en los ejemplos de C#. Debe descargar la carpeta **Data** junto con el proyecto de ejemplos.

3. Abra el archivo RunExamples.cs. Todos los ejemplos se invocan desde aquí.

4. Descomente los ejemplos que desea ejecutar dentro del proyecto.

No dude en ponerse en contacto a través de nuestros foros si tiene problemas al configurar o ejecutar los ejemplos.
## **Contribuir**
Puede contribuir al proyecto añadiendo o mejorando un ejemplo. Todos los ejemplos y proyectos de muestra en el repositorio son de código abierto, por lo que usted (y otras personas) pueden utilizarlos libremente en sus aplicaciones.

Para contribuir, puede bifurcar el repositorio, editar el código fuente y crear una solicitud de extracción. Revisaremos los cambios. Si los consideramos útiles, los añadiremos al repositorio.