---
title: Presentación mediante VBA
type: docs
weight: 250
url: /es/nodejs-java/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, añadir macro, eliminar macro, añadir VBA, eliminar VBA, extraer macro, extraer VBA, macro PowerPoint, presentación PowerPoint, Java, Aspose.Slides para Node.js mediante Java"
description: "Añadir, eliminar y extraer macros VBA en presentaciones PowerPoint en JavaScript"
---

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando añades macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la clase [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) para administrar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Usa el constructor [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) para añadir un nuevo proyecto VBA.
1. Añade un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Añade referencias a <stdole>.
1. Añade referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código JavaScript muestra cómo añadir una macro VBA desde cero a una presentación:
```javascript
// Crea una instancia de la clase Presentation
let pres = new aspose.slides.Presentation();
try {
    // Crea un nuevo proyecto VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Añade un módulo vacío al proyecto VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Establece el código fuente del módulo
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Crea una referencia a <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Crea una referencia a Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Añade referencias al proyecto VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Guarda la presentación
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Puede que quieras probar el **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), una aplicación web gratuita utilizada para eliminar macros de documentos PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
1. Accede al módulo de la macro y elimínalo.
1. Guarda la presentación modificada.

Este código JavaScript muestra cómo eliminar una macro VBA:
```javascript
// Carga la presentación que contiene la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Accede al módulo Vba y lo elimina
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Guarda la presentación
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Extraer macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código JavaScript muestra cómo extraer macros VBA de una presentación que contiene macros:
```javascript
// Carga la presentación que contiene la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Comprueba si la presentación contiene un proyecto VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Comprobar si un proyecto VBA está protegido con contraseña**

Usando el método [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), puedes determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y carga una presentación que contiene una macro.
2. Verifica si la presentación contiene un [VBA project](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/).
3. Comprueba si el proyecto VBA está protegido con contraseña para ver sus propiedades.
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Comprueba si la presentación contiene un proyecto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**¿Qué pasa con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para mantener las macros, elige PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación, por ejemplo, para actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puedes acceder a los [ActiveX controls](/slides/es/nodejs-java/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.