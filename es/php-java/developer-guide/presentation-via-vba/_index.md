---
title: Gestionar proyectos VBA en presentaciones con PHP
linktitle: Presentación vía VBA
type: docs
weight: 250
url: /es/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Descubra cómo generar y manipular presentaciones PowerPoint y OpenDocument mediante VBA con Aspose.Slides para PHP mediante Java para optimizar su flujo de trabajo."
---

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando añades macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Añadir macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) para permitir crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes utilizar la interfaz [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) para gestionar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Utiliza el constructor [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) para añadir un nuevo proyecto VBA.
3. Añade un módulo al VbaProject.
4. Establece el código fuente del módulo.
5. Añade referencias a <stdole>.
6. Añade referencias a **Microsoft Office**.
7. Asocia las referencias con el proyecto VBA.
8. Guarda la presentación.

Este código PHP muestra cómo añadir una macro VBA desde cero a una presentación:
```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Crea un nuevo proyecto VBA
    $pres->setVbaProject(new VbaProject());
    # Añade un módulo vacío al proyecto VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Establece el código fuente del módulo
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Crea una referencia a <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Crea una referencia a Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Añade referencias al proyecto VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Guarda la presentación
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Puede que quieras probar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), una aplicación web gratuita que se utiliza para eliminar macros de documentos de PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Utilizando la propiedad [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
2. Accede al módulo Macro y elimínalo.
3. Guarda la presentación modificada.

Este código PHP muestra cómo eliminar una macro VBA:
```php
  # Carga la presentación que contiene la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Accede al módulo Vba y lo elimina
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Guarda la presentación
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Extraer macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
2. Comprueba si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código PHP muestra cómo extraer macros VBA de una presentación que contiene macros:
```php
  # Carga la presentación que contiene la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Comprueba si la presentación contiene un proyecto VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Comprobar si un proyecto VBA está protegido con contraseña**

Utilizando el método [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected), puedes determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga una presentación que contiene una macro.
2. Comprueba si la presentación contiene un [proyecto VBA](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. Comprueba si el proyecto VBA está protegido con contraseña para ver sus propiedades.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Comprueba si la presentación contiene un proyecto VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **Preguntas frecuentes**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para conservar las macros, elige PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puedes acceder a los [controles ActiveX](/slides/es/php-java/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.