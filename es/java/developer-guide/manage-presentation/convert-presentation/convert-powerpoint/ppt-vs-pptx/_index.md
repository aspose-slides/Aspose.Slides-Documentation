---
title: PPT vs PPTX
type: docs
weight: 10
url: /java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lee sobre las diferencias entre PPT y PPTX en Aspose.Slides."
---

## **¿Qué es PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) es un formato de archivo binario, es decir, es imposible ver su contenido sin herramientas especiales. Las primeras versiones de PowerPoint 97-2003 trabajaban con el formato de archivo PPT; sin embargo, su expansibilidad es limitada.
## **¿Qué es PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) es un nuevo formato de archivo de presentación, basado en el estándar Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX es un conjunto archivado de archivos XML y multimedia. El formato PPTX es fácilmente ampliable. Por ejemplo, es fácil agregar soporte para un nuevo tipo de gráfico o tipo de forma, sin cambiar el formato PPTX en cada nueva versión de PowerPoint. El formato PPTX se utiliza desde PowerPoint 2007.
## **PPT vs PPTX**
Aunque PPTX proporciona una funcionalidad mucho más amplia, PPT sigue siendo bastante popular. La necesidad de convertir de PPT a PPTX y viceversa es altamente demandada.

Sin embargo, la conversión entre el antiguo formato PPT y el nuevo formato PPTX es el desafío más complicado entre otros formatos de Microsoft Office. Aunque la especificación del formato PPT es abierta, es difícil trabajar con él. PowerPoint puede crear partes especiales (MetroBlob) en los archivos PPT para almacenar información de PPTX que no es compatible con el formato PPT y que no se puede mostrar en las versiones antiguas de PowerPoint. Esta información puede ser restaurada cuando un archivo PPT se carga en una versión moderna de PowerPoint o se convierte al formato PPTX.

Aspose.Slides proporciona una interfaz común para trabajar con todos los formatos de presentación. Permite convertir de PPT a PPTX y de PPTX a PPT de manera muy simple. Aspose.Slides admite completamente la conversión de PPT a PPTX y también admite la conversión de PPTX a PPT con algunas restricciones. Recomendamos usar el formato PPTX siempre que sea posible.

{{% alert color="primary" %}} 

Verifique la calidad de las conversiones de PPT a PPTX y de PPTX a PPT con la aplicación de conversión en línea [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Guardar la presentación PPT en formato PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Lee más sobre [**Cómo convertir presentaciones PPT a PPTX**.](/slides/java/convert-ppt-to-pptx/)
{{% /alert %}} 