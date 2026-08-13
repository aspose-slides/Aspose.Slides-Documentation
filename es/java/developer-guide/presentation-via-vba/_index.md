---
title: Gestionar proyectos VBA en presentaciones usando Java
linktitle: Presentación mediante VBA
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
description: "Descubra cómo generar y manipular presentaciones PowerPoint y OpenDocument mediante VBA con Aspose.Slides para Java y optimizar su flujo de trabajo."
---
## **Introducción**

Aspose.Slides proporciona clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Nota" color="warning" %}} 

Cuando convierte una presentación que contiene macros a otro formato de archivo (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando añade macros a una presentación o vuelve a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides ** nunca ** ejecuta las macros en una presentación.

{{% /alert %}}

## **Añadir macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/es/java/com.aspose.slides/vbaproject/) para permitirle crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puede utilizar la interfaz [IVbaProject](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivbaproject/) para gestionar VBA incrustado en una presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).
1. Utilice el constructor [VbaProject](https://reference.aspose.com/slides/es/java/com.aspose.slides/vbaproject/#VbaProject--) para añadir un nuevo proyecto VBA.
1. Añada un módulo al VbaProject.
1. Establezca el código fuente del módulo.
1. Añada referencias a <stdole>.
1. Añada referencias a **Microsoft Office**.
1. Asocie las referencias con el proyecto VBA.
1. Guarde la presentación.

Este código Java muestra cómo añadir una macro VBA desde cero a una presentación:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Puede que le interese probar **Aspose** [Macro Remover](https://products.aspose.app/slides/es/remove-macros), una aplicación web gratuita que sirve para eliminar macros de documentos PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Utilizando la propiedad [VbaProject](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getVbaProject--) de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation), puede eliminar una macro VBA.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation) y cargue la presentación que contiene la macro.
1. Acceda al módulo de la macro y elimínelo.
1. Guarde la presentación modificada.

Este código Java muestra cómo eliminar una macro VBA:

```java
import com.aspose.slides.*;

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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation) y cargue la presentación que contiene la macro.
2. Verifique si la presentación contiene un proyecto VBA.
3. Recorra todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código Java muestra cómo extraer macros VBA de una presentación que contiene macros:

```java
import com.aspose.slides.*;

// Carga la presentación que contiene la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Comprueba si la Presentación contiene un proyecto VBA
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

Utilizando el método [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) puede determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y cargue una presentación que contenga una macro.
2. Verifique si la presentación contiene un [VBA project](https://reference.aspose.com/slides/es/java/com.aspose.slides/vbaproject/).
3. Compruebe si el proyecto VBA está protegido con contraseña para ver sus propiedades.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Comprueba si la presentación contiene un proyecto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### ¿Qué ocurre con las macros si guardo la presentación como PPTX?

Las macros se eliminarán porque PPTX no admite VBA. Para conservar las macros, elija PPTM, PPSM o POTM.

### ¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

### ¿Se admite trabajar con controles ActiveX vinculados a código VBA?

Sí, puede acceder a los [ActiveX controls](/slides/es/java/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.