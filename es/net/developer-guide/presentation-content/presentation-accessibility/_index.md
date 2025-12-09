---
title: Gestionar la accesibilidad de presentaciones en .NET
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/net/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Automatice la verificación de la accesibilidad de presentaciones en archivos PPT, PPTX y ODP con Aspose.Slides para .NET—mejore la experiencia del lector de pantalla y aumente el cumplimiento."
---

## **Visión General**

La accesibilidad de presentaciones asegura que las personas que utilizan tecnologías de asistencia—como lectores de pantalla, pantallas Braille o navegación solo con teclado—puedan comprender y navegar sus diapositivas tan eficazmente como las audiencias videntes que usan ratón. Las buenas prácticas se enfocan en un orden de lectura claro, texto alternativo significativo para elementos visuales informativos, suficiente contraste de color, tipografía legible, texto descriptivo en los enlaces y evitar transmitir significado únicamente mediante color o posición. Cuando la accesibilidad se planifica desde el principio, el resultado es una estructura más limpia, visuales más consistentes y contenido que llega a cada espectador sin soluciones alternativas.

## **Marcar como decorativo**

Marcar como decorativo indica que los elementos visuales son puramente ornamentales, de modo que los lectores de pantalla los omiten, reduciendo el ruido y manteniendo el foco en el contenido significativo. Aplíquese a fondos, adornos y separadores—nunca a gráficos, íconos o imágenes que transmitan información. Aspose.Slides expone esta señal para la detección y validación, permitiendo comprobaciones automáticas de accesibilidad y limpieza.

![Marcar como decorativo](mark_as_decorative.png)

El siguiente ejemplo de código muestra cómo determinar si una forma está marcada como decorativa.
```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```
