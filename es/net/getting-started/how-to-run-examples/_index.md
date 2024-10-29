---
title: Cómo Ejecutar Ejemplos
type: docs
weight: 130
url: /es/net/how-to-run-examples/
---

## **Requisitos de Software**
Antes de descargar y ejecutar los ejemplos, verifica y confirma que tu configuración cumpla con estos requisitos:

- Visual Studio 2010 o superior.
- Administrador de Paquetes NuGet instalado en Visual Studio. Verifica que la versión más reciente de la API NuGet esté instalada en Visual Studio.

Para instrucciones sobre cómo instalar el administrador de paquetes NuGet, visita esta página: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Ve a **Herramientas** > **Opciones** > **Administrador de Paquetes NuGet**.

1. Expande **Administrador de Paquetes NuGet** (haciendo doble clic en él) y luego selecciona **Origen de Paquetes**.

1. Verifica y confirma que el parámetro nuget.org esté seleccionado.

   El proyecto de ejemplo utiliza la función de Restauración Automática de Paquetes de NuGet, por lo que necesitas tener una conexión a Internet activa.

   Si no tienes una conexión a Internet activa en la máquina donde pretendes ejecutar los ejemplos, consulta [Instalación](https://docs.aspose.com/slides/net/installation/) y agrega (manualmente) una referencia a Aspose.Slides.dll en el proyecto de ejemplo.
## **Descargar desde GitHub**
Todos los ejemplos de Aspose.Slides para .NET están alojados en [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Puedes clonar el repositorio usando tu cliente de GitHub favorito o descargar el archivo ZIP [aquí](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Si descargas el archivo ZIP, debes extraer su contenido a una carpeta en tu computadora.

Todos los ejemplos se almacenan en la carpeta **Ejemplos**.

Hay un archivo de solución de Visual Studio en C#. Los proyectos están creados en Visual Studio 2013, pero los archivos de solución son compatibles con Visual Studio 2010 SP1 y superior.

2. Abre el archivo de solución en Visual Studio y compila el proyecto.

   En la primera ejecución, las dependencias se descargan automáticamente a través de NuGet.

La carpeta **Datos** en la carpeta raíz de **Ejemplos** contiene archivos de entrada utilizados en los ejemplos de C#. Debes descargar la carpeta **Datos** junto con el proyecto de ejemplos.

3. Abre el archivo RunExamples.cs. Todos los ejemplos se llaman desde aquí.

4. Descomenta los ejemplos que deseas ejecutar dentro del proyecto.

No dudes en ponerte en contacto a través de nuestros foros si tienes problemas para configurar o ejecutar los ejemplos.
## **Contribuir**
Puedes contribuir al proyecto añadiendo o mejorando un ejemplo. Todos los ejemplos y proyectos de demostración en el repositorio son de código abierto, por lo que tú (y otras personas) pueden usarlos libremente en aplicaciones.

Para contribuir, puedes bifurcar el repositorio, editar el código fuente y crear una solicitud de extracción. Revisaremos los cambios. Si los consideramos útiles, los añadiremos al repositorio.