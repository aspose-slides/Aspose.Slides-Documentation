---
title: PPT vs PPTX
type: docs
weight: 10
url: /es/nodejs-java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lea sobre las diferencias entre PPT y PPTX en Aspose.Slides."
---

## **¿Qué es PPT?**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) es un formato de archivo binario, es decir, es imposible ver su contenido sin herramientas especiales. Las primeras versiones de PowerPoint 97-2003 trabajaban con el formato de archivo PPT, sin embargo su expandibilidad es limitada.  

## **¿Qué es PPTX?**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) es un nuevo formato de archivo de presentación, basado en el estándar Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX es un conjunto archivado de archivos XML y de medios. El formato PPTX es fácilmente ampliable. Por ejemplo, es sencillo añadir soporte para un nuevo tipo de gráfico o forma, sin cambiar el formato PPTX en cada nueva versión de PowerPoint. El formato PPTX se usa a partir de PowerPoint 2007.  

## **PPT vs PPTX**

Aunque PPTX ofrece una funcionalidad mucho más amplia, PPT sigue siendo bastante popular. La necesidad de convertir de PPT a PPTX y viceversa es muy demandada.  

Sin embargo, la conversión entre el antiguo formato PPT y el nuevo formato PPTX es el desafío más complicado entre los demás formatos de Microsoft Office. Aunque la especificación del formato PPT es abierta, resulta difícil trabajar con ella. PowerPoint puede crear partes especiales (MetroBlob) en archivos PPT para almacenar información de PPTX que no es compatible con el formato PPT y que no puede mostrarse en versiones antiguas de PowerPoint. Esta información puede restaurarse cuando un archivo PPT se carga en una versión moderna de PowerPoint o se convierte al formato PPTX.  

Aspose.Slides proporciona una clase común para trabajar con todos los formatos de presentación. Permite convertir de PPT a PPTX y de PPTX a PPT de forma muy sencilla. Aspose.Slides admite completamente la conversión de PPT a PPTX y también admite la conversión de PPTX a PPT con algunas restricciones. Recomendamos usar el formato PPTX siempre que sea posible.  

{{% alert color="primary" %}} 

Comprueba la calidad de las conversiones de PPT a PPTX y de PPTX a PPT con la [**aplicación de conversión Aspose.Slides**](https://products.aspose.app/slides/conversion/).  

{{% /alert %}} 
```javascript
// Instanciar un objeto Presentation que representa un archivo PPT
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // Guardar la presentación PPT en formato PPTX
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Lea más [**Cómo convertir presentaciones PPT a PPTX**.](/slides/es/nodejs-java/convert-ppt-to-pptx/)  
{{% /alert %}} 

## **FAQ**

**¿Tiene sentido mantener presentaciones antiguas en PPT si se abren sin errores?**

Si una presentación se abre de manera fiable y no necesita colaboración ni funciones más recientes, puede conservarse en PPT. Pero para garantizar la compatibilidad futura y la extensibilidad, es mejor [convertir a PPTX](/slides/es/nodejs-java/convert-ppt-to-pptx/): el formato se basa en el estándar abierto OOXML y es más fácilmente compatible con herramientas modernas.  

**¿Cómo decidir qué archivos son críticos para convertir a PPTX primero?**

Convierta primero las presentaciones que: sean editadas por varias personas; contengan gráficos [charts](/slides/es/nodejs-java/create-chart/) o formas [shapes](/slides/es/nodejs-java/shape-manipulations/) complejas; se usen en comunicaciones externas; o generen advertencias al [abrirse](/slides/es/nodejs-java/open-presentation/).  

**¿Se conservará la protección con contraseña al convertir de PPT a PPTX y viceversa?**

La protección con contraseña solo se mantiene con una conversión correcta y con soporte de cifrado en la herramienta utilizada. Es más fiable [eliminar la protección](/slides/es/nodejs-java/password-protected-presentation/), [convertir](/slides/es/nodejs-java/convert-ppt-to-pptx/), y luego volver a aplicar la protección según la política de seguridad.  

**¿Por qué algunos efectos desaparecen o se simplifican al convertir PPTX nuevamente a PPT?**

Porque PPT no admite algunos objetos o propiedades más recientes. PowerPoint y otras herramientas pueden almacenar "rastros" de esa información en bloques especiales para su restauración posterior, pero las versiones antiguas de PowerPoint no pueden renderizarlos.