---
title: Administrar proyectos VBA en presentaciones usando Java
linktitle: Presentación vía VBA
type: docs
weight: 250
url: /es/java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- añadir macro
- eliminar macro
- extraer macro
- añadir VBA
- eliminar VBA
- extraer VBA
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo generar y manipular presentaciones de PowerPoint y OpenDocument mediante VBA con Aspose.Slides para Java y optimizar su flujo de trabajo."
---

{{% alert title="Note" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se trasladan al archivo resultante).

Cuando añades macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) para gestionar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Utiliza el constructor [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) para agregar un nuevo proyecto VBA.
1. Añade un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Añade referencias a <stdole>.
1. Añade referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código Java te muestra cómo agregar una macro VBA desde cero a una presentación:
```java
// Crea una instancia de la clase de presentación
Presentation pres = new Presentation();
try {
    // Crea un nuevo proyecto VBA
    pres.setVbaProject(new VbaProject());
    
    // Añade un módulo vacío al proyecto VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Establece el código fuente del módulo
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Crea una referencia a <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Crea una referencia a Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Añade referencias al proyecto VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Guarda la presentación
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Quizás quieras probar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), que es una aplicación web gratuita utilizada para eliminar macros de documentos PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) bajo la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y carga la presentación que contiene la macro.
1. Accede al módulo Macro y elimínalo.
1. Guarda la presentación modificada.

Este código Java te muestra cómo eliminar una macro VBA:
```java
// Carga la presentación que contiene la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Accede al módulo Vba y lo elimina 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Guarda la presentación
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Extraer macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código Java te muestra cómo extraer macros VBA de una presentación que contiene macros:
```java
// Carga la presentación que contiene la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Verifica si la presentación contiene un proyecto VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Comprobar si un proyecto VBA está protegido con contraseña**

Usando el método [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) puedes determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga una presentación que contenga una macro.
2. Verifica si la presentación contiene un [VBA project](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/).
3. Comprueba si el proyecto VBA está protegido con contraseña para ver sus propiedades.
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Compruebe si la presentación contiene un proyecto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para conservarlas, elige PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puedes acceder a los [ActiveX controls](/slides/es/java/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.