---
title: Flash
type: docs
weight: 10
url: /es/nodejs-java/flash/
description: Extracción de objetos Flash de presentaciones PowerPoint usando JavaScript
---

## **Extraer objetos Flash de la presentación**

Aspose.Slides para Node.js a través de Java ofrece una funcionalidad para extraer objetos flash de una presentación. Puede acceder al control flash por nombre y extraerlo de la presentación, incluyendo el almacenamiento de datos de objetos SWF.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Qué formatos de presentación son compatibles al extraer contenido Flash?**

[Aspose.Slides soporta](/slides/es/nodejs-java/supported-file-formats/) los principales formatos de PowerPoint como PPT y PPTX, ya que puede cargar estos contenedores y acceder a sus controles, incluidos los elementos ActiveX relacionados con Flash.

**¿Puedo convertir una presentación con Flash a HTML5 y conservar la interactividad de Flash?**

No. Aspose.Slides no ejecuta contenido SWF ni convierte su interactividad. Aunque la exportación a [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/es/nodejs-java/export-to-html5/) está soportada, Flash no se reproducirá en los navegadores modernos debido al fin del soporte. La ruta recomendada es reemplazar Flash por alternativas como video o animaciones HTML5 antes de la exportación.

**Desde una perspectiva de seguridad, ¿Aspose.Slides ejecuta archivos SWF al leer una presentación?**

No. Aspose.Slides trata Flash como datos binarios incrustados en el archivo y no ejecuta contenido SWF durante el procesamiento.

**¿Cómo debo manejar presentaciones que incluyen Flash junto con otros archivos incrustados a través de OLE?**

Aspose.Slides soporta [extraer objetos OLE incrustados](/slides/es/nodejs-java/manage-ole/), por lo que puede procesar todo el contenido incrustado relacionado en un solo paso, manejando los controles Flash y otros documentos incrustados mediante OLE juntos.