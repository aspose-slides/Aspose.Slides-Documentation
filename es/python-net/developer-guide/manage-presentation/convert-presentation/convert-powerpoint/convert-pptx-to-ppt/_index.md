---
title: Convertir PPTX a PPT en Python
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/python-net/convert-pptx-to-ppt/
keywords:
- PPTX a PPT
- convertir PPTX a PPT
- convertir PowerPoint
- convertir presentación
- Python
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para Python mediante .NET—garantice una compatibilidad perfecta con los formatos de PowerPoint mientras conserva el diseño y la calidad de su presentación."
---

## **Visión general**

Aspose.Slides para Python le permite convertir presentaciones PPTX modernas al formato PPT heredado completamente mediante código. Abra un PPTX y expórtelo como PPT manteniendo el contenido y el diseño de la presentación, haciendo que el resultado sea compatible con versiones anteriores de PowerPoint. El mismo flujo de trabajo puede producir otros resultados, como PDF, XPS, ODP, HTML o imágenes, por lo que se integra fácilmente en scripts, canalizaciones CI y procesamiento por lotes.

## **Convertir PPTX a PPT**

Para convertir un PPTX a PPT, simplemente pase el nombre de archivo y el formato de guardado al método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El ejemplo en Python a continuación convierte una presentación de PPTX a PPT usando las opciones predeterminadas.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
presentation = slides.Presentation("presentation.pptx")

# Guardar la presentación como un archivo PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (por ejemplo, ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, use un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configure protection/encryption settings](/slides/es/python-net/password-protected-presentation/) para el PPT guardado.

**Ver también:**
- [Convertir PPT y PPTX a PDF en Python | Opciones avanzadas](/slides/es/python-net/convert-powerpoint-to-pdf/)
- [Convertir presentaciones de PowerPoint a XPS en Python](/slides/es/python-net/convert-powerpoint-to-xps/)
- [Convertir presentaciones de PowerPoint a HTML en Python](/slides/es/python-net/convert-powerpoint-to-html/)
- [Convertir diapositivas de PowerPoint a PNG en Python](/slides/es/python-net/convert-powerpoint-to-png/)