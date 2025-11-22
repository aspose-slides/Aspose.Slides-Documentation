---
title: Secuencia de selección de fuentes en C#
linktitle: Secuencia de selección de fuentes en C#
type: docs
weight: 80
url: /es/net/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: Secuencia de selección de fuentes de PowerPoint en C#
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se sustituyen — vea [**Reemplazo de fuentes**](https://docs.aspose.com/slides/net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/net/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides usa una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han definido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/net/custom-font/). 

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas a través del [administrador de fuentes](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), para que puedas decidir si [incrustas](/slides/es/net/embedded-font/), [reemplazas](/slides/es/net/font-replacement/) o agregas [fuentes externas](/slides/es/net/custom-font/). Esto ayuda a prevenir sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito un cambio de fuente silencioso a una fuente inadecuada cuando falta un glifo?**

Define con antelación [reglas de reemplazo de fuentes](/slides/es/net/font-replacement/) y [reglas de retroceso de fuentes](/slides/es/net/fallback-font/). Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.