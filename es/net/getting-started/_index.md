---
title: Primeros pasos
type: docs
weight: 10
url: /es/net/getting-started/
keywords:
- primeros pasos
- requisitos del sistema
- instalación
- primera presentación
- NuGet
- procesamiento de PPT
- procesamiento de PPTX
- procesamiento de ODP
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "El camino desde un proyecto .NET nuevo hasta la primera presentación guardada con Aspose.Slides: verifica los requisitos, instala el paquete, ejecuta un primer programa y continúa con tareas comunes."
---
## **Resumen**

Siga los cuatro pasos a continuación en orden. Cada paso indica qué hacer y enlaza al artículo con los detalles. La evaluación, la licencia y el soporte se tratan después de los pasos.

## **Paso 1: Verificar los requisitos del sistema**

Aspose.Slides for .NET funciona en Windows, Linux y macOS. [Requisitos del sistema](/slides/es/net/system-requirements/) enumera los sistemas operativos y versiones de .NET que admite cada paquete, y las bibliotecas que Linux necesita adicionalmente.

## **Paso 2: Instalar el paquete**

Aspose.Slides for .NET se distribuye a través de NuGet como dos paquetes que proporcionan las mismas clases. Añada uno de ellos a su proyecto:

- En Windows: `dotnet add package Aspose.Slides.NET`
- En Linux y macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. En Linux, instale primero la biblioteca `fontconfig`.
- En Alpine Linux, y en sistemas Linux cuya glibc sea anterior a 2.23 (x64) o 2.39 (ARM64): Aspose.Slides.NET, con la biblioteca `libgdiplus` instalada.

[Instalación](/slides/es/net/installation/) proporciona los comandos de Linux, la configuración de inicio adicional que Aspose.Slides.NET necesita en Linux, y los pasos para Visual Studio.

## **Paso 3: Crear su primera presentación**

El [inicio rápido en la página principal de Aspose.Slides for .NET](/slides/es/net/#your-first-presentation) es un programa de consola completo: añade un cuadro de texto a una diapositiva y guarda la presentación como un archivo PPTX. [Crear presentaciones](/slides/es/net/create-presentation/) explica los mismos pasos con más detalle y muestra cómo abrir una presentación existente y guardarla en otro formato.

## **Paso 4: Continuar con tareas comunes**

- [Abrir una presentación](/slides/es/net/open-presentation/)
- [Guardar una presentación](/slides/es/net/save-presentation/)
- [Convertir una presentación a PDF](/slides/es/net/convert-powerpoint-to-pdf/)
- [Renderizar diapositivas como imágenes](/slides/es/net/convert-slide/)
- [Editar texto de la presentación](/slides/es/net/manage-text/)
- [Ejemplos por elemento de diapositiva](/slides/es/net/examples/)

## **Evaluar y licenciar**

Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua a cada diapositiva que guarda y trunca el texto leído de las presentaciones.

- [Evaluar Aspose.Slides](/slides/es/net/evaluate-aspose-slides/) describe las limitaciones de la evaluación y cómo solicitar una licencia temporal.
- [Licenciamiento](/slides/es/net/licensing/) muestra cómo aplicar una licencia desde un archivo, un flujo o un recurso incrustado.
- [Licenciamiento por consumo](/slides/es/net/metered-licensing/) cubre la licencia facturada por uso.
- [Formatos de archivo compatibles](/slides/es/net/supported-file-formats/) enumera los formatos que Aspose.Slides puede cargar y guardar.

## **Obtener ayuda**

[Soporte del producto](/slides/es/net/product-support/) explica cómo hacer una pregunta en el [foro de soporte gratuito](https://forum.aspose.com/c/slides/11) y qué incluir al informar de un problema.

## **Preguntas frecuentes**

**¿Necesito tener Microsoft PowerPoint instalado?**

No. Aspose.Slides lee y escribe los archivos de presentación por sí mismo y no utiliza PowerPoint, por lo que también se ejecuta en servidores y en Linux.

**¿Qué paquete debo usar para una aplicación .NET Framework?**

Aspose.Slides.NET. Incluye compilaciones para .NET Framework 4.6.2 y posteriores, .NET 6 y posteriores, y .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform requiere .NET 6 o posterior.