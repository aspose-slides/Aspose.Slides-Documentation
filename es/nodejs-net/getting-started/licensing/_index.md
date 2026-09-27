---
title: Licencias
description: "Aplica un archivo de licencia a Aspose.Slides for Node.js via .NET, consulta los límites de la versión de evaluación y obtén una licencia temporal gratuita de 30 días para pruebas."
type: docs
weight: 80
url: /es/nodejs-net/licensing/
---
## **Visión general**

Aspose.Slides for Node.js via .NET es un paquete npm tanto para evaluación como para producción. Sin una licencia, se ejecuta en modo de evaluación. Después de comprar una licencia, o obtener una licencia temporal gratuita de 30 días, la aplicas con unas pocas líneas de código y las limitaciones de evaluación dejan de aplicarse.

{{% alert color="info" title="Nota" %}}

Las políticas generales sobre cómo evaluar, licenciar y comprar productos Aspose se recogen en [Políticas de compra y FAQ](https://purchase.aspose.com/policies). Los precios aparecen en la página de [Información de precios](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

## **Limitaciones de la versión de evaluación**

La versión de evaluación proporciona la funcionalidad completa del producto, con dos limitaciones:

- **Marca de agua.** Cada diapositiva de cada presentación que guardes recibe una marca de agua de evaluación: un cuadro de texto bloqueado en el centro de la diapositiva que dice "Evaluation only". La misma marca de agua se dibuja en las exportaciones a PDF, XPS y HTML y en las imágenes de diapositivas.
- **Texto truncado.** El texto que tu código recupera de un marco de texto, párrafo o porción se corta a sus primeros cinco caracteres, seguido del aviso "... text has been truncated due to evaluation version limitation." Las exportaciones a Markdown y HTML5 se truncan de la misma manera. El texto que tu código escribe se guarda completo.

[Evaluar Aspose.Slides](/slides/es/nodejs-net/evaluate-aspose-slides/) describe ambas limitaciones en detalle e incluye un script que las muestra.

{{% alert color="success" title="Consejo" %}}

Para probar Aspose.Slides sin las limitaciones de evaluación, solicita una **licencia temporal gratuita de 30 días**. Consulta [¿Cómo obtener una licencia temporal?](https://purchase.aspose.com/temporary-license) para más detalles.

{{% /alert %}}

## **Acerca de la licencia**

La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada y la fecha de vencimiento de la suscripción. El archivo está firmado digitalmente, por lo que no debe modificarse: incluso un salto de línea adicional añadido por error lo invalida.

## **Aplicar una licencia**

Aplica la licencia con el método `setLicense` de la clase `License`. Llámalo una vez por proceso, antes de crear cualquier objeto `Presentation`. Llamarlo de nuevo no causa daño, pero repite trabajo que ya se ha realizado.

El siguiente script aplica una licencia desde un archivo llamado `Aspose.Slides.lic`. Sustituye el nombre por el nombre o la ruta completa de tu archivo de licencia; el archivo puede tener cualquier nombre.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Un nombre de archivo o ruta relativa se resuelve respecto a la carpeta actual, la desde la que ejecutas `node`. Mantén el archivo de licencia en la carpeta de tu proyecto y ejecuta tus scripts desde allí, o pasa la ruta completa.

Si el archivo no se encuentra, o no es una licencia válida, `setLicense` lanza un error, y Aspose.Slides permanece en modo de evaluación. El script captura el error y muestra su mensaje. Para un archivo ausente, el mensaje comienza con `License "Aspose.Slides.lic" doesn't exist or access is restricted.` y enumera cada ubicación que se buscó.

En este paquete, una licencia se aplica únicamente desde un archivo. `License` no acepta un flujo, y el paquete no expone licencias basadas en consumo. Para la clase que envuelve el paquete, consulta [License](https://reference.aspose.com/slides/net/aspose.slides/license/) en la referencia de API de Aspose.Slides para .NET.