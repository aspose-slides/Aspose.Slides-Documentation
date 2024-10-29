---
title: PPT vs PPTX
type: docs
weight: 10
url: /es/php-java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lee sobre las diferencias entre PPT y PPTX en Aspose.Slides."
---


## **¿Qué es PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) es un formato de archivo binario, es decir, es imposible ver su contenido sin herramientas especiales. Las primeras versiones de PowerPoint 97-2003 trabajaban con el formato de archivo PPT, sin embargo, su expandibilidad es limitada. 
## **¿Qué es PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) es un nuevo formato de archivo de presentación, basado en el estándar Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX es un conjunto archivado de archivos XML y de medios. El formato PPTX es fácilmente expandable. Por ejemplo, es fácil agregar soporte para un nuevo tipo de gráfico o tipo de forma, sin cambiar el formato PPTX en cada nueva versión de PowerPoint. El formato PPTX se utiliza a partir de PowerPoint 2007.
## **PPT vs PPTX**
Aunque PPTX proporciona una funcionalidad mucho más amplia, PPT sigue siendo bastante popular. La necesidad de convertir de PPT a PPTX y viceversa es muy demandada.

Sin embargo, la conversión entre el antiguo formato PPT y el nuevo formato PPTX es el desafío más complicado entre otros formatos de Microsoft Office. Aunque la especificación del formato PPT está abierta, es difícil trabajar con ella. PowerPoint puede crear partes especiales (MetroBlob) en los archivos PPT para almacenar información de PPTX que no es compatible con el formato PPT y que no puede mostrarse en las versiones antiguas de PowerPoint. Esta información puede ser restaurada cuando un archivo PPT se carga en una versión moderna de PowerPoint o se convierte al formato PPTX.

Aspose.Slides proporciona una interfaz común para trabajar con todos los formatos de presentación. Permite convertir de PPT a PPTX y de PPTX a PPT de una manera muy simple. Aspose.Slides admite completamente la conversión de PPT a PPTX y también admite la conversión de PPTX a PPT con algunas restricciones. Recomendamos usar el formato PPTX siempre que sea posible.

{{% alert color="primary" %}} 

Verifica la calidad de las conversiones de PPT a PPTX y de PPTX a PPT con la [**aplicación de conversión Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```php
  # Instancia un objeto Presentation que representa un archivo PPT
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # Guardando la presentación PPT en formato PPTX
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Lee más sobre [**Cómo convertir presentaciones de PPT a PPTX**.](/slides/es/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 